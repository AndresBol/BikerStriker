namespace BikerStriker.Layers.UI.Mantenimientos
{
    partial class frmMantenimientoTarjeta
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
            this.dgvTarjetas = new System.Windows.Forms.DataGridView();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.lblNumero = new System.Windows.Forms.Label();
            this.lblTipoTarjeta = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.cmbTipoTarjeta = new System.Windows.Forms.ComboBox();
            this.pnlBotom = new System.Windows.Forms.Panel();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.lblFechaVencimiento = new System.Windows.Forms.Label();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.lblCliente = new System.Windows.Forms.Label();
            this.cmbCliente = new System.Windows.Forms.ComboBox();
            this.dtpFechaVencimiento = new System.Windows.Forms.DateTimePicker();
            this.lblCodigoSeguridad = new System.Windows.Forms.Label();
            this.nudCodigoSeguridad = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTarjetas)).BeginInit();
            this.pnlBotom.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCodigoSeguridad)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTarjetas
            // 
            this.dgvTarjetas.AllowUserToAddRows = false;
            this.dgvTarjetas.AllowUserToDeleteRows = false;
            this.dgvTarjetas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvTarjetas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTarjetas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTarjetas.Location = new System.Drawing.Point(0, 0);
            this.dgvTarjetas.MultiSelect = false;
            this.dgvTarjetas.Name = "dgvTarjetas";
            this.dgvTarjetas.ReadOnly = true;
            this.dgvTarjetas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTarjetas.Size = new System.Drawing.Size(800, 483);
            this.dgvTarjetas.TabIndex = 0;
            this.dgvTarjetas.SelectionChanged += new System.EventHandler(this.dgvTarjetas_SelectionChanged);
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtitulo.Location = new System.Drawing.Point(12, 0);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(207, 26);
            this.lblSubtitulo.TabIndex = 1;
            this.lblSubtitulo.Text = "Tarjeta seleccionada";
            // 
            // lblNumero
            // 
            this.lblNumero.AutoSize = true;
            this.lblNumero.Location = new System.Drawing.Point(14, 45);
            this.lblNumero.Name = "lblNumero";
            this.lblNumero.Size = new System.Drawing.Size(44, 13);
            this.lblNumero.TabIndex = 2;
            this.lblNumero.Text = "Numero";
            // 
            // lblTipoTarjeta
            // 
            this.lblTipoTarjeta.AutoSize = true;
            this.lblTipoTarjeta.Location = new System.Drawing.Point(16, 74);
            this.lblTipoTarjeta.Name = "lblTipoTarjeta";
            this.lblTipoTarjeta.Size = new System.Drawing.Size(75, 13);
            this.lblTipoTarjeta.TabIndex = 3;
            this.lblTipoTarjeta.Text = "Tipo de tarjeta";
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(116, 42);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(223, 20);
            this.txtNumero.TabIndex = 4;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(170)))), ((int)(((byte)(27)))));
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(263, 149);
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
            this.btnEliminar.Location = new System.Drawing.Point(174, 149);
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
            this.btnAdd.Location = new System.Drawing.Point(12, 149);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(88, 47);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "Añadir Tarjeta";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // cmbTipoTarjeta
            // 
            this.cmbTipoTarjeta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoTarjeta.FormattingEnabled = true;
            this.cmbTipoTarjeta.Location = new System.Drawing.Point(116, 71);
            this.cmbTipoTarjeta.Name = "cmbTipoTarjeta";
            this.cmbTipoTarjeta.Size = new System.Drawing.Size(223, 21);
            this.cmbTipoTarjeta.TabIndex = 11;
            // 
            // pnlBotom
            // 
            this.pnlBotom.Controls.Add(this.pnlRight);
            this.pnlBotom.Controls.Add(this.pnlLeft);
            this.pnlBotom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotom.Location = new System.Drawing.Point(0, 275);
            this.pnlBotom.Name = "pnlBotom";
            this.pnlBotom.Size = new System.Drawing.Size(800, 208);
            this.pnlBotom.TabIndex = 12;
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.nudCodigoSeguridad);
            this.pnlRight.Controls.Add(this.lblCodigoSeguridad);
            this.pnlRight.Controls.Add(this.dtpFechaVencimiento);
            this.pnlRight.Controls.Add(this.lblFechaVencimiento);
            this.pnlRight.Controls.Add(this.btnEliminar);
            this.pnlRight.Controls.Add(this.btnGuardar);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRight.Location = new System.Drawing.Point(437, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(363, 208);
            this.pnlRight.TabIndex = 1;
            // 
            // lblFechaVencimiento
            // 
            this.lblFechaVencimiento.AutoSize = true;
            this.lblFechaVencimiento.Location = new System.Drawing.Point(3, 45);
            this.lblFechaVencimiento.Name = "lblFechaVencimiento";
            this.lblFechaVencimiento.Size = new System.Drawing.Size(112, 13);
            this.lblFechaVencimiento.TabIndex = 8;
            this.lblFechaVencimiento.Text = "Fecha de vencimiento";
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.lblCliente);
            this.pnlLeft.Controls.Add(this.cmbCliente);
            this.pnlLeft.Controls.Add(this.lblTipoTarjeta);
            this.pnlLeft.Controls.Add(this.btnAdd);
            this.pnlLeft.Controls.Add(this.lblSubtitulo);
            this.pnlLeft.Controls.Add(this.cmbTipoTarjeta);
            this.pnlLeft.Controls.Add(this.lblNumero);
            this.pnlLeft.Controls.Add(this.txtNumero);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(354, 208);
            this.pnlLeft.TabIndex = 0;
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(16, 101);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(39, 13);
            this.lblCliente.TabIndex = 12;
            this.lblCliente.Text = "Cliente";
            // 
            // cmbCliente
            // 
            this.cmbCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCliente.FormattingEnabled = true;
            this.cmbCliente.Location = new System.Drawing.Point(116, 98);
            this.cmbCliente.Name = "cmbCliente";
            this.cmbCliente.Size = new System.Drawing.Size(223, 21);
            this.cmbCliente.TabIndex = 13;
            // 
            // dtpFechaVencimiento
            // 
            this.dtpFechaVencimiento.Location = new System.Drawing.Point(121, 42);
            this.dtpFechaVencimiento.Name = "dtpFechaVencimiento";
            this.dtpFechaVencimiento.Size = new System.Drawing.Size(230, 20);
            this.dtpFechaVencimiento.TabIndex = 14;
            // 
            // lblCodigoSeguridad
            // 
            this.lblCodigoSeguridad.AutoSize = true;
            this.lblCodigoSeguridad.Location = new System.Drawing.Point(3, 74);
            this.lblCodigoSeguridad.Name = "lblCodigoSeguridad";
            this.lblCodigoSeguridad.Size = new System.Drawing.Size(104, 13);
            this.lblCodigoSeguridad.TabIndex = 15;
            this.lblCodigoSeguridad.Text = "Código de seguridad";
            // 
            // nudCodigoSeguridad
            // 
            this.nudCodigoSeguridad.Location = new System.Drawing.Point(121, 72);
            this.nudCodigoSeguridad.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.nudCodigoSeguridad.Name = "nudCodigoSeguridad";
            this.nudCodigoSeguridad.Size = new System.Drawing.Size(230, 20);
            this.nudCodigoSeguridad.TabIndex = 19;
            this.nudCodigoSeguridad.ThousandsSeparator = true;
            this.nudCodigoSeguridad.Value = new decimal(new int[] {
            111,
            0,
            0,
            0});
            // 
            // frmMantenimientoTarjeta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 483);
            this.Controls.Add(this.pnlBotom);
            this.Controls.Add(this.dgvTarjetas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMantenimientoTarjeta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento de Tarjetas";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTarjetas)).EndInit();
            this.pnlBotom.ResumeLayout(false);
            this.pnlRight.ResumeLayout(false);
            this.pnlRight.PerformLayout();
            this.pnlLeft.ResumeLayout(false);
            this.pnlLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCodigoSeguridad)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTarjetas;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Label lblNumero;
        private System.Windows.Forms.Label lblTipoTarjeta;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ComboBox cmbTipoTarjeta;
        private System.Windows.Forms.Panel pnlBotom;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Label lblFechaVencimiento;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.ComboBox cmbCliente;
        private System.Windows.Forms.DateTimePicker dtpFechaVencimiento;
        private System.Windows.Forms.Label lblCodigoSeguridad;
        private System.Windows.Forms.NumericUpDown nudCodigoSeguridad;
    }
}