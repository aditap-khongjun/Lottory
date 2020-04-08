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

                outData.Rows.Add(customerID, customerName, _Price.ToString("N0"), (_Price - _Discount).ToString("N0"), _winPrice.ToString("N0"), _netPrice.ToString("N0"));
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
        private double getwinGPriceFromDB(string CustomerID, int TypeID, List<string> WinNumber)
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
                    case BaseTypeID.uptod3:
                        sqlgetWinPrice = string.Format(@"SELECT o.Number, o.GroupPrice, ci.{2} AS winRate
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE oe.Number = '{0}' AND o.TypeID = {1} AND c.CustomerID = '{3}'", winNumber, TypeID.ToString(), DBWinRate.tod3, CustomerID);
                        break;
                    case BaseTypeID.tod3:
                        sqlgetWinPrice = string.Format(@"SELECT o.Number, o.Price AS GroupPrice, ci.{2} AS winRate
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE oe.Number = '{0}' AND o.TypeID = {1} AND c.CustomerID = '{3}'", winNumber, TypeID.ToString(), DBWinRate.tod3, CustomerID);
                        break;
                    case BaseTypeID.uptod2:
                        sqlgetWinPrice = string.Format(@"SELECT o.Number, o.GroupPrice, ci.{2} AS winRate
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE oe.Number = '{0}' AND o.TypeID = {1} AND c.CustomerID = '{3}'", winNumber, TypeID.ToString(), DBWinRate.tod2, CustomerID);
                        break;
                    case BaseTypeID.tod2:
                        sqlgetWinPrice = string.Format(@"SELECT o.Number, o.Price AS GroupPrice, ci.{2} AS winRate
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE oe.Number = '{0}' AND o.TypeID = {1} AND c.CustomerID = '{3}'", winNumber, TypeID.ToString(), DBWinRate.tod2, CustomerID);
                        break;
                }
                SqlCommand sqlgetWinPriceCom = new SqlCommand(sqlgetWinPrice, connection);
                SqlDataReader winPriceInfo = sqlgetWinPriceCom.ExecuteReader();
                while (winPriceInfo.Read())
                {
                    double _price = Convert.ToDouble(winPriceInfo["GroupPrice"]);
                    double _winRate = Convert.ToDouble(winPriceInfo["winRate"]);
                    outWinNumber += _price * _winRate;
                }
                connection.Close();
            }
            return outWinNumber;
        }
        private double getwinGPriceFromDB(string CustomerID, int TypeID,string state, List<string> WinNumber)
        {
            double outWinNumber = 0;
            int _typeID = 0;
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
                    case BaseTypeID.uptod3:
                        sqlgetWinPrice = string.Format(@"SELECT o.Number, o.GroupPrice, ci.{2} AS winRate
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE oe.Number = '{0}' AND o.TypeID = {1} AND c.CustomerID = '{3}'", winNumber, TypeID.ToString(), DBWinRate.tod3, CustomerID);
                        break;
                    case BaseTypeID.tod3:
                        sqlgetWinPrice = string.Format(@"SELECT o.Number, o.Price AS GroupPrice, ci.{2} AS winRate
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE oe.Number = '{0}' AND o.TypeID = {1} AND c.CustomerID = '{3}'", winNumber, TypeID.ToString(), DBWinRate.tod3, CustomerID);
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
                        sqlgetWinPrice = string.Format(@"SELECT DISTINCT o.Number, o.GroupPrice, ci.{2} AS winRate
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE oe.Number = '{0}' AND o.TypeID = {1} AND oe.TypeID = {4} AND c.CustomerID = '{3}'", winNumber, TypeID.ToString(), DBWinRate.tod2, CustomerID, _typeID.ToString());
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
                        sqlgetWinPrice = string.Format(@"SELECT o.Number, o.Price AS GroupPrice, ci.{2} AS winRate
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE oe.Number = '{0}' AND o.TypeID = {1} AND oe.TypeID = {4} AND c.CustomerID = '{3}'", winNumber, TypeID.ToString(), DBWinRate.tod2, CustomerID, _typeID.ToString());
                        break;
                }
                SqlCommand sqlgetWinPriceCom = new SqlCommand(sqlgetWinPrice, connection);
                SqlDataReader winPriceInfo = sqlgetWinPriceCom.ExecuteReader();
                while (winPriceInfo.Read())
                {
                    double _price = Convert.ToDouble(winPriceInfo["GroupPrice"]);
                    double _winRate = Convert.ToDouble(winPriceInfo["winRate"]);
                    outWinNumber += _price * _winRate;
                }
                connection.Close();
            }
            return outWinNumber;
        }
        private double getwinPriceFromDB(string CustomerID, int TypeID, string state, List<string> WinNumber)
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
                    case BaseTypeID.door62:
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
                                            WHERE oe.Number = '{0}' AND o.TypeID = {1} AND oe.TypeID = {4} AND c.CustomerID = '{3}'", winNumber, TypeID.ToString(), DBWinRate.up2, CustomerID, _typeID.ToString());
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
                    case BaseTypeID.uptod3:
                        sqlgetWinPrice = string.Format(@"SELECT o.Number, o.Price, ci.{2} AS winRate
                                            FROM ((OrderList o
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE o.Number = '{0}' AND o.TypeID = {1} AND c.CustomerID = '{3}'", winNumber, TypeID.ToString(), DBWinRate.up3, CustomerID);
                        break;
                    case BaseTypeID.up3:
                    case BaseTypeID.group3:
                    case BaseTypeID.door543:
                    case BaseTypeID.tgroup3:
                        sqlgetWinPrice = string.Format(@"SELECT oe.Number, oe.Price, ci.{2} AS winRate
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE oe.Number = '{0}' AND o.TypeID = {1} AND c.CustomerID = '{3}'", winNumber, TypeID.ToString(), DBWinRate.up3, CustomerID);

                        break;
                    case BaseTypeID.uptod2:
                    case BaseTypeID.up2:
                    case BaseTypeID.ht2:
                    case BaseTypeID.hu2:
                        sqlgetWinPrice = string.Format(@"SELECT o.Number, o.Price, ci.{2} AS winRate
                                            FROM ((OrderList o
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE o.Number = '{0}' AND o.TypeID = {1} AND c.CustomerID = '{3}'", winNumber, TypeID.ToString(), DBWinRate.up2, CustomerID);
                        break;
                    case BaseTypeID.door19up2:
                    case BaseTypeID.door62:
                        sqlgetWinPrice = string.Format(@"SELECT oe.Number, oe.Price, ci.{2} AS winRate
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE oe.Number = '{0}' AND o.TypeID = {1} AND c.CustomerID = '{3}'", winNumber, TypeID.ToString(), DBWinRate.up2, CustomerID);
                        break;
                    case BaseTypeID.lowgroup3:
                    case BaseTypeID.low3:
                        sqlgetWinPrice = string.Format(@"SELECT oe.Number, oe.Price, ci.{2} AS winRate
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE oe.Number = '{0}' AND o.TypeID = {1} AND c.CustomerID = '{3}'", winNumber, TypeID.ToString(), DBWinRate.low3, CustomerID);
                        break;
                    case BaseTypeID.low2:
                        sqlgetWinPrice = string.Format(@"SELECT o.Number, o.Price, ci.{2} AS winRate
                                            FROM ((OrderList o
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE o.Number = '{0}' AND o.TypeID = {1} AND c.CustomerID = '{3}'", winNumber, TypeID.ToString(), DBWinRate.low2, CustomerID);

                        break;
                    case BaseTypeID.door19low2:
                        sqlgetWinPrice = string.Format(@"SELECT oe.Number, oe.Price, ci.{2} AS winRate
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE oe.Number = '{0}' AND o.TypeID = {1} AND c.CustomerID = '{3}'", winNumber, TypeID.ToString(), DBWinRate.low2, CustomerID);
                        break;
                    case BaseTypeID.tod5:
                        sqlgetWinPrice = string.Format(@"SELECT o.Number, o.Price, ci.{2} AS winRate
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE oe.Number = '{0}' AND o.TypeID = {1} AND c.CustomerID = '{3}'", winNumber, TypeID.ToString(), DBWinRate.tod5, CustomerID);
                        break;
                    case BaseTypeID.group5:
                        sqlgetWinPrice = string.Format(@"SELECT oe.Number, oe.Price, ci.{2} AS winRate
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE oe.Number = '{0}' AND o.TypeID = {1} AND c.CustomerID = '{3}'", winNumber, TypeID.ToString(), DBWinRate.up3, CustomerID);
                        break;
                    case BaseTypeID.up1:
                        sqlgetWinPrice = string.Format(@"SELECT o.Number, o.Price, ci.{2} AS winRate
                                            FROM ((OrderList o
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE o.Number = '{0}' AND o.TypeID = {1} AND c.CustomerID = '{3}'", winNumber, TypeID.ToString(), DBWinRate.up1, CustomerID);
                        break;
                    case BaseTypeID.low1:
                        sqlgetWinPrice = string.Format(@"SELECT o.Number, o.Price, ci.{2} AS winRate
                                            FROM ((OrderList o
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE o.Number = '{0}' AND o.TypeID = {1} AND c.CustomerID = '{3}'", winNumber, TypeID.ToString(), DBWinRate.low1, CustomerID);
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

            // for 3up
            List<string> winNumber3up = getWinNumber(WinNumberType.up3);

            double payuptod3 = getwinPriceFromDB(CustomerID, BaseTypeID.uptod3, winNumber3up);
            double payup3 = getwinPriceFromDB(CustomerID, BaseTypeID.up3, winNumber3up);
            double paygroup3 = getwinPriceFromDB(CustomerID, BaseTypeID.group3, winNumber3up);
            double paydoor543 = getwinPriceFromDB(CustomerID, BaseTypeID.door543, winNumber3up);
            double paytgroup3 = getwinPriceFromDB(CustomerID, BaseTypeID.tgroup3, winNumber3up);
            double paygroup5 = getwinPriceFromDB(CustomerID, BaseTypeID.group5, winNumber3up);

            outWinList.Add(payuptod3);
            outWinList.Add(payup3);
            outWinList.Add(paygroup3);
            outWinList.Add(paydoor543);
            outWinList.Add(paytgroup3);
            outWinList.Add(paygroup5);

            // for 2up
            // for 2up
            // get winnumber for 2up
            List<string> winNumber2up = getWinNumber(WinNumberType.up2);
            // get winnumber for 2ht
            List<string> winNumber2ht = getWinNumber(WinNumberType.ht2);
            // get winnumber for 2hu
            List<string> winNumber2hu = getWinNumber(WinNumberType.hu2);

            // get winprice
            double payuptod2 = getwinPriceFromDB(CustomerID, BaseTypeID.uptod2, winNumber2up);
            double payup2 = getwinPriceFromDB(CustomerID, BaseTypeID.up2, winNumber2up);
            double payht2 = getwinPriceFromDB(CustomerID, BaseTypeID.ht2, winNumber2ht);
            double payhu2 = getwinPriceFromDB(CustomerID, BaseTypeID.hu2, winNumber2hu);
            double paydoor19up2 = getwinPriceFromDB(CustomerID, BaseTypeID.door19up2, winNumber2up);
            
            // for door6 
            double paydoor62up = getwinPriceFromDB(CustomerID, BaseTypeID.door62, "up", winNumber2up);
            double paydoor62ht = getwinPriceFromDB(CustomerID, BaseTypeID.door62, "ht", winNumber2ht);
            double paydoor62hu = getwinPriceFromDB(CustomerID, BaseTypeID.door62, "hu", winNumber2hu);

            outWinList.Add(payuptod2);
            outWinList.Add(payup2);
            outWinList.Add(payht2);
            outWinList.Add(payhu2);
            outWinList.Add(paydoor19up2);
            outWinList.Add(paydoor62up);
            outWinList.Add(paydoor62ht);
            outWinList.Add(paydoor62hu);

            // for 2low
            // get winnumber
            List<string> winNumber2low = getWinNumber(WinNumberType.low2);
            // get winprice
            double paylow2 = getwinPriceFromDB(CustomerID, BaseTypeID.low2, winNumber2low);
            double paydoor19low2 = getwinPriceFromDB(CustomerID, BaseTypeID.door19low2, winNumber2low);

            outWinList.Add(paylow2);
            outWinList.Add(paydoor19low2);

            // for 3tod
            double payTuptod3 = getwinGPriceFromDB(CustomerID, BaseTypeID.uptod3, winNumber3up);
            double paytod3 = getwinGPriceFromDB(CustomerID, BaseTypeID.tod3, winNumber3up);

            outWinList.Add(payTuptod3);
            outWinList.Add(paytod3);

            // for 2tod
            // for 2tod
            // get winprice
            double payuptod2up = getwinGPriceFromDB(CustomerID, BaseTypeID.uptod2, "up", winNumber2up);
            double payuptod2ht = getwinGPriceFromDB(CustomerID, BaseTypeID.uptod2, "ht", winNumber2ht);
            double payuptod2hu = getwinGPriceFromDB(CustomerID, BaseTypeID.uptod2, "hu", winNumber2hu);

            double paytod2up = getwinGPriceFromDB(CustomerID, BaseTypeID.tod2, "up", winNumber2up);
            double paytod2ht = getwinGPriceFromDB(CustomerID, BaseTypeID.tod2, "ht", winNumber2ht);
            double paytod2hu = getwinGPriceFromDB(CustomerID, BaseTypeID.tod2, "hu", winNumber2hu);

            if(payuptod2up != 0)
            {
                outWinList.Add(payuptod2up);
            }
            else if(payuptod2ht != 0)
            {
                outWinList.Add(payuptod2ht);
            }
            else if(payuptod2hu != 0)
            {
                outWinList.Add(payuptod2hu);
            }

            if(paytod2up != 0)
            {
                outWinList.Add(paytod2up);
            }
            else if(paytod2ht != 0)
            {
                outWinList.Add(paytod2ht);
            }
            else if(paytod2hu != 0)
            {
                outWinList.Add(paytod2hu);
            }


            // for 5tod
            // get winnumber
            // get winprice
            double paytod5 = getwinPriceFromDB(CustomerID, BaseTypeID.tod5, winNumber3up);
            outWinList.Add(paytod5);

            // for 1freeup
            List<string> winNumber1up = getWinNumber(WinNumberType.up1);
            // get winprice
            double payup1 = getwinPriceFromDB(CustomerID, BaseTypeID.up1, winNumber1up);

            outWinList.Add(payup1);

            // for 1low
            // get winnumber
            List<string> winNumber1low = getWinNumber(WinNumberType.low1);
            // get winprice
            double paylow1 = getwinPriceFromDB(CustomerID, BaseTypeID.low1, winNumber1low);

            outWinList.Add(paylow1);

            // for 3low
            // get winnumber
            List<string> winNumber3low = getWinNumber(WinNumberType.low3);
            // get winprice
            double paylow3 = getwinPriceFromDB(CustomerID, BaseTypeID.low3, winNumber3low);
            double paylowgroup3 = getwinPriceFromDB(CustomerID, BaseTypeID.lowgroup3, winNumber3low);


            outWinList.Add(paylow3);
            outWinList.Add(paylowgroup3);

            // for 1front
            // for 1front
            // get winnumber
            List<string> winNumber1front = getWinNumber(WinNumberType.upfront1);
            // get winprice
            double payupfront1 = getwinPriceFromDB(CustomerID, BaseTypeID.upfront1, winNumber1front);

            outWinList.Add(payupfront1);

            // for 1center
            // get winnumber
            List<string> winNumber1center = getWinNumber(WinNumberType.upcenter1);
            // get winprice
            double payupcenter1 = getwinPriceFromDB(CustomerID, BaseTypeID.upcenter1, winNumber1center);

            outWinList.Add(payupcenter1);

            // for 1back
            // get winnumber
            List<string> winNumber1back = getWinNumber(WinNumberType.upback1);
            // get winprice
            double payupback1 = getwinPriceFromDB(CustomerID, BaseTypeID.upback1, winNumber1back);

            outWinList.Add(payupback1);

            // for 1lowfront
            // get winnumber
            List<string> winNumber1lowfront = getWinNumber(WinNumberType.lowfront1);
            // get winprice
            double paylowfront1 = getwinPriceFromDB(CustomerID, BaseTypeID.lowfront1, winNumber1lowfront);

            outWinList.Add(paylowfront1);

            // for 1lowback
            // get winnumber
            List<string> winNumber1lowback = getWinNumber(WinNumberType.lowback1);
            // get winprice
            double paylowback1 = getwinPriceFromDB(CustomerID, BaseTypeID.lowback1, winNumber1lowback);

            outWinList.Add(paylowback1);

            return outWinList.Sum();
        }


    }
}
