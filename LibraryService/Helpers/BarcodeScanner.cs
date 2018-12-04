using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using ZXing;

namespace LibraryService.Helpers
{
    public class BarcodeScanner
    {
        public static string Scan(byte[] image)
        {
            Bitmap bitmap;
            using (var memoryStream = new MemoryStream(image))
            {
                bitmap = new Bitmap(memoryStream);
            }

            bitmap = ToGrayscale(bitmap);

            BarcodeReader reader = new BarcodeReader { AutoRotate = true };
            Result result = reader.Decode(bitmap);
            bitmap.Dispose();

            try
            {
                return result.Text;
            }
            catch (NullReferenceException)
            {
                return "";
            }
        }

        private static Bitmap ToGrayscale(Bitmap bitmap)
        {
            for (int x = 0; x < bitmap.Width; x++)
            {
                for (int y = 0; y < bitmap.Height; y++)
                {
                    Color color = bitmap.GetPixel(x, y);
                    Color newColor = Color.FromArgb(color.R, 0, 0);
                    bitmap.SetPixel(x, y, newColor);
                }
            }
            return bitmap;
        }

    }
}