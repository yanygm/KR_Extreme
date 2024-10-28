using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using KartRider;
using KartRider.Common.Network;
using KartRider.Common.Utilities;
using KartRider.Data;
using KartRider.IO;
using KartRider.TrackName;

namespace Extreme;

public class ClientSession : Session
{
	public SessionGroup Parent { get; set; }

	public CheckState Unchecked { get; private set; }

	public ClientSession(SessionGroup parent, Socket socket)
		: base(socket)
	{
		Parent = parent;
	}

	public override void OnDisconnect()
	{
		Console.WriteLine("Client_Disconnected");
		Parent.Server.Disconnect();
		((Session)Parent.Client).Disconnect();
	}

	public override void OnPacket(InPacket iPacket)
	{
		lock (Parent.m_lock)
		{
			((PacketBase)iPacket).Position = 0;
			uint num = iPacket.ReadUInt();
			Console.WriteLine("Client-" + (PacketName)num + "£º" + BitConverter.ToString(iPacket.ToArray()).Replace("-", ""));
			if (num != Adler32Helper.GenerateAdler32(Encoding.ASCII.GetBytes("PcReportRaidOccur"), 0u) && num != Adler32Helper.GenerateAdler32(Encoding.ASCII.GetBytes("PqReportBadProcess"), 0u) && num != Adler32Helper.GenerateAdler32(Encoding.ASCII.GetBytes("PqModifiedClient"), 0u) && num != Adler32Helper.GenerateAdler32(Encoding.ASCII.GetBytes("PcReportMyBadAction"), 0u) && num != 1340475309)
			{
				if (num == Adler32Helper.GenerateAdler32_ASCII("PqCrackLogPacket", 0u))
				{
					int num2 = iPacket.ReadInt();
					int num3 = iPacket.ReadInt();
					int num4 = iPacket.ReadInt();
					byte b = iPacket.ReadByte();
					int num5 = iPacket.ReadInt();
					byte b2 = iPacket.ReadByte();
					string text = iPacket.ReadString(false);
					string text2 = iPacket.ReadString(false);
					string text3 = iPacket.ReadString(false);
					Console.WriteLine("[{0}] {1} {2} {3} {4} {5} {6} {7} {8} {9}", DateTime.Now, num2, num3, num4, b, num5, b2, text, text2, text3);
					using StreamWriter streamWriter = new StreamWriter("crackLog.txt", append: true);
					streamWriter.WriteLine("[{0}] {1} {2} {3} {4} {5} {6} {7} {8} {9}", DateTime.Now, num2, num3, num4, b, num5, b2, text, text2, text3);
					return;
				}
				if (num == Adler32Helper.GenerateAdler32_ASCII("RqReportAbnormal", 0u))
				{
					string arg = iPacket.ReadString(false);
					Console.WriteLine("[{0}] {1}", DateTime.Now, arg);
					using StreamWriter streamWriter2 = new StreamWriter("ReportAbnormal.txt", append: true);
					streamWriter2.WriteLine("[{0}] {1}", DateTime.Now, arg);
					return;
				}
				/*
				if (num == Adler32Helper.GenerateAdler32_ASCII("GameControlPacket", 0u))
				{
					OutPacket val = new OutPacket("GameControlPacket");
					try
					{
						int num6 = iPacket.ReadInt();
						val.WriteInt(num6);
						switch (num6)
						{
						case 0:
						{
							iPacket.ReadByte();
							val.WriteByte((byte)1);
							val.WriteBytes(iPacket.ReadBytes(75));
							uint num9 = iPacket.ReadUInt();
							val.WriteUInt(1679038577u);
							val.WriteBytes(iPacket.ReadBytes(5));
							break;
						}
						case 2:
						{
							Parent.GoalIn = true;
							val.WriteByte(iPacket.ReadByte());
							SessionGroup.SaveRaceTime = iPacket.ReadInt();
							val.WriteInt(SessionGroup.SaveRaceTime);
							val.WriteUInt(iPacket.ReadUInt());
							int num7 = iPacket.ReadEncodedInt();
							val.WriteEncInt(num7);
							val.WriteByte(iPacket.ReadByte());
							for (int i = 0; i < 7; i++)
							{
								val.WriteUInt(iPacket.ReadUInt());
							}
							if (Program.GameReport_Development)
							{
								Console.WriteLine("LAPS: {0}, TIME: {1}", num7, SessionGroup.SaveRaceTime);
								int num8 = iPacket.ReadInt();
								Parent.TotalSendPlaneCount += num8;
								Parent.GameReportCut++;
								Console.WriteLine("Cut:{0}\t  PlaneCheck: {1}     Total: {2}\t Max: {3}     Goalin", Parent.GameReportCut, num8, Parent.TotalSendPlaneCount, Parent.PlaneCheckMax);
								if (num8 > 4)
								{
									Console.WriteLine("Disconnect!!!!!!!");
								}
							}
							int sendPlaneCount = Parent.SendPlaneCount;
							val.WriteInt(sendPlaneCount);
							for (int j = 0; j < 6; j++)
							{
								val.WriteInt(0);
							}
							val.WriteInt(0);
							for (int k = 0; k < 3; k++)
							{
								val.WriteInt(0);
							}
							for (int l = 0; l < sendPlaneCount; l++)
							{
								Parent.PlaneCheck1 = (byte)CryptoConstants.GetKey((uint)Parent.PlaneCheck1);
								val.WriteByte(Parent.PlaneCheck1);
							}
							Parent.SendPlaneCount -= sendPlaneCount;
							for (int m = sendPlaneCount; m < 10; m++)
							{
								val.WriteByte((byte)0);
							}
							Parent.KartSpec.Encode(val, encodeOriginal: true);
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
							val.WriteEncInt(0);
							val.WriteEncByte((byte)0);
							break;
						}
						}
						Parent.Server.Send(val);
						return;
					}
					finally
					{
						((IDisposable)val)?.Dispose();
					}
				}
				*/
				if (num == Adler32Helper.GenerateAdler32_ASCII("GameReportPacket", 0u))
				{
					byte[] array = iPacket.ReadBytes(18);
					int num10 = iPacket.ReadInt();
					int num11 = iPacket.ReadInt();
					int num12 = iPacket.ReadEncodedInt();
					int[][] array2 = new int[20][];
					for (int n = 0; n < 20; n++)
					{
						array2[n] = new int[3];
						array2[n][0] = iPacket.ReadEncodedInt();
						array2[n][1] = iPacket.ReadEncodedInt();
						array2[n][2] = iPacket.ReadEncodedInt();
					}
					int num13 = iPacket.ReadEncodedInt();
					int num14 = iPacket.ReadEncodedInt();
					int num15 = iPacket.ReadEncodedInt();
					float num16 = iPacket.ReadEncodedFloat();
					float num17 = iPacket.ReadEncodedFloat();
					float num18 = iPacket.ReadEncodedFloat();
					int num19 = iPacket.ReadInt();
					byte[] array3 = iPacket.ReadBytes(20);
					int num20 = iPacket.ReadInt();
					byte[] array4 = iPacket.ReadBytes(16);
					byte[] array5 = iPacket.ReadBytes(10);
					float num21 = iPacket.ReadFloat();
					float num22 = iPacket.ReadFloat();
					byte b3 = iPacket.ReadEncodedByte();
					int num23 = 0;
					if (Program.Randomizer.Next(100) < 70)
					{
						num23++;
					}
					if (Program.Randomizer.Next(100) < 50)
					{
						num23++;
					}
					if (Program.Randomizer.Next(100) < 20)
					{
						num23++;
					}
					num23 = Math.Min(Parent.SendPlaneCount, num23);
					if (Program.GameReport_Development)
					{
						Parent.TotalSendPlaneCount += num19;
						Parent.GameReportCut++;
						Console.WriteLine("Cut:{0}\t  PlaneCheck: {1}     Total: {2}\t Max: {3}     Dist: {4}", Parent.GameReportCut, num19, Parent.TotalSendPlaneCount, Parent.PlaneCheckMax, num18);
					}
					else if (Program.ReportLog)
					{
						Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9} {10} {11} {12} {13} {14} {15} {16} {17} {18} {19}", array2[0][0], array2[1][0], array2[2][0], array2[3][0], array2[4][0], array2[5][0], array2[6][0], array2[7][0], array2[8][0], array2[9][0], array2[10][0], array2[11][0], array2[12][0], array2[13][0], array2[14][0], array2[15][0], array2[16][0], array2[17][0], array2[18][0], array2[19][0]);
						Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9} {10} {11} {12} {13} {14} {15} {16} {17} {18} {19}", array2[0][1], array2[1][1], array2[2][1], array2[3][1], array2[4][1], array2[5][1], array2[6][1], array2[7][1], array2[8][1], array2[9][1], array2[10][1], array2[11][1], array2[12][1], array2[13][1], array2[14][1], array2[15][1], array2[16][1], array2[17][1], array2[18][1], array2[19][1]);
						Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9} {10} {11} {12} {13} {14} {15} {16} {17} {18} {19}", array2[0][2], array2[1][2], array2[2][2], array2[3][2], array2[4][2], array2[5][2], array2[6][2], array2[7][2], array2[8][2], array2[9][2], array2[10][2], array2[11][2], array2[12][2], array2[13][2], array2[14][2], array2[15][2], array2[16][2], array2[17][2], array2[18][2], array2[19][2]);
						Console.WriteLine("{0} {1} {2} {3} {4} {5} {6}", num13, num14, num16, num17, num20, num21, num22);
						Console.WriteLine("PlaneCheck: {0}", num19);
						Console.WriteLine("PlaneCheckPwn: {0}", num23);
						Console.WriteLine("Status: {0}", b3);
						Console.WriteLine("dist: {0}", num18);
						if (!Parent.GameReport)
						{
							float num24 = Math.Min((float)(Environment.TickCount - Parent.Server.game_myRealStartTick - 7000) / 12.5f, 10000f) + (float)Program.Randomizer.NextDouble() + (float)Program.Randomizer.Next(20);
							int num25 = Environment.TickCount - Parent.Server.game_myRealStartTick - 7000;
							Console.WriteLine("distPwn: {0}", num24);
						}
					}
					else
					{
						Console.WriteLine("{0} {1} {2} {3}", num13, num14, num16, num17);
					}
					OutPacket val2 = new OutPacket("GameReportPacket");
					try
					{
						val2.WriteBytes(array);
						val2.WriteInt(0);
						val2.WriteInt(0);
						val2.WriteEncInt(0);
						for (int num26 = 0; num26 < 20; num26++)
						{
							val2.WriteEncInt(0);
							val2.WriteEncInt(0);
							val2.WriteEncInt(0);
						}
						val2.WriteEncInt(0);
						val2.WriteEncInt(0);
						val2.WriteEncInt(1);
						val2.WriteEncFloat(0f);
						val2.WriteEncFloat(0f);
						val2.WriteEncFloat(99999f);
						val2.WriteInt(num23);
						val2.WriteBytes(new byte[20]);
						val2.WriteInt(0);
						val2.WriteBytes(new byte[16]);
						for (int num27 = 0; num27 < num23; num27++)
						{
							Parent.PlaneCheck1 = (byte)CryptoConstants.GetKey((uint)Parent.PlaneCheck1);
							val2.WriteByte(Parent.PlaneCheck1);
						}
						Parent.SendPlaneCount -= num23;
						for (int num28 = num23; num28 < 10; num28++)
						{
							val2.WriteByte((byte)0);
						}
						val2.WriteFloat(1f);
						val2.WriteFloat(0f);
						val2.WriteEncByte(b3);
						Parent.Server.Send(val2);
						return;
					}
					finally
					{
						((IDisposable)val2)?.Dispose();
					}
				}
				if (num == Adler32Helper.GenerateAdler32_ASCII("PcReportStateInGame", 0u))
				{
					int num29 = iPacket.ReadEncodedInt();
					int num30 = iPacket.ReadEncodedInt();
					uint num31 = (uint)iPacket.ReadEncodedInt();
					uint num32 = (uint)iPacket.ReadEncodedInt();
					if (Program.ReportLog)
					{
						Console.WriteLine("PcReportStateInGame: {0} {1} {2} {3}", num29, num30, num31, num32);
					}
					OutPacket val3 = new OutPacket("PcReportStateInGame");
					try
					{
						val3.WriteEncInt(num29);
						val3.WriteEncInt(num30);
						int tick = Program.Tick;
						val3.WriteEncUInt(CryptoConstants.GetKey((uint)tick));
						val3.WriteEncUInt(CryptoConstants.GetKey((uint)(tick + 1)));
						Parent.Server.Send(val3);
						return;
					}
					finally
					{
						((IDisposable)val3)?.Dispose();
					}
				}
				if (num == Adler32Helper.GenerateAdler32_ASCII("SpRqLotteryPacket", 0u))
				{
					short num33 = iPacket.ReadShort();
					iPacket.ReadBool();
					int num34 = iPacket.ReadInt();
					Console.WriteLine("Id: {0}, Type: {1}", num33, num34);
				}
				else
				{
					if (num == Adler32Helper.GenerateAdler32_ASCII("ChClientUdpAddrPacket", 0u))
					{
						Parent.UDPAddr.RelayedEndPoint = iPacket.ReadEndPoint();
						Console.WriteLine("ChClientUdpAddrPacket : {0}, Local : {1}", Parent.UDPAddr.RelayedEndPoint, Parent.UDPAddr.SocketEndPoint);
						OutPacket val4 = new OutPacket("ChClientUdpAddrPacket");
						try
						{
							val4.WriteEndPoint(Parent.UDPAddr.RelayedEndPoint.Address, (ushort)Parent.UDPAddr.RelayedEndPoint.Port);
							Parent.Server.Send(val4);
							return;
						}
						finally
						{
							((IDisposable)val4)?.Dispose();
						}
					}
					if (num == Adler32Helper.GenerateAdler32_ASCII("ChClientP2pAddrPacket", 0u))
					{
						Parent.P2PAddr.RelayedEndPoint = iPacket.ReadEndPoint();
						Console.WriteLine("ChClientP2pAddrPacket : {0}, Local : {1}", Parent.P2PAddr.RelayedEndPoint, Parent.P2PAddr.SocketEndPoint);
						OutPacket val5 = new OutPacket("ChClientP2pAddrPacket");
						try
						{
							val5.WriteEndPoint(Parent.P2PAddr.RelayedEndPoint.Address, (ushort)Parent.P2PAddr.RelayedEndPoint.Port);
							Parent.Server.Send(val5);
							return;
						}
						finally
						{
							((IDisposable)val5)?.Dispose();
						}
					}
					if (num == Adler32Helper.GenerateAdler32_ASCII("LoRqDecLucciPacket", 0u) || num == Adler32Helper.GenerateAdler32_ASCII("LoRqUseItemPacket", 0u) || num == Adler32Helper.GenerateAdler32_ASCII("PqUseSpecialKit", 0u))
					{
						return;
					}
					if (num == Adler32Helper.GenerateAdler32_ASCII("LoRqDeleteItemPacket", 0u))
					{
						Console.WriteLine("LoRqDeleteItemPacket: {0}", ((object)iPacket).ToString());
						OutPacket val6 = new OutPacket("LoRpDeleteItemPacket");
						try
						{
							((Session)Parent.Client).Send(val6);
							return;
						}
						finally
						{
							((IDisposable)val6)?.Dispose();
						}
					}
					if (num == Adler32Helper.GenerateAdler32_ASCII("LoRqStartSinglePacket", 0u))
					{
						int timeAttackStartTicks = iPacket.ReadInt();
						Parent.TimeAttackStartTicks = timeAttackStartTicks;
						Parent.PlaneCheck1 = (byte)Parent.TimeAttackStartTicks;
						uint num35 = CryptoConstants.GetKey(CryptoConstants.GetKey((uint)Parent.TimeAttackStartTicks)) % 5 + 6;
						int num36 = (int)num35;
						Parent.SendPlaneCount = (int)num35;
						Parent.GameReport = true;
						if (Program.GameReport_Development)
						{
							Parent.TotalSendPlaneCount = 0;
							Parent.GameReportCut = 0;
							Parent.PlaneCheckMax = Parent.SendPlaneCount;
							Console.WriteLine("PlaneCheckMax: {0}", Parent.SendPlaneCount);
						}
					}
					else
					{
						if (num == Adler32Helper.GenerateAdler32_ASCII("PqStartTimeAttack", 0u))
						{
							int num37 = iPacket.ReadInt();
							int num38 = iPacket.ReadInt();
							uint num39 = iPacket.ReadUInt();
							TrackName trackName = (TrackName)num39;
							byte b4 = iPacket.ReadByte();
							byte b5 = iPacket.ReadByte();
							short num40 = iPacket.ReadShort();
							short num41 = iPacket.ReadShort();
							byte b6 = iPacket.ReadByte();
							int num42 = iPacket.ReadInt();
							int num43 = iPacket.ReadInt();
							byte b7 = iPacket.ReadByte();
							byte b8 = iPacket.ReadByte();
							byte b9 = iPacket.ReadByte();
							int num44 = iPacket.ReadInt();
							byte b10 = iPacket.ReadByte();
							Console.WriteLine("StartTimeAttack: SpeedType: {0}, Kart: {1}, FlyingPet: {2}, Track: {3}", b4, num40, num41, trackName);
							OutPacket val7 = new OutPacket("PqStartTimeAttack");
							try
							{
								val7.WriteInt(num37);
								val7.WriteInt(num38);
								val7.WriteUInt(num39);
								val7.WriteByte(b4);
								val7.WriteByte(b5);
								val7.WriteShort(num40);
								val7.WriteShort(num41);
								val7.WriteByte(b6);
								val7.WriteInt(num42);
								val7.WriteInt(num43);
								val7.WriteByte(b7);
								val7.WriteByte(b8);
								val7.WriteByte(b9);
								val7.WriteInt(num44);
								val7.WriteByte(b10);
								Parent.Server.Send(val7);
								return;
							}
							finally
							{
								((IDisposable)val7)?.Dispose();
							}
						}
						if (num == Adler32Helper.GenerateAdler32_ASCII("PqFinishTimeAttack", 0u))
						{
							int num45 = iPacket.ReadInt();
							int num46 = iPacket.ReadInt();
							byte b11 = iPacket.ReadByte();
							int num47 = iPacket.ReadInt();
							int num48 = iPacket.ReadInt();
							int num49 = iPacket.ReadInt();
							int num50 = iPacket.ReadInt();
							int num51 = iPacket.ReadInt();
							SessionGroup.min = num51 / 60000;
							int num52 = num51 - SessionGroup.min * 60000;
							SessionGroup.sec = num52 / 1000;
							SessionGroup.mil = num51 % 1000;
							Console.WriteLine("FinishTimeAttack : FinishType: {0}, RewardType: {1}, Time: {2} ({3}:{4}:{5})", num45, b11, num51, SessionGroup.min, SessionGroup.sec, SessionGroup.mil);
							OutPacket val8 = new OutPacket("PqFinishTimeAttack");
							try
							{
								val8.WriteInt(num45);
								val8.WriteInt(num46);
								val8.WriteByte(b11);
								val8.WriteInt(num47);
								val8.WriteInt(num48);
								val8.WriteInt(num49);
								val8.WriteInt(num50);
								val8.WriteInt(num51);
								Parent.Server.Send(val8);
								return;
							}
							finally
							{
								((IDisposable)val8)?.Dispose();
							}
						}
					}
				}
			}
		}
		OutPacket val9 = new OutPacket(64);
		try
		{
			val9.WriteBytes(((PacketBase)iPacket).ToArray());
			//Console.WriteLine("SendToServer-" + (PacketName)BitConverter.ToUInt32(val9.ToArray(), 0) + "£º" + BitConverter.ToString(val9.ToArray()).Replace("-", ""));
			Parent.Server.Send(val9);
		}
		finally
		{
			((IDisposable)val9)?.Dispose();
		}
	}
}
