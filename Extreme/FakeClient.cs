using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using KartRider.Common.Add;

namespace Extreme;

public class FakeClient : Form
{
	private IContainer components = null;

	private Label txKartRiderInfo;

	private TabControl tabCont_Info;

	private TabPage tab_AccountInfo;

	private TabPage tabPage2;

	private Label txAccountName;

	private Label txAccountID;

	private Label txRiderName;

	private Label txLucci;

	private Label txRP;

	public FakeClient()
	{
		InitializeComponent();
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	private void FakeClient_Load(object sender, EventArgs e)
	{
		txKartRiderInfo.Text = "KartRider (UNK) : Waiting for server connection...";
		txAccountID.Visible = true;
	}

	private void InitializeComponent()
	{
		this.txKartRiderInfo = new System.Windows.Forms.Label();
		this.tabCont_Info = new System.Windows.Forms.TabControl();
		this.tab_AccountInfo = new System.Windows.Forms.TabPage();
		this.txRP = new System.Windows.Forms.Label();
		this.txLucci = new System.Windows.Forms.Label();
		this.txRiderName = new System.Windows.Forms.Label();
		this.txAccountID = new System.Windows.Forms.Label();
		this.txAccountName = new System.Windows.Forms.Label();
		this.tabPage2 = new System.Windows.Forms.TabPage();
		this.tabCont_Info.SuspendLayout();
		this.tab_AccountInfo.SuspendLayout();
		base.SuspendLayout();
		this.txKartRiderInfo.AutoSize = true;
		this.txKartRiderInfo.Location = new System.Drawing.Point(13, 13);
		this.txKartRiderInfo.Name = "txKartRiderInfo";
		this.txKartRiderInfo.Size = new System.Drawing.Size(95, 12);
		this.txKartRiderInfo.TabIndex = 0;
		this.txKartRiderInfo.Text = "KartRider (KOR)";
		this.tabCont_Info.Controls.Add(this.tab_AccountInfo);
		this.tabCont_Info.Controls.Add(this.tabPage2);
		this.tabCont_Info.Location = new System.Drawing.Point(12, 49);
		this.tabCont_Info.Name = "tabCont_Info";
		this.tabCont_Info.SelectedIndex = 0;
		this.tabCont_Info.Size = new System.Drawing.Size(776, 375);
		this.tabCont_Info.TabIndex = 1;
		this.tab_AccountInfo.Controls.Add(this.txRP);
		this.tab_AccountInfo.Controls.Add(this.txLucci);
		this.tab_AccountInfo.Controls.Add(this.txRiderName);
		this.tab_AccountInfo.Controls.Add(this.txAccountID);
		this.tab_AccountInfo.Controls.Add(this.txAccountName);
		this.tab_AccountInfo.Location = new System.Drawing.Point(4, 22);
		this.tab_AccountInfo.Name = "tab_AccountInfo";
		this.tab_AccountInfo.Padding = new System.Windows.Forms.Padding(3);
		this.tab_AccountInfo.Size = new System.Drawing.Size(768, 349);
		this.tab_AccountInfo.TabIndex = 0;
		this.tab_AccountInfo.Text = "Account Info";
		this.tab_AccountInfo.UseVisualStyleBackColor = true;
		this.txRP.AutoSize = true;
		this.txRP.Location = new System.Drawing.Point(15, 102);
		this.txRP.Name = "txRP";
		this.txRP.Size = new System.Drawing.Size(33, 12);
		this.txRP.TabIndex = 4;
		this.txRP.Text = "RP : ";
		this.txLucci.AutoSize = true;
		this.txLucci.Location = new System.Drawing.Point(15, 80);
		this.txLucci.Name = "txLucci";
		this.txLucci.Size = new System.Drawing.Size(48, 12);
		this.txLucci.TabIndex = 3;
		this.txLucci.Text = "Lucci : ";
		this.txRiderName.AutoSize = true;
		this.txRiderName.Location = new System.Drawing.Point(15, 59);
		this.txRiderName.Name = "txRiderName";
		this.txRiderName.Size = new System.Drawing.Size(74, 12);
		this.txRiderName.TabIndex = 2;
		this.txRiderName.Text = "Nickname : ";
		this.txAccountID.AutoSize = true;
		this.txAccountID.Location = new System.Drawing.Point(15, 38);
		this.txAccountID.Name = "txAccountID";
		this.txAccountID.Size = new System.Drawing.Size(78, 12);
		this.txAccountID.TabIndex = 1;
		this.txAccountID.Text = "Account ID : ";
		this.txAccountName.AutoSize = true;
		this.txAccountName.Location = new System.Drawing.Point(15, 17);
		this.txAccountName.Name = "txAccountName";
		this.txAccountName.Size = new System.Drawing.Size(101, 12);
		this.txAccountName.TabIndex = 0;
		this.txAccountName.Text = "Account Name : ";
		this.tabPage2.Location = new System.Drawing.Point(4, 22);
		this.tabPage2.Name = "tabPage2";
		this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
		this.tabPage2.Size = new System.Drawing.Size(768, 349);
		this.tabPage2.TabIndex = 1;
		this.tabPage2.Text = "tabPage2";
		this.tabPage2.UseVisualStyleBackColor = true;
		base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 12f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(800, 436);
		base.Controls.Add(this.tabCont_Info);
		base.Controls.Add(this.txKartRiderInfo);
		this.Font = new System.Drawing.Font("굴림", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
		base.MaximizeBox = false;
		base.Name = "FakeClient";
		this.Text = "FakeClient";
		base.Load += new System.EventHandler(FakeClient_Load);
		this.tabCont_Info.ResumeLayout(false);
		this.tab_AccountInfo.ResumeLayout(false);
		this.tab_AccountInfo.PerformLayout();
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	public void UpdateAccountInfo(uint uAccountID, string strAccountName)
	{
		if (!txAccountName.InvokeRequired && !txAccountID.InvokeRequired)
		{
			txAccountName.Text = $"Account Name : {strAccountName}";
			txAccountID.Text = $"Account ID : {uAccountID}";
			return;
		}
		Invoke((MethodInvoker)delegate
		{
			txAccountName.Text = $"Account Name : {strAccountName}";
			txAccountID.Text = $"Account ID : {uAccountID}";
		});
	}

	public void UpdateKartRiderInfo(ushort usLocale, ushort usMajorVer, ushort usMinorVer, string strPatch, byte nClientLoc)
	{
		if (!txKartRiderInfo.InvokeRequired)
		{
			txKartRiderInfo.Text = $"KartRider (Region:{VersionInfo.GetRegionFromLocale(usLocale)}, Lang:{VersionInfo.GetLang(nClientLoc)}) Ver. {usMajorVer}.{usMinorVer}";
			return;
		}
		Invoke((MethodInvoker)delegate
		{
			txKartRiderInfo.Text = $"KartRider (Region:{VersionInfo.GetRegionFromLocale(usLocale)}, Lang:{VersionInfo.GetLang(nClientLoc)}) Ver. {usMajorVer}.{usMinorVer}";
		});
	}

	public void UpdateLucci(uint nLucci)
	{
		if (!txLucci.InvokeRequired)
		{
			txLucci.Text = $"Lucci : {nLucci}";
			return;
		}
		Invoke((MethodInvoker)delegate
		{
			txLucci.Text = $"Lucci : {nLucci}";
		});
	}

	public void UpdateRiderName(string strRiderName)
	{
		if (!txRiderName.InvokeRequired)
		{
			txRiderName.Text = $"Rider Name : {strRiderName}";
			return;
		}
		Invoke((MethodInvoker)delegate
		{
			txRiderName.Text = $"Rider Name : {strRiderName}";
		});
	}

	public void UpdateRP(int nRP)
	{
		if (!txRP.InvokeRequired)
		{
			txRP.Text = $"RP : {nRP}";
			return;
		}
		Invoke((MethodInvoker)delegate
		{
			txRP.Text = $"RP : {nRP}";
		});
	}
}
