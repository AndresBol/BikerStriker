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
    public partial class frmMantenimientoCategoria : Form
    {
        private static readonly ILog _Logger = LogManager.GetLogger("MyControlEventos");
        public frmMantenimientoCategoria()
        {
            InitializeComponent();
            ActualizarTabla();
            CrearCategoriaComponentes();
        }

        private void ActualizarCampos(Categoria categoria)
        {
            txtNombre.Text = categoria.Nombre;
        }

        private void ActualizarTabla()
        {
            try
            {
                IBLLCategoria bll = new BLLCategoria();
                dgvCategorias.DataSource = bll.GetAllCategoria();
            }
            catch (Exception ex)
            {
                _Logger.ErrorFormat("Error {0}", ex.Message);
                MessageBox.Show($"Ha sucedido un error: \n{ex.Message}");
                throw;
            }
        }

        private bool Validaciones()
        {
            if (txtNombre.Text == "")
            {
                MessageBox.Show("Porfavor digite un nombre");
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
                    IBLLCategoria bll = new BLLCategoria();
                    Categoria categoria = new Categoria();
                    categoria.Nombre = txtNombre.Text;

                    if (dgvCategorias.SelectedRows.Count > 0)
                    {
                        categoria.Id = ((Categoria)dgvCategorias.CurrentRow.DataBoundItem).Id;
                    }

                    bll.Save(categoria);
                    ActualizarTabla();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ooops: {ex.Message}");
                    throw;
                }
            }
            
        }

        private void dgvCategorias_SelectionChanged(object sender, EventArgs e)
        {
            ActualizarCampos((Categoria)dgvCategorias.CurrentRow.DataBoundItem);
            EditarCategoriaComponentes();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            dgvCategorias.ClearSelection();
            CrearCategoriaComponentes();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            IBLLCategoria bll = new BLLCategoria();
            bll.Remove(((Categoria)dgvCategorias.CurrentRow.DataBoundItem).Id);
            ActualizarTabla();
        }

        private void CrearCategoriaComponentes()
        {
            lblSubtitulo.Text = "Añadir Categoria";
            btnEliminar.Visible = false;
            txtNombre.Text = "";
            btnAdd.Visible = false;
        }
        private void EditarCategoriaComponentes()
        {
            lblSubtitulo.Text = "Editar Categoria";
            btnEliminar.Visible = true;
            btnAdd.Visible = true;
        }

    }
}
