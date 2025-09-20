namespace HotelCalifornia
{
    partial class EditarEmp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditarEmp));
            this.BCancelar = new System.Windows.Forms.Button();
            this.BFin = new System.Windows.Forms.Button();
            this.TEmail = new System.Windows.Forms.TextBox();
            this.TTelefono = new System.Windows.Forms.TextBox();
            this.TNombre = new System.Windows.Forms.TextBox();
            this.TApellido = new System.Windows.Forms.TextBox();
            this.LLegajo = new System.Windows.Forms.Label();
            this.LEmail = new System.Windows.Forms.Label();
            this.LTelefono = new System.Windows.Forms.Label();
            this.LNombre = new System.Windows.Forms.Label();
            this.LApellido = new System.Windows.Forms.Label();
            this.LTitulo = new System.Windows.Forms.Label();
            this.LEstado = new System.Windows.Forms.Label();
            this.PEstado = new System.Windows.Forms.Panel();
            this.RBDesactivado = new System.Windows.Forms.RadioButton();
            this.RBActivado = new System.Windows.Forms.RadioButton();
            this.LMostrarLeg = new System.Windows.Forms.Label();
            this.LMantenerAct = new System.Windows.Forms.Label();
            this.LMantenerIna = new System.Windows.Forms.Label();
            this.PEstado.SuspendLayout();
            this.SuspendLayout();
            // 
            // BCancelar
            // 
            this.BCancelar.Image = ((System.Drawing.Image)(resources.GetObject("BCancelar.Image")));
            this.BCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BCancelar.Location = new System.Drawing.Point(178, 341);
            this.BCancelar.Name = "BCancelar";
            this.BCancelar.Size = new System.Drawing.Size(94, 35);
            this.BCancelar.TabIndex = 38;
            this.BCancelar.Text = "Cancelar";
            this.BCancelar.UseVisualStyleBackColor = true;
            this.BCancelar.Click += new System.EventHandler(this.BCancelar_Click);
            // 
            // BFin
            // 
            this.BFin.Image = ((System.Drawing.Image)(resources.GetObject("BFin.Image")));
            this.BFin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BFin.Location = new System.Drawing.Point(330, 341);
            this.BFin.Name = "BFin";
            this.BFin.Size = new System.Drawing.Size(92, 35);
            this.BFin.TabIndex = 37;
            this.BFin.Text = "Finalizar";
            this.BFin.UseVisualStyleBackColor = true;
            this.BFin.Click += new System.EventHandler(this.BFin_Click);
            // 
            // TEmail
            // 
            this.TEmail.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TEmail.Location = new System.Drawing.Point(87, 204);
            this.TEmail.Name = "TEmail";
            this.TEmail.Size = new System.Drawing.Size(242, 26);
            this.TEmail.TabIndex = 31;
            // 
            // TTelefono
            // 
            this.TTelefono.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TTelefono.Location = new System.Drawing.Point(87, 172);
            this.TTelefono.Name = "TTelefono";
            this.TTelefono.Size = new System.Drawing.Size(242, 26);
            this.TTelefono.TabIndex = 30;
            // 
            // TNombre
            // 
            this.TNombre.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TNombre.Location = new System.Drawing.Point(87, 140);
            this.TNombre.Name = "TNombre";
            this.TNombre.Size = new System.Drawing.Size(242, 26);
            this.TNombre.TabIndex = 29;
            this.TNombre.Leave += new System.EventHandler(this.TNombre_Leave);
            // 
            // TApellido
            // 
            this.TApellido.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TApellido.Location = new System.Drawing.Point(87, 108);
            this.TApellido.Name = "TApellido";
            this.TApellido.Size = new System.Drawing.Size(242, 26);
            this.TApellido.TabIndex = 28;
            this.TApellido.Leave += new System.EventHandler(this.TApellido_Leave);
            // 
            // LLegajo
            // 
            this.LLegajo.AutoSize = true;
            this.LLegajo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LLegajo.Location = new System.Drawing.Point(21, 77);
            this.LLegajo.Name = "LLegajo";
            this.LLegajo.Size = new System.Drawing.Size(63, 19);
            this.LLegajo.TabIndex = 26;
            this.LLegajo.Text = "Legajo: ";
            // 
            // LEmail
            // 
            this.LEmail.AutoSize = true;
            this.LEmail.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LEmail.Location = new System.Drawing.Point(20, 207);
            this.LEmail.Name = "LEmail";
            this.LEmail.Size = new System.Drawing.Size(47, 19);
            this.LEmail.TabIndex = 25;
            this.LEmail.Text = "Email";
            // 
            // LTelefono
            // 
            this.LTelefono.AutoSize = true;
            this.LTelefono.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTelefono.Location = new System.Drawing.Point(18, 175);
            this.LTelefono.Name = "LTelefono";
            this.LTelefono.Size = new System.Drawing.Size(64, 19);
            this.LTelefono.TabIndex = 24;
            this.LTelefono.Text = "Teléfono";
            // 
            // LNombre
            // 
            this.LNombre.AutoSize = true;
            this.LNombre.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LNombre.Location = new System.Drawing.Point(21, 143);
            this.LNombre.Name = "LNombre";
            this.LNombre.Size = new System.Drawing.Size(60, 19);
            this.LNombre.TabIndex = 23;
            this.LNombre.Text = "Nombre";
            // 
            // LApellido
            // 
            this.LApellido.AutoSize = true;
            this.LApellido.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LApellido.Location = new System.Drawing.Point(20, 111);
            this.LApellido.Name = "LApellido";
            this.LApellido.Size = new System.Drawing.Size(62, 19);
            this.LApellido.TabIndex = 22;
            this.LApellido.Text = "Apellido";
            // 
            // LTitulo
            // 
            this.LTitulo.AutoSize = true;
            this.LTitulo.Font = new System.Drawing.Font("Times New Roman", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTitulo.Location = new System.Drawing.Point(12, 9);
            this.LTitulo.Name = "LTitulo";
            this.LTitulo.Size = new System.Drawing.Size(369, 31);
            this.LTitulo.TabIndex = 21;
            this.LTitulo.Text = "Edición de datos del empleado";
            // 
            // LEstado
            // 
            this.LEstado.AutoSize = true;
            this.LEstado.Font = new System.Drawing.Font("Times New Roman", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LEstado.Location = new System.Drawing.Point(450, 108);
            this.LEstado.Name = "LEstado";
            this.LEstado.Size = new System.Drawing.Size(189, 23);
            this.LEstado.TabIndex = 39;
            this.LEstado.Text = "Estado del empleado";
            // 
            // PEstado
            // 
            this.PEstado.Controls.Add(this.RBDesactivado);
            this.PEstado.Controls.Add(this.RBActivado);
            this.PEstado.Location = new System.Drawing.Point(416, 140);
            this.PEstado.Name = "PEstado";
            this.PEstado.Size = new System.Drawing.Size(249, 35);
            this.PEstado.TabIndex = 40;
            // 
            // RBDesactivado
            // 
            this.RBDesactivado.AutoSize = true;
            this.RBDesactivado.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RBDesactivado.Location = new System.Drawing.Point(133, 3);
            this.RBDesactivado.Name = "RBDesactivado";
            this.RBDesactivado.Size = new System.Drawing.Size(107, 23);
            this.RBDesactivado.TabIndex = 1;
            this.RBDesactivado.TabStop = true;
            this.RBDesactivado.Text = "Desactivado";
            this.RBDesactivado.UseVisualStyleBackColor = true;
            // 
            // RBActivado
            // 
            this.RBActivado.AutoSize = true;
            this.RBActivado.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RBActivado.Location = new System.Drawing.Point(29, 3);
            this.RBActivado.Name = "RBActivado";
            this.RBActivado.Size = new System.Drawing.Size(85, 23);
            this.RBActivado.TabIndex = 0;
            this.RBActivado.TabStop = true;
            this.RBActivado.Text = "Activado";
            this.RBActivado.UseVisualStyleBackColor = true;
            // 
            // LMostrarLeg
            // 
            this.LMostrarLeg.AutoSize = true;
            this.LMostrarLeg.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LMostrarLeg.ForeColor = System.Drawing.Color.Black;
            this.LMostrarLeg.Location = new System.Drawing.Point(90, 77);
            this.LMostrarLeg.Name = "LMostrarLeg";
            this.LMostrarLeg.Size = new System.Drawing.Size(55, 19);
            this.LMostrarLeg.TabIndex = 42;
            this.LMostrarLeg.Text = "Legajo";
            // 
            // LMantenerAct
            // 
            this.LMantenerAct.AutoSize = true;
            this.LMantenerAct.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LMantenerAct.Location = new System.Drawing.Point(416, 182);
            this.LMantenerAct.Name = "LMantenerAct";
            this.LMantenerAct.Size = new System.Drawing.Size(178, 15);
            this.LMantenerAct.TabIndex = 43;
            this.LMantenerAct.Text = "* Activado para mantener activo";
            // 
            // LMantenerIna
            // 
            this.LMantenerIna.AutoSize = true;
            this.LMantenerIna.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LMantenerIna.Location = new System.Drawing.Point(416, 207);
            this.LMantenerIna.Name = "LMantenerIna";
            this.LMantenerIna.Size = new System.Drawing.Size(208, 15);
            this.LMantenerIna.TabIndex = 44;
            this.LMantenerIna.Text = "* Desactivado para mantener inactivo";
            // 
            // EditarEmp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(714, 420);
            this.ControlBox = false;
            this.Controls.Add(this.LMantenerIna);
            this.Controls.Add(this.LMantenerAct);
            this.Controls.Add(this.LMostrarLeg);
            this.Controls.Add(this.PEstado);
            this.Controls.Add(this.LEstado);
            this.Controls.Add(this.BCancelar);
            this.Controls.Add(this.BFin);
            this.Controls.Add(this.TEmail);
            this.Controls.Add(this.TTelefono);
            this.Controls.Add(this.TNombre);
            this.Controls.Add(this.TApellido);
            this.Controls.Add(this.LLegajo);
            this.Controls.Add(this.LEmail);
            this.Controls.Add(this.LTelefono);
            this.Controls.Add(this.LNombre);
            this.Controls.Add(this.LApellido);
            this.Controls.Add(this.LTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "EditarEmp";
            this.Text = "EditarEmp";
            this.PEstado.ResumeLayout(false);
            this.PEstado.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BCancelar;
        private System.Windows.Forms.Button BFin;
        private System.Windows.Forms.TextBox TEmail;
        private System.Windows.Forms.TextBox TTelefono;
        private System.Windows.Forms.TextBox TNombre;
        private System.Windows.Forms.TextBox TApellido;
        private System.Windows.Forms.Label LLegajo;
        private System.Windows.Forms.Label LEmail;
        private System.Windows.Forms.Label LTelefono;
        private System.Windows.Forms.Label LNombre;
        private System.Windows.Forms.Label LApellido;
        private System.Windows.Forms.Label LTitulo;
        private System.Windows.Forms.Label LEstado;
        private System.Windows.Forms.Panel PEstado;
        private System.Windows.Forms.RadioButton RBDesactivado;
        private System.Windows.Forms.RadioButton RBActivado;
        private System.Windows.Forms.Label LMostrarLeg;
        private System.Windows.Forms.Label LMantenerAct;
        private System.Windows.Forms.Label LMantenerIna;
    }
}