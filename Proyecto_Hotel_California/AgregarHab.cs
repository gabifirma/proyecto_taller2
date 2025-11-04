using System;
using System.Windows.Forms;

namespace HotelCalifornia
{
    /// <summary>
    /// Formulario para agregar nuevas habitaciones al sistema del hotel.
    /// Permite ingresar información básica como número, tipo y características de la habitación.
    /// </summary>
    public partial class AgregarHab : Form
    {
        /// <summary>
        /// Inicializa una nueva instancia del formulario AgregarHab y
        /// configura los componentes necesarios para la interfaz de usuario.
        /// </summary>
        public AgregarHab()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Maneja el evento de carga del formulario AgregarHab, ejecutando
        /// las tareas de inicialización necesarias como cargar tipos de habitación disponibles.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los argumentos del evento.</param>
        private void AgregarHab_Load(object sender, EventArgs e)
        {
            // Inicialización del formulario AgregarHab
        }
    }
}
