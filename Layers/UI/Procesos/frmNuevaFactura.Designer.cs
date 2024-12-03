namespace BikerStriker.Layers.UI.Procesos
{
    partial class frmNuevaFactura
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
            this.pnlCampos = new System.Windows.Forms.Panel();
            this.imgLogoWhite = new System.Windows.Forms.PictureBox();
            this.pnlCamposDer = new System.Windows.Forms.Panel();
            this.cmbTarjeta = new System.Windows.Forms.ComboBox();
            this.lblTarjeta = new System.Windows.Forms.Label();
            this.pnlCamposIzq = new System.Windows.Forms.Panel();
            this.cmbCliente = new System.Windows.Forms.ComboBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.pnlDetalle = new System.Windows.Forms.Panel();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.nudCantidad = new System.Windows.Forms.NumericUpDown();
            this.pnlDetalleDer = new System.Windows.Forms.Panel();
            this.btnEliminarDetalle = new System.Windows.Forms.Button();
            this.dgvFacturaDetalle = new System.Windows.Forms.DataGridView();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.pnlCamposDetalle = new System.Windows.Forms.Panel();
            this.cmbCategoria = new System.Windows.Forms.ComboBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.cmbProducto = new System.Windows.Forms.ComboBox();
            this.lblProducto = new System.Windows.Forms.Label();
            this.pnlFacturaDown = new System.Windows.Forms.Panel();
            this.lblPrecioTotal = new System.Windows.Forms.Label();
            this.pnlFacturaBD = new System.Windows.Forms.Panel();
            this.lblOrdenTrabajo = new System.Windows.Forms.Label();
            this.cmbOrdenTrabajo = new System.Windows.Forms.ComboBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.pnlCampos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgLogoWhite)).BeginInit();
            this.pnlCamposDer.SuspendLayout();
            this.pnlCamposIzq.SuspendLayout();
            this.pnlDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).BeginInit();
            this.pnlDetalleDer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturaDetalle)).BeginInit();
            this.pnlCamposDetalle.SuspendLayout();
            this.pnlFacturaDown.SuspendLayout();
            this.pnlFacturaBD.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCampos
            // 
            this.pnlCampos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlCampos.Controls.Add(this.imgLogoWhite);
            this.pnlCampos.Controls.Add(this.pnlCamposDer);
            this.pnlCampos.Controls.Add(this.pnlCamposIzq);
            this.pnlCampos.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCampos.Location = new System.Drawing.Point(0, 0);
            this.pnlCampos.Name = "pnlCampos";
            this.pnlCampos.Size = new System.Drawing.Size(800, 97);
            this.pnlCampos.TabIndex = 19;
            // 
            // imgLogoWhite
            // 
            this.imgLogoWhite.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imgLogoWhite.Image = global::BikerStriker.Properties.Resources.Logo_whiterounded;
            this.imgLogoWhite.Location = new System.Drawing.Point(289, 0);
            this.imgLogoWhite.Name = "imgLogoWhite";
            this.imgLogoWhite.Size = new System.Drawing.Size(210, 93);
            this.imgLogoWhite.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgLogoWhite.TabIndex = 21;
            this.imgLogoWhite.TabStop = false;
            // 
            // pnlCamposDer
            // 
            this.pnlCamposDer.Controls.Add(this.cmbTarjeta);
            this.pnlCamposDer.Controls.Add(this.lblTarjeta);
            this.pnlCamposDer.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlCamposDer.Location = new System.Drawing.Point(499, 0);
            this.pnlCamposDer.Name = "pnlCamposDer";
            this.pnlCamposDer.Size = new System.Drawing.Size(297, 93);
            this.pnlCamposDer.TabIndex = 20;
            // 
            // cmbTarjeta
            // 
            this.cmbTarjeta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTarjeta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.cmbTarjeta.FormattingEnabled = true;
            this.cmbTarjeta.Location = new System.Drawing.Point(57, 44);
            this.cmbTarjeta.Name = "cmbTarjeta";
            this.cmbTarjeta.Size = new System.Drawing.Size(230, 24);
            this.cmbTarjeta.TabIndex = 21;
            // 
            // lblTarjeta
            // 
            this.lblTarjeta.AutoSize = true;
            this.lblTarjeta.Font = new System.Drawing.Font("Myanmar Text", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTarjeta.Location = new System.Drawing.Point(84, 7);
            this.lblTarjeta.Name = "lblTarjeta";
            this.lblTarjeta.Size = new System.Drawing.Size(201, 34);
            this.lblTarjeta.TabIndex = 20;
            this.lblTarjeta.Text = "Seleccione una tarjeta";
            // 
            // pnlCamposIzq
            // 
            this.pnlCamposIzq.Controls.Add(this.cmbCliente);
            this.pnlCamposIzq.Controls.Add(this.lblCliente);
            this.pnlCamposIzq.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlCamposIzq.Location = new System.Drawing.Point(0, 0);
            this.pnlCamposIzq.Name = "pnlCamposIzq";
            this.pnlCamposIzq.Size = new System.Drawing.Size(289, 93);
            this.pnlCamposIzq.TabIndex = 19;
            // 
            // cmbCliente
            // 
            this.cmbCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.cmbCliente.FormattingEnabled = true;
            this.cmbCliente.Location = new System.Drawing.Point(9, 44);
            this.cmbCliente.Name = "cmbCliente";
            this.cmbCliente.Size = new System.Drawing.Size(224, 24);
            this.cmbCliente.TabIndex = 19;
            this.cmbCliente.SelectedIndexChanged += new System.EventHandler(this.cmbCliente_SelectedIndexChanged);
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Font = new System.Drawing.Font("Myanmar Text", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCliente.Location = new System.Drawing.Point(4, 7);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(193, 34);
            this.lblCliente.TabIndex = 18;
            this.lblCliente.Text = "Seleccione un cliente";
            // 
            // pnlDetalle
            // 
            this.pnlDetalle.Controls.Add(this.lblCantidad);
            this.pnlDetalle.Controls.Add(this.nudCantidad);
            this.pnlDetalle.Controls.Add(this.pnlDetalleDer);
            this.pnlDetalle.Controls.Add(this.lblPrecio);
            this.pnlDetalle.Controls.Add(this.lblNombre);
            this.pnlDetalle.Controls.Add(this.txtNombre);
            this.pnlDetalle.Controls.Add(this.lblCodigo);
            this.pnlDetalle.Controls.Add(this.txtCodigo);
            this.pnlDetalle.Controls.Add(this.lblDescripcion);
            this.pnlDetalle.Controls.Add(this.txtDescripcion);
            this.pnlDetalle.Controls.Add(this.pnlCamposDetalle);
            this.pnlDetalle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDetalle.Location = new System.Drawing.Point(0, 97);
            this.pnlDetalle.Name = "pnlDetalle";
            this.pnlDetalle.Size = new System.Drawing.Size(800, 275);
            this.pnlDetalle.TabIndex = 20;
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Location = new System.Drawing.Point(12, 251);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(49, 13);
            this.lblCantidad.TabIndex = 24;
            this.lblCantidad.Text = "Cantidad";
            // 
            // nudCantidad
            // 
            this.nudCantidad.Location = new System.Drawing.Point(108, 244);
            this.nudCantidad.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.nudCantidad.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCantidad.Name = "nudCantidad";
            this.nudCantidad.Size = new System.Drawing.Size(236, 20);
            this.nudCantidad.TabIndex = 23;
            this.nudCantidad.ThousandsSeparator = true;
            this.nudCantidad.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCantidad.ValueChanged += new System.EventHandler(this.nudCantidad_ValueChanged);
            // 
            // pnlDetalleDer
            // 
            this.pnlDetalleDer.Controls.Add(this.btnEliminarDetalle);
            this.pnlDetalleDer.Controls.Add(this.dgvFacturaDetalle);
            this.pnlDetalleDer.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlDetalleDer.Location = new System.Drawing.Point(415, 66);
            this.pnlDetalleDer.Name = "pnlDetalleDer";
            this.pnlDetalleDer.Padding = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.pnlDetalleDer.Size = new System.Drawing.Size(385, 209);
            this.pnlDetalleDer.TabIndex = 22;
            // 
            // btnEliminarDetalle
            // 
            this.btnEliminarDetalle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(37)))));
            this.btnEliminarDetalle.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnEliminarDetalle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarDetalle.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarDetalle.ForeColor = System.Drawing.Color.White;
            this.btnEliminarDetalle.Location = new System.Drawing.Point(12, 178);
            this.btnEliminarDetalle.Name = "btnEliminarDetalle";
            this.btnEliminarDetalle.Size = new System.Drawing.Size(361, 31);
            this.btnEliminarDetalle.TabIndex = 8;
            this.btnEliminarDetalle.Text = "Eliminar";
            this.btnEliminarDetalle.UseVisualStyleBackColor = false;
            this.btnEliminarDetalle.Click += new System.EventHandler(this.btnEliminarDetalle_Click);
            // 
            // dgvFacturaDetalle
            // 
            this.dgvFacturaDetalle.AllowUserToAddRows = false;
            this.dgvFacturaDetalle.AllowUserToDeleteRows = false;
            this.dgvFacturaDetalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvFacturaDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFacturaDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFacturaDetalle.Location = new System.Drawing.Point(12, 0);
            this.dgvFacturaDetalle.MultiSelect = false;
            this.dgvFacturaDetalle.Name = "dgvFacturaDetalle";
            this.dgvFacturaDetalle.ReadOnly = true;
            this.dgvFacturaDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFacturaDetalle.Size = new System.Drawing.Size(361, 209);
            this.dgvFacturaDetalle.TabIndex = 1;
            this.dgvFacturaDetalle.Click += new System.EventHandler(this.dgvOrdenDetalle_Click);
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecio.Location = new System.Drawing.Point(350, 75);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(59, 20);
            this.lblPrecio.TabIndex = 21;
            this.lblPrecio.Text = "Precio";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(12, 101);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(44, 13);
            this.lblNombre.TabIndex = 19;
            this.lblNombre.Text = "Nombre";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(108, 98);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.ReadOnly = true;
            this.txtNombre.Size = new System.Drawing.Size(236, 20);
            this.txtNombre.TabIndex = 20;
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(12, 75);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(40, 13);
            this.lblCodigo.TabIndex = 17;
            this.lblCodigo.Text = "Codigo";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(108, 72);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.ReadOnly = true;
            this.txtCodigo.Size = new System.Drawing.Size(236, 20);
            this.txtCodigo.TabIndex = 18;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(12, 127);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(63, 13);
            this.lblDescripcion.TabIndex = 15;
            this.lblDescripcion.Text = "Descripción";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(108, 124);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.ReadOnly = true;
            this.txtDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescripcion.Size = new System.Drawing.Size(236, 87);
            this.txtDescripcion.TabIndex = 16;
            // 
            // pnlCamposDetalle
            // 
            this.pnlCamposDetalle.Controls.Add(this.cmbCategoria);
            this.pnlCamposDetalle.Controls.Add(this.btnAgregar);
            this.pnlCamposDetalle.Controls.Add(this.cmbProducto);
            this.pnlCamposDetalle.Controls.Add(this.lblProducto);
            this.pnlCamposDetalle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCamposDetalle.Location = new System.Drawing.Point(0, 0);
            this.pnlCamposDetalle.Name = "pnlCamposDetalle";
            this.pnlCamposDetalle.Padding = new System.Windows.Forms.Padding(0, 6, 12, 6);
            this.pnlCamposDetalle.Size = new System.Drawing.Size(800, 66);
            this.pnlCamposDetalle.TabIndex = 0;
            // 
            // cmbCategoria
            // 
            this.cmbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.Location = new System.Drawing.Point(225, 23);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(143, 24);
            this.cmbCategoria.TabIndex = 22;
            this.cmbCategoria.SelectedIndexChanged += new System.EventHandler(this.cmbCategoria_SelectedIndexChanged);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.Location = new System.Drawing.Point(558, 6);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(3, 3, 22, 3);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(230, 54);
            this.btnAgregar.TabIndex = 21;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // cmbProducto
            // 
            this.cmbProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.cmbProducto.FormattingEnabled = true;
            this.cmbProducto.Location = new System.Drawing.Point(374, 23);
            this.cmbProducto.Name = "cmbProducto";
            this.cmbProducto.Size = new System.Drawing.Size(178, 24);
            this.cmbProducto.TabIndex = 20;
            // 
            // lblProducto
            // 
            this.lblProducto.AutoSize = true;
            this.lblProducto.Font = new System.Drawing.Font("Myanmar Text", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProducto.Location = new System.Drawing.Point(5, 19);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(214, 34);
            this.lblProducto.TabIndex = 19;
            this.lblProducto.Text = "Seleccione un producto";
            // 
            // pnlFacturaDown
            // 
            this.pnlFacturaDown.Controls.Add(this.lblPrecioTotal);
            this.pnlFacturaDown.Controls.Add(this.pnlFacturaBD);
            this.pnlFacturaDown.Controls.Add(this.btnGuardar);
            this.pnlFacturaDown.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFacturaDown.Location = new System.Drawing.Point(0, 395);
            this.pnlFacturaDown.Name = "pnlFacturaDown";
            this.pnlFacturaDown.Size = new System.Drawing.Size(800, 86);
            this.pnlFacturaDown.TabIndex = 23;
            // 
            // lblPrecioTotal
            // 
            this.lblPrecioTotal.AutoSize = true;
            this.lblPrecioTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecioTotal.Location = new System.Drawing.Point(187, 10);
            this.lblPrecioTotal.Name = "lblPrecioTotal";
            this.lblPrecioTotal.Size = new System.Drawing.Size(104, 20);
            this.lblPrecioTotal.TabIndex = 25;
            this.lblPrecioTotal.Text = "Precio Total";
            // 
            // pnlFacturaBD
            // 
            this.pnlFacturaBD.Controls.Add(this.lblOrdenTrabajo);
            this.pnlFacturaBD.Controls.Add(this.cmbOrdenTrabajo);
            this.pnlFacturaBD.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlFacturaBD.Location = new System.Drawing.Point(0, 0);
            this.pnlFacturaBD.Name = "pnlFacturaBD";
            this.pnlFacturaBD.Size = new System.Drawing.Size(176, 86);
            this.pnlFacturaBD.TabIndex = 24;
            // 
            // lblOrdenTrabajo
            // 
            this.lblOrdenTrabajo.AutoSize = true;
            this.lblOrdenTrabajo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrdenTrabajo.Location = new System.Drawing.Point(8, 10);
            this.lblOrdenTrabajo.Name = "lblOrdenTrabajo";
            this.lblOrdenTrabajo.Size = new System.Drawing.Size(148, 20);
            this.lblOrdenTrabajo.TabIndex = 25;
            this.lblOrdenTrabajo.Text = "Orden de Trabajo";
            // 
            // cmbOrdenTrabajo
            // 
            this.cmbOrdenTrabajo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOrdenTrabajo.FormattingEnabled = true;
            this.cmbOrdenTrabajo.Location = new System.Drawing.Point(12, 33);
            this.cmbOrdenTrabajo.Name = "cmbOrdenTrabajo";
            this.cmbOrdenTrabajo.Size = new System.Drawing.Size(144, 21);
            this.cmbOrdenTrabajo.TabIndex = 23;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(170)))), ((int)(((byte)(27)))));
            this.btnGuardar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(652, 0);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(148, 86);
            this.btnGuardar.TabIndex = 7;
            this.btnGuardar.Text = "Guardar Factura";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // frmNuevaFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 481);
            this.Controls.Add(this.pnlFacturaDown);
            this.Controls.Add(this.pnlDetalle);
            this.Controls.Add(this.pnlCampos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmNuevaFactura";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Crear Factura";
            this.pnlCampos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgLogoWhite)).EndInit();
            this.pnlCamposDer.ResumeLayout(false);
            this.pnlCamposDer.PerformLayout();
            this.pnlCamposIzq.ResumeLayout(false);
            this.pnlCamposIzq.PerformLayout();
            this.pnlDetalle.ResumeLayout(false);
            this.pnlDetalle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).EndInit();
            this.pnlDetalleDer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturaDetalle)).EndInit();
            this.pnlCamposDetalle.ResumeLayout(false);
            this.pnlCamposDetalle.PerformLayout();
            this.pnlFacturaDown.ResumeLayout(false);
            this.pnlFacturaDown.PerformLayout();
            this.pnlFacturaBD.ResumeLayout(false);
            this.pnlFacturaBD.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlCampos;
        private System.Windows.Forms.Panel pnlCamposIzq;
        private System.Windows.Forms.Panel pnlCamposDer;
        private System.Windows.Forms.PictureBox imgLogoWhite;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.ComboBox cmbCliente;
        private System.Windows.Forms.ComboBox cmbTarjeta;
        private System.Windows.Forms.Label lblTarjeta;
        private System.Windows.Forms.Panel pnlDetalle;
        private System.Windows.Forms.Panel pnlCamposDetalle;
        private System.Windows.Forms.Label lblProducto;
        private System.Windows.Forms.ComboBox cmbProducto;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.DataGridView dgvFacturaDetalle;
        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.Button btnEliminarDetalle;
        private System.Windows.Forms.Panel pnlDetalleDer;
        private System.Windows.Forms.Panel pnlFacturaDown;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.NumericUpDown nudCantidad;
        private System.Windows.Forms.ComboBox cmbOrdenTrabajo;
        private System.Windows.Forms.Panel pnlFacturaBD;
        private System.Windows.Forms.Label lblOrdenTrabajo;
        private System.Windows.Forms.Label lblPrecioTotal;
        private System.Windows.Forms.Label lblCantidad;
    }
}