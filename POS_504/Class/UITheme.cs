using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace POS_504.Class
{
    public static class UITheme
    {
        // -------------------------------------------------------------
        // Executive Color Palette - Soft Slate & High-Contrast Cards
        // Eliminates the blinding pure-white look ("សពេក")
        // -------------------------------------------------------------
        public static readonly Color Primary = Color.FromArgb(37, 99, 235);         // Royal Blue #2563EB
        public static readonly Color PrimaryHover = Color.FromArgb(29, 78, 216);    // Darker Blue #1D4ED8
        public static readonly Color PrimaryLight = Color.FromArgb(239, 246, 255);  // Soft Blue #EFF6FF

        public static readonly Color DarkSlate = Color.FromArgb(15, 23, 42);        // Slate 900 #0F172A
        public static readonly Color SlateHeader = Color.FromArgb(30, 41, 59);      // Slate 800 #1E293B
        public static readonly Color SlateCard = Color.FromArgb(51, 65, 85);        // Slate 700 #334155

        // Soft Canvas Background (Comfortable on cashier/admin eyes, distinct from white controls)
        public static readonly Color FormBackground = Color.FromArgb(235, 239, 244); // Slate-Gray #EBEFF4
        public static readonly Color MdiWorkspace = Color.FromArgb(218, 224, 233);   // Slate Workspace #DAE0E9
        public static readonly Color CardBackground = Color.White;                  // Pure White Cards
        public static readonly Color BorderColor = Color.FromArgb(203, 213, 225);    // Slate 300 #CBD5E1
        public static readonly Color BorderFocus = Color.FromArgb(37, 99, 235);     // Blue 500

        public static readonly Color TextPrimary = Color.FromArgb(15, 23, 42);      // Slate 900 #0F172A
        public static readonly Color TextSecondary = Color.FromArgb(51, 65, 85);    // Slate 700 #334155 (High contrast)
        public static readonly Color TextMuted = Color.FromArgb(100, 116, 139);     // Slate 500 #64748B

        // Semantic Action Button Colors (Refined Modern Executive Palette)
        public static readonly Color Info = Color.FromArgb(14, 165, 233);           // Sky 500 #0EA5E9 (Add / New)
        public static readonly Color InfoHover = Color.FromArgb(2, 132, 199);       // Sky 600 #0284C7

        public static readonly Color Success = Color.FromArgb(16, 185, 129);        // Emerald 500 #10B981 (Insert / Save / Pay)
        public static readonly Color SuccessHover = Color.FromArgb(5, 150, 105);    // Emerald 600 #059669

        public static readonly Color Warning = Color.FromArgb(245, 158, 11);        // Amber 500 #F59E0B (Update / Edit)
        public static readonly Color WarningHover = Color.FromArgb(217, 119, 6);    // Amber 600 #D97706

        public static readonly Color Danger = Color.FromArgb(239, 68, 68);          // Rose 500 #EF4444 (Delete / Remove)
        public static readonly Color DangerHover = Color.FromArgb(220, 38, 38);     // Rose 600 #DC2626

        public static readonly Color Secondary = Color.FromArgb(100, 116, 139);     // Slate 500 #64748B (Close / Exit / Back)
        public static readonly Color SecondaryHover = Color.FromArgb(71, 85, 105);  // Slate 600 #475569

        public static readonly Color Indigo = Color.FromArgb(99, 102, 241);         // Indigo 500 #6366F1 (Browse / Upload)
        public static readonly Color IndigoHover = Color.FromArgb(79, 70, 229);     // Indigo 600 #4F46E5

        // DataGridView Colors
        public static readonly Color GridHeaderBack = Color.FromArgb(30, 41, 59);   // Slate 800
        public static readonly Color GridHeaderFore = Color.White;
        public static readonly Color GridRowAlternate = Color.FromArgb(243, 246, 250); // Soft Slate 50
        public static readonly Color GridSelectionBack = Color.FromArgb(224, 231, 255); // Soft Indigo 100
        public static readonly Color GridSelectionFore = Color.FromArgb(15, 23, 42);   // High Contrast Dark

        public static readonly Font TitleFont = new Font("Segoe UI Semibold", 15F, FontStyle.Bold);
        public static readonly Font SubTitleFont = new Font("Segoe UI", 10F, FontStyle.Regular);
        public static readonly Font SectionFont = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
        public static readonly Font HeaderFont = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
        public static readonly Font LabelFont = new Font("Segoe UI", 9.5F, FontStyle.Regular);
        public static readonly Font LabelBoldFont = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
        public static readonly Font InputFont = new Font("Segoe UI", 9.5F, FontStyle.Regular);
        public static readonly Font ButtonFont = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
        public static readonly Font GridHeaderFont = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
        public static readonly Font GridCellFont = new Font("Segoe UI", 9.5F, FontStyle.Regular);

        // -------------------------------------------------------------
        // Main Method: Apply Modern Theme to Any Form
        // -------------------------------------------------------------
        public static void ApplyModernTheme(this Form form)
        {
            if (form == null) return;

            try
            {
                form.SuspendLayout();

                // Set Form Properties
                form.Font = LabelFont;
                form.BackColor = FormBackground;
                form.ForeColor = TextPrimary;

                string formName = form.GetType().Name;
                bool isMain = formName.Contains("Main");
                bool isReport = formName.Contains("Report") || formName.Contains("Rpt");
                bool isMajorScreen = formName.Contains("Sale") || formName.Contains("Purchase") || formName.Contains("Product");

                // Upgrade obsolete FixedToolWindow
                if (form.FormBorderStyle == FormBorderStyle.FixedToolWindow)
                {
                    form.FormBorderStyle = FormBorderStyle.FixedSingle;
                }

                // Prevent standard setup/dialog forms from blowing up to 1080p empty void!
                if (!isMain && !isReport && !isMajorScreen)
                {
                    form.MaximizeBox = false;
                    form.WindowState = FormWindowState.Normal;
                }
                else if (isReport)
                {
                    form.MaximizeBox = true;
                    form.FormBorderStyle = FormBorderStyle.Sizable;
                }
                else
                {
                    form.MaximizeBox = true;
                }

                form.StartPosition = FormStartPosition.CenterScreen;

                // Recursively style all controls inside the form
                StyleControlsRecursive(form.Controls);

                form.ResumeLayout(true);
            }
            catch
            {
                // Safety guard: Never let theming fail application startup
            }
        }

        private static void StyleControlsRecursive(Control.ControlCollection controls)
        {
            if (controls == null) return;

            foreach (Control ctrl in controls)
            {
                if (ctrl == null) continue;

                // Buttons
                if (ctrl is Button btn)
                {
                    StyleButton(btn);
                }
                // DataGridView
                else if (ctrl is DataGridView dgv)
                {
                    StyleDataGridView(dgv);
                }
                // Labels
                else if (ctrl is Label lbl)
                {
                    StyleLabel(lbl);
                }
                // TextBox
                else if (ctrl is TextBox txt)
                {
                    StyleTextBox(txt);
                }
                // ComboBox
                else if (ctrl is ComboBox cbo)
                {
                    StyleComboBox(cbo);
                }
                // DateTimePicker
                else if (ctrl is DateTimePicker dtp)
                {
                    StyleDateTimePicker(dtp);
                }
                // NumericUpDown
                else if (ctrl is NumericUpDown num)
                {
                    StyleNumericUpDown(num);
                }
                // CheckBox
                else if (ctrl is CheckBox chk)
                {
                    StyleCheckBox(chk);
                }
                // GroupBox
                else if (ctrl is GroupBox gb)
                {
                    StyleGroupBox(gb);
                }
                // ToolStrip
                else if (ctrl is ToolStrip ts && !(ctrl is MenuStrip) && !(ctrl is StatusStrip))
                {
                    StyleToolStrip(ts);
                }
                // MenuStrip
                else if (ctrl is MenuStrip ms)
                {
                    StyleMenuStrip(ms);
                }
                // StatusStrip
                else if (ctrl is StatusStrip ss)
                {
                    StyleStatusStrip(ss);
                }
                // Panel
                else if (ctrl is Panel pnl)
                {
                    if (pnl.BackColor == Color.White || pnl.BackColor == FormBackground)
                    {
                        pnl.BackColor = Color.White;
                    }
                }

                // Recurse for container controls
                if (ctrl.HasChildren && !(ctrl is DataGridView))
                {
                    StyleControlsRecursive(ctrl.Controls);
                }
            }
        }

        // -------------------------------------------------------------
        // Control Stylers
        // -------------------------------------------------------------
        public static GraphicsPath GetRoundedPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int d = radius * 2;
            if (d > rect.Width) d = rect.Width;
            if (d > rect.Height) d = rect.Height;
            if (d <= 0)
            {
                path.AddRectangle(rect);
                return path;
            }

            Rectangle arc = new Rectangle(rect.X, rect.Y, d, d);
            path.AddArc(arc, 180, 90);
            arc.X = rect.Right - d;
            path.AddArc(arc, 270, 90);
            arc.Y = rect.Bottom - d;
            path.AddArc(arc, 0, 90);
            arc.X = rect.Left;
            path.AddArc(arc, 90, 90);
            path.CloseFigure();
            return path;
        }

        public static void StyleButton(Button btn)
        {
            if (btn == null) return;

            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = ButtonFont;
            btn.Cursor = Cursors.Hand;
            btn.ForeColor = Color.White;

            string name = (btn.Name ?? "").ToLowerInvariant();
            string text = (btn.Text ?? "").ToLowerInvariant().Trim();

            Color baseColor;
            Color hoverColor;

            // Determine semantic role
            if (name.Contains("add") || text.Contains("add") || text.Contains("new"))
            {
                if (text.Contains("new") || name.Contains("btnadd"))
                {
                    baseColor = Info;
                    hoverColor = InfoHover;
                }
                else
                {
                    baseColor = Success;
                    hoverColor = SuccessHover;
                }
            }
            else if (name.Contains("insert") || text.Contains("insert") || name.Contains("save") || text.Contains("save") || text.Contains("pay"))
            {
                baseColor = Success;
                hoverColor = SuccessHover;
            }
            else if (name.Contains("update") || text.Contains("update") || name.Contains("edit") || text.Contains("edit"))
            {
                baseColor = Warning;
                hoverColor = WarningHover;
            }
            else if (name.Contains("delete") || text.Contains("delete") || name.Contains("remove"))
            {
                baseColor = Danger;
                hoverColor = DangerHover;
            }
            else if (name.Contains("browse") || text.Contains("browse") || text.Contains("browser"))
            {
                baseColor = Indigo;
                hoverColor = IndigoHover;
            }
            else if (name.Contains("close") || text.Contains("close") || name.Contains("exit") || text.Contains("exit") || text.Contains("cancel"))
            {
                baseColor = Secondary;
                hoverColor = SecondaryHover;
            }
            else if (name.Contains("login") || text.Contains("login") || text.Contains("sign in"))
            {
                baseColor = Primary;
                hoverColor = PrimaryHover;
            }
            else
            {
                baseColor = Primary;
                hoverColor = PrimaryHover;
            }

            btn.BackColor = baseColor;
            btn.FlatAppearance.MouseOverBackColor = hoverColor;
            btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(
                Math.Max(0, hoverColor.R - 20),
                Math.Max(0, hoverColor.G - 20),
                Math.Max(0, hoverColor.B - 20));

            // Apply modern smooth rounded corners (radius = 6px)
            try
            {
                void ApplyRoundedCorners()
                {
                    if (btn.Width > 0 && btn.Height > 0)
                    {
                        using (GraphicsPath path = GetRoundedPath(btn.ClientRectangle, 6))
                        {
                            btn.Region = new Region(path);
                        }
                    }
                }

                ApplyRoundedCorners();
                btn.Resize += (s, e) => ApplyRoundedCorners();
            }
            catch { }
        }

        public static void StyleDataGridView(DataGridView dgv)
        {
            if (dgv == null) return;

            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.FixedSingle;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.GridColor = Color.FromArgb(226, 232, 240);
            dgv.RowHeadersVisible = false;
            dgv.EnableHeadersVisualStyles = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.AllowUserToResizeRows = false;
            dgv.RowTemplate.Height = 34;

            // Column Header Style - Uniform Dark Slate across ALL columns
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = GridHeaderBack;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = GridHeaderFore;
            // Setting SelectionBackColor to match HeaderBack PREVENTS selected column header turning blue!
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = GridHeaderBack;
            dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor = GridHeaderFore;
            dgv.ColumnHeadersDefaultCellStyle.Font = GridHeaderFont;
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.ColumnHeadersDefaultCellStyle.Padding = new Padding(8, 0, 8, 0);
            dgv.ColumnHeadersHeight = 38;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            // Default Cell Style
            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = TextPrimary;
            dgv.DefaultCellStyle.Font = GridCellFont;
            dgv.DefaultCellStyle.SelectionBackColor = GridSelectionBack;
            dgv.DefaultCellStyle.SelectionForeColor = GridSelectionFore;
            dgv.DefaultCellStyle.Padding = new Padding(8, 2, 8, 2);
            dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            // Alternating Row Style (Gentle soft slate 50, crisp alternating)
            dgv.AlternatingRowsDefaultCellStyle.BackColor = GridRowAlternate;
            dgv.AlternatingRowsDefaultCellStyle.ForeColor = TextPrimary;
            dgv.AlternatingRowsDefaultCellStyle.SelectionBackColor = GridSelectionBack;
            dgv.AlternatingRowsDefaultCellStyle.SelectionForeColor = GridSelectionFore;
            dgv.AlternatingRowsDefaultCellStyle.Padding = new Padding(8, 2, 8, 2);

            // Hook data binding so newly loaded database columns also get styled and won't turn blue or truncate!
            dgv.DataBindingComplete += (s, e) =>
            {
                try
                {
                    foreach (DataGridViewColumn col in dgv.Columns)
                    {
                        col.HeaderCell.Style.BackColor = GridHeaderBack;
                        col.HeaderCell.Style.ForeColor = GridHeaderFore;
                        col.HeaderCell.Style.SelectionBackColor = GridHeaderBack;
                        col.HeaderCell.Style.SelectionForeColor = GridHeaderFore;
                        if (dgv.Columns.Count > 6)
                        {
                            col.MinimumWidth = 85;
                        }
                    }
                }
                catch { }
            };

            if (dgv.Columns.Count > 6)
            {
                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            }
            else
            {
                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        public static void StyleLabel(Label lbl)
        {
            if (lbl == null) return;

            string name = (lbl.Name ?? "").ToLowerInvariant();
            string text = (lbl.Text ?? "").Trim();

            // Detect if label sits on a dark banner (e.g. Header bar or top dock)
            bool isDark = false;
            if (lbl.BackColor != Color.Transparent && lbl.BackColor.R < 100 && lbl.BackColor.G < 100 && lbl.BackColor.B < 120)
            {
                isDark = true;
            }
            else if (lbl.Parent != null && lbl.Parent.BackColor.R < 100 && lbl.Parent.BackColor.G < 100 && lbl.Parent.BackColor.B < 120)
            {
                isDark = true;
            }

            bool isTitle = (lbl.Font != null && (lbl.Font.FontFamily.Name.Equals("Impact", StringComparison.OrdinalIgnoreCase) || lbl.Font.Size >= 13)) ||
                           name == "label9" || name == "label11" || name == "label3" ||
                           text.EndsWith("Information", StringComparison.OrdinalIgnoreCase) ||
                           text.EndsWith("Setup", StringComparison.OrdinalIgnoreCase) ||
                           text.EndsWith("Report", StringComparison.OrdinalIgnoreCase) ||
                           text.EndsWith("Management", StringComparison.OrdinalIgnoreCase) ||
                           text.ToUpperInvariant().Contains("POINT OF SALE") ||
                           text.ToUpperInvariant().Contains("LOGIN");

            if (isDark)
            {
                lbl.ForeColor = Color.White;
                if (isTitle)
                {
                    lbl.Font = TitleFont;
                }
                return;
            }

            if (isTitle)
            {
                lbl.Font = TitleFont;
                lbl.ForeColor = DarkSlate;
                if (lbl.BackColor == Color.Red)
                {
                    // Clean up ugly red banner
                    lbl.BackColor = SlateHeader;
                    lbl.ForeColor = Color.White;
                }
            }
            else
            {
                // Standard field label - High contrast slate 700 (#334155)
                lbl.Font = LabelBoldFont;
                lbl.ForeColor = TextSecondary;
            }
        }

        public static void StyleTextBox(TextBox txt)
        {
            if (txt == null) return;
            txt.Font = InputFont;
            txt.ForeColor = TextPrimary;
            txt.BackColor = Color.White;
            txt.BorderStyle = BorderStyle.FixedSingle;
        }

        public static void StyleComboBox(ComboBox cbo)
        {
            if (cbo == null) return;
            cbo.Font = InputFont;
            cbo.ForeColor = TextPrimary;
            cbo.BackColor = Color.White;
            cbo.FlatStyle = FlatStyle.Flat;
        }

        public static void StyleDateTimePicker(DateTimePicker dtp)
        {
            if (dtp == null) return;
            dtp.Font = InputFont;
            dtp.CalendarForeColor = TextPrimary;
            dtp.CalendarTitleBackColor = Primary;
            dtp.CalendarTitleForeColor = Color.White;
        }

        public static void StyleNumericUpDown(NumericUpDown num)
        {
            if (num == null) return;
            num.Font = InputFont;
            num.BorderStyle = BorderStyle.FixedSingle;
            num.ForeColor = TextPrimary;
            num.BackColor = Color.White;
        }

        public static void StyleCheckBox(CheckBox chk)
        {
            if (chk == null) return;
            chk.Font = LabelBoldFont;
            chk.ForeColor = TextPrimary;
            chk.Cursor = Cursors.Hand;
        }

        public static void StyleGroupBox(GroupBox gb)
        {
            if (gb == null) return;
            gb.Font = HeaderFont;
            gb.ForeColor = SlateHeader;
            gb.BackColor = Color.Transparent;
        }

        public static void StyleMenuStrip(MenuStrip ms)
        {
            if (ms == null) return;
            ms.Renderer = new ModernMenuRenderer();
            ms.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular);
            ms.BackColor = DarkSlate;
            ms.ForeColor = Color.White;
            ms.Padding = new Padding(6, 4, 6, 4);

            foreach (ToolStripItem item in ms.Items)
            {
                item.ForeColor = Color.White;
                item.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular);
            }
        }

        public static void StyleToolStrip(ToolStrip ts)
        {
            if (ts == null) return;
            ts.Renderer = new ModernToolStripRenderer();
            ts.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            ts.BackColor = Color.White;
            ts.GripStyle = ToolStripGripStyle.Hidden;
            ts.Padding = new Padding(10, 6, 10, 6);

            foreach (ToolStripItem item in ts.Items)
            {
                item.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
                item.ForeColor = SlateHeader;
                item.Margin = new Padding(3, 2, 3, 2);
            }
        }

        public static void StyleStatusStrip(StatusStrip ss)
        {
            if (ss == null) return;
            ss.Renderer = new ModernStatusStripRenderer();
            ss.BackColor = DarkSlate;
            ss.ForeColor = Color.FromArgb(226, 232, 240);
            ss.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);

            foreach (ToolStripItem item in ss.Items)
            {
                item.ForeColor = Color.FromArgb(226, 232, 240);
                item.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            }
        }

        public static void SetMdiBackground(Form mdiForm, Color color)
        {
            if (mdiForm == null) return;
            foreach (Control ctrl in mdiForm.Controls)
            {
                if (ctrl is MdiClient mdiClient)
                {
                    mdiClient.BackColor = MdiWorkspace;
                    break;
                }
            }
        }
    }

    // -------------------------------------------------------------
    // Custom Renderers for MenuStrip, ToolStrip, and StatusStrip
    // -------------------------------------------------------------
    public class ModernColorTable : ProfessionalColorTable
    {
        public override Color MenuBorder => Color.FromArgb(30, 41, 59);
        public override Color MenuItemBorder => Color.Transparent;
        public override Color MenuItemSelected => Color.FromArgb(37, 99, 235);
        public override Color MenuStripGradientBegin => Color.FromArgb(15, 23, 42);
        public override Color MenuStripGradientEnd => Color.FromArgb(15, 23, 42);
        public override Color ToolStripDropDownBackground => Color.FromArgb(30, 41, 59);
        public override Color ImageMarginGradientBegin => Color.FromArgb(30, 41, 59);
        public override Color ImageMarginGradientMiddle => Color.FromArgb(30, 41, 59);
        public override Color ImageMarginGradientEnd => Color.FromArgb(30, 41, 59);
        public override Color MenuItemSelectedGradientBegin => Color.FromArgb(37, 99, 235);
        public override Color MenuItemSelectedGradientEnd => Color.FromArgb(37, 99, 235);
        public override Color MenuItemPressedGradientBegin => Color.FromArgb(29, 78, 216);
        public override Color MenuItemPressedGradientMiddle => Color.FromArgb(29, 78, 216);
        public override Color MenuItemPressedGradientEnd => Color.FromArgb(29, 78, 216);
        public override Color SeparatorDark => Color.FromArgb(51, 65, 85);
        public override Color SeparatorLight => Color.FromArgb(51, 65, 85);
    }

    public class ModernMenuRenderer : ToolStripProfessionalRenderer
    {
        public ModernMenuRenderer() : base(new ModernColorTable()) { }

        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            e.TextColor = Color.White;
            base.OnRenderItemText(e);
        }
    }

    public class ModernToolStripColorTable : ProfessionalColorTable
    {
        public override Color ToolStripGradientBegin => Color.White;
        public override Color ToolStripGradientMiddle => Color.White;
        public override Color ToolStripGradientEnd => Color.White;
        public override Color ToolStripBorder => Color.FromArgb(226, 232, 240);
        public override Color ButtonSelectedHighlight => Color.FromArgb(239, 246, 255);
        public override Color ButtonSelectedGradientBegin => Color.FromArgb(239, 246, 255);
        public override Color ButtonSelectedGradientMiddle => Color.FromArgb(239, 246, 255);
        public override Color ButtonSelectedGradientEnd => Color.FromArgb(239, 246, 255);
        public override Color ButtonSelectedBorder => Color.FromArgb(191, 219, 254);
        public override Color ButtonPressedHighlight => Color.FromArgb(219, 234, 254);
        public override Color ButtonPressedGradientBegin => Color.FromArgb(219, 234, 254);
        public override Color ButtonPressedGradientMiddle => Color.FromArgb(219, 234, 254);
        public override Color ButtonPressedGradientEnd => Color.FromArgb(219, 234, 254);
        public override Color ButtonPressedBorder => Color.FromArgb(147, 197, 253);
    }

    public class ModernToolStripRenderer : ToolStripProfessionalRenderer
    {
        public ModernToolStripRenderer() : base(new ModernToolStripColorTable()) { }

        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            e.TextColor = Color.FromArgb(30, 41, 59);
            base.OnRenderItemText(e);
        }
    }

    public class ModernStatusStripColorTable : ProfessionalColorTable
    {
        public override Color StatusStripGradientBegin => Color.FromArgb(15, 23, 42);
        public override Color StatusStripGradientEnd => Color.FromArgb(15, 23, 42);
    }

    public class ModernStatusStripRenderer : ToolStripProfessionalRenderer
    {
        public ModernStatusStripRenderer() : base(new ModernStatusStripColorTable()) { }

        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            e.TextColor = Color.FromArgb(226, 232, 240);
            base.OnRenderItemText(e);
        }
    }
}
