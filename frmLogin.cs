using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Meksefe.com_Zirve_Entegrator
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Helper.CurrentUser.Valid)
                Program.Cancelled = true;
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                await Helper.Login(txtUsername.Text.Trim(), txtPassword.Text.Trim());
                if (Helper.CurrentUser.Valid)
                {
                    Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
