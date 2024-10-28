using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using KartRider.Common.Security;
using KartRider.Common.Utilities;
using KartRider.IO;

namespace KartRider.Common.Network2;

public abstract class Session
{
	private readonly Socket _socket;

	public uint _RIV;

	public uint _SIV;

	private const int DEFAULT_SIZE = 65536;

	private byte[] mBuffer = new byte[65536];

	private byte[] mSharedBuffer = new byte[65536];

	private int mCursor = 0;

	public int mDisconnected = 0;

	private LockFreeQueue<ByteArraySegment> mSendSegments = new LockFreeQueue<ByteArraySegment>();

	private int mSending = 0;

	private string _label;

	public string Label => _label;

	private SocketAsyncEventArgs mReadEventArgs { get; set; }

	private SocketAsyncEventArgs mWriteEventArgs { get; set; }

	public Socket Socket => _socket;

	public Session(Socket socket)
	{
		_socket = socket;
		mWriteEventArgs = new SocketAsyncEventArgs
		{
			DisconnectReuseSocket = false
		};
		mWriteEventArgs.Completed += delegate(object s, SocketAsyncEventArgs a)
		{
			EndSend(a);
		};
		WaitForData();
	}

	public void Append(byte[] pBuffer)
	{
		Append(pBuffer, 0, pBuffer.Length);
	}

	public void Append(byte[] pBuffer, int pStart, int pLength)
	{
		try
		{
			if (mBuffer.Length - mCursor < pLength)
			{
				int num;
				for (num = mBuffer.Length * 2; num < mCursor + pLength; num *= 2)
				{
				}
				Array.Resize(ref mBuffer, num);
			}
			Buffer.BlockCopy(pBuffer, pStart, mBuffer, mCursor, pLength);
			mCursor += pLength;
		}
		catch (Exception)
		{
		}
	}

	public void BeginReceive()
	{
		if (mDisconnected == 0 && _socket.Connected)
		{
			try
			{
				_socket.BeginReceive(mSharedBuffer, 0, 65536, SocketFlags.None, EndReceive, _socket);
				return;
			}
			catch
			{
				Disconnect();
				return;
			}
		}
		Disconnect();
	}

	private void BeginSend()
	{
		ByteArraySegment next = mSendSegments.Next;
		try
		{
			if (next == null)
			{
				mSendSegments.Dequeue();
				return;
			}
			if (next.Buffer.Length >= next.Length)
			{
				byte[] buffer = next.Buffer;
				byte[] array = new byte[buffer.Length + ((_SIV != 0) ? 8 : 4)];
				if (_SIV != 0)
				{
					uint num = KRPacketCrypto.HashEncrypt(buffer, (uint)buffer.Length, _SIV);
					Buffer.BlockCopy(BitConverter.GetBytes((int)(_SIV ^ (buffer.Length + 4) ^ 0xF834A608u)), 0, array, 0, 4);
					Buffer.BlockCopy(BitConverter.GetBytes(_SIV ^ num ^ 0xC9F84A90u), 0, array, array.Length - 4, 4);
					_SIV += 21446425u;
					if (_SIV == 0)
					{
						_SIV = 1u;
					}
				}
				else
				{
					Buffer.BlockCopy(BitConverter.GetBytes(buffer.Length), 0, array, 0, 4);
				}
				Buffer.BlockCopy(buffer, 0, array, 4, buffer.Length);
				mWriteEventArgs.SetBuffer(array, 0, array.Length);
				next = null;
				try
				{
					if (!Socket.SendAsync(mWriteEventArgs))
					{
						EndSend(mWriteEventArgs);
					}
					return;
				}
				catch (ObjectDisposedException ex)
				{
					Console.WriteLine("[SOCKET ERR] {0}", ex.ToString());
					Disconnect();
					return;
				}
			}
			Console.WriteLine("[SOCKET ERR] Tried to send a packet that has a bufferlength value that is lower than the length: {0} {1}", next.Buffer.Length, next.Length);
			mSendSegments.Dequeue();
		}
		catch (Exception ex2)
		{
			Console.WriteLine("[SOCKET ERR] {0}", ex2.ToString());
			Disconnect();
		}
	}

