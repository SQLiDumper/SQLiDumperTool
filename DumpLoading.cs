using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;
using ns0;
using Taskbar;

// Token: 0x02000090 RID: 144
[DesignerGenerated]
public partial class DumpLoading : Form
{
	// Token: 0x06000809 RID: 2057 RVA: 0x000359DC File Offset: 0x00033BDC
	public DumpLoading(Form fOwner, ProgressBarStyle pBarStyle = ProgressBarStyle.Blocks)
	{
		base.Load += this.DumpLoading_Load;
		this.form_0 = fOwner;
		this.InitializeComponent();
		this.prgStatus.Value = 0;
		this.prgStatus.Maximum = 100;
		this.prgStatus.Style = pBarStyle;
		this.prgStatus.BringToFront();
		this.prgStatus.Visible = true;
		Globals.AddMouseMoveForm(this);
		Globals.translate_0.Add(this, this.icontainer_0);
	}

	// Token: 0x1700028B RID: 651
	// (get) Token: 0x0600080C RID: 2060 RVA: 0x00035E8C File Offset: 0x0003408C
	// (set) Token: 0x0600080D RID: 2061 RVA: 0x00035E94 File Offset: 0x00034094
	internal virtual ProgressBar prgStatus
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x1700028C RID: 652
	// (get) Token: 0x0600080E RID: 2062 RVA: 0x00035EA0 File Offset: 0x000340A0
	// (set) Token: 0x0600080F RID: 2063 RVA: 0x00035EA8 File Offset: 0x000340A8
	internal virtual GroupBox grbBack
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x1700028D RID: 653
	// (get) Token: 0x06000810 RID: 2064 RVA: 0x00035EB4 File Offset: 0x000340B4
	// (set) Token: 0x06000811 RID: 2065 RVA: 0x00035EBC File Offset: 0x000340BC
	internal virtual ToolStripButton tsbPause
	{
		[CompilerGenerated]
		get
		{
			return this._tsbPause;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_3);
			ToolStripButton toolStripButton = this._tsbPause;
			if (toolStripButton != null)
			{
				toolStripButton.Click -= eventHandler;
			}
			this._tsbPause = value;
			toolStripButton = this._tsbPause;
			if (toolStripButton != null)
			{
				toolStripButton.Click += eventHandler;
			}
		}
	}

	// Token: 0x1700028E RID: 654
	// (get) Token: 0x06000812 RID: 2066 RVA: 0x00035F00 File Offset: 0x00034100
	// (set) Token: 0x06000813 RID: 2067 RVA: 0x00035F08 File Offset: 0x00034108
	internal virtual ToolStripButton tsbStop
	{
		[CompilerGenerated]
		get
		{
			return this._tsbStop;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_4);
			ToolStripButton toolStripButton = this._tsbStop;
			if (toolStripButton != null)
			{
				toolStripButton.Click -= eventHandler;
			}
			this._tsbStop = value;
			toolStripButton = this._tsbStop;
			if (toolStripButton != null)
			{
				toolStripButton.Click += eventHandler;
			}
		}
	}

	// Token: 0x1700028F RID: 655
	// (get) Token: 0x06000814 RID: 2068 RVA: 0x00035F4C File Offset: 0x0003414C
	// (set) Token: 0x06000815 RID: 2069 RVA: 0x00035F54 File Offset: 0x00034154
	public virtual ToolStrip tstMain
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x14000003 RID: 3
	// (add) Token: 0x06000816 RID: 2070 RVA: 0x00035F60 File Offset: 0x00034160
	// (remove) Token: 0x06000817 RID: 2071 RVA: 0x00035F98 File Offset: 0x00034198
	public event DumpLoading.OnPauseEventHandler OnPause
	{
		[CompilerGenerated]
		add
		{
			DumpLoading.OnPauseEventHandler onPauseEventHandler = this.onPauseEventHandler_0;
			DumpLoading.OnPauseEventHandler onPauseEventHandler2;
			do
			{
				onPauseEventHandler2 = onPauseEventHandler;
				DumpLoading.OnPauseEventHandler onPauseEventHandler3 = (DumpLoading.OnPauseEventHandler)Delegate.Combine(onPauseEventHandler2, value);
				onPauseEventHandler = Interlocked.CompareExchange<DumpLoading.OnPauseEventHandler>(ref this.onPauseEventHandler_0, onPauseEventHandler3, onPauseEventHandler2);
			}
			while (onPauseEventHandler != onPauseEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			DumpLoading.OnPauseEventHandler onPauseEventHandler = this.onPauseEventHandler_0;
			DumpLoading.OnPauseEventHandler onPauseEventHandler2;
			do
			{
				onPauseEventHandler2 = onPauseEventHandler;
				DumpLoading.OnPauseEventHandler onPauseEventHandler3 = (DumpLoading.OnPauseEventHandler)Delegate.Remove(onPauseEventHandler2, value);
				onPauseEventHandler = Interlocked.CompareExchange<DumpLoading.OnPauseEventHandler>(ref this.onPauseEventHandler_0, onPauseEventHandler3, onPauseEventHandler2);
			}
			while (onPauseEventHandler != onPauseEventHandler2);
		}
	}

	// Token: 0x14000004 RID: 4
	// (add) Token: 0x06000818 RID: 2072 RVA: 0x00035FD0 File Offset: 0x000341D0
	// (remove) Token: 0x06000819 RID: 2073 RVA: 0x00036008 File Offset: 0x00034208
	public event DumpLoading.OnCancelEventHandler OnCancel
	{
		[CompilerGenerated]
		add
		{
			DumpLoading.OnCancelEventHandler onCancelEventHandler = this.onCancelEventHandler_0;
			DumpLoading.OnCancelEventHandler onCancelEventHandler2;
			do
			{
				onCancelEventHandler2 = onCancelEventHandler;
				DumpLoading.OnCancelEventHandler onCancelEventHandler3 = (DumpLoading.OnCancelEventHandler)Delegate.Combine(onCancelEventHandler2, value);
				onCancelEventHandler = Interlocked.CompareExchange<DumpLoading.OnCancelEventHandler>(ref this.onCancelEventHandler_0, onCancelEventHandler3, onCancelEventHandler2);
			}
			while (onCancelEventHandler != onCancelEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			DumpLoading.OnCancelEventHandler onCancelEventHandler = this.onCancelEventHandler_0;
			DumpLoading.OnCancelEventHandler onCancelEventHandler2;
			do
			{
				onCancelEventHandler2 = onCancelEventHandler;
				DumpLoading.OnCancelEventHandler onCancelEventHandler3 = (DumpLoading.OnCancelEventHandler)Delegate.Remove(onCancelEventHandler2, value);
				onCancelEventHandler = Interlocked.CompareExchange<DumpLoading.OnCancelEventHandler>(ref this.onCancelEventHandler_0, onCancelEventHandler3, onCancelEventHandler2);
			}
			while (onCancelEventHandler != onCancelEventHandler2);
		}
	}

	// Token: 0x0600081A RID: 2074 RVA: 0x00036040 File Offset: 0x00034240
	internal void method_0(int int_0, ref bool bool_2)
	{
		if (base.InvokeRequired)
		{
			base.Invoke(new DumpLoading.Delegate40(this.method_0), new object[] { int_0, bool_2 });
		}
		else
		{
			if (int_0 > 0)
			{
				this.prgStatus.Value = int_0;
				if (!Globals.GMain.Boolean_1)
				{
					Globals.G_Taskbar.SetProgressState(ProgressBarState.Normal);
					Globals.G_Taskbar.SetProgressValue(int_0, 100);
				}
			}
			bool_2 = this.bool_0;
		}
	}

	// Token: 0x17000290 RID: 656
	// (get) Token: 0x0600081B RID: 2075 RVA: 0x000360C4 File Offset: 0x000342C4
	internal bool Boolean_0
	{
		get
		{
			return this.bool_0;
		}
	}

	// Token: 0x17000291 RID: 657
	// (get) Token: 0x0600081C RID: 2076 RVA: 0x000360CC File Offset: 0x000342CC
	internal bool Boolean_1
	{
		get
		{
			return this.bool_1;
		}
	}

	// Token: 0x0600081D RID: 2077 RVA: 0x000360D4 File Offset: 0x000342D4
	internal void method_1(ProgressBarStyle progressBarStyle_0)
	{
		if (this.prgStatus.InvokeRequired)
		{
			this.prgStatus.Invoke(new DumpLoading.Delegate38(this.method_1), new object[] { progressBarStyle_0 });
		}
		else
		{
			this.prgStatus.Style = progressBarStyle_0;
			if (!Globals.GMain.Boolean_1)
			{
				if (this.prgStatus.Style == ProgressBarStyle.Marquee)
				{
					Globals.G_Taskbar.SetProgressState(ProgressBarState.Indeterminate);
				}
				else
				{
					Globals.G_Taskbar.SetProgressState(ProgressBarState.Normal);
				}
			}
		}
	}

	// Token: 0x0600081E RID: 2078 RVA: 0x0003615C File Offset: 0x0003435C
	internal void method_2(string string_0)
	{
		if (this.grbBack.InvokeRequired)
		{
			this.grbBack.Invoke(new DumpLoading.Delegate37(this.method_2), new object[] { string_0 });
		}
		else
		{
			this.grbBack.Text = string_0;
		}
	}

	// Token: 0x0600081F RID: 2079 RVA: 0x0003619C File Offset: 0x0003439C
	private void method_3(object sender, EventArgs e)
	{
		if (base.InvokeRequired)
		{
			base.Invoke(new DumpLoading.Delegate39(this.method_3), new object[] { sender, e });
		}
		else
		{
			this.bool_1 = this.tsbPause.Checked;
			DumpLoading.OnPauseEventHandler onPauseEventHandler = this.onPauseEventHandler_0;
			if (onPauseEventHandler != null)
			{
				onPauseEventHandler(this.bool_1);
			}
			if (!Globals.GMain.Boolean_1)
			{
				if (this.bool_1)
				{
					Globals.G_Taskbar.SetProgressState(ProgressBarState.Paused);
				}
				else
				{
					Globals.G_Taskbar.SetProgressState(ProgressBarState.Normal);
				}
			}
		}
	}

	// Token: 0x06000820 RID: 2080 RVA: 0x0003622C File Offset: 0x0003442C
	private void method_4(object sender, EventArgs e)
	{
		if (base.InvokeRequired)
		{
			base.Invoke(new DumpLoading.Delegate39(this.method_4), new object[] { sender, e });
		}
		else
		{
			this.tsbPause.Checked = false;
			this.tstMain.Enabled = false;
			this.bool_1 = false;
			this.bool_0 = true;
			DumpLoading.OnCancelEventHandler onCancelEventHandler = this.onCancelEventHandler_0;
			if (onCancelEventHandler != null)
			{
				onCancelEventHandler();
			}
		}
	}

	// Token: 0x06000821 RID: 2081 RVA: 0x0003629C File Offset: 0x0003449C
	private void DumpLoading_Load(object sender, EventArgs e)
	{
		this.prgStatus.BringToFront();
	}

	// Token: 0x04000441 RID: 1089
	private bool bool_0;

	// Token: 0x04000442 RID: 1090
	private bool bool_1;

	// Token: 0x04000443 RID: 1091
	private Form form_0;

	// Token: 0x04000444 RID: 1092
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private DumpLoading.OnPauseEventHandler onPauseEventHandler_0;

	// Token: 0x04000445 RID: 1093
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private DumpLoading.OnCancelEventHandler onCancelEventHandler_0;

	// Token: 0x02000091 RID: 145
	// (Invoke) Token: 0x06000825 RID: 2085
	private delegate void Delegate37(string s);

	// Token: 0x02000092 RID: 146
	// (Invoke) Token: 0x06000829 RID: 2089
	private delegate void Delegate38(ProgressBarStyle i);

	// Token: 0x02000093 RID: 147
	// (Invoke) Token: 0x0600082D RID: 2093
	private delegate void Delegate39(object sender, EventArgs e);

	// Token: 0x02000094 RID: 148
	// (Invoke) Token: 0x06000831 RID: 2097
	private delegate void Delegate40(int perc, ref bool bCancel);

	// Token: 0x02000095 RID: 149
	// (Invoke) Token: 0x06000835 RID: 2101
	public delegate void OnPauseEventHandler(bool bPaused);

	// Token: 0x02000096 RID: 150
	// (Invoke) Token: 0x06000839 RID: 2105
	public delegate void OnCancelEventHandler();
}
