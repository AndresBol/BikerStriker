using BikerStriker.Interfaces;
using BikerStriker.Layers.BLL;
using BikerStriker.Layers.DAL;
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
    public partial class frmMantenimientoProducto : Form
    {
        private static readonly ILog _Logger = LogManager.GetLogger("MyControlEventos");
        public frmMantenimientoProducto()
        {
            InitializeComponent();

            DALCategoria dALCategoria = new DALCategoria();
            cmbCategoria.DataSource = dALCategoria.GetAllCategoria();

            ActualizarTabla();
            CrearProductoComponentes();
        }

        private void ActualizarCampos(Producto producto)
        {
            txtCodigo.Text = producto.Codigo;
            txtNombre.Text = producto.Nombre;
            nudPrecio.Value = (decimal) producto.Precio;
            txtDescripcion.Text = producto.Descripcion;
            nudCantidad.Value = producto.Cantidad;
            cmbCategoria.SelectedIndex = cmbCategoria.FindString(producto.Categoria.ToString());
            chkServicio.Checked = producto.EsServicio;
        }

        private async void ActualizarTabla()
        {
            try
            {
                IBLLProducto bll = new BLLProducto();
                dgvProductos.DataSource = await bll.GetAllProducto();
                dgvProductos.Columns["Descripcion"].Visible = false;
            }
            catch (Exception ex)
            {
                _Logger.ErrorFormat("Error {0}", ex.Message);
                MessageBox.Show($"Ha sucedido un error: \n{ex.Message}");
                throw;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            try
            {
                IBLLProducto bll = new BLLProducto();
                Producto producto = new Producto();
                producto.Codigo = txtCodigo.Text;
                producto.Nombre = txtNombre.Text;
                producto.Precio = (double) nudPrecio.Value;
                producto.Descripcion = txtDescripcion.Text;
                producto.Cantidad = (int) nudCantidad.Value;
                producto.Categoria = (Categoria) cmbCategoria.SelectedItem;
                producto.EsServicio = chkServicio.Checked;

                if(dgvProductos.SelectedRows.Count > 0)
                {
                    producto.Id = ((Producto)dgvProductos.CurrentRow.DataBoundItem).Id;
                }

                bll.Save(producto);
                ActualizarTabla();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ooops: {ex.Message}");
                throw;
            }
        }

        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            ActualizarCampos((Producto)dgvProductos.CurrentRow.DataBoundItem);
            EditarProductoComponentes();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            dgvProductos.ClearSelection();
            CrearProductoComponentes();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            IBLLProducto bll = new BLLProducto();
            bll.Remove(((Producto)dgvProductos.CurrentRow.DataBoundItem).Id);
            ActualizarTabla();
        }

        private void CrearProductoComponentes()
        {
            lblSubtitulo.Text = "Añadir Producto";
            btnEliminar.Visible = false;
            btnAdd.Visible = false;

            txtCodigo.Text = "";
            txtNombre.Text = "";
            nudPrecio.Value = 0;
            txtDescripcion.Text = "";
            nudCantidad.Value = 0;
            cmbCategoria.SelectedIndex = 0;
            chkServicio.Checked = false;
        }
        private void EditarProductoComponentes()
        {
            lblSubtitulo.Text = "Editar Producto";
            btnEliminar.Visible = true;
            btnAdd.Visible = true;
        }

    }
}
