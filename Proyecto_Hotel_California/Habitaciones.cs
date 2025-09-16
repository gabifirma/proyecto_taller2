using HotelCalifornia;
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

namespace Proyecto_Hotel_California
{
    public partial class Habitaciones : Form
    {
        public Habitaciones()
        {
            InitializeComponent();
        }

        private void BAgregarHab_Click(object sender, EventArgs e)
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
                using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
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

        private void BEditarHab_Click(object sender, EventArgs e)
        {
            EditarHab ventana = new EditarHab();
            ventana.ShowDialog();
        }

        private void Habitaciones_Load(object sender, EventArgs e)
        {
            string conexion = "Server=DESKTOP-9V9JJ39\\SQLEXPRESS;Database=Hotel;Trusted_Connection=True;";

            using (SqlConnection conn = new SqlConnection(conexion))
            {
                conn.Open();
                string query = @"SELECT 
                    h.numero_hab, 
                    h.piso, 
                    h.id_estado, 
                    t.nombre, 
                    t.capacidad, 
                    t.descripcion,
                    t.base_precio
                 FROM Habitacion h
                 INNER JOIN TipoHabitacion t ON h.id_tipo = t.id_tipo";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                GrillaHabitaciones.AutoGenerateColumns = false;
                GrillaHabitaciones.Columns["numero_hab"].DataPropertyName = "numero_hab";
                GrillaHabitaciones.Columns["piso"].DataPropertyName = "piso";
                GrillaHabitaciones.Columns["id_estado"].DataPropertyName = "id_estado";
                GrillaHabitaciones.Columns["nombre"].DataPropertyName = "nombre";
                GrillaHabitaciones.Columns["capacidad"].DataPropertyName = "capacidad";
                GrillaHabitaciones.Columns["descripcion"].DataPropertyName = "descripcion";
                GrillaHabitaciones.Columns["base_precio"].DataPropertyName = "base_precio";
                GrillaHabitaciones.DataSource = dt;
            }
        }
    }
}
