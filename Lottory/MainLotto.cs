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
    public partial class MainLotto : Form
    {
        // Properties of ระบบ
        private ToolStripMenuItem MenuSystem = new ToolStripMenuItem();
        private ToolStripSeparator MenuSystem_separator1 = new ToolStripSeparator();
        private ToolStripMenuItem MenuSystem_Exit = new ToolStripMenuItem();
        private ToolStripMenuItem MenuSystem_Login = new ToolStripMenuItem();
        private ToolStripMenuItem MenuSystem_ChangeUser = new ToolStripMenuItem();
        public ToolStripMenuItem MenuSystem_Logout = new ToolStripMenuItem();
        private ToolStripMenuItem MenuSystem_ShowMainMenu = new ToolStripMenuItem();
        private ToolStripSeparator MenuSystem_separator2 = new ToolStripSeparator();


        // Properties of เกี่ยวกับตัวเลข
        private ToolStripMenuItem MenuAboutNumber = new ToolStripMenuItem();
        public ToolStripMenuItem MenuAboutNumber_AddNumber = new ToolStripMenuItem();
        private ToolStripSeparator MenuAboutNumber_separator1 = new ToolStripSeparator();
        public ToolStripMenuItem MenuAboutNumber_ShowNumber = new ToolStripMenuItem();

        // Properties of วงเงินอั้น
        private ToolStripMenuItem MenuMoneyLimit = new ToolStripMenuItem();
        private ToolStripMenuItem MenuMoneyLimit_AnalysisLimit = new ToolStripMenuItem();
        private ToolStripMenuItem MenuMoneyLimit_DefineLimit = new ToolStripMenuItem();

        // Properties of การผันตัวเลข
        private ToolStripMenuItem MenuConvertNumber = new ToolStripMenuItem();
        private ToolStripMenuItem MenuConvertNumber_Define = new ToolStripMenuItem();

        // Properties of ข้อมูลระบบ
        private ToolStripMenuItem MenuSystemInfo = new ToolStripMenuItem();
        private ToolStripMenuItem MenuSystemInfo_parameter = new ToolStripMenuItem();
        private ToolStripMenuItem MenuSystemInfo_Clear = new ToolStripMenuItem();

        // Properties of บัญชีลูกค้า
        private ToolStripMenuItem MenuCustomerAccount = new ToolStripMenuItem();
        private ToolStripMenuItem MenuCustomerAccount_Management = new ToolStripMenuItem();
        private ToolStripMenuItem MenuCustomerAccount_Report = new ToolStripMenuItem();

        // Properties of เบอร์ออก
        private ToolStripMenuItem MenuWinNumber = new ToolStripMenuItem();
        private ToolStripMenuItem MenuWinNumber_Define = new ToolStripMenuItem();

        // Properties of รายงาน
        private ToolStripMenuItem MenuReport = new ToolStripMenuItem();
        private ToolStripMenuItem MenuReport_AllNumber = new ToolStripMenuItem();
        private ToolStripMenuItem MenuReport_AllBuying = new ToolStripMenuItem();
        private ToolStripMenuItem MenuReport_PageBuying = new ToolStripMenuItem();
        private ToolStripSeparator MenuReport_separator1 = new ToolStripSeparator();
        private ToolStripMenuItem MenuReport_LimitNumber = new ToolStripMenuItem();
        private ToolStripMenuItem MenuReport_19DoorsBuying = new ToolStripMenuItem();
        private ToolStripMenuItem MenuReport_CustomerBuying = new ToolStripMenuItem();

        // EmployeeID
        public string EmployeeID { get; set; }


        public MainLotto()
        {
            InitializeComponent();

            // Callback
            //
            // MenuSystem
            MenuSystem_Login.Click += new EventHandler(MenuSystem_Login_Click); //เข้าสู่ระบบ
            MenuSystem_ChangeUser.Click += new EventHandler(MenuSystem_ChangeUser_Click); //เปลี่ยนแปลงผู้ใช้
            MenuSystem_Logout.Click += new EventHandler(MenuSystem_Logout_Click); //ออกจากระบบ
            MenuSystem_ShowMainMenu.Click += new EventHandler(MenuSystem_ShowMainMenu_Click); //แสดงเมนูหลัก
            MenuSystem_Exit.Click += new EventHandler(MenuSystem_Exit_Click); //ออกจากโปรแกรม

            // MenuAboutNumber
            MenuAboutNumber_AddNumber.Click += new EventHandler(MenuAboutNumber_AddNumber_Click); //ป้อนตัวเลข
            MenuAboutNumber_ShowNumber.Click += new System.EventHandler(this.MenuAboutNumber_ShowNumber_Click); //แสดงตัวเลข (เรียงตามเงิน)

            // MenuMoneyLimit 
            MenuMoneyLimit_DefineLimit.Click += new EventHandler(MenuMoneyLimit_DefineLimit_Click);

            // MenuSystemInfo
            MenuSystemInfo_parameter.Click += new EventHandler(MenuSystemInfo_parameter_Click);
            MenuSystemInfo_Clear.Click += new EventHandler(MenuSystemInfo_Clear_Click);

            // MenuCustomerAccount
            MenuCustomerAccount_Management.Click += new EventHandler(MenuCustomerAccount_Management_Click);
            MenuCustomerAccount_Report.Click += new EventHandler(MenuCustomerAccount_Report_Click);

            // MenuWinNumber
            MenuWinNumber_Define.Click += new EventHandler(MenuWinNumber_Define_Click);

            // Report
            MenuReport_AllBuying.Click += new EventHandler(MenuReport_AllBuying_Click);
            MenuReport_PageBuying.Click += new EventHandler(MenuReport_PageBuying_Click);
            MenuReport_LimitNumber.Click += new EventHandler(MenuReport_LimitNumber_Click);

            // Analysis
            MenuMoneyLimit_AnalysisLimit.Click += new EventHandler(MenuMoneyLimit_AnalysisLimit_Click);
        }

        private void MenuMoneyLimit_AnalysisLimit_Click(object sender, EventArgs e)
        {
            ShowForm(Analysis.Instance);
        }

        private void MenuReport_LimitNumber_Click(object sender, EventArgs e)
        {
            ShowForm(Report_OverMoney.Instance);
        }

        private void MenuReport_PageBuying_Click(object sender, EventArgs e)
        {
            ShowForm(Report_PageBuying.Instance);
        }

        private void MenuReport_AllBuying_Click(object sender, EventArgs e)
        {
            ShowForm(Report_AllBuying.Instance);
        }

        // My Method
        private void Load_Normal_Menu()
        {
            ClearMenu();

            // Add Main Menu
            menuBar.Items.AddRange(new ToolStripItem[]{
                MenuSystem,
                MenuAboutNumber,
                MenuMoneyLimit,
                MenuConvertNumber,
                MenuSystemInfo,
                MenuCustomerAccount,
                MenuWinNumber,
                MenuReport
            });
            // Setting Main Menu
            MenuSystem.Text = "ระบบ";
            MenuAboutNumber.Text = "ข้อมูลตัวเลข";
            MenuMoneyLimit.Text = "วงเงินอั้น";
            MenuConvertNumber.Text = "ผันตัวเลข";
            MenuSystemInfo.Text = "ข้อมูลระบบ";
            MenuCustomerAccount.Text = "บัญชีลูกค้า";
            MenuWinNumber.Text = "เบอร์ออก";
            MenuReport.Text = "รายงาน";
 
            // Add DropDown of MenuSystem
            // 
            MenuSystem.DropDownItems.AddRange(new ToolStripItem[] {
                MenuSystem_ChangeUser,
                MenuSystem_Logout,
                MenuSystem_separator1,
                MenuSystem_ShowMainMenu,
                MenuSystem_separator2,
                MenuSystem_Exit
            });

            // Setting DropDown of MenuSystem
            MenuSystem_ChangeUser.Text = "เปลี่ยนผู้ใช้ระบบ";
            MenuSystem_Logout.Text = "ออกจากระบบ";
            MenuSystem_ShowMainMenu.Text = "แสดงเมนูหลัก";
            MenuSystem_Exit.Text = "ออกจากโปรแกรม";
            
            // Add DropDown of MenuAboutNumber
            MenuAboutNumber.DropDownItems.AddRange(new ToolStripItem[] {
                MenuAboutNumber_AddNumber,
                MenuAboutNumber_separator1,
                MenuAboutNumber_ShowNumber
            });
            
            // Setting DropDown of MenuAboutNumber
            MenuAboutNumber_AddNumber.Text = "ป้อนตัวเลข";
            MenuAboutNumber_AddNumber.ShortcutKeys = Keys.F12;
            MenuAboutNumber_ShowNumber.Text = "แสดงตัวเลข (เรียงตามเงิน)";
            
            // Add DropDown of MenuMoneyLimit 
            MenuMoneyLimit.DropDownItems.AddRange(new ToolStripItem[] {
                MenuMoneyLimit_AnalysisLimit,
                MenuMoneyLimit_DefineLimit
            });
            // Setting DropDown of MenuMoneyLimit 
            //MenuMoneyLimit_AnalysisLimit.Enabled = false;
            MenuMoneyLimit_AnalysisLimit.Text = "วิเคราะห์ความเสี่ยง";
            MenuMoneyLimit_AnalysisLimit.ShortcutKeys = Keys.F10;
            MenuMoneyLimit_DefineLimit.Text = "ตีตัวเลขที่เกินวงเงินอั้น";
            
            
            // Add DropDown of MenuConvertNumber
            MenuConvertNumber.DropDownItems.AddRange(new ToolStripItem[] {
                MenuConvertNumber_Define
            });
            // Setting DropDown of MenuConvertNumber 
            MenuConvertNumber_Define.Enabled = false;
            MenuConvertNumber_Define.Text = "กำหนดการผันตัวเลข";
            
            // Add DropDown of MenuSystemInfo
            MenuSystemInfo.DropDownItems.AddRange(new ToolStripItem[] {
                MenuSystemInfo_parameter,
                MenuSystemInfo_Clear
            });
            // Setting DropDown of MenuSystemInfo
            MenuSystemInfo_parameter.Text = "กำหนดค่าต่าง ๆ";
            MenuSystemInfo_Clear.Text = "ลบข้อมูลทั้งหมด";
            
            // Add DropDown of MenuCustomerAccount
            MenuCustomerAccount.DropDownItems.AddRange(new ToolStripItem[] {
                MenuCustomerAccount_Management,
                MenuCustomerAccount_Report
            });
            // Setting DropDown of MenuCustomerAccount
            MenuCustomerAccount_Management.Text = "จัดการข้อมูลลูกค้า";
            MenuCustomerAccount_Report.Text = "รายงานบัญชีลูกค้า";
            MenuCustomerAccount_Report.ShortcutKeys = Keys.F9;

            // Add DropDown of MenuWinNumber 
            MenuWinNumber.DropDownItems.AddRange(new ToolStripItem[] {
                MenuWinNumber_Define
            });
            // Setting DropDown of MenuWinNumber
            MenuWinNumber_Define.Text = "กำหนดเบอร์ที่ออก";
             
            // Add DropDown of MenuReport
            MenuReport.DropDownItems.AddRange(new ToolStripItem[] {
                MenuReport_AllNumber,
                MenuReport_AllBuying,
                MenuReport_PageBuying,
                MenuReport_separator1,
                MenuReport_LimitNumber,
                MenuReport_19DoorsBuying,
                MenuReport_CustomerBuying
            });
            // Setting DropDown of MenuReport
            MenuReport_AllNumber.Text = "แสดงข้อมูลที่ป้อน";
            MenuReport_AllBuying.Text = "แสดงยอดซื้อตามเลข (รวม)";
            MenuReport_PageBuying.Text = "แสดงยอดซื้อตามเลข (ตามหน้า)";
            MenuReport_LimitNumber.Text = "รายงานแสดงตัวเลขที่ตีออก (ทุกตัวที่เคยตีออก)";
            MenuReport_19DoorsBuying.Text = "รายงานแสดงตัวเลขยอดซื้อ 19ประตู";
            MenuReport_CustomerBuying.Text = "รายงานแสดงยอดซื้อของลูกค้าแต่ละคน";
        }

        private void MenuWinNumber_Define_Click(object sender, EventArgs e)
        {
            // Show WinNumberSetting
            ShowForm(WinNumberSetting.Instance);
        }
        private void ClearMenu()
        {
            menuBar.Items.Clear();
            MenuSystem.DropDownItems.Clear();
            MenuAboutNumber.DropDownItems.Clear();
            MenuMoneyLimit.DropDownItems.Clear();
            MenuConvertNumber.DropDownItems.Clear();
            MenuSystemInfo.DropDownItems.Clear();
            MenuCustomerAccount.DropDownItems.Clear();
            MenuWinNumber.DropDownItems.Clear();
            MenuReport.DropDownItems.Clear();
        }

        private void Load_Login_Menu()
        {
            // Clear
            ClearMenu();

            // Add Menu Item
            menuBar.Items.Add(MenuSystem);

            // Add MenuSystem DropDown
            MenuSystem.DropDownItems.AddRange(new ToolStripItem[]
            {
                MenuSystem_Login,
                MenuSystem_separator1,
                MenuSystem_Exit
            });

            // Setting Properties
            // MenuSystem
            MenuSystem.Name = "MenuSystem";
            MenuSystem.Text = "ระบบ";
            // MenuSystem_Login
            MenuSystem_Login.Name = "MenuSystem_Login";
            MenuSystem_Login.Text = "เข้าสู่ระบบ";
            
            // MenuSystem_Exit
            MenuSystem_Exit.Name = "MenuSystem_Exit";
            MenuSystem_Exit.Text = "ออกจากโปรแกรม";

            MenuSystem_Login.PerformClick();
        }

        private void MenuSystem_Login_Click(object sender, EventArgs e)
        {
            
            Login login = new Login();
            DialogResult userLoginResult = login.ShowDialog();
            if(userLoginResult == DialogResult.OK)
            {
                Load_Normal_Menu();
                //Show 
                ShowForm(MainMenu.Instance);
                this.Text = "Lotto - " + Login.EmpolyeeName;
            }
            else if(userLoginResult == DialogResult.Cancel)
            {
                // nothing to do
            }
        }

        private void MenuSystem_Exit_Click(object sender, EventArgs e)
        {
            // Close windows
            this.Close();
        }

        private void MainLotto_Load(object sender, EventArgs e)
        {
            // Start Login Menu
            Load_Login_Menu();
        }

        private void MenuSystem_ShowMainMenu_Click(object sender, EventArgs e)
        {
            //Show Main Menu
            ShowForm(MainMenu.Instance);
        }

        public void ShowForm(Form frm)
        {
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }
        private void CloseAllChild(Form[] mainForm)
        {
            foreach (Form frm in mainForm)
            {
                frm.Close();
            }
        }

        private void MenuSystem_ChangeUser_Click(object sender, EventArgs e)
        {
            // Change User Login //
            //
            // Same Login user
            MenuSystem_Login.PerformClick();
        }

        private void MenuSystem_Logout_Click(object sender, EventArgs e)
        {
            // System Logout //
            //
            // Close Child Form
            CloseAllChild(MdiChildren);

            // Show System Login Menu
            Load_Login_Menu();

        }

        private void MenuAboutNumber_AddNumber_Click(object sender, EventArgs e)
        {
            // Show AddNumberSetting
            ShowForm(AddNumberSetting.Instance);

            // Close Number Detail
            if (AddNumberDetail.Instance != null)
            {
                foreach(Form child in this.MdiChildren)
                {
                    if(string.Equals(child.Name,"AddNumberDetail"))
                    {
                        child.Close();
                    }
                }
            }
        }

        private void MenuAboutNumber_ShowNumber_Click(object sender, EventArgs e)
        {
            // Show Number order by Money
            ShowForm(BuyingSummary.Instance);
        }

        private void MenuMoneyLimit_DefineLimit_Click(object sender, EventArgs e)
        {
            // Define Money Limit
            ShowForm(MoneyTackingOff.Instance);
        }

        private void MenuSystemInfo_parameter_Click(object sender, EventArgs e)
        {
            // Parameter Setting
            ShowForm(Setting.Instance);
        }

        private void MenuSystemInfo_Clear_Click(object sender, EventArgs e)
        {
            // Clear Imformation
            DialogResult result = MessageBox.Show("ต้องการลบข้อมูลทั้งหมดหรือไม่","ลบข้อมูล",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            switch(result)
            {
                case DialogResult.Yes:
                    // delete information
                    deleteCustomerInformation();
                    break;
                case DialogResult.No:
                    // Nothing to do
                    break;
            }
        }
        private void deleteCustomerInformation()
        {
            deleteInfoFromDB("OrderListExpand");
            deleteInfoFromDB("OrderList");
            deleteInfoFromDB("CustomerOrder");

            setZeroToDB("Number_1up");
            setZeroToDB("Number_1upfront");
            setZeroToDB("Number_1upcenter");
            setZeroToDB("Number_1upback");
            setZeroToDB("Number_1low");
            setZeroToDB("Number_1lowfront");
            setZeroToDB("Number_1lowback");
            setZeroToDB("Number_2up");
            setZeroToDB("Number_2ht");
            setZeroToDB("Number_2hu");
            setZeroToDB("Number_2low");
            setZeroToDB("Number_3up");
            setZeroToDB("Number_3low");

            setEmptyWinNumber();
        }
        private void deleteInfoFromDB(string TableName)
        {
            SqlConnection connection = new SqlConnection(Database.CnnVal("LottoryDB"));
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            string sqldeleteInfo = string.Format("DELETE FROM {0}", TableName);
            SqlCommand sqldeleteInfoCom = new SqlCommand(sqldeleteInfo, connection);
            sqldeleteInfoCom.ExecuteNonQuery();
            connection.Close();
        }
        private void setZeroToDB(string TableName)
        {
            SqlConnection connection = new SqlConnection(Database.CnnVal("LottoryDB"));
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            string sqldeleteInfo = string.Format("UPDATE {0} SET Price = 0, OutPrice = 0, OwnPrice = 0", TableName);
            SqlCommand sqldeleteInfoCom = new SqlCommand(sqldeleteInfo, connection);
            sqldeleteInfoCom.ExecuteNonQuery();
            connection.Close();
        }
        private void setEmptyWinNumber()
        {
            SqlConnection connection = new SqlConnection(Database.CnnVal("LottoryDB"));
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            string sqldeleteInfo = "UPDATE WinNumber SET Number = NULL";
            SqlCommand sqldeleteInfoCom = new SqlCommand(sqldeleteInfo, connection);
            sqldeleteInfoCom.ExecuteNonQuery();
            connection.Close();
        }

        private void MenuCustomerAccount_Management_Click(object sender, EventArgs e)
        {
            // Account Management
            ShowForm(CustomerInformation.Instance);
        }

        private void MenuCustomerAccount_Report_Click(object sender, EventArgs e)
        {
            // Customer Report Windows
            ShowForm(CustomerReportSummary.Instance);
        }
    }
}
