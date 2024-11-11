using BikerStriker.Enums;
using BikerStriker.Layers.UI.Mantenimientos;
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
            pnlMantenimientos.Visible = false;
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
            btnMantenimientos.Image = btnMarcas.Visible ? Properties.Resources.arrow_left : Properties.Resources.arrow_down;
        }

        private void ToggleVisibilityPanels(TipoCategoriasMenu tipo)
        {
            switch (tipo)
            {
                case TipoCategoriasMenu.Mantenimiento:
                    pnlMantenimientos.Visible = !pnlMantenimientos.Visible;
                    break;
                case TipoCategoriasMenu.Reporte:
                    break;
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
    }
}
