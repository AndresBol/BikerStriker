using BikerStriker.Layers.BLL;
using BikerStriker.Layers.Entities;
using BikerStriker.Layers.Reports;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel.MsmqIntegration;
using MimeKit;
using MailKit.Security;
using MailKit.Net.Smtp;
using System.Xml;

namespace BikerStriker.Patrones
{
    public class BikerStrikerFacturaFacade
    {
        public Factura Factura { get; set; }

        public bool GuardarFactura()
        {
            BLLFactura bLLFactura = new BLLFactura();
            BLLFacturaDetalle bllFacturaDetalle = new BLLFacturaDetalle();

            bLLFactura.Save(Factura, GenerarXML());

            Factura.Id = bLLFactura.GetIdFactura(Factura);

            if(Factura.Id != -1)
            {
                foreach (var fDetalle in Factura.FacturaDetalle)
                {
                    bllFacturaDetalle.Save(fDetalle, Factura.Id);
                }

            }

            return Factura.Id != -1;
        }

        private XmlDocument GenerarXML()
        {
            XmlDocument xmlDoc = new XmlDocument();

            xmlDoc.LoadXml("<BikerStrikerFactura></BikerStrikerFactura>");
            xmlDoc.DocumentElement.SetAttribute("TotalColones", Factura.TotalColones.ToString("#,##0.00"));
            xmlDoc.DocumentElement.SetAttribute("TotalDolares", Factura.TotalDolares.ToString("#,##0.00"));

            XmlElement nNumeroFactura = xmlDoc.CreateElement("NumeroFactura");
            nNumeroFactura.InnerText = Factura.Id.ToString();

            XmlElement nCliente = xmlDoc.CreateElement("Cliente");
            nCliente.SetAttribute("Identificacion", Factura.Cliente.Identificacion);
            nCliente.InnerText = Factura.Cliente.ToString();

            XmlElement nTarjeta = xmlDoc.CreateElement("Tarjeta");
            nTarjeta.SetAttribute("Tipo", Factura.Tarjeta.TipoTarjeta.ToString());
            nTarjeta.InnerText = Factura.Tarjeta.Numero;
            nCliente.AppendChild(nTarjeta);

            xmlDoc.DocumentElement.AppendChild(nNumeroFactura);
            xmlDoc.DocumentElement.AppendChild(nCliente);

            if (Factura.OrdenTrabajo != null)
            {
                XmlElement nOrdenDeTrabajo = xmlDoc.CreateElement("OrdenDeTrabajo");
                nOrdenDeTrabajo.SetAttribute("FechaInicio", Factura.OrdenTrabajo.FechaInicio.ToShortDateString());
                nOrdenDeTrabajo.SetAttribute("FechaFinalizacion", Factura.OrdenTrabajo.FechaFinalizacion.ToShortDateString());

                XmlElement nBicicleta = xmlDoc.CreateElement("Bicicleta");
                nBicicleta.SetAttribute("NumeroSerie", Factura.OrdenTrabajo.Bicicleta.NumeroSerie);
                nBicicleta.InnerText = $"{Factura.OrdenTrabajo.Bicicleta.Modelo.Marca.Nombre} {Factura.OrdenTrabajo.Bicicleta.Modelo.Nombre}";
                nOrdenDeTrabajo.AppendChild(nBicicleta);

                foreach (OrdenDetalle ordenDetalle in Factura.OrdenTrabajo.OrdenDetalle)
                {
                    XmlElement nServicio = xmlDoc.CreateElement("Servicio");
                    nServicio.SetAttribute("PrecioColones", ordenDetalle.Servicio.Precio.ToString());
                    nServicio.SetAttribute("PrecioDolares", ordenDetalle.Servicio.Dolarizado.ToString());
                    nServicio.InnerText = ordenDetalle.Servicio.Nombre;

                    nOrdenDeTrabajo.AppendChild(nServicio);
                }
                xmlDoc.DocumentElement.AppendChild(nOrdenDeTrabajo);
            }

            if (Factura.FacturaDetalle != null)
            {
                XmlElement nDetalleFactura = xmlDoc.CreateElement("DetalleFactura");

                foreach (FacturaDetalle facturaDetalle in Factura.FacturaDetalle)
                {
                    XmlElement nProducto = xmlDoc.CreateElement("Producto");
                    nProducto.SetAttribute("Cantidad", facturaDetalle.Cantidad.ToString());
                    nProducto.InnerText = facturaDetalle.Producto.ToString();

                    nDetalleFactura.AppendChild(nProducto);
                }
                xmlDoc.DocumentElement.AppendChild(nDetalleFactura);
            }

            return xmlDoc;
        }

        private MemoryStream GenerarPDF() 
        {
            GenerarFacturaPDF generadorPDF = new GenerarFacturaPDF();
            Byte[] bytes = generadorPDF.ObtenerPDF(Factura);

            return new MemoryStream(bytes);
        }

        public bool EnviarFacturaEmail()
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Biker Striker SA", "bikerstrikersa@gmail.com"));
            message.To.Add(new MailboxAddress("Recipient Name", Factura.Cliente.Correo));
            message.Subject = $"Nueva Factura #{Factura.Id} | Biker Striker SA";

            var body = new TextPart("plain")
            {
                Text = $"Se ha registrado una nueva factura a nombre de {Factura.Cliente}.\n¡Gracias por confiar en nosotros!"
            };

            using (var pdfStream = GenerarPDF())
            {
                var attachmentPdf = new MimePart("application", "pdf")
                {
                    Content = new MimeContent(pdfStream),
                    ContentDisposition = new ContentDisposition(ContentDisposition.Attachment),
                    ContentTransferEncoding = ContentEncoding.Base64,
                    FileName = $"Factura_{Factura.Id}.pdf"
                };

                var xmlDocument = GenerarXML();
                using (var xmlStream = new MemoryStream())
                {
                    xmlDocument.Save(xmlStream);
                    xmlStream.Position = 0;

                    var attachmentXml = new MimePart("application", "xml")
                    {
                        Content = new MimeContent(xmlStream),
                        ContentDisposition = new ContentDisposition(ContentDisposition.Attachment),
                        ContentTransferEncoding = ContentEncoding.Base64,
                        FileName = $"Factura_{Factura.Id}.xml"
                    };

                    var multipart = new Multipart("mixed");
                    multipart.Add(body);
                    multipart.Add(attachmentPdf);
                    multipart.Add(attachmentXml);

                    message.Body = multipart;

                    using (var client = new SmtpClient())
                    {
                        client.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                        client.Authenticate("bikerstrikersa@gmail.com", "pgtt jyqd siff vfbh");
                        client.Send(message);
                        client.Disconnect(true);
                    }
                }
            }
            return true;
        }

        public void AjusteFactura()
        {
            BLLOrdenTrabajo bLLOrdenTrabajo = new BLLOrdenTrabajo();
            BLLProducto bLLProducto = new BLLProducto();

            if (Factura.OrdenTrabajo != null)
            {
                bLLOrdenTrabajo.ActualizarPago(Factura.OrdenTrabajo.Id);
            }

            foreach(FacturaDetalle facturaDetalle in Factura.FacturaDetalle)
            {
                Producto producto = facturaDetalle.Producto;
                producto.Cantidad -= facturaDetalle.Cantidad;

                bLLProducto.Save(producto);
            }
        }
    }
}
