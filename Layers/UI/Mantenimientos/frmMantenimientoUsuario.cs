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
    public partial class frmMantenimientoUsuario : Form
    {
        private static readonly ILog _Logger = LogManager.GetLogger("MyControlEventos");
        public frmMantenimientoUsuario()
        {
            InitializeComponent();
            ActualizarTabla();
            CrearUsuarioComponentes();
        }

        private void ActualizarCampos(Usuario usuario)
        {
            txtNombre.Text = usuario.Nombre;
        }

        private void ActualizarTabla()
        {
            try
            {
                IBLLUsuario bll = new BLLUsuario();
                dgvUsuarios.DataSource = bll.GetAllUsuario();
                dgvUsuarios.Columns["Logo"].Visible = false;
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
                IBLLUsuario bll = new BLLUsuario();
                /*Usuario usuario = new Usuario();
                usuario.Nombre = txtNombre.Text;

                if(dgvUsuarios.SelectedRows.Count > 0)
                {
                    usuario.Id = ((Usuario)dgvUsuarios.CurrentRow.DataBoundItem).Id;
                }

                bll.Save(usuario);*/
                ActualizarTabla();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ooops: {ex.Message}");
                throw;
            }
        }

        private void dgvUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            ActualizarCampos((Usuario)dgvUsuarios.CurrentRow.DataBoundItem);
            EditarUsuarioComponentes();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            dgvUsuarios.ClearSelection();
            CrearUsuarioComponentes();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            IBLLUsuario bll = new BLLUsuario();
            //bll.Remove(((Usuario)dgvUsuarios.CurrentRow.DataBoundItem).Id);
            ActualizarTabla();
        }

        private void CrearUsuarioComponentes()
        {
            lblSubtitulo.Text = "Añadir Usuario";
            btnEliminar.Visible = false;
            txtNombre.Text = "";
            txtCorreo.Text = "";
            txtCorreo.Visible = false;
            btnAdd.Visible = false;
        }
        private void EditarUsuarioComponentes()
        {
            lblSubtitulo.Text = "Editar Usuario";
            txtCorreo.Text = "";
            txtCorreo.Visible = false;
            btnEliminar.Visible = true;
            btnAdd.Visible = true;
        }

    }
}
