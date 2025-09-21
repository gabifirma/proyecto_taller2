namespace HotelCalifornia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Habitaciones));
            this.LTituloHabitaciones = new System.Windows.Forms.Label();
            this.GrillaHabitaciones = new System.Windows.Forms.DataGridView();
            this.numero_hab = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.piso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.capacidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.base_precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BEditarHab = new System.Windows.Forms.Button();
            this.BAgregarHab = new System.Windows.Forms.Button();
            this.RBSuite = new System.Windows.Forms.RadioButton();
            this.PRol = new System.Windows.Forms.Panel();
            this.RBInha = new System.Windows.Forms.RadioButton();
            this.RBDisp = new System.Windows.Forms.RadioButton();
            this.RBOcup = new System.Windows.Forms.RadioButton();
            this.LEstado = new System.Windows.Forms.Label();
            this.RBDoble = new System.Windows.Forms.RadioButton();
            this.RBSingle = new System.Windows.Forms.RadioButton();
            this.TPiso = new System.Windows.Forms.TextBox();
            this.TNumero = new System.Windows.Forms.TextBox();
            this.LTipo = new System.Windows.Forms.Label();
            this.LPiso = new System.Windows.Forms.Label();
            this.LNumero = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaHabitaciones)).BeginInit();
            this.PRol.SuspendLayout();
            this.SuspendLayout();
            // 
            // LTituloHabitaciones
            // 
            this.LTituloHabitaciones.AutoSize = true;
            this.LTituloHabitaciones.Font = new System.Drawing.Font("Times New Roman", 21.75F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTituloHabitaciones.Location = new System.Drawing.Point(14, 12);
            this.LTituloHabitaciones.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LTituloHabitaciones.Name = "LTituloHabitaciones";
            this.LTituloHabitaciones.Size = new System.Drawing.Size(288, 33);
            this.LTituloHabitaciones.TabIndex = 0;
            this.LTituloHabitaciones.Text = "Grilla de Habitaciones";
            // 
            // GrillaHabitaciones
            // 
            this.GrillaHabitaciones.AllowUserToAddRows = false;
            this.GrillaHabitaciones.AllowUserToDeleteRows = false;
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
            this.GrillaHabitaciones.Location = new System.Drawing.Point(14, 412);
            this.GrillaHabitaciones.Margin = new System.Windows.Forms.Padding(4);
            this.GrillaHabitaciones.Name = "GrillaHabitaciones";
            this.GrillaHabitaciones.ReadOnly = true;
            this.GrillaHabitaciones.RowHeadersVisible = false;
            this.GrillaHabitaciones.Size = new System.Drawing.Size(980, 239);
            this.GrillaHabitaciones.TabIndex = 1;
            // 
            // numero_hab
            // 
            this.numero_hab.HeaderText = "Número Hab.";
            this.numero_hab.Name = "numero_hab";
            this.numero_hab.ReadOnly = true;
            // 
            // piso
            // 
            this.piso.HeaderText = "Piso";
            this.piso.Name = "piso";
            this.piso.ReadOnly = true;
            // 
            // id_estado
            // 
            this.id_estado.HeaderText = "Estado";
            this.id_estado.Name = "id_estado";
            this.id_estado.ReadOnly = true;
            // 
            // nombre
            // 
            this.nombre.HeaderText = "Nombre";
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            // 
            // capacidad
            // 
            this.capacidad.HeaderText = "Capacidad";
            this.capacidad.Name = "capacidad";
            this.capacidad.ReadOnly = true;
            // 
            // descripcion
            // 
            this.descripcion.HeaderText = "Descripción";
            this.descripcion.Name = "descripcion";
            this.descripcion.ReadOnly = true;
            // 
            // base_precio
            // 
            this.base_precio.HeaderText = "Precio Base";
            this.base_precio.Name = "base_precio";
            this.base_precio.ReadOnly = true;
            // 
            // BEditarHab
            // 
            this.BEditarHab.Image = ((System.Drawing.Image)(resources.GetObject("BEditarHab.Image")));
            this.BEditarHab.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BEditarHab.Location = new System.Drawing.Point(215, 197);
            this.BEditarHab.Margin = new System.Windows.Forms.Padding(4);
            this.BEditarHab.Name = "BEditarHab";
            this.BEditarHab.Size = new System.Drawing.Size(111, 52);
            this.BEditarHab.TabIndex = 6;
            this.BEditarHab.Text = "Editar";
            this.BEditarHab.UseVisualStyleBackColor = true;
            this.BEditarHab.Click += new System.EventHandler(this.BEditarHab_Click);
            // 
            // BAgregarHab
            // 
            this.BAgregarHab.Image = ((System.Drawing.Image)(resources.GetObject("BAgregarHab.Image")));
            this.BAgregarHab.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BAgregarHab.Location = new System.Drawing.Point(93, 197);
            this.BAgregarHab.Margin = new System.Windows.Forms.Padding(4);
            this.BAgregarHab.Name = "BAgregarHab";
            this.BAgregarHab.Size = new System.Drawing.Size(111, 52);
            this.BAgregarHab.TabIndex = 5;
            this.BAgregarHab.Text = "Agregar";
            this.BAgregarHab.UseVisualStyleBackColor = true;
            this.BAgregarHab.Click += new System.EventHandler(this.BAgregarHab_Click);
            // 
            // RBSuite
            // 
            this.RBSuite.AutoSize = true;
            this.RBSuite.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RBSuite.Location = new System.Drawing.Point(718, 84);
            this.RBSuite.Margin = new System.Windows.Forms.Padding(4);
            this.RBSuite.Name = "RBSuite";
            this.RBSuite.Size = new System.Drawing.Size(59, 23);
            this.RBSuite.TabIndex = 51;
            this.RBSuite.Text = "Suite";
            this.RBSuite.UseVisualStyleBackColor = true;
            // 
            // PRol
            // 
            this.PRol.Controls.Add(this.RBInha);
            this.PRol.Controls.Add(this.RBDisp);
            this.PRol.Controls.Add(this.RBOcup);
            this.PRol.Location = new System.Drawing.Point(93, 145);
            this.PRol.Margin = new System.Windows.Forms.Padding(4);
            this.PRol.Name = "PRol";
            this.PRol.Size = new System.Drawing.Size(368, 44);
            this.PRol.TabIndex = 48;
            // 
            // RBInha
            // 
            this.RBInha.AutoSize = true;
            this.RBInha.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RBInha.Location = new System.Drawing.Point(227, 8);
            this.RBInha.Margin = new System.Windows.Forms.Padding(4);
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
            this.RBDisp.Location = new System.Drawing.Point(4, 10);
            this.RBDisp.Margin = new System.Windows.Forms.Padding(4);
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
            this.RBOcup.Location = new System.Drawing.Point(121, 5);
            this.RBOcup.Margin = new System.Windows.Forms.Padding(4);
            this.RBOcup.Name = "RBOcup";
            this.RBOcup.Size = new System.Drawing.Size(85, 23);
            this.RBOcup.TabIndex = 15;
            this.RBOcup.Text = "Ocupado";
            this.RBOcup.UseVisualStyleBackColor = true;
            // 
            // LEstado
            // 
            this.LEstado.AutoSize = true;
            this.LEstado.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LEstado.Location = new System.Drawing.Point(16, 156);
            this.LEstado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LEstado.Name = "LEstado";
            this.LEstado.Size = new System.Drawing.Size(54, 19);
            this.LEstado.TabIndex = 47;
            this.LEstado.Text = "Estado";
            // 
            // RBDoble
            // 
            this.RBDoble.AutoSize = true;
            this.RBDoble.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RBDoble.Location = new System.Drawing.Point(614, 84);
            this.RBDoble.Margin = new System.Windows.Forms.Padding(4);
            this.RBDoble.Name = "RBDoble";
            this.RBDoble.Size = new System.Drawing.Size(65, 23);
            this.RBDoble.TabIndex = 46;
            this.RBDoble.Text = "Doble";
            this.RBDoble.UseVisualStyleBackColor = true;
            // 
            // RBSingle
            // 
            this.RBSingle.AutoSize = true;
            this.RBSingle.Checked = true;
            this.RBSingle.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RBSingle.Location = new System.Drawing.Point(504, 84);
            this.RBSingle.Margin = new System.Windows.Forms.Padding(4);
            this.RBSingle.Name = "RBSingle";
            this.RBSingle.Size = new System.Drawing.Size(66, 23);
            this.RBSingle.TabIndex = 45;
            this.RBSingle.TabStop = true;
            this.RBSingle.Text = "Single";
            this.RBSingle.UseVisualStyleBackColor = true;
            // 
            // TPiso
            // 
            this.TPiso.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TPiso.Location = new System.Drawing.Point(299, 80);
            this.TPiso.Margin = new System.Windows.Forms.Padding(4);
            this.TPiso.Name = "TPiso";
            this.TPiso.Size = new System.Drawing.Size(90, 26);
            this.TPiso.TabIndex = 44;
            // 
            // TNumero
            // 
            this.TNumero.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TNumero.Location = new System.Drawing.Point(93, 80);
            this.TNumero.Margin = new System.Windows.Forms.Padding(4);
            this.TNumero.Name = "TNumero";
            this.TNumero.Size = new System.Drawing.Size(90, 26);
            this.TNumero.TabIndex = 43;
            // 
            // LTipo
            // 
            this.LTipo.AutoSize = true;
            this.LTipo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTipo.Location = new System.Drawing.Point(427, 84);
            this.LTipo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LTipo.Name = "LTipo";
            this.LTipo.Size = new System.Drawing.Size(37, 19);
            this.LTipo.TabIndex = 42;
            this.LTipo.Text = "Tipo";
            // 
            // LPiso
            // 
            this.LPiso.AutoSize = true;
            this.LPiso.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LPiso.Location = new System.Drawing.Point(236, 84);
            this.LPiso.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LPiso.Name = "LPiso";
            this.LPiso.Size = new System.Drawing.Size(37, 19);
            this.LPiso.TabIndex = 41;
            this.LPiso.Text = "Piso";
            // 
            // LNumero
            // 
            this.LNumero.AutoSize = true;
            this.LNumero.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LNumero.Location = new System.Drawing.Point(15, 84);
            this.LNumero.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LNumero.Name = "LNumero";
            this.LNumero.Size = new System.Drawing.Size(60, 19);
            this.LNumero.TabIndex = 40;
            this.LNumero.Text = "Número";
            // 
            // Habitaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(1008, 667);
            this.Controls.Add(this.RBSuite);
            this.Controls.Add(this.PRol);
            this.Controls.Add(this.LEstado);
            this.Controls.Add(this.RBDoble);
            this.Controls.Add(this.RBSingle);
            this.Controls.Add(this.TPiso);
            this.Controls.Add(this.TNumero);
            this.Controls.Add(this.LTipo);
            this.Controls.Add(this.LPiso);
            this.Controls.Add(this.LNumero);
            this.Controls.Add(this.BEditarHab);
            this.Controls.Add(this.BAgregarHab);
            this.Controls.Add(this.GrillaHabitaciones);
            this.Controls.Add(this.LTituloHabitaciones);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Habitaciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Habitaciones";
            this.Load += new System.EventHandler(this.Habitaciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GrillaHabitaciones)).EndInit();
            this.PRol.ResumeLayout(false);
            this.PRol.PerformLayout();
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
        private System.Windows.Forms.RadioButton RBSuite;
        private System.Windows.Forms.Panel PRol;
        private System.Windows.Forms.RadioButton RBInha;
        private System.Windows.Forms.RadioButton RBDisp;
        private System.Windows.Forms.RadioButton RBOcup;
        private System.Windows.Forms.Label LEstado;
        private System.Windows.Forms.RadioButton RBDoble;
        private System.Windows.Forms.RadioButton RBSingle;
        private System.Windows.Forms.TextBox TPiso;
        private System.Windows.Forms.TextBox TNumero;
        private System.Windows.Forms.Label LTipo;
        private System.Windows.Forms.Label LPiso;
        private System.Windows.Forms.Label LNumero;
    }
}