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
            this.id_pago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.monto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_metodo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.referencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LTituloPagos = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaPagos)).BeginInit();
            this.SuspendLayout();
            // 
            // GrillaPagos
            // 
            this.GrillaPagos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GrillaPagos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrillaPagos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_pago,
            this.fecha,
            this.monto,
            this.id_metodo,
            this.referencia});
            this.GrillaPagos.Location = new System.Drawing.Point(12, 138);
            this.GrillaPagos.Name = "GrillaPagos";
            this.GrillaPagos.Size = new System.Drawing.Size(710, 150);
            this.GrillaPagos.TabIndex = 0;
            // 
            // id_pago
            // 
            this.id_pago.HeaderText = "ID Pago";
            this.id_pago.Name = "id_pago";
            // 
            // fecha
            // 
            this.fecha.HeaderText = "Fecha";
            this.fecha.Name = "fecha";
            // 
            // monto
            // 
            this.monto.HeaderText = "Monto";
            this.monto.Name = "monto";
            // 
            // id_metodo
            // 
            this.id_metodo.HeaderText = "Método";
            this.id_metodo.Name = "id_metodo";
            // 
            // referencia
            // 
            this.referencia.HeaderText = "Referencia";
            this.referencia.Name = "referencia";
            // 
            // LTituloPagos
            // 
            this.LTituloPagos.AutoSize = true;
            this.LTituloPagos.Font = new System.Drawing.Font("Times New Roman", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTituloPagos.Location = new System.Drawing.Point(269, 27);
            this.LTituloPagos.Name = "LTituloPagos";
            this.LTituloPagos.Size = new System.Drawing.Size(166, 28);
            this.LTituloPagos.TabIndex = 1;
            this.LTituloPagos.Text = "Grilla de Pagos";
            // 
            // Pagos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(734, 511);
            this.Controls.Add(this.LTituloPagos);
            this.Controls.Add(this.GrillaPagos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Pagos";
            this.Text = "Pagos";
            ((System.ComponentModel.ISupportInitialize)(this.GrillaPagos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView GrillaPagos;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_pago;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn monto;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_metodo;
        private System.Windows.Forms.DataGridViewTextBoxColumn referencia;
        private System.Windows.Forms.Label LTituloPagos;
    }
}