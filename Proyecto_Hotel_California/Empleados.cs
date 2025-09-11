using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Hotel_California
{
    public partial class Empleados : Form
    {
        public Empleados()
        {
            InitializeComponent();
        }

        private void BAgregarEmp_Click(object sender, EventArgs e)
        {
            AgregarEmp ventana = new AgregarEmp();
            ventana.ShowDialog();
        }

        private void BEditarEmp_Click(object sender, EventArgs e)
        {
            EditarEmp ventana = new EditarEmp();
            ventana.ShowDialog();
        }

        private void BEliminarEmp_Click(object sender, EventArgs e)
        {

        }
    }
}
