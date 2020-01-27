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
using System.Data.SqlClient;

namespace Lottory
{
    public partial class Summary_Customer_Page_Report_temp : Form
    {
        private static Summary_Customer_Page_Report_temp _instance;
        public static Summary_Customer_Page_Report_temp Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Summary_Customer_Page_Report_temp();
                return _instance;
            }
        }
        private void Summary_Customer_Page_Report_FormClosed(object sender, FormClosedEventArgs e)
        {
            _instance = null;
        }
        public string CustomerID;
        public string PageID;

        // for inside form
        private ReportParameterCollection CustomerInfo;
        private DataTable BuyingTable;
        private DataTable BuyingSummary;
        private DataTable PayingTable;
        private DataTable PayingSummary;

        public Summary_Customer_Page_Report_temp()
        {
            InitializeComponent();
            // DataTable 
            init_table();
        }
        private void init_table()
        {
            CustomerInfo = new ReportParameterCollection();

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

        private string getCustomerName(string customerID)
        {
            string outName = string.Empty;
            SqlConnection connection = new SqlConnection(Database.CnnVal("LottoryDB"));
            if(connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            string sqlgetCustomerName = string.Format(@"SELECT CustomerName FROM CustomerInfo
                                                        WHERE CustomerID = '{0}'", customerID);
            SqlCommand sqlgetCustomerNameCom = new SqlCommand(sqlgetCustomerName, connection);
            SqlDataReader NameInfo = sqlgetCustomerNameCom.ExecuteReader();
            while(NameInfo.Read())
            {
                outName = NameInfo["CustomerName"].ToString();
            }
            connection.Close();
            return outName;
        }
        private void Summary_Customer_Page_Report_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'MyLottoDBDataSet.Customer_Report_Dataset' table. You can move, or remove it, as needed.
            //this.Customer_Report_DatasetTableAdapter.Fill(this.MyLottoDBDataSet.Customer_Report_Dataset);
            // get Customer Name

            // get Customer Buying Info
            DataTable CustomerBuyingInfo = getBuyingInfo(CustomerID, PageID);
            DataTable CustomerBuyingSummary = getBuyingSummary(CustomerBuyingInfo);

            // get Customer Paying Info
            DataTable CustomerPayingInfo = getPayingInfo(CustomerID, PageID);
            DataTable CustomerPayingSummary = getPayingSummary(CustomerBuyingInfo);

            ReportParameter customerid = new ReportParameter("CustomerID", CustomerID);
            ReportParameter page = new ReportParameter("Page", PageID);
            ReportParameter customername = new ReportParameter("CustomerName", getCustomerName(CustomerID));
            ReportParameter Paysummary = new ReportParameter("sumPay", Convert.ToInt32(CustomerPayingSummary.Rows[0]["sumPayPrice"]).ToString("N0"));
            CustomerInfo.Add(customerid);
            CustomerInfo.Add(page);
            CustomerInfo.Add(customername);
            CustomerInfo.Add(Paysummary);
            //this.reportViewer1.LocalReport.SetParameters(CustomerInfo);

            /*
            ReportParameter sumPay = new ReportParameter("sumPay", "1,000");
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
            */
            
            //this.BuyingTableBindingSource.DataSource = CustomerBuyingInfo;
           // this.BuyingSummaryBindingSource.DataSource = CustomerBuyingSummary;
            //this.PayingTableBindingSource.DataSource = CustomerPayingInfo;
            //this.PayingSummaryBindingSource.DataSource = CustomerPayingSummary;
            
            //ReportDataSource rdsBuyingTable1 = new ReportDataSource("BuyingTable", BuyingTable1);
            //ReportDataSource rdsBuyingTable2 = new ReportDataSource("BuyingTable", BuyingTable2);
            //this.reportViewer1.LocalReport.DataSources.Add(rdsBuyingTable1);
            //this.reportViewer1.RefreshReport();
           // this.reportViewer1.RefreshReport();

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
            if(string.Equals(PageID,"ทั้งหมด"))
            {
                _price3up = getPriceFromDB(CustomerID, BaseTypeID.up3,string.Empty);
                _disc3up = getDiscountFromDB(CustomerID, BaseTypeID.up3, string.Empty);
            }
            else
            {
                _price3up = getPriceFromDB(CustomerID, BaseTypeID.up3, PageID);
                _disc3up = getDiscountFromDB(CustomerID, BaseTypeID.up3, PageID);
            }
            if(_price3up > 0)
            {
                outBuyingInfo.Rows.Add("3 บน", _price3up, _disc3up);
            }
            // for 3low
            int _price3low;
            int _disc3low;
            if(string.Equals(PageID, "ทั้งหมด"))
            {
                _price3low = getPriceFromDB(CustomerID, BaseTypeID.low3, string.Empty);
                _disc3low = getDiscountFromDB(CustomerID, BaseTypeID.low3, string.Empty);
            }
            else
            {
                _price3low = getPriceFromDB(CustomerID, BaseTypeID.low3, PageID);
                _disc3low = getDiscountFromDB(CustomerID, BaseTypeID.low3, PageID);
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
                _disc2up = getDiscountFromDB(CustomerID, BaseTypeID.up2, string.Empty);
            }
            else
            {
                _price2up = getPriceFromDB(CustomerID, BaseTypeID.up2, PageID);
                _disc2up = getDiscountFromDB(CustomerID, BaseTypeID.up2, PageID);
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
                _disc2low = getDiscountFromDB(CustomerID, BaseTypeID.low2, string.Empty);
            }
            else
            {
                _price2low = getPriceFromDB(CustomerID, BaseTypeID.low2, PageID);
                _disc2low = getDiscountFromDB(CustomerID, BaseTypeID.low2, PageID);
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
                _disc2ht = getDiscountFromDB(CustomerID, BaseTypeID.ht2, string.Empty);
            }
            else
            {
                _price2ht = getPriceFromDB(CustomerID, BaseTypeID.ht2, PageID);
                _disc2ht = getDiscountFromDB(CustomerID, BaseTypeID.ht2, PageID);
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
                _disc2hu = getDiscountFromDB(CustomerID, BaseTypeID.hu2, string.Empty);
            }
            else
            {
                _price2hu = getPriceFromDB(CustomerID, BaseTypeID.hu2, PageID);
                _disc2hu = getDiscountFromDB(CustomerID, BaseTypeID.hu2, PageID);
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
                _disc1up = getDiscountFromDB(CustomerID, BaseTypeID.up1, string.Empty);
            }
            else
            {
                _price1up = getPriceFromDB(CustomerID, BaseTypeID.up1, PageID);
                _disc1up = getDiscountFromDB(CustomerID, BaseTypeID.up1, PageID);
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
                _disc1low = getDiscountFromDB(CustomerID, BaseTypeID.low1, string.Empty);
            }
            else
            {
                _price1low = getPriceFromDB(CustomerID, BaseTypeID.low1, PageID);
                _disc1low = getDiscountFromDB(CustomerID, BaseTypeID.low1, PageID);
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
                _disc1front = getDiscountFromDB(CustomerID, BaseTypeID.upfront1, string.Empty);
            }
            else
            {
                _price1front = getPriceFromDB(CustomerID, BaseTypeID.upfront1, PageID);
                _disc1front = getDiscountFromDB(CustomerID, BaseTypeID.upfront1, PageID);
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
                _disc1center = getDiscountFromDB(CustomerID, BaseTypeID.upcenter1, string.Empty);
            }
            else
            {
                _price1center = getPriceFromDB(CustomerID, BaseTypeID.upcenter1, PageID);
                _disc1center = getDiscountFromDB(CustomerID, BaseTypeID.upcenter1, PageID);
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
                _disc1back = getDiscountFromDB(CustomerID, BaseTypeID.upback1, string.Empty);
            }
            else
            {
                _price1back = getPriceFromDB(CustomerID, BaseTypeID.upback1, PageID);
                _disc1back = getDiscountFromDB(CustomerID, BaseTypeID.upback1, PageID);
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
                _disc1lowfront = getDiscountFromDB(CustomerID, BaseTypeID.lowfront1, string.Empty);
            }
            else
            {
                _price1lowfront = getPriceFromDB(CustomerID, BaseTypeID.lowfront1, PageID);
                _disc1lowfront = getDiscountFromDB(CustomerID, BaseTypeID.lowfront1, PageID);
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
                _disc1lowback = getDiscountFromDB(CustomerID, BaseTypeID.lowback1, string.Empty);
            }
            else
            {
                _price1lowback = getPriceFromDB(CustomerID, BaseTypeID.lowback1, PageID);
                _disc1lowback = getDiscountFromDB(CustomerID, BaseTypeID.lowback1, PageID);
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
            outBuyingSummary.Columns.Add("sumPrice");
            outBuyingSummary.Columns.Add("sumDiscount");

            double _sumPrice = 0;
            double _sumDiscount = 0;
            foreach (DataRow dr in buyingInfo.Rows)
            {
                    _sumPrice += Convert.ToDouble(dr.ItemArray[1]);
                    _sumDiscount += Convert.ToDouble(dr.ItemArray[2]);
            }
            DataRow rowSummary = outBuyingSummary.NewRow();
            rowSummary["sumPrice"] = _sumPrice.ToString("N0");
            rowSummary["sumDiscount"] = _sumDiscount.ToString("N0");
            outBuyingSummary.Rows.Add(rowSummary);
            return outBuyingSummary;
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
            getwinPriceFromDB(CustomerID, BaseTypeID.up3, winNumber3up, out double _winPrice3up, out double _winRate3up);
            // get payprice
            double _payPrice3up = _winPrice3up * _winRate3up;
            if(_winPrice3up > 0)
            {
                outPayingInfo.Rows.Add("3 บน", _winPrice3up.ToString("N0"), _payPrice3up.ToString("N0"));
            }
            // for 3low
            // get winnumber
            List<string> winNumber3low = getWinNumber(WinNumberType.low3);
            // get winprice
            getwinPriceFromDB(CustomerID, BaseTypeID.low3, winNumber3low, out double _winPrice3low, out double _winRate3low);
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
            getwinPriceFromDB(CustomerID, BaseTypeID.up2, winNumber2up, out double _winPrice2up, out double _winRate2up);
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
            getwinPriceFromDB(CustomerID, BaseTypeID.low2, winNumber2low, out double _winPrice2low, out double _winRate2low);
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
            getwinPriceFromDB(CustomerID, BaseTypeID.ht2, winNumber2ht, out double _winPrice2ht, out double _winRate2ht);
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
            getwinPriceFromDB(CustomerID, BaseTypeID.hu2, winNumber2hu, out double _winPrice2hu, out double _winRate2hu);
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
            getwinPriceFromDB(CustomerID, BaseTypeID.up1, winNumber1up, out double _winPrice1up, out double _winRate1up);
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
            getwinPriceFromDB(CustomerID, BaseTypeID.low1, winNumber1low, out double _winPrice1low, out double _winRate1low);
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
            getwinPriceFromDB(CustomerID, BaseTypeID.upfront1, winNumber1front, out double _winPrice1front, out double _winRate1front);
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
            getwinPriceFromDB(CustomerID, BaseTypeID.upcenter1, winNumber1center, out double _winPrice1center, out double _winRate1center);
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
            getwinPriceFromDB(CustomerID, BaseTypeID.upback1, winNumber1back, out double _winPrice1back, out double _winRate1back);
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
            getwinPriceFromDB(CustomerID, BaseTypeID.lowfront1, winNumber1lowfront, out double _winPrice1lowfront, out double _winRate1lowfront);
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
            getwinPriceFromDB(CustomerID, BaseTypeID.lowback1, winNumber1lowback, out double _winPrice1lowback, out double _winRate1lowback);
            // get payprice
            double _payPrice1lowback = _winPrice1lowback * _winRate1lowback;
            if (_winPrice1lowback > 0)
            {
                outPayingInfo.Rows.Add("1 ล่างหลัง", _winPrice1lowback.ToString("N0"), _payPrice1lowback.ToString("N0"));
            }

            return outPayingInfo;
        }
        private DataTable getPayingSummary(DataTable payingInfo)
        {
            DataTable outPayingSummary = new DataTable();
            outPayingSummary.Columns.Add("sumWinPrice");
            outPayingSummary.Columns.Add("sumPayPrice");

            double _sumWinPrice = 0;
            double _sumPayPrice = 0;
            foreach (DataRow dr in payingInfo.Rows)
            {
                _sumWinPrice += Convert.ToDouble(dr.ItemArray[1]);
                _sumPayPrice += Convert.ToDouble(dr.ItemArray[2]);
            }
            
            DataRow rowSummary = outPayingSummary.NewRow();
            rowSummary["sumWinPrice"] = _sumWinPrice.ToString("N0");
            rowSummary["sumPayPrice"] = _sumPayPrice.ToString("N0");
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
            if(string.IsNullOrEmpty(PageID))
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
        private void getwinPriceFromDB(string customerID, int TypeID, List<string> WinNumber,out double winPrice, out double winRate)
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
                        sqlgetWinPrice = string.Format(@"SELECT oe.Number, oe.Price, ci.{2} AS winRate
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE oe.Number = '{0}' AND oe.TypeID = {1} AND c.CustomerID = '{3}'", winNumber, TypeID.ToString(), DBWinRate.up3, customerID);
                        break;
                    case BaseTypeID.low3:
                        sqlgetWinPrice = string.Format(@"SELECT oe.Number, oe.Price, ci.{2} AS winRate
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE oe.Number = '{0}' AND oe.TypeID = {1} AND c.CustomerID = '{3}'", winNumber, TypeID.ToString(), DBWinRate.low3, customerID);
                        break;
                    case BaseTypeID.up2:
                    case BaseTypeID.ht2:
                    case BaseTypeID.hu2:
                        sqlgetWinPrice = string.Format(@"SELECT oe.Number, oe.Price, ci.{2} AS winRate
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE oe.Number = '{0}' AND oe.TypeID = {1} AND c.CustomerID = '{3}'", winNumber, TypeID.ToString(), DBWinRate.up2, customerID);
                        break;
                    case BaseTypeID.low2:
                        sqlgetWinPrice = string.Format(@"SELECT oe.Number, oe.Price, ci.{2} AS winRate
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE oe.Number = '{0}' AND oe.TypeID = {1} AND c.CustomerID = '{3}'", winNumber, TypeID.ToString(), DBWinRate.low2, customerID);
                        break;
                    case BaseTypeID.up1:
                        sqlgetWinPrice = string.Format(@"SELECT oe.Number, oe.Price, ci.{2} AS winRate
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE oe.Number = '{0}' AND oe.TypeID = {1} AND c.CustomerID = '{3}'", winNumber, TypeID.ToString(), DBWinRate.up1, customerID);
                        break;
                    case BaseTypeID.low1:
                        sqlgetWinPrice = string.Format(@"SELECT oe.Number, oe.Price, ci.{2} AS winRate
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE oe.Number = '{0}' AND oe.TypeID = {1} AND c.CustomerID = '{3}'", winNumber, TypeID.ToString(), DBWinRate.low1, customerID);
                        break;
                    case BaseTypeID.upfront1:
                        sqlgetWinPrice = string.Format(@"SELECT oe.Number, oe.Price, ci.{2} AS winRate
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE oe.Number = '{0}' AND oe.TypeID = {1} AND c.CustomerID = '{3}'", winNumber, TypeID.ToString(), DBWinRate.upfront1, customerID);
                        break;
                    case BaseTypeID.upback1:
                        sqlgetWinPrice = string.Format(@"SELECT oe.Number, oe.Price, ci.{2} AS winRate
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE oe.Number = '{0}' AND oe.TypeID = {1} AND c.CustomerID = '{3}'", winNumber, TypeID.ToString(), DBWinRate.upback1, customerID);
                        break;
                    case BaseTypeID.upcenter1:
                        sqlgetWinPrice = string.Format(@"SELECT oe.Number, oe.Price, ci.{2} AS winRate
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE oe.Number = '{0}' AND oe.TypeID = {1} AND c.CustomerID = '{3}'", winNumber, TypeID.ToString(), DBWinRate.upcenter1, customerID);
                        break;
                    case BaseTypeID.lowfront1:
                        sqlgetWinPrice = string.Format(@"SELECT oe.Number, oe.Price, ci.{2} AS winRate
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE oe.Number = '{0}' AND oe.TypeID = {1} AND c.CustomerID = '{3}'", winNumber, TypeID.ToString(), DBWinRate.upfront1, customerID);
                        break;
                    case BaseTypeID.lowback1:
                        sqlgetWinPrice = string.Format(@"SELECT oe.Number, oe.Price, ci.{2} AS winRate
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE oe.Number = '{0}' AND oe.TypeID = {1} AND c.CustomerID = '{3}'", winNumber, TypeID.ToString(), DBWinRate.upback1, customerID);
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


    }
}
