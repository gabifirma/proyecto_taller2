using HotelCalifornia.Models;
using HotelCalifornia.Services;
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
    public partial class CrearPagoForm : Form
    {
        private int idReserva;

        public CrearPagoForm(int idRes)
        {
            InitializeComponent();
            idReserva = idRes;
        }

        private void CrearPagoForm_Load(object sender, EventArgs e)
        {
            InitializeForm();
        }

        private void CargarEmpleado()
        {
            using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
            {
                conn.Open();
                string query = "SELECT apellido, nombre, legajo, telefono, email, estado FROM Empleado WHERE legajo = @Legajo";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Legajo", empleadoLegajo);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        // Mostrar ID del empleado en el título o label
                        TApellido.Text = reader["Apellido"].ToString();
                        TNombre.Text = reader["Nombre"].ToString();
                        LMostrarLeg.Text = reader["Legajo"].ToString();
                        TTelefono.Text = reader["Telefono"].ToString();
                        TEmail.Text = reader["Email"].ToString();
                        if (reader["estado"].Equals(true))
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
                        MessageBox.Show("No se encontró el empleado con ese ID.");
                        this.Close();
                    }
                }
            }
        }

        private void InitializeForm()
        {
            // Configurar fecha por defecto
            dtpFechaPago.Value = DateTime.Now;
            dtpFechaPago.MaxDate = DateTime.Now; // No permitir fechas futuras

            // Cargar reservas disponibles
            LoadReservas();

            // Configurar métodos de pago
            cmbMetodoPago.Items.AddRange(new string[]
            {
                "Efectivo",
                "Tarjeta", 
                "Transferencia",
                "Cheque"
            });

            // Configurar estados
            cmbEstado.Items.AddRange(new string[]
            {
                "Pendiente",
                "Confirmado"
            });
            cmbEstado.SelectedIndex = 0; // Pendiente por defecto

            // Eventos
            cmbReserva.SelectedIndexChanged += CmbReserva_SelectedIndexChanged;
        }



        private void btnGuardar_Click(object sender, EventArgs e)
        {
           
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
