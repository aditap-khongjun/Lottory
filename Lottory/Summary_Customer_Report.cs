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
    public partial class Summary_Customer_Report : Form
    {
        private static Summary_Customer_Report _instance;
        public static Summary_Customer_Report Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Summary_Customer_Report();
                return _instance;
            }
        }
        private void Summary_Customer_Report_FormClosed(object sender, FormClosedEventArgs e)
        {
            _instance = null;
        }
        public Summary_Customer_Report()
        {
            InitializeComponent();
        }

        private void Summary_Customer_Report_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'MyLottoDBDataSet.Customer_Report_Dataset' table. You can move, or remove it, as needed.
            //this.Customer_Report_DatasetTableAdapter.Fill(this.MyLottoDBDataSet.Customer_Report_Dataset);
            // try datatable
            DataTable customerInfo = getCustomerBuyingSummary();

            // TODO: This line of code loads data into the 'Lotto_DBDataSet4.Customer_Report_Dataset' table. You can move, or remove it, as needed.
            //this.Customer_Report_DatasetTableAdapter.Fill(this.Lotto_DBDataSet4.Customer_Report_Dataset);
            Summary_CustomerInfo summaryCustomer = getSummary(customerInfo);



            this.BSCustomerBuying.DataSource = customerInfo;
            this.BSSummary.DataSource = summaryCustomer;
            this.reportViewer1.RefreshReport();
        }
        private Summary_CustomerInfo getSummary(DataTable tableData)
        {
            Summary_CustomerInfo outSummary = new Summary_CustomerInfo();
            double _sumPrice = 0;
            double _sumDisc = 0;
            double _sumWinPrice = 0;
            double _sumNetPrice = 0;
            foreach(DataRow dr in tableData.Rows)
            {
                _sumPrice += Convert.ToDouble(dr.ItemArray[2]);
                _sumDisc += Convert.ToDouble(dr.ItemArray[3]);
                _sumWinPrice += Convert.ToDouble(dr.ItemArray[4]);
                _sumNetPrice += Convert.ToDouble(dr.ItemArray[5]);
            }
            outSummary.sumPrice = _sumPrice.ToString("N0");
            outSummary.sumDiscount = _sumDisc.ToString("N0");
            outSummary.sumWinPrice = _sumWinPrice.ToString("N0");
            outSummary.sumNetPrice = _sumNetPrice.ToString("N0");

            return outSummary;
        }
        private DataTable getCustomerBuyingSummary()
        {
            DataTable outData = new DataTable();
            outData.Columns.Add("CustomerID");
            outData.Columns.Add("CustomerName");
            outData.Columns.Add("Price");
            outData.Columns.Add("Discount");
            outData.Columns.Add("WinPrice");
            outData.Columns.Add("netPrice");

            // get Customer List
            DataTable CustomerInfo = getCustomerList();
            foreach (DataRow customerinfo in CustomerInfo.Rows)
            {
                string customerID = customerinfo.ItemArray[0].ToString();
                string customerName = customerinfo.ItemArray[1].ToString();
                // get Price
                double _Price = getPrice(customerID);

                // get Discount
                double _Discount = getDiscount(customerID);

                // get WinPrice
                double _winPrice = getWinPrice(customerID);

                // get Net Price
                double _netPrice = _Price - (_Discount + _winPrice);

                outData.Rows.Add(customerID, customerName, _Price.ToString("N0"), _Discount.ToString("N0"), _winPrice.ToString("N0"), _netPrice.ToString("N0"));
            }

            return outData;

        }
        private DataTable getCustomerList()
        {
            DataTable outCustomerID = new DataTable();
            SqlConnection connection = new SqlConnection(Database.CnnVal("LottoryDB"));
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            string sqlgetCustomerID = @"SELECT ci.CustomerID, MAX(ci.CustomerName) AS CustomerName
                                        FROM CustomerOrder c INNER JOIN CustomerInfo ci ON c.CustomerID = ci. CustomerID
                                        GROUP BY ci.CustomerID";
            SqlDataAdapter da = new SqlDataAdapter(sqlgetCustomerID, connection);
            da.Fill(outCustomerID);
            connection.Close();

            return outCustomerID;
        }
        private double getPrice(string customerID)
        {
            double outPrice = 0;
            SqlConnection connection = new SqlConnection(Database.CnnVal("LottoryDB"));
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            string sqlgetPrice = string.Format(@"SELECT ISNULL(SUM(OwnPrice),0) AS Price
                                                 FROM ((CustomerOrder c INNER JOIN OrderList o ON c.OrderID = o.OrderID)
                                                 INNER JOIN OrderListExpand oe ON o.OrderListID = oe.OrderListID)
                                                 WHERE c.CustomerID = '{0}'", customerID);
            SqlCommand sqlgetPriceCom = new SqlCommand(sqlgetPrice, connection);
            SqlDataReader PriceInfo = sqlgetPriceCom.ExecuteReader();
            if (PriceInfo.Read())
            {
                outPrice = Convert.ToDouble(PriceInfo["Price"]);
            }
            connection.Close();
            return outPrice;
        }
        private double getDiscount(string customerID)
        {
            double outDiscount = 0;
            SqlConnection connection = new SqlConnection(Database.CnnVal("LottoryDB"));
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            string sqlgetDiscount = string.Format(@"SELECT ISNULL(SUM(DiscPrice),0) AS Discount
                                                 FROM ((CustomerOrder c INNER JOIN OrderList o ON c.OrderID = o.OrderID)
                                                 INNER JOIN OrderListExpand oe ON o.OrderListID = oe.OrderListID)
                                                 WHERE c.CustomerID = '{0}'", customerID);
            SqlCommand sqlgetDiscountCom = new SqlCommand(sqlgetDiscount, connection);
            SqlDataReader DiscountInfo = sqlgetDiscountCom.ExecuteReader();
            if (DiscountInfo.Read())
            {
                outDiscount = Convert.ToDouble(DiscountInfo["Discount"]);
            }
            connection.Close();

            return outDiscount;

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
        private double getwinPriceFromDB(string CustomerID, int TypeID, List<string> WinNumber)
        {
            double outWinNumber = 0;
            string sqlgetWinPrice = string.Empty;
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
                                            WHERE oe.Number = '{0}' AND oe.TypeID = {1} AND c.CustomerID = '{3}'", winNumber, TypeID.ToString(), DBWinRate.up3, CustomerID);
                        break;
                    case BaseTypeID.low3:
                        sqlgetWinPrice = string.Format(@"SELECT oe.Number, oe.Price, ci.{2} AS winRate
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE oe.Number = '{0}' AND oe.TypeID = {1} AND c.CustomerID = '{3}'", winNumber, TypeID.ToString(), DBWinRate.low3, CustomerID);
                        break;
                    case BaseTypeID.up2:
                    case BaseTypeID.ht2:
                    case BaseTypeID.hu2:
                        sqlgetWinPrice = string.Format(@"SELECT oe.Number, oe.Price, ci.{2} AS winRate
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE oe.Number = '{0}' AND oe.TypeID = {1} AND c.CustomerID = '{3}'", winNumber, TypeID.ToString(), DBWinRate.up2, CustomerID);
                        break;
                    case BaseTypeID.low2:
                        sqlgetWinPrice = string.Format(@"SELECT oe.Number, oe.Price, ci.{2} AS winRate
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE oe.Number = '{0}' AND oe.TypeID = {1} AND c.CustomerID = '{3}'", winNumber, TypeID.ToString(), DBWinRate.low2, CustomerID);
                        break;
                    case BaseTypeID.up1:
                        sqlgetWinPrice = string.Format(@"SELECT oe.Number, oe.Price, ci.{2} AS winRate
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE oe.Number = '{0}' AND oe.TypeID = {1} AND c.CustomerID = '{3}'", winNumber, TypeID.ToString(), DBWinRate.up1, CustomerID);
                        break;
                    case BaseTypeID.low1:
                        sqlgetWinPrice = string.Format(@"SELECT oe.Number, oe.Price, ci.{2} AS winRate
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE oe.Number = '{0}' AND oe.TypeID = {1} AND c.CustomerID = '{3}'", winNumber, TypeID.ToString(), DBWinRate.low1, CustomerID);
                        break;
                    case BaseTypeID.upfront1:
                        sqlgetWinPrice = string.Format(@"SELECT oe.Number, oe.Price, ci.{2} AS winRate
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE oe.Number = '{0}' AND oe.TypeID = {1} AND c.CustomerID = '{3}'", winNumber, TypeID.ToString(), DBWinRate.upfront1, CustomerID);
                        break;
                    case BaseTypeID.upback1:
                        sqlgetWinPrice = string.Format(@"SELECT oe.Number, oe.Price, ci.{2} AS winRate
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE oe.Number = '{0}' AND oe.TypeID = {1} AND c.CustomerID = '{3}'", winNumber, TypeID.ToString(), DBWinRate.upback1, CustomerID);
                        break;
                    case BaseTypeID.upcenter1:
                        sqlgetWinPrice = string.Format(@"SELECT oe.Number, oe.Price, ci.{2} AS winRate
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE oe.Number = '{0}' AND oe.TypeID = {1} AND c.CustomerID = '{3}'", winNumber, TypeID.ToString(), DBWinRate.upcenter1, CustomerID);
                        break;
                    case BaseTypeID.lowfront1:
                        sqlgetWinPrice = string.Format(@"SELECT oe.Number, oe.Price, ci.{2} AS winRate
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE oe.Number = '{0}' AND oe.TypeID = {1} AND c.CustomerID = '{3}'", winNumber, TypeID.ToString(), DBWinRate.upfront1, CustomerID);
                        break;
                    case BaseTypeID.lowback1:
                        sqlgetWinPrice = string.Format(@"SELECT oe.Number, oe.Price, ci.{2} AS winRate
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE oe.Number = '{0}' AND oe.TypeID = {1} AND c.CustomerID = '{3}'", winNumber, TypeID.ToString(), DBWinRate.upback1, CustomerID);
                        break;

                }
                SqlCommand sqlgetWinPriceCom = new SqlCommand(sqlgetWinPrice, connection);
                SqlDataReader winPriceInfo = sqlgetWinPriceCom.ExecuteReader();
                while (winPriceInfo.Read())
                {
                    double _price = Convert.ToDouble(winPriceInfo["Price"]);
                    double _winRate = Convert.ToDouble(winPriceInfo["winRate"]);
                    outWinNumber += _price * _winRate;
                }
                connection.Close();
            }
            return outWinNumber;
        }
        private double getWinPrice(string CustomerID)
        {
            List<double> outWinList = new List<double>();

            outWinList.Add(getwinPriceFromDB(CustomerID, BaseTypeID.up3, getWinNumber(WinNumberType.up3)));
            outWinList.Add(getwinPriceFromDB(CustomerID, BaseTypeID.low3, getWinNumber(WinNumberType.low3)));
            outWinList.Add(getwinPriceFromDB(CustomerID, BaseTypeID.up2, getWinNumber(WinNumberType.up2)));
            outWinList.Add(getwinPriceFromDB(CustomerID, BaseTypeID.low2, getWinNumber(WinNumberType.low2)));
            outWinList.Add(getwinPriceFromDB(CustomerID, BaseTypeID.ht2, getWinNumber(WinNumberType.ht2)));
            outWinList.Add(getwinPriceFromDB(CustomerID, BaseTypeID.hu2, getWinNumber(WinNumberType.hu2)));
            outWinList.Add(getwinPriceFromDB(CustomerID, BaseTypeID.up1, getWinNumber(WinNumberType.up1)));
            outWinList.Add(getwinPriceFromDB(CustomerID, BaseTypeID.low1, getWinNumber(WinNumberType.low1)));
            outWinList.Add(getwinPriceFromDB(CustomerID, BaseTypeID.upfront1, getWinNumber(WinNumberType.upfront1)));
            outWinList.Add(getwinPriceFromDB(CustomerID, BaseTypeID.upcenter1, getWinNumber(WinNumberType.upcenter1)));
            outWinList.Add(getwinPriceFromDB(CustomerID, BaseTypeID.upback1, getWinNumber(WinNumberType.upback1)));
            outWinList.Add(getwinPriceFromDB(CustomerID, BaseTypeID.lowfront1, getWinNumber(WinNumberType.lowfront1)));
            outWinList.Add(getwinPriceFromDB(CustomerID, BaseTypeID.lowback1, getWinNumber(WinNumberType.lowback1)));

            return outWinList.Sum();
        }


    }
}
