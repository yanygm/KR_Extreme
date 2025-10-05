using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using KartRider.Challenger;
using KartRider.Common.Data;
using KartRider.Common.Network;
using KartRider.Common.Security;
using KartRider.Common.Utilities;
using KartRider.IO;
using KartRider.Licenses;
using Microsoft.Win32;
using static KartRider.Common.Data.PINFile;

namespace Extreme;

public class RouterForm : Form
{
    public static bool GameFastRaceMacro;

    public static bool GameRaceMacro;

    public static int LotteryCount;

    public static bool VersusModeMacro;

    public static bool pwnJewel;

    public static int MarbleCount;

    public static bool GameGoalTime;

    public static bool GameRaceTime;

    public static bool AFKBlockCatch = false;

    public static int RaceTime = 30000;

    private IContainer components = null;

    private Button button2;

    private Button button3;

    private Button button6;

    public TextBox txLotteryType;

    private Button btnLottery;

    public TextBox txLotteryCount;

    public TextBox txLotteryID;

    private Button button8;

    private Button button10;

    private Button button11;

    private Button button12;

    private Button button14;

    private Button button21;

    private Button button18;

    private TextBox tx_GoRoomSpamUserNO;

    private Button button23;

    private Button btnMarble;

    private TextBox txMarbleCount;

    private Button button26;

    private TextBox txGoalinRiderSlot;

    private Button btnGoalin;

    private Button button20;

    private Button button28;

    private Button button27;

    private TextBox tx_DL_RiderId;

    private Button button32;

    public TextBox myRoomUserNo;

    private TextBox txUseKoin_NickName;

    private Button button19;

    private TextBox tbx_HackList;

    private Button button38;

    private Button button1;

    private Button button25;

    public TextBox tx_Laps;

    private TextBox txBingoCount;

    private Button button34;

    private TextBox txScenarioRewardCount;

    private Button button4;

    private Button button24;

    public TextBox tx_AutoLaps;

    private Button button39;

    private Button button31;

    private Button button33;

    private Button button43;

    public Button but_QuestPwn;

    public Button btnUseKoinChangeCard;

    public Button but_KoinPwn;

    private TextBox tx_MyroomCheckPassEtc;

    private Button button44;

    private TextBox txScenarioMainStage;

    private TextBox txScenarioStage;

    private Button ConsoleLogger;

    public string RootDirectory { get; set; }

    public float AntiCollideValue { get; set; }

    public RouterForm()
    {
        InitializeComponent();
    }

