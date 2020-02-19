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

            //init table
            init_table();
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
            //Summary_Customer_Page_Report customerPageReport = Summary_Customer_Page_Report.Instance;
            //customerPageReport.MdiParent = this.MdiParent;
            //customerPageReport.CustomerID = CustomerIDList.Text;
            //customerPageReport.PageID = PageIDList.Text;
            //customerPageReport.Show();
            //customerPageReport.Activate();

            // update report
            update_report();
        }
        private void update_report()
        {
            CustomerID = CustomerIDList.Text;
            PageID = PageIDList.Text;
            // get Customer Buying Info
            DataTable CustomerBuyingInfo = getBuyingInfo(CustomerID, PageID);
            DataTable CustomerBuyingSummary = getBuyingSummary(CustomerBuyingInfo);
            // get Customer Paying Info
            DataTable CustomerPayingInfo = getPayingInfo(CustomerID, PageID);
            DataTable CustomerPayingSummary = getPayingSummary(CustomerPayingInfo);

            CustomerInfo.CustomerID = CustomerID;
            CustomerInfo.customerName = getCustomerName(CustomerID);
            CustomerInfo.PageID = PageID;
            CustomerInfo.sumPay = CustomerPayingSummary.Rows[0]["SumPayPrice"].ToString();

            this.cusotmerInfo_page_reportBindingSource.DataSource = CustomerInfo;
            this.BuyingTableBindingSource.DataSource = CustomerBuyingInfo;
            this.BuyingSummaryBindingSource.DataSource = CustomerBuyingSummary;
            this.PayingTableBindingSource.DataSource = CustomerPayingInfo;
            this.PayingSummaryBindingSource.DataSource = CustomerPayingSummary;
            this.reportViewer1.RefreshReport();
        }
        private string getCustomerName(string customerID)
        {
            string outName = string.Empty;
            SqlConnection connection = new SqlConnection(Database.CnnVal("LottoryDB"));
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            string sqlgetCustomerName = string.Format(@"SELECT CustomerName FROM CustomerInfo
                                                        WHERE CustomerID = '{0}'", customerID);
            SqlCommand sqlgetCustomerNameCom = new SqlCommand(sqlgetCustomerName, connection);
            SqlDataReader NameInfo = sqlgetCustomerNameCom.ExecuteReader();
            while (NameInfo.Read())
            {
                outName = NameInfo["CustomerName"].ToString();
            }
            connection.Close();
            return outName;
        }
        private DataTable getBuyingInfo(string CustomerID, string PageID)
        {
            DataTable outBuyingInfo = new DataTable();
            outBuyingInfo.Columns.Add("Type");
            outBuyingInfo.Columns.Add("Price");
            outBuyingInfo.Columns.Add("Discount");
            // for 3up
            int _price3up;
            int _disc3up;
            if (string.Equals(PageID, "ทั้งหมด"))
            {
                _price3up = getPriceFromDB(CustomerID, BaseTypeID.up3, string.Empty);
                _disc3up = _price3up - getDiscountFromDB(CustomerID, BaseTypeID.up3, string.Empty);
            }
            else
            {
                _price3up = getPriceFromDB(CustomerID, BaseTypeID.up3, PageID);
                _disc3up = _price3up - getDiscountFromDB(CustomerID, BaseTypeID.up3, PageID);
            }
            if (_price3up > 0)
            {
                outBuyingInfo.Rows.Add("3 บน", _price3up, _disc3up);
            }
            // for 3low
            int _price3low;
            int _disc3low;
            if (string.Equals(PageID, "ทั้งหมด"))
            {
                _price3low = getPriceFromDB(CustomerID, BaseTypeID.low3, string.Empty);
                _disc3low = _price3low - getDiscountFromDB(CustomerID, BaseTypeID.low3, string.Empty);
            }
            else
            {
                _price3low = getPriceFromDB(CustomerID, BaseTypeID.low3, PageID);
                _disc3low = _price3low - getDiscountFromDB(CustomerID, BaseTypeID.low3, PageID);
            }
            if (_price3low > 0)
            {
                outBuyingInfo.Rows.Add("3 ล่าง", _price3low, _disc3low);
            }
            // for 2up
            int _price2up;
            int _disc2up;
            if (string.Equals(PageID, "ทั้งหมด"))
            {
                _price2up = getPriceFromDB(CustomerID, BaseTypeID.up2, string.Empty);
                _disc2up = _price2up - getDiscountFromDB(CustomerID, BaseTypeID.up2, string.Empty);
            }
            else
            {
                _price2up = getPriceFromDB(CustomerID, BaseTypeID.up2, PageID);
                _disc2up = _price2up - getDiscountFromDB(CustomerID, BaseTypeID.up2, PageID);
            }
            if (_price2up > 0)
            {
                outBuyingInfo.Rows.Add("2 บน", _price2up, _disc2up);
            }
            // for 2low
            int _price2low;
            int _disc2low;
            if (string.Equals(PageID, "ทั้งหมด"))
            {
                _price2low = getPriceFromDB(CustomerID, BaseTypeID.low2, string.Empty);
                _disc2low = _price2low - getDiscountFromDB(CustomerID, BaseTypeID.low2, string.Empty);
            }
            else
            {
                _price2low = getPriceFromDB(CustomerID, BaseTypeID.low2, PageID);
                _disc2low = _price2low - getDiscountFromDB(CustomerID, BaseTypeID.low2, PageID);
            }
            if (_price2low > 0)
            {
                outBuyingInfo.Rows.Add("2 ล่าง", _price2low, _disc2low);
            }
            // for 2ht
            int _price2ht;
            int _disc2ht;
            if (string.Equals(PageID, "ทั้งหมด"))
            {
                _price2ht = getPriceFromDB(CustomerID, BaseTypeID.ht2, string.Empty);
                _disc2ht = _price2ht - getDiscountFromDB(CustomerID, BaseTypeID.ht2, string.Empty);
            }
            else
            {
                _price2ht = getPriceFromDB(CustomerID, BaseTypeID.ht2, PageID);
                _disc2ht = _price2ht - getDiscountFromDB(CustomerID, BaseTypeID.ht2, PageID);
            }
            if (_price2ht > 0)
            {
                outBuyingInfo.Rows.Add("ร้อยสิบ", _price2ht, _disc2ht);
            }
            // for 2hu
            int _price2hu;
            int _disc2hu;
            if (string.Equals(PageID, "ทั้งหมด"))
            {
                _price2hu = getPriceFromDB(CustomerID, BaseTypeID.hu2, string.Empty);
                _disc2hu = _price2hu - getDiscountFromDB(CustomerID, BaseTypeID.hu2, string.Empty);
            }
            else
            {
                _price2hu = getPriceFromDB(CustomerID, BaseTypeID.hu2, PageID);
                _disc2hu = _price2hu - getDiscountFromDB(CustomerID, BaseTypeID.hu2, PageID);
            }
            if (_price2hu > 0)
            {
                outBuyingInfo.Rows.Add("ร้อยหน่วย", _price2hu, _disc2hu);
            }
            // for 1up
            int _price1up;
            int _disc1up;
            if (string.Equals(PageID, "ทั้งหมด"))
            {
                _price1up = getPriceFromDB(CustomerID, BaseTypeID.up1, string.Empty);
                _disc1up = _price1up - getDiscountFromDB(CustomerID, BaseTypeID.up1, string.Empty);
            }
            else
            {
                _price1up = getPriceFromDB(CustomerID, BaseTypeID.up1, PageID);
                _disc1up = _price1up - getDiscountFromDB(CustomerID, BaseTypeID.up1, PageID);
            }
            if (_price1up > 0)
            {
                outBuyingInfo.Rows.Add("1 บน", _price1up, _disc1up);
            }
            // for 1low
            int _price1low;
            int _disc1low;
            if (string.Equals(PageID, "ทั้งหมด"))
            {
                _price1low = getPriceFromDB(CustomerID, BaseTypeID.low1, string.Empty);
                _disc1low = _price1low - getDiscountFromDB(CustomerID, BaseTypeID.low1, string.Empty);
            }
            else
            {
                _price1low = getPriceFromDB(CustomerID, BaseTypeID.low1, PageID);
                _disc1low = _price1low - getDiscountFromDB(CustomerID, BaseTypeID.low1, PageID);
            }
            if (_price1low > 0)
            {
                outBuyingInfo.Rows.Add("1 ล่าง", _price1low, _disc1low);
            }
            // for 1front
            int _price1front;
            int _disc1front;
            if (string.Equals(PageID, "ทั้งหมด"))
            {
                _price1front = getPriceFromDB(CustomerID, BaseTypeID.upfront1, string.Empty);
                _disc1front = _price1front - getDiscountFromDB(CustomerID, BaseTypeID.upfront1, string.Empty);
            }
            else
            {
                _price1front = getPriceFromDB(CustomerID, BaseTypeID.upfront1, PageID);
                _disc1front = _price1front - getDiscountFromDB(CustomerID, BaseTypeID.upfront1, PageID);
            }
            if (_price1front > 0)
            {
                outBuyingInfo.Rows.Add("1 หน้า", _price1front, _disc1front);
            }
            // for 1center
            int _price1center;
            int _disc1center;
            if (string.Equals(PageID, "ทั้งหมด"))
            {
                _price1center = getPriceFromDB(CustomerID, BaseTypeID.upcenter1, string.Empty);
                _disc1center = _price1center - getDiscountFromDB(CustomerID, BaseTypeID.upcenter1, string.Empty);
            }
            else
            {
                _price1center = getPriceFromDB(CustomerID, BaseTypeID.upcenter1, PageID);
                _disc1center = _price1center - getDiscountFromDB(CustomerID, BaseTypeID.upcenter1, PageID);
            }
            if (_price1center > 0)
            {
                outBuyingInfo.Rows.Add("1 กลาง", _price1center, _disc1center);
            }
            // for 1back
            int _price1back;
            int _disc1back;
            if (string.Equals(PageID, "ทั้งหมด"))
            {
                _price1back = getPriceFromDB(CustomerID, BaseTypeID.upback1, string.Empty);
                _disc1back = _price1back - getDiscountFromDB(CustomerID, BaseTypeID.upback1, string.Empty);
            }
            else
            {
                _price1back = getPriceFromDB(CustomerID, BaseTypeID.upback1, PageID);
                _disc1back = _price1back - getDiscountFromDB(CustomerID, BaseTypeID.upback1, PageID);
            }
            if (_price1back > 0)
            {
                outBuyingInfo.Rows.Add("1 หลัง", _price1back, _disc1back);
            }
            // for 1lowfront
            int _price1lowfront;
            int _disc1lowfront;
            if (string.Equals(PageID, "ทั้งหมด"))
            {
                _price1lowfront = getPriceFromDB(CustomerID, BaseTypeID.lowfront1, string.Empty);
                _disc1lowfront = _price1lowfront - getDiscountFromDB(CustomerID, BaseTypeID.lowfront1, string.Empty);
            }
            else
            {
                _price1lowfront = getPriceFromDB(CustomerID, BaseTypeID.lowfront1, PageID);
                _disc1lowfront = _price1lowfront - getDiscountFromDB(CustomerID, BaseTypeID.lowfront1, PageID);
            }
            if (_price1lowfront > 0)
            {
                outBuyingInfo.Rows.Add("1 ล่างหน้า", _price1lowfront, _disc1lowfront);
            }
            // for 1lowback
            int _price1lowback;
            int _disc1lowback;
            if (string.Equals(PageID, "ทั้งหมด"))
            {
                _price1lowback = getPriceFromDB(CustomerID, BaseTypeID.lowback1, string.Empty);
                _disc1lowback = _price1lowback - getDiscountFromDB(CustomerID, BaseTypeID.lowback1, string.Empty);
            }
            else
            {
                _price1lowback = getPriceFromDB(CustomerID, BaseTypeID.lowback1, PageID);
                _disc1lowback = _price1lowback - getDiscountFromDB(CustomerID, BaseTypeID.lowback1, PageID);
            }
            if (_price1lowback > 0)
            {
                outBuyingInfo.Rows.Add("1 ล่างหลัง", _price1lowback, _disc1lowback);
            }

            return outBuyingInfo;
        }
        private DataTable getBuyingSummary(DataTable buyingInfo)
        {
            DataTable outBuyingSummary = new DataTable();
            outBuyingSummary.Columns.Add("SumPrice");
            outBuyingSummary.Columns.Add("SumDiscount");

            double _sumPrice = 0;
            double _sumDiscount = 0;
            foreach (DataRow dr in buyingInfo.Rows)
            {
                _sumPrice += Convert.ToDouble(dr.ItemArray[1]);
                _sumDiscount += Convert.ToDouble(dr.ItemArray[2]);
            }
            DataRow rowSummary = outBuyingSummary.NewRow();
            rowSummary["SumPrice"] = _sumPrice.ToString("N0");
            rowSummary["SumDiscount"] = _sumDiscount.ToString("N0");
            outBuyingSummary.Rows.Add(rowSummary);
            return outBuyingSummary;
        }
        private List<string> getWinNumber(string WinType)
        {
            List<string> outNumber = new List<string>();
            SqlConnection connection = new SqlConnection(Database.CnnVal("LottoryDB"));
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            string getWinNumber = string.Format(@"SELECT Number FROM WinNumber
                                                  WHERE TypeName = N'{0}'", WinType);
            SqlCommand getWinNumberCom = new SqlCommand(getWinNumber, connection);
            SqlDataReader winNumberInfo = getWinNumberCom.ExecuteReader();
            while (winNumberInfo.Read())
            {
                outNumber.Add(winNumberInfo["Number"].ToString());
            }

            return outNumber;
        }
        private DataTable getPayingInfo(string CustomerID, string PageID)
        {
            DataTable outPayingInfo = new DataTable();
            outPayingInfo.Columns.Add("Type");
            outPayingInfo.Columns.Add("WinPrice");
            outPayingInfo.Columns.Add("PayPrice");

            // for 3up
            // get winnumber
            List<string> winNumber3up = getWinNumber(WinNumberType.up3);
            // get winprice
            getwinPriceFromDB(CustomerID, BaseTypeID.up3, winNumber3up, PageID, out double _winPrice3up, out double _winRate3up);
            // get payprice
            double _payPrice3up = _winPrice3up * _winRate3up;
            if (_winPrice3up > 0)
            {
                outPayingInfo.Rows.Add("3 บน", _winPrice3up.ToString("N0"), _payPrice3up.ToString("N0"));
            }
            // for 3low
            // get winnumber
            List<string> winNumber3low = getWinNumber(WinNumberType.low3);
            // get winprice
            getwinPriceFromDB(CustomerID, BaseTypeID.low3, winNumber3low, PageID, out double _winPrice3low, out double _winRate3low);
            // get payprice
            double _payPrice3low = _winPrice3low * _winRate3low;
            if (_winPrice3low > 0)
            {
                outPayingInfo.Rows.Add("3 ล่าง", _winPrice3low.ToString("N0"), _payPrice3low.ToString("N0"));
            }
            // for 2up
            // get winnumber
            List<string> winNumber2up = getWinNumber(WinNumberType.up2);
            // get winprice
            getwinPriceFromDB(CustomerID, BaseTypeID.up2, winNumber2up, PageID, out double _winPrice2up, out double _winRate2up);
            // get payprice
            double _payPrice2up = _winPrice2up * _winRate2up;
            if (_winPrice2up > 0)
            {
                outPayingInfo.Rows.Add("2 บน", _winPrice2up.ToString("N0"), _payPrice2up.ToString("N0"));
            }
            // for 2low
            // get winnumber
            List<string> winNumber2low = getWinNumber(WinNumberType.low2);
            // get winprice
            getwinPriceFromDB(CustomerID, BaseTypeID.low2, winNumber2low, PageID, out double _winPrice2low, out double _winRate2low);
            // get payprice
            double _payPrice2low = _winPrice2low * _winRate2low;
            if (_winPrice2low > 0)
            {
                outPayingInfo.Rows.Add("2 ล่าง", _winPrice2low.ToString("N0"), _payPrice2low.ToString("N0"));
            }
            // for 2ht
            // get winnumber
            List<string> winNumber2ht = getWinNumber(WinNumberType.ht2);
            // get winprice
            getwinPriceFromDB(CustomerID, BaseTypeID.ht2, winNumber2ht, PageID, out double _winPrice2ht, out double _winRate2ht);
            // get payprice
            double _payPrice2ht = _winPrice2ht * _winRate2ht;
            if (_winPrice2ht > 0)
            {
                outPayingInfo.Rows.Add("ร้อยสิบ", _winPrice2ht.ToString("N0"), _payPrice2ht.ToString("N0"));
            }
            // for 2hu
            // get winnumber
            List<string> winNumber2hu = getWinNumber(WinNumberType.hu2);
            // get winprice
            getwinPriceFromDB(CustomerID, BaseTypeID.hu2, winNumber2hu, PageID, out double _winPrice2hu, out double _winRate2hu);
            // get payprice
            double _payPrice2hu = _winPrice2hu * _winRate2hu;
            if (_winPrice2hu > 0)
            {
                outPayingInfo.Rows.Add("ร้อยหน่วย", _winPrice2hu.ToString("N0"), _payPrice2hu.ToString("N0"));
            }
            // for 1up
            // get winnumber
            List<string> winNumber1up = getWinNumber(WinNumberType.up1);
            // get winprice
            getwinPriceFromDB(CustomerID, BaseTypeID.up1, winNumber1up, PageID, out double _winPrice1up, out double _winRate1up);
            // get payprice
            double _payPrice1up = _winPrice1up * _winRate1up;
            if (_winPrice1up > 0)
            {
                outPayingInfo.Rows.Add("1 บน", _winPrice1up.ToString("N0"), _payPrice1up.ToString("N0"));
            }
            // for llow
            // get winnumber
            List<string> winNumber1low = getWinNumber(WinNumberType.low1);
            // get winprice
            getwinPriceFromDB(CustomerID, BaseTypeID.low1, winNumber1low, PageID, out double _winPrice1low, out double _winRate1low);
            // get payprice
            double _payPrice1low = _winPrice1low * _winRate1low;
            if (_winPrice1low > 0)
            {
                outPayingInfo.Rows.Add("1 ล่าง", _winPrice1low.ToString("N0"), _payPrice1low.ToString("N0"));
            }
            // for 1front
            // get winnumber
            List<string> winNumber1front = getWinNumber(WinNumberType.upfront1);
            // get winprice
            getwinPriceFromDB(CustomerID, BaseTypeID.upfront1, winNumber1front, PageID, out double _winPrice1front, out double _winRate1front);
            // get payprice
            double _payPrice1front = _winPrice1front * _winRate1front;
            if (_winPrice1front > 0)
            {
                outPayingInfo.Rows.Add("1 หน้า", _winPrice1front.ToString("N0"), _payPrice1front.ToString("N0"));
            }
            // for 1center
            // get winnumber
            List<string> winNumber1center = getWinNumber(WinNumberType.upcenter1);
            // get winprice
            getwinPriceFromDB(CustomerID, BaseTypeID.upcenter1, winNumber1center, PageID, out double _winPrice1center, out double _winRate1center);
            // get payprice
            double _payPrice1center = _winPrice1center * _winRate1center;
            if (_winPrice1center > 0)
            {
                outPayingInfo.Rows.Add("1 กลาง", _winPrice1center.ToString("N0"), _payPrice1center.ToString("N0"));
            }
            // for 1back
            // get winnumber
            List<string> winNumber1back = getWinNumber(WinNumberType.upback1);
            // get winprice
            getwinPriceFromDB(CustomerID, BaseTypeID.upback1, winNumber1back, PageID, out double _winPrice1back, out double _winRate1back);
            // get payprice
            double _payPrice1back = _winPrice1back * _winRate1back;
            if (_winPrice1back > 0)
            {
                outPayingInfo.Rows.Add("1 หลัง", _winPrice1back.ToString("N0"), _payPrice1back.ToString("N0"));
            }
            // for 1lowfront
            // get winnumber
            List<string> winNumber1lowfront = getWinNumber(WinNumberType.lowfront1);
            // get winprice
            getwinPriceFromDB(CustomerID, BaseTypeID.lowfront1, winNumber1lowfront, PageID, out double _winPrice1lowfront, out double _winRate1lowfront);
            // get payprice
            double _payPrice1lowfront = _winPrice1lowfront * _winRate1lowfront;
            if (_winPrice1lowfront > 0)
            {
                outPayingInfo.Rows.Add("1 ล่างหน้า", _winPrice1lowfront.ToString("N0"), _payPrice1lowfront.ToString("N0"));
            }
            // for 1lowback
            // get winnumber
            List<string> winNumber1lowback = getWinNumber(WinNumberType.lowback1);
            // get winprice
            getwinPriceFromDB(CustomerID, BaseTypeID.lowback1, winNumber1lowback, PageID, out double _winPrice1lowback, out double _winRate1lowback);
            // get payprice
            double _payPrice1lowback = _winPrice1lowback * _winRate1lowback;
            if (_winPrice1lowback > 0)
            {
                outPayingInfo.Rows.Add("1 ล่างหลัง", _winPrice1lowback.ToString("N0"), _payPrice1lowback.ToString("N0"));
            }

            return outPayingInfo;
        }
        private void getwinPriceFromDB(string customerID, int TypeID, List<string> WinNumber, string PageID, out double winPrice, out double winRate)
        {
            winPrice = 0;
            winRate = 0;
            string sqlgetWinPrice = string.Empty;
            double _price;
            double _winRate = 0;
            foreach (string winNumber in WinNumber)
            {
                SqlConnection connection = new SqlConnection(Database.CnnVal("LottoryDB"));
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                switch (TypeID)
                {
                    case BaseTypeID.up3:
                        if (string.Equals(PageID, "ทั้งหมด"))
                        {
                            sqlgetWinPrice = string.Format(@"SELECT oe.Number, oe.Price, ci.{2} AS winRate
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE oe.Number = '{0}' AND oe.TypeID = {1} AND c.CustomerID = '{3}'", winNumber, TypeID.ToString(), DBWinRate.up3, customerID);
                        }
                        else
                        {
                            sqlgetWinPrice = string.Format(@"SELECT oe.Number, oe.Price, ci.{2} AS winRate
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE oe.Number = '{0}' AND oe.TypeID = {1} AND c.CustomerID = '{3}' AND c.Page = {4}", winNumber, TypeID.ToString(), DBWinRate.up3, customerID, PageID);
                        }
                        break;
                    case BaseTypeID.low3:
                        if (string.Equals(PageID, "ทั้งหมด"))
                        {
                            sqlgetWinPrice = string.Format(@"SELECT oe.Number, oe.Price, ci.{2} AS winRate
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE oe.Number = '{0}' AND oe.TypeID = {1} AND c.CustomerID = '{3}'", winNumber, TypeID.ToString(), DBWinRate.low3, customerID);
                        }
                        else
                        {
                            sqlgetWinPrice = string.Format(@"SELECT oe.Number, oe.Price, ci.{2} AS winRate
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE oe.Number = '{0}' AND oe.TypeID = {1} AND c.CustomerID = '{3}' AND c.Page = {4}", winNumber, TypeID.ToString(), DBWinRate.low3, customerID, PageID);
                        }
                        break;
                    case BaseTypeID.up2:
                    case BaseTypeID.ht2:
                    case BaseTypeID.hu2:
                        if (string.Equals(PageID, "ทั้งหมด"))
                        {
                            sqlgetWinPrice = string.Format(@"SELECT oe.Number, oe.Price, ci.{2} AS winRate
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE oe.Number = '{0}' AND oe.TypeID = {1} AND c.CustomerID = '{3}'", winNumber, TypeID.ToString(), DBWinRate.up2, customerID);
                        }
                        else
                        {
                            sqlgetWinPrice = string.Format(@"SELECT oe.Number, oe.Price, ci.{2} AS winRate
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE oe.Number = '{0}' AND oe.TypeID = {1} AND c.CustomerID = '{3}' AND c.Page = {4}", winNumber, TypeID.ToString(), DBWinRate.up2, customerID, PageID);
                        }

                        break;
                    case BaseTypeID.low2:
                        if (string.Equals(PageID, "ทั้งหมด"))
                        {
                            sqlgetWinPrice = string.Format(@"SELECT oe.Number, oe.Price, ci.{2} AS winRate
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE oe.Number = '{0}' AND oe.TypeID = {1} AND c.CustomerID = '{3}'", winNumber, TypeID.ToString(), DBWinRate.low2, customerID);
                        }
                        else
                        {
                            sqlgetWinPrice = string.Format(@"SELECT oe.Number, oe.Price, ci.{2} AS winRate
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE oe.Number = '{0}' AND oe.TypeID = {1} AND c.CustomerID = '{3}' AND c.Page = {4}", winNumber, TypeID.ToString(), DBWinRate.low2, customerID, PageID);
                        }
                        break;
                    case BaseTypeID.up1:
                        if (string.Equals(PageID, "ทั้งหมด"))
                        {
                            sqlgetWinPrice = string.Format(@"SELECT oe.Number, oe.Price, ci.{2} AS winRate
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE oe.Number = '{0}' AND oe.TypeID = {1} AND c.CustomerID = '{3}'", winNumber, TypeID.ToString(), DBWinRate.up1, customerID);
                        }
                        else
                        {
                            sqlgetWinPrice = string.Format(@"SELECT oe.Number, oe.Price, ci.{2} AS winRate
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE oe.Number = '{0}' AND oe.TypeID = {1} AND c.CustomerID = '{3}' AND c.Page = {4}", winNumber, TypeID.ToString(), DBWinRate.up1, customerID, PageID);
                        }

                        break;
                    case BaseTypeID.low1:
                        if (string.Equals(PageID, "ทั้งหมด"))
                        {
                            sqlgetWinPrice = string.Format(@"SELECT oe.Number, oe.Price, ci.{2} AS winRate
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE oe.Number = '{0}' AND oe.TypeID = {1} AND c.CustomerID = '{3}'", winNumber, TypeID.ToString(), DBWinRate.low1, customerID);
                        }
                        else
                        {
                            sqlgetWinPrice = string.Format(@"SELECT oe.Number, oe.Price, ci.{2} AS winRate
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE oe.Number = '{0}' AND oe.TypeID = {1} AND c.CustomerID = '{3}' AND c.Page = {4}", winNumber, TypeID.ToString(), DBWinRate.low1, customerID, PageID);
                        }

                        break;
                    case BaseTypeID.upfront1:
                        if (string.Equals(PageID, "ทั้งหมด"))
                        {
                            sqlgetWinPrice = string.Format(@"SELECT oe.Number, oe.Price, ci.{2} AS winRate
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE oe.Number = '{0}' AND oe.TypeID = {1} AND c.CustomerID = '{3}'", winNumber, TypeID.ToString(), DBWinRate.upfront1, customerID);
                        }
                        else
                        {
                            sqlgetWinPrice = string.Format(@"SELECT oe.Number, oe.Price, ci.{2} AS winRate
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE oe.Number = '{0}' AND oe.TypeID = {1} AND c.CustomerID = '{3}' AND c.Page = {4}", winNumber, TypeID.ToString(), DBWinRate.upfront1, customerID, PageID);
                        }

                        break;
                    case BaseTypeID.upback1:
                        if (string.Equals(PageID, "ทั้งหมด"))
                        {
                            sqlgetWinPrice = string.Format(@"SELECT oe.Number, oe.Price, ci.{2} AS winRate
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE oe.Number = '{0}' AND oe.TypeID = {1} AND c.CustomerID = '{3}'", winNumber, TypeID.ToString(), DBWinRate.upback1, customerID);
                        }
                        else
                        {
                            sqlgetWinPrice = string.Format(@"SELECT oe.Number, oe.Price, ci.{2} AS winRate
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE oe.Number = '{0}' AND oe.TypeID = {1} AND c.CustomerID = '{3}' AND c.Page = {4}", winNumber, TypeID.ToString(), DBWinRate.upback1, customerID, PageID);
                        }

                        break;
                    case BaseTypeID.upcenter1:
                        if (string.Equals(PageID, "ทั้งหมด"))
                        {
                            sqlgetWinPrice = string.Format(@"SELECT oe.Number, oe.Price, ci.{2} AS winRate
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE oe.Number = '{0}' AND oe.TypeID = {1} AND c.CustomerID = '{3}'", winNumber, TypeID.ToString(), DBWinRate.upcenter1, customerID);
                        }
                        else
                        {
                            sqlgetWinPrice = string.Format(@"SELECT oe.Number, oe.Price, ci.{2} AS winRate
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE oe.Number = '{0}' AND oe.TypeID = {1} AND c.CustomerID = '{3}' AND c.Page = {4}", winNumber, TypeID.ToString(), DBWinRate.upcenter1, customerID, PageID);
                        }

                        break;
                    case BaseTypeID.lowfront1:
                        if (string.Equals(PageID, "ทั้งหมด"))
                        {
                            sqlgetWinPrice = string.Format(@"SELECT oe.Number, oe.Price, ci.{2} AS winRate
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE oe.Number = '{0}' AND oe.TypeID = {1} AND c.CustomerID = '{3}'", winNumber, TypeID.ToString(), DBWinRate.upfront1, customerID);
                        }
                        else
                        {
                            sqlgetWinPrice = string.Format(@"SELECT oe.Number, oe.Price, ci.{2} AS winRate
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE oe.Number = '{0}' AND oe.TypeID = {1} AND c.CustomerID = '{3}' AND c.Page = {4}", winNumber, TypeID.ToString(), DBWinRate.upfront1, customerID, PageID);
                        }

                        break;
                    case BaseTypeID.lowback1:
                        if (string.Equals(PageID, "ทั้งหมด"))
                        {
                            sqlgetWinPrice = string.Format(@"SELECT oe.Number, oe.Price, ci.{2} AS winRate
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE oe.Number = '{0}' AND oe.TypeID = {1} AND c.CustomerID = '{3}'", winNumber, TypeID.ToString(), DBWinRate.upback1, customerID);
                        }
                        else
                        {
                            sqlgetWinPrice = string.Format(@"SELECT oe.Number, oe.Price, ci.{2} AS winRate
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE oe.Number = '{0}' AND oe.TypeID = {1} AND c.CustomerID = '{3}' AND c.Page = {4}", winNumber, TypeID.ToString(), DBWinRate.upback1, customerID, PageID);
                        }
                        break;

                }
                SqlCommand sqlgetWinPriceCom = new SqlCommand(sqlgetWinPrice, connection);
                SqlDataReader winPriceInfo = sqlgetWinPriceCom.ExecuteReader();
                while (winPriceInfo.Read())
                {
                    _price = Convert.ToDouble(winPriceInfo["Price"]);
                    _winRate = Convert.ToDouble(winPriceInfo["winRate"]);
                    winPrice += _price;
                }
                connection.Close();
                //winPrice = outWinNumber;
                winRate = _winRate;
            }

        }
        private int getDiscountFromDB(string CustomerID, int TypeID, string PageID)
        {
            int outDisc = 0;
            SqlConnection connection = new SqlConnection(Database.CnnVal("LottoryDB"));
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            string sqlgetPrice;
            if (string.IsNullOrEmpty(PageID))
            {
                sqlgetPrice = string.Format(@"SELECT ISNULL(SUM(DiscPrice),0) AS Price
                                              FROM (CustomerOrder c INNER JOIN OrderList o ON c.OrderID = o.OrderID)
                                              INNER JOIN OrderListExpand oe ON o.OrderListID = oe.OrderListID
                                              WHERE oe.TypeID = {0} AND c.CustomerID = '{1}'", TypeID.ToString(), CustomerID);
            }
            else
            {
                sqlgetPrice = string.Format(@"SELECT ISNULL(SUM(DiscPrice),0) AS Price
                                              FROM (CustomerOrder c INNER JOIN OrderList o ON c.OrderID = o.OrderID)
                                              INNER JOIN OrderListExpand oe ON o.OrderListID = oe.OrderListID
                                              WHERE oe.TypeID = {0} AND c.CustomerID = '{1}' AND c.Page = {2}", TypeID.ToString(), CustomerID, PageID);
            }

            SqlCommand sqlgetPriceCom = new SqlCommand(sqlgetPrice, connection);
            SqlDataReader PriceInfo = sqlgetPriceCom.ExecuteReader();
            while (PriceInfo.Read())
            {
                outDisc = Convert.ToInt32(PriceInfo["Price"]);
            }
            connection.Close();
            return outDisc;
        }
        private DataTable getPayingSummary(DataTable payingInfo)
        {
            DataTable outPayingSummary = new DataTable();
            outPayingSummary.Columns.Add("SumWinPrice");
            outPayingSummary.Columns.Add("SumPayPrice");

            double _sumWinPrice = 0;
            double _sumPayPrice = 0;
            foreach (DataRow dr in payingInfo.Rows)
            {
                _sumWinPrice += Convert.ToDouble(dr.ItemArray[1]);
                _sumPayPrice += Convert.ToDouble(dr.ItemArray[2]);
            }

            DataRow rowSummary = outPayingSummary.NewRow();
            rowSummary["SumWinPrice"] = _sumWinPrice.ToString("N0");
            rowSummary["SumPayPrice"] = _sumPayPrice.ToString("N0");
            outPayingSummary.Rows.Add(rowSummary);
            return outPayingSummary;
        }
        private int getPriceFromDB(string CustomerID, int TypeID, string PageID)
        {
            int outPrice = 0;
            SqlConnection connection = new SqlConnection(Database.CnnVal("LottoryDB"));
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            string sqlgetPrice;
            if (string.IsNullOrEmpty(PageID))
            {
                sqlgetPrice = string.Format(@"SELECT ISNULL(SUM(OwnPrice),0) AS Price
                                              FROM (CustomerOrder c INNER JOIN OrderList o ON c.OrderID = o.OrderID)
                                              INNER JOIN OrderListExpand oe ON o.OrderListID = oe.OrderListID
                                              WHERE oe.TypeID = {0} AND c.CustomerID = '{1}'", TypeID.ToString(), CustomerID);
            }
            else
            {
                sqlgetPrice = string.Format(@"SELECT ISNULL(SUM(OwnPrice),0) AS Price
                                              FROM (CustomerOrder c INNER JOIN OrderList o ON c.OrderID = o.OrderID)
                                              INNER JOIN OrderListExpand oe ON o.OrderListID = oe.OrderListID
                                              WHERE oe.TypeID = {0} AND c.CustomerID = '{1}' AND c.Page = {2}", TypeID.ToString(), CustomerID, PageID);
            }

            SqlCommand sqlgetPriceCom = new SqlCommand(sqlgetPrice, connection);
            SqlDataReader PriceInfo = sqlgetPriceCom.ExecuteReader();
            while (PriceInfo.Read())
            {
                outPrice = Convert.ToInt32(PriceInfo["Price"]);
            }
            connection.Close();
            return outPrice;
        }
        public string CustomerID;
        public string PageID;

        // for inside form
        private cusotmerInfo_page_report CustomerInfo;
        private DataTable BuyingTable;
        private DataTable BuyingSummary;
        private DataTable PayingTable;
        private DataTable PayingSummary;
        private void init_table()
        {
            CustomerInfo = new cusotmerInfo_page_report();

            BuyingTable = new DataTable();
            BuyingTable.Columns.Add("Type");
            BuyingTable.Columns.Add("Price");
            BuyingTable.Columns.Add("Discount");
            BuyingSummary = new DataTable();
            BuyingSummary.Columns.Add("sumPrice");
            BuyingSummary.Columns.Add("sumDiscount");

            PayingTable = new DataTable();
            PayingTable.Columns.Add("Type");
            PayingTable.Columns.Add("WinPrice");
            PayingTable.Columns.Add("PayPrice");
            PayingSummary = new DataTable();
            PayingSummary.Columns.Add("sumWinPrice");
            PayingSummary.Columns.Add("sumPayPrice");

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
            CustomerIDList.Focus();
            
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

        private void CustomerIDList_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Enter:
                    PageIDList.Focus();
                    break;
                case Keys.Right:
                    PageIDList.Focus();
                    PageIDList.SelectAll();
                    break;
            }
        }

        private void PageIDList_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    update_report();
                    break;
                case Keys.Left:
                    CustomerIDList.Focus();
                    CustomerIDList.SelectAll();
                    break;
            }
        }
    }
}
