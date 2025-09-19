using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HotelCalifornia;
using Proyecto_Hotel_California.Styles;

namespace Proyecto_Hotel_California
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            ApplyStyles();
            ConfigureMenuByRole();
            UpdateHeader();
            DatabaseHelper.InitializeDatabase();
        }

        private void ApplyStyles()
        {
            AppStyles.ApplyFormStyle(this);
        }

        private void abrirFormHIjo(object formhijo)
        {
            if (this.PContenedor.Controls.Count > 0)
                this.PContenedor.Controls.RemoveAt(0);
            Form fh = formhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.PContenedor.Controls.Add(fh);
            this.PContenedor.Tag = fh;
            fh.Show();
            
            // Si es el formulario Home, forzar refresh después de mostrarlo
            if (fh is Home homeForm)
            {
                // Usar múltiples intentos para asegurar que se cargue correctamente
                Timer refreshTimer = new Timer();
                refreshTimer.Interval = 100;
                int attempts = 0;
                refreshTimer.Tick += (s, e) =>
                {
                    attempts++;
                    homeForm.ForceRefresh();
                    
                    if (attempts >= 2) // Intentar 2 veces
                    {
                        refreshTimer.Stop();
                        refreshTimer.Dispose();
                    }
                };
                refreshTimer.Start();
            }
        }

        private void BInicio_Click(object sender, EventArgs e)
        {
            abrirFormHIjo(new Home());
        }

        private void BClientes_Click(object sender, EventArgs e)
        {
            abrirFormHIjo(new Clientes());
        }

        private void BEmpleados_Click(object sender, EventArgs e)
        {
            if (!UserSession.HasPermission("supervisor"))
            {
                MessageBox.Show("No tiene permisos para acceder a esta sección.", 
                              "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            abrirFormHIjo(new Empleados());
        }

        private void BHabitaciones_Click(object sender, EventArgs e)
        {
            abrirFormHIjo(new Habitaciones());
        }

        private void BReservas_Click(object sender, EventArgs e)
        {
            abrirFormHIjo(new Reservas());
        }

        private void BPagos_Click(object sender, EventArgs e)
        {
            abrirFormHIjo(new Pagos());
        }

        private void ConfigureMenuByRole()
        {
            if (!UserSession.IsLoggedIn)
            {
                // Si no hay sesión, ocultar todo
                BEmpleados.Visible = false;
                BReservas.Visible = false;
                BPagos.Visible = false;
                BClientes.Visible = false;
                BHabitaciones.Visible = false;
                return;
            }

            string userRole = UserSession.GetUserRole();

            switch (userRole)
            {
                case "Administrador":
                    // Administrador: acceso completo
                    BEmpleados.Visible = true;
                    BReservas.Visible = true;
                    BPagos.Visible = true;
                    BClientes.Visible = true;
                    BHabitaciones.Visible = true;
                    break;

                case "Supervisor":
                    // Supervisor: acceso a empleados y reservas
                    BEmpleados.Visible = true;
                    BReservas.Visible = true;
                    BPagos.Visible = true;
                    BClientes.Visible = true;
                    BHabitaciones.Visible = true;
                    break;

                case "Recepcionista":
                    // Recepcionista: NO ver empleados, sí reservas y pagos
                    BEmpleados.Visible = false;
                    BReservas.Visible = true;
                    BPagos.Visible = true;
                    BClientes.Visible = true;
                    BHabitaciones.Visible = true;
                    break;

                default:
                    // Por defecto, ocultar todo
                    BEmpleados.Visible = false;
                    BReservas.Visible = false;
                    BPagos.Visible = false;
                    BClientes.Visible = false;
                    BHabitaciones.Visible = false;
                    break;
            }
        }

        private void UpdateHeader()
        {
            if (UserSession.IsLoggedIn)
            {
                this.Text = $"Hotel California — {UserSession.GetUserRole()}";
            }
            else
            {
                this.Text = "Hotel California";
            }
        }

        private void BLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro que desea cerrar sesión?", 
                                                "Confirmar Cierre de Sesión", 
                                                MessageBoxButtons.YesNo, 
                                                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                UserSession.Logout();
                MessageBox.Show("Sesión cerrada exitosamente.", "Información", 
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                // Cerrar el formulario actual y mostrar login
                this.Hide();
                LoginForm loginForm = new LoginForm();
                loginForm.ShowDialog();
                this.Close();
            }
        }

    }
}
