using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Chilkat;
using Microsoft.VisualBasic.CompilerServices;
using ns0;

// Token: 0x0200001D RID: 29
public class Updater
{
	// Token: 0x06000134 RID: 308 RVA: 0x00007B9C File Offset: 0x00005D9C
	public Updater()
	{
		this.XMLPath = Globals.APP_PATH + "\\update.xml";
	}

	// Token: 0x06000135 RID: 309 RVA: 0x00007BBC File Offset: 0x00005DBC
	public void GenerateXML()
	{
		Class51 @class = new Class51(this.XMLPath, "SQLi_Dumper", ';', 0);
		@class.method_6("Version", "Major", Conversions.ToString(Globals.VERSION.Major));
		@class.method_6("Version", "Minor", Conversions.ToString(Globals.VERSION.Minor));
		@class.method_6("Version", "Revision", Conversions.ToString(Globals.VERSION.Build));
		@class.method_6("Download", "RAR", "http://aderisci.com/sqli_dumper/update.dat");
		@class.method_6("Changelog", "TXT", "09/15/2017 - v.9.6\r\n* Added Grids Filters by date\r\n* Fixed Dumper data parser (for some MySQL Error injections)\r\n* Misc: improvements, fixes and optimizations\r\n09/01/2017 - v.9.5\r\n* Fix MySQL Load\\Write File for MySQL v.4.x (Data Dumper)\r\n* Fix Stop Work 'Search Column\\Table' MSG Box Error\r\n* Improved Search column sort\r\n* Improved Search Grids freezing\r\n* Improved ContextMenu poor visibility\r\n* Add Grids Key Control \r\n  CTRL + A to select All\r\n  Delete key to delete selected items\r\n  Enter key to go to dumper\r\n08/26/2017 - v.9.4\r\n* Added Germany, Portuguese and Persian Language\r\n* Added Import menu (queue)\r\n* Added Re-Exploiter menu\r\n* Improved Exploiter, better detection rate\r\n* Improved Data Dump, problem with '?~!' in MySQL Error Basead\r\n* Improved Scanner, IP/Proxy control with blacklisted\r\n* Improved Search Column\\Tables\r\n* Improved Dumper Auto-Setup (detecting HTTP Flow Redirects)\r\n08/12/2017 - v.9.3\r\n* Added XXS support\r\n* Added Import URL Injectables.xml from v.8.x\r\n* Added extra 3 column (search rows)\r\n* Added Exploit from .txt (press Start Exploiter with queue empty)\r\n* Added Statistics Virtualization\r\n* Improved exploiter engine\r\n* Improved analyzer engine\r\n  ~40% better detection\r\n  fixed unique filter by domain\r\n  fixed loadfile bug dection\r\n* Improved Dumper for long time dumping (no more slow, only if request delays)\r\n* Improved RAM\\CPU and Traffic use\r\n* Improved multi thread engine stop\r\n* Improved HTTP Debbuger, better delay control\r\n* Improved GUI Core Load\\UnLoad performance\r\n* Improved Skins (added news, removed some)\r\n* Fixed grids auto scroll\r\n* Fixed open new instancie bug on schema\r\n ** For security reasons, HWID is changed.\r\n ** Contact me via jabber for update, or email me.\r\n ** c4rl0s [at] jabber.ru or c4rl0s.pt [at] gmail.com\r\n ** Sorry for any inconvenience");
		@class.method_9(true, true);
	}