    private void OnFormClosing(object sender, FormClosingEventArgs e)
    {
        if (Process.GetProcessesByName("KartRider").Length == 0)
        {
            File.Delete(RootDirectory + "\\KartRider.pin");
            File.Move(RootDirectory + "\\KartRider.pin-bak", RootDirectory + "\\KartRider.pin");
        }
        else
        {
            MessageBox.Show("카트라이더가 종료되지 않았습니다!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            e.Cancel = true;
        }
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        string text = "";
        text = ((!Environment.Is64BitOperatingSystem) ? "HKEY_CURRENT_USER\\SOFTWARE\\TCGame\\kart" : "HKEY_CURRENT_USER\\SOFTWARE\\TCGame\\kart");
        Console.WriteLine("Looking for KartRider Directory in {0}...", text);
        RootDirectory = (string)Registry.GetValue(text, "gamepath", null);
        Console.WriteLine("Looking for KartRider.pin at {0}...", RootDirectory);
        if (!File.Exists(RootDirectory + "\\KartRider.pin"))
        {
            return;
        }
        Console.WriteLine("Backing up old PinFile...");
        if (File.Exists(RootDirectory + "\\KartRider.pin-bak"))
        {
            File.Delete(RootDirectory + "\\KartRider.pin-bak");
        }
        File.Copy(RootDirectory + "\\KartRider.pin", RootDirectory + "\\KartRider.pin-bak");
        PINFile val = new PINFile(RootDirectory + "\\KartRider.pin");
        foreach (AuthMethod authMethod in val.AuthMethods)
        {
            Console.WriteLine("Changing IP Addr to local... {0}", authMethod.Name);
            authMethod.LoginServers.Clear();
            authMethod.LoginServers.Add(new IPEndPoint
            {
                IP = "127.0.0.1",
                Port = 39312
            });
        }
        Console.WriteLine("Saving new PinFile...");
        File.WriteAllBytes(RootDirectory + "\\KartRider.pin", val.GetEncryptedData());
        RouterListener.Start();
    }

    private void Button1_Click(object sender, EventArgs e)
    {
        OutPacket val = new OutPacket("ChReRqEnterMyRoomPacket");
        try
        {
            val.WriteUInt(uint.Parse(myRoomUserNo.Text));
            RouterListener.MySession.Server.Send(val);
        }
        finally
        {
            ((IDisposable)val)?.Dispose();
        }
    }

    private void Button2_Click(object sender, EventArgs e)
    {
        SessionGroup mySession = RouterListener.MySession;
        mySession.RequestRewardBox = true;
        mySession.RewardBox.Clear();
        mySession.SendGetRewardBox();
    }

    private void Button3_Click(object sender, EventArgs e)
    {
        GameFastRaceMacro = !GameFastRaceMacro;
    }

    private void Button6_Click(object sender, EventArgs e)
    {
        OutPacket val = new OutPacket("PqGetRider");
        try
        {
            RouterListener.MySession.Server.Send(val);
        }
        finally
        {
            ((IDisposable)val)?.Dispose();
        }
    }

    private void BtnLottery_Click(object sender, EventArgs e)
    {
        LotteryCount = int.Parse(txLotteryCount.Text);
        int num = int.Parse(txLotteryID.Text);
        int num2 = int.Parse(txLotteryType.Text);
        OutPacket val = new OutPacket("SpRqLotteryPacket");
        try
        {
            val.WriteShort((short)num);
            val.WriteBool(true);
            val.WriteInt(num2);
            RouterListener.MySession.Server.Send(val);
        }
        finally
        {
            ((IDisposable)val)?.Dispose();
        }
    }

    private void Button8_Click(object sender, EventArgs e)
    {
        GameSupport.Send_AddLucci();
    }

    private void Button10_Click(object sender, EventArgs e)
    {
        int num = int.Parse(tx_MyroomCheckPassEtc.Text);
        OutPacket val = new OutPacket("ChRpMyroomCheckPassEtcPacket");
        try
        {
            val.WriteInt(num);
            val.WriteInt(1);
            ((Session)RouterListener.MySession.Client).Send(val);
        }
        finally
        {
            ((IDisposable)val)?.Dispose();
        }
    }

    private void Button11_Click(object sender, EventArgs e)
    {
        OutPacket val = new OutPacket("PqAddTimeEventTimerPacket");
        try
        {
            RouterListener.MySession.Server.Send(val);
        }
        finally
        {
            ((IDisposable)val)?.Dispose();
        }
    }

    private void Button12_Click(object sender, EventArgs e)
    {
        OutPacket val = new OutPacket("PqGetRiderQuestUX2ndData");
        try
        {
            RouterListener.MySession.Server.Send(val);
        }
        finally
        {
            ((IDisposable)val)?.Dispose();
        }
    }

    private void Button14_Click(object sender, EventArgs e)
    {
        GameSupport.Send_GameRoomStart();
    }

    private void Button21_Click(object sender, EventArgs e)
    {
        GameSupport.Send_LeaveRoom();
    }

    private void Button18_Click(object sender, EventArgs e)
    {
        OutPacket val = new OutPacket("PqWhereIsRider");
        try
        {
            val.WriteUInt(uint.Parse(tx_GoRoomSpamUserNO.Text));
            RouterListener.MySession.Server.Send(val);
        }
        finally
        {
            ((IDisposable)val)?.Dispose();
        }
    }

    private void Button23_Click(object sender, EventArgs e)
    {
        GameSupport.ALL_Disconnect();
    }

    private void BtnMarble_Click(object sender, EventArgs e)
    {
        MarbleCount = int.Parse(txMarbleCount.Text);
        OutPacket val = new OutPacket("PqBlueMarble");
        try
        {
            OutPacket val2 = new OutPacket(4);
            val2.WriteTime(DateTime.Now);
            byte[] array = KREncodedBlock.Encode(((PacketBase)val2).ToArray(), (KREncodedBlock.EncodeFlag)2, (uint?)2242368262u);
            val.WriteInt(array.Length);
            val.WriteBytes(array);
            val.WriteInt(1);
            RouterListener.MySession.Server.Send(val);
        }
        finally
        {
            ((IDisposable)val)?.Dispose();
        }
    }

    private void Button26_Click(object sender, EventArgs e)
    {
        new Thread((ThreadStart)delegate
        {
            button26.Enabled = false;
            for (int i = 0; i < int.Parse(txBingoCount.Text); i++)
            {
                for (byte b = 1; b <= 9; b++)
                {
                    OutPacket val = new OutPacket("PqBingoSelectNum");
                    try
                    {
                        OutPacket val2 = new OutPacket(4);
                        val2.WriteTime(DateTime.Now);
                        byte[] array = KREncodedBlock.Encode(((PacketBase)val2).ToArray(), (KREncodedBlock.EncodeFlag)2, (uint?)2242368262u);
                        val.WriteInt(array.Length);
                        val.WriteBytes(array);
                        val.WriteByte(b);
                        val.WriteByte((byte)10);
                        val.WriteByte((byte)5);
                        val.WriteByte((byte)5);
                        val.WriteByte((byte)0);
                        val.WriteByte((byte)0);
                        RouterListener.MySession.Server.Send(val);
                    }
                    finally
                    {
                        ((IDisposable)val)?.Dispose();
                    }
                    Thread.Sleep(1100);
                }
                Console.WriteLine("BingoCut: {0}", i + 1);
            }
            button26.Enabled = true;
        }).Start();
    }

    private void BtnGoalin_Click(object sender, EventArgs e)
    {
        OutPacket val = new OutPacket("GameAiGoalinPacket");
        try
        {
            val.WriteInt(int.Parse(txGoalinRiderSlot.Text));
            val.WriteInt(Environment.TickCount - RouterListener.MySession.Server.game_myRealStartTick - 7000);
            RouterListener.MySession.Server.Send(val);
        }
        finally
        {
            ((IDisposable)val)?.Dispose();
        }
    }

    private void Button20_Click(object sender, EventArgs e)
    {
        OutPacket val = new OutPacket("GrChangeTrackPacket");
        try
        {
            val.WriteUInt(Adler32Helper.GenerateAdler32_UNICODE("village_I04", 0u));
            val.WriteInt(0);
            val.WriteBytes(new byte[32]);
            RouterListener.MySession.Server.Send(val);
        }
        finally
        {
            ((IDisposable)val)?.Dispose();
        }
    }

    private void Button28_Click(object sender, EventArgs e)
    {
        OutPacket val = new OutPacket("GrChangeTrackPacket");
        try
        {
            val.WriteUInt(Adler32Helper.GenerateAdler32_UNICODE("beach_R04", 0u));
            val.WriteInt(0);
            val.WriteBytes(new byte[32]);
            RouterListener.MySession.Server.Send(val);
        }
        finally
        {
            ((IDisposable)val)?.Dispose();
        }
    }

    private void Button27_Click(object sender, EventArgs e)
    {
        uint num = uint.Parse(tx_DL_RiderId.Text);
        OutPacket val = new OutPacket("RqDeclareLovePacket");
        try
        {
            val.WriteUInt(SessionGroup.UserNO);
            val.WriteString(SessionGroup.RiderName);
            val.WriteUInt(num);
            val.WriteInt(0);
            val.WriteByte((byte)1);
            RouterListener.MySession.Server.Send(val);
        }
        finally
        {
            ((IDisposable)val)?.Dispose();
        }
    }

    public static void Disconnect(int slot)
    {
        new Thread((ThreadStart)delegate
        {
            ServerSession server = RouterListener.MySession.Server;
            uint num = (uint)(1 << (slot & 0x1F));
            Thread.Sleep(700);
            OutPacket val = new OutPacket("GameSlotPacket");
            try
            {
                val.WriteInt(Program.MySlot);
                val.WriteUInt(num);
                val.WriteInt(9);
                val.WriteInt(4);
                val.WriteInt(-1);
                RouterListener.MySession.Server.Send(val);
            }
            finally
            {
                ((IDisposable)val)?.Dispose();
            }
        }).Start();
    }

    private void Tbx_HackList_TextChanged(object sender, EventArgs e)
    {
        Program.ListHacks.Clear();
        string text = tbx_HackList.Text;
        string[] collection = text.Split(new string[1] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
        Program.ListHacks.AddRange(collection);
    }

    private void Button32_Click(object sender, EventArgs e)
    {
        VersusModeMacro = !VersusModeMacro;
    }

    private void btnUseKoinChangeCard_Click(object sender, EventArgs e)
    {
        OutPacket val = new OutPacket("PqUseKoinChangeCardPacket");
        try
        {
            val.WriteInt(0);
            val.WriteString(txUseKoin_NickName.Text);
            val.WriteByte((byte)1);
            val.WriteShort((short)57);
            val.WriteShort((short)5);
            val.WriteString(SessionGroup.RiderName);
            val.WriteInt(0);
            RouterListener.MySession.Server.Send(val);
        }
        finally
        {
            ((IDisposable)val)?.Dispose();
        }
    }

    private void Button19_Click(object sender, EventArgs e)
    {
        pwnJewel = !pwnJewel;
    }

    private void Button22_Click(object sender, EventArgs e)
    {
        OutPacket val = new OutPacket("PqUseKoinChangeCardPacket");
        try
        {
            val.WriteInt(0);
            val.WriteInt(0);
            val.WriteByte((byte)0);
            val.WriteShort((short)57);
            val.WriteShort((short)5);
            val.WriteInt(0);
            val.WriteInt(0);
            RouterListener.MySession.Server.Send(val);
        }
        finally
        {
            ((IDisposable)val)?.Dispose();
        }
    }

    private void Button38_Click(object sender, EventArgs e)
    {
        new Thread((ThreadStart)delegate
        {
            button38.Enabled = false;
            OutPacket val = new OutPacket("PqEnterFishingPacket");
            try
            {
                RouterListener.MySession.Server.Send(val);
            }
            finally
            {
                ((IDisposable)val)?.Dispose();
            }
            Thread.Sleep(2500);
            OutPacket val2 = new OutPacket("PqEndFishingPacket");
            try
            {
                val2.WriteByte((byte)1);
                val2.WriteHexString(SessionGroup.Fishing);
                val2.WriteInt(4);
                val2.WriteUShort((ushort)50000);
                val2.WriteShort((short)0);
                val2.WriteUShort((ushort)55000);
                val2.WriteShort((short)0);
                val2.WriteUShort((ushort)60000);
                val2.WriteShort((short)0);
                val2.WriteUShort((ushort)65000);
                val2.WriteShort((short)0);
                RouterListener.MySession.Server.Send(val2);
            }
            finally
            {
                ((IDisposable)val2)?.Dispose();
            }
            button38.Enabled = true;
        }).Start();
    }

    private void Button25_Click(object sender, EventArgs e)
    {
        int num = Environment.TickCount - RouterListener.MySession.Server.game_myRealStartTick - 7000;
        if (SessionGroup.GameType == 17)
        {
            SessionGroup.min = 0;
            SessionGroup.sec = 30;
            SessionGroup.mil = 0;
            RaceTime = 30000;
        }
        else
        {
            SessionGroup.min = SuspiciousRaceCheck.RaceTime / 60000;
            int num2 = SuspiciousRaceCheck.RaceTime - SessionGroup.min * 60000;
            SessionGroup.sec = num2 / 1000;
            SessionGroup.mil = SuspiciousRaceCheck.RaceTime % 1000;
            RaceTime = SuspiciousRaceCheck.RaceTime;
        }
        if (num >= RaceTime)
        {
            if (4 >= RouterListener.MySession.SendPlaneCount)
            {
                RouterListener.MySession.Send_GoalIn();
            }
            else
            {
                MessageBox.Show("경고) d/c 가능성 있음\r\n\r\nPlaneCount: " + RouterListener.MySession.SendPlaneCount);
            }
            return;
        }
        MessageBox.Show("비정상 기록: " + SessionGroup.min + ":" + SessionGroup.sec + ":" + SessionGroup.mil);
    }

    private void button34_Click(object sender, EventArgs e)
    {
        new Thread((ThreadStart)delegate
        {
            button34.Enabled = false;
            int num = int.Parse(txScenarioRewardCount.Text);
            int millisecondsTimeout = 500;
            byte b = byte.Parse(txScenarioMainStage.Text);
            byte b2 = byte.Parse(txScenarioStage.Text);
            OutPacket val = new OutPacket("PqStartScenario");
            try
            {
                val.WriteByte(b);
                val.WriteByte((byte)0);
                val.WriteByte((byte)0);
                val.WriteByte(b2);
                RouterListener.MySession.Server.Send(val);
            }
            finally
            {
                ((IDisposable)val)?.Dispose();
            }
            Thread.Sleep(millisecondsTimeout);
            for (int i = 1; i <= num; i++)
            {
                OutPacket val2 = new OutPacket("PqCompleteScenarioSingle");
                try
                {
                    OutPacket val3 = new OutPacket(4);
                    val3.WriteTime(DateTime.Now);
                    byte[] array = KREncodedBlock.Encode(((PacketBase)val3).ToArray(), (KREncodedBlock.EncodeFlag)2, (uint?)2242368262u);
                    val2.WriteInt(array.Length);
                    val2.WriteBytes(array);
                    val2.WriteByte(b);
                    val2.WriteByte((byte)0);
                    val2.WriteByte((byte)0);
                    val2.WriteByte(b2);
                    RouterListener.MySession.Server.Send(val2);
                }
                finally
                {
                    ((IDisposable)val2)?.Dispose();
                }
                OutPacket val4 = new OutPacket("PqGetRider");
                try
                {
                    RouterListener.MySession.Server.Send(val4);
                }
                finally
                {
                    ((IDisposable)val4)?.Dispose();
                }
                Thread.Sleep(millisecondsTimeout);
                Console.WriteLine("ScenarioRewardCut: {0}", i);
            }
            button34.Enabled = true;
        }).Start();
    }

    private void button44_Click(object sender, EventArgs e)
    {
        Licenses.Licenses_Clear();
    }

    private void button4_Click(object sender, EventArgs e)
    {
        GameRaceMacro = !GameRaceMacro;
    }

    private void button24_Click(object sender, EventArgs e)
    {
        OutPacket val = new OutPacket("PqPwd2ndOptionDisablePacket");
        try
        {
            val.WriteBool(false);
            RouterListener.MySession.Server.Send(val);
        }
        finally
        {
            ((IDisposable)val)?.Dispose();
        }
    }

    private void button39_Click(object sender, EventArgs e)
    {
        GameSupport.Send_RoomKick();
    }

    private void button13_Click(object sender, EventArgs e)
    {
        for (int i = 1330; i <= 1332; i++)
        {
            OutPacket val = new OutPacket("PqGameOutRunUX2ndClearPacket");
            try
            {
                val.WriteInt(i);
                val.WriteTime(DateTime.Now);
                val.WriteInt(0);
                RouterListener.MySession.Server.Send(val);
            }
            finally
            {
                ((IDisposable)val)?.Dispose();
            }
        }
    }

    private void button31_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < 4; i++)
        {
            OutPacket val = new OutPacket("GameSlotPacket");
            try
            {
                val.WriteInt(Program.MySlot);
                switch (i)
                {
                    case 0:
                        val.WriteHexString("0C 00 00 00 0C 56 00 00 45 00 00 00 63 05 3E 27 82 06 FC 38 FF 00 00 91 00 00 00 00 24 C8 BC 42 58 89 16 43 00 3A CD 40 00 00 70 41 00 00 80 BF 00 00 00 80 00 00 00 00 00 00 00 00 00 00 80 BF 00 00 00 80 00 00 00 00 00 00 00 80 00 00 80 3F 04");
                        break;
                    case 1:
                        val.WriteHexString("0C 00 00 00 0C 69 00 00 45 00 00 00 63 05 3E 27 82 06 FC 38 00 01 00 91 00 00 00 00 24 C8 BC 42 58 89 16 43 00 3A CD 40 00 00 70 C1 00 00 80 BF 00 00 00 80 00 00 00 00 00 00 00 00 00 00 80 BF 00 00 00 80 00 00 00 00 00 00 00 80 00 00 80 3F 04");
                        break;
                    case 2:
                        val.WriteHexString("0C 00 00 00 0C 56 00 00 45 00 00 00 63 05 3E 27 82 06 FC 38 01 01 00 91 00 00 00 00 24 C8 BC 42 58 89 16 43 00 3A CD 40 00 00 A0 40 00 00 80 BF 00 00 00 80 00 00 00 00 00 00 00 00 00 00 80 BF 00 00 00 80 00 00 00 00 00 00 00 80 00 00 80 3F 04");
                        break;
                    default:
                        val.WriteHexString("0C 00 00 00 0C 00 00 00 45 00 00 00 63 05 3E 27 82 06 FC 38 02 01 00 91 00 00 00 00 24 C8 BC 42 58 89 16 43 00 3A CD 40 00 00 A0 C0 00 00 80 BF 00 00 00 80 00 00 00 00 00 00 00 00 00 00 80 BF 00 00 00 80 00 00 00 00 00 00 00 80 00 00 80 3F 04");
                        break;
                }
                ((Session)RouterListener.MySession.Client).Send(val);
            }
            finally
            {
                ((IDisposable)val)?.Dispose();
            }
        }
    }

