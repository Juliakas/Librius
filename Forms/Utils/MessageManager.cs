using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyLibrarian.Forms.Utils
{
    internal static class MessageManager
    {
        public static void ShowMessageBox(Exception ex, string optionalCaption = "Exception")
        {
            MessageBox.Show(ex.Message, optionalCaption);
        }

        public static void ShowMessageBox(string text, string optionalCaption = "Error")
        {
            MessageBox.Show(text, optionalCaption);
        }
    }
}
