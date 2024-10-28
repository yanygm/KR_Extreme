using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Extreme;

public class AntiHackDlg : Form
{
	public class UserItem
	{
		public int Slot { get; set; }

		public string UserNick { get; set; }

		public uint UserNO { get; set; }

		public UserItem(UserItem o)
		{
			UserNick = o.UserNick;
			UserNO = o.UserNO;
			Slot = o.Slot;
		}

		public UserItem()
		{
		}

		public override string ToString()
		{
			return $"{UserNick} ({UserNO})";
		}
	}

	private IContainer components = null;

	private ListBox listBox_Hack;

	private ListBox listBox_CurUser;

	private Button button1;

	private Button button2;

	public AntiHackDlg()
	{
		InitializeComponent();
	}

	public void AddCurUser(string sIndex, uint userNo, int slot)
	{
		listBox_CurUser.Invoke((MethodInvoker)delegate
		{
			listBox_CurUser.Items.Add(new UserItem
			{
				UserNick = sIndex,
				UserNO = userNo,
				Slot = slot
			});
		});
	}

	private void button1_Click(object sender, EventArgs e)
	{
		if (listBox_CurUser.SelectedIndex < 0 || listBox_CurUser.SelectedIndex >= listBox_CurUser.Items.Count)
		{
			return;
		}
		UserItem userItem = new UserItem((UserItem)listBox_CurUser.Items[listBox_CurUser.SelectedIndex]);
		if (userItem.Slot != -1)
		{
			RouterForm.Disconnect(userItem.Slot);
		}
		userItem.Slot = -1;
		if (!HasUser(userItem.UserNO))
		{
			listBox_Hack.Invoke((MethodInvoker)delegate
			{
				listBox_Hack.Items.Add(userItem);
			});
		}
	}

	private void button2_Click(object sender, EventArgs e)
	{
		if (listBox_Hack.SelectedIndex >= 0 && listBox_Hack.SelectedIndex < listBox_Hack.Items.Count)
		{
			listBox_Hack.Invoke((MethodInvoker)delegate
			{
				listBox_Hack.Items.RemoveAt(listBox_Hack.SelectedIndex);
			});
		}
	}

	public void ClearCurUsers()
	{
		listBox_CurUser.Invoke((MethodInvoker)delegate
		{
			listBox_CurUser.Items.Clear();
		});
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	public bool HasUser(uint userNo)
	{
		foreach (object item in listBox_Hack.Items)
		{
			if ((item as UserItem).UserNO == userNo)
			{
				return true;
			}
		}
		return false;
	}

	private void InitializeComponent()
	{
		this.listBox_Hack = new System.Windows.Forms.ListBox();
		this.listBox_CurUser = new System.Windows.Forms.ListBox();
		this.button1 = new System.Windows.Forms.Button();
		this.button2 = new System.Windows.Forms.Button();
		base.SuspendLayout();
		this.listBox_Hack.FormattingEnabled = true;
		this.listBox_Hack.ItemHeight = 12;
		this.listBox_Hack.Location = new System.Drawing.Point(13, 13);
		this.listBox_Hack.Name = "listBox_Hack";
		this.listBox_Hack.Size = new System.Drawing.Size(178, 292);
		this.listBox_Hack.TabIndex = 0;
		this.listBox_CurUser.FormattingEnabled = true;
		this.listBox_CurUser.ItemHeight = 12;
		this.listBox_CurUser.Location = new System.Drawing.Point(198, 13);
		this.listBox_CurUser.Name = "listBox_CurUser";
		this.listBox_CurUser.Size = new System.Drawing.Size(178, 292);
		this.listBox_CurUser.TabIndex = 1;
		this.button1.Location = new System.Drawing.Point(198, 311);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(105, 23);
		this.button1.TabIndex = 2;
		this.button1.Text = "선택한 유저 등록";
		this.button1.UseVisualStyleBackColor = true;
		this.button1.Click += new System.EventHandler(button1_Click);
		this.button2.Location = new System.Drawing.Point(13, 311);
		this.button2.Name = "button2";
		this.button2.Size = new System.Drawing.Size(105, 23);
		this.button2.TabIndex = 3;
		this.button2.Text = "선택한 유저 삭제";
		this.button2.UseVisualStyleBackColor = true;
		this.button2.Click += new System.EventHandler(button2_Click);
		this.AllowDrop = true;
		base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 12f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(390, 352);
		base.Controls.Add(this.button2);
		base.Controls.Add(this.button1);
		base.Controls.Add(this.listBox_CurUser);
		base.Controls.Add(this.listBox_Hack);
		this.Font = new System.Drawing.Font("굴림", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
		base.MaximizeBox = false;
		base.Name = "AntiHackDlg";
		this.Text = "AntiHackDlg";
		base.ResumeLayout(false);
	}
}
