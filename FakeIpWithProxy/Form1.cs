using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FakeIpWithProxy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            cbbTypeProxy.SelectedIndex = 0;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            var stop = new Stop();
            stop.StopFakeIp();
        }

        private void txtProxy_TextChanged(object sender, EventArgs e)
        {
            txtIpProxy.Text = "";
            txtPortProxy.Text = "";
            txtUsername.Text = "";
            txtPassword.Text = "";
            string proxy = txtProxy.Text;
            string[] splitProxy = proxy.Split(':');
            if(splitProxy.Length == 1 )
            {
                txtIpProxy.Text = splitProxy[0];
            }else if(splitProxy.Length == 2)
            {
                txtIpProxy.Text = splitProxy[0];
                txtPortProxy.Text = splitProxy[1];
            }else if (splitProxy.Length == 3)
            {
                txtIpProxy.Text = splitProxy[0];
                txtPortProxy.Text = splitProxy[1];
                txtUsername.Text = splitProxy[2];
            }
            else
            {
                txtIpProxy.Text = splitProxy[0];
                txtPortProxy.Text = splitProxy[1];
                txtUsername.Text = splitProxy[2];
                txtPassword.Text = splitProxy[3];
            }
        }
    }
}
