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
    public partial class AddNumberGroup : Form
    {
        public List<TextBox> groupNumber;
        public List<string> groupNumberOut { get; set; }

        public int maxLength { get; set; }
        public AddNumberGroup()
        {
            InitializeComponent();
            
        }
        private void AddNumberGroup_Load(object sender, EventArgs e)
        {
            groupNumber = new List<TextBox>()
            {
                tbNumber1, tbNumber2, tbNumber3, tbNumber4, tbNumber5,
                tbNumber6, tbNumber7, tbNumber8, tbNumber9, tbNumber10,
                tbNumber11, tbNumber12, tbNumber13, tbNumber14, tbNumber15,
                tbNumber16, tbNumber17, tbNumber18, tbNumber19, tbNumber20,
                tbNumber21, tbNumber22, tbNumber23, tbNumber24, tbNumber25
            };
            init_textLength();
            this.AcceptButton = btOK;
            this.tbNumber1.Focus();
        }
        private void init_textLength()
        {
            foreach(TextBox itemNumber in groupNumber)
            {
                itemNumber.MaxLength = maxLength;
            }
        }

        private void tbNumber_TextChanged(object sender, EventArgs e)
        {
            TextBox tbNumber = (TextBox)sender;
            string tbName = tbNumber.Name;
            int x;
            if(Int32.TryParse(tbNumber.Text,out x) || string.IsNullOrEmpty(tbNumber.Text))
            {
                if (tbNumber.Text.Length == maxLength)
                {
                    switch (tbName)
                    {
                        case "tbNumber1":
                            tbNumber2.Focus();
                            tbNumber2.SelectAll();
                            break;
                        case "tbNumber2":
                            tbNumber3.Focus();
                            tbNumber3.SelectAll();
                            break;
                        case "tbNumber3":
                            tbNumber4.Focus();
                            tbNumber4.SelectAll();
                            break;
                        case "tbNumber4":
                            tbNumber5.Focus();
                            tbNumber5.SelectAll();
                            break;
                        case "tbNumber5":
                            tbNumber6.Focus();
                            tbNumber6.SelectAll();
                            break;
                        case "tbNumber6":
                            tbNumber7.Focus();
                            tbNumber7.SelectAll();
                            break;
                        case "tbNumber7":
                            tbNumber8.Focus();
                            tbNumber8.SelectAll();
                            break;
                        case "tbNumber8":
                            tbNumber9.Focus();
                            tbNumber9.SelectAll();
                            break;
                        case "tbNumber9":
                            tbNumber10.Focus();
                            tbNumber10.SelectAll();
                            break;
                        case "tbNumber10":
                            tbNumber11.Focus();
                            tbNumber11.SelectAll();
                            break;
                        case "tbNumber11":
                            tbNumber12.Focus();
                            tbNumber12.SelectAll();
                            break;
                        case "tbNumber12":
                            tbNumber13.Focus();
                            tbNumber13.SelectAll();
                            break;
                        case "tbNumber13":
                            tbNumber14.Focus();
                            tbNumber14.SelectAll();
                            break;
                        case "tbNumber14":
                            tbNumber15.Focus();
                            tbNumber15.SelectAll();
                            break;
                        case "tbNumber15":
                            tbNumber16.Focus();
                            tbNumber16.SelectAll();
                            break;
                        case "tbNumber16":
                            tbNumber17.Focus();
                            tbNumber17.SelectAll();
                            break;
                        case "tbNumber17":
                            tbNumber18.Focus();
                            tbNumber18.SelectAll();
                            break;
                        case "tbNumber18":
                            tbNumber19.Focus();
                            tbNumber19.SelectAll();
                            break;
                        case "tbNumber19":
                            tbNumber20.Focus();
                            tbNumber20.SelectAll();
                            break;
                        case "tbNumber20":
                            tbNumber21.Focus();
                            tbNumber21.SelectAll();
                            break;
                        case "tbNumber21":
                            tbNumber22.Focus();
                            tbNumber22.SelectAll();
                            break;
                        case "tbNumber22":
                            tbNumber23.Focus();
                            tbNumber23.SelectAll();
                            break;
                        case "tbNumber23":
                            tbNumber24.Focus();
                            tbNumber24.SelectAll();
                            break;
                        case "tbNumber24":
                            tbNumber25.Focus();
                            tbNumber25.SelectAll();
                            break;
                        case "tbNumber25":
                            tbNumber1.Focus();
                            tbNumber1.SelectAll();
                            break;
                    }
                }
            }
            else
            {
                MessageBox.Show("กรุณาใส่ข้อมูลเป็นตัวเลขเท่านั้น", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }

        private void btOK_Click(object sender, EventArgs e)
        {
            // add group Number to List
            List<string> _groupNumber = new List<string>();
            foreach(TextBox tbItem in groupNumber)
            {
                if(!string.IsNullOrEmpty(tbItem.Text))
                {
                    _groupNumber.Add(tbItem.Text);
                }
            }
            groupNumberOut = _groupNumber;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void tbNumber_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox tbNumber = (TextBox)sender;
            string tbName = tbNumber.Name;
            switch(e.KeyCode)
            {
                case Keys.PageDown:
                    btOK.PerformClick();
                    break;
                case Keys.Up:
                    switch (tbName)
                    {
                        case "tbNumber1":
                            tbNumber25.Focus();
                            tbNumber25.SelectAll();
                            break;
                        case "tbNumber2":
                            tbNumber1.Focus();
                            tbNumber1.SelectAll();
                            break;
                        case "tbNumber3":
                            tbNumber2.Focus();
                            tbNumber2.SelectAll();
                            break;
                        case "tbNumber4":
                            tbNumber3.Focus();
                            tbNumber3.SelectAll();
                            break;
                        case "tbNumber5":
                            tbNumber4.Focus();
                            tbNumber4.SelectAll();
                            break;
                        case "tbNumber6":
                            tbNumber5.Focus();
                            tbNumber5.SelectAll();
                            break;
                        case "tbNumber7":
                            tbNumber6.Focus();
                            tbNumber6.SelectAll();
                            break;
                        case "tbNumber8":
                            tbNumber7.Focus();
                            tbNumber7.SelectAll();
                            break;
                        case "tbNumber9":
                            tbNumber8.Focus();
                            tbNumber8.SelectAll();
                            break;
                        case "tbNumber10":
                            tbNumber9.Focus();
                            tbNumber9.SelectAll();
                            break;
                        case "tbNumber11":
                            tbNumber10.Focus();
                            tbNumber10.SelectAll();
                            break;
                        case "tbNumber12":
                            tbNumber11.Focus();
                            tbNumber11.SelectAll();
                            break;
                        case "tbNumber13":
                            tbNumber12.Focus();
                            tbNumber12.SelectAll();
                            break;
                        case "tbNumber14":
                            tbNumber13.Focus();
                            tbNumber13.SelectAll();
                            break;
                        case "tbNumber15":
                            tbNumber14.Focus();
                            tbNumber14.SelectAll();
                            break;
                        case "tbNumber16":
                            tbNumber15.Focus();
                            tbNumber15.SelectAll();
                            break;
                        case "tbNumber17":
                            tbNumber16.Focus();
                            tbNumber16.SelectAll();
                            break;
                        case "tbNumber18":
                            tbNumber17.Focus();
                            tbNumber17.SelectAll();
                            break;
                        case "tbNumber19":
                            tbNumber18.Focus();
                            tbNumber18.SelectAll();
                            break;
                        case "tbNumber20":
                            tbNumber19.Focus();
                            tbNumber19.SelectAll();
                            break;
                        case "tbNumber21":
                            tbNumber20.Focus();
                            tbNumber20.SelectAll();
                            break;
                        case "tbNumber22":
                            tbNumber21.Focus();
                            tbNumber21.SelectAll();
                            break;
                        case "tbNumber23":
                            tbNumber22.Focus();
                            tbNumber22.SelectAll();
                            break;
                        case "tbNumber24":
                            tbNumber23.Focus();
                            tbNumber23.SelectAll();
                            break;
                        case "tbNumber25":
                            tbNumber24.Focus();
                            tbNumber24.SelectAll();
                            break;
                    }
                    break;
            }
        }


    }
}
