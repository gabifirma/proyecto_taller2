using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HotelCalifornia;
using HotelCalifornia.Styles;

namespace HotelCalifornia
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            ApplyStyles();
            ConfigureMenuByRole();
            UpdateHeader();
            DatabaseHelper.InitializeDatabase();
        }

        private void ApplyStyles()
        {
            AppStyles.ApplyFormStyle(this);
        }

        private void abrirFormHIjo(object formhijo)
        {
            if (this.PContenedor.Controls.Count > 0)
                this.PContenedor.Controls.RemoveAt(0);
            Form fh = formhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.PContenedor.Controls.Add(fh);
            this.PContenedor.Tag = fh;
            fh.Show();
            
            // Home form functionality removed - form doesn't exist
        }

        private void BInicio_Click(object sender, EventArgs e)
        {
            // Clear the container - show main dashboard
            if (this.PContenedor.Controls.Count > 0)
                this.PContenedor.Controls.RemoveAt(0);
            
            // Crear y mostrar panel de estadísticas
            MostrarPanelEstadisticas();
        }

        private void MostrarPanelEstadisticas()
        {
            // Crear panel principal para las estadísticas
            Panel panelStats = new Panel();
            panelStats.Dock = DockStyle.Fill;
            panelStats.BackColor = AppStyles.BackgroundColor;
            
            // Título principal
            Label lblTitulo = new Label();
            lblTitulo.Text = "Dashboard - Hotel California";
            lblTitulo.Font = AppStyles.TitleFont;
            lblTitulo.ForeColor = AppStyles.PrimaryColor;
            lblTitulo.Location = new Point(30, 20);
            lblTitulo.Size = new Size(400, 40);
            panelStats.Controls.Add(lblTitulo);

            // Obtener estadísticas de la base de datos
            var stats = ObtenerEstadisticas();

            // Panel para las tarjetas de estadísticas
            Panel panelTarjetas = new Panel();
            panelTarjetas.Location = new Point(30, 80);
            panelTarjetas.Size = new Size(800, 200);
            panelTarjetas.BackColor = Color.Transparent;

            // Crear tarjetas de estadísticas
            CrearTarjetaEstadistica(panelTarjetas, "Total Reservas", stats.TotalReservas.ToString(), AppStyles.PrimaryColor, new Point(0, 0));
            CrearTarjetaEstadistica(panelTarjetas, "Reservas Activas", stats.ReservasActivas.ToString(), AppStyles.SuccessColor, new Point(200, 0));
            CrearTarjetaEstadistica(panelTarjetas, "Total Clientes", stats.TotalClientes.ToString(), AppStyles.SecondaryColor, new Point(400, 0));
            CrearTarjetaEstadistica(panelTarjetas, "Habitaciones Ocupadas", stats.HabitacionesOcupadas.ToString(), AppStyles.AccentColor, new Point(600, 0));

            panelStats.Controls.Add(panelTarjetas);

            // Panel para información adicional
            Panel panelInfo = new Panel();
            panelInfo.Location = new Point(30, 300);
            panelInfo.Size = new Size(800, 150);
            panelInfo.BackColor = AppStyles.SurfaceColor;
            panelInfo.BorderStyle = BorderStyle.FixedSingle;

            Label lblInfo = new Label();
            lblInfo.Text = "Información del Sistema";
            lblInfo.Font = AppStyles.SubtitleFont;
            lblInfo.ForeColor = AppStyles.TextPrimaryColor;
            lblInfo.Location = new Point(20, 10);
            lblInfo.Size = new Size(300, 30);
            panelInfo.Controls.Add(lblInfo);

            Label lblDetalles = new Label();
            lblDetalles.Text = $"Usuario: {UserSession.CurrentUser?.NombreCompleto ?? "N/A"}\n" +
                              $"Rol: {UserSession.CurrentUser?.TipoUsuario ?? "N/A"}\n" +
                              $"Fecha: {DateTime.Now:dd/MM/yyyy HH:mm}";
            lblDetalles.Font = AppStyles.BodyFont;
            lblDetalles.ForeColor = AppStyles.TextSecondaryColor;
            lblDetalles.Location = new Point(20, 50);
            lblDetalles.Size = new Size(300, 80);
            panelInfo.Controls.Add(lblDetalles);

            panelStats.Controls.Add(panelInfo);

            // Agregar el panel al contenedor
            this.PContenedor.Controls.Add(panelStats);
        }

        private void CrearTarjetaEstadistica(Panel contenedor, string titulo, string valor, Color color, Point ubicacion)
        {
            Panel tarjeta = new Panel();
            tarjeta.Size = new Size(180, 120);
            tarjeta.Location = ubicacion;
            tarjeta.BackColor = AppStyles.SurfaceColor;
            tarjeta.BorderStyle = BorderStyle.FixedSingle;

            Label lblTitulo = new Label();
            lblTitulo.Text = titulo;
            lblTitulo.Font = AppStyles.SmallFont;
            lblTitulo.ForeColor = AppStyles.TextSecondaryColor;
            lblTitulo.Location = new Point(10, 10);
            lblTitulo.Size = new Size(160, 20);
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            tarjeta.Controls.Add(lblTitulo);

            Label lblValor = new Label();
            lblValor.Text = valor;
            lblValor.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblValor.ForeColor = color;
            lblValor.Location = new Point(10, 40);
            lblValor.Size = new Size(160, 60);
            lblValor.TextAlign = ContentAlignment.MiddleCenter;
            tarjeta.Controls.Add(lblValor);

            contenedor.Controls.Add(tarjeta);
        }

        private (int TotalReservas, int ReservasActivas, int TotalClientes, int HabitacionesOcupadas) ObtenerEstadisticas()
        {
            try
            {
                // Usar DataService para obtener estadísticas
                var reservas = HotelCalifornia.Services.DataService.GetReservas();
                var totalReservas = reservas.Count;
                var reservasActivas = reservas.Count(r => r.Estado == "Activa" || r.Estado == "Confirmada");

                return (
                    TotalReservas: totalReservas,
                    ReservasActivas: reservasActivas,
                    TotalClientes: ObtenerTotalClientes(),
                    HabitacionesOcupadas: ObtenerHabitacionesOcupadas()
                );
            }
            catch
            {
                // En caso de error, devolver valores por defecto
                return (0, 0, 0, 0);
            }
        }

        private int ObtenerTotalClientes()
        {
            try
            {
                if (!DatabaseHelper.TestConnection()) return 0;
                
                using (var conn = new System.Data.SqlClient.SqlConnection(DatabaseHelper.GetConnectionString()))
                {
                    conn.Open();
                    var cmd = new System.Data.SqlClient.SqlCommand("SELECT COUNT(*) FROM Cliente", conn);
                    return (int)cmd.ExecuteScalar();
                }
            }
            catch
            {
                return 0;
            }
        }

        private int ObtenerHabitacionesOcupadas()
        {
            try
            {
                if (!DatabaseHelper.TestConnection()) return 0;
                
                using (var conn = new System.Data.SqlClient.SqlConnection(DatabaseHelper.GetConnectionString()))
                {
                    conn.Open();
                    var cmd = new System.Data.SqlClient.SqlCommand("SELECT COUNT(*) FROM Habitacion WHERE estado = 'Ocupada'", conn);
                    return (int)cmd.ExecuteScalar();
                }
            }
            catch
            {
                return 0;
            }
        }

        private void BClientes_Click(object sender, EventArgs e)
        {
            abrirFormHIjo(new Clientes());
        }

        private void BEmpleados_Click(object sender, EventArgs e)
        {
            if (!UserSession.HasPermission("supervisor"))
            {
                MessageBox.Show("No tiene permisos para acceder a esta sección.", 
                              "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            abrirFormHIjo(new Empleados());
        }

        private void BHabitaciones_Click(object sender, EventArgs e)
        {
            abrirFormHIjo(new Habitaciones());
        }

        private void BReservas_Click(object sender, EventArgs e)
        {
            abrirFormHIjo(new Reservas());
        }

        private void BPagos_Click(object sender, EventArgs e)
        {
            abrirFormHIjo(new Pagos());
        }

        private void ConfigureMenuByRole()
        {
            if (!UserSession.IsLoggedIn)
            {
                // Si no hay sesión, ocultar todo
                BEmpleados.Visible = false;
                BReservas.Visible = false;
                BPagos.Visible = false;
                BClientes.Visible = false;
                BHabitaciones.Visible = false;
                return;
            }

            string userRole = UserSession.GetUserRole();

            switch (userRole)
            {
                case "Administrador":
                    // Administrador: acceso completo
                    BEmpleados.Visible = true;
                    BReservas.Visible = true;
                    BPagos.Visible = true;
                    BClientes.Visible = true;
                    BHabitaciones.Visible = true;
                    break;

                case "Supervisor":
                    // Supervisor: acceso a empleados y reservas
                    BEmpleados.Visible = false;
                    BReservas.Visible = true;
                    BPagos.Visible = true;
                    BClientes.Visible = true;
                    BHabitaciones.Visible = true;
                    break;

                case "Recepcionista":
                    // Recepcionista: NO ver empleados, sí reservas y pagos
                    BEmpleados.Visible = false;
                    BReservas.Visible = true;
                    BPagos.Visible = false;
                    BClientes.Visible = false;
                    BHabitaciones.Visible = true;
                    break;

                default:
                    // Por defecto, ocultar todo
                    BEmpleados.Visible = false;
                    BReservas.Visible = false;
                    BPagos.Visible = false;
                    BClientes.Visible = false;
                    BHabitaciones.Visible = false;
                    break;
            }
        }

        private void UpdateHeader()
        {
            if (UserSession.IsLoggedIn)
            {
                this.Text = $"Hotel California — {UserSession.GetUserRole()}";
            }
            else
            {
                this.Text = "Hotel California";
            }
        }

        private void BLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro que desea cerrar sesión?", 
                                                "Confirmar Cierre de Sesión", 
                                                MessageBoxButtons.YesNo, 
                                                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                UserSession.Logout();
                MessageBox.Show("Sesión cerrada exitosamente.", "Información", 
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                // Cerrar el formulario actual y mostrar login
                this.Hide();
                LoginForm loginForm = new LoginForm();
                loginForm.ShowDialog();
                this.Close();
            }
        }

    }
}
