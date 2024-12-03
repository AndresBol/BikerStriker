namespace BikerStriker.Layers.UI.Mantenimientos
{
    partial class frmMantenimientoTienda
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
            this.dgvTiendas = new System.Windows.Forms.DataGridView();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.pnlBotom = new System.Windows.Forms.Panel();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.lblCedulaJuridica = new System.Windows.Forms.Label();
            this.txtCedulaJuridica = new System.Windows.Forms.TextBox();
            this.lblImpuestoVenta = new System.Windows.Forms.Label();
            this.nudImpuestoVenta = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTiendas)).BeginInit();
            this.pnlBotom.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudImpuestoVenta)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTiendas
            // 
            this.dgvTiendas.AllowUserToAddRows = false;
            this.dgvTiendas.AllowUserToDeleteRows = false;
            this.dgvTiendas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvTiendas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTiendas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTiendas.Location = new System.Drawing.Point(0, 0);
            this.dgvTiendas.MultiSelect = false;
            this.dgvTiendas.Name = "dgvTiendas";
            this.dgvTiendas.ReadOnly = true;
            this.dgvTiendas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTiendas.Size = new System.Drawing.Size(800, 470);
            this.dgvTiendas.TabIndex = 0;
            this.dgvTiendas.SelectionChanged += new System.EventHandler(this.dgvTiendas_SelectionChanged);
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtitulo.Location = new System.Drawing.Point(10, 0);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(205, 26);
            this.lblSubtitulo.TabIndex = 1;
            this.lblSubtitulo.Text = "Tienda seleccionada";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(12, 69);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(44, 13);
            this.lblNombre.TabIndex = 2;
            this.lblNombre.Text = "Nombre";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(140, 66);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(258, 20);
            this.txtNombre.TabIndex = 4;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(170)))), ((int)(((byte)(27)))));
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(245, 129);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(88, 47);
            this.btnGuardar.TabIndex = 6;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(37)))));
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Location = new System.Drawing.Point(156, 129);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(83, 47);
            this.btnEliminar.TabIndex = 7;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(138)))), ((int)(((byte)(195)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(12, 129);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(88, 47);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "Añadir Tienda";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // pnlBotom
            // 
            this.pnlBotom.Controls.Add(this.pnlRight);
            this.pnlBotom.Controls.Add(this.pnlLeft);
            this.pnlBotom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotom.Location = new System.Drawing.Point(0, 282);
            this.pnlBotom.Name = "pnlBotom";
            this.pnlBotom.Size = new System.Drawing.Size(800, 188);
            this.pnlBotom.TabIndex = 13;
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.lblDireccion);
            this.pnlRight.Controls.Add(this.txtDireccion);
            this.pnlRight.Controls.Add(this.lblTelefono);
            this.pnlRight.Controls.Add(this.btnGuardar);
            this.pnlRight.Controls.Add(this.txtTelefono);
            this.pnlRight.Controls.Add(this.btnEliminar);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRight.Location = new System.Drawing.Point(455, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(345, 188);
            this.pnlRight.TabIndex = 1;
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Location = new System.Drawing.Point(13, 72);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(52, 13);
            this.lblDireccion.TabIndex = 15;
            this.lblDireccion.Text = "Dirección";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(82, 69);
            this.txtDireccion.Multiline = true;
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDireccion.Size = new System.Drawing.Size(251, 43);
            this.txtDireccion.TabIndex = 16;
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Location = new System.Drawing.Point(13, 43);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(49, 13);
            this.lblTelefono.TabIndex = 13;
            this.lblTelefono.Text = "Telefono";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(82, 40);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(251, 20);
            this.txtTelefono.TabIndex = 14;
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.nudImpuestoVenta);
            this.pnlLeft.Controls.Add(this.lblImpuestoVenta);
            this.pnlLeft.Controls.Add(this.lblCedulaJuridica);
            this.pnlLeft.Controls.Add(this.txtCedulaJuridica);
            this.pnlLeft.Controls.Add(this.btnAdd);
            this.pnlLeft.Controls.Add(this.lblSubtitulo);
            this.pnlLeft.Controls.Add(this.lblNombre);
            this.pnlLeft.Controls.Add(this.txtNombre);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(398, 188);
            this.pnlLeft.TabIndex = 0;
            // 
            // lblCedulaJuridica
            // 
            this.lblCedulaJuridica.AutoSize = true;
            this.lblCedulaJuridica.Location = new System.Drawing.Point(12, 43);
            this.lblCedulaJuridica.Name = "lblCedulaJuridica";
            this.lblCedulaJuridica.Size = new System.Drawing.Size(79, 13);
            this.lblCedulaJuridica.TabIndex = 11;
            this.lblCedulaJuridica.Text = "Cedula Juridica";
            // 
            // txtCedulaJuridica
            // 
            this.txtCedulaJuridica.Location = new System.Drawing.Point(140, 40);
            this.txtCedulaJuridica.Name = "txtCedulaJuridica";
            this.txtCedulaJuridica.Size = new System.Drawing.Size(258, 20);
            this.txtCedulaJuridica.TabIndex = 12;
            // 
            // lblImpuestoVenta
            // 
            this.lblImpuestoVenta.AutoSize = true;
            this.lblImpuestoVenta.Location = new System.Drawing.Point(12, 94);
            this.lblImpuestoVenta.Name = "lblImpuestoVenta";
            this.lblImpuestoVenta.Size = new System.Drawing.Size(106, 13);
            this.lblImpuestoVenta.TabIndex = 13;
            this.lblImpuestoVenta.Text = "Impuesto de venta %";
            // 
            // nudImpuestoVenta
            // 
            this.nudImpuestoVenta.DecimalPlaces = 2;
            this.nudImpuestoVenta.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nudImpuestoVenta.Location = new System.Drawing.Point(140, 92);
            this.nudImpuestoVenta.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudImpuestoVenta.Name = "nudImpuestoVenta";
            this.nudImpuestoVenta.Size = new System.Drawing.Size(255, 20);
            this.nudImpuestoVenta.TabIndex = 14;
            this.nudImpuestoVenta.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // frmMantenimientoTienda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 470);
            this.Controls.Add(this.pnlBotom);
            this.Controls.Add(this.dgvTiendas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMantenimientoTienda";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento de Tiendas";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTiendas)).EndInit();
            this.pnlBotom.ResumeLayout(false);
            this.pnlRight.ResumeLayout(false);
            this.pnlRight.PerformLayout();
            this.pnlLeft.ResumeLayout(false);
            this.pnlLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudImpuestoVenta)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTiendas;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Panel pnlBotom;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Label lblCedulaJuridica;
        private System.Windows.Forms.TextBox txtCedulaJuridica;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.NumericUpDown nudImpuestoVenta;
        private System.Windows.Forms.Label lblImpuestoVenta;
    }
}