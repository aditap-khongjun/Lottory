using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lottory
{
    public partial class Analysis : Form
    {
        public Analysis()
        {
            InitializeComponent();
        }

        private void cb3up_CheckedChanged(object sender, EventArgs e)
        {
            // Enable
            tb3up.Enabled = cb3up.Checked;
        }

        private void cb3low_CheckedChanged(object sender, EventArgs e)
        {
            // Enable
            tb3low1.Enabled = cb3low.Checked;
            tb3low2.Enabled = cb3low.Checked;
            tb3low3.Enabled = cb3low.Checked;
            tb3low4.Enabled = cb3low.Checked;
        }

        private void cb2low_CheckedChanged(object sender, EventArgs e)
        {
            // Enable
            tb2low.Enabled = cb2low.Checked;
        }

        private void cb2up_CheckedChanged(object sender, EventArgs e)
        {
            // Enable
            tb2up.Enabled = cb2up.Checked;
        }

        private void cb2ht_CheckedChanged(object sender, EventArgs e)
        {
            // Enable
            tb2ht.Enabled = cb2ht.Checked;
        }

        private void cb2hu_CheckedChanged(object sender, EventArgs e)
        {
            // Enable
            tb2hu.Enabled = cb2hu.Checked;
        }

        private void cb1up_CheckedChanged(object sender, EventArgs e)
        {
            tb1up1.Enabled = cb1up.Checked;
            tb1up2.Enabled = cb1up.Checked;
            tb1up3.Enabled = cb1up.Checked;
        }

        private void cb1front_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cb1center_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cb1back_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cb1low_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cb1lowfront_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cb1lowback_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
