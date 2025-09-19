using System.Drawing;
using System.Windows.Forms;

namespace Proyecto_Hotel_California.Styles
{
    public static class AppStyles
    {
        // Paleta de colores principal
        public static readonly Color PrimaryColor = Color.FromArgb(0, 128, 128);      // Teal
        public static readonly Color SecondaryColor = Color.FromArgb(70, 130, 180);   // SteelBlue
        public static readonly Color AccentColor = Color.FromArgb(255, 140, 0);       // DarkOrange
        public static readonly Color BackgroundColor = Color.FromArgb(248, 249, 250); // Light Gray
        public static readonly Color SurfaceColor = Color.White;
        public static readonly Color TextPrimaryColor = Color.FromArgb(33, 37, 41);   // Dark Gray
        public static readonly Color TextSecondaryColor = Color.FromArgb(108, 117, 125); // Medium Gray
        public static readonly Color SuccessColor = Color.FromArgb(40, 167, 69);      // Green
        public static readonly Color WarningColor = Color.FromArgb(255, 193, 7);      // Yellow
        public static readonly Color ErrorColor = Color.FromArgb(220, 53, 69);        // Red

        // Tipografías
        public static readonly Font TitleFont = new Font("Segoe UI", 18F, FontStyle.Bold);
        public static readonly Font SubtitleFont = new Font("Segoe UI", 14F, FontStyle.Bold);
        public static readonly Font HeaderFont = new Font("Segoe UI", 12F, FontStyle.Bold);
        public static readonly Font BodyFont = new Font("Segoe UI", 10F, FontStyle.Regular);
        public static readonly Font SmallFont = new Font("Segoe UI", 9F, FontStyle.Regular);
        public static readonly Font ButtonFont = new Font("Segoe UI", 10F, FontStyle.Bold);

        // Métodos para aplicar estilos a controles
        public static void ApplyFormStyle(Form form)
        {
            form.BackColor = BackgroundColor;
            form.Font = BodyFont;
            form.ForeColor = TextPrimaryColor;
        }

        public static void ApplyTitleStyle(Label label)
        {
            label.Font = TitleFont;
            label.ForeColor = PrimaryColor;
            label.BackColor = Color.Transparent;
        }

        public static void ApplySubtitleStyle(Label label)
        {
            label.Font = SubtitleFont;
            label.ForeColor = TextPrimaryColor;
            label.BackColor = Color.Transparent;
        }

        public static void ApplyHeaderStyle(Label label)
        {
            label.Font = HeaderFont;
            label.ForeColor = TextPrimaryColor;
            label.BackColor = Color.Transparent;
        }

        public static void ApplyBodyStyle(Label label)
        {
            label.Font = BodyFont;
            label.ForeColor = TextPrimaryColor;
            label.BackColor = Color.Transparent;
        }

        public static void ApplyPrimaryButtonStyle(Button button)
        {
            button.BackColor = PrimaryColor;
            button.ForeColor = Color.White;
            button.Font = ButtonFont;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.Cursor = Cursors.Hand;
        }

        public static void ApplySecondaryButtonStyle(Button button)
        {
            button.BackColor = SecondaryColor;
            button.ForeColor = Color.White;
            button.Font = ButtonFont;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.Cursor = Cursors.Hand;
        }

        public static void ApplySuccessButtonStyle(Button button)
        {
            button.BackColor = SuccessColor;
            button.ForeColor = Color.White;
            button.Font = ButtonFont;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.Cursor = Cursors.Hand;
        }

        public static void ApplyWarningButtonStyle(Button button)
        {
            button.BackColor = WarningColor;
            button.ForeColor = TextPrimaryColor;
            button.Font = ButtonFont;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.Cursor = Cursors.Hand;
        }

        public static void ApplyErrorButtonStyle(Button button)
        {
            button.BackColor = ErrorColor;
            button.ForeColor = Color.White;
            button.Font = ButtonFont;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.Cursor = Cursors.Hand;
        }

        public static void ApplyTextBoxStyle(TextBox textBox)
        {
            textBox.Font = BodyFont;
            textBox.BackColor = SurfaceColor;
            textBox.ForeColor = TextPrimaryColor;
            textBox.BorderStyle = BorderStyle.FixedSingle;
        }

        public static void ApplyComboBoxStyle(ComboBox comboBox)
        {
            comboBox.Font = BodyFont;
            comboBox.BackColor = SurfaceColor;
            comboBox.ForeColor = TextPrimaryColor;
            comboBox.FlatStyle = FlatStyle.Flat;
        }

        public static void ApplyDataGridViewStyle(DataGridView dataGridView)
        {
            dataGridView.BackgroundColor = SurfaceColor;
            dataGridView.GridColor = Color.FromArgb(224, 224, 224);
            dataGridView.Font = BodyFont;
            dataGridView.ForeColor = TextPrimaryColor;
            dataGridView.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 123, 255, 50);
            dataGridView.DefaultCellStyle.SelectionForeColor = TextPrimaryColor;
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = PrimaryColor;
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView.ColumnHeadersDefaultCellStyle.Font = HeaderFont;
            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.BorderStyle = BorderStyle.None;
            dataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView.RowHeadersVisible = false;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.ReadOnly = true;
            dataGridView.MultiSelect = false;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        public static void ApplyGroupBoxStyle(GroupBox groupBox)
        {
            groupBox.Font = HeaderFont;
            groupBox.ForeColor = TextPrimaryColor;
            groupBox.BackColor = Color.Transparent;
        }

        public static void ApplyPanelStyle(Panel panel)
        {
            panel.BackColor = SurfaceColor;
            panel.BorderStyle = BorderStyle.FixedSingle;
        }
    }
}
