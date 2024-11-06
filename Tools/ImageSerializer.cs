using System;
using System.Drawing;
using System.IO;

namespace BikerStriker.Tools
{
    internal static class ImageSerializer
    {
        public static string SerializeImageToString(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

                return Convert.ToBase64String(ms.ToArray());
            }
        }
        public static Image DeserializeImageFromString(string imageData)
        {
            byte[] imageBytes = Convert.FromBase64String(imageData);

            using (MemoryStream ms = new MemoryStream(imageBytes))
            {
                return Image.FromStream(ms);
            }
        }
    }
}
