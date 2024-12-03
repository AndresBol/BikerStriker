using BikerStriker.Enums;
using BikerStriker.Layers.BLL;
using BikerStriker.Layers.DAL;
using BikerStriker.Layers.Entities;
using BikerStriker.Patrones;
using BikerStriker.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BikerStriker.Layers.UI.Procesos
{
    public partial class frmNuevaFactura : Form
    {
        private List<Producto> Productos;
        private BindingList<FacturaDetalle> FacturaDetalle = new BindingList<FacturaDetalle>();

        public frmNuevaFactura()
        {
            InitializeComponent();
            btnEliminarDetalle.Visible = false;
            CargarElementos();

        }

        private async void CargarElementos()
        {
            BLLCliente bLLCliente = new BLLCliente();
            
            Usuario uActivo = Settings.Default.Usuario;

            if (uActivo.TipoUsuario == TipoUsuario.Cliente)
            {
                cmbCliente.DataSource = new List<Cliente> { bLLCliente.GetClienteByUserID(uActivo.UsuarioId) };
            }
            else
            {
                cmbCliente.DataSource = bLLCliente.GetAllCliente();
            }

            dgvFacturaDetalle.DataSource = FacturaDetalle;
            dgvFacturaDetalle.Columns["Id"].Visible = false;

            BLLProducto bLLProducto = new BLLProducto();
            Productos = await bLLProducto.GetSoloProductos();

            BLLCategoria bLLCategoria = new BLLCategoria();
            cmbCategoria.DataSource = bLLCategoria.GetAllCategoria();
        }

        private void ActualizarProductos() 
        {
            var ProductosFiltrados = Productos
                       .Where(d => d.Categoria.Id == ((Categoria)cmbCategoria.SelectedItem).Id)
                       .ToList();

            cmbProducto.DataSource = ProductosFiltrados;
        }

        private void ActualizarCamposDetalle(FacturaDetalle facturaDetalle)
        {
            if(facturaDetalle != null)
            {
                txtCodigo.Text = facturaDetalle.Producto.Codigo;
                txtNombre.Text = facturaDetalle.Producto.Nombre;
                txtDescripcion.Text = facturaDetalle.Producto.Descripcion;
                lblPrecio.Text = $"Precio\n₡ {facturaDetalle.Producto.Precio.ToString("#,##0.00")}\n$ {facturaDetalle.Producto.Dolarizado.ToString("#,##0.00")}";
                nudCantidad.Value = facturaDetalle.Cantidad;
            }
        }

        private void LimpiarCamposDetalle()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            lblPrecio.Text = "Precio\n₡\n$";
            btnEliminarDetalle.Visible = false;
            cmbProducto.SelectedItem = null;
            nudCantidad.Value = 1;
        }

        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarProductos();
        }

        private async void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cliente cliente = (Cliente) cmbCliente.SelectedItem;
            if (cliente != null)
            {
                BLLTarjeta bLLTarjeta = new BLLTarjeta();
                cmbTarjeta.DataSource = bLLTarjeta.GetAllTarjetaFromCliente(cliente.ClienteId);

                BLLOrdenTrabajo bllOrdenTrabajo = new BLLOrdenTrabajo();
                cmbOrdenTrabajo.DataSource = await bllOrdenTrabajo.GetAllPendingOrdenTrabajoFromCliente(cliente.ClienteId);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Producto producto = (Producto) cmbProducto.SelectedItem;
            FacturaDetalle.Add(new FacturaDetalle(producto, (int) nudCantidad.Value));
            Productos.Remove(producto);
            ActualizarProductos();
            LimpiarCamposDetalle();
            ActualizarPrecioTotal();
        }

        private void dgvOrdenDetalle_Click(object sender, EventArgs e)
        {
            if (dgvFacturaDetalle.SelectedRows.Count > 0)
            {
                cmbProducto.SelectedItem = null;
                btnEliminarDetalle.Visible = true;
                ActualizarCamposDetalle((FacturaDetalle)dgvFacturaDetalle.CurrentRow.DataBoundItem);
            }
        }

        private void btnEliminarDetalle_Click(object sender, EventArgs e)
        {
            FacturaDetalle facturaDetalle = (FacturaDetalle)dgvFacturaDetalle.CurrentRow.DataBoundItem;

            DialogResult respuesta = MessageBox.Show($"¿Desea eliminar el producto: {facturaDetalle.Producto.Nombre}?", "Eliminar producto", MessageBoxButtons.YesNo);

            if (respuesta == DialogResult.Yes)
            {
                FacturaDetalle.Remove(facturaDetalle);
                Productos.Add(facturaDetalle.Producto);
                LimpiarCamposDetalle();
                ActualizarProductos();
                ActualizarPrecioTotal();
            }
        }

        private void ActualizarPrecioTotal()
        {
            double TotalColones = FacturaDetalle.Sum(p => p.Producto.Precio);
            double TotalDolares = FacturaDetalle.Sum(p => p.Producto.Dolarizado);

            lblPrecioTotal.Text = $"Precio Total\n₡ {TotalColones.ToString("#,##0.00")}\n$ {TotalDolares.ToString("#,##0.00")}";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            GenerarOrdenDeTrabajo();
        }

        private void GenerarOrdenDeTrabajo()
        {
            /*
            Cliente cliente = (Cliente)cmbCliente.SelectedItem;
            Tarjeta tarjeta = (Tarjeta)cmbTarjeta.SelectedItem;

            BikerStrikerFacturaFacade facturaFacade = new BikerStrikerFacturaFacade();
            OrdenDeTrabajoFactory facturaFactory = new OrdenDeTrabajoFactory();

            Image firma = (Image)CloneBitmapWithWhiteBackground(signatureBitmap).Clone();

            Factura factura = facturaFactory.CrearOrdenDeTrabajo(dtpFechaInicio.Value, dtpFechaFinalizacion.Value, firma, cliente, tarjeta, ProductosSeleccionados.ToList(), Fotografias.ToList());

            facturaFacade.Factura = factura;

            if (facturaFacade.GuardarFactura())
            {
                MessageBox.Show($"Se ha generado con exito la Orden de Trabajo #{facturaFacade.Factura.Id}", "¡Proceso Exitoso!",MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (facturaFacade.EnviarFacturaEmail())
                {
                    MessageBox.Show($"Se ha enviado con exito la Orden de Trabajo #{facturaFacade.Factura.Id} al correo {facturaFacade.Factura.Cliente.Correo}", "¡Proceso Exitoso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("NO se ha podido enviar por correo la Orden de Trabajo", "¡Proceso Fallido!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("NO se ha podido generar la Orden de Trabajo", "¡Proceso Fallido!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
        }

        private void nudCantidad_ValueChanged(object sender, EventArgs e)
        {
            if (dgvFacturaDetalle.SelectedRows.Count > 0)
            {
                FacturaDetalle fDetalle = (FacturaDetalle)dgvFacturaDetalle.CurrentRow.DataBoundItem;
                FacturaDetalle[FacturaDetalle.IndexOf(fDetalle)].Cantidad = (int)nudCantidad.Value;
            }
        }
    }
}   
