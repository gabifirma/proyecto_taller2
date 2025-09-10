using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Proyecto_Hotel_California
{
    public partial class IngresarEmp : Form
    {
        public IngresarEmp()
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

            if (SoloLetras(TApellido.Text) && SoloLetras(TNombre.Text) && valorLegajo && SoloNumeros(TTelefono.Text) && valorEmail)
            {
                MessageBox.Show("El empleado: " + TApellido.Text + " " + TNombre.Text + " se agregó correctamente.");
            }

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
        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
