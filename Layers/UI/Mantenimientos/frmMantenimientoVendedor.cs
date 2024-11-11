using BikerStriker.Enums;
using BikerStriker.Interfaces;
using BikerStriker.Layers.BLL;
using BikerStriker.Layers.Entities;
using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BikerStriker.Layers.UI.Mantenimientos
{
    public partial class frmMantenimientoVendedor : Form
    {
        private static readonly ILog _Logger = LogManager.GetLogger("MyControlEventos");
        public frmMantenimientoVendedor()
        {
            InitializeComponent();
            ActualizarTabla();
            CrearVendedorComponentes();
        }

        private void ActualizarCampos(Vendedor vendedor)
        {
            txtCorreo.Text = vendedor.Correo;
            txtContrasena.Text = vendedor.Contraseña;
            imgFotografia.Image = vendedor.Fotografia;
            txtCodigo.Text = vendedor.Codigo;
            txtNombre.Text = vendedor.Nombre;
            txtApellidos.Text = vendedor.Apellidos;
            dtpFechaNacimiento.Value = vendedor.FechaNacimiento;
        }

        private void ActualizarTabla()
        {
            try
            {
                IBLLVendedor bll = new BLLVendedor();
                dgvVendedores.DataSource = bll.GetAllVendedor();
                dgvVendedores.Columns["Fotografia"].Visible = false;
            }
            catch (Exception ex)
            {
                _Logger.ErrorFormat("Error {0}", ex.Message);
                MessageBox.Show($"Ha sucedido un error: \n{ex.Message}");
                throw;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Solo JPEG | *.jpeg";
            DialogResult resultado = openFileDialog.ShowDialog();
            if (resultado == System.Windows.Forms.DialogResult.OK)
            {
                txtFotografia.Visible = true;
                txtFotografia.Text = openFileDialog.FileName;
                imgFotografia.Image = Image.FromFile(openFileDialog.FileName);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            try
            {
                
                IBLLVendedor bll = new BLLVendedor();
                Vendedor vendedor = new Vendedor();
                vendedor.Correo = txtCorreo.Text;
                vendedor.Contraseña = txtContrasena.Text;
                vendedor.Fotografia = imgFotografia.Image;
                vendedor.Codigo = txtCodigo.Text;
                vendedor.Nombre = txtNombre.Text;
                vendedor.Apellidos = txtApellidos.Text;
                vendedor.FechaNacimiento = dtpFechaNacimiento.Value;

                if(dgvVendedores.SelectedRows.Count > 0)
                {
                    Vendedor vVendedor = (Vendedor)dgvVendedores.CurrentRow.DataBoundItem;
                    vendedor.UsuarioId = vVendedor.UsuarioId;
                    vendedor.VendedorId = vVendedor.VendedorId;
                }

                bll.Save(vendedor);
                ActualizarTabla();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ooops: {ex.Message}");
                throw;
            }
        }

        private void dgvVendedores_SelectionChanged(object sender, EventArgs e)
        {
            ActualizarCampos((Vendedor)dgvVendedores.CurrentRow.DataBoundItem);
            EditarVendedorComponentes();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            dgvVendedores.ClearSelection();
            CrearVendedorComponentes();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Vendedor vendedor = ((Vendedor)dgvVendedores.CurrentRow.DataBoundItem);

            IBLLVendedor cBLL = new BLLVendedor();
            cBLL.Remove(vendedor.VendedorId);

            IBLLUsuario uBLL = new BLLUsuario();
            uBLL.Remove(vendedor.UsuarioId);

            ActualizarTabla();
        }

        private void CrearVendedorComponentes()
        {
            lblSubtitulo.Text = "Añadir Vendedor";
            btnEliminar.Visible = false;
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtApellidos.Text = "";
            dtpFechaNacimiento.Value = DateTime.Today;
            txtCorreo.Text = "";
            txtContrasena.Text = "";
            txtFotografia.Text = "";
            txtFotografia.Visible = false;
            imgFotografia.Image = null;
            btnAdd.Visible = false;
        }
        private void EditarVendedorComponentes()
        {
            lblSubtitulo.Text = "Editar Vendedor";
            txtFotografia.Text = "";
            txtFotografia.Visible = false;
            btnEliminar.Visible = true;
            btnAdd.Visible = true;
        }

    }

}
