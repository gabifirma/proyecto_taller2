namespace HotelCalifornia
{
    partial class AgregarEmpleadoConUsuario1
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
            this.LTitulo1 = new System.Windows.Forms.Label();
            this.LTituloEmpleado = new System.Windows.Forms.Label();
            this.LNombre = new System.Windows.Forms.Label();
            this.LApellido = new System.Windows.Forms.Label();
            this.LTelefono = new System.Windows.Forms.Label();
            this.LEmail = new System.Windows.Forms.Label();
            this.chkCrearUsuario = new System.Windows.Forms.CheckBox();
            this.GBUsuario = new System.Windows.Forms.GroupBox();
            this.CMBRol = new System.Windows.Forms.ComboBox();
            this.TPassword = new System.Windows.Forms.TextBox();
            this.TUsuario = new System.Windows.Forms.TextBox();
            this.LRol = new System.Windows.Forms.Label();
            this.LPassword = new System.Windows.Forms.Label();
            this.LUsuario = new System.Windows.Forms.Label();
            this.LTituloUsuario = new System.Windows.Forms.Label();
            this.TNombre = new System.Windows.Forms.TextBox();
            this.TApellido = new System.Windows.Forms.TextBox();
            this.TTelefono = new System.Windows.Forms.TextBox();
            this.TEmail = new System.Windows.Forms.TextBox();
            this.BGuardar = new System.Windows.Forms.Button();
            this.BCancelar = new System.Windows.Forms.Button();
            this.GBUsuario.SuspendLayout();
            this.SuspendLayout();
            // 
            // LTitulo1
            // 
            this.LTitulo1.AutoSize = true;
            this.LTitulo1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTitulo1.Location = new System.Drawing.Point(12, 9);
            this.LTitulo1.Name = "LTitulo1";
            this.LTitulo1.Size = new System.Drawing.Size(181, 30);
            this.LTitulo1.TabIndex = 0;
            this.LTitulo1.Text = "Nuevo Empleado";
            // 
            // LTituloEmpleado
            // 
            this.LTituloEmpleado.AutoSize = true;
            this.LTituloEmpleado.Location = new System.Drawing.Point(14, 74);
            this.LTituloEmpleado.Name = "LTituloEmpleado";
            this.LTituloEmpleado.Size = new System.Drawing.Size(102, 13);
            this.LTituloEmpleado.TabIndex = 1;
            this.LTituloEmpleado.Text = "Datos del Empleado";
            // 
            // LNombre
            // 
            this.LNombre.AutoSize = true;
            this.LNombre.Location = new System.Drawing.Point(14, 102);
            this.LNombre.Name = "LNombre";
            this.LNombre.Size = new System.Drawing.Size(47, 13);
            this.LNombre.TabIndex = 2;
            this.LNombre.Text = "Nombre:";
            // 
            // LApellido
            // 
            this.LApellido.AutoSize = true;
            this.LApellido.Location = new System.Drawing.Point(14, 132);
            this.LApellido.Name = "LApellido";
            this.LApellido.Size = new System.Drawing.Size(47, 13);
            this.LApellido.TabIndex = 3;
            this.LApellido.Text = "Apellido:";
            // 
            // LTelefono
            // 
            this.LTelefono.AutoSize = true;
            this.LTelefono.Location = new System.Drawing.Point(14, 163);
            this.LTelefono.Name = "LTelefono";
            this.LTelefono.Size = new System.Drawing.Size(52, 13);
            this.LTelefono.TabIndex = 4;
            this.LTelefono.Text = "Teléfono:";
            // 
            // LEmail
            // 
            this.LEmail.AutoSize = true;
            this.LEmail.Location = new System.Drawing.Point(17, 192);
            this.LEmail.Name = "LEmail";
            this.LEmail.Size = new System.Drawing.Size(35, 13);
            this.LEmail.TabIndex = 5;
            this.LEmail.Text = "Email:";
            // 
            // chkCrearUsuario
            // 
            this.chkCrearUsuario.AutoSize = true;
            this.chkCrearUsuario.Location = new System.Drawing.Point(20, 233);
            this.chkCrearUsuario.Name = "chkCrearUsuario";
            this.chkCrearUsuario.Size = new System.Drawing.Size(184, 17);
            this.chkCrearUsuario.TabIndex = 6;
            this.chkCrearUsuario.Text = "Crear usuario para este empleado";
            this.chkCrearUsuario.UseVisualStyleBackColor = true;
            this.chkCrearUsuario.CheckedChanged += new System.EventHandler(this.ChkCrearUsuario_CheckedChanged);
            // 
            // GBUsuario
            // 
            this.GBUsuario.Controls.Add(this.CMBRol);
            this.GBUsuario.Controls.Add(this.TPassword);
            this.GBUsuario.Controls.Add(this.TUsuario);
            this.GBUsuario.Controls.Add(this.LRol);
            this.GBUsuario.Controls.Add(this.LPassword);
            this.GBUsuario.Controls.Add(this.LUsuario);
            this.GBUsuario.Controls.Add(this.LTituloUsuario);
            this.GBUsuario.Enabled = false;
            this.GBUsuario.Location = new System.Drawing.Point(20, 256);
            this.GBUsuario.Name = "GBUsuario";
            this.GBUsuario.Size = new System.Drawing.Size(532, 160);
            this.GBUsuario.TabIndex = 7;
            this.GBUsuario.TabStop = false;
            // 
            // CMBRol
            // 
            this.CMBRol.FormattingEnabled = true;
            this.CMBRol.Location = new System.Drawing.Point(77, 124);
            this.CMBRol.Name = "CMBRol";
            this.CMBRol.Size = new System.Drawing.Size(190, 21);
            this.CMBRol.TabIndex = 18;
            // 
            // TPassword
            // 
            this.TPassword.Location = new System.Drawing.Point(77, 93);
            this.TPassword.Name = "TPassword";
            this.TPassword.PasswordChar = '*';
            this.TPassword.Size = new System.Drawing.Size(441, 20);
            this.TPassword.TabIndex = 17;
            // 
            // TUsuario
            // 
            this.TUsuario.Location = new System.Drawing.Point(77, 63);
            this.TUsuario.Name = "TUsuario";
            this.TUsuario.Size = new System.Drawing.Size(441, 20);
            this.TUsuario.TabIndex = 16;
            // 
            // LRol
            // 
            this.LRol.AutoSize = true;
            this.LRol.Location = new System.Drawing.Point(6, 127);
            this.LRol.Name = "LRol";
            this.LRol.Size = new System.Drawing.Size(26, 13);
            this.LRol.TabIndex = 14;
            this.LRol.Text = "Rol:";
            // 
            // LPassword
            // 
            this.LPassword.AutoSize = true;
            this.LPassword.Location = new System.Drawing.Point(6, 96);
            this.LPassword.Name = "LPassword";
            this.LPassword.Size = new System.Drawing.Size(64, 13);
            this.LPassword.TabIndex = 13;
            this.LPassword.Text = "Contraseña:";
            // 
            // LUsuario
            // 
            this.LUsuario.AutoSize = true;
            this.LUsuario.Location = new System.Drawing.Point(6, 66);
            this.LUsuario.Name = "LUsuario";
            this.LUsuario.Size = new System.Drawing.Size(46, 13);
            this.LUsuario.TabIndex = 12;
            this.LUsuario.Text = "Usuario:";
            // 
            // LTituloUsuario
            // 
            this.LTituloUsuario.AutoSize = true;
            this.LTituloUsuario.Location = new System.Drawing.Point(6, 34);
            this.LTituloUsuario.Name = "LTituloUsuario";
            this.LTituloUsuario.Size = new System.Drawing.Size(91, 13);
            this.LTituloUsuario.TabIndex = 7;
            this.LTituloUsuario.Text = "Datos del Usuario";
            // 
            // TNombre
            // 
            this.TNombre.Location = new System.Drawing.Point(85, 99);
            this.TNombre.Name = "TNombre";
            this.TNombre.Size = new System.Drawing.Size(441, 20);
            this.TNombre.TabIndex = 8;
            this.TNombre.Leave += new System.EventHandler(this.TNombre_Leave);
            // 
            // TApellido
            // 
            this.TApellido.Location = new System.Drawing.Point(85, 129);
            this.TApellido.Name = "TApellido";
            this.TApellido.Size = new System.Drawing.Size(441, 20);
            this.TApellido.TabIndex = 9;
            this.TApellido.Leave += new System.EventHandler(this.TApellido_Leave);
            // 
            // TTelefono
            // 
            this.TTelefono.Location = new System.Drawing.Point(85, 160);
            this.TTelefono.Name = "TTelefono";
            this.TTelefono.Size = new System.Drawing.Size(441, 20);
            this.TTelefono.TabIndex = 10;
            // 
            // TEmail
            // 
            this.TEmail.Location = new System.Drawing.Point(85, 189);
            this.TEmail.Name = "TEmail";
            this.TEmail.Size = new System.Drawing.Size(441, 20);
            this.TEmail.TabIndex = 11;
            // 
            // BGuardar
            // 
            this.BGuardar.Location = new System.Drawing.Point(136, 425);
            this.BGuardar.Name = "BGuardar";
            this.BGuardar.Size = new System.Drawing.Size(121, 41);
            this.BGuardar.TabIndex = 12;
            this.BGuardar.Text = "Guardar";
            this.BGuardar.UseVisualStyleBackColor = true;
            this.BGuardar.Click += new System.EventHandler(this.BGuardar_Click);
            // 
            // BCancelar
            // 
            this.BCancelar.Location = new System.Drawing.Point(307, 425);
            this.BCancelar.Name = "BCancelar";
            this.BCancelar.Size = new System.Drawing.Size(121, 41);
            this.BCancelar.TabIndex = 13;
            this.BCancelar.Text = "Cancelar";
            this.BCancelar.UseVisualStyleBackColor = true;
            this.BCancelar.Click += new System.EventHandler(this.BCancelar_Click);
            // 
            // AgregarEmpleadoConUsuario1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 515);
            this.Controls.Add(this.BCancelar);
            this.Controls.Add(this.BGuardar);
            this.Controls.Add(this.TEmail);
            this.Controls.Add(this.TTelefono);
            this.Controls.Add(this.TApellido);
            this.Controls.Add(this.TNombre);
            this.Controls.Add(this.GBUsuario);
            this.Controls.Add(this.chkCrearUsuario);
            this.Controls.Add(this.LEmail);
            this.Controls.Add(this.LTelefono);
            this.Controls.Add(this.LApellido);
            this.Controls.Add(this.LNombre);
            this.Controls.Add(this.LTituloEmpleado);
            this.Controls.Add(this.LTitulo1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AgregarEmpleadoConUsuario1";
            this.Text = "AgregarEmpleadoConUsuario1";
            this.GBUsuario.ResumeLayout(false);
            this.GBUsuario.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LTitulo1;
        private System.Windows.Forms.Label LTituloEmpleado;
        private System.Windows.Forms.Label LNombre;
        private System.Windows.Forms.Label LApellido;
        private System.Windows.Forms.Label LTelefono;
        private System.Windows.Forms.Label LEmail;
        private System.Windows.Forms.CheckBox chkCrearUsuario;
        private System.Windows.Forms.GroupBox GBUsuario;
        private System.Windows.Forms.Label LTituloUsuario;
        private System.Windows.Forms.TextBox TNombre;
        private System.Windows.Forms.TextBox TApellido;
        private System.Windows.Forms.TextBox TTelefono;
        private System.Windows.Forms.TextBox TEmail;
        private System.Windows.Forms.TextBox TPassword;
        private System.Windows.Forms.TextBox TUsuario;
        private System.Windows.Forms.Label LRol;
        private System.Windows.Forms.Label LPassword;
        private System.Windows.Forms.Label LUsuario;
        private System.Windows.Forms.ComboBox CMBRol;
        private System.Windows.Forms.Button BGuardar;
        private System.Windows.Forms.Button BCancelar;
    }
}