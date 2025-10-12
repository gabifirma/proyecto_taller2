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
            AgregarEditarUsuarioForm formAgregar = new AgregarEditarUsuarioForm();
            if (formAgregar.ShowDialog() == DialogResult.OK)
            {
                CargarUsuarios();
            }
        }

        /// <summary>
        /// Abre el formulario para editar un usuario existente
        /// </summary>
        private void btnEditarUsuario_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un usuario para editar.",
                              "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int idUsuario = Convert.ToInt32(dgvUsuarios.SelectedRows[0].Cells["id_usuario"].Value);
            AgregarEditarUsuarioForm formEditar = new AgregarEditarUsuarioForm(idUsuario);
            if (formEditar.ShowDialog() == DialogResult.OK)
            {
                CargarUsuarios();
            }
        }

        /// <summary>
        /// Elimina un usuario (lo marca como inactivo)
        /// </summary>
        private void btnEliminarUsuario_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un usuario para eliminar.",
                              "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int idUsuario = Convert.ToInt32(dgvUsuarios.SelectedRows[0].Cells["id_usuario"].Value);
            string username = dgvUsuarios.SelectedRows[0].Cells["username"].Value.ToString();

            DialogResult result = MessageBox.Show(
                $"¿Está seguro que desea desactivar el usuario '{username}'?",
                "Confirmar Eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (DatabaseHelper.DeleteUser(idUsuario))
                {
                    MessageBox.Show("Usuario desactivado exitosamente.",
                                  "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarUsuarios();
                }
                else
                {
                    MessageBox.Show("Error al desactivar el usuario.",
                                  "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }

    /// <summary>
    /// Formulario para agregar o editar usuarios
    /// Permite seleccionar un empleado existente y asignarle credenciales y rol
    /// </summary>
    public partial class AgregarEditarUsuarioForm : Form
    {
        private ComboBox cmbEmpleado;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private ComboBox cmbRol;
        private CheckBox chkActivo;
        private Button btnGuardar;
        private Button btnCancelar;
        private int? idUsuarioEditar = null;

        public AgregarEditarUsuarioForm(int? idUsuario = null)
        {
            idUsuarioEditar = idUsuario;
            InitializeComponent();
            CargarEmpleados();
            CargarRoles();
            
            if (idUsuarioEditar.HasValue)
            {
                CargarDatosUsuario(idUsuarioEditar.Value);
            }
        }

        private void InitializeComponent()
        {
            this.Text = idUsuarioEditar.HasValue ? "Editar Usuario" : "Agregar Nuevo Usuario";
            this.Size = new Size(570, 400);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Título
            Label lblTitulo = new Label { 
                Text = idUsuarioEditar.HasValue ? "Editar Usuario" : "Nuevo Usuario", 
                Font = new Font("Segoe UI", 16, FontStyle.Bold), 
                Location = new Point(30, 20), 
                AutoSize = true 
            };
            
            // GroupBox para datos del usuario
            GroupBox gbUsuario = new GroupBox { 
                Text = "Datos del Usuario", 
                Location = new Point(35, 70), 
                Size = new Size(500, 220), 
                Font = new Font("Segoe UI", 10, FontStyle.Bold) 
            };
            
            // Empleado
            Label lblEmpleado = new Label { 
                Text = "Empleado:", 
                Location = new Point(20, 33), 
                Size = new Size(100, 19), 
                Font = new Font("Segoe UI", 10) 
            };
            cmbEmpleado = new ComboBox { 
                Location = new Point(130, 30), 
                Size = new Size(350, 25), 
                Font = new Font("Segoe UI", 10), 
                DropDownStyle = ComboBoxStyle.DropDownList 
            };
            
            // Username
            Label lblUsername = new Label { 
                Text = "Usuario:", 
                Location = new Point(20, 73), 
                Size = new Size(100, 19), 
                Font = new Font("Segoe UI", 10) 
            };
            txtUsername = new TextBox { 
                Location = new Point(130, 70), 
                Size = new Size(350, 25), 
                Font = new Font("Segoe UI", 10) 
            };
            
            // Password
            Label lblPassword = new Label { 
                Text = "Contraseña:", 
                Location = new Point(20, 113), 
                Size = new Size(100, 19), 
                Font = new Font("Segoe UI", 10) 
            };
            txtPassword = new TextBox { 
                Location = new Point(130, 110), 
                Size = new Size(350, 25), 
                Font = new Font("Segoe UI", 10), 
                PasswordChar = '*' 
            };
            
            // Rol
            Label lblRol = new Label { 
                Text = "Rol:", 
                Location = new Point(20, 153), 
                Size = new Size(100, 19), 
                Font = new Font("Segoe UI", 10) 
            };
            cmbRol = new ComboBox { 
                Location = new Point(130, 150), 
                Size = new Size(350, 25), 
                Font = new Font("Segoe UI", 10), 
                DropDownStyle = ComboBoxStyle.DropDownList 
            };
            
            // Activo
            chkActivo = new CheckBox { 
                Text = "Usuario Activo", 
                Location = new Point(130, 185), 
                Size = new Size(150, 25), 
                Font = new Font("Segoe UI", 10),
                Checked = true
            };
            
            gbUsuario.Controls.AddRange(new Control[] { 
                lblEmpleado, cmbEmpleado, 
                lblUsername, txtUsername, 
                lblPassword, txtPassword, 
                lblRol, cmbRol,
                chkActivo 
            });
            
            // Botones
            btnGuardar = new Button { 
                Text = idUsuarioEditar.HasValue ? "Actualizar" : "Guardar", 
                Location = new Point(155, 310), 
                Size = new Size(150, 40), 
                BackColor = Color.FromArgb(46, 204, 113), 
                ForeColor = Color.White, 
                FlatStyle = FlatStyle.Flat, 
                Font = new Font("Segoe UI", 10, FontStyle.Bold) 
            };
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.Click += BtnGuardar_Click;
            
            btnCancelar = new Button { 
                Text = "Cancelar", 
                Location = new Point(325, 310), 
                Size = new Size(150, 40), 
                BackColor = Color.FromArgb(231, 76, 60), 
                ForeColor = Color.White, 
                FlatStyle = FlatStyle.Flat, 
                Font = new Font("Segoe UI", 10, FontStyle.Bold) 
            };
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };
            
            this.Controls.AddRange(new Control[] { lblTitulo, gbUsuario, btnGuardar, btnCancelar });
            this.BackColor = Color.FromArgb(236, 240, 241);
        }

        /// <summary>
        /// Carga los empleados disponibles en el ComboBox
        /// </summary>
        private void CargarEmpleados()
        {
            try
            {
                DataTable dtEmpleados = DatabaseHelper.GetEmpleadosSinUsuario();
                
                if (dtEmpleados.Rows.Count > 0 || idUsuarioEditar.HasValue)
                {
                    cmbEmpleado.DataSource = dtEmpleados;
                    cmbEmpleado.DisplayMember = "nombre_completo";
                    cmbEmpleado.ValueMember = "legajo";
                    if (dtEmpleados.Rows.Count > 0)
                        cmbEmpleado.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("No hay empleados disponibles sin usuario asignado.\nPrimero debe crear empleados desde la sección Empleados.", 
                                  "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar empleados: {ex.Message}", 
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Carga los roles disponibles en el ComboBox
        /// </summary>
        private void CargarRoles()
        {
            try
            {
                DataTable dtRoles = DatabaseHelper.GetAllRoles();
                
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
        /// Carga los datos de un usuario existente para edición
        /// </summary>
        private void CargarDatosUsuario(int idUsuario)
        {
            try
            {
                DataTable dtUsuario = DatabaseHelper.GetUsuarioById(idUsuario);
                if (dtUsuario.Rows.Count > 0)
                {
                    DataRow row = dtUsuario.Rows[0];
                    txtUsername.Text = row["username"].ToString();
                    txtPassword.Text = row["contrasena"].ToString();
                    cmbRol.SelectedValue = Convert.ToInt32(row["id_rol"]);
                    chkActivo.Checked = Convert.ToBoolean(row["activo"]);
                    
                    // Cargar el empleado asociado
                    if (row["legajo"] != DBNull.Value)
                    {
                        int legajo = Convert.ToInt32(row["legajo"]);
                        cmbEmpleado.SelectedValue = legajo;
                        cmbEmpleado.Enabled = false; // No permitir cambiar el empleado
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos del usuario: {ex.Message}", 
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Maneja el evento click del botón Guardar.
        /// Crea o actualiza un usuario asociado a un empleado existente.
        /// </summary>
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            try
            {
                int legajo = Convert.ToInt32(cmbEmpleado.SelectedValue);
                string username = txtUsername.Text.Trim();
                string password = txtPassword.Text.Trim();
                int idRol = Convert.ToInt32(cmbRol.SelectedValue);
                bool activo = chkActivo.Checked;

                bool resultado;
                if (idUsuarioEditar.HasValue)
                {
                    // Actualizar usuario existente
                    resultado = DatabaseHelper.UpdateUsuario(
                        idUsuarioEditar.Value, username, password, idRol, activo);
                    
                    if (resultado)
                    {
                        MessageBox.Show("Usuario actualizado exitosamente.", 
                                      "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                else
                {
                    // Crear nuevo usuario
                    resultado = DatabaseHelper.CreateUsuario(legajo, username, password, idRol);
                    
                    if (resultado)
                    {
                        MessageBox.Show("Usuario creado exitosamente.", 
                                      "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
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
        private bool ValidarCampos()
        {
            // Validar empleado
            if (cmbEmpleado.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un empleado.", 
                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbEmpleado.Focus();
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

            if (txtPassword.Text.Trim().Length < 6)
            {
                MessageBox.Show("La contraseña debe tener al menos 6 caracteres.", 
                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return false;
            }

            // Validar rol
            if (cmbRol.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un rol para el usuario.", 
                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbRol.Focus();
                return false;
            }

            return true;
        }
    }
}
