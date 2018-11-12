using MyLibrarian.Forms.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXing;

namespace MyLibrarian.Detection
{
    class BarcodeScanning
    {
        public static string Scan(Image image)
        {
            Bitmap bitmap = new Bitmap(image);
            //Bitmap bitmap = new Bitmap("images.jpg");
            BarcodeReader reader = new BarcodeReader { AutoRotate = true };
            Result result = reader.Decode(bitmap);
            bitmap.Dispose();

            try
            {
                MessageManager.ShowMessageBox(result.Text);
                return result.Text;
            }catch(NullReferenceException ex)
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
