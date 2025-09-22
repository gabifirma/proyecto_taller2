using System.Drawing;
using System.Windows.Forms;

namespace HotelCalifornia.Styles
{
    /// <summary>
    /// Clase estática que define todos los estilos visuales de la aplicación Hotel California.
    /// Centraliza colores, fuentes y métodos para aplicar estilos consistentes en toda la aplicación.
    /// </summary>
    public static class AppStyles
    {
        #region Paleta de Colores

        /// <summary>Color principal de la aplicación (Verde azulado)</summary>
        public static readonly Color PrimaryColor = Color.FromArgb(0, 128, 128);      // Teal
        
        /// <summary>Color secundario de la aplicación (Azul acero)</summary>
        public static readonly Color SecondaryColor = Color.FromArgb(70, 130, 180);   // SteelBlue
        
        /// <summary>Color de acento para elementos destacados (Naranja oscuro)</summary>
        public static readonly Color AccentColor = Color.FromArgb(255, 140, 0);       // DarkOrange
        
        /// <summary>Color de fondo principal de la aplicación (Gris claro)</summary>
        public static readonly Color BackgroundColor = Color.FromArgb(248, 249, 250); // Light Gray
        
        /// <summary>Color de superficie para paneles y tarjetas (Blanco)</summary>
        public static readonly Color SurfaceColor = Color.White;
        
        /// <summary>Color de texto principal (Gris oscuro)</summary>
        public static readonly Color TextPrimaryColor = Color.FromArgb(33, 37, 41);   // Dark Gray
        
        /// <summary>Color de texto secundario (Gris medio)</summary>
        public static readonly Color TextSecondaryColor = Color.FromArgb(108, 117, 125); // Medium Gray
        
        /// <summary>Color para indicar éxito o estados positivos (Verde)</summary>
        public static readonly Color SuccessColor = Color.FromArgb(40, 167, 69);      // Green
        
        /// <summary>Color para advertencias (Amarillo)</summary>
        public static readonly Color WarningColor = Color.FromArgb(255, 193, 7);      // Yellow
        
        /// <summary>Color para errores o estados negativos (Rojo)</summary>
        public static readonly Color ErrorColor = Color.FromArgb(220, 53, 69);        // Red

        #endregion

        #region Tipografías

        /// <summary>Fuente para títulos principales</summary>
        public static readonly Font TitleFont = new Font("Segoe UI", 18F, FontStyle.Bold);
        
        /// <summary>Fuente para subtítulos</summary>
        public static readonly Font SubtitleFont = new Font("Segoe UI", 14F, FontStyle.Bold);
        
        /// <summary>Fuente para encabezados de sección</summary>
        public static readonly Font HeaderFont = new Font("Segoe UI", 12F, FontStyle.Bold);
        
        /// <summary>Fuente para texto del cuerpo</summary>
        public static readonly Font BodyFont = new Font("Segoe UI", 10F, FontStyle.Regular);
        
        /// <summary>Fuente para texto pequeño</summary>
        public static readonly Font SmallFont = new Font("Segoe UI", 9F, FontStyle.Regular);
        
        /// <summary>Fuente para botones</summary>
        public static readonly Font ButtonFont = new Font("Segoe UI", 10F, FontStyle.Bold);

        #endregion

        #region Métodos de Aplicación de Estilos

        /// <summary>
        /// Aplica el estilo base a un formulario
        /// </summary>
        /// <param name="form">Formulario al que aplicar el estilo</param>
        public static void ApplyFormStyle(Form form)
        {
            form.BackColor = BackgroundColor;
            form.Font = BodyFont;
            form.ForeColor = TextPrimaryColor;
        }

        /// <summary>
        /// Aplica el estilo de título a una etiqueta
        /// </summary>
        /// <param name="label">Etiqueta a la que aplicar el estilo</param>
        public static void ApplyTitleStyle(Label label)
        {
            label.Font = TitleFont;
            label.ForeColor = PrimaryColor;
            label.BackColor = Color.Transparent;
        }

        /// <summary>
        /// Aplica el estilo de subtítulo a una etiqueta
        /// </summary>
        /// <param name="label">Etiqueta a la que aplicar el estilo</param>
        public static void ApplySubtitleStyle(Label label)
        {
            label.Font = SubtitleFont;
            label.ForeColor = TextPrimaryColor;
            label.BackColor = Color.Transparent;
        }

