namespace BikerStriker
{
    partial class frmMenuPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenuPrincipal));
            this.pnlAsideMenu = new System.Windows.Forms.Panel();
            this.pnlFacturas = new System.Windows.Forms.Panel();
            this.btnNuevaFactura = new System.Windows.Forms.Button();
            this.btnFacturas = new System.Windows.Forms.Button();
            this.pnlOrdenesTrabajo = new System.Windows.Forms.Panel();
            this.BtnVerOrdenes = new System.Windows.Forms.Button();
            this.btnNuevaOrden = new System.Windows.Forms.Button();
            this.btnOrdenesTrabajo = new System.Windows.Forms.Button();
            this.pnlMantenimientos = new System.Windows.Forms.Panel();
            this.btnContactos = new System.Windows.Forms.Button();
            this.btnTarjetas = new System.Windows.Forms.Button();
            this.btnTiendas = new System.Windows.Forms.Button();
            this.btnProductos = new System.Windows.Forms.Button();
            this.btnCategorias = new System.Windows.Forms.Button();
            this.btnBicicletas = new System.Windows.Forms.Button();
            this.btnVendedores = new System.Windows.Forms.Button();
            this.btnClientes = new System.Windows.Forms.Button();
            this.btnMarcas = new System.Windows.Forms.Button();
            this.btnAdministradores = new System.Windows.Forms.Button();
            this.btnModelos = new System.Windows.Forms.Button();
            this.btnMantenimientos = new System.Windows.Forms.Button();
            this.imgLogo = new System.Windows.Forms.PictureBox();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.pnlUsuario = new System.Windows.Forms.Panel();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.imgUserLogo = new System.Windows.Forms.PictureBox();
            this.lblChildFrmTitle = new System.Windows.Forms.Label();
            this.pnlDesktop = new System.Windows.Forms.Panel();
            this.pnlAsideMenu.SuspendLayout();
            this.pnlFacturas.SuspendLayout();
            this.pnlOrdenesTrabajo.SuspendLayout();
            this.pnlMantenimientos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgLogo)).BeginInit();
            this.pnlHeader.SuspendLayout();
            this.pnlUsuario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgUserLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlAsideMenu
            // 
            this.pnlAsideMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.pnlAsideMenu.Controls.Add(this.pnlFacturas);
            this.pnlAsideMenu.Controls.Add(this.btnFacturas);
            this.pnlAsideMenu.Controls.Add(this.pnlOrdenesTrabajo);
            this.pnlAsideMenu.Controls.Add(this.btnOrdenesTrabajo);
            this.pnlAsideMenu.Controls.Add(this.pnlMantenimientos);
            this.pnlAsideMenu.Controls.Add(this.btnMantenimientos);
            this.pnlAsideMenu.Controls.Add(this.imgLogo);
            this.pnlAsideMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlAsideMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlAsideMenu.Name = "pnlAsideMenu";
            this.pnlAsideMenu.Size = new System.Drawing.Size(240, 815);
            this.pnlAsideMenu.TabIndex = 0;
            // 
            // pnlFacturas
            // 
            this.pnlFacturas.Controls.Add(this.btnNuevaFactura);
            this.pnlFacturas.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFacturas.Location = new System.Drawing.Point(0, 721);
            this.pnlFacturas.Name = "pnlFacturas";
            this.pnlFacturas.Size = new System.Drawing.Size(240, 39);
            this.pnlFacturas.TabIndex = 9;
            // 
            // btnNuevaFactura
            // 
            this.btnNuevaFactura.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnNuevaFactura.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNuevaFactura.FlatAppearance.BorderSize = 0;
            this.btnNuevaFactura.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevaFactura.Font = new System.Drawing.Font("Sylfaen", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevaFactura.ForeColor = System.Drawing.Color.White;
            this.btnNuevaFactura.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevaFactura.Image")));
            this.btnNuevaFactura.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnNuevaFactura.Location = new System.Drawing.Point(0, 0);
            this.btnNuevaFactura.Name = "btnNuevaFactura";
            this.btnNuevaFactura.Size = new System.Drawing.Size(240, 37);
            this.btnNuevaFactura.TabIndex = 13;
            this.btnNuevaFactura.Text = "Nueva Factura";
            this.btnNuevaFactura.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevaFactura.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNuevaFactura.UseVisualStyleBackColor = false;
            this.btnNuevaFactura.Click += new System.EventHandler(this.btnNuevaFactura_Click);
            // 
            // btnFacturas
            // 
            this.btnFacturas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnFacturas.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnFacturas.FlatAppearance.BorderSize = 0;
            this.btnFacturas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFacturas.Font = new System.Drawing.Font("Sylfaen", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFacturas.ForeColor = System.Drawing.Color.White;
            this.btnFacturas.Image = global::BikerStriker.Properties.Resources.arrow_down;
            this.btnFacturas.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFacturas.Location = new System.Drawing.Point(0, 684);
            this.btnFacturas.Name = "btnFacturas";
            this.btnFacturas.Size = new System.Drawing.Size(240, 37);
            this.btnFacturas.TabIndex = 8;
            this.btnFacturas.Text = "Facturas";
            this.btnFacturas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFacturas.UseVisualStyleBackColor = false;
            this.btnFacturas.Click += new System.EventHandler(this.btnFacturas_Click);
            // 
            // pnlOrdenesTrabajo
            // 
            this.pnlOrdenesTrabajo.Controls.Add(this.BtnVerOrdenes);
            this.pnlOrdenesTrabajo.Controls.Add(this.btnNuevaOrden);
            this.pnlOrdenesTrabajo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlOrdenesTrabajo.Location = new System.Drawing.Point(0, 606);
            this.pnlOrdenesTrabajo.Name = "pnlOrdenesTrabajo";
            this.pnlOrdenesTrabajo.Size = new System.Drawing.Size(240, 78);
            this.pnlOrdenesTrabajo.TabIndex = 7;
            // 
            // BtnVerOrdenes
            // 
            this.BtnVerOrdenes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.BtnVerOrdenes.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnVerOrdenes.FlatAppearance.BorderSize = 0;
            this.BtnVerOrdenes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnVerOrdenes.Font = new System.Drawing.Font("Sylfaen", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnVerOrdenes.ForeColor = System.Drawing.Color.White;
            this.BtnVerOrdenes.Image = ((System.Drawing.Image)(resources.GetObject("BtnVerOrdenes.Image")));
            this.BtnVerOrdenes.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.BtnVerOrdenes.Location = new System.Drawing.Point(0, 37);
            this.BtnVerOrdenes.Name = "BtnVerOrdenes";
            this.BtnVerOrdenes.Size = new System.Drawing.Size(240, 41);
            this.BtnVerOrdenes.TabIndex = 14;
            this.BtnVerOrdenes.Text = "Ver Órdenes";
            this.BtnVerOrdenes.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnVerOrdenes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnVerOrdenes.UseVisualStyleBackColor = false;
            this.BtnVerOrdenes.Click += new System.EventHandler(this.BtnVerOrdenes_Click);
            // 
            // btnNuevaOrden
            // 
            this.btnNuevaOrden.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnNuevaOrden.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNuevaOrden.FlatAppearance.BorderSize = 0;
            this.btnNuevaOrden.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevaOrden.Font = new System.Drawing.Font("Sylfaen", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevaOrden.ForeColor = System.Drawing.Color.White;
            this.btnNuevaOrden.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevaOrden.Image")));
            this.btnNuevaOrden.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnNuevaOrden.Location = new System.Drawing.Point(0, 0);
            this.btnNuevaOrden.Name = "btnNuevaOrden";
            this.btnNuevaOrden.Size = new System.Drawing.Size(240, 37);
            this.btnNuevaOrden.TabIndex = 13;
            this.btnNuevaOrden.Text = "Nueva Orden";
            this.btnNuevaOrden.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevaOrden.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNuevaOrden.UseVisualStyleBackColor = false;
            this.btnNuevaOrden.Click += new System.EventHandler(this.btnNuevaOrden_Click);
            // 
            // btnOrdenesTrabajo
            // 
            this.btnOrdenesTrabajo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnOrdenesTrabajo.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnOrdenesTrabajo.FlatAppearance.BorderSize = 0;
            this.btnOrdenesTrabajo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrdenesTrabajo.Font = new System.Drawing.Font("Sylfaen", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrdenesTrabajo.ForeColor = System.Drawing.Color.White;
            this.btnOrdenesTrabajo.Image = global::BikerStriker.Properties.Resources.arrow_down;
            this.btnOrdenesTrabajo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOrdenesTrabajo.Location = new System.Drawing.Point(0, 569);
            this.btnOrdenesTrabajo.Name = "btnOrdenesTrabajo";
            this.btnOrdenesTrabajo.Size = new System.Drawing.Size(240, 37);
            this.btnOrdenesTrabajo.TabIndex = 6;
            this.btnOrdenesTrabajo.Text = "Órdenes de Trabajo";
            this.btnOrdenesTrabajo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOrdenesTrabajo.UseVisualStyleBackColor = false;
            this.btnOrdenesTrabajo.Click += new System.EventHandler(this.btnOrdenesTrabajo_Click);
            // 
            // pnlMantenimientos
            // 
            this.pnlMantenimientos.Controls.Add(this.btnContactos);
            this.pnlMantenimientos.Controls.Add(this.btnTarjetas);
            this.pnlMantenimientos.Controls.Add(this.btnTiendas);
            this.pnlMantenimientos.Controls.Add(this.btnProductos);
            this.pnlMantenimientos.Controls.Add(this.btnCategorias);
            this.pnlMantenimientos.Controls.Add(this.btnBicicletas);
            this.pnlMantenimientos.Controls.Add(this.btnVendedores);
            this.pnlMantenimientos.Controls.Add(this.btnClientes);
            this.pnlMantenimientos.Controls.Add(this.btnMarcas);
            this.pnlMantenimientos.Controls.Add(this.btnAdministradores);
            this.pnlMantenimientos.Controls.Add(this.btnModelos);
            this.pnlMantenimientos.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMantenimientos.Location = new System.Drawing.Point(0, 162);
            this.pnlMantenimientos.Name = "pnlMantenimientos";
            this.pnlMantenimientos.Size = new System.Drawing.Size(240, 407);
            this.pnlMantenimientos.TabIndex = 5;
            // 
            // btnContactos
            // 
            this.btnContactos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnContactos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnContactos.FlatAppearance.BorderSize = 0;
            this.btnContactos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnContactos.Font = new System.Drawing.Font("Sylfaen", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContactos.ForeColor = System.Drawing.Color.White;
            this.btnContactos.Image = ((System.Drawing.Image)(resources.GetObject("btnContactos.Image")));
            this.btnContactos.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnContactos.Location = new System.Drawing.Point(0, 370);
            this.btnContactos.Name = "btnContactos";
            this.btnContactos.Size = new System.Drawing.Size(240, 37);
            this.btnContactos.TabIndex = 12;
            this.btnContactos.Text = "Contactos";
            this.btnContactos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnContactos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnContactos.UseVisualStyleBackColor = false;
            this.btnContactos.Click += new System.EventHandler(this.btnContactos_Click);
            // 
            // btnTarjetas
            // 
            this.btnTarjetas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnTarjetas.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTarjetas.FlatAppearance.BorderSize = 0;
            this.btnTarjetas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTarjetas.Font = new System.Drawing.Font("Sylfaen", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTarjetas.ForeColor = System.Drawing.Color.White;
            this.btnTarjetas.Image = ((System.Drawing.Image)(resources.GetObject("btnTarjetas.Image")));
            this.btnTarjetas.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnTarjetas.Location = new System.Drawing.Point(0, 333);
            this.btnTarjetas.Name = "btnTarjetas";
            this.btnTarjetas.Size = new System.Drawing.Size(240, 37);
            this.btnTarjetas.TabIndex = 11;
            this.btnTarjetas.Text = "Tarjetas";
            this.btnTarjetas.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnTarjetas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTarjetas.UseVisualStyleBackColor = false;
            this.btnTarjetas.Click += new System.EventHandler(this.btnTarjetas_Click);
            // 
            // btnTiendas
            // 
            this.btnTiendas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnTiendas.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTiendas.FlatAppearance.BorderSize = 0;
            this.btnTiendas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTiendas.Font = new System.Drawing.Font("Sylfaen", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTiendas.ForeColor = System.Drawing.Color.White;
            this.btnTiendas.Image = ((System.Drawing.Image)(resources.GetObject("btnTiendas.Image")));
            this.btnTiendas.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnTiendas.Location = new System.Drawing.Point(0, 296);
            this.btnTiendas.Name = "btnTiendas";
            this.btnTiendas.Size = new System.Drawing.Size(240, 37);
            this.btnTiendas.TabIndex = 10;
            this.btnTiendas.Text = "Tiendas";
            this.btnTiendas.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnTiendas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTiendas.UseVisualStyleBackColor = false;
            this.btnTiendas.Click += new System.EventHandler(this.btnTiendas_Click);
            // 
            // btnProductos
            // 
            this.btnProductos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnProductos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProductos.FlatAppearance.BorderSize = 0;
            this.btnProductos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProductos.Font = new System.Drawing.Font("Sylfaen", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProductos.ForeColor = System.Drawing.Color.White;
            this.btnProductos.Image = ((System.Drawing.Image)(resources.GetObject("btnProductos.Image")));
            this.btnProductos.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnProductos.Location = new System.Drawing.Point(0, 259);
            this.btnProductos.Name = "btnProductos";
            this.btnProductos.Size = new System.Drawing.Size(240, 37);
            this.btnProductos.TabIndex = 9;
            this.btnProductos.Text = "Productos";
            this.btnProductos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnProductos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnProductos.UseVisualStyleBackColor = false;
            this.btnProductos.Click += new System.EventHandler(this.btnProductos_Click);
            // 
            // btnCategorias
            // 
            this.btnCategorias.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnCategorias.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCategorias.FlatAppearance.BorderSize = 0;
            this.btnCategorias.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategorias.Font = new System.Drawing.Font("Sylfaen", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCategorias.ForeColor = System.Drawing.Color.White;
            this.btnCategorias.Image = ((System.Drawing.Image)(resources.GetObject("btnCategorias.Image")));
            this.btnCategorias.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnCategorias.Location = new System.Drawing.Point(0, 222);
            this.btnCategorias.Name = "btnCategorias";
            this.btnCategorias.Size = new System.Drawing.Size(240, 37);
            this.btnCategorias.TabIndex = 8;
            this.btnCategorias.Text = "Categorias";
            this.btnCategorias.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCategorias.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCategorias.UseVisualStyleBackColor = false;
            this.btnCategorias.Click += new System.EventHandler(this.btnCategorias_Click);
            // 
            // btnBicicletas
            // 
            this.btnBicicletas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnBicicletas.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBicicletas.FlatAppearance.BorderSize = 0;
            this.btnBicicletas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBicicletas.Font = new System.Drawing.Font("Sylfaen", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBicicletas.ForeColor = System.Drawing.Color.White;
            this.btnBicicletas.Image = ((System.Drawing.Image)(resources.GetObject("btnBicicletas.Image")));
            this.btnBicicletas.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnBicicletas.Location = new System.Drawing.Point(0, 185);
            this.btnBicicletas.Name = "btnBicicletas";
            this.btnBicicletas.Size = new System.Drawing.Size(240, 37);
            this.btnBicicletas.TabIndex = 7;
            this.btnBicicletas.Text = "Bicicletas";
            this.btnBicicletas.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBicicletas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBicicletas.UseVisualStyleBackColor = false;
            this.btnBicicletas.Click += new System.EventHandler(this.btnBicicletas_Click);
            // 
            // btnVendedores
            // 
            this.btnVendedores.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnVendedores.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnVendedores.FlatAppearance.BorderSize = 0;
            this.btnVendedores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVendedores.Font = new System.Drawing.Font("Sylfaen", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVendedores.ForeColor = System.Drawing.Color.White;
            this.btnVendedores.Image = ((System.Drawing.Image)(resources.GetObject("btnVendedores.Image")));
            this.btnVendedores.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnVendedores.Location = new System.Drawing.Point(0, 148);
            this.btnVendedores.Name = "btnVendedores";
            this.btnVendedores.Size = new System.Drawing.Size(240, 37);
            this.btnVendedores.TabIndex = 6;
            this.btnVendedores.Text = "Vendedores";
            this.btnVendedores.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnVendedores.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVendedores.UseVisualStyleBackColor = false;
            this.btnVendedores.Click += new System.EventHandler(this.btnVendedores_Click);
            // 
            // btnClientes
            // 
            this.btnClientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnClientes.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnClientes.FlatAppearance.BorderSize = 0;
            this.btnClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClientes.Font = new System.Drawing.Font("Sylfaen", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClientes.ForeColor = System.Drawing.Color.White;
            this.btnClientes.Image = ((System.Drawing.Image)(resources.GetObject("btnClientes.Image")));
            this.btnClientes.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnClientes.Location = new System.Drawing.Point(0, 111);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(240, 37);
            this.btnClientes.TabIndex = 5;
            this.btnClientes.Text = "Clientes";
            this.btnClientes.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnClientes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClientes.UseVisualStyleBackColor = false;
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // btnMarcas
            // 
            this.btnMarcas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnMarcas.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMarcas.FlatAppearance.BorderSize = 0;
            this.btnMarcas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMarcas.Font = new System.Drawing.Font("Sylfaen", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMarcas.ForeColor = System.Drawing.Color.White;
            this.btnMarcas.Image = ((System.Drawing.Image)(resources.GetObject("btnMarcas.Image")));
            this.btnMarcas.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnMarcas.Location = new System.Drawing.Point(0, 74);
            this.btnMarcas.Name = "btnMarcas";
            this.btnMarcas.Size = new System.Drawing.Size(240, 37);
            this.btnMarcas.TabIndex = 2;
            this.btnMarcas.Text = "Marcas";
            this.btnMarcas.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMarcas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMarcas.UseVisualStyleBackColor = false;
            this.btnMarcas.Click += new System.EventHandler(this.btnMarcas_Click);
            // 
            // btnAdministradores
            // 
            this.btnAdministradores.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnAdministradores.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAdministradores.FlatAppearance.BorderSize = 0;
            this.btnAdministradores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdministradores.Font = new System.Drawing.Font("Sylfaen", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdministradores.ForeColor = System.Drawing.Color.White;
            this.btnAdministradores.Image = ((System.Drawing.Image)(resources.GetObject("btnAdministradores.Image")));
            this.btnAdministradores.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnAdministradores.Location = new System.Drawing.Point(0, 37);
            this.btnAdministradores.Name = "btnAdministradores";
            this.btnAdministradores.Size = new System.Drawing.Size(240, 37);
            this.btnAdministradores.TabIndex = 4;
            this.btnAdministradores.Text = "Administradores";
            this.btnAdministradores.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAdministradores.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAdministradores.UseVisualStyleBackColor = false;
            this.btnAdministradores.Click += new System.EventHandler(this.btnAdministradores_Click);
            // 
            // btnModelos
            // 
            this.btnModelos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnModelos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnModelos.FlatAppearance.BorderSize = 0;
            this.btnModelos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModelos.Font = new System.Drawing.Font("Sylfaen", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModelos.ForeColor = System.Drawing.Color.White;
            this.btnModelos.Image = ((System.Drawing.Image)(resources.GetObject("btnModelos.Image")));
            this.btnModelos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModelos.Location = new System.Drawing.Point(0, 0);
            this.btnModelos.Name = "btnModelos";
            this.btnModelos.Size = new System.Drawing.Size(240, 37);
            this.btnModelos.TabIndex = 3;
            this.btnModelos.Text = "Modelos";
            this.btnModelos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnModelos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnModelos.UseVisualStyleBackColor = false;
            this.btnModelos.Click += new System.EventHandler(this.btnModelos_Click);
            // 
            // btnMantenimientos
            // 
            this.btnMantenimientos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnMantenimientos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMantenimientos.FlatAppearance.BorderSize = 0;
            this.btnMantenimientos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMantenimientos.Font = new System.Drawing.Font("Sylfaen", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMantenimientos.ForeColor = System.Drawing.Color.White;
            this.btnMantenimientos.Image = global::BikerStriker.Properties.Resources.arrow_down;
            this.btnMantenimientos.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMantenimientos.Location = new System.Drawing.Point(0, 125);
            this.btnMantenimientos.Name = "btnMantenimientos";
            this.btnMantenimientos.Size = new System.Drawing.Size(240, 37);
            this.btnMantenimientos.TabIndex = 1;
            this.btnMantenimientos.Text = "Mantenimientos";
            this.btnMantenimientos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMantenimientos.UseVisualStyleBackColor = false;
            this.btnMantenimientos.Click += new System.EventHandler(this.btnMantenimientos_Click);
            // 
            // imgLogo
            // 
            this.imgLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.imgLogo.Image = global::BikerStriker.Properties.Resources.Logo_BikerStriker_BlackBackground;
            this.imgLogo.Location = new System.Drawing.Point(0, 0);
            this.imgLogo.Name = "imgLogo";
            this.imgLogo.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.imgLogo.Size = new System.Drawing.Size(240, 125);
            this.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgLogo.TabIndex = 0;
            this.imgLogo.TabStop = false;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.pnlHeader.Controls.Add(this.pnlUsuario);
            this.pnlHeader.Controls.Add(this.lblChildFrmTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(240, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(948, 125);
            this.pnlHeader.TabIndex = 1;
            // 
            // pnlUsuario
            // 
            this.pnlUsuario.Controls.Add(this.lblUsuario);
            this.pnlUsuario.Controls.Add(this.imgUserLogo);
            this.pnlUsuario.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlUsuario.Location = new System.Drawing.Point(602, 0);
            this.pnlUsuario.Name = "pnlUsuario";
            this.pnlUsuario.Size = new System.Drawing.Size(346, 125);
            this.pnlUsuario.TabIndex = 1;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Sylfaen", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.ForeColor = System.Drawing.Color.White;
            this.lblUsuario.Location = new System.Drawing.Point(141, 35);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(140, 48);
            this.lblUsuario.TabIndex = 2;
            this.lblUsuario.Text = "Usuario";
            this.lblUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblUsuario.Click += new System.EventHandler(this.lblUsuario_Click);
            // 
            // imgUserLogo
            // 
            this.imgUserLogo.Image = global::BikerStriker.Properties.Resources.user_logo;
            this.imgUserLogo.Location = new System.Drawing.Point(287, 33);
            this.imgUserLogo.Name = "imgUserLogo";
            this.imgUserLogo.Size = new System.Drawing.Size(53, 50);
            this.imgUserLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgUserLogo.TabIndex = 3;
            this.imgUserLogo.TabStop = false;
            this.imgUserLogo.Click += new System.EventHandler(this.imgUserLogo_Click);
            // 
            // lblChildFrmTitle
            // 
            this.lblChildFrmTitle.AutoSize = true;
            this.lblChildFrmTitle.Font = new System.Drawing.Font("Sylfaen", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChildFrmTitle.ForeColor = System.Drawing.Color.White;
            this.lblChildFrmTitle.Location = new System.Drawing.Point(6, 35);
            this.lblChildFrmTitle.Name = "lblChildFrmTitle";
            this.lblChildFrmTitle.Size = new System.Drawing.Size(262, 48);
            this.lblChildFrmTitle.TabIndex = 0;
            this.lblChildFrmTitle.Text = "Menú Principal";
            // 
            // pnlDesktop
            // 
            this.pnlDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDesktop.Location = new System.Drawing.Point(240, 125);
            this.pnlDesktop.Name = "pnlDesktop";
            this.pnlDesktop.Size = new System.Drawing.Size(948, 690);
            this.pnlDesktop.TabIndex = 2;
            // 
            // frmMenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1188, 815);
            this.Controls.Add(this.pnlDesktop);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlAsideMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmMenuPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menú Principal";
            this.pnlAsideMenu.ResumeLayout(false);
            this.pnlFacturas.ResumeLayout(false);
            this.pnlOrdenesTrabajo.ResumeLayout(false);
            this.pnlMantenimientos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgLogo)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlUsuario.ResumeLayout(false);
            this.pnlUsuario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgUserLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlAsideMenu;
        private System.Windows.Forms.PictureBox imgLogo;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Button btnMantenimientos;
        private System.Windows.Forms.Button btnMarcas;
        private System.Windows.Forms.Button btnModelos;
        private System.Windows.Forms.Label lblChildFrmTitle;
        private System.Windows.Forms.Panel pnlDesktop;
        private System.Windows.Forms.Button btnAdministradores;
        private System.Windows.Forms.Panel pnlMantenimientos;
        private System.Windows.Forms.Button btnClientes;
        private System.Windows.Forms.Button btnVendedores;
        private System.Windows.Forms.Button btnBicicletas;
        private System.Windows.Forms.Button btnCategorias;
        private System.Windows.Forms.Button btnProductos;
        private System.Windows.Forms.Button btnTiendas;
        private System.Windows.Forms.Panel pnlUsuario;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.PictureBox imgUserLogo;
        private System.Windows.Forms.Button btnTarjetas;
        private System.Windows.Forms.Button btnContactos;
        private System.Windows.Forms.Button btnOrdenesTrabajo;
        private System.Windows.Forms.Panel pnlOrdenesTrabajo;
        private System.Windows.Forms.Button BtnVerOrdenes;
        private System.Windows.Forms.Button btnNuevaOrden;
        private System.Windows.Forms.Panel pnlFacturas;
        private System.Windows.Forms.Button btnNuevaFactura;
        private System.Windows.Forms.Button btnFacturas;
    }
}

