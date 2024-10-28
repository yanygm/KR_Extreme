using System;
using System.Collections.Generic;
using System.Net.Sockets;
using KartRider;
using KartRider.Common.Add;
using KartRider.Common.Security;
using KartRider.Common.Utilities;
using KartRider.IO;
using RewardItemBox;

namespace Extreme;

public class SessionGroup
{
	public UdpSession UDPAddr = new UdpSession();

	public UdpSession P2PAddr = new UdpSession();

	public UdpSession ServerRelay1 = new UdpSession();

	public UdpSession ServerRelay2 = new UdpSession();

	public List<UdpSession> ClientRelay = new List<UdpSession>();

	public object m_lock = new object();

	public List<uint> PlaneSets = new List<uint>();

	public List<byte> PlaneSets2 = new List<byte>();

	public int SendPlaneCount = 6;

	public int TotalSendPlaneCount = 6;

	public int PlaneCheckMax = 0;

	public int GameReportCut = 0;

	public byte[] PlaneHexArray2 = HexEncoding.GetBytes("F6 9F 6A F8 8D E3 4A");

	public int SendCount = 0;

	public byte PlaneCheck1 = 0;

	public bool GoalIn = true;

	public int TimeAttackMyTicks = 0;

	public int TimeAttackStartTicks = 0;

	public bool GameReport = true;

	public uint GameTrack = 0u;

	public List<short> KartItems = new List<short>();

	public byte[] Return_Packet = null;

	public List<RewardItem> RewardBox = new List<RewardItem>();

	public bool RequestRewardBox = false;

	public static string RiderName = "";

	public static string Fishing;

	public static int RaceTime;

	public static int SaveRaceTime;

	public static string AFKBlockCatch1;

	public static string AFKBlockCatch2;

	public static string LoginData;

	public static int Stock;

	public static uint RiderUid;

	public static uint Lucci;

	public static int RP;

	public static byte GameType;

	public static int RoomMaster;

	public static string RoomName;

	public static int min;

	public static int sec;

	public static int mil;

	public int AiMasterSlot { get; set; } = -1;


	public int AISlot { get; set; } = -1;


	public ClientSession Client { get; set; }

	public List<Tuple<short, short>> Enchants { get; set; }

	public List<int> FishTicks { get; set; } = new List<int>();


	public int[] FishValues { get; set; }

	public static string GuildName { get; set; }

	public List<Item> Items { get; set; }

	public KartSpec KartSpec { get; set; }

	public int MasterSlot { get; set; } = -1;


	public ServerSession Server { get; set; }

	public SessionKey SKey { get; set; }

	public SessionKey SKey2 { get; set; }

	public int TimeAttackCheckVal { get; set; }

	public static int TimeAttack_StartTicks { get; set; }

	public static string UserID { get; set; }

	public static uint UserNO { get; set; }

	public static uint Track { get; set; }

	public SessionGroup(Socket clientSocket, Socket serverSocket)
	{
		Client = new ClientSession(this, clientSocket);
		Server = new ServerSession(this, serverSocket);
		Items = new List<Item>();
		Enchants = new List<Tuple<short, short>>();
		SKey = new SessionKey();
		SKey2 = new SessionKey();
		KartSpec = new KartSpec();
		FishValues = new int[11];
	}

