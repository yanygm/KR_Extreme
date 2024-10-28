using System;
using System.Threading;
using KartRider.IO;

namespace Extreme;

public static class GameSupport
{
	public static void Send_FirstRequest()
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		OutPacket val = new OutPacket("GrFirstRequestPacket");
		try
		{
			RouterListener.MySession.Server.Send(val);
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	public static void Send_GameStart()
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		OutPacket val = new OutPacket("GameControlPacket");
		try
		{
			val.WriteInt(0);
			val.WriteByte((byte)1);
			val.WriteBytes(new byte[75]);
			val.WriteUInt(1679038577u);
			val.WriteInt(0);
			val.WriteByte((byte)0);
			RouterListener.MySession.Server.Send(val);
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	public static void Send_GameRoomStart()
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		OutPacket val = new OutPacket("GrRequestStartPacket");
		try
		{
			val.WriteInt(0);
			RouterListener.MySession.Server.Send(val);
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	public static void Send_AddLucci()
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		byte b = 133;
		int num = 1000;
		OutPacket val = new OutPacket("LoRqAddLucciPacket");
		try
		{
			val.WriteByte(b);
			val.WriteInt(1000);
			RouterListener.MySession.Server.Send(val);
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
		Console.WriteLine("LoRqAddLucciPacket : Type: {0}, Lucci: {1}", b, num);
	}

	public static void Send_GameRoomReady()
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		OutPacket val = new OutPacket("GrRequestSetSlotStatePacket");
		try
		{
			val.WriteInt(3);
			RouterListener.MySession.Server.Send(val);
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	public static void Send_LeaveRoom()
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		OutPacket val = new OutPacket("ChLeaveRoomRequestPacket");
		try
		{
			val.WriteBool(true);
			RouterListener.MySession.Server.Send(val);
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	public static void Send_RoomKick()
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		for (int i = 0; i < 8; i++)
		{
			if (Program.MySlot != i)
			{
				OutPacket val = new OutPacket("GrRequestKickPacket");
				try
				{
					val.WriteInt(i);
					RouterListener.MySession.Server.Send(val);
				}
				finally
				{
					((IDisposable)val)?.Dispose();
				}
			}
		}
	}

	public static void ALL_Disconnect()
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		OutPacket val = new OutPacket("GameSlotPacket");
		try
		{
			val.WriteInt(Program.MySlot);
			val.WriteUInt(255u);
			val.WriteInt(9);
			val.WriteInt(4);
			val.WriteInt(-1);
			RouterListener.MySession.Server.Send(val);
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	public static void AutoRoomStartAndReady()
	{
		new Thread((ThreadStart)delegate
		{
			if (SessionGroup.RoomMaster == Program.MySlot)
			{
				Thread.Sleep(1000);
				Send_GameRoomStart();
			}
			else
			{
				Send_GameRoomReady();
			}
		}).Start();
	}

	public static void OnlyRoomMasterStart()
	{
		new Thread((ThreadStart)delegate
		{
			if (SessionGroup.RoomMaster == Program.MySlot)
			{
				Thread.Sleep(1000);
				Send_GameRoomStart();
			}
		}).Start();
	}
}
