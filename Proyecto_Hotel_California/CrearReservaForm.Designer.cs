namespace HotelCalifornia
{
    partial class CrearReservaForm
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.TNombre = new System.Windows.Forms.TextBox();
            this.LServicios = new System.Windows.Forms.Label();
            this.lblMontoEstimado = new System.Windows.Forms.Label();
            this.TMonto = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.LNumHab = new System.Windows.Forms.Label();
            this.GrillaHabDisp = new System.Windows.Forms.DataGridView();
            this.TApellido = new System.Windows.Forms.TextBox();
            this.lblApellido = new System.Windows.Forms.Label();
            this.TDni = new System.Windows.Forms.TextBox();
            this.lblDni = new System.Windows.Forms.Label();
            this.TTelefono = new System.Windows.Forms.TextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.TEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.CBCantNoches = new System.Windows.Forms.DomainUpDown();
            this.LCantNoches = new System.Windows.Forms.Label();
            this.CHJacuzzi = new System.Windows.Forms.CheckBox();
            this.CHMinibar = new System.Windows.Forms.CheckBox();
            this.CHPool = new System.Windows.Forms.CheckBox();
            this.BListaClientes = new System.Windows.Forms.Button();
            this.numero_hab = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.piso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.capacidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.base_precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Reservar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaHabDisp)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(349, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(155, 25);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Nueva Reserva";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(30, 62);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(82, 13);
            this.lblNombre.TabIndex = 1;
            this.lblNombre.Text = "Nombre Cliente:";
            // 
            // TNombre
            // 
            this.TNombre.Location = new System.Drawing.Point(118, 60);
            this.TNombre.Name = "TNombre";
            this.TNombre.Size = new System.Drawing.Size(212, 20);
            this.TNombre.TabIndex = 2;
            this.TNombre.Leave += new System.EventHandler(this.TNombre_Leave);
            // 
            // LServicios
            // 
            this.LServicios.AutoSize = true;
            this.LServicios.Location = new System.Drawing.Point(351, 140);
            this.LServicios.Name = "LServicios";
            this.LServicios.Size = new System.Drawing.Size(53, 13);
            this.LServicios.TabIndex = 9;
            this.LServicios.Text = "Servicios:";
            // 
            // lblMontoEstimado
            // 
            this.lblMontoEstimado.AutoSize = true;
            this.lblMontoEstimado.Location = new System.Drawing.Point(30, 442);
            this.lblMontoEstimado.Name = "lblMontoEstimado";
            this.lblMontoEstimado.Size = new System.Drawing.Size(86, 13);
            this.lblMontoEstimado.TabIndex = 13;
            this.lblMontoEstimado.Text = "Monto Estimado:";
            // 
            // TMonto
            // 
            this.TMonto.Location = new System.Drawing.Point(122, 439);
            this.TMonto.Name = "TMonto";
            this.TMonto.ReadOnly = true;
            this.TMonto.Size = new System.Drawing.Size(120, 20);
            this.TMonto.TabIndex = 14;
            this.TMonto.Text = "0.00";
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.Green;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(319, 473);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(100, 35);
            this.btnGuardar.TabIndex = 15;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(439, 473);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 35);
            this.btnCancelar.TabIndex = 16;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // LNumHab
            // 
            this.LNumHab.AutoSize = true;
            this.LNumHab.Location = new System.Drawing.Point(31, 224);
            this.LNumHab.Name = "LNumHab";
            this.LNumHab.Size = new System.Drawing.Size(129, 13);
            this.LNumHab.TabIndex = 17;
            this.LNumHab.Text = "Habitaciones Disponibles:";
            // 
            // GrillaHabDisp
            // 
            this.GrillaHabDisp.AllowUserToAddRows = false;
            this.GrillaHabDisp.AllowUserToDeleteRows = false;
            this.GrillaHabDisp.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GrillaHabDisp.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GrillaHabDisp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrillaHabDisp.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.numero_hab,
            this.piso,
            this.nombre,
            this.capacidad,
            this.descripcion,
            this.base_precio,
            this.Reservar});
            this.GrillaHabDisp.EnableHeadersVisualStyles = false;
            this.GrillaHabDisp.Location = new System.Drawing.Point(33, 251);
            this.GrillaHabDisp.Name = "GrillaHabDisp";
            this.GrillaHabDisp.ReadOnly = true;
            this.GrillaHabDisp.RowHeadersVisible = false;
            this.GrillaHabDisp.Size = new System.Drawing.Size(815, 168);
            this.GrillaHabDisp.TabIndex = 18;
            this.GrillaHabDisp.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrillaHabDisp_CellContentClick);
            this.GrillaHabDisp.CurrentCellDirtyStateChanged += new System.EventHandler(this.GrillaHabDisp_CurrentCellDirtyStateChanged);
            // 
            // TApellido
            // 
            this.TApellido.Location = new System.Drawing.Point(439, 60);
            this.TApellido.Name = "TApellido";
            this.TApellido.Size = new System.Drawing.Size(212, 20);
            this.TApellido.TabIndex = 20;
            this.TApellido.Leave += new System.EventHandler(this.TApellido_Leave);
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new System.Drawing.Point(351, 63);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(82, 13);
            this.lblApellido.TabIndex = 19;
            this.lblApellido.Text = "Apellido Cliente:";
            // 
            // TDni
            // 
            this.TDni.Location = new System.Drawing.Point(118, 98);
            this.TDni.Name = "TDni";
            this.TDni.Size = new System.Drawing.Size(212, 20);
            this.TDni.TabIndex = 22;
            // 
            // lblDni
            // 
            this.lblDni.AutoSize = true;
            this.lblDni.Location = new System.Drawing.Point(30, 100);
            this.lblDni.Name = "lblDni";
            this.lblDni.Size = new System.Drawing.Size(64, 13);
            this.lblDni.TabIndex = 21;
            this.lblDni.Text = "DNI Cliente:";
            // 
            // TTelefono
            // 
            this.TTelefono.Location = new System.Drawing.Point(439, 100);
            this.TTelefono.Name = "TTelefono";
            this.TTelefono.Size = new System.Drawing.Size(212, 20);
            this.TTelefono.TabIndex = 24;
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Location = new System.Drawing.Point(351, 102);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(87, 13);
            this.lblTelefono.TabIndex = 23;
            this.lblTelefono.Text = "Teléfono Cliente:";
            // 
            // TEmail
            // 
            this.TEmail.Location = new System.Drawing.Point(118, 137);
            this.TEmail.Name = "TEmail";
            this.TEmail.Size = new System.Drawing.Size(212, 20);
            this.TEmail.TabIndex = 26;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(30, 139);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(70, 13);
            this.lblEmail.TabIndex = 25;
            this.lblEmail.Text = "Email Cliente:";
            // 
            // CBCantNoches
            // 
            this.CBCantNoches.Items.Add("1");
            this.CBCantNoches.Items.Add("2");
            this.CBCantNoches.Items.Add("3");
            this.CBCantNoches.Items.Add("4");
            this.CBCantNoches.Items.Add("5");
            this.CBCantNoches.Items.Add("6");
            this.CBCantNoches.Items.Add("7");
            this.CBCantNoches.Location = new System.Drawing.Point(118, 176);
            this.CBCantNoches.Name = "CBCantNoches";
            this.CBCantNoches.ReadOnly = true;
            this.CBCantNoches.Size = new System.Drawing.Size(120, 20);
            this.CBCantNoches.TabIndex = 30;
            this.CBCantNoches.Text = "0";
            this.CBCantNoches.SelectedItemChanged += new System.EventHandler(this.CBCantNoches_SelectedItemChanged);
            // 
            // LCantNoches
            // 
            this.LCantNoches.AutoSize = true;
            this.LCantNoches.Location = new System.Drawing.Point(30, 178);
            this.LCantNoches.Name = "LCantNoches";
            this.LCantNoches.Size = new System.Drawing.Size(75, 13);
            this.LCantNoches.TabIndex = 31;
            this.LCantNoches.Text = "Cant. Noches:";
            // 
            // CHJacuzzi
            // 
            this.CHJacuzzi.AutoSize = true;
            this.CHJacuzzi.Location = new System.Drawing.Point(439, 139);
            this.CHJacuzzi.Name = "CHJacuzzi";
            this.CHJacuzzi.Size = new System.Drawing.Size(61, 17);
            this.CHJacuzzi.TabIndex = 32;
            this.CHJacuzzi.Text = "Jacuzzi";
            this.CHJacuzzi.UseVisualStyleBackColor = true;
            this.CHJacuzzi.CheckedChanged += new System.EventHandler(this.CHJacuzzi_CheckedChanged);
            // 
            // CHMinibar
            // 
            this.CHMinibar.AutoSize = true;
            this.CHMinibar.Location = new System.Drawing.Point(508, 139);
            this.CHMinibar.Name = "CHMinibar";
            this.CHMinibar.Size = new System.Drawing.Size(60, 17);
            this.CHMinibar.TabIndex = 33;
            this.CHMinibar.Text = "Minibar";
            this.CHMinibar.UseVisualStyleBackColor = true;
            this.CHMinibar.CheckedChanged += new System.EventHandler(this.CHMinibar_CheckedChanged);
            // 
            // CHPool
            // 
            this.CHPool.AutoSize = true;
            this.CHPool.Location = new System.Drawing.Point(574, 139);
            this.CHPool.Name = "CHPool";
            this.CHPool.Size = new System.Drawing.Size(47, 17);
            this.CHPool.TabIndex = 34;
            this.CHPool.Text = "Pool";
            this.CHPool.UseVisualStyleBackColor = true;
            this.CHPool.CheckedChanged += new System.EventHandler(this.CHPool_CheckedChanged);
            // 
            // BListaClientes
            // 
            this.BListaClientes.Location = new System.Drawing.Point(714, 60);
            this.BListaClientes.Name = "BListaClientes";
            this.BListaClientes.Size = new System.Drawing.Size(78, 60);
            this.BListaClientes.TabIndex = 35;
            this.BListaClientes.Text = "Lista de Clientes";
            this.BListaClientes.UseVisualStyleBackColor = true;
            this.BListaClientes.Click += new System.EventHandler(this.BListaClientes_Click);
            // 
            // numero_hab
            // 
            this.numero_hab.DataPropertyName = "numero_hab";
            this.numero_hab.HeaderText = "Número";
            this.numero_hab.Name = "numero_hab";
            this.numero_hab.ReadOnly = true;
            // 
            // piso
            // 
            this.piso.DataPropertyName = "piso";
            this.piso.HeaderText = "Piso";
            this.piso.Name = "piso";
            this.piso.ReadOnly = true;
            // 
            // nombre
            // 
            this.nombre.DataPropertyName = "nombre";
            this.nombre.HeaderText = "Nombre";
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            // 
            // capacidad
            // 
            this.capacidad.DataPropertyName = "capacidad";
            this.capacidad.HeaderText = "Capacidad";
            this.capacidad.Name = "capacidad";
            this.capacidad.ReadOnly = true;
            // 
            // descripcion
            // 
            this.descripcion.DataPropertyName = "descripcion";
            this.descripcion.HeaderText = "Descripción";
            this.descripcion.Name = "descripcion";
            this.descripcion.ReadOnly = true;
            // 
            // base_precio
            // 
            this.base_precio.DataPropertyName = "base_precio";
            this.base_precio.HeaderText = "Precio Base";
            this.base_precio.Name = "base_precio";
            this.base_precio.ReadOnly = true;
            // 
            // Reservar
            // 
            this.Reservar.DataPropertyName = "reservar";
            this.Reservar.HeaderText = "Reservar";
            this.Reservar.Name = "Reservar";
            this.Reservar.ReadOnly = true;
            this.Reservar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // CrearReservaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(875, 520);
            this.Controls.Add(this.BListaClientes);
            this.Controls.Add(this.CHPool);
            this.Controls.Add(this.CHMinibar);
            this.Controls.Add(this.CHJacuzzi);
            this.Controls.Add(this.LCantNoches);
            this.Controls.Add(this.CBCantNoches);
            this.Controls.Add(this.TEmail);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.TTelefono);
            this.Controls.Add(this.lblTelefono);
            this.Controls.Add(this.TDni);
            this.Controls.Add(this.lblDni);
            this.Controls.Add(this.TApellido);
            this.Controls.Add(this.lblApellido);
            this.Controls.Add(this.GrillaHabDisp);
            this.Controls.Add(this.LNumHab);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.TMonto);
            this.Controls.Add(this.lblMontoEstimado);
            this.Controls.Add(this.LServicios);
            this.Controls.Add(this.TNombre);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CrearReservaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nueva Reserva - Hotel California";
            this.Load += new System.EventHandler(this.CrearReservaForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GrillaHabDisp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox TNombre;
        private System.Windows.Forms.Label LServicios;
        private System.Windows.Forms.Label lblMontoEstimado;
        private System.Windows.Forms.TextBox TMonto;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label LNumHab;
        private System.Windows.Forms.TextBox TApellido;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.TextBox TDni;
        private System.Windows.Forms.Label lblDni;
        private System.Windows.Forms.TextBox TTelefono;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.TextBox TEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.DataGridView GrillaHabDisp;
        private System.Windows.Forms.DomainUpDown CBCantNoches;
        private System.Windows.Forms.Label LCantNoches;
        private System.Windows.Forms.CheckBox CHJacuzzi;
        private System.Windows.Forms.CheckBox CHMinibar;
        private System.Windows.Forms.CheckBox CHPool;
        private System.Windows.Forms.Button BListaClientes;
        private System.Windows.Forms.DataGridViewTextBoxColumn numero_hab;
        private System.Windows.Forms.DataGridViewTextBoxColumn piso;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn capacidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn base_precio;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Reservar;
    }
}
