using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikerStriker.Util
{
    public static class QRCodeGeneratorUtility
    {
        /// <summary>
        /// Genera un código QR a partir de un número entero.
        /// </summary>
        /// <param name="number">El número entero a codificar en el código QR.</param>
        /// <returns>Un objeto Image que representa el código QR.</returns>
        public static Image GenerateQRCodeFromInteger(int number)
        {
            try
            {
                string data = number.ToString();

                using (var qrGenerator = new QRCodeGenerator())
                {
                    QRCodeData qrCodeData = qrGenerator.CreateQrCode(data, QRCodeGenerator.ECCLevel.Q);
                    using (var qrCode = new QRCode(qrCodeData))
                    {
                        Bitmap qrCodeImage = qrCode.GetGraphic(20);
                        return qrCodeImage;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error al generar el código QR.", ex);
            }
        }
    }
}
