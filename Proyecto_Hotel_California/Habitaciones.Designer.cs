namespace Proyecto_Hotel_California
{
    partial class Habitaciones
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
            this.LTituloHabitaciones = new System.Windows.Forms.Label();
            this.GrillaHabitaciones = new System.Windows.Forms.DataGridView();
            this.BEditarHab = new System.Windows.Forms.Button();
            this.BAgregarHab = new System.Windows.Forms.Button();
            this.numero_hab = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.piso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.capacidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.base_precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaHabitaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // LTituloHabitaciones
            // 
            this.LTituloHabitaciones.AutoSize = true;
            this.LTituloHabitaciones.Font = new System.Drawing.Font("Times New Roman", 18F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTituloHabitaciones.Location = new System.Drawing.Point(234, 36);
            this.LTituloHabitaciones.Name = "LTituloHabitaciones";
            this.LTituloHabitaciones.Size = new System.Drawing.Size(238, 28);
            this.LTituloHabitaciones.TabIndex = 0;
            this.LTituloHabitaciones.Text = "Grilla de Habitaciones";
            // 
            // GrillaHabitaciones
            // 
            this.GrillaHabitaciones.AllowUserToAddRows = false;
            this.GrillaHabitaciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GrillaHabitaciones.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GrillaHabitaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrillaHabitaciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.numero_hab,
            this.piso,
            this.id_estado,
            this.nombre,
            this.capacidad,
            this.descripcion,
            this.base_precio});
            this.GrillaHabitaciones.Location = new System.Drawing.Point(12, 144);
            this.GrillaHabitaciones.Name = "GrillaHabitaciones";
            this.GrillaHabitaciones.RowHeadersVisible = false;
            this.GrillaHabitaciones.Size = new System.Drawing.Size(710, 183);
            this.GrillaHabitaciones.TabIndex = 1;
            // 
            // BEditarHab
            // 
            this.BEditarHab.Location = new System.Drawing.Point(113, 88);
            this.BEditarHab.Name = "BEditarHab";
            this.BEditarHab.Size = new System.Drawing.Size(95, 40);
            this.BEditarHab.TabIndex = 6;
            this.BEditarHab.Text = "Editar";
            this.BEditarHab.UseVisualStyleBackColor = true;
            this.BEditarHab.Click += new System.EventHandler(this.BEditarHab_Click);
            // 
            // BAgregarHab
            // 
            this.BAgregarHab.Location = new System.Drawing.Point(12, 88);
            this.BAgregarHab.Name = "BAgregarHab";
            this.BAgregarHab.Size = new System.Drawing.Size(95, 40);
            this.BAgregarHab.TabIndex = 5;
            this.BAgregarHab.Text = "Agregar";
            this.BAgregarHab.UseVisualStyleBackColor = true;
            this.BAgregarHab.Click += new System.EventHandler(this.BAgregarHab_Click);
            // 
            // numero_hab
            // 
            this.numero_hab.HeaderText = "Número Hab.";
            this.numero_hab.Name = "numero_hab";
            // 
            // piso
            // 
            this.piso.HeaderText = "Piso";
            this.piso.Name = "piso";
            // 
            // id_estado
            // 
            this.id_estado.HeaderText = "Estado";
            this.id_estado.Name = "id_estado";
            // 
            // nombre
            // 
            this.nombre.HeaderText = "Nombre";
            this.nombre.Name = "nombre";
            // 
            // capacidad
            // 
            this.capacidad.HeaderText = "Capacidad";
            this.capacidad.Name = "capacidad";
            // 
            // descripcion
            // 
            this.descripcion.HeaderText = "Descripción";
            this.descripcion.Name = "descripcion";
            // 
            // base_precio
            // 
            this.base_precio.HeaderText = "Precio Base";
            this.base_precio.Name = "base_precio";
            // 
            // Habitaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(734, 511);
            this.Controls.Add(this.BEditarHab);
            this.Controls.Add(this.BAgregarHab);
            this.Controls.Add(this.GrillaHabitaciones);
            this.Controls.Add(this.LTituloHabitaciones);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Habitaciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Habitaciones";
            this.Load += new System.EventHandler(this.Habitaciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GrillaHabitaciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LTituloHabitaciones;
        private System.Windows.Forms.DataGridView GrillaHabitaciones;
        private System.Windows.Forms.Button BEditarHab;
        private System.Windows.Forms.Button BAgregarHab;
        private System.Windows.Forms.DataGridViewTextBoxColumn numero_hab;
        private System.Windows.Forms.DataGridViewTextBoxColumn piso;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn capacidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn base_precio;
    }
}