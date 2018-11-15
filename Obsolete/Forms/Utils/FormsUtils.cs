using MyLibrarian.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyLibrarian.Forms.Utils
{
    internal static class FormsUtils
    {
        internal static void ExitApplication()
        {
            ControllerDB.Instance.Close();
            Application.Exit();
        }
    }
}
