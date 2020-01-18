using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Lottory
{
    public partial class WinNumberSetting : Form
    {
        private static WinNumberSetting _instance;
        public static WinNumberSetting Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new WinNumberSetting();
                return _instance;
            }
        }
        private void WinNumberSetting_FormClosed(object sender, FormClosedEventArgs e)
        {
            _instance = null;
        }
        public WinNumberSetting()
        {
            InitializeComponent();
        }

        private void WinNumberSetting_Load(object sender, EventArgs e)
        {
            // get WinNumber from DB to Form
            WinNumberToForm();
        }
        private void WinNumberToForm()
        {
            tbNumber3up.Text = getWinNumberFromDB(WinNumberType.up3, 1);
            tbNumber3low1.Text = getWinNumberFromDB(WinNumberType.low3, 1);
            tbNumber3low2.Text = getWinNumberFromDB(WinNumberType.low3, 2);
            tbNumber3low3.Text = getWinNumberFromDB(WinNumberType.low3, 3);
            tbNumber3low4.Text = getWinNumberFromDB(WinNumberType.low3, 4);
            tbNumber2low.Text = getWinNumberFromDB(WinNumberType.low2, 1);
        }
        private string getWinNumberFromDB(string TypeName, int No)
        {
            string winNumber = string.Empty;
            // Load WinNumber from DB
            SqlConnection connection = new SqlConnection(Database.CnnVal("LottoryDB"));
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            string sqlgetWinNumber = string.Format(@"SELECT Number
                                                     FROM WinNumber
                                                     WHERE TypeName = N'{0}' AND No = {1}", TypeName, No.ToString());
            SqlCommand sqlgetWinNumberCom = new SqlCommand(sqlgetWinNumber, connection);
            SqlDataReader WinNumberInfo = sqlgetWinNumberCom.ExecuteReader();
            while(WinNumberInfo.Read())
            {
                winNumber = WinNumberInfo["Number"].ToString();
            }
            connection.Close();

            return winNumber;
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            WinNumberToDB();
            
        }
        private void WinNumberToDB()
        {
            // set WinNumber to DB
            // get Number from Form
            string Number3up;
            string Number3low1;
            string Number3low2;
            string Number3low3;
            string Number3low4;
            string Number2low;
            if ((tbNumber3up.Text.Length != tbNumber3up.MaxLength) && !string.IsNullOrEmpty(tbNumber3up.Text))
            {
                //error
                MessageBox.Show("กรุณาใส่เบอร์ออก 3 บนให้ถูกต้อง", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                Number3up = tbNumber3up.Text;
            }
            if((tbNumber3low1.Text.Length != tbNumber3low1.MaxLength) && !string.IsNullOrEmpty(tbNumber3low1.Text))
            {
                //error
                MessageBox.Show("กรุณาใส่เบอร์ออก 3 ล่างให้ถูกต้อง", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                Number3low1 = tbNumber3low1.Text;
            }
            if((tbNumber3low2.Text.Length != tbNumber3low2.MaxLength) && !string.IsNullOrEmpty(tbNumber3low2.Text))
            {
                //error
                MessageBox.Show("กรุณาใส่เบอร์ออก 3 ล่างให้ถูกต้อง", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                Number3low2 = tbNumber3low2.Text;
            }
            if((tbNumber3low3.Text.Length != tbNumber3low3.MaxLength) && !string.IsNullOrEmpty(tbNumber3low3.Text))
            {
                //error
                MessageBox.Show("กรุณาใส่เบอร์ออก 3 ล่างให้ถูกต้อง", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                Number3low3 = tbNumber3low3.Text;
            }
            if((tbNumber3low4.Text.Length != tbNumber3low4.MaxLength) && !string.IsNullOrEmpty(tbNumber3low4.Text))
            {
                //error
                MessageBox.Show("กรุณาใส่เบอร์ออก 3 ล่างให้ถูกต้อง", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                Number3low4 = tbNumber3low4.Text;
            }
            if((tbNumber2low.Text.Length != tbNumber2low.MaxLength) && !string.IsNullOrEmpty(tbNumber2low.Text))
            {
                //error
                MessageBox.Show("กรุณาใส่เบอร์ออก 2 ล่างให้ถูกต้อง", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                Number2low = tbNumber2low.Text;
            }
            
            // 3up
            if(!string.IsNullOrEmpty(Number3up))
            {
                string Number1up1 = Number3up.Substring(0, 1);
                string Number1up2 = Number3up.Substring(1, 1);
                string Number1up3 = Number3up.Substring(2, 1);
                string Number2up = Number3up.Substring(1, 2);
                string Number2hu = string.Format("{0}{1}", Number3up.Substring(0, 1), Number3up.Substring(2, 1));
                string Number2ht = Number3up.Substring(0, 2);
                string Number1front = Number1up1;
                string Number1center = Number1up2;
                string Number1back = Number1up3;

                // set Number to DB
                setWinNumberToDB(WinNumberType.up3, 1, Number3up);
                setWinNumberToDB(WinNumberType.up1, 1, Number1up1);
                setWinNumberToDB(WinNumberType.up1, 2, Number1up2);
                setWinNumberToDB(WinNumberType.up1, 3, Number1up3);
                setWinNumberToDB(WinNumberType.up2, 1, Number2up);
                setWinNumberToDB(WinNumberType.hu2, 1, Number2hu);
                setWinNumberToDB(WinNumberType.ht2, 1, Number2ht);
                setWinNumberToDB(WinNumberType.upfront1, 1, Number1front);
                setWinNumberToDB(WinNumberType.upcenter1, 1, Number1center);
                setWinNumberToDB(WinNumberType.upback1, 1, Number1back);
            }
            else
            {
                // case empty
                string Number1up1 = string.Empty;
                string Number1up2 = string.Empty;
                string Number1up3 = string.Empty;
                string Number2up = string.Empty;
                string Number2hu = string.Empty;
                string Number2ht = string.Empty;
                string Number1front = string.Empty;
                string Number1center = string.Empty;
                string Number1back = string.Empty;

                setWinNumberToDB(WinNumberType.up3, 1, Number3up);
                setWinNumberToDB(WinNumberType.up1, 1, Number1up1);
                setWinNumberToDB(WinNumberType.up1, 2, Number1up2);
                setWinNumberToDB(WinNumberType.up1, 3, Number1up3);
                setWinNumberToDB(WinNumberType.up2, 1, Number2up);
                setWinNumberToDB(WinNumberType.hu2, 1, Number2hu);
                setWinNumberToDB(WinNumberType.ht2, 1, Number2ht);
                setWinNumberToDB(WinNumberType.upfront1, 1, Number1front);
                setWinNumberToDB(WinNumberType.upcenter1, 1, Number1center);
                setWinNumberToDB(WinNumberType.upback1, 1, Number1back);
            }

            // 3low
            setWinNumberToDB(WinNumberType.low3, 1, Number3low1);
            setWinNumberToDB(WinNumberType.low3, 2, Number3low2);
            setWinNumberToDB(WinNumberType.low3, 3, Number3low3);
            setWinNumberToDB(WinNumberType.low3, 4, Number3low4);

            
            // 2low
            if(!string.IsNullOrEmpty(Number2low))
            {
                string Number1lowfront = Number2low.Substring(0, 1);
                string Number1lowback = Number2low.Substring(1, 1);
                string Number1low1 = Number1lowfront;
                string Number1low2 = Number1lowback;

                setWinNumberToDB(WinNumberType.low2, 1, Number2low);
                setWinNumberToDB(WinNumberType.lowback1, 1, Number1lowback);
                setWinNumberToDB(WinNumberType.lowfront1, 1, Number1lowfront);
                setWinNumberToDB(WinNumberType.low1, 1, Number1low1);
                setWinNumberToDB(WinNumberType.low1, 2, Number1low2);
            }
            else
            {
                // case empty
                string Number1lowfront = string.Empty;
                string Number1lowback = string.Empty;
                string Number1low1 = string.Empty;
                string Number1low2 = string.Empty;

                setWinNumberToDB(WinNumberType.low2, 1, Number2low);
                setWinNumberToDB(WinNumberType.lowback1, 1, Number1lowback);
                setWinNumberToDB(WinNumberType.lowfront1, 1, Number1lowfront);
                setWinNumberToDB(WinNumberType.low1, 1, Number1low1);
                setWinNumberToDB(WinNumberType.low1, 2, Number1low2);
            }
            MessageBox.Show("บันทึกเบอร์ออกเรียบร้อย", "บันทึก");
        }
        private void setWinNumberToDB(string TypeName, int No, string Number)
        {
            //
            SqlConnection connection = new SqlConnection(Database.CnnVal("LottoryDB"));
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            string sqlsetWinNumber = string.Format(@"UPDATE WinNumber
                                                     SET Number = '{0}'
                                                     WHERE TypeName = N'{1}' AND No = {2}", Number, TypeName, No.ToString());
            SqlCommand sqlsetWinNumberCom = new SqlCommand(sqlsetWinNumber, connection);
            sqlsetWinNumberCom.ExecuteNonQuery();
            connection.Close();

        }

        private void tbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btClear_Click(object sender, EventArgs e)
        {
            tbNumber3up.Text = string.Empty;
            tbNumber3low1.Text = string.Empty;
            tbNumber3low2.Text = string.Empty;
            tbNumber3low3.Text = string.Empty;
            tbNumber3low4.Text = string.Empty;
            tbNumber2low.Text = string.Empty;

            tbNumber3up.Focus();
        }
        private void Number_Change(object sender, EventArgs e)
        {
            TextBox winNumber = (TextBox)sender;
            string tbName = winNumber.Name;
            int x;
            if(!Int32.TryParse(winNumber.Text,out x) && !string.IsNullOrEmpty(winNumber.Text))
            {
                MessageBox.Show("กรุณาใส่ตัวเลขเท่านั้น", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (winNumber.Text.Length == winNumber.MaxLength)
                {
                    switch (tbName)
                    {
                        case "tbNumber3up":
                            tbNumber3low1.Focus();
                            tbNumber3low1.SelectAll();
                            break;
                        case "tbNumber3low1":
                            tbNumber3low2.Focus();
                            tbNumber3low2.SelectAll();
                            break;
                        case "tbNumber3low2":
                            tbNumber3low3.Focus();
                            tbNumber3low3.SelectAll();
                            break;
                        case "tbNumber3low3":
                            tbNumber3low4.Focus();
                            tbNumber3low4.SelectAll();
                            break;
                        case "tbNumber3low4":
                            tbNumber2low.Focus();
                            tbNumber2low.SelectAll();
                            break;
                        case "tbNumber2low":
                            tbNumber3up.Focus();
                            tbNumber3up.SelectAll();
                            break;
                    }
                }
            }
            
        }

        private void Number_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox tbNumber = (TextBox)sender;
            string tbName = tbNumber.Name;
            switch(e.KeyCode)
            {
                case Keys.Up:
                    switch(tbName)
                    {
                        case "tbNumber3up":
                            tbNumber2low.Focus();
                            tbNumber2low.SelectAll();
                            break;
                        case "tbNumber3low1":
                            tbNumber3up.Focus();
                            tbNumber3up.SelectAll();
                            break;
                        case "tbNumber3low2":
                            tbNumber3low1.Focus();
                            tbNumber3low1.SelectAll();
                            break;
                        case "tbNumber3low3":
                            tbNumber3low2.Focus();
                            tbNumber3low2.SelectAll();
                            break;
                        case "tbNumber3low4":
                            tbNumber3low3.Focus();
                            tbNumber3low3.SelectAll();
                            break;
                        case "tbNumber2low":
                            tbNumber3low4.Focus();
                            tbNumber3low4.SelectAll();
                            break;
                    }
                    break;
            }
        }
    }
}
