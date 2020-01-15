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
    public partial class BuyingSummary : Form
    {
        private static BuyingSummary _instance;

        public static BuyingSummary Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new BuyingSummary();
                return _instance;
            }
        }
        private void BuyingSummary_FormClosed(object sender, FormClosedEventArgs e)
        {
            _instance = null;
        }
        public BuyingSummary()
        {
            InitializeComponent();
        }


        private void BuyingSummary_Load(object sender, EventArgs e)
        {
            // Show Summary
            showBuyingSummary();

            // get Customer List Information
            updateCusotmerNameList();

        }
        private void updateCusotmerNameList()
        {
            SqlConnection connection = new SqlConnection(Database.CnnVal("LottoryDB"));
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            string sqlgetCustomerIDList = string.Format(@"SELECT CustomerID
                                                          FROM CustomerOrder
                                                          GROUP BY CustomerID");
            SqlCommand sqlgetCustomerIDListCom = new SqlCommand(sqlgetCustomerIDList, connection);
            SqlDataReader CustomerListInfo = sqlgetCustomerIDListCom.ExecuteReader();
            while (CustomerListInfo.Read())
            {
                CustomerList.Items.Add(CustomerListInfo["CustomerID"].ToString());
            }
            connection.Close();
        }
        private void showBuyingSummary()
        {
            // Customer Buying
            double _Price3up = getPriceFromDB(BaseTypeID.up3);
            double _Price3low = getPriceFromDB(BaseTypeID.low3);
            double _Price2up = getPriceFromDB(BaseTypeID.up2);
            double _Price2low = getPriceFromDB(BaseTypeID.low2);
            double _Price1up = getPriceFromDB(BaseTypeID.up1);
            double _Price1front = getPriceFromDB(BaseTypeID.upfront1);
            double _Price1center = getPriceFromDB(BaseTypeID.upcenter1);
            double _Price1back = getPriceFromDB(BaseTypeID.upback1);
            double _Price1low = getPriceFromDB(BaseTypeID.low1);
            Price3up.Text = _Price3up.ToString("N0");
            Price3low.Text = _Price3low.ToString("N0");
            Price2up.Text = _Price2up.ToString("N0");
            Price2low.Text = _Price2low.ToString("N0");
            Price1up.Text = _Price1up.ToString("N0");
            Price1front.Text = _Price1front.ToString("N0");
            Price1center.Text = _Price1center.ToString("N0");
            Price1back.Text = _Price1back.ToString("N0");
            Price1low.Text = _Price1low.ToString("N0");

            // discount
            double _Discount3up = getDiscountFromDB(BaseTypeID.up3);
            double _Discount3low = getDiscountFromDB(BaseTypeID.low3);
            double _Discount2up = getDiscountFromDB(BaseTypeID.up2);
            double _Discount2low = getDiscountFromDB(BaseTypeID.low2);
            double _Discount1up = getDiscountFromDB(BaseTypeID.up1);
            double _Discount1front = getDiscountFromDB(BaseTypeID.upfront1);
            double _Discount1center = getDiscountFromDB(BaseTypeID.upcenter1);
            double _Discount1back = getDiscountFromDB(BaseTypeID.upback1);
            double _Discount1low = getDiscountFromDB(BaseTypeID.low1);
            Discount3up.Text = _Discount3up.ToString("N0");
            Discount3low.Text = _Discount3low.ToString("N0");
            Discount2up.Text = _Discount2up.ToString("N0");
            Discount2low.Text = _Discount2low.ToString("N0");
            Discount1up.Text = _Discount1up.ToString("N0");
            Discount1front.Text = _Discount1front.ToString("N0");
            Discount1center.Text = _Discount1center.ToString("N0");
            Discount1back.Text = _Discount1back.ToString("N0");
            Discount1low.Text = _Discount1low.ToString("N0");

            // net
            double _Net3up = _Price3up - _Discount3up;
            double _Net3low = _Price3low - _Discount3low;
            double _Net2up = _Price2up - _Discount2up;
            double _Net2low = _Price2low - _Discount2low;
            double _Net1up = _Price1up - _Discount1up;
            double _Net1front = _Price1front - _Discount1front;
            double _Net1center = _Price1center - _Discount1center;
            double _Net1back = _Price1back - _Discount1back;
            double _Net1low = _Price1low - _Discount1low;
            Net3up.Text = _Net3up.ToString("N0");
            Net3low.Text = _Net3low.ToString("N0");
            Net2up.Text = _Net2up.ToString("N0");
            Net2low.Text = _Net2low.ToString("N0");
            Net1up.Text = _Net1up.ToString("N0");
            Net1front.Text = _Net1front.ToString("N0");
            Net1center.Text = _Net1center.ToString("N0");
            Net1back.Text = _Net1back.ToString("N0");
            Net1low.Text = _Net1low.ToString("N0");

            // summary
            List<double> _PriceList = new List<double>();
            _PriceList.Add(_Price3up);
            _PriceList.Add(_Price3low);
            _PriceList.Add(_Price2up);
            _PriceList.Add(_Price2low);
            _PriceList.Add(_Price1up);
            _PriceList.Add(_Price1front);
            _PriceList.Add(_Price1center);
            _PriceList.Add(_Price1back);
            _PriceList.Add(_Price1low);

            List<double> _DiscountList = new List<double>();
            _DiscountList.Add(_Discount3up);
            _DiscountList.Add(_Discount3low);
            _DiscountList.Add(_Discount2up);
            _DiscountList.Add(_Discount2low);
            _DiscountList.Add(_Discount1up);
            _DiscountList.Add(_Discount1front);
            _DiscountList.Add(_Discount1center);
            _DiscountList.Add(_Discount1back);
            _DiscountList.Add(_Discount1low);

            List<double> _NetList = new List<double>();
            _NetList.Add(_Net3up);
            _NetList.Add(_Net3low);
            _NetList.Add(_Net2up);
            _NetList.Add(_Net2low);
            _NetList.Add(_Net1up);
            _NetList.Add(_Net1front);
            _NetList.Add(_Net1center);
            _NetList.Add(_Net1back);
            _NetList.Add(_Net1low);


            PriceAll.Text = _PriceList.Sum().ToString("N0");
            DiscountAll.Text = _DiscountList.Sum().ToString("N0");
            NetAll.Text = _NetList.Sum().ToString("N0");

        }
        private double getPriceFromDB(int TypeID)
        {
            double outPrice = 0;
            SqlConnection connection = new SqlConnection(Database.CnnVal("LottoryDB"));
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            string sqlgetPrice;
            switch (TypeID)
            {
                case BaseTypeID.up3:
                    sqlgetPrice = "SELECT SUM(OwnPrice - OutPrice) AS Price FROM Number_3up";
                    break;
                case BaseTypeID.up2:
                    sqlgetPrice = "SELECT SUM(OwnPrice - OutPrice) AS Price FROM Number_2up";
                    break;
                case BaseTypeID.low2:
                    sqlgetPrice = "SELECT SUM(OwnPrice - OutPrice) AS Price FROM Number_2low";
                    break;
                default:
                    sqlgetPrice = string.Format(@"SELECT ISNULL(SUM(OwnPrice),0) AS Price
                                                 FROM OrderListExpand
                                                 WHERE TypeID = {0}", TypeID.ToString());
                    break;
            }
            SqlCommand sqlgetPriceCom = new SqlCommand(sqlgetPrice, connection);
            SqlDataReader sumPrice = sqlgetPriceCom.ExecuteReader();
            while (sumPrice.Read())
            {
                outPrice = Convert.ToDouble(sumPrice["Price"]);
            }
            connection.Close();
            return outPrice;
        }
        private double getDiscountFromDB(int TypeID)
        {
            double outDiscount = 0;
            SqlConnection connection = new SqlConnection(Database.CnnVal("LottoryDB"));
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            string sqlgetDiscount = string.Format(@"SELECT ISNULL(SUM(DiscPrice),0) AS Discount
                                                    FROM OrderListExpand
                                                    WHERE TypeID = {0}", TypeID.ToString());
            SqlCommand sqlgetDiscountCom = new SqlCommand(sqlgetDiscount, connection);
            SqlDataReader DiscountInfo = sqlgetDiscountCom.ExecuteReader();
            while(DiscountInfo.Read())
            {
                outDiscount = Convert.ToDouble(DiscountInfo["Discount"]);
            }
            connection.Close();
            return outDiscount;
        }
        private DataTable getNumberXXXFromDB(int TypeID)
        {
            DataTable NumberTable = new DataTable();
            NumberTable.Columns.Add("Number");
            NumberTable.Columns.Add("Price");

            SqlConnection connection = new SqlConnection(Database.CnnVal("LottoryDB"));
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            string sqlgetNumberInfo;
            switch (TypeID)
            {
                case BaseTypeID.up3:
                    sqlgetNumberInfo = "SELECT Number, (OwnPrice - OutPrice) AS Price FROM Number_3up WHERE Price > 0";
                    break;
                case BaseTypeID.up2:
                    sqlgetNumberInfo = "SELECT Number, (OwnPrice - OutPrice) AS Price FROM Number_2up WHERE Price > 0";
                    break;
                case BaseTypeID.low2:
                    sqlgetNumberInfo = "SELECT Number, (OwnPrice - OutPrice) AS Price FROM Number_2low WHERE Price > 0";
                    break;
                default:
                    sqlgetNumberInfo = string.Format(@"SELECT Number, SUM(OwnPrice) AS Price
                                                    FROM OrderListExpand
                                                    WHERE TypeID = {0}
                                                    Group BY Number", TypeID.ToString());
                    break;
            }
            
            SqlCommand sqlgetNumberInfoCom = new SqlCommand(sqlgetNumberInfo, connection);
            SqlDataReader NumberInfo = sqlgetNumberInfoCom.ExecuteReader();
            while (NumberInfo.Read())
            {
                NumberTable.Rows.Add(NumberInfo["Number"].ToString(), Convert.ToInt32(NumberInfo["Price"]).ToString("N0"));
            }
            connection.Close();
            return NumberTable;
        }

        private void ShowDetail(object sender, EventArgs e)
        {
            Button btDetail = (Button)sender;
            DataTable dbTable = new DataTable();
            string heading = "ตารางแสดงตัวเลข ";
            switch(btDetail.Name)
            {
                case "Detail3up":
                    dbTable = getNumberXXXFromDB(BaseTypeID.up3);
                    heading += "3 บน";
                    break;
                case "Detail3low":
                    dbTable = getNumberXXXFromDB(BaseTypeID.low3);
                    heading += "3 ล่าง";
                    break;
                case "Detail2up":
                    dbTable = getNumberXXXFromDB(BaseTypeID.up2);
                    heading += "2 บน";
                    break;
                case "Detail2low":
                    dbTable = getNumberXXXFromDB(BaseTypeID.low2);
                    heading += "2 ล่าง";
                    break;
                case "Detail1up":
                    dbTable = getNumberXXXFromDB(BaseTypeID.up1);
                    heading += "1 บน";
                    break;
                case "Detail1front":
                    dbTable = getNumberXXXFromDB(BaseTypeID.upfront1);
                    heading += "1 หน้า";
                    break;
                case "Detail1center":
                    dbTable = getNumberXXXFromDB(BaseTypeID.upcenter1);
                    heading += "1 กลาง";
                    break;
                case "Detail1back":
                    dbTable = getNumberXXXFromDB(BaseTypeID.upback1);
                    heading += "1 หลัง";
                    break;
                case "Detail1low":
                    dbTable = getNumberXXXFromDB(BaseTypeID.low1);
                    heading += "1 ล่าง";
                    break;
                default:
                    // error
                    break;
            }

            // Show Detail Number Form
            DetailNumberXXX detailFrom = DetailNumberXXX.Instance;
            detailFrom.MdiParent = this.MdiParent;
            detailFrom.DataTableToFrom(dbTable);
            detailFrom.lbHeading.Text = heading;
            detailFrom.Show();
        }

        private void DetailAll_Click(object sender, EventArgs e)
        {
            // show for all customer
            OpenNumberBuyingList(true);
        }
        private void OpenNumberBuyingList(bool AllShow)
        {
            NumberBuyingList NumberbuyingForm = NumberBuyingList.Instance;
            NumberbuyingForm.MdiParent = this.MdiParent;
            if(AllShow)
            {
                NumberbuyingForm.CustomerID = string.Empty;
                NumberbuyingForm.PageNumber = string.Empty;
                NumberbuyingForm.Text = string.Format("ตารางแสดงตัวเลข (รวม)");
            }
            else
            {
                NumberbuyingForm.CustomerID = CustomerList.Text;
                NumberbuyingForm.PageNumber = PageList.Text;
                if(string.Equals(PageList.Text,"ทั้งหมด"))
                {
                    NumberbuyingForm.Text = string.Format("ตารางแสดงตัวเลข รหัส {0} ทุกหน้า", CustomerList.Text);
                }
                else
                {
                    NumberbuyingForm.Text = string.Format("ตารางแสดงตัวเลข รหัส {0} หน้า {1}", CustomerList.Text, PageList.Text);
                }
            }
            NumberbuyingForm.AllShow = AllShow;
            NumberbuyingForm.Show();
        }
        private void ShowForCustomer_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(CustomerList.Text) && !string.IsNullOrEmpty(PageList.Text))
            {
                OpenNumberBuyingList(false);
            }
        }
       
        private void CustomerList_SelectedIndexChanged(object sender, EventArgs e)
        {
            PageList.Items.Clear();
            PageList.Items.Add("ทั้งหมด");
            // Update Page List
            SqlConnection connection = new SqlConnection(Database.CnnVal("LottoryDB"));
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            string sqlgetPageList = string.Format(@"SELECT Page FROM CustomerOrder
                                                    WHERE CustomerID = '{0}'", CustomerList.Text);
            SqlCommand sqlgetPageListCom = new SqlCommand(sqlgetPageList, connection);
            SqlDataReader PageListInfo = sqlgetPageListCom.ExecuteReader();
            while (PageListInfo.Read())
            {
                PageList.Items.Add(PageListInfo["Page"].ToString());
            }
            connection.Close();
        }

        private void BackToMain_Click(object sender, EventArgs e)
        {
            MainLotto mainLotto = (MainLotto)this.MdiParent;
            mainLotto.ShowForm(MainMenu.Instance);
        }
    }
}
