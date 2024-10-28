using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using KartRider.Common.Network;
using KartRider.IO;

namespace Extreme;

public class Development : Form
{
	public static bool ShowPacketLog;

	private IContainer components = null;

	private Button button2;

	private Button button1;

	public TextBox text_PacketLog;

	private RadioButton radioButton1;

	private RadioButton radioButton2;

	private TextBox text_Sleep;

	private TextBox Packet_Count;

	private Button button3;

	private TextBox ValuePacket;

	private TextBox NamePacket;

	private Button button4;

	private TextBox tx_ValuePacket;

	private Button button5;

	private Button button6;

	public Development()
	{
		InitializeComponent();
	}

	private void button2_Click(object sender, EventArgs e)
	{
		using StreamWriter streamWriter = new StreamWriter("SavePacketLog.txt");
		streamWriter.WriteLine(text_PacketLog.Text);
	}

	private void button1_Click(object sender, EventArgs e)
	{
		text_PacketLog.Text = "";
	}

	private void text_PacketLog_TextChanged(object sender, EventArgs e)
	{
		text_PacketLog.SelectionStart = text_PacketLog.Text.Length;
		text_PacketLog.ScrollToCaret();
	}

	private void radioButton1_CheckedChanged(object sender, EventArgs e)
	{
		ShowPacketLog = false;
	}

	private void radioButton2_CheckedChanged(object sender, EventArgs e)
	{
		ShowPacketLog = true;
	}

	private void button3_Click(object sender, EventArgs e)
	{
		new Thread((ThreadStart)delegate
		{
			//IL_001e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0024: Expected O, but got Unknown
			button3.Enabled = false;
			for (int i = 0; i < int.Parse(Packet_Count.Text); i++)
			{
				OutPacket val = new OutPacket(NamePacket.Text);
				try
				{
					val.WriteHexString(ValuePacket.Text);
					RouterListener.MySession.Server.Send(val);
				}
				finally
				{
					((IDisposable)val)?.Dispose();
				}
				Thread.Sleep(int.Parse(text_Sleep.Text));
			}
			button3.Enabled = true;
		}).Start();
	}

	private void Button4_Click(object sender, EventArgs e)
	{
		new Thread((ThreadStart)delegate
		{
			//IL_001e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0024: Expected O, but got Unknown
			button4.Enabled = false;
			for (int i = 0; i < int.Parse(Packet_Count.Text); i++)
			{
				OutPacket val = new OutPacket(NamePacket.Text);
				try
				{
					val.WriteHexString(ValuePacket.Text);
					((Session)RouterListener.MySession.Client).Send(val);
				}
				finally
				{
					((IDisposable)val)?.Dispose();
				}
				Thread.Sleep(int.Parse(text_Sleep.Text));
			}
			button4.Enabled = true;
		}).Start();
	}