	public void SendGetRewardBox()
	{
		if (RewardBox.Count > 0)
		{
			RewardItem rewardItem = RewardBox[0];
			RewardBox.RemoveAt(0);
			Console.WriteLine("SpRqReceiveRewardItemPacket: {0}", rewardItem.StockId);
			OutPacket val = new OutPacket("SpRqReceiveRewardItemPacket");
			try
			{
				val.WriteULong(rewardItem.SN);
				val.WriteInt(rewardItem.StockId);
				Server.Send(val);
				return;
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
		}
		OutPacket val2 = new OutPacket("SpRqGetRewardBoxListPacket");
		try
		{
			val2.WriteULong(0uL);
			Server.Send(val2);
		}
		finally
		{
			((IDisposable)val2)?.Dispose();
		}
	}

	public void Send_GoalIn()
	{
		if (GoalIn)
		{
			return;
		}
		GoalIn = true;
		bool flag = byte.Parse(Program.RouterFormDlg.tx_AutoLaps.Text) == 1;
		int num = int.Parse(Program.RouterFormDlg.tx_Laps.Text);
		OutPacket val = new OutPacket("GameControlPacket");
		try
		{
			val.WriteInt(2);
			val.WriteBool(false);
			int num2 = Environment.TickCount - Server.game_myRealStartTick - 7000;
			if (RouterForm.GameRaceMacro)
			{
				if (GameType == 17)
				{
					val.WriteUInt(30000u);
				}
				else
				{
					val.WriteInt(SuspiciousRaceCheck.RaceTime);
				}
			}
			else if (RouterForm.GameRaceTime)
			{
				val.WriteInt(RaceTime - 1);
			}
			else
			{
				val.WriteInt(num2);
			}
			val.WriteUInt(0u);
			if (flag)
			{
				val.WriteEncInt(num);
			}
			else if (!flag)
			{
				val.WriteEncInt(SuspiciousRaceCheck.Laps + 1);
			}
			val.WriteBool(true);
			SKey.GenNew(0);
			SKey.Encode(val);
			int sendPlaneCount = SendPlaneCount;
			val.WriteInt(sendPlaneCount);
			for (int i = 0; i < 6; i++)
			{
				val.WriteInt(0);
			}
			val.WriteInt(0);
			for (int j = 0; j < 3; j++)
			{
				val.WriteInt(0);
			}
			for (int k = 0; k < sendPlaneCount; k++)
			{
				PlaneCheck1 = (byte)CryptoConstants.GetKey((uint)PlaneCheck1);
				val.WriteByte(PlaneCheck1);
			}
			SendPlaneCount -= sendPlaneCount;
			for (int l = sendPlaneCount; l < 10; l++)
			{
				val.WriteByte((byte)0);
			}
			KartSpec.Encode(val, encodeOriginal: true);
			val.WriteHexString("16 00 00 00 53 02 00 00 00 00 53 24 92 93 92 DF E1 17 53 DB 55 9C 14 D7 C9 20");
			val.WriteInt(0);
			val.WriteInt(0);
			val.WriteInt(0);
			val.WriteInt(0);
			val.WriteInt(0);
			val.WriteInt(0);
			val.WriteInt(0);
			val.WriteInt(0);
			val.WriteUInt(1679038577u);
			val.WriteEncInt((num2 + 8000) / 9000);
			val.WriteEncByte((byte)0);
			Server.Send(val);
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	public void Send_Report()
	{
		if (RouterForm.VersusModeMacro)
		{
			Console.WriteLine("RaceTime: {0}", Environment.TickCount - Server.game_myRealStartTick - 7000);
		}
		OutPacket val = new OutPacket("GameReportPacket");
		try
		{
			OutPacket val2 = new OutPacket(4);
			val2.WriteTime(DateTime.Now);
			byte[] array = KREncodedBlock.Encode(((PacketBase)val2).ToArray(), (KREncodedBlock.EncodeFlag)2, (uint?)2242368262u);
			val.WriteInt(array.Length);
			val.WriteBytes(array);
			val.WriteInt(0);
			val.WriteInt(0);
			val.WriteEncInt(0);
			for (int i = 0; i < 20; i++)
			{
				val.WriteEncInt(0);
				val.WriteEncInt(0);
				val.WriteEncInt(0);
			}
			val.WriteEncInt(0);
			val.WriteEncInt(0);
			val.WriteEncInt(1);
			val.WriteEncFloat(0f);
			val.WriteEncFloat(0f);
			val.WriteEncFloat(99999f);
			int num = 0;
			if (Program.Randomizer.Next(100) < 90)
			{
				num++;
			}
			if (Program.Randomizer.Next(100) < 70)
			{
				num++;
			}
			if (Program.Randomizer.Next(100) < 50)
			{
				num++;
			}
			num = Math.Min(SendPlaneCount, num);
			val.WriteInt(num);
			val.WriteBytes(new byte[20]);
			val.WriteInt(0);
			val.WriteBytes(new byte[16]);
			for (int j = 0; j < num; j++)
			{
				PlaneCheck1 = (byte)CryptoConstants.GetKey((uint)PlaneCheck1);
				val.WriteByte(PlaneCheck1);
			}
			SendPlaneCount -= num;
			for (int k = num; k < 10; k++)
			{
				val.WriteByte((byte)0);
			}
			val.WriteFloat(1f);
			val.WriteFloat(0f);
			val.WriteEncByte((byte)1);
			Server.Send(val);
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}
}
