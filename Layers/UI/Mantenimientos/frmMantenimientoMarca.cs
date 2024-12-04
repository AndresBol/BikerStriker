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
    public partial class frmMantenimientoMarca : Form
    {
        private static readonly ILog _Logger = LogManager.GetLogger("MyControlEventos");
        public frmMantenimientoMarca()
        {
            InitializeComponent();
            ActualizarTabla();
            CrearMarcaComponentes();
        }

        private void ActualizarCampos(Marca marca)
        {
            txtNombre.Text = marca.Nombre;
            imgLogo.Image = marca.Logo;
        }

        private void ActualizarTabla()
        {
            try
            {
                IBLLMarca bll = new BLLMarca();
                dgvMarcas.DataSource = bll.GetAllMarca();
                dgvMarcas.Columns["Logo"].Visible = false;
            }
            catch (Exception ex)
            {
                _Logger.ErrorFormat("Error {0}", ex.Message);
                MessageBox.Show($"Ha sucedido un error: \n{ex.Message}");
                throw;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Solo JPEG | *.jpeg";
            DialogResult resultado = openFileDialog.ShowDialog();
            if (resultado == System.Windows.Forms.DialogResult.OK)
            {
                txtLogo.Visible = true;
                txtLogo.Text = openFileDialog.FileName;
                imgLogo.Image = Image.FromFile(openFileDialog.FileName);
            }
        }

        private bool Validaciones()
        {
            if (txtNombre.Text == "")
            {
                MessageBox.Show("Porfavor digite un nombre");
                return false;
            }
            if(imgLogo.Image == null)
            {
                MessageBox.Show("Porfavor digite un logo");
                return false;
            }
            return true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Validaciones())
            {
                try
                {
                    IBLLMarca bll = new BLLMarca();
                    Marca marca = new Marca();
                    marca.Nombre = txtNombre.Text;
                    marca.Logo = imgLogo.Image;

                    if (dgvMarcas.SelectedRows.Count > 0)
                    {
                        marca.Id = ((Marca)dgvMarcas.CurrentRow.DataBoundItem).Id;
                    }

                    bll.Save(marca);
                    ActualizarTabla();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ooops: {ex.Message}");
                    throw;
                }
            }
        }

        private void dgvMarcas_SelectionChanged(object sender, EventArgs e)
        {
            ActualizarCampos((Marca)dgvMarcas.CurrentRow.DataBoundItem);
            EditarMarcaComponentes();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            dgvMarcas.ClearSelection();
            CrearMarcaComponentes();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            IBLLMarca bll = new BLLMarca();
            bll.Remove(((Marca)dgvMarcas.CurrentRow.DataBoundItem).Id);
            ActualizarTabla();
        }

        private void CrearMarcaComponentes()
        {
            lblSubtitulo.Text = "Añadir Marca";
            btnEliminar.Visible = false;
            txtNombre.Text = "";
            txtLogo.Text = "";
            txtLogo.Visible = false;
            imgLogo.Image = null;
            btnAdd.Visible = false;
        }
        private void EditarMarcaComponentes()
        {
            lblSubtitulo.Text = "Editar Marca";
            txtLogo.Text = "";
            txtLogo.Visible = false;
            btnEliminar.Visible = true;
            btnAdd.Visible = true;
        }

    }
}
