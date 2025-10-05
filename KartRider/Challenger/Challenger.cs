using System;
using System.Threading;
using Extreme;
using KartRider.IO;

namespace KartRider.Challenger;

public static class Challenger
{
	public static void Complete_Challenger()
	{
		new Thread((ThreadStart)delegate
		{
			for (byte b = 1; b <= 40; b++)
			{
				string text = "41 04 A0 3C 07 59 AC 20 00 00 00 00 00 89 03";
				string text2 = "6F 6D 57 00 78 F9 64 1A 40 9B 09 01 0C 41 8B 1D 04 00 00 00 14 F2 18 00 53 F6 61 00 5A 51 CC AD 0C 41 8B 1D 2C F2 18 00 DD D8 C6 00 5A 51 CC AD CC AD 71 18 14 64 71 18 14 64";
				string text3 = "16 00 00 00 53 02 00 00 00 00 53 24 92 93 92 DF E1 17 53 DB 55 9C 14 D7 C9 20";
				string text4 = "71 4B B2 B3 26 B5 70 89 29 E9 9B B3 63 70 70 89 BA 62 BE 69 70 70 7C 7C BA 7C BA 7C C7 4D BA 7C B3 86 34 9D 1F B3 BA 52 7F CE BA 92 5A D7 BA 68 89 CE BA 1A 28 D7 BA 7C F0 B1 65 AB DC B1 BA 7C 8F 86 BA 7C 8F 86 1B 1B 35 09 1B 1B 35 09 1B 1B 35 09 BA C0 A0 CE BA 7C F6 09 A3 33 FD C9 A2 FC 3F F1 BA 09 2A CE BA 68 5E CE BA 62 B7 CE BA 09 43 CE BA 7C 11 CE BA 52 BC CE 0F 7D 87 B3 48 EA 52 B3 BA 7C 11 D7 BA 52 3B D7 BA 52 7F CE E2 82 39 CE 71 4B CD B3 BA BA 7C 99 B3 65 AB C6 B3 BA 6A 7C 70 89 EA 7C 70 89 1B 1B 90 B3 BA 7C C7 4D BA BA BA BA BA BA A2 FC B4 F1 A2 FC B4 F1 1B 1B 35 09 BA 7C 8F B3 BA 7C 70 89 BA 7C 70 89 BA 7C 70 89 BA 7C 7E 69 BA 7C 7E 4D BA BA 7C 70 89 BA 7C 7E 69 BA 7C 7E 69 BA 7C 7E 4D";
				OutPacket val = new OutPacket("PqCompleteChallenger");
				try
				{
					val.WriteShort((short)b);
					val.WriteShort((short)0);
					val.WriteByte((byte)0);
					val.WriteShort((short)0);
					val.WriteShort((short)0);
					val.WriteByte((byte)1);
					val.WriteHexString(text);
					RouterListener.MySession.SKey.GenNew(0);
					RouterListener.MySession.SKey.Encode(val);
					val.WriteInt(0);
					val.WriteHexString(text2);
					val.WriteHexString(text4);
					val.WriteHexString(text3);
					RouterListener.MySession.Server.Send(val);
				}
				finally
				{
					((IDisposable)val)?.Dispose();
				}
				OutPacket val2 = new OutPacket("PqCompleteChallenger");
				try
				{
					val2.WriteShort((short)b);
					val2.WriteShort((short)0);
					val2.WriteByte((byte)0);
					val2.WriteShort((short)1);
					val2.WriteShort((short)0);
					val2.WriteByte((byte)2);
					val2.WriteHexString(text);
					RouterListener.MySession.SKey.GenNew(0);
					RouterListener.MySession.SKey.Encode(val2);
					val2.WriteInt(0);
					val2.WriteHexString(text2);
					val2.WriteHexString(text4);
					val2.WriteHexString(text3);
					RouterListener.MySession.Server.Send(val2);
				}
				finally
				{
					((IDisposable)val2)?.Dispose();
				}
				OutPacket val3 = new OutPacket("PqCompleteChallenger");
				try
				{
					val3.WriteShort((short)b);
					val3.WriteShort((short)0);
					val3.WriteByte((byte)0);
					val3.WriteShort((short)2);
					val3.WriteShort((short)0);
					val3.WriteByte((byte)4);
					val3.WriteHexString(text);
					RouterListener.MySession.SKey.GenNew(0);
					RouterListener.MySession.SKey.Encode(val3);
					val3.WriteInt(0);
					val3.WriteHexString(text2);
					val3.WriteHexString(text4);
					val3.WriteHexString(text3);
					RouterListener.MySession.Server.Send(val3);
				}
				finally
				{
					((IDisposable)val3)?.Dispose();
				}
				Console.WriteLine(b);
				Thread.Sleep(300);
			}
		}).Start();
	}
}
