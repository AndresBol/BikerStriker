using BikerStriker.Enums;
using BikerStriker.Layers.UI.Mantenimientos;
using BikerStriker.Layers.UI.Procesos;
using BikerStriker.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BikerStriker
{
    public partial class frmMenuPrincipal : Form
    {
        private Form currentChildForm;
        public frmMenuPrincipal()
        {
            InitializeComponent();
            pnlOrdenesTrabajo.Visible = false;
            pnlMantenimientos.Visible = false;
            btnMantenimientos.Visible = Settings.Default.Usuario.TipoUsuario == TipoUsuario.Administrador;
            lblUsuario.Text = Settings.Default.Nombre;
            AdjustLabelToLeft(lblUsuario);
        }

        private void AdjustLabelToLeft(Label label)
        {
            label.AutoSize = false;

            using (Graphics g = label.CreateGraphics())
            {
                SizeF size = g.MeasureString(label.Text, label.Font);
                int newWidth = (int)Math.Ceiling(size.Width) + 5;
                int widthDifference = newWidth - label.Width;
                label.Left -= widthDifference;
                label.Width = newWidth;
            }
        }



        private void OpenChildForm(Form childfrm)
        {
            if (currentChildForm != null) currentChildForm.Close();
        
            currentChildForm = childfrm;
            childfrm.TopLevel = false;
            childfrm.FormBorderStyle = FormBorderStyle.None;
            childfrm.Dock = DockStyle.Fill;
            pnlDesktop.Controls.Add(childfrm);
            pnlDesktop.Tag = childfrm;
            childfrm.BringToFront();
            childfrm.Show();
            lblChildFrmTitle.Text = childfrm.Text;

        }

        private void btnMantenimientos_Click(object sender, EventArgs e)
        {
            ToggleVisibilityPanels(TipoCategoriasMenu.Mantenimiento);
            btnMantenimientos.Image = pnlMantenimientos.Visible ? Properties.Resources.arrow_left : Properties.Resources.arrow_down;
        }

        private void ToggleVisibilityPanels(TipoCategoriasMenu tipo)
        {
            switch (tipo)
            {
                case TipoCategoriasMenu.Mantenimiento:
                    pnlMantenimientos.Visible = !pnlMantenimientos.Visible;
                    break;
                case TipoCategoriasMenu.OrdenTrabajo:
                    pnlOrdenesTrabajo.Visible = !pnlOrdenesTrabajo.Visible;
                    break;
                case TipoCategoriasMenu.Reporte:
                    break;
            }
        }

        private void lblUsuario_Click(object sender, EventArgs e)
        {
            CerrarSesion();
        }

        private void imgUserLogo_Click(object sender, EventArgs e)
        {
            CerrarSesion();
        }

        private void CerrarSesion()
        {
            DialogResult respuesta = MessageBox.Show("¿Desea cerrar la sesión?", "Cerrar sesión", MessageBoxButtons.YesNo);

            if (respuesta == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start(Application.ExecutablePath);
                Application.Exit();
            }
        }
        private void btnMarcas_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmMantenimientoMarca());
        }

        private void btnModelos_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmMantenimientoModelo());
        }

        private void btnAdministradores_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmMantenimientoAdministrador());
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmMantenimientoCliente());
        }

        private void btnVendedores_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmMantenimientoVendedor());
        }

        private void btnBicicletas_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmMantenimientoBicicleta());
        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmMantenimientoCategoria());
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmMantenimientoProducto());
        }

        private void btnTiendas_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmMantenimientoTienda());
        }

        private void btnTarjetas_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmMantenimientoTarjeta());
        }

        private void btnContactos_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmMantenimientoContacto());
        }

        private void btnOrdenesTrabajo_Click(object sender, EventArgs e)
        {
            ToggleVisibilityPanels(TipoCategoriasMenu.OrdenTrabajo);
            btnOrdenesTrabajo.Image = pnlOrdenesTrabajo.Visible ? Properties.Resources.arrow_left : Properties.Resources.arrow_down;
        }

        private void btnNuevaOrden_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmNuevaOT());
        }

        private void BtnVerOrdenes_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmOrdenesDeTrabajo());
        }
    }
}
