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
            MessageBox.Show("บันทึกเบอร์ออกเรียบร้อย", "บันทึก");
        }
        private void WinNumberToDB()
        {
            // set WinNumber to DB
            // get Number from Form
            string Number3up = tbNumber3up.Text;
            string Number3low1 = tbNumber3low1.Text;
            string Number3low2 = tbNumber3low2.Text;
            string Number3low3 = tbNumber3low3.Text;
            string Number3low4 = tbNumber3low4.Text;
            string Number2low = tbNumber2low.Text;

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
        }
    }
}
