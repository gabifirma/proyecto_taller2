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
using HotelCalifornia.Styles;

namespace HotelCalifornia
{
    public partial class Habitaciones : BaseResponsiveForm
    {
        public Habitaciones()
        {
            InitializeComponent();
            // La clase base BaseResponsiveForm se encarga del responsive design automáticamente
        }
        

        // Método eliminado - los estilos se aplican automáticamente por BaseResponsiveForm

        private void BAgregarHab_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Funcionalidad de agregar habitación no implementada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BEditarHab_Click(object sender, EventArgs e)
        {
            EditarHab ventana = new EditarHab();
            ventana.ShowDialog();
        }

        private void Habitaciones_Load(object sender, EventArgs e)
        {
 

            using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
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
