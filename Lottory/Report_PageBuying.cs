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
    public partial class Report_PageBuying : Form
    {
        private static Report_PageBuying _instance;
        public static Report_PageBuying Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Report_PageBuying();
                return _instance;
            }
        }
        private void Report_PageBuying_FormClosed(object sender, FormClosedEventArgs e)
        {
            _instance = null;
        }
        public Report_PageBuying()
        {
            InitializeComponent();
        }

        private void Report_PageBuying_Load(object sender, EventArgs e)
        {

            
        }
        private void Search_Click(object sender, EventArgs e)
        {
            NumberSearch numberInfo = new NumberSearch();
            numberInfo.Number = tbNumber.Text;
            numberInfo.Type = string.Format("{0} {1}", tbNumber.Text.Length, cbType.Text);
            this.NumberSearchBindingSource.DataSource = numberInfo;

            // get All Customer Buying
            DataTable buyingList = getPageBuyingList(tbNumber.Text, getTypeID(tbNumber.Text, cbType.Text));
            this.PageBuyingBindingSource.DataSource = buyingList;

            this.reportViewer1.RefreshReport();
        }

        private int getTypeID(string Number, string Type)
        {
            int outTypeID = 0;
            switch (Number.Length)
            {
                case 1:
                    switch (Type)
                    {
                        case "บน":
                            outTypeID = BaseTypeID.up1;
                            break;
                        case "ล่าง":
                            outTypeID = BaseTypeID.low1;
                            break;
                    }
                    break;
                case 2:
                    switch (Type)
                    {
                        case "บน":
                            outTypeID = BaseTypeID.up2;
                            break;
                        case "ล่าง":
                            outTypeID = BaseTypeID.low2;
                            break;
                    }
                    break;
                case 3:
                    switch (Type)
                    {
                        case "บน":
                            outTypeID = BaseTypeID.up3;
                            break;
                        case "ล่าง":
                            outTypeID = BaseTypeID.low3;
                            break;
                    }
                    break;
            }
            return outTypeID;
        }
        private DataTable getPageBuyingList(string Number, int TypeID)
        {
            DataTable outBuying = new DataTable();
            outBuying.Columns.Add("CustomerID");
            outBuying.Columns.Add("CustomerName");
            outBuying.Columns.Add("Page");
            outBuying.Columns.Add("Number");
            outBuying.Columns.Add("Type");
            outBuying.Columns.Add("Price");
            outBuying.Columns.Add("Group");

            // get customerInfo
            SqlConnection connection = new SqlConnection(Database.CnnVal("LottoryDB"));
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            string sqlgetcustomerinfo = string.Format(@"SELECT DISTINCT c.CustomerID,ci.CustomerName, c.Page
                                                        FROM ((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                                        INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID) INNER JOIN CustomerInfo ci ON BINARY_CHECKSUM(ci.CustomerID) = BINARY_CHECKSUM(c.CustomerID)
                                                        WHERE oe.Number = '{0}' AND oe.TypeID = {1}
                                                        ORDER BY c.CustomerID, c.Page ", Number, TypeID.ToString());
            SqlCommand sqlgetcustomerinfoCom = new SqlCommand(sqlgetcustomerinfo, connection);
            SqlDataReader customerInfo = sqlgetcustomerinfoCom.ExecuteReader();
            while (customerInfo.Read())
            {
                string _customerID = customerInfo["CustomerID"].ToString();
                string _customerName = customerInfo["CustomerName"].ToString();
                string _Page = customerInfo["Page"].ToString();

                DataTable _PageBuying = getCustomerPageBuying(_customerID, _customerName, _Page, Number, TypeID);
                foreach(DataRow row in _PageBuying.Rows)
                {
                    string _customerid = row["CustomerID"].ToString();
                    string _customername = row["CustomerName"].ToString();
                    string _page = row["Page"].ToString();
                    string _number = row["Number"].ToString();
                    string _type = row["Type"].ToString();
                    string _price = row["Price"].ToString();
                    string _gprice = row["Group"].ToString();

                    outBuying.Rows.Add(_customerid, _customername, _page, _number, _type, _price, _gprice);

                }
            }
            connection.Close();
            return outBuying;
        }
        private DataTable getCustomerPageBuying(string CustomerID, string CustomerName, string PageID, string Number, int TypeID)
        {
            DataTable outBuying = new DataTable();
            outBuying.Columns.Add("CustomerID");
            outBuying.Columns.Add("CustomerName");
            outBuying.Columns.Add("Page");
            outBuying.Columns.Add("Number");
            outBuying.Columns.Add("Type");
            outBuying.Columns.Add("Price");
            outBuying.Columns.Add("Group");

            SqlConnection connection = new SqlConnection(Database.CnnVal("LottoryDB"));
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            string sqlgetBuying = string.Format(@"SELECT DISTINCT o.Number,t.TypeName, o.Price, o.GroupPrice
                                                  FROM ((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                                  INNER JOIN CustomerOrder c ON c.OrderID = o.OrderID)
                                                  INNER JOIN TypeNumberInfo t ON o.TypeID = t.TypeID
                                                  WHERE oe.Number = '{0}' AND oe.TypeID = {1} AND c.Page = {2} AND BINARY_CHECKSUM(c.CustomerID) = BINARY_CHECKSUM('{3}')", Number, TypeID.ToString(), PageID, CustomerID);

            SqlCommand sqlgetBuyingCom = new SqlCommand(sqlgetBuying, connection);
            SqlDataReader BuyingInfo = sqlgetBuyingCom.ExecuteReader();
            bool firstRow = true;
            while (BuyingInfo.Read())
            {
                string _Number = BuyingInfo["Number"].ToString();
                string _Type = BuyingInfo["TypeName"].ToString();
                string _Price;
                string _groupPrice;
                if(Convert.ToInt32(BuyingInfo["Price"]) > 0)
                {
                    _Price = Convert.ToDouble(BuyingInfo["Price"]).ToString("N0");
                }
                else
                {
                    _Price = string.Empty;
                }
                if(Convert.ToInt32(BuyingInfo["GroupPrice"]) > 0)
                {
                    _groupPrice = Convert.ToDouble(BuyingInfo["GroupPrice"]).ToString("N0");
                }
                else
                {
                    _groupPrice = string.Empty;
                }
                if(firstRow)
                {
                    outBuying.Rows.Add(CustomerID, CustomerName, PageID, _Number, _Type, _Price, _groupPrice);
                    firstRow = false;
                }
                else
                {
                    outBuying.Rows.Add(string.Empty, string.Empty, string.Empty, _Number, _Type, _Price, _groupPrice);
                }
                
            }
            connection.Close();
            return outBuying;
        }


    }
}
