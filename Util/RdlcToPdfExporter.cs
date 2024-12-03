using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Reporting.WinForms;
using System.Windows.Forms;

//string rdlcPath = "C:\\Users\\Andrés Bolaños\\Desktop\\Proyecto_Progra3\\BikerStriker\\Layers\\Reports\\repOrdenTrabajo.rdlc";
//string dataSourceName = "DataSetOrdenTrabajo";

namespace BikerStriker.Util
{ 
    public static class RdlcToPdfExporter
    {
        public static void ExportRdlcToPdf(object dataSource)
        {
            string rdlcPath = "C:\\Users\\Andrés Bolaños\\Desktop\\Proyecto_Progra3\\BikerStriker\\Layers\\Reports\\repOrdenTrabajo.rdlc";
            string dataSourceName = "DataSetOrdenTrabajo";
            string outputPdfPath = "C:\\Users\\Andrés Bolaños\\Desktop\\Reportes\\RepOutput.pdf";

            // Ensure the RDLC file exists
            if (!File.Exists(rdlcPath))
            {
                throw new FileNotFoundException("RDLC file not found.", rdlcPath);
            }

            // Create the LocalReport object
            LocalReport report = new LocalReport
            {
                ReportPath = rdlcPath
            };

            // Add the data source
            report.DataSources.Clear();
            report.DataSources.Add(new ReportDataSource(dataSourceName, dataSource));

            // Render the report to a PDF
            string mimeType, encoding, fileNameExtension;
            string[] streams;
            Warning[] warnings;

            byte[] pdfBytes = report.Render(
                "PDF", // Specify the output format as PDF
                null,  // Use default device info settings
                out mimeType,
                out encoding,
                out fileNameExtension,
                out streams,
                out warnings
            );

            // Save the PDF to the specified file path
            using (FileStream fs = new FileStream(outputPdfPath, FileMode.Create))
            {
                fs.Write(pdfBytes, 0, pdfBytes.Length);
            }

            MessageBox.Show($"PDF successfully exported to: {outputPdfPath}");
        }
    }

}
