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
    public partial class frmMantenimientoContacto : Form
    {
        private static readonly ILog _Logger = LogManager.GetLogger("MyControlEventos");
        public frmMantenimientoContacto()
        {
            InitializeComponent();
            LlenarCombos();
            ActualizarTabla();
            CrearContactoComponentes();
        }

        private void LlenarCombos()
        {
            BLLCliente bllCliente = new BLLCliente();
            cmbCliente.DataSource = bllCliente.GetAllCliente();
        }

        private void ActualizarCampos(Contacto contacto, int ClienteId)
        {
            BLLCliente bllCliente = new BLLCliente();
            txtTelefono.Text = contacto.Telefono;
            cmbCliente.SelectedIndex = cmbCliente.FindString(bllCliente.GetClienteByID(ClienteId).ToString());
        }

        private void ActualizarTabla()
        {
            try
            {
                IBLLContacto bll = new BLLContacto();
                dgvContactos.DataSource = bll.GetAllContacto();
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
                IBLLContacto bll = new BLLContacto();
                Contacto contacto = new Contacto();
                contacto.Telefono = txtTelefono.Text;

                if (dgvContactos.SelectedRows.Count > 0)
                {
                    contacto.Id = ((Contacto)dgvContactos.CurrentRow.DataBoundItem).Id;
                }

                bll.Save(contacto, ((Cliente) cmbCliente.SelectedItem).ClienteId);
                ActualizarTabla();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ooops: {ex.Message}");
                throw;
            }
        }   

        private void dgvContactos_SelectionChanged(object sender, EventArgs e)
        {
            IBLLContacto bll = new BLLContacto();
            Contacto contacto = (Contacto)dgvContactos.CurrentRow.DataBoundItem;
            ActualizarCampos(contacto, bll.GetClientIdFromId(contacto.Id));
            EditarContactoComponentes();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            dgvContactos.ClearSelection();
            CrearContactoComponentes();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            IBLLContacto bll = new BLLContacto();
            bll.Remove(((Contacto)dgvContactos.CurrentRow.DataBoundItem).Id);
            ActualizarTabla();
        }

        private void CrearContactoComponentes()
        {
            lblSubtitulo.Text = "Añadir Contacto";
            btnEliminar.Visible = false;
            txtTelefono.Text = "";
            cmbCliente.SelectedIndex = 0;
            btnAdd.Visible = false;
        }
        private void EditarContactoComponentes()
        {
            lblSubtitulo.Text = "Editar Contacto";
            btnEliminar.Visible = true;
            btnAdd.Visible = true;
        }
    }
}
