namespace Proyecto_Hotel_California
{
    partial class Empleados
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
            this.GrillaEmpleados = new System.Windows.Forms.DataGridView();
            this.Legajo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Apellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LTituloEmp = new System.Windows.Forms.Label();
            this.BAgregarEmp = new System.Windows.Forms.Button();
            this.TLegajo = new System.Windows.Forms.TextBox();
            this.TEmail = new System.Windows.Forms.TextBox();
            this.TTelefono = new System.Windows.Forms.TextBox();
            this.TNombre = new System.Windows.Forms.TextBox();
            this.TApellido = new System.Windows.Forms.TextBox();
            this.LLegajo = new System.Windows.Forms.Label();
            this.LEmail = new System.Windows.Forms.Label();
            this.LTelefono = new System.Windows.Forms.Label();
            this.LNombre = new System.Windows.Forms.Label();
            this.LApellido = new System.Windows.Forms.Label();
            this.TBuscar = new System.Windows.Forms.TextBox();
            this.LBuscar = new System.Windows.Forms.Label();
            this.BBuscar = new System.Windows.Forms.Button();
            this.BRecargar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaEmpleados)).BeginInit();
            this.SuspendLayout();
            // 
            // GrillaEmpleados
            // 
            this.GrillaEmpleados.AllowUserToAddRows = false;
            this.GrillaEmpleados.AllowUserToDeleteRows = false;
            this.GrillaEmpleados.AllowUserToResizeRows = false;
            this.GrillaEmpleados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GrillaEmpleados.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GrillaEmpleados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrillaEmpleados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Legajo,
            this.Apellido,
            this.Nombre,
            this.Telefono,
            this.Email,
            this.Estado});
            this.GrillaEmpleados.EnableHeadersVisualStyles = false;
            this.GrillaEmpleados.Location = new System.Drawing.Point(12, 250);
            this.GrillaEmpleados.Name = "GrillaEmpleados";
            this.GrillaEmpleados.RowHeadersVisible = false;
            this.GrillaEmpleados.Size = new System.Drawing.Size(840, 252);
            this.GrillaEmpleados.TabIndex = 0;
            this.GrillaEmpleados.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrillaEmpleados_CellDoubleClick);
            // 
            // Legajo
            // 
            this.Legajo.DataPropertyName = "legajo";
            this.Legajo.HeaderText = "Legajo";
            this.Legajo.Name = "Legajo";
            // 
            // Apellido
            // 
            this.Apellido.DataPropertyName = "apellido";
            this.Apellido.HeaderText = "Apellido";
            this.Apellido.Name = "Apellido";
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "nombre";
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            // 
            // Telefono
            // 
            this.Telefono.DataPropertyName = "telefono";
            this.Telefono.HeaderText = "Teléfono";
            this.Telefono.Name = "Telefono";
            // 
            // Email
            // 
            this.Email.DataPropertyName = "email";
            this.Email.HeaderText = "Email";
            this.Email.Name = "Email";
            // 
            // Estado
            // 
            this.Estado.DataPropertyName = "estado";
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Estado.ToolTipText = "Estado";
            // 
            // LTituloEmp
            // 
            this.LTituloEmp.AutoSize = true;
            this.LTituloEmp.Font = new System.Drawing.Font("Times New Roman", 21.75F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTituloEmp.Location = new System.Drawing.Point(6, 9);
            this.LTituloEmp.Name = "LTituloEmp";
            this.LTituloEmp.Size = new System.Drawing.Size(262, 33);
            this.LTituloEmp.TabIndex = 1;
            this.LTituloEmp.Text = "Grilla de Empleados";
            // 
            // BAgregarEmp
            // 
            this.BAgregarEmp.Location = new System.Drawing.Point(696, 55);
            this.BAgregarEmp.Name = "BAgregarEmp";
            this.BAgregarEmp.Size = new System.Drawing.Size(156, 40);
            this.BAgregarEmp.TabIndex = 2;
            this.BAgregarEmp.Text = "Agregar";
            this.BAgregarEmp.UseVisualStyleBackColor = true;
            this.BAgregarEmp.Click += new System.EventHandler(this.BAgregarEmp_Click);
            // 
            // TLegajo
            // 
            this.TLegajo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TLegajo.Location = new System.Drawing.Point(87, 119);
            this.TLegajo.Name = "TLegajo";
            this.TLegajo.Size = new System.Drawing.Size(247, 26);
            this.TLegajo.TabIndex = 30;
            // 
            // TEmail
            // 
            this.TEmail.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TEmail.Location = new System.Drawing.Point(422, 90);
            this.TEmail.Name = "TEmail";
            this.TEmail.Size = new System.Drawing.Size(260, 26);
            this.TEmail.TabIndex = 29;
            // 
            // TTelefono
            // 
            this.TTelefono.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TTelefono.Location = new System.Drawing.Point(87, 87);
            this.TTelefono.Name = "TTelefono";
            this.TTelefono.Size = new System.Drawing.Size(247, 26);
            this.TTelefono.TabIndex = 28;
            // 
            // TNombre
            // 
            this.TNombre.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TNombre.Location = new System.Drawing.Point(422, 55);
            this.TNombre.Name = "TNombre";
            this.TNombre.Size = new System.Drawing.Size(260, 26);
            this.TNombre.TabIndex = 27;
            this.TNombre.Leave += new System.EventHandler(this.TNombre_Leave);
            // 
            // TApellido
            // 
            this.TApellido.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TApellido.Location = new System.Drawing.Point(87, 55);
            this.TApellido.Name = "TApellido";
            this.TApellido.Size = new System.Drawing.Size(247, 26);
            this.TApellido.TabIndex = 26;
            this.TApellido.Leave += new System.EventHandler(this.TApellido_Leave);
            // 
            // LLegajo
            // 
            this.LLegajo.AutoSize = true;
            this.LLegajo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LLegajo.Location = new System.Drawing.Point(21, 122);
            this.LLegajo.Name = "LLegajo";
            this.LLegajo.Size = new System.Drawing.Size(54, 19);
            this.LLegajo.TabIndex = 25;
            this.LLegajo.Text = "Legajo";
            // 
            // LEmail
            // 
            this.LEmail.AutoSize = true;
            this.LEmail.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LEmail.Location = new System.Drawing.Point(355, 93);
            this.LEmail.Name = "LEmail";
            this.LEmail.Size = new System.Drawing.Size(47, 19);
            this.LEmail.TabIndex = 24;
            this.LEmail.Text = "Email";
            // 
            // LTelefono
            // 
            this.LTelefono.AutoSize = true;
            this.LTelefono.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTelefono.Location = new System.Drawing.Point(18, 90);
            this.LTelefono.Name = "LTelefono";
            this.LTelefono.Size = new System.Drawing.Size(64, 19);
            this.LTelefono.TabIndex = 23;
            this.LTelefono.Text = "Teléfono";
            // 
            // LNombre
            // 
            this.LNombre.AutoSize = true;
            this.LNombre.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LNombre.Location = new System.Drawing.Point(353, 58);
            this.LNombre.Name = "LNombre";
            this.LNombre.Size = new System.Drawing.Size(66, 19);
            this.LNombre.TabIndex = 22;
            this.LNombre.Text = "Nombres";
            // 
            // LApellido
            // 
            this.LApellido.AutoSize = true;
            this.LApellido.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LApellido.Location = new System.Drawing.Point(20, 58);
            this.LApellido.Name = "LApellido";
            this.LApellido.Size = new System.Drawing.Size(62, 19);
            this.LApellido.TabIndex = 21;
            this.LApellido.Text = "Apellido";
            // 
            // TBuscar
            // 
            this.TBuscar.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBuscar.Location = new System.Drawing.Point(12, 218);
            this.TBuscar.Name = "TBuscar";
            this.TBuscar.Size = new System.Drawing.Size(282, 26);
            this.TBuscar.TabIndex = 32;
            // 
            // LBuscar
            // 
            this.LBuscar.AutoSize = true;
            this.LBuscar.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBuscar.Location = new System.Drawing.Point(13, 196);
            this.LBuscar.Name = "LBuscar";
            this.LBuscar.Size = new System.Drawing.Size(53, 19);
            this.LBuscar.TabIndex = 31;
            this.LBuscar.Text = "Buscar";
            // 
            // BBuscar
            // 
            this.BBuscar.Location = new System.Drawing.Point(309, 219);
            this.BBuscar.Name = "BBuscar";
            this.BBuscar.Size = new System.Drawing.Size(93, 25);
            this.BBuscar.TabIndex = 41;
            this.BBuscar.Text = "Buscar";
            this.BBuscar.UseVisualStyleBackColor = true;
            this.BBuscar.Click += new System.EventHandler(this.BFiltrar_Click);
            // 
            // BRecargar
            // 
            this.BRecargar.Location = new System.Drawing.Point(408, 219);
            this.BRecargar.Name = "BRecargar";
            this.BRecargar.Size = new System.Drawing.Size(105, 25);
            this.BRecargar.TabIndex = 42;
            this.BRecargar.Text = "Recargar";
            this.BRecargar.UseVisualStyleBackColor = true;
            this.BRecargar.Click += new System.EventHandler(this.BRecargar_Click);
            // 
            // Empleados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(864, 510);
            this.Controls.Add(this.BRecargar);
            this.Controls.Add(this.BBuscar);
            this.Controls.Add(this.TBuscar);
            this.Controls.Add(this.LBuscar);
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
            this.Controls.Add(this.BAgregarEmp);
            this.Controls.Add(this.LTituloEmp);
            this.Controls.Add(this.GrillaEmpleados);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Empleados";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Empleados_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GrillaEmpleados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView GrillaEmpleados;
        private System.Windows.Forms.Label LTituloEmp;
        private System.Windows.Forms.Button BAgregarEmp;
        private System.Windows.Forms.DataGridViewTextBoxColumn Legajo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Apellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.TextBox TLegajo;
        private System.Windows.Forms.TextBox TEmail;
        private System.Windows.Forms.TextBox TTelefono;
        private System.Windows.Forms.TextBox TNombre;
        private System.Windows.Forms.TextBox TApellido;
        private System.Windows.Forms.Label LLegajo;
        private System.Windows.Forms.Label LEmail;
        private System.Windows.Forms.Label LTelefono;
        private System.Windows.Forms.Label LNombre;
        private System.Windows.Forms.Label LApellido;
        private System.Windows.Forms.TextBox TBuscar;
        private System.Windows.Forms.Label LBuscar;
        private System.Windows.Forms.Button BBuscar;
        private System.Windows.Forms.Button BRecargar;
    }
}