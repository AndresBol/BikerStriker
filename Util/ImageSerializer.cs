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
            using (MemoryStream ms = new MemoryStream(imageBytes))
            {
                using (Image loadedImage = Image.FromStream(ms))
                {
                    Image imageCopy = new Bitmap(loadedImage);

                    using (MemoryStream jpegStream = new MemoryStream())
                    {
                        imageCopy.Save(jpegStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                        jpegStream.Position = 0;
                        return Image.FromStream(jpegStream);
                    }
                }
            }
        }
    }
}
