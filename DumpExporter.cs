using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Web;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ns0;

// Token: 0x0200008C RID: 140
[DesignerGenerated]
public partial class DumpExporter : Form
{
	// Token: 0x060007BB RID: 1979 RVA: 0x0003353C File Offset: 0x0003173C
	public DumpExporter(DataGridView g, string dFileName, string sURL, Dumper o)
	{
		base.FormClosing += this.DumpExporter_FormClosing;
		base.Load += this.DumpExporter_Load;
		this.InitializeComponent();
		this.dataGridView_0 = g;
		this.string_0 = dFileName;
		this.string_1 = sURL;
		this.dumper_0 = o;
		global::Globals.translate_0.Add(this, this.icontainer_0);
	}

	// Token: 0x17000272 RID: 626
	// (get) Token: 0x060007BE RID: 1982 RVA: 0x0003456C File Offset: 0x0003276C
	// (set) Token: 0x060007BF RID: 1983 RVA: 0x00034574 File Offset: 0x00032774
	internal virtual Button OK_Button
	{
		[CompilerGenerated]
		get
		{
			return this._OK_Button;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_6);
			Button button = this._OK_Button;
			if (button != null)
			{
				button.Click -= eventHandler;
			}
			this._OK_Button = value;
			button = this._OK_Button;
			if (button != null)
			{
				button.Click += eventHandler;
			}
		}
	}

	// Token: 0x17000273 RID: 627
	// (get) Token: 0x060007C0 RID: 1984 RVA: 0x000345B8 File Offset: 0x000327B8
	// (set) Token: 0x060007C1 RID: 1985 RVA: 0x000345C0 File Offset: 0x000327C0
	internal virtual Button Cancel_Button
	{
		[CompilerGenerated]
		get
		{
			return this._Cancel_Button;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_7);
			Button button = this._Cancel_Button;
			if (button != null)
			{
				button.Click -= eventHandler;
			}
			this._Cancel_Button = value;
			button = this._Cancel_Button;
			if (button != null)
			{
				button.Click += eventHandler;
			}
		}
	}

	// Token: 0x17000274 RID: 628
	// (get) Token: 0x060007C2 RID: 1986 RVA: 0x00034604 File Offset: 0x00032804
	// (set) Token: 0x060007C3 RID: 1987 RVA: 0x0003460C File Offset: 0x0003280C
	internal virtual GroupBox grbDelimiter
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x17000275 RID: 629
	// (get) Token: 0x060007C4 RID: 1988 RVA: 0x00034618 File Offset: 0x00032818
	// (set) Token: 0x060007C5 RID: 1989 RVA: 0x00034620 File Offset: 0x00032820
	internal virtual RadioButton rdbOpt1
	{
		[CompilerGenerated]
		get
		{
			return this._rdbOpt1;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_8);
			EventHandler eventHandler2 = new EventHandler(this.method_8);
			RadioButton radioButton = this._rdbOpt1;
			if (radioButton != null)
			{
				radioButton.CheckedChanged -= eventHandler;
				radioButton.CheckedChanged -= eventHandler2;
			}
			this._rdbOpt1 = value;
			radioButton = this._rdbOpt1;
			if (radioButton != null)
			{
				radioButton.CheckedChanged += eventHandler;
				radioButton.CheckedChanged += eventHandler2;
			}
		}
	}

	// Token: 0x17000276 RID: 630
	// (get) Token: 0x060007C6 RID: 1990 RVA: 0x00034680 File Offset: 0x00032880
	// (set) Token: 0x060007C7 RID: 1991 RVA: 0x00034688 File Offset: 0x00032888
	internal virtual RadioButton rdbOpt2
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x17000277 RID: 631
	// (get) Token: 0x060007C8 RID: 1992 RVA: 0x00034694 File Offset: 0x00032894
	// (set) Token: 0x060007C9 RID: 1993 RVA: 0x0003469C File Offset: 0x0003289C
	internal virtual TextBox txtDeli
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x17000278 RID: 632
	// (get) Token: 0x060007CA RID: 1994 RVA: 0x000346A8 File Offset: 0x000328A8
	// (set) Token: 0x060007CB RID: 1995 RVA: 0x000346B0 File Offset: 0x000328B0
	internal virtual StatusStrip stsMain
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x17000279 RID: 633
	// (get) Token: 0x060007CC RID: 1996 RVA: 0x000346BC File Offset: 0x000328BC
	// (set) Token: 0x060007CD RID: 1997 RVA: 0x000346C4 File Offset: 0x000328C4
	internal virtual ToolStripStatusLabel lblStatus
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x1700027A RID: 634
	// (get) Token: 0x060007CE RID: 1998 RVA: 0x000346D0 File Offset: 0x000328D0
	// (set) Token: 0x060007CF RID: 1999 RVA: 0x000346D8 File Offset: 0x000328D8
	internal virtual ProgressBar prbStatus
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x1700027B RID: 635
	// (get) Token: 0x060007D0 RID: 2000 RVA: 0x000346E4 File Offset: 0x000328E4
	// (set) Token: 0x060007D1 RID: 2001 RVA: 0x000346EC File Offset: 0x000328EC
	internal virtual BackgroundWorker bwSave
	{
		[CompilerGenerated]
		get
		{
			return this.backgroundWorker_0;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			DoWorkEventHandler doWorkEventHandler = new DoWorkEventHandler(this.method_2);
			ProgressChangedEventHandler progressChangedEventHandler = new ProgressChangedEventHandler(this.method_3);
			RunWorkerCompletedEventHandler runWorkerCompletedEventHandler = new RunWorkerCompletedEventHandler(this.method_4);
			BackgroundWorker backgroundWorker = this.backgroundWorker_0;
			if (backgroundWorker != null)
			{
				backgroundWorker.DoWork -= doWorkEventHandler;
				backgroundWorker.ProgressChanged -= progressChangedEventHandler;
				backgroundWorker.RunWorkerCompleted -= runWorkerCompletedEventHandler;
			}
			this.backgroundWorker_0 = value;
			backgroundWorker = this.backgroundWorker_0;
			if (backgroundWorker != null)
			{
				backgroundWorker.DoWork += doWorkEventHandler;
				backgroundWorker.ProgressChanged += progressChangedEventHandler;
				backgroundWorker.RunWorkerCompleted += runWorkerCompletedEventHandler;
			}
		}
	}

	// Token: 0x1700027C RID: 636
	// (get) Token: 0x060007D2 RID: 2002 RVA: 0x00034768 File Offset: 0x00032968
	// (set) Token: 0x060007D3 RID: 2003 RVA: 0x00034770 File Offset: 0x00032970
	internal virtual GroupBox grbColumns
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x1700027D RID: 637
	// (get) Token: 0x060007D4 RID: 2004 RVA: 0x0003477C File Offset: 0x0003297C
	// (set) Token: 0x060007D5 RID: 2005 RVA: 0x00034784 File Offset: 0x00032984
	internal virtual CheckedListBox lsColumns
	{
		[CompilerGenerated]
		get
		{
			return this._lsColumns;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			ItemCheckEventHandler itemCheckEventHandler = new ItemCheckEventHandler(this.method_14);
			CheckedListBox checkedListBox = this._lsColumns;
			if (checkedListBox != null)
			{
				checkedListBox.ItemCheck -= itemCheckEventHandler;
			}
			this._lsColumns = value;
			checkedListBox = this._lsColumns;
			if (checkedListBox != null)
			{
				checkedListBox.ItemCheck += itemCheckEventHandler;
			}
		}
	}

	// Token: 0x1700027E RID: 638
	// (get) Token: 0x060007D6 RID: 2006 RVA: 0x000347C8 File Offset: 0x000329C8
	// (set) Token: 0x060007D7 RID: 2007 RVA: 0x000347D0 File Offset: 0x000329D0
	internal virtual ContextMenuStrip mnuColumns
	{
		[CompilerGenerated]
		get
		{
			return this._mnuColumns;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			CancelEventHandler cancelEventHandler = new CancelEventHandler(this.method_11);
			ContextMenuStrip contextMenuStrip = this._mnuColumns;
			if (contextMenuStrip != null)
			{
				contextMenuStrip.Opening -= cancelEventHandler;
			}
			this._mnuColumns = value;
			contextMenuStrip = this._mnuColumns;
			if (contextMenuStrip != null)
			{
				contextMenuStrip.Opening += cancelEventHandler;
			}
		}
	}

	// Token: 0x1700027F RID: 639
	// (get) Token: 0x060007D8 RID: 2008 RVA: 0x00034814 File Offset: 0x00032A14
	// (set) Token: 0x060007D9 RID: 2009 RVA: 0x0003481C File Offset: 0x00032A1C
	internal virtual ToolStripMenuItem mmnCheck
	{
		[CompilerGenerated]
		get
		{
			return this._mmnCheck;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_9);
			ToolStripMenuItem toolStripMenuItem = this._mmnCheck;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= eventHandler;
			}
			this._mmnCheck = value;
			toolStripMenuItem = this._mmnCheck;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += eventHandler;
			}
		}
	}

	// Token: 0x17000280 RID: 640
	// (get) Token: 0x060007DA RID: 2010 RVA: 0x00034860 File Offset: 0x00032A60
	// (set) Token: 0x060007DB RID: 2011 RVA: 0x00034868 File Offset: 0x00032A68
	internal virtual ToolStripMenuItem mmnUnCheck
	{
		[CompilerGenerated]
		get
		{
			return this._mmnUnCheck;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_9);
			ToolStripMenuItem toolStripMenuItem = this._mmnUnCheck;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= eventHandler;
			}
			this._mmnUnCheck = value;
			toolStripMenuItem = this._mmnUnCheck;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += eventHandler;
			}
		}
	}

	// Token: 0x17000281 RID: 641
	// (get) Token: 0x060007DC RID: 2012 RVA: 0x000348AC File Offset: 0x00032AAC
	// (set) Token: 0x060007DD RID: 2013 RVA: 0x000348B4 File Offset: 0x00032AB4
	internal virtual TextBox txtReplaceLine
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x17000282 RID: 642
	// (get) Token: 0x060007DE RID: 2014 RVA: 0x000348C0 File Offset: 0x00032AC0
	// (set) Token: 0x060007DF RID: 2015 RVA: 0x000348C8 File Offset: 0x00032AC8
	internal virtual CheckBox chkReplaceLines
	{
		[CompilerGenerated]
		get
		{
			return this._chkReplaceLines;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_10);
			CheckBox checkBox = this._chkReplaceLines;
			if (checkBox != null)
			{
				checkBox.CheckedChanged -= eventHandler;
			}
			this._chkReplaceLines = value;
			checkBox = this._chkReplaceLines;
			if (checkBox != null)
			{
				checkBox.CheckedChanged += eventHandler;
			}
		}
	}

	// Token: 0x17000283 RID: 643
	// (get) Token: 0x060007E0 RID: 2016 RVA: 0x0003490C File Offset: 0x00032B0C
	// (set) Token: 0x060007E1 RID: 2017 RVA: 0x00034914 File Offset: 0x00032B14
	internal virtual ToolStripMenuItem mnuMoveUP
	{
		[CompilerGenerated]
		get
		{
			return this._mnuMoveUP;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_12);
			ToolStripMenuItem toolStripMenuItem = this._mnuMoveUP;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= eventHandler;
			}
			this._mnuMoveUP = value;
			toolStripMenuItem = this._mnuMoveUP;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += eventHandler;
			}
		}
	}

	// Token: 0x17000284 RID: 644
	// (get) Token: 0x060007E2 RID: 2018 RVA: 0x00034958 File Offset: 0x00032B58
	// (set) Token: 0x060007E3 RID: 2019 RVA: 0x00034960 File Offset: 0x00032B60
	internal virtual ToolStripMenuItem mnuMoveDown
	{
		[CompilerGenerated]
		get
		{
			return this._mnuMoveDown;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_12);
			ToolStripMenuItem toolStripMenuItem = this._mnuMoveDown;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= eventHandler;
			}
			this._mnuMoveDown = value;
			toolStripMenuItem = this._mnuMoveDown;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += eventHandler;
			}
		}
	}

	// Token: 0x17000285 RID: 645
	// (get) Token: 0x060007E4 RID: 2020 RVA: 0x000349A4 File Offset: 0x00032BA4
	// (set) Token: 0x060007E5 RID: 2021 RVA: 0x000349AC File Offset: 0x00032BAC
	internal virtual ToolStripSeparator ToolStripSeparator1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x17000286 RID: 646
	// (get) Token: 0x060007E6 RID: 2022 RVA: 0x000349B8 File Offset: 0x00032BB8
	// (set) Token: 0x060007E7 RID: 2023 RVA: 0x000349C0 File Offset: 0x00032BC0
	internal virtual GroupBox grbType
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x17000287 RID: 647
	// (get) Token: 0x060007E8 RID: 2024 RVA: 0x000349CC File Offset: 0x00032BCC
	// (set) Token: 0x060007E9 RID: 2025 RVA: 0x000349D4 File Offset: 0x00032BD4
	internal virtual RadioButton rdpType_2
	{
		[CompilerGenerated]
		get
		{
			return this._rdpType_2;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_13);
			RadioButton radioButton = this._rdpType_2;
			if (radioButton != null)
			{
				radioButton.CheckedChanged -= eventHandler;
			}
			this._rdpType_2 = value;
			radioButton = this._rdpType_2;
			if (radioButton != null)
			{
				radioButton.CheckedChanged += eventHandler;
			}
		}
	}

	// Token: 0x17000288 RID: 648
	// (get) Token: 0x060007EA RID: 2026 RVA: 0x00034A18 File Offset: 0x00032C18
	// (set) Token: 0x060007EB RID: 2027 RVA: 0x00034A20 File Offset: 0x00032C20
	internal virtual RadioButton rdpType_1
	{
		[CompilerGenerated]
		get
		{
			return this._rdpType_1;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_13);
			RadioButton radioButton = this._rdpType_1;
			if (radioButton != null)
			{
				radioButton.CheckedChanged -= eventHandler;
			}
			this._rdpType_1 = value;
			radioButton = this._rdpType_1;
			if (radioButton != null)
			{
				radioButton.CheckedChanged += eventHandler;
			}
		}
	}

	// Token: 0x17000289 RID: 649
	// (get) Token: 0x060007EC RID: 2028 RVA: 0x00034A64 File Offset: 0x00032C64
	// (set) Token: 0x060007ED RID: 2029 RVA: 0x00034A6C File Offset: 0x00032C6C
	internal virtual RadioButton rdpType_3
	{
		[CompilerGenerated]
		get
		{
			return this._rdpType_3;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_13);
			RadioButton radioButton = this._rdpType_3;
			if (radioButton != null)
			{
				radioButton.CheckedChanged -= eventHandler;
			}
			this._rdpType_3 = value;
			radioButton = this._rdpType_3;
			if (radioButton != null)
			{
				radioButton.CheckedChanged += eventHandler;
			}
		}
	}

	// Token: 0x1700028A RID: 650
	// (get) Token: 0x060007EE RID: 2030 RVA: 0x00034AB0 File Offset: 0x00032CB0
	// (set) Token: 0x060007EF RID: 2031 RVA: 0x00034AB8 File Offset: 0x00032CB8
	internal virtual Panel Panel1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x060007F0 RID: 2032 RVA: 0x00034AC4 File Offset: 0x00032CC4
	private DataGridViewRow method_0(int int_1)
	{
		DataGridViewRow dataGridViewRow;
		if (this.dataGridView_0.InvokeRequired)
		{
			dataGridViewRow = (DataGridViewRow)this.dataGridView_0.Invoke(new DumpExporter.Delegate35(this.method_0), new object[] { int_1 });
		}
		else
		{
			dataGridViewRow = this.dataGridView_0.Rows[int_1];
		}
		return dataGridViewRow;
	}

	// Token: 0x060007F1 RID: 2033 RVA: 0x00034B20 File Offset: 0x00032D20
	private int method_1()
	{
		int num;
		if (this.dataGridView_0.InvokeRequired)
		{
			num = Conversions.ToInteger(this.dataGridView_0.Invoke(new DumpExporter.Delegate36(this.method_1)));
		}
		else
		{
			num = this.dataGridView_0.RowCount;
		}
		return num;
	}

	// Token: 0x060007F2 RID: 2034 RVA: 0x00034B68 File Offset: 0x00032D68
	private void method_2(object sender, DoWorkEventArgs e)
	{
		StreamWriter streamWriter = null;
		checked
		{
			try
			{
				this.bool_0 = true;
				streamWriter = new StreamWriter(this.string_0, false, Encoding.Unicode);
				try
				{
					foreach (KeyValuePair<string, int> keyValuePair in this.dictionary_0)
					{
						bool flag;
						switch (this.enFileTytpe_0)
						{
						case DumpExporter.enFileTytpe.const_0:
							if (flag)
							{
								streamWriter.Write(this.string_6 + keyValuePair.Key);
							}
							else
							{
								streamWriter.Write(DateAndTime.Now.ToString());
								streamWriter.WriteLine();
								streamWriter.Write(global::Globals.APP_VERSION);
								streamWriter.WriteLine();
								streamWriter.Write(this.string_1);
								streamWriter.WriteLine();
								streamWriter.WriteLine();
								streamWriter.Write(keyValuePair.Key);
							}
							break;
						case DumpExporter.enFileTytpe.HTML:
							if (!flag)
							{
								streamWriter.WriteLine("<html>");
								streamWriter.WriteLine("<title>" + HttpUtility.HtmlEncode(this.string_1) + "</title>");
								streamWriter.WriteLine("<body>");
								streamWriter.WriteLine("<table border>");
								streamWriter.WriteLine("<tr>");
							}
							streamWriter.WriteLine("<td>" + HttpUtility.HtmlEncode(keyValuePair.Key) + "</td>");
							break;
						case DumpExporter.enFileTytpe.const_2:
							if (!flag)
							{
								streamWriter.WriteLine("<DocumentElement>");
								streamWriter.WriteLine("<URL>" + HttpUtility.HtmlEncode(this.string_1) + "</URL>");
							}
							break;
						}
						flag = true;
					}
				}
				finally
				{
					Dictionary<string, int>.Enumerator enumerator;
					((IDisposable)enumerator).Dispose();
				}
				switch (this.enFileTytpe_0)
				{
				case DumpExporter.enFileTytpe.const_0:
					streamWriter.WriteLine();
					break;
				case DumpExporter.enFileTytpe.HTML:
					streamWriter.WriteLine("</tr>");
					break;
				}
				int num2;
				for (;;)
				{
					int num = (int)Math.Round(Math.Round((double)((num2 + 1) * 100) / (double)this.method_1()));
					this.bwSave.ReportProgress(num, "Rows " + Strings.FormatNumber(num2, 0, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault) + " of " + Strings.FormatNumber(this.method_1(), 0, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault));
					if (this.bwSave.CancellationPending)
					{
						break;
					}
					DataGridViewRow dataGridViewRow = this.method_0(num2);
					bool flag = false;
					try
					{
						foreach (KeyValuePair<string, int> keyValuePair2 in this.dictionary_0)
						{
							string text = Conversions.ToString(dataGridViewRow.Cells[keyValuePair2.Value].Value);
							if (this.enFileTytpe_0 == DumpExporter.enFileTytpe.const_0 && this.bool_1)
							{
								if (text.IndexOf("\n") > 0)
								{
									text = text.Replace("\n", this.string_5);
								}
								if (text.IndexOf("\v\n") > 0)
								{
									text = text.Replace("\v\n", this.string_5);
								}
								if (text.IndexOf("\r") > 0)
								{
									text = text.Replace("\r", this.string_5);
								}
								if (text.IndexOf("\r\n") > 0)
								{
									text = text.Replace("\r\n", this.string_5);
								}
							}
							switch (this.enFileTytpe_0)
							{
							case DumpExporter.enFileTytpe.const_0:
								if (flag)
								{
									streamWriter.Write(this.string_6 + text);
								}
								else
								{
									streamWriter.Write(text);
								}
								break;
							case DumpExporter.enFileTytpe.HTML:
								if (!flag)
								{
									streamWriter.WriteLine("<tr>");
								}
								streamWriter.WriteLine("<td>" + HttpUtility.HtmlEncode(text) + "</td>");
								break;
							case DumpExporter.enFileTytpe.const_2:
							{
								if (!flag)
								{
									streamWriter.WriteLine("<item>");
								}
								string text2 = HttpUtility.HtmlEncode(keyValuePair2.Key);
								streamWriter.WriteLine(string.Concat(new string[]
								{
									"<",
									text2,
									">",
									HttpUtility.HtmlEncode(text),
									"</",
									text2,
									">"
								}));
								break;
							}
							}
							flag = true;
						}
					}
					finally
					{
						Dictionary<string, int>.Enumerator enumerator2;
						((IDisposable)enumerator2).Dispose();
					}
					switch (this.enFileTytpe_0)
					{
					case DumpExporter.enFileTytpe.const_0:
						streamWriter.WriteLine();
						break;
					case DumpExporter.enFileTytpe.HTML:
						streamWriter.WriteLine("</tr>");
						break;
					case DumpExporter.enFileTytpe.const_2:
						streamWriter.WriteLine("</item>");
						break;
					}
					num2++;
					if (this.dumper_0.Boolean_0)
					{
						if (num2 >= this.method_1() - 1)
						{
							do
							{
								this.bwSave.ReportProgress(num, "Waiting.. Rows " + Strings.FormatNumber(num2, 0, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault) + " of " + Strings.FormatNumber(this.method_1(), 0, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault));
								Thread.Sleep(200);
								if (!this.dumper_0.Boolean_0)
								{
									break;
								}
							}
							while (this.method_1() - 1 - num2 <= 20 && !this.bwSave.CancellationPending);
						}
					}
					else if (num2 >= this.method_1() - 1)
					{
						break;
					}
				}
				switch (this.enFileTytpe_0)
				{
				case DumpExporter.enFileTytpe.HTML:
					streamWriter.WriteLine("</body>");
					streamWriter.WriteLine("</html>");
					break;
				case DumpExporter.enFileTytpe.const_2:
					streamWriter.WriteLine("</DocumentElement>");
					break;
				}
				if (num2 == this.method_1() - 1)
				{
					e.Result = "Saved " + Strings.FormatNumber(this.method_1(), 0, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault) + " rows.";
				}
				else
				{
					e.Result = string.Concat(new string[]
					{
						"Saved ",
						Strings.FormatNumber(this.method_1(), 0, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault),
						" rows, missed ",
						Conversions.ToString(this.method_1() - 1 - num2),
						"."
					});
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			finally
			{
				if (this.bwSave.CancellationPending)
				{
					e.Result = "Canceled by user";
				}
				if (streamWriter != null)
				{
					streamWriter.Close();
				}
			}
		}
	}

	// Token: 0x060007F3 RID: 2035 RVA: 0x00035228 File Offset: 0x00033428
	private void method_3(object sender, ProgressChangedEventArgs e)
	{
		if (e.ProgressPercentage < 100)
		{
			this.prbStatus.Value = e.ProgressPercentage;
		}
		this.lblStatus.Text = e.UserState.ToString();
	}

	// Token: 0x060007F4 RID: 2036 RVA: 0x00035260 File Offset: 0x00033460
	private void method_4(object sender, RunWorkerCompletedEventArgs e)
	{
		this.prbStatus.Value = 0;
		this.prbStatus.Visible = false;
		if (e.Result == null)
		{
			this.lblStatus.Text = "Ready.";
		}
		else
		{
			this.lblStatus.Text = e.Result.ToString();
		}
		this.OK_Button.Enabled = true;
		this.OK_Button.Text = "&Start..";
		this.Cancel_Button.Enabled = true;
		this.grbDelimiter.Enabled = true;
		this.grbColumns.Enabled = true;
		this.method_13(null, null);
		this.bool_0 = false;
	}

	// Token: 0x060007F5 RID: 2037 RVA: 0x00035308 File Offset: 0x00033508
	private int method_5(string string_7)
	{
		checked
		{
			int num = this.dataGridView_0.ColumnCount - 1;
			for (int i = 1; i <= num; i++)
			{
				if (string_7.Equals(this.dataGridView_0.Columns[i].HeaderText))
				{
					return i;
				}
			}
			return -1;
		}
	}

	// Token: 0x060007F6 RID: 2038 RVA: 0x00035354 File Offset: 0x00033554
	private void method_6(object sender, EventArgs e)
	{
		checked
		{
			if (this.OK_Button.Text.Equals("&Start.."))
			{
				this.dictionary_0 = new Dictionary<string, int>();
				int num = this.lsColumns.Items.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					string text = Conversions.ToString(this.lsColumns.Items[i]);
					if (this.lsColumns.GetItemChecked(i))
					{
						this.dictionary_0.Add(text, this.method_5(text));
					}
				}
				if (this.dictionary_0.Count == 0)
				{
					Interaction.Beep();
					this.lblStatus.Text = "Selected the column(s).";
					return;
				}
				if (this.rdbOpt1.Checked)
				{
					this.string_6 = "\t";
				}
				else
				{
					this.string_6 = this.txtDeli.Text;
				}
				this.bool_1 = this.chkReplaceLines.Checked;
				this.string_5 = this.txtReplaceLine.Text;
				using (SaveFileDialog saveFileDialog = new SaveFileDialog())
				{
					saveFileDialog.Title = "Save as..";
					saveFileDialog.FileName = this.string_0.Replace("/", "-");
					saveFileDialog.InitialDirectory = this.string_4;
					bool flag;
					if ((flag = true) == this.rdpType_1.Checked)
					{
						this.enFileTytpe_0 = DumpExporter.enFileTytpe.const_0;
						saveFileDialog.Filter = "Text File|*.txt";
						saveFileDialog.FileName = Path.ChangeExtension(saveFileDialog.FileName, "txt");
					}
					else if (flag == this.rdpType_2.Checked)
					{
						this.enFileTytpe_0 = DumpExporter.enFileTytpe.HTML;
						saveFileDialog.Filter = "HTML File|*.html";
						saveFileDialog.FileName = Path.ChangeExtension(saveFileDialog.FileName, "html");
					}
					else if (flag == this.rdpType_3.Checked)
					{
						this.enFileTytpe_0 = DumpExporter.enFileTytpe.const_2;
						saveFileDialog.Filter = "XML File|*.xml";
						saveFileDialog.FileName = Path.ChangeExtension(saveFileDialog.FileName, "xml");
					}
					if (saveFileDialog.ShowDialog() == DialogResult.OK)
					{
						this.string_0 = saveFileDialog.FileName;
						saveFileDialog.InitialDirectory = this.string_4;
						this.bwSave.RunWorkerAsync();
						this.OK_Button.Text = "&Cancel..";
						this.prbStatus.Visible = true;
						this.Cancel_Button.Enabled = false;
						this.grbDelimiter.Enabled = false;
						this.grbColumns.Enabled = false;
					}
					return;
				}
			}
			this.OK_Button.Enabled = false;
			this.bwSave.CancelAsync();
		}
	}

	// Token: 0x060007F7 RID: 2039 RVA: 0x000355EC File Offset: 0x000337EC
	private void method_7(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.Cancel;
		base.Close();
	}

	// Token: 0x060007F8 RID: 2040 RVA: 0x000355FC File Offset: 0x000337FC
	private void method_8(object sender, EventArgs e)
	{
		this.txtDeli.Enabled = this.rdbOpt2.Checked;
	}

	// Token: 0x060007F9 RID: 2041 RVA: 0x00035614 File Offset: 0x00033814
	private void DumpExporter_FormClosing(object sender, FormClosingEventArgs e)
	{
		try
		{
			Class50.smethod_4(base.Name, "LastPath", this.string_4, null);
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	// Token: 0x060007FA RID: 2042 RVA: 0x00035670 File Offset: 0x00033870
	private void DumpExporter_Load(object sender, EventArgs e)
	{
		checked
		{
			try
			{
				this.OK_Button.Text = "&Start..";
				int num = this.dataGridView_0.ColumnCount - 1;
				for (int i = 1; i <= num; i++)
				{
					this.lsColumns.Items.Add(this.dataGridView_0.Columns[i].HeaderText);
					this.lsColumns.SetItemChecked(i - 1, true);
				}
				global::Globals.AddMouseMoveForm(this);
				Class50.smethod_2(this, null);
				this.string_4 = Class50.smethod_5(base.Name, "LastPath", "", null);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
	}

	// Token: 0x060007FB RID: 2043 RVA: 0x0003573C File Offset: 0x0003393C
	private void method_9(object sender, EventArgs e)
	{
		checked
		{
			int num = this.lsColumns.Items.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				bool flag;
				if ((flag = true) == (sender == this.mmnCheck))
				{
					this.lsColumns.SetItemChecked(i, true);
				}
				else if (flag == (sender == this.mmnUnCheck))
				{
					this.lsColumns.SetItemChecked(i, false);
				}
			}
		}
	}

	// Token: 0x060007FC RID: 2044 RVA: 0x000357A4 File Offset: 0x000339A4
	private void method_10(object sender, EventArgs e)
	{
		this.txtReplaceLine.Enabled = this.chkReplaceLines.Checked;
	}

	// Token: 0x060007FD RID: 2045 RVA: 0x000357BC File Offset: 0x000339BC
	private void method_11(object sender, CancelEventArgs e)
	{
		e.Cancel = this.bool_0;
		if (this.lsColumns.SelectedIndex < 0)
		{
			this.mnuMoveUP.Enabled = false;
			this.mnuMoveDown.Enabled = false;
		}
		else
		{
			this.mnuMoveUP.Enabled = this.lsColumns.SelectedIndex > 0;
			this.mnuMoveDown.Enabled = this.lsColumns.SelectedIndex < checked(this.lsColumns.Items.Count - 1);
		}
	}

	// Token: 0x060007FE RID: 2046 RVA: 0x00035844 File Offset: 0x00033A44
	private void method_12(object sender, EventArgs e)
	{
		bool itemChecked = this.lsColumns.GetItemChecked(this.lsColumns.SelectedIndex);
		checked
		{
			if (sender == this.mnuMoveUP)
			{
				if (this.lsColumns.SelectedIndex > 0)
				{
					int num = this.lsColumns.SelectedIndex - 1;
					this.lsColumns.Items.Insert(num, RuntimeHelpers.GetObjectValue(this.lsColumns.SelectedItem));
					this.lsColumns.Items.RemoveAt(this.lsColumns.SelectedIndex);
					this.lsColumns.SelectedIndex = num;
				}
			}
			else if (this.lsColumns.SelectedIndex < this.lsColumns.Items.Count - 1)
			{
				int num2 = this.lsColumns.SelectedIndex + 2;
				this.lsColumns.Items.Insert(num2, RuntimeHelpers.GetObjectValue(this.lsColumns.SelectedItem));
				this.lsColumns.Items.RemoveAt(this.lsColumns.SelectedIndex);
				this.lsColumns.SelectedIndex = num2 - 1;
			}
			this.lsColumns.SetItemChecked(this.lsColumns.SelectedIndex, itemChecked);
		}
	}

	// Token: 0x060007FF RID: 2047 RVA: 0x00035970 File Offset: 0x00033B70
	private void method_13(object sender, EventArgs e)
	{
		global::Globals.LockWindowUpdate(base.Handle);
		this.chkReplaceLines.Enabled = this.rdpType_1.Checked;
		this.txtReplaceLine.Enabled = this.rdpType_1.Checked;
		this.grbDelimiter.Visible = this.rdpType_1.Checked;
		global::Globals.LockWindowUpdate(IntPtr.Zero);
	}

	// Token: 0x06000800 RID: 2048 RVA: 0x000359D8 File Offset: 0x00033BD8
	private void method_14(object sender, ItemCheckEventArgs e)
	{
	}

	// Token: 0x04000419 RID: 1049
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("bwSave")]
	private BackgroundWorker backgroundWorker_0;

	// Token: 0x04000429 RID: 1065
	private DataGridView dataGridView_0;

	// Token: 0x0400042A RID: 1066
	private string string_0;

	// Token: 0x0400042B RID: 1067
	private string string_1;

	// Token: 0x0400042C RID: 1068
	private static string string_2;

	// Token: 0x0400042D RID: 1069
	private static string string_3;

	// Token: 0x0400042E RID: 1070
	private static int int_0;

	// Token: 0x0400042F RID: 1071
	private string string_4;

	// Token: 0x04000430 RID: 1072
	private bool bool_0;

	// Token: 0x04000431 RID: 1073
	private Dictionary<string, int> dictionary_0;

	// Token: 0x04000432 RID: 1074
	private bool bool_1;

	// Token: 0x04000433 RID: 1075
	private string string_5;

	// Token: 0x04000434 RID: 1076
	private string string_6;

	// Token: 0x04000435 RID: 1077
	private DumpExporter.enFileTytpe enFileTytpe_0;

	// Token: 0x04000436 RID: 1078
	private Dumper dumper_0;

	// Token: 0x0200008D RID: 141
	public enum enFileTytpe
	{
		// Token: 0x04000438 RID: 1080
		const_0,
		// Token: 0x04000439 RID: 1081
		HTML,
		// Token: 0x0400043A RID: 1082
		const_2
	}

	// Token: 0x0200008E RID: 142
	// (Invoke) Token: 0x06000804 RID: 2052
	private delegate DataGridViewRow Delegate35(int Index);

	// Token: 0x0200008F RID: 143
	// (Invoke) Token: 0x06000808 RID: 2056
	private delegate int Delegate36();
}
