using System;
using System.Drawing;
using System.Windows.Forms;
using HotelCalifornia.Styles;

namespace HotelCalifornia
{
    public class BaseResponsiveForm : Form
    {
        private Timer resizeTimer;
        private Size lastSize = Size.Empty;
        private bool isAdjusting = false;

        public BaseResponsiveForm()
        {
            // Configurar para reducir parpadeo y mejorar performance
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | 
                         ControlStyles.UserPaint | 
                         ControlStyles.DoubleBuffer | 
                         ControlStyles.ResizeRedraw, true);

            // Eventos para responsive design
            this.Resize += BaseResponsiveForm_Resize;
            this.Load += BaseResponsiveForm_Load;
        }

        private void BaseResponsiveForm_Load(object sender, EventArgs e)
        {
            ApplyResponsiveLayout();
        }

        private void BaseResponsiveForm_Resize(object sender, EventArgs e)
        {
            // Desactivado el resize automático para evitar problemas
            // Solo aplicar estilos una vez al cargar
        }

        private void ApplyResponsiveLayoutDelayed()
        {
            if (resizeTimer != null)
            {
                resizeTimer.Stop();
                resizeTimer.Dispose();
            }

            resizeTimer = new Timer();
            resizeTimer.Interval = 150;
            resizeTimer.Tick += (s, args) =>
            {
                resizeTimer.Stop();
                resizeTimer.Dispose();
                resizeTimer = null;
                ApplyResponsiveLayout();
            };
            resizeTimer.Start();
        }

        protected virtual void ApplyResponsiveLayout()
        {
            if (isAdjusting) return;

            isAdjusting = true;
            lastSize = this.Size;

            try
            {
                this.SuspendLayout();
                
                // Aplicar estilos base
                AppStyles.ApplyFormStyle(this);
                
                // Ajustar controles según el tamaño de la ventana
                AdjustControlsForScreenSize();
                
                this.ResumeLayout(false);
                this.PerformLayout();
            }
            finally
            {
                isAdjusting = false;
            }
        }

        protected virtual void AdjustControlsForScreenSize()
        {
            // Solo aplicar estilos básicos sin modificar layouts
            foreach (Control control in this.Controls)
            {
                ApplyBasicStyles(control);
            }
        }
        
        private void ApplyBasicStyles(Control control)
        {
            // Aplicar estilos básicos sin modificar tamaños o posiciones
            // NO aplicar estilos a DataGridView para evitar problemas de superposición
            if (control is Button button)
            {
                AdjustButton(button);
            }
            else if (control is TextBox textBox)
            {
                AppStyles.ApplyTextBoxStyle(textBox);
            }
            else if (control is GroupBox groupBox)
            {
                AppStyles.ApplyGroupBoxStyle(groupBox);
            }
            else if (control is Panel panel)
            {
                AppStyles.ApplyPanelStyle(panel);
            }
            
            // Recursivo para controles contenedores
            if (control.HasChildren)
            {
                foreach (Control child in control.Controls)
                {
                    ApplyBasicStyles(child);
                }
            }
        }

        private void AdjustControlRecursive(Control control)
        {
            // NO ajustar DataGridView para evitar problemas
            // Solo ajustar otros controles
            if (control is GroupBox groupBox)
            {
                AdjustGroupBox(groupBox);
            }
            // Ajustar Panel
            else if (control is Panel panel)
            {
                AdjustPanel(panel);
            }
            // Ajustar botones
            else if (control is Button button)
            {
                AdjustButton(button);
            }
            // Ajustar TextBox
            else if (control is TextBox textBox)
            {
                AdjustTextBox(textBox);
            }

            // Recursivo para controles contenedores
            if (control.HasChildren)
            {
                foreach (Control child in control.Controls)
                {
                    AdjustControlRecursive(child);
                }
            }
        }

        protected virtual void AdjustGroupBox(GroupBox groupBox)
        {
            AppStyles.ApplyGroupBoxStyle(groupBox);
            
            // Ajustar ancho si no está anclado
            if (groupBox.Anchor == AnchorStyles.None || groupBox.Dock == DockStyle.None)
            {
                int maxWidth = this.ClientSize.Width - groupBox.Left - 20;
                if (maxWidth > 0)
                {
                    groupBox.Width = Math.Min(groupBox.Width, maxWidth);
                }
            }
        }

        protected virtual void AdjustPanel(Panel panel)
        {
            AppStyles.ApplyPanelStyle(panel);
        }

        protected virtual void AdjustButton(Button button)
        {
            // Aplicar estilos según el nombre del botón
            if (button.Name.ToLower().Contains("agregar") || button.Name.ToLower().Contains("nuevo"))
                AppStyles.ApplySuccessButtonStyle(button);
            else if (button.Name.ToLower().Contains("editar") || button.Name.ToLower().Contains("modificar"))
                AppStyles.ApplyWarningButtonStyle(button);
            else if (button.Name.ToLower().Contains("eliminar") || button.Name.ToLower().Contains("borrar"))
                AppStyles.ApplyErrorButtonStyle(button);
            else if (button.Name.ToLower().Contains("buscar") || button.Name.ToLower().Contains("filtrar"))
                AppStyles.ApplyPrimaryButtonStyle(button);
            else
                AppStyles.ApplySecondaryButtonStyle(button);
        }

        protected virtual void AdjustTextBox(TextBox textBox)
        {
            AppStyles.ApplyTextBoxStyle(textBox);
        }

        // Cleanup
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (resizeTimer != null)
                {
                    resizeTimer.Stop();
                    resizeTimer.Dispose();
                    resizeTimer = null;
                }
            }
            base.Dispose(disposing);
        }
    }
}
