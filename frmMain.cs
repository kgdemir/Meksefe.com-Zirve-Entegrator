using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static Meksefe.com_Zirve_Entegrator.Helper;

namespace Meksefe.com_Zirve_Entegrator
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            checkUser(true);
        }
        Response<IsEmri> isemri;
        private async void frmMain_Load(object sender, EventArgs e)
        {
            textBox1.Text = Helper.CurrentUser.Ad + Helper.CurrentUser.Soyad;
            Size size = TextRenderer.MeasureText(textBox1.Text, textBox1.Font);
            textBox1.Width = size.Width;
            textBox1.Height = size.Height;
            textBox1.Left = Width - size.Width - 20;
            progressBar1.Width = textBox1.Left - 20;
            progressBar1.Value = progressBar1.Step;
            progressBar1.Style = ProgressBarStyle.Marquee;
            isemri = await Helper.GetIsEmriList();
            
        }
        private void checkUser(bool hide = false)
        {
            if (hide)
            {
                this.Visible = false;
                while (!Program.Cancelled && !(Helper.CurrentUser?.ValidUntil > DateTime.Now))
                {
                    Program.CheckUser();
                }
                if (Program.Cancelled)
                    Environment.Exit(-1);
                this.Visible = true;
                return;
            }
            if (Application.OpenForms.Count > 0 && Application.OpenForms[Application.OpenForms.Count - 1]?.Name == "frmLogin")
                return;
            while (!Program.Cancelled && !(Helper.CurrentUser?.ValidUntil > DateTime.Now))
            {
                Program.CheckUser();
            }
            if (Program.Cancelled)
                Environment.Exit(-1);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value != progressBar1.Maximum && isemri?.Obj?.Count > 0)
            {
                progressBar1.Value = progressBar1.Maximum;
                progressBar1.Style = ProgressBarStyle.Blocks;
                dataGridView1.DataSource = isemri;
            }
            checkUser();
        }
    }
}
