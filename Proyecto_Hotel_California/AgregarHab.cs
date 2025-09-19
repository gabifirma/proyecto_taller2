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
using Proyecto_Hotel_California.Styles;

namespace Proyecto_Hotel_California
{
    public partial class AgregarHab : Form
    {
        public AgregarHab()
        {
            InitializeComponent();
            ApplyStyles();
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

        private void BCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BFin_Click(object sender, EventArgs e)
        {
            Boolean valorPiso = int.TryParse(TPiso.Text, out int piso);
            Boolean valorNum = int.TryParse(TNumero.Text, out int num);

            if (!valorNum)
            {
                MessageBox.Show("El NÚMERO o esta vacío o no es un número");
                return;
            }

            if (!valorPiso)
            {
                MessageBox.Show("El PISO o esta vacío o no es un número");
                return;
            }

            if (valorPiso && valorNum)
            {
                // Cambia la cadena de conexión por la de tu base de datos
                string conexion = "Server=DESKTOP-9V9JJ39\\SQLEXPRESS;Database=Hotel;Trusted_Connection=True;";

                using (SqlConnection conn = new SqlConnection(conexion))
                {
                    conn.Open();

                    string query = "INSERT INTO Habitacion (numero_hab, piso, id_tipo, id_estado) " +
                                   "VALUES (@Numero_hab, @Piso, @Id_tipo, @Id_estado)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Numero_hab", TNumero.Text);
                        cmd.Parameters.AddWithValue("@Piso", TPiso.Text);
                        if (RBSingle.Checked)
                        {
                            cmd.Parameters.AddWithValue("@Id_tipo", 1);
                        }
                        else if (RBDoble.Checked)
                        {
                            cmd.Parameters.AddWithValue("@Id_tipo", 2);
                        }
                        else if (RBSuite.Checked)
                        {
                            cmd.Parameters.AddWithValue("@Id_tipo", 3);
                        }

                        if (RBDisp.Checked)
                        {
                            cmd.Parameters.AddWithValue("@Id_estado", 1);
                        }
                        else if (RBOcup.Checked)
                        {
                            cmd.Parameters.AddWithValue("@Id_estado", 2);
                        }
                        else if (RBInha.Checked)
                        {
                            cmd.Parameters.AddWithValue("@Id_estado", 3);
                        }

                        int filas = cmd.ExecuteNonQuery();

                        if (filas > 0)
                        {
                            MessageBox.Show("Habitación guardada correctamente en la base de datos.");

                        }
                        else
                        {
                            MessageBox.Show("No se pudo guardar la habitación.");
                        }
                        this.Close();
                    }
                }
            }
        }
    }
}
