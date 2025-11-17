using System;
using System.Net;
using System.Net.Sockets;
using KartRider.Common.Security;
using KartRider.IO;

namespace Extreme;

public sealed class UdpSession
{
	private Socket _socket;

	public const int SIO_UDP_CONNRESET = -1744830452;

	private byte[] _buffer = new byte[8192];

	private EndPoint _endPoint = new IPEndPoint(IPAddress.Any, 0);

	public int Port => ((IPEndPoint)_socket.LocalEndPoint).Port;

	public IPEndPoint RelayedEndPoint { get; set; }

	public IPEndPoint RelayedLocalEndPoint { get; set; }

	public IPEndPoint SocketEndPoint => (IPEndPoint)_socket.LocalEndPoint;

	public UdpSession()
	{
		_socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
		_socket.IOControl((IOControlCode)(-1744830452L), new byte[4], null);
		_socket.Bind(new IPEndPoint(IPAddress.Any, 0));
		BeginReceive();
	}

	private void BeginReceive()
	{
		try
		{
			_socket.BeginReceiveFrom(_buffer, 0, _buffer.Length, SocketFlags.None, ref _endPoint, EndReceive, null);
		}
		catch
		{
			BeginReceive();
		}
	}

	public void BeginSend(byte[] inData, IPEndPoint endPoint)
	{
		byte[] array = new byte[inData.Length + 8];
		uint num = (uint)new Random((int)DateTime.Now.Ticks).Next();
		uint num2 = KRPacketCrypto.HashEncrypt(inData, (uint)inData.Length, num);
		Buffer.BlockCopy(BitConverter.GetBytes(num), 0, array, 0, 4);
		Buffer.BlockCopy(BitConverter.GetBytes(num ^ num2 ^ 0x4F3816C3u), 0, array, array.Length - 4, 4);
		Buffer.BlockCopy(inData, 0, array, 4, inData.Length);
		try
		{
			_socket.BeginSendTo(array, 0, array.Length, SocketFlags.None, endPoint, EndSend, null);
			Console.WriteLine($"Udp-Send: {BitConverter.ToString(array)}");
		}
		catch
		{
			Console.WriteLine("Packet loss! BeginSend");
		}
	}

	public void Close()
	{
		try
		{
			_socket.Close();
		}
		catch
		{
		}
	}

	private void EndReceive(IAsyncResult iar)
	{
		try
		{
			EndPoint endPoint = new IPEndPoint(IPAddress.Any, 0);
			int num = _socket.EndReceiveFrom(iar, ref endPoint);
			if (!IsSameIPEP((IPEndPoint)endPoint, RelayedEndPoint))
			{
				RelayedLocalEndPoint = (IPEndPoint)endPoint;
			}
			if (num >= 16)
			{
				uint num2 = BitConverter.ToUInt32(_buffer, 0);
				uint num3 = BitConverter.ToUInt32(_buffer, num - 4);
				byte[] array = new byte[num - 8];
				Buffer.BlockCopy(_buffer, 4, array, 0, array.Length);
				if (KRPacketCrypto.HashDecrypt(array, (uint)array.Length, num2) == (num2 ^ 0x4F3816C3 ^ num3))
				{
					InPacket val = new InPacket(array);
					try
					{
						val.ReadUInt();
						val.ReadUInt();
						if (!IsSameIPEP((IPEndPoint)endPoint, RelayedEndPoint))
						{
							BeginSend(array, RelayedEndPoint);
						}
						else
						{
							BeginSend(array, RelayedLocalEndPoint);
						}
						Console.WriteLine($"Udp-Receive: {BitConverter.ToString(array)}");
					}
					finally
					{
						((IDisposable)val)?.Dispose();
					}
				}
				else
				{
					Console.WriteLine("CheckSum fail! EndReceive");
				}
			}
		}
		catch
		{
		}
		BeginReceive();
	}

	private void EndSend(IAsyncResult res)
	{
		try
		{
			_socket.EndSendTo(res);
		}
		catch
		{
			Console.WriteLine("Packet loss! EndSend");
		}
	}

	public static bool IsSameIPEP(IPEndPoint a, IPEndPoint b)
	{
		return a.Address.Equals(b.Address) && a.Port == b.Port;
	}
}
