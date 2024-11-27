using BikerStriker.Enums;
using BikerStriker.Interfaces;
using BikerStriker.Layers.BLL;
using BikerStriker.Layers.Entities;
using BikerStriker.Util;
using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BikerStriker.Layers.UI.Mantenimientos
{
    public partial class frmMantenimientoCliente : Form
    {
        private static readonly ILog _Logger = LogManager.GetLogger("MyControlEventos");

        private CR_DirectorioApiHelper Cr_Directorio = new CR_DirectorioApiHelper();
        public frmMantenimientoCliente()
        {
            InitializeComponent();
        }

        private async void frmMantenimientoCliente_Load(object sender, EventArgs e)
        {
            await Inicializar();
            cmbGenero.DataSource = Enum.GetValues(typeof(TipoGenero));
            ActualizarTabla();
        }

        public async Task Inicializar()
        {
            await Cr_Directorio.LlenarListasAsync();

            cmbProvincia.DataSource = Cr_Directorio.Provincias;
        }


        private void ActualizarCampos(Cliente cliente)
        {
            txtCorreo.Text = cliente.Correo;
            txtContrasena.Text = cliente.Contraseña;
            
            string[] direccion = cliente.Direccion.Split(',');

            cmbProvincia.SelectedIndex = cmbProvincia.FindString(direccion[0]);
            cmbCanton.SelectedIndex = cmbCanton.FindString(direccion[1]);
            cmbDistrito.SelectedIndex = cmbDistrito.FindString(direccion[2]);

            txtIdentificacion.Text = cliente.Identificacion;
            txtNombre.Text = cliente.Nombre;
            txtApellidos.Text = cliente.Apellidos;
            cmbGenero.SelectedItem = cliente.Genero;
        }

        private void ActualizarTabla()
        {
            try
            {
                IBLLCliente bll = new BLLCliente();
                dgvClientes.DataSource = bll.GetAllCliente();
                dgvClientes.Columns["Direccion"].Visible = false;
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
                IBLLCliente bll = new BLLCliente();
                Cliente cliente = new Cliente();
                cliente.Correo = txtCorreo.Text;
                cliente.Contraseña = txtContrasena.Text;
                cliente.Direccion = $"{cmbProvincia.SelectedItem},{cmbCanton.SelectedItem},{cmbDistrito.SelectedItem}";
                cliente.Identificacion = txtIdentificacion.Text;
                cliente.Nombre = txtNombre.Text;
                cliente.Apellidos = txtApellidos.Text;
                cliente.Genero = (TipoGenero) cmbGenero.SelectedItem;

                if(dgvClientes.SelectedRows.Count > 0)
                {
                    Cliente vCliente = (Cliente)dgvClientes.CurrentRow.DataBoundItem;
                    cliente.UsuarioId = vCliente.UsuarioId;
                    cliente.ClienteId = vCliente.ClienteId;
                }

                bll.Save(cliente);
                ActualizarTabla();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ooops: {ex.Message}");
                throw;
            }
        }

        private void dgvClientes_SelectionChanged(object sender, EventArgs e)
        {
            ActualizarCampos((Cliente)dgvClientes.CurrentRow.DataBoundItem);
            EditarClienteComponentes();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            dgvClientes.ClearSelection();
            CrearClienteComponentes();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Cliente cliente = ((Cliente)dgvClientes.CurrentRow.DataBoundItem);

            IBLLCliente cBLL = new BLLCliente();
            cBLL.Remove(cliente.ClienteId);

            IBLLUsuario uBLL = new BLLUsuario();
            uBLL.Remove(cliente.UsuarioId);

            ActualizarTabla();
        }

        private void CrearClienteComponentes()
        {
            lblSubtitulo.Text = "Añadir Cliente";
            btnEliminar.Visible = false;
            txtIdentificacion.Text = "";
            txtNombre.Text = "";
            txtApellidos.Text = "";
            cmbGenero.SelectedIndex = 0;
            //ActualizarProvincias();
            txtCorreo.Text = "";
            txtContrasena.Text = "";
            btnAdd.Visible = false;
        }
        private void EditarClienteComponentes()
        {
            lblSubtitulo.Text = "Editar Cliente";
            btnEliminar.Visible = true;
            btnAdd.Visible = true;
        }

        private async void txtIdentificacion_TextChanged(object sender, EventArgs e)
        {
            string cedula = txtIdentificacion.Text;

            if (Regex.IsMatch(cedula, @"^\d-\d{4}-\d{4}$"))
            {
                string nombre = await HaciendaApiHelper.ObtenerNombrePorCedulaAsync(cedula.Replace("-", ""));
                
                if(nombre != null)
                {
                    string[] nombreSegmentado = nombre.Split(' ');

                    for (int i = 0; i < nombreSegmentado.Length; i++)
                    {
                        nombreSegmentado[i] = char.ToUpper(nombreSegmentado[i][0]) + nombreSegmentado[i].Substring(1).ToLower();
                    }
                    
                    if(nombreSegmentado.Length >= 4)
                    {
                        txtNombre.Text = $"{nombreSegmentado[0]} {nombreSegmentado[1]}";
                        txtApellidos.Text = $"{nombreSegmentado[2]} {nombreSegmentado[3]}";
                    }
                    else
                    {
                        txtNombre.Text = $"{nombreSegmentado[0]}";
                        txtApellidos.Text = $"{nombreSegmentado[1]} {nombreSegmentado[2]}";
                    }
                }
            }
        }

        private void cmbProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cantonesFiltrados = Cr_Directorio.Cantones
                    .Where(c => c.Provincia.Id == ((Provincia) cmbProvincia.SelectedItem).Id)
                    .ToList();

            cmbCanton.DataSource = cantonesFiltrados;
        }
        private void cmbCanton_SelectedIndexChanged(object sender, EventArgs e)
        {
            var distritosFiltrados = Cr_Directorio.Distritos
                   .Where(d => d.Canton.Id == ((Canton)cmbCanton.SelectedItem).Id)
                   .ToList();

            cmbDistrito.DataSource = distritosFiltrados;
        }
    }
}