	// Token: 0x06000136 RID: 310 RVA: 0x00007C6C File Offset: 0x00005E6C
	public void Check(bool bMsgBox)
	{
		try
		{
			Http http = new Http();
			http.UserAgent = Conversions.ToString(Globals.GetObjectValue(Globals.GMain.txtUserAgent));
			http.Accept = Conversions.ToString(Globals.GetObjectValue(Globals.GMain.txtAccept));
			http.ConnectTimeout = Conversions.ToInteger(Globals.GetObjectValue(Globals.GMain.numHTTPTimeout));
			http.ReadTimeout = http.ConnectTimeout;
			http.FollowRedirects = true;
			http.AutoAddHostHeader = true;
			http.AllowGzip = true;
			http.SendCookies = true;
			http.SaveCookies = true;
			http.CookieDir = "memory";
			http.UseIEProxy = false;
			Thread.Sleep(2000);
			string text;
			if (!string.IsNullOrEmpty(text))
			{
				Class51 @class = new Class51(text, "SQLi_Dumper", ';', 1);
				Version version = new Version(Conversions.ToInteger(@class.method_3("Version", "Major", "0")), Conversions.ToInteger(@class.method_3("Version", "Minor", "0")), Conversions.ToInteger(@class.method_3("Version", "Revision", "0")));
				if (version.CompareTo(Globals.VERSION) > 0)
				{
					using (new Class8(Globals.GMain))
					{
						MessageBox.Show(Globals.translate_0.GetStr(Globals.GMain, 36, "") + version.ToString() + "\r\n\r\n" + @class.method_3("Changelog", "TXT", ""), "SQLi Dumper Update", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						goto IL_01C2;
					}
				}
			}
			if (bMsgBox)
			{
				using (new Class8(Globals.GMain))
				{
					MessageBox.Show(Globals.translate_0.GetStr(Globals.GMain, 38, ""), "SQLi Dumper Update", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
			}
			IL_01C2:
			http.Dispose();
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.StackTrace);
		}
		finally
		{
			if (File.Exists(Globals.APP_PATH + "\\update.bin"))
			{
				File.Delete(Globals.APP_PATH + "\\update.bin");
			}
		}
	}

	// Token: 0x06000137 RID: 311 RVA: 0x00007EF0 File Offset: 0x000060F0
	private void OnPercentDone(object sender, PercentDoneEventArgs e)
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
			Application.DoEvents();
			IL_0011:
			num2 = 3;
			this.__Donloader.prbDownload.Value = e.PercentDone;
			IL_0029:
			num2 = 4;
			if (!this.__Donloader.Cancel)
			{
				goto IL_0041;
			}
			IL_0038:
			num2 = 5;
			e.Abort = true;
			IL_0041:
			goto IL_00B4;
			IL_0043:
			int num3 = num4 + 1;
			num4 = 0;
			@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
			IL_006D:
			goto IL_00A9;
			IL_006F:
			num4 = num2;
			@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], (num > -2) ? num : 1);
			IL_0087:;
		}
		catch when (endfilter((obj is Exception) & (num != 0) & (num4 == 0)))
		{
			Exception ex = (Exception)obj2;
			goto IL_006F;
		}
		IL_00A9:
		throw ProjectData.CreateProjectError(-2146828237);
		IL_00B4:
		if (num4 != 0)
		{
			ProjectData.ClearProjectError();
		}
	}

	// Token: 0x06000138 RID: 312 RVA: 0x00007FCC File Offset: 0x000061CC
	private void OnReceiveRate(object sender, DataRateEventArgs e)
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
			this.__Donloader.Text = Globals.translate_0.GetStr(Globals.GMain, 39, "") + Globals.FormatBytes(e.BytesPerSec) + "\\s";
			IL_0044:
			num2 = 3;
			Application.DoEvents();
			IL_004B:
			goto IL_00B2;
			IL_004D:
			int num3 = num4 + 1;
			num4 = 0;
			@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
			IL_006B:
			goto IL_00A7;
			IL_006D:
			num4 = num2;
			@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], (num > -2) ? num : 1);
			IL_0085:;
		}
		catch when (endfilter((obj is Exception) & (num != 0) & (num4 == 0)))
		{
			Exception ex = (Exception)obj2;
			goto IL_006D;
		}
		IL_00A7:
		throw ProjectData.CreateProjectError(-2146828237);
		IL_00B2:
		if (num4 != 0)
		{
			ProjectData.ClearProjectError();
		}
	}

	// Token: 0x040000D8 RID: 216
	private string XMLPath;

	// Token: 0x040000D9 RID: 217
	private static string XMLSection;

	// Token: 0x040000DA RID: 218
	private static string UPDATE_TMP;

	// Token: 0x040000DB RID: 219
	private static string DownloadXML;

	// Token: 0x040000DC RID: 220
	private static string DownloadEXE;

	// Token: 0x040000DD RID: 221
	private UpdateProg __Donloader;
}
