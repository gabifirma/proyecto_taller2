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
using static System.Net.Mime.MediaTypeNames;


namespace Proyecto_Hotel_California
{
    public partial class AgregarEmp : Form
    {
        public AgregarEmp()
        {
            InitializeComponent();
        }
        // función de validación
        private bool SoloLetras(string texto)
        {
            return Regex.IsMatch(texto, @"^[a-zA-Z]+$");
        }

        private bool SoloNumeros(string texto)
        {
            return Regex.IsMatch(texto, @"^[0-9]+$");
        }

        private void BFin_Click(object sender, EventArgs e)
        {
            Boolean valorApellido = !String.IsNullOrEmpty(TApellido.Text);
            Boolean valorNombre = !String.IsNullOrEmpty(TNombre.Text);
            Boolean valorLegajo = int.TryParse(TLegajo.Text, out int legajo);
            Boolean valorTelefono = !String.IsNullOrEmpty(TTelefono.Text);
            Boolean valorEmail = !String.IsNullOrEmpty(TEmail.Text);

            if (!valorApellido)
            {
                MessageBox.Show("El campo APELLIDO no puede estar vacío.");
                return;
            }

            if (!valorNombre)
            {
                MessageBox.Show("El campo NOMBRE no puede estar vacío.");
                return;
            }            

            if (!SoloLetras(TApellido.Text) || !SoloLetras(TNombre.Text))
            {
                MessageBox.Show("Solo se permiten letras para nombre y apellido");
                return;
            }

            if (!valorTelefono)
            {
                MessageBox.Show("El campo TELÉFONO no puede estar vacío");
                return;
            }

            if (!SoloNumeros(TTelefono.Text))
            {
                MessageBox.Show("Solo se permiten números para teléfono");
                return;
            }

            if (!valorEmail)
            {
                MessageBox.Show("Campo EMAIL vacío");
                return;
            }

            if (!valorLegajo)
            {
                MessageBox.Show("El LEGAJO o esta vacío o no es un número");
                return;
            }

            //guardarlo todo en la base de datos
            if (SoloLetras(TApellido.Text) && SoloLetras(TNombre.Text) && valorLegajo && SoloNumeros(TTelefono.Text) && valorEmail)
            {
                // Cambia la cadena de conexión por la de tu base de datos
                string conexion = "Server=DESKTOP-9V9JJ39\\SQLEXPRESS;Database=Hotel;Trusted_Connection=True;";

                using (SqlConnection conn = new SqlConnection(conexion))
                {
                    conn.Open();

                    string query = "INSERT INTO Empleado (apellido, nombre, legajo, telefono, email, estado) " +
                                   "VALUES (@Apellido, @Nombre, @Legajo, @Telefono, @Email, @Estado)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Apellido", TApellido.Text);
                        cmd.Parameters.AddWithValue("@Nombre", TNombre.Text);
                        cmd.Parameters.AddWithValue("@Legajo", TLegajo.Text);
                        cmd.Parameters.AddWithValue("@Telefono", TTelefono.Text);
                        cmd.Parameters.AddWithValue("@Email", TEmail.Text);
                        cmd.Parameters.AddWithValue("@Estado", true);

                        int filas = cmd.ExecuteNonQuery();

                        if (filas > 0)
                        {
                            MessageBox.Show("Empleado guardado correctamente en la base de datos.");
                            
                        }
                        else
                        {
                            MessageBox.Show("No se pudo guardar el empleado.");
                        }
                        this.Close();
                    }
                }
            }
        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
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
