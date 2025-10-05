using System;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using KartNew.Utilities;
using KartRider.Common.Utilities;

namespace KartRider.IO;

public class OutPacket : PacketBase, IDisposable
{
    private MemoryStream m_stream;

    private bool m_disposed;

    public override int Length => (int)m_stream.Position;

    public override int Position
    {
        get
        {
            return (int)m_stream.Position;
        }
        set
        {
            m_stream.Position = value;
        }
    }

    public bool Disposed => m_disposed;

    public OutPacket(int size = 64)
    {
        m_stream = new MemoryStream(size);
        m_disposed = false;
    }

    public OutPacket(string rttiVal)
        : this()
    {
        WriteUInt(Adler32Helper.GenerateAdler32(Encoding.ASCII.GetBytes(rttiVal)));
    }

    private void Append(long value, int byteCount)
    {
        for (int i = 0; i < byteCount; i++)
        {
            m_stream.WriteByte((byte)value);
            value >>= 8;
        }
    }

    public void WriteTime(DateTime time)
    {
        WriteTime((time == DateTime.MinValue) ? (-1) : time.Ticks);
    }

    public void WriteTime(long ticks)
    {
        if (ticks == -1)
        {
            WriteShort(-1);
            WriteShort(0);
            return;
        }

        DateTime time = new DateTime(ticks);
        int num = TimeUtil.GetDays(time) - 1;
        WriteShort((short)num);
        WriteShort((short)(time.Second / 4 + time.Minute * 15 + time.Hour * 900));
    }

    public void WriteBool(bool value)
    {
        ThrowIfDisposed();
        WriteByte((byte)(value ? 1 : 0));
    }

    public void WriteEncFloat(float value)
    {
        WriteBytes(CryptoConstants.encryptBytes(BitConverter.GetBytes(value)));
    }

    public void WriteEncInt(int value)
    {
        WriteBytes(CryptoConstants.encryptBytes(BitConverter.GetBytes(value)));
    }

    public void WriteEncUInt(uint value)
    {
        WriteBytes(CryptoConstants.encryptBytes(BitConverter.GetBytes(value)));
    }

    public void WriteEncByte(byte value)
    {
        WriteBytes(CryptoConstants.encryptBytes(new byte[1] { value }));
    }

    public void WriteByte(byte value = 0)
    {
        ThrowIfDisposed();
        m_stream.WriteByte(value);
    }

    public void WriteSByte(sbyte value = 0)
    {
        WriteByte((byte)value);
    }

    public void WriteBytes(params byte[] value)
    {
        ThrowIfDisposed();
        m_stream.Write(value, 0, value.Length);
    }

    public void WriteShort(short value = 0)
    {
        ThrowIfDisposed();
        Append(value, 2);
    }

    public void WriteUShort(ushort value = 0)
    {
        WriteShort((short)value);
    }

    public void WriteInt(int value = 0)
    {
        ThrowIfDisposed();
        Append(value, 4);
    }

    public void WriteFloat(float value = 0f)
    {
        WriteBytes(BitConverter.GetBytes(value));
    }

    public void WriteUInt(uint value = 0u)
    {
        WriteInt((int)value);
    }

    public void WriteLong(long value = 0L)
    {
        ThrowIfDisposed();
        Append(value, 8);
    }

    public void WriteULong(ulong value = 0uL)
    {
        WriteLong((long)value);
    }

    public void WriteString(string value)
    {
        if (value == null)
        {
            throw new ArgumentNullException("value");
        }

        WriteInt(value.Length);
        WriteString(value, value.Length);
    }

    public void WriteString(string value, int length)
    {
        if (value == null || length < 0 || length > value.Length)
        {
            throw new ArgumentNullException("value");
        }

        byte[] bytes = Encoding.Unicode.GetBytes(value);
        int i;
        for (i = 0; i < value.Length && i < length; i++)
        {
            int num = i * 2;
            WriteByte(bytes[num]);
            WriteByte(bytes[num + 1]);
        }

        for (; i < length; i++)
        {
            WriteShort(0);
        }
    }

    public void WriteHexString(string value)
    {
        if (value == null)
        {
            throw new ArgumentNullException("value");
        }

        value = value.Replace(" ", "");
        for (int i = 0; i < value.Length; i += 2)
        {
            WriteByte(byte.Parse(value.Substring(i, 2), NumberStyles.HexNumber));
        }
    }

    public void WriteEndPoint(IPEndPoint endpoint)
    {
        if (endpoint == null)
        {
            WriteInt();
            WriteUShort(0);
        }
        else
        {
            WriteEndPoint(endpoint.Address, (ushort)endpoint.Port);
        }
    }

    public void WriteEndPoint(IPAddress ip, ushort port)
    {
        WriteBytes(ip.GetAddressBytes());
        WriteUShort(port);
    }

    private void ThrowIfDisposed()
    {
        if (m_disposed)
        {
            throw new ObjectDisposedException(GetType().FullName);
        }
    }

    public override byte[] ToArray()
    {
        ThrowIfDisposed();
        return m_stream.ToArray();
    }

    public new void Dispose()
    {
        m_disposed = true;
        if (m_stream != null)
        {
            m_stream.Dispose();
        }

        m_stream = null;
    }
}