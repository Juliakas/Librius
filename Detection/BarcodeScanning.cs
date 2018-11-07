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
            Result result = new BarcodeReader().Decode(bitmap);

            try
            {
                MessageManager.ShowMessageBox(result.Text);
                return result.Text;
            }catch(NullReferenceException ex)
            {
                return "";
            }
            
        }
    }
}
