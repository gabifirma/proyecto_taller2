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
    /// <summary>
    /// Formulario principal del sistema Hotel California.
    /// Actúa como contenedor MDI para todos los demás formularios y maneja la navegación principal.
    /// Incluye un dashboard con estadísticas y controla el acceso según el rol del usuario.
    /// </summary>
    public partial class Main : Form
    {
        /// <summary>
        /// Constructor del formulario principal.
        /// Inicializa los componentes, aplica estilos, configura el menú según el rol del usuario
        /// y establece la conexión con la base de datos.
        /// </summary>
        public Main()
        {
            InitializeComponent();
            ApplyStyles();
            ConfigureMenuByRole();
            UpdateHeader();
            DatabaseHelper.InitializeDatabase();
        }

        /// <summary>
        /// Aplica los estilos visuales al formulario principal
        /// </summary>
        private void ApplyStyles()
        {
            AppStyles.ApplyFormStyle(this);
        }

        /// <summary>
        /// Abre un formulario hijo dentro del contenedor principal (MDI)
        /// </summary>
        /// <param name="formhijo">Formulario a mostrar como hijo</param>
        private void abrirFormHIjo(object formhijo)
        {
            // Limpiar el contenedor si ya tiene un formulario
            if (this.PContenedor.Controls.Count > 0)
                this.PContenedor.Controls.RemoveAt(0);
            
            // Configurar el formulario hijo para que se muestre dentro del contenedor
            Form fh = formhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.PContenedor.Controls.Add(fh);
            this.PContenedor.Tag = fh;
            fh.Show();
        }

        /// <summary>
        /// Maneja el evento click del botón Inicio.
        /// Muestra el dashboard principal con estadísticas del hotel.
        /// </summary>
        private void BInicio_Click(object sender, EventArgs e)
        {
            // Limpiar el contenedor para mostrar el dashboard principal
            if (this.PContenedor.Controls.Count > 0)
                this.PContenedor.Controls.RemoveAt(0);
            
            // Crear y mostrar panel de estadísticas
            MostrarPanelEstadisticas();
        }

        /// <summary>
        /// Crea y muestra el panel de estadísticas del dashboard principal.
        /// Incluye tarjetas con métricas del hotel e información del usuario actual.
        /// </summary>
        private void MostrarPanelEstadisticas()
        {
            // Crear panel principal para las estadísticas
            Panel panelStats = new Panel();
            panelStats.Dock = DockStyle.Fill;
            panelStats.BackColor = AppStyles.BackgroundColor;
            
            // Título principal del dashboard
            Label lblTitulo = new Label();
            lblTitulo.Text = "Dashboard - Hotel California";
            lblTitulo.Font = AppStyles.TitleFont;
            lblTitulo.ForeColor = AppStyles.PrimaryColor;
            lblTitulo.Location = new Point(30, 20);
            lblTitulo.Size = new Size(400, 40);
            panelStats.Controls.Add(lblTitulo);

            // Obtener estadísticas actuales de la base de datos
            var stats = ObtenerEstadisticas();

            // Panel contenedor para las tarjetas de estadísticas
            Panel panelTarjetas = new Panel();
            panelTarjetas.Location = new Point(30, 80);
            panelTarjetas.Size = new Size(800, 200);
            panelTarjetas.BackColor = Color.Transparent;

            // Crear tarjetas individuales con las métricas principales
            CrearTarjetaEstadistica(panelTarjetas, "Total Reservas", stats.TotalReservas.ToString(), AppStyles.PrimaryColor, new Point(0, 0));
            CrearTarjetaEstadistica(panelTarjetas, "Reservas Activas", stats.ReservasActivas.ToString(), AppStyles.SuccessColor, new Point(200, 0));
            CrearTarjetaEstadistica(panelTarjetas, "Total Clientes", stats.TotalClientes.ToString(), AppStyles.SecondaryColor, new Point(400, 0));
            CrearTarjetaEstadistica(panelTarjetas, "Habitaciones Ocupadas", stats.HabitacionesOcupadas.ToString(), AppStyles.AccentColor, new Point(600, 0));

            panelStats.Controls.Add(panelTarjetas);

            // Panel para información del sistema y usuario actual
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

            // Mostrar información del usuario actual y fecha/hora
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

            // Agregar el panel completo al contenedor principal
            this.PContenedor.Controls.Add(panelStats);
        }

        /// <summary>
        /// Crea una tarjeta visual para mostrar una estadística específica
        /// </summary>
        /// <param name="contenedor">Panel contenedor donde se agregará la tarjeta</param>
        /// <param name="titulo">Título de la estadística</param>
        /// <param name="valor">Valor numérico a mostrar</param>
        /// <param name="color">Color del valor numérico</param>
        /// <param name="ubicacion">Posición de la tarjeta en el contenedor</param>
        private void CrearTarjetaEstadistica(Panel contenedor, string titulo, string valor, Color color, Point ubicacion)
        {
            // Crear panel para la tarjeta individual
            Panel tarjeta = new Panel();
            tarjeta.Size = new Size(180, 120);
            tarjeta.Location = ubicacion;
            tarjeta.BackColor = AppStyles.SurfaceColor;
            tarjeta.BorderStyle = BorderStyle.FixedSingle;

            // Etiqueta para el título de la estadística
            Label lblTitulo = new Label();
            lblTitulo.Text = titulo;
            lblTitulo.Font = AppStyles.SmallFont;
            lblTitulo.ForeColor = AppStyles.TextSecondaryColor;
            lblTitulo.Location = new Point(10, 10);
            lblTitulo.Size = new Size(160, 20);
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            tarjeta.Controls.Add(lblTitulo);

            // Etiqueta para el valor numérico (grande y destacado)
            Label lblValor = new Label();
            lblValor.Text = valor;
            lblValor.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblValor.ForeColor = color;
            lblValor.Location = new Point(10, 40);
            lblValor.Size = new Size(160, 60);
            lblValor.TextAlign = ContentAlignment.MiddleCenter;
            tarjeta.Controls.Add(lblValor);

            // Agregar la tarjeta al contenedor
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

        /// <summary>
        /// Maneja el evento click del botón Clientes.
        /// Abre el formulario de gestión de clientes.
        /// </summary>
        private void BClientes_Click(object sender, EventArgs e)
        {
            abrirFormHIjo(new Clientes());
        }

        /// <summary>
        /// Maneja el evento click del botón Empleados.
        /// Verifica permisos antes de abrir el formulario de gestión de empleados.
        /// </summary>
        private void BEmpleados_Click(object sender, EventArgs e)
        {
            // Verificar que el usuario tenga permisos de supervisor o superior
            if (!UserSession.HasPermission("supervisor"))
            {
                MessageBox.Show("No tiene permisos para acceder a esta sección.", 
                              "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            abrirFormHIjo(new Empleados());
        }

        /// <summary>
        /// Maneja el evento click del botón Habitaciones.
        /// Abre el formulario de gestión de habitaciones.
        /// </summary>
        private void BHabitaciones_Click(object sender, EventArgs e)
        {
            abrirFormHIjo(new Habitaciones());
        }

        /// <summary>
        /// Maneja el evento click del botón Reservas.
        /// Abre el formulario de gestión de reservas.
        /// </summary>
        private void BReservas_Click(object sender, EventArgs e)
        {
            abrirFormHIjo(new Reservas());
        }

        /// <summary>
        /// Maneja el evento click del botón Pagos.
        /// Abre el formulario de gestión de pagos.
        /// </summary>
        private void BPagos_Click(object sender, EventArgs e)
        {
            abrirFormHIjo(new Pagos());
        }

        /// <summary>
        /// Maneja el evento click del botón Gestión de Usuarios.
        /// Solo accesible para administradores.
        /// </summary>
        private void BGestionUsuarios_Click(object sender, EventArgs e)
        {
            // Verificar que el usuario tenga permisos de administrador
            if (!UserSession.HasPermission("administrador"))
            {
                MessageBox.Show("No tiene permisos para acceder a esta sección.", 
                              "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            abrirFormHIjo(new GestionUsuarios());
        }

        /// <summary>
        /// Configura la visibilidad de los botones del menú según el rol del usuario actual.
        /// Implementa el control de acceso basado en roles (RBAC).
        /// </summary>
        private void ConfigureMenuByRole()
        {
            if (!UserSession.IsLoggedIn)
            {
                // Si no hay sesión activa, ocultar todos los botones
                BGestionUsuarios.Visible = false;
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
                    // Administrador: acceso completo a todas las funcionalidades
                    BGestionUsuarios.Visible = true;
                    BEmpleados.Visible = true;
                    BReservas.Visible = true;
                    BPagos.Visible = true;
                    BClientes.Visible = true;
                    BHabitaciones.Visible = true;
                    break;

                case "Supervisor":
                    // Supervisor: acceso a la mayoría de funciones excepto empleados y usuarios
                    BGestionUsuarios.Visible = false;
                    BEmpleados.Visible = false;
                    BReservas.Visible = true;
                    BPagos.Visible = true;
                    BClientes.Visible = true;
                    BHabitaciones.Visible = true;
                    break;

                case "Recepcionista":
                case "Recepcion":
                    // Recepcionista: acceso limitado solo a reservas y habitaciones
                    BGestionUsuarios.Visible = false;
                    BEmpleados.Visible = false;
                    BReservas.Visible = true;
                    BPagos.Visible = false;
                    BClientes.Visible = false;
                    BHabitaciones.Visible = true;
                    break;

                default:
                    // Por defecto, ocultar todo si el rol no es reconocido
                    BGestionUsuarios.Visible = false;
                    BEmpleados.Visible = false;
                    BReservas.Visible = false;
                    BPagos.Visible = false;
                    BClientes.Visible = false;
                    BHabitaciones.Visible = false;
                    break;
            }
        }

        /// <summary>
        /// Actualiza el título de la ventana principal con información del usuario actual
        /// </summary>
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

        /// <summary>
        /// Maneja el evento click del botón Logout.
        /// Confirma con el usuario y cierra la sesión actual.
        /// </summary>
        private void BLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro que desea cerrar sesión?", 
                                                "Confirmar Cierre de Sesión", 
                                                MessageBoxButtons.YesNo, 
                                                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Cerrar la sesión actual
                UserSession.Logout();
                MessageBox.Show("Sesión cerrada exitosamente.", "Información", 
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                // Cerrar el formulario actual y mostrar el formulario de login
                this.Hide();
                LoginForm loginForm = new LoginForm();
                loginForm.ShowDialog();
                this.Close();
            }
        }

    }
}
