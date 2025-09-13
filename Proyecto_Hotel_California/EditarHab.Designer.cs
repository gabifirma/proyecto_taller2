namespace Proyecto_Hotel_California
{
    partial class EditarHab
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
            this.RBSuite = new System.Windows.Forms.RadioButton();
            this.BCancelar = new System.Windows.Forms.Button();
            this.BFin = new System.Windows.Forms.Button();
            this.PRol = new System.Windows.Forms.Panel();
            this.RBInha = new System.Windows.Forms.RadioButton();
            this.RBDisp = new System.Windows.Forms.RadioButton();
            this.RBOcup = new System.Windows.Forms.RadioButton();
            this.LRol = new System.Windows.Forms.Label();
            this.RBDoble = new System.Windows.Forms.RadioButton();
            this.RBSingle = new System.Windows.Forms.RadioButton();
            this.TPiso = new System.Windows.Forms.TextBox();
            this.TNumero = new System.Windows.Forms.TextBox();
            this.LTipo = new System.Windows.Forms.Label();
            this.LPiso = new System.Windows.Forms.Label();
            this.LNumero = new System.Windows.Forms.Label();
            this.LTitulo = new System.Windows.Forms.Label();
            this.PRol.SuspendLayout();
            this.SuspendLayout();
            // 
            // RBSuite
            // 
            this.RBSuite.AutoSize = true;
            this.RBSuite.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RBSuite.Location = new System.Drawing.Point(270, 116);
            this.RBSuite.Name = "RBSuite";
            this.RBSuite.Size = new System.Drawing.Size(59, 23);
            this.RBSuite.TabIndex = 52;
            this.RBSuite.Text = "Suite";
            this.RBSuite.UseVisualStyleBackColor = true;
            // 
            // BCancelar
            // 
            this.BCancelar.Location = new System.Drawing.Point(171, 246);
            this.BCancelar.Name = "BCancelar";
            this.BCancelar.Size = new System.Drawing.Size(75, 23);
            this.BCancelar.TabIndex = 51;
            this.BCancelar.Text = "Cancelar";
            this.BCancelar.UseVisualStyleBackColor = true;
            this.BCancelar.Click += new System.EventHandler(this.BCancelar_Click);
            // 
            // BFin
            // 
            this.BFin.Location = new System.Drawing.Point(327, 246);
            this.BFin.Name = "BFin";
            this.BFin.Size = new System.Drawing.Size(75, 23);
            this.BFin.TabIndex = 50;
            this.BFin.Text = "Finalizar";
            this.BFin.UseVisualStyleBackColor = true;
            // 
            // PRol
            // 
            this.PRol.Controls.Add(this.RBInha);
            this.PRol.Controls.Add(this.RBDisp);
            this.PRol.Controls.Add(this.RBOcup);
            this.PRol.Location = new System.Drawing.Point(87, 156);
            this.PRol.Name = "PRol";
            this.PRol.Size = new System.Drawing.Size(315, 34);
            this.PRol.TabIndex = 49;
            // 
            // RBInha
            // 
            this.RBInha.AutoSize = true;
            this.RBInha.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RBInha.Location = new System.Drawing.Point(195, 8);
            this.RBInha.Name = "RBInha";
            this.RBInha.Size = new System.Drawing.Size(105, 23);
            this.RBInha.TabIndex = 16;
            this.RBInha.Text = "Inhabilitado";
            this.RBInha.UseVisualStyleBackColor = true;
            // 
            // RBDisp
            // 
            this.RBDisp.AutoSize = true;
            this.RBDisp.Checked = true;
            this.RBDisp.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RBDisp.Location = new System.Drawing.Point(3, 8);
            this.RBDisp.Name = "RBDisp";
            this.RBDisp.Size = new System.Drawing.Size(95, 23);
            this.RBDisp.TabIndex = 17;
            this.RBDisp.TabStop = true;
            this.RBDisp.Text = "Disponible";
            this.RBDisp.UseVisualStyleBackColor = true;
            // 
            // RBOcup
            // 
            this.RBOcup.AutoSize = true;
            this.RBOcup.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RBOcup.Location = new System.Drawing.Point(104, 8);
            this.RBOcup.Name = "RBOcup";
            this.RBOcup.Size = new System.Drawing.Size(85, 23);
            this.RBOcup.TabIndex = 15;
            this.RBOcup.Text = "Ocupado";
            this.RBOcup.UseVisualStyleBackColor = true;
            // 
            // LRol
            // 
            this.LRol.AutoSize = true;
            this.LRol.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LRol.Location = new System.Drawing.Point(21, 164);
            this.LRol.Name = "LRol";
            this.LRol.Size = new System.Drawing.Size(30, 19);
            this.LRol.TabIndex = 48;
            this.LRol.Text = "Rol";
            // 
            // RBDoble
            // 
            this.RBDoble.AutoSize = true;
            this.RBDoble.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RBDoble.Location = new System.Drawing.Point(181, 116);
            this.RBDoble.Name = "RBDoble";
            this.RBDoble.Size = new System.Drawing.Size(65, 23);
            this.RBDoble.TabIndex = 47;
            this.RBDoble.Text = "Doble";
            this.RBDoble.UseVisualStyleBackColor = true;
            // 
            // RBSingle
            // 
            this.RBSingle.AutoSize = true;
            this.RBSingle.Checked = true;
            this.RBSingle.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RBSingle.Location = new System.Drawing.Point(87, 116);
            this.RBSingle.Name = "RBSingle";
            this.RBSingle.Size = new System.Drawing.Size(66, 23);
            this.RBSingle.TabIndex = 46;
            this.RBSingle.TabStop = true;
            this.RBSingle.Text = "Single";
            this.RBSingle.UseVisualStyleBackColor = true;
            // 
            // TPiso
            // 
            this.TPiso.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TPiso.Location = new System.Drawing.Point(263, 67);
            this.TPiso.Name = "TPiso";
            this.TPiso.Size = new System.Drawing.Size(78, 26);
            this.TPiso.TabIndex = 45;
            // 
            // TNumero
            // 
            this.TNumero.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TNumero.Location = new System.Drawing.Point(87, 67);
            this.TNumero.Name = "TNumero";
            this.TNumero.Size = new System.Drawing.Size(78, 26);
            this.TNumero.TabIndex = 44;
            // 
            // LTipo
            // 
            this.LTipo.AutoSize = true;
            this.LTipo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTipo.Location = new System.Drawing.Point(21, 116);
            this.LTipo.Name = "LTipo";
            this.LTipo.Size = new System.Drawing.Size(37, 19);
            this.LTipo.TabIndex = 43;
            this.LTipo.Text = "Tipo";
            // 
            // LPiso
            // 
            this.LPiso.AutoSize = true;
            this.LPiso.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LPiso.Location = new System.Drawing.Point(209, 70);
            this.LPiso.Name = "LPiso";
            this.LPiso.Size = new System.Drawing.Size(37, 19);
            this.LPiso.TabIndex = 42;
            this.LPiso.Text = "Piso";
            // 
            // LNumero
            // 
            this.LNumero.AutoSize = true;
            this.LNumero.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LNumero.Location = new System.Drawing.Point(20, 70);
            this.LNumero.Name = "LNumero";
            this.LNumero.Size = new System.Drawing.Size(60, 19);
            this.LNumero.TabIndex = 41;
            this.LNumero.Text = "Número";
            // 
            // LTitulo
            // 
            this.LTitulo.AutoSize = true;
            this.LTitulo.Font = new System.Drawing.Font("Times New Roman", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTitulo.Location = new System.Drawing.Point(108, 9);
            this.LTitulo.Name = "LTitulo";
            this.LTitulo.Size = new System.Drawing.Size(354, 31);
            this.LTitulo.TabIndex = 40;
            this.LTitulo.Text = "Editar datos de la habitación";
            // 
            // EditarHab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.RBSuite);
            this.Controls.Add(this.BCancelar);
            this.Controls.Add(this.BFin);
            this.Controls.Add(this.PRol);
            this.Controls.Add(this.LRol);
            this.Controls.Add(this.RBDoble);
            this.Controls.Add(this.RBSingle);
            this.Controls.Add(this.TPiso);
            this.Controls.Add(this.TNumero);
            this.Controls.Add(this.LTipo);
            this.Controls.Add(this.LPiso);
            this.Controls.Add(this.LNumero);
            this.Controls.Add(this.LTitulo);
            this.Name = "EditarHab";
            this.Text = "EditarHab";
            this.PRol.ResumeLayout(false);
            this.PRol.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton RBSuite;
        private System.Windows.Forms.Button BCancelar;
        private System.Windows.Forms.Button BFin;
        private System.Windows.Forms.Panel PRol;
        private System.Windows.Forms.RadioButton RBInha;
        private System.Windows.Forms.RadioButton RBDisp;
        private System.Windows.Forms.RadioButton RBOcup;
        private System.Windows.Forms.Label LRol;
        private System.Windows.Forms.RadioButton RBDoble;
        private System.Windows.Forms.RadioButton RBSingle;
        private System.Windows.Forms.TextBox TPiso;
        private System.Windows.Forms.TextBox TNumero;
        private System.Windows.Forms.Label LTipo;
        private System.Windows.Forms.Label LPiso;
        private System.Windows.Forms.Label LNumero;
        private System.Windows.Forms.Label LTitulo;
    }
}