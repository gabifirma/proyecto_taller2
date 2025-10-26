namespace HotelCalifornia
{
    partial class GestionUsuarios
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
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.lblRol = new System.Windows.Forms.Label();
            this.cmbRolFiltro = new System.Windows.Forms.ComboBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.cmbEstadoFiltro = new System.Windows.Forms.ComboBox();
            this.btnLimpiarFiltros = new System.Windows.Forms.Button();
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.btnAgregarUsuario = new System.Windows.Forms.Button();
            this.btnEditarUsuario = new System.Windows.Forms.Button();
            this.btnEliminarUsuario = new System.Windows.Forms.Button();
            this.lblEstados = new System.Windows.Forms.Label();
            this.lblEstadoActivo = new System.Windows.Forms.Label();
            this.lblEstadoInactivo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.lblTitulo.Location = new System.Drawing.Point(30, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(298, 30);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Gestión de Usuarios";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtBuscar.Location = new System.Drawing.Point(95, 70);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(250, 25);
            this.txtBuscar.TabIndex = 1;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblBuscar.Location = new System.Drawing.Point(20, 73);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(52, 19);
            this.lblBuscar.TabIndex = 2;
            this.lblBuscar.Text = "Buscar";
            // 
            // lblRol
            // 
            this.lblRol.AutoSize = true;
            this.lblRol.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblRol.Location = new System.Drawing.Point(370, 73);
            this.lblRol.Name = "lblRol";
            this.lblRol.Size = new System.Drawing.Size(30, 19);
            this.lblRol.TabIndex = 3;
            this.lblRol.Text = "Rol";
            // 
            // cmbRolFiltro
            // 
            this.cmbRolFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRolFiltro.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbRolFiltro.FormattingEnabled = true;
            this.cmbRolFiltro.Location = new System.Drawing.Point(410, 70);
            this.cmbRolFiltro.Name = "cmbRolFiltro";
            this.cmbRolFiltro.Size = new System.Drawing.Size(180, 25);
            this.cmbRolFiltro.TabIndex = 4;
            this.cmbRolFiltro.SelectedIndexChanged += new System.EventHandler(this.cmbRolFiltro_SelectedIndexChanged);
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblEstado.Location = new System.Drawing.Point(610, 73);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(52, 19);
            this.lblEstado.TabIndex = 5;
            this.lblEstado.Text = "Estado";
            // 
            // cmbEstadoFiltro
            // 
            this.cmbEstadoFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstadoFiltro.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbEstadoFiltro.FormattingEnabled = true;
            this.cmbEstadoFiltro.Location = new System.Drawing.Point(670, 70);
            this.cmbEstadoFiltro.Name = "cmbEstadoFiltro";
            this.cmbEstadoFiltro.Size = new System.Drawing.Size(110, 25);
            this.cmbEstadoFiltro.TabIndex = 6;
            this.cmbEstadoFiltro.SelectedIndexChanged += new System.EventHandler(this.cmbEstadoFiltro_SelectedIndexChanged);
            // 
            // btnLimpiarFiltros
            // 
            this.btnLimpiarFiltros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnLimpiarFiltros.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiarFiltros.FlatAppearance.BorderSize = 0;
            this.btnLimpiarFiltros.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiarFiltros.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLimpiarFiltros.ForeColor = System.Drawing.Color.White;
            this.btnLimpiarFiltros.Location = new System.Drawing.Point(670, 110);
            this.btnLimpiarFiltros.Name = "btnLimpiarFiltros";
            this.btnLimpiarFiltros.Size = new System.Drawing.Size(110, 30);
            this.btnLimpiarFiltros.TabIndex = 7;
            this.btnLimpiarFiltros.Text = "Limpiar";
            this.btnLimpiarFiltros.UseVisualStyleBackColor = false;
            this.btnLimpiarFiltros.Click += new System.EventHandler(this.btnLimpiarFiltros_Click);
            // 
            // dgvUsuarios
            // 
            this.dgvUsuarios.AllowUserToAddRows = false;
            this.dgvUsuarios.AllowUserToDeleteRows = false;
            this.dgvUsuarios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvUsuarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsuarios.BackgroundColor = System.Drawing.Color.White;
            this.dgvUsuarios.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuarios.Location = new System.Drawing.Point(20, 160);
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.ReadOnly = true;
            this.dgvUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsuarios.Size = new System.Drawing.Size(760, 290);
            this.dgvUsuarios.TabIndex = 8;
            this.dgvUsuarios.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsuarios_CellDoubleClick);
            this.dgvUsuarios.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvUsuarios_DataBindingComplete);
            // 
            // btnAgregarUsuario
            // 
            this.btnAgregarUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnAgregarUsuario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarUsuario.FlatAppearance.BorderSize = 0;
            this.btnAgregarUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarUsuario.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAgregarUsuario.ForeColor = System.Drawing.Color.White;
            this.btnAgregarUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregarUsuario.Location = new System.Drawing.Point(630, 470);
            this.btnAgregarUsuario.Name = "btnAgregarUsuario";
            this.btnAgregarUsuario.Size = new System.Drawing.Size(150, 40);
            this.btnAgregarUsuario.TabIndex = 9;
            this.btnAgregarUsuario.Text = "Agregar Usuario";
            this.btnAgregarUsuario.UseVisualStyleBackColor = false;
            this.btnAgregarUsuario.Click += new System.EventHandler(this.btnAgregarUsuario_Click);
            // 
            // btnEditarUsuario
            // 
            this.btnEditarUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnEditarUsuario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditarUsuario.FlatAppearance.BorderSize = 0;
            this.btnEditarUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditarUsuario.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnEditarUsuario.ForeColor = System.Drawing.Color.White;
            this.btnEditarUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditarUsuario.Location = new System.Drawing.Point(470, 470);
            this.btnEditarUsuario.Name = "btnEditarUsuario";
            this.btnEditarUsuario.Size = new System.Drawing.Size(150, 40);
            this.btnEditarUsuario.TabIndex = 10;
            this.btnEditarUsuario.Text = "Editar Usuario";
            this.btnEditarUsuario.UseVisualStyleBackColor = false;
            this.btnEditarUsuario.Click += new System.EventHandler(this.btnEditarUsuario_Click);
            // 
            // btnEliminarUsuario
            // 
            this.btnEliminarUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnEliminarUsuario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminarUsuario.FlatAppearance.BorderSize = 0;
            this.btnEliminarUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarUsuario.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnEliminarUsuario.ForeColor = System.Drawing.Color.White;
            this.btnEliminarUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminarUsuario.Location = new System.Drawing.Point(310, 470);
            this.btnEliminarUsuario.Name = "btnEliminarUsuario";
            this.btnEliminarUsuario.Size = new System.Drawing.Size(150, 40);
            this.btnEliminarUsuario.TabIndex = 11;
            this.btnEliminarUsuario.Text = "Eliminar Usuario";
            this.btnEliminarUsuario.UseVisualStyleBackColor = false;
            this.btnEliminarUsuario.Click += new System.EventHandler(this.btnEliminarUsuario_Click);
            // 
            // lblEstados
            // 
            this.lblEstados.AutoSize = true;
            this.lblEstados.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblEstados.Location = new System.Drawing.Point(20, 125);
            this.lblEstados.Name = "lblEstados";
            this.lblEstados.Size = new System.Drawing.Size(57, 15);
            this.lblEstados.TabIndex = 12;
            this.lblEstados.Text = "Estados:";
            // 
            // lblEstadoActivo
            // 
            this.lblEstadoActivo.AutoSize = true;
            this.lblEstadoActivo.BackColor = System.Drawing.Color.White;
            this.lblEstadoActivo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblEstadoActivo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEstadoActivo.Location = new System.Drawing.Point(90, 124);
            this.lblEstadoActivo.MinimumSize = new System.Drawing.Size(70, 0);
            this.lblEstadoActivo.Name = "lblEstadoActivo";
            this.lblEstadoActivo.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.lblEstadoActivo.Size = new System.Drawing.Size(70, 21);
            this.lblEstadoActivo.TabIndex = 13;
            this.lblEstadoActivo.Text = "Activo";
            // 
            // lblEstadoInactivo
            // 
            this.lblEstadoInactivo.AutoSize = true;
            this.lblEstadoInactivo.BackColor = System.Drawing.Color.LightCoral;
            this.lblEstadoInactivo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblEstadoInactivo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEstadoInactivo.Location = new System.Drawing.Point(170, 124);
            this.lblEstadoInactivo.MinimumSize = new System.Drawing.Size(70, 0);
            this.lblEstadoInactivo.Name = "lblEstadoInactivo";
            this.lblEstadoInactivo.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.lblEstadoInactivo.Size = new System.Drawing.Size(70, 21);
            this.lblEstadoInactivo.TabIndex = 14;
            this.lblEstadoInactivo.Text = "Inactivo";
            // 
            // GestionUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(800, 530);
            this.Controls.Add(this.lblEstadoInactivo);
            this.Controls.Add(this.lblEstadoActivo);
            this.Controls.Add(this.lblEstados);
            this.Controls.Add(this.btnEliminarUsuario);
            this.Controls.Add(this.btnEditarUsuario);
            this.Controls.Add(this.btnAgregarUsuario);
            this.Controls.Add(this.dgvUsuarios);
            this.Controls.Add(this.btnLimpiarFiltros);
            this.Controls.Add(this.cmbEstadoFiltro);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.cmbRolFiltro);
            this.Controls.Add(this.lblRol);
            this.Controls.Add(this.lblBuscar);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GestionUsuarios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestión de Usuarios - Hotel California";
            this.Load += new System.EventHandler(this.GestionUsuarios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.Label lblRol;
        private System.Windows.Forms.ComboBox cmbRolFiltro;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.ComboBox cmbEstadoFiltro;
        private System.Windows.Forms.Button btnLimpiarFiltros;
        private System.Windows.Forms.DataGridView dgvUsuarios;
        private System.Windows.Forms.Button btnAgregarUsuario;
        private System.Windows.Forms.Button btnEditarUsuario;
        private System.Windows.Forms.Button btnEliminarUsuario;
        private System.Windows.Forms.Label lblEstados;
        private System.Windows.Forms.Label lblEstadoActivo;
        private System.Windows.Forms.Label lblEstadoInactivo;
    }
}
