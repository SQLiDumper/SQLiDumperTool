using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ns0;

// Token: 0x020000B4 RID: 180
[DesignerGenerated]
public partial class Exporter : Form
{
	// Token: 0x06000A4F RID: 2639 RVA: 0x0003D2F4 File Offset: 0x0003B4F4
	public Exporter(DataGridView grid)
	{
		base.FormClosing += this.Exporter_FormClosing;
		base.Load += this.Exporter_Load;
		this.InitializeComponent();
		this.dataGridView_0 = grid;
		global::Globals.AddMouseMoveForm(this);
		global::Globals.translate_0.Add(this, this.icontainer_0);
	}

	// Token: 0x17000322 RID: 802
	// (get) Token: 0x06000A52 RID: 2642 RVA: 0x0003DDA4 File Offset: 0x0003BFA4
	// (set) Token: 0x06000A53 RID: 2643 RVA: 0x0003DDAC File Offset: 0x0003BFAC
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
			EventHandler eventHandler = new EventHandler(this.method_2);
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

	// Token: 0x17000323 RID: 803
	// (get) Token: 0x06000A54 RID: 2644 RVA: 0x0003DDF0 File Offset: 0x0003BFF0
	// (set) Token: 0x06000A55 RID: 2645 RVA: 0x0003DDF8 File Offset: 0x0003BFF8
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
			EventHandler eventHandler = new EventHandler(this.method_3);
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

	// Token: 0x17000324 RID: 804
	// (get) Token: 0x06000A56 RID: 2646 RVA: 0x0003DE3C File Offset: 0x0003C03C
	// (set) Token: 0x06000A57 RID: 2647 RVA: 0x0003DE44 File Offset: 0x0003C044
	internal virtual GroupBox grbDelimiter
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x17000325 RID: 805
	// (get) Token: 0x06000A58 RID: 2648 RVA: 0x0003DE50 File Offset: 0x0003C050
	// (set) Token: 0x06000A59 RID: 2649 RVA: 0x0003DE58 File Offset: 0x0003C058
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
			EventHandler eventHandler = new EventHandler(this.method_4);
			EventHandler eventHandler2 = new EventHandler(this.method_4);
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

	// Token: 0x17000326 RID: 806
	// (get) Token: 0x06000A5A RID: 2650 RVA: 0x0003DEB8 File Offset: 0x0003C0B8
	// (set) Token: 0x06000A5B RID: 2651 RVA: 0x0003DEC0 File Offset: 0x0003C0C0
	internal virtual RadioButton rdbOpt2
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x17000327 RID: 807
	// (get) Token: 0x06000A5C RID: 2652 RVA: 0x0003DECC File Offset: 0x0003C0CC
	// (set) Token: 0x06000A5D RID: 2653 RVA: 0x0003DED4 File Offset: 0x0003C0D4
	internal virtual TextBox txtDeli
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x17000328 RID: 808
	// (get) Token: 0x06000A5E RID: 2654 RVA: 0x0003DEE0 File Offset: 0x0003C0E0
	// (set) Token: 0x06000A5F RID: 2655 RVA: 0x0003DEE8 File Offset: 0x0003C0E8
	internal virtual BackgroundWorker bwSave
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x17000329 RID: 809
	// (get) Token: 0x06000A60 RID: 2656 RVA: 0x0003DEF4 File Offset: 0x0003C0F4
	// (set) Token: 0x06000A61 RID: 2657 RVA: 0x0003DEFC File Offset: 0x0003C0FC
	internal virtual GroupBox grbColumns
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x1700032A RID: 810
	// (get) Token: 0x06000A62 RID: 2658 RVA: 0x0003DF08 File Offset: 0x0003C108
	// (set) Token: 0x06000A63 RID: 2659 RVA: 0x0003DF10 File Offset: 0x0003C110
	internal virtual CheckedListBox lsColumns
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x1700032B RID: 811
	// (get) Token: 0x06000A64 RID: 2660 RVA: 0x0003DF1C File Offset: 0x0003C11C
	// (set) Token: 0x06000A65 RID: 2661 RVA: 0x0003DF24 File Offset: 0x0003C124
	internal virtual GroupBox grbType
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x1700032C RID: 812
	// (get) Token: 0x06000A66 RID: 2662 RVA: 0x0003DF30 File Offset: 0x0003C130
	// (set) Token: 0x06000A67 RID: 2663 RVA: 0x0003DF38 File Offset: 0x0003C138
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
			EventHandler eventHandler = new EventHandler(this.method_5);
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

