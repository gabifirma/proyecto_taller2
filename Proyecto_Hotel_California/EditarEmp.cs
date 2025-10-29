using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using HotelCalifornia.Styles;

namespace HotelCalifornia
{
    public partial class EditarEmp : Form
    {
        private int empleadoLegajo;
        public EditarEmp(int legajo)
        {
            InitializeComponent();
            empleadoLegajo = legajo;
            ApplyStyles();
            CargarEmpleado();
        }

        private void ApplyStyles()
        {
            AppStyles.ApplyFormStyle(this);
            
            // Aplicar estilos a los controles
            foreach (Control control in this.Controls)
            {
                ApplyControlStyles(control);
            }
        }

        private void ApplyControlStyles(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is TextBox textBox)
                {
                    AppStyles.ApplyTextBoxStyle(textBox);
                }
                else if (control is ComboBox comboBox)
                {
                    AppStyles.ApplyComboBoxStyle(comboBox);
                }
                else if (control is Button button)
                {
                    if (button.Name.Contains("Guardar") || button.Name.Contains("Actualizar"))
                        AppStyles.ApplySuccessButtonStyle(button);
                    else if (button.Name.Contains("Cancelar") || button.Name.Contains("Salir"))
                        AppStyles.ApplySecondaryButtonStyle(button);
                    else if (button.Name.Contains("Eliminar"))
                        AppStyles.ApplyErrorButtonStyle(button);
                    else
                        AppStyles.ApplyPrimaryButtonStyle(button);
                }
                else if (control is Label label)
                {
                    AppStyles.ApplyBodyStyle(label);
                }
                else if (control is GroupBox groupBox)
                {
                    AppStyles.ApplyGroupBoxStyle(groupBox);
                    ApplyControlStyles(groupBox);
                }
                else if (control is Panel panel)
                {
                    AppStyles.ApplyPanelStyle(panel);
                    ApplyControlStyles(panel);
                }
                
                if (control.HasChildren)
                {
                    ApplyControlStyles(control);
                }
            }
        }

        private void CargarEmpleado()
        {
            try
            {
                DataTable dt = DatabaseHelper.GetEmpleadoByLegajo(empleadoLegajo);
                
                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    
                    // Mostrar datos del empleado
                    TApellido.Text = row["apellido"].ToString();
                    TNombre.Text = row["nombre"].ToString();
                    LMostrarLeg.Text = row["legajo"].ToString();
                    TTelefono.Text = row["telefono"].ToString();
                    TEmail.Text = row["email"].ToString();
                    
                    bool estado = Convert.ToBoolean(row["estado"]);
                    if (estado)
                    {
                        RBActivado.Checked = true;                          
                    }
                    else
                    {
                        RBDesactivado.Checked = true;
                    }
                }
                else
                {
                    MessageBox.Show("No se encontró el empleado con ese legajo.", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar empleado: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
        //valido que solo se ingresen letras en nombre y apellido
        private bool SoloLetras(string texto)
        {
            return Regex.IsMatch(texto, @"^[a-zA-Z]+$");
        }
        //valido que solo se ingresen numeros en telefono
        private bool SoloNumeros(string texto)
        {
            return Regex.IsMatch(texto, @"^[0-9]+$");
        }
        //boton cancelar
        private void BCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BFin_Click(object sender, EventArgs e)
        {
            //validaciones de apellido y nombre
            if (!SoloLetras(TApellido.Text) || !SoloLetras(TNombre.Text))
            {
                MessageBox.Show("Solo se permiten letras para nombre y apellido");
                return;
            }
            //validacion de telefono
            if (!SoloNumeros(TTelefono.Text))
            {
                MessageBox.Show("Solo se permiten números para teléfono");
                return;
            }

            // El legajo no es editable, se muestra en LMostrarLeg

            //guardarlo todo en la base de datos
            if (SoloLetras(TApellido.Text) && SoloLetras(TNombre.Text) && SoloNumeros(TTelefono.Text))
            {
                try
                {                    
                    // Verificar que el número no sea demasiado grande para INT
                    if (TTelefono.Text.Length > 10)
                    {
                        MessageBox.Show("El teléfono es demasiado largo. Máximo 10 dígitos.",
                                      "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    
                    int legajo = int.Parse(LMostrarLeg.Text);
                    bool estado = RBActivado.Checked;

                    if (!estado)
                    {
                        string usernameAsociado = DatabaseHelper.GetUsernameByLegajo(legajo);
                        if (!string.IsNullOrEmpty(usernameAsociado) && usernameAsociado.Equals("admin", StringComparison.OrdinalIgnoreCase))
                        {
                            MessageBox.Show("No se puede desactivar el empleado asociado al usuario administrador principal.",
                                          "Acción No Permitida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // Actualizar empleado usando el nuevo método
                    bool resultado = DatabaseHelper.UpdateEmpleado(
                        legajo,
                        TNombre.Text.Trim(),
                        TApellido.Text.Trim(),
                        TTelefono.Text.Trim(),
                        TEmail.Text.Trim(),
                        estado
                    );
                    
                    if (resultado)
                    {
                        MessageBox.Show("Empleado actualizado correctamente.", "Éxito",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close(); // cierra el form de edición
                    }
                    else
                    {
                        MessageBox.Show("No se pudo actualizar el empleado.", "Error",
                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al actualizar empleado: {ex.Message}", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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

        private void TNombre_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TNombre.Text))
            {
                string texto = TNombre.Text.ToLower(); // todo en minúscula
                TNombre.Text = char.ToUpper(texto[0]) + texto.Substring(1); // primera en mayúscula
            }
        }
    }
}
