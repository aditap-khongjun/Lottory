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
    public partial class Report_AllBuying : Form
    {
        private static Report_AllBuying _instance;
        public static Report_AllBuying Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Report_AllBuying();
                return _instance;
            }
        }
        private void Report_AllBuying_FormClosed(object sender, FormClosedEventArgs e)
        {
            _instance = null;
        }
        public Report_AllBuying()
        {
            InitializeComponent();
        }

        private void Report_AllBuying_Load(object sender, EventArgs e)
        {
            
        }

        private void Search_Click(object sender, EventArgs e)
        {
            NumberSearch numberInfo = new NumberSearch();
            numberInfo.Number = tbNumber.Text;
            numberInfo.Type = string.Format("{0} {1}", tbNumber.Text.Length, cbType.Text);
            this.NumberSearchBindingSource.DataSource = numberInfo;

            // get All Customer Buying
            DataTable buyingList = getAllBuyingList(tbNumber.Text, getTypeID(tbNumber.Text, cbType.Text));
            this.AllBuyingBindingSource.DataSource = buyingList;

            this.reportViewer1.RefreshReport();
        }
        private int getTypeID(string Number, string Type)
        {
            int outTypeID = 0;
            switch(Number.Length)
            {
                case 1:
                    switch(Type)
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
                    switch(Type)
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
        private DataTable getAllBuyingList(string Number, int TypeID)
        {
            DataTable outBuying = new DataTable();
            outBuying.Columns.Add("CustomerID");
            outBuying.Columns.Add("CustomerName");
            outBuying.Columns.Add("Buying");
            outBuying.Columns["Buying"].DataType = typeof(Double);

            SqlConnection connection = new SqlConnection(Database.CnnVal("LottoryDB"));
            if(connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            string sqlgetcustomerinfo = string.Format(@"SELECT DISTINCT ci.CustomerID, ci.CustomerName, oe.Number
                                                        FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                                        INNER JOIN CustomerOrder c ON o.OrderID = c.OrderID)
                                                        INNER JOIN CustomerInfo ci ON c.CustomerID = ci.CustomerID)
                                                        WHERE oe.Number = '{0}' AND oe.TypeID = {1}", Number, TypeID.ToString());
            SqlCommand sqlgetcustomerinfoCom = new SqlCommand(sqlgetcustomerinfo, connection);
            SqlDataReader customerInfo = sqlgetcustomerinfoCom.ExecuteReader();
            while(customerInfo.Read())
            {
                string _customerID = customerInfo["CustomerID"].ToString();
                string _customerName = customerInfo["CustomerName"].ToString();

                // get Customer Buying
                string _customerBuy = getCustomerBuying(_customerID, Number, TypeID).ToString("N0");

                outBuying.Rows.Add(_customerID, _customerName, _customerBuy);
            }
            connection.Close();

            //sort row
            DataView dtView = new DataView(outBuying);
            dtView.Sort = "Buying DESC";
            outBuying = dtView.ToTable();

            return outBuying;
        }
        private double getCustomerBuying(string CustomerID, string Number, int TypeID)
        {
            double outBuying = 0;
            SqlConnection connection = new SqlConnection(Database.CnnVal("LottoryDB"));
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            string sqlgetBuying = string.Format(@"SELECT SUM(oe.OwnPrice) AS Price
                                                  FROM (((OrderListExpand oe INNER JOIN OrderList o ON oe.OrderListID = o.OrderListID)
                                                  INNER JOIN CustomerOrder c ON o.OrderID = c.OrderID)
                                                  INNER JOIN CustomerInfo ci ON c.CustomerID = ci.CustomerID)
                                                  WHERE oe.Number = '{0}' AND oe.TypeID = {1} AND ci.CustomerID = '{2}'", Number, TypeID.ToString(), CustomerID);
             
            SqlCommand sqlgetBuyingCom = new SqlCommand(sqlgetBuying, connection);
            SqlDataReader BuyingInfo = sqlgetBuyingCom.ExecuteReader();
            while(BuyingInfo.Read())
            {
                outBuying = Convert.ToDouble(BuyingInfo["Price"]);
            }
            connection.Close();
            return outBuying;
        }


    }
}