	public void Disconnect()
	{
		if (Interlocked.CompareExchange(ref mDisconnected, 1, 0) == 0)
		{
			OnDisconnect();
			try
			{
				Socket.Shutdown(SocketShutdown.Both);
				Socket.Close();
			}
			catch
			{
			}
			mWriteEventArgs.Completed -= delegate(object s, SocketAsyncEventArgs a)
			{
				EndSend(a);
			};
			mWriteEventArgs.Dispose();
			mWriteEventArgs = null;
		}
	}

	private void EndReceive(IAsyncResult ar)
	{
		//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a8: Expected O, but got Unknown
		if (mDisconnected != 0)
		{
			return;
		}
		try
		{
			int num = 0;
			try
			{
				num = _socket.EndReceive(ar);
			}
			catch
			{
				Disconnect();
				return;
			}
			if (num > 0)
			{
				Append(mSharedBuffer, 0, num);
				while (mCursor >= 4)
				{
					uint num2 = BitConverter.ToUInt32(mBuffer, 0);
					if (_RIV != 0)
					{
						num2 = _RIV ^ num2 ^ 0xF834A608u;
					}
					if (mCursor < num2 + 4)
					{
						break;
					}
					byte[] array = new byte[num2];
					Buffer.BlockCopy(mBuffer, 4, array, 0, (int)num2);
					if (_RIV != 0)
					{
						int num3 = (int)(num2 - 4);
						if ((_RIV ^ BitConverter.ToUInt32(array, num3) ^ 0xC9F84A90u) != KRPacketCrypto.HashDecrypt(array, (uint)num3, _RIV))
						{
							Console.WriteLine("Different checksum while decrypting");
						}
						_RIV += 21446425u;
						if (_RIV == 0)
						{
							_RIV = 1u;
						}
					}
					mCursor = (int)(mCursor - (num2 + 4));
					if (mCursor > 0)
					{
						Buffer.BlockCopy(mBuffer, (int)(num2 + 4), mBuffer, 0, mCursor);
					}
					if (mDisconnected == 0)
					{
						InPacket val = new InPacket(array);
						try
						{
							OnPacket(val);
						}
						finally
						{
							((IDisposable)val)?.Dispose();
						}
						continue;
					}
					return;
				}
				BeginReceive();
			}
			else
			{
				Disconnect();
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.ToString());
			Disconnect();
		}
	}

	private void EndSend(SocketAsyncEventArgs pArguments)
	{
		if (mDisconnected != 0)
		{
			return;
		}
		try
		{
			if (pArguments.BytesTransferred > 0)
			{
				if (mSendSegments.Next.Advance(pArguments.BytesTransferred))
				{
					mSendSegments.Dequeue();
				}
				if (mSendSegments.Next == null)
				{
					mSending = 0;
				}
				else
				{
					BeginSend();
				}
			}
			else
			{
				if (pArguments.SocketError != 0)
				{
					Console.WriteLine("Send Error: {0}", pArguments.SocketError);
				}
				Console.WriteLine("Disconnected session 1 {0}", pArguments.SocketError.ToString());
				Disconnect();
			}
		}
		catch
		{
			Disconnect();
		}
	}

	public string GetRemoteAddress()
	{
		try
		{
			return ((IPEndPoint)_socket.RemoteEndPoint).Address.ToString();
		}
		catch
		{
			return "";
		}
	}

	public IPEndPoint GetRemoteEndPoint()
	{
		try
		{
			return (IPEndPoint)_socket.RemoteEndPoint;
		}
		catch
		{
			return new IPEndPoint(0L, 0);
		}
	}

	public abstract void OnDisconnect();

	public abstract void OnPacket(InPacket inPacket);

	public void Send(OutPacket pPacket)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected O, but got Unknown
		try
		{
			if (mDisconnected == 0)
			{
				mSendSegments.Enqueue(new ByteArraySegment(((PacketBase)pPacket).ToArray(), true));
				if (Interlocked.CompareExchange(ref mSending, 1, 0) == 0)
				{
					BeginSend();
				}
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine("Disconnected session 11 {0}", ex.ToString());
			Disconnect();
		}
	}

	public void SendRaw(byte[] pBuffer)
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		if (mDisconnected == 0)
		{
			mSendSegments.Enqueue(new ByteArraySegment(pBuffer, false));
			if (Interlocked.CompareExchange(ref mSending, 1, 0) == 0)
			{
				BeginSend();
			}
		}
	}

	public void WaitForData()
	{
		BeginReceive();
	}
}
