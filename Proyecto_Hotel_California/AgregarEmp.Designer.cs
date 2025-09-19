namespace Proyecto_Hotel_California
{
    partial class AgregarEmp
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
            this.LTitulo = new System.Windows.Forms.Label();
            this.LApellido = new System.Windows.Forms.Label();
            this.LNombre = new System.Windows.Forms.Label();
            this.LTelefono = new System.Windows.Forms.Label();
            this.LEmail = new System.Windows.Forms.Label();
            this.LLegajo = new System.Windows.Forms.Label();
            this.TApellido = new System.Windows.Forms.TextBox();
            this.TNombre = new System.Windows.Forms.TextBox();
            this.TTelefono = new System.Windows.Forms.TextBox();
            this.TEmail = new System.Windows.Forms.TextBox();
            this.TLegajo = new System.Windows.Forms.TextBox();
            this.LRol = new System.Windows.Forms.Label();
            this.RBSuper = new System.Windows.Forms.RadioButton();
            this.RBAdmin = new System.Windows.Forms.RadioButton();
            this.RBRecep = new System.Windows.Forms.RadioButton();
            this.PRol = new System.Windows.Forms.Panel();
            this.BFin = new System.Windows.Forms.Button();
            this.BCancelar = new System.Windows.Forms.Button();
            this.PRol.SuspendLayout();
            this.SuspendLayout();
            // 
            // LTitulo
            // 
            this.LTitulo.AutoSize = true;
            this.LTitulo.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTitulo.Location = new System.Drawing.Point(137, 9);
            this.LTitulo.Name = "LTitulo";
            this.LTitulo.Size = new System.Drawing.Size(370, 31);
            this.LTitulo.TabIndex = 0;
            this.LTitulo.Text = "Ingrese los datos del empleado";
            // 
            // LApellido
            // 
            this.LApellido.AutoSize = true;
            this.LApellido.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LApellido.Location = new System.Drawing.Point(15, 53);
            this.LApellido.Name = "LApellido";
            this.LApellido.Size = new System.Drawing.Size(62, 19);
            this.LApellido.TabIndex = 1;
            this.LApellido.Text = "Apellido";
            // 
            // LNombre
            // 
            this.LNombre.AutoSize = true;
            this.LNombre.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LNombre.Location = new System.Drawing.Point(13, 85);
            this.LNombre.Name = "LNombre";
            this.LNombre.Size = new System.Drawing.Size(66, 19);
            this.LNombre.TabIndex = 2;
            this.LNombre.Text = "Nombres";
            // 
            // LTelefono
            // 
            this.LTelefono.AutoSize = true;
            this.LTelefono.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTelefono.Location = new System.Drawing.Point(13, 120);
            this.LTelefono.Name = "LTelefono";
            this.LTelefono.Size = new System.Drawing.Size(64, 19);
            this.LTelefono.TabIndex = 3;
            this.LTelefono.Text = "Teléfono";
            // 
            // LEmail
            // 
            this.LEmail.AutoSize = true;
            this.LEmail.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LEmail.Location = new System.Drawing.Point(15, 152);
            this.LEmail.Name = "LEmail";
            this.LEmail.Size = new System.Drawing.Size(47, 19);
            this.LEmail.TabIndex = 4;
            this.LEmail.Text = "Email";
            // 
            // LLegajo
            // 
            this.LLegajo.AutoSize = true;
            this.LLegajo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LLegajo.Location = new System.Drawing.Point(16, 187);
            this.LLegajo.Name = "LLegajo";
            this.LLegajo.Size = new System.Drawing.Size(54, 19);
            this.LLegajo.TabIndex = 5;
            this.LLegajo.Text = "Legajo";
            // 
            // TApellido
            // 
            this.TApellido.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TApellido.Location = new System.Drawing.Point(82, 50);
            this.TApellido.Name = "TApellido";
            this.TApellido.Size = new System.Drawing.Size(242, 26);
            this.TApellido.TabIndex = 7;
            this.TApellido.Leave += new System.EventHandler(this.TApellido_Leave);
            // 
            // TNombre
            // 
            this.TNombre.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TNombre.Location = new System.Drawing.Point(82, 82);
            this.TNombre.Name = "TNombre";
            this.TNombre.Size = new System.Drawing.Size(242, 26);
            this.TNombre.TabIndex = 8;
            this.TNombre.Leave += new System.EventHandler(this.TNombre_Leave);
            // 
            // TTelefono
            // 
            this.TTelefono.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TTelefono.Location = new System.Drawing.Point(82, 117);
            this.TTelefono.Name = "TTelefono";
            this.TTelefono.Size = new System.Drawing.Size(242, 26);
            this.TTelefono.TabIndex = 9;
            // 
            // TEmail
            // 
            this.TEmail.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TEmail.Location = new System.Drawing.Point(82, 149);
            this.TEmail.Name = "TEmail";
            this.TEmail.Size = new System.Drawing.Size(242, 26);
            this.TEmail.TabIndex = 10;
            // 
            // TLegajo
            // 
            this.TLegajo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TLegajo.Location = new System.Drawing.Point(82, 184);
            this.TLegajo.Name = "TLegajo";
            this.TLegajo.Size = new System.Drawing.Size(242, 26);
            this.TLegajo.TabIndex = 11;
            // 
            // LRol
            // 
            this.LRol.AutoSize = true;
            this.LRol.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LRol.Location = new System.Drawing.Point(16, 241);
            this.LRol.Name = "LRol";
            this.LRol.Size = new System.Drawing.Size(30, 19);
            this.LRol.TabIndex = 14;
            this.LRol.Text = "Rol";
            // 
            // RBSuper
            // 
            this.RBSuper.AutoSize = true;
            this.RBSuper.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RBSuper.Location = new System.Drawing.Point(146, 8);
            this.RBSuper.Name = "RBSuper";
            this.RBSuper.Size = new System.Drawing.Size(96, 23);
            this.RBSuper.TabIndex = 15;
            this.RBSuper.Text = "Supervisor";
            this.RBSuper.UseVisualStyleBackColor = true;
            // 
            // RBAdmin
            // 
            this.RBAdmin.AutoSize = true;
            this.RBAdmin.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RBAdmin.Location = new System.Drawing.Point(266, 8);
            this.RBAdmin.Name = "RBAdmin";
            this.RBAdmin.Size = new System.Drawing.Size(120, 23);
            this.RBAdmin.TabIndex = 16;
            this.RBAdmin.Text = "Administrador";
            this.RBAdmin.UseVisualStyleBackColor = true;
            // 
            // RBRecep
            // 
            this.RBRecep.AutoSize = true;
            this.RBRecep.Checked = true;
            this.RBRecep.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RBRecep.Location = new System.Drawing.Point(8, 8);
            this.RBRecep.Name = "RBRecep";
            this.RBRecep.Size = new System.Drawing.Size(115, 23);
            this.RBRecep.TabIndex = 17;
            this.RBRecep.TabStop = true;
            this.RBRecep.Text = "Recepcionista";
            this.RBRecep.UseVisualStyleBackColor = true;
            // 
            // PRol
            // 
            this.PRol.Controls.Add(this.RBAdmin);
            this.PRol.Controls.Add(this.RBRecep);
            this.PRol.Controls.Add(this.RBSuper);
            this.PRol.Location = new System.Drawing.Point(82, 233);
            this.PRol.Name = "PRol";
            this.PRol.Size = new System.Drawing.Size(403, 34);
            this.PRol.TabIndex = 18;
            // 
            // BFin
            // 
            this.BFin.Location = new System.Drawing.Point(348, 336);
            this.BFin.Name = "BFin";
            this.BFin.Size = new System.Drawing.Size(75, 23);
            this.BFin.TabIndex = 19;
            this.BFin.Text = "Finalizar";
            this.BFin.UseVisualStyleBackColor = true;
            this.BFin.Click += new System.EventHandler(this.BFin_Click);
            // 
            // BCancelar
            // 
            this.BCancelar.Location = new System.Drawing.Point(192, 336);
            this.BCancelar.Name = "BCancelar";
            this.BCancelar.Size = new System.Drawing.Size(75, 23);
            this.BCancelar.TabIndex = 20;
            this.BCancelar.Text = "Cancelar";
            this.BCancelar.UseVisualStyleBackColor = true;
            this.BCancelar.Click += new System.EventHandler(this.BCancelar_Click);
            // 
            // AgregarEmp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(685, 406);
            this.Controls.Add(this.BCancelar);
            this.Controls.Add(this.BFin);
            this.Controls.Add(this.PRol);
            this.Controls.Add(this.LRol);
            this.Controls.Add(this.TLegajo);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "AgregarEmp";
            this.Text = "Ingresar Empleado";
            this.PRol.ResumeLayout(false);
            this.PRol.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LTitulo;
        private System.Windows.Forms.Label LApellido;
        private System.Windows.Forms.Label LNombre;
        private System.Windows.Forms.Label LTelefono;
        private System.Windows.Forms.Label LEmail;
        private System.Windows.Forms.Label LLegajo;
        private System.Windows.Forms.TextBox TApellido;
        private System.Windows.Forms.TextBox TNombre;
        private System.Windows.Forms.TextBox TTelefono;
        private System.Windows.Forms.TextBox TEmail;
        private System.Windows.Forms.TextBox TLegajo;
        private System.Windows.Forms.Label LRol;
        private System.Windows.Forms.RadioButton RBSuper;
        private System.Windows.Forms.RadioButton RBAdmin;
        private System.Windows.Forms.RadioButton RBRecep;
        private System.Windows.Forms.Panel PRol;
        private System.Windows.Forms.Button BFin;
        private System.Windows.Forms.Button BCancelar;
    }
}