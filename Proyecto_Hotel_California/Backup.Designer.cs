namespace HotelCalifornia
{
    partial class Backup
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
            this.BGenerar = new System.Windows.Forms.Button();
            this.LGenerar = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LTituloReservas
            // 
            this.LTituloReservas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LTituloReservas.AutoSize = true;
            this.LTituloReservas.Font = new System.Drawing.Font("Times New Roman", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTituloReservas.Location = new System.Drawing.Point(196, 9);
            this.LTituloReservas.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LTituloReservas.Name = "LTituloReservas";
            this.LTituloReservas.Size = new System.Drawing.Size(191, 28);
            this.LTituloReservas.TabIndex = 1;
            this.LTituloReservas.Text = "Generar Respaldo";
            // 
            // BGenerar
            // 
            this.BGenerar.Location = new System.Drawing.Point(337, 99);
            this.BGenerar.Name = "BGenerar";
            this.BGenerar.Size = new System.Drawing.Size(146, 39);
            this.BGenerar.TabIndex = 2;
            this.BGenerar.Text = "Crear";
            this.BGenerar.UseVisualStyleBackColor = true;
            this.BGenerar.Click += new System.EventHandler(this.BGenerar_Click);
            // 
            // LGenerar
            // 
            this.LGenerar.AutoSize = true;
            this.LGenerar.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LGenerar.Location = new System.Drawing.Point(12, 103);
            this.LGenerar.Name = "LGenerar";
            this.LGenerar.Size = new System.Drawing.Size(304, 25);
            this.LGenerar.TabIndex = 3;
            this.LGenerar.Text = "Crear respaldo de la base de datos";
            // 
            // Backup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(635, 450);
            this.Controls.Add(this.LGenerar);
            this.Controls.Add(this.BGenerar);
            this.Controls.Add(this.LTituloReservas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Backup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Backup";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LTituloReservas;
        private System.Windows.Forms.Button BGenerar;
        private System.Windows.Forms.Label LGenerar;
    }
}