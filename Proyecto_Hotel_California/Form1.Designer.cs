namespace Proyecto_Hotel_California
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
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
            this.PEntrada = new System.Windows.Forms.Panel();
            this.LPassword = new System.Windows.Forms.Label();
            this.LUsuario = new System.Windows.Forms.Label();
            this.TPassword = new System.Windows.Forms.TextBox();
            this.TUsuario = new System.Windows.Forms.TextBox();
            this.LIniciar = new System.Windows.Forms.Label();
            this.BIniciar = new System.Windows.Forms.Button();
            this.PEntrada.SuspendLayout();
            this.SuspendLayout();
            // 
            // PEntrada
            // 
            this.PEntrada.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.PEntrada.Controls.Add(this.LPassword);
            this.PEntrada.Controls.Add(this.LUsuario);
            this.PEntrada.Controls.Add(this.TPassword);
            this.PEntrada.Controls.Add(this.TUsuario);
            this.PEntrada.Controls.Add(this.LIniciar);
            this.PEntrada.Controls.Add(this.BIniciar);
            this.PEntrada.Location = new System.Drawing.Point(164, 72);
            this.PEntrada.Name = "PEntrada";
            this.PEntrada.Size = new System.Drawing.Size(528, 311);
            this.PEntrada.TabIndex = 0;
            // 
            // LPassword
            // 
            this.LPassword.AutoSize = true;
            this.LPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LPassword.Location = new System.Drawing.Point(52, 172);
            this.LPassword.Name = "LPassword";
            this.LPassword.Size = new System.Drawing.Size(92, 20);
            this.LPassword.TabIndex = 5;
            this.LPassword.Text = "Contraseña";
            // 
            // LUsuario
            // 
            this.LUsuario.AutoSize = true;
            this.LUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LUsuario.Location = new System.Drawing.Point(52, 89);
            this.LUsuario.Name = "LUsuario";
            this.LUsuario.Size = new System.Drawing.Size(64, 20);
            this.LUsuario.TabIndex = 4;
            this.LUsuario.Text = "Usuario";
            // 
            // TPassword
            // 
            this.TPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TPassword.Location = new System.Drawing.Point(164, 169);
            this.TPassword.Name = "TPassword";
            this.TPassword.Size = new System.Drawing.Size(183, 26);
            this.TPassword.TabIndex = 3;
            // 
            // TUsuario
            // 
            this.TUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TUsuario.Location = new System.Drawing.Point(164, 86);
            this.TUsuario.Name = "TUsuario";
            this.TUsuario.Size = new System.Drawing.Size(183, 26);
            this.TUsuario.TabIndex = 2;
            // 
            // LIniciar
            // 
            this.LIniciar.AutoSize = true;
            this.LIniciar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LIniciar.Location = new System.Drawing.Point(159, 30);
            this.LIniciar.Name = "LIniciar";
            this.LIniciar.Size = new System.Drawing.Size(155, 25);
            this.LIniciar.TabIndex = 1;
            this.LIniciar.Text = "Iniciar Sesión";
            // 
            // BIniciar
            // 
            this.BIniciar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BIniciar.Location = new System.Drawing.Point(216, 244);
            this.BIniciar.Name = "BIniciar";
            this.BIniciar.Size = new System.Drawing.Size(75, 23);
            this.BIniciar.TabIndex = 0;
            this.BIniciar.Text = "Entrar";
            this.BIniciar.UseVisualStyleBackColor = true;
            this.BIniciar.Click += new System.EventHandler(this.BIniciar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 462);
            this.Controls.Add(this.PEntrada);
            this.Name = "Form1";
            this.Text = "Form1";
            this.PEntrada.ResumeLayout(false);
            this.PEntrada.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PEntrada;
        private System.Windows.Forms.Label LIniciar;
        private System.Windows.Forms.Button BIniciar;
        private System.Windows.Forms.Label LPassword;
        private System.Windows.Forms.Label LUsuario;
        private System.Windows.Forms.TextBox TPassword;
        private System.Windows.Forms.TextBox TUsuario;
    }
}

