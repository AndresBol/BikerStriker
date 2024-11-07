using System;
using System.Drawing;
using System.IO;

namespace BikerStriker.Tools
{
    internal static class ImageSerializer
    {
        public static byte[] SerializeImageToString(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

                return ms.ToArray();
            }
        }

        public static Image DeserializeImageFromString(byte[] imageBytes)
        {
            using (MemoryStream ms = new MemoryStream(imageBytes))
            {
                return Image.FromStream(ms);
            }
        }

        
    }
}
