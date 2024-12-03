using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BikerStriker.Layers.Reports
{
    public partial class frmRepOrdenesTrabajo : Form
    {
        public frmRepOrdenesTrabajo()
        {
            InitializeComponent();
        }

        private void frmRepOrdenesTrabajo_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dsBikerStrikerOrdenTrabajo.OrdenTrabajo' Puede moverla o quitarla según sea necesario.
            this.ordenTrabajoTableAdapter.Fill(this.dsBikerStrikerOrdenTrabajo.OrdenTrabajo);
            this.reportViewer1.RefreshReport();
            /*
            string mimeType;
            string encoding;
            string filenameExtension;
            string[] streamids;
            Warning[] warnings;
            byte[] bytes = reportViewer1.LocalReport.Render(
            "PDF", null, out mimeType, out encoding, out filenameExtension,
            out streamids, out warnings);

            using (FileStream fs = new FileStream("C:\\Users\\Andrés Bolaños\\Desktop\\Reportes\\Output.pdf", FileMode.Create))
            {
                fs.Write(bytes, 0, bytes.Length);
            }*/
        }
    }
}
