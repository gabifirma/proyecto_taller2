namespace Proyecto_Hotel_California
{
    partial class Clientes
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
            this.GrillaClientes = new System.Windows.Forms.DataGridView();
            this.DNI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Apellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Teléfono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dirección = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaAlta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Activo = new System.Windows.Forms.DataGridViewButtonColumn();
            this.LTituloClientes = new System.Windows.Forms.Label();
            this.LNombre = new System.Windows.Forms.Label();
            this.TNombre = new System.Windows.Forms.TextBox();
            this.TApellido = new System.Windows.Forms.TextBox();
            this.LApellido = new System.Windows.Forms.Label();
            this.TDni = new System.Windows.Forms.TextBox();
            this.LDni = new System.Windows.Forms.Label();
            this.TTelefono = new System.Windows.Forms.TextBox();
            this.LTelefono = new System.Windows.Forms.Label();
            this.LEstado = new System.Windows.Forms.Label();
            this.RActivo = new System.Windows.Forms.RadioButton();
            this.RInactivo = new System.Windows.Forms.RadioButton();
            this.BBuscar = new System.Windows.Forms.Button();
            this.LFechaA = new System.Windows.Forms.Label();
            this.DTClientes = new System.Windows.Forms.DateTimePicker();
            this.TEmail = new System.Windows.Forms.TextBox();
            this.LEmail = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // GrillaClientes
            // 
            this.GrillaClientes.AllowUserToAddRows = false;
            this.GrillaClientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GrillaClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrillaClientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DNI,
            this.Apellido,
            this.Nombre,
            this.Teléfono,
            this.Email,
            this.Dirección,
            this.FechaAlta,
            this.Activo});
            this.GrillaClientes.Location = new System.Drawing.Point(12, 255);
            this.GrillaClientes.Name = "GrillaClientes";
            this.GrillaClientes.RowHeadersVisible = false;
            this.GrillaClientes.Size = new System.Drawing.Size(710, 150);
            this.GrillaClientes.TabIndex = 1;
            // 
            // DNI
            // 
            this.DNI.HeaderText = "DNI";
            this.DNI.Name = "DNI";
            // 
            // Apellido
            // 
            this.Apellido.HeaderText = "Apellido";
            this.Apellido.Name = "Apellido";
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            // 
            // Teléfono
            // 
            this.Teléfono.HeaderText = "Teléfono";
            this.Teléfono.Name = "Teléfono";
            // 
            // Email
            // 
            this.Email.HeaderText = "Email";
            this.Email.Name = "Email";
            // 
            // Dirección
            // 
            this.Dirección.HeaderText = "Dirección";
            this.Dirección.Name = "Dirección";
            // 
            // FechaAlta
            // 
            this.FechaAlta.HeaderText = "Fecha de Alta";
            this.FechaAlta.Name = "FechaAlta";
            // 
            // Activo
            // 
            this.Activo.HeaderText = "Estado";
            this.Activo.Name = "Activo";
            this.Activo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Activo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Activo.Text = "Cambiar Estado";
            this.Activo.ToolTipText = "Estado";
            // 
            // LTituloClientes
            // 
            this.LTituloClientes.AutoSize = true;
            this.LTituloClientes.Font = new System.Drawing.Font("Times New Roman", 18F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTituloClientes.Location = new System.Drawing.Point(286, 20);
            this.LTituloClientes.Name = "LTituloClientes";
            this.LTituloClientes.Size = new System.Drawing.Size(187, 28);
            this.LTituloClientes.TabIndex = 2;
            this.LTituloClientes.Text = "Grilla de Clientes";
            // 
            // LNombre
            // 
            this.LNombre.AutoSize = true;
            this.LNombre.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LNombre.Location = new System.Drawing.Point(9, 64);
            this.LNombre.Name = "LNombre";
            this.LNombre.Size = new System.Drawing.Size(76, 22);
            this.LNombre.TabIndex = 3;
            this.LNombre.Text = "Nombre";
            // 
            // TNombre
            // 
            this.TNombre.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TNombre.Location = new System.Drawing.Point(91, 63);
            this.TNombre.Name = "TNombre";
            this.TNombre.Size = new System.Drawing.Size(166, 26);
            this.TNombre.TabIndex = 4;
            this.TNombre.Leave += new System.EventHandler(this.TNombre_Leave);
            // 
            // TApellido
            // 
            this.TApellido.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TApellido.Location = new System.Drawing.Point(369, 64);
            this.TApellido.Name = "TApellido";
            this.TApellido.Size = new System.Drawing.Size(166, 26);
            this.TApellido.TabIndex = 6;
            this.TApellido.Leave += new System.EventHandler(this.TApellido_Leave);
            // 
            // LApellido
            // 
            this.LApellido.AutoSize = true;
            this.LApellido.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LApellido.Location = new System.Drawing.Point(287, 65);
            this.LApellido.Name = "LApellido";
            this.LApellido.Size = new System.Drawing.Size(77, 22);
            this.LApellido.TabIndex = 5;
            this.LApellido.Text = "Apellido";
            // 
            // TDni
            // 
            this.TDni.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TDni.Location = new System.Drawing.Point(91, 108);
            this.TDni.Name = "TDni";
            this.TDni.Size = new System.Drawing.Size(166, 26);
            this.TDni.TabIndex = 8;
            // 
            // LDni
            // 
            this.LDni.AutoSize = true;
            this.LDni.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LDni.Location = new System.Drawing.Point(9, 109);
            this.LDni.Name = "LDni";
            this.LDni.Size = new System.Drawing.Size(45, 22);
            this.LDni.TabIndex = 7;
            this.LDni.Text = "DNI";
            // 
            // TTelefono
            // 
            this.TTelefono.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TTelefono.Location = new System.Drawing.Point(369, 109);
            this.TTelefono.Name = "TTelefono";
            this.TTelefono.Size = new System.Drawing.Size(166, 26);
            this.TTelefono.TabIndex = 10;
            // 
            // LTelefono
            // 
            this.LTelefono.AutoSize = true;
            this.LTelefono.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTelefono.Location = new System.Drawing.Point(287, 110);
            this.LTelefono.Name = "LTelefono";
            this.LTelefono.Size = new System.Drawing.Size(80, 22);
            this.LTelefono.TabIndex = 9;
            this.LTelefono.Text = "Teléfono";
            // 
            // LEstado
            // 
            this.LEstado.AutoSize = true;
            this.LEstado.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LEstado.Location = new System.Drawing.Point(287, 158);
            this.LEstado.Name = "LEstado";
            this.LEstado.Size = new System.Drawing.Size(67, 22);
            this.LEstado.TabIndex = 13;
            this.LEstado.Text = "Estado";
            // 
            // RActivo
            // 
            this.RActivo.AutoSize = true;
            this.RActivo.Checked = true;
            this.RActivo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RActivo.Location = new System.Drawing.Point(369, 158);
            this.RActivo.Name = "RActivo";
            this.RActivo.Size = new System.Drawing.Size(70, 23);
            this.RActivo.TabIndex = 14;
            this.RActivo.TabStop = true;
            this.RActivo.Text = "Activo";
            this.RActivo.UseVisualStyleBackColor = true;
            // 
            // RInactivo
            // 
            this.RInactivo.AutoSize = true;
            this.RInactivo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RInactivo.Location = new System.Drawing.Point(454, 158);
            this.RInactivo.Name = "RInactivo";
            this.RInactivo.Size = new System.Drawing.Size(81, 23);
            this.RInactivo.TabIndex = 15;
            this.RInactivo.Text = "Inactivo";
            this.RInactivo.UseVisualStyleBackColor = true;
            // 
            // BBuscar
            // 
            this.BBuscar.Location = new System.Drawing.Point(591, 110);
            this.BBuscar.Name = "BBuscar";
            this.BBuscar.Size = new System.Drawing.Size(84, 34);
            this.BBuscar.TabIndex = 16;
            this.BBuscar.Text = "Buscar";
            this.BBuscar.UseVisualStyleBackColor = true;
            this.BBuscar.Click += new System.EventHandler(this.BBuscar_Click);
            // 
            // LFechaA
            // 
            this.LFechaA.AutoSize = true;
            this.LFechaA.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LFechaA.Location = new System.Drawing.Point(9, 199);
            this.LFechaA.Name = "LFechaA";
            this.LFechaA.Size = new System.Drawing.Size(82, 22);
            this.LFechaA.TabIndex = 11;
            this.LFechaA.Text = "Fecha A.";
            // 
            // DTClientes
            // 
            this.DTClientes.Location = new System.Drawing.Point(91, 201);
            this.DTClientes.Name = "DTClientes";
            this.DTClientes.Size = new System.Drawing.Size(200, 20);
            this.DTClientes.TabIndex = 17;
            // 
            // TEmail
            // 
            this.TEmail.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TEmail.Location = new System.Drawing.Point(91, 155);
            this.TEmail.Name = "TEmail";
            this.TEmail.Size = new System.Drawing.Size(166, 26);
            this.TEmail.TabIndex = 19;
            // 
            // LEmail
            // 
            this.LEmail.AutoSize = true;
            this.LEmail.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LEmail.Location = new System.Drawing.Point(9, 156);
            this.LEmail.Name = "LEmail";
            this.LEmail.Size = new System.Drawing.Size(58, 22);
            this.LEmail.TabIndex = 18;
            this.LEmail.Text = "Email";
            // 
            // Clientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(734, 511);
            this.Controls.Add(this.TEmail);
            this.Controls.Add(this.LEmail);
            this.Controls.Add(this.DTClientes);
            this.Controls.Add(this.BBuscar);
            this.Controls.Add(this.RInactivo);
            this.Controls.Add(this.RActivo);
            this.Controls.Add(this.LEstado);
            this.Controls.Add(this.LFechaA);
            this.Controls.Add(this.TTelefono);
            this.Controls.Add(this.LTelefono);
            this.Controls.Add(this.TDni);
            this.Controls.Add(this.LDni);
            this.Controls.Add(this.TApellido);
            this.Controls.Add(this.LApellido);
            this.Controls.Add(this.TNombre);
            this.Controls.Add(this.LNombre);
            this.Controls.Add(this.LTituloClientes);
            this.Controls.Add(this.GrillaClientes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Clientes";
            this.Text = "Clientes";
            ((System.ComponentModel.ISupportInitialize)(this.GrillaClientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView GrillaClientes;
        private System.Windows.Forms.Label LTituloClientes;
        private System.Windows.Forms.DataGridViewTextBoxColumn DNI;
        private System.Windows.Forms.DataGridViewTextBoxColumn Apellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Teléfono;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dirección;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaAlta;
        private System.Windows.Forms.DataGridViewButtonColumn Activo;
        private System.Windows.Forms.Label LNombre;
        private System.Windows.Forms.TextBox TNombre;
        private System.Windows.Forms.TextBox TApellido;
        private System.Windows.Forms.Label LApellido;
        private System.Windows.Forms.TextBox TDni;
        private System.Windows.Forms.Label LDni;
        private System.Windows.Forms.TextBox TTelefono;
        private System.Windows.Forms.Label LTelefono;
        private System.Windows.Forms.Label LEstado;
        private System.Windows.Forms.RadioButton RActivo;
        private System.Windows.Forms.RadioButton RInactivo;
        private System.Windows.Forms.Button BBuscar;
        private System.Windows.Forms.Label LFechaA;
        private System.Windows.Forms.DateTimePicker DTClientes;
        private System.Windows.Forms.TextBox TEmail;
        private System.Windows.Forms.Label LEmail;
    }
}