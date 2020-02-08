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
    public partial class MainMenu : Form
    {
        private static MainMenu _instance;

        public static MainMenu Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new MainMenu();
                return _instance;
            }
        }
        public MainMenu()
        {
            InitializeComponent();
        }

        private void MainMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            _instance = null;
        }

        private void btSystemLogout_Click(object sender, EventArgs e)
        {
            // Logout on MainLotto Form
            MainLotto mainLotto = (MainLotto)this.MdiParent;
            mainLotto.MenuSystem_Logout.PerformClick();
        }

        private void btAddNumber_Click(object sender, EventArgs e)
        {
            // Open Add Number setting
            MainLotto mainLotto = (MainLotto)this.MdiParent;
            mainLotto.MenuAboutNumber_AddNumber.PerformClick();

        }

        private void btShowNumber_Click(object sender, EventArgs e)
        {
            // Open Buying summary
            MainLotto mainLotto = (MainLotto)this.MdiParent;
            mainLotto.MenuAboutNumber_ShowNumber.PerformClick();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            // Read WinNumer
            lbNumber3low1.Text = getWinNumberFromDB(WinNumberType.low3, 1);
            lbNumber3low2.Text = getWinNumberFromDB(WinNumberType.low3, 2);
            lbNumber3low3.Text = getWinNumberFromDB(WinNumberType.low3, 3);
            lbNumber3low4.Text = getWinNumberFromDB(WinNumberType.low3, 4);
            lbNumber3up.Text = getWinNumberFromDB(WinNumberType.up3, 1);
            lbNumber2low.Text = getWinNumberFromDB(WinNumberType.low2, 1);
            lbNumber2hu.Text = getWinNumberFromDB(WinNumberType.hu2, 1);
            lbNumber2ht.Text = getWinNumberFromDB(WinNumberType.ht2, 1);
            lbNumber2up.Text = getWinNumberFromDB(WinNumberType.up2, 1);
            lbNumber1upback.Text = getWinNumberFromDB(WinNumberType.upback1, 1);
            lbNumber1upfront.Text = getWinNumberFromDB(WinNumberType.upfront1, 1);
            lbNumber1upcenter.Text = getWinNumberFromDB(WinNumberType.upcenter1, 1);
            lbNumber1lowback.Text = getWinNumberFromDB(WinNumberType.lowback1, 1);
            lbNumber1lowfront.Text = getWinNumberFromDB(WinNumberType.lowfront1, 1);
            lbNumber1low1.Text = getWinNumberFromDB(WinNumberType.low1, 1);
            lbNumber1low2.Text = getWinNumberFromDB(WinNumberType.low1, 2);
            lbNumber1up1.Text = getWinNumberFromDB(WinNumberType.up1, 1);
            lbNumber1up2.Text = getWinNumberFromDB(WinNumberType.up1, 2);
            lbNumber1up3.Text = getWinNumberFromDB(WinNumberType.up1, 3);
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
            while (WinNumberInfo.Read())
            {
                winNumber = WinNumberInfo["Number"].ToString();
            }
            connection.Close();

            return winNumber;
        }

        private void btNumberLimitSet_Click(object sender, EventArgs e)
        {
            NumberLimitSetting numlimitForm = NumberLimitSetting.Instance;
            numlimitForm.MdiParent = this.MdiParent;
            numlimitForm.Show();
            numlimitForm.Activate();

        }

        private void btMoneyLimitAnalyz_Click(object sender, EventArgs e)
        {

        }

        private void btMoneyLimitDefine_Click(object sender, EventArgs e)
        {

            MoneyTackingOff tackingOffForm = MoneyTackingOff.Instance;
            tackingOffForm.MdiParent = this.MdiParent;
            tackingOffForm.Show();
            tackingOffForm.Activate();
        }

        private void btClearSystemInfo_Click(object sender, EventArgs e)
        {

        }

        private void btCustomerAccount_Click(object sender, EventArgs e)
        {

        }

        private void btWinNumber_Click(object sender, EventArgs e)
        {

        }
    }
}
