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
    public partial class frmMantenimientoModelo : Form
    {
        private static readonly ILog _Logger = LogManager.GetLogger("MyControlEventos");
        public frmMantenimientoModelo()
        {
            InitializeComponent();
            LlenarCombos();
            ActualizarTabla();
            CrearModeloComponentes();
        }

        private void LlenarCombos()
        {
            BLLMarca bLLMarca = new BLLMarca();
            cmbMarca.DataSource = bLLMarca.GetAllMarca();
        }

        private void ActualizarCampos(Modelo modelo)
        {
            txtNombre.Text = modelo.Nombre;
            cmbMarca.SelectedIndex = cmbMarca.FindString(modelo.Marca.ToString());
        }

        private void ActualizarTabla()
        {
            try
            {
                IBLLModelo bll = new BLLModelo();
                dgvModelos.DataSource = bll.GetAllModelo();
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
                IBLLModelo bll = new BLLModelo();
                Modelo modelo = new Modelo();
                modelo.Nombre = txtNombre.Text;
                modelo.Marca = (Marca) cmbMarca.SelectedItem;

                if(dgvModelos.SelectedRows.Count > 0)
                {
                    modelo.Id = ((Modelo)dgvModelos.CurrentRow.DataBoundItem).Id;
                }

                bll.Save(modelo);
                ActualizarTabla();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ooops: {ex.Message}");
                throw;
            }
        }

        private void dgvModelos_SelectionChanged(object sender, EventArgs e)
        {
            ActualizarCampos((Modelo)dgvModelos.CurrentRow.DataBoundItem);
            EditarModeloComponentes();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            dgvModelos.ClearSelection();
            CrearModeloComponentes();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            IBLLModelo bll = new BLLModelo();
            bll.Remove(((Modelo)dgvModelos.CurrentRow.DataBoundItem).Id);
            ActualizarTabla();
        }

        private void CrearModeloComponentes()
        {
            lblSubtitulo.Text = "Añadir Modelo";
            btnEliminar.Visible = false;
            txtNombre.Text = "";
            cmbMarca.SelectedIndex = 0;
            btnAdd.Visible = false;
        }
        private void EditarModeloComponentes()
        {
            lblSubtitulo.Text = "Editar Modelo";
            btnEliminar.Visible = true;
            btnAdd.Visible = true;
        }
    }
}
