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
                using (Bitmap bitmap = new Bitmap(image))
                {
                    bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                }

                return ms.ToArray();
            }
        }


        public static Image DeserializeImageFromString(byte[] imageBytes)
        {
            if (imageBytes == null || imageBytes.Length == 0)
                return null;

            try
            {
                using (MemoryStream ms = new MemoryStream(imageBytes))
                {
                    using (Image loadedImage = Image.FromStream(ms, false, true))
                    {
                        return new Bitmap(loadedImage);
                    }
                }
            }
            catch (ArgumentException) { 
                return null;
            }
            catch (OutOfMemoryException)
            {
                return null;
            }
        }
    }
}
