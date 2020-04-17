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
            this.ActiveControl = CustomerIDList;
            CustomerIDList.Focus();

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
            if(checkcorrectData())
            {
                update_report();
            }
            
        }
        private bool checkcorrectData()
        {
            if(string.IsNullOrEmpty(CustomerIDList.Text))
            {
                // error
                MessageBox.Show("กรุณาใส่รหัสผู้ใช้");
                return false;
            }
            else if (string.IsNullOrEmpty(PageIDList.Text))
            {
                MessageBox.Show("กรุณากำหนดหน้า");
                return false;
            }
            else
            {
                return true;
            }
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

            // NetPay
            DataTable NetPlay = new DataTable();
            NetPlay.Columns.Add("payState");
            NetPlay.Columns.Add("payPrice");

            double receive = Convert.ToDouble(CustomerBuyingSummary.Rows[0][1]);
            double payWin = Convert.ToDouble(CustomerPayingSummary.Rows[0][1]);

            if(payWin - receive > 0)
            {
                NetPlay.Rows.Add("จ่าย", (payWin - receive).ToString("N0"));
            }
            else
            {
                NetPlay.Rows.Add("รับ", (receive - payWin).ToString("N0"));
            }

            CustomerInfo.CustomerID = CustomerID;
            CustomerInfo.customerName = getCustomerName(CustomerID);
            CustomerInfo.PageID = PageID;
            CustomerInfo.sumPay = CustomerPayingSummary.Rows[0]["SumPayPrice"].ToString();

            this.cusotmerInfo_page_reportBindingSource.DataSource = CustomerInfo;
            this.BuyingTableBindingSource.DataSource = CustomerBuyingInfo;
            this.BuyingSummaryBindingSource.DataSource = CustomerBuyingSummary;
            this.PayingTableBindingSource.DataSource = CustomerPayingInfo;
            this.PayingSummaryBindingSource.DataSource = CustomerPayingSummary;
            this.NetPayBindingSource.DataSource = NetPlay;
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
            // for 3(up,low)
            int _p3uptod;
            int _p3up;
            int _p3low;
            int _p3door54;
            int _p3group;
            int _ptGroup;
            int _pGroupLow;
            int _p4group;
            int _p5group;
            int _price3 = 0;

            double _d3uptod;
            double _d3up;
            double _d3low;
            double _d3door54;
            double _d3group;
            double _dtGroup;
            double _dGroupLow;
            double _d4group;
            double _d5group;
            int _disc3 = 0;

            if (string.Equals(PageID, "ทั้งหมด"))
            {
                // get Price From DB
                _p3uptod = getPriceFromDB(CustomerID, BaseTypeID.uptod3, string.Empty);
                _p3up = getPriceFromDB(CustomerID, BaseTypeID.up3, string.Empty);
                _p3low = getPriceFromDB(CustomerID, BaseTypeID.low3, string.Empty);
                _p3door54 = getPriceFromDB(CustomerID, BaseTypeID.door543, string.Empty);
                _p3group = getPriceFromDB(CustomerID, BaseTypeID.group3, string.Empty);
                _ptGroup = getPriceFromDB(CustomerID, BaseTypeID.tgroup3, string.Empty);
                _pGroupLow = getPriceFromDB(CustomerID, BaseTypeID.lowgroup3, string.Empty);
                _p4group = getPriceFromDB(CustomerID, BaseTypeID.group4, string.Empty);
                _p5group = getPriceFromDB(CustomerID, BaseTypeID.group5, string.Empty);

                _price3 = _p3uptod + _p3up + _p3low + _p3door54 + _p3group + _ptGroup + _pGroupLow + _p4group + _p5group;

                // get Discount From DB
                _d3uptod = getDiscountFromDB(CustomerID, BaseTypeID.uptod3, string.Empty);
                _d3up = getDiscountFromDB(CustomerID, BaseTypeID.up3, string.Empty);
                _d3low = getDiscountFromDB(CustomerID, BaseTypeID.low3, string.Empty);
                _d3door54 = getDiscountFromDB(CustomerID, BaseTypeID.door543, string.Empty);
                _d3group = getDiscountFromDB(CustomerID, BaseTypeID.group3, string.Empty);
                _dtGroup = getDiscountFromDB(CustomerID, BaseTypeID.tgroup3, string.Empty);
                _dGroupLow = getDiscountFromDB(CustomerID, BaseTypeID.lowgroup3, string.Empty);
                _d4group = getDiscountFromDB(CustomerID, BaseTypeID.group4, string.Empty);
                _d5group = getDiscountFromDB(CustomerID, BaseTypeID.group5, string.Empty);

                _disc3 = _price3 - Convert.ToInt32(_d3uptod + _d3up + _d3low + _d3door54 + _d3group + _dtGroup + _dGroupLow + _d4group + _d5group);
            }
            else
            {
                // get Price From DB
                _p3uptod = getPriceFromDB(CustomerID, BaseTypeID.uptod3, PageID);
                _p3up = getPriceFromDB(CustomerID, BaseTypeID.up3, PageID);
                _p3low = getPriceFromDB(CustomerID, BaseTypeID.low3, PageID);
                _p3door54 = getPriceFromDB(CustomerID, BaseTypeID.door543, PageID);
                _p3group = getPriceFromDB(CustomerID, BaseTypeID.group3, PageID);
                _ptGroup = getPriceFromDB(CustomerID, BaseTypeID.tgroup3, PageID);
                _pGroupLow = getPriceFromDB(CustomerID, BaseTypeID.lowgroup3, PageID);
                _p4group = getPriceFromDB(CustomerID, BaseTypeID.group4, PageID);
                _p5group = getPriceFromDB(CustomerID, BaseTypeID.group5, PageID);

                _price3 = _p3uptod + _p3up + _p3low + _p3door54 + _p3group + _ptGroup + _pGroupLow + _p4group + _p5group;


                // get Discount From DB
                _d3uptod = getDiscountFromDB(CustomerID, BaseTypeID.uptod3, PageID);
                _d3up = getDiscountFromDB(CustomerID, BaseTypeID.up3, PageID);
                _d3low = getDiscountFromDB(CustomerID, BaseTypeID.low3, PageID);
                _d3door54 = getDiscountFromDB(CustomerID, BaseTypeID.door543, PageID);
                _d3group = getDiscountFromDB(CustomerID, BaseTypeID.group3, PageID);
                _dtGroup = getDiscountFromDB(CustomerID, BaseTypeID.tgroup3, PageID);
                _dGroupLow = getDiscountFromDB(CustomerID, BaseTypeID.lowgroup3, PageID);
                _d4group = getDiscountFromDB(CustomerID, BaseTypeID.group4, PageID);
                _d5group = getDiscountFromDB(CustomerID, BaseTypeID.group5, PageID);

                _disc3 = _price3 - Convert.ToInt32(_d3uptod + _d3up + _d3low + _d3door54 + _d3group + _dtGroup + _dGroupLow + _d4group + _d5group);
            }

            if (_price3 != 0)
            {
                outBuyingInfo.Rows.Add("3", _price3, _disc3);
            }
            
            // for 2up
            int _p2up;
            int _p2low;
            int _p2uptod;
            int _p2door6;
            int _p2updoor19;
            int _p2lowdoor19;
            int _p2ht;
            int _p2hu;
            int _price2 = 0;

            double _d2up;
            double _d2low;
            double _d2uptod;
            double _d2door6;
            double _d2updoor19;
            double _d2lowdoor19;
            double _d2ht;
            double _d2hu;
            int _disc2 = 0;
            if (string.Equals(PageID, "ทั้งหมด"))
            {
                // get Price From DB
                _p2up = getPriceFromDB(CustomerID, BaseTypeID.up2, string.Empty);
                _p2low = getPriceFromDB(CustomerID, BaseTypeID.low2, string.Empty);
                _p2uptod = getPriceFromDB(CustomerID, BaseTypeID.uptod2, string.Empty);
                _p2door6 = getPriceFromDB(CustomerID, BaseTypeID.door62, string.Empty);
                _p2updoor19 = getPriceFromDB(CustomerID, BaseTypeID.door19up2, string.Empty);
                _p2lowdoor19 = getPriceFromDB(CustomerID, BaseTypeID.door19low2, string.Empty);
                _p2ht = getPriceFromDB(CustomerID, BaseTypeID.ht2, string.Empty);
                _p2hu = getPriceFromDB(CustomerID, BaseTypeID.hu2, string.Empty);

                _price2 = _p2up + _p2low + _p2uptod + _p2door6 + _p2updoor19 + _p2lowdoor19 + _p2ht + _p2hu;

                // get Discount From DB
                _d2up = getDiscountFromDB(CustomerID, BaseTypeID.up2, string.Empty);
                _d2low = getDiscountFromDB(CustomerID, BaseTypeID.low2, string.Empty);
                _d2uptod = getDiscountFromDB(CustomerID, BaseTypeID.uptod2, string.Empty);
                _d2door6 = getDiscountFromDB(CustomerID, BaseTypeID.door62, string.Empty);
                _d2updoor19 = getDiscountFromDB(CustomerID, BaseTypeID.door19up2, string.Empty);
                _d2lowdoor19 = getDiscountFromDB(CustomerID, BaseTypeID.door19low2, string.Empty);
                _d2ht = getDiscountFromDB(CustomerID, BaseTypeID.ht2, string.Empty);
                _d2hu = getDiscountFromDB(CustomerID, BaseTypeID.hu2, string.Empty);

                _disc2 = _price2 - Convert.ToInt32(_d2up + _d2low + _d2uptod + _d2door6 + _d2updoor19 + _d2lowdoor19 + _d2ht + _d2hu);
                //_disc2up = _price2up - getDiscountFromDB(CustomerID, BaseTypeID.up2, string.Empty);
            }
            else
            {
                // get Price From DB
                _p2up = getPriceFromDB(CustomerID, BaseTypeID.up2, PageID);
                _p2low = getPriceFromDB(CustomerID, BaseTypeID.low2, PageID);
                _p2uptod = getPriceFromDB(CustomerID, BaseTypeID.uptod2, PageID);
                _p2door6 = getPriceFromDB(CustomerID, BaseTypeID.door62, PageID);
                _p2updoor19 = getPriceFromDB(CustomerID, BaseTypeID.door19up2, PageID);
                _p2lowdoor19 = getPriceFromDB(CustomerID, BaseTypeID.door19low2, PageID);
                _p2ht = getPriceFromDB(CustomerID, BaseTypeID.ht2, PageID);
                _p2hu = getPriceFromDB(CustomerID, BaseTypeID.hu2, PageID);

                _price2 = _p2up + _p2low + _p2uptod + _p2door6 + _p2updoor19 + _p2lowdoor19 + _p2ht + _p2hu;

                // get Discount From DB
                _d2up = getDiscountFromDB(CustomerID, BaseTypeID.up2, PageID);
                _d2low = getDiscountFromDB(CustomerID, BaseTypeID.low2, PageID);
                _d2uptod = getDiscountFromDB(CustomerID, BaseTypeID.uptod2, PageID);
                _d2door6 = getDiscountFromDB(CustomerID, BaseTypeID.door62, PageID);
                _d2updoor19 = getDiscountFromDB(CustomerID, BaseTypeID.door19up2, PageID);
                _d2lowdoor19 = getDiscountFromDB(CustomerID, BaseTypeID.door19low2, PageID);
                _d2ht = getDiscountFromDB(CustomerID, BaseTypeID.ht2, PageID);
                _d2hu = getDiscountFromDB(CustomerID, BaseTypeID.hu2, PageID);

                _disc2 = _price2 - Convert.ToInt32(_d2up + _d2low + _d2uptod + _d2door6 + _d2updoor19 + _d2lowdoor19 + _d2ht + _d2hu);
            }
            if (_price2 != 0)
            {
                outBuyingInfo.Rows.Add("2", _price2, _disc2);
            }

            // for 2,3 tod up,low
            int _p3tod;
            int _p2tod;
            int _ptod;

            double _d3tod;
            double _d2tod;
            int _dtod;
            if (string.Equals(PageID, "ทั้งหมด"))
            {
                // get Group tod from DB
                _p3uptod = getGroupFromDB(CustomerID, BaseTypeID.uptod3, string.Empty);
                _p2uptod = getGroupFromDB(CustomerID, BaseTypeID.uptod2, string.Empty);
                _p3tod = getGroupFromDB(CustomerID, BaseTypeID.tod3, string.Empty);
                _p2tod = getGroupFromDB(CustomerID, BaseTypeID.tod2, string.Empty);

                _ptod = _p3uptod + _p2uptod + _p3tod + _p2tod;

                // get Group tod Discount From DB
                _d3uptod = getGDiscountFromDB(CustomerID, BaseTypeID.uptod3, string.Empty);
                _d2uptod = getGDiscountFromDB(CustomerID, BaseTypeID.uptod2, string.Empty);
                _d3tod = getGDiscountFromDB(CustomerID, BaseTypeID.tod3, string.Empty);
                _d2tod = getGDiscountFromDB(CustomerID, BaseTypeID.tod2, string.Empty);

                _dtod = _ptod - Convert.ToInt32(_d3uptod + _d2uptod + _d3tod + _d2tod);
            }
            else
            {
                // get Group tod from DB
                _p3uptod = getGroupFromDB(CustomerID, BaseTypeID.uptod3, PageID);
                _p2uptod = getGroupFromDB(CustomerID, BaseTypeID.uptod2, PageID);
                _p3tod = getGroupFromDB(CustomerID, BaseTypeID.tod3, PageID);
                _p2tod = getGroupFromDB(CustomerID, BaseTypeID.tod2, PageID);

                _ptod = _p3uptod + _p2uptod + _p3tod + _p2tod;

                // get Group tod Discount From DB
                _d3uptod = getGDiscountFromDB(CustomerID, BaseTypeID.uptod3, PageID);
                _d2uptod = getGDiscountFromDB(CustomerID, BaseTypeID.uptod2, PageID);
                _d3tod = getGDiscountFromDB(CustomerID, BaseTypeID.tod3, PageID);
                _d2tod = getGDiscountFromDB(CustomerID, BaseTypeID.tod2, PageID);

                _dtod = _ptod - Convert.ToInt32(_d3uptod + _d2uptod + _d3tod + _d2tod);
            }
            if (_ptod != 0)
            {
                outBuyingInfo.Rows.Add("T", _ptod, _dtod);
            }
            
            // for 5 digit
            int _p5tod;
            int _price5;

            double _d5tod;
            int _disc5;
            if (string.Equals(PageID, "ทั้งหมด"))
            {
                // get Price From DB
               
                _p5tod = getPriceFromDB(CustomerID, BaseTypeID.tod5, string.Empty);

                _price5 = _p5tod;

                // get Discount From DB
                
                _d5tod = getDiscountFromDB(CustomerID, BaseTypeID.tod5, string.Empty);
                _disc5 = _price5 - Convert.ToInt32(_d5tod);
            }
            else
            {
                // get Price From DB
                _p5tod = getPriceFromDB(CustomerID, BaseTypeID.tod5, PageID);

                _price5 = _p5tod;

                // get Discount From DB
                _d5tod = getDiscountFromDB(CustomerID, BaseTypeID.tod5, PageID);
                _disc5 = _price5 - Convert.ToInt32(_d5tod);
            }
            if (_price5 != 0)
            {
                outBuyingInfo.Rows.Add("5", _price5, _disc5);
            }
            
            // for 1 up,low
            int _p1up;
            int _p1low;
            int _p1upfront;
            int _p1upcenter;
            int _p1upback;
            int _p1lowfront;
            int _p1lowback;
            int _price1;

            double _d1up;
            double _d1low;
            double _d1upfront;
            double _d1upcenter;
            double _d1upback;
            double _d1lowfront;
            double _d1lowback;
            int _disc1;

            if (string.Equals(PageID, "ทั้งหมด"))
            {
                // get Price From DB
                _p1up = getPriceFromDB(CustomerID, BaseTypeID.up1, string.Empty);
                _p1low = getPriceFromDB(CustomerID, BaseTypeID.low1, string.Empty);
                _p1upfront = getPriceFromDB(CustomerID, BaseTypeID.upfront1, string.Empty);
                _p1upcenter = getPriceFromDB(CustomerID, BaseTypeID.upcenter1, string.Empty);
                _p1upback = getPriceFromDB(CustomerID, BaseTypeID.upback1, string.Empty);
                _p1lowfront = getPriceFromDB(CustomerID, BaseTypeID.lowfront1, string.Empty);
                _p1lowback = getPriceFromDB(CustomerID, BaseTypeID.lowback1, string.Empty);

                _price1 = (_p1up + _p1low + _p1upfront + _p1upcenter + _p1upback + _p1lowfront + _p1lowback);


                // get Discount From DB
                _d1up = getDiscountFromDB(CustomerID, BaseTypeID.up1, string.Empty);
                _d1low = getDiscountFromDB(CustomerID, BaseTypeID.low1, string.Empty);
                _d1upfront = getDiscountFromDB(CustomerID, BaseTypeID.upfront1, string.Empty);
                _d1upcenter = getDiscountFromDB(CustomerID, BaseTypeID.upcenter1, string.Empty);
                _d1upback = getDiscountFromDB(CustomerID, BaseTypeID.upback1, string.Empty);
                _d1lowfront = getDiscountFromDB(CustomerID, BaseTypeID.lowfront1, string.Empty);
                _d1lowback = getDiscountFromDB(CustomerID, BaseTypeID.lowback1, string.Empty);

                _disc1 = _price1 - Convert.ToInt32(_d1up + _d1low + _d1upfront + _d1upcenter + _d1upback + _d1lowfront + _d1lowback);


                //_disc2hu = _price2hu - getDiscountFromDB(CustomerID, BaseTypeID.hu2, string.Empty);
            }
            else
            {
                // get Price From DB
                _p1up = getPriceFromDB(CustomerID, BaseTypeID.up1, PageID);
                _p1low = getPriceFromDB(CustomerID, BaseTypeID.low1, PageID);
                _p1upfront = getPriceFromDB(CustomerID, BaseTypeID.upfront1, PageID);
                _p1upcenter = getPriceFromDB(CustomerID, BaseTypeID.upcenter1, PageID);
                _p1upback = getPriceFromDB(CustomerID, BaseTypeID.upback1, PageID);
                _p1lowfront = getPriceFromDB(CustomerID, BaseTypeID.lowfront1, PageID);
                _p1lowback = getPriceFromDB(CustomerID, BaseTypeID.lowback1, PageID);

                _price1 = (_p1up + _p1low + _p1upfront + _p1upcenter + _p1upback + _p1lowfront + _p1lowback);


                // get Discount From DB
                _d1up = getDiscountFromDB(CustomerID, BaseTypeID.up1, PageID);
                _d1low = getDiscountFromDB(CustomerID, BaseTypeID.low1, PageID);
                _d1upfront = getDiscountFromDB(CustomerID, BaseTypeID.upfront1, PageID);
                _d1upcenter = getDiscountFromDB(CustomerID, BaseTypeID.upcenter1, PageID);
                _d1upback = getDiscountFromDB(CustomerID, BaseTypeID.upback1, PageID);
                _d1lowfront = getDiscountFromDB(CustomerID, BaseTypeID.lowfront1, PageID);
                _d1lowback = getDiscountFromDB(CustomerID, BaseTypeID.lowback1, PageID);

                _disc1 = _price1 - Convert.ToInt32(_d1up + _d1low + _d1upfront + _d1upcenter + _d1upback + _d1lowfront + _d1lowback);

                //_price2hu = getPriceFromDB(CustomerID, BaseTypeID.hu2, PageID);
                //_disc2hu = _price2hu - getDiscountFromDB(CustomerID, BaseTypeID.hu2, PageID);
            }
            if (_price1 != 0)
            {
                outBuyingInfo.Rows.Add("1", _price1, _disc1);
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
            string getWinNumber = string.Format(@"SELECT DISTINCT Number FROM WinNumber
                                                  WHERE TypeName = N'{0}'", WinType);
            SqlCommand getWinNumberCom = new SqlCommand(getWinNumber, connection);
            SqlDataReader winNumberInfo = getWinNumberCom.ExecuteReader();
            while (winNumberInfo.Read())
            {
                outNumber.Add(winNumberInfo["Number"].ToString());
            }
            connection.Close();

            return outNumber;
        }
        private DataTable getPayingInfo(string CustomerID, string PageID)
        {
            DataTable outPayingInfo = new DataTable();
            outPayingInfo.Columns.Add("Type");
            outPayingInfo.Columns.Add("WinPrice");
            outPayingInfo.Columns.Add("PayPrice");
            outPayingInfo.Columns.Add("PageNumber");

            // for 3up
            // get winnumber
            List<string> winNumber3up = getWinNumber(WinNumberType.up3);
            // get winprice
            List<int> Pageuptod3 = getwinPriceFromDB(CustomerID, BaseTypeID.uptod3, winNumber3up, PageID, out double _winP3uptod, out double _winR3uptod);
            List<int> Pageup3 = getwinPriceFromDB(CustomerID, BaseTypeID.up3, winNumber3up, PageID, out double _winP3up, out double _winR3up);
            List<int> Pagegroup3 = getwinPriceFromDB(CustomerID, BaseTypeID.group3, winNumber3up, PageID, out double _winP3group, out double _winR3group);
            List<int> Pagedoor543 = getwinPriceFromDB(CustomerID, BaseTypeID.door543, winNumber3up, PageID, out double _winP3door54, out double _winR3door54);
            List<int> Pagetgroup3 = getwinPriceFromDB(CustomerID, BaseTypeID.tgroup3, winNumber3up, PageID, out double _winP3tgroup, out double _winR3tgroup);

            List<int> Pagegroup5 = getwinPriceFromDB(CustomerID, BaseTypeID.group5, winNumber3up, PageID, out double _winP5group, out double _winR5group);
            List<int> Pagegroup4 = getwinPriceFromDB(CustomerID, BaseTypeID.group4, winNumber3up, PageID, out double _winP4group, out double _winR4group);
            
            // get payprice
            double _payP3uptod = _winP3uptod * _winR3uptod;
            double _payP3up = _winP3up * _winR3up;
            double _payP3group = _winP3group * _winR3group;
            double _payP3door54 = _winP3door54 * _winR3door54;
            double _payP3tgroup = _winP3tgroup * _winR3tgroup;

            double _payP5group = _winP5group * _winR5group;
            double _payP4group = _winP4group * _winR4group;
            // summary
            double _payPrice3up = _payP3uptod + _payP3up + _payP3group + _payP3door54 + _payP3tgroup + _payP5group + _payP4group;
            double _winPrice3up = _winP3uptod + _winP3up + _winP3group + _winP3door54 + _winP3tgroup + _winP5group + _winP4group;
            if (_winPrice3up != 0)
            {
                List<int> _Page3up = new List<int>();
                if(Pageuptod3.Any())
                {
                    _Page3up.AddRange(Pageuptod3);
                }
                if(Pageup3.Any())
                {
                    _Page3up.AddRange(Pageup3);
                }
                if(Pagegroup3.Any())
                {
                    _Page3up.AddRange(Pagegroup3);
                }
                if(Pagedoor543.Any())
                {
                    _Page3up.AddRange(Pagedoor543);
                }
                if(Pagetgroup3.Any())
                {
                    _Page3up.AddRange(Pagetgroup3);
                }
                if(Pagegroup5.Any())
                {
                    _Page3up.AddRange(Pagegroup5);
                }
                if(Pagegroup4.Any())
                {
                    _Page3up.AddRange(Pagegroup4);
                }
                List<int> uniqPage3up = _Page3up.Distinct().ToList();
                string strPage3up = string.Join(",", uniqPage3up);
                outPayingInfo.Rows.Add("3 บน", _winPrice3up.ToString("N0"), _payPrice3up.ToString("N0"), strPage3up);
            }
            
            // for 2up
            // get winnumber for 2up
            List<string> winNumber2up = getWinNumber(WinNumberType.up2);
            // get winnumber for 2ht
            List<string> winNumber2ht = getWinNumber(WinNumberType.ht2);
            // get winnumber for 2hu
            List<string> winNumber2hu = getWinNumber(WinNumberType.hu2);

            // get winprice
            List<int> Pageuptod2 = getwinPriceFromDB(CustomerID, BaseTypeID.uptod2, winNumber2up, PageID, out double _winP2uptod, out double _winR2uptod);
            List<int> Pageup2 = getwinPriceFromDB(CustomerID, BaseTypeID.up2, winNumber2up, PageID, out double _winP2up, out double _winR2up);
            List<int> Pageht2 = getwinPriceFromDB(CustomerID, BaseTypeID.ht2, winNumber2ht, PageID, out double _winP2ht, out double _winR2ht);
            List<int> Pagehu2 = getwinPriceFromDB(CustomerID, BaseTypeID.hu2, winNumber2hu, PageID, out double _winP2hu, out double _winR2hu);
            List<int> Pagedoor19up2 = getwinPriceFromDB(CustomerID, BaseTypeID.door19up2, winNumber2up, PageID, out double _winP2updoor19, out double _winR2updoor19);
            // for door6 
            List<int> Pagedoor62up = getwinPriceFromDB(CustomerID, BaseTypeID.door62,"up", winNumber2up, PageID, out double _winP2updoor6, out double _winR2updoor6);
            List<int> Pagedoor62ht = getwinPriceFromDB(CustomerID, BaseTypeID.door62,"ht", winNumber2ht, PageID, out double _winP2htdoor6, out double _winR2htdoor6);
            List<int> Pagedoor62hu = getwinPriceFromDB(CustomerID, BaseTypeID.door62,"hu", winNumber2hu, PageID, out double _winP2hudoor6, out double _winR2hudoor6);
            // get payprice
            double _payP2uptod = _winP2uptod * _winR2uptod;
            double _payP2up = _winP2up * _winR2up;
            double _payP2ht = _winP2ht * _winR2ht;
            double _payP2hu = _winP2hu * _winR2hu;
            double _payP2updoor19 = _winP2updoor19 * _winR2updoor19;
            double _payP2updoor6 = _winP2updoor6 * _winR2updoor6;
            double _payP2htdoor6 = _winP2htdoor6 * _winR2htdoor6;
            double _payP2hudoor6 = _winP2hudoor6 * _winR2hudoor6;
            double _winPrice2up = _winP2uptod + _winP2up + _winP2ht + _winP2hu + _winP2updoor19 +
                _winP2updoor6 + _winP2htdoor6 + _winP2hudoor6;
            double _payPrice2up = _payP2uptod + _payP2up + _payP2ht + _payP2hu + _payP2updoor19 +
                _payP2updoor6 + _payP2htdoor6 + _payP2hudoor6;
            if (_winPrice2up != 0)
            {
                List<int> _Page2up = new List<int>();
                if (Pageuptod2.Any())
                {
                    _Page2up.AddRange(Pageuptod2);
                }
                if (Pageup2.Any())
                {
                    _Page2up.AddRange(Pageup2);
                }
                if (Pageht2.Any())
                {
                    _Page2up.AddRange(Pageht2);
                }
                if (Pagehu2.Any())
                {
                    _Page2up.AddRange(Pagehu2);
                }
                if (Pagedoor19up2.Any())
                {
                    _Page2up.AddRange(Pagedoor19up2);
                }
                if (Pagedoor62up.Any())
                {
                    _Page2up.AddRange(Pagedoor62up);
                }
                if (Pagedoor62ht.Any())
                {
                    _Page2up.AddRange(Pagedoor62ht);
                }
                if (Pagedoor62hu.Any())
                {
                    _Page2up.AddRange(Pagedoor62hu);
                }
                List<int> uniqPage2up = _Page2up.Distinct().ToList();
                string strPage2up = string.Join(",", uniqPage2up);
                outPayingInfo.Rows.Add("2 บน", _winPrice2up.ToString("N0"), _payPrice2up.ToString("N0"), strPage2up);
            }


            // for 2low
            // get winnumber
            List<string> winNumber2low = getWinNumber(WinNumberType.low2);
            // get winprice
            List<int> Pagelow2 = getwinPriceFromDB(CustomerID, BaseTypeID.low2, winNumber2low, PageID, out double _winP2low, out double _winR2low);
            List<int> Pagedoor19low2 = getwinPriceFromDB(CustomerID, BaseTypeID.door19low2, winNumber2low, PageID, out double _winP2lowdoor19, out double _winR2lowdoor19);
            // get payprice
            double _payP2low = _winP2low * _winR2low;
            double _payP2lowdoor19 = _winP2lowdoor19 * _winR2lowdoor19;

            double _winPrice2low = _winP2low + _winP2lowdoor19;
            double _payPrice2low = _payP2low + _payP2lowdoor19;
            if (_winPrice2low != 0)
            {
                List<int> _Page2low = new List<int>();
                if (Pagelow2.Any())
                {
                    _Page2low.AddRange(Pagelow2);
                }
                if (Pagedoor19low2.Any())
                {
                    _Page2low.AddRange(Pagedoor19low2);
                }
                List<int> uniqPage2low = _Page2low.Distinct().ToList();
                string strPage2low = string.Join(",", uniqPage2low);
                outPayingInfo.Rows.Add("2 ล่าง", _winPrice2low.ToString("N0"), _payPrice2low.ToString("N0"), strPage2low);
            }
            // for 3tod
            // get winprice
            Pageuptod3 = getwinGPriceFromDB(CustomerID, BaseTypeID.uptod3, winNumber3up, PageID, out _winP3uptod, out _winR3uptod);
            List<int> Pagetod3 = getwinGPriceFromDB(CustomerID, BaseTypeID.tod3, winNumber3up, PageID, out double _winP3tod, out double _winR3tod);
            // get payprice
            _payP3uptod = _winP3uptod * _winR3uptod;
            double _payP3tod = _winP3tod * _winR3tod;

            double _winPrice3tod = _winP3uptod + _winP3tod;

            double _payPrice3tod = _payP3uptod + _payP3tod;
            if (_winPrice3tod != 0)
            {
                List<int> _Page3tod = new List<int>();
                if (Pageuptod3.Any())
                {
                    _Page3tod.AddRange(Pageuptod3);
                }
                if (Pagetod3.Any())
                {
                    _Page3tod.AddRange(Pagetod3);
                }
                List<int> uniqPage3tod = _Page3tod.Distinct().ToList();
                string strPage3tod = string.Join(",", uniqPage3tod);
                outPayingInfo.Rows.Add("3T", _winPrice3tod.ToString("N0"), _payPrice3tod.ToString("N0"), strPage3tod);
            }


            // for 2tod
            // get winprice
            List<int> Pageuptod2up = getwinGPriceFromDB(CustomerID, BaseTypeID.uptod2,"up", winNumber2up, PageID, out double _winP2uptodUP, out double _winR2uptodUP);
            List<int> Pageuptod2ht = getwinGPriceFromDB(CustomerID, BaseTypeID.uptod2, "ht", winNumber2ht, PageID, out double _winP2uptodHT, out double _winR2uptodHT);
            List<int> Pageuptod2hu = getwinGPriceFromDB(CustomerID, BaseTypeID.uptod2, "hu", winNumber2hu, PageID, out double _winP2uptodHU, out double _winR2uptodHU);

            List<int> Pagetod2up = getwinGPriceFromDB(CustomerID, BaseTypeID.tod2,"up", winNumber2up, PageID, out double _winP2todUP, out double _winR2todUP);
            List<int> Pagetod2ht = getwinGPriceFromDB(CustomerID, BaseTypeID.tod2, "ht", winNumber2ht, PageID, out double _winP2todHT, out double _winR2todHT);
            List<int> Pagetod2hu = getwinGPriceFromDB(CustomerID, BaseTypeID.tod2, "hu", winNumber2hu, PageID, out double _winP2todHU, out double _winR2todHU);
            // get payprice
            double _payP2uptodT = 0;
            double _winP2uptodT = 0;
            if(_winP2uptodUP != 0)
            {
                _payP2uptodT = _winP2uptodUP * _winR2uptodUP;
                _winP2uptodT = _winP2uptodUP;
            }
            else if(_winP2uptodHT != 0)
            {
                _payP2uptodT = _winP2uptodHT * _winR2uptodHT;
                _winP2uptodT = _winP2uptodHT;
            }
            else if(_winP2uptodHU != 0)
            {
                _payP2uptodT = _winP2uptodHU * _winR2uptodHU;
                _winP2uptodT = _winP2uptodHU;
            }

            double _payP2todT = 0;
            double _winP2todT = 0;
            if (_winP2todUP != 0)
            {
                _payP2todT = _winP2todUP * _winR2todUP;
                _winP2todT = _winP2todUP;
            }
            else if(_winP2todHT != 0)
            {
                _payP2todT = _winP2todHT * _winR2todHT;
                _winP2todT = _winP2todHT;
            }
            else if(_winP2todHU != 0)
            {
                _payP2todT = _winP2todHU * _winR2todHU;
                _winP2todT = _winP2todHU;
            }



            double _winPrice2tod = _winP2uptodT + _winP2todT;

            double _payPrice2tod = _payP2uptodT + _payP2todT;
            if (_winPrice2tod != 0)
            {
                List<int> _Page2tod = new List<int>();
                if (Pageuptod2up.Any())
                {
                    _Page2tod.AddRange(Pageuptod2up);
                }
                if (Pageuptod2ht.Any())
                {
                    _Page2tod.AddRange(Pageuptod2ht);
                }
                if (Pageuptod2hu.Any())
                {
                    _Page2tod.AddRange(Pageuptod2hu);
                }
                if (Pagetod2up.Any())
                {
                    _Page2tod.AddRange(Pagetod2up);
                }
                if (Pagetod2ht.Any())
                {
                    _Page2tod.AddRange(Pagetod2ht);
                }
                if (Pagetod2hu.Any())
                {
                    _Page2tod.AddRange(Pagetod2hu);
                }
                List<int> uniqPage2tod = _Page2tod.Distinct().ToList();
                string strPage2tod = string.Join(",", uniqPage2tod);
                outPayingInfo.Rows.Add("2T", _winPrice2tod.ToString("N0"), _payPrice2tod.ToString("N0"), strPage2tod);
            }
            
            // for 5up
            // get winnumber
            // get winprice
            List<int> Pagetod5 = getwinPriceFromDB(CustomerID, BaseTypeID.tod5, winNumber3up, PageID, out double _winP5tod, out double _winR5tod);
            // get payprice
            double _payP5tod = _winP5tod * _winR5tod;

            if (_winP5tod != 0)
            {
                List<int> _Page5tod = new List<int>();

                if (Pagetod5.Any())
                {
                    _Page5tod.AddRange(Pagetod5);
                }
                List<int> uniqPage5tod = _Page5tod.Distinct().ToList();
                string strPage5tod = string.Join(",", uniqPage5tod);
                outPayingInfo.Rows.Add("5", _winP5tod.ToString("N0"), _payP5tod.ToString("N0"), strPage5tod);
            }
            
            // for lfreeup
            // get winnumber
            List<string> winNumber1up = getWinNumber(WinNumberType.up1);
            // get winprice
            List<int> Pageup1 = getwinPriceFromDB(CustomerID, BaseTypeID.up1, winNumber1up, PageID, out double _winP1up, out double _winR1up);

            // get payprice
            double _payP1up = _winP1up * _winR1up;
            double _winPrice1up = _winP1up;
            double _payPrice1up = _payP1up;
            if (_winPrice1up != 0)
            {
                List<int> _Page1up = new List<int>();
                if (Pageup1.Any())
                {
                    _Page1up.AddRange(Pageup1);
                }
                List<int> uniqPage1up = _Page1up.Distinct().ToList();
                string strPage1up = string.Join(",", uniqPage1up);
                outPayingInfo.Rows.Add("L", _winPrice1up.ToString("N0"), _payPrice1up.ToString("N0"), strPage1up);
            }
            // 1low
            // get winnumber
            List<string> winNumber1low = getWinNumber(WinNumberType.low1);
            // get winprice
            List<int> Pagelow1 = getwinPriceFromDB(CustomerID, BaseTypeID.low1, winNumber1low, PageID, out double _winP1low, out double _winR1low);

            // get payprice
            double _payP1low = _winP1low * _winR1low;
            double _winPrice1low = _winP1low;
            double _payPrice1low = _payP1low;
            if (_winPrice1low != 0)
            {
                List<int> _Page1low = new List<int>();
                if (Pagelow1.Any())
                {
                    _Page1low.AddRange(Pagelow1);
                }
                List<int> uniqPage1low = _Page1low.Distinct().ToList();
                string strPage1low = string.Join(",", uniqPage1low);
                outPayingInfo.Rows.Add("LL", _winPrice1low.ToString("N0"), _payPrice1low.ToString("N0"), strPage1low);
            }
            
            // for 3low
            // get winnumber
            List<string> winNumber3low = getWinNumber(WinNumberType.low3);
            // get winprice
            List<int> Pagelow3 = getwinPriceFromDB(CustomerID, BaseTypeID.low3, winNumber3low, PageID, out double _winP3low, out double _winR3low);
            List<int> Pagelowgroup3 = getwinPriceFromDB(CustomerID, BaseTypeID.lowgroup3, winNumber3low, PageID, out double _winP3lowgroup, out double _winR3lowgroup);
            // get payprice
            double _payP3low = _winP3low * _winR3low;
            double _payP3lowgroup = _winP3lowgroup * _winR3lowgroup;

            double _winPrice3low = _winP3low + _winP3lowgroup;
            double _payPrice3low = _payP3low + _payP3lowgroup;
            
            if (_winPrice3low != 0)
            {
                List<int> _Page3low = new List<int>();
                if (Pagelow3.Any())
                {
                    _Page3low.AddRange(Pagelow3);
                }
                if (Pagelowgroup3.Any())
                {
                    _Page3low.AddRange(Pagelowgroup3);
                }
                List<int> uniqPage3low = _Page3low.Distinct().ToList();
                string strPage3low = string.Join(",", uniqPage3low);
                outPayingInfo.Rows.Add("3 ล่าง", _winPrice3low.ToString("N0"), _payPrice3low.ToString("N0"), strPage3low);
            }
            // for 1front
            // get winnumber
            List<string> winNumber1front = getWinNumber(WinNumberType.upfront1);
            // get winprice
            List<int> Pageupfront1 = getwinPriceFromDB(CustomerID, BaseTypeID.upfront1, winNumber1front, PageID, out double _winP1front, out double _winR1front);
            // get payprice
            double _payP1front = _winP1front * _winR1front;

            double _winPrice1front = _winP1front;
            double _payPrice1front = _payP1front;
            if (_winPrice1front != 0)
            {
                List<int> _Page1upfront = new List<int>();
                if (Pageupfront1.Any())
                {
                    _Page1upfront.AddRange(Pageupfront1);
                }
                List<int> uniqPage1upfront = _Page1upfront.Distinct().ToList();
                string strPage1upfront = string.Join(",", uniqPage1upfront);
                outPayingInfo.Rows.Add("1 หน้า", _winPrice1front.ToString("N0"), _payPrice1front.ToString("N0"), strPage1upfront);
            }
            
            // for 1center
            // get winnumber
            List<string> winNumber1center = getWinNumber(WinNumberType.upcenter1);
            // get winprice
            List<int> Pageupcenter1 = getwinPriceFromDB(CustomerID, BaseTypeID.upcenter1, winNumber1center, PageID, out double _winPrice1center, out double _winRate1center);
            // get payprice
            double _payPrice1center = _winPrice1center * _winRate1center;
            if (_winPrice1center != 0)
            {
                List<int> _Page1upcenter = new List<int>();
                if (Pageupcenter1.Any())
                {
                    _Page1upcenter.AddRange(Pageupcenter1);
                }
                List<int> uniqPage1upcenter = _Page1upcenter.Distinct().ToList();
                string strPage1upcenter = string.Join(",", uniqPage1upcenter);
                outPayingInfo.Rows.Add("1 กลาง", _winPrice1center.ToString("N0"), _payPrice1center.ToString("N0"), strPage1upcenter);
            }
            
            // for 1back
            // get winnumber
            List<string> winNumber1back = getWinNumber(WinNumberType.upback1);
            // get winprice
            List<int> Pageupback1 = getwinPriceFromDB(CustomerID, BaseTypeID.upback1, winNumber1back, PageID, out double _winPrice1back, out double _winRate1back);
            // get payprice
            double _payPrice1back = _winPrice1back * _winRate1back;
            if (_winPrice1back != 0)
            {
                List<int> _Page1upback = new List<int>();
                if (Pageupback1.Any())
                {
                    _Page1upback.AddRange(Pageupback1);
                }
                List<int> uniqPage1upback = _Page1upback.Distinct().ToList();
                string strPage1upback = string.Join(",", uniqPage1upback);
                outPayingInfo.Rows.Add("1 หลัง", _winPrice1back.ToString("N0"), _payPrice1back.ToString("N0"), strPage1upback);
            }
            // for 1lowfront
            // get winnumber
            List<string> winNumber1lowfront = getWinNumber(WinNumberType.lowfront1);
            // get winprice
            List<int> Pagelowfront1 = getwinPriceFromDB(CustomerID, BaseTypeID.lowfront1, winNumber1lowfront, PageID, out double _winPrice1lowfront, out double _winRate1lowfront);
            // get payprice
            double _payPrice1lowfront = _winPrice1lowfront * _winRate1lowfront;
            if (_winPrice1lowfront != 0)
            {
                List<int> _Page1lowfront = new List<int>();
                if (Pagelowfront1.Any())
                {
                    _Page1lowfront.AddRange(Pagelowfront1);
                }
                List<int> uniqPage1lowfront = _Page1lowfront.Distinct().ToList();
                string strPage1lowfront = string.Join(",", uniqPage1lowfront);
                outPayingInfo.Rows.Add("1 ล่างหน้า", _winPrice1lowfront.ToString("N0"), _payPrice1lowfront.ToString("N0"), strPage1lowfront);
            }
            // for 1lowback
            // get winnumber
            List<string> winNumber1lowback = getWinNumber(WinNumberType.lowback1);
            // get winprice
            List<int> Pagelowback1 = getwinPriceFromDB(CustomerID, BaseTypeID.lowback1, winNumber1lowback, PageID, out double _winPrice1lowback, out double _winRate1lowback);
            // get payprice
            double _payPrice1lowback = _winPrice1lowback * _winRate1lowback;
            if (_winPrice1lowback != 0)
            {
                List<int> _Page1lowback = new List<int>();
                if (Pagelowback1.Any())
                {
                    _Page1lowback.AddRange(Pagelowback1);
                }
                List<int> uniqPage1lowback = _Page1lowback.Distinct().ToList();
                string strPage1lowback = string.Join(",", uniqPage1lowback);
                outPayingInfo.Rows.Add("1 ล่างหลัง", _winPrice1lowback.ToString("N0"), _payPrice1lowback.ToString("N0"), strPage1lowback);
            }
            
            return outPayingInfo;
        }
        private List<int> getwinPriceFromDB(string customerID, int TypeID, string state, List<string> WinNumber, string PageID, out double winPrice, out double winRate)
        {
            List<int> PageOut = new List<int>();
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
                    case BaseTypeID.door62:
                        if (string.Equals(PageID, "ทั้งหมด"))
                        {
                            int _typeID = 0;
                            switch (state)
                            {
                                case "up":
                                    _typeID = BaseTypeID.up2;
                                    break;
                                case "ht":
                                    _typeID = BaseTypeID.ht2;
                                    break;
                                case "hu":
                                    _typeID = BaseTypeID.hu2;
                                    break;
                            }
                            sqlgetWinPrice = string.Format(@"SELECT oe.Number, oe.Price, ci.{2} AS winRate, c.Page
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE oe.Number = '{0}' AND o.TypeID = {1} AND oe.TypeID = {4} AND c.CustomerID = '{3}'", winNumber, TypeID.ToString(),  DBWinRate.up2, customerID, _typeID.ToString());
                        }
                        else
                        {
                            int _typeID = 0;
                            switch (state)
                            {
                                case "up":
                                    _typeID = BaseTypeID.up2;
                                    break;
                                case "ht":
                                    _typeID = BaseTypeID.ht2;
                                    break;
                                case "hu":
                                    _typeID = BaseTypeID.hu2;
                                    break;
                            }
                            sqlgetWinPrice = string.Format(@"SELECT oe.Number, oe.Price, ci.{2} AS winRate
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE oe.Number = '{0}' AND o.TypeID = {1} AND oe.TypeID = {5} AND c.CustomerID = '{3}' AND c.Page = {4}", winNumber, TypeID.ToString(), DBWinRate.up2, customerID, PageID, _typeID.ToString());
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
                    if (string.Equals(PageID, "ทั้งหมด"))
                    {
                        PageOut.Add(Convert.ToInt32(winPriceInfo["Page"]));
                    }
                }
                connection.Close();
                //winPrice = outWinNumber;
                winRate = _winRate;
            }
            return PageOut;
        }
        private List<int> getwinGPriceFromDB(string customerID, int TypeID, List<string> WinNumber, string PageID, out double winPrice, out double winRate)
        {
            List<int> PageOut = new List<int>();
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
                    case BaseTypeID.uptod3:
                        if (string.Equals(PageID, "ทั้งหมด"))
                        {
                            sqlgetWinPrice = string.Format(@"SELECT o.Number, o.GroupPrice, ci.{2} AS winRate, c.Page
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE oe.Number = '{0}' AND o.TypeID = {1} AND c.CustomerID = '{3}'", winNumber, TypeID.ToString(), DBWinRate.tod3, customerID);
                        }
                        else
                        {
                            sqlgetWinPrice = string.Format(@"SELECT o.Number, o.GroupPrice, ci.{2} AS winRate
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE oe.Number = '{0}' AND o.TypeID = {1} AND c.CustomerID = '{3}' AND c.Page = {4}", winNumber, TypeID.ToString(), DBWinRate.tod3, customerID, PageID);
                        }
                        break;
                    case BaseTypeID.tod3:
                        if (string.Equals(PageID, "ทั้งหมด"))
                        {
                            sqlgetWinPrice = string.Format(@"SELECT o.Number, o.Price AS GroupPrice, ci.{2} AS winRate, c.Page
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE oe.Number = '{0}' AND o.TypeID = {1} AND c.CustomerID = '{3}'", winNumber, TypeID.ToString(), DBWinRate.tod3, customerID);
                        }
                        else
                        {
                            sqlgetWinPrice = string.Format(@"SELECT o.Number, o.Price AS GroupPrice, ci.{2} AS winRate
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE oe.Number = '{0}' AND o.TypeID = {1} AND c.CustomerID = '{3}' AND c.Page = {4}", winNumber, TypeID.ToString(), DBWinRate.tod3, customerID, PageID);
                        }
                        break;
                    case BaseTypeID.uptod2:
                        if (string.Equals(PageID, "ทั้งหมด"))
                        {
                            sqlgetWinPrice = string.Format(@"SELECT o.Number, o.GroupPrice, ci.{2} AS winRate, c.Page
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE oe.Number = '{0}' AND o.TypeID = {1} AND c.CustomerID = '{3}'", winNumber, TypeID.ToString(), DBWinRate.tod2, customerID);
                        }
                        else
                        {
                            sqlgetWinPrice = string.Format(@"SELECT o.Number, o.GroupPrice, ci.{2} AS winRate
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE oe.Number = '{0}' AND o.TypeID = {1} AND c.CustomerID = '{3}' AND c.Page = {4}", winNumber, TypeID.ToString(), DBWinRate.tod2, customerID, PageID);
                        }
                        break;
                    case BaseTypeID.tod2:
                        if (string.Equals(PageID, "ทั้งหมด"))
                        {
                            sqlgetWinPrice = string.Format(@"SELECT o.Number, o.Price AS GroupPrice, ci.{2} AS winRate, c.Page
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE oe.Number = '{0}' AND o.TypeID = {1} AND c.CustomerID = '{3}'", winNumber, TypeID.ToString(), DBWinRate.tod2, customerID);
                        }
                        else
                        {
                            sqlgetWinPrice = string.Format(@"SELECT o.Number, o.Price AS GroupPrice, ci.{2} AS winRate
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE oe.Number = '{0}' AND o.TypeID = {1} AND c.CustomerID = '{3}' AND c.Page = {4}", winNumber, TypeID.ToString(), DBWinRate.tod2, customerID, PageID);
                        }
                        break;

                }
                SqlCommand sqlgetWinPriceCom = new SqlCommand(sqlgetWinPrice, connection);
                SqlDataReader winPriceInfo = sqlgetWinPriceCom.ExecuteReader();
                while (winPriceInfo.Read())
                {
                    _price = Convert.ToDouble(winPriceInfo["GroupPrice"]);
                    _winRate = Convert.ToDouble(winPriceInfo["winRate"]);
                    winPrice += _price;
                    if (string.Equals(PageID, "ทั้งหมด"))
                    {
                        PageOut.Add(Convert.ToInt32(winPriceInfo["Page"]));
                    }
                }
                connection.Close();
                //winPrice = outWinNumber;
                winRate = _winRate;
            }
            return PageOut;
        }
        private List<int> getwinGPriceFromDB(string customerID, int TypeID, string state, List<string> WinNumber, string PageID, out double winPrice, out double winRate)
        {
            List<int> PageOut = new List<int>();
            winPrice = 0;
            winRate = 0;
            string sqlgetWinPrice = string.Empty;
            double _price;
            double _winRate = 0;
            int _typeID = 0;
            foreach (string winNumber in WinNumber)
            {
                SqlConnection connection = new SqlConnection(Database.CnnVal("LottoryDB"));
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                switch (TypeID)
                {
                    case BaseTypeID.uptod3:
                        if (string.Equals(PageID, "ทั้งหมด"))
                        {
                            sqlgetWinPrice = string.Format(@"SELECT o.Number, o.GroupPrice, ci.{2} AS winRate, c.Page
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE oe.Number = '{0}' AND o.TypeID = {1} AND c.CustomerID = '{3}'", winNumber, TypeID.ToString(), DBWinRate.tod3, customerID);
                        }
                        else
                        {
                            sqlgetWinPrice = string.Format(@"SELECT o.Number, o.GroupPrice, ci.{2} AS winRate
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE oe.Number = '{0}' AND o.TypeID = {1} AND c.CustomerID = '{3}' AND c.Page = {4}", winNumber, TypeID.ToString(), DBWinRate.tod3, customerID, PageID);
                        }
                        break;
                    case BaseTypeID.tod3:
                        if (string.Equals(PageID, "ทั้งหมด"))
                        {
                            sqlgetWinPrice = string.Format(@"SELECT o.Number, o.Price AS GroupPrice, ci.{2} AS winRate, c.Page
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE oe.Number = '{0}' AND o.TypeID = {1} AND c.CustomerID = '{3}'", winNumber, TypeID.ToString(), DBWinRate.tod3, customerID);
                        }
                        else
                        {
                            sqlgetWinPrice = string.Format(@"SELECT o.Number, o.Price AS GroupPrice, ci.{2} AS winRate
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE oe.Number = '{0}' AND o.TypeID = {1} AND c.CustomerID = '{3}' AND c.Page = {4}", winNumber, TypeID.ToString(), DBWinRate.tod3, customerID, PageID);
                        }
                        break;
                    case BaseTypeID.uptod2:
                        
                        switch (state)
                        {
                            case "up":
                                _typeID = BaseTypeID.up2;
                                break;
                            case "ht":
                                _typeID = BaseTypeID.ht2;
                                break;
                            case "hu":
                                _typeID = BaseTypeID.hu2;
                                break;
                        }
                        if (string.Equals(PageID, "ทั้งหมด"))
                        {

                            sqlgetWinPrice = string.Format(@"SELECT DISTINCT o.Number, o.GroupPrice, ci.{2} AS winRate, c.Page
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE oe.Number = '{0}' AND o.TypeID = {1} AND oe.TypeID = {4} AND c.CustomerID = '{3}'", winNumber, TypeID.ToString(), DBWinRate.tod2, customerID, _typeID.ToString());
                        }
                        else
                        {
                            sqlgetWinPrice = string.Format(@"SELECT DISTINCT o.Number, o.GroupPrice, ci.{2} AS winRate
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE oe.Number = '{0}' AND o.TypeID = {1} AND oe.TypeID = {5} AND c.CustomerID = '{3}' AND c.Page = {4}", winNumber, TypeID.ToString(), DBWinRate.tod2, customerID, PageID, _typeID.ToString());
                        }
                        break;
                    case BaseTypeID.tod2:
                        switch (state)
                        {
                            case "up":
                                _typeID = BaseTypeID.up2;
                                break;
                            case "ht":
                                _typeID = BaseTypeID.ht2;
                                break;
                            case "hu":
                                _typeID = BaseTypeID.hu2;
                                break;
                        }
                        if (string.Equals(PageID, "ทั้งหมด"))
                        {
                            sqlgetWinPrice = string.Format(@"SELECT o.Number, o.Price AS GroupPrice, ci.{2} AS winRate, c.Page
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE oe.Number = '{0}' AND o.TypeID = {1} AND oe.TypeID = {4} AND c.CustomerID = '{3}'", winNumber, TypeID.ToString(), DBWinRate.tod2, customerID, _typeID.ToString());
                        }
                        else
                        {
                            sqlgetWinPrice = string.Format(@"SELECT o.Number, o.Price AS GroupPrice, ci.{2} AS winRate
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE oe.Number = '{0}' AND o.TypeID = {1} AND oe.TypeID = {5} AND c.CustomerID = '{3}' AND c.Page = {4}", winNumber, TypeID.ToString(), DBWinRate.tod2, customerID, PageID, _typeID.ToString());
                        }
                        break;

                }
                SqlCommand sqlgetWinPriceCom = new SqlCommand(sqlgetWinPrice, connection);
                SqlDataReader winPriceInfo = sqlgetWinPriceCom.ExecuteReader();
                while (winPriceInfo.Read())
                {
                    _price = Convert.ToDouble(winPriceInfo["GroupPrice"]);
                    _winRate = Convert.ToDouble(winPriceInfo["winRate"]);
                    winPrice += _price;
                    if (string.Equals(PageID, "ทั้งหมด"))
                    {
                        PageOut.Add(Convert.ToInt32(winPriceInfo["Page"]));
                    }
                }
                connection.Close();
                //winPrice = outWinNumber;
                winRate = _winRate;
            }
            return PageOut;
        }
        private List<int> getwinPriceFromDB(string customerID, int TypeID, List<string> WinNumber, string PageID, out double winPrice, out double winRate)
        {
            List<int> PageOut = new List<int>();
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
                    case BaseTypeID.uptod3:

                        if (string.Equals(PageID, "ทั้งหมด"))
                        {
                            sqlgetWinPrice = string.Format(@"SELECT o.Number, o.Price, ci.{2} AS winRate, c.Page
                                            FROM ((OrderList o
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE o.Number = '{0}' AND o.TypeID = {1} AND c.CustomerID = '{3}'", winNumber, TypeID.ToString(), DBWinRate.up3, customerID);
                        }
                        else
                        {
                            sqlgetWinPrice = string.Format(@"SELECT o.Number, o.Price, ci.{2} AS winRate
                                            FROM ((OrderList o
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE o.Number = '{0}' AND o.TypeID = {1} AND c.CustomerID = '{3}' AND c.Page = {4}", winNumber, TypeID.ToString(), DBWinRate.up3, customerID, PageID);
                        }
                        break;
                    case BaseTypeID.up3:
                    case BaseTypeID.group3:
                    case BaseTypeID.group4:
                    case BaseTypeID.door543:
                    case BaseTypeID.tgroup3:
                        if (string.Equals(PageID, "ทั้งหมด"))
                        {
                            sqlgetWinPrice = string.Format(@"SELECT oe.Number, oe.Price, ci.{2} AS winRate, c.Page
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE oe.Number = '{0}' AND o.TypeID = {1} AND c.CustomerID = '{3}'", winNumber, TypeID.ToString(), DBWinRate.up3, customerID);
                        }
                        else
                        {
                            sqlgetWinPrice = string.Format(@"SELECT oe.Number, oe.Price, ci.{2} AS winRate
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE oe.Number = '{0}' AND o.TypeID = {1} AND c.CustomerID = '{3}' AND c.Page = {4}", winNumber, TypeID.ToString(), DBWinRate.up3, customerID, PageID);
                        }
                        break;
                    case BaseTypeID.uptod2:
                    case BaseTypeID.up2:
                    case BaseTypeID.ht2:
                    case BaseTypeID.hu2:
                        if (string.Equals(PageID, "ทั้งหมด"))
                        {
                            sqlgetWinPrice = string.Format(@"SELECT o.Number, o.Price, ci.{2} AS winRate, c.Page
                                            FROM ((OrderList o
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE o.Number = '{0}' AND o.TypeID = {1} AND c.CustomerID = '{3}'", winNumber, TypeID.ToString(), DBWinRate.up2, customerID);
                        }
                        else
                        {
                            sqlgetWinPrice = string.Format(@"SELECT o.Number, o.Price, ci.{2} AS winRate
                                            FROM ((OrderList o
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE o.Number = '{0}' AND o.TypeID = {1} AND c.CustomerID = '{3}' AND c.Page = {4}", winNumber, TypeID.ToString(), DBWinRate.up2, customerID, PageID);
                        }
                        break;
                    case BaseTypeID.door19up2:
                    case BaseTypeID.door62:
                        if (string.Equals(PageID, "ทั้งหมด"))
                        {
                            sqlgetWinPrice = string.Format(@"SELECT oe.Number, oe.Price, ci.{2} AS winRate, c.Page
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE oe.Number = '{0}' AND o.TypeID = {1} AND c.CustomerID = '{3}'", winNumber, TypeID.ToString(), DBWinRate.up2, customerID);
                        }
                        else
                        {
                            sqlgetWinPrice = string.Format(@"SELECT oe.Number, oe.Price, ci.{2} AS winRate
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE oe.Number = '{0}' AND o.TypeID = {1} AND c.CustomerID = '{3}' AND c.Page = {4}", winNumber, TypeID.ToString(), DBWinRate.up2, customerID, PageID);
                        }
                        break;
                    case BaseTypeID.low2:
                        if (string.Equals(PageID, "ทั้งหมด"))
                        {
                            sqlgetWinPrice = string.Format(@"SELECT o.Number, o.Price, ci.{2} AS winRate, c.Page
                                            FROM ((OrderList o
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE o.Number = '{0}' AND o.TypeID = {1} AND c.CustomerID = '{3}'", winNumber, TypeID.ToString(), DBWinRate.low2, customerID);
                        }
                        else
                        {
                            sqlgetWinPrice = string.Format(@"SELECT o.Number, o.Price, ci.{2} AS winRate
                                            FROM ((OrderList o
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE o.Number = '{0}' AND o.TypeID = {1} AND c.CustomerID = '{3}' AND c.Page = {4}", winNumber, TypeID.ToString(), DBWinRate.low2, customerID, PageID);
                        }
                        break;
                    case BaseTypeID.door19low2:
                        if (string.Equals(PageID, "ทั้งหมด"))
                        {
                            sqlgetWinPrice = string.Format(@"SELECT oe.Number, oe.Price, ci.{2} AS winRate, c.Page
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE oe.Number = '{0}' AND o.TypeID = {1} AND c.CustomerID = '{3}'", winNumber, TypeID.ToString(), DBWinRate.low2, customerID);
                        }
                        else
                        {
                            sqlgetWinPrice = string.Format(@"SELECT oe.Number, oe.Price, ci.{2} AS winRate
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE oe.Number = '{0}' AND o.TypeID = {1} AND c.CustomerID = '{3}' AND c.Page = {4}", winNumber, TypeID.ToString(), DBWinRate.low2, customerID, PageID);
                        }
                        break;
                    case BaseTypeID.group5:
                        if (string.Equals(PageID, "ทั้งหมด"))
                        {
                            sqlgetWinPrice = string.Format(@"SELECT oe.Number, oe.Price, ci.{2} AS winRate, c.Page
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE oe.Number = '{0}' AND o.TypeID = {1} AND c.CustomerID = '{3}'", winNumber, TypeID.ToString(), DBWinRate.up3, customerID);
                        }
                        else
                        {
                            sqlgetWinPrice = string.Format(@"SELECT oe.Number, oe.Price, ci.{2} AS winRate
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE oe.Number = '{0}' AND o.TypeID = {1} AND c.CustomerID = '{3}' AND c.Page = {4}", winNumber, TypeID.ToString(), DBWinRate.up3, customerID, PageID);
                        }
                        break;
                    case BaseTypeID.tod5:
                        if (string.Equals(PageID, "ทั้งหมด"))
                        {
                            sqlgetWinPrice = string.Format(@"SELECT o.Number, o.Price, ci.{2} AS winRate, c.Page
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE oe.Number = '{0}' AND o.TypeID = {1} AND c.CustomerID = '{3}'", winNumber, TypeID.ToString(), DBWinRate.tod5, customerID);
                        }
                        else
                        {
                            sqlgetWinPrice = string.Format(@"SELECT o.Number, o.Price, ci.{2} AS winRate
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE oe.Number = '{0}' AND o.TypeID = {1} AND c.CustomerID = '{3}' AND c.Page = {4}", winNumber, TypeID.ToString(), DBWinRate.tod5, customerID, PageID);
                        }
                        break;
                    case BaseTypeID.up1:
                        if (string.Equals(PageID, "ทั้งหมด"))
                        {
                            sqlgetWinPrice = string.Format(@"SELECT o.Number, o.Price, ci.{2} AS winRate, c.Page
                                            FROM ((OrderList o
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE o.Number = '{0}' AND o.TypeID = {1} AND c.CustomerID = '{3}'", winNumber, TypeID.ToString(), DBWinRate.up1, customerID);
                        }
                        else
                        {
                            sqlgetWinPrice = string.Format(@"SELECT o.Number, o.Price, ci.{2} AS winRate
                                            FROM ((OrderList o
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE o.Number = '{0}' AND o.TypeID = {1} AND c.CustomerID = '{3}' AND c.Page = {4}", winNumber, TypeID.ToString(), DBWinRate.up1, customerID, PageID);
                        }
                        break;
                    case BaseTypeID.low1:
                        if (string.Equals(PageID, "ทั้งหมด"))
                        {
                            sqlgetWinPrice = string.Format(@"SELECT o.Number, o.Price, ci.{2} AS winRate, c.Page
                                            FROM ((OrderList o
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE o.Number = '{0}' AND o.TypeID = {1} AND c.CustomerID = '{3}'", winNumber, TypeID.ToString(), DBWinRate.low1, customerID);
                        }
                        else
                        {
                            sqlgetWinPrice = string.Format(@"SELECT o.Number, o.Price, ci.{2} AS winRate
                                            FROM ((OrderList o
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE o.Number = '{0}' AND o.TypeID = {1} AND c.CustomerID = '{3}' AND c.Page = {4}", winNumber, TypeID.ToString(), DBWinRate.low1, customerID, PageID);
                        }
                        break;
                    case BaseTypeID.lowgroup3:
                    case BaseTypeID.low3:
                        if (string.Equals(PageID, "ทั้งหมด"))
                        {
                            sqlgetWinPrice = string.Format(@"SELECT oe.Number, oe.Price, ci.{2} AS winRate, c.Page
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE oe.Number = '{0}' AND o.TypeID = {1} AND c.CustomerID = '{3}'", winNumber, TypeID.ToString(), DBWinRate.low3, customerID);
                        }
                        else
                        {
                            sqlgetWinPrice = string.Format(@"SELECT oe.Number, oe.Price, ci.{2} AS winRate
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE oe.Number = '{0}' AND o.TypeID = {1} AND c.CustomerID = '{3}' AND c.Page = {4}", winNumber, TypeID.ToString(), DBWinRate.low3, customerID, PageID);
                        }
                        break;
                    case BaseTypeID.upfront1:
                        if (string.Equals(PageID, "ทั้งหมด"))
                        {
                            sqlgetWinPrice = string.Format(@"SELECT oe.Number, oe.Price, ci.{2} AS winRate, c.Page
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
                            sqlgetWinPrice = string.Format(@"SELECT oe.Number, oe.Price, ci.{2} AS winRate, c.Page
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
                            sqlgetWinPrice = string.Format(@"SELECT oe.Number, oe.Price, ci.{2} AS winRate, c.Page
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
                            sqlgetWinPrice = string.Format(@"SELECT oe.Number, oe.Price, ci.{2} AS winRate, c.Page
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
                            sqlgetWinPrice = string.Format(@"SELECT oe.Number, oe.Price, ci.{2} AS winRate, c.Page
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
                        /*
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
                        */
                        /*
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
                        
                            */

                }
                SqlCommand sqlgetWinPriceCom = new SqlCommand(sqlgetWinPrice, connection);
                SqlDataReader winPriceInfo = sqlgetWinPriceCom.ExecuteReader();
                
                while (winPriceInfo.Read())
                {
                    _price = Convert.ToDouble(winPriceInfo["Price"]);
                    _winRate = Convert.ToDouble(winPriceInfo["winRate"]);
                    winPrice += _price;
                    if (string.Equals(PageID, "ทั้งหมด"))
                    {
                        PageOut.Add(Convert.ToInt32(winPriceInfo["Page"]));

                    }
                }
                connection.Close();
                //winPrice = outWinNumber;
                winRate = _winRate;
                
            }
            return PageOut;
        }
        private double getDiscountFromDB(string CustomerID, int TypeID, string PageID)
        {
            double outDisc = 0;
            SqlConnection connection = new SqlConnection(Database.CnnVal("LottoryDB"));
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            string sqlgetDiscount = string.Empty;
            if (string.IsNullOrEmpty(PageID))
            {
                switch (TypeID)
                {
                    case BaseTypeID.uptod3:
                    case BaseTypeID.uptod2:
                        sqlgetDiscount = string.Format(@"SELECT ISNULL(SUM(oe.DiscPrice),0) AS DiscPrice
                                                         FROM (CustomerOrder c INNER JOIN OrderList o ON c.OrderID = o.OrderID)
                                                         INNER JOIN OrderListExpand oe ON o.OrderListID = oe.OrderListID
                                                         WHERE o.TypeID = {0} AND c.CustomerID = '{1}' AND (o.Number = oe.Number) AND (o.Price = oe.Price)", TypeID.ToString(), CustomerID);
                        //sqlgetPrice = string.Format(@"SELECT ISNULL(SUM(Price),0) AS Price
                        //                      FROM (CustomerOrder c INNER JOIN OrderList o ON c.OrderID = o.OrderID)
                        //                      WHERE o.TypeID = {0} AND c.CustomerID = '{1}'", TypeID.ToString(), CustomerID);
                        break;
                    case BaseTypeID.group4:
                    case BaseTypeID.up3:
                    case BaseTypeID.low3:
                    case BaseTypeID.group3:
                    case BaseTypeID.door543:
                    case BaseTypeID.tgroup3:
                    case BaseTypeID.lowgroup3:

                    case BaseTypeID.up2:
                    case BaseTypeID.low2:
                    case BaseTypeID.door62:
                    case BaseTypeID.door19up2:
                    case BaseTypeID.door19low2:
                    case BaseTypeID.hu2:
                    case BaseTypeID.ht2:
                    case BaseTypeID.group5:
                    case BaseTypeID.tod5:

                    case BaseTypeID.up1:
                    case BaseTypeID.low1:
                    case BaseTypeID.upfront1:
                    case BaseTypeID.upcenter1:
                    case BaseTypeID.upback1:
                    case BaseTypeID.lowfront1:
                    case BaseTypeID.lowback1:
                        sqlgetDiscount = string.Format(@"SELECT ISNULL(SUM(oe.DiscPrice),0) AS DiscPrice
                                                         FROM (CustomerOrder c INNER JOIN OrderList o ON c.OrderID = o.OrderID)
                                                         INNER JOIN OrderListExpand oe ON o.OrderListID = oe.OrderListID
                                                         WHERE o.TypeID = {0} AND c.CustomerID = '{1}' ", TypeID.ToString(), CustomerID);
                        //sqlgetPrice = string.Format(@"SELECT ISNULL(SUM(OwnPrice),0) AS Price
                        //                      FROM (CustomerOrder c INNER JOIN OrderList o ON c.OrderID = o.OrderID)
                        //                      INNER JOIN OrderListExpand oe ON o.OrderListID = oe.OrderListID
                        //                      WHERE o.TypeID = {0} AND c.CustomerID = '{1}'", TypeID.ToString(), CustomerID);
                        break;

                }
                //sqlgetDiscount = string.Format(@"SELECT ISNULL(SUM(DiscPrice),0) AS Price
                //                              FROM (CustomerOrder c INNER JOIN OrderList o ON c.OrderID = o.OrderID)
                //                              INNER JOIN OrderListExpand oe ON o.OrderListID = oe.OrderListID
                //                              WHERE oe.TypeID = {0} AND c.CustomerID = '{1}'", TypeID.ToString(), CustomerID);
            }
            else
            {
                switch (TypeID)
                {
                    case BaseTypeID.uptod3:
                    case BaseTypeID.uptod2:
                        sqlgetDiscount = string.Format(@"SELECT ISNULL(SUM(oe.DiscPrice),0) AS DiscPrice
                                                         FROM (CustomerOrder c INNER JOIN OrderList o ON c.OrderID = o.OrderID)
                                                         INNER JOIN OrderListExpand oe ON o.OrderListID = oe.OrderListID
                                                         WHERE o.TypeID = {0} AND c.CustomerID = '{1}' AND (o.Number = oe.Number) AND (o.Price = oe.Price) AND c.Page = {2}", TypeID.ToString(), CustomerID, PageID);
                        //sqlgetPrice = string.Format(@"SELECT ISNULL(SUM(Price),0) AS Price
                        //                      FROM (CustomerOrder c INNER JOIN OrderList o ON c.OrderID = o.OrderID)
                        //                      WHERE o.TypeID = {0} AND c.CustomerID = '{1}'", TypeID.ToString(), CustomerID);
                        break;
                    case BaseTypeID.group4:
                    case BaseTypeID.up3:
                    case BaseTypeID.low3:
                    case BaseTypeID.group3:
                    case BaseTypeID.door543:
                    case BaseTypeID.tgroup3:
                    case BaseTypeID.lowgroup3:

                    case BaseTypeID.up2:
                    case BaseTypeID.low2:
                    case BaseTypeID.door62:
                    case BaseTypeID.door19up2:
                    case BaseTypeID.door19low2:
                    case BaseTypeID.hu2:
                    case BaseTypeID.ht2:
                    case BaseTypeID.group5:
                    case BaseTypeID.tod5:

                    case BaseTypeID.up1:
                    case BaseTypeID.low1:
                    case BaseTypeID.upfront1:
                    case BaseTypeID.upcenter1:
                    case BaseTypeID.upback1:
                    case BaseTypeID.lowfront1:
                    case BaseTypeID.lowback1:
                        sqlgetDiscount = string.Format(@"SELECT ISNULL(SUM(oe.DiscPrice),0) AS DiscPrice
                                                         FROM (CustomerOrder c INNER JOIN OrderList o ON c.OrderID = o.OrderID)
                                                         INNER JOIN OrderListExpand oe ON o.OrderListID = oe.OrderListID
                                                         WHERE o.TypeID = {0} AND c.CustomerID = '{1}' AND c.Page = {2}", TypeID.ToString(), CustomerID, PageID);
                        //sqlgetPrice = string.Format(@"SELECT ISNULL(SUM(OwnPrice),0) AS Price
                        //                      FROM (CustomerOrder c INNER JOIN OrderList o ON c.OrderID = o.OrderID)
                        //                      INNER JOIN OrderListExpand oe ON o.OrderListID = oe.OrderListID
                        //                      WHERE o.TypeID = {0} AND c.CustomerID = '{1}'", TypeID.ToString(), CustomerID);
                        break;

                }
                //sqlgetDiscount = string.Format(@"SELECT ISNULL(SUM(DiscPrice),0) AS Price
                //                              FROM (CustomerOrder c INNER JOIN OrderList o ON c.OrderID = o.OrderID)
                //                              INNER JOIN OrderListExpand oe ON o.OrderListID = oe.OrderListID
                //                              WHERE oe.TypeID = {0} AND c.CustomerID = '{1}' AND c.Page = {2}", TypeID.ToString(), CustomerID, PageID);
            }

            SqlCommand sqlgetPriceCom = new SqlCommand(sqlgetDiscount, connection);
            SqlDataReader PriceInfo = sqlgetPriceCom.ExecuteReader();
            while (PriceInfo.Read())
            {
                outDisc = Convert.ToDouble(PriceInfo["DiscPrice"]);
            }
            connection.Close();
            return outDisc;
        }
        private double getGDiscountFromDB(string CustomerID, int TypeID, string PageID)
        {
            double outDisc = 0;
            SqlConnection connection = new SqlConnection(Database.CnnVal("LottoryDB"));
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            string sqlgetDiscount = string.Empty;
            if (string.IsNullOrEmpty(PageID))
            {
                switch (TypeID)
                {
                    case BaseTypeID.uptod3:
                    case BaseTypeID.uptod2:
                        sqlgetDiscount = string.Format(@"SELECT ISNULL(SUM(oe.DiscPrice),0) AS DiscPrice
                                                         FROM (CustomerOrder c INNER JOIN OrderList o ON c.OrderID = o.OrderID)
                                                         INNER JOIN OrderListExpand oe ON o.OrderListID = oe.OrderListID
                                                         WHERE o.TypeID = {0} AND c.CustomerID = '{1}' AND (o.Price <> oe.Price)", TypeID.ToString(), CustomerID);
                        //sqlgetPrice = string.Format(@"SELECT ISNULL(SUM(Price),0) AS Price
                        //                      FROM (CustomerOrder c INNER JOIN OrderList o ON c.OrderID = o.OrderID)
                        //                      WHERE o.TypeID = {0} AND c.CustomerID = '{1}'", TypeID.ToString(), CustomerID);
                        break;
                    case BaseTypeID.tod3:
                    case BaseTypeID.tod2:
                        sqlgetDiscount = string.Format(@"SELECT ISNULL(SUM(oe.DiscPrice),0) AS DiscPrice
                                                         FROM (CustomerOrder c INNER JOIN OrderList o ON c.OrderID = o.OrderID)
                                                         INNER JOIN OrderListExpand oe ON o.OrderListID = oe.OrderListID
                                                         WHERE o.TypeID = {0} AND c.CustomerID = '{1}' ", TypeID.ToString(), CustomerID);
                        //sqlgetPrice = string.Format(@"SELECT ISNULL(SUM(OwnPrice),0) AS Price
                        //                      FROM (CustomerOrder c INNER JOIN OrderList o ON c.OrderID = o.OrderID)
                        //                      INNER JOIN OrderListExpand oe ON o.OrderListID = oe.OrderListID
                        //                      WHERE o.TypeID = {0} AND c.CustomerID = '{1}'", TypeID.ToString(), CustomerID);
                        break;

                }
                //sqlgetDiscount = string.Format(@"SELECT ISNULL(SUM(DiscPrice),0) AS Price
                //                              FROM (CustomerOrder c INNER JOIN OrderList o ON c.OrderID = o.OrderID)
                //                              INNER JOIN OrderListExpand oe ON o.OrderListID = oe.OrderListID
                //                              WHERE oe.TypeID = {0} AND c.CustomerID = '{1}'", TypeID.ToString(), CustomerID);
            }
            else
            {
                switch (TypeID)
                {
                    case BaseTypeID.uptod3:
                    case BaseTypeID.uptod2:
                        sqlgetDiscount = string.Format(@"SELECT ISNULL(SUM(oe.DiscPrice),0) AS DiscPrice
                                                         FROM (CustomerOrder c INNER JOIN OrderList o ON c.OrderID = o.OrderID)
                                                         INNER JOIN OrderListExpand oe ON o.OrderListID = oe.OrderListID
                                                         WHERE o.TypeID = {0} AND c.CustomerID = '{1}' AND (o.Price <> oe.Price) AND c.Page = {2}", TypeID.ToString(), CustomerID, PageID);
                        //sqlgetPrice = string.Format(@"SELECT ISNULL(SUM(Price),0) AS Price
                        //                      FROM (CustomerOrder c INNER JOIN OrderList o ON c.OrderID = o.OrderID)
                        //                      WHERE o.TypeID = {0} AND c.CustomerID = '{1}'", TypeID.ToString(), CustomerID);
                        break;
                    case BaseTypeID.tod3:
                    case BaseTypeID.tod2:
                        sqlgetDiscount = string.Format(@"SELECT ISNULL(SUM(oe.DiscPrice),0) AS DiscPrice
                                                         FROM (CustomerOrder c INNER JOIN OrderList o ON c.OrderID = o.OrderID)
                                                         INNER JOIN OrderListExpand oe ON o.OrderListID = oe.OrderListID
                                                         WHERE o.TypeID = {0} AND c.CustomerID = '{1}' AND c.Page = {2}", TypeID.ToString(), CustomerID, PageID);
                        //sqlgetPrice = string.Format(@"SELECT ISNULL(SUM(OwnPrice),0) AS Price
                        //                      FROM (CustomerOrder c INNER JOIN OrderList o ON c.OrderID = o.OrderID)
                        //                      INNER JOIN OrderListExpand oe ON o.OrderListID = oe.OrderListID
                        //                      WHERE o.TypeID = {0} AND c.CustomerID = '{1}'", TypeID.ToString(), CustomerID);
                        break;

                }
                //sqlgetDiscount = string.Format(@"SELECT ISNULL(SUM(DiscPrice),0) AS Price
                //                              FROM (CustomerOrder c INNER JOIN OrderList o ON c.OrderID = o.OrderID)
                //                              INNER JOIN OrderListExpand oe ON o.OrderListID = oe.OrderListID
                //                              WHERE oe.TypeID = {0} AND c.CustomerID = '{1}' AND c.Page = {2}", TypeID.ToString(), CustomerID, PageID);
            }

            SqlCommand sqlgetPriceCom = new SqlCommand(sqlgetDiscount, connection);
            SqlDataReader PriceInfo = sqlgetPriceCom.ExecuteReader();
            while (PriceInfo.Read())
            {
                outDisc = Convert.ToDouble(PriceInfo["DiscPrice"]);
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
            string sqlgetPrice = string.Empty;
            if (string.IsNullOrEmpty(PageID))
            {
                switch(TypeID)
                {
                    case BaseTypeID.uptod3:
                    case BaseTypeID.uptod2:
                        sqlgetPrice = string.Format(@"SELECT ISNULL(SUM(Price),0) AS Price
                                              FROM (CustomerOrder c INNER JOIN OrderList o ON c.OrderID = o.OrderID)
                                              WHERE o.TypeID = {0} AND c.CustomerID = '{1}'", TypeID.ToString(), CustomerID);
                        break;
                    case BaseTypeID.group4:
                    case BaseTypeID.up3:
                    case BaseTypeID.low3:
                    case BaseTypeID.group3:
                    case BaseTypeID.door543:
                    case BaseTypeID.tgroup3:
                    case BaseTypeID.lowgroup3:

                    case BaseTypeID.up2:
                    case BaseTypeID.low2:
                    case BaseTypeID.door62:
                    case BaseTypeID.door19up2:
                    case BaseTypeID.door19low2:
                    case BaseTypeID.hu2:
                    case BaseTypeID.ht2:

                    case BaseTypeID.group5:
                    case BaseTypeID.tod5:

                    case BaseTypeID.up1:
                    case BaseTypeID.low1:
                    case BaseTypeID.upfront1:
                    case BaseTypeID.upcenter1:
                    case BaseTypeID.upback1:
                    case BaseTypeID.lowfront1:
                    case BaseTypeID.lowback1:
                        sqlgetPrice = string.Format(@"SELECT ISNULL(SUM(OwnPrice),0) AS Price
                                              FROM (CustomerOrder c INNER JOIN OrderList o ON c.OrderID = o.OrderID)
                                              INNER JOIN OrderListExpand oe ON o.OrderListID = oe.OrderListID
                                              WHERE o.TypeID = {0} AND c.CustomerID = '{1}'", TypeID.ToString(), CustomerID);
                        break;

                }

            }
            else
            {
                switch (TypeID)
                {
                    case BaseTypeID.uptod3:
                    case BaseTypeID.uptod2:
                        sqlgetPrice = string.Format(@"SELECT ISNULL(SUM(Price),0) AS Price
                                              FROM (CustomerOrder c INNER JOIN OrderList o ON c.OrderID = o.OrderID)
                                              WHERE o.TypeID = {0} AND c.CustomerID = '{1}' AND c.Page = {2}", TypeID.ToString(), CustomerID, PageID);
                        break;
                    case BaseTypeID.group4:
                    case BaseTypeID.up3:
                    case BaseTypeID.low3:
                    case BaseTypeID.group3:
                    case BaseTypeID.door543:
                    case BaseTypeID.tgroup3:
                    case BaseTypeID.lowgroup3:

                    case BaseTypeID.up2:
                    case BaseTypeID.low2:
                    case BaseTypeID.door62:
                    case BaseTypeID.door19up2:
                    case BaseTypeID.door19low2:
                    case BaseTypeID.hu2:
                    case BaseTypeID.ht2:
                    case BaseTypeID.group5:
                    case BaseTypeID.tod5:

                    case BaseTypeID.up1:
                    case BaseTypeID.low1:
                    case BaseTypeID.upfront1:
                    case BaseTypeID.upcenter1:
                    case BaseTypeID.upback1:
                    case BaseTypeID.lowfront1:
                    case BaseTypeID.lowback1:
                        sqlgetPrice = string.Format(@"SELECT ISNULL(SUM(OwnPrice),0) AS Price
                                              FROM (CustomerOrder c INNER JOIN OrderList o ON c.OrderID = o.OrderID)
                                              INNER JOIN OrderListExpand oe ON o.OrderListID = oe.OrderListID
                                              WHERE o.TypeID = {0} AND c.CustomerID = '{1}' AND c.Page = {2}", TypeID.ToString(), CustomerID, PageID);
                        break;

                }
                //sqlgetPrice = string.Format(@"SELECT ISNULL(SUM(OwnPrice),0) AS Price
                //                              FROM (CustomerOrder c INNER JOIN OrderList o ON c.OrderID = o.OrderID)
                //                              INNER JOIN OrderListExpand oe ON o.OrderListID = oe.OrderListID
                //                              WHERE oe.TypeID = {0} AND c.CustomerID = '{1}' AND c.Page = {2}", TypeID.ToString(), CustomerID, PageID);
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
        private int getGroupFromDB(string CustomerID, int TypeID, string PageID)
        {
            int outPrice = 0;
            SqlConnection connection = new SqlConnection(Database.CnnVal("LottoryDB"));
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            string sqlgetGPrice = string.Empty;
            if (string.IsNullOrEmpty(PageID))
            {
                switch (TypeID)
                {
                    case BaseTypeID.uptod3:
                    case BaseTypeID.uptod2:
                        sqlgetGPrice = string.Format(@"SELECT ISNULL(SUM(GroupPrice),0) AS Price
                                              FROM (CustomerOrder c INNER JOIN OrderList o ON c.OrderID = o.OrderID)
                                              WHERE o.TypeID = {0} AND c.CustomerID = '{1}'", TypeID.ToString(), CustomerID);
                        break;
                    case BaseTypeID.tod3:
                    case BaseTypeID.tod2:
                        sqlgetGPrice = string.Format(@"SELECT ISNULL(SUM(OwnPrice),0) AS Price
                                              FROM (CustomerOrder c INNER JOIN OrderList o ON c.OrderID = o.OrderID)
                                              INNER JOIN OrderListExpand oe ON o.OrderListID = oe.OrderListID
                                              WHERE o.TypeID = {0} AND c.CustomerID = '{1}'", TypeID.ToString(), CustomerID);
                        break;

                }

            }
            else
            {
                switch (TypeID)
                {
                    case BaseTypeID.uptod3:
                    case BaseTypeID.uptod2:
                        sqlgetGPrice = string.Format(@"SELECT ISNULL(SUM(GroupPrice),0) AS Price
                                              FROM (CustomerOrder c INNER JOIN OrderList o ON c.OrderID = o.OrderID)
                                              WHERE o.TypeID = {0} AND c.CustomerID = '{1}' AND c.Page = {2}", TypeID.ToString(), CustomerID, PageID);
                        break;
                    case BaseTypeID.tod3:
                    case BaseTypeID.tod2:
                        sqlgetGPrice = string.Format(@"SELECT ISNULL(SUM(OwnPrice),0) AS Price
                                              FROM (CustomerOrder c INNER JOIN OrderList o ON c.OrderID = o.OrderID)
                                              INNER JOIN OrderListExpand oe ON o.OrderListID = oe.OrderListID
                                              WHERE o.TypeID = {0} AND c.CustomerID = '{1}' AND c.Page = {2}", TypeID.ToString(), CustomerID, PageID);
                        break;

                }
                //sqlgetPrice = string.Format(@"SELECT ISNULL(SUM(OwnPrice),0) AS Price
                //                              FROM (CustomerOrder c INNER JOIN OrderList o ON c.OrderID = o.OrderID)
                //                              INNER JOIN OrderListExpand oe ON o.OrderListID = oe.OrderListID
                //                              WHERE oe.TypeID = {0} AND c.CustomerID = '{1}' AND c.Page = {2}", TypeID.ToString(), CustomerID, PageID);
            }

            SqlCommand sqlgetPriceCom = new SqlCommand(sqlgetGPrice, connection);
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
            List<string> PageList = getPageList(CustomerIDList.Text);
            PageList.Add("ทั้งหมด");
            PageIDList.DataSource = PageList;
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
            PageList.Add("ทั้งหมด");
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

        private void CustomerReportSummary_KeyDown(object sender, KeyEventArgs e)
        {
            Form mainLotto = this.MdiParent;
            foreach (Form child in mainLotto.MdiChildren)
            {
                switch (e.KeyCode)
                {
                    case Keys.F10:
                        // active Number Detail
                        if (string.Equals(child.Name, "AddNumberDetail"))
                        {
                            child.Activate();
                            this.Close();
                        }
                        break;
                    case Keys.F1:
                        if (string.Equals(child.Name, "AddNumberSetting"))
                        {
                            child.Activate();
                            this.Close();
                        }
                        break;
                }

            }

        }
    }
}
