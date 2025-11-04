using System;
using System.Windows.Forms;

namespace HotelCalifornia
{
    /// <summary>
    /// Formulario para agregar nuevos empleados al sistema del hotel.
    /// Permite ingresar información personal y laboral de los empleados.
    /// </summary>
    public partial class AgregarEmp : Form
    {
        /// <summary>
        /// Inicializa una nueva instancia del formulario AgregarEmp y
        /// configura los componentes necesarios para la interfaz de usuario.
        /// </summary>
        public AgregarEmp()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Maneja el evento de carga del formulario AgregarEmp, ejecutando
        /// las tareas de inicialización necesarias como cargar departamentos y cargos.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los argumentos del evento.</param>
        private void AgregarEmp_Load(object sender, EventArgs e)
        {
            // Inicialización del formulario AgregarEmp
        }
    }
}
