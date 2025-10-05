using KartRider.IO;

namespace KartRider.Common.Add;

public class Item
{
	public short Amount { get; set; }

	public short expr1 { get; set; }

	public short expr2 { get; set; }

	public short ItemID { get; set; }

	public short SN { get; set; }

	public short Type { get; set; }

	public byte Unk2 { get; set; }

	public byte Unk3 { get; set; }

	public byte Unk4 { get; set; }

	public byte Unk5 { get; set; }

	public short Unk6 { get; set; }

	public Item(InPacket iPacket)
	{
		Type = iPacket.ReadShort();
		ItemID = iPacket.ReadShort();
		SN = iPacket.ReadShort();
		Amount = iPacket.ReadShort();
		Unk2 = iPacket.ReadByte();
		Unk3 = iPacket.ReadByte();
		expr1 = iPacket.ReadShort();
		expr2 = iPacket.ReadShort();
		Unk4 = iPacket.ReadByte();
		Unk5 = iPacket.ReadByte();
		Unk6 = iPacket.ReadShort();
	}

	public Item()
	{
	}

	public void Encode(OutPacket oPacket)
	{
		oPacket.WriteShort(Type);
		oPacket.WriteShort(ItemID);
		oPacket.WriteShort(SN);
		oPacket.WriteShort(Amount);
		oPacket.WriteByte(Unk2);
		oPacket.WriteByte(Unk3);
		oPacket.WriteShort(expr1);
		oPacket.WriteShort(expr2);
		oPacket.WriteByte(Unk4);
		oPacket.WriteByte(Unk5);
		oPacket.WriteShort(Unk6);
	}
}