	// Token: 0x1700032D RID: 813
	// (get) Token: 0x06000A68 RID: 2664 RVA: 0x0003DF7C File Offset: 0x0003C17C
	// (set) Token: 0x06000A69 RID: 2665 RVA: 0x0003DF84 File Offset: 0x0003C184
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
			EventHandler eventHandler = new EventHandler(this.method_5);
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

	// Token: 0x1700032E RID: 814
	// (get) Token: 0x06000A6A RID: 2666 RVA: 0x0003DFC8 File Offset: 0x0003C1C8
	// (set) Token: 0x06000A6B RID: 2667 RVA: 0x0003DFD0 File Offset: 0x0003C1D0
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
			EventHandler eventHandler = new EventHandler(this.method_5);
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

	// Token: 0x1700032F RID: 815
	// (get) Token: 0x06000A6C RID: 2668 RVA: 0x0003E014 File Offset: 0x0003C214
	// (set) Token: 0x06000A6D RID: 2669 RVA: 0x0003E01C File Offset: 0x0003C21C
	internal virtual Panel Panel1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x06000A6E RID: 2670 RVA: 0x0003E028 File Offset: 0x0003C228
	private string method_0(string string_3)
	{
		return SecurityElement.Escape(string_3);
	}

	// Token: 0x06000A6F RID: 2671 RVA: 0x0003E040 File Offset: 0x0003C240
	private void method_1(string string_3)
	{
		StreamWriter streamWriter = null;
		checked
		{
			try
			{
				this.bool_0 = true;
				streamWriter = new StreamWriter(string_3);
				int num = this.lsColumns.Items.Count - 1;
				bool flag;
				for (int i = 0; i <= num; i++)
				{
					if (this.lsColumns.GetItemChecked(i))
					{
						switch (this.enFileTytpe_0)
						{
						case Exporter.enFileTytpe.const_0:
							if (flag)
							{
								streamWriter.Write(Operators.ConcatenateObject(this.string_2, this.lsColumns.Items[i]));
							}
							else
							{
								streamWriter.Write(this.method_0(global::Globals.APP_VERSION));
								streamWriter.WriteLine();
								streamWriter.Write(DateAndTime.Now.ToString());
								streamWriter.WriteLine();
								streamWriter.WriteLine();
								streamWriter.Write(RuntimeHelpers.GetObjectValue(this.lsColumns.Items[i]));
							}
							break;
						case Exporter.enFileTytpe.HTML:
							if (!flag)
							{
								streamWriter.WriteLine("<html>");
								streamWriter.WriteLine("<title>" + this.method_0(global::Globals.APP_VERSION) + "</title>");
								streamWriter.WriteLine("<body>");
								streamWriter.WriteLine("<table border>");
								streamWriter.WriteLine("<tr>");
							}
							streamWriter.WriteLine(Operators.ConcatenateObject(Operators.ConcatenateObject("<td>", this.lsColumns.Items[i]), "</td>"));
							break;
						case Exporter.enFileTytpe.const_2:
							if (!flag)
							{
								streamWriter.WriteLine("<DocumentElement>");
								streamWriter.WriteLine("<AppVersion>" + this.method_0(global::Globals.APP_VERSION) + "</AppVersion>");
							}
							break;
						}
						flag = true;
					}
				}
				switch (this.enFileTytpe_0)
				{
				case Exporter.enFileTytpe.const_0:
					streamWriter.WriteLine();
					break;
				case Exporter.enFileTytpe.HTML:
					streamWriter.WriteLine("</tr>");
					break;
				}
				flag = false;
				int num2 = this.dataGridView_0.Rows.Count - 1;
				for (int j = 0; j <= num2; j++)
				{
					int num3 = this.lsColumns.Items.Count - 1;
					for (int k = 0; k <= num3; k++)
					{
						if (this.lsColumns.GetItemChecked(k))
						{
							string text = Conversions.ToString(this.dataGridView_0.Rows[j].Cells[k + 1].Value);
							switch (this.enFileTytpe_0)
							{
							case Exporter.enFileTytpe.const_0:
								if (flag)
								{
									streamWriter.Write(this.string_2 + text);
								}
								else
								{
									streamWriter.Write(text);
								}
								break;
							case Exporter.enFileTytpe.HTML:
								if (!flag)
								{
									streamWriter.WriteLine("<tr>");
								}
								streamWriter.WriteLine("<td>" + SecurityElement.Escape(text) + "</td>");
								break;
							case Exporter.enFileTytpe.const_2:
								if (!flag)
								{
									streamWriter.WriteLine("<item>");
								}
								streamWriter.WriteLine(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("<", this.lsColumns.Items[k]), ">"), this.method_0(text)), "</"), this.lsColumns.Items[k]), ">"));
								break;
							}
						}
						flag = true;
					}
					switch (this.enFileTytpe_0)
					{
					case Exporter.enFileTytpe.const_0:
						streamWriter.WriteLine();
						break;
					case Exporter.enFileTytpe.HTML:
						streamWriter.WriteLine("</tr>");
						break;
					case Exporter.enFileTytpe.const_2:
						streamWriter.WriteLine("</item>");
						break;
					}
					flag = false;
				}
				switch (this.enFileTytpe_0)
				{
				case Exporter.enFileTytpe.HTML:
					streamWriter.WriteLine("</body>");
					streamWriter.WriteLine("</html>");
					break;
				case Exporter.enFileTytpe.const_2:
					streamWriter.WriteLine("</DocumentElement>");
					break;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			finally
			{
				if (streamWriter != null)
				{
					streamWriter.Close();
				}
			}
		}
	}

	// Token: 0x06000A70 RID: 2672 RVA: 0x0003E48C File Offset: 0x0003C68C
	private void method_2(object sender, EventArgs e)
	{
		checked
		{
			try
			{
				int num = this.lsColumns.Items.Count - 1;
				bool flag;
				for (int i = 0; i <= num; i++)
				{
					if (this.lsColumns.GetItemChecked(i))
					{
						flag = true;
					}
				}
				if (!unchecked(-(flag > false)))
				{
					Interaction.Beep();
					Interaction.MsgBox("Selected the column(s).", MsgBoxStyle.OkOnly, null);
				}
				else
				{
					if (this.rdbOpt1.Checked)
					{
						this.string_2 = "\t";
					}
					else
					{
						this.string_2 = this.txtDeli.Text;
					}
					using (SaveFileDialog saveFileDialog = new SaveFileDialog())
					{
						saveFileDialog.Title = "Save as..";
						saveFileDialog.FileName = this.string_1;
						saveFileDialog.InitialDirectory = this.string_0;
						bool flag2;
						if ((flag2 = true) == this.rdpType_1.Checked)
						{
							this.enFileTytpe_0 = Exporter.enFileTytpe.const_0;
							saveFileDialog.Filter = "Text File|*.txt";
							saveFileDialog.FileName = Path.ChangeExtension(saveFileDialog.FileName, "txt");
						}
						else if (flag2 == this.rdpType_2.Checked)
						{
							this.enFileTytpe_0 = Exporter.enFileTytpe.HTML;
							saveFileDialog.Filter = "HTML File|*.html";
							saveFileDialog.FileName = Path.ChangeExtension(saveFileDialog.FileName, "html");
						}
						else if (flag2 == this.rdpType_3.Checked)
						{
							this.enFileTytpe_0 = Exporter.enFileTytpe.const_2;
							saveFileDialog.Filter = "XML File|*.xml";
							saveFileDialog.FileName = Path.ChangeExtension(saveFileDialog.FileName, "xml");
						}
						if (saveFileDialog.ShowDialog() == DialogResult.OK)
						{
							this.Cursor = Cursors.WaitCursor;
							Application.DoEvents();
							this.string_0 = saveFileDialog.FileName.Substring(0, saveFileDialog.FileName.LastIndexOf("\\"));
							this.string_1 = saveFileDialog.FileName.Substring(saveFileDialog.FileName.LastIndexOf("\\") + 1);
							this.method_1(saveFileDialog.FileName);
							this.Cursor = Cursors.Default;
							MessageBox.Show("Data export completed successfully.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						}
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}
	}

	// Token: 0x06000A71 RID: 2673 RVA: 0x0003E6E4 File Offset: 0x0003C8E4
	private void method_3(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.Cancel;
		base.Close();
	}

	// Token: 0x06000A72 RID: 2674 RVA: 0x0003E6F4 File Offset: 0x0003C8F4
	private void method_4(object sender, EventArgs e)
	{
		this.txtDeli.Enabled = this.rdbOpt2.Checked;
	}

	// Token: 0x06000A73 RID: 2675 RVA: 0x0003E70C File Offset: 0x0003C90C
	private void Exporter_FormClosing(object sender, FormClosingEventArgs e)
	{
		checked
		{
			try
			{
				Class50.smethod_4(this.dataGridView_0.Name, "LastPath", this.string_0, null);
				Class50.smethod_4(this.dataGridView_0.Name, "LastFileName", this.string_1, null);
				Class50.smethod_3(this, null);
				int num = this.lsColumns.Items.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					string text = Conversions.ToString(this.lsColumns.Items[i]);
					Class50.smethod_4(this.lsColumns.Name, text, this.lsColumns.GetItemChecked(i).ToString(), null);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
	}

	// Token: 0x06000A74 RID: 2676 RVA: 0x0003E7EC File Offset: 0x0003C9EC
	private void Exporter_Load(object sender, EventArgs e)
	{
		checked
		{
			try
			{
				Class50.smethod_2(this, null);
				this.string_0 = Class50.smethod_5(this.dataGridView_0.Name, "LastPath", global::Globals.APP_PATH, null);
				this.string_1 = Class50.smethod_5(this.dataGridView_0.Name, "LastFileName", "Checkeds", null);
				this.lsColumns.Items.Clear();
				int num = this.dataGridView_0.Columns.Count - 1;
				for (int i = 1; i <= num; i++)
				{
					string headerText = this.dataGridView_0.Columns[i].HeaderText;
					this.lsColumns.Items.Add(headerText);
					this.lsColumns.SetItemChecked(i - 1, Conversions.ToBoolean(Class50.smethod_5(this.lsColumns.Name, headerText, (i < 3).ToString(), null)));
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
	}

	// Token: 0x06000A75 RID: 2677 RVA: 0x0003E904 File Offset: 0x0003CB04
	private void method_5(object sender, EventArgs e)
	{
		global::Globals.LockWindowUpdate(base.Handle);
		this.grbDelimiter.Visible = this.rdpType_1.Checked;
		global::Globals.LockWindowUpdate(IntPtr.Zero);
	}

	// Token: 0x04000519 RID: 1305
	[AccessedThroughProperty("bwSave")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private BackgroundWorker backgroundWorker_0;

	// Token: 0x04000521 RID: 1313
	private string string_0;

	// Token: 0x04000522 RID: 1314
	private string string_1;

	// Token: 0x04000523 RID: 1315
	private bool bool_0;

	// Token: 0x04000524 RID: 1316
	private Exporter.enFileTytpe enFileTytpe_0;

	// Token: 0x04000525 RID: 1317
	private string string_2;

	// Token: 0x04000526 RID: 1318
	private DataGridView dataGridView_0;

	// Token: 0x020000B5 RID: 181
	public enum enFileTytpe
	{
		// Token: 0x04000528 RID: 1320
		const_0,
		// Token: 0x04000529 RID: 1321
		HTML,
		// Token: 0x0400052A RID: 1322
		const_2
	}
}
