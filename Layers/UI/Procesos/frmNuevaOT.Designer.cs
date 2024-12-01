namespace BikerStriker.Layers.UI.Procesos
{
    partial class frmNuevaOT
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNuevaOT));
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaFinalizacion = new System.Windows.Forms.DateTimePicker();
            this.lblFechaInicio = new System.Windows.Forms.Label();
            this.lblFechaFinal = new System.Windows.Forms.Label();
            this.pnlCampos = new System.Windows.Forms.Panel();
            this.imgLogoWhite = new System.Windows.Forms.PictureBox();
            this.pnlCamposDer = new System.Windows.Forms.Panel();
            this.cmbBicicleta = new System.Windows.Forms.ComboBox();
            this.lblBicicleta = new System.Windows.Forms.Label();
            this.pnlCamposIzq = new System.Windows.Forms.Panel();
            this.cmbCliente = new System.Windows.Forms.ComboBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.pnlDetalle = new System.Windows.Forms.Panel();
            this.pnlDetalleDer = new System.Windows.Forms.Panel();
            this.btnEliminarDetalle = new System.Windows.Forms.Button();
            this.dgvOrdenDetalle = new System.Windows.Forms.DataGridView();
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
            this.cmbServicio = new System.Windows.Forms.ComboBox();
            this.lblServicio = new System.Windows.Forms.Label();
            this.pnlFotos = new System.Windows.Forms.Panel();
            this.imgFoto = new System.Windows.Forms.PictureBox();
            this.pnlFotosIzq = new System.Windows.Forms.Panel();
            this.dgvFotos = new System.Windows.Forms.DataGridView();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.pnlFotosBottom = new System.Windows.Forms.Panel();
            this.btnEliminarFoto = new System.Windows.Forms.Button();
            this.pnlOrdenDown = new System.Windows.Forms.Panel();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.pnlCampos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgLogoWhite)).BeginInit();
            this.pnlCamposDer.SuspendLayout();
            this.pnlCamposIzq.SuspendLayout();
            this.pnlDetalle.SuspendLayout();
            this.pnlDetalleDer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenDetalle)).BeginInit();
            this.pnlCamposDetalle.SuspendLayout();
            this.pnlFotos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoto)).BeginInit();
            this.pnlFotosIzq.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFotos)).BeginInit();
            this.pnlFotosBottom.SuspendLayout();
            this.pnlOrdenDown.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaInicio.Location = new System.Drawing.Point(9, 46);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(224, 20);
            this.dtpFechaInicio.TabIndex = 15;
            // 
            // dtpFechaFinalizacion
            // 
            this.dtpFechaFinalizacion.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.dtpFechaFinalizacion.Location = new System.Drawing.Point(55, 46);
            this.dtpFechaFinalizacion.Name = "dtpFechaFinalizacion";
            this.dtpFechaFinalizacion.Size = new System.Drawing.Size(230, 20);
            this.dtpFechaFinalizacion.TabIndex = 16;
            // 
            // lblFechaInicio
            // 
            this.lblFechaInicio.AutoSize = true;
            this.lblFechaInicio.Font = new System.Drawing.Font("Myanmar Text", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaInicio.Location = new System.Drawing.Point(3, 9);
            this.lblFechaInicio.Name = "lblFechaInicio";
            this.lblFechaInicio.Size = new System.Drawing.Size(115, 34);
            this.lblFechaInicio.TabIndex = 17;
            this.lblFechaInicio.Text = "Fecha Inicio";
            // 
            // lblFechaFinal
            // 
            this.lblFechaFinal.AutoSize = true;
            this.lblFechaFinal.Font = new System.Drawing.Font("Myanmar Text", 14.25F);
            this.lblFechaFinal.Location = new System.Drawing.Point(102, 9);
            this.lblFechaFinal.Name = "lblFechaFinal";
            this.lblFechaFinal.Size = new System.Drawing.Size(192, 34);
            this.lblFechaFinal.TabIndex = 18;
            this.lblFechaFinal.Text = "Fecha de finalización";
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
            this.pnlCampos.Size = new System.Drawing.Size(800, 172);
            this.pnlCampos.TabIndex = 19;
            // 
            // imgLogoWhite
            // 
            this.imgLogoWhite.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imgLogoWhite.Image = global::BikerStriker.Properties.Resources.Logo_whiterounded;
            this.imgLogoWhite.Location = new System.Drawing.Point(289, 0);
            this.imgLogoWhite.Name = "imgLogoWhite";
            this.imgLogoWhite.Size = new System.Drawing.Size(210, 168);
            this.imgLogoWhite.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgLogoWhite.TabIndex = 21;
            this.imgLogoWhite.TabStop = false;
            // 
            // pnlCamposDer
            // 
            this.pnlCamposDer.Controls.Add(this.cmbBicicleta);
            this.pnlCamposDer.Controls.Add(this.lblFechaFinal);
            this.pnlCamposDer.Controls.Add(this.lblBicicleta);
            this.pnlCamposDer.Controls.Add(this.dtpFechaFinalizacion);
            this.pnlCamposDer.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlCamposDer.Location = new System.Drawing.Point(499, 0);
            this.pnlCamposDer.Name = "pnlCamposDer";
            this.pnlCamposDer.Size = new System.Drawing.Size(297, 168);
            this.pnlCamposDer.TabIndex = 20;
            // 
            // cmbBicicleta
            // 
            this.cmbBicicleta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBicicleta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.cmbBicicleta.FormattingEnabled = true;
            this.cmbBicicleta.Location = new System.Drawing.Point(55, 118);
            this.cmbBicicleta.Name = "cmbBicicleta";
            this.cmbBicicleta.Size = new System.Drawing.Size(230, 24);
            this.cmbBicicleta.TabIndex = 21;
            // 
            // lblBicicleta
            // 
            this.lblBicicleta.AutoSize = true;
            this.lblBicicleta.Font = new System.Drawing.Font("Myanmar Text", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBicicleta.Location = new System.Drawing.Point(68, 81);
            this.lblBicicleta.Name = "lblBicicleta";
            this.lblBicicleta.Size = new System.Drawing.Size(217, 34);
            this.lblBicicleta.TabIndex = 20;
            this.lblBicicleta.Text = "Seleccione una bicicleta";
            // 
            // pnlCamposIzq
            // 
            this.pnlCamposIzq.Controls.Add(this.cmbCliente);
            this.pnlCamposIzq.Controls.Add(this.lblCliente);
            this.pnlCamposIzq.Controls.Add(this.lblFechaInicio);
            this.pnlCamposIzq.Controls.Add(this.dtpFechaInicio);
            this.pnlCamposIzq.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlCamposIzq.Location = new System.Drawing.Point(0, 0);
            this.pnlCamposIzq.Name = "pnlCamposIzq";
            this.pnlCamposIzq.Size = new System.Drawing.Size(289, 168);
            this.pnlCamposIzq.TabIndex = 19;
            // 
            // cmbCliente
            // 
            this.cmbCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.cmbCliente.FormattingEnabled = true;
            this.cmbCliente.Location = new System.Drawing.Point(9, 118);
            this.cmbCliente.Name = "cmbCliente";
            this.cmbCliente.Size = new System.Drawing.Size(224, 24);
            this.cmbCliente.TabIndex = 19;
            this.cmbCliente.SelectedIndexChanged += new System.EventHandler(this.cmbCliente_SelectedIndexChanged);
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Font = new System.Drawing.Font("Myanmar Text", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCliente.Location = new System.Drawing.Point(3, 81);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(193, 34);
            this.lblCliente.TabIndex = 18;
            this.lblCliente.Text = "Seleccione un cliente";
            // 
            // pnlDetalle
            // 
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
            this.pnlDetalle.Location = new System.Drawing.Point(0, 172);
            this.pnlDetalle.Name = "pnlDetalle";
            this.pnlDetalle.Size = new System.Drawing.Size(800, 209);
            this.pnlDetalle.TabIndex = 20;
            // 
            // pnlDetalleDer
            // 
            this.pnlDetalleDer.Controls.Add(this.btnEliminarDetalle);
            this.pnlDetalleDer.Controls.Add(this.dgvOrdenDetalle);
            this.pnlDetalleDer.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlDetalleDer.Location = new System.Drawing.Point(415, 67);
            this.pnlDetalleDer.Name = "pnlDetalleDer";
            this.pnlDetalleDer.Padding = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.pnlDetalleDer.Size = new System.Drawing.Size(385, 142);
            this.pnlDetalleDer.TabIndex = 22;
            // 
            // btnEliminarDetalle
            // 
            this.btnEliminarDetalle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(37)))));
            this.btnEliminarDetalle.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnEliminarDetalle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarDetalle.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarDetalle.ForeColor = System.Drawing.Color.White;
            this.btnEliminarDetalle.Location = new System.Drawing.Point(12, 111);
            this.btnEliminarDetalle.Name = "btnEliminarDetalle";
            this.btnEliminarDetalle.Size = new System.Drawing.Size(361, 31);
            this.btnEliminarDetalle.TabIndex = 8;
            this.btnEliminarDetalle.Text = "Eliminar";
            this.btnEliminarDetalle.UseVisualStyleBackColor = false;
            this.btnEliminarDetalle.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // dgvOrdenDetalle
            // 
            this.dgvOrdenDetalle.AllowUserToAddRows = false;
            this.dgvOrdenDetalle.AllowUserToDeleteRows = false;
            this.dgvOrdenDetalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvOrdenDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrdenDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOrdenDetalle.Location = new System.Drawing.Point(12, 0);
            this.dgvOrdenDetalle.MultiSelect = false;
            this.dgvOrdenDetalle.Name = "dgvOrdenDetalle";
            this.dgvOrdenDetalle.ReadOnly = true;
            this.dgvOrdenDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrdenDetalle.Size = new System.Drawing.Size(361, 142);
            this.dgvOrdenDetalle.TabIndex = 1;
            this.dgvOrdenDetalle.Click += new System.EventHandler(this.dgvOrdenDetalle_Click);
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecio.Location = new System.Drawing.Point(350, 70);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(59, 20);
            this.lblPrecio.TabIndex = 21;
            this.lblPrecio.Text = "Precio";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(12, 96);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(44, 13);
            this.lblNombre.TabIndex = 19;
            this.lblNombre.Text = "Nombre";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(108, 93);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.ReadOnly = true;
            this.txtNombre.Size = new System.Drawing.Size(236, 20);
            this.txtNombre.TabIndex = 20;
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(12, 70);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(40, 13);
            this.lblCodigo.TabIndex = 17;
            this.lblCodigo.Text = "Codigo";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(108, 67);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.ReadOnly = true;
            this.txtCodigo.Size = new System.Drawing.Size(236, 20);
            this.txtCodigo.TabIndex = 18;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(12, 122);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(63, 13);
            this.lblDescripcion.TabIndex = 15;
            this.lblDescripcion.Text = "Descripción";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(108, 119);
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
            this.pnlCamposDetalle.Controls.Add(this.cmbServicio);
            this.pnlCamposDetalle.Controls.Add(this.lblServicio);
            this.pnlCamposDetalle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCamposDetalle.Location = new System.Drawing.Point(0, 0);
            this.pnlCamposDetalle.Name = "pnlCamposDetalle";
            this.pnlCamposDetalle.Padding = new System.Windows.Forms.Padding(0, 6, 12, 6);
            this.pnlCamposDetalle.Size = new System.Drawing.Size(800, 67);
            this.pnlCamposDetalle.TabIndex = 0;
            // 
            // cmbCategoria
            // 
            this.cmbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.Location = new System.Drawing.Point(212, 23);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(132, 24);
            this.cmbCategoria.TabIndex = 22;
            this.cmbCategoria.SelectedIndexChanged += new System.EventHandler(this.cmbCategoria_SelectedIndexChanged);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.Location = new System.Drawing.Point(556, 6);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(3, 3, 22, 3);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(232, 55);
            this.btnAgregar.TabIndex = 21;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // cmbServicio
            // 
            this.cmbServicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbServicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.cmbServicio.FormattingEnabled = true;
            this.cmbServicio.Location = new System.Drawing.Point(350, 23);
            this.cmbServicio.Name = "cmbServicio";
            this.cmbServicio.Size = new System.Drawing.Size(200, 24);
            this.cmbServicio.TabIndex = 20;
            this.cmbServicio.SelectedIndexChanged += new System.EventHandler(this.cmbServicio_SelectedIndexChanged);
            // 
            // lblServicio
            // 
            this.lblServicio.AutoSize = true;
            this.lblServicio.Font = new System.Drawing.Font("Myanmar Text", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServicio.Location = new System.Drawing.Point(5, 19);
            this.lblServicio.Name = "lblServicio";
            this.lblServicio.Size = new System.Drawing.Size(201, 34);
            this.lblServicio.TabIndex = 19;
            this.lblServicio.Text = "Seleccione un servicio";
            // 
            // pnlFotos
            // 
            this.pnlFotos.Controls.Add(this.pnlFotosBottom);
            this.pnlFotos.Controls.Add(this.imgFoto);
            this.pnlFotos.Controls.Add(this.pnlFotosIzq);
            this.pnlFotos.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlFotos.Location = new System.Drawing.Point(0, 381);
            this.pnlFotos.Name = "pnlFotos";
            this.pnlFotos.Padding = new System.Windows.Forms.Padding(12);
            this.pnlFotos.Size = new System.Drawing.Size(409, 209);
            this.pnlFotos.TabIndex = 21;
            // 
            // imgFoto
            // 
            this.imgFoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgFoto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imgFoto.Location = new System.Drawing.Point(210, 12);
            this.imgFoto.Name = "imgFoto";
            this.imgFoto.Size = new System.Drawing.Size(187, 185);
            this.imgFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgFoto.TabIndex = 24;
            this.imgFoto.TabStop = false;
            // 
            // pnlFotosIzq
            // 
            this.pnlFotosIzq.Controls.Add(this.btnEliminarFoto);
            this.pnlFotosIzq.Controls.Add(this.dgvFotos);
            this.pnlFotosIzq.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlFotosIzq.Location = new System.Drawing.Point(12, 12);
            this.pnlFotosIzq.Name = "pnlFotosIzq";
            this.pnlFotosIzq.Size = new System.Drawing.Size(198, 185);
            this.pnlFotosIzq.TabIndex = 21;
            // 
            // dgvFotos
            // 
            this.dgvFotos.AllowUserToAddRows = false;
            this.dgvFotos.AllowUserToDeleteRows = false;
            this.dgvFotos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvFotos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFotos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFotos.Location = new System.Drawing.Point(0, 0);
            this.dgvFotos.MultiSelect = false;
            this.dgvFotos.Name = "dgvFotos";
            this.dgvFotos.ReadOnly = true;
            this.dgvFotos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFotos.Size = new System.Drawing.Size(198, 185);
            this.dgvFotos.TabIndex = 2;
            this.dgvFotos.SelectionChanged += new System.EventHandler(this.dgvFotos_SelectionChanged);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnBuscar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.Location = new System.Drawing.Point(0, 0);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Padding = new System.Windows.Forms.Padding(10);
            this.btnBuscar.Size = new System.Drawing.Size(187, 47);
            this.btnBuscar.TabIndex = 23;
            this.btnBuscar.Text = "Añadir Imagen";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // pnlFotosBottom
            // 
            this.pnlFotosBottom.Controls.Add(this.btnBuscar);
            this.pnlFotosBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFotosBottom.Location = new System.Drawing.Point(210, 150);
            this.pnlFotosBottom.Name = "pnlFotosBottom";
            this.pnlFotosBottom.Size = new System.Drawing.Size(187, 47);
            this.pnlFotosBottom.TabIndex = 25;
            // 
            // btnEliminarFoto
            // 
            this.btnEliminarFoto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(37)))));
            this.btnEliminarFoto.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnEliminarFoto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarFoto.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarFoto.ForeColor = System.Drawing.Color.White;
            this.btnEliminarFoto.Location = new System.Drawing.Point(0, 138);
            this.btnEliminarFoto.Name = "btnEliminarFoto";
            this.btnEliminarFoto.Size = new System.Drawing.Size(198, 47);
            this.btnEliminarFoto.TabIndex = 24;
            this.btnEliminarFoto.Text = "Eliminar";
            this.btnEliminarFoto.UseVisualStyleBackColor = false;
            this.btnEliminarFoto.Click += new System.EventHandler(this.btnEliminarFoto_Click);
            // 
            // pnlOrdenDown
            // 
            this.pnlOrdenDown.Controls.Add(this.btnGuardar);
            this.pnlOrdenDown.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlOrdenDown.Location = new System.Drawing.Point(415, 381);
            this.pnlOrdenDown.Name = "pnlOrdenDown";
            this.pnlOrdenDown.Padding = new System.Windows.Forms.Padding(12);
            this.pnlOrdenDown.Size = new System.Drawing.Size(385, 209);
            this.pnlOrdenDown.TabIndex = 22;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(170)))), ((int)(((byte)(27)))));
            this.btnGuardar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(12, 150);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(361, 47);
            this.btnGuardar.TabIndex = 7;
            this.btnGuardar.Text = "Guardar Orden de Trabajo";
            this.btnGuardar.UseVisualStyleBackColor = false;
            // 
            // frmNuevaOT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 590);
            this.Controls.Add(this.pnlOrdenDown);
            this.Controls.Add(this.pnlFotos);
            this.Controls.Add(this.pnlDetalle);
            this.Controls.Add(this.pnlCampos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmNuevaOT";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Crear Orden De Trabajo";
            this.pnlCampos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgLogoWhite)).EndInit();
            this.pnlCamposDer.ResumeLayout(false);
            this.pnlCamposDer.PerformLayout();
            this.pnlCamposIzq.ResumeLayout(false);
            this.pnlCamposIzq.PerformLayout();
            this.pnlDetalle.ResumeLayout(false);
            this.pnlDetalle.PerformLayout();
            this.pnlDetalleDer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenDetalle)).EndInit();
            this.pnlCamposDetalle.ResumeLayout(false);
            this.pnlCamposDetalle.PerformLayout();
            this.pnlFotos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgFoto)).EndInit();
            this.pnlFotosIzq.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFotos)).EndInit();
            this.pnlFotosBottom.ResumeLayout(false);
            this.pnlOrdenDown.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.DateTimePicker dtpFechaFinalizacion;
        private System.Windows.Forms.Label lblFechaInicio;
        private System.Windows.Forms.Label lblFechaFinal;
        private System.Windows.Forms.Panel pnlCampos;
        private System.Windows.Forms.Panel pnlCamposIzq;
        private System.Windows.Forms.Panel pnlCamposDer;
        private System.Windows.Forms.PictureBox imgLogoWhite;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.ComboBox cmbCliente;
        private System.Windows.Forms.ComboBox cmbBicicleta;
        private System.Windows.Forms.Label lblBicicleta;
        private System.Windows.Forms.Panel pnlDetalle;
        private System.Windows.Forms.Panel pnlCamposDetalle;
        private System.Windows.Forms.Label lblServicio;
        private System.Windows.Forms.ComboBox cmbServicio;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.DataGridView dgvOrdenDetalle;
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
        private System.Windows.Forms.Panel pnlFotos;
        private System.Windows.Forms.Panel pnlFotosIzq;
        private System.Windows.Forms.DataGridView dgvFotos;
        private System.Windows.Forms.PictureBox imgFoto;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Panel pnlFotosBottom;
        private System.Windows.Forms.Button btnEliminarFoto;
        private System.Windows.Forms.Panel pnlOrdenDown;
        private System.Windows.Forms.Button btnGuardar;
    }
}