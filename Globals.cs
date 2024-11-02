using System;
using System.Collections;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ns0;
using ScrollingBoxCtrl;
using Taskbar;

// Token: 0x020000C7 RID: 199
[StandardModule]
internal sealed class Globals
{
	// Token: 0x06000B84 RID: 2948
	[DllImport("user32.dll")]
	public static extern int SendMessage(IntPtr hWnd, int wMsg, bool wParam, int lParam);

	// Token: 0x06000B85 RID: 2949
	[DllImport("user32.dll")]
	public static extern bool LockWindowUpdate(IntPtr hWndLock);

	// Token: 0x06000B86 RID: 2950
	[DllImport("user32.dll")]
	private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

	// Token: 0x06000B87 RID: 2951
	[DllImport("user32.dll")]
	private static extern uint GetWindowLong(IntPtr hWnd, int nIndex);

	// Token: 0x06000B88 RID: 2952
	[DllImport("user32.dll", SetLastError = true)]
	private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int int_0, int int_1, int cx, int cy, uint uFlags);

	// Token: 0x06000B89 RID: 2953
	[DllImport("user32.dll")]
	public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

	// Token: 0x06000B8A RID: 2954
	[DllImport("user32.dll")]
	private static extern bool ReleaseCapture();

	// Token: 0x06000B8B RID: 2955
	[DllImport("kernel32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
	private static extern int SetProcessWorkingSetSize(IntPtr hProcess, int dwMinimumWorkingSetSize, int dwMaximumWorkingSetSize);

	// Token: 0x06000B8C RID: 2956
	[DllImport("psapi.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
	private static extern int EmptyWorkingSet(IntPtr hwProc);

	// Token: 0x06000B8D RID: 2957
	[DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "SendMessage")]
	private static extern IntPtr SendMessage_1(IntPtr hWnd, int msg, int wParam, ref global::Globals.LVITEM lvi);

	// Token: 0x06000B8E RID: 2958 RVA: 0x00046538 File Offset: 0x00044738
	public static void SelectAllItemsLVW(ListViewExt lvw)
	{
		global::Globals.SetItemState(lvw, -1, 2, 2);
	}

	// Token: 0x06000B8F RID: 2959 RVA: 0x00046544 File Offset: 0x00044744
	private static void SetItemState(ListViewExt list, int itemIndex, int mask, int value)
	{
		global::Globals.LVITEM lvitem = default(global::Globals.LVITEM);
		lvitem.stateMask = mask;
		lvitem.state = value;
		global::Globals.SendMessage_1(list.Handle, 4139, itemIndex, ref lvitem);
	}

	// Token: 0x06000B90 RID: 2960 RVA: 0x00046580 File Offset: 0x00044780
	public static bool LockWindowUpdateForced(bool bState)
	{
		return global::Globals.SendMessage(global::Globals.GMain.Handle, 11, bState, 0) > 0;
	}

	// Token: 0x06000B91 RID: 2961 RVA: 0x00046598 File Offset: 0x00044798
	public static void ReleaseMemory()
	{
		try
		{
			GC.Collect();
			GC.WaitForPendingFinalizers();
			if (Environment.OSVersion.Platform == PlatformID.Win32NT)
			{
				global::Globals.EmptyWorkingSet(Process.GetCurrentProcess().Handle);
			}
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x06000B92 RID: 2962 RVA: 0x000465F0 File Offset: 0x000447F0
	public static void ListBoxSelectAll(ListBox l, bool b)
	{
		global::Globals.SendMessage(l.Handle, 389, b, -1);
	}

	// Token: 0x06000B93 RID: 2963 RVA: 0x00046608 File Offset: 0x00044808
	public static void AddMouseMove(object sender, MouseEventArgs e)
	{
		checked
		{
			if (e.Button == MouseButtons.Left)
			{
				Form form = null;
				if (sender is ToolStripLabel)
				{
					sender = ((ToolStripLabel)sender).GetCurrentParent().FindForm();
				}
				else if (sender is ToolStripStatusLabel)
				{
					sender = ((ToolStripStatusLabel)sender).GetCurrentParent().FindForm();
				}
				if ((sender is Form) & (global::Globals.GMain != null))
				{
					if (sender == global::Globals.GMain.DumperForm)
					{
						form = global::Globals.GMain;
					}
					else if (sender == global::Globals.GMain.LoginFinderForm)
					{
						form = global::Globals.GMain;
					}
					else if (sender == global::Globals.GMain.DumperForm)
					{
						form = global::Globals.GMain;
					}
					else if (sender == global::Globals.GMain.AnalizerForm)
					{
						form = global::Globals.GMain;
					}
					else
					{
						form = (Form)sender;
					}
				}
				else if (sender is Control)
				{
					Form form2 = ((Control)sender).FindForm();
					int num = Application.OpenForms.Count - 1;
					for (int i = 0; i <= num; i++)
					{
						if (form2 == null)
						{
							break;
						}
						form = form2;
						if (form is MainForm)
						{
							break;
						}
						form2 = form2.ParentForm;
					}
				}
				else
				{
					form = global::Globals.GMain;
				}
				if (form != null)
				{
					global::Globals.ReleaseCapture();
					global::Globals.SendMessage(form.Handle, 161, 2, 0);
				}
			}
		}
	}

	// Token: 0x06000B94 RID: 2964 RVA: 0x0004675C File Offset: 0x0004495C
	public static void AddMouseMoveForm(Form f)
	{
		f.MouseDown += global::Globals.AddMouseMove;
		try
		{
			foreach (object obj in Class50.smethod_6(f).Values)
			{
				object objectValue = RuntimeHelpers.GetObjectValue(obj);
				bool flag;
				if ((flag = true) == objectValue is Panel || flag == objectValue is Label || flag == objectValue is PictureBox || flag == objectValue is ProgressBar || flag == objectValue is GroupBox || flag == objectValue is ScrollingBox || flag == objectValue is ToolStrip)
				{
					if (objectValue is ToolStrip)
					{
						try
						{
							foreach (object obj2 in ((ToolStrip)objectValue).Items)
							{
								ToolStripItem toolStripItem = (ToolStripItem)obj2;
								bool flag2;
								if ((flag2 = true) == toolStripItem is ToolStripStatusLabel || flag2 == toolStripItem is ToolStripLabel || flag2 == toolStripItem is ToolStripSeparator || flag2 == toolStripItem is ToolStripProgressBar)
								{
									toolStripItem.MouseDown += global::Globals.AddMouseMove;
								}
							}
						}
						finally
						{
							IEnumerator enumerator2;
							if (enumerator2 is IDisposable)
							{
								(enumerator2 as IDisposable).Dispose();
							}
						}
					}
					if (objectValue is Control)
					{
						((Control)objectValue).MouseDown += global::Globals.AddMouseMove;
					}
				}
				if (objectValue is ToolStrip)
				{
					ToolStrip toolStrip = (ToolStrip)objectValue;
					toolStrip.ImageScalingSize = new Size(16, 16);
					toolStrip.BackgroundImageLayout = ImageLayout.None;
					toolStrip.RenderMode = ToolStripRenderMode.System;
					toolStrip.AutoSize = false;
					toolStrip.Height = 23;
					try
					{
						foreach (object obj3 in ((ToolStrip)objectValue).Items)
						{
							ToolStripItem toolStripItem2 = (ToolStripItem)obj3;
							toolStripItem2.AutoSize = true;
							toolStripItem2.BackgroundImageLayout = ImageLayout.None;
						}
					}
					finally
					{
						IEnumerator enumerator3;
						if (enumerator3 is IDisposable)
						{
							(enumerator3 as IDisposable).Dispose();
						}
					}
					toolStrip.RenderMode = ToolStripRenderMode.ManagerRenderMode;
					toolStrip = null;
				}
				else if (objectValue is MenuStrip)
				{
					MenuStrip menuStrip = (MenuStrip)objectValue;
					menuStrip.ImageScalingSize = new Size(16, 16);
					menuStrip.RenderMode = ToolStripRenderMode.ManagerRenderMode;
				}
				else if (objectValue is ContextMenuStrip)
				{
					ContextMenuStrip contextMenuStrip = (ContextMenuStrip)objectValue;
					contextMenuStrip.ImageScalingSize = new Size(16, 16);
					contextMenuStrip.RenderMode = ToolStripRenderMode.ManagerRenderMode;
				}
				else if (objectValue is StatusStrip)
				{
					StatusStrip statusStrip = (StatusStrip)objectValue;
					statusStrip.ImageScalingSize = new Size(16, 16);
					statusStrip.RenderMode = ToolStripRenderMode.ManagerRenderMode;
					statusStrip.AutoSize = true;
				}
				else if (!(objectValue is Button) && objectValue is DataGridView)
				{
					((DataGridView)objectValue).BorderStyle = BorderStyle.None;
				}
			}
		}
		finally
		{
			IEnumerator enumerator;
			if (enumerator is IDisposable)
			{
				(enumerator as IDisposable).Dispose();
			}
		}
	}

	// Token: 0x06000B95 RID: 2965 RVA: 0x00046A90 File Offset: 0x00044C90
	public static object GetObjectValue(object c)
	{
		object obj;
		bool flag;
		if (!global::Globals.GMain.bool_2)
		{
			obj = null;
		}
		else if (global::Globals.GMain.InvokeRequired)
		{
			obj = global::Globals.GMain.Invoke(new global::Globals.DGetObjectValue(global::Globals.GetObjectValue), new object[] { c });
		}
		else if ((flag = true) == c is ComboBox)
		{
			obj = ((ComboBox)c).SelectedIndex;
		}
		else if (flag == c is ToolStripComboBox)
		{
			obj = ((ToolStripComboBox)c).Text;
		}
		else if (flag == c is TextBox)
		{
			obj = ((TextBox)c).Text;
		}
		else if (flag == c is Label)
		{
			obj = ((Label)c).Text;
		}
		else if (flag == c is CheckBox)
		{
			obj = ((CheckBox)c).Checked;
		}
		else if (flag == c is RadioButton)
		{
			obj = ((RadioButton)c).Checked;
		}
		else if (flag == c is ToolStripButton)
		{
			obj = ((ToolStripButton)c).Checked;
		}
		else if (flag == c is ToolStripLabel)
		{
			obj = ((ToolStripLabel)c).Text;
		}
		else if (flag == c is NumericUpDown)
		{
			obj = ((NumericUpDown)c).Value;
		}
		else if (flag == c is TrackBar)
		{
			obj = ((TrackBar)c).Value;
		}
		else if (flag == c is TreeViewExt)
		{
			obj = ((TreeViewExt)c).Handle;
		}
		else if (flag == c is ListBox)
		{
			obj = ((ListBox)c).Items;
		}
		else if (flag == c is DataGridView)
		{
			obj = ((DataGridView)c).Rows;
		}
		else if (flag == c is ListViewExt)
		{
			ListViewItem[] array = new ListViewItem[checked(((ListViewExt)c).Items.Count - 1 + 1)];
			((ListViewExt)c).Items.CopyTo(array, 0);
			obj = array;
		}
		else
		{
			if (flag != c is ToolStripSpringTextBox)
			{
				throw new Exception("Bad Changed GetObjectValue");
			}
			obj = ((ToolStripSpringTextBox)c).Text;
		}
		return obj;
	}

	// Token: 0x06000B96 RID: 2966 RVA: 0x00046D00 File Offset: 0x00044F00
	public static void SetObjectValue(object c, object v)
	{
		bool flag;
		if (global::Globals.GMain.InvokeRequired)
		{
			global::Globals.GMain.Invoke(new global::Globals.DSetObjectValue(global::Globals.SetObjectValue), new object[] { c, v });
		}
		else if ((flag = true) == c is ComboBox)
		{
			((ComboBox)c).SelectedIndex = Conversions.ToInteger(v);
		}
		else if (flag == c is ToolStripComboBox)
		{
			((ToolStripComboBox)c).SelectedItem = RuntimeHelpers.GetObjectValue(v);
		}
		else if (flag == c is TextBox)
		{
			((TextBox)c).Text = Conversions.ToString(v);
		}
		else if (flag == c is Label)
		{
			((Label)c).Text = Conversions.ToString(v);
		}
		else if (flag == c is CheckBox)
		{
			((CheckBox)c).Checked = Conversions.ToBoolean(v);
		}
		else if (flag == c is RadioButton)
		{
			((RadioButton)c).Checked = Conversions.ToBoolean(v);
		}
		else if (flag == c is ToolStripButton)
		{
			((ToolStripButton)c).Checked = Conversions.ToBoolean(v);
		}
		else if (flag == c is ToolStripLabel)
		{
			if (v is string)
			{
				((ToolStripLabel)c).Text = Conversions.ToString(v);
			}
			else
			{
				((ToolStripLabel)c).Image = (Image)v;
			}
		}
		else if (flag == c is NumericUpDown)
		{
			((NumericUpDown)c).Value = Conversions.ToDecimal(v);
		}
		else if (flag == c is TrackBar)
		{
			((TrackBar)c).Value = Conversions.ToInteger(v);
		}
		else if (flag == c is WebBrowser)
		{
			((WebBrowser)c).DocumentText = Conversions.ToString(v);
		}
		else
		{
			if (flag != c is TabPage)
			{
				throw new Exception("Bad Changed SetObjectValue");
			}
			((TabPage)c).Text = Conversions.ToString(v);
		}
	}

	// Token: 0x06000B97 RID: 2967 RVA: 0x00046F18 File Offset: 0x00045118
	public static void SetFlatBorder(Control c)
	{
		int num;
		int num5;
		object obj;
		try
		{
			IL_0002:
			ProjectData.ClearProjectError();
			num = -2;
			IL_000A:
			int num2 = 2;
			long num3 = (long)((ulong)global::Globals.GetWindowLong(c.Handle, -20));
			IL_001B:
			num2 = 3;
			num3 = (num3 & -513L) | 131072L;
			IL_002D:
			num2 = 4;
			global::Globals.SetWindowLong(c.Handle, -20, checked((int)num3));
			IL_003F:
			num2 = 5;
			global::Globals.SetWindowPos(c.Handle, IntPtr.Zero, (int)IntPtr.Zero, (int)IntPtr.Zero, (int)IntPtr.Zero, (int)IntPtr.Zero, 55U);
			IL_007C:
			goto IL_00EB;
			IL_007E:
			int num4 = num5 + 1;
			num5 = 0;
			@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num4);
			IL_00A4:
			goto IL_00E0;
			IL_00A6:
			num5 = num2;
			@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], (num > -2) ? num : 1);
			IL_00BE:;
		}
		catch when (endfilter((obj is Exception) & (num != 0) & (num5 == 0)))
		{
			Exception ex = (Exception)obj2;
			goto IL_00A6;
		}
		IL_00E0:
		throw ProjectData.CreateProjectError(-2146828237);
		IL_00EB:
		if (num5 != 0)
		{
			ProjectData.ClearProjectError();
		}
	}

	// Token: 0x06000B98 RID: 2968 RVA: 0x00047028 File Offset: 0x00045228
	public static int FormatPercentage(int curValue, int totalValue)
	{
		return checked((int)Math.Round(Math.Round((double)(100 * curValue) / (double)totalValue)));
	}

	// Token: 0x06000B99 RID: 2969 RVA: 0x0004704C File Offset: 0x0004524C
	public static string FormatNumbers(int i, bool bIgnoreZero = true)
	{
		try
		{
			string text = Strings.FormatNumber(i, 0, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault);
			if (bIgnoreZero && text.Equals("0"))
			{
				text = "";
			}
			return text;
		}
		catch (Exception ex)
		{
		}
		return "";
	}

	// Token: 0x06000B9A RID: 2970 RVA: 0x000470AC File Offset: 0x000452AC
	public static string FormatStr(string value)
	{
		string text;
		if (string.IsNullOrEmpty(value))
		{
			text = "";
		}
		else
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (string text2 in value.Split(new char[] { ' ' }))
			{
				bool flag = false;
				if (text2.Length > 2)
				{
					char[] array2 = text2.ToCharArray();
					int num = 0;
					if (num < array2.Length)
					{
						char c = array2[num];
						flag = char.IsLetter(c) & char.IsLower(c);
					}
				}
				if (flag)
				{
					stringBuilder.Append(CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text2));
				}
				else
				{
					stringBuilder.Append(text2);
				}
				stringBuilder.Append(' ');
			}
			text = stringBuilder.ToString();
		}
		return text;
	}

	// Token: 0x06000B9B RID: 2971 RVA: 0x00047170 File Offset: 0x00045370
	public static bool ValideIP(string sIP)
	{
		try
		{
			sIP = sIP.Split(new char[] { ':' })[0].Trim();
			Match match = Regex.Match(sIP, "^(?:[0-9]{1,3}\\.){3}[0-9]{1,3}$", RegexOptions.IgnoreCase);
			return match.Success;
		}
		catch (Exception ex)
		{
		}
		return false;
	}

	// Token: 0x06000B9C RID: 2972 RVA: 0x000471D0 File Offset: 0x000453D0
	public static string FormatBytes(double bytes)
	{
		string text;
		if (bytes >= 1125899906842624.0)
		{
			text = Conversions.ToString(Math.Round(bytes / 1125899906842624.0, 2)) + " PiB";
		}
		else if (bytes >= 1099511627776.0)
		{
			text = Conversions.ToString(Math.Round(bytes / 1099511627776.0, 2)) + " TiB";
		}
		else if (bytes >= 1073741824.0)
		{
			text = Conversions.ToString(Math.Round(bytes / 1073741824.0, 2)) + " GiB";
		}
		else if (bytes >= 1048576.0)
		{
			text = Conversions.ToString(Math.Round(bytes / 1048576.0, 2)) + " MiB";
		}
		else if (bytes >= 1024.0)
		{
			text = Conversions.ToString(Math.Round(bytes / 1024.0, 0)) + " KiB";
		}
		else
		{
			text = Conversions.ToString(bytes) + " Bytes";
		}
		return text;
	}

	// Token: 0x06000B9D RID: 2973 RVA: 0x000472FC File Offset: 0x000454FC
	public static void ShellUrl(string url)
	{
		new global::Globals.ShellT(url);
	}

	// Token: 0x0400059A RID: 1434
	public static string JABBER_KEY = "c4rl0s@jabber.ru";

	// Token: 0x0400059B RID: 1435
	public static bool IS_DUMP_INSTANCE = false;

	// Token: 0x0400059C RID: 1436
	public static bool NETWORK_AVAILABLE = true;

	// Token: 0x0400059D RID: 1437
	public static string[] COMMAND_LINE_ARGS;

	// Token: 0x0400059E RID: 1438
	public static string CHANGE_LOG_10_1;

	// Token: 0x0400059F RID: 1439
	public static string CHANGE_LOG_10_0;

	// Token: 0x040005A0 RID: 1440
	public static string CHANGE_LOG_9_9;

	// Token: 0x040005A1 RID: 1441
	public static string CHANGE_LOG_9_8;

	// Token: 0x040005A2 RID: 1442
	public static string CHANGE_LOG_9_7;

	// Token: 0x040005A3 RID: 1443
	public static string CHANGE_LOG_9_6;

	// Token: 0x040005A4 RID: 1444
	public static string CHANGE_LOG_9_5;

	// Token: 0x040005A5 RID: 1445
	public static string CHANGE_LOG_9_4;

	// Token: 0x040005A6 RID: 1446
	public static string CHANGE_LOG_9_3;

	// Token: 0x040005A7 RID: 1447
	public static string CHANGE_LOG_9_2;

	// Token: 0x040005A8 RID: 1448
	public static string CHANGE_LOG_9_1;

	// Token: 0x040005A9 RID: 1449
	public static string CHANGE_LOG;

	// Token: 0x040005AA RID: 1450
	public static Manager G_Taskbar;

	// Token: 0x040005AB RID: 1451
	public static DataGP G_DataGP;

	// Token: 0x040005AC RID: 1452
	public static string G_KEY;

	// Token: 0x040005AD RID: 1453
	public static Class35 G_SOCKS;

	// Token: 0x040005AE RID: 1454
	public static Class40 GTrash;

	// Token: 0x040005AF RID: 1455
	public static Class37 GQueue;

	// Token: 0x040005B0 RID: 1456
	public static Class29 DG_SQLi;

	// Token: 0x040005B1 RID: 1457
	public static Class29 DG_SQLiNoInjectable;

	// Token: 0x040005B2 RID: 1458
	public static Class29 DG_FileInclusao;

	// Token: 0x040005B3 RID: 1459
	public static Class26 GStatistics;

	// Token: 0x040005B4 RID: 1460
	public static Updater GUpdater;

	// Token: 0x040005B5 RID: 1461
	public static Translate translate_0;

	// Token: 0x040005B6 RID: 1462
	public static long CountryBegin = 16776960L;

	// Token: 0x040005B7 RID: 1463
	public static string[] CountryName = new string[]
	{
		"Unknown", "Asia/Pacific Region", "Europe", "Andorra", "United Arab Emirates", "Afghanistan", "Antigua and Barbuda", "Anguilla", "Albania", "Armenia",
		"Netherlands Antilles", "Angola", "Antarctica", "Argentina", "American Samoa", "Austria", "Australia", "Aruba", "Azerbaijan", "Bosnia and Herzegovina",
		"Barbados", "Bangladesh", "Belgium", "Burkina Faso", "Bulgaria", "Bahrain", "Burundi", "Benin", "Bermuda", "Brunei Darussalam",
		"Bolivia", "Brazil", "Bahamas", "Bhutan", "Bouvet Island", "Botswana", "Belarus", "Belize", "Canada", "Cocos (Keeling) Islands",
		"Congo, The Democratic Republic of the", "Central African Republic", "Congo", "Switzerland", "Cote D'Ivoire", "Cook Islands", "Chile", "Cameroon", "China", "Colombia",
		"Costa Rica", "Cuba", "Cape Verde", "Christmas Island", "Cyprus", "Czech Republic", "Germany", "Djibouti", "Denmark", "Dominica",
		"Dominican Republic", "Algeria", "Ecuador", "Estonia", "Egypt", "Western Sahara", "Eritrea", "Spain", "Ethiopia", "Finland",
		"Fiji", "Falkland Islands (Malvinas)", "Micronesia, Federated States of", "Faroe Islands", "France", "France, Metropolitan", "Gabon", "United Kingdom", "Grenada", "Georgia",
		"French Guiana", "Ghana", "Gibraltar", "Greenland", "Gambia", "Guinea", "Guadeloupe", "Equatorial Guinea", "Greece", "South Georgia and the South Sandwich Islands",
		"Guatemala", "Guam", "Guinea-Bissau", "Guyana", "Hong Kong", "Heard Island and McDonald Islands", "Honduras", "Croatia", "Haiti", "Hungary",
		"Indonesia", "Ireland", "Israel", "India", "British Indian Ocean Territory", "Iraq", "Iran, Islamic Republic of", "Iceland", "Italy", "Jamaica",
		"Jordan", "Japan", "Kenya", "Kyrgyzstan", "Cambodia", "Kiribati", "Comoros", "Saint Kitts and Nevis", "Korea, Democratic People's Republic of", "Korea, Republic of",
		"Kuwait", "Cayman Islands", "Kazakstan", "Lao People's Democratic Republic", "Lebanon", "Saint Lucia", "Liechtenstein", "Sri Lanka", "Liberia", "Lesotho",
		"Lithuania", "Luxembourg", "Latvia", "Libyan Arab Jamahiriya", "Morocco", "Monaco", "Moldova, Republic of", "Madagascar", "Marshall Islands", "Macedonia, the Former Yugoslav Republic of",
		"Mali", "Myanmar", "Mongolia", "Macao", "Northern Mariana Islands", "Martinique", "Mauritania", "Montserrat", "Malta", "Mauritius",
		"Maldives", "Malawi", "Mexico", "Malaysia", "Mozambique", "Namibia", "New Caledonia", "Niger", "Norfolk Island", "Nigeria",
		"Nicaragua", "Netherlands", "Norway", "Nepal", "Nauru", "Niue", "New Zealand", "Oman", "Panama", "Peru",
		"French Polynesia", "Papua New Guinea", "Philippines", "Pakistan", "Poland", "Saint Pierre and Miquelon", "Pitcairn", "Puerto Rico", "Palestinian Territory, Occupied", "Portugal",
		"Palau", "Paraguay", "Qatar", "Reunion", "Romania", "Russian Federation", "Rwanda", "Saudi Arabia", "Solomon Islands", "Seychelles",
		"Sudan", "Sweden", "Singapore", "Saint Helena", "Slovenia", "Svalbard and Jan Mayen", "Slovakia", "Sierra Leone", "San Marino", "Senegal",
		"Somalia", "Suriname", "Sao Tome and Principe", "El Salvador", "Syrian Arab Republic", "Swaziland", "Turks and Caicos Islands", "Chad", "French Southern Territories", "Togo",
		"Thailand", "Tajikistan", "Tokelau", "Turkmenistan", "Tunisia", "Tonga", "Timor-Leste", "Turkey", "Trinidad and Tobago", "Tuvalu",
		"Taiwan, Province of China", "Tanzania, United Republic of", "Ukraine", "Uganda", "United States Minor Outlying Islands", "United States", "Uruguay", "Uzbekistan", "Holy See (Vatican City State)", "Saint Vincent and the Grenadines",
		"Venezuela", "Virgin Islands, British", "Virgin Islands, U.S.", "Vietnam", "Vanuatu", "Wallis and Futuna", "Samoa", "Yemen", "Mayotte", "Yugoslavia",
		"South Africa", "Zambia", "Montenegro", "Zimbabwe", "Anonymous Proxy", "Satellite Provider", "Other", "Aland Islands", "Guernsey", "Isle of Man",
		"Jersey", "Saint Barthelemy", "Saint Martin"
	};

	// Token: 0x040005B8 RID: 1464
	public static string[] CountryCode = new string[]
	{
		"--", "AP", "EU", "AD", "AE", "AF", "AG", "AI", "AL", "AM",
		"AN", "AO", "AQ", "AR", "AS", "AT", "AU", "AW", "AZ", "BA",
		"BB", "BD", "BE", "BF", "BG", "BH", "BI", "BJ", "BM", "BN",
		"BO", "BR", "BS", "BT", "BV", "BW", "BY", "BZ", "CA", "CC",
		"CD", "CF", "CG", "CH", "CI", "CK", "CL", "CM", "CN", "CO",
		"CR", "CU", "CV", "CX", "CY", "CZ", "DE", "DJ", "DK", "DM",
		"DO", "DZ", "EC", "EE", "EG", "EH", "ER", "ES", "ET", "FI",
		"FJ", "FK", "FM", "FO", "FR", "FX", "GA", "GB", "GD", "GE",
		"GF", "GH", "GI", "GL", "GM", "GN", "GP", "GQ", "GR", "GS",
		"GT", "GU", "GW", "GY", "HK", "HM", "HN", "HR", "HT", "HU",
		"ID", "IE", "IL", "IN", "IO", "IQ", "IR", "IS", "IT", "JM",
		"JO", "JP", "KE", "KG", "KH", "KI", "KM", "KN", "KP", "KR",
		"KW", "KY", "KZ", "LA", "LB", "LC", "LI", "LK", "LR", "LS",
		"LT", "LU", "LV", "LY", "MA", "MC", "MD", "MG", "MH", "MK",
		"ML", "MM", "MN", "MO", "MP", "MQ", "MR", "MS", "MT", "MU",
		"MV", "MW", "MX", "MY", "MZ", "NA", "NC", "NE", "NF", "NG",
		"NI", "NL", "NO", "NP", "NR", "NU", "NZ", "OM", "PA", "PE",
		"PF", "PG", "PH", "PK", "PL", "PM", "PN", "PR", "PS", "PT",
		"PW", "PY", "QA", "RE", "RO", "RU", "RW", "SA", "SB", "SC",
		"SD", "SE", "SG", "SH", "SI", "SJ", "SK", "SL", "SM", "SN",
		"SO", "SR", "ST", "SV", "SY", "SZ", "TC", "TD", "TF", "TG",
		"TH", "TJ", "TK", "TM", "TN", "TO", "TL", "TR", "TT", "TV",
		"TW", "TZ", "UA", "UG", "UM", "US", "UY", "UZ", "VA", "VC",
		"VE", "VG", "VI", "VN", "VU", "WF", "WS", "YE", "YT", "RS",
		"ZA", "ZM", "ME", "ZW", "A1", "A2", "O1", "AX", "GG", "IM",
		"JE", "BL", "MF"
	};

	// Token: 0x040005B9 RID: 1465
	public static readonly string APP_PATH = Application.StartupPath;

	// Token: 0x040005BA RID: 1466
	public static readonly string XML_PATH = global::Globals.APP_PATH + "\\Settings.xml";

	// Token: 0x040005BB RID: 1467
	public static readonly string TXT_PATH = global::Globals.APP_PATH + "\\TXT\\";

	// Token: 0x040005BC RID: 1468
	public static readonly string LNG_PATH = global::Globals.APP_PATH + "\\LNG\\";

	// Token: 0x040005BD RID: 1469
	public static readonly string SCHEMA_PATH = global::Globals.APP_PATH + "\\XML\\";

	// Token: 0x040005BE RID: 1470
	public static readonly string QUEUE_PATH = global::Globals.TXT_PATH + "Queue.txt";

	// Token: 0x040005BF RID: 1471
	public static readonly string NOTEPAD_PATH = global::Globals.TXT_PATH + "Notepad.txt";

	// Token: 0x040005C0 RID: 1472
	public static readonly string SOCKS_PATH = global::Globals.TXT_PATH + "Proxies.txt";

	// Token: 0x040005C1 RID: 1473
	public static readonly string CHECKED_PATH = global::Globals.TXT_PATH + "Checkeds.txt";

	// Token: 0x040005C2 RID: 1474
	public static readonly string TRASH_PATH = global::Globals.TXT_PATH + "Trash.txt";

	// Token: 0x040005C3 RID: 1475
	public static readonly string DIC_LOGIN_FINDER = global::Globals.TXT_PATH + "DicLoginFinder.txt";

	// Token: 0x040005C4 RID: 1476
	public static readonly Version VERSION = new Version(10, 6, 0);

	// Token: 0x040005C5 RID: 1477
	public static readonly string APP_VERSION = string.Concat(new string[]
	{
		Class2.Class0_0.Info.ProductName,
		" v.",
		Conversions.ToString(global::Globals.VERSION.Major),
		".",
		Conversions.ToString(global::Globals.VERSION.Minor),
		""
	});

	// Token: 0x040005C6 RID: 1478
	public static MainForm GMain = new MainForm();

	// Token: 0x040005C7 RID: 1479
	private static int GWL_EXSTYLE;

	// Token: 0x040005C8 RID: 1480
	private static int WS_EX_CLIENTEDGE;

	// Token: 0x040005C9 RID: 1481
	private static int WS_EX_STATICEDGE;

	// Token: 0x040005CA RID: 1482
	private static int SWP_FRAMECHANGED;

	// Token: 0x040005CB RID: 1483
	private static int SWP_NOACTIVATE;

	// Token: 0x040005CC RID: 1484
	private static int SWP_NOMOVE;

	// Token: 0x040005CD RID: 1485
	private static int SWP_NOSIZE;

	// Token: 0x040005CE RID: 1486
	private static int SWP_NOZORDER;

	// Token: 0x040005CF RID: 1487
	private static int SWP_DRAWFRAME;

	// Token: 0x040005D0 RID: 1488
	private static int SWP_FLAGS;

	// Token: 0x040005D1 RID: 1489
	private static int WM_NCLBUTTONDOWN;

	// Token: 0x040005D2 RID: 1490
	private static int HT_CAPTION;

	// Token: 0x040005D3 RID: 1491
	private static int LVM_FIRST;

	// Token: 0x040005D4 RID: 1492
	private static int LVM_SETITEMSTATE;

	// Token: 0x020000C8 RID: 200
	// (Invoke) Token: 0x06000BA2 RID: 2978
	public delegate object DGetObjectValue(object c);

	// Token: 0x020000C9 RID: 201
	// (Invoke) Token: 0x06000BA6 RID: 2982
	public delegate void DSetObjectValue(object c, object value);

	// Token: 0x020000CA RID: 202
	public enum SearchHost : byte
	{
		// Token: 0x040005D6 RID: 1494
		Google,
		// Token: 0x040005D7 RID: 1495
		DuckDuckGo,
		// Token: 0x040005D8 RID: 1496
		Bing,
		// Token: 0x040005D9 RID: 1497
		Yahoo,
		// Token: 0x040005DA RID: 1498
		Ask,
		// Token: 0x040005DB RID: 1499
		AOL,
		// Token: 0x040005DC RID: 1500
		WOW,
		// Token: 0x040005DD RID: 1501
		StartPage,
		// Token: 0x040005DE RID: 1502
		Yandex,
		// Token: 0x040005DF RID: 1503
		Rambler,
		// Token: 0x040005E0 RID: 1504
		Search
	}

	// Token: 0x020000CB RID: 203
	public enum WebServer : byte
	{
		// Token: 0x040005E2 RID: 1506
		UNKNOW,
		// Token: 0x040005E3 RID: 1507
		LINUX,
		// Token: 0x040005E4 RID: 1508
		WINDOWS
	}

	// Token: 0x020000CC RID: 204
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	private struct LVITEM
	{
		// Token: 0x040005E5 RID: 1509
		public int mask;

		// Token: 0x040005E6 RID: 1510
		public int iItem;

		// Token: 0x040005E7 RID: 1511
		public int iSubItem;

		// Token: 0x040005E8 RID: 1512
		public int state;

		// Token: 0x040005E9 RID: 1513
		public int stateMask;

		// Token: 0x040005EA RID: 1514
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pszText;

		// Token: 0x040005EB RID: 1515
		public int cchTextMax;

		// Token: 0x040005EC RID: 1516
		public int iImage;

		// Token: 0x040005ED RID: 1517
		public IntPtr lParam;

		// Token: 0x040005EE RID: 1518
		public int iIndent;

		// Token: 0x040005EF RID: 1519
		public int iGroupId;

		// Token: 0x040005F0 RID: 1520
		public int cColumns;

		// Token: 0x040005F1 RID: 1521
		public IntPtr puColumns;
	}

	// Token: 0x020000CD RID: 205
	private sealed class ShellT
	{
		// Token: 0x06000BA7 RID: 2983 RVA: 0x00047310 File Offset: 0x00045510
		public ShellT(string url)
		{
			int num2;
			int num4;
			object obj;
			try
			{
				IL_0007:
				int num = 1;
				this.__URL = url;
				IL_0010:
				ProjectData.ClearProjectError();
				num2 = -2;
				IL_0018:
				num = 3;
				Thread thread = new Thread(new ThreadStart(this.IShell));
				IL_002C:
				num = 4;
				thread.IsBackground = true;
				IL_0035:
				num = 5;
				thread.Start();
				IL_003D:
				goto IL_00AC;
				IL_003F:
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_0065:
				goto IL_00A1;
				IL_0067:
				num4 = num;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], (num2 > -2) ? num2 : 1);
				IL_007F:;
			}
			catch when (endfilter((obj is Exception) & (num2 != 0) & (num4 == 0)))
			{
				Exception ex = (Exception)obj2;
				goto IL_0067;
			}
			IL_00A1:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_00AC:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		// Token: 0x06000BA8 RID: 2984 RVA: 0x000473E4 File Offset: 0x000455E4
		private void IShell()
		{
			int num;
			int num4;
			object obj;
			try
			{
				IL_0002:
				ProjectData.ClearProjectError();
				num = -2;
				IL_000A:
				int num2 = 2;
				Process.Start(this.__URL);
				IL_0018:
				goto IL_007B;
				IL_001A:
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_0034:
				goto IL_0070;
				IL_0036:
				num4 = num2;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], (num > -2) ? num : 1);
				IL_004E:;
			}
			catch when (endfilter((obj is Exception) & (num != 0) & (num4 == 0)))
			{
				Exception ex = (Exception)obj2;
				goto IL_0036;
			}
			IL_0070:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_007B:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		// Token: 0x040005F2 RID: 1522
		private string __URL;
	}

	// Token: 0x020000CE RID: 206
	private sealed class LongExtensions
	{
		// Token: 0x06000BA9 RID: 2985 RVA: 0x00047484 File Offset: 0x00045684
		private LongExtensions()
		{
		}

		// Token: 0x06000BAA RID: 2986 RVA: 0x0004748C File Offset: 0x0004568C
		static LongExtensions()
		{
			Func<long, int, string> FormatAsProportionOfUnit = (long bytes, int shift) => ((double)(bytes >> shift) / 1024.0).ToString("0.###");
			global::Globals.LongExtensions.bytesToUnitConverters = new Func<long, string>[]
			{
				(long bytes) => bytes.ToString() + " B",
				(long bytes) => FormatAsProportionOfUnit(bytes, 0) + " KiB",
				(long bytes) => FormatAsProportionOfUnit(bytes, 10) + " MiB",
				(long bytes) => FormatAsProportionOfUnit(bytes, 20) + " GiB",
				(long bytes) => FormatAsProportionOfUnit(bytes, 30) + " TiB",
				(long bytes) => FormatAsProportionOfUnit(bytes, 40) + " PiB",
				(long bytes) => FormatAsProportionOfUnit(bytes, 50) + " EiB"
			};
		}

		// Token: 0x06000BAB RID: 2987 RVA: 0x00047544 File Offset: 0x00045744
		public static string ToReadableByteSizeString(long bytes)
		{
			checked
			{
				string text;
				if (bytes <= 0L)
				{
					text = "0 B";
				}
				else
				{
					int i;
					for (i = 0; i < global::Globals.LongExtensions.numberOfBytesInUnit.Length; i++)
					{
						if (bytes < global::Globals.LongExtensions.numberOfBytesInUnit[i])
						{
							return global::Globals.LongExtensions.bytesToUnitConverters[i](bytes);
						}
					}
					text = global::Globals.LongExtensions.bytesToUnitConverters[i](bytes);
				}
				return text;
			}
		}

		// Token: 0x040005F3 RID: 1523
		private static readonly long[] numberOfBytesInUnit = new long[] { 1024L, 1048576L, 1073741824L, 1099511627776L, 1125899906842624L, 1152921504606846976L };

		// Token: 0x040005F4 RID: 1524
		private static readonly Func<long, string>[] bytesToUnitConverters;
	}
}
