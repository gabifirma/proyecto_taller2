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
            this.LBuscar = new System.Windows.Forms.Label();
            this.TBuscar = new System.Windows.Forms.TextBox();
            this.LEstado = new System.Windows.Forms.Label();
            this.RActivo = new System.Windows.Forms.RadioButton();
            this.RInactivo = new System.Windows.Forms.RadioButton();
            this.BBuscar = new System.Windows.Forms.Button();
            this.LDesde = new System.Windows.Forms.Label();
            this.DTDesde = new System.Windows.Forms.DateTimePicker();
            this.DTHasta = new System.Windows.Forms.DateTimePicker();
            this.LHasta = new System.Windows.Forms.Label();
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
            this.GrillaClientes.Location = new System.Drawing.Point(12, 150);
            this.GrillaClientes.Name = "GrillaClientes";
            this.GrillaClientes.RowHeadersVisible = false;
            this.GrillaClientes.Size = new System.Drawing.Size(840, 319);
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
            this.LTituloClientes.Font = new System.Drawing.Font("Times New Roman", 21.75F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTituloClientes.Location = new System.Drawing.Point(12, 9);
            this.LTituloClientes.Name = "LTituloClientes";
            this.LTituloClientes.Size = new System.Drawing.Size(224, 33);
            this.LTituloClientes.TabIndex = 2;
            this.LTituloClientes.Text = "Grilla de Clientes";
            // 
            // LBuscar
            // 
            this.LBuscar.AutoSize = true;
            this.LBuscar.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBuscar.Location = new System.Drawing.Point(9, 64);
            this.LBuscar.Name = "LBuscar";
            this.LBuscar.Size = new System.Drawing.Size(68, 22);
            this.LBuscar.TabIndex = 3;
            this.LBuscar.Text = "Buscar";
            // 
            // TBuscar
            // 
            this.TBuscar.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBuscar.Location = new System.Drawing.Point(91, 63);
            this.TBuscar.Name = "TBuscar";
            this.TBuscar.Size = new System.Drawing.Size(281, 26);
            this.TBuscar.TabIndex = 4;
            // 
            // LEstado
            // 
            this.LEstado.AutoSize = true;
            this.LEstado.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LEstado.Location = new System.Drawing.Point(392, 66);
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
            this.RActivo.Location = new System.Drawing.Point(474, 66);
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
            this.RInactivo.Location = new System.Drawing.Point(559, 66);
            this.RInactivo.Name = "RInactivo";
            this.RInactivo.Size = new System.Drawing.Size(81, 23);
            this.RInactivo.TabIndex = 15;
            this.RInactivo.Text = "Inactivo";
            this.RInactivo.UseVisualStyleBackColor = true;
            // 
            // BBuscar
            // 
            this.BBuscar.Location = new System.Drawing.Point(691, 78);
            this.BBuscar.Name = "BBuscar";
            this.BBuscar.Size = new System.Drawing.Size(114, 35);
            this.BBuscar.TabIndex = 16;
            this.BBuscar.Text = "Buscar";
            this.BBuscar.UseVisualStyleBackColor = true;
            this.BBuscar.Click += new System.EventHandler(this.BBuscar_Click);
            // 
            // LDesde
            // 
            this.LDesde.AutoSize = true;
            this.LDesde.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LDesde.Location = new System.Drawing.Point(9, 104);
            this.LDesde.Name = "LDesde";
            this.LDesde.Size = new System.Drawing.Size(60, 22);
            this.LDesde.TabIndex = 11;
            this.LDesde.Text = "Desde";
            // 
            // DTDesde
            // 
            this.DTDesde.Location = new System.Drawing.Point(91, 106);
            this.DTDesde.Name = "DTDesde";
            this.DTDesde.Size = new System.Drawing.Size(200, 20);
            this.DTDesde.TabIndex = 17;
            // 
            // DTHasta
            // 
            this.DTHasta.Location = new System.Drawing.Point(396, 106);
            this.DTHasta.Name = "DTHasta";
            this.DTHasta.Size = new System.Drawing.Size(200, 20);
            this.DTHasta.TabIndex = 19;
            // 
            // LHasta
            // 
            this.LHasta.AutoSize = true;
            this.LHasta.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LHasta.Location = new System.Drawing.Point(314, 104);
            this.LHasta.Name = "LHasta";
            this.LHasta.Size = new System.Drawing.Size(58, 22);
            this.LHasta.TabIndex = 18;
            this.LHasta.Text = "Hasta";
            // 
            // Clientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(864, 510);
            this.Controls.Add(this.DTHasta);
            this.Controls.Add(this.LHasta);
            this.Controls.Add(this.DTDesde);
            this.Controls.Add(this.BBuscar);
            this.Controls.Add(this.RInactivo);
            this.Controls.Add(this.RActivo);
            this.Controls.Add(this.LEstado);
            this.Controls.Add(this.LDesde);
            this.Controls.Add(this.TBuscar);
            this.Controls.Add(this.LBuscar);
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
        private System.Windows.Forms.Label LBuscar;
        private System.Windows.Forms.TextBox TBuscar;
        private System.Windows.Forms.Label LEstado;
        private System.Windows.Forms.RadioButton RActivo;
        private System.Windows.Forms.RadioButton RInactivo;
        private System.Windows.Forms.Button BBuscar;
        private System.Windows.Forms.Label LDesde;
        private System.Windows.Forms.DateTimePicker DTDesde;
        private System.Windows.Forms.DateTimePicker DTHasta;
        private System.Windows.Forms.Label LHasta;
    }
}