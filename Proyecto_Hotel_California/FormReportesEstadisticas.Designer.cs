namespace HotelCalifornia
{
    partial class FormReportesEstadisticas
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabReservas = new System.Windows.Forms.TabPage();
            this.lblTotalIngresosReservas = new System.Windows.Forms.Label();
            this.lblTotalRegistrosReservas = new System.Windows.Forms.Label();
            this.btnExportarReservas = new System.Windows.Forms.Button();
            this.btnLimpiarFiltrosReservas = new System.Windows.Forms.Button();
            this.btnBuscarReservas = new System.Windows.Forms.Button();
            this.dgvReporteReservas = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtBusquedaReservas = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbEstadoReserva = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkFiltrarFechasReservas = new System.Windows.Forms.CheckBox();
            this.dtpFechaHastaReservas = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpFechaDesdeReservas = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPagos = new System.Windows.Forms.TabPage();
            this.lblTotalesPagos = new System.Windows.Forms.Label();
            this.lblTotalRegistrosPagos = new System.Windows.Forms.Label();
            this.btnExportarPagos = new System.Windows.Forms.Button();
            this.btnLimpiarFiltrosPagos = new System.Windows.Forms.Button();
            this.btnBuscarPagos = new System.Windows.Forms.Button();
            this.dgvReportePagos = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtBusquedaPagos = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbMetodoPago = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chkFiltrarFechasPagos = new System.Windows.Forms.CheckBox();
            this.dtpFechaHastaPagos = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpFechaDesdeePagos = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.tabEstadisticas = new System.Windows.Forms.TabPage();
            this.btnTopClientes = new System.Windows.Forms.Button();
            this.btnExportarGrafico = new System.Windows.Forms.Button();
            this.btnGenerarEstadisticas = new System.Windows.Forms.Button();
            this.panelGrafico = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbHabitacionesPopulares = new System.Windows.Forms.RadioButton();
            this.rbPagosPorMetodo = new System.Windows.Forms.RadioButton();
            this.rbIngresos = new System.Windows.Forms.RadioButton();
            this.numAño = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.rbOcupacion = new System.Windows.Forms.RadioButton();
            this.tabControl.SuspendLayout();
            this.tabReservas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporteReservas)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabPagos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReportePagos)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tabEstadisticas.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAño)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabReservas);
            this.tabControl.Controls.Add(this.tabPagos);
            this.tabControl.Controls.Add(this.tabEstadisticas);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1100, 700);
            this.tabControl.TabIndex = 0;
            // 
            // tabReservas
            // 
            this.tabReservas.Controls.Add(this.lblTotalIngresosReservas);
            this.tabReservas.Controls.Add(this.lblTotalRegistrosReservas);
            this.tabReservas.Controls.Add(this.btnExportarReservas);
            this.tabReservas.Controls.Add(this.btnLimpiarFiltrosReservas);
            this.tabReservas.Controls.Add(this.btnBuscarReservas);
            this.tabReservas.Controls.Add(this.dgvReporteReservas);
            this.tabReservas.Controls.Add(this.groupBox1);
            this.tabReservas.Location = new System.Drawing.Point(4, 22);
            this.tabReservas.Name = "tabReservas";
            this.tabReservas.Padding = new System.Windows.Forms.Padding(3);
            this.tabReservas.Size = new System.Drawing.Size(1092, 674);
            this.tabReservas.TabIndex = 0;
            this.tabReservas.Text = "Reportes de Reservas";
            this.tabReservas.UseVisualStyleBackColor = true;
            // 
            // lblTotalIngresosReservas
            // 
            this.lblTotalIngresosReservas.AutoSize = true;
            this.lblTotalIngresosReservas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotalIngresosReservas.Location = new System.Drawing.Point(300, 635);
            this.lblTotalIngresosReservas.Name = "lblTotalIngresosReservas";
            this.lblTotalIngresosReservas.Size = new System.Drawing.Size(162, 15);
            this.lblTotalIngresosReservas.TabIndex = 6;
            this.lblTotalIngresosReservas.Text = "?? Total Ingresos: $0.00";
            // 
            // lblTotalRegistrosReservas
            // 
            this.lblTotalRegistrosReservas.AutoSize = true;
            this.lblTotalRegistrosReservas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotalRegistrosReservas.Location = new System.Drawing.Point(20, 635);
            this.lblTotalRegistrosReservas.Name = "lblTotalRegistrosReservas";
            this.lblTotalRegistrosReservas.Size = new System.Drawing.Size(155, 15);
            this.lblTotalRegistrosReservas.TabIndex = 5;
            this.lblTotalRegistrosReservas.Text = "?? Total de registros: 0";
            // 
            // btnExportarReservas
            // 
            this.btnExportarReservas.Location = new System.Drawing.Point(970, 625);
            this.btnExportarReservas.Name = "btnExportarReservas";
            this.btnExportarReservas.Size = new System.Drawing.Size(100, 35);
            this.btnExportarReservas.TabIndex = 4;
            this.btnExportarReservas.Text = "Exportar";
            this.btnExportarReservas.UseVisualStyleBackColor = true;
            this.btnExportarReservas.Click += new System.EventHandler(this.btnExportarReservas_Click);
            // 
            // btnLimpiarFiltrosReservas
            // 
            this.btnLimpiarFiltrosReservas.Location = new System.Drawing.Point(850, 625);
            this.btnLimpiarFiltrosReservas.Name = "btnLimpiarFiltrosReservas";
            this.btnLimpiarFiltrosReservas.Size = new System.Drawing.Size(100, 35);
            this.btnLimpiarFiltrosReservas.TabIndex = 3;
            this.btnLimpiarFiltrosReservas.Text = "Limpiar";
            this.btnLimpiarFiltrosReservas.UseVisualStyleBackColor = true;
            this.btnLimpiarFiltrosReservas.Click += new System.EventHandler(this.btnLimpiarFiltrosReservas_Click);
            // 
            // btnBuscarReservas
            // 
            this.btnBuscarReservas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btnBuscarReservas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarReservas.ForeColor = System.Drawing.Color.White;
            this.btnBuscarReservas.Location = new System.Drawing.Point(730, 625);
            this.btnBuscarReservas.Name = "btnBuscarReservas";
            this.btnBuscarReservas.Size = new System.Drawing.Size(100, 35);
            this.btnBuscarReservas.TabIndex = 2;
            this.btnBuscarReservas.Text = "Buscar";
            this.btnBuscarReservas.UseVisualStyleBackColor = false;
            this.btnBuscarReservas.Click += new System.EventHandler(this.btnBuscarReservas_Click);
            // 
            // dgvReporteReservas
            // 
            this.dgvReporteReservas.AllowUserToAddRows = false;
            this.dgvReporteReservas.AllowUserToDeleteRows = false;
            this.dgvReporteReservas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReporteReservas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReporteReservas.Location = new System.Drawing.Point(20, 180);
            this.dgvReporteReservas.Name = "dgvReporteReservas";
            this.dgvReporteReservas.ReadOnly = true;
            this.dgvReporteReservas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReporteReservas.Size = new System.Drawing.Size(1050, 430);
            this.dgvReporteReservas.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtBusquedaReservas);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbEstadoReserva);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.chkFiltrarFechasReservas);
            this.groupBox1.Controls.Add(this.dtpFechaHastaReservas);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dtpFechaDesdeReservas);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(20, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1050, 150);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros de Búsqueda";
            // 
            // txtBusquedaReservas
            // 
            this.txtBusquedaReservas.Location = new System.Drawing.Point(203, 105);
            this.txtBusquedaReservas.Name = "txtBusquedaReservas";
            this.txtBusquedaReservas.Size = new System.Drawing.Size(300, 20);
            this.txtBusquedaReservas.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Buscar (Texto libre):";
            // 
            // cmbEstadoReserva
            // 
            this.cmbEstadoReserva.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstadoReserva.FormattingEnabled = true;
            this.cmbEstadoReserva.Location = new System.Drawing.Point(120, 70);
            this.cmbEstadoReserva.Name = "cmbEstadoReserva";
            this.cmbEstadoReserva.Size = new System.Drawing.Size(200, 21);
            this.cmbEstadoReserva.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Estado:";
            // 
            // chkFiltrarFechasReservas
            // 
            this.chkFiltrarFechasReservas.AutoSize = true;
            this.chkFiltrarFechasReservas.Location = new System.Drawing.Point(28, 32);
            this.chkFiltrarFechasReservas.Name = "chkFiltrarFechasReservas";
            this.chkFiltrarFechasReservas.Size = new System.Drawing.Size(104, 17);
            this.chkFiltrarFechasReservas.TabIndex = 4;
            this.chkFiltrarFechasReservas.Text = "Filtrar por fechas";
            this.chkFiltrarFechasReservas.UseVisualStyleBackColor = true;
            this.chkFiltrarFechasReservas.CheckedChanged += new System.EventHandler(this.chkFiltrarFechasReservas_CheckedChanged);
            // 
            // dtpFechaHastaReservas
            // 
            this.dtpFechaHastaReservas.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaHastaReservas.Location = new System.Drawing.Point(600, 30);
            this.dtpFechaHastaReservas.Name = "dtpFechaHastaReservas";
            this.dtpFechaHastaReservas.Size = new System.Drawing.Size(150, 20);
            this.dtpFechaHastaReservas.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(550, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Hasta:";
            // 
            // dtpFechaDesdeReservas
            // 
            this.dtpFechaDesdeReservas.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaDesdeReservas.Location = new System.Drawing.Point(370, 30);
            this.dtpFechaDesdeReservas.Name = "dtpFechaDesdeReservas";
            this.dtpFechaDesdeReservas.Size = new System.Drawing.Size(150, 20);
            this.dtpFechaDesdeReservas.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(320, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Desde:";
            // 
            // tabPagos
            // 
            this.tabPagos.Controls.Add(this.lblTotalesPagos);
            this.tabPagos.Controls.Add(this.lblTotalRegistrosPagos);
            this.tabPagos.Controls.Add(this.btnExportarPagos);
            this.tabPagos.Controls.Add(this.btnLimpiarFiltrosPagos);
            this.tabPagos.Controls.Add(this.btnBuscarPagos);
            this.tabPagos.Controls.Add(this.dgvReportePagos);
            this.tabPagos.Controls.Add(this.groupBox2);
            this.tabPagos.Location = new System.Drawing.Point(4, 22);
            this.tabPagos.Name = "tabPagos";
            this.tabPagos.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagos.Size = new System.Drawing.Size(1092, 674);
            this.tabPagos.TabIndex = 1;
            this.tabPagos.Text = "Reportes de Pagos";
            this.tabPagos.UseVisualStyleBackColor = true;
            // 
            // lblTotalesPagos
            // 
            this.lblTotalesPagos.AutoSize = true;
            this.lblTotalesPagos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.lblTotalesPagos.Location = new System.Drawing.Point(20, 655);
            this.lblTotalesPagos.Name = "lblTotalesPagos";
            this.lblTotalesPagos.Size = new System.Drawing.Size(450, 13);
            this.lblTotalesPagos.TabIndex = 6;
            this.lblTotalesPagos.Text = "?? Efectivo: $0.00 | ?? Tarjeta: $0.00 | ?? Transfer.: $0.00 | ?? TOTAL: $0.00";
            // 
            // lblTotalRegistrosPagos
            // 
            this.lblTotalRegistrosPagos.AutoSize = true;
            this.lblTotalRegistrosPagos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotalRegistrosPagos.Location = new System.Drawing.Point(20, 635);
            this.lblTotalRegistrosPagos.Name = "lblTotalRegistrosPagos";
            this.lblTotalRegistrosPagos.Size = new System.Drawing.Size(118, 15);
            this.lblTotalRegistrosPagos.TabIndex = 5;
            this.lblTotalRegistrosPagos.Text = "?? Total: 0 pagos";
            // 
            // btnExportarPagos
            // 
            this.btnExportarPagos.Location = new System.Drawing.Point(970, 625);
            this.btnExportarPagos.Name = "btnExportarPagos";
            this.btnExportarPagos.Size = new System.Drawing.Size(100, 35);
            this.btnExportarPagos.TabIndex = 4;
            this.btnExportarPagos.Text = "Exportar";
            this.btnExportarPagos.UseVisualStyleBackColor = true;
            this.btnExportarPagos.Click += new System.EventHandler(this.btnExportarPagos_Click);
            // 
            // btnLimpiarFiltrosPagos
            // 
            this.btnLimpiarFiltrosPagos.Location = new System.Drawing.Point(850, 625);
            this.btnLimpiarFiltrosPagos.Name = "btnLimpiarFiltrosPagos";
            this.btnLimpiarFiltrosPagos.Size = new System.Drawing.Size(100, 35);
            this.btnLimpiarFiltrosPagos.TabIndex = 3;
            this.btnLimpiarFiltrosPagos.Text = "Limpiar";
            this.btnLimpiarFiltrosPagos.UseVisualStyleBackColor = true;
            this.btnLimpiarFiltrosPagos.Click += new System.EventHandler(this.btnLimpiarFiltrosPagos_Click);
            // 
            // btnBuscarPagos
            // 
            this.btnBuscarPagos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btnBuscarPagos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarPagos.ForeColor = System.Drawing.Color.White;
            this.btnBuscarPagos.Location = new System.Drawing.Point(730, 625);
            this.btnBuscarPagos.Name = "btnBuscarPagos";
            this.btnBuscarPagos.Size = new System.Drawing.Size(100, 35);
            this.btnBuscarPagos.TabIndex = 2;
            this.btnBuscarPagos.Text = "Buscar";
            this.btnBuscarPagos.UseVisualStyleBackColor = false;
            this.btnBuscarPagos.Click += new System.EventHandler(this.btnBuscarPagos_Click);
            // 
            // dgvReportePagos
            // 
            this.dgvReportePagos.AllowUserToAddRows = false;
            this.dgvReportePagos.AllowUserToDeleteRows = false;
            this.dgvReportePagos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReportePagos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReportePagos.Location = new System.Drawing.Point(20, 180);
            this.dgvReportePagos.Name = "dgvReportePagos";
            this.dgvReportePagos.ReadOnly = true;
            this.dgvReportePagos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReportePagos.Size = new System.Drawing.Size(1050, 430);
            this.dgvReportePagos.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtBusquedaPagos);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cmbMetodoPago);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.chkFiltrarFechasPagos);
            this.groupBox2.Controls.Add(this.dtpFechaHastaPagos);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.dtpFechaDesdeePagos);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(20, 15);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1050, 150);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filtros de Búsqueda";
            // 
            // txtBusquedaPagos
            // 
            this.txtBusquedaPagos.Location = new System.Drawing.Point(179, 105);
            this.txtBusquedaPagos.Name = "txtBusquedaPagos";
            this.txtBusquedaPagos.Size = new System.Drawing.Size(300, 20);
            this.txtBusquedaPagos.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Buscar (Texto libre):";
            // 
            // cmbMetodoPago
            // 
            this.cmbMetodoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMetodoPago.FormattingEnabled = true;
            this.cmbMetodoPago.Location = new System.Drawing.Point(120, 70);
            this.cmbMetodoPago.Name = "cmbMetodoPago";
            this.cmbMetodoPago.Size = new System.Drawing.Size(200, 21);
            this.cmbMetodoPago.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Método de Pago:";
            // 
            // chkFiltrarFechasPagos
            // 
            this.chkFiltrarFechasPagos.AutoSize = true;
            this.chkFiltrarFechasPagos.Location = new System.Drawing.Point(28, 32);
            this.chkFiltrarFechasPagos.Name = "chkFiltrarFechasPagos";
            this.chkFiltrarFechasPagos.Size = new System.Drawing.Size(104, 17);
            this.chkFiltrarFechasPagos.TabIndex = 4;
            this.chkFiltrarFechasPagos.Text = "Filtrar por fechas";
            this.chkFiltrarFechasPagos.UseVisualStyleBackColor = true;
            this.chkFiltrarFechasPagos.CheckedChanged += new System.EventHandler(this.chkFiltrarFechasPagos_CheckedChanged);
            // 
            // dtpFechaHastaPagos
            // 
            this.dtpFechaHastaPagos.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaHastaPagos.Location = new System.Drawing.Point(600, 30);
            this.dtpFechaHastaPagos.Name = "dtpFechaHastaPagos";
            this.dtpFechaHastaPagos.Size = new System.Drawing.Size(150, 20);
            this.dtpFechaHastaPagos.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(550, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Hasta:";
            // 
            // dtpFechaDesdeePagos
            // 
            this.dtpFechaDesdeePagos.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaDesdeePagos.Location = new System.Drawing.Point(370, 30);
            this.dtpFechaDesdeePagos.Name = "dtpFechaDesdeePagos";
            this.dtpFechaDesdeePagos.Size = new System.Drawing.Size(150, 20);
            this.dtpFechaDesdeePagos.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(320, 33);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Desde:";
            // 
            // tabEstadisticas
            // 
            this.tabEstadisticas.Controls.Add(this.btnTopClientes);
            this.tabEstadisticas.Controls.Add(this.btnExportarGrafico);
            this.tabEstadisticas.Controls.Add(this.btnGenerarEstadisticas);
            this.tabEstadisticas.Controls.Add(this.panelGrafico);
            this.tabEstadisticas.Controls.Add(this.groupBox3);
            this.tabEstadisticas.Location = new System.Drawing.Point(4, 22);
            this.tabEstadisticas.Name = "tabEstadisticas";
            this.tabEstadisticas.Size = new System.Drawing.Size(1092, 674);
            this.tabEstadisticas.TabIndex = 2;
            this.tabEstadisticas.Text = "Estadísticas";
            this.tabEstadisticas.UseVisualStyleBackColor = true;
            // 
            // btnTopClientes
            // 
            this.btnTopClientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(39)))), ((int)(((byte)(176)))));
            this.btnTopClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTopClientes.ForeColor = System.Drawing.Color.White;
            this.btnTopClientes.Location = new System.Drawing.Point(230, 625);
            this.btnTopClientes.Name = "btnTopClientes";
            this.btnTopClientes.Size = new System.Drawing.Size(150, 35);
            this.btnTopClientes.TabIndex = 4;
            this.btnTopClientes.Text = "Top 10 Clientes";
            this.btnTopClientes.UseVisualStyleBackColor = false;
            this.btnTopClientes.Click += new System.EventHandler(this.btnTopClientes_Click);
            // 
            // btnExportarGrafico
            // 
            this.btnExportarGrafico.Location = new System.Drawing.Point(970, 625);
            this.btnExportarGrafico.Name = "btnExportarGrafico";
            this.btnExportarGrafico.Size = new System.Drawing.Size(100, 35);
            this.btnExportarGrafico.TabIndex = 3;
            this.btnExportarGrafico.Text = "Exportar Gráfico";
            this.btnExportarGrafico.UseVisualStyleBackColor = true;
            this.btnExportarGrafico.Click += new System.EventHandler(this.btnExportarGrafico_Click);
            // 
            // btnGenerarEstadisticas
            // 
            this.btnGenerarEstadisticas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnGenerarEstadisticas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerarEstadisticas.ForeColor = System.Drawing.Color.White;
            this.btnGenerarEstadisticas.Location = new System.Drawing.Point(20, 625);
            this.btnGenerarEstadisticas.Name = "btnGenerarEstadisticas";
            this.btnGenerarEstadisticas.Size = new System.Drawing.Size(180, 35);
            this.btnGenerarEstadisticas.TabIndex = 2;
            this.btnGenerarEstadisticas.Text = "Generar Estadísticas";
            this.btnGenerarEstadisticas.UseVisualStyleBackColor = false;
            this.btnGenerarEstadisticas.Click += new System.EventHandler(this.btnGenerarEstadisticas_Click);
            // 
            // panelGrafico
            // 
            this.panelGrafico.BackColor = System.Drawing.Color.White;
            this.panelGrafico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelGrafico.Location = new System.Drawing.Point(20, 180);
            this.panelGrafico.Name = "panelGrafico";
            this.panelGrafico.Size = new System.Drawing.Size(1050, 430);
            this.panelGrafico.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rbHabitacionesPopulares);
            this.groupBox3.Controls.Add(this.rbPagosPorMetodo);
            this.groupBox3.Controls.Add(this.rbIngresos);
            this.groupBox3.Controls.Add(this.numAño);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.rbOcupacion);
            this.groupBox3.Location = new System.Drawing.Point(20, 15);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1050, 150);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tipo de Estadística";
            // 
            // rbHabitacionesPopulares
            // 
            this.rbHabitacionesPopulares.AutoSize = true;
            this.rbHabitacionesPopulares.Location = new System.Drawing.Point(28, 110);
            this.rbHabitacionesPopulares.Name = "rbHabitacionesPopulares";
            this.rbHabitacionesPopulares.Size = new System.Drawing.Size(207, 17);
            this.rbHabitacionesPopulares.TabIndex = 5;
            this.rbHabitacionesPopulares.Text = "Top 10 Habitaciones Más Reservadas";
            this.rbHabitacionesPopulares.UseVisualStyleBackColor = true;
            // 
            // rbPagosPorMetodo
            // 
            this.rbPagosPorMetodo.AutoSize = true;
            this.rbPagosPorMetodo.Location = new System.Drawing.Point(28, 85);
            this.rbPagosPorMetodo.Name = "rbPagosPorMetodo";
            this.rbPagosPorMetodo.Size = new System.Drawing.Size(155, 17);
            this.rbPagosPorMetodo.TabIndex = 4;
            this.rbPagosPorMetodo.Text = "Pagos por Método de Pago";
            this.rbPagosPorMetodo.UseVisualStyleBackColor = true;
            // 
            // rbIngresos
            // 
            this.rbIngresos.AutoSize = true;
            this.rbIngresos.Location = new System.Drawing.Point(28, 60);
            this.rbIngresos.Name = "rbIngresos";
            this.rbIngresos.Size = new System.Drawing.Size(119, 17);
            this.rbIngresos.TabIndex = 3;
            this.rbIngresos.Text = "Ingresos Mensuales";
            this.rbIngresos.UseVisualStyleBackColor = true;
            // 
            // numAño
            // 
            this.numAño.Location = new System.Drawing.Point(200, 59);
            this.numAño.Maximum = new decimal(new int[] {
            2099,
            0,
            0,
            0});
            this.numAño.Minimum = new decimal(new int[] {
            2020,
            0,
            0,
            0});
            this.numAño.Name = "numAño";
            this.numAño.Size = new System.Drawing.Size(80, 20);
            this.numAño.TabIndex = 2;
            this.numAño.Value = new decimal(new int[] {
            2024,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(165, 61);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Año:";
            // 
            // rbOcupacion
            // 
            this.rbOcupacion.AutoSize = true;
            this.rbOcupacion.Checked = true;
            this.rbOcupacion.Location = new System.Drawing.Point(28, 35);
            this.rbOcupacion.Name = "rbOcupacion";
            this.rbOcupacion.Size = new System.Drawing.Size(124, 17);
            this.rbOcupacion.TabIndex = 0;
            this.rbOcupacion.TabStop = true;
            this.rbOcupacion.Text = "Reservas por Estado";
            this.rbOcupacion.UseVisualStyleBackColor = true;
            // 
            // FormReportesEstadisticas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 700);
            this.ControlBox = false;
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormReportesEstadisticas";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Reportes y Estadísticas - Hotel California";
            this.Load += new System.EventHandler(this.FormReportesEstadisticas_Load);
            this.tabControl.ResumeLayout(false);
            this.tabReservas.ResumeLayout(false);
            this.tabReservas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporteReservas)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPagos.ResumeLayout(false);
            this.tabPagos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReportePagos)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabEstadisticas.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAño)).EndInit();
            this.ResumeLayout(false);

        }

  #endregion

  private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabReservas;
        private System.Windows.Forms.TabPage tabPagos;
        private System.Windows.Forms.TabPage tabEstadisticas;
