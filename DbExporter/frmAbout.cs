using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace DbExporter
{
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lnkLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo p = new ProcessStartInfo(lnkLink.Text);
            p.UseShellExecute = true;
            Process.Start(p);
        }
    }
}
