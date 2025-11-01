using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelCalifornia
{
    public partial class AgregarEmpleadoConUsuario1 : Form
    {
        public AgregarEmpleadoConUsuario1()
        {
            InitializeComponent();
            CargarRoles();
        }

        private void ChkCrearUsuario_CheckedChanged(object sender, EventArgs e)
        {
            GBUsuario.Enabled = chkCrearUsuario.Checked;
            if (!chkCrearUsuario.Checked)
            {
                TUsuario.Clear();
                TPassword.Clear();
                if (CMBRol.Items.Count > 0)
                    CMBRol.SelectedIndex = 0;
            }
        }

        private void CargarRoles()
        {
            try
            {
                DataTable dtRoles = DatabaseHelper.GetAllRoles();
                if (dtRoles.Rows.Count > 0)
                {
                    CMBRol.DataSource = dtRoles;
                    CMBRol.DisplayMember = "nombre";
                    CMBRol.ValueMember = "id_rol";
                    CMBRol.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar roles: {ex.Message}",
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            try
            {
                string nombre = TNombre.Text.Trim();
                string apellido = TApellido.Text.Trim();
                string telefono = TTelefono.Text.Trim();
                string email = TEmail.Text.Trim();

                if (chkCrearUsuario.Checked)
                {
                    // Crear empleado y usuario en una transacción
                    string username = TUsuario.Text.Trim();
                    string password = TPassword.Text.Trim();
                    int idRol = Convert.ToInt32(CMBRol.SelectedValue);

                    bool resultado = DatabaseHelper.CreateEmpleadoAndUsuario(nombre, apellido, telefono, email, username, password, idRol);

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
            if (string.IsNullOrWhiteSpace(TNombre.Text))
            {
                MessageBox.Show("El nombre es obligatorio.",
                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TNombre.Focus();
                return false;
            }

            // Validar apellido
            if (string.IsNullOrWhiteSpace(TApellido.Text))
            {
                MessageBox.Show("El apellido es obligatorio.",
                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TApellido.Focus();
                return false;
            }

            // Validar teléfono
            if (string.IsNullOrWhiteSpace(TTelefono.Text) || TTelefono.Text.Length < 7)
            {
                MessageBox.Show("El campo Teléfono no puede estar vacío y debe tener al menos 7 dígitos.",
                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TTelefono.Focus();
                return false;
            }

            // Validar email
            if (string.IsNullOrWhiteSpace(TEmail.Text))
            {
                MessageBox.Show("El email es obligatorio.",
                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TEmail.Focus();
                return false;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(TEmail.Text,
                @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
            {
                MessageBox.Show("El email no tiene un formato válido.",
                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TEmail.Focus();
                return false;
            }

            // Si se va a crear usuario, validar esos campos
            if (chkCrearUsuario.Checked)
            {
                if (string.IsNullOrWhiteSpace(TUsuario.Text))
                {
                    MessageBox.Show("El nombre de usuario es obligatorio.",
                                  "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TUsuario.Focus();
                    return false;
                }

                if (TUsuario.Text.Trim().Length < 4)
                {
                    MessageBox.Show("El nombre de usuario debe tener al menos 4 caracteres.",
                                  "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TUsuario.Focus();
                    return false;
                }

                if (string.IsNullOrWhiteSpace(TPassword.Text))
                {
                    MessageBox.Show("La contraseña es obligatoria.",
                                  "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TPassword.Focus();
                    return false;
                }

                if (TPassword.Text.Trim().Length < 6)
                {
                    MessageBox.Show("La contraseña debe tener al menos 6 caracteres.",
                                  "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TPassword.Focus();
                    return false;
                }

                if (CMBRol.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar un rol para el usuario.",
                                  "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    CMBRol.Focus();
                    return false;
                }
            }
            return true;
        }

        private void TNombre_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TNombre.Text))
            {
                string texto = TNombre.Text.ToLower(); // todo en minúscula
                TNombre.Text = char.ToUpper(texto[0]) + texto.Substring(1); // primera en mayúscula
            }
        }

        private void TApellido_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TApellido.Text))
            {
                string texto = TApellido.Text.ToLower(); // todo en minúscula
                TApellido.Text = char.ToUpper(texto[0]) + texto.Substring(1); // primera en mayúscula
            }
        }
    }
}
