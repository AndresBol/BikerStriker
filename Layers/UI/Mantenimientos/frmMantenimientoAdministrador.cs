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
    public partial class frmMantenimientoAdministrador : Form
    {
        private static readonly ILog _Logger = LogManager.GetLogger("MyControlEventos");
        public frmMantenimientoAdministrador()
        {
            InitializeComponent();
            ActualizarTabla();
            CrearAdministradorComponentes();
        }

        private void ActualizarCampos(Administrador administrador)
        {
            txtCorreo.Text = administrador.Correo;
            txtContrasena.Text = administrador.Contraseña;
            txtNombre.Text = administrador.Nombre;
            txtApellidos.Text = administrador.Apellidos;
        }

        private void ActualizarTabla()
        {
            try
            {
                IBLLAdministrador bll = new BLLAdministrador();
                dgvAdministradores.DataSource = bll.GetAllAdministrador();
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
            if (txtCorreo.Text == "")
            {
                MessageBox.Show("Porfavor digite un correo");
                return false;
            }

            if (!txtCorreo.Text.Contains('@'))
            {
                MessageBox.Show("Porfavor digite un correo valido");
                return false;
            }
            if (txtContrasena.Text == "")
            {
                MessageBox.Show("Porfavor digite una contraseña");
                return false;
            }
            if (txtNombre.Text == "")
            {
                MessageBox.Show("Porfavor digite un Nombre");
                return false;
            }
            if (txtApellidos.Text == "")
            {
                MessageBox.Show("Porfavor digite los Apellidos");
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
                    IBLLAdministrador bll = new BLLAdministrador();
                    Administrador administrador = new Administrador();
                    administrador.Correo = txtCorreo.Text;
                    administrador.Contraseña = txtContrasena.Text;
                    administrador.Nombre = txtNombre.Text;
                    administrador.Apellidos = txtApellidos.Text;

                    if (dgvAdministradores.SelectedRows.Count > 0)
                    {
                        administrador.UsuarioId = ((Administrador)dgvAdministradores.CurrentRow.DataBoundItem).UsuarioId;
                    }

                    bll.Save(administrador);
                    ActualizarTabla();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ooops: {ex.Message}");
                    throw;
                }
            }
        }

        private void dgvAdministradors_SelectionChanged(object sender, EventArgs e)
        {
            ActualizarCampos((Administrador)dgvAdministradores.CurrentRow.DataBoundItem);
            EditarAdministradorComponentes();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            dgvAdministradores.ClearSelection();
            CrearAdministradorComponentes();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            IBLLAdministrador bll = new BLLAdministrador();
            bll.Remove(((Administrador)dgvAdministradores.CurrentRow.DataBoundItem).UsuarioId);
            ActualizarTabla();
        }

        private void CrearAdministradorComponentes()
        {
            lblSubtitulo.Text = "Añadir Administrador";
            btnEliminar.Visible = false;
            txtNombre.Text = "";
            txtApellidos.Text = "";
            txtCorreo.Text = "";
            txtContrasena.Text = "";
            btnAdd.Visible = false;
        }
        private void EditarAdministradorComponentes()
        {
            lblSubtitulo.Text = "Editar Administrador";
            btnEliminar.Visible = true;
            btnAdd.Visible = true;
        }

    }
}