    private void button33_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < 4; i++)
        {
            OutPacket val = new OutPacket("GameSlotPacket");
            try
            {
                val.WriteInt(Program.MySlot);
                switch (i)
                {
                    case 0:
                        val.WriteHexString("0C 00 00 00 0C 60 00 00 45 00 00 00 63 05 3E 27 82 06 FC 38 EC 00 00 91 00 00 00 00 24 C8 BC 42 28 7A 16 43 00 3A CD 40 00 00 70 41 00 00 80 BF 00 00 00 80 00 00 00 00 00 00 00 00 00 00 80 BF 00 00 00 80 00 00 00 00 00 00 00 80 00 00 80 3F 02");
                        break;
                    case 1:
                        val.WriteHexString("0C 00 00 00 0C F2 00 00 45 00 00 00 63 05 3E 27 82 06 FC 38 ED 00 00 91 00 00 00 00 24 C8 BC 42 28 7A 16 43 00 3A CD 40 00 00 70 C1 00 00 80 BF 00 00 00 80 00 00 00 00 00 00 00 00 00 00 80 BF 00 00 00 80 00 00 00 00 00 00 00 80 00 00 80 3F 02");
                        break;
                    case 2:
                        val.WriteHexString("0C 00 00 00 0C 00 00 00 45 00 00 00 63 05 3E 27 82 06 FC 38 EE 00 00 91 00 00 00 00 24 C8 BC 42 28 7A 16 43 00 3A CD 40 00 00 A0 40 00 00 80 BF 00 00 00 80 00 00 00 00 00 00 00 00 00 00 80 BF 00 00 00 80 00 00 00 00 00 00 00 80 00 00 80 3F 02");
                        break;
                    default:
                        val.WriteHexString("0C 00 00 00 0C F2 00 00 45 00 00 00 63 05 3E 27 82 06 FC 38 EF 00 00 91 00 00 00 00 24 C8 BC 42 28 7A 16 43 00 3A CD 40 00 00 A0 C0 00 00 80 BF 00 00 00 80 00 00 00 00 00 00 00 00 00 00 80 BF 00 00 00 80 00 00 00 00 00 00 00 80 00 00 80 3F 02");
                        break;
                }
                ((Session)RouterListener.MySession.Client).Send(val);
            }
            finally
            {
                ((IDisposable)val)?.Dispose();
            }
        }
    }

    private void button43_Click(object sender, EventArgs e)
    {
        Challenger.Complete_Challenger();
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void ConsoleLogger_Click(object sender, EventArgs e)
    {
        CachedConsoleWriter.SaveToFile();
        CachedConsoleWriter.cachedWriter.ClearCache();
    }

    private void InitializeComponent()
    {
        this.button1 = new System.Windows.Forms.Button();
        this.button2 = new System.Windows.Forms.Button();
        this.button3 = new System.Windows.Forms.Button();
        this.button6 = new System.Windows.Forms.Button();
        this.txLotteryType = new System.Windows.Forms.TextBox();
        this.btnLottery = new System.Windows.Forms.Button();
        this.txLotteryCount = new System.Windows.Forms.TextBox();
        this.txLotteryID = new System.Windows.Forms.TextBox();
        this.button8 = new System.Windows.Forms.Button();
        this.myRoomUserNo = new System.Windows.Forms.TextBox();
        this.button10 = new System.Windows.Forms.Button();
        this.button11 = new System.Windows.Forms.Button();
        this.button12 = new System.Windows.Forms.Button();
        this.button14 = new System.Windows.Forms.Button();
        this.button21 = new System.Windows.Forms.Button();
        this.button18 = new System.Windows.Forms.Button();
        this.tx_GoRoomSpamUserNO = new System.Windows.Forms.TextBox();
        this.button23 = new System.Windows.Forms.Button();
        this.btnMarble = new System.Windows.Forms.Button();
        this.txMarbleCount = new System.Windows.Forms.TextBox();
        this.button26 = new System.Windows.Forms.Button();
        this.txGoalinRiderSlot = new System.Windows.Forms.TextBox();
        this.btnGoalin = new System.Windows.Forms.Button();
        this.button20 = new System.Windows.Forms.Button();
        this.button28 = new System.Windows.Forms.Button();
        this.button27 = new System.Windows.Forms.Button();
        this.tx_DL_RiderId = new System.Windows.Forms.TextBox();
        this.button32 = new System.Windows.Forms.Button();
        this.tbx_HackList = new System.Windows.Forms.TextBox();
        this.btnUseKoinChangeCard = new System.Windows.Forms.Button();
        this.txUseKoin_NickName = new System.Windows.Forms.TextBox();
        this.button19 = new System.Windows.Forms.Button();
        this.but_KoinPwn = new System.Windows.Forms.Button();
        this.button38 = new System.Windows.Forms.Button();
        this.button25 = new System.Windows.Forms.Button();
        this.tx_Laps = new System.Windows.Forms.TextBox();
        this.txBingoCount = new System.Windows.Forms.TextBox();
        this.button34 = new System.Windows.Forms.Button();
        this.txScenarioRewardCount = new System.Windows.Forms.TextBox();
        this.button4 = new System.Windows.Forms.Button();
        this.button24 = new System.Windows.Forms.Button();
        this.tx_AutoLaps = new System.Windows.Forms.TextBox();
        this.button39 = new System.Windows.Forms.Button();
        this.but_QuestPwn = new System.Windows.Forms.Button();
        this.button31 = new System.Windows.Forms.Button();
        this.button33 = new System.Windows.Forms.Button();
        this.button43 = new System.Windows.Forms.Button();
        this.tx_MyroomCheckPassEtc = new System.Windows.Forms.TextBox();
        this.button44 = new System.Windows.Forms.Button();
        this.txScenarioMainStage = new System.Windows.Forms.TextBox();
        this.txScenarioStage = new System.Windows.Forms.TextBox();
        this.ConsoleLogger = new System.Windows.Forms.Button();

        base.SuspendLayout();

        this.button1.Location = new System.Drawing.Point(96, 264);
        this.button1.Name = "button1";
        this.button1.Size = new System.Drawing.Size(106, 23);
        this.button1.TabIndex = 0;
        this.button1.Text = "enter myroom";
        this.button1.UseVisualStyleBackColor = true;
        this.button1.Click += new System.EventHandler(Button1_Click);

        this.button2.Location = new System.Drawing.Point(356, 138);
        this.button2.Name = "button2";
        this.button2.Size = new System.Drawing.Size(93, 23);
        this.button2.TabIndex = 6;
        this.button2.Text = "Reward Box";
        this.button2.UseVisualStyleBackColor = true;
        this.button2.Click += new System.EventHandler(Button2_Click);

        this.button3.Location = new System.Drawing.Point(14, 42);
        this.button3.Name = "button3";
        this.button3.Size = new System.Drawing.Size(192, 23);
        this.button3.TabIndex = 8;
        this.button3.Text = "Fast Race Macro";
        this.button3.UseVisualStyleBackColor = true;
        this.button3.Click += new System.EventHandler(Button3_Click);

        this.button6.Location = new System.Drawing.Point(14, 100);
        this.button6.Name = "button6";
        this.button6.Size = new System.Drawing.Size(185, 23);
        this.button6.TabIndex = 12;
        this.button6.Text = "Return Item";
        this.button6.UseVisualStyleBackColor = true;
        this.button6.Click += new System.EventHandler(Button6_Click);

        this.txLotteryType.Location = new System.Drawing.Point(140, 433);
        this.txLotteryType.Name = "txLotteryType";
        this.txLotteryType.Size = new System.Drawing.Size(59, 21);
        this.txLotteryType.TabIndex = 41;
        this.txLotteryType.Text = "0";

        this.btnLottery.Location = new System.Drawing.Point(14, 460);
        this.btnLottery.Name = "btnLottery";
        this.btnLottery.Size = new System.Drawing.Size(186, 23);
        this.btnLottery.TabIndex = 40;
        this.btnLottery.Text = "Lottery";
        this.btnLottery.UseVisualStyleBackColor = true;
        this.btnLottery.Click += new System.EventHandler(BtnLottery_Click);

        this.txLotteryCount.Location = new System.Drawing.Point(81, 433);
        this.txLotteryCount.Name = "txLotteryCount";
        this.txLotteryCount.Size = new System.Drawing.Size(53, 21);
        this.txLotteryCount.TabIndex = 39;
        this.txLotteryCount.Text = "1";

        this.txLotteryID.Location = new System.Drawing.Point(15, 433);
        this.txLotteryID.Name = "txLotteryID";
        this.txLotteryID.Size = new System.Drawing.Size(60, 21);
        this.txLotteryID.TabIndex = 38;

        this.button8.Location = new System.Drawing.Point(212, 395);
        this.button8.Name = "button8";
        this.button8.Size = new System.Drawing.Size(184, 23);
        this.button8.TabIndex = 43;
        this.button8.Text = "Add Lucci (Event Mode)";
        this.button8.UseVisualStyleBackColor = true;
        this.button8.Click += new System.EventHandler(Button8_Click);

        this.myRoomUserNo.Location = new System.Drawing.Point(12, 265);
        this.myRoomUserNo.Name = "myRoomUserNo";
        this.myRoomUserNo.Size = new System.Drawing.Size(78, 21);
        this.myRoomUserNo.TabIndex = 45;
        this.myRoomUserNo.Text = "1615653648";

        this.button10.Location = new System.Drawing.Point(212, 69);
        this.button10.Name = "button10";
        this.button10.Size = new System.Drawing.Size(119, 23);
        this.button10.TabIndex = 47;
        this.button10.Text = "Request Items";
        this.button10.UseVisualStyleBackColor = true;
        this.button10.Click += new System.EventHandler(Button10_Click);

        this.button11.Location = new System.Drawing.Point(11, 341);
        this.button11.Name = "button11";
        this.button11.Size = new System.Drawing.Size(188, 23);
        this.button11.TabIndex = 48;
        this.button11.Text = "PlayTime Reset";
        this.button11.UseVisualStyleBackColor = true;
        this.button11.Click += new System.EventHandler(Button11_Click);

        this.button12.Location = new System.Drawing.Point(11, 370);
        this.button12.Name = "button12";
        this.button12.Size = new System.Drawing.Size(188, 23);
        this.button12.TabIndex = 49;
        this.button12.Text = "Quest Reset";
        this.button12.UseVisualStyleBackColor = true;
        this.button12.Click += new System.EventHandler(Button12_Click);

        this.button14.Location = new System.Drawing.Point(12, 297);
        this.button14.Name = "button14";
        this.button14.Size = new System.Drawing.Size(190, 23);
        this.button14.TabIndex = 52;
        this.button14.Text = "Force Room Start";
        this.button14.UseVisualStyleBackColor = true;
        this.button14.Click += new System.EventHandler(Button14_Click);

        this.button21.Location = new System.Drawing.Point(464, 162);
        this.button21.Name = "button21";
        this.button21.Size = new System.Drawing.Size(88, 23);
        this.button21.TabIndex = 64;
        this.button21.Text = "Leave Room";
        this.button21.UseVisualStyleBackColor = true;
        this.button21.Click += new System.EventHandler(Button21_Click);

        this.button18.Location = new System.Drawing.Point(799, 22);
        this.button18.Name = "button18";
        this.button18.Size = new System.Drawing.Size(115, 23);
        this.button18.TabIndex = 69;
        this.button18.Text = "Where Is Rider?";
        this.button18.UseVisualStyleBackColor = true;
        this.button18.Click += new System.EventHandler(Button18_Click);

        this.tx_GoRoomSpamUserNO.Location = new System.Drawing.Point(800, 51);
        this.tx_GoRoomSpamUserNO.Name = "tx_GoRoomSpamUserNO";
        this.tx_GoRoomSpamUserNO.Size = new System.Drawing.Size(100, 21);
        this.tx_GoRoomSpamUserNO.TabIndex = 70;

        this.button23.Location = new System.Drawing.Point(212, 127);
        this.button23.Name = "button23";
        this.button23.Size = new System.Drawing.Size(104, 23);
        this.button23.TabIndex = 72;
        this.button23.Text = "ALL D/C";
        this.button23.UseVisualStyleBackColor = true;
        this.button23.Click += new System.EventHandler(Button23_Click);

        this.btnMarble.Location = new System.Drawing.Point(87, 398);
        this.btnMarble.Name = "btnMarble";
        this.btnMarble.Size = new System.Drawing.Size(112, 23);
        this.btnMarble.TabIndex = 77;
        this.btnMarble.Text = "Marble Dice";
        this.btnMarble.UseVisualStyleBackColor = true;
        this.btnMarble.Click += new System.EventHandler(BtnMarble_Click);

        this.txMarbleCount.Location = new System.Drawing.Point(15, 399);
        this.txMarbleCount.Name = "txMarbleCount";
        this.txMarbleCount.Size = new System.Drawing.Size(66, 21);
        this.txMarbleCount.TabIndex = 76;
        this.txMarbleCount.Text = "1";

        this.button26.Location = new System.Drawing.Point(631, 41);
        this.button26.Name = "button26";
        this.button26.Size = new System.Drawing.Size(116, 23);
        this.button26.TabIndex = 79;
        this.button26.Text = "BingoNum";
        this.button26.UseVisualStyleBackColor = true;
        this.button26.Click += new System.EventHandler(Button26_Click);

        this.txGoalinRiderSlot.Location = new System.Drawing.Point(212, 361);
        this.txGoalinRiderSlot.Name = "txGoalinRiderSlot";
        this.txGoalinRiderSlot.Size = new System.Drawing.Size(80, 21);
        this.txGoalinRiderSlot.TabIndex = 81;

        this.btnGoalin.Location = new System.Drawing.Point(298, 360);
        this.btnGoalin.Name = "btnGoalin";
        this.btnGoalin.Size = new System.Drawing.Size(99, 23);
        this.btnGoalin.TabIndex = 80;
        this.btnGoalin.Text = "AI Goal In";
        this.btnGoalin.UseVisualStyleBackColor = true;
        this.btnGoalin.Click += new System.EventHandler(BtnGoalin_Click);

        this.button20.Location = new System.Drawing.Point(212, 273);
        this.button20.Name = "button20";
        this.button20.Size = new System.Drawing.Size(185, 23);
        this.button20.TabIndex = 91;
        this.button20.Text = "VILLAGE TRACK";
        this.button20.UseVisualStyleBackColor = true;
        this.button20.Click += new System.EventHandler(Button20_Click);

        this.button28.Location = new System.Drawing.Point(212, 302);
        this.button28.Name = "button28";
        this.button28.Size = new System.Drawing.Size(185, 23);
        this.button28.TabIndex = 92;
        this.button28.Text = "BEACH TRACK";
        this.button28.UseVisualStyleBackColor = true;
        this.button28.Click += new System.EventHandler(Button28_Click);

        this.button27.Location = new System.Drawing.Point(805, 289);
        this.button27.Name = "button27";
        this.button27.Size = new System.Drawing.Size(114, 23);
        this.button27.TabIndex = 94;
        this.button27.Text = "Declare Love";
        this.button27.UseVisualStyleBackColor = true;
        this.button27.Click += new System.EventHandler(Button27_Click);

        this.tx_DL_RiderId.Location = new System.Drawing.Point(806, 262);
        this.tx_DL_RiderId.Name = "tx_DL_RiderId";
        this.tx_DL_RiderId.Size = new System.Drawing.Size(100, 21);
        this.tx_DL_RiderId.TabIndex = 96;

        this.button32.Location = new System.Drawing.Point(14, 12);
        this.button32.Name = "button32";
        this.button32.Size = new System.Drawing.Size(192, 23);
        this.button32.TabIndex = 111;
        this.button32.Text = "Versus Mode Macro";
        this.button32.UseVisualStyleBackColor = true;
        this.button32.Click += new System.EventHandler(Button32_Click);

        this.tbx_HackList.Location = new System.Drawing.Point(14, 162);
        this.tbx_HackList.Multiline = true;
        this.tbx_HackList.Name = "tbx_HackList";
        this.tbx_HackList.Size = new System.Drawing.Size(188, 90);
        this.tbx_HackList.TabIndex = 127;
        this.tbx_HackList.TextChanged += new System.EventHandler(Tbx_HackList_TextChanged);

        this.btnUseKoinChangeCard.Location = new System.Drawing.Point(213, 460);
        this.btnUseKoinChangeCard.Name = "btnUseKoinChangeCard";
        this.btnUseKoinChangeCard.Size = new System.Drawing.Size(184, 23);
        this.btnUseKoinChangeCard.TabIndex = 134;
        this.btnUseKoinChangeCard.Text = "Premium Item";
        this.btnUseKoinChangeCard.UseVisualStyleBackColor = true;
        this.btnUseKoinChangeCard.Click += new System.EventHandler(btnUseKoinChangeCard_Click);

        this.txUseKoin_NickName.Location = new System.Drawing.Point(213, 433);
        this.txUseKoin_NickName.Name = "txUseKoin_NickName";
        this.txUseKoin_NickName.Size = new System.Drawing.Size(183, 21);
        this.txUseKoin_NickName.TabIndex = 133;

        this.button19.Location = new System.Drawing.Point(14, 129);
        this.button19.Name = "button19";
        this.button19.Size = new System.Drawing.Size(185, 23);
        this.button19.TabIndex = 137;
        this.button19.Text = "Game Jewel Pwn";
        this.button19.UseVisualStyleBackColor = true;
        this.button19.Click += new System.EventHandler(Button19_Click);

        this.but_KoinPwn.Location = new System.Drawing.Point(477, 201);
        this.but_KoinPwn.Name = "but_KoinPwn";
        this.but_KoinPwn.Size = new System.Drawing.Size(75, 23);
        this.but_KoinPwn.TabIndex = 138;
        this.but_KoinPwn.Text = "Koin Pwn";
        this.but_KoinPwn.UseVisualStyleBackColor = true;
        this.but_KoinPwn.Click += new System.EventHandler(Button22_Click);

        this.button38.Location = new System.Drawing.Point(212, 156);
        this.button38.Name = "button38";
        this.button38.Size = new System.Drawing.Size(104, 23);
        this.button38.TabIndex = 183;
        this.button38.Text = "AFK Fishing";
        this.button38.UseVisualStyleBackColor = true;
        this.button38.Click += new System.EventHandler(Button38_Click);

        this.button25.Location = new System.Drawing.Point(564, 460);
        this.button25.Name = "button25";
        this.button25.Size = new System.Drawing.Size(184, 23);
        this.button25.TabIndex = 204;
        this.button25.Text = "Goal In Test";
        this.button25.UseVisualStyleBackColor = true;
        this.button25.Click += new System.EventHandler(Button25_Click);

        this.tx_Laps.Location = new System.Drawing.Point(565, 433);
        this.tx_Laps.Name = "tx_Laps";
        this.tx_Laps.Size = new System.Drawing.Size(88, 21);
        this.tx_Laps.TabIndex = 205;
        this.tx_Laps.Text = "1";

        this.txBingoCount.Location = new System.Drawing.Point(565, 42);
        this.txBingoCount.Name = "txBingoCount";
        this.txBingoCount.Size = new System.Drawing.Size(60, 21);
        this.txBingoCount.TabIndex = 209;
        this.txBingoCount.Text = "1";

        this.button34.Location = new System.Drawing.Point(564, 318);
        this.button34.Name = "button34";
        this.button34.Size = new System.Drawing.Size(184, 23);
        this.button34.TabIndex = 219;
        this.button34.Text = "Scenario Reward";
        this.button34.UseVisualStyleBackColor = true;
        this.button34.Click += new System.EventHandler(button34_Click);

        this.txScenarioRewardCount.Location = new System.Drawing.Point(565, 291);
        this.txScenarioRewardCount.Name = "txScenarioRewardCount";
        this.txScenarioRewardCount.Size = new System.Drawing.Size(76, 21);
        this.txScenarioRewardCount.TabIndex = 221;
        this.txScenarioRewardCount.Text = "1";

        this.button4.Location = new System.Drawing.Point(14, 71);
        this.button4.Name = "button4";
        this.button4.Size = new System.Drawing.Size(188, 23);
        this.button4.TabIndex = 251;
        this.button4.Text = "Game Race Macro";
        this.button4.UseVisualStyleBackColor = true;
        this.button4.Click += new System.EventHandler(button4_Click);

        this.button24.Location = new System.Drawing.Point(799, 156);
        this.button24.Name = "button24";
        this.button24.Size = new System.Drawing.Size(113, 23);
        this.button24.TabIndex = 299;
        this.button24.Text = "Pwd2nd Disable";
        this.button24.UseVisualStyleBackColor = true;
        this.button24.Click += new System.EventHandler(button24_Click);

        this.tx_AutoLaps.Location = new System.Drawing.Point(659, 433);
        this.tx_AutoLaps.Name = "tx_AutoLaps";
        this.tx_AutoLaps.Size = new System.Drawing.Size(88, 21);
        this.tx_AutoLaps.TabIndex = 325;
        this.tx_AutoLaps.Text = "0";

        this.button39.Location = new System.Drawing.Point(347, 39);
        this.button39.Name = "button39";
        this.button39.Size = new System.Drawing.Size(75, 23);
        this.button39.TabIndex = 332;
        this.button39.Text = "Room Kick";
        this.button39.UseVisualStyleBackColor = true;
        this.button39.Click += new System.EventHandler(button39_Click);

        this.but_QuestPwn.Location = new System.Drawing.Point(456, 230);
        this.but_QuestPwn.Name = "but_QuestPwn";
        this.but_QuestPwn.Size = new System.Drawing.Size(75, 23);
        this.but_QuestPwn.TabIndex = 339;
        this.but_QuestPwn.Text = "Quest Pwn";
        this.but_QuestPwn.UseVisualStyleBackColor = true;
        this.but_QuestPwn.Click += new System.EventHandler(button13_Click);

        this.button31.Location = new System.Drawing.Point(453, 40);
        this.button31.Name = "button31";
        this.button31.Size = new System.Drawing.Size(103, 23);
        this.button31.TabIndex = 341;
        this.button31.Text = "gold item Box";
        this.button31.UseVisualStyleBackColor = true;
        this.button31.Click += new System.EventHandler(button31_Click);

        this.button33.Location = new System.Drawing.Point(453, 69);
        this.button33.Name = "button33";
        this.button33.Size = new System.Drawing.Size(103, 23);
        this.button33.TabIndex = 342;
        this.button33.Text = "silver item Box";
        this.button33.UseVisualStyleBackColor = true;
        this.button33.Click += new System.EventHandler(button33_Click);

        this.button43.Location = new System.Drawing.Point(564, 346);
        this.button43.Name = "button43";
        this.button43.Size = new System.Drawing.Size(183, 23);
        this.button43.TabIndex = 346;
        this.button43.Text = "Complete Challenger";
        this.button43.UseVisualStyleBackColor = true;
        this.button43.Click += new System.EventHandler(button43_Click);

        this.tx_MyroomCheckPassEtc.Location = new System.Drawing.Point(213, 41);
        this.tx_MyroomCheckPassEtc.Name = "tx_MyroomCheckPassEtc";
        this.tx_MyroomCheckPassEtc.Size = new System.Drawing.Size(79, 21);
        this.tx_MyroomCheckPassEtc.TabIndex = 353;
        this.tx_MyroomCheckPassEtc.Text = "0";

        this.button44.Location = new System.Drawing.Point(564, 375);
        this.button44.Name = "button44";
        this.button44.Size = new System.Drawing.Size(184, 23);
        this.button44.TabIndex = 248;
        this.button44.Text = "Licenses Test";
        this.button44.UseVisualStyleBackColor = true;
        this.button44.Click += new System.EventHandler(button44_Click);

        this.txScenarioMainStage.Location = new System.Drawing.Point(647, 291);
        this.txScenarioMainStage.Name = "txScenarioMainStage";
        this.txScenarioMainStage.Size = new System.Drawing.Size(47, 21);
        this.txScenarioMainStage.TabIndex = 355;
        this.txScenarioStage.Location = new System.Drawing.Point(700, 291);
        this.txScenarioStage.Name = "txScenarioStage";
        this.txScenarioStage.Size = new System.Drawing.Size(47, 21);
        this.txScenarioStage.TabIndex = 356;

        this.ConsoleLogger.Location = new System.Drawing.Point(805, 400);
        this.ConsoleLogger.Name = "ConsoleLogger";
        this.ConsoleLogger.Size = new System.Drawing.Size(114, 23);
        this.ConsoleLogger.TabIndex = 375;
        this.ConsoleLogger.Text = "Save Log";
        this.ConsoleLogger.UseVisualStyleBackColor = true;
        this.ConsoleLogger.Click += new System.EventHandler(ConsoleLogger_Click);

        base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 12f);
        base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        base.ClientSize = new System.Drawing.Size(938, 497);

        base.Controls.Add(this.txScenarioStage);
        base.Controls.Add(this.txScenarioMainStage);
        base.Controls.Add(this.tx_MyroomCheckPassEtc);
        base.Controls.Add(this.button43);
        base.Controls.Add(this.button33);
        base.Controls.Add(this.button31);
        base.Controls.Add(this.but_QuestPwn);
        base.Controls.Add(this.button39);
        base.Controls.Add(this.tx_AutoLaps);
        base.Controls.Add(this.button24);
        base.Controls.Add(this.button4);
        base.Controls.Add(this.button44);
        base.Controls.Add(this.txScenarioRewardCount);
        base.Controls.Add(this.button34);
        base.Controls.Add(this.txBingoCount);
        base.Controls.Add(this.tx_Laps);
        base.Controls.Add(this.button25);
        base.Controls.Add(this.button38);
        base.Controls.Add(this.but_KoinPwn);
        base.Controls.Add(this.button19);
        base.Controls.Add(this.btnUseKoinChangeCard);
        base.Controls.Add(this.txUseKoin_NickName);
        base.Controls.Add(this.tbx_HackList);
        base.Controls.Add(this.button32);
        base.Controls.Add(this.tx_DL_RiderId);
        base.Controls.Add(this.button27);
        base.Controls.Add(this.button28);
        base.Controls.Add(this.button20);
        base.Controls.Add(this.txGoalinRiderSlot);
        base.Controls.Add(this.btnGoalin);
        base.Controls.Add(this.button26);
        base.Controls.Add(this.btnMarble);
        base.Controls.Add(this.txMarbleCount);
        base.Controls.Add(this.button23);
        base.Controls.Add(this.tx_GoRoomSpamUserNO);
        base.Controls.Add(this.button18);
        base.Controls.Add(this.button21);
        base.Controls.Add(this.button14);
        base.Controls.Add(this.button12);
        base.Controls.Add(this.button11);
        base.Controls.Add(this.button10);
        base.Controls.Add(this.myRoomUserNo);
        base.Controls.Add(this.button8);
        base.Controls.Add(this.txLotteryType);
        base.Controls.Add(this.btnLottery);
        base.Controls.Add(this.txLotteryCount);
        base.Controls.Add(this.txLotteryID);
        base.Controls.Add(this.button6);
        base.Controls.Add(this.button3);
        base.Controls.Add(this.button2);
        base.Controls.Add(this.button1);
        base.Controls.Add(this.ConsoleLogger);

        this.Font = new System.Drawing.Font("굴림", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
        base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        base.MaximizeBox = false;
        base.Name = "RouterForm";
        this.Text = "KR_Extreme © 2017 by LAON (김라온)";
        base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(OnFormClosing);
        base.ResumeLayout(false);
        base.PerformLayout();
    }
}
