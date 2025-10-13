using System;
using System.Windows.Forms;

namespace HotelCalifornia
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            InitializeUserInterface();
            
            // Inicializar la base de datos si es necesario
            DatabaseHelper.InitializeDatabase();
        }

        private void InitializeUserInterface()
        {
            // Configurar el título del formulario con información del usuario
            this.Text = $"Hotel California - {UserSession.GetUserDisplayName()} ({UserSession.GetUserRole()})";
            
            // Configurar el label del usuario
            lblUsuario.Text = $"Usuario: {UserSession.GetUserDisplayName()} | Rol: {UserSession.GetUserRole()}";
            
            // Configurar permisos de botones según el rol del usuario
            ConfigureUserPermissions();
        }

        private void ConfigureUserPermissions()
        {
            // Configurar visibilidad de botones según el rol del usuario
            string userRole = UserSession.GetUserRole();
            
            switch (userRole)
            {
                case "Administrador":
                    // Administrador: acceso completo
                    btnGestionUsuarios.Visible = true;
                    btnEmpleados.Visible = true;
                    btnReservas.Visible = true;
                    btnPagos.Visible = true;
                    btnClientes.Visible = true;
                    btnHabitaciones.Visible = true;
                    break;
                    
                case "Supervisor":
                    // Supervisor: acceso a empleados y operaciones
                    btnGestionUsuarios.Visible = false;
                    btnEmpleados.Visible = true;  // Supervisores SÍ pueden ver empleados
                    btnReservas.Visible = true;
                    btnPagos.Visible = true;
                    btnClientes.Visible = true;
                    btnHabitaciones.Visible = true;
                    break;
                    
                case "Recepcion":
                case "Recepcionista":
                    // Recepción: acceso limitado
                    btnGestionUsuarios.Visible = false;
                    btnEmpleados.Visible = false;
                    btnReservas.Visible = true;
                    btnPagos.Visible = false;
                    btnClientes.Visible = true;
                    btnHabitaciones.Visible = true;
                    break;
                    
                default:
                    // Por defecto, ocultar funciones sensibles
                    btnGestionUsuarios.Visible = false;
                    btnEmpleados.Visible = false;
                    break;
            }
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            // Abrir el formulario de clientes
            Clientes formClientes = new Clientes();
            formClientes.ShowDialog();
        }

        private void btnGestionUsuarios_Click(object sender, EventArgs e)
        {
            // Verificar permisos de administrador
            if (!UserSession.HasPermission("Administrador"))
            {
                MessageBox.Show("No tiene permisos para acceder a esta sección.", 
                              "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            // Abrir el formulario de gestión de usuarios
            GestionUsuarios formGestionUsuarios = new GestionUsuarios();
            formGestionUsuarios.ShowDialog();
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            // Verificar permisos (Administrador o Supervisor)
            if (!UserSession.HasPermission("supervisor"))
            {
                MessageBox.Show("No tiene permisos para acceder a esta sección.", 
                              "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            // Abrir el formulario de empleados
            Empleados formEmpleados = new Empleados();
            formEmpleados.ShowDialog();
        }

        private void btnHabitaciones_Click(object sender, EventArgs e)
        {
            // Abrir el formulario de habitaciones
            Habitaciones formHabitaciones = new Habitaciones();
            formHabitaciones.ShowDialog();
        }

        private void btnReservas_Click(object sender, EventArgs e)
        {
            // Abrir el formulario de reservas
            Reservas formReservas = new Reservas();
            formReservas.ShowDialog();
        }

        private void btnPagos_Click(object sender, EventArgs e)
        {
            // Verificar permisos
            if (!UserSession.HasPermission("supervisor"))
            {
                MessageBox.Show("No tiene permisos para acceder a esta sección.", 
                              "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            // Abrir el formulario de pagos
            Pagos formPagos = new Pagos();
            formPagos.ShowDialog();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro que desea cerrar sesión?", 
                                                "Cerrar Sesión", 
                                                MessageBoxButtons.YesNo, 
                                                MessageBoxIcon.Question);
            
            if (result == DialogResult.Yes)
            {
                // Cerrar sesión
                UserSession.Logout();
                
                // Mostrar el formulario de login
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
                
                // Cerrar el formulario principal
                this.Close();
            }
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bienvenido al sistema Hotel California!\n\n" +
                          $"Usuario: {UserSession.GetUserDisplayName()}\n" +
                          $"Rol: {UserSession.GetUserRole()}\n\n" +
                          "Seleccione un módulo del menú lateral para continuar.", 
                          "Inicio", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
