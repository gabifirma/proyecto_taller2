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
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numero_hab = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipo_hab = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_creacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.LTituloFiltros = new System.Windows.Forms.Label();
            this.BActualizar = new System.Windows.Forms.Button();
            this.LTerminadas = new System.Windows.Forms.Label();
            this.LConfirmadas = new System.Windows.Forms.Label();
            this.LEspera = new System.Windows.Forms.Label();
            this.LEstados = new System.Windows.Forms.Label();
            this.BFinalizar = new System.Windows.Forms.Button();
            this.LFinalizarC = new System.Windows.Forms.Label();
            this.TReservaN = new System.Windows.Forms.TextBox();
            this.LReservaN = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaReservas)).BeginInit();
            this.SuspendLayout();
            // 
            // LTituloReservas
            // 
            this.LTituloReservas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.GrillaReservas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GrillaReservas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GrillaReservas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GrillaReservas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrillaReservas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.inicio,
            this.fin,
            this.nombre,
            this.apellido,
            this.numero_hab,
            this.tipo_hab,
            this.subtotal,
            this.total,
            this.estado,
            this.fecha_creacion});
            this.GrillaReservas.Location = new System.Drawing.Point(14, 252);
            this.GrillaReservas.Margin = new System.Windows.Forms.Padding(4);
            this.GrillaReservas.Name = "GrillaReservas";
            this.GrillaReservas.ReadOnly = true;
            this.GrillaReservas.RowHeadersVisible = false;
            this.GrillaReservas.Size = new System.Drawing.Size(981, 272);
            this.GrillaReservas.TabIndex = 1;
            this.GrillaReservas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrillaReservas_CellDoubleClick);
            // 
            // id
            // 
            this.id.DataPropertyName = "ID";
            this.id.FillWeight = 25F;
            this.id.HeaderText = "N°";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            // 
            // inicio
            // 
            this.inicio.DataPropertyName = "Inicio";
            this.inicio.FillWeight = 33.42974F;
            this.inicio.HeaderText = "Inicio";
            this.inicio.Name = "inicio";
            this.inicio.ReadOnly = true;
            // 
            // fin
            // 
            this.fin.DataPropertyName = "Fin";
            this.fin.FillWeight = 33.42974F;
            this.fin.HeaderText = "Fin";
            this.fin.Name = "fin";
            this.fin.ReadOnly = true;
            // 
            // nombre
            // 
            this.nombre.DataPropertyName = "Nombre";
            this.nombre.FillWeight = 33.42974F;
            this.nombre.HeaderText = "Nombre";
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            // 
            // apellido
            // 
            this.apellido.DataPropertyName = "Apellido";
            this.apellido.FillWeight = 33.42974F;
            this.apellido.HeaderText = "Apellido";
            this.apellido.Name = "apellido";
            this.apellido.ReadOnly = true;
            // 
            // numero_hab
            // 
            this.numero_hab.DataPropertyName = "Habitaciones";
            this.numero_hab.FillWeight = 33.42974F;
            this.numero_hab.HeaderText = "Habitaciones";
            this.numero_hab.Name = "numero_hab";
            this.numero_hab.ReadOnly = true;
            // 
            // tipo_hab
            // 
            this.tipo_hab.DataPropertyName = "Tipos";
            this.tipo_hab.FillWeight = 33.42974F;
            this.tipo_hab.HeaderText = "Tipos";
            this.tipo_hab.Name = "tipo_hab";
            this.tipo_hab.ReadOnly = true;
            // 
            // subtotal
            // 
            this.subtotal.DataPropertyName = "Subtotal";
            this.subtotal.FillWeight = 33.42974F;
            this.subtotal.HeaderText = "Subtotal ($)";
            this.subtotal.Name = "subtotal";
            this.subtotal.ReadOnly = true;
            // 
            // total
            // 
            this.total.DataPropertyName = "Total";
            this.total.FillWeight = 40F;
            this.total.HeaderText = "Total ($)";
            this.total.Name = "total";
            this.total.ReadOnly = true;
            // 
            // estado
            // 
            this.estado.DataPropertyName = "Estado";
            this.estado.HeaderText = "estado";
            this.estado.Name = "estado";
            this.estado.ReadOnly = true;
            this.estado.Visible = false;
            // 
            // fecha_creacion
            // 
            this.fecha_creacion.DataPropertyName = "fecha_creacion";
            this.fecha_creacion.HeaderText = "fecha_creacion";
            this.fecha_creacion.Name = "fecha_creacion";
            this.fecha_creacion.ReadOnly = true;
            this.fecha_creacion.Visible = false;
            // 
            // RBSuite
            // 
            this.RBSuite.AutoSize = true;
            this.RBSuite.Location = new System.Drawing.Point(467, 180);
            this.RBSuite.Name = "RBSuite";
            this.RBSuite.Size = new System.Drawing.Size(57, 23);
            this.RBSuite.TabIndex = 17;
            this.RBSuite.Text = "Suite";
            this.RBSuite.UseVisualStyleBackColor = true;
            // 
            // RBDoble
            // 
            this.RBDoble.AutoSize = true;
            this.RBDoble.Location = new System.Drawing.Point(467, 151);
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
            this.RBSingle.Location = new System.Drawing.Point(467, 122);
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
            this.lblMetodoPago.Location = new System.Drawing.Point(463, 98);
            this.lblMetodoPago.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMetodoPago.Name = "lblMetodoPago";
            this.lblMetodoPago.Size = new System.Drawing.Size(67, 19);
            this.lblMetodoPago.TabIndex = 15;
            this.lblMetodoPago.Text = "Tipo Hab:";
            // 
            // LApellido
            // 
            this.LApellido.AutoSize = true;
            this.LApellido.Location = new System.Drawing.Point(238, 98);
            this.LApellido.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LApellido.Name = "LApellido";
            this.LApellido.Size = new System.Drawing.Size(107, 19);
            this.LApellido.TabIndex = 11;
            this.LApellido.Text = "Apellido Cliente:";
            // 
            // TApellido
            // 
            this.TApellido.Location = new System.Drawing.Point(242, 121);
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
            this.btnLimpiarFiltros.Location = new System.Drawing.Point(617, 151);
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
            this.btnNuevaReserva.Location = new System.Drawing.Point(755, 102);
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
            this.btnBuscar.Location = new System.Drawing.Point(617, 102);
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
            this.LFechaHasta.Location = new System.Drawing.Point(178, 154);
            this.LFechaHasta.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LFechaHasta.Name = "LFechaHasta";
            this.LFechaHasta.Size = new System.Drawing.Size(86, 19);
            this.LFechaHasta.TabIndex = 5;
            this.LFechaHasta.Text = "Fecha Hasta:";
            // 
            // LFechaDesde
            // 
            this.LFechaDesde.AutoSize = true;
            this.LFechaDesde.Location = new System.Drawing.Point(38, 154);
            this.LFechaDesde.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LFechaDesde.Name = "LFechaDesde";
            this.LFechaDesde.Size = new System.Drawing.Size(89, 19);
            this.LFechaDesde.TabIndex = 4;
            this.LFechaDesde.Text = "Fecha Desde:";
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin.Location = new System.Drawing.Point(182, 180);
            this.dtpFechaFin.Margin = new System.Windows.Forms.Padding(4);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(116, 25);
            this.dtpFechaFin.TabIndex = 3;
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicio.Location = new System.Drawing.Point(42, 180);
            this.dtpFechaInicio.Margin = new System.Windows.Forms.Padding(4);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(116, 25);
            this.dtpFechaInicio.TabIndex = 2;
            // 
            // LNombre
            // 
            this.LNombre.AutoSize = true;
            this.LNombre.Location = new System.Drawing.Point(38, 98);
            this.LNombre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LNombre.Name = "LNombre";
            this.LNombre.Size = new System.Drawing.Size(108, 19);
            this.LNombre.TabIndex = 1;
            this.LNombre.Text = "Nombre Cliente:";
            // 
            // TNombre
            // 
            this.TNombre.Location = new System.Drawing.Point(42, 121);
            this.TNombre.Margin = new System.Windows.Forms.Padding(4);
            this.TNombre.Name = "TNombre";
            this.TNombre.Size = new System.Drawing.Size(174, 25);
            this.TNombre.TabIndex = 0;
            // 
            // LTituloFiltros
            // 
            this.LTituloFiltros.AutoSize = true;
            this.LTituloFiltros.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTituloFiltros.Location = new System.Drawing.Point(38, 66);
            this.LTituloFiltros.Name = "LTituloFiltros";
            this.LTituloFiltros.Size = new System.Drawing.Size(65, 25);
            this.LTituloFiltros.TabIndex = 19;
            this.LTituloFiltros.Text = "Filtros";
            // 
            // BActualizar
            // 
            this.BActualizar.BackColor = System.Drawing.Color.Orange;
            this.BActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BActualizar.ForeColor = System.Drawing.Color.White;
            this.BActualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BActualizar.Location = new System.Drawing.Point(755, 180);
            this.BActualizar.Margin = new System.Windows.Forms.Padding(4);
            this.BActualizar.Name = "BActualizar";
            this.BActualizar.Size = new System.Drawing.Size(140, 46);
            this.BActualizar.TabIndex = 20;
            this.BActualizar.Text = "Actualizar";
            this.BActualizar.UseVisualStyleBackColor = false;
            this.BActualizar.Click += new System.EventHandler(this.BActualizar_Click);
            // 
            // LTerminadas
            // 
            this.LTerminadas.AutoSize = true;
            this.LTerminadas.BackColor = System.Drawing.Color.LightCoral;
            this.LTerminadas.Location = new System.Drawing.Point(347, 229);
            this.LTerminadas.Name = "LTerminadas";
            this.LTerminadas.Size = new System.Drawing.Size(151, 19);
            this.LTerminadas.TabIndex = 21;
            this.LTerminadas.Text = "Terminadas/Canceladas";
            // 
            // LConfirmadas
            // 
            this.LConfirmadas.AutoSize = true;
            this.LConfirmadas.BackColor = System.Drawing.Color.LightGreen;
            this.LConfirmadas.Location = new System.Drawing.Point(121, 229);
            this.LConfirmadas.Name = "LConfirmadas";
            this.LConfirmadas.Size = new System.Drawing.Size(86, 19);
            this.LConfirmadas.TabIndex = 22;
            this.LConfirmadas.Text = "Confirmadas";
            // 
            // LEspera
            // 
            this.LEspera.AutoSize = true;
            this.LEspera.BackColor = System.Drawing.Color.Khaki;
            this.LEspera.Location = new System.Drawing.Point(239, 229);
            this.LEspera.Name = "LEspera";
            this.LEspera.Size = new System.Drawing.Size(68, 19);
            this.LEspera.TabIndex = 23;
            this.LEspera.Text = "En Espera";
            // 
            // LEstados
            // 
            this.LEstados.AutoSize = true;
            this.LEstados.Location = new System.Drawing.Point(39, 229);
            this.LEstados.Name = "LEstados";
            this.LEstados.Size = new System.Drawing.Size(63, 19);
            this.LEstados.TabIndex = 24;
            this.LEstados.Text = "Estados: ";
            // 
            // BFinalizar
            // 
            this.BFinalizar.BackColor = System.Drawing.Color.IndianRed;
            this.BFinalizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BFinalizar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BFinalizar.ForeColor = System.Drawing.Color.White;
            this.BFinalizar.Location = new System.Drawing.Point(242, 578);
            this.BFinalizar.Margin = new System.Windows.Forms.Padding(4);
            this.BFinalizar.Name = "BFinalizar";
            this.BFinalizar.Size = new System.Drawing.Size(149, 25);
            this.BFinalizar.TabIndex = 25;
            this.BFinalizar.Text = "Finalizar/Cancelar";
            this.BFinalizar.UseVisualStyleBackColor = false;
            this.BFinalizar.Click += new System.EventHandler(this.BFinalizar_Click);
            // 
            // LFinalizarC
            // 
            this.LFinalizarC.AutoSize = true;
            this.LFinalizarC.Location = new System.Drawing.Point(38, 542);
            this.LFinalizarC.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LFinalizarC.Name = "LFinalizarC";
            this.LFinalizarC.Size = new System.Drawing.Size(166, 19);
            this.LFinalizarC.TabIndex = 26;
            this.LFinalizarC.Text = "Finalizar/Cancelar Reserva";
            // 
            // TReservaN
            // 
            this.TReservaN.Location = new System.Drawing.Point(125, 578);
            this.TReservaN.Margin = new System.Windows.Forms.Padding(4);
            this.TReservaN.Name = "TReservaN";
            this.TReservaN.Size = new System.Drawing.Size(109, 25);
            this.TReservaN.TabIndex = 27;
            // 
            // LReservaN
            // 
            this.LReservaN.AutoSize = true;
            this.LReservaN.Location = new System.Drawing.Point(38, 581);
            this.LReservaN.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LReservaN.Name = "LReservaN";
            this.LReservaN.Size = new System.Drawing.Size(78, 19);
            this.LReservaN.TabIndex = 28;
            this.LReservaN.Text = "Reserva N°:";
            // 
            // Reservas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1008, 667);
            this.Controls.Add(this.LReservaN);
            this.Controls.Add(this.TReservaN);
            this.Controls.Add(this.LFinalizarC);
            this.Controls.Add(this.BFinalizar);
            this.Controls.Add(this.LEstados);
            this.Controls.Add(this.LEspera);
            this.Controls.Add(this.LConfirmadas);
            this.Controls.Add(this.LTerminadas);
            this.Controls.Add(this.BActualizar);
            this.Controls.Add(this.LTituloFiltros);
            this.Controls.Add(this.RBSuite);
            this.Controls.Add(this.RBDoble);
            this.Controls.Add(this.GrillaReservas);
            this.Controls.Add(this.RBSingle);
            this.Controls.Add(this.LTituloReservas);
            this.Controls.Add(this.lblMetodoPago);
            this.Controls.Add(this.LNombre);
            this.Controls.Add(this.LApellido);
            this.Controls.Add(this.TNombre);
            this.Controls.Add(this.TApellido);
            this.Controls.Add(this.dtpFechaInicio);
            this.Controls.Add(this.btnLimpiarFiltros);
            this.Controls.Add(this.dtpFechaFin);
            this.Controls.Add(this.btnNuevaReserva);
            this.Controls.Add(this.LFechaDesde);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.LFechaHasta);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Reservas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Reservas";
            this.Load += new System.EventHandler(this.Reservas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GrillaReservas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LTituloReservas;
        private System.Windows.Forms.DataGridView GrillaReservas;
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
        private System.Windows.Forms.Label LTituloFiltros;
        private System.Windows.Forms.Button BActualizar;
        private System.Windows.Forms.Label LTerminadas;
        private System.Windows.Forms.Label LConfirmadas;
        private System.Windows.Forms.Label LEspera;
        private System.Windows.Forms.Label LEstados;
        private System.Windows.Forms.Button BFinalizar;
        private System.Windows.Forms.Label LFinalizarC;
        private System.Windows.Forms.TextBox TReservaN;
        private System.Windows.Forms.Label LReservaN;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn inicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn fin;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn apellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn numero_hab;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo_hab;
        private System.Windows.Forms.DataGridViewTextBoxColumn subtotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn total;
        private System.Windows.Forms.DataGridViewTextBoxColumn estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_creacion;
    }
}