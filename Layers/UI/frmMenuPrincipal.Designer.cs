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
            this.pnlMantenimientos = new System.Windows.Forms.Panel();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblChildFrmTitle = new System.Windows.Forms.Label();
            this.pnlDesktop = new System.Windows.Forms.Panel();
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
            this.btnTiendas = new System.Windows.Forms.Button();
            this.pnlAsideMenu.SuspendLayout();
            this.pnlMantenimientos.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlAsideMenu
            // 
            this.pnlAsideMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.pnlAsideMenu.Controls.Add(this.pnlMantenimientos);
            this.pnlAsideMenu.Controls.Add(this.btnMantenimientos);
            this.pnlAsideMenu.Controls.Add(this.imgLogo);
            this.pnlAsideMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlAsideMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlAsideMenu.Name = "pnlAsideMenu";
            this.pnlAsideMenu.Size = new System.Drawing.Size(208, 578);
            this.pnlAsideMenu.TabIndex = 0;
            // 
            // pnlMantenimientos
            // 
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
            this.pnlMantenimientos.Size = new System.Drawing.Size(208, 348);
            this.pnlMantenimientos.TabIndex = 5;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.pnlHeader.Controls.Add(this.lblChildFrmTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(208, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(954, 125);
            this.pnlHeader.TabIndex = 1;
            // 
            // lblChildFrmTitle
            // 
            this.lblChildFrmTitle.AutoSize = true;
            this.lblChildFrmTitle.Font = new System.Drawing.Font("Sylfaen", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChildFrmTitle.ForeColor = System.Drawing.Color.White;
            this.lblChildFrmTitle.Location = new System.Drawing.Point(18, 35);
            this.lblChildFrmTitle.Name = "lblChildFrmTitle";
            this.lblChildFrmTitle.Size = new System.Drawing.Size(262, 48);
            this.lblChildFrmTitle.TabIndex = 0;
            this.lblChildFrmTitle.Text = "Menú Principal";
            // 
            // pnlDesktop
            // 
            this.pnlDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDesktop.Location = new System.Drawing.Point(208, 125);
            this.pnlDesktop.Name = "pnlDesktop";
            this.pnlDesktop.Size = new System.Drawing.Size(954, 453);
            this.pnlDesktop.TabIndex = 2;
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
            this.btnProductos.Size = new System.Drawing.Size(208, 37);
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
            this.btnCategorias.Size = new System.Drawing.Size(208, 37);
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
            this.btnBicicletas.Size = new System.Drawing.Size(208, 37);
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
            this.btnVendedores.Size = new System.Drawing.Size(208, 37);
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
            this.btnClientes.Size = new System.Drawing.Size(208, 37);
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
            this.btnMarcas.Size = new System.Drawing.Size(208, 37);
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
            this.btnAdministradores.Size = new System.Drawing.Size(208, 37);
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
            this.btnModelos.Size = new System.Drawing.Size(208, 37);
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
            this.btnMantenimientos.Size = new System.Drawing.Size(208, 37);
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
            this.imgLogo.Size = new System.Drawing.Size(208, 125);
            this.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgLogo.TabIndex = 0;
            this.imgLogo.TabStop = false;
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
            this.btnTiendas.Size = new System.Drawing.Size(208, 37);
            this.btnTiendas.TabIndex = 10;
            this.btnTiendas.Text = "Tiendas";
            this.btnTiendas.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnTiendas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTiendas.UseVisualStyleBackColor = false;
            this.btnTiendas.Click += new System.EventHandler(this.btnTiendas_Click);
            // 
            // frmMenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1162, 578);
            this.Controls.Add(this.pnlDesktop);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlAsideMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmMenuPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menú Principal";
            this.pnlAsideMenu.ResumeLayout(false);
            this.pnlMantenimientos.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgLogo)).EndInit();
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
    }
}

