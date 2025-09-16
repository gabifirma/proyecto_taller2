namespace Proyecto_Hotel_California
{
    partial class Pagos
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
            this.GrillaPagos = new System.Windows.Forms.DataGridView();
            this.LTituloPagos = new System.Windows.Forms.Label();
            this.groupBoxFiltros = new System.Windows.Forms.GroupBox();
            this.btnLimpiarFiltros = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lblMetodoPago = new System.Windows.Forms.Label();
            this.cmbMetodoPago = new System.Windows.Forms.ComboBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.lblFechaPago = new System.Windows.Forms.Label();
            this.dtpFechaPago = new System.Windows.Forms.DateTimePicker();
            this.lblBuscarCliente = new System.Windows.Forms.Label();
            this.txtBuscarCliente = new System.Windows.Forms.TextBox();
            this.btnNuevoPago = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaPagos)).BeginInit();
            this.groupBoxFiltros.SuspendLayout();
            this.SuspendLayout();
            // 
            // GrillaPagos
            // 
            this.GrillaPagos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GrillaPagos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrillaPagos.Location = new System.Drawing.Point(12, 200);
            this.GrillaPagos.Name = "GrillaPagos";
            this.GrillaPagos.ReadOnly = true;
            this.GrillaPagos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GrillaPagos.Size = new System.Drawing.Size(710, 250);
            this.GrillaPagos.TabIndex = 0;
            this.GrillaPagos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrillaPagos_CellContentClick);
            // 
            // groupBoxFiltros
            // 
            this.groupBoxFiltros.Controls.Add(this.btnLimpiarFiltros);
            this.groupBoxFiltros.Controls.Add(this.btnBuscar);
            this.groupBoxFiltros.Controls.Add(this.lblMetodoPago);
            this.groupBoxFiltros.Controls.Add(this.cmbMetodoPago);
            this.groupBoxFiltros.Controls.Add(this.lblEstado);
            this.groupBoxFiltros.Controls.Add(this.cmbEstado);
            this.groupBoxFiltros.Controls.Add(this.lblFechaPago);
            this.groupBoxFiltros.Controls.Add(this.dtpFechaPago);
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
            this.txtBuscarCliente.Size = new System.Drawing.Size(120, 20);
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
            // dtpFechaPago
            // 
            this.dtpFechaPago.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaPago.Location = new System.Drawing.Point(280, 25);
            this.dtpFechaPago.Name = "dtpFechaPago";
            this.dtpFechaPago.Size = new System.Drawing.Size(100, 20);
            this.dtpFechaPago.TabIndex = 2;
            // 
            // lblFechaPago
            // 
            this.lblFechaPago.AutoSize = true;
            this.lblFechaPago.Location = new System.Drawing.Point(220, 28);
            this.lblFechaPago.Name = "lblFechaPago";
            this.lblFechaPago.Size = new System.Drawing.Size(40, 13);
            this.lblFechaPago.TabIndex = 3;
            this.lblFechaPago.Text = "Fecha:";
            // 
            // cmbEstado
            // 
            this.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Items.AddRange(new object[] {
            "Todos",
            "Confirmado",
            "Pendiente",
            "Reembolsado"});
            this.cmbEstado.Location = new System.Drawing.Point(80, 55);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(120, 21);
            this.cmbEstado.TabIndex = 4;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(15, 58);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(43, 13);
            this.lblEstado.TabIndex = 5;
            this.lblEstado.Text = "Estado:";
            // 
            // cmbMetodoPago
            // 
            this.cmbMetodoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMetodoPago.FormattingEnabled = true;
            this.cmbMetodoPago.Items.AddRange(new object[] {
            "Todos",
            "Efectivo",
            "Tarjeta",
            "Transferencia",
            "Cheque"});
            this.cmbMetodoPago.Location = new System.Drawing.Point(280, 55);
            this.cmbMetodoPago.Name = "cmbMetodoPago";
            this.cmbMetodoPago.Size = new System.Drawing.Size(100, 21);
            this.cmbMetodoPago.TabIndex = 6;
            // 
            // lblMetodoPago
            // 
            this.lblMetodoPago.AutoSize = true;
            this.lblMetodoPago.Location = new System.Drawing.Point(220, 58);
            this.lblMetodoPago.Name = "lblMetodoPago";
            this.lblMetodoPago.Size = new System.Drawing.Size(48, 13);
            this.lblMetodoPago.TabIndex = 7;
            this.lblMetodoPago.Text = "Método:";
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(400, 25);
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
            this.btnLimpiarFiltros.Location = new System.Drawing.Point(490, 25);
            this.btnLimpiarFiltros.Name = "btnLimpiarFiltros";
            this.btnLimpiarFiltros.Size = new System.Drawing.Size(75, 25);
            this.btnLimpiarFiltros.TabIndex = 9;
            this.btnLimpiarFiltros.Text = "Limpiar";
            this.btnLimpiarFiltros.UseVisualStyleBackColor = false;
            this.btnLimpiarFiltros.Click += new System.EventHandler(this.btnLimpiarFiltros_Click);
            // 
            // btnNuevoPago
            // 
            this.btnNuevoPago.BackColor = System.Drawing.Color.Green;
            this.btnNuevoPago.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevoPago.ForeColor = System.Drawing.Color.White;
            this.btnNuevoPago.Location = new System.Drawing.Point(600, 70);
            this.btnNuevoPago.Name = "btnNuevoPago";
            this.btnNuevoPago.Size = new System.Drawing.Size(120, 35);
            this.btnNuevoPago.TabIndex = 3;
            this.btnNuevoPago.Text = "Nuevo Pago";
            this.btnNuevoPago.UseVisualStyleBackColor = false;
            this.btnNuevoPago.Click += new System.EventHandler(this.btnNuevoPago_Click);
            // 
            // LTituloPagos
            // 
            this.LTituloPagos.AutoSize = true;
            this.LTituloPagos.Font = new System.Drawing.Font("Times New Roman", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTituloPagos.Location = new System.Drawing.Point(280, 15);
            this.LTituloPagos.Name = "LTituloPagos";
            this.LTituloPagos.Size = new System.Drawing.Size(180, 28);
            this.LTituloPagos.TabIndex = 1;
            this.LTituloPagos.Text = "Gestión de Pagos";
            // 
            // Pagos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(734, 511);
            this.Controls.Add(this.btnNuevoPago);
            this.Controls.Add(this.groupBoxFiltros);
            this.Controls.Add(this.LTituloPagos);
            this.Controls.Add(this.GrillaPagos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Pagos";
            this.Text = "Pagos";
            this.Load += new System.EventHandler(this.Pagos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GrillaPagos)).EndInit();
            this.groupBoxFiltros.ResumeLayout(false);
            this.groupBoxFiltros.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView GrillaPagos;
        private System.Windows.Forms.Label LTituloPagos;
        private System.Windows.Forms.GroupBox groupBoxFiltros;
        private System.Windows.Forms.TextBox txtBuscarCliente;
        private System.Windows.Forms.Label lblBuscarCliente;
        private System.Windows.Forms.DateTimePicker dtpFechaPago;
        private System.Windows.Forms.Label lblFechaPago;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.ComboBox cmbMetodoPago;
        private System.Windows.Forms.Label lblMetodoPago;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnLimpiarFiltros;
        private System.Windows.Forms.Button btnNuevoPago;
    }
}