namespace HotelCalifornia
{
    partial class DetallesPago
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
            this.LCliente = new System.Windows.Forms.Label();
            this.LReferencia = new System.Windows.Forms.Label();
            this.LFechaPago = new System.Windows.Forms.Label();
            this.LResIni = new System.Windows.Forms.Label();
            this.LResFin = new System.Windows.Forms.Label();
            this.LDni = new System.Windows.Forms.Label();
            this.LEmail = new System.Windows.Forms.Label();
            this.LFactura = new System.Windows.Forms.Label();
            this.GrillaHabitaciones = new System.Windows.Forms.DataGridView();
            this.numero_hab = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.piso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cant_noches = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LHabitacion = new System.Windows.Forms.Label();
            this.LNroRef = new System.Windows.Forms.Label();
            this.LFP = new System.Windows.Forms.Label();
            this.LClie = new System.Windows.Forms.Label();
            this.LD = new System.Windows.Forms.Label();
            this.LMail = new System.Windows.Forms.Label();
            this.LFactu = new System.Windows.Forms.Label();
            this.LInicioR = new System.Windows.Forms.Label();
            this.LFinR = new System.Windows.Forms.Label();
            this.LMP = new System.Windows.Forms.Label();
            this.LMetodoP = new System.Windows.Forms.Label();
            this.LNumRes = new System.Windows.Forms.Label();
            this.LNroReserva = new System.Windows.Forms.Label();
            this.LServiciosOcup = new System.Windows.Forms.Label();
            this.GrillaServicios = new System.Windows.Forms.DataGridView();
            this.servicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precio_servico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaHabitaciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaServicios)).BeginInit();
            this.SuspendLayout();
            // 
            // LCliente
            // 
            this.LCliente.AutoSize = true;
            this.LCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LCliente.Location = new System.Drawing.Point(13, 54);
            this.LCliente.Name = "LCliente";
            this.LCliente.Size = new System.Drawing.Size(66, 20);
            this.LCliente.TabIndex = 0;
            this.LCliente.Text = "Cliente: ";
            // 
            // LReferencia
            // 
            this.LReferencia.AutoSize = true;
            this.LReferencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LReferencia.Location = new System.Drawing.Point(12, 25);
            this.LReferencia.Name = "LReferencia";
            this.LReferencia.Size = new System.Drawing.Size(95, 20);
            this.LReferencia.TabIndex = 1;
            this.LReferencia.Text = "Referencia: ";
            // 
            // LFechaPago
            // 
            this.LFechaPago.AutoSize = true;
            this.LFechaPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LFechaPago.Location = new System.Drawing.Point(281, 25);
            this.LFechaPago.Name = "LFechaPago";
            this.LFechaPago.Size = new System.Drawing.Size(125, 20);
            this.LFechaPago.TabIndex = 2;
            this.LFechaPago.Text = "Fecha de Pago: ";
            // 
            // LResIni
            // 
            this.LResIni.AutoSize = true;
            this.LResIni.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LResIni.Location = new System.Drawing.Point(281, 80);
            this.LResIni.Name = "LResIni";
            this.LResIni.Size = new System.Drawing.Size(117, 20);
            this.LResIni.TabIndex = 3;
            this.LResIni.Text = "Inicio Reserva: ";
            // 
            // LResFin
            // 
            this.LResFin.AutoSize = true;
            this.LResFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LResFin.Location = new System.Drawing.Point(281, 108);
            this.LResFin.Name = "LResFin";
            this.LResFin.Size = new System.Drawing.Size(102, 20);
            this.LResFin.TabIndex = 4;
            this.LResFin.Text = "Fin Reserva: ";
            // 
            // LDni
            // 
            this.LDni.AutoSize = true;
            this.LDni.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LDni.Location = new System.Drawing.Point(12, 80);
            this.LDni.Name = "LDni";
            this.LDni.Size = new System.Drawing.Size(45, 20);
            this.LDni.TabIndex = 6;
            this.LDni.Text = "DNI: ";
            // 
            // LEmail
            // 
            this.LEmail.AutoSize = true;
            this.LEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LEmail.Location = new System.Drawing.Point(12, 108);
            this.LEmail.Name = "LEmail";
            this.LEmail.Size = new System.Drawing.Size(56, 20);
            this.LEmail.TabIndex = 7;
            this.LEmail.Text = "Email: ";
            // 
            // LFactura
            // 
            this.LFactura.AutoSize = true;
            this.LFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LFactura.Location = new System.Drawing.Point(12, 136);
            this.LFactura.Name = "LFactura";
            this.LFactura.Size = new System.Drawing.Size(72, 20);
            this.LFactura.TabIndex = 8;
            this.LFactura.Text = "Factura: ";
            // 
            // GrillaHabitaciones
            // 
            this.GrillaHabitaciones.AllowUserToAddRows = false;
            this.GrillaHabitaciones.AllowUserToDeleteRows = false;
            this.GrillaHabitaciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GrillaHabitaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrillaHabitaciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.numero_hab,
            this.piso,
            this.tipo,
            this.cant_noches,
            this.precio,
            this.subtotal});
            this.GrillaHabitaciones.Location = new System.Drawing.Point(12, 192);
            this.GrillaHabitaciones.Name = "GrillaHabitaciones";
            this.GrillaHabitaciones.ReadOnly = true;
            this.GrillaHabitaciones.RowHeadersVisible = false;
            this.GrillaHabitaciones.Size = new System.Drawing.Size(610, 85);
            this.GrillaHabitaciones.TabIndex = 9;
            // 
            // numero_hab
            // 
            this.numero_hab.DataPropertyName = "Num_hab";
            this.numero_hab.HeaderText = "Número";
            this.numero_hab.Name = "numero_hab";
            this.numero_hab.ReadOnly = true;
            // 
            // piso
            // 
            this.piso.DataPropertyName = "Piso";
            this.piso.HeaderText = "Piso";
            this.piso.Name = "piso";
            this.piso.ReadOnly = true;
            // 
            // tipo
            // 
            this.tipo.DataPropertyName = "Tipo";
            this.tipo.HeaderText = "Tipo";
            this.tipo.Name = "tipo";
            this.tipo.ReadOnly = true;
            // 
            // cant_noches
            // 
            this.cant_noches.DataPropertyName = "Noches";
            this.cant_noches.HeaderText = "Cant. Noches";
            this.cant_noches.Name = "cant_noches";
            this.cant_noches.ReadOnly = true;
            // 
            // precio
            // 
            this.precio.DataPropertyName = "Precio";
            this.precio.HeaderText = "Precio ($)";
            this.precio.Name = "precio";
            this.precio.ReadOnly = true;
            // 
            // subtotal
            // 
            this.subtotal.DataPropertyName = "Subtotal";
            this.subtotal.HeaderText = "Subtotal ($)";
            this.subtotal.Name = "subtotal";
            this.subtotal.ReadOnly = true;
            // 
            // LHabitacion
            // 
            this.LHabitacion.AutoSize = true;
            this.LHabitacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LHabitacion.Location = new System.Drawing.Point(13, 169);
            this.LHabitacion.Name = "LHabitacion";
            this.LHabitacion.Size = new System.Drawing.Size(110, 20);
            this.LHabitacion.TabIndex = 10;
            this.LHabitacion.Text = "Habitación/es:";
            // 
            // LNroRef
            // 
            this.LNroRef.AutoSize = true;
            this.LNroRef.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LNroRef.Location = new System.Drawing.Point(113, 25);
            this.LNroRef.Name = "LNroRef";
            this.LNroRef.Size = new System.Drawing.Size(13, 20);
            this.LNroRef.TabIndex = 11;
            this.LNroRef.Text = ".";
            // 
            // LFP
            // 
            this.LFP.AutoSize = true;
            this.LFP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LFP.Location = new System.Drawing.Point(412, 25);
            this.LFP.Name = "LFP";
            this.LFP.Size = new System.Drawing.Size(13, 20);
            this.LFP.TabIndex = 12;
            this.LFP.Text = ".";
            // 
            // LClie
            // 
            this.LClie.AutoSize = true;
            this.LClie.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LClie.Location = new System.Drawing.Point(85, 54);
            this.LClie.Name = "LClie";
            this.LClie.Size = new System.Drawing.Size(13, 20);
            this.LClie.TabIndex = 13;
            this.LClie.Text = ".";
            // 
            // LD
            // 
            this.LD.AutoSize = true;
            this.LD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LD.Location = new System.Drawing.Point(63, 80);
            this.LD.Name = "LD";
            this.LD.Size = new System.Drawing.Size(13, 20);
            this.LD.TabIndex = 14;
            this.LD.Text = ".";
            // 
            // LMail
            // 
            this.LMail.AutoSize = true;
            this.LMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LMail.Location = new System.Drawing.Point(74, 108);
            this.LMail.Name = "LMail";
            this.LMail.Size = new System.Drawing.Size(13, 20);
            this.LMail.TabIndex = 15;
            this.LMail.Text = ".";
            // 
            // LFactu
            // 
            this.LFactu.AutoSize = true;
            this.LFactu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LFactu.Location = new System.Drawing.Point(90, 136);
            this.LFactu.Name = "LFactu";
            this.LFactu.Size = new System.Drawing.Size(13, 20);
            this.LFactu.TabIndex = 16;
            this.LFactu.Text = ".";
            // 
            // LInicioR
            // 
            this.LInicioR.AutoSize = true;
            this.LInicioR.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LInicioR.Location = new System.Drawing.Point(404, 80);
            this.LInicioR.Name = "LInicioR";
            this.LInicioR.Size = new System.Drawing.Size(13, 20);
            this.LInicioR.TabIndex = 17;
            this.LInicioR.Text = ".";
            // 
            // LFinR
            // 
            this.LFinR.AutoSize = true;
            this.LFinR.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LFinR.Location = new System.Drawing.Point(385, 108);
            this.LFinR.Name = "LFinR";
            this.LFinR.Size = new System.Drawing.Size(13, 20);
            this.LFinR.TabIndex = 18;
            this.LFinR.Text = ".";
            // 
            // LMP
            // 
            this.LMP.AutoSize = true;
            this.LMP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LMP.Location = new System.Drawing.Point(412, 54);
            this.LMP.Name = "LMP";
            this.LMP.Size = new System.Drawing.Size(13, 20);
            this.LMP.TabIndex = 20;
            this.LMP.Text = ".";
            // 
            // LMetodoP
            // 
            this.LMetodoP.AutoSize = true;
            this.LMetodoP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LMetodoP.Location = new System.Drawing.Point(281, 54);
            this.LMetodoP.Name = "LMetodoP";
            this.LMetodoP.Size = new System.Drawing.Size(134, 20);
            this.LMetodoP.TabIndex = 19;
            this.LMetodoP.Text = "Método de Pago: ";
            // 
            // LNumRes
            // 
            this.LNumRes.AutoSize = true;
            this.LNumRes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LNumRes.Location = new System.Drawing.Point(383, 136);
            this.LNumRes.Name = "LNumRes";
            this.LNumRes.Size = new System.Drawing.Size(13, 20);
            this.LNumRes.TabIndex = 22;
            this.LNumRes.Text = ".";
            // 
            // LNroReserva
            // 
            this.LNroReserva.AutoSize = true;
            this.LNroReserva.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LNroReserva.Location = new System.Drawing.Point(281, 136);
            this.LNroReserva.Name = "LNroReserva";
            this.LNroReserva.Size = new System.Drawing.Size(96, 20);
            this.LNroReserva.TabIndex = 21;
            this.LNroReserva.Text = "N° Reserva: ";
            // 
            // LServiciosOcup
            // 
            this.LServiciosOcup.AutoSize = true;
            this.LServiciosOcup.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LServiciosOcup.Location = new System.Drawing.Point(12, 290);
            this.LServiciosOcup.Name = "LServiciosOcup";
            this.LServiciosOcup.Size = new System.Drawing.Size(153, 20);
            this.LServiciosOcup.TabIndex = 23;
            this.LServiciosOcup.Text = "Servicios Ocupados:";
            // 
            // GrillaServicios
            // 
            this.GrillaServicios.AllowUserToAddRows = false;
            this.GrillaServicios.AllowUserToDeleteRows = false;
            this.GrillaServicios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GrillaServicios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrillaServicios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.servicio,
            this.cantidad,
            this.precio_servico});
            this.GrillaServicios.Location = new System.Drawing.Point(12, 313);
            this.GrillaServicios.Name = "GrillaServicios";
            this.GrillaServicios.ReadOnly = true;
            this.GrillaServicios.RowHeadersVisible = false;
            this.GrillaServicios.Size = new System.Drawing.Size(365, 98);
            this.GrillaServicios.TabIndex = 24;
            // 
            // servicio
            // 
            this.servicio.DataPropertyName = "Servicio";
            this.servicio.HeaderText = "Servicio";
            this.servicio.Name = "servicio";
            this.servicio.ReadOnly = true;
            // 
            // cantidad
            // 
            this.cantidad.DataPropertyName = "Cantidad";
            this.cantidad.HeaderText = "Cantidad";
            this.cantidad.Name = "cantidad";
            this.cantidad.ReadOnly = true;
            // 
            // precio_servico
            // 
            this.precio_servico.DataPropertyName = "PrecioServ";
            this.precio_servico.HeaderText = "Precio ($)";
            this.precio_servico.Name = "precio_servico";
            this.precio_servico.ReadOnly = true;
            // 
            // DetallesPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(628, 417);
            this.Controls.Add(this.GrillaServicios);
            this.Controls.Add(this.LServiciosOcup);
            this.Controls.Add(this.LNumRes);
            this.Controls.Add(this.LNroReserva);
            this.Controls.Add(this.LMP);
            this.Controls.Add(this.LMetodoP);
            this.Controls.Add(this.LFinR);
            this.Controls.Add(this.LInicioR);
            this.Controls.Add(this.LFactu);
            this.Controls.Add(this.LMail);
            this.Controls.Add(this.LD);
            this.Controls.Add(this.LClie);
            this.Controls.Add(this.LFP);
            this.Controls.Add(this.LNroRef);
            this.Controls.Add(this.LHabitacion);
            this.Controls.Add(this.GrillaHabitaciones);
            this.Controls.Add(this.LFactura);
            this.Controls.Add(this.LEmail);
            this.Controls.Add(this.LDni);
            this.Controls.Add(this.LResFin);
            this.Controls.Add(this.LResIni);
            this.Controls.Add(this.LFechaPago);
            this.Controls.Add(this.LReferencia);
            this.Controls.Add(this.LCliente);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DetallesPago";
            this.Text = "Detalles del Pago";
            this.Load += new System.EventHandler(this.DetallesPago_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GrillaHabitaciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaServicios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LCliente;
        private System.Windows.Forms.Label LReferencia;
        private System.Windows.Forms.Label LFechaPago;
        private System.Windows.Forms.Label LResIni;
        private System.Windows.Forms.Label LResFin;
        private System.Windows.Forms.Label LDni;
        private System.Windows.Forms.Label LEmail;
        private System.Windows.Forms.Label LFactura;
        private System.Windows.Forms.DataGridView GrillaHabitaciones;
        private System.Windows.Forms.Label LHabitacion;
        private System.Windows.Forms.Label LNroRef;
        private System.Windows.Forms.Label LFP;
        private System.Windows.Forms.Label LClie;
        private System.Windows.Forms.Label LD;
        private System.Windows.Forms.Label LMail;
        private System.Windows.Forms.Label LFactu;
        private System.Windows.Forms.Label LInicioR;
        private System.Windows.Forms.Label LFinR;
        private System.Windows.Forms.Label LMP;
        private System.Windows.Forms.Label LMetodoP;
        private System.Windows.Forms.Label LNumRes;
        private System.Windows.Forms.Label LNroReserva;
        private System.Windows.Forms.DataGridViewTextBoxColumn numero_hab;
        private System.Windows.Forms.DataGridViewTextBoxColumn piso;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cant_noches;
        private System.Windows.Forms.DataGridViewTextBoxColumn precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn subtotal;
        private System.Windows.Forms.Label LServiciosOcup;
        private System.Windows.Forms.DataGridView GrillaServicios;
        private System.Windows.Forms.DataGridViewTextBoxColumn servicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn precio_servico;
    }
}