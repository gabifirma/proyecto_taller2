namespace Proyecto_Hotel_California
{
    partial class Reservas
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
            this.LTituloReservas = new System.Windows.Forms.Label();
            this.GrillaReservas = new System.Windows.Forms.DataGridView();
            this.groupBoxFiltros = new System.Windows.Forms.GroupBox();
            this.btnLimpiarFiltros = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lblEstado = new System.Windows.Forms.Label();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.lblFechaFin = new System.Windows.Forms.Label();
            this.lblFechaInicio = new System.Windows.Forms.Label();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.lblBuscarCliente = new System.Windows.Forms.Label();
            this.txtBuscarCliente = new System.Windows.Forms.TextBox();
            this.btnNuevaReserva = new System.Windows.Forms.Button();
            this.btnVerPagos = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaReservas)).BeginInit();
            this.groupBoxFiltros.SuspendLayout();
            this.SuspendLayout();
            // 
            // LTituloReservas
            // 
            this.LTituloReservas.AutoSize = true;
            this.LTituloReservas.Font = new System.Drawing.Font("Times New Roman", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTituloReservas.Location = new System.Drawing.Point(280, 15);
            this.LTituloReservas.Name = "LTituloReservas";
            this.LTituloReservas.Size = new System.Drawing.Size(194, 28);
            this.LTituloReservas.TabIndex = 0;
            this.LTituloReservas.Text = "Gestión de Reservas";
            // 
            // GrillaReservas
            // 
            this.GrillaReservas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GrillaReservas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrillaReservas.Location = new System.Drawing.Point(12, 200);
            this.GrillaReservas.Name = "GrillaReservas";
            this.GrillaReservas.ReadOnly = true;
            this.GrillaReservas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GrillaReservas.Size = new System.Drawing.Size(710, 250);
            this.GrillaReservas.TabIndex = 1;
            this.GrillaReservas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrillaReservas_CellDoubleClick);
            // 
            // groupBoxFiltros
            // 
            this.groupBoxFiltros.Controls.Add(this.btnLimpiarFiltros);
            this.groupBoxFiltros.Controls.Add(this.btnBuscar);
            this.groupBoxFiltros.Controls.Add(this.lblEstado);
            this.groupBoxFiltros.Controls.Add(this.cmbEstado);
            this.groupBoxFiltros.Controls.Add(this.lblFechaFin);
            this.groupBoxFiltros.Controls.Add(this.lblFechaInicio);
            this.groupBoxFiltros.Controls.Add(this.dtpFechaFin);
            this.groupBoxFiltros.Controls.Add(this.dtpFechaInicio);
            this.groupBoxFiltros.Controls.Add(this.lblBuscarCliente);
            this.groupBoxFiltros.Controls.Add(this.txtBuscarCliente);
            this.groupBoxFiltros.Location = new System.Drawing.Point(12, 50);
            this.groupBoxFiltros.Name = "groupBoxFiltros";
            this.groupBoxFiltros.Size = new System.Drawing.Size(580, 100);
            this.groupBoxFiltros.TabIndex = 2;
            this.groupBoxFiltros.TabStop = false;
            this.groupBoxFiltros.Text = "Filtros de Búsqueda";
            // 
            // txtBuscarCliente
            // 
            this.txtBuscarCliente.Location = new System.Drawing.Point(80, 25);
            this.txtBuscarCliente.Name = "txtBuscarCliente";
            this.txtBuscarCliente.Size = new System.Drawing.Size(150, 20);
            this.txtBuscarCliente.TabIndex = 0;
            // 
            // lblBuscarCliente
            // 
            this.lblBuscarCliente.AutoSize = true;
            this.lblBuscarCliente.Location = new System.Drawing.Point(15, 28);
            this.lblBuscarCliente.Name = "lblBuscarCliente";
            this.lblBuscarCliente.Size = new System.Drawing.Size(42, 13);
            this.lblBuscarCliente.TabIndex = 1;
            this.lblBuscarCliente.Text = "Cliente:";
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicio.Location = new System.Drawing.Point(310, 25);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(100, 20);
            this.dtpFechaInicio.TabIndex = 2;
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin.Location = new System.Drawing.Point(470, 25);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(100, 20);
            this.dtpFechaFin.TabIndex = 3;
            // 
            // lblFechaInicio
            // 
            this.lblFechaInicio.AutoSize = true;
            this.lblFechaInicio.Location = new System.Drawing.Point(245, 28);
            this.lblFechaInicio.Name = "lblFechaInicio";
            this.lblFechaInicio.Size = new System.Drawing.Size(68, 13);
            this.lblFechaInicio.TabIndex = 4;
            this.lblFechaInicio.Text = "Fecha Inicio:";
            // 
            // lblFechaFin
            // 
            this.lblFechaFin.AutoSize = true;
            this.lblFechaFin.Location = new System.Drawing.Point(420, 28);
            this.lblFechaFin.Name = "lblFechaFin";
            this.lblFechaFin.Size = new System.Drawing.Size(57, 13);
            this.lblFechaFin.TabIndex = 5;
            this.lblFechaFin.Text = "Fecha Fin:";
            // 
            // cmbEstado
            // 
            this.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Items.AddRange(new object[] {
            "Todos",
            "Confirmada",
            "Pendiente",
            "Anulada"});
            this.cmbEstado.Location = new System.Drawing.Point(80, 55);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(150, 21);
            this.cmbEstado.TabIndex = 6;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(15, 58);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(43, 13);
            this.lblEstado.TabIndex = 7;
            this.lblEstado.Text = "Estado:";
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(310, 55);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 25);
            this.btnBuscar.TabIndex = 8;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnLimpiarFiltros
            // 
            this.btnLimpiarFiltros.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnLimpiarFiltros.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiarFiltros.ForeColor = System.Drawing.Color.White;
            this.btnLimpiarFiltros.Location = new System.Drawing.Point(400, 55);
            this.btnLimpiarFiltros.Name = "btnLimpiarFiltros";
            this.btnLimpiarFiltros.Size = new System.Drawing.Size(75, 25);
            this.btnLimpiarFiltros.TabIndex = 9;
            this.btnLimpiarFiltros.Text = "Limpiar";
            this.btnLimpiarFiltros.UseVisualStyleBackColor = false;
            this.btnLimpiarFiltros.Click += new System.EventHandler(this.btnLimpiarFiltros_Click);
            // 
            // btnNuevaReserva
            // 
            this.btnNuevaReserva.BackColor = System.Drawing.Color.Green;
            this.btnNuevaReserva.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevaReserva.ForeColor = System.Drawing.Color.White;
            this.btnNuevaReserva.Location = new System.Drawing.Point(600, 70);
            this.btnNuevaReserva.Name = "btnNuevaReserva";
            this.btnNuevaReserva.Size = new System.Drawing.Size(120, 35);
            this.btnNuevaReserva.TabIndex = 3;
            this.btnNuevaReserva.Text = "Nueva Reserva";
            this.btnNuevaReserva.UseVisualStyleBackColor = false;
            this.btnNuevaReserva.Click += new System.EventHandler(this.btnNuevaReserva_Click);
            // 
            // btnVerPagos
            // 
            this.btnVerPagos.BackColor = System.Drawing.Color.Orange;
            this.btnVerPagos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerPagos.ForeColor = System.Drawing.Color.White;
            this.btnVerPagos.Location = new System.Drawing.Point(600, 115);
            this.btnVerPagos.Name = "btnVerPagos";
            this.btnVerPagos.Size = new System.Drawing.Size(120, 35);
            this.btnVerPagos.TabIndex = 4;
            this.btnVerPagos.Text = "Ver Pagos";
            this.btnVerPagos.UseVisualStyleBackColor = false;
            this.btnVerPagos.Click += new System.EventHandler(this.btnVerPagos_Click);
            // 
            // Reservas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(734, 511);
            this.Controls.Add(this.btnVerPagos);
            this.Controls.Add(this.btnNuevaReserva);
            this.Controls.Add(this.groupBoxFiltros);
            this.Controls.Add(this.GrillaReservas);
            this.Controls.Add(this.LTituloReservas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Reservas";
            this.Text = "Reservas";
            this.Load += new System.EventHandler(this.Reservas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GrillaReservas)).EndInit();
            this.groupBoxFiltros.ResumeLayout(false);
            this.groupBoxFiltros.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LTituloReservas;
        private System.Windows.Forms.DataGridView GrillaReservas;
        private System.Windows.Forms.GroupBox groupBoxFiltros;
        private System.Windows.Forms.TextBox txtBuscarCliente;
        private System.Windows.Forms.Label lblBuscarCliente;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.Label lblFechaInicio;
        private System.Windows.Forms.Label lblFechaFin;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnLimpiarFiltros;
        private System.Windows.Forms.Button btnNuevaReserva;
        private System.Windows.Forms.Button btnVerPagos;
    }
}