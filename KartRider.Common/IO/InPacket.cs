using System;
using System.Net;
using System.Text;
using KartNew.Utilities;

namespace KartRider.IO;

public class InPacket : PacketBase
{
    private byte[] _buffer;

    private int _index;

    public override int Position
    {
        get
        {
            return _index;
        }
        set
        {
            _index = value;
        }
    }

    public override int Length => _buffer.Length;

    public int Available => _buffer.Length - _index;

    public InPacket(byte[] packet)
    {
        _buffer = packet;
        _index = 0;
    }

    public override void Dispose()
    {
        _buffer = null;
    }

    private void CheckLength(int length)
    {
        if (_index + length > _buffer.Length || length < 0)
        {
            throw new PacketReadException("Not enough space");
        }
    }

    public bool ReadBool()
    {
        return ReadByte() == 1;
    }

    public byte ReadByte()
    {
        CheckLength(1);
        return _buffer[_index++];
    }

    public sbyte ReadSByte()
    {
        return (sbyte)ReadByte();
    }

    public byte ReadEncodedByte()
    {
        return CryptoConstants.decodeBytes(new byte[1] { ReadByte() })[0];
    }

    public int ReadEncodedInt()
    {
        return BitConverter.ToInt32(CryptoConstants.decodeBytes(new byte[4]
        {
            ReadByte(),
            ReadByte(),
            ReadByte(),
            ReadByte()
        }), 0);
    }

    public uint ReadEncodedUInt()
    {
        return BitConverter.ToUInt32(CryptoConstants.decodeBytes(new byte[4]
        {
            ReadByte(),
            ReadByte(),
            ReadByte(),
            ReadByte()
        }), 0);
    }

    public float ReadEncodedFloat()
    {
        return BitConverter.ToSingle(CryptoConstants.decodeBytes(new byte[4]
        {
            ReadByte(),
            ReadByte(),
            ReadByte(),
            ReadByte()
        }), 0);
    }

    public byte[] ReadBytes(int count)
    {
        CheckLength(count);
        byte[] array = new byte[count];
        Buffer.BlockCopy(_buffer, _index, array, 0, count);
        _index += count;
        return array;
    }

    public unsafe short ReadShort()
    {
        CheckLength(2);
        short result;
        fixed (byte* ptr = _buffer)
        {
            result = *(short*)(ptr + _index);
        }

        _index += 2;
        return result;
    }

    public ushort ReadUShort()
    {
        return (ushort)ReadShort();
    }

    public unsafe int ReadInt()
    {
        CheckLength(4);
        int result;
        fixed (byte* ptr = _buffer)
        {
            result = *(int*)(ptr + _index);
        }

        _index += 4;
        return result;
    }

    public unsafe float ReadFloat()
    {
        CheckLength(4);
        float result;
        fixed (byte* ptr = _buffer)
        {
            result = *(float*)(ptr + _index);
        }

        _index += 4;
        return result;
    }

    public uint ReadUInt()
    {
        return (uint)ReadInt();
    }

    public unsafe long ReadLong()
    {
        CheckLength(8);
        long result;
        fixed (byte* ptr = _buffer)
        {
            result = *(long*)(ptr + _index);
        }

        _index += 8;
        return result;
    }

    public ulong ReadULong()
    {
        return (ulong)ReadLong();
    }

    public string ReadString(bool ascii = false)
    {
        int num = ReadInt();
        if (!ascii)
        {
            num *= 2;
        }

        CheckLength(num);
        if (ascii)
        {
            return Encoding.ASCII.GetString(ReadBytes(num));
        }

        return Encoding.Unicode.GetString(ReadBytes(num));
    }

    public string ReadShortString(bool ascii = true)
    {
        int num = ReadShort();
        if (!ascii)
        {
            num *= 2;
        }

        CheckLength(num);
        if (ascii)
        {
            return Encoding.ASCII.GetString(ReadBytes(num));
        }

        return Encoding.Unicode.GetString(ReadBytes(num));
    }

    public void Skip(int count)
    {
        CheckLength(count);
        _index += count;
    }

    public override byte[] ToArray()
    {
        byte[] array = new byte[_buffer.Length];
        Buffer.BlockCopy(_buffer, 0, array, 0, _buffer.Length);
        return array;
    }

    public IPEndPoint ReadEndPoint()
    {
        return new IPEndPoint(new IPAddress(ReadBytes(4)), ReadUShort());
    }

    public DateTime ReadTime()
    {
        ushort num = ReadUShort();
        ushort num2 = ReadUShort();
        if (num == ushort.MaxValue)
        {
            return DateTime.MinValue;
        }

        uint num3 = (uint)(num * 21600 + num2);
        int date = (int)(num3 / 21600);
        int year = TimeUtil.GetYear(ref date) + 1900;
        int month = TimeUtil.GetMonth(ref date, TimeUtil.IsLeapYear(year)) + 1;
        int hour = (int)(num3 % 21600 / 900);
        int minute = (int)(num3 % 21600 % 900 / 15);
        int second = (int)(4 * (num3 % 21600 % 900 % 15));
        return new DateTime(year, month, date, hour, minute, second);
    }
}