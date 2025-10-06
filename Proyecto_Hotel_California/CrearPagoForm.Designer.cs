namespace HotelCalifornia
{
    partial class CrearPagoForm
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
            this.lblReserva = new System.Windows.Forms.Label();
            this.lblMonto = new System.Windows.Forms.Label();
            this.lblMetodoPago = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.LReserva = new System.Windows.Forms.Label();
            this.lblFechaPago = new System.Windows.Forms.Label();
            this.LFecha = new System.Windows.Forms.Label();
            this.LMonto = new System.Windows.Forms.Label();
            this.RBEfectivo = new System.Windows.Forms.RadioButton();
            this.RBCredito = new System.Windows.Forms.RadioButton();
            this.RBTrans = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(170, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(126, 25);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Nuevo Pago";
            // 
            // lblReserva
            // 
            this.lblReserva.AutoSize = true;
            this.lblReserva.Location = new System.Drawing.Point(30, 97);
            this.lblReserva.Name = "lblReserva";
            this.lblReserva.Size = new System.Drawing.Size(50, 13);
            this.lblReserva.TabIndex = 1;
            this.lblReserva.Text = "Reserva:";
            // 
            // lblMonto
            // 
            this.lblMonto.AutoSize = true;
            this.lblMonto.Location = new System.Drawing.Point(30, 137);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new System.Drawing.Size(40, 13);
            this.lblMonto.TabIndex = 3;
            this.lblMonto.Text = "Monto:";
            // 
            // lblMetodoPago
            // 
            this.lblMetodoPago.AutoSize = true;
            this.lblMetodoPago.Location = new System.Drawing.Point(30, 176);
            this.lblMetodoPago.Name = "lblMetodoPago";
            this.lblMetodoPago.Size = new System.Drawing.Size(89, 13);
            this.lblMetodoPago.TabIndex = 7;
            this.lblMetodoPago.Text = "Método de Pago:";
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.Green;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(200, 280);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(100, 35);
            this.btnGuardar.TabIndex = 11;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(320, 280);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 35);
            this.btnCancelar.TabIndex = 12;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // LReserva
            // 
            this.LReserva.AutoSize = true;
            this.LReserva.Location = new System.Drawing.Point(150, 97);
            this.LReserva.Name = "LReserva";
            this.LReserva.Size = new System.Drawing.Size(47, 13);
            this.LReserva.TabIndex = 13;
            this.LReserva.Text = "Reserva";
            // 
            // lblFechaPago
            // 
            this.lblFechaPago.AutoSize = true;
            this.lblFechaPago.Location = new System.Drawing.Point(30, 67);
            this.lblFechaPago.Name = "lblFechaPago";
            this.lblFechaPago.Size = new System.Drawing.Size(83, 13);
            this.lblFechaPago.TabIndex = 5;
            this.lblFechaPago.Text = "Fecha de Pago:";
            // 
            // LFecha
            // 
            this.LFecha.AutoSize = true;
            this.LFecha.Location = new System.Drawing.Point(150, 66);
            this.LFecha.Name = "LFecha";
            this.LFecha.Size = new System.Drawing.Size(37, 13);
            this.LFecha.TabIndex = 14;
            this.LFecha.Text = "Fecha";
            // 
            // LMonto
            // 
            this.LMonto.AutoSize = true;
            this.LMonto.Location = new System.Drawing.Point(153, 137);
            this.LMonto.Name = "LMonto";
            this.LMonto.Size = new System.Drawing.Size(60, 13);
            this.LMonto.TabIndex = 15;
            this.LMonto.Text = "Monto total";
            // 
            // RBEfectivo
            // 
            this.RBEfectivo.AutoSize = true;
            this.RBEfectivo.Checked = true;
            this.RBEfectivo.Location = new System.Drawing.Point(150, 176);
            this.RBEfectivo.Name = "RBEfectivo";
            this.RBEfectivo.Size = new System.Drawing.Size(64, 17);
            this.RBEfectivo.TabIndex = 16;
            this.RBEfectivo.TabStop = true;
            this.RBEfectivo.Text = "Efectivo";
            this.RBEfectivo.UseVisualStyleBackColor = true;
            // 
            // RBCredito
            // 
            this.RBCredito.AutoSize = true;
            this.RBCredito.Location = new System.Drawing.Point(241, 176);
            this.RBCredito.Name = "RBCredito";
            this.RBCredito.Size = new System.Drawing.Size(58, 17);
            this.RBCredito.TabIndex = 17;
            this.RBCredito.Text = "Crédito";
            this.RBCredito.UseVisualStyleBackColor = true;
            // 
            // RBTrans
            // 
            this.RBTrans.AutoSize = true;
            this.RBTrans.Location = new System.Drawing.Point(343, 176);
            this.RBTrans.Name = "RBTrans";
            this.RBTrans.Size = new System.Drawing.Size(90, 17);
            this.RBTrans.TabIndex = 18;
            this.RBTrans.Text = "Transferencia";
            this.RBTrans.UseVisualStyleBackColor = true;
            // 
            // CrearPagoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(480, 340);
            this.Controls.Add(this.RBTrans);
            this.Controls.Add(this.RBCredito);
            this.Controls.Add(this.RBEfectivo);
            this.Controls.Add(this.LMonto);
            this.Controls.Add(this.LFecha);
            this.Controls.Add(this.LReserva);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.lblMetodoPago);
            this.Controls.Add(this.lblFechaPago);
            this.Controls.Add(this.lblMonto);
            this.Controls.Add(this.lblReserva);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CrearPagoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nuevo Pago - Hotel California";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblReserva;
        private System.Windows.Forms.Label lblMonto;
        private System.Windows.Forms.Label lblMetodoPago;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label LReserva;
        private System.Windows.Forms.Label lblFechaPago;
        private System.Windows.Forms.Label LFecha;
        private System.Windows.Forms.Label LMonto;
        private System.Windows.Forms.RadioButton RBEfectivo;
        private System.Windows.Forms.RadioButton RBCredito;
        private System.Windows.Forms.RadioButton RBTrans;
    }
}
