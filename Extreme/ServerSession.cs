using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using KartRider;
using KartRider.Common.Add;
//using KartRider.Common.Network;
using KartRider.Common.Network2;
using KartRider.Common.Security;
using KartRider.Common.Utilities;
using KartRider.Data;
using KartRider.IO;
using RewardItemBox;

namespace Extreme;

public class ServerSession : Session
{
    public int gameStartTick = 0;

    public int game_myRealStartTick = 0;

    private bool recievedEndJewel = false;

    public SessionGroup Parent { get; set; }

    public ServerSession(SessionGroup parent, Socket socket)
        : base(socket)
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
            Console.WriteLine("Server-" + packetName + "£º" + BitConverter.ToString(iPacket.ToArray()).Replace("-", ""));
            string text = ((object)iPacket).ToString();
            string text2 = text.Substring(0, text.Length - 12);
            if (Program.ShowPacketLog)
            {
                switch (packetName)
                {
                    case PacketName.PcFirstMessage:
                        Console.WriteLine("Recv : {0} {1}", packetName, ((object)iPacket).ToString());
                        break;
                    default:
                        Console.WriteLine("Recv : {0} {1}", packetName, text2);
                        break;
                    case PacketName.S2C_NGSData:
                        break;
                }
            }
            if (Development.ShowPacketLog)
            {
                switch (packetName)
                {
                    case PacketName.PcFirstMessage:
                        {
                            TextBox text_PacketLog = Program.DevelopmentDlg.text_PacketLog;
                            text_PacketLog.Text = text_PacketLog.Text + "Recv : " + packetName.ToString() + " " + text + "\r\n";
                            break;
                        }
                    default:
                        {
                            TextBox text_PacketLog = Program.DevelopmentDlg.text_PacketLog;
                            text_PacketLog.Text = text_PacketLog.Text + "Recv : " + packetName.ToString() + " " + text2 + "\r\n";
                            break;
                        }
                    case PacketName.S2C_NGSData:
                        break;
                }
            }
            if (num == Adler32Helper.GenerateAdler32_ASCII("PcUserShutDownMessage", 0u))
            {
                return;
            }
            switch (num)
            {
                case 673908096u:
                    {
                        ushort num104 = iPacket.ReadUShort();
                        ushort num105 = iPacket.ReadUShort();
                        ushort num106 = iPacket.ReadUShort();
                        string text12 = iPacket.ReadString(false);
                        uint num107 = iPacket.ReadUInt();
                        uint num108 = iPacket.ReadUInt();
                        Parent.Server._RIV = num107 ^ num108;
                        Parent.Server._SIV = num107 ^ num108;
                        byte b17 = iPacket.ReadByte();
                        string text13 = iPacket.ReadString(false);
                        byte[] array = iPacket.ReadBytes(31);
                        string text14 = iPacket.ReadString(false);
                        Console.WriteLine("PcFirstMessage : {0} {1} {2}", num104, num105, num106);
                        Console.WriteLine("strPatch : {0}", text12);
                        Console.WriteLine("Key1 : {0}", text13);
                        Console.WriteLine("Key2 : {0}", text14);
                        Console.WriteLine("first_val : {0}", num107);
                        Console.WriteLine("second_val : {0}", num108);
                        if (Program.FakeClient)
                        {
                            Program.Client.UpdateKartRiderInfo(num104, num105, num106, text12, b17);
                        }
                        OutPacket val11 = new OutPacket(64);
                        try
                        {
                            val11.WriteUInt(673908096u);
                            val11.WriteUShort(num104);
                            val11.WriteUShort(num105);
                            val11.WriteUShort(num106);
                            val11.WriteString(text12);
                            val11.WriteUInt(num107);
                            val11.WriteUInt(num108);
                            val11.WriteByte(b17);
                            val11.WriteString(text13);
                            val11.WriteBytes(array);
                            val11.WriteString(text14);
                            SendToClient(((PacketBase)val11).ToArray());
                        }
                        finally
                        {
                            ((IDisposable)val11)?.Dispose();
                        }
                        Parent.Client._RIV = num107 ^ num108;
                        Parent.Client._SIV = num107 ^ num108;
                        break;
                    }
                default:
                    if (num != 391906320)
                    {
                        if (num == Adler32Helper.GenerateAdler32_ASCII("PrChannelSwitch", 0u))
                        {
                            OutPacket val = new OutPacket("PrChannelSwitch");
                            try
                            {
                                val.WriteInt(iPacket.ReadInt());
                                val.WriteShort(iPacket.ReadShort());
                                val.WriteShort(iPacket.ReadShort());
                                val.WriteEndPoint(IPAddress.Parse("127.0.0.1"), (ushort)39312);
                                RouterListener.ForceConnect = $"{iPacket.ReadByte()}.{iPacket.ReadByte()}.{iPacket.ReadByte()}.{iPacket.ReadByte()}";
                                RouterListener.NewConnRequest = true;
                                SendToClient(((PacketBase)val).ToArray());
                                break;
                            }
                            finally
                            {
                                ((IDisposable)val)?.Dispose();
                            }
                        }
                        if (num == Adler32Helper.GenerateAdler32_ASCII("PcMove4MyRoom", 0u))
                        {
                            OutPacket val2 = new OutPacket("PcMove4MyRoom");
                            try
                            {
                                val2.WriteInt(iPacket.ReadInt());
                                val2.WriteShort(iPacket.ReadShort());
                                val2.WriteShort(iPacket.ReadShort());
                                val2.WriteBytes(iPacket.ReadBytes(4));
                                val2.WriteEndPoint(IPAddress.Parse("127.0.0.1"), (ushort)39312);
                                RouterListener.ForceConnect = $"{iPacket.ReadByte()}.{iPacket.ReadByte()}.{iPacket.ReadByte()}.{iPacket.ReadByte()}";
                                SendToClient(((PacketBase)val2).ToArray());
                                break;
                            }
                            finally
                            {
                                ((IDisposable)val2)?.Dispose();
                            }
                        }
                        if (num == Adler32Helper.GenerateAdler32_ASCII("PrBingoSync", 0u))
                        {
                            bool flag = iPacket.ReadBool();
                            ushort num2 = iPacket.ReadUShort();
                            ushort num3 = iPacket.ReadUShort();
                            Console.WriteLine("BingoSync : MyLap: {0}, BingoBall: {1}", num2, num3);
                            SendToClient(((PacketBase)iPacket).ToArray());
                            break;
                        }
                        if (num == Adler32Helper.GenerateAdler32_ASCII("PrBingoSelectNum", 0u))
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
                            SendToClient(((PacketBase)iPacket).ToArray());
                            break;
                        }
                        if (num == Adler32Helper.GenerateAdler32_ASCII("PrBlueMarble", 0u))
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
                                        OutPacket val15 = new OutPacket("PqBlueMarble");
                                        try
                                        {
                                            OutPacket val16 = new OutPacket(4);
                                            val16.WriteTime(DateTime.Now);
                                            byte[] array2 = KREncodedBlock.Encode(((PacketBase)val16).ToArray(), (KREncodedBlock.EncodeFlag)2, (uint?)2242368262u);
                                            val15.WriteInt(array2.Length);
                                            val15.WriteBytes(array2);
                                            val15.WriteInt(1);
                                            Send(val15);
                                        }
                                        finally
                                        {
                                            ((IDisposable)val15)?.Dispose();
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
                            SendToClient(((PacketBase)iPacket).ToArray());
                            break;
                        }
                        if (num == 1006110391 || num == 1396836340 || num == 349832159 || num == 1127745326)
                        {
                            OutPacket val3 = new OutPacket(64);
                            try
                            {
                                val3.WriteUInt(num);
                                if (num == 1006110391)
                                {
                                    val3.WriteInt(iPacket.ReadInt());
                                    val3.WriteInt(iPacket.ReadInt());
                                }
                                if (num == 1396836340 || num == 349832159 || num == 1127745326)
                                {
                                    val3.WriteByte(iPacket.ReadByte());
                                }
                                Program.HandleSpecChange(Parent.KartSpec, val3, iPacket);
                                if (num == 1006110391)
                                {
                                    val3.WriteByte(iPacket.ReadByte());
                                    val3.WriteInt(iPacket.ReadInt());
                                    val3.WriteInt(iPacket.ReadInt());
                                    val3.WriteInt(iPacket.ReadInt());
                                    val3.WriteInt(iPacket.ReadInt());
                                    val3.WriteInt(iPacket.ReadInt());
                                }
                                if (num == 1396836340)
                                {
                                    val3.WriteInt(iPacket.ReadInt());
                                }
                                if (num == 1396836340 || num == 349832159)
                                {
                                    val3.WriteByte(iPacket.ReadByte());
                                }
                                SendToClient(((PacketBase)val3).ToArray());
                                break;
                            }
                            finally
                            {
                                ((IDisposable)val3)?.Dispose();
                            }
                        }
                        if (num == Adler32Helper.GenerateAdler32_ASCII("PrGetRider", 0u))
                        {
                            OutPacket val4 = new OutPacket("PrGetRider");
                            try
                            {
                                byte b3 = iPacket.ReadByte();
                                val4.WriteByte(b3);
                                byte b4 = iPacket.ReadByte();
                                val4.WriteByte(b4);
                                if (b3 == 1)
                                {
                                    SessionGroup.RiderName = iPacket.ReadString(false);
                                    val4.WriteString(SessionGroup.RiderName);
                                    for (int l = 0; l < 5; l++)
                                    {
                                        val4.WriteShort(iPacket.ReadShort());
                                    }
                                    for (int m = 0; m <= Program.MAX_EQP_P; m++)
                                    {
                                        val4.WriteShort(iPacket.ReadShort());
                                    }
                                    val4.WriteByte(iPacket.ReadByte());
                                    val4.WriteString(iPacket.ReadString(false));
                                    SessionGroup.Lucci = iPacket.ReadUInt();
                                    val4.WriteUInt(SessionGroup.Lucci);
                                    SessionGroup.RP = iPacket.ReadInt();
                                    val4.WriteInt(SessionGroup.RP);
                                    Console.WriteLine("Rider {0} logged in!", SessionGroup.RiderName);
                                    val4.WriteBytes(iPacket.ReadBytes(iPacket.Available));
                                    if (Program.FakeClient)
                                    {
                                        Program.Client.UpdateRiderName(SessionGroup.RiderName);
                                        Program.Client.UpdateLucci(SessionGroup.Lucci);
                                        Program.Client.UpdateRP(SessionGroup.RP);
                                    }
                                }
                                SendToClient(((PacketBase)val4).ToArray());
                                break;
                            }
                            finally
                            {
                                ((IDisposable)val4)?.Dispose();
                            }
                        }
                        if (num == Adler32Helper.GenerateAdler32(Encoding.ASCII.GetBytes("ChRpEnterMyRoomPacket"), 0u))
                        {
                            OutPacket val5 = new OutPacket("ChRpEnterMyRoomPacket");
                            try
                            {
                                string text3 = iPacket.ReadString(false);
                                val5.WriteString(text3);
                                val5.WriteByte(iPacket.ReadByte());
                                val5.WriteShort(iPacket.ReadShort());
                                byte b5 = iPacket.ReadByte();
                                val5.WriteByte(b5);
                                val5.WriteByte(iPacket.ReadByte());
                                val5.WriteByte(iPacket.ReadByte());
                                val5.WriteByte(iPacket.ReadByte());
                                val5.WriteByte(iPacket.ReadByte());
                                string text4 = iPacket.ReadString(false);
                                val5.WriteString(text4);
                                val5.WriteString(iPacket.ReadString(false));
                                string text5 = iPacket.ReadString(false);
                                val5.WriteString(text5);
                                val5.WriteShort(iPacket.ReadShort());
                                val5.WriteShort(iPacket.ReadShort());
                                Console.WriteLine("MyRoom Data--------------------------------");
                                Console.WriteLine("Nickname: {0}", text3);
                                Console.WriteLine("ROOM PWD: {0}", text4);
                                Console.WriteLine("ITEM PWD: {0}", text5);
                                Console.WriteLine("-------------------------------------------");
                                Console.WriteLine(text2);
                                SendToClient(((PacketBase)val5).ToArray());
                                break;
                            }
                            finally
                            {
                                ((IDisposable)val5)?.Dispose();
                            }
                        }
                        if (num == Adler32Helper.GenerateAdler32_ASCII("PrLevelUpCheckPacket", 0u))
                        {
                            int num18 = iPacket.ReadInt();
                            for (int n = 0; n < num18; n++)
                            {
                                iPacket.ReadByte();
                                int num19 = iPacket.ReadInt();
                                using (StreamWriter streamWriter = new StreamWriter("LevelUpCheck.log", append: true))
                                {
                                    streamWriter.Write("[{0}] RewardLucci: {1} ", DateTime.Now, num19);
                                    Console.Write("[{0}] RewardLucci: {1} ", DateTime.Now, num19);
                                }
                                int num20 = iPacket.ReadInt();
                                for (int num21 = 0; num21 < num20; num21++)
                                {
                                    int num22 = iPacket.ReadInt();
                                    using StreamWriter streamWriter2 = new StreamWriter("LevelUpCheck.log", append: true);
                                    streamWriter2.Write("Stock: {0} ", num22);
                                    Console.Write("Stock: {0} ", num22);
                                }
                                iPacket.ReadInt();
                                iPacket.ReadByte();
                                int num23 = iPacket.ReadInt();
                                Leveltable leveltable = (Leveltable)num23;
                                using StreamWriter streamWriter3 = new StreamWriter("LevelUpCheck.log", append: true);
                                streamWriter3.WriteLine("NextRp: {0} {1}", num23, leveltable);
                                Console.WriteLine("NextRp: {0} {1}", num23, leveltable);
                            }
                            if (!RouterForm.GameRaceMacro && !RouterForm.pwnJewel && !RouterForm.GameFastRaceMacro)
                            {
                                SendToClient(((PacketBase)iPacket).ToArray());
                            }
                            break;
                        }
                        /*
                        if (num == 1357645790 || num == 1625229448 || num == 1950091637 || num == 863766061)
                        {
                            if (num != 863766061)
                            {
                                SuspiciousRaceCheck.SuspiciousRaceCheckLog = true;
                                if (Program.AntiHack)
                                {
                                    Program.HackPwnDlg.ClearCurUsers();
                                }
                            }
                            OutPacket val6 = new OutPacket(64);
                            try
                            {
                                val6.WriteUInt(num);
                                if (num != 863766061)
                                {
                                    val6.WriteUInt(iPacket.ReadUInt());
                                    string text6 = iPacket.ReadString(false);
                                    val6.WriteString(text6);
                                    val6.WriteString(iPacket.ReadString(false));
                                    SessionGroup.GameType = iPacket.ReadByte();
                                    byte b6 = iPacket.ReadByte();
                                    val6.WriteByte(SessionGroup.GameType);
                                    val6.WriteByte(b6);
                                    val6.WriteInt(iPacket.ReadInt());
                                    val6.WriteByte(iPacket.ReadByte());
                                    val6.WriteUInt(iPacket.ReadUInt());
                                    val6.WriteUInt(iPacket.ReadUInt());
                                    val6.WriteByte(iPacket.ReadByte());
                                    val6.WriteByte(iPacket.ReadByte());
                                    val6.WriteUInt(iPacket.ReadUInt());
                                }
                                uint num24 = iPacket.ReadUInt();
                                val6.WriteUInt(num24);
                                val6.WriteBytes(iPacket.ReadBytes(36));
                                SessionGroup.RoomMaster = iPacket.ReadInt();
                                val6.WriteInt(SessionGroup.RoomMaster);
                                val6.WriteBytes(iPacket.ReadBytes(11));
                                int num25 = iPacket.ReadInt();
                                val6.WriteInt(num25);
                                for (int num26 = 0; num26 < num25; num26++)
                                {
                                    val6.WriteByte(iPacket.ReadByte());
                                }
                                for (int num27 = 0; num27 < 4; num27++)
                                {
                                    val6.WriteInt(iPacket.ReadInt());
                                }
                                for (int num28 = 0; num28 < 16; num28++)
                                {
                                    int num29 = iPacket.ReadInt();
                                    val6.WriteInt(num29);
                                    if (num29 == 2 || num29 == 3 || num29 == 5)
                                    {
                                        uint num30 = iPacket.ReadUInt();
                                        if (num30 == SessionGroup.UserNO)
                                        {
                                            Program.MySlot = num28;
                                        }
                                        val6.WriteUInt(num30);
                                        IPEndPoint iPEndPoint = new IPEndPoint(new IPAddress(iPacket.ReadBytes(4)), iPacket.ReadUShort());
                                        IPEndPoint iPEndPoint2 = new IPEndPoint(new IPAddress(iPacket.ReadBytes(4)), iPacket.ReadUShort());
                                        val6.WriteEndPoint(iPEndPoint);
                                        val6.WriteEndPoint(iPEndPoint2);
                                        string text7 = iPacket.ReadString(false);
                                        if (num != 863766061)
                                        {
                                            Console.WriteLine(text7);
                                            Console.WriteLine(num28);
                                            Console.WriteLine("Public: {0}", iPEndPoint);
                                            Console.WriteLine("Private: {0}", iPEndPoint2);
                                            if (Program.AntiHack)
                                            {
                                                Program.HackPwnDlg.AddCurUser(text7, num30, num28);
                                                if (Program.HackPwnDlg.HasUser(num30))
                                                {
                                                    RouterForm.Disconnect(num28);
                                                }
                                            }
                                            if (Program.ListHacks.Contains(text7))
                                            {
                                                Console.WriteLine("Disconnecting {0}", text7);
                                                RouterForm.Disconnect(num28);
                                            }
                                        }
                                        short num31 = iPacket.ReadShort();
                                        short num32 = iPacket.ReadShort();
                                        val6.WriteString(text7);
                                        val6.WriteShort(num31);
                                        val6.WriteShort(num32);
                                        val6.WriteShort(iPacket.ReadShort());
                                        if (num != 863766061)
                                        {
                                            short num33 = iPacket.ReadShort();
                                            if (num33 == 0)
                                            {
                                                val6.WriteShort((short)1);
                                            }
                                            else
                                            {
                                                val6.WriteShort(num33);
                                            }
                                            short num34 = iPacket.ReadShort();
                                            if (num34 == 0)
                                            {
                                                val6.WriteShort((short)6);
                                            }
                                            else
                                            {
                                                val6.WriteShort(num34);
                                            }
                                            short num35 = iPacket.ReadShort();
                                            val6.WriteShort(num35);
                                            short num36 = iPacket.ReadShort();
                                            val6.WriteShort(num36);
                                            short num37 = iPacket.ReadShort();
                                            val6.WriteShort(num37);
                                            short num38 = iPacket.ReadShort();
                                            val6.WriteShort(num38);
                                            short num39 = iPacket.ReadShort();
                                            val6.WriteShort(num39);
                                            short num40 = iPacket.ReadShort();
                                            val6.WriteShort(num40);
                                            short num41 = iPacket.ReadShort();
                                            val6.WriteShort(num41);
                                            short num42 = iPacket.ReadShort();
                                            val6.WriteShort(num42);
                                            short num43 = iPacket.ReadShort();
                                            val6.WriteShort(num43);
                                            short num44 = iPacket.ReadShort();
                                            val6.WriteShort(num44);
                                            short num45 = iPacket.ReadShort();
                                            val6.WriteShort(num45);
                                            short num46 = iPacket.ReadShort();
                                            val6.WriteShort(num46);
                                            short num47 = iPacket.ReadShort();
                                            val6.WriteShort(num47);
                                            short num48 = iPacket.ReadShort();
                                            val6.WriteShort(num48);
                                            short num49 = iPacket.ReadShort();
                                            val6.WriteShort(num49);
                                            short num50 = iPacket.ReadShort();
                                            val6.WriteShort(num50);
                                            short num51 = iPacket.ReadShort();
                                            val6.WriteShort(num51);
                                            short num52 = iPacket.ReadShort();
                                            val6.WriteShort(num52);
                                            short num53 = iPacket.ReadShort();
                                            val6.WriteShort(num53);
                                            short num54 = iPacket.ReadShort();
                                            val6.WriteShort(num54);
                                            short num55 = iPacket.ReadShort();
                                            val6.WriteShort(num55);
                                            short num56 = iPacket.ReadShort();
                                            val6.WriteShort(num56);
                                            short num57 = iPacket.ReadShort();
                                            val6.WriteShort(num57);
                                            short num58 = iPacket.ReadShort();
                                            val6.WriteShort(num58);
                                            short num59 = iPacket.ReadShort();
                                            val6.WriteShort(num59);
                                            short num60 = iPacket.ReadShort();
                                            val6.WriteShort(num60);
                                            short num61 = iPacket.ReadShort();
                                            if (num61 == 0)
                                            {
                                                val6.WriteShort((short)6);
                                            }
                                            else
                                            {
                                                val6.WriteShort(num61);
                                            }
                                            short num62 = iPacket.ReadShort();
                                            val6.WriteShort(num62);
                                            short num63 = iPacket.ReadShort();
                                            val6.WriteShort(num63);
                                            short num64 = iPacket.ReadShort();
                                            val6.WriteShort(num64);
                                        }
                                        else
                                        {
                                            for (int num65 = 0; num65 <= Program.MAX_EQP_P; num65++)
                                            {
                                                val6.WriteShort(iPacket.ReadShort());
                                            }
                                        }
                                        val6.WriteByte(iPacket.ReadByte());
                                        val6.WriteString(iPacket.ReadString(false));
                                        int num66 = iPacket.ReadInt();
                                        val6.WriteInt(num66);
                                        byte b7 = iPacket.ReadByte();
                                        val6.WriteByte(b7);
                                        val6.WriteByte(iPacket.ReadByte());
                                        val6.WriteByte(iPacket.ReadByte());
                                        for (int num67 = 0; num67 < 8; num67++)
                                        {
                                            val6.WriteInt(iPacket.ReadInt());
                                        }
                                        val6.WriteInt(iPacket.ReadInt());
                                        val6.WriteInt(iPacket.ReadInt());
                                        val6.WriteInt(iPacket.ReadInt());
                                        val6.WriteInt(iPacket.ReadInt());
                                        val6.WriteInt(iPacket.ReadInt());
                                        val6.WriteByte(iPacket.ReadByte());
                                        val6.WriteByte(iPacket.ReadByte());
                                        val6.WriteByte(iPacket.ReadByte());
                                        val6.WriteByte(iPacket.ReadByte());
                                        byte b8 = iPacket.ReadByte();
                                        string text8 = iPacket.ReadString(false);
                                        int num68 = iPacket.ReadInt();
                                        int num69 = iPacket.ReadInt();
                                        val6.WriteByte(b8);
                                        val6.WriteString(text8);
                                        val6.WriteInt(num68);
                                        val6.WriteInt(num69);
                                        val6.WriteInt(iPacket.ReadInt());
                                        val6.WriteInt(iPacket.ReadInt());
                                        byte b9 = iPacket.ReadByte();
                                        val6.WriteByte(b9);
                                        val6.WriteInt(iPacket.ReadInt());
                                        continue;
                                    }
                                    switch (num29)
                                    {
                                        case 4:
                                            {
                                                uint num70 = iPacket.ReadUInt();
                                                if (num70 == SessionGroup.UserNO)
                                                {
                                                    Program.MySlot = num28;
                                                }
                                                val6.WriteUInt(num70);
                                                IPEndPoint iPEndPoint3 = new IPEndPoint(new IPAddress(iPacket.ReadBytes(4)), iPacket.ReadUShort());
                                                IPEndPoint iPEndPoint4 = new IPEndPoint(new IPAddress(iPacket.ReadBytes(4)), iPacket.ReadUShort());
                                                string text9 = iPacket.ReadString(false);
                                                Console.WriteLine("Observer: {0}", text9);
                                                Console.WriteLine("IP: {0}, {1}", iPEndPoint3, iPEndPoint4);
                                                val6.WriteEndPoint(iPEndPoint3);
                                                val6.WriteEndPoint(iPEndPoint4);
                                                val6.WriteString(text9);
                                                break;
                                            }
                                        case 7:
                                            if (num != 863766061)
                                            {
                                                Console.WriteLine("AI Slot : {0}", num28);
                                                Parent.AISlot = num28;
                                            }
                                            val6.WriteShort(iPacket.ReadShort());
                                            val6.WriteShort(iPacket.ReadShort());
                                            val6.WriteShort(iPacket.ReadShort());
                                            val6.WriteShort(iPacket.ReadShort());
                                            val6.WriteShort(iPacket.ReadShort());
                                            val6.WriteShort(iPacket.ReadShort());
                                            val6.WriteByte(iPacket.ReadByte());
                                            break;
                                    }
                                }
                                for (int num71 = 0; num71 < 8; num71++)
                                {
                                    val6.WriteUInt(iPacket.ReadUInt());
                                }
                                if (num != 863766061)
                                {
                                    val6.WriteInt(iPacket.ReadInt());
                                    Program.HandleSpecChange(Parent.KartSpec, val6, iPacket);
                                    int num72 = iPacket.ReadInt();
                                    val6.WriteInt(num72);
                                    for (int num73 = 0; num73 < num72; num73++)
                                    {
                                        val6.WriteEncFloat(iPacket.ReadEncodedFloat());
                                        val6.WriteEncFloat(iPacket.ReadEncodedFloat());
                                        val6.WriteEncFloat(iPacket.ReadEncodedFloat());
                                        val6.WriteEncFloat(iPacket.ReadEncodedFloat());
                                        val6.WriteEncFloat(iPacket.ReadEncodedFloat());
                                        val6.WriteEncFloat(iPacket.ReadEncodedFloat());
                                    }
                                    SessionGroup.Track = iPacket.ReadUInt();
                                    val6.WriteUInt(SessionGroup.Track);
                                    SuspiciousRaceCheck.SuspiciousRaceCheckLog = true;
                                    SuspiciousRaceCheck.RaceTimeCheck();
                                    val6.WriteInt(iPacket.ReadInt());
                                    val6.WriteString(iPacket.ReadString(false));
                                    val6.WriteInt(iPacket.ReadInt());
                                    val6.WriteByte(iPacket.ReadByte());
                                    val6.WriteByte(iPacket.ReadByte());
                                    val6.WriteInt(iPacket.ReadInt());
                                    val6.WriteInt(iPacket.ReadInt());
                                    val6.WriteUInt(iPacket.ReadUInt());
                                    val6.WriteByte(iPacket.ReadByte());
                                    val6.WriteInt(iPacket.ReadInt());
                                    string text10 = iPacket.ReadString(false);
                                    val6.WriteString(text10);
                                    switch (num)
                                    {
                                        case 1625229448u:
                                            val6.WriteInt(iPacket.ReadInt());
                                            break;
                                        case 1950091637u:
                                            {
                                                short num74 = iPacket.ReadShort();
                                                byte b10 = iPacket.ReadByte();
                                                byte b11 = iPacket.ReadByte();
                                                byte b12 = iPacket.ReadByte();
                                                float num75 = iPacket.ReadFloat();
                                                ushort num76 = iPacket.ReadUShort();
                                                val6.WriteShort(num74);
                                                val6.WriteByte(b10);
                                                val6.WriteByte(b11);
                                                val6.WriteByte(b12);
                                                val6.WriteFloat(num75);
                                                val6.WriteInt((int)num76);
                                                val6.WriteShort(iPacket.ReadShort());
                                                for (int num77 = 0; num77 < 7; num77++)
                                                {
                                                    val6.WriteInt(iPacket.ReadInt());
                                                }
                                                break;
                                            }
                                    }
                                }
                                val6.WriteBytes(iPacket.ReadBytes(iPacket.Available));
                                SendToClient(((PacketBase)val6).ToArray());
                                break;
                            }
                            finally
                            {
                                ((IDisposable)val6)?.Dispose();
                            }
                        }
                        */
                        if (num == Adler32Helper.GenerateAdler32_ASCII("GameControlPacket", 0u))
                        {
                            OutPacket val7 = new OutPacket("GameControlPacket");
                            try
                            {
                                int num78 = iPacket.ReadInt();
                                byte b13 = iPacket.ReadByte();
                                val7.WriteInt(num78);
                                val7.WriteByte(b13);
                                if (b13 != 0)
                                {
                                    val7.WriteInt(iPacket.ReadInt());
                                    val7.WriteInt(iPacket.ReadInt());
                                }
                                int num79 = iPacket.ReadInt();
                                val7.WriteInt(num79);
                                val7.WriteBytes(iPacket.ReadBytes(iPacket.Available));
                                SendToClient(((PacketBase)val7).ToArray());
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
                                break;
                            }
                            finally
                            {
                                ((IDisposable)val7)?.Dispose();
                            }
                        }
                        if (num == Adler32Helper.GenerateAdler32_ASCII("SingleProcessJewelPacket", 0u) || num == Adler32Helper.GenerateAdler32_ASCII("GameJewelPacket", 0u))
                        {
                            if (num == 1995966864)
                            {
                                Console.WriteLine("SingleProcessJewelPacket: {0}", text2);
                            }
                            if (num == 754386377)
                            {
                                Console.WriteLine("GameJewelPacket: {0}", text2);
                            }
                            SendToClient(((PacketBase)iPacket).ToArray());
                            if (RouterForm.pwnJewel)
                            {
                                recievedEndJewel = true;
                            }
                            break;
                        }
                        if (num == Adler32Helper.GenerateAdler32_ASCII("GameRaceTimePacket", 0u))
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
                            SendToClient(((PacketBase)iPacket).ToArray());
                            if (RouterForm.pwnJewel)
                            {
                                new Thread((ThreadStart)delegate
                                {
                                    while (!recievedEndJewel)
                                    {
                                        Thread.Sleep(300);
                                        OutPacket val14 = new OutPacket("GameBoosterAddPacket");
                                        try
                                        {
                                            Send(val14);
                                        }
                                        finally
                                        {
                                            ((IDisposable)val14)?.Dispose();
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
                            break;
                        }
                        if (num == Adler32Helper.GenerateAdler32_ASCII("LoRpAddRacingTimePacket", 0u))
                        {
                            int num84 = iPacket.ReadInt();
                            SessionGroup.min = num84 / 60000;
                            int num85 = num84 - SessionGroup.min * 60000;
                            SessionGroup.sec = num85 / 1000;
                            SessionGroup.mil = num84 % 1000;
                            Console.WriteLine("LoRpAddRacingTimePacket: {0} ({1}:{2}:{3})", num84, SessionGroup.min, SessionGroup.sec, SessionGroup.mil);
                            SendToClient(((PacketBase)iPacket).ToArray());
                            break;
                        }
                        if (num == Adler32Helper.GenerateAdler32_ASCII("GrSessionDataPacket", 0u))
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
                            SendToClient(((PacketBase)iPacket).ToArray());
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
                            break;
                        }
                        if (num == Adler32Helper.GenerateAdler32(Encoding.ASCII.GetBytes("RmOwnerItemPacket"), 0u))
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
                            SendToClient(((PacketBase)iPacket).ToArray());
                            break;
                        }
                        if (num == Adler32Helper.GenerateAdler32(Encoding.ASCII.GetBytes("LoRpGetRiderItemPacket"), 0u))
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
                            OutPacket val8 = new OutPacket("LoRpGetRiderItemPacket");
                            try
                            {
                                val8.WriteInt(num90);
                                val8.WriteInt(num91);
                                val8.WriteInt(list2.Count);
                                foreach (Item item3 in list2)
                                {
                                    item3.Unk2 = 0;
                                    item3.Unk3 = 0;
                                    item3.Encode(val8);
                                }
                                SendToClient(((PacketBase)val8).ToArray());
                                break;
                            }
                            finally
                            {
                                ((IDisposable)val8)?.Dispose();
                            }
                        }
                        if (num == Adler32Helper.GenerateAdler32_ASCII("PrEnterFishingPacket", 0u))
                        {
                            string text11 = ((object)iPacket).ToString();
                            SessionGroup.Fishing = text11.Substring(24, 132);
                            SendToClient(((PacketBase)iPacket).ToArray());
                        }
                        else if (num == Adler32Helper.GenerateAdler32_ASCII("PrEndFishingPacket", 0u))
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
                            SendToClient(((PacketBase)iPacket).ToArray());
                        }
                        else if (num == Adler32Helper.GenerateAdler32_ASCII("SpRpLotteryPacket", 0u))
                        {
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
                                    OutPacket val12 = new OutPacket("SpRqLotteryPacket");
                                    try
                                    {
                                        val12.WriteShort((short)LotteryID);
                                        val12.WriteBool(true);
                                        val12.WriteInt(LotteryType);
                                        Send(val12);
                                    }
                                    finally
                                    {
                                        ((IDisposable)val12)?.Dispose();
                                    }
                                    if (LotteryType == 2)
                                    {
                                        Thread.Sleep(300);
                                        OutPacket val13 = new OutPacket("SpRqBingoGachaPacket");
                                        try
                                        {
                                            val13.WriteInt(3);
                                            Send(val13);
                                        }
                                        finally
                                        {
                                            ((IDisposable)val13)?.Dispose();
                                        }
                                    }
                                }).Start();
                            }
                            if (type != 5)
                            {
                                SendToClient(((PacketBase)iPacket).ToArray());
                            }
                        }
                        else if (num == Adler32Helper.GenerateAdler32_ASCII("SpRpGetRewardBoxListPacket", 0u))
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
                                SendToClient(((PacketBase)iPacket).ToArray());
                            }
                        }
                        else if (num != Adler32Helper.GenerateAdler32_ASCII("SpRpReceiveRewardItemPacket", 0u))
                        {
                            if (num == Adler32Helper.GenerateAdler32_ASCII("PrLogin", 0u))
                            {
                                int num101 = iPacket.ReadInt();
                                switch (num101)
                                {
                                    case 0:
                                        {
                                            OutPacket val9 = new OutPacket("PrLogin");
                                            try
                                            {
                                                val9.WriteInt(num101);
                                                val9.WriteBytes(iPacket.ReadBytes(4));
                                                SessionGroup.UserNO = iPacket.ReadUInt();
                                                SessionGroup.UserID = iPacket.ReadString(false);
                                                if (Program.FakeClient)
                                                {
                                                    Program.Client.UpdateAccountInfo(SessionGroup.UserNO, SessionGroup.UserID);
                                                }
                                                val9.WriteUInt(SessionGroup.UserNO);
                                                val9.WriteString(SessionGroup.UserID);
                                                val9.WriteByte(iPacket.ReadByte());
                                                val9.WriteByte(iPacket.ReadByte());
                                                val9.WriteByte(iPacket.ReadByte());
                                                val9.WriteInt(iPacket.ReadInt());
                                                val9.WriteByte(iPacket.ReadByte());
                                                val9.WriteBytes(iPacket.ReadBytes(4));
                                                uint num102 = iPacket.ReadUInt();
                                                val9.WriteUInt(1068u);
                                                for (int num103 = 0; num103 < 11; num103++)
                                                {
                                                    val9.WriteInt(iPacket.ReadInt());
                                                }
                                                val9.WriteByte(iPacket.ReadByte());
                                                IPEndPoint arg2 = new IPEndPoint(new IPAddress(iPacket.ReadBytes(4)), iPacket.ReadUShort());
                                                IPEndPoint arg3 = new IPEndPoint(new IPAddress(iPacket.ReadBytes(4)), iPacket.ReadUShort());
                                                Console.WriteLine("Login: uid: {0}, rid: {1}, pmap: {2}", SessionGroup.UserID, SessionGroup.UserNO, num102);
                                                Console.WriteLine("Server: {0}, {1}", arg2, arg3);
                                                val9.WriteEndPoint(IPAddress.Parse(RouterListener.forceConnect), (ushort)39311);
                                                val9.WriteEndPoint(IPAddress.Parse(RouterListener.forceConnect), (ushort)39312);
                                                val9.WriteInt(iPacket.ReadInt());
                                                val9.WriteInt(iPacket.ReadInt());
                                                val9.WriteInt(iPacket.ReadInt());
                                                val9.WriteByte(iPacket.ReadByte());
                                                val9.WriteString(iPacket.ReadString());
                                                val9.WriteInt(iPacket.ReadInt());
                                                val9.WriteInt(iPacket.ReadInt());
                                                val9.WriteString(iPacket.ReadString());
                                                val9.WriteString(iPacket.ReadString());
                                                val9.WriteInt(4);
                                                val9.WriteString("content");
                                                val9.WriteInt(0);
                                                val9.WriteInt(2);
                                                val9.WriteString("name");
                                                val9.WriteString("dynamicPpl");
                                                val9.WriteString("enable");
                                                val9.WriteString("false");
                                                val9.WriteInt(1);
                                                val9.WriteString("region");
                                                val9.WriteInt(0);
                                                val9.WriteInt(1);
                                                val9.WriteString("szId");
                                                val9.WriteString("3002");
                                                val9.WriteInt(0);
                                                val9.WriteString("content");
                                                val9.WriteInt(0);
                                                val9.WriteInt(3);
                                                val9.WriteString("name");
                                                val9.WriteString("endingBanner");
                                                val9.WriteString("enable");
                                                val9.WriteString("false");
                                                val9.WriteString("value");
                                                val9.WriteString("http://popkart.tiancity.com/homepage/endbanner.html");
                                                val9.WriteInt(0);
                                                val9.WriteString("content");
                                                val9.WriteInt(0);
                                                val9.WriteInt(3);
                                                val9.WriteString("name");
                                                val9.WriteString("themeXyy");
                                                val9.WriteString("enable");
                                                val9.WriteString("true");
                                                val9.WriteString("visible");
                                                val9.WriteString("true");
                                                val9.WriteInt(0);
                                                val9.WriteString("content");
                                                val9.WriteInt(0);
                                                val9.WriteInt(3);
                                                val9.WriteString("name");
                                                val9.WriteString("themeKorea");
                                                val9.WriteString("enable");
                                                val9.WriteString("true");
                                                val9.WriteString("visible");
                                                val9.WriteString("true");
                                                val9.WriteInt(0);
                                                val9.WriteByte(0);
                                                val9.WriteByte(0);
                                                val9.WriteByte(1);
                                                val9.WriteHexString("EA 2F A7 17");
                                                SendToClient(((PacketBase)val9).ToArray());
                                                break;
                                            }
                                            finally
                                            {
                                                ((IDisposable)val9)?.Dispose();
                                            }
                                        }
                                    case 4:
                                        SendToClient(((PacketBase)iPacket).ToArray());
                                        break;
                                    default:
                                        SendToClient(((PacketBase)iPacket).ToArray());
                                        break;
                                }
                            }
                            else
                            {
                                SendToClient(((PacketBase)iPacket).ToArray());
                            }
                        }
                        else if (iPacket.ReadInt() != 0)
                        {
                            Parent.RequestRewardBox = false;
                        }
                        else if (!Parent.RequestRewardBox)
                        {
                            SendToClient(((PacketBase)iPacket).ToArray());
                        }
                        else
                        {
                            new Thread((ThreadStart)delegate
                            {
                                Thread.Sleep(60);
                                Parent.SendGetRewardBox();
                            }).Start();
                        }
                        break;
                    }
                    goto case 765724105u;
                case 765724105u:
                    {
                        OutPacket val10 = new OutPacket(64);
                        try
                        {
                            val10.WriteUInt(num);
                            val10.WriteByte(iPacket.ReadByte());
                            IPEndPoint arg4 = new IPEndPoint(new IPAddress(iPacket.ReadBytes(4)), iPacket.ReadUShort());
                            IPEndPoint arg5 = new IPEndPoint(new IPAddress(iPacket.ReadBytes(4)), iPacket.ReadUShort());
                            Console.WriteLine("Server: {0}, {1}", arg4, arg5);
                            val10.WriteEndPoint(IPAddress.Parse(RouterListener.forceConnect), (ushort)39311);
                            val10.WriteEndPoint(IPAddress.Parse(RouterListener.forceConnect), (ushort)39312);
                            if (num == 391906320)
                            {
                                val10.WriteBytes(iPacket.ReadBytes(6));
                            }
                            SendToClient(((PacketBase)val10).ToArray());
                            break;
                        }
                        finally
                        {
                            ((IDisposable)val10)?.Dispose();
                        }
                    }
            }
        }
    }

    public new void Send(OutPacket oPacket)
    {
        PacketName packetName = (PacketName)BitConverter.ToUInt32(((PacketBase)oPacket).ToArray(), 0);
        if (Program.ShowPacketLog && packetName != PacketName.C2S_NGSData)
        {
            Console.WriteLine("Send : {0} {1}", (PacketName)BitConverter.ToUInt32(((PacketBase)oPacket).ToArray(), 0), ((object)oPacket).ToString());
        }
        if (Development.ShowPacketLog && packetName != PacketName.C2S_NGSData)
        {
            TextBox text_PacketLog = Program.DevelopmentDlg.text_PacketLog;
            text_PacketLog.Text = text_PacketLog.Text + "Send : " + ((PacketName)BitConverter.ToUInt32(((PacketBase)oPacket).ToArray(), 0)).ToString() + " " + ((object)oPacket).ToString() + "\r\n";
        }
        base.Send(oPacket);
    }

    public void SendToClient(byte[] data)
    {
        lock (Parent.m_lock)
        {
            OutPacket val = new OutPacket(64);
            //Console.WriteLine("SendToClient-" + (PacketName)BitConverter.ToUInt32(data, 0) + "£º" + BitConverter.ToString(data).Replace("-", ""));
            try
            {
                val.WriteBytes(data);
                Parent.Client.Send(val);
            }
            finally
            {
                ((IDisposable)val)?.Dispose();
            }
        }
    }

    [DllImport("kernel32", CharSet = CharSet.Unicode)]
    private static extern long WritePrivateProfileString(string Section, string Key, string Value, string FilePath);

    [DllImport("user32.dll")]
    private static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, int dwExtraInfo);
}
