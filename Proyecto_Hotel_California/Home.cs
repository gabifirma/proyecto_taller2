using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proyecto_Hotel_California.Styles;
using HotelCalifornia;

namespace Proyecto_Hotel_California
{
    public partial class Home : Form
    {
        private Timer resizeTimer;
        
        public Home()
        {
            InitializeComponent();
            ApplyStyles();
            
            // Eventos para auto-adaptación (simplificados para reducir parpadeo)
            this.Resize += Home_Resize;
            this.ParentChanged += Home_ParentChanged;
            
            LoadStatistics();
        }
        
        private void Home_ParentChanged(object sender, EventArgs e)
        {
            // Cuando se agrega a un contenedor padre, refrescar
            if (this.Parent != null)
            {
                RefreshLayoutDelayed();
            }
        }
        
        private Size lastSize = Size.Empty;
        private bool isRefreshing = false;
        
        private void Home_Layout(object sender, LayoutEventArgs e)
        {
            // Solo refrescar si realmente cambió el tamaño y no estamos ya refrescando
            if (!isRefreshing && this.Size != lastSize && this.Size.Width > 0 && this.Size.Height > 0)
            {
                RefreshLayoutDelayed();
            }
        }
        
        private void RefreshLayout()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(RefreshLayout));
                return;
            }
            
            if (isRefreshing) return; // Evitar múltiples refresh simultáneos
            
            isRefreshing = true;
            lastSize = this.Size;
            
            try
            {
                this.SuspendLayout();
                
                // Solo limpiar si hay controles
                if (this.Controls.Count > 0)
                {
                    this.Controls.Clear();
                }
                
                LoadStatistics();
                this.ResumeLayout(false);
                this.PerformLayout();
            }
            finally
            {
                isRefreshing = false;
            }
        }
        
        private void RefreshLayoutDelayed()
        {
            // Usar un timer para evitar múltiples redraws
            if (resizeTimer != null)
            {
                resizeTimer.Stop();
                resizeTimer.Dispose();
            }
            
            resizeTimer = new Timer();
            resizeTimer.Interval = 200; // Aumentar delay para reducir parpadeo
            resizeTimer.Tick += (s, args) =>
            {
                resizeTimer.Stop();
                resizeTimer.Dispose();
                resizeTimer = null;
                
                RefreshLayout();
            };
            resizeTimer.Start();
        }

        private void Home_Resize(object sender, EventArgs e)
        {
            // Solo refrescar si el cambio es significativo para evitar parpadeo
            if (!isRefreshing && this.Size.Width > 0 && this.Size.Height > 0)
            {
                if (lastSize.IsEmpty || 
                    Math.Abs(this.Size.Width - lastSize.Width) > 20 || 
                    Math.Abs(this.Size.Height - lastSize.Height) > 20)
                {
                    RefreshLayoutDelayed();
                }
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            // Asegurar que se cargue correctamente al abrir
            RefreshLayout();
        }
        
        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {
            base.SetBoundsCore(x, y, width, height, specified);
            
            // Solo refrescar si realmente cambió el tamaño significativamente
            if ((specified & BoundsSpecified.Size) != 0 && !isRefreshing)
            {
                Size newSize = new Size(width, height);
                if (Math.Abs(newSize.Width - lastSize.Width) > 10 || Math.Abs(newSize.Height - lastSize.Height) > 10)
                {
                    RefreshLayoutDelayed();
                }
            }
        }
        
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            
            // Solo refrescar si el cambio es significativo
            if (!isRefreshing && this.Size != lastSize)
            {
                if (Math.Abs(this.Size.Width - lastSize.Width) > 10 || Math.Abs(this.Size.Height - lastSize.Height) > 10)
                {
                    RefreshLayoutDelayed();
                }
            }
        }

        private void ApplyStyles()
        {
            // Configurar para reducir parpadeo
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | 
                         ControlStyles.UserPaint | 
                         ControlStyles.DoubleBuffer | 
                         ControlStyles.ResizeRedraw, true);
            
            AppStyles.ApplyFormStyle(this);
            
            // Aplicar estilos específicos para el dashboard
            this.WindowState = FormWindowState.Maximized;
            this.Dock = DockStyle.Fill;
            
            // Habilitar scroll automático
            this.AutoScroll = true;
            this.AutoScrollMinSize = new Size(800, 700); // Tamaño mínimo para activar scroll
        }

        private void LoadStatistics()
        {
            // Estadísticas ficticias para el dashboard
            try
            {
                // Ocultar elementos no necesarios
                pictureBox1.Visible = false;
                button1.Visible = false;
                button2.Visible = false;
                
                // Crear título centrado con rol del usuario
                CreateCenteredHeader();
                
                // Crear estadísticas con gráficos
                CreateStatisticsWithCharts();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar estadísticas: {ex.Message}", "Error", 
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CreateCenteredHeader()
        {
            // Obtener información del usuario actual
            string userRole = GetCurrentUserRole();
            string userName = GetCurrentUserName();
            
            // Calcular dimensiones responsive considerando el scroll
            int clientWidth = this.AutoScroll ? this.ClientSize.Width : this.Width;
            int headerWidth = Math.Min(800, clientWidth - 100); // Máximo 800px, mínimo deja 50px a cada lado
            int headerHeight = 160;
            int startY = 20; // Posición fija para consistencia
            
            // Crear panel contenedor centrado
            Panel headerPanel = new Panel();
            headerPanel.Size = new Size(headerWidth, headerHeight);
            headerPanel.Location = new Point((clientWidth - headerWidth) / 2, startY);
            headerPanel.Anchor = AnchorStyles.Top;
            
            // Título principal
            Label lblWelcome = new Label();
            lblWelcome.Text = "Bienvenido al Sistema Hotel California";
            lblWelcome.Size = new Size(headerWidth, 45);
            lblWelcome.Location = new Point(0, 0);
            lblWelcome.TextAlign = ContentAlignment.MiddleCenter;
            AppStyles.ApplyTitleStyle(lblWelcome);
            lblWelcome.AutoSize = false;
            
            // Nombre del usuario
            Label lblUserName = new Label();
            lblUserName.Text = $"Usuario: {userName}";
            lblUserName.Size = new Size(headerWidth, 30);
            lblUserName.Location = new Point(0, 50);
            lblUserName.TextAlign = ContentAlignment.MiddleCenter;
            AppStyles.ApplySubtitleStyle(lblUserName);
            lblUserName.ForeColor = AppStyles.PrimaryColor;
            lblUserName.AutoSize = false;
            
            // Rol del usuario
            Label lblRole = new Label();
            lblRole.Text = $"Perfil: {userRole}";
            lblRole.Size = new Size(headerWidth, 30);
            lblRole.Location = new Point(0, 85);
            lblRole.TextAlign = ContentAlignment.MiddleCenter;
            AppStyles.ApplyHeaderStyle(lblRole);
            lblRole.ForeColor = AppStyles.SecondaryColor;
            lblRole.AutoSize = false;
            
            // Fecha y hora
            Label lblDateTime = new Label();
            lblDateTime.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy - HH:mm");
            lblDateTime.Size = new Size(headerWidth, 25);
            lblDateTime.Location = new Point(0, 120);
            lblDateTime.TextAlign = ContentAlignment.MiddleCenter;
            AppStyles.ApplyBodyStyle(lblDateTime);
            lblDateTime.ForeColor = AppStyles.TextSecondaryColor;
            lblDateTime.AutoSize = false;
            
            headerPanel.Controls.Add(lblWelcome);
            headerPanel.Controls.Add(lblUserName);
            headerPanel.Controls.Add(lblRole);
            headerPanel.Controls.Add(lblDateTime);
            
            this.Controls.Add(headerPanel);
        }

        private string GetCurrentUserName()
        {
            // Obtener el nombre real del usuario actual desde UserSession
            try
            {
                if (UserSession.IsLoggedIn)
                {
                    return UserSession.GetUserDisplayName();
                }
                else
                {
                    return "Usuario no identificado";
                }
            }
            catch (Exception)
            {
                // Si hay algún error, mostrar nombre por defecto
                return "Usuario";
            }
        }

        private string GetCurrentUserRole()
        {
            // Obtener el rol real del usuario actual desde UserSession
            try
            {
                if (UserSession.IsLoggedIn)
                {
                    return UserSession.GetUserRole();
                }
                else
                {
                    return "Usuario no autenticado";
                }
            }
            catch (Exception)
            {
                // Si hay algún error, mostrar rol por defecto
                return "Usuario";
            }
        }

        private void CreateStatisticsWithCharts()
        {
            // Calcular dimensiones responsive considerando el scroll
            int clientWidth = this.AutoScroll ? this.ClientSize.Width : this.Width;
            int availableWidth = clientWidth - 80; // Dejar 40px de margen a cada lado
            int maxPanelWidth = 300;
            int minPanelWidth = 250;
            
            // Determinar cuántos paneles por fila según el ancho disponible
            int panelsPerRow = Math.Max(1, Math.Min(3, availableWidth / (minPanelWidth + 20)));
            int panelWidth = Math.Min(maxPanelWidth, (availableWidth - (20 * (panelsPerRow - 1))) / panelsPerRow);
            int panelHeight = 220;
            int spacing = 20;
            
            // Calcular posición inicial
            int totalRowWidth = (panelWidth * panelsPerRow) + (spacing * (panelsPerRow - 1));
            int startX = (clientWidth - totalRowWidth) / 2;
            int startY = 240; // Posición fija para consistencia
            
            // Datos de los paneles
            var panelData = new[]
            {
                new { Title = "📋 RESERVAS", Stat1 = "Total: 45", Stat2 = "Activas: 28", Stat3 = "Pendientes: 17", Values = new int[] { 28, 17 }, Labels = new string[] { "Activas", "Pendientes" } },
                new { Title = "💰 PAGOS", Stat1 = "Total: 38", Stat2 = "Completados: 25", Stat3 = "Pendientes: 13", Values = new int[] { 25, 13 }, Labels = new string[] { "Completados", "Pendientes" } },
                new { Title = "🏨 HABITACIONES", Stat1 = "Total: 50", Stat2 = "Disponibles: 22", Stat3 = "Ocupadas: 28", Values = new int[] { 22, 28 }, Labels = new string[] { "Disponibles", "Ocupadas" } },
                new { Title = "📊 INGRESOS", Stat1 = "Mes: $125,450", Stat2 = "Año: $1,250,000", Stat3 = "Prom: $41,500", Values = new int[] { 125, 1250, 415 }, Labels = new string[] { "Mes", "Año", "Prom" } },
                new { Title = "👥 CLIENTES", Stat1 = "Total: 156", Stat2 = "Nuevos: 12", Stat3 = "VIP: 8", Values = new int[] { 136, 12, 8 }, Labels = new string[] { "Regulares", "Nuevos", "VIP" } },
                new { Title = "⭐ OCUPACIÓN", Stat1 = "Promedio: 78%", Stat2 = "Fin sem: 95%", Stat3 = "Entre sem: 65%", Values = new int[] { 78, 95, 65 }, Labels = new string[] { "Promedio", "Fin sem", "Entre sem" } }
            };
            
            // Calcular número de filas necesarias
            int totalRows = (int)Math.Ceiling((double)panelData.Length / panelsPerRow);
            
            // Crear paneles dinámicamente
            for (int i = 0; i < panelData.Length; i++)
            {
                int row = i / panelsPerRow;
                int col = i % panelsPerRow;
                
                // Recalcular startX para cada fila si no está completa
                int panelsInThisRow = Math.Min(panelsPerRow, panelData.Length - (row * panelsPerRow));
                int thisRowWidth = (panelWidth * panelsInThisRow) + (spacing * (panelsInThisRow - 1));
                int thisRowStartX = (clientWidth - thisRowWidth) / 2;
                
                int x = thisRowStartX + (col * (panelWidth + spacing));
                int y = startY + (row * (panelHeight + spacing));
                
                var data = panelData[i];
                CreateStatisticsPanelWithChart(data.Title, data.Stat1, data.Stat2, data.Stat3, 
                                             x, y, panelWidth, panelHeight, data.Values, data.Labels);
            }
            
            // Calcular altura total necesaria y actualizar AutoScrollMinSize
            int totalHeight = startY + (totalRows * panelHeight) + ((totalRows - 1) * spacing) + 50; // +50 para margen inferior
            this.AutoScrollMinSize = new Size(800, totalHeight);
        }

        private void CreateStatisticsPanel(string title, string stat1, string stat2, string stat3, int x, int y)
        {
            Panel panel = new Panel();
            panel.Size = new Size(220, 150);
            panel.Location = new Point(x, y);
            AppStyles.ApplyPanelStyle(panel);
            panel.BorderStyle = BorderStyle.FixedSingle;

            Label lblTitle = new Label();
            lblTitle.Text = title;
            lblTitle.Location = new Point(10, 10);
            lblTitle.Size = new Size(200, 25);
            AppStyles.ApplyHeaderStyle(lblTitle);
            lblTitle.ForeColor = AppStyles.PrimaryColor;

            Label lblStat1 = new Label();
            lblStat1.Text = stat1;
            lblStat1.Location = new Point(15, 45);
            lblStat1.Size = new Size(190, 20);
            AppStyles.ApplyBodyStyle(lblStat1);

            Label lblStat2 = new Label();
            lblStat2.Text = stat2;
            lblStat2.Location = new Point(15, 70);
            lblStat2.Size = new Size(190, 20);
            AppStyles.ApplyBodyStyle(lblStat2);

            Label lblStat3 = new Label();
            lblStat3.Text = stat3;
            lblStat3.Location = new Point(15, 95);
            lblStat3.Size = new Size(190, 20);
            AppStyles.ApplyBodyStyle(lblStat3);

            panel.Controls.Add(lblTitle);
            panel.Controls.Add(lblStat1);
            panel.Controls.Add(lblStat2);
            panel.Controls.Add(lblStat3);

            this.Controls.Add(panel);
        }

        private void CreateStatisticsPanelWithChart(string title, string stat1, string stat2, string stat3, 
                                                   int x, int y, int width, int height, int[] values, string[] labels)
        {
            Panel panel = new Panel();
            panel.Size = new Size(width, height);
            panel.Location = new Point(x, y);
            AppStyles.ApplyPanelStyle(panel);
            panel.BorderStyle = BorderStyle.FixedSingle;

            // Título del panel
            Label lblTitle = new Label();
            lblTitle.Text = title;
            lblTitle.Location = new Point(10, 10);
            lblTitle.Size = new Size(width - 20, 30);
            AppStyles.ApplyHeaderStyle(lblTitle);
            lblTitle.ForeColor = AppStyles.PrimaryColor;
            lblTitle.AutoSize = false;
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;

            // Estadísticas de texto
            Label lblStat1 = new Label();
            lblStat1.Text = stat1;
            lblStat1.Location = new Point(15, 45);
            lblStat1.Size = new Size((width - 30) / 2, 22);
            AppStyles.ApplyBodyStyle(lblStat1);
            lblStat1.AutoSize = false;

            Label lblStat2 = new Label();
            lblStat2.Text = stat2;
            lblStat2.Location = new Point(15, 70);
            lblStat2.Size = new Size((width - 30) / 2, 22);
            AppStyles.ApplyBodyStyle(lblStat2);
            lblStat2.AutoSize = false;

            Label lblStat3 = new Label();
            lblStat3.Text = stat3;
            lblStat3.Location = new Point(15, 95);
            lblStat3.Size = new Size((width - 30) / 2, 22);
            AppStyles.ApplyBodyStyle(lblStat3);
            lblStat3.AutoSize = false;

            // Crear gráfico simple responsive
            Panel chartPanel = new Panel();
            int chartWidth = width - 30;
            int chartHeight = height - 135;
            chartPanel.Size = new Size(chartWidth, chartHeight);
            chartPanel.Location = new Point(15, 125);
            chartPanel.BackColor = Color.White;
            chartPanel.BorderStyle = BorderStyle.FixedSingle;
            chartPanel.Paint += (sender, e) => DrawSimpleChart(e.Graphics, values, labels, chartPanel.Size);

            panel.Controls.Add(lblTitle);
            panel.Controls.Add(lblStat1);
            panel.Controls.Add(lblStat2);
            panel.Controls.Add(lblStat3);
            panel.Controls.Add(chartPanel);

            this.Controls.Add(panel);
        }

        private void DrawSimpleChart(Graphics g, int[] values, string[] labels, Size size)
        {
            if (values == null || values.Length == 0) return;

            // Colores para las barras
            Color[] colors = { AppStyles.PrimaryColor, AppStyles.SecondaryColor, AppStyles.AccentColor, 
                             AppStyles.SuccessColor, AppStyles.WarningColor, AppStyles.ErrorColor };

            int maxValue = values.Max();
            if (maxValue == 0) maxValue = 1;

            int barWidth = (size.Width - 40) / values.Length;
            int chartHeight = size.Height - 30;

            for (int i = 0; i < values.Length; i++)
            {
                int barHeight = (int)((double)values[i] / maxValue * chartHeight);
                int x = 20 + (i * barWidth);
                int y = size.Height - barHeight - 15;

                // Dibujar barra
                using (Brush brush = new SolidBrush(colors[i % colors.Length]))
                {
                    g.FillRectangle(brush, x, y, barWidth - 5, barHeight);
                }

                // Dibujar valor encima de la barra
                using (Font font = new Font("Segoe UI", 8))
                using (Brush textBrush = new SolidBrush(AppStyles.TextPrimaryColor))
                {
                    string valueText = values[i].ToString();
                    SizeF textSize = g.MeasureString(valueText, font);
                    g.DrawString(valueText, font, textBrush, 
                               x + (barWidth - textSize.Width) / 2, y - 15);
                }
            }
        }

        public void RefreshStatistics()
        {
            RefreshLayout();
        }
        
        // Método para forzar actualización desde el formulario padre
        public void ForceRefresh()
        {
            // Forzar refresh inmediato
            RefreshLayout();
        }
        
        // Cleanup del timer cuando se cierra el formulario
        private void CleanupTimer()
        {
            if (resizeTimer != null)
            {
                resizeTimer.Stop();
                resizeTimer.Dispose();
                resizeTimer = null;
            }
        }
        
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            CleanupTimer();
            base.OnFormClosed(e);
        }
    }
}
