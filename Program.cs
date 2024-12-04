using BikerStriker.Layers.UI;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BikerStriker
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            frmLogin ofrmLogin = new frmLogin();
            ofrmLogin.ShowDialog();

            if(ofrmLogin.DialogResult == DialogResult.OK) Application.Run(new frmMenuPrincipal());
        }
    }
}
