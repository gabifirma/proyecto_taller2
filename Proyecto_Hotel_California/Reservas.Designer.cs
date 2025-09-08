namespace Proyecto_Hotel_California
{
    partial class Reservas
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
            this.LTituloReservas = new System.Windows.Forms.Label();
            this.GrillaReservas = new System.Windows.Forms.DataGridView();
            this.id_reserva = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaInicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaFin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaCreacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.observaciones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaReservas)).BeginInit();
            this.SuspendLayout();
            // 
            // LTituloReservas
            // 
            this.LTituloReservas.AutoSize = true;
            this.LTituloReservas.Font = new System.Drawing.Font("Times New Roman", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTituloReservas.Location = new System.Drawing.Point(256, 37);
            this.LTituloReservas.Name = "LTituloReservas";
            this.LTituloReservas.Size = new System.Drawing.Size(194, 28);
            this.LTituloReservas.TabIndex = 0;
            this.LTituloReservas.Text = "Grilla de Reservas";
            // 
            // GrillaReservas
            // 
            this.GrillaReservas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GrillaReservas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrillaReservas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_reserva,
            this.fechaInicio,
            this.fechaFin,
            this.estado,
            this.fechaCreacion,
            this.observaciones});
            this.GrillaReservas.Location = new System.Drawing.Point(12, 121);
            this.GrillaReservas.Name = "GrillaReservas";
            this.GrillaReservas.Size = new System.Drawing.Size(710, 150);
            this.GrillaReservas.TabIndex = 1;
            // 
            // id_reserva
            // 
            this.id_reserva.HeaderText = "ID Reserva";
            this.id_reserva.Name = "id_reserva";
            // 
            // fechaInicio
            // 
            this.fechaInicio.HeaderText = "Fecha Ini.";
            this.fechaInicio.Name = "fechaInicio";
            // 
            // fechaFin
            // 
            this.fechaFin.HeaderText = "Fecha Fin";
            this.fechaFin.Name = "fechaFin";
            // 
            // estado
            // 
            this.estado.HeaderText = "Estado";
            this.estado.Name = "estado";
            // 
            // fechaCreacion
            // 
            this.fechaCreacion.HeaderText = "Fecha Creación";
            this.fechaCreacion.Name = "fechaCreacion";
            // 
            // observaciones
            // 
            this.observaciones.HeaderText = "Observaciones";
            this.observaciones.Name = "observaciones";
            // 
            // Reservas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(734, 511);
            this.Controls.Add(this.GrillaReservas);
            this.Controls.Add(this.LTituloReservas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Reservas";
            this.Text = "Reservas";
            ((System.ComponentModel.ISupportInitialize)(this.GrillaReservas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LTituloReservas;
        private System.Windows.Forms.DataGridView GrillaReservas;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_reserva;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaInicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaFin;
        private System.Windows.Forms.DataGridViewTextBoxColumn estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaCreacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn observaciones;
    }
}