using System;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace HotelCalifornia
{
    /// <summary>
    /// Formulario para la gestión de usuarios del sistema.
    /// Solo accesible para usuarios con rol de Administrador.
    /// Permite ver, crear y gestionar usuarios del sistema.
    /// </summary>
    public partial class GestionUsuarios : Form
    {
        public GestionUsuarios()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Evento que se ejecuta al cargar el formulario.
        /// Carga la lista de usuarios existentes.
        /// </summary>
        private void GestionUsuarios_Load(object sender, EventArgs e)
        {
            // Verificar que el usuario tenga permisos de administrador
            if (!UserSession.HasPermission("administrador"))
            {
                MessageBox.Show("No tiene permisos para acceder a esta funcionalidad.", 
                              "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            CargarUsuarios();
        }

        /// <summary>
        /// Carga la lista de usuarios desde la base de datos
        /// </summary>
        private void CargarUsuarios()
        {
            try
            {
                DataTable dtUsuarios = DatabaseHelper.GetAllUsers();
                
                if (dtUsuarios == null || dtUsuarios.Rows.Count == 0)
                {
                    MessageBox.Show("No hay usuarios en la base de datos o no se pudo conectar.", 
                                  "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                
                dgvUsuarios.DataSource = dtUsuarios;
                
                // Configurar las columnas del DataGridView
                if (dgvUsuarios.Columns.Count > 0)
                {
                    if (dgvUsuarios.Columns.Contains("id_usuario"))
                        dgvUsuarios.Columns["id_usuario"].HeaderText = "ID";
                    if (dgvUsuarios.Columns.Contains("username"))
                        dgvUsuarios.Columns["username"].HeaderText = "Usuario";
                    if (dgvUsuarios.Columns.Contains("nombre_completo"))
                        dgvUsuarios.Columns["nombre_completo"].HeaderText = "Nombre Completo";
                    if (dgvUsuarios.Columns.Contains("nombre_rol"))
                        dgvUsuarios.Columns["nombre_rol"].HeaderText = "Rol";
                    
                    // Ocultar columnas sensibles
                    if (dgvUsuarios.Columns.Contains("contrasena"))
                        dgvUsuarios.Columns["contrasena"].Visible = false;
                    if (dgvUsuarios.Columns.Contains("password"))
                        dgvUsuarios.Columns["password"].Visible = false;
                    if (dgvUsuarios.Columns.Contains("id_rol"))
                        dgvUsuarios.Columns["id_rol"].Visible = false;
                    if (dgvUsuarios.Columns.Contains("legajo"))
                        dgvUsuarios.Columns["legajo"].Visible = false;
                }
                
                dgvUsuarios.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar usuarios: {ex.Message}\n\nStack: {ex.StackTrace}", 
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Abre el formulario para agregar un nuevo usuario
        /// </summary>
        private void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            AgregarUsuarioForm formAgregar = new AgregarUsuarioForm();
            if (formAgregar.ShowDialog() == DialogResult.OK)
            {
                // Recargar la lista después de agregar
                CargarUsuarios();
            }
        }
    }

    // Clase auxiliar para el formulario de agregar usuario
    public partial class AgregarUsuarioForm : Form
    {
        private TextBox txtNombre;
        private TextBox txtApellido;
        private TextBox txtTelefono;
        private TextBox txtEmail;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private ComboBox cmbRol;
        private Button btnGuardar;
        private Button btnCancelar;

        public AgregarUsuarioForm()
        {
            InitializeComponent();
            CargarRoles();
        }

        private void InitializeComponent()
        {
            this.Text = "Agregar Nuevo Usuario";
            this.Size = new Size(570, 540);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Labels y TextBoxes para Empleado
            Label lblTitulo = new Label { Text = "Nuevo Usuario", Font = new Font("Segoe UI", 16, FontStyle.Bold), Location = new Point(30, 20), AutoSize = true };
            
            GroupBox gbEmpleado = new GroupBox { Text = "Datos del Empleado", Location = new Point(35, 70), Size = new Size(500, 200), Font = new Font("Segoe UI", 10, FontStyle.Bold) };
            
            Label lblNombre = new Label { Text = "Nombre:", Location = new Point(20, 33), Size = new Size(80, 19), Font = new Font("Segoe UI", 10) };
            txtNombre = new TextBox { Location = new Point(120, 30), Size = new Size(350, 25), Font = new Font("Segoe UI", 10) };
            
            Label lblApellido = new Label { Text = "Apellido:", Location = new Point(20, 73), Size = new Size(80, 19), Font = new Font("Segoe UI", 10) };
            txtApellido = new TextBox { Location = new Point(120, 70), Size = new Size(350, 25), Font = new Font("Segoe UI", 10) };
            
            Label lblTelefono = new Label { Text = "Teléfono:", Location = new Point(20, 113), Size = new Size(80, 19), Font = new Font("Segoe UI", 10) };
            txtTelefono = new TextBox { Location = new Point(120, 110), Size = new Size(350, 25), Font = new Font("Segoe UI", 10) };
            
            Label lblEmail = new Label { Text = "Email:", Location = new Point(20, 153), Size = new Size(80, 19), Font = new Font("Segoe UI", 10) };
            txtEmail = new TextBox { Location = new Point(120, 150), Size = new Size(350, 25), Font = new Font("Segoe UI", 10) };
            
            gbEmpleado.Controls.AddRange(new Control[] { lblNombre, txtNombre, lblApellido, txtApellido, lblTelefono, txtTelefono, lblEmail, txtEmail });
            
            // Labels y TextBoxes para Usuario
            GroupBox gbUsuario = new GroupBox { Text = "Datos del Usuario", Location = new Point(35, 290), Size = new Size(500, 160), Font = new Font("Segoe UI", 10, FontStyle.Bold) };
            
            Label lblUsername = new Label { Text = "Usuario:", Location = new Point(20, 33), Size = new Size(80, 19), Font = new Font("Segoe UI", 10) };
            txtUsername = new TextBox { Location = new Point(120, 30), Size = new Size(350, 25), Font = new Font("Segoe UI", 10) };
            
            Label lblPassword = new Label { Text = "Contraseña:", Location = new Point(20, 73), Size = new Size(100, 19), Font = new Font("Segoe UI", 10) };
            txtPassword = new TextBox { Location = new Point(120, 70), Size = new Size(350, 25), Font = new Font("Segoe UI", 10), PasswordChar = '*' };
            
            Label lblRol = new Label { Text = "Rol:", Location = new Point(20, 113), Size = new Size(80, 19), Font = new Font("Segoe UI", 10) };
            cmbRol = new ComboBox { Location = new Point(120, 110), Size = new Size(350, 25), Font = new Font("Segoe UI", 10), DropDownStyle = ComboBoxStyle.DropDownList };
            
            gbUsuario.Controls.AddRange(new Control[] { lblUsername, txtUsername, lblPassword, txtPassword, lblRol, cmbRol });
            
            // Botones
            btnGuardar = new Button { Text = "Guardar Usuario", Location = new Point(155, 470), Size = new Size(150, 40), BackColor = Color.FromArgb(46, 204, 113), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10, FontStyle.Bold) };
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.Click += BtnGuardar_Click;
            
            btnCancelar = new Button { Text = "Cancelar", Location = new Point(325, 470), Size = new Size(150, 40), BackColor = Color.FromArgb(231, 76, 60), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10, FontStyle.Bold) };
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };
            
            this.Controls.AddRange(new Control[] { lblTitulo, gbEmpleado, gbUsuario, btnGuardar, btnCancelar });
            this.BackColor = Color.FromArgb(236, 240, 241);
        }

        /// <summary>
        /// Carga los roles disponibles en el ComboBox, excluyendo el rol de Administrador
        /// </summary>
        private void CargarRoles()
        {
            try
            {
                DataTable dtRoles = DatabaseHelper.GetRolesExceptAdmin();
                
                if (dtRoles.Rows.Count > 0)
                {
                    cmbRol.DataSource = dtRoles;
                    cmbRol.DisplayMember = "nombre";
                    cmbRol.ValueMember = "id_rol";
                    cmbRol.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("No se pudieron cargar los roles disponibles.", 
                                  "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar roles: {ex.Message}", 
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Maneja el evento click del botón Guardar.
        /// Valida los datos y crea el empleado con su usuario asociado.
        /// </summary>
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            // Validar todos los campos
            if (!ValidarCampos())
                return;

            try
            {
                // Obtener los valores de los campos
                string nombre = txtNombre.Text.Trim();
                string apellido = txtApellido.Text.Trim();
                string telefono = txtTelefono.Text.Trim();
                string email = txtEmail.Text.Trim();
                string username = txtUsername.Text.Trim();
                string password = txtPassword.Text.Trim();
                int idRol = Convert.ToInt32(cmbRol.SelectedValue);

                // Crear el empleado y usuario usando transacción
                bool resultado = DatabaseHelper.CreateEmpleadoAndUsuario(
                    nombre, apellido, telefono, email, username, password, idRol);

                if (resultado)
                {
                    MessageBox.Show("Usuario y empleado creados exitosamente.", 
                                  "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", 
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Valida que todos los campos estén completos y tengan el formato correcto
        /// </summary>
        /// <returns>True si todos los campos son válidos, False en caso contrario</returns>
        private bool ValidarCampos()
        {
            // Validar nombre
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Ingrese el nombre del empleado.", 
                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return false;
            }

            // Validar apellido
            if (string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                MessageBox.Show("Ingrese el apellido del empleado.", 
                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtApellido.Focus();
                return false;
            }

            // Validar teléfono
            if (string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                MessageBox.Show("Ingrese el teléfono del empleado.", 
                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelefono.Focus();
                return false;
            }

            // Validar email
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Ingrese el email del empleado.", 
                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            // Validar formato de email
            if (!ValidarFormatoEmail(txtEmail.Text.Trim()))
            {
                MessageBox.Show("Ingrese un email válido.", 
                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            // Validar username
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Ingrese el nombre de usuario.", 
                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return false;
            }

            // Validar que el username tenga al menos 4 caracteres
            if (txtUsername.Text.Trim().Length < 4)
            {
                MessageBox.Show("El nombre de usuario debe tener al menos 4 caracteres.", 
                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return false;
            }

            // Validar contraseña
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Ingrese la contraseña.", 
                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return false;
            }

            // Validar que la contraseña tenga al menos 6 caracteres
            if (txtPassword.Text.Trim().Length < 6)
            {
                MessageBox.Show("La contraseña debe tener al menos 6 caracteres.", 
                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return false;
            }

            // Validar que se haya seleccionado un rol
            if (cmbRol.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un rol para el usuario.", 
                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbRol.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// Valida el formato de un email usando expresiones regulares
        /// </summary>
        /// <param name="email">Email a validar</param>
        /// <returns>True si el formato es válido, False en caso contrario</returns>
        private bool ValidarFormatoEmail(string email)
        {
            string patron = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, patron);
        }

        /// <summary>
        /// Limpia todos los campos del formulario
        /// </summary>
        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            cmbRol.SelectedIndex = 0;
            txtNombre.Focus();
        }

        /// <summary>
        /// Maneja el evento click del botón Cancelar.
        /// Cierra el formulario sin guardar cambios.
        /// </summary>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
