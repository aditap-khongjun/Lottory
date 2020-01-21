using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace Lottory
{
    public partial class Summary_Customer_Page_Report : Form
    {
        private ReportParameterCollection CustomerInfo1;
        private ReportParameterCollection CustomerInfo2;
        private DataTable BuyingTable1;
        private DataTable BuyingSummary1;
        private DataTable PayingTable1;
        private DataTable PayingSummary1;
        private DataTable BuyingTable2;
        private DataTable BuyingSummary2;
        private DataTable PayingTable2;
        private DataTable PayingSummary2;

        public Summary_Customer_Page_Report()
        {
            InitializeComponent();
            // DataTable 
            CustomerInfo1 = new ReportParameterCollection();

            BuyingTable1 = new DataTable();
            BuyingTable1.Columns.Add("Type");
            BuyingTable1.Columns.Add("Price");
            BuyingTable1.Columns.Add("Discount");
            BuyingSummary1 = new DataTable();
            BuyingSummary1.Columns.Add("sumPrice");
            BuyingSummary1.Columns.Add("sumDiscount");

            PayingTable1 = new DataTable();
            PayingTable1.Columns.Add("Type");
            PayingTable1.Columns.Add("WinPrice");
            PayingTable1.Columns.Add("PayPrice");
            PayingSummary1 = new DataTable();
            PayingSummary1.Columns.Add("sumWinPrice");
            PayingSummary1.Columns.Add("sumPayPrice");

            CustomerInfo2 = new ReportParameterCollection();

            BuyingTable2 = new DataTable();
            BuyingTable2.Columns.Add("Type");
            BuyingTable2.Columns.Add("Price");
            BuyingTable2.Columns.Add("Discount");
            BuyingSummary2 = new DataTable();
            BuyingSummary2.Columns.Add("sumPrice");
            BuyingSummary2.Columns.Add("sumDiscount");

            PayingTable2 = new DataTable();
            PayingTable2.Columns.Add("Type");
            PayingTable2.Columns.Add("WinPrice");
            PayingTable2.Columns.Add("PayPrice");
            PayingSummary2 = new DataTable();
            PayingSummary2.Columns.Add("sumWinPrice");
            PayingSummary2.Columns.Add("sumPayPrice");
        }

        private void Summary_Customer_Page_Report_Load(object sender, EventArgs e)
        {
            ReportParameter customerid1 = new ReportParameter("CustomerID", "001");
            ReportParameter customername1 = new ReportParameter("CustomerName", "TestCustomer");
            ReportParameter page1 = new ReportParameter("Page", "All");
            ReportParameter sumPay1 = new ReportParameter("sumPay", "1,000");
            CustomerInfo1.Add(customerid1);
            CustomerInfo1.Add(customername1);
            CustomerInfo1.Add(page1);
            CustomerInfo1.Add(sumPay1);
            this.reportViewer1.LocalReport.SetParameters(CustomerInfo1);
            
            BuyingTable1.Rows.Add("Row1", "Price1", "Discount1");
            BuyingTable1.Rows.Add("Row2", "Price2", "Discount2");
            BuyingSummary1.Rows.Add("sumPrice", "sumDiscount");

            PayingTable1.Rows.Add("Row1", "WinPrice1", "PayPrice1");
            PayingTable1.Rows.Add("Row2", "winPrice2", "PayPrice2");
            PayingSummary1.Rows.Add("sumWinPrice", "sumPayPrice");

            ReportParameter customerid2 = new ReportParameter("CustomerID", "001");
            ReportParameter customername2 = new ReportParameter("CustomerName", "TestCustomer");
            ReportParameter page2 = new ReportParameter("Page", "All");
            ReportParameter sumPay2 = new ReportParameter("sumPay", "1,000");
            CustomerInfo2.Add(customerid2);
            CustomerInfo2.Add(customername2);
            CustomerInfo2.Add(page2);
            CustomerInfo2.Add(sumPay2);

            BuyingTable2.Rows.Add("Row1", "Price1", "Discount1");
            BuyingTable2.Rows.Add("Row2", "Price2", "Discount2");
            BuyingSummary2.Rows.Add("sumPrice", "sumDiscount");

            PayingTable2.Rows.Add("Row1", "WinPrice1", "PayPrice1");
            PayingTable2.Rows.Add("Row2", "winPrice2", "PayPrice2");
            PayingSummary2.Rows.Add("sumWinPrice", "sumPayPrice");

            List<ReportParameterCollection> reportParamList = new List<ReportParameterCollection>();
            reportParamList.Add(CustomerInfo1);
            reportParamList.Add(CustomerInfo2);
            /*
            this.reportViewer1.LocalReport.SetParameters(;
            this.CustomerInfoBindingSource.DataSource = CustomerInfo;
            this.BuyingTableBindingSource.DataSource = BuyingTable;
            this.BuyingSummaryBindingSource.DataSource = BuyingSummary;
            this.PayingTableBindingSource.DataSource = PayingTable;
            this.PayingSummaryBindingSource.DataSource = PayingSummary;
            */
            ReportDataSource rdsBuyingTable1 = new ReportDataSource("BuyingTable", BuyingTable1);
            ReportDataSource rdsBuyingTable2 = new ReportDataSource("BuyingTable", BuyingTable2);
            this.reportViewer1.LocalReport.DataSources.Add(rdsBuyingTable1);
            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }
    }
}
