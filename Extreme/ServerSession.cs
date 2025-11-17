using KartRider;
using KartRider.Common.Add;
using KartRider.Common.Network2;
using KartRider.Common.Security;
using KartRider.Common.Utilities;
using KartRider.Data;
using KartRider.IO;
using RewardItemBox;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Extreme;

public class ServerSession : Session
{
    public int gameStartTick = 0;

    public int game_myRealStartTick = 0;

    private bool recievedEndJewel = false;

    public SessionGroup Parent { get; set; }

    public ServerSession(SessionGroup parent, Socket socket) : base(socket)
    {
        Parent = parent;
    }

    [DllImport("kernel32", CharSet = CharSet.Unicode)]
    private static extern int GetPrivateProfileString(string Section, string Key, string Default, StringBuilder RetVal, int Size, string FilePath);

    public override void OnDisconnect()
    {
        Console.WriteLine("Server_Disconnected");
        Parent.Server.Disconnect();
        Parent.Client.Disconnect();
    }

    public override void OnPacket(InPacket iPacket)
    {
        if (Parent == null)
        {
            Thread.Sleep(1000);
        }
        lock (Parent.m_lock)
        {
            ((PacketBase)iPacket).Position = 0;
            uint num = iPacket.ReadUInt();
            PacketName packetName = (PacketName)num;
            Console.WriteLine("Receive-{0}: {1}", packetName, BitConverter.ToString(iPacket.ToArray()).Replace("-", " "));
            if (num == Adler32Helper.GenerateAdler32_ASCII("PcUserShutDownMessage", 0u))
            {
                return;
            }
            else if (num == Adler32Helper.GenerateAdler32_ASCII("PcFirstMessage", 0))
            {
                SessionGroup.usLocale = iPacket.ReadUShort();
                ushort UShort2 = iPacket.ReadUShort();
                ushort UShort3 = iPacket.ReadUShort();
                string strPatch = iPacket.ReadString(false);
                uint RIV = iPacket.ReadUInt();
                uint SIV = iPacket.ReadUInt();
                Parent.Server._RIV = RIV ^ SIV;
                Parent.Server._SIV = RIV ^ SIV;
                byte Byte1 = iPacket.ReadByte();
                string Key1 = iPacket.ReadString(false);
                byte[] Bytes1 = iPacket.ReadBytes(31);
                string Key2 = iPacket.ReadString(false);
                Console.WriteLine("PcFirstMessage : {0} {1} {2}", SessionGroup.usLocale, UShort2, UShort3);
                Console.WriteLine("strPatch : {0}", strPatch);
                Console.WriteLine("Key1 : {0}", Key1);
                Console.WriteLine("Key2 : {0}", Key2);
                Console.WriteLine("first_val : {0}", RIV);
                Console.WriteLine("second_val : {0}", SIV);
                using (OutPacket outPacket = new OutPacket("PcFirstMessage"))
                {
                    outPacket.WriteUShort(SessionGroup.usLocale);
                    outPacket.WriteUShort(UShort2);
                    outPacket.WriteUShort(UShort3);
                    outPacket.WriteString(strPatch);
                    outPacket.WriteUInt(RIV);
                    outPacket.WriteUInt(SIV);
                    outPacket.WriteByte(Byte1);
                    outPacket.WriteString(Key1);
                    outPacket.WriteBytes(Bytes1);
                    outPacket.WriteString(Key2);
                    SendToClient(outPacket);
                }
                Parent.Client._RIV = RIV ^ SIV;
                Parent.Client._SIV = RIV ^ SIV;
            }
            else if (num == Adler32Helper.GenerateAdler32_ASCII("PrChannelSwitch", 0))
            {
                using (OutPacket outPacket = new OutPacket("PrChannelSwitch"))
                {
                    outPacket.WriteInt(iPacket.ReadInt());
                    outPacket.WriteShort(iPacket.ReadShort());
                    outPacket.WriteShort(iPacket.ReadShort());
                    outPacket.WriteEndPoint(IPAddress.Parse("127.0.0.1"), 39312);
                    RouterListener.ForceConnect = $"{iPacket.ReadByte()}.{iPacket.ReadByte()}.{iPacket.ReadByte()}.{iPacket.ReadByte()}";
                    RouterListener.NewConnRequest = true;
                    SendToClient(outPacket);
                }
            }
            else if (num == Adler32Helper.GenerateAdler32_ASCII("PcMove4MyRoom", 0))
            {
                using (OutPacket outPacket = new OutPacket("PcMove4MyRoom"))
                {
                    outPacket.WriteInt(iPacket.ReadInt());
                    outPacket.WriteShort(iPacket.ReadShort());
                    outPacket.WriteShort(iPacket.ReadShort());
                    outPacket.WriteBytes(iPacket.ReadBytes(4));
                    outPacket.WriteEndPoint(IPAddress.Parse("127.0.0.1"), 39312);
                    RouterListener.ForceConnect = $"{iPacket.ReadByte()}.{iPacket.ReadByte()}.{iPacket.ReadByte()}.{iPacket.ReadByte()}";
                    SendToClient(outPacket);
                }
            }
            else if (num == Adler32Helper.GenerateAdler32_ASCII("PrChannelMoveIn", 0) || num == Adler32Helper.GenerateAdler32_ASCII("PrIn4MyRoom", 0))
            {
                using (OutPacket outPacket = new OutPacket("PrChannelMoveIn"))
                {
                    outPacket.WriteByte(iPacket.ReadByte());
                    IPEndPoint IP1 = new IPEndPoint(new IPAddress(iPacket.ReadBytes(4)), iPacket.ReadUShort());
                    IPEndPoint IP2 = new IPEndPoint(new IPAddress(iPacket.ReadBytes(4)), iPacket.ReadUShort());
                    Console.WriteLine($"Server: {IP1.Address}:{IP1.Port}, {IP2.Address}:{IP2.Port}");
                    outPacket.WriteEndPoint(IPAddress.Parse(RouterListener.ForceConnect), 39311);
                    outPacket.WriteEndPoint(IPAddress.Parse(RouterListener.ForceConnect), 39312);
                    if (num == Adler32Helper.GenerateAdler32_ASCII("PrIn4MyRoom", 0))
                    {
                        outPacket.WriteBytes(iPacket.ReadBytes(6));
                    }
                    SendToClient(outPacket);
                }
            }
            else if (num == Adler32Helper.GenerateAdler32_ASCII("PrBingoSync", 0))
            {
                bool flag = iPacket.ReadBool();
                ushort num2 = iPacket.ReadUShort();
                ushort num3 = iPacket.ReadUShort();
                Console.WriteLine("BingoSync : MyLap: {0}, BingoBall: {1}", num2, num3);
                Default(iPacket);
            }
            else if (num == Adler32Helper.GenerateAdler32_ASCII("PrBingoSelectNum", 0))
            {
                int num4 = iPacket.ReadInt();
                iPacket.ReadUShort();
                iPacket.ReadUShort();
                iPacket.ReadByte();
                iPacket.ReadInt();
                int num5 = iPacket.ReadInt();
                if (num5 > 0)
                {
                    Console.WriteLine("BingoReward Type1: {0}", num5);
                }
                for (int i = 0; i < num5; i++)
                {
                    iPacket.ReadInt();
                    iPacket.ReadInt();
                    int num6 = iPacket.ReadInt();
                    Console.WriteLine("Stock: {0}", num6);
                }
                int num7 = iPacket.ReadInt();
                if (num7 > 0)
                {
                    Console.WriteLine("BingoReward Type2: {0}", num7);
                }
                for (int j = 0; j < num7; j++)
                {
                    iPacket.ReadInt();
                    iPacket.ReadInt();
                    int num8 = iPacket.ReadInt();
                    Console.WriteLine("Stock: {0}", num8);
                }
                Default(iPacket);
            }
            else if (num == Adler32Helper.GenerateAdler32_ASCII("PrBlueMarble", 0))
            {
                int num9 = iPacket.ReadInt();
                ushort num10 = iPacket.ReadUShort();
                byte b = iPacket.ReadByte();
                ushort num11 = iPacket.ReadUShort();
                int num12 = iPacket.ReadInt();
                for (int k = 0; k < num12; k++)
                {
                    iPacket.ReadShort();
                }
                byte b2 = iPacket.ReadByte();
                if (b2 != 0)
                {
                    RouterForm.MarbleCount--;
                    if (RouterForm.MarbleCount > 0)
                    {
                        new Thread((ThreadStart)delegate
                        {
                            Thread.Sleep(1100);
                            using (OutPacket outPacket = new OutPacket("PqBlueMarble"))
                            {
                                using (OutPacket oPacket = new OutPacket(4))
                                {
                                    oPacket.WriteTime(DateTime.Now);
                                    byte[] array = KREncodedBlock.Encode(oPacket.ToArray(), (KREncodedBlock.EncodeFlag)2, 2242368262);
                                    outPacket.WriteInt(array.Length);
                                    outPacket.WriteBytes(array);
                                    outPacket.WriteInt(1);
                                    SendToClient(outPacket);
                                }
                            }
                        }).Start();
                    }
                }
                int num13 = iPacket.ReadInt();
                switch (num13)
                {
                    case 1:
                        {
                            int num16 = iPacket.ReadInt();
                            Console.WriteLine("Stock: {0}", num16);
                            break;
                        }
                    case 2:
                        {
                            uint num15 = iPacket.ReadUInt();
                            Console.WriteLine("Lucci: {0}", num15);
                            break;
                        }
                    case 3:
                        {
                            int num14 = iPacket.ReadInt();
                            Console.WriteLine("RP: {0}", num14);
                            break;
                        }
                }
                int num17 = iPacket.ReadInt();
                Console.WriteLine("PrBlueMarble : OpenType: {0}, MyLap: {1}, MySlot: {2}, MyDice: {3}, UnkCount: {4}, DiceNum: {5}, RewardType: {6}, FinishedLucci: {7}", num9, num10, b, num11, num12, b2, num13, num17);
                Default(iPacket);
            }
            else if (num == Adler32Helper.GenerateAdler32_ASCII("GameControlPacket", 0))
            {
                using (OutPacket outPacket = new OutPacket("GameControlPacket"))
                {
                    int num78 = iPacket.ReadInt();
                    byte b13 = iPacket.ReadByte();
                    outPacket.WriteInt(num78);
                    outPacket.WriteByte(b13);
                    if (b13 != 0)
                    {
                        outPacket.WriteInt(iPacket.ReadInt());
                        outPacket.WriteInt(iPacket.ReadInt());
                    }
                    int num79 = iPacket.ReadInt();
                    outPacket.WriteInt(num79);
                    outPacket.WriteBytes(iPacket.ReadBytes(iPacket.Available));
                    SendToClient(outPacket);
                    switch (num78)
                    {
                        case 1:
                            {
                                gameStartTick = num79;
                                game_myRealStartTick = Environment.TickCount;
                                Parent.PlaneCheck1 = (byte)gameStartTick;
                                uint num80 = CryptoConstants.GetKey(CryptoConstants.GetKey((uint)gameStartTick)) % 5 + 6;
                                int num81 = (int)num80;
                                Parent.SendPlaneCount = (int)num80;
                                Parent.GoalIn = false;
                                Parent.GameReport = false;
                                if (Program.GameReport_Development)
                                {
                                    Parent.TotalSendPlaneCount = 0;
                                    Parent.GameReportCut = 0;
                                    Parent.PlaneCheckMax = Parent.SendPlaneCount;
                                    Console.WriteLine("PlaneCheckMax: {0}", Parent.SendPlaneCount);
                                }
                                if (Program.Goal)
                                {
                                    RouterForm.GameRaceTime = false;
                                    RouterForm.GameGoalTime = true;
                                }
                                if (RouterForm.GameFastRaceMacro)
                                {
                                    new Thread((ThreadStart)delegate
                                    {
                                        for (int num111 = 0; num111 < 6; num111++)
                                        {
                                            Parent.Send_Report();
                                        }
                                        Parent.Send_GoalIn();
                                        for (int num112 = 0; num112 < SuspiciousRaceCheck.ReportCount - 6; num112++)
                                        {
                                            Thread.Sleep(300);
                                            Parent.Send_Report();
                                        }
                                    }).Start();
                                }
                                else if (RouterForm.GameRaceMacro || RouterForm.VersusModeMacro)
                                {
                                    new Thread((ThreadStart)delegate
                                    {
                                        if (SessionGroup.GameType == 17)
                                        {
                                            Thread.Sleep(37100);
                                            Parent.Send_GoalIn();
                                        }
                                        else
                                        {
                                            Thread.Sleep(SuspiciousRaceCheck.RaceTime + 7100);
                                            Parent.Send_GoalIn();
                                        }
                                    }).Start();
                                }
                                else
                                {
                                    if (!RouterForm.pwnJewel)
                                    {
                                        break;
                                    }
                                    recievedEndJewel = false;
                                    new Thread((ThreadStart)delegate
                                    {
                                        for (int num109 = 0; num109 < 6; num109++)
                                        {
                                            Thread.Sleep(100);
                                            Parent.Send_Report();
                                        }
                                        Parent.Send_GoalIn();
                                        for (int num110 = 0; num110 < SuspiciousRaceCheck.ReportCount - 6; num110++)
                                        {
                                            Thread.Sleep(300);
                                            Parent.Send_Report();
                                        }
                                    }).Start();
                                }
                                break;
                            }
                        case 4:
                            Parent.GoalIn = true;
                            if (RouterForm.pwnJewel)
                            {
                                recievedEndJewel = true;
                            }
                            break;
                    }
                }
            }
            else if (num == Adler32Helper.GenerateAdler32_ASCII("SingleProcessJewelPacket", 0) || num == Adler32Helper.GenerateAdler32_ASCII("GameJewelPacket", 0))
            {
                string text = iPacket.ToString();
                string text2 = text.Substring(0, text.Length - 12);
                if (num == Adler32Helper.GenerateAdler32_ASCII("SingleProcessJewelPacket", 0))
                {
                    Console.WriteLine("SingleProcessJewelPacket: {0}", text2);
                }
                if (num == Adler32Helper.GenerateAdler32_ASCII("GameJewelPacket", 0))
                {
                    Console.WriteLine("GameJewelPacket: {0}", text2);
                }
                Default(iPacket);
                if (RouterForm.pwnJewel)
                {
                    recievedEndJewel = true;
                }
            }
            else if (num == Adler32Helper.GenerateAdler32_ASCII("GameRaceTimePacket", 0))
            {
                int num82 = iPacket.ReadInt();
                SessionGroup.RaceTime = iPacket.ReadInt();
                SessionGroup.min = SessionGroup.RaceTime / 60000;
                int num83 = SessionGroup.RaceTime - SessionGroup.min * 60000;
                SessionGroup.sec = num83 / 1000;
                SessionGroup.mil = SessionGroup.RaceTime % 1000;
                if (num82 == Program.MySlot)
                {
                    Console.WriteLine("LAPS: {0}, TIME: {1} ({2}:{3}:{4})", SuspiciousRaceCheck.Laps, SessionGroup.RaceTime, SessionGroup.min, SessionGroup.sec, SessionGroup.mil);
                }
                Default(iPacket);
                if (RouterForm.pwnJewel)
                {
                    new Thread((ThreadStart)delegate
                    {
                        while (!recievedEndJewel)
                        {
                            Thread.Sleep(300);
                            using (OutPacket outPacket = new OutPacket("GameBoosterAddPacket"))
                            {
                                SendToClient(outPacket);
                            }
                        }
                    }).Start();
                }
                if (RouterForm.GameGoalTime && num82 != Program.MySlot)
                {
                    Console.WriteLine("PLAYER: {0}, LAPS: {1}, TIME: {2} ({3}:{4}:{5})", num82, SuspiciousRaceCheck.Laps, SessionGroup.RaceTime, SessionGroup.min, SessionGroup.sec, SessionGroup.mil);
                    RouterForm.GameRaceTime = true;
                    Parent.Send_GoalIn();
                    RouterForm.GameGoalTime = false;
                }
            }
            else if (num == Adler32Helper.GenerateAdler32_ASCII("LoRpAddRacingTimePacket", 0))
            {
                int num84 = iPacket.ReadInt();
                SessionGroup.min = num84 / 60000;
                int num85 = num84 - SessionGroup.min * 60000;
                SessionGroup.sec = num85 / 1000;
                SessionGroup.mil = num84 % 1000;
                Console.WriteLine("LoRpAddRacingTimePacket: {0} ({1}:{2}:{3})", num84, SessionGroup.min, SessionGroup.sec, SessionGroup.mil);
                Default(iPacket);
            }
            else if (num == Adler32Helper.GenerateAdler32_ASCII("GrSessionDataPacket", 0))
            {
                SessionGroup.RoomName = iPacket.ReadString(false);
                string arg = iPacket.ReadString(false);
                byte b14 = iPacket.ReadByte();
                byte b15 = iPacket.ReadByte();
                Console.WriteLine("------------ ROOM SESSION INFO ------------");
                Console.WriteLine("ROOM NAME: {0}", SessionGroup.RoomName);
                Console.WriteLine("ROOM PWD : {0}", arg);
                Console.WriteLine("ROOM TYPE: {0}", b14);
                Console.WriteLine("-------------------------------------------");
                Default(iPacket);
                if (RouterForm.GameRaceMacro || RouterForm.GameFastRaceMacro || RouterForm.pwnJewel)
                {
                    new Thread((ThreadStart)delegate
                    {
                        Thread.Sleep(1000);
                        GameSupport.AutoRoomStartAndReady();
                    }).Start();
                }
                else if (RouterForm.VersusModeMacro)
                {
                    new Thread((ThreadStart)delegate
                    {
                        Thread.Sleep(1000);
                        GameSupport.Send_GameRoomReady();
                    }).Start();
                }
            }
            else if (num == Adler32Helper.GenerateAdler32(Encoding.ASCII.GetBytes("RmOwnerItemPacket"), 0))
            {
                int num86 = iPacket.ReadInt();
                int num87 = iPacket.ReadInt();
                int num88 = iPacket.ReadInt();
                List<Item> list = new List<Item>();
                for (int num89 = 0; num89 < num88; num89++)
                {
                    Item item = new Item(iPacket);
                    if (item.Type == 37 || item.Type == 38 || item.Type == 39)
                    {
                        Console.WriteLine("{0}:{1}:{2}:{3}:{4}:{5}:{6}:{7}:{8}:{9}:{10}", item.Type, item.ItemID, item.SN, item.Amount, item.Unk2, item.Unk3, item.expr1, item.expr2, item.Unk4, item.Unk5, item.Unk6);
                    }
                    list.Add(item);
                }
                Default(iPacket);
            }
            else if (num == Adler32Helper.GenerateAdler32(Encoding.ASCII.GetBytes("LoRpGetRiderItemPacket"), 0))
            {
                int num90 = iPacket.ReadInt();
                int num91 = iPacket.ReadInt();
                int num92 = iPacket.ReadInt();
                List<Item> list2 = new List<Item>();
                for (int num93 = 0; num93 < num92; num93++)
                {
                    Item item2 = new Item(iPacket);
                    list2.Add(item2);
                }
                using (OutPacket outPacket = new OutPacket("LoRpGetRiderItemPacket"))
                {
                    outPacket.WriteInt(num90);
                    outPacket.WriteInt(num91);
                    outPacket.WriteInt(list2.Count);
                    foreach (Item item3 in list2)
                    {
                        item3.Unk2 = 0;
                        item3.Unk3 = 0;
                        item3.Encode(outPacket);
                    }
                    SendToClient(outPacket);
                }
            }
            else if (num == Adler32Helper.GenerateAdler32_ASCII("PrEnterFishingPacket", 0))
            {
                string text11 = iPacket.ToString();
                SessionGroup.Fishing = text11.Substring(24, 132);
                Default(iPacket);
            }
            else if (num == Adler32Helper.GenerateAdler32_ASCII("PrEndFishingPacket", 0))
            {
                int num94 = iPacket.ReadInt();
                int num95 = iPacket.ReadInt();
                int num96 = iPacket.ReadInt();
                int num97 = iPacket.ReadInt();
                iPacket.ReadInt();
                Console.WriteLine("Type: {0} Stock: {1} RP: {2} Lucci: {3}", num94, num95, num96, num97);
                using (StreamWriter streamWriter4 = new StreamWriter("EndFishing.log", append: true))
                {
                    streamWriter4.WriteLine("[{0}] Type: {1} Stock: {2} RP: {3} Lucci: {4}", DateTime.Now, num94, num95, num96, num97);
                }
                Default(iPacket);
            }
            else if (num == Adler32Helper.GenerateAdler32_ASCII("SpRpLotteryPacket", 0))
            {
                string text = iPacket.ToString();
                string text2 = text.Substring(0, text.Length - 12);
                Console.WriteLine(text2);
                int type = iPacket.ReadInt();
                int num98 = iPacket.ReadInt();
                iPacket.ReadUInt();
                iPacket.ReadByte();
                byte b16 = iPacket.ReadByte();
                if (type == 0)
                {
                    RouterForm.LotteryCount--;
                    Console.WriteLine("Stock: {0}, {1}", num98, b16);
                }
                if (RouterForm.LotteryCount > 0)
                {
                    Console.WriteLine("LotteryCount: {0}", RouterForm.LotteryCount);
                    int LotteryID = int.Parse(Program.RouterFormDlg.txLotteryID.Text);
                    int LotteryType = int.Parse(Program.RouterFormDlg.txLotteryType.Text);
                    new Thread((ThreadStart)delegate
                    {
                        Thread.Sleep((type == 5) ? 100 : 1100);
                        using (OutPacket outPacket = new OutPacket("SpRqLotteryPacket"))
                        {
                            outPacket.WriteShort((short)LotteryID);
                            outPacket.WriteBool(true);
                            outPacket.WriteInt(LotteryType);
                            Send(outPacket);
                        }
                        if (LotteryType == 2)
                        {
                            Thread.Sleep(300);
                            using (OutPacket oPacker = new OutPacket("SpRqBingoGachaPacket"))
                            {
                                oPacker.WriteInt(3);
                                Send(oPacker);
                            }
                        }
                    }).Start();
                }
                if (type != 5)
                {
                    Default(iPacket);
                }
            }
            else if (num == Adler32Helper.GenerateAdler32_ASCII("SpRpGetRewardBoxListPacket", 0))
            {
                int num99 = iPacket.ReadInt();
                Parent.RewardBox.Clear();
                for (int num100 = 0; num100 < num99; num100++)
                {
                    Parent.RewardBox.Add(new RewardItem(iPacket));
                }
                if (num99 > 0 && Parent.RequestRewardBox)
                {
                    Parent.SendGetRewardBox();
                }
                else if (num99 <= 0)
                {
                    Parent.RequestRewardBox = false;
                }
                if (!Parent.RequestRewardBox)
                {
                    Default(iPacket);
                }
            }
            else if (num == Adler32Helper.GenerateAdler32_ASCII("ChRpEnterMyRoomPacket", 0))
            {
                using (OutPacket outPacket = new OutPacket("ChRpEnterMyRoomPacket"))
                {
                    string Nickname = iPacket.ReadString(false);
                    outPacket.WriteString(Nickname);
                    outPacket.WriteByte(iPacket.ReadByte());
                    outPacket.WriteShort(iPacket.ReadShort());
                    byte b5 = iPacket.ReadByte();
                    outPacket.WriteByte(b5);
                    outPacket.WriteByte(iPacket.ReadByte());
                    outPacket.WriteByte(iPacket.ReadByte());
                    outPacket.WriteByte(iPacket.ReadByte());
                    outPacket.WriteByte(iPacket.ReadByte());
                    string RoomPwd = iPacket.ReadString(false);
                    outPacket.WriteString(RoomPwd);
                    outPacket.WriteString(iPacket.ReadString(false));
                    string ItemPwd = iPacket.ReadString(false);
                    outPacket.WriteString(ItemPwd);
                    outPacket.WriteShort(iPacket.ReadShort());
                    outPacket.WriteShort(iPacket.ReadShort());
                    Console.WriteLine("MyRoom Data--------------------------------");
                    Console.WriteLine("Nickname: {0}", Nickname);
                    Console.WriteLine("ROOM PWD: {0}", RoomPwd);
                    Console.WriteLine("ITEM PWD: {0}", ItemPwd);
                    Console.WriteLine("-------------------------------------------");
                    SendToClient(outPacket);
                }
            }
            else if (num == Adler32Helper.GenerateAdler32_ASCII("PrLogin", 0))
            {
                int position = iPacket.Position;
                int length = iPacket.Length;
                int Int1 = iPacket.ReadInt();
                switch (Int1)
                {
                    case 0:
                        {
                            using (OutPacket outPacket = new OutPacket("PrLogin"))
                            {
                                outPacket.WriteInt(Int1);
                                outPacket.WriteUShort(iPacket.ReadUShort());
                                outPacket.WriteUShort(iPacket.ReadUShort());
                                SessionGroup.UserNO = iPacket.ReadUInt();
                                SessionGroup.UserID = iPacket.ReadString(false);
                                outPacket.WriteUInt(SessionGroup.UserNO);
                                outPacket.WriteString(SessionGroup.UserID);
                                outPacket.WriteByte(iPacket.ReadByte());
                                outPacket.WriteByte(iPacket.ReadByte());
                                outPacket.WriteByte(iPacket.ReadByte());
                                outPacket.WriteInt(iPacket.ReadInt());
                                outPacket.WriteByte(iPacket.ReadByte());
                                outPacket.WriteBytes(iPacket.ReadBytes(4));
                                uint pmap = iPacket.ReadUInt();
                                outPacket.WriteUInt(pmap);//1068
                                for (int i = 0; i < 11; i++)
                                {
                                    outPacket.WriteInt(iPacket.ReadInt());
                                }
                                outPacket.WriteByte(iPacket.ReadByte());
                                IPEndPoint IP1 = new IPEndPoint(new IPAddress(iPacket.ReadBytes(4)), iPacket.ReadUShort());
                                IPEndPoint IP2 = new IPEndPoint(new IPAddress(iPacket.ReadBytes(4)), iPacket.ReadUShort());
                                Console.WriteLine("Login: uid: {0}, rid: {1}, pmap: {2}", SessionGroup.UserID, SessionGroup.UserNO, pmap);
                                Console.WriteLine($"Server: {IP1.Address}:{IP1.Port}, {IP2.Address}:{IP2.Port}");
                                outPacket.WriteEndPoint(IPAddress.Parse(RouterListener.sIP), 39311);
                                outPacket.WriteEndPoint(IPAddress.Parse(RouterListener.sIP), 39312);
                                outPacket.WriteInt(iPacket.ReadInt());
                                outPacket.WriteInt(iPacket.ReadInt());
                                outPacket.WriteInt(iPacket.ReadInt());
                                outPacket.WriteByte(iPacket.ReadByte());
                                outPacket.WriteString(iPacket.ReadString());
                                outPacket.WriteInt(iPacket.ReadInt());
                                outPacket.WriteInt(iPacket.ReadInt());
                                outPacket.WriteString(iPacket.ReadString());
                                outPacket.WriteString(iPacket.ReadString());
                                outPacket.WriteInt(6);
                                outPacket.WriteString("content");
                                outPacket.WriteInt(0);
                                outPacket.WriteInt(2);
                                outPacket.WriteString("name");
                                outPacket.WriteString("dynamicPpl");
                                outPacket.WriteString("enable");
                                outPacket.WriteString("false");
                                outPacket.WriteInt(1);
                                outPacket.WriteString("region");
                                outPacket.WriteInt(0);
                                outPacket.WriteInt(1);
                                outPacket.WriteString("szId");
                                outPacket.WriteString(SessionGroup.usLocale.ToString());
                                outPacket.WriteInt(0);
                                outPacket.WriteString("content");
                                outPacket.WriteInt(0);
                                outPacket.WriteInt(3);
                                outPacket.WriteString("name");
                                outPacket.WriteString("grandprix");
                                outPacket.WriteString("enable");
                                outPacket.WriteString("true");
                                outPacket.WriteString("visible");
                                outPacket.WriteString("true");
                                outPacket.WriteInt(0);
                                outPacket.WriteString("content");
                                outPacket.WriteInt(0);
                                outPacket.WriteInt(3);
                                outPacket.WriteString("name");
                                outPacket.WriteString("endingBanner");
                                outPacket.WriteString("enable");
                                outPacket.WriteString("false");
                                outPacket.WriteString("value");
                                outPacket.WriteString("http://popkart.tiancity.com/homepage/endbanner.html");
                                outPacket.WriteInt(0);
                                outPacket.WriteString("content");
                                outPacket.WriteInt(0);
                                outPacket.WriteInt(3);
                                outPacket.WriteString("name");
                                outPacket.WriteString("themeXyy");
                                outPacket.WriteString("enable");
                                outPacket.WriteString("true");
                                outPacket.WriteString("visible");
                                outPacket.WriteString("true");
                                outPacket.WriteInt(0);
                                outPacket.WriteString("content");
                                outPacket.WriteInt(0);
                                outPacket.WriteInt(3);
                                outPacket.WriteString("name");
                                outPacket.WriteString("themeKorea");
                                outPacket.WriteString("enable");
                                outPacket.WriteString("true");
                                outPacket.WriteString("visible");
                                outPacket.WriteString("true");
                                outPacket.WriteInt(0);
                                outPacket.WriteString("content");
                                outPacket.WriteInt(0);
                                outPacket.WriteInt(5);
                                outPacket.WriteString("name");
                                outPacket.WriteString("timeAttack");
                                outPacket.WriteString("enable");
                                outPacket.WriteString("true");
                                outPacket.WriteString("visible");
                                outPacket.WriteString("true");
                                outPacket.WriteString("value");
                                outPacket.WriteString("village_R01");
                                outPacket.WriteString("maxReplayFileCount");
                                outPacket.WriteString("250");
                                outPacket.WriteInt(0);
                                outPacket.WriteByte(0);
                                iPacket.Position = length - 6;
                                outPacket.WriteByte(iPacket.ReadByte());
                                outPacket.WriteByte(iPacket.ReadByte());
                                outPacket.WriteUInt(iPacket.ReadUInt());
                                SendToClient(outPacket);
                                break;
                            }
                        }
                    case 4:
                        Default(iPacket);
                        break;
                    default:
                        Default(iPacket);
                        break;
                }
            }
            else if (num == Adler32Helper.GenerateAdler32_ASCII("PrStartTimeAttack", 0) || num == Adler32Helper.GenerateAdler32_ASCII("PrchallengerKartSpec", 0) || num == Adler32Helper.GenerateAdler32_ASCII("PrKartSpec", 0) || num == Adler32Helper.GenerateAdler32_ASCII("PrStartRiderSchool", 0))
            {
                using (OutPacket outPacket = new OutPacket())
                {
                    outPacket.WriteUInt(num);
                    if (num == Adler32Helper.GenerateAdler32_ASCII("PrStartTimeAttack", 0))
                    {
                        outPacket.WriteInt(iPacket.ReadInt());
                        outPacket.WriteInt(iPacket.ReadInt());
                    }
                    if (num == Adler32Helper.GenerateAdler32_ASCII("PrchallengerKartSpec", 0) || num == Adler32Helper.GenerateAdler32_ASCII("PrKartSpec", 0) || num == Adler32Helper.GenerateAdler32_ASCII("PrStartRiderSchool", 0))
                    {
                        outPacket.WriteByte(iPacket.ReadByte());
                    }
                    int endPosition = Program.HandleSpecChange(Parent.KartSpec, outPacket, iPacket);
                    iPacket.Position = endPosition;
                    outPacket.WriteBytes(iPacket.ReadBytes(iPacket.Available));
                    SendToClient(outPacket);
                }
            }
            else if (num == Adler32Helper.GenerateAdler32_ASCII("SpRpReceiveRewardItemPacket", 0))
            {
                if (iPacket.ReadInt() != 0)
                {
                    Parent.RequestRewardBox = false;
                }
                else if (!Parent.RequestRewardBox)
                {
                    Default(iPacket);
                }
                else
                {
                    new Thread((ThreadStart)delegate
                    {
                        Thread.Sleep(60);
                        Parent.SendGetRewardBox();
                    }).Start();
                }
            }
            else if (num == Adler32Helper.GenerateAdler32_ASCII("GrCommandStartPacket", 0))
            {
                using (OutPacket outPacket = new OutPacket("GrCommandStartPacket"))
                {
                    uint GrSessionDataPacket = iPacket.ReadUInt();
                    if (GrSessionDataPacket == Adler32Helper.GenerateAdler32_ASCII("GrSessionDataPacket", 0))
                    {
                        outPacket.WriteUInt(GrSessionDataPacket);
                        string RoomName = iPacket.ReadString(false);
                        Console.WriteLine("RoomName: {0}", RoomName);
                        outPacket.WriteString(RoomName);
                        string RoomPWD = iPacket.ReadString(false);
                        Console.WriteLine("RoomPWD: {0}", RoomPWD);
                        outPacket.WriteString(RoomPWD);
                        outPacket.WriteByte(iPacket.ReadByte());
                        byte SpeedType = iPacket.ReadByte();
                        Console.WriteLine("SpeedType: {0}", SpeedType);
                        outPacket.WriteByte(SpeedType);
                        outPacket.WriteInt(iPacket.ReadInt());
                        outPacket.WriteByte(iPacket.ReadByte());
                        outPacket.WriteInt(iPacket.ReadInt());
                        outPacket.WriteInt(iPacket.ReadInt());
                        outPacket.WriteByte(iPacket.ReadByte());
                        outPacket.WriteByte(iPacket.ReadByte());
                        outPacket.WriteByte(iPacket.ReadByte());

                        uint GrSlotDataPacket = iPacket.ReadUInt();
                        if (GrSlotDataPacket == Adler32Helper.GenerateAdler32_ASCII("GrSlotDataPacket", 0))
                        {
                            outPacket.WriteUInt(GrSlotDataPacket);
                            outPacket.WriteUInt(iPacket.ReadUInt());
                            outPacket.WriteInt(iPacket.ReadInt());
                            outPacket.WriteBytes(iPacket.ReadBytes(32));
                            outPacket.WriteInt(iPacket.ReadInt());
                            outPacket.WriteInt(iPacket.ReadInt());
                            outPacket.WriteInt(iPacket.ReadInt());
                            outPacket.WriteShort(iPacket.ReadShort());
                            outPacket.WriteByte(iPacket.ReadByte());
                            outPacket.WriteByte(iPacket.ReadByte());
                            outPacket.WriteByte(iPacket.ReadByte());
                            outPacket.WriteByte(iPacket.ReadByte());
                            outPacket.WriteByte(iPacket.ReadByte());
                            outPacket.WriteInt(iPacket.ReadInt());
                            outPacket.WriteInt(iPacket.ReadInt());
                            outPacket.WriteInt(iPacket.ReadInt());
                            outPacket.WriteInt(iPacket.ReadInt());
                            for (int i = 0; i < 8; i++)
                            {
                                int PlayerType = iPacket.ReadInt();
                                Console.WriteLine("PlayerType: {0}", PlayerType);
                                outPacket.WriteInt(PlayerType); // Player Type, 2 = RoomMaster, 3 = AutoReady, 4 = Observer, 5 = Preparing, 7 = AI
                                if (PlayerType == 2 || PlayerType == 3 || PlayerType == 4 || PlayerType == 5)
                                {
                                    uint UserNO = iPacket.ReadUInt();
                                    outPacket.WriteUInt(UserNO);
                                    IPEndPoint IP = new IPEndPoint(new IPAddress(iPacket.ReadBytes(4)), iPacket.ReadUShort());
                                    outPacket.WriteEndPoint(IP);
                                    outPacket.WriteInt(iPacket.ReadInt());
                                    outPacket.WriteShort(iPacket.ReadShort());
                                    string Nickname = iPacket.ReadString(false);
                                    outPacket.WriteString(Nickname);
                                    outPacket.WriteBytes(iPacket.ReadBytes(6));
                                    outPacket.WriteBytes(iPacket.ReadBytes(73));
                                    outPacket.WriteShort(iPacket.ReadShort());
                                    string Card = iPacket.ReadString(false);
                                    outPacket.WriteString(Card);
                                    uint RP = iPacket.ReadUInt();
                                    outPacket.WriteUInt(RP);
                                    byte Team = iPacket.ReadByte();
                                    outPacket.WriteByte(Team);
                                    outPacket.WriteByte(iPacket.ReadByte());
                                    outPacket.WriteByte(iPacket.ReadByte());
                                    for (int j = 0; j < 8; j++)
                                    {
                                        outPacket.WriteInt(iPacket.ReadInt());
                                    }
                                    outPacket.WriteInt(iPacket.ReadInt());
                                    outPacket.WriteInt(iPacket.ReadInt());
                                    outPacket.WriteInt(iPacket.ReadInt());
                                    outPacket.WriteInt(iPacket.ReadInt());
                                    outPacket.WriteInt(iPacket.ReadInt());
                                    outPacket.WriteBytes(iPacket.ReadBytes(4));
                                    outPacket.WriteByte(iPacket.ReadByte());
                                    string ClubName = iPacket.ReadString(false);
                                    outPacket.WriteString(ClubName);
                                    int ClubMark_LOGO = iPacket.ReadInt();
                                    outPacket.WriteInt(ClubMark_LOGO);
                                    outPacket.WriteInt(iPacket.ReadInt());
                                    outPacket.WriteInt(iPacket.ReadInt());
                                    outPacket.WriteInt(iPacket.ReadInt());
                                    outPacket.WriteByte(iPacket.ReadByte());
                                    outPacket.WriteInt(iPacket.ReadInt());
                                    outPacket.WriteShort(iPacket.ReadShort());
                                    Console.WriteLine($"UserNO: {UserNO} IP: {IP.Address}:{IP.Port} Nickname: {Nickname} RP: {RP} Team: {Team} ClubName: {ClubName} ClubMark_LOGO: {ClubMark_LOGO}");
                                }
                                else if (PlayerType == 7)
                                {
                                    outPacket.WriteBytes(iPacket.ReadBytes(13));
                                }
                            }
                            outPacket.WriteBytes(iPacket.ReadBytes(32));
                            for (int k = 0; k < 8; k++)
                            {
                                outPacket.WriteUInt(iPacket.ReadUInt());
                            }
                            outPacket.WriteInt(iPacket.ReadInt());
                            int endPosition = Program.HandleSpecChange(Parent.KartSpec, outPacket, iPacket);
                            iPacket.Position = endPosition;
                            outPacket.WriteBytes(iPacket.ReadBytes(iPacket.Available));
                            SendToClient(outPacket);
                        }
                        else
                        {
                            Default(iPacket);
                        }
                    }
                    else
                    {
                        Default(iPacket);
                    }
                }
            }
            else
            {
                Default(iPacket);
            }
        }
    }

    public new void Send(OutPacket oPacket)
    {
        base.Send(oPacket);
    }

    public void SendToClient(OutPacket oPacket)
    {
        lock (Parent.m_lock)
        {
            try
            {
                Parent.Client.Send(oPacket);
            }
            finally
            {
                ((IDisposable)oPacket)?.Dispose();
            }
        }
    }

    public void Default(InPacket iPacket)
    {
        using (OutPacket outPacket = new OutPacket())
        {
            outPacket.WriteBytes(iPacket.ToArray());
            SendToClient(outPacket);
        }
    }

    [DllImport("kernel32", CharSet = CharSet.Unicode)]
    private static extern long WritePrivateProfileString(string Section, string Key, string Value, string FilePath);

    [DllImport("user32.dll")]
    private static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, int dwExtraInfo);
}