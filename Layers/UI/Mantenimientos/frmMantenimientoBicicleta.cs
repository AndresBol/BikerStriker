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
    public partial class frmMantenimientoBicicleta : Form
    {
        private static readonly ILog _Logger = LogManager.GetLogger("MyControlEventos");
        public frmMantenimientoBicicleta()
        {
            InitializeComponent();
            LlenarCombos();
            ActualizarTabla();
            CrearBicicletaComponentes();
        }

        private void LlenarCombos()
        {
            BLLModelo bLLModelo = new BLLModelo();
            cmbModelo.DataSource = bLLModelo.GetAllModelo();

            BLLCliente bllCliente = new BLLCliente();
            cmbCliente.DataSource = bllCliente.GetAllCliente();
        }

        private void ActualizarCampos(Bicicleta bicicleta, int ClienteId)
        {
            BLLCliente bllCliente = new BLLCliente();

            txtNumeroSerie.Text = bicicleta.NumeroSerie;
            pnlColor.BackColor = bicicleta.Color;
            cmbModelo.SelectedIndex = cmbModelo.FindString(bicicleta.Modelo.ToString());
            cmbCliente.SelectedIndex = cmbCliente.FindString(bllCliente.GetClienteByID(ClienteId).ToString());
        }

        private void ActualizarTabla()
        {
            try
            {
                IBLLBicicleta bll = new BLLBicicleta();
                dgvBicicletas.DataSource = bll.GetAllBicicleta();
                dgvBicicletas.Columns["color"].Visible = false;
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
                IBLLBicicleta bll = new BLLBicicleta();
                Bicicleta bicicleta = new Bicicleta();
                bicicleta.NumeroSerie = txtNumeroSerie.Text;
                bicicleta.Color = pnlColor.BackColor;
                bicicleta.Modelo = (Modelo) cmbModelo.SelectedItem;

                if(dgvBicicletas.SelectedRows.Count > 0)
                {
                    bicicleta.Id = ((Bicicleta)dgvBicicletas.CurrentRow.DataBoundItem).Id;
                }

                bll.Save(bicicleta, ((Cliente) cmbCliente.SelectedItem).ClienteId);
                ActualizarTabla();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ooops: {ex.Message}");
                throw;
            }
        }

        private void dgvBicicletas_SelectionChanged(object sender, EventArgs e)
        {
            IBLLBicicleta bll = new BLLBicicleta();
            Bicicleta bicicleta = (Bicicleta)dgvBicicletas.CurrentRow.DataBoundItem;
            ActualizarCampos(bicicleta, bll.GetClientIdFromId(bicicleta.Id));
            EditarBicicletaComponentes();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            dgvBicicletas.ClearSelection();
            CrearBicicletaComponentes();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            IBLLBicicleta bll = new BLLBicicleta();
            bll.Remove(((Bicicleta)dgvBicicletas.CurrentRow.DataBoundItem).Id);
            ActualizarTabla();
        }

        private void CrearBicicletaComponentes()
        {
            lblSubtitulo.Text = "Añadir Bicicleta";
            btnEliminar.Visible = false;
            txtNumeroSerie.Text = "";
            pnlColor.BackColor = Color.White;
            cmbModelo.SelectedIndex = 0;
            cmbCliente.SelectedIndex = 0;
            btnAdd.Visible = false;
        }
        private void EditarBicicletaComponentes()
        {
            lblSubtitulo.Text = "Editar Bicicleta";
            btnEliminar.Visible = true;
            btnAdd.Visible = true;
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            colorDialog.AllowFullOpen = true;
            colorDialog.Color = pnlColor.BackColor;
            colorDialog.FullOpen = true;
            colorDialog.AnyColor = true;
            if(colorDialog.ShowDialog() == DialogResult.OK)
            {
                pnlColor.BackColor = colorDialog.Color;
            }
        }
    }
}
