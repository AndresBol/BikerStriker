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

namespace BikerStriker.Patrones
{
    public class BikerStrikerOrdenTrabajoFacade
    {
        public OrdenTrabajo OrdenTrabajo { get; set; }

        public bool GuardarOrdenTrabajo()
        {
            BLLOrdenTrabajo bLLOrdenTrabajo = new BLLOrdenTrabajo();
            BLLOrdenDetalle bllOrdenDetalle = new BLLOrdenDetalle();
            BLLOrdenFoto bllOrdenFoto = new BLLOrdenFoto();

            bLLOrdenTrabajo.Save(OrdenTrabajo);

            OrdenTrabajo.Id = bLLOrdenTrabajo.GetIdOrdenTrabajo(OrdenTrabajo);

            if(OrdenTrabajo.Id != -1)
            {
                foreach (var oDetalle in OrdenTrabajo.OrdenDetalle)
                {
                    bllOrdenDetalle.Save(oDetalle, OrdenTrabajo.Id);
                }

                foreach (var oFoto in OrdenTrabajo.OrdenFoto)
                {
                    bllOrdenFoto.Save(oFoto, OrdenTrabajo.Id);
                }
            }

            return OrdenTrabajo.Id != -1;
        }

        private MemoryStream GenerarPDF() 
        {
            GenerarOrdenTrabajoPDF generadorPDF = new GenerarOrdenTrabajoPDF();
            Byte[] bytes = generadorPDF.ObtenerPDF(OrdenTrabajo);

            return new MemoryStream(bytes);
        }

        public bool EnviarOrdenTrabajoEmail()
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Biker Striker SA", "bikerstrikersa@gmail.com"));
            message.To.Add(new MailboxAddress("Recipient Name", OrdenTrabajo.Cliente.Correo));
            message.Subject = $"Nueva orden de trabajo #{OrdenTrabajo.Id} | Biker Striker SA";

            var body = new TextPart("plain")
            {
                Text = $"Se ha registrado una nueva orden de trabajo a nombre de {OrdenTrabajo.Cliente}.\n¡Gracias por confiar en nosotros!"
            };

            using (var pdfStream = GenerarPDF())
            {
                var attachment = new MimePart("application", "pdf")
                {
                    Content = new MimeContent(pdfStream),
                    ContentDisposition = new ContentDisposition(ContentDisposition.Attachment),
                    ContentTransferEncoding = ContentEncoding.Base64,
                    FileName = $"OrdenTrabajo_{OrdenTrabajo.Id}.pdf"
                };

                var multipart = new Multipart("mixed");
                multipart.Add(body);
                multipart.Add(attachment);

                message.Body = multipart;

                using (var client = new SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);

                    client.Authenticate("bikerstrikersa@gmail.com", "pgtt jyqd siff vfbh");

                    client.Send(message);
                    client.Disconnect(true);
                }
            }
            return true;
        }
    }
}
