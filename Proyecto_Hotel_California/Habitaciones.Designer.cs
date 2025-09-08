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
            this.LOcupadas = new System.Windows.Forms.Label();
            this.num_habitacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.piso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.capacidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaHabitaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // LTituloHabitaciones
            // 
            this.LTituloHabitaciones.AutoSize = true;
            this.LTituloHabitaciones.Font = new System.Drawing.Font("Times New Roman", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTituloHabitaciones.Location = new System.Drawing.Point(234, 36);
            this.LTituloHabitaciones.Name = "LTituloHabitaciones";
            this.LTituloHabitaciones.Size = new System.Drawing.Size(238, 28);
            this.LTituloHabitaciones.TabIndex = 0;
            this.LTituloHabitaciones.Text = "Grilla de Habitaciones";
            // 
            // GrillaHabitaciones
            // 
            this.GrillaHabitaciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GrillaHabitaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrillaHabitaciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.num_habitacion,
            this.piso,
            this.id_estado,
            this.nombre,
            this.capacidad,
            this.descripcion});
            this.GrillaHabitaciones.Location = new System.Drawing.Point(12, 143);
            this.GrillaHabitaciones.Name = "GrillaHabitaciones";
            this.GrillaHabitaciones.Size = new System.Drawing.Size(710, 118);
            this.GrillaHabitaciones.TabIndex = 1;
            // 
            // LOcupadas
            // 
            this.LOcupadas.AutoSize = true;
            this.LOcupadas.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LOcupadas.Location = new System.Drawing.Point(12, 114);
            this.LOcupadas.Name = "LOcupadas";
            this.LOcupadas.Size = new System.Drawing.Size(115, 22);
            this.LOcupadas.TabIndex = 2;
            this.LOcupadas.Text = "Habitaciones";
            // 
            // num_habitacion
            // 
            this.num_habitacion.HeaderText = "Número Hab.";
            this.num_habitacion.Name = "num_habitacion";
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
            // Habitaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(734, 511);
            this.Controls.Add(this.LOcupadas);
            this.Controls.Add(this.GrillaHabitaciones);
            this.Controls.Add(this.LTituloHabitaciones);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Habitaciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Habitaciones";
            ((System.ComponentModel.ISupportInitialize)(this.GrillaHabitaciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LTituloHabitaciones;
        private System.Windows.Forms.DataGridView GrillaHabitaciones;
        private System.Windows.Forms.Label LOcupadas;
        private System.Windows.Forms.DataGridViewTextBoxColumn num_habitacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn piso;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn capacidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
    }
}