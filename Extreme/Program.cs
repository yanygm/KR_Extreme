using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using KartRider.Common.Utilities;
using KartRider.IO;

namespace Extreme;

internal static class Program
{
	public static Development DevelopmentDlg;

	public static KartSpecDialog KartSpecDlg;

	public static FakeClient Client;

	public static RouterForm RouterFormDlg;

	public static AntiHackDlg HackPwnDlg;

	public static int MySlot;

	public static int MAX_EQP_P;

	public static List<string> ListHacks;

	public static bool ShowPacketLog;

	public static bool Development;

	public static Random Randomizer;

	public static bool KartSpec;

	public static bool Goal;

	public static bool AntiHack;

	public static bool FakeClient;

	public static bool ReportLog;

	public static bool GameReport_Development;

	public static int Tick
	{
		get
		{
			QueryPerformanceFrequency(out var lpFrequency);
			QueryPerformanceCounter(out var lpPerformanceCount);
			lpPerformanceCount *= 1000;
			return (int)(lpPerformanceCount / lpFrequency);
		}
	}

	static Program()
	{
		MySlot = -1;
		MAX_EQP_P = 32;
		ListHacks = new List<string>();
		ShowPacketLog = false;
		Randomizer = new Random(Environment.TickCount);
		Goal = false;
		ReportLog = false;
		GameReport_Development = false;
		Development = false;
		FakeClient = false;
		AntiHack = false;
		KartSpec = false;
	}

	public static void HandleSpecChange(KartSpec spec, OutPacket oPacket, InPacket iPacket)
	{
		spec.Decode(iPacket);
		if (!KartSpec)
		{
			spec.CornerDrawFactor += 0.055f;
			spec.TransAccelFactor += 0.015f;
			spec.DriftEscapeForce += 500f;
			spec.SteerConstraint += 0.3f;
			spec.SlipBrakeForce -= 200f;
			spec.DriftMaxGauge -= 100f;
			spec.DragFactor -= 0.0008f;
			spec.GripBrakeForce -= 12f;
			spec.RearGripFactor += 0.3f;
			spec.FrontGripFactor += 0.3f;
			spec.NormalBoosterTime += 100f;
			spec.StartBoosterTimeSpeed += 100f;
			float antiCollideBalance = (spec.antiCollideBalance = 0f);
			spec.antiCollideBalance = antiCollideBalance;
		}
		spec.DriftMaxGauge = Math.Max(1f, spec.DriftMaxGauge);
		spec.Encode(oPacket, encodeOriginal: false);
	}

	[STAThread]
	private static void Main(string[] args)
	{
		Application.EnableVisualStyles();
		Application.SetCompatibleTextRenderingDefault(defaultValue: false);
		if (Development)
		{
			DevelopmentDlg = new Development();
			DevelopmentDlg.Show();
		}
		if (FakeClient)
		{
			Client = new FakeClient();
			Client.Show();
		}
		if (AntiHack)
		{
			HackPwnDlg = new AntiHackDlg();
			HackPwnDlg.Show();
		}
		if (KartSpec)
		{
			KartSpecDlg = new KartSpecDialog();
			KartSpecDlg.Show();
		}
		Application.Run(RouterFormDlg = new RouterForm());
		NativeMethods.FreeConsole();
	}

	[DllImport("Kernel32.dll")]
	private static extern bool QueryPerformanceCounter(out long lpPerformanceCount);

	[DllImport("Kernel32.dll")]
	private static extern bool QueryPerformanceFrequency(out long lpFrequency);
}
