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
        private int getGroupFromDB(int TypeID)
        {
            int outPrice = 0;
            SqlConnection connection = new SqlConnection(Database.CnnVal("LottoryDB"));
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            string sqlgetGPrice = string.Empty;

            switch (TypeID)
            {
                case BaseTypeID.uptod3:
                case BaseTypeID.uptod2:
                    sqlgetGPrice = string.Format(@"SELECT ISNULL(SUM(GroupPrice),0) AS Price
                                                   FROM OrderList o
                                                   WHERE o.TypeID = {0}", TypeID.ToString());
                    break;
                case BaseTypeID.tod3:
                case BaseTypeID.tod2:
                    sqlgetGPrice = string.Format(@"SELECT ISNULL(SUM(OwnPrice),0) AS Price
                                            FROM OrderList o
                                            INNER JOIN OrderListExpand oe ON o.OrderListID = oe.OrderListID
                                            WHERE o.TypeID = {0}", TypeID.ToString());
                    break;

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
        private double getDiscountFromDB(int TypeID)
        {
            double outDisc = 0;
            SqlConnection connection = new SqlConnection(Database.CnnVal("LottoryDB"));
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            string sqlgetDiscount = string.Empty;
            switch (TypeID)
            {
                case BaseTypeID.uptod3:
                case BaseTypeID.uptod2:
                    sqlgetDiscount = string.Format(@"SELECT ISNULL(SUM(oe.DiscPrice),0) AS DiscPrice
                                                        FROM OrderList o
                                                        INNER JOIN OrderListExpand oe ON o.OrderListID = oe.OrderListID
                                                        WHERE o.TypeID = {0} AND (o.Number = oe.Number) AND (o.Price = oe.Price)", TypeID.ToString());
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
                                                        FROM OrderList o
                                                        INNER JOIN OrderListExpand oe ON o.OrderListID = oe.OrderListID
                                                        WHERE o.TypeID = {0}", TypeID.ToString());
                    break;

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
        private double getGDiscountFromDB(int TypeID)
        {
            double outDisc = 0;
            SqlConnection connection = new SqlConnection(Database.CnnVal("LottoryDB"));
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            string sqlgetDiscount = string.Empty;
            switch (TypeID)
            {
                case BaseTypeID.uptod3:
                case BaseTypeID.uptod2:
                    sqlgetDiscount = string.Format(@"SELECT ISNULL(SUM(oe.DiscPrice),0) AS DiscPrice
                                                        FROM (CustomerOrder c INNER JOIN OrderList o ON c.OrderID = o.OrderID)
                                                        INNER JOIN OrderListExpand oe ON o.OrderListID = oe.OrderListID
                                                        WHERE o.TypeID = {0} AND (o.Price <> oe.Price)", TypeID.ToString());
                    break;
                case BaseTypeID.tod3:
                case BaseTypeID.tod2:
                    sqlgetDiscount = string.Format(@"SELECT ISNULL(SUM(oe.DiscPrice),0) AS DiscPrice
                                                        FROM (CustomerOrder c INNER JOIN OrderList o ON c.OrderID = o.OrderID)
                                                        INNER JOIN OrderListExpand oe ON o.OrderListID = oe.OrderListID
                                                        WHERE o.TypeID = {0}", TypeID.ToString());
                    break;

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
        private void Summary_Report_Load(object sender, EventArgs e)
        {
            DataTable summaryInfo = new DataTable();
            summaryInfo.Columns.Add("Type");
            summaryInfo.Columns.Add("Price");
            summaryInfo.Columns.Add("Discount");
            summaryInfo.Columns.Add("WinPrice");
            summaryInfo.Columns.Add("NetPrice");

            // Price
            
            // for 3up
            double _p3uptod = getPriceFromDB(BaseTypeID.uptod3);
            double _p3up = getPriceFromDB(BaseTypeID.up3);
            double _p3door54 = getPriceFromDB(BaseTypeID.door543);
            double _p3group = getPriceFromDB(BaseTypeID.group3);
            double _ptGroup = getPriceFromDB(BaseTypeID.tgroup3);
            double _p4group = getPriceFromDB(BaseTypeID.group4);
            double _p5group = getPriceFromDB(BaseTypeID.group5);
            // Sum Price 3up
            List<double> PriceList3up = new List<double>();
            PriceList3up.Add(_p3uptod);
            PriceList3up.Add(_p3up);
            PriceList3up.Add(_p3door54);
            PriceList3up.Add(_p3group);
            PriceList3up.Add(_ptGroup);
            PriceList3up.Add(_p4group);
            PriceList3up.Add(_p5group);

            // for 2up
            double _p2up = getPriceFromDB(BaseTypeID.up2);
            double _p2uptod = getPriceFromDB(BaseTypeID.uptod2);
            double _p2door6 = getPriceFromDB(BaseTypeID.door62);
            double _p2updoor19 = getPriceFromDB(BaseTypeID.door19up2);
            double _p2ht = getPriceFromDB(BaseTypeID.ht2);
            double _p2hu = getPriceFromDB(BaseTypeID.hu2);
            // Sum Price 2up
            List<double> PriceList2up = new List<double>();
            PriceList2up.Add(_p2up);
            PriceList2up.Add(_p2uptod);
            PriceList2up.Add(_p2door6);
            PriceList2up.Add(_p2updoor19);
            PriceList2up.Add(_p2ht);
            PriceList2up.Add(_p2hu);

            // for 2low
            double _p2low = getPriceFromDB(BaseTypeID.low2);
            double _p2lowdoor19 = getPriceFromDB(BaseTypeID.door19low2);
            // Sum Price 2low
            List<double> PriceList2low = new List<double>();
            PriceList2low.Add(_p2low);
            PriceList2low.Add(_p2lowdoor19);

            // for 3tod
            double _p3Tuptod = getGroupFromDB(BaseTypeID.uptod3);
            double _p3tod = getGroupFromDB(BaseTypeID.tod3);
            // sum Price 3tod
            List<double> PriceList3tod = new List<double>();
            PriceList3tod.Add(_p3Tuptod);
            PriceList3tod.Add(_p3tod);

            // for 2tod
            double _p2Tuptod = getGroupFromDB(BaseTypeID.uptod2);
            double _p2tod = getGroupFromDB(BaseTypeID.tod2);
            // sum Price 2tod
            List<double> PriceList2tod = new List<double>();
            PriceList2tod.Add(_p2Tuptod);
            PriceList2tod.Add(_p2tod);

            // for 1free up
            double _p1up = getPriceFromDB(BaseTypeID.up1);
            // sum Price 1up
            List<double> PriceList1up = new List<double>();
            PriceList1up.Add(_p1up);

            // for 1,front,center,back up and low
            double _p1upfront = getPriceFromDB(BaseTypeID.upfront1);
            double _p1upcenter = getPriceFromDB(BaseTypeID.upcenter1);
            double _p1upback = getPriceFromDB(BaseTypeID.upback1);
            double _p1lowfront = getPriceFromDB(BaseTypeID.lowfront1);
            double _p1lowback = getPriceFromDB(BaseTypeID.lowback1);
            // sum Price up,low 
            List<double> PriceList1puk = new List<double>();
            PriceList1puk.Add(_p1upfront);
            PriceList1puk.Add(_p1upcenter);
            PriceList1puk.Add(_p1upback);
            PriceList1puk.Add(_p1lowfront);
            PriceList1puk.Add(_p1lowback);

            // for 1free low
            double _p1low = getPriceFromDB(BaseTypeID.low1);
            //  sum Price 1low
            List<double> PriceList1low = new List<double>();
            PriceList1low.Add(_p1low);

            // for 5tod
            double _p5tod = getPriceFromDB(BaseTypeID.tod5);
            // sum Price 5tod
            List<double> PriceList5tod = new List<double>();
            PriceList5tod.Add(_p5tod);

            // for 3low
            double _p3low = getPriceFromDB(BaseTypeID.low3);
            double _pGroupLow = getPriceFromDB(BaseTypeID.lowgroup3);
            // sum Price 3low
            List<double> PriceList3low = new List<double>();
            PriceList3low.Add(_p3low);
            PriceList3low.Add(_pGroupLow);

            // Discount 
            // for 3up
            double _d3uptod = getDiscountFromDB(BaseTypeID.uptod3);
            double _d3up = getDiscountFromDB(BaseTypeID.up3);
            double _d3door54 = getDiscountFromDB(BaseTypeID.door543);
            double _d3group = getDiscountFromDB(BaseTypeID.group3);
            double _dtGroup = getDiscountFromDB(BaseTypeID.tgroup3);
            double _d4group = getDiscountFromDB(BaseTypeID.group4);
            double _d5group = getDiscountFromDB(BaseTypeID.group5);
            // Sum Discount for 3up
            List<double> DiscList3up = new List<double>();
            DiscList3up.Add(_d3uptod);
            DiscList3up.Add(_d3up);
            DiscList3up.Add(_d3door54);
            DiscList3up.Add(_d3group);
            DiscList3up.Add(_dtGroup);
            DiscList3up.Add(_d4group);
            DiscList3up.Add(_d5group);

            // for 2up
            double _d2up = getDiscountFromDB(BaseTypeID.up2);
            double _d2uptod = getDiscountFromDB(BaseTypeID.uptod2);
            double _d2door6 = getDiscountFromDB(BaseTypeID.door62);
            double _d2updoor19 = getDiscountFromDB(BaseTypeID.door19up2);
            double _d2ht = getDiscountFromDB(BaseTypeID.ht2);
            double _d2hu = getDiscountFromDB(BaseTypeID.hu2);
            // sum Discount 2up
            List<double> DiscList2up = new List<double>();
            DiscList2up.Add(_d2up);
            DiscList2up.Add(_d2uptod);
            DiscList2up.Add(_d2door6);
            DiscList2up.Add(_d2updoor19);
            DiscList2up.Add(_d2ht);
            DiscList2up.Add(_d2hu);

            // for 2low
            double _d2low = getDiscountFromDB(BaseTypeID.low2);
            double _d2lowdoor19 = getDiscountFromDB(BaseTypeID.door19low2);
            // sum Discount 2low
            List<double> DiscList2low = new List<double>();
            DiscList2low.Add(_d2low);
            DiscList2low.Add(_d2lowdoor19);

            // for 3tod
            double _d3Tuptod = getGDiscountFromDB(BaseTypeID.uptod3);
            double _d3tod = getGDiscountFromDB(BaseTypeID.tod3);
            
            // sum Discount 3tod
            List<double> DiscList3tod = new List<double>();
            DiscList3tod.Add(_d3Tuptod);
            DiscList3tod.Add(_d3tod);

            // for 2tod
            double _d2Tuptod = getGDiscountFromDB(BaseTypeID.uptod2);
            double _d2tod = getGDiscountFromDB(BaseTypeID.tod2);
            // sum Discount 2tod
            List<double> DiscList2tod = new List<double>();
            DiscList2tod.Add(_d2Tuptod);
            DiscList2tod.Add(_d2tod);

            // for 1freeup
            double _d1up = getDiscountFromDB(BaseTypeID.up1);
            // sum Discount 1up
            List<double> DiscList1up = new List<double>();
            DiscList1up.Add(_d1up);

            // for 1puk
            double _d1upfront = getDiscountFromDB(BaseTypeID.upfront1);
            double _d1upcenter = getDiscountFromDB(BaseTypeID.upcenter1);
            double _d1upback = getDiscountFromDB(BaseTypeID.upback1);
            double _d1lowfront = getDiscountFromDB(BaseTypeID.lowfront1);
            double _d1lowback = getDiscountFromDB(BaseTypeID.lowback1);
            // sum Discount 1puk
            List<double> DiscList1puk = new List<double>();
            DiscList1puk.Add(_d1upfront);
            DiscList1puk.Add(_d1upcenter);
            DiscList1puk.Add(_d1upback);
            DiscList1puk.Add(_d1lowfront);
            DiscList1puk.Add(_d1lowback);

            // for 1low
            double _d1low = getDiscountFromDB(BaseTypeID.low1);
            // sum Discount 1low
            List<double> DiscList1low = new List<double>();
            DiscList1low.Add(_d1low);

            // for 5tod
            double _d5tod = getDiscountFromDB(BaseTypeID.tod5);
            // sum Discount 5tod
            List<double> DiscList5tod = new List<double>();
            DiscList5tod.Add(_d5tod);

            // for 3low
            double _d3low = getDiscountFromDB(BaseTypeID.low3);
            double _dGroupLow = getDiscountFromDB(BaseTypeID.lowgroup3);
            // sum Discount 3low
            List<double> DiscList3low = new List<double>();
            DiscList3low.Add(_d3low);
            DiscList3low.Add(_dGroupLow);

            //WinPrice
            // for 3up
            List<string> winNumber3up = getWinNumber(WinNumberType.up3);

            double payuptod3 = getwinPriceFromDB(BaseTypeID.uptod3, winNumber3up);
            double payup3 = getwinPriceFromDB(BaseTypeID.up3, winNumber3up);
            double paygroup3 = getwinPriceFromDB(BaseTypeID.group3, winNumber3up);
            double paydoor543 = getwinPriceFromDB(BaseTypeID.door543, winNumber3up);
            double paytgroup3 = getwinPriceFromDB(BaseTypeID.tgroup3, winNumber3up);
            double paygroup5 = getwinPriceFromDB(BaseTypeID.group5, winNumber3up);
            double paygroup4 = getwinPriceFromDB(BaseTypeID.group4, winNumber3up);
            // sum PayPrice 3up
            List<double> PayList3up = new List<double>();
            PayList3up.Add(payuptod3);
            PayList3up.Add(payup3);
            PayList3up.Add(paygroup3);
            PayList3up.Add(paydoor543);
            PayList3up.Add(paytgroup3);
            PayList3up.Add(paygroup4);
            PayList3up.Add(paygroup5);

            // for 2up
            List<string> winNumber2up = getWinNumber(WinNumberType.up2);
            // get winnumber for 2ht
            List<string> winNumber2ht = getWinNumber(WinNumberType.ht2);
            // get winnumber for 2hu
            List<string> winNumber2hu = getWinNumber(WinNumberType.hu2);

            // get winprice
            double payuptod2 = getwinPriceFromDB(BaseTypeID.uptod2, winNumber2up);
            double payup2 = getwinPriceFromDB(BaseTypeID.up2, winNumber2up);
            double payht2 = getwinPriceFromDB(BaseTypeID.ht2, winNumber2ht);
            double payhu2 = getwinPriceFromDB(BaseTypeID.hu2, winNumber2hu);
            double paydoor19up2 = getwinPriceFromDB(BaseTypeID.door19up2, winNumber2up);

            // for door6 
            double paydoor62up = getwinPriceFromDB(BaseTypeID.door62, "up", winNumber2up);
            double paydoor62ht = getwinPriceFromDB(BaseTypeID.door62, "ht", winNumber2ht);
            double paydoor62hu = getwinPriceFromDB(BaseTypeID.door62, "hu", winNumber2hu);
            // sum PayPrice 2up
            List<double> PayList2up = new List<double>();
            PayList2up.Add(payuptod2);
            PayList2up.Add(payup2);
            PayList2up.Add(payht2);
            PayList2up.Add(payhu2);
            PayList2up.Add(paydoor19up2);
            PayList2up.Add(paydoor62up);
            PayList2up.Add(paydoor62ht);
            PayList2up.Add(paydoor62hu);

            // for 2low
            List<string> winNumber2low = getWinNumber(WinNumberType.low2);
            // get winprice
            double paylow2 = getwinPriceFromDB(BaseTypeID.low2, winNumber2low);
            double paydoor19low2 = getwinPriceFromDB(BaseTypeID.door19low2, winNumber2low);
            // sum PayPrice 2low
            List<double> PayList2low = new List<double>();
            PayList2low.Add(paylow2);
            PayList2low.Add(paydoor19low2);

            // for 3tod
            double payTuptod3 = getwinGPriceFromDB(BaseTypeID.uptod3, winNumber3up);
            double paytod3 = getwinGPriceFromDB(BaseTypeID.tod3, winNumber3up);
            // sum PayPrice 3tod
            List<double> PayList3tod = new List<double>();
            PayList3tod.Add(payTuptod3);
            PayList3tod.Add(paytod3);

            // for 2tod
            double payuptod2up = getwinGPriceFromDB(BaseTypeID.uptod2, "up", winNumber2up);
            double payuptod2ht = getwinGPriceFromDB(BaseTypeID.uptod2, "ht", winNumber2ht);
            double payuptod2hu = getwinGPriceFromDB(BaseTypeID.uptod2, "hu", winNumber2hu);

            double paytod2up = getwinGPriceFromDB(BaseTypeID.tod2, "up", winNumber2up);
            double paytod2ht = getwinGPriceFromDB(BaseTypeID.tod2, "ht", winNumber2ht);
            double paytod2hu = getwinGPriceFromDB(BaseTypeID.tod2, "hu", winNumber2hu);
            // sum PayPrice 2tod
            List<double> PayList2tod = new List<double>();
            if (payuptod2up != 0)
            {
                PayList2tod.Add(payuptod2up);
            }
            else if (payuptod2ht != 0)
            {
                PayList2tod.Add(payuptod2ht);
            }
            else if (payuptod2hu != 0)
            {
                PayList2tod.Add(payuptod2hu);
            }

            if (paytod2up != 0)
            {
                PayList2tod.Add(paytod2up);
            }
            else if (paytod2ht != 0)
            {
                PayList2tod.Add(paytod2ht);
            }
            else if (paytod2hu != 0)
            {
                PayList2tod.Add(paytod2hu);
            }

            // for 1up
            // for 1freeup
            List<string> winNumber1up = getWinNumber(WinNumberType.up1);
            // get winprice
            double payup1 = getwinPriceFromDB(BaseTypeID.up1, winNumber1up);
            // sum PayPrice 1up
            List<double> PayList1up = new List<double>();
            PayList1up.Add(payup1);

            // for 1puk
            // get winnumber
            List<string> winNumber1front = getWinNumber(WinNumberType.upfront1);
            // get winprice
            double payupfront1 = getwinPriceFromDB(BaseTypeID.upfront1, winNumber1front);
            // for 1center
            // get winnumber
            List<string> winNumber1center = getWinNumber(WinNumberType.upcenter1);
            // get winprice
            double payupcenter1 = getwinPriceFromDB(BaseTypeID.upcenter1, winNumber1center);
            // for 1back
            // get winnumber
            List<string> winNumber1back = getWinNumber(WinNumberType.upback1);
            // get winprice
            double payupback1 = getwinPriceFromDB(BaseTypeID.upback1, winNumber1back);
            // for 1lowfront
            // get winnumber
            List<string> winNumber1lowfront = getWinNumber(WinNumberType.lowfront1);
            // get winprice
            double paylowfront1 = getwinPriceFromDB(BaseTypeID.lowfront1, winNumber1lowfront);
            // for 1lowback
            // get winnumber
            List<string> winNumber1lowback = getWinNumber(WinNumberType.lowback1);
            // get winprice
            double paylowback1 = getwinPriceFromDB(BaseTypeID.lowback1, winNumber1lowback);
            // sum PayPrice 1puk
            List<double> PayList1puk = new List<double>();
            PayList1puk.Add(payupfront1);
            PayList1puk.Add(payupcenter1);
            PayList1puk.Add(payupback1);
            PayList1puk.Add(paylowfront1);
            PayList1puk.Add(paylowback1);

            // for 1low
            // get winnumber
            List<string> winNumber1low = getWinNumber(WinNumberType.low1);
            // get winprice
            double paylow1 = getwinPriceFromDB(BaseTypeID.low1, winNumber1low);
            // sum PayPrice 1low
            List<double> PayList1low = new List<double>();
            PayList1low.Add(paylow1);

            // for 5tod
            double paytod5 = getwinPriceFromDB(BaseTypeID.tod5, winNumber3up);
            // sum PayPrice 5tod
            List<double> PayList5tod = new List<double>();
            PayList5tod.Add(paytod5);

            // for 3low
            // get winnumber
            List<string> winNumber3low = getWinNumber(WinNumberType.low3);
            // get winprice
            double paylow3 = getwinPriceFromDB(BaseTypeID.low3, winNumber3low);
            double paylowgroup3 = getwinPriceFromDB(BaseTypeID.lowgroup3, winNumber3low);
            // sum PayPrice 3low
            List<double> PayList3low = new List<double>();
            PayList3low.Add(paylow3);
            PayList3low.Add(paylowgroup3);


            /*
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

            // for 3up
            //PriceList.Add(_price3up);
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
            // sum Discount
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

            // Win Price
            //for 3up
            double _win3up = getWinPrice(BaseTypeID.up3);
            //for 3low
            double _win3low = getWinPrice(BaseTypeID.low3);
            // for 2up
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
            // sum WinPrice
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
            */

            //Net
            // for 3up

            double NetPrice3up = PriceList3up.Sum() - (DiscList3up.Sum() + PayList3up.Sum());
            double NetPrice2up = PriceList2up.Sum() - (DiscList2up.Sum() + PayList2up.Sum());
            double NetPrice2low = PriceList2low.Sum() - (DiscList2low.Sum() + PayList2low.Sum());
            double NetPrice3tod = PriceList3tod.Sum() - (DiscList3tod.Sum() + PayList3tod.Sum());
            double NetPrice2tod = PriceList2tod.Sum() - (DiscList2tod.Sum() + PayList2tod.Sum());
            double NetPrice1up = PriceList1up.Sum() - (DiscList1up.Sum() + PayList1up.Sum());
            double NetPrice1puk = PriceList1puk.Sum() - (DiscList1puk.Sum() + PayList1puk.Sum());
            double NetPrice1low = PriceList1low.Sum() - (DiscList1low.Sum() + PayList1low.Sum());
            double NetPrice5tod = PriceList5tod.Sum() - (DiscList5tod.Sum() + PayList5tod.Sum());
            double NetPrice3low = PriceList3low.Sum() - (DiscList3low.Sum() + PayList3low.Sum());

            /*
            double _netPriceup3 = (Convert.ToDouble(_price3up) - (Convert.ToDouble(_Disc3up) + _win3up));
            double _netPricelow3 = (Convert.ToDouble(_price3low) - (Convert.ToDouble(_Disc3low) + _win3low));
            double _netPriceup2 = (Convert.ToDouble(_price2up) - (Convert.ToDouble(_Disc2up) + _win2up));
            double _netPricelow2 = (Convert.ToDouble(_price2low) - (Convert.ToDouble(_Disc2low) + _win2low));
            double _netPriceht2 = (Convert.ToDouble(_price2ht) - (Convert.ToDouble(_Disc2ht) + _win2ht));
            double _netPricehu2 = (Convert.ToDouble(_price2hu) - (Convert.ToDouble(_Disc2hu) + _win2hu));
            double _netPriceup1 = (Convert.ToDouble(_price1up) - (Convert.ToDouble(_Disc1up) + _win1up));
            double _netPricelow1 = (Convert.ToDouble(_price1low) - (Convert.ToDouble(_Disc1low) + _win1low));
            double _netPricefront1 = (Convert.ToDouble(_price1front) - (Convert.ToDouble(_Disc1front) + _win1front));
            double _netPricecenter1 = (Convert.ToDouble(_price1center) - (Convert.ToDouble(_Disc1center) + _win1center));
            double _netPriceback1 = (Convert.ToDouble(_price1back) - (Convert.ToDouble(_Disc1back) + _win1back));
            double _netPricelowfront1 = (Convert.ToDouble(_price1lowfront) - (Convert.ToDouble(_Disc1lowfront) + _win1lowfront));
            double _netPricelowback1 = (Convert.ToDouble(_price1lowback) - (Convert.ToDouble(_Disc1lowback) + _win1lowback));
            double _sumNetPrice = (Convert.ToDouble(PriceList.Sum()) - (Convert.ToDouble(DiscList.Sum()) + winList.Sum()));
            */
            // Summary
            if(PriceList3up.Sum() != 0)
            {
                summaryInfo.Rows.Add("3 บน", PriceList3up.Sum().ToString("N0"), (PriceList3up.Sum()-DiscList3up.Sum()).ToString("N0"),PayList3up.Sum().ToString("N0"),NetPrice3up.ToString("N0"));
            }
            if(PriceList2up.Sum() != 0)
            {
                summaryInfo.Rows.Add("2 บน", PriceList2up.Sum().ToString("N0"), (PriceList2up.Sum() - DiscList2up.Sum()).ToString("N0"), PayList2up.Sum().ToString("N0"), NetPrice2up.ToString("N0"));
            }
            if (PriceList2low.Sum() != 0)
            {
                summaryInfo.Rows.Add("2 ล่าง", PriceList2low.Sum().ToString("N0"), (PriceList2low.Sum() - DiscList2low.Sum()).ToString("N0"), PayList2low.Sum().ToString("N0"), NetPrice2low.ToString("N0"));
            }
            if (PriceList3tod.Sum() != 0)
            {
                summaryInfo.Rows.Add("โต๊ด 3 บน", PriceList3tod.Sum().ToString("N0"), (PriceList3tod.Sum() - DiscList3tod.Sum()).ToString("N0"), PayList3tod.Sum().ToString("N0"), NetPrice3tod.ToString("N0"));
            }
            if (PriceList2tod.Sum() != 0)
            {
                summaryInfo.Rows.Add("โต๊ด 2 บน", PriceList2tod.Sum().ToString("N0"), (PriceList2tod.Sum() - DiscList2tod.Sum()).ToString("N0"), PayList2tod.Sum().ToString("N0"), NetPrice2tod.ToString("N0"));
            }
            if (PriceList1up.Sum() != 0)
            {
                summaryInfo.Rows.Add("1 บน", PriceList1up.Sum().ToString("N0"), (PriceList1up.Sum() - DiscList1up.Sum()).ToString("N0"), PayList1up.Sum().ToString("N0"), NetPrice1up.ToString("N0"));
            }
            if (PriceList1puk.Sum() != 0)
            {
                summaryInfo.Rows.Add("ปัก", PriceList1puk.Sum().ToString("N0"), (PriceList1puk.Sum() - DiscList1puk.Sum()).ToString("N0"), PayList1puk.Sum().ToString("N0"), NetPrice1puk.ToString("N0"));
            }
            if (PriceList1low.Sum() != 0)
            {
                summaryInfo.Rows.Add("1 ล่าง", PriceList1low.Sum().ToString("N0"), (PriceList1low.Sum() - DiscList1low.Sum()).ToString("N0"), PayList1low.Sum().ToString("N0"), NetPrice1low.ToString("N0"));
            }
            if (PriceList5tod.Sum() != 0)
            {
                summaryInfo.Rows.Add("5 ตัวโต๊ด", PriceList5tod.Sum().ToString("N0"), (PriceList5tod.Sum() - DiscList5tod.Sum()).ToString("N0"), PayList5tod.Sum().ToString("N0"), NetPrice5tod.ToString("N0"));
            }
            if (PriceList3low.Sum() != 0)
            {
                summaryInfo.Rows.Add("3 ล่าง", PriceList3low.Sum().ToString("N0"), (PriceList3low.Sum() - DiscList3low.Sum()).ToString("N0"), PayList3low.Sum().ToString("N0"), NetPrice3low.ToString("N0"));
            }

            /*
            if(_price2up > 0)
            {
                summaryInfo.Rows.Add("2 บน", _price2up.ToString("N0"), _Disc2up.ToString("N0"), _win2up.ToString("N0"), _netPriceup2.ToString("N0"));
            }
            if(_price2low > 0)
            {
                summaryInfo.Rows.Add("2 ล่าง", _price2low.ToString("N0"), _Disc2low.ToString("N0"), _win2low.ToString("N0"), _netPricelow2.ToString("N0"));
            }
            if(_price2ht > 0)
            {
                summaryInfo.Rows.Add("ร้อยสิบ", _price2ht.ToString("N0"), _Disc2ht.ToString("N0"), _win2ht.ToString("N0"), _netPriceht2.ToString("N0"));
            }
            if(_price2hu > 0)
            {
                summaryInfo.Rows.Add("ร้อยหน่วย", _price2hu.ToString("N0"), _Disc2hu.ToString("N0"), _win2hu.ToString("N0"), _netPricehu2.ToString("N0"));
            }
            if(_price1up > 0)
            {
                summaryInfo.Rows.Add("1 บน", _price1up.ToString("N0"), _Disc1up.ToString("N0"), _win1up.ToString("N0"), _netPriceup1.ToString("N0"));
            }
            if(_price1low > 0)
            {
                summaryInfo.Rows.Add("1 ล่าง", _price1low.ToString("N0"), _Disc1low.ToString("N0"), _win1low.ToString("N0"), _netPricelow1.ToString("N0"));
            }
            if(_price1front > 0)
            {
                summaryInfo.Rows.Add("1 หน้า", _price1front.ToString("N0"), _Disc1front.ToString("N0"), _win1front.ToString("N0"), _netPricefront1.ToString("N0"));
            }
            if(_price1center > 0)
            {
                summaryInfo.Rows.Add("1 กลาง", _price1center.ToString("N0"), _Disc1center.ToString("N0"), _win1center.ToString("N0"), _netPricecenter1.ToString("N0"));
            }
            if(_price1back > 0)
            {
                summaryInfo.Rows.Add("1 หลัง", _price1back.ToString("N0"), _Disc1back.ToString("N0"), _win1back.ToString("N0"), _netPriceback1.ToString("N0"));
            }
            if(_price1lowfront > 0)
            {
                summaryInfo.Rows.Add("1 ล่างหน้า", _price1lowfront.ToString("N0"), _Disc1lowfront.ToString("N0"), _win1lowfront.ToString("N0"), _netPricelowfront1.ToString("N0"));
            }
            if(_price1lowback > 0)
            {
                summaryInfo.Rows.Add("1 ล่างหลัง", _price1lowback.ToString("N0"), _Disc1lowback.ToString("N0"), _win1lowback.ToString("N0"), _netPricelowback1.ToString("N0"));
            }
            */
            List<double> PriceList = new List<double>();
            PriceList.AddRange(PriceList3up);
            PriceList.AddRange(PriceList2up);
            PriceList.AddRange(PriceList2low);
            PriceList.AddRange(PriceList3tod);
            PriceList.AddRange(PriceList2tod);
            PriceList.AddRange(PriceList1up);
            PriceList.AddRange(PriceList1puk);
            PriceList.AddRange(PriceList1low);
            PriceList.AddRange(PriceList5tod);
            PriceList.AddRange(PriceList3low);

            List<double> DiscList = new List<double>();
            DiscList.AddRange(DiscList3up);
            DiscList.AddRange(DiscList2up);
            DiscList.AddRange(DiscList2low);
            DiscList.AddRange(DiscList3tod);
            DiscList.AddRange(DiscList2tod);
            DiscList.AddRange(DiscList1up);
            DiscList.AddRange(DiscList1puk);
            DiscList.AddRange(DiscList1low);
            DiscList.AddRange(DiscList5tod);
            DiscList.AddRange(DiscList3low);

            List<double> PayList = new List<double>();
            PayList.AddRange(PayList3up);
            PayList.AddRange(PayList2up);
            PayList.AddRange(PayList2low);
            PayList.AddRange(PayList3tod);
            PayList.AddRange(PayList2tod);
            PayList.AddRange(PayList1up);
            PayList.AddRange(PayList1puk);
            PayList.AddRange(PayList1low);
            PayList.AddRange(PayList5tod);
            PayList.AddRange(PayList3low);

            List<double> NetList = new List<double>();
            NetList.Add(NetPrice3up);
            NetList.Add(NetPrice2up);
            NetList.Add(NetPrice2low);
            NetList.Add(NetPrice3tod);
            NetList.Add(NetPrice2tod);
            NetList.Add(NetPrice1up);
            NetList.Add(NetPrice1puk);
            NetList.Add(NetPrice1low);
            NetList.Add(NetPrice5tod);
            NetList.Add(NetPrice3low);

            summaryInfo.Rows.Add("รวมทั้งหมด", PriceList.Sum().ToString("N0"), (PriceList.Sum() - DiscList.Sum()).ToString("N0"), PayList.Sum().ToString("N0"), NetList.Sum().ToString("N0"));

            summaryReportTableBindingSource.DataSource = summaryInfo;
            this.reportViewer1.RefreshReport();
        }
        private double getwinPriceFromDB(int TypeID, string state, List<string> WinNumber)
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
                                            INNER JOIN CustomerInfo ci ON BINARY_CHECKSUM(ci.CustomerID) = BINARY_CHECKSUM(c.CustomerID))
                                            WHERE oe.Number = '{0}' AND o.TypeID = {1} AND oe.TypeID = {3}", winNumber, TypeID.ToString(), DBWinRate.up2, _typeID.ToString());
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
        private double getPriceFromDB(int TypeID)
        {
            double outPrice = 0;
            SqlConnection connection = new SqlConnection(Database.CnnVal("LottoryDB"));
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            string sqlgetPrice = string.Empty;
            switch (TypeID)
            {
                case BaseTypeID.uptod3:
                case BaseTypeID.uptod2:
                    sqlgetPrice = string.Format(@"SELECT ISNULL(SUM(Price),0) AS Price
                                            FROM OrderList o
                                            WHERE o.TypeID = {0}", TypeID.ToString());
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
                                            FROM OrderList o
                                            INNER JOIN OrderListExpand oe ON o.OrderListID = oe.OrderListID
                                            WHERE o.TypeID = {0}", TypeID.ToString());
                    break;

            }
            SqlCommand sqlgetPriceCom = new SqlCommand(sqlgetPrice, connection);
            SqlDataReader PriceInfo = sqlgetPriceCom.ExecuteReader();
            while (PriceInfo.Read())
            {
                outPrice = Convert.ToDouble(PriceInfo["Price"]);
            }
            connection.Close();
            return outPrice;
        }
        /*
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
        */
        
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
        /*
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
        */
        private double getwinGPriceFromDB(int TypeID, string state, List<string> WinNumber)
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
                                            INNER JOIN CustomerInfo ci ON BINARY_CHECKSUM(ci.CustomerID) = BINARY_CHECKSUM(c.CustomerID))
                                            WHERE oe.Number = '{0}' AND o.TypeID = {1}", winNumber, TypeID.ToString(), DBWinRate.tod3);
                        break;
                    case BaseTypeID.tod3:
                        sqlgetWinPrice = string.Format(@"SELECT o.Number, o.Price AS GroupPrice, ci.{2} AS winRate
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON BINARY_CHECKSUM(ci.CustomerID) = BINARY_CHECKSUM(c.CustomerID))
                                            WHERE oe.Number = '{0}' AND o.TypeID = {1}", winNumber, TypeID.ToString(), DBWinRate.tod3);
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
                                            INNER JOIN CustomerInfo ci ON BINARY_CHECKSUM(ci.CustomerID) = BINARY_CHECKSUM(c.CustomerID))
                                            WHERE oe.Number = '{0}' AND o.TypeID = {1} AND oe.TypeID = {3}", winNumber, TypeID.ToString(), DBWinRate.tod2, _typeID.ToString());
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
                                            INNER JOIN CustomerInfo ci ON BINARY_CHECKSUM(ci.CustomerID) = BINARY_CHECKSUM(c.CustomerID))
                                            WHERE oe.Number = '{0}' AND o.TypeID = {1} AND oe.TypeID = {3}", winNumber, TypeID.ToString(), DBWinRate.tod2, _typeID.ToString());
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
        private double getwinGPriceFromDB(int TypeID, List<string> WinNumber)
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
                                            INNER JOIN CustomerInfo ci ON BINARY_CHECKSUM(ci.CustomerID) = BINARY_CHECKSUM(c.CustomerID))
                                            WHERE oe.Number = '{0}' AND o.TypeID = {1}", winNumber, TypeID.ToString(), DBWinRate.tod3);
                        break;
                    case BaseTypeID.tod3:
                        sqlgetWinPrice = string.Format(@"SELECT o.Number, o.Price AS GroupPrice, ci.{2} AS winRate
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON BINARY_CHECKSUM(ci.CustomerID) = BINARY_CHECKSUM(c.CustomerID))
                                            WHERE oe.Number = '{0}' AND o.TypeID = {1}", winNumber, TypeID.ToString(), DBWinRate.tod3);
                        break;
                    case BaseTypeID.uptod2:
                        sqlgetWinPrice = string.Format(@"SELECT o.Number, o.GroupPrice, ci.{2} AS winRate
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON BINARY_CHECKSUM(ci.CustomerID) = BINARY_CHECKSUM(c.CustomerID))
                                            WHERE oe.Number = '{0}' AND o.TypeID = {1}", winNumber, TypeID.ToString(), DBWinRate.tod2);
                        break;
                    case BaseTypeID.tod2:
                        sqlgetWinPrice = string.Format(@"SELECT o.Number, o.Price AS GroupPrice, ci.{2} AS winRate
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON BINARY_CHECKSUM(ci.CustomerID) = BINARY_CHECKSUM(c.CustomerID))
                                            WHERE oe.Number = '{0}' AND o.TypeID = {1}", winNumber, TypeID.ToString(), DBWinRate.tod2);
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
        private double getwinPriceFromDB(int TypeID, List<string> WinNumber)
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
                                            INNER JOIN CustomerInfo ci ON BINARY_CHECKSUM(ci.CustomerID) = BINARY_CHECKSUM(c.CustomerID))
                                            WHERE o.Number = '{0}' AND o.TypeID = {1}", winNumber, TypeID.ToString(), DBWinRate.up3);
                        break;
                    case BaseTypeID.up3:
                    case BaseTypeID.group3:
                    case BaseTypeID.group4:
                    case BaseTypeID.door543:
                    case BaseTypeID.tgroup3:
                        sqlgetWinPrice = string.Format(@"SELECT oe.Number, oe.Price, ci.{2} AS winRate
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON BINARY_CHECKSUM(ci.CustomerID) = BINARY_CHECKSUM(c.CustomerID))
                                            WHERE oe.Number = '{0}' AND o.TypeID = {1}", winNumber, TypeID.ToString(), DBWinRate.up3);

                        break;
                    case BaseTypeID.uptod2:
                    case BaseTypeID.up2:
                    case BaseTypeID.ht2:
                    case BaseTypeID.hu2:
                        sqlgetWinPrice = string.Format(@"SELECT o.Number, o.Price, ci.{2} AS winRate
                                            FROM ((OrderList o
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON BINARY_CHECKSUM(ci.CustomerID) = BINARY_CHECKSUM(c.CustomerID))
                                            WHERE o.Number = '{0}' AND o.TypeID = {1}", winNumber, TypeID.ToString(), DBWinRate.up2);
                        break;
                    case BaseTypeID.door19up2:
                    case BaseTypeID.door62:
                        sqlgetWinPrice = string.Format(@"SELECT oe.Number, oe.Price, ci.{2} AS winRate
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON BINARY_CHECKSUM(ci.CustomerID) = BINARY_CHECKSUM(c.CustomerID))
                                            WHERE oe.Number = '{0}' AND o.TypeID = {1}", winNumber, TypeID.ToString(), DBWinRate.up2);
                        break;
                    case BaseTypeID.lowgroup3:
                    case BaseTypeID.low3:
                        sqlgetWinPrice = string.Format(@"SELECT oe.Number, oe.Price, ci.{2} AS winRate
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON BINARY_CHECKSUM(ci.CustomerID) = BINARY_CHECKSUM(c.CustomerID))
                                            WHERE oe.Number = '{0}' AND o.TypeID = {1}", winNumber, TypeID.ToString(), DBWinRate.low3);
                        break;
                    case BaseTypeID.low2:
                        sqlgetWinPrice = string.Format(@"SELECT o.Number, o.Price, ci.{2} AS winRate
                                            FROM ((OrderList o
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON BINARY_CHECKSUM(ci.CustomerID) = BINARY_CHECKSUM(c.CustomerID))
                                            WHERE o.Number = '{0}' AND o.TypeID = {1}", winNumber, TypeID.ToString(), DBWinRate.low2);

                        break;
                    case BaseTypeID.door19low2:
                        sqlgetWinPrice = string.Format(@"SELECT oe.Number, oe.Price, ci.{2} AS winRate
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON BINARY_CHECKSUM(ci.CustomerID) = BINARY_CHECKSUM(c.CustomerID))
                                            WHERE oe.Number = '{0}' AND o.TypeID = {1}", winNumber, TypeID.ToString(), DBWinRate.low2);
                        break;
                    case BaseTypeID.tod5:
                        sqlgetWinPrice = string.Format(@"SELECT o.Number, o.Price, ci.{2} AS winRate
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON BINARY_CHECKSUM(ci.CustomerID) = BINARY_CHECKSUM(c.CustomerID))
                                            WHERE oe.Number = '{0}' AND o.TypeID = {1}", winNumber, TypeID.ToString(), DBWinRate.tod5);
                        break;
                    case BaseTypeID.group5:
                        sqlgetWinPrice = string.Format(@"SELECT oe.Number, oe.Price, ci.{2} AS winRate
                                            FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON BINARY_CHECKSUM(ci.CustomerID) = BINARY_CHECKSUM(c.CustomerID))
                                            WHERE oe.Number = '{0}' AND o.TypeID = {1}", winNumber, TypeID.ToString(), DBWinRate.up3);
                        break;
                    case BaseTypeID.up1:
                        sqlgetWinPrice = string.Format(@"SELECT o.Number, o.Price, ci.{2} AS winRate
                                            FROM ((OrderList o
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON BINARY_CHECKSUM(ci.CustomerID) = BINARY_CHECKSUM(c.CustomerID))
                                            WHERE o.Number = '{0}' AND o.TypeID = {1}", winNumber, TypeID.ToString(), DBWinRate.up1);
                        break;
                    case BaseTypeID.low1:
                        sqlgetWinPrice = string.Format(@"SELECT o.Number, o.Price, ci.{2} AS winRate
                                            FROM ((OrderList o
                                            INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                            INNER JOIN CustomerInfo ci ON BINARY_CHECKSUM(ci.CustomerID) = BINARY_CHECKSUM(c.CustomerID))
                                            WHERE o.Number = '{0}' AND o.TypeID = {1}", winNumber, TypeID.ToString(), DBWinRate.low1);
                        break;
                    case BaseTypeID.upfront1:
                        sqlgetWinPrice = string.Format(@"SELECT oe.Number, oe.Price, ci.{2} AS winRate
                                                FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                                INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                                INNER JOIN CustomerInfo ci ON BINARY_CHECKSUM(ci.CustomerID) = BINARY_CHECKSUM(c.CustomerID))
                                                WHERE oe.Number = '{0}' AND oe.TypeID = {1}", winNumber, TypeID.ToString(), DBWinRate.upfront1);
                        break;
                    case BaseTypeID.upback1:
                        sqlgetWinPrice = string.Format(@"SELECT oe.Number, oe.Price, ci.{2} AS winRate
                                                FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                                INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                                INNER JOIN CustomerInfo ci ON BINARY_CHECKSUM(ci.CustomerID) = BINARY_CHECKSUM(c.CustomerID))
                                                WHERE oe.Number = '{0}' AND oe.TypeID = {1}", winNumber, TypeID.ToString(), DBWinRate.upback1);

                        break;
                    case BaseTypeID.upcenter1:
                        sqlgetWinPrice = string.Format(@"SELECT oe.Number, oe.Price, ci.{2} AS winRate
                                                FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                                INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                                INNER JOIN CustomerInfo ci ON BINARY_CHECKSUM(ci.CustomerID) = BINARY_CHECKSUM(c.CustomerID))
                                                WHERE oe.Number = '{0}' AND oe.TypeID = {1}", winNumber, TypeID.ToString(), DBWinRate.upcenter1);

                        break;
                    case BaseTypeID.lowfront1:
                        sqlgetWinPrice = string.Format(@"SELECT oe.Number, oe.Price, ci.{2} AS winRate
                                                FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                                INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                                INNER JOIN CustomerInfo ci ON BINARY_CHECKSUM(ci.CustomerID) = BINARY_CHECKSUM(c.CustomerID))
                                                WHERE oe.Number = '{0}' AND oe.TypeID = {1}", winNumber, TypeID.ToString(), DBWinRate.upfront1);

                        break;
                    case BaseTypeID.lowback1:
                        sqlgetWinPrice = string.Format(@"SELECT oe.Number, oe.Price, ci.{2} AS winRate
                                                FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                                INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                                INNER JOIN CustomerInfo ci ON BINARY_CHECKSUM(ci.CustomerID) = BINARY_CHECKSUM(c.CustomerID))
                                                WHERE oe.Number = '{0}' AND oe.TypeID = {1}", winNumber, TypeID.ToString(), DBWinRate.upback1);

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
    }
}
