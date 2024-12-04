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
            if (cmbProducto.SelectedItem != null)
            {
                Producto producto = (Producto)cmbProducto.SelectedItem;
                if (producto.Cantidad > 0)
                {
                    FacturaDetalle.Add(new FacturaDetalle(producto, (int)nudCantidad.Value));
                    Productos.Remove(producto);
                    ActualizarProductos();
                    LimpiarCamposDetalle();
                    ActualizarPrecioTotal();
                }
                else
                {
                    MessageBox.Show($"No es posible comprar {producto}. No tenemos más existencias de este producto.", "¡Lo sentimos!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Porfavor escoja algún producto.");
            }


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
            BLLTienda bllTienda = new BLLTienda();
            Tienda tienda = bllTienda.GetAllTienda()[0];

            OrdenTrabajo ordenTrabajo = (OrdenTrabajo) cmbOrdenTrabajo.SelectedItem;

            double IVA = tienda.ImpuestoVenta / 100;

            double TotalColones = FacturaDetalle.Sum(p => p.Producto.Precio * p.Cantidad) + ((ordenTrabajo != null) ? ordenTrabajo.OrdenDetalle.Sum(p => p.Servicio.Precio) : 0);
            double TotalDolares = FacturaDetalle.Sum(p => p.Producto.Dolarizado * p.Cantidad) + ((ordenTrabajo != null) ? ordenTrabajo.OrdenDetalle.Sum(p => p.Servicio.Dolarizado) : 0);

            lblPrecioTotal.Text = $"Precio Total\n₡ {TotalColones.ToString("#,##0.00")}    Impuesto de Venta: ₡ {(TotalColones * IVA).ToString("#,##0.00")}\n$ {TotalDolares.ToString("#,##0.00")}    Impuesto de Venta: $ {(TotalDolares * IVA).ToString("#,##0.00")}";
        }
        private bool Validaciones()
        {
            if (cmbCliente.SelectedItem == null)
            {
                MessageBox.Show("Porfavor escoja algún cliente.");
                return false;
            }
            if (cmbTarjeta.SelectedItem == null)
            {
                MessageBox.Show("Porfavor escoja una tarjeta.");
                return false;
            }
            if (FacturaDetalle.ToList().Count <= 0)
            {
                MessageBox.Show("Porfavor escoja algún producto.");
                return false;
            }

            return true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Validaciones())
            {
                GenerarFactura();
            }
            
        }

        private void GenerarFactura()
        {
            Cliente cliente = (Cliente)cmbCliente.SelectedItem;
            Tarjeta tarjeta = (Tarjeta)cmbTarjeta.SelectedItem;
            OrdenTrabajo ordenTrabajo = (OrdenTrabajo)cmbOrdenTrabajo.SelectedItem;

            double TotalColones = FacturaDetalle.Sum(p => p.Producto.Precio * p.Cantidad) + ((ordenTrabajo != null) ? ordenTrabajo.OrdenDetalle.Sum(p => p.Servicio.Precio) : 0);
            double TotalDolares = FacturaDetalle.Sum(p => p.Producto.Dolarizado * p.Cantidad) + ((ordenTrabajo != null) ? ordenTrabajo.OrdenDetalle.Sum(p => p.Servicio.Dolarizado) : 0);

            BikerStrikerFacturaFacade facturaFacade = new BikerStrikerFacturaFacade();
            FacturaFactory facturaFactory = new FacturaFactory();

            Factura factura = facturaFactory.CrearFactura(cliente, tarjeta, TotalColones, TotalDolares, ordenTrabajo, FacturaDetalle.ToList());

            facturaFacade.Factura = factura;

            if (facturaFacade.GuardarFactura())
            {
                MessageBox.Show($"Se ha generado con exito la Factura #{facturaFacade.Factura.Id}", "¡Proceso Exitoso!",MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (facturaFacade.EnviarFacturaEmail())
                {
                    facturaFacade.AjusteFactura();
                    MessageBox.Show($"Se ha enviado con exito la Factura #{facturaFacade.Factura.Id} al correo {facturaFacade.Factura.Cliente.Correo}", "¡Proceso Exitoso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("NO se ha podido enviar por correo la Factura", "¡Proceso Fallido!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("NO se ha podido generar la Factura", "¡Proceso Fallido!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void nudCantidad_ValueChanged(object sender, EventArgs e)
        {
            if (dgvFacturaDetalle.SelectedRows.Count > 0)
            {
                FacturaDetalle fDetalle = (FacturaDetalle)dgvFacturaDetalle.CurrentRow.DataBoundItem;

                int cantidad = (int)nudCantidad.Value;
                int cantidadAlmacen = fDetalle.Producto.Cantidad;

                if (cantidadAlmacen >= cantidad) 
                {
                    fDetalle.Cantidad = cantidad;
                    FacturaDetalle[FacturaDetalle.IndexOf(fDetalle)] = fDetalle;
                }
                else
                {
                    MessageBox.Show($"No es posible comprar {cantidad} {fDetalle.Producto}. Cantidad en almacen: {cantidadAlmacen}.","¡Lo sentimos!",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    nudCantidad.Value = cantidadAlmacen;
                }

                

                ActualizarPrecioTotal();
            }
        }
    }
}   
