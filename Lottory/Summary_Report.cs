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
using Microsoft.Reporting.WinForms;

namespace Lottory
{
    public partial class Summary_Report : Form
    {
        private static Summary_Report _instance;
        public static Summary_Report Instance 
        {
            get
            {
                if (_instance == null)
                    _instance = new Summary_Report();
                return _instance;
            }
        }
        private void Summary_Report_FormClosed(object sender, FormClosedEventArgs e)
        {
            _instance = null;
        }
        public Summary_Report()
        {
            InitializeComponent();
        }

        private void Summary_Report_Load(object sender, EventArgs e)
        {
            SummaryInfo summaryInfo = new SummaryInfo();
            // Price
            int _price3up = getPriceFromDB(BaseTypeID.up3);
            int _price3low = getPriceFromDB(BaseTypeID.low3);
            int _price2up = getPriceFromDB(BaseTypeID.up2);
            int _price2low = getPriceFromDB(BaseTypeID.low2);
            int _price2ht = getPriceFromDB(BaseTypeID.ht2);
            int _price2hu = getPriceFromDB(BaseTypeID.hu2);
            int _price1up = getPriceFromDB(BaseTypeID.up1);
            int _price1low = getPriceFromDB(BaseTypeID.low1);
            int _price1front = getPriceFromDB(BaseTypeID.upfront1);
            int _price1center = getPriceFromDB(BaseTypeID.upcenter1);
            int _price1back = getPriceFromDB(BaseTypeID.upback1);
            int _price1lowfront = getPriceFromDB(BaseTypeID.lowfront1);
            int _price1lowback = getPriceFromDB(BaseTypeID.lowback1);

            summaryInfo.Priceup3 = _price3up.ToString("N0");
            summaryInfo.Pricelow3 = _price3low.ToString("N0");
            summaryInfo.Priceup2 = _price2up.ToString("N0");
            summaryInfo.Pricelow2 = _price2low.ToString("N0");
            summaryInfo.Priceht2 = _price2ht.ToString("N0");
            summaryInfo.Pricehu2 = _price2hu.ToString("N0");
            summaryInfo.Priceup1 = _price1up.ToString("N0");
            summaryInfo.Pricelow1 = _price1low.ToString("N0");
            summaryInfo.Pricefront1 = _price1front.ToString("N0");
            summaryInfo.Pricecenter1 = _price1center.ToString("N0");
            summaryInfo.Priceback1 = _price1back.ToString("N0");
            summaryInfo.Pricelowfront1 = _price1lowfront.ToString("N0");
            summaryInfo.Pricelowback1 = _price1lowback.ToString("N0");

            List<int> PriceList = new List<int>();
            PriceList.Add(_price3up);
            PriceList.Add(_price3low);
            PriceList.Add(_price2up);
            PriceList.Add(_price2low);
            PriceList.Add(_price2ht);
            PriceList.Add(_price2hu);
            PriceList.Add(_price1up);
            PriceList.Add(_price1low);
            PriceList.Add(_price1front);
            PriceList.Add(_price1center);
            PriceList.Add(_price1back);
            PriceList.Add(_price1lowfront);
            PriceList.Add(_price1lowback);
            summaryInfo.sumPrice = PriceList.Sum().ToString("N0");

            // Discount
            int _Disc3up = getDiscountFromDB(BaseTypeID.up3);
            int _Disc3low = getDiscountFromDB(BaseTypeID.low3);
            int _Disc2up = getDiscountFromDB(BaseTypeID.up2);
            int _Disc2low = getDiscountFromDB(BaseTypeID.low2);
            int _Disc2ht = getDiscountFromDB(BaseTypeID.ht2);
            int _Disc2hu = getDiscountFromDB(BaseTypeID.hu2);
            int _Disc1up = getDiscountFromDB(BaseTypeID.up1);
            int _Disc1low = getDiscountFromDB(BaseTypeID.low1);
            int _Disc1front = getDiscountFromDB(BaseTypeID.upfront1);
            int _Disc1center = getDiscountFromDB(BaseTypeID.upcenter1);
            int _Disc1back = getDiscountFromDB(BaseTypeID.upback1);
            int _Disc1lowfront = getDiscountFromDB(BaseTypeID.lowfront1);
            int _Disc1lowback = getDiscountFromDB(BaseTypeID.lowback1);

            summaryInfo.Discountup3 = _Disc3up.ToString("N0");
            summaryInfo.Discountlow3 = _Disc3low.ToString("N0");
            summaryInfo.Discountup2 = _Disc2up.ToString("N0");
            summaryInfo.Discountlow2 = _Disc2low.ToString("N0");
            summaryInfo.Discountht2 = _Disc2ht.ToString("N0");
            summaryInfo.Discounthu2 = _Disc2hu.ToString("N0");
            summaryInfo.Discountup1 = _Disc1up.ToString("N0");
            summaryInfo.Discountlow1 = _Disc1low.ToString("N0");
            summaryInfo.Discountfront1 = _Disc1front.ToString("N0");
            summaryInfo.Discountcenter1 = _Disc1center.ToString("N0");
            summaryInfo.Discountback1 = _Disc1back.ToString("N0");
            summaryInfo.Discountlowfront1 = _Disc1lowfront.ToString("N0");
            summaryInfo.Discountlowback1 = _Disc1lowback.ToString("N0");

            List<int> DiscList = new List<int>();
            DiscList.Add(_Disc3up);
            DiscList.Add(_Disc3low);
            DiscList.Add(_Disc2up);
            DiscList.Add(_Disc2low);
            DiscList.Add(_Disc2ht);
            DiscList.Add(_Disc2hu);
            DiscList.Add(_Disc1up);
            DiscList.Add(_Disc1low);
            DiscList.Add(_Disc1front);
            DiscList.Add(_Disc1center);
            DiscList.Add(_Disc1back);
            DiscList.Add(_Disc1lowfront);
            DiscList.Add(_Disc1lowback);
            summaryInfo.sumDiscount = DiscList.Sum().ToString("N0");

            // Win
            double _win3up = getWinPrice(BaseTypeID.up3);
            double _win3low = getWinPrice(BaseTypeID.low3);
            double _win2up = getWinPrice(BaseTypeID.up2);
            double _win2low = getWinPrice(BaseTypeID.low2);
            double _win2ht = getWinPrice(BaseTypeID.ht2);
            double _win2hu = getWinPrice(BaseTypeID.hu2);
            double _win1up = getWinPrice(BaseTypeID.up1);
            double _win1low = getWinPrice(BaseTypeID.low1);
            double _win1front = getWinPrice(BaseTypeID.upfront1);
            double _win1center = getWinPrice(BaseTypeID.upcenter1);
            double _win1back = getWinPrice(BaseTypeID.upback1);
            double _win1lowfront = getWinPrice(BaseTypeID.lowfront1);
            double _win1lowback = getWinPrice(BaseTypeID.lowback1);
            summaryInfo.WinPriceup3 = _win3up.ToString("N0");
            summaryInfo.WinPricelow3 = _win3low.ToString("N0");
            summaryInfo.WinPriceup2 = _win2up.ToString("N0");
            summaryInfo.WinPricelow2 = _win2low.ToString("N0");
            summaryInfo.WinPriceht2 = _win2ht.ToString("N0");
            summaryInfo.WinPricehu2 = _win2hu.ToString("N0");
            summaryInfo.WinPriceup1 = _win1up.ToString("N0");
            summaryInfo.WinPricelow1 = _win1low.ToString("N0");
            summaryInfo.WinPricefront1 = _win1front.ToString("N0");
            summaryInfo.WinPricecenter1 = _win1center.ToString("N0");
            summaryInfo.WinPriceback1 = _win1back.ToString("N0");
            summaryInfo.WinPricelowfront1 = _win1lowfront.ToString("N0");
            summaryInfo.WinPricelowback1 = _win1lowback.ToString("N0");

            List<double> winList = new List<double>();
            winList.Add(_win3up);
            winList.Add(_win3low);
            winList.Add(_win2up);
            winList.Add(_win2low);
            winList.Add(_win2ht);
            winList.Add(_win2hu);
            winList.Add(_win1up);
            winList.Add(_win1low);
            winList.Add(_win1front);
            winList.Add(_win1center);
            winList.Add(_win1back);
            winList.Add(_win1lowfront);
            winList.Add(_win1lowback);
            summaryInfo.sumWinPrice = winList.Sum().ToString("N0");

            //Net
            summaryInfo.netPriceup3 = (Convert.ToDouble(_price3up) - (Convert.ToDouble(_Disc3up) + _win3up)).ToString("N0");
            summaryInfo.netPricelow3 = (Convert.ToDouble(_price3low) - (Convert.ToDouble(_Disc3low) + _win3low)).ToString("N0");
            summaryInfo.netPriceup2 = (Convert.ToDouble(_price2up) - (Convert.ToDouble(_Disc2up) + _win2up)).ToString("N0");
            summaryInfo.netPricelow2 = (Convert.ToDouble(_price2low) - (Convert.ToDouble(_Disc2low) + _win2low)).ToString("N0");
            summaryInfo.netPriceht2 = (Convert.ToDouble(_price2ht) - (Convert.ToDouble(_Disc2ht) + _win2ht)).ToString("N0");
            summaryInfo.netPricehu2 = (Convert.ToDouble(_price2hu) - (Convert.ToDouble(_Disc2hu) + _win2hu)).ToString("N0");
            summaryInfo.netPriceup1 = (Convert.ToDouble(_price1up) - (Convert.ToDouble(_Disc1up) + _win1up)).ToString("N0");
            summaryInfo.netPricelow1 = (Convert.ToDouble(_price1low) - (Convert.ToDouble(_Disc1low) + _win1low)).ToString("N0");
            summaryInfo.netPricefront1 = (Convert.ToDouble(_price1front) - (Convert.ToDouble(_Disc1front) + _win1front)).ToString("N0");
            summaryInfo.netPricecenter1 = (Convert.ToDouble(_price1center) - (Convert.ToDouble(_Disc1center) + _win1center)).ToString("N0");
            summaryInfo.netPriceback1 = (Convert.ToDouble(_price1back) - (Convert.ToDouble(_Disc1back) + _win1back)).ToString("N0");
            summaryInfo.netPricelowfront1 = (Convert.ToDouble(_price1lowfront) - (Convert.ToDouble(_Disc1lowfront) + _win1lowfront)).ToString("N0");
            summaryInfo.netPricelowback1 = (Convert.ToDouble(_price1lowback) - (Convert.ToDouble(_Disc1lowback) + _win1lowback)).ToString("N0");
            summaryInfo.sumNetPrice = (Convert.ToDouble(PriceList.Sum()) - (Convert.ToDouble(DiscList.Sum()) + winList.Sum())).ToString("N0");

            SummaryInfoBindingSource.DataSource = summaryInfo;
            this.reportViewer1.RefreshReport();
        }
        private int getPriceFromDB(int TypeID)
        {
            int outPrice = 0;
            SqlConnection connection = new SqlConnection(Database.CnnVal("LottoryDB"));
            if(connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            string sqlgetPrice;
            switch(TypeID)
            {
                case BaseTypeID.up3:
                    sqlgetPrice = string.Format("SELECT SUM(OwnPrice - OutPrice) AS Price FROM {0}",DBNumber.up3);
                    break;
                case BaseTypeID.low3:
                    sqlgetPrice = string.Format("SELECT SUM(OwnPrice - OutPrice) AS Price FROM {0}", DBNumber.low3);
                    break;
                case BaseTypeID.up2:
                    sqlgetPrice = string.Format("SELECT SUM(OwnPrice - OutPrice) AS Price FROM {0}", DBNumber.up2);
                    break;
                case BaseTypeID.low2:
                    sqlgetPrice = string.Format("SELECT SUM(OwnPrice - OutPrice) AS Price FROM {0}", DBNumber.low2);
                    break;
                case BaseTypeID.up1:
                    sqlgetPrice = string.Format("SELECT SUM(OwnPrice - OutPrice) AS Price FROM {0}", DBNumber.up1);
                    break;
                case BaseTypeID.low1:
                    sqlgetPrice = string.Format("SELECT SUM(OwnPrice - OutPrice) AS Price FROM {0}", DBNumber.low1);
                    break;
                default:
                    sqlgetPrice = string.Format(@"SELECT ISNULL(SUM(OwnPrice),0) AS Price FROM OrderListExpand
                                                  WHERE TypeID = {0}", TypeID);

                    break;
            }
            SqlCommand sqlgetPriceCom = new SqlCommand(sqlgetPrice, connection);
            SqlDataReader PriceInfo = sqlgetPriceCom.ExecuteReader();
            while(PriceInfo.Read())
            {
                outPrice = Convert.ToInt32(PriceInfo["Price"]);
            }
            connection.Close();
            return outPrice;
        }
        private int getDiscountFromDB(int TypeID)
        {
            int outDiscount = 0;
            SqlConnection connection = new SqlConnection(Database.CnnVal("LottoryDB"));
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            string sqlgetDiscount = string.Format(@"SELECT ISNULL(SUM(DiscPrice),0) AS Discount
                                                    FROM OrderListExpand
                                                    WHERE TypeID = {0}",TypeID);

            SqlCommand sqlgetDiscountCom = new SqlCommand(sqlgetDiscount, connection);
            SqlDataReader DiscountInfo = sqlgetDiscountCom.ExecuteReader();
            while (DiscountInfo.Read())
            {
                outDiscount = Convert.ToInt32(DiscountInfo["Discount"]);
            }
            connection.Close();
            return outDiscount;
        }
        private double getWinPrice(int TypeID)
        {
            double outWin = 0;
            switch(TypeID)
            {
                case BaseTypeID.up3:
                    List<string> winNumber3up = getWinNumber(WinNumberType.up3);
                    outWin = getwinPriceFromDB(TypeID, winNumber3up);
                    break;
                case BaseTypeID.low3:
                    List<string> winNumber3low = getWinNumber(WinNumberType.low3);
                    outWin = getwinPriceFromDB(TypeID, winNumber3low);
                    break;
                case BaseTypeID.up2:
                    List<string> winNumber2up = getWinNumber(WinNumberType.up2);
                    outWin = getwinPriceFromDB(TypeID, winNumber2up);
                    break;
                case BaseTypeID.low2:
                    List<string> winNumber2low = getWinNumber(WinNumberType.low2);
                    outWin = getwinPriceFromDB(TypeID, winNumber2low);
                    break;
                case BaseTypeID.ht2:
                    List<string> winNumber2ht = getWinNumber(WinNumberType.ht2);
                    outWin = getwinPriceFromDB(TypeID, winNumber2ht);
                    break;
                case BaseTypeID.hu2:
                    List<string> winNumber2hu = getWinNumber(WinNumberType.hu2);
                    outWin = getwinPriceFromDB(TypeID, winNumber2hu);
                    break;
                case BaseTypeID.up1:
                    List<string> winNumber1up = getWinNumber(WinNumberType.up1);
                    outWin = getwinPriceFromDB(TypeID, winNumber1up);
                    break;
                case BaseTypeID.low1:
                    List<string> winNumber1low = getWinNumber(WinNumberType.low1);
                    outWin = getwinPriceFromDB(TypeID, winNumber1low);
                    break;
                case BaseTypeID.upfront1:
                    List<string> winNumber1front = getWinNumber(WinNumberType.upfront1);
                    outWin = getwinPriceFromDB(TypeID, winNumber1front);
                    break;
                case BaseTypeID.upcenter1:
                    List<string> winNumber1center = getWinNumber(WinNumberType.upcenter1);
                    outWin = getwinPriceFromDB(TypeID, winNumber1center);
                    break;
                case BaseTypeID.upback1:
                    List<string> winNumber1back = getWinNumber(WinNumberType.upback1);
                    outWin = getwinPriceFromDB(TypeID, winNumber1back);
                    break;
                case BaseTypeID.lowfront1:
                    List<string> winNumber1lowfront = getWinNumber(WinNumberType.lowfront1);
                    outWin = getwinPriceFromDB(TypeID, winNumber1lowfront);
                    break;
                case BaseTypeID.lowback1:
                    List<string> winNumber1lowback = getWinNumber(WinNumberType.lowback1);
                    outWin = getwinPriceFromDB(TypeID, winNumber1lowback);
                    break;
            }
            return outWin;
        }
        private double getwinPriceFromDB(int TypeID,List<string> WinNumber)
        {
            double outWinNumber = 0;
            string sqlgetWinPrice = string.Empty;
            foreach(string winNumber in WinNumber)
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
                                            WHERE oe.Number = '{0}' AND oe.TypeID = {1}", winNumber, TypeID.ToString(), DBWinRate.up3);
                    break;
                    case BaseTypeID.low3:
                        sqlgetWinPrice = string.Format(@"SELECT oe.Number, oe.Price, ci.{2} AS winRate
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE oe.Number = '{0}' AND oe.TypeID = {1}", winNumber, TypeID.ToString(), DBWinRate.low3);
                        break;
                    case BaseTypeID.up2:
                    case BaseTypeID.ht2:
                    case BaseTypeID.hu2:
                        sqlgetWinPrice = string.Format(@"SELECT oe.Number, oe.Price, ci.{2} AS winRate
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE oe.Number = '{0}' AND oe.TypeID = {1}", winNumber, TypeID.ToString(), DBWinRate.up2);
                        break;
                    case BaseTypeID.low2:
                        sqlgetWinPrice = string.Format(@"SELECT oe.Number, oe.Price, ci.{2} AS winRate
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE oe.Number = '{0}' AND oe.TypeID = {1}", winNumber, TypeID.ToString(), DBWinRate.low2);
                        break;
                    case BaseTypeID.up1:
                        sqlgetWinPrice = string.Format(@"SELECT oe.Number, oe.Price, ci.{2} AS winRate
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE oe.Number = '{0}' AND oe.TypeID = {1}", winNumber, TypeID.ToString(), DBWinRate.up1);
                        break;
                    case BaseTypeID.low1:
                        sqlgetWinPrice = string.Format(@"SELECT oe.Number, oe.Price, ci.{2} AS winRate
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE oe.Number = '{0}' AND oe.TypeID = {1}", winNumber, TypeID.ToString(), DBWinRate.low1);
                        break;
                    case BaseTypeID.upfront1:
                        sqlgetWinPrice = string.Format(@"SELECT oe.Number, oe.Price, ci.{2} AS winRate
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE oe.Number = '{0}' AND oe.TypeID = {1}", winNumber, TypeID.ToString(), DBWinRate.upfront1);
                        break;
                    case BaseTypeID.upback1:
                        sqlgetWinPrice = string.Format(@"SELECT oe.Number, oe.Price, ci.{2} AS winRate
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE oe.Number = '{0}' AND oe.TypeID = {1}", winNumber, TypeID.ToString(), DBWinRate.upback1);
                        break;
                    case BaseTypeID.upcenter1:
                        sqlgetWinPrice = string.Format(@"SELECT oe.Number, oe.Price, ci.{2} AS winRate
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE oe.Number = '{0}' AND oe.TypeID = {1}", winNumber, TypeID.ToString(), DBWinRate.upcenter1);
                        break;
                    case BaseTypeID.lowfront1:
                        sqlgetWinPrice = string.Format(@"SELECT oe.Number, oe.Price, ci.{2} AS winRate
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE oe.Number = '{0}' AND oe.TypeID = {1}", winNumber, TypeID.ToString(), DBWinRate.upfront1);
                        break;
                    case BaseTypeID.lowback1:
                        sqlgetWinPrice = string.Format(@"SELECT oe.Number, oe.Price, ci.{2} AS winRate
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON ci.CustomerID = c.CustomerID)
                                            WHERE oe.Number = '{0}' AND oe.TypeID = {1}", winNumber, TypeID.ToString(), DBWinRate.upback1);
                        break;
                    
                }
                SqlCommand sqlgetWinPriceCom = new SqlCommand(sqlgetWinPrice, connection);
                SqlDataReader winPriceInfo = sqlgetWinPriceCom.ExecuteReader();
                while(winPriceInfo.Read())
                {
                    double _price = Convert.ToDouble(winPriceInfo["Price"]);
                    double _winRate = Convert.ToDouble(winPriceInfo["winRate"]);
                    outWinNumber += _price * _winRate;
                }
                connection.Close();
            }
            return outWinNumber;
            
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
