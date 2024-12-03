using BikerStriker.Enums;
using BikerStriker.Layers.BLL;
using BikerStriker.Layers.Entities;
using BikerStriker.Layers.Reports;
using BikerStriker.Patrones;
using BikerStriker.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BikerStriker.Layers.UI.Mantenimientos
{
    public partial class frmOrdenesDeTrabajo : Form
    {
        public frmOrdenesDeTrabajo()
        {
            InitializeComponent();
            CargarElementos();
        }

        private async void CargarElementos()
        {
            BLLOrdenTrabajo bllOrdenTrabajo = new BLLOrdenTrabajo();

            Usuario uActivo = Settings.Default.Usuario;

            if (uActivo.TipoUsuario == TipoUsuario.Cliente)
            {
                BLLCliente bllCliente = new BLLCliente();
                Cliente cliente = bllCliente.GetClienteByUserID(uActivo.UsuarioId);

                dgvOrdenesTrabajo.DataSource = await bllOrdenTrabajo.GetAllOrdenTrabajoFromCliente(cliente.ClienteId);
            }
            else
            {
                dgvOrdenesTrabajo.DataSource = await bllOrdenTrabajo.GetAllOrdenTrabajo();
            }

            dgvOrdenesTrabajo.Columns["Firma"].Visible = false;

            if (dgvOrdenesTrabajo.SelectedRows.Count > 0)
            {
                ActualizarCampos((OrdenTrabajo)dgvOrdenesTrabajo.CurrentRow.DataBoundItem);
            }
        }
        private void dgvOrdenesTrabajo_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvOrdenesTrabajo.SelectedRows.Count > 0)
            {
                ActualizarCampos((OrdenTrabajo)dgvOrdenesTrabajo.CurrentRow.DataBoundItem);
            }
        }

        private void ActualizarCampos(OrdenTrabajo ordenTrabajo)
        {
            img_Firma.Image = ordenTrabajo.Firma;

            double TotalColones = ordenTrabajo.OrdenDetalle.Sum(p => p.Servicio.Precio);
            double TotalDolares = ordenTrabajo.OrdenDetalle.Sum(p => p.Servicio.Dolarizado);

            lblPrecioTotal.Text = $"Precio Total\n{TotalColones.ToString("#,##0.00")} ₡\n{TotalDolares.ToString("#,##0.00")} $";

            dgvOrdenDetalle.DataSource = ordenTrabajo.OrdenDetalle.Select(od => od.Servicio).ToList();
            dgvOrdenDetalle.Columns["Id"].Visible = false;
            dgvOrdenDetalle.Columns["Cantidad"].Visible = false;
            dgvOrdenDetalle.Columns["EsServicio"].Visible = false;
            dgvFotos.DataSource = ordenTrabajo.OrdenFoto;
            dgvFotos.Columns["Id"].Visible = false;
            dgvFotos.Columns["Ruta"].Visible = false;
        }

        private void btnEnviarCorreo_Click(object sender, EventArgs e)
        {
            BikerStrikerOrdenTrabajoFacade ordenTrabajoFacade = new BikerStrikerOrdenTrabajoFacade();
            ordenTrabajoFacade.OrdenTrabajo = (OrdenTrabajo)dgvOrdenesTrabajo.CurrentRow.DataBoundItem;


            if (ordenTrabajoFacade.EnviarOrdenTrabajoEmail())
            {
                MessageBox.Show($"Se ha enviado con exito la Orden de Trabajo #{ordenTrabajoFacade.OrdenTrabajo.Id} al correo {ordenTrabajoFacade.OrdenTrabajo.Cliente.Correo}", "¡Proceso Exitoso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("NO se ha podido enviar por correo la Orden de Trabajo", "¡Proceso Fallido!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}   