        /// <summary>
        /// Aplica el estilo de encabezado a una etiqueta
        /// </summary>
        /// <param name="label">Etiqueta a la que aplicar el estilo</param>
        public static void ApplyHeaderStyle(Label label)
        {
            label.Font = HeaderFont;
            label.ForeColor = TextPrimaryColor;
            label.BackColor = Color.Transparent;
        }

        /// <summary>
        /// Aplica el estilo de texto del cuerpo a una etiqueta
        /// </summary>
        /// <param name="label">Etiqueta a la que aplicar el estilo</param>
        public static void ApplyBodyStyle(Label label)
        {
            label.Font = BodyFont;
            label.ForeColor = TextPrimaryColor;
            label.BackColor = Color.Transparent;
        }

        /// <summary>
        /// Aplica el estilo principal a un botón (color primario)
        /// </summary>
        /// <param name="button">Botón al que aplicar el estilo</param>
        public static void ApplyPrimaryButtonStyle(Button button)
        {
            button.BackColor = PrimaryColor;
            button.ForeColor = Color.White;
            button.Font = ButtonFont;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.Cursor = Cursors.Hand;
        }

        /// <summary>
        /// Aplica el estilo secundario a un botón (color secundario)
        /// </summary>
        /// <param name="button">Botón al que aplicar el estilo</param>
        public static void ApplySecondaryButtonStyle(Button button)
        {
            button.BackColor = SecondaryColor;
            button.ForeColor = Color.White;
            button.Font = ButtonFont;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.Cursor = Cursors.Hand;
        }

        /// <summary>
        /// Aplica el estilo de éxito a un botón (color verde)
        /// </summary>
        /// <param name="button">Botón al que aplicar el estilo</param>
        public static void ApplySuccessButtonStyle(Button button)
        {
            button.BackColor = SuccessColor;
            button.ForeColor = Color.White;
            button.Font = ButtonFont;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.Cursor = Cursors.Hand;
        }

        /// <summary>
        /// Aplica el estilo de advertencia a un botón (color amarillo)
        /// </summary>
        /// <param name="button">Botón al que aplicar el estilo</param>
        public static void ApplyWarningButtonStyle(Button button)
        {
            button.BackColor = WarningColor;
            button.ForeColor = TextPrimaryColor;
            button.Font = ButtonFont;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.Cursor = Cursors.Hand;
        }

        /// <summary>
        /// Aplica el estilo de error a un botón (color rojo)
        /// </summary>
        /// <param name="button">Botón al que aplicar el estilo</param>
        public static void ApplyErrorButtonStyle(Button button)
        {
            button.BackColor = ErrorColor;
            button.ForeColor = Color.White;
            button.Font = ButtonFont;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.Cursor = Cursors.Hand;
        }

        /// <summary>
        /// Aplica el estilo estándar a una caja de texto
        /// </summary>
        /// <param name="textBox">Caja de texto a la que aplicar el estilo</param>
        public static void ApplyTextBoxStyle(TextBox textBox)
        {
            textBox.Font = BodyFont;
            textBox.BackColor = SurfaceColor;
            textBox.ForeColor = TextPrimaryColor;
            textBox.BorderStyle = BorderStyle.FixedSingle;
        }

        /// <summary>
        /// Aplica el estilo estándar a un ComboBox
        /// </summary>
        /// <param name="comboBox">ComboBox al que aplicar el estilo</param>
        public static void ApplyComboBoxStyle(ComboBox comboBox)
        {
            comboBox.Font = BodyFont;
            comboBox.BackColor = SurfaceColor;
            comboBox.ForeColor = TextPrimaryColor;
            comboBox.FlatStyle = FlatStyle.Flat;
        }

        /// <summary>
        /// Aplica el estilo estándar a un DataGridView con configuración completa
        /// </summary>
        /// <param name="dataGridView">DataGridView al que aplicar el estilo</param>
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

        /// <summary>
        /// Aplica el estilo estándar a un GroupBox
        /// </summary>
        /// <param name="groupBox">GroupBox al que aplicar el estilo</param>
        public static void ApplyGroupBoxStyle(GroupBox groupBox)
        {
            groupBox.Font = HeaderFont;
            groupBox.ForeColor = TextPrimaryColor;
            groupBox.BackColor = Color.Transparent;
        }

        /// <summary>
        /// Aplica el estilo estándar a un Panel
        /// </summary>
        /// <param name="panel">Panel al que aplicar el estilo</param>
        public static void ApplyPanelStyle(Panel panel)
        {
            panel.BackColor = SurfaceColor;
            panel.BorderStyle = BorderStyle.FixedSingle;
        }

        #endregion
    }
}
