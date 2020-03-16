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

            if(!cb3up.Checked)
            {
                cbSelectAll.Checked = false;
            }
        }

        private void cb3low_CheckedChanged(object sender, EventArgs e)
        {
            // Enable
            tb3low1.Enabled = cb3low.Checked;
            tb3low2.Enabled = cb3low.Checked;
            tb3low3.Enabled = cb3low.Checked;
            tb3low4.Enabled = cb3low.Checked;

            if (!cb3low.Checked)
            {
                cbSelectAll.Checked = false;
            }
        }

        private void cb2low_CheckedChanged(object sender, EventArgs e)
        {
            // Enable
            tb2low.Enabled = cb2low.Checked;

            if (!cb2low.Checked)
            {
                cbSelectAll.Checked = false;
            }
        }

        private void cb2up_CheckedChanged(object sender, EventArgs e)
        {
            // Enable
            tb2up.Enabled = cb2up.Checked;

            if (!cb2up.Checked)
            {
                cbSelectAll.Checked = false;
            }
        }

        private void cb2ht_CheckedChanged(object sender, EventArgs e)
        {
            // Enable
            tb2ht.Enabled = cb2ht.Checked;

            if (!cb2ht.Checked)
            {
                cbSelectAll.Checked = false;
            }
        }

        private void cb2hu_CheckedChanged(object sender, EventArgs e)
        {
            // Enable
            tb2hu.Enabled = cb2hu.Checked;

            if (!cb2hu.Checked)
            {
                cbSelectAll.Checked = false;
            }
        }

        private void cb1up_CheckedChanged(object sender, EventArgs e)
        {
            tb1up1.Enabled = cb1up.Checked;
            tb1up2.Enabled = cb1up.Checked;
            tb1up3.Enabled = cb1up.Checked;

            if (!cb1up.Checked)
            {
                cbSelectAll.Checked = false;
            }
        }

        private void cb1front_CheckedChanged(object sender, EventArgs e)
        {
            tb1front.Enabled = cb1front.Checked;

            if (!cb1front.Checked)
            {
                cbSelectAll.Checked = false;
            }
        }

        private void cb1center_CheckedChanged(object sender, EventArgs e)
        {
            tb1center.Enabled = cb1center.Checked;

            if (!cb1center.Checked)
            {
                cbSelectAll.Checked = false;
            }
        }

        private void cb1back_CheckedChanged(object sender, EventArgs e)
        {
            tb1back.Enabled = cb1back.Checked;

            if (!cb1back.Checked)
            {
                cbSelectAll.Checked = false;
            }
        }

        private void cb1low_CheckedChanged(object sender, EventArgs e)
        {
            tb1low1.Enabled = cb1low.Checked;
            tb1low2.Enabled = cb1low.Checked;

            if (!cb1low.Checked)
            {
                cbSelectAll.Checked = false;
            }
        }

        private void cb1lowfront_CheckedChanged(object sender, EventArgs e)
        {
            tb1lowfront.Enabled = cb1lowfront.Checked;

            if (!cb1lowfront.Checked)
            {
                cbSelectAll.Checked = false;
            }
        }

        private void cb1lowback_CheckedChanged(object sender, EventArgs e)
        {
            tb1lowback.Enabled = cb1lowback.Checked;

            if (!cb1lowback.Checked)
            {
                cbSelectAll.Checked = false;
            }
        }

        private void cbSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSelectAll.Checked)
            {
                cb3up.Checked = cbSelectAll.Checked;
                cb3low.Checked = cbSelectAll.Checked;
                cb2low.Checked = cbSelectAll.Checked;
                cb2up.Checked = cbSelectAll.Checked;
                cb2ht.Checked = cbSelectAll.Checked;
                cb2hu.Checked = cbSelectAll.Checked;
                cb1up.Checked = cbSelectAll.Checked;
                cb1front.Checked = cbSelectAll.Checked;
                cb1center.Checked = cbSelectAll.Checked;
                cb1back.Checked = cbSelectAll.Checked;
                cb1low.Checked = cbSelectAll.Checked;
                cb1lowfront.Checked = cbSelectAll.Checked;
                cb1lowback.Checked = cbSelectAll.Checked;
            }

        }

        private void tb3up_TextChanged(object sender, EventArgs e)
        {
            switch(tb3up.Text.Length)
            {
                case 3:
                    setRelativeText3up();
                    break;
                case 0:
                    // clear
                    clearRelativeText3up();
                    break;

            }
        }
        private void setRelativeText3up()
        {
            // for 1
            tb1front.Text = tb3up.Text.Substring(0, 1);
            tb1center.Text = tb3up.Text.Substring(1, 1);
            tb1back.Text = tb3up.Text.Substring(2, 1);

            tb1up1.Text = tb1front.Text;
            tb1up2.Text = tb1center.Text;
            tb1up3.Text = tb1back.Text;

            // for 2
            tb2up.Text = tb3up.Text.Substring(1, 2);

            // for ht
            tb2ht.Text = tb3up.Text.Substring(0, 2);

            // for hu
            tb2hu.Text = tb3up.Text.Substring(0, 1) + tb3up.Text.Substring(2, 1);
        }
        private void clearRelativeText3up()
        {
            // for 1
            tb1front.Text = string.Empty;
            tb1center.Text = string.Empty;
            tb1back.Text = string.Empty;

            tb1up1.Text = string.Empty;
            tb1up2.Text = string.Empty;
            tb1up3.Text = string.Empty;

            // for 2
            tb2up.Text = string.Empty;

            // for ht
            tb2ht.Text = string.Empty;

            // for hu
            tb2hu.Text = string.Empty;
        }

        private void tb3low_TextChanged(object sender, EventArgs e)
        {
            TextBox tb3low = (TextBox)sender;
            switch(tb3low.Text.Length)
            {
                case 3:
                    switch (tb3low.Name)
                    {
                        case "tb3low1":
                            tb3low2.Focus();
                            tb3low2.SelectAll();
                            break;
                        case "tb3low2":
                            tb3low3.Focus();
                            tb3low3.SelectAll();
                            break;
                        case "tb3low3":
                            tb3low4.Focus();
                            tb3low4.SelectAll();
                            break;
                        case "tb3low4":
                            tb3low1.Focus();
                            tb3low1.SelectAll();
                            break;
                    }
                    break;
            }

        }

        private void tb1up_TextChanged(object sender, EventArgs e)
        {
            TextBox tb1up = (TextBox)sender;
            switch (tb1up.Text.Length)
            {
                case 1:
                    switch (tb1up.Name)
                    {
                        case "tb1up1":
                            tb1up2.Focus();
                            tb1up2.SelectAll();
                            break;
                        case "tb1up2":
                            tb1up3.Focus();
                            tb1up3.SelectAll();
                            break;
                        case "tb1up3":
                            tb1up1.Focus();
                            tb1up1.SelectAll();
                            break;
                    }
                    break;
            }
        }
    }
}
