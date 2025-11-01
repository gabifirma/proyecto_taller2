namespace HotelCalifornia
{
    partial class Pagos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pagos));
            this.GrillaPagos = new System.Windows.Forms.DataGridView();
            this.referencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_pago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.monto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_metodoPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LTituloPagos = new System.Windows.Forms.Label();
            this.groupBoxFiltros = new System.Windows.Forms.GroupBox();
            this.RBCredito = new System.Windows.Forms.RadioButton();
            this.RBTrans = new System.Windows.Forms.RadioButton();
            this.RBEfectivo = new System.Windows.Forms.RadioButton();
            this.TReferencia = new System.Windows.Forms.TextBox();
            this.LHasta = new System.Windows.Forms.Label();
            this.DTHasta = new System.Windows.Forms.DateTimePicker();
            this.btnLimpiarFiltros = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lblMetodoPago = new System.Windows.Forms.Label();
            this.LReferencia = new System.Windows.Forms.Label();
            this.LDesde = new System.Windows.Forms.Label();
            this.DTDesde = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaPagos)).BeginInit();
            this.groupBoxFiltros.SuspendLayout();
            this.SuspendLayout();
            // 
            // GrillaPagos
            // 
            this.GrillaPagos.AllowUserToAddRows = false;
            this.GrillaPagos.AllowUserToDeleteRows = false;
            this.GrillaPagos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GrillaPagos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrillaPagos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.referencia,
            this.id_pago,
            this.fecha,
            this.monto,
            this.id_metodoPago});
            this.GrillaPagos.Location = new System.Drawing.Point(14, 262);
            this.GrillaPagos.Margin = new System.Windows.Forms.Padding(4);
            this.GrillaPagos.Name = "GrillaPagos";
            this.GrillaPagos.ReadOnly = true;
            this.GrillaPagos.RowHeadersVisible = false;
            this.GrillaPagos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GrillaPagos.Size = new System.Drawing.Size(828, 327);
            this.GrillaPagos.TabIndex = 0;
            this.GrillaPagos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrillaPagos_CellDoubleClick);
            // 
            // referencia
            // 
            this.referencia.DataPropertyName = "referencia";
            this.referencia.FillWeight = 45F;
            this.referencia.HeaderText = "Referencia";
            this.referencia.Name = "referencia";
            this.referencia.ReadOnly = true;
            // 
            // id_pago
            // 
            this.id_pago.DataPropertyName = "id_pago";
            this.id_pago.HeaderText = "ID";
            this.id_pago.Name = "id_pago";
            this.id_pago.ReadOnly = true;
            this.id_pago.Visible = false;
            // 
            // fecha
            // 
            this.fecha.DataPropertyName = "fecha";
            this.fecha.FillWeight = 55.20305F;
            this.fecha.HeaderText = "Fecha";
            this.fecha.Name = "fecha";
            this.fecha.ReadOnly = true;
            // 
            // monto
            // 
            this.monto.DataPropertyName = "monto";
            this.monto.FillWeight = 55.20305F;
            this.monto.HeaderText = "Monto";
            this.monto.Name = "monto";
            this.monto.ReadOnly = true;
            // 
            // id_metodoPago
            // 
            this.id_metodoPago.DataPropertyName = "metodoPago";
            this.id_metodoPago.FillWeight = 55.20305F;
            this.id_metodoPago.HeaderText = "Metodo de Pago";
            this.id_metodoPago.Name = "id_metodoPago";
            this.id_metodoPago.ReadOnly = true;
            // 
            // LTituloPagos
            // 
            this.LTituloPagos.AutoSize = true;
            this.LTituloPagos.Font = new System.Drawing.Font("Times New Roman", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTituloPagos.Location = new System.Drawing.Point(327, 20);
            this.LTituloPagos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LTituloPagos.Name = "LTituloPagos";
            this.LTituloPagos.Size = new System.Drawing.Size(183, 28);
            this.LTituloPagos.TabIndex = 1;
            this.LTituloPagos.Text = "Gestión de Pagos";
            // 
            // groupBoxFiltros
            // 
            this.groupBoxFiltros.Controls.Add(this.RBCredito);
            this.groupBoxFiltros.Controls.Add(this.RBTrans);
            this.groupBoxFiltros.Controls.Add(this.RBEfectivo);
            this.groupBoxFiltros.Controls.Add(this.TReferencia);
            this.groupBoxFiltros.Controls.Add(this.LHasta);
            this.groupBoxFiltros.Controls.Add(this.DTHasta);
            this.groupBoxFiltros.Controls.Add(this.btnLimpiarFiltros);
            this.groupBoxFiltros.Controls.Add(this.btnBuscar);
            this.groupBoxFiltros.Controls.Add(this.lblMetodoPago);
            this.groupBoxFiltros.Controls.Add(this.LReferencia);
            this.groupBoxFiltros.Controls.Add(this.LDesde);
            this.groupBoxFiltros.Controls.Add(this.DTDesde);
            this.groupBoxFiltros.Location = new System.Drawing.Point(14, 65);
            this.groupBoxFiltros.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxFiltros.Name = "groupBoxFiltros";
            this.groupBoxFiltros.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxFiltros.Size = new System.Drawing.Size(828, 129);
            this.groupBoxFiltros.TabIndex = 2;
            this.groupBoxFiltros.TabStop = false;
            this.groupBoxFiltros.Text = "Filtros de Búsqueda";
            // 
            // RBCredito
            // 
            this.RBCredito.AutoSize = true;
            this.RBCredito.Location = new System.Drawing.Point(453, 104);
            this.RBCredito.Name = "RBCredito";
            this.RBCredito.Size = new System.Drawing.Size(86, 23);
            this.RBCredito.TabIndex = 14;
            this.RBCredito.Text = "3-Crédito";
            this.RBCredito.UseVisualStyleBackColor = true;
            // 
            // RBTrans
            // 
            this.RBTrans.AutoSize = true;
            this.RBTrans.Location = new System.Drawing.Point(453, 75);
            this.RBTrans.Name = "RBTrans";
            this.RBTrans.Size = new System.Drawing.Size(120, 23);
            this.RBTrans.TabIndex = 14;
            this.RBTrans.Text = "2-Transferencia";
            this.RBTrans.UseVisualStyleBackColor = true;
            // 
            // RBEfectivo
            // 
            this.RBEfectivo.AutoSize = true;
            this.RBEfectivo.Checked = true;
            this.RBEfectivo.Location = new System.Drawing.Point(453, 46);
            this.RBEfectivo.Name = "RBEfectivo";
            this.RBEfectivo.Size = new System.Drawing.Size(88, 23);
            this.RBEfectivo.TabIndex = 13;
            this.RBEfectivo.TabStop = true;
            this.RBEfectivo.Text = "1-Efectivo";
            this.RBEfectivo.UseVisualStyleBackColor = true;
            // 
            // TReferencia
            // 
            this.TReferencia.Location = new System.Drawing.Point(121, 89);
            this.TReferencia.Margin = new System.Windows.Forms.Padding(4);
            this.TReferencia.Name = "TReferencia";
            this.TReferencia.Size = new System.Drawing.Size(139, 25);
            this.TReferencia.TabIndex = 12;
            // 
            // LHasta
            // 
            this.LHasta.AutoSize = true;
            this.LHasta.Location = new System.Drawing.Point(243, 26);
            this.LHasta.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LHasta.Name = "LHasta";
            this.LHasta.Size = new System.Drawing.Size(86, 19);
            this.LHasta.TabIndex = 11;
            this.LHasta.Text = "Fecha Hasta:";
            // 
            // DTHasta
            // 
            this.DTHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTHasta.Location = new System.Drawing.Point(247, 48);
            this.DTHasta.Margin = new System.Windows.Forms.Padding(4);
            this.DTHasta.Name = "DTHasta";
            this.DTHasta.Size = new System.Drawing.Size(116, 25);
            this.DTHasta.TabIndex = 10;
            // 
            // btnLimpiarFiltros
            // 
            this.btnLimpiarFiltros.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnLimpiarFiltros.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiarFiltros.ForeColor = System.Drawing.Color.White;
            this.btnLimpiarFiltros.Image = ((System.Drawing.Image)(resources.GetObject("btnLimpiarFiltros.Image")));
            this.btnLimpiarFiltros.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLimpiarFiltros.Location = new System.Drawing.Point(732, 26);
            this.btnLimpiarFiltros.Margin = new System.Windows.Forms.Padding(4);
            this.btnLimpiarFiltros.Name = "btnLimpiarFiltros";
            this.btnLimpiarFiltros.Size = new System.Drawing.Size(88, 33);
            this.btnLimpiarFiltros.TabIndex = 9;
            this.btnLimpiarFiltros.Text = "Limpiar";
            this.btnLimpiarFiltros.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLimpiarFiltros.UseVisualStyleBackColor = false;
            this.btnLimpiarFiltros.Click += new System.EventHandler(this.btnLimpiarFiltros_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.Location = new System.Drawing.Point(732, 69);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(4);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(88, 33);
            this.btnBuscar.TabIndex = 8;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lblMetodoPago
            // 
            this.lblMetodoPago.AutoSize = true;
            this.lblMetodoPago.Location = new System.Drawing.Point(449, 22);
            this.lblMetodoPago.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMetodoPago.Name = "lblMetodoPago";
            this.lblMetodoPago.Size = new System.Drawing.Size(61, 19);
            this.lblMetodoPago.TabIndex = 7;
            this.lblMetodoPago.Text = "Método:";
            // 
            // LReferencia
            // 
            this.LReferencia.AutoSize = true;
            this.LReferencia.Location = new System.Drawing.Point(21, 92);
            this.LReferencia.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LReferencia.Name = "LReferencia";
            this.LReferencia.Size = new System.Drawing.Size(74, 19);
            this.LReferencia.TabIndex = 5;
            this.LReferencia.Text = "Referencia:";
            // 
            // LDesde
            // 
            this.LDesde.AutoSize = true;
            this.LDesde.Location = new System.Drawing.Point(21, 26);
            this.LDesde.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LDesde.Name = "LDesde";
            this.LDesde.Size = new System.Drawing.Size(89, 19);
            this.LDesde.TabIndex = 3;
            this.LDesde.Text = "Fecha Desde:";
            // 
            // DTDesde
            // 
            this.DTDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTDesde.Location = new System.Drawing.Point(25, 48);
            this.DTDesde.Margin = new System.Windows.Forms.Padding(4);
            this.DTDesde.Name = "DTDesde";
            this.DTDesde.Size = new System.Drawing.Size(116, 25);
            this.DTDesde.TabIndex = 2;
            // 
            // Pagos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(856, 668);
            this.Controls.Add(this.groupBoxFiltros);
            this.Controls.Add(this.LTituloPagos);
            this.Controls.Add(this.GrillaPagos);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
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
        private System.Windows.Forms.Label LTituloPagos;
        private System.Windows.Forms.GroupBox groupBoxFiltros;
        private System.Windows.Forms.DateTimePicker DTDesde;
        private System.Windows.Forms.Label LDesde;
        private System.Windows.Forms.Label LReferencia;
        private System.Windows.Forms.Label lblMetodoPago;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnLimpiarFiltros;
        private System.Windows.Forms.DataGridView GrillaPagos;
        private System.Windows.Forms.Label LHasta;
        private System.Windows.Forms.DateTimePicker DTHasta;
        private System.Windows.Forms.TextBox TReferencia;
        private System.Windows.Forms.RadioButton RBCredito;
        private System.Windows.Forms.RadioButton RBTrans;
        private System.Windows.Forms.RadioButton RBEfectivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn referencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_pago;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn monto;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_metodoPago;
    }
}