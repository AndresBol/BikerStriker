using BikerStriker.Interfaces;
using BikerStriker.Layers.BLL;
using BikerStriker.Layers.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BikerStriker.Layers.UI.Mantenimientos
{
    public partial class frmMantenimientoMarca : Form
    {
        public frmMantenimientoMarca()
        {
            InitializeComponent();
        }

        private void ActualizarImagen()
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Solo JPEG | *.jpeg";
            DialogResult resultado = openFileDialog.ShowDialog();
            if (resultado == System.Windows.Forms.DialogResult.OK)
            {
                txtLogo.Text = openFileDialog.FileName;
                imgLogo.Image = Image.FromFile(openFileDialog.FileName);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            try
            {
                IBLLMarca bll = new BLLMarca();
                Marca marca = new Marca();
                marca.Nombre = txtNombre.Text;
                marca.Logo = imgLogo.Image;

                bll.Save(marca);
                //ActualizarTabla();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ooops: {ex.Message}");
                throw;
            }
        }
    }
}
