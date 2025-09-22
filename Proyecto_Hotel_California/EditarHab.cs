using HotelCalifornia.Styles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace HotelCalifornia
{
    public partial class EditarHab : Form
    {
        private int habitacionNumero;
        public EditarHab(int numero_hab)
        {
            InitializeComponent();
            ApplyStyles();
            habitacionNumero = numero_hab;
            CargarHabitacion();
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
                    if (button.Name.Contains("Fin") || button.Name.Contains("Guardar"))
                        AppStyles.ApplySuccessButtonStyle(button);
                    else if (button.Name.Contains("Cancelar") || button.Name.Contains("BCancelar"))
                        AppStyles.ApplySecondaryButtonStyle(button);
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

        private void CargarHabitacion()
        {
            using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
            {
                conn.Open();
                string query = "SELECT numero_hab, piso, id_tipo, id_estado FROM Habitacion WHERE numero_hab = @Numero_hab";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Numero_hab", habitacionNumero);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        // Mostrar Numero de la habitacion en el título o label
                        LNum.Text = reader["Numero_hab"].ToString();
                        LNumPiso.Text = reader["Piso"].ToString();
                        if (reader["Id_tipo"].Equals(1))
                        {
                            RBSingle.Checked = true;
                        }
                        else if (reader["Id_estado"].Equals(2))
                        {
                            RBDoble.Checked = true;
                        }
                        else
                        {
                            RBSuite.Checked = true;
                        }

                        if (reader["Id_estado"].Equals(1))
                        {
                            RBDisp.Checked = true;
                        }
                        else if(reader["Id_estado"].Equals(2))
                        {
                            RBOcup.Checked = true;
                        }
                        else
                        {
                            RBInha.Checked = true;
                        }                        
                    }
                    else
                    {
                        MessageBox.Show("No se encontró la habitación con ese Número.");
                        this.Close();
                    }
                }
            }
        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BFin_Click(object sender, EventArgs e)
        {

        }
    }
}
