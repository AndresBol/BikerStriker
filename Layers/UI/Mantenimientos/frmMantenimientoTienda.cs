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
    public partial class frmMantenimientoTienda : Form
    {
        private static readonly ILog _Logger = LogManager.GetLogger("MyControlEventos");
        public frmMantenimientoTienda()
        {
            InitializeComponent();
            ActualizarTabla();
            CrearTiendaComponentes();
        }

        private void ActualizarCampos(Tienda tienda)
        {
            txtCedulaJuridica.Text = tienda.CedulaJuridica;
            txtNombre.Text = tienda.Nombre;
            txtTelefono.Text = tienda.Telefono;
            txtDireccion.Text = tienda.Direccion;
            nudImpuestoVenta.Value = (decimal) tienda.ImpuestoVenta;
        }

        private void ActualizarTabla()
        {
            try
            {
                IBLLTienda bll = new BLLTienda();
                dgvTiendas.DataSource = bll.GetAllTienda();
                dgvTiendas.Columns["Direccion"].Visible = false;
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
                IBLLTienda bll = new BLLTienda();
                Tienda tienda = new Tienda();
                tienda.CedulaJuridica = txtCedulaJuridica.Text;
                tienda.Nombre = txtNombre.Text;
                tienda.Telefono = txtTelefono.Text;
                tienda.Direccion = txtDireccion.Text;
                tienda.ImpuestoVenta = (double) nudImpuestoVenta.Value;

                if(dgvTiendas.SelectedRows.Count > 0)
                {
                    tienda.Id = ((Tienda)dgvTiendas.CurrentRow.DataBoundItem).Id;
                }

                bll.Save(tienda);
                ActualizarTabla();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ooops: {ex.Message}");
                throw;
            }
        }

        private void dgvTiendas_SelectionChanged(object sender, EventArgs e)
        {
            ActualizarCampos((Tienda)dgvTiendas.CurrentRow.DataBoundItem);
            EditarTiendaComponentes();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            dgvTiendas.ClearSelection();
            CrearTiendaComponentes();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            IBLLTienda bll = new BLLTienda();
            bll.Remove(((Tienda)dgvTiendas.CurrentRow.DataBoundItem).Id);
            ActualizarTabla();
        }

        private void CrearTiendaComponentes()
        {
            lblSubtitulo.Text = "Añadir Tienda";
            btnEliminar.Visible = false;
            btnAdd.Visible = false;
            txtCedulaJuridica.Text = "";
            txtNombre.Text = "";
            txtTelefono.Text = "";
            txtDireccion.Text = "";
            nudImpuestoVenta.Value = 1;
        }
        private void EditarTiendaComponentes()
        {
            lblSubtitulo.Text = "Editar Tienda";
            btnEliminar.Visible = true;
            btnAdd.Visible = true;
        }

    }
}
