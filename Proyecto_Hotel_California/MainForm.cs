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
            btnGestionUsuarios.Visible = UserSession.HasPermission("Administrador");
            btnEmpleados.Visible = UserSession.HasPermission("Administrador");
            
            // Los demás botones están disponibles para todos los roles
            // pero se pueden agregar más restricciones si es necesario
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Módulo de Clientes - En desarrollo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            MessageBox.Show("Módulo de Empleados - En desarrollo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnHabitaciones_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Módulo de Habitaciones - En desarrollo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnReservas_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Módulo de Reservas - En desarrollo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnPagos_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Módulo de Pagos - En desarrollo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                
                // Cerrar el formulario principal
                this.Close();
                
                // Mostrar el formulario de login
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
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