	private void button5_Click(object sender, EventArgs e)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Expected O, but got Unknown
		OutPacket val = new OutPacket(64);
		try
		{
			val.WriteHexString(tx_ValuePacket.Text);
			RouterListener.MySession.Server.Send(val);
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	private void button6_Click(object sender, EventArgs e)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Expected O, but got Unknown
		OutPacket val = new OutPacket(64);
		try
		{
			val.WriteHexString(tx_ValuePacket.Text);
			((Session)RouterListener.MySession.Client).Send(val);
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		this.button2 = new System.Windows.Forms.Button();
		this.button1 = new System.Windows.Forms.Button();
		this.text_PacketLog = new System.Windows.Forms.TextBox();
		this.radioButton1 = new System.Windows.Forms.RadioButton();
		this.radioButton2 = new System.Windows.Forms.RadioButton();
		this.text_Sleep = new System.Windows.Forms.TextBox();
		this.Packet_Count = new System.Windows.Forms.TextBox();
		this.button3 = new System.Windows.Forms.Button();
		this.ValuePacket = new System.Windows.Forms.TextBox();
		this.NamePacket = new System.Windows.Forms.TextBox();
		this.button4 = new System.Windows.Forms.Button();
		this.tx_ValuePacket = new System.Windows.Forms.TextBox();
		this.button5 = new System.Windows.Forms.Button();
		this.button6 = new System.Windows.Forms.Button();
		base.SuspendLayout();
		this.button2.Location = new System.Drawing.Point(572, 219);
		this.button2.Name = "button2";
		this.button2.Size = new System.Drawing.Size(206, 23);
		this.button2.TabIndex = 48;
		this.button2.Text = "PacketLog Save";
		this.button2.UseVisualStyleBackColor = true;
		this.button2.Click += new System.EventHandler(button2_Click);
		this.button1.Location = new System.Drawing.Point(572, 190);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(206, 23);
		this.button1.TabIndex = 47;
		this.button1.Text = "PacketLog Delete";
		this.button1.UseVisualStyleBackColor = true;
		this.button1.Click += new System.EventHandler(button1_Click);
		this.text_PacketLog.Location = new System.Drawing.Point(17, 20);
		this.text_PacketLog.Multiline = true;
		this.text_PacketLog.Name = "text_PacketLog";
		this.text_PacketLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
		this.text_PacketLog.Size = new System.Drawing.Size(539, 371);
		this.text_PacketLog.TabIndex = 46;
		this.text_PacketLog.TextChanged += new System.EventHandler(text_PacketLog_TextChanged);
		this.radioButton1.AutoSize = true;
		this.radioButton1.Checked = true;
		this.radioButton1.Location = new System.Drawing.Point(572, 278);
		this.radioButton1.Name = "radioButton1";
		this.radioButton1.Size = new System.Drawing.Size(113, 16);
		this.radioButton1.TabIndex = 49;
		this.radioButton1.TabStop = true;
		this.radioButton1.Text = "Packet Log OFF";
		this.radioButton1.UseVisualStyleBackColor = true;
		this.radioButton1.CheckedChanged += new System.EventHandler(radioButton1_CheckedChanged);
		this.radioButton2.AutoSize = true;
		this.radioButton2.Location = new System.Drawing.Point(572, 254);
		this.radioButton2.Name = "radioButton2";
		this.radioButton2.Size = new System.Drawing.Size(108, 16);
		this.radioButton2.TabIndex = 50;
		this.radioButton2.Text = "Packet Log ON";
		this.radioButton2.UseVisualStyleBackColor = true;
		this.radioButton2.CheckedChanged += new System.EventHandler(radioButton2_CheckedChanged);
		this.text_Sleep.Location = new System.Drawing.Point(679, 132);
		this.text_Sleep.Name = "text_Sleep";
		this.text_Sleep.Size = new System.Drawing.Size(98, 21);
		this.text_Sleep.TabIndex = 346;
		this.text_Sleep.Text = "500";
		this.Packet_Count.Location = new System.Drawing.Point(572, 132);
		this.Packet_Count.Name = "Packet_Count";
		this.Packet_Count.Size = new System.Drawing.Size(100, 21);
		this.Packet_Count.TabIndex = 345;
		this.Packet_Count.Text = "1";
		this.button3.Location = new System.Drawing.Point(572, 74);
		this.button3.Name = "button3";
		this.button3.Size = new System.Drawing.Size(206, 23);
		this.button3.TabIndex = 344;
		this.button3.Text = "Server Send Packet";
		this.button3.UseVisualStyleBackColor = true;
		this.button3.Click += new System.EventHandler(button3_Click);
		this.ValuePacket.Location = new System.Drawing.Point(572, 47);
		this.ValuePacket.Name = "ValuePacket";
		this.ValuePacket.Size = new System.Drawing.Size(206, 21);
		this.ValuePacket.TabIndex = 343;
		this.NamePacket.Location = new System.Drawing.Point(572, 20);
		this.NamePacket.Name = "NamePacket";
		this.NamePacket.Size = new System.Drawing.Size(206, 21);
		this.NamePacket.TabIndex = 342;
		this.button4.Location = new System.Drawing.Point(572, 103);
		this.button4.Name = "button4";
		this.button4.Size = new System.Drawing.Size(206, 23);
		this.button4.TabIndex = 347;
		this.button4.Text = "Server Recv Packet";
		this.button4.UseVisualStyleBackColor = true;
		this.button4.Click += new System.EventHandler(Button4_Click);
		this.tx_ValuePacket.Location = new System.Drawing.Point(17, 402);
		this.tx_ValuePacket.Name = "tx_ValuePacket";
		this.tx_ValuePacket.Size = new System.Drawing.Size(760, 21);
		this.tx_ValuePacket.TabIndex = 348;
		this.button5.Location = new System.Drawing.Point(572, 339);
		this.button5.Name = "button5";
		this.button5.Size = new System.Drawing.Size(206, 23);
		this.button5.TabIndex = 349;
		this.button5.Text = "Server Send Packet";
		this.button5.UseVisualStyleBackColor = true;
		this.button5.Click += new System.EventHandler(button5_Click);
		this.button6.Location = new System.Drawing.Point(572, 368);
		this.button6.Name = "button6";
		this.button6.Size = new System.Drawing.Size(206, 23);
		this.button6.TabIndex = 350;
		this.button6.Text = "Server Recv Packet";
		this.button6.UseVisualStyleBackColor = true;
		this.button6.Click += new System.EventHandler(button6_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 12f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(794, 436);
		base.Controls.Add(this.button6);
		base.Controls.Add(this.button5);
		base.Controls.Add(this.tx_ValuePacket);
		base.Controls.Add(this.button4);
		base.Controls.Add(this.text_Sleep);
		base.Controls.Add(this.Packet_Count);
		base.Controls.Add(this.button3);
		base.Controls.Add(this.ValuePacket);
		base.Controls.Add(this.NamePacket);
		base.Controls.Add(this.radioButton2);
		base.Controls.Add(this.radioButton1);
		base.Controls.Add(this.button2);
		base.Controls.Add(this.button1);
		base.Controls.Add(this.text_PacketLog);
		this.Font = new System.Drawing.Font("굴림", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
		base.MaximizeBox = false;
		base.Name = "Development";
		this.Text = "Development";
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
