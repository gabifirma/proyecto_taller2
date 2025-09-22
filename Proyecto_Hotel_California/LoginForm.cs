using System;
using System.Windows.Forms;

namespace HotelCalifornia
{
    /// <summary>
    /// Formulario de inicio de sesión del sistema Hotel California.
    /// Maneja la autenticación de usuarios tanto con base de datos como en modo offline.
    /// </summary>
    public partial class LoginForm : Form
    {
        /// <summary>
        /// Constructor del formulario de login.
        /// Inicializa los componentes y configura el botón de login como botón por defecto.
        /// </summary>
        public LoginForm()
        {
            InitializeComponent();
            // Configurar el botón de login para que se active con Enter
            this.AcceptButton = btnLogin;
        }

        /// <summary>
        /// Maneja el evento click del botón Login.
        /// Valida las credenciales y autentica al usuario.
        /// </summary>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string password = txtPassword.Text.Trim();

            // Validar que se haya ingresado el usuario
            if (string.IsNullOrEmpty(usuario))
            {
                MessageBox.Show("Ingrese el usuario.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsuario.Focus();
                return;
            }

            // Validar que se haya ingresado la contraseña
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
                // Iniciar sesión del usuario autenticado
                UserSession.Login(usuarioAutenticado);
                
                // Mostrar mensaje de bienvenida personalizado
                MessageBox.Show($"¡Bienvenido, {usuarioAutenticado.NombreCompleto}!\nRol: {usuarioAutenticado.TipoUsuario}", 
                              "Login Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Abrir formulario principal y ocultar el login
                Main mainForm = new Main();
                mainForm.Show();
                this.Hide();
            }
            else
            {
                // Mostrar error de autenticación
                MessageBox.Show("Usuario o contraseña incorrectos.", "Error de Autenticación", 
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
                txtUsuario.Focus();
            }
        }

        /// <summary>
        /// Valida las credenciales del usuario usando datos hardcodeados.
        /// Se utiliza como fallback cuando no hay conexión a la base de datos.
        /// </summary>
        /// <param name="usuario">Nombre de usuario</param>
        /// <param name="password">Contraseña del usuario</param>
        /// <returns>Objeto Usuario si las credenciales son válidas, null en caso contrario</returns>
        private Usuario ValidateUserSimple(string usuario, string password)
        {
            // Validación simple sin base de datos usando usuarios predefinidos
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

        /// <summary>
        /// Maneja el evento click del botón Salir.
        /// Cierra completamente la aplicación.
        /// </summary>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Maneja el evento click del botón para mostrar/ocultar contraseña.
        /// Alterna entre mostrar la contraseña en texto plano o con asteriscos.
        /// </summary>
        private void btnTogglePassword_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '*')
            {
                // Mostrar contraseña en texto plano
                txtPassword.PasswordChar = '\0';
                btnTogglePassword.Text = "🙈"; // Cambiar icono a "ocultar"
            }
            else
            {
                // Ocultar contraseña con asteriscos
                txtPassword.PasswordChar = '*';
                btnTogglePassword.Text = "👁"; // Cambiar icono a "mostrar"
            }
        }
    }
}
