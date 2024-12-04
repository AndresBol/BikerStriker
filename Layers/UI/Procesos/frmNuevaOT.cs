using BikerStriker.Enums;
using BikerStriker.Layers.BLL;
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
    public partial class frmNuevaOT : Form
    {
        private List<Producto> Servicios;
        private BindingList<Producto> ServiciosSeleccionados = new BindingList<Producto>();
        private BindingList<OrdenFoto> Fotografias = new BindingList<OrdenFoto>();

        private Bitmap signatureBitmap;
        private bool isDrawing = false;
        private Point lastPoint;
        public frmNuevaOT()
        {
            InitializeComponent();
            btnEliminarDetalle.Visible = false;
            btnEliminarFoto.Visible = false;
            CargarElementos();

            InitializeBitmap(null,null);
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

            dgvFotos.DataSource = Fotografias;
            dgvFotos.Columns["Id"].Visible = false;
            dgvFotos.Columns["Foto"].Visible = false;

            dgvOrdenDetalle.DataSource = ServiciosSeleccionados;
            dgvOrdenDetalle.Columns["Id"].Visible = false;
            dgvOrdenDetalle.Columns["Descripcion"].Visible = false;
            dgvOrdenDetalle.Columns["Categoria"].Visible = false;
            dgvOrdenDetalle.Columns["Cantidad"].Visible = false;
            dgvOrdenDetalle.Columns["EsServicio"].Visible = false;

            BLLProducto bLLProducto = new BLLProducto();
            Servicios = await bLLProducto.GetSoloServicios();

            BLLCategoria bLLCategoria = new BLLCategoria();
            cmbCategoria.DataSource = bLLCategoria.GetAllCategoria();
        }

        private void ActualizarServicios() 
        {
            var ServiciosFiltrados = Servicios
                       .Where(d => d.Categoria.Id == ((Categoria)cmbCategoria.SelectedItem).Id)
                       .ToList();

            cmbServicio.DataSource = ServiciosFiltrados;
        }

        private void ActualizarCamposDetalle(Producto producto)
        {
            if(producto != null)
            {
                txtCodigo.Text = producto.Codigo;
                txtNombre.Text = producto.Nombre;
                txtDescripcion.Text = producto.Descripcion;
                lblPrecio.Text = $"Precio\n₡ {producto.Precio.ToString("#,##0.00")}\n$ {producto.Dolarizado.ToString("#,##0.00")}";
            }
        }

        private void LimpiarCamposDetalle()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            lblPrecio.Text = "Precio\n₡\n$";
            btnEliminarDetalle.Visible = false;
            cmbServicio.SelectedItem = null;
        }

        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarServicios();
        }

        private void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cliente cliente = (Cliente) cmbCliente.SelectedItem;
            if (cliente != null)
            {
                BLLBicicleta bLLBicicleta = new BLLBicicleta();
                cmbBicicleta.DataSource = bLLBicicleta.GetAllBicicletaFromCliente(cliente.ClienteId);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if(cmbServicio.SelectedItem != null)
            {
                Producto servicio = (Producto)cmbServicio.SelectedItem;
                ServiciosSeleccionados.Add(servicio);
                Servicios.Remove(servicio);
                ActualizarServicios();
                LimpiarCamposDetalle();
                ActualizarPrecioTotal();
            }
            else
            {
                MessageBox.Show("Porfavor escoja algún servicio.");
            }
            
        }

        private void dgvOrdenDetalle_Click(object sender, EventArgs e)
        {
            if (dgvOrdenDetalle.SelectedRows.Count > 0)
            {
                cmbServicio.SelectedItem = null;
                btnEliminarDetalle.Visible = true;
                ActualizarCamposDetalle((Producto)dgvOrdenDetalle.CurrentRow.DataBoundItem);
            }
        }

        private void cmbServicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnEliminarDetalle.Visible = false;
            ActualizarCamposDetalle((Producto)cmbServicio.SelectedItem);
        }

        private void btnEliminarDetalle_Click(object sender, EventArgs e)
        {
            Producto servicio = (Producto)dgvOrdenDetalle.CurrentRow.DataBoundItem;

            DialogResult respuesta = MessageBox.Show($"¿Desea eliminar el servicio: {servicio.Nombre}?", "Eliminar servicio", MessageBoxButtons.YesNo);

            if (respuesta == DialogResult.Yes)
            {
                ServiciosSeleccionados.Remove(servicio);
                Servicios.Add(servicio);
                LimpiarCamposDetalle();
                ActualizarServicios();
                ActualizarPrecioTotal();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Solo JPEG | *.jpeg";
            DialogResult resultado = openFileDialog.ShowDialog();
            if (resultado == System.Windows.Forms.DialogResult.OK)
            {
                Fotografias.Add(new OrdenFoto(openFileDialog.FileName, Image.FromFile(openFileDialog.FileName)));
            }
        }

        private void dgvFotos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvFotos.SelectedRows.Count > 0)
            {
                imgFoto.Image = ((OrdenFoto)dgvFotos.CurrentRow.DataBoundItem).Foto;
                btnEliminarFoto.Visible = true;
            }
        }

        private void btnEliminarFoto_Click(object sender, EventArgs e)
        {
            OrdenFoto foto = (OrdenFoto)dgvFotos.CurrentRow.DataBoundItem;
            DialogResult respuesta = MessageBox.Show($"¿Desea eliminar la foto con ruta: {foto.Ruta}?", "Eliminar Fotografia", MessageBoxButtons.YesNo);

            if (respuesta == DialogResult.Yes)
            {
                Fotografias.Remove(foto);
                btnEliminarFoto.Visible = false;
                imgFoto.Image=null;
                dgvFotos.ClearSelection();
            }
        }

        private void InitializeBitmap(object sender, EventArgs e)
        {
            if (signatureBitmap != null)
                signatureBitmap.Dispose();

            signatureBitmap = new Bitmap(img_Firma.ClientSize.Width, img_Firma.ClientSize.Height);
            img_Firma.Invalidate();
        }

        private void img_Firma_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDrawing = false;
            }
        }

        private void img_Firma_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                using (Graphics g = Graphics.FromImage(signatureBitmap))
                {
                    g.DrawLine(Pens.Black, lastPoint, e.Location);
                }
                lastPoint = e.Location;
                img_Firma.Invalidate();
            }
        }

        private void img_Firma_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDrawing = true;
                lastPoint = e.Location;
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            using (Graphics g = Graphics.FromImage(signatureBitmap))
            {
                g.Clear(Color.White);
            }
            img_Firma.Invalidate();
        }

        private void img_Firma_Paint(object sender, PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.DrawImage(signatureBitmap, 0, 0);
        }

        private void ActualizarPrecioTotal()
        {
            double TotalColones = ServiciosSeleccionados.Sum(p => p.Precio);
            double TotalDolares = ServiciosSeleccionados.Sum(p => p.Dolarizado);

            lblPrecioTotal.Text = $"Precio Total\n₡ {TotalColones.ToString("#,##0.00")}\n$ {TotalDolares.ToString("#,##0.00")}";
        }

        private bool Validaciones()
        {
            if (signatureBitmap == null)
            {
                MessageBox.Show("Porfavor escoja algún servicio.");
                return false;
            }
            if(cmbCliente.SelectedItem == null)
            {
                MessageBox.Show("Porfavor escoja algún cliente.");
                return false;
            }
            if (cmbBicicleta.SelectedItem == null)
            {
                MessageBox.Show("Porfavor escoja una bicicleta.");
                return false;
            }
            if(ServiciosSeleccionados.ToList().Count <= 0)
            {
                MessageBox.Show("Porfavor escoja algún servicio.");
                return false;
            }

            return true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Validaciones())
            {
                GenerarOrdenDeTrabajo();
            }
        }

        private Bitmap CloneBitmapWithWhiteBackground(Bitmap originalBitmap)
        {
            // Crear un nuevo Bitmap con las mismas dimensiones que el original
            Bitmap clonedBitmap = new Bitmap(originalBitmap.Width, originalBitmap.Height);

            // Usar Graphics para dibujar el contenido del original sobre un fondo blanco
            using (Graphics g = Graphics.FromImage(clonedBitmap))
            {
                // Rellenar el fondo con blanco
                g.Clear(Color.White);

                // Dibujar la imagen original
                g.DrawImage(originalBitmap, 0, 0);
            }

            return clonedBitmap;
        }

        private void GenerarOrdenDeTrabajo()
        {
            Cliente cliente = (Cliente)cmbCliente.SelectedItem;
            Bicicleta bicicleta = (Bicicleta)cmbBicicleta.SelectedItem;

            BikerStrikerOrdenTrabajoFacade ordenTrabajoFacade = new BikerStrikerOrdenTrabajoFacade();
            OrdenDeTrabajoFactory ordenTrabajoFactory = new OrdenDeTrabajoFactory();

            Image firma = (Image)CloneBitmapWithWhiteBackground(signatureBitmap).Clone();

            OrdenTrabajo ordenTrabajo = ordenTrabajoFactory.CrearOrdenDeTrabajo(dtpFechaInicio.Value, dtpFechaFinalizacion.Value, firma, cliente, bicicleta, ServiciosSeleccionados.ToList(), Fotografias.ToList());

            ordenTrabajoFacade.OrdenTrabajo = ordenTrabajo;

            if (ordenTrabajoFacade.GuardarOrdenTrabajo())
            {
                MessageBox.Show($"Se ha generado con exito la Orden de Trabajo #{ordenTrabajoFacade.OrdenTrabajo.Id}", "¡Proceso Exitoso!",MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (ordenTrabajoFacade.EnviarOrdenTrabajoEmail())
                {
                    MessageBox.Show($"Se ha enviado con exito la Orden de Trabajo #{ordenTrabajoFacade.OrdenTrabajo.Id} al correo {ordenTrabajoFacade.OrdenTrabajo.Cliente.Correo}", "¡Proceso Exitoso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("NO se ha podido enviar por correo la Orden de Trabajo", "¡Proceso Fallido!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("NO se ha podido generar la Orden de Trabajo", "¡Proceso Fallido!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}   
