using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

// Token: 0x020000A9 RID: 169
[StandardModule]
public sealed class Helper
{
	// Token: 0x06000985 RID: 2437 RVA: 0x0003A624 File Offset: 0x00038824
	public static LinearGradientBrush CreateGlassGradientBrush(Rectangle Rectangle, Color Color1, Color Color2)
	{
		LinearGradientBrush linearGradientBrush = new LinearGradientBrush(Rectangle, Color1, Color2, LinearGradientMode.Vertical);
		Bitmap bitmap = new Bitmap(1, Rectangle.Height);
		Graphics graphics = Graphics.FromImage(bitmap);
		graphics.FillRectangle(linearGradientBrush, new Rectangle(0, 0, 1, Rectangle.Height));
		ColorBlend colorBlend = new ColorBlend(4);
		colorBlend.Colors[0] = bitmap.GetPixel(0, 0);
		checked
		{
			colorBlend.Colors[1] = bitmap.GetPixel(0, (int)Math.Round((double)bitmap.Height / 3.0));
			colorBlend.Colors[2] = bitmap.GetPixel(0, bitmap.Height - 1);
			colorBlend.Colors[3] = bitmap.GetPixel(0, (int)Math.Round((double)bitmap.Height / 3.0));
			colorBlend.Positions[0] = 0f;
			colorBlend.Positions[1] = 0.335f;
			colorBlend.Positions[2] = 0.335f;
			colorBlend.Positions[3] = 1f;
			linearGradientBrush.InterpolationColors = colorBlend;
			graphics.Dispose();
			bitmap.Dispose();
			return linearGradientBrush;
		}
	}

	// Token: 0x040004D1 RID: 1233
	public static Helper.Colors RenderColors = new Helper.Colors();

	// Token: 0x020000AA RID: 170
	public class Colors
	{
		// Token: 0x06000987 RID: 2439 RVA: 0x0003A74C File Offset: 0x0003894C
		public Color BackHighColor(ToolStripRenderMode RenderMode, Color ManagedColor)
		{
			Color color;
			if (RenderMode == ToolStripRenderMode.System)
			{
				color = Color.Transparent;
			}
			else if (RenderMode == ToolStripRenderMode.Professional)
			{
				color = ProfessionalColors.ToolStripGradientEnd;
			}
			else
			{
				color = ManagedColor;
			}
			return color;
		}

		// Token: 0x06000988 RID: 2440 RVA: 0x0003A778 File Offset: 0x00038978
		public Color BackLowColor(ToolStripRenderMode RenderMode, Color ManagedColor)
		{
			Color color;
			if (RenderMode == ToolStripRenderMode.System)
			{
				color = Color.Transparent;
			}
			else if (RenderMode == ToolStripRenderMode.Professional)
			{
				color = ProfessionalColors.ToolStripGradientBegin;
			}
			else
			{
				color = ManagedColor;
			}
			return color;
		}

		// Token: 0x06000989 RID: 2441 RVA: 0x0003A7A4 File Offset: 0x000389A4
		public Color BorderColor(ToolStripRenderMode RenderMode, Color ManagedColor)
		{
			Color color;
			if (RenderMode == ToolStripRenderMode.System)
			{
				color = SystemColors.ControlDarkDark;
			}
			else if (RenderMode == ToolStripRenderMode.Professional)
			{
				color = ProfessionalColors.GripDark;
			}
			else
			{
				color = ManagedColor;
			}
			return color;
		}

		// Token: 0x0600098A RID: 2442 RVA: 0x0003A7D0 File Offset: 0x000389D0
		public Color BorderColorDisabled(ToolStripRenderMode RenderMode, Color ManagedColor)
		{
			Color color;
			if (RenderMode == ToolStripRenderMode.System)
			{
				color = SystemColors.ControlDark;
			}
			else if (RenderMode == ToolStripRenderMode.Professional)
			{
				color = ProfessionalColors.SeparatorDark;
			}
			else
			{
				color = ManagedColor;
			}
			return color;
		}

		// Token: 0x0600098B RID: 2443 RVA: 0x0003A7FC File Offset: 0x000389FC
		public Color ControlButtonBackHighColor(ToolStripRenderMode RenderMode, Color ManagedColor)
		{
			Color color;
			if (RenderMode == ToolStripRenderMode.System)
			{
				color = SystemColors.ButtonHighlight;
			}
			else if (RenderMode == ToolStripRenderMode.Professional)
			{
				color = ProfessionalColors.ButtonSelectedGradientBegin;
			}
			else
			{
				color = ManagedColor;
			}
			return color;
		}

