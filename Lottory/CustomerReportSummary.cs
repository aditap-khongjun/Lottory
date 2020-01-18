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
        }


    }
}
