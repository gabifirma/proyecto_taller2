namespace HotelCalifornia
{
    partial class Empleados
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Empleados));
            this.GrillaEmpleados = new System.Windows.Forms.DataGridView();
            this.LTituloEmp = new System.Windows.Forms.Label();
            this.BAgregarEmp = new System.Windows.Forms.Button();
            this.TBuscar = new System.Windows.Forms.TextBox();
            this.LBuscar = new System.Windows.Forms.Label();
            this.BBuscar = new System.Windows.Forms.Button();
            this.BRecargar = new System.Windows.Forms.Button();
            this.Legajo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Apellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.estado});
            this.GrillaEmpleados.EnableHeadersVisualStyles = false;
            this.GrillaEmpleados.Location = new System.Drawing.Point(14, 135);
            this.GrillaEmpleados.Margin = new System.Windows.Forms.Padding(4);
            this.GrillaEmpleados.Name = "GrillaEmpleados";
            this.GrillaEmpleados.ReadOnly = true;
            this.GrillaEmpleados.RowHeadersVisible = false;
            this.GrillaEmpleados.Size = new System.Drawing.Size(980, 493);
            this.GrillaEmpleados.TabIndex = 0;
            this.GrillaEmpleados.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrillaEmpleados_CellDoubleClick);
            // 
            // LTituloEmp
            // 
            this.LTituloEmp.AutoSize = true;
            this.LTituloEmp.Font = new System.Drawing.Font("Times New Roman", 21.75F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTituloEmp.Location = new System.Drawing.Point(7, 12);
            this.LTituloEmp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LTituloEmp.Name = "LTituloEmp";
            this.LTituloEmp.Size = new System.Drawing.Size(262, 33);
            this.LTituloEmp.TabIndex = 1;
            this.LTituloEmp.Text = "Grilla de Empleados";
            // 
            // BAgregarEmp
            // 
            this.BAgregarEmp.Image = ((System.Drawing.Image)(resources.GetObject("BAgregarEmp.Image")));
            this.BAgregarEmp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BAgregarEmp.Location = new System.Drawing.Point(850, 75);
            this.BAgregarEmp.Margin = new System.Windows.Forms.Padding(4);
            this.BAgregarEmp.Name = "BAgregarEmp";
            this.BAgregarEmp.Size = new System.Drawing.Size(144, 52);
            this.BAgregarEmp.TabIndex = 2;
            this.BAgregarEmp.Text = "Agregar";
            this.BAgregarEmp.UseVisualStyleBackColor = true;
            this.BAgregarEmp.Click += new System.EventHandler(this.BAgregarEmp_Click);
            // 
            // TBuscar
            // 
            this.TBuscar.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBuscar.Location = new System.Drawing.Point(14, 91);
            this.TBuscar.Margin = new System.Windows.Forms.Padding(4);
            this.TBuscar.Name = "TBuscar";
            this.TBuscar.Size = new System.Drawing.Size(328, 26);
            this.TBuscar.TabIndex = 3;
            // 
            // LBuscar
            // 
            this.LBuscar.AutoSize = true;
            this.LBuscar.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBuscar.Location = new System.Drawing.Point(15, 62);
            this.LBuscar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBuscar.Name = "LBuscar";
            this.LBuscar.Size = new System.Drawing.Size(53, 19);
            this.LBuscar.TabIndex = 31;
            this.LBuscar.Text = "Buscar";
            // 
            // BBuscar
            // 
            this.BBuscar.Image = ((System.Drawing.Image)(resources.GetObject("BBuscar.Image")));
            this.BBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BBuscar.Location = new System.Drawing.Point(360, 87);
            this.BBuscar.Margin = new System.Windows.Forms.Padding(4);
            this.BBuscar.Name = "BBuscar";
            this.BBuscar.Size = new System.Drawing.Size(108, 33);
            this.BBuscar.TabIndex = 4;
            this.BBuscar.Text = "Buscar";
            this.BBuscar.UseVisualStyleBackColor = true;
            this.BBuscar.Click += new System.EventHandler(this.BFiltrar_Click);
            // 
            // BRecargar
            // 
            this.BRecargar.Image = ((System.Drawing.Image)(resources.GetObject("BRecargar.Image")));
            this.BRecargar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BRecargar.Location = new System.Drawing.Point(476, 87);
            this.BRecargar.Margin = new System.Windows.Forms.Padding(4);
            this.BRecargar.Name = "BRecargar";
            this.BRecargar.Size = new System.Drawing.Size(122, 33);
            this.BRecargar.TabIndex = 5;
            this.BRecargar.Text = "Recargar";
            this.BRecargar.UseVisualStyleBackColor = true;
            this.BRecargar.Click += new System.EventHandler(this.BRecargar_Click);
            // 
            // Legajo
            // 
            this.Legajo.DataPropertyName = "legajo";
            this.Legajo.HeaderText = "Legajo";
            this.Legajo.Name = "Legajo";
            this.Legajo.ReadOnly = true;
            // 
            // Apellido
            // 
            this.Apellido.DataPropertyName = "apellido";
            this.Apellido.HeaderText = "Apellido";
            this.Apellido.Name = "Apellido";
            this.Apellido.ReadOnly = true;
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "nombre";
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // Telefono
            // 
            this.Telefono.DataPropertyName = "telefono";
            this.Telefono.HeaderText = "Teléfono";
            this.Telefono.Name = "Telefono";
            this.Telefono.ReadOnly = true;
            // 
            // Email
            // 
            this.Email.DataPropertyName = "email";
            this.Email.HeaderText = "Email";
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
            // 
            // estado
            // 
            this.estado.DataPropertyName = "estado";
            this.estado.HeaderText = "estado";
            this.estado.Name = "estado";
            this.estado.ReadOnly = true;
            this.estado.Visible = false;
            // 
            // Empleados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(1008, 641);
            this.Controls.Add(this.BRecargar);
            this.Controls.Add(this.BBuscar);
            this.Controls.Add(this.TBuscar);
            this.Controls.Add(this.LBuscar);
            this.Controls.Add(this.BAgregarEmp);
            this.Controls.Add(this.LTituloEmp);
            this.Controls.Add(this.GrillaEmpleados);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
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
        private System.Windows.Forms.TextBox TBuscar;
        private System.Windows.Forms.Label LBuscar;
        private System.Windows.Forms.Button BBuscar;
        private System.Windows.Forms.Button BRecargar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Legajo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Apellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn estado;
    }
}