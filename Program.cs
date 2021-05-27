using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Meksefe.com_Zirve_Entegrator
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }

        static frmLogin login = new frmLogin();
        public static bool Cancelled = false;
        public static void CheckUser()
        {
            if (string.IsNullOrEmpty(Helper.CurrentUser?.access_token) || Helper.CurrentUser.ValidUntil < DateTime.Now)
            {
                login.ShowDialog();
            }
        }
    }
}
