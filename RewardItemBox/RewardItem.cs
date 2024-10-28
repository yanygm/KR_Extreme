using KartRider.IO;

namespace RewardItemBox;

public class RewardItem
{
	public uint AcquireTime { get; set; }

	public uint ExpireTime { get; set; }

	public byte AcquireType { get; set; }

	public ulong SN { get; set; }

	public int StockId { get; set; }

	public RewardItem(InPacket iPacket)
	{
		SN = iPacket.ReadULong();
		AcquireType = iPacket.ReadByte();
		StockId = iPacket.ReadInt();
		AcquireTime = iPacket.ReadUInt();
		ExpireTime = iPacket.ReadUInt();
	}
}
