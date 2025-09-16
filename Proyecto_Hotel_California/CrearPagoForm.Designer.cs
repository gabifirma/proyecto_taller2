namespace Proyecto_Hotel_California
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
            this.cmbReserva = new System.Windows.Forms.ComboBox();
            this.lblMonto = new System.Windows.Forms.Label();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.lblFechaPago = new System.Windows.Forms.Label();
            this.dtpFechaPago = new System.Windows.Forms.DateTimePicker();
            this.lblMetodoPago = new System.Windows.Forms.Label();
            this.cmbMetodoPago = new System.Windows.Forms.ComboBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(170, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(130, 25);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Nuevo Pago";
            // 
            // lblReserva
            // 
            this.lblReserva.AutoSize = true;
            this.lblReserva.Location = new System.Drawing.Point(30, 70);
            this.lblReserva.Name = "lblReserva";
            this.lblReserva.Size = new System.Drawing.Size(51, 13);
            this.lblReserva.TabIndex = 1;
            this.lblReserva.Text = "Reserva:";
            // 
            // cmbReserva
            // 
            this.cmbReserva.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReserva.FormattingEnabled = true;
            this.cmbReserva.Location = new System.Drawing.Point(150, 67);
            this.cmbReserva.Name = "cmbReserva";
            this.cmbReserva.Size = new System.Drawing.Size(300, 21);
            this.cmbReserva.TabIndex = 2;
            // 
            // lblMonto
            // 
            this.lblMonto.AutoSize = true;
            this.lblMonto.Location = new System.Drawing.Point(30, 110);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new System.Drawing.Size(40, 13);
            this.lblMonto.TabIndex = 3;
            this.lblMonto.Text = "Monto:";
            // 
            // txtMonto
            // 
            this.txtMonto.Location = new System.Drawing.Point(150, 107);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(120, 20);
            this.txtMonto.TabIndex = 4;
            // 
            // lblFechaPago
            // 
            this.lblFechaPago.AutoSize = true;
            this.lblFechaPago.Location = new System.Drawing.Point(30, 150);
            this.lblFechaPago.Name = "lblFechaPago";
            this.lblFechaPago.Size = new System.Drawing.Size(82, 13);
            this.lblFechaPago.TabIndex = 5;
            this.lblFechaPago.Text = "Fecha de Pago:";
            // 
            // dtpFechaPago
            // 
            this.dtpFechaPago.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaPago.Location = new System.Drawing.Point(150, 147);
            this.dtpFechaPago.Name = "dtpFechaPago";
            this.dtpFechaPago.Size = new System.Drawing.Size(120, 20);
            this.dtpFechaPago.TabIndex = 6;
            // 
            // lblMetodoPago
            // 
            this.lblMetodoPago.AutoSize = true;
            this.lblMetodoPago.Location = new System.Drawing.Point(30, 190);
            this.lblMetodoPago.Name = "lblMetodoPago";
            this.lblMetodoPago.Size = new System.Drawing.Size(85, 13);
            this.lblMetodoPago.TabIndex = 7;
            this.lblMetodoPago.Text = "Método de Pago:";
            // 
            // cmbMetodoPago
            // 
            this.cmbMetodoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMetodoPago.FormattingEnabled = true;
            this.cmbMetodoPago.Location = new System.Drawing.Point(150, 187);
            this.cmbMetodoPago.Name = "cmbMetodoPago";
            this.cmbMetodoPago.Size = new System.Drawing.Size(150, 21);
            this.cmbMetodoPago.TabIndex = 8;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(30, 230);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(43, 13);
            this.lblEstado.TabIndex = 9;
            this.lblEstado.Text = "Estado:";
            // 
            // cmbEstado
            // 
            this.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Location = new System.Drawing.Point(150, 227);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(150, 21);
            this.cmbEstado.TabIndex = 10;
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
            // CrearPagoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(480, 340);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.cmbEstado);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.cmbMetodoPago);
            this.Controls.Add(this.lblMetodoPago);
            this.Controls.Add(this.dtpFechaPago);
            this.Controls.Add(this.lblFechaPago);
            this.Controls.Add(this.txtMonto);
            this.Controls.Add(this.lblMonto);
            this.Controls.Add(this.cmbReserva);
            this.Controls.Add(this.lblReserva);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CrearPagoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nuevo Pago - Hotel California";
            this.Load += new System.EventHandler(this.CrearPagoForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblReserva;
        private System.Windows.Forms.ComboBox cmbReserva;
        private System.Windows.Forms.Label lblMonto;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.Label lblFechaPago;
        private System.Windows.Forms.DateTimePicker dtpFechaPago;
        private System.Windows.Forms.Label lblMetodoPago;
        private System.Windows.Forms.ComboBox cmbMetodoPago;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
    }
}
