namespace HotelCalifornia
{
    partial class Reservas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Reservas));
            this.LTituloReservas = new System.Windows.Forms.Label();
            this.GrillaReservas = new System.Windows.Forms.DataGridView();
            this.groupBoxFiltros = new System.Windows.Forms.GroupBox();
            this.RBSuite = new System.Windows.Forms.RadioButton();
            this.RBDoble = new System.Windows.Forms.RadioButton();
            this.RBSingle = new System.Windows.Forms.RadioButton();
            this.lblMetodoPago = new System.Windows.Forms.Label();
            this.LApellido = new System.Windows.Forms.Label();
            this.TApellido = new System.Windows.Forms.TextBox();
            this.btnLimpiarFiltros = new System.Windows.Forms.Button();
            this.btnNuevaReserva = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.LFechaHasta = new System.Windows.Forms.Label();
            this.LFechaDesde = new System.Windows.Forms.Label();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.LNombre = new System.Windows.Forms.Label();
            this.TNombre = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaReservas)).BeginInit();
            this.groupBoxFiltros.SuspendLayout();
            this.SuspendLayout();
            // 
            // LTituloReservas
            // 
            this.LTituloReservas.AutoSize = true;
            this.LTituloReservas.Font = new System.Drawing.Font("Times New Roman", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTituloReservas.Location = new System.Drawing.Point(327, 20);
            this.LTituloReservas.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LTituloReservas.Name = "LTituloReservas";
            this.LTituloReservas.Size = new System.Drawing.Size(211, 28);
            this.LTituloReservas.TabIndex = 0;
            this.LTituloReservas.Text = "Gestión de Reservas";
            // 
            // GrillaReservas
            // 
            this.GrillaReservas.AllowUserToAddRows = false;
            this.GrillaReservas.AllowUserToDeleteRows = false;
            this.GrillaReservas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GrillaReservas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrillaReservas.Location = new System.Drawing.Point(14, 275);
            this.GrillaReservas.Margin = new System.Windows.Forms.Padding(4);
            this.GrillaReservas.Name = "GrillaReservas";
            this.GrillaReservas.ReadOnly = true;
            this.GrillaReservas.RowHeadersVisible = false;
            this.GrillaReservas.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.GrillaReservas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GrillaReservas.Size = new System.Drawing.Size(1096, 327);
            this.GrillaReservas.TabIndex = 1;
            this.GrillaReservas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrillaReservas_CellDoubleClick);
            // 
            // groupBoxFiltros
            // 
            this.groupBoxFiltros.Controls.Add(this.RBSuite);
            this.groupBoxFiltros.Controls.Add(this.RBDoble);
            this.groupBoxFiltros.Controls.Add(this.RBSingle);
            this.groupBoxFiltros.Controls.Add(this.lblMetodoPago);
            this.groupBoxFiltros.Controls.Add(this.LApellido);
            this.groupBoxFiltros.Controls.Add(this.TApellido);
            this.groupBoxFiltros.Controls.Add(this.btnLimpiarFiltros);
            this.groupBoxFiltros.Controls.Add(this.btnNuevaReserva);
            this.groupBoxFiltros.Controls.Add(this.btnBuscar);
            this.groupBoxFiltros.Controls.Add(this.LFechaHasta);
            this.groupBoxFiltros.Controls.Add(this.LFechaDesde);
            this.groupBoxFiltros.Controls.Add(this.dtpFechaFin);
            this.groupBoxFiltros.Controls.Add(this.dtpFechaInicio);
            this.groupBoxFiltros.Controls.Add(this.LNombre);
            this.groupBoxFiltros.Controls.Add(this.TNombre);
            this.groupBoxFiltros.Location = new System.Drawing.Point(14, 65);
            this.groupBoxFiltros.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxFiltros.Name = "groupBoxFiltros";
            this.groupBoxFiltros.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxFiltros.Size = new System.Drawing.Size(993, 144);
            this.groupBoxFiltros.TabIndex = 2;
            this.groupBoxFiltros.TabStop = false;
            this.groupBoxFiltros.Text = "Filtros de Búsqueda";
            // 
            // RBSuite
            // 
            this.RBSuite.AutoSize = true;
            this.RBSuite.Location = new System.Drawing.Point(447, 104);
            this.RBSuite.Name = "RBSuite";
            this.RBSuite.Size = new System.Drawing.Size(57, 23);
            this.RBSuite.TabIndex = 17;
            this.RBSuite.Text = "Suite";
            this.RBSuite.UseVisualStyleBackColor = true;
            // 
            // RBDoble
            // 
            this.RBDoble.AutoSize = true;
            this.RBDoble.Location = new System.Drawing.Point(447, 75);
            this.RBDoble.Name = "RBDoble";
            this.RBDoble.Size = new System.Drawing.Size(63, 23);
            this.RBDoble.TabIndex = 18;
            this.RBDoble.Text = "Doble";
            this.RBDoble.UseVisualStyleBackColor = true;
            // 
            // RBSingle
            // 
            this.RBSingle.AutoSize = true;
            this.RBSingle.Checked = true;
            this.RBSingle.Location = new System.Drawing.Point(447, 46);
            this.RBSingle.Name = "RBSingle";
            this.RBSingle.Size = new System.Drawing.Size(63, 23);
            this.RBSingle.TabIndex = 16;
            this.RBSingle.TabStop = true;
            this.RBSingle.Text = "Single";
            this.RBSingle.UseVisualStyleBackColor = true;
            // 
            // lblMetodoPago
            // 
            this.lblMetodoPago.AutoSize = true;
            this.lblMetodoPago.Location = new System.Drawing.Point(443, 22);
            this.lblMetodoPago.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMetodoPago.Name = "lblMetodoPago";
            this.lblMetodoPago.Size = new System.Drawing.Size(67, 19);
            this.lblMetodoPago.TabIndex = 15;
            this.lblMetodoPago.Text = "Tipo Hab:";
            // 
            // LApellido
            // 
            this.LApellido.AutoSize = true;
            this.LApellido.Location = new System.Drawing.Point(218, 22);
            this.LApellido.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LApellido.Name = "LApellido";
            this.LApellido.Size = new System.Drawing.Size(107, 19);
            this.LApellido.TabIndex = 11;
            this.LApellido.Text = "Apellido Cliente:";
            // 
            // TApellido
            // 
            this.TApellido.Location = new System.Drawing.Point(222, 45);
            this.TApellido.Margin = new System.Windows.Forms.Padding(4);
            this.TApellido.Name = "TApellido";
            this.TApellido.Size = new System.Drawing.Size(174, 25);
            this.TApellido.TabIndex = 10;
            // 
            // btnLimpiarFiltros
            // 
            this.btnLimpiarFiltros.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnLimpiarFiltros.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiarFiltros.ForeColor = System.Drawing.Color.White;
            this.btnLimpiarFiltros.Image = ((System.Drawing.Image)(resources.GetObject("btnLimpiarFiltros.Image")));
            this.btnLimpiarFiltros.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLimpiarFiltros.Location = new System.Drawing.Point(597, 75);
            this.btnLimpiarFiltros.Margin = new System.Windows.Forms.Padding(4);
            this.btnLimpiarFiltros.Name = "btnLimpiarFiltros";
            this.btnLimpiarFiltros.Size = new System.Drawing.Size(88, 33);
            this.btnLimpiarFiltros.TabIndex = 9;
            this.btnLimpiarFiltros.Text = "Limpiar";
            this.btnLimpiarFiltros.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLimpiarFiltros.UseVisualStyleBackColor = false;
            this.btnLimpiarFiltros.Click += new System.EventHandler(this.btnLimpiarFiltros_Click);
            // 
            // btnNuevaReserva
            // 
            this.btnNuevaReserva.BackColor = System.Drawing.Color.Green;
            this.btnNuevaReserva.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevaReserva.ForeColor = System.Drawing.Color.White;
            this.btnNuevaReserva.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevaReserva.Image")));
            this.btnNuevaReserva.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevaReserva.Location = new System.Drawing.Point(735, 26);
            this.btnNuevaReserva.Margin = new System.Windows.Forms.Padding(4);
            this.btnNuevaReserva.Name = "btnNuevaReserva";
            this.btnNuevaReserva.Size = new System.Drawing.Size(140, 46);
            this.btnNuevaReserva.TabIndex = 3;
            this.btnNuevaReserva.Text = "Nueva Reserva";
            this.btnNuevaReserva.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNuevaReserva.UseVisualStyleBackColor = false;
            this.btnNuevaReserva.Click += new System.EventHandler(this.btnNuevaReserva_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.Location = new System.Drawing.Point(597, 26);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(4);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(88, 33);
            this.btnBuscar.TabIndex = 8;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // LFechaHasta
            // 
            this.LFechaHasta.AutoSize = true;
            this.LFechaHasta.Location = new System.Drawing.Point(158, 78);
            this.LFechaHasta.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LFechaHasta.Name = "LFechaHasta";
            this.LFechaHasta.Size = new System.Drawing.Size(86, 19);
            this.LFechaHasta.TabIndex = 5;
            this.LFechaHasta.Text = "Fecha Hasta:";
            // 
            // LFechaDesde
            // 
            this.LFechaDesde.AutoSize = true;
            this.LFechaDesde.Location = new System.Drawing.Point(18, 78);
            this.LFechaDesde.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LFechaDesde.Name = "LFechaDesde";
            this.LFechaDesde.Size = new System.Drawing.Size(89, 19);
            this.LFechaDesde.TabIndex = 4;
            this.LFechaDesde.Text = "Fecha Desde:";
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin.Location = new System.Drawing.Point(158, 104);
            this.dtpFechaFin.Margin = new System.Windows.Forms.Padding(4);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(116, 25);
            this.dtpFechaFin.TabIndex = 3;
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicio.Location = new System.Drawing.Point(18, 104);
            this.dtpFechaInicio.Margin = new System.Windows.Forms.Padding(4);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(116, 25);
            this.dtpFechaInicio.TabIndex = 2;
            // 
            // LNombre
            // 
            this.LNombre.AutoSize = true;
            this.LNombre.Location = new System.Drawing.Point(18, 22);
            this.LNombre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LNombre.Name = "LNombre";
            this.LNombre.Size = new System.Drawing.Size(108, 19);
            this.LNombre.TabIndex = 1;
            this.LNombre.Text = "Nombre Cliente:";
            // 
            // TNombre
            // 
            this.TNombre.Location = new System.Drawing.Point(22, 45);
            this.TNombre.Margin = new System.Windows.Forms.Padding(4);
            this.TNombre.Name = "TNombre";
            this.TNombre.Size = new System.Drawing.Size(174, 25);
            this.TNombre.TabIndex = 0;
            // 
            // Reservas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1123, 668);
            this.Controls.Add(this.groupBoxFiltros);
            this.Controls.Add(this.GrillaReservas);
            this.Controls.Add(this.LTituloReservas);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
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
        private System.Windows.Forms.TextBox TNombre;
        private System.Windows.Forms.Label LNombre;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.Label LFechaDesde;
        private System.Windows.Forms.Label LFechaHasta;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnLimpiarFiltros;
        private System.Windows.Forms.Button btnNuevaReserva;
        private System.Windows.Forms.Label LApellido;
        private System.Windows.Forms.TextBox TApellido;
        private System.Windows.Forms.RadioButton RBSuite;
        private System.Windows.Forms.RadioButton RBDoble;
        private System.Windows.Forms.RadioButton RBSingle;
        private System.Windows.Forms.Label lblMetodoPago;
    }
}