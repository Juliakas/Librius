using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyLibrarian.Forms
{
    class MessageManager
    {
        public static void ShowMessageBox (Exception e)
        {
            MessageBox.Show(e.Message);
        }

        public static void ShowMessageBox(string text, string caption)
        {
            MessageBox.Show(text, caption);
        }
        public static void ShowMessageBox(string text)
        {
            MessageBox.Show(text);
        }
    }
}