private System.Windows.Forms.GroupBox groupBox1;
 private System.Windows.Forms.DateTimePicker dtpFechaDesdeReservas;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpFechaHastaReservas;
        private System.Windows.Forms.Label label3;
private System.Windows.Forms.CheckBox chkFiltrarFechasReservas;
  private System.Windows.Forms.ComboBox cmbEstadoReserva;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBusquedaReservas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvReporteReservas;
        private System.Windows.Forms.Button btnBuscarReservas;
        private System.Windows.Forms.Button btnLimpiarFiltrosReservas;
  private System.Windows.Forms.Button btnExportarReservas;
        private System.Windows.Forms.Label lblTotalRegistrosReservas;
        private System.Windows.Forms.Label lblTotalIngresosReservas;
 private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtBusquedaPagos;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbMetodoPago;
 private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkFiltrarFechasPagos;
        private System.Windows.Forms.DateTimePicker dtpFechaHastaPagos;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpFechaDesdeePagos;
      private System.Windows.Forms.Label label8;
  private System.Windows.Forms.DataGridView dgvReportePagos;
        private System.Windows.Forms.Button btnBuscarPagos;
        private System.Windows.Forms.Button btnLimpiarFiltrosPagos;
        private System.Windows.Forms.Button btnExportarPagos;
    private System.Windows.Forms.Label lblTotalRegistrosPagos;
  private System.Windows.Forms.Label lblTotalesPagos;
        private System.Windows.Forms.GroupBox groupBox3;
   private System.Windows.Forms.RadioButton rbOcupacion;
private System.Windows.Forms.NumericUpDown numAño;
    private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RadioButton rbIngresos;
  private System.Windows.Forms.RadioButton rbPagosPorMetodo;
 private System.Windows.Forms.RadioButton rbHabitacionesPopulares;
    private System.Windows.Forms.Panel panelGrafico;
        private System.Windows.Forms.Button btnGenerarEstadisticas;
        private System.Windows.Forms.Button btnExportarGrafico;
     private System.Windows.Forms.Button btnTopClientes;
    }
}
