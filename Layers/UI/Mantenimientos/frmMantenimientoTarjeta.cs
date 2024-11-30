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
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BikerStriker.Layers.UI.Mantenimientos
{
    public partial class frmMantenimientoTarjeta : Form
    {
        private static readonly ILog _Logger = LogManager.GetLogger("MyControlEventos");
        public frmMantenimientoTarjeta()
        {
            InitializeComponent();
            LlenarCombos();
            ActualizarTabla();
            CrearTarjetaComponentes();
        }

        private void LlenarCombos()
        {
            cmbTipoTarjeta.DataSource = Enum.GetValues(typeof(TipoTarjeta));

            BLLCliente bllCliente = new BLLCliente();
            cmbCliente.DataSource = bllCliente.GetAllCliente();
        }

        private void ActualizarCampos(Tarjeta tarjeta, int ClienteId)
        {
            BLLCliente bllCliente = new BLLCliente();
            txtNumero.Text = tarjeta.Numero;
            dtpFechaVencimiento.Value = tarjeta.FechaVencimiento;
            nudCodigoSeguridad.Value = tarjeta.CodigoSeguridad;
            cmbTipoTarjeta.SelectedItem = tarjeta.TipoTarjeta;
            cmbCliente.SelectedIndex = cmbCliente.FindString(bllCliente.GetClienteByID(ClienteId).ToString());
        }

        private void ActualizarTabla()
        {
            try
            {
                IBLLTarjeta bll = new BLLTarjeta();
                dgvTarjetas.DataSource = bll.GetAllTarjeta();
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
                IBLLTarjeta bll = new BLLTarjeta();
                Tarjeta tarjeta = new Tarjeta();
                tarjeta.Numero = txtNumero.Text;
                tarjeta.FechaVencimiento = dtpFechaVencimiento.Value;
                tarjeta.CodigoSeguridad = (short) nudCodigoSeguridad.Value;
                tarjeta.TipoTarjeta = (TipoTarjeta) cmbTipoTarjeta.SelectedItem;

                if (dgvTarjetas.SelectedRows.Count > 0)
                {
                    tarjeta.Id = ((Tarjeta)dgvTarjetas.CurrentRow.DataBoundItem).Id;
                }

                bll.Save(tarjeta, ((Cliente) cmbCliente.SelectedItem).ClienteId);
                ActualizarTabla();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ooops: {ex.Message}");
                throw;
            }
        }   

        private void dgvTarjetas_SelectionChanged(object sender, EventArgs e)
        {
            IBLLTarjeta bll = new BLLTarjeta();
            Tarjeta tarjeta = (Tarjeta)dgvTarjetas.CurrentRow.DataBoundItem;
            ActualizarCampos(tarjeta, bll.GetClientIdFromId(tarjeta.Id));
            EditarTarjetaComponentes();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            dgvTarjetas.ClearSelection();
            CrearTarjetaComponentes();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            IBLLTarjeta bll = new BLLTarjeta();
            bll.Remove(((Tarjeta)dgvTarjetas.CurrentRow.DataBoundItem).Id);
            ActualizarTabla();
        }

        private void CrearTarjetaComponentes()
        {
            lblSubtitulo.Text = "Añadir Tarjeta";
            btnEliminar.Visible = false;
            txtNumero.Text = "";
            dtpFechaVencimiento.Value = DateTime.Now;
            nudCodigoSeguridad.Value = 111;
            cmbTipoTarjeta.SelectedIndex = 0;
            cmbCliente.SelectedIndex = 0;
            btnAdd.Visible = false;
        }
        private void EditarTarjetaComponentes()
        {
            lblSubtitulo.Text = "Editar Tarjeta";
            btnEliminar.Visible = true;
            btnAdd.Visible = true;
        }
    }
}
