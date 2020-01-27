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
    public partial class CustomerReportSummary : Form
    {
        private static CustomerReportSummary _instance;
        public static CustomerReportSummary Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new CustomerReportSummary();
                return _instance;
            }
        }
        private void CustomerReportSummary_FormClosed(object sender, FormClosedEventArgs e)
        {
            _instance = null;
        }
        public CustomerReportSummary()
        {
            InitializeComponent();
        }

        private void ReportAll_Click(object sender, EventArgs e)
        {
            // Document
            Summary_Report summaryForm = Summary_Report.Instance;
            summaryForm.MdiParent = this.MdiParent;
            summaryForm.Show();

        }

        private void ReportCustomer_Click(object sender, EventArgs e)
        {
            // Document
            Summary_Customer_Report customerSummary = Summary_Customer_Report.Instance;
            customerSummary.MdiParent = this.MdiParent;
            customerSummary.Show();
        }

        private void ReportCustomer_pay_Click(object sender, EventArgs e)
        {
            // Document
            Summary_Customer_pay_Report customerPaySummary = Summary_Customer_pay_Report.Instance;
            customerPaySummary.MdiParent = this.MdiParent;
            customerPaySummary.Show();
        }

        private void ReportCustomerPage_Click(object sender, EventArgs e)
        {
            // Document
            Summary_Customer_Page_Report_temp customerPageReport = Summary_Customer_Page_Report_temp.Instance;
            customerPageReport.MdiParent = this.MdiParent;
            customerPageReport.CustomerID = CustomerIDList.Text;
            customerPageReport.PageID = PageIDList.Text;
            customerPageReport.Show();
            customerPageReport.Activate();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            MainMenu mainMenu = MainMenu.Instance;
            mainMenu.MdiParent = this.MdiParent;
            mainMenu.Show();
            mainMenu.Activate();
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            // get Page ID
        }

        private void CustomerReportSummary_Load(object sender, EventArgs e)
        {
            // get Customer ID
            CustomerIDList.Items.AddRange(getCustomerIDList().ToArray());
        }
        private List<string> getCustomerIDList()
        {
            List<string> outIDList = new List<string>();

            // get CustomerID List from DB
            SqlConnection connection = new SqlConnection(Database.CnnVal("LottoryDB"));
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            string sqlgetCustomerID = "SELECT CustomerID FROM CustomerInfo";
            SqlCommand getCustomerIDCom = new SqlCommand(sqlgetCustomerID, connection);
            SqlDataReader CustomerInfo = getCustomerIDCom.ExecuteReader();
            while(CustomerInfo.Read())
            {
                outIDList.Add(CustomerInfo["CustomerID"].ToString());
            }
            connection.Close();
            return outIDList;
        }

        private void CustomerIDList_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> PageList = getPageList(CustomerIDList.Text);
            PageList.Insert(0, "ทั้งหมด");
            PageIDList.DataSource = PageList;
        }

        private List<string> getPageList(string customerID)
        {
            List<string> outPage = new List<string>();

            SqlConnection connection = new SqlConnection(Database.CnnVal("LottoryDB"));
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            string sqlgetPage = string.Format(@"SELECT Page FROM CustomerOrder
                                                WHERE CustomerID = '{0}'", customerID);
            SqlCommand sqlgetPageCom = new SqlCommand(sqlgetPage, connection);
            SqlDataReader PageInfo = sqlgetPageCom.ExecuteReader();
            while(PageInfo.Read())
            {
                outPage.Add(PageInfo["Page"].ToString());
            }
            connection.Close();
            return outPage;
        }

    }
}
