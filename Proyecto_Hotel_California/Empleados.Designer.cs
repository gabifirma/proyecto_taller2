namespace Proyecto_Hotel_California
{
    partial class Empleados
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
            this.GrillaEmpleados = new System.Windows.Forms.DataGridView();
            this.id_empleado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Legajo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Apellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewButtonColumn();
            this.LTituloEmp = new System.Windows.Forms.Label();
            this.BAgregarEmp = new System.Windows.Forms.Button();
            this.BEditarEmp = new System.Windows.Forms.Button();
            this.BEliminarEmp = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaEmpleados)).BeginInit();
            this.SuspendLayout();
            // 
            // GrillaEmpleados
            // 
            this.GrillaEmpleados.AllowUserToAddRows = false;
            this.GrillaEmpleados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GrillaEmpleados.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GrillaEmpleados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrillaEmpleados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_empleado,
            this.Legajo,
            this.Apellido,
            this.Nombre,
            this.Telefono,
            this.Email,
            this.Estado});
            this.GrillaEmpleados.EnableHeadersVisualStyles = false;
            this.GrillaEmpleados.Location = new System.Drawing.Point(12, 173);
            this.GrillaEmpleados.Name = "GrillaEmpleados";
            this.GrillaEmpleados.RowHeadersVisible = false;
            this.GrillaEmpleados.Size = new System.Drawing.Size(710, 150);
            this.GrillaEmpleados.TabIndex = 0;
            // 
            // id_empleado
            // 
            this.id_empleado.HeaderText = "ID Empleado";
            this.id_empleado.Name = "id_empleado";
            // 
            // Legajo
            // 
            this.Legajo.HeaderText = "Legajo";
            this.Legajo.Name = "Legajo";
            // 
            // Apellido
            // 
            this.Apellido.HeaderText = "Apellido";
            this.Apellido.Name = "Apellido";
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            // 
            // Telefono
            // 
            this.Telefono.HeaderText = "Teléfono";
            this.Telefono.Name = "Telefono";
            // 
            // Email
            // 
            this.Email.HeaderText = "Email";
            this.Email.Name = "Email";
            // 
            // Estado
            // 
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Estado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Estado.Text = "Activar/Desactivar";
            this.Estado.ToolTipText = "Estado";
            this.Estado.UseColumnTextForButtonValue = true;
            // 
            // LTituloEmp
            // 
            this.LTituloEmp.AutoSize = true;
            this.LTituloEmp.Font = new System.Drawing.Font("Times New Roman", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTituloEmp.Location = new System.Drawing.Point(253, 30);
            this.LTituloEmp.Name = "LTituloEmp";
            this.LTituloEmp.Size = new System.Drawing.Size(215, 28);
            this.LTituloEmp.TabIndex = 1;
            this.LTituloEmp.Text = "Grilla de Empleados";
            // 
            // BAgregarEmp
            // 
            this.BAgregarEmp.Location = new System.Drawing.Point(12, 116);
            this.BAgregarEmp.Name = "BAgregarEmp";
            this.BAgregarEmp.Size = new System.Drawing.Size(95, 40);
            this.BAgregarEmp.TabIndex = 2;
            this.BAgregarEmp.Text = "Agregar";
            this.BAgregarEmp.UseVisualStyleBackColor = true;
            this.BAgregarEmp.Click += new System.EventHandler(this.BAgregarEmp_Click);
            // 
            // BEditarEmp
            // 
            this.BEditarEmp.Location = new System.Drawing.Point(113, 116);
            this.BEditarEmp.Name = "BEditarEmp";
            this.BEditarEmp.Size = new System.Drawing.Size(95, 40);
            this.BEditarEmp.TabIndex = 3;
            this.BEditarEmp.Text = "Editar";
            this.BEditarEmp.UseVisualStyleBackColor = true;
            this.BEditarEmp.Click += new System.EventHandler(this.BEditarEmp_Click);
            // 
            // BEliminarEmp
            // 
            this.BEliminarEmp.Location = new System.Drawing.Point(214, 116);
            this.BEliminarEmp.Name = "BEliminarEmp";
            this.BEliminarEmp.Size = new System.Drawing.Size(95, 40);
            this.BEliminarEmp.TabIndex = 4;
            this.BEliminarEmp.Text = "Eliminar";
            this.BEliminarEmp.UseVisualStyleBackColor = true;
            this.BEliminarEmp.Click += new System.EventHandler(this.BEliminarEmp_Click);
            // 
            // Empleados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(734, 511);
            this.Controls.Add(this.BEliminarEmp);
            this.Controls.Add(this.BEditarEmp);
            this.Controls.Add(this.BAgregarEmp);
            this.Controls.Add(this.LTituloEmp);
            this.Controls.Add(this.GrillaEmpleados);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Empleados";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.GrillaEmpleados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView GrillaEmpleados;
        private System.Windows.Forms.Label LTituloEmp;
        private System.Windows.Forms.Button BAgregarEmp;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_empleado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Legajo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Apellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewButtonColumn Estado;
        private System.Windows.Forms.Button BEditarEmp;
        private System.Windows.Forms.Button BEliminarEmp;
    }
}