using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace HotelCalifornia
{
    /// <summary>
    /// Formulario para agregar un nuevo empleado con la opción de crear un usuario asociado
    /// </summary>
    public partial class AgregarEmpleadoConUsuario : Form
    {
        private TextBox txtNombre;
        private TextBox txtApellido;
        private TextBox txtTelefono;
        private TextBox txtEmail;
        private CheckBox chkCrearUsuario;
        private GroupBox gbUsuario;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private ComboBox cmbRol;
        private Button btnGuardar;
        private Button btnCancelar;

        public AgregarEmpleadoConUsuario()
        {
            InitializeComponent();
            CargarRoles();
        }

        private void InitializeComponent()
        {
            this.Text = "Agregar Nuevo Empleado";
            this.Size = new Size(600, 550);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.FromArgb(236, 240, 241);

            // Título
            Label lblTitulo = new Label
            {
                Text = "Nuevo Empleado",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                Location = new Point(30, 20),
                AutoSize = true
            };

            // GroupBox para datos del empleado
            GroupBox gbEmpleado = new GroupBox
            {
                Text = "Datos del Empleado",
                Location = new Point(30, 60),
                Size = new Size(540, 180),
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };

            // Nombre
            Label lblNombre = new Label
            {
                Text = "Nombre:",
                Location = new Point(20, 30),
                Size = new Size(100, 25),
                Font = new Font("Segoe UI", 10)
            };
            txtNombre = new TextBox
            {
                Location = new Point(130, 30),
                Size = new Size(380, 25),
                Font = new Font("Segoe UI", 10)
            };

            // Apellido
            Label lblApellido = new Label
            {
                Text = "Apellido:",
                Location = new Point(20, 65),
                Size = new Size(100, 25),
                Font = new Font("Segoe UI", 10)
            };
            txtApellido = new TextBox
            {
                Location = new Point(130, 65),
                Size = new Size(380, 25),
                Font = new Font("Segoe UI", 10)
            };

            // Teléfono
            Label lblTelefono = new Label
            {
                Text = "Teléfono:",
                Location = new Point(20, 100),
                Size = new Size(100, 25),
                Font = new Font("Segoe UI", 10)
            };
            txtTelefono = new TextBox
            {
                Location = new Point(130, 100),
                Size = new Size(380, 25),
                Font = new Font("Segoe UI", 10),
                MaxLength = 50
            };

            // Email
            Label lblEmail = new Label
            {
                Text = "Email:",
                Location = new Point(20, 135),
                Size = new Size(100, 25),
                Font = new Font("Segoe UI", 10)
            };
            txtEmail = new TextBox
            {
                Location = new Point(130, 135),
                Size = new Size(380, 25),
                Font = new Font("Segoe UI", 10)
            };

            gbEmpleado.Controls.AddRange(new Control[] {
                lblNombre, txtNombre,
                lblApellido, txtApellido,
                lblTelefono, txtTelefono,
                lblEmail, txtEmail
            });

            // CheckBox para crear usuario
            chkCrearUsuario = new CheckBox
            {
                Text = "Crear usuario para este empleado",
                Location = new Point(30, 250),
                Size = new Size(300, 30),
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 73, 94)
            };
            chkCrearUsuario.CheckedChanged += ChkCrearUsuario_CheckedChanged;

            // GroupBox para datos del usuario
            gbUsuario = new GroupBox
            {
                Text = "Datos del Usuario",
                Location = new Point(30, 285),
                Size = new Size(540, 150),
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Enabled = false
            };

            // Username
            Label lblUsername = new Label
            {
                Text = "Usuario:",
                Location = new Point(20, 30),
                Size = new Size(100, 25),
                Font = new Font("Segoe UI", 10)
            };
            txtUsername = new TextBox
            {
                Location = new Point(130, 30),
                Size = new Size(380, 25),
                Font = new Font("Segoe UI", 10)
            };

            // Password
            Label lblPassword = new Label
            {
                Text = "Contraseña:",
                Location = new Point(20, 65),
                Size = new Size(100, 25),
                Font = new Font("Segoe UI", 10)
            };
            txtPassword = new TextBox
            {
                Location = new Point(130, 65),
                Size = new Size(380, 25),
                Font = new Font("Segoe UI", 10),
                PasswordChar = '*'
            };

            // Rol
            Label lblRol = new Label
            {
                Text = "Rol:",
                Location = new Point(20, 100),
                Size = new Size(100, 25),
                Font = new Font("Segoe UI", 10)
            };
            cmbRol = new ComboBox
            {
                Location = new Point(130, 100),
                Size = new Size(380, 25),
                Font = new Font("Segoe UI", 10),
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            gbUsuario.Controls.AddRange(new Control[] {
                lblUsername, txtUsername,
                lblPassword, txtPassword,
                lblRol, cmbRol
            });

            // Botones
            btnGuardar = new Button
            {
                Text = "Guardar",
                Location = new Point(180, 455),
                Size = new Size(120, 40),
                BackColor = Color.FromArgb(46, 204, 113),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.Click += BtnGuardar_Click;

            btnCancelar = new Button
            {
                Text = "Cancelar",
                Location = new Point(320, 455),
                Size = new Size(120, 40),
                BackColor = Color.FromArgb(231, 76, 60),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.Click += (s, e) => this.Close();

            this.Controls.AddRange(new Control[] {
                lblTitulo, gbEmpleado, chkCrearUsuario, gbUsuario, btnGuardar, btnCancelar
            });
        }

        private void ChkCrearUsuario_CheckedChanged(object sender, EventArgs e)
        {
            gbUsuario.Enabled = chkCrearUsuario.Checked;
            if (!chkCrearUsuario.Checked)
            {
                txtUsername.Clear();
                txtPassword.Clear();
                if (cmbRol.Items.Count > 0)
                    cmbRol.SelectedIndex = 0;
            }
        }

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
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar roles: {ex.Message}",
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            try
            {
                string nombre = txtNombre.Text.Trim();
                string apellido = txtApellido.Text.Trim();
                string telefono = txtTelefono.Text.Trim();
                string email = txtEmail.Text.Trim();

                if (chkCrearUsuario.Checked)
                {
                    // Crear empleado y usuario en una transacción
                    string username = txtUsername.Text.Trim();
                    string password = txtPassword.Text.Trim();
                    int idRol = Convert.ToInt32(cmbRol.SelectedValue);

                    bool resultado = DatabaseHelper.CreateEmpleadoAndUsuario(
                        nombre, apellido, telefono, email, username, password, idRol);

                    if (resultado)
                    {
                        MessageBox.Show("Empleado y usuario creados exitosamente.",
                                      "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                else
                {
                    // Crear solo empleado
                    int legajo = DatabaseHelper.CreateEmpleado(nombre, apellido, telefono, email);
                    
                    MessageBox.Show($"Empleado creado exitosamente con legajo: {legajo}",
                                  "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}",
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarCampos()
        {
            // Validar nombre
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre es obligatorio.",
                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return false;
            }

            // Validar apellido
            if (string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                MessageBox.Show("El apellido es obligatorio.",
                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtApellido.Focus();
                return false;
            }

            // Validar teléfono
            if (string.IsNullOrWhiteSpace(txtTelefono.Text) || txtTelefono.Text.Length < 7)
            {
                MessageBox.Show("El campo Teléfono no puede estar vacío y debe tener al menos 7 dígitos.",
                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelefono.Focus();
                return false;
            }

            // Validar email
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("El email es obligatorio.",
                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(txtEmail.Text, 
                @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
            {
                MessageBox.Show("El email no tiene un formato válido.",
                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            // Si se va a crear usuario, validar esos campos
            if (chkCrearUsuario.Checked)
            {
                if (string.IsNullOrWhiteSpace(txtUsername.Text))
                {
                    MessageBox.Show("El nombre de usuario es obligatorio.",
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

                if (string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    MessageBox.Show("La contraseña es obligatoria.",
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

                if (cmbRol.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar un rol para el usuario.",
                                  "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbRol.Focus();
                    return false;
                }
            }

            return true;
        }
    }
}
