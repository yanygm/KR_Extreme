using System;
using KartRider;
using KartRider.IO;

namespace Extreme;

public class SessionKey
{
	public uint a;

	public uint b;

	public uint c;

	public uint d;

	public uint e;

	public uint f;

	public uint g;

	public void Decode(InPacket iPacket)
	{
		a = iPacket.ReadEncodedUInt();
		b = iPacket.ReadEncodedUInt();
		c = iPacket.ReadEncodedUInt();
		d = iPacket.ReadEncodedUInt();
		e = iPacket.ReadEncodedUInt();
		f = iPacket.ReadEncodedUInt();
		g = iPacket.ReadEncodedUInt();
	}

	public void Encode(OutPacket oPacket)
	{
		oPacket.WriteEncUInt(a);
		oPacket.WriteEncUInt(b);
		oPacket.WriteEncUInt(c);
		oPacket.WriteEncUInt(d);
		oPacket.WriteEncUInt(e);
		oPacket.WriteEncUInt(f);
		oPacket.WriteEncUInt(g);
	}

	public void GenNew(int baseTick = -1)
	{
		a = 0u;
		uint key = CryptoConstants.GetKey(a);
		b = key ^ 0xCC511046u;
		b = key ^ 0xCC511046u;
		c = key ^ 0xFFu;
		d = CryptoConstants.GetKey(key + 1);
		e = CryptoConstants.GetKey(key + 2);
		f = CryptoConstants.GetKey(key + 3);
		OutPacket val = new OutPacket(64);
		val.WriteTime(DateTime.Now);
		byte[] array = ((PacketBase)val).ToArray();
		g = BitConverter.ToUInt32(new byte[4]
		{
			array[2],
			array[3],
			array[0],
			array[1]
		}, 0);
		val.Dispose();
	}
}
