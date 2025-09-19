using Proyecto_Hotel_California;
using System;
using System.Windows.Forms;

namespace HotelCalifornia
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            this.AcceptButton = btnLogin;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(usuario))
            {
                MessageBox.Show("Ingrese el usuario.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsuario.Focus();
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Ingrese la contraseña.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            // Intentar autenticar con base de datos primero
            Usuario usuarioAutenticado = DatabaseHelper.AuthenticateUser(usuario, password);
            
            // Si no hay base de datos o no encuentra usuario, usar validación simple
            if (usuarioAutenticado == null)
            {
                usuarioAutenticado = ValidateUserSimple(usuario, password);
            }

            if (usuarioAutenticado != null)
            {
                // Iniciar sesión
                UserSession.Login(usuarioAutenticado);
                
                // Mostrar mensaje de bienvenida
                MessageBox.Show($"¡Bienvenido, {usuarioAutenticado.NombreCompleto}!\nRol: {usuarioAutenticado.TipoUsuario}", 
                              "Login Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Abrir formulario principal
                Main mainForm = new Main();
                mainForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos.", "Error de Autenticación", 
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
                txtUsuario.Focus();
            }
        }

        private Usuario ValidateUserSimple(string usuario, string password)
        {
            // Validación simple sin base de datos
            if (usuario == "admin" && password == "admin123")
            {
                return new Usuario("admin", "admin123", "Administrador", "Administrador del Sistema");
            }
            else if (usuario == "supervisor1" && password == "super123")
            {
                return new Usuario("supervisor1", "super123", "Supervisor", "Supervisor General");
            }
            else if (usuario == "recepcion1" && password == "recepcion123")
            {
                return new Usuario("recepcion1", "recepcion123", "Recepcionista", "Recepcionista Principal");
            }
            
            return null;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnTogglePassword_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '*')
            {
                // Mostrar contraseña
                txtPassword.PasswordChar = '\0';
                btnTogglePassword.Text = "🙈"; // Cambiar icono a "ocultar"
            }
            else
            {
                // Ocultar contraseña
                txtPassword.PasswordChar = '*';
                btnTogglePassword.Text = "👁"; // Cambiar icono a "mostrar"
            }
        }
    }
}