		// Token: 0x0600098C RID: 2444 RVA: 0x0003A828 File Offset: 0x00038A28
		public Color ControlButtonBackLowColor(ToolStripRenderMode RenderMode, Color ManagedColor)
		{
			Color color;
			if (RenderMode == ToolStripRenderMode.System)
			{
				color = SystemColors.ButtonHighlight;
			}
			else if (RenderMode == ToolStripRenderMode.Professional)
			{
				color = ProfessionalColors.ButtonSelectedGradientEnd;
			}
			else
			{
				color = ManagedColor;
			}
			return color;
		}

		// Token: 0x0600098D RID: 2445 RVA: 0x0003A854 File Offset: 0x00038A54
		public Color ControlButtonBorderColor(ToolStripRenderMode RenderMode, Color ManagedColor)
		{
			Color color;
			if (RenderMode == ToolStripRenderMode.System)
			{
				color = SystemColors.HotTrack;
			}
			else if (RenderMode == ToolStripRenderMode.Professional)
			{
				color = ProfessionalColors.ButtonPressedBorder;
			}
			else
			{
				color = ManagedColor;
			}
			return color;
		}

		// Token: 0x0600098E RID: 2446 RVA: 0x0003A880 File Offset: 0x00038A80
		public Color TabBackHighColor(ToolStripRenderMode RenderMode, Color ManagedColor)
		{
			Color color;
			if (RenderMode == ToolStripRenderMode.System)
			{
				color = SystemColors.Control;
			}
			else if (RenderMode == ToolStripRenderMode.Professional)
			{
				color = ProfessionalColors.MenuItemPressedGradientBegin;
			}
			else
			{
				color = ManagedColor;
			}
			return color;
		}

		// Token: 0x0600098F RID: 2447 RVA: 0x0003A8AC File Offset: 0x00038AAC
		public Color TabBackLowColor(ToolStripRenderMode RenderMode, Color ManagedColor)
		{
			Color color;
			if (RenderMode == ToolStripRenderMode.System)
			{
				color = SystemColors.Control;
			}
			else if (RenderMode == ToolStripRenderMode.Professional)
			{
				color = ProfessionalColors.MenuItemPressedGradientEnd;
			}
			else
			{
				color = ManagedColor;
			}
			return color;
		}

		// Token: 0x06000990 RID: 2448 RVA: 0x0003A8D8 File Offset: 0x00038AD8
		public Color TabBackHighColorDisabled(ToolStripRenderMode RenderMode, Color ManagedColor)
		{
			Color color;
			if (RenderMode == ToolStripRenderMode.System)
			{
				color = SystemColors.Control;
			}
			else if (RenderMode == ToolStripRenderMode.Professional)
			{
				color = ProfessionalColors.ToolStripDropDownBackground;
			}
			else
			{
				color = ManagedColor;
			}
			return color;
		}

		// Token: 0x06000991 RID: 2449 RVA: 0x0003A904 File Offset: 0x00038B04
		public Color TabBackLowColorDisabled(ToolStripRenderMode RenderMode, Color ManagedColor)
		{
			Color color;
			if (RenderMode == ToolStripRenderMode.System)
			{
				color = SystemColors.Control;
			}
			else if (RenderMode == ToolStripRenderMode.Professional)
			{
				color = ProfessionalColors.ToolStripGradientMiddle;
			}
			else
			{
				color = ManagedColor;
			}
			return color;
		}

		// Token: 0x06000992 RID: 2450 RVA: 0x0003A930 File Offset: 0x00038B30
		public Color TabCloseButtonBackHighColor(ToolStripRenderMode RenderMode, Color ManagedColor)
		{
			Color color;
			if (RenderMode == ToolStripRenderMode.System)
			{
				color = Color.Transparent;
			}
			else if (RenderMode == ToolStripRenderMode.Professional)
			{
				color = Color.Transparent;
			}
			else
			{
				color = ManagedColor;
			}
			return color;
		}

		// Token: 0x06000993 RID: 2451 RVA: 0x0003A95C File Offset: 0x00038B5C
		public Color TabCloseButtonBackHighColorDisabled(ToolStripRenderMode RenderMode, Color ManagedColor)
		{
			Color color;
			if (RenderMode == ToolStripRenderMode.System)
			{
				color = Color.Transparent;
			}
			else if (RenderMode == ToolStripRenderMode.Professional)
			{
				color = Color.Transparent;
			}
			else
			{
				color = ManagedColor;
			}
			return color;
		}

		// Token: 0x06000994 RID: 2452 RVA: 0x0003A988 File Offset: 0x00038B88
		public Color TabCloseButtonBackHighColorHot(ToolStripRenderMode RenderMode, Color ManagedColor)
		{
			Color color;
			if (RenderMode == ToolStripRenderMode.System)
			{
				color = SystemColors.ButtonHighlight;
			}
			else if (RenderMode == ToolStripRenderMode.Professional)
			{
				color = Color.WhiteSmoke;
			}
			else
			{
				color = ManagedColor;
			}
			return color;
		}

