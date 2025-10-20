namespace HotelCalifornia
{
    partial class Habitaciones
    {
        /// <summary>
        /// Variable del diseñador requerida.
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
            this.BAgregarHab = new System.Windows.Forms.Button();
            this.RBSuite = new System.Windows.Forms.RadioButton();
            this.PRol = new System.Windows.Forms.Panel();
            this.RBInha = new System.Windows.Forms.RadioButton();
            this.RBDisp = new System.Windows.Forms.RadioButton();
            this.RBOcup = new System.Windows.Forms.RadioButton();
            this.LEstado = new System.Windows.Forms.Label();
            this.RBDoble = new System.Windows.Forms.RadioButton();
            this.RBSingle = new System.Windows.Forms.RadioButton();
            this.TNumero = new System.Windows.Forms.TextBox();
            this.LTipo = new System.Windows.Forms.Label();
            this.LNumero = new System.Windows.Forms.Label();
            this.LEjemplo = new System.Windows.Forms.Label();
            this.LEstados = new System.Windows.Forms.Label();
            this.LOcupada = new System.Windows.Forms.Label();
            this.LLibre = new System.Windows.Forms.Label();
            this.LInha = new System.Windows.Forms.Label();
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
            this.GrillaHabitaciones.Location = new System.Drawing.Point(19, 273);
            this.GrillaHabitaciones.Margin = new System.Windows.Forms.Padding(4);
            this.GrillaHabitaciones.Name = "GrillaHabitaciones";
            this.GrillaHabitaciones.ReadOnly = true;
            this.GrillaHabitaciones.RowHeadersVisible = false;
            this.GrillaHabitaciones.Size = new System.Drawing.Size(980, 326);
            this.GrillaHabitaciones.TabIndex = 1;
            this.GrillaHabitaciones.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrillaHabitaciones_CellDoubleClick);
            // 
            // numero_hab
            // 
            this.numero_hab.DataPropertyName = "numero_hab";
            this.numero_hab.HeaderText = "Número Hab.";
            this.numero_hab.Name = "numero_hab";
            this.numero_hab.ReadOnly = true;
            // 
            // piso
            // 
            this.piso.DataPropertyName = "piso";
            this.piso.HeaderText = "Piso";
            this.piso.Name = "piso";
            this.piso.ReadOnly = true;
            // 
            // id_estado
            // 
            this.id_estado.DataPropertyName = "id_estado";
            this.id_estado.HeaderText = "Estado";
            this.id_estado.Name = "id_estado";
            this.id_estado.ReadOnly = true;
            this.id_estado.Visible = false;
            // 
            // nombre
            // 
            this.nombre.DataPropertyName = "nombre";
            this.nombre.HeaderText = "Nombre";
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            // 
            // capacidad
            // 
            this.capacidad.DataPropertyName = "capacidad";
            this.capacidad.HeaderText = "Capacidad";
            this.capacidad.Name = "capacidad";
            this.capacidad.ReadOnly = true;
            // 
            // descripcion
            // 
            this.descripcion.DataPropertyName = "descripcion";
            this.descripcion.HeaderText = "Descripción";
            this.descripcion.Name = "descripcion";
            this.descripcion.ReadOnly = true;
            // 
            // base_precio
            // 
            this.base_precio.DataPropertyName = "base_precio";
            this.base_precio.HeaderText = "Precio Base";
            this.base_precio.Name = "base_precio";
            this.base_precio.ReadOnly = true;
            // 
            // BAgregarHab
            // 
            this.BAgregarHab.Image = ((System.Drawing.Image)(resources.GetObject("BAgregarHab.Image")));
            this.BAgregarHab.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BAgregarHab.Location = new System.Drawing.Point(681, 106);
            this.BAgregarHab.Margin = new System.Windows.Forms.Padding(4);
            this.BAgregarHab.Name = "BAgregarHab";
            this.BAgregarHab.Size = new System.Drawing.Size(111, 52);
            this.BAgregarHab.TabIndex = 5;
            this.BAgregarHab.Text = "Agregar";
            this.BAgregarHab.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BAgregarHab.UseVisualStyleBackColor = true;
            this.BAgregarHab.Click += new System.EventHandler(this.BAgregarHab_Click);
            // 
            // RBSuite
            // 
            this.RBSuite.AutoSize = true;
            this.RBSuite.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RBSuite.Location = new System.Drawing.Point(553, 83);
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
            this.PRol.Location = new System.Drawing.Point(92, 169);
            this.PRol.Margin = new System.Windows.Forms.Padding(4);
            this.PRol.Name = "PRol";
            this.PRol.Size = new System.Drawing.Size(368, 44);
            this.PRol.TabIndex = 48;
            // 
            // RBInha
            // 
            this.RBInha.AutoSize = true;
            this.RBInha.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RBInha.Location = new System.Drawing.Point(242, 11);
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
            this.RBOcup.Location = new System.Drawing.Point(125, 11);
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
            this.LEstado.Location = new System.Drawing.Point(15, 180);
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
            this.RBDoble.Location = new System.Drawing.Point(449, 83);
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
            this.RBSingle.Location = new System.Drawing.Point(339, 83);
            this.RBSingle.Margin = new System.Windows.Forms.Padding(4);
            this.RBSingle.Name = "RBSingle";
            this.RBSingle.Size = new System.Drawing.Size(66, 23);
            this.RBSingle.TabIndex = 45;
            this.RBSingle.TabStop = true;
            this.RBSingle.Text = "Single";
            this.RBSingle.UseVisualStyleBackColor = true;
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
            this.LTipo.Location = new System.Drawing.Point(262, 83);
            this.LTipo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LTipo.Name = "LTipo";
            this.LTipo.Size = new System.Drawing.Size(37, 19);
            this.LTipo.TabIndex = 42;
            this.LTipo.Text = "Tipo";
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
            // LEjemplo
            // 
            this.LEjemplo.AutoSize = true;
            this.LEjemplo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LEjemplo.Location = new System.Drawing.Point(19, 130);
            this.LEjemplo.Name = "LEjemplo";
            this.LEjemplo.Size = new System.Drawing.Size(420, 21);
            this.LEjemplo.TabIndex = 52;
            this.LEjemplo.Text = "* (ej. \"201\" es la primera habitación del segundo piso)";
            // 
            // LEstados
            // 
            this.LEstados.AutoSize = true;
            this.LEstados.Location = new System.Drawing.Point(23, 230);
            this.LEstados.Name = "LEstados";
            this.LEstados.Size = new System.Drawing.Size(63, 19);
            this.LEstados.TabIndex = 56;
            this.LEstados.Text = "Estados: ";
            // 
            // LOcupada
            // 
            this.LOcupada.AutoSize = true;
            this.LOcupada.BackColor = System.Drawing.Color.Khaki;
            this.LOcupada.Location = new System.Drawing.Point(171, 230);
            this.LOcupada.Name = "LOcupada";
            this.LOcupada.Size = new System.Drawing.Size(64, 19);
            this.LOcupada.TabIndex = 55;
            this.LOcupada.Text = "Ocupada";
            // 
            // LLibre
            // 
            this.LLibre.AutoSize = true;
            this.LLibre.BackColor = System.Drawing.Color.LightGreen;
            this.LLibre.Location = new System.Drawing.Point(105, 230);
            this.LLibre.Name = "LLibre";
            this.LLibre.Size = new System.Drawing.Size(39, 19);
            this.LLibre.TabIndex = 54;
            this.LLibre.Text = "Libre";
            // 
            // LInha
            // 
            this.LInha.AutoSize = true;
            this.LInha.BackColor = System.Drawing.Color.LightCoral;
            this.LInha.Location = new System.Drawing.Point(262, 230);
            this.LInha.Name = "LInha";
            this.LInha.Size = new System.Drawing.Size(80, 19);
            this.LInha.TabIndex = 53;
            this.LInha.Text = "Inhabilitada";
            // 
            // Habitaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(1008, 667);
            this.Controls.Add(this.LEstados);
            this.Controls.Add(this.LOcupada);
            this.Controls.Add(this.LLibre);
            this.Controls.Add(this.LInha);
            this.Controls.Add(this.LEjemplo);
            this.Controls.Add(this.RBSuite);
            this.Controls.Add(this.PRol);
            this.Controls.Add(this.LEstado);
            this.Controls.Add(this.RBDoble);
            this.Controls.Add(this.RBSingle);
            this.Controls.Add(this.TNumero);
            this.Controls.Add(this.LTipo);
            this.Controls.Add(this.LNumero);
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
        private System.Windows.Forms.Button BAgregarHab;
        private System.Windows.Forms.RadioButton RBSuite;
        private System.Windows.Forms.Panel PRol;
        private System.Windows.Forms.RadioButton RBInha;
        private System.Windows.Forms.RadioButton RBDisp;
        private System.Windows.Forms.RadioButton RBOcup;
        private System.Windows.Forms.Label LEstado;
        private System.Windows.Forms.RadioButton RBDoble;
        private System.Windows.Forms.RadioButton RBSingle;
        private System.Windows.Forms.TextBox TNumero;
        private System.Windows.Forms.Label LTipo;
        private System.Windows.Forms.Label LNumero;
        private System.Windows.Forms.DataGridViewTextBoxColumn numero_hab;
        private System.Windows.Forms.DataGridViewTextBoxColumn piso;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn capacidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn base_precio;
        private System.Windows.Forms.Label LEjemplo;
        private System.Windows.Forms.Label LEstados;
        private System.Windows.Forms.Label LOcupada;
        private System.Windows.Forms.Label LLibre;
        private System.Windows.Forms.Label LInha;
    }
}