		// Token: 0x06000995 RID: 2453 RVA: 0x0003A9B4 File Offset: 0x00038BB4
		public Color TabCloseButtonBackLowColor(ToolStripRenderMode RenderMode, Color ManagedColor)
		{
			Color color;
			if (RenderMode == ToolStripRenderMode.System)
			{
				color = Color.Transparent;
			}
			else if (RenderMode == ToolStripRenderMode.Professional)
			{
				color = Color.Transparent;
			}
			else
			{
				color = ManagedColor;
			}
			return color;
		}

		// Token: 0x06000996 RID: 2454 RVA: 0x0003A9E0 File Offset: 0x00038BE0
		public Color TabCloseButtonBackLowColorDisabled(ToolStripRenderMode RenderMode, Color ManagedColor)
		{
			Color color;
			if (RenderMode == ToolStripRenderMode.System)
			{
				color = Color.Transparent;
			}
			else if (RenderMode == ToolStripRenderMode.Professional)
			{
				color = Color.Transparent;
			}
			else
			{
				color = ManagedColor;
			}
			return color;
		}

		// Token: 0x06000997 RID: 2455 RVA: 0x0003AA0C File Offset: 0x00038C0C
		public Color TabCloseButtonBackLowColorHot(ToolStripRenderMode RenderMode, Color ManagedColor)
		{
			Color color;
			if (RenderMode == ToolStripRenderMode.System)
			{
				color = SystemColors.ButtonHighlight;
			}
			else if (RenderMode == ToolStripRenderMode.Professional)
			{
				color = Color.LightGray;
			}
			else
			{
				color = ManagedColor;
			}
			return color;
		}

		// Token: 0x06000998 RID: 2456 RVA: 0x0003AA38 File Offset: 0x00038C38
		public Color TabCloseButtonBorderColor(ToolStripRenderMode RenderMode, Color ManagedColor)
		{
			Color color;
			if (RenderMode == ToolStripRenderMode.System)
			{
				color = SystemColors.ControlDark;
			}
			else if (RenderMode == ToolStripRenderMode.Professional)
			{
				color = Color.Transparent;
			}
			else
			{
				color = ManagedColor;
			}
			return color;
		}

		// Token: 0x06000999 RID: 2457 RVA: 0x0003AA64 File Offset: 0x00038C64
		public Color TabCloseButtonBorderColorDisabled(ToolStripRenderMode RenderMode, Color ManagedColor)
		{
			Color color;
			if (RenderMode == ToolStripRenderMode.System)
			{
				color = SystemColors.GrayText;
			}
			else if (RenderMode == ToolStripRenderMode.Professional)
			{
				color = Color.Transparent;
			}
			else
			{
				color = ManagedColor;
			}
			return color;
		}

		// Token: 0x0600099A RID: 2458 RVA: 0x0003AA90 File Offset: 0x00038C90
		public Color TabCloseButtonBorderColorHot(ToolStripRenderMode RenderMode, Color ManagedColor)
		{
			Color color;
			if (RenderMode == ToolStripRenderMode.System)
			{
				color = SystemColors.HotTrack;
			}
			else if (RenderMode == ToolStripRenderMode.Professional)
			{
				color = Color.Gray;
			}
			else
			{
				color = ManagedColor;
			}
			return color;
		}

		// Token: 0x0600099B RID: 2459 RVA: 0x0003AABC File Offset: 0x00038CBC
		public Color TabCloseButtonForeColor(ToolStripRenderMode RenderMode, Color ManagedColor)
		{
			Color color;
			if (RenderMode == ToolStripRenderMode.System)
			{
				color = SystemColors.ControlText;
			}
			else if (RenderMode == ToolStripRenderMode.Professional)
			{
				color = Color.Gray;
			}
			else
			{
				color = ManagedColor;
			}
			return color;
		}

		// Token: 0x0600099C RID: 2460 RVA: 0x0003AAE8 File Offset: 0x00038CE8
		public Color TabCloseButtonForeColorDisabled(ToolStripRenderMode RenderMode, Color ManagedColor)
		{
			Color color;
			if (RenderMode == ToolStripRenderMode.System)
			{
				color = SystemColors.GrayText;
			}
			else if (RenderMode == ToolStripRenderMode.Professional)
			{
				color = Color.Gray;
			}
			else
			{
				color = ManagedColor;
			}
			return color;
		}

		// Token: 0x0600099D RID: 2461 RVA: 0x0003AB14 File Offset: 0x00038D14
		public Color TabCloseButtonForeColorHot(ToolStripRenderMode RenderMode, Color ManagedColor)
		{
			Color color;
			if (RenderMode == ToolStripRenderMode.System)
			{
				color = SystemColors.ControlText;
			}
			else if (RenderMode == ToolStripRenderMode.Professional)
			{
				color = Color.Firebrick;
			}
			else
			{
				color = ManagedColor;
			}
			return color;
		}
	}
}
