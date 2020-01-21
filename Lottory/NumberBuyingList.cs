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
    public partial class NumberBuyingList : Form
    {
        private static NumberBuyingList _instance;
        public static NumberBuyingList Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new NumberBuyingList();
                return _instance;
            }

        }
        private void NumberBuyingList_FormClosed(object sender, FormClosedEventArgs e)
        {
            _instance = null;
        }

        public string CustomerID { get; set; }
        public string PageNumber { get; set; }
        public bool AllShow { get; set; }

        public NumberBuyingList()
        {
            InitializeComponent();
        }
        private void NumberBuyingList_Load(object sender, EventArgs e)
        {
            // Show Number List
            if(this.AllShow)
            {
                showAllNumberTable();
                showAllBuyingSummary();
            }
            else
            {
                showCustomerNumberTable();
                showCusmterBuyingSummary();
            }
        }
        private void showCustomerNumberTable()
        {// Show Customer Buying Number

            if(string.Equals(this.PageNumber,"ทั้งหมด"))
            {// For All Page
                // update Number 3up
                dgvNumber3up.DataSource = getNumberXXXFromDB(BaseTypeID.up3, this.CustomerID, string.Empty);
                dgvNumber3up.ClearSelection();
                // update Number 2up
                dgvNumber2up.DataSource = getNumberXXXFromDB(BaseTypeID.up2, this.CustomerID, string.Empty);
                dgvNumber2up.ClearSelection();
                // update Numbe 2low
                dgvNumber2low.DataSource = getNumberXXXFromDB(BaseTypeID.low2, this.CustomerID, string.Empty);
                dgvNumber2low.ClearSelection();
                // update Number 3low
                dgvNumber3low.DataSource = getNumberXXXFromDB(BaseTypeID.low3, this.CustomerID, string.Empty);
                dgvNumber3low.ClearSelection();
                // update Number 1up
                dgvNumber1up.DataSource = getNumberXXXFromDB(BaseTypeID.up1, this.CustomerID, string.Empty);
                dgvNumber1up.ClearSelection();
                // update Number 1low
                dgvNumber1low.DataSource = getNumberXXXFromDB(BaseTypeID.low1, this.CustomerID, string.Empty);
                dgvNumber1low.ClearSelection();
            }
            else
            {// For Each Page
                // update Number 3up
                dgvNumber3up.DataSource = getNumberXXXFromDB(BaseTypeID.up3, this.CustomerID, this.PageNumber);
                dgvNumber3up.ClearSelection();
                // update Number 2up
                dgvNumber2up.DataSource = getNumberXXXFromDB(BaseTypeID.up2, this.CustomerID, this.PageNumber);
                dgvNumber2up.ClearSelection();
                // update Numbe 2low
                dgvNumber2low.DataSource = getNumberXXXFromDB(BaseTypeID.low2, this.CustomerID, this.PageNumber);
                dgvNumber2low.ClearSelection();
                // update Number 3low
                dgvNumber3low.DataSource = getNumberXXXFromDB(BaseTypeID.low3, this.CustomerID, this.PageNumber);
                dgvNumber3low.ClearSelection();
                // update Number 1up
                dgvNumber1up.DataSource = getNumberXXXFromDB(BaseTypeID.up1, this.CustomerID, this.PageNumber);
                dgvNumber1up.ClearSelection();
                // update Number 1low
                dgvNumber1low.DataSource = getNumberXXXFromDB(BaseTypeID.low1, this.CustomerID, this.PageNumber);
                dgvNumber1low.ClearSelection();
            }
        }
        private void showCusmterBuyingSummary()
        {
            if(string.Equals(this.PageNumber,"ทั้งหมด"))
            {
                // label for 3up
                lbPrice3up.Text = getNumberXXXPriceFromDB(BaseTypeID.up3, this.CustomerID, string.Empty).ToString("N0");
                // label for 2up
                lbPrice2up.Text = getNumberXXXPriceFromDB(BaseTypeID.up2, this.CustomerID, string.Empty).ToString("N0");
                // label for 2low
                lbPrice2low.Text = getNumberXXXPriceFromDB(BaseTypeID.low2, this.CustomerID, string.Empty).ToString("N0");
                // lable for 3low
                lbPrice3low.Text = getNumberXXXPriceFromDB(BaseTypeID.low3, this.CustomerID, string.Empty).ToString("N0");
                // lable for 1up
                lbPrice1up.Text = getNumberXXXPriceFromDB(BaseTypeID.up1, this.CustomerID, string.Empty).ToString("N0");
                // label for 1low
                lbPrice1low.Text = getNumberXXXPriceFromDB(BaseTypeID.low1, this.CustomerID, string.Empty).ToString("N0");
            }
            else
            {
                // label for 3up
                lbPrice3up.Text = getNumberXXXPriceFromDB(BaseTypeID.up3, this.CustomerID, this.PageNumber).ToString("N0");
                // label for 2up
                lbPrice2up.Text = getNumberXXXPriceFromDB(BaseTypeID.up2, this.CustomerID, this.PageNumber).ToString("N0");
                // label for 2low
                lbPrice2low.Text = getNumberXXXPriceFromDB(BaseTypeID.low2, this.CustomerID, this.PageNumber).ToString("N0");
                // lable for 3low
                lbPrice3low.Text = getNumberXXXPriceFromDB(BaseTypeID.low3, this.CustomerID, this.PageNumber).ToString("N0");
                // lable for 1up
                lbPrice1up.Text = getNumberXXXPriceFromDB(BaseTypeID.up1, this.CustomerID, this.PageNumber).ToString("N0");
                // label for 1low
                lbPrice1low.Text = getNumberXXXPriceFromDB(BaseTypeID.low1, this.CustomerID, this.PageNumber).ToString("N0");
            }
        }
        private double getNumberXXXPriceFromDB(int TypeID)
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
                    sqlgetPrice = string.Format(@"SELECT ISNULL(SUM(o1.Price),0) AS Price
                                                 FROM (
	                                                SELECT Number, SUM(OwnPrice) AS Price
	                                                FROM OrderListExpand
	                                                WHERE TypeID = {0}
	                                                GROUP BY Number
	                                                ) o1", TypeID.ToString());
                    break;
            }
            
            SqlCommand sqlgetPriceCom = new SqlCommand(sqlgetPrice, connection);
            SqlDataReader sumPrice = sqlgetPriceCom.ExecuteReader();
            while(sumPrice.Read())
            {
                outPrice = Convert.ToDouble(sumPrice["Price"]);
            }
            connection.Close();
            return outPrice;
        }
        private double getNumberXXXPriceFromDB(int TypeID, string CustomerID, string PageNumber)
        {
            double outPrice = 0;
            SqlConnection connection = new SqlConnection(Database.CnnVal("LottoryDB"));
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            string sqlgetPrice;
            if (string.IsNullOrEmpty(PageNumber))
            {
                sqlgetPrice  = string.Format(@"SELECT ISNULL(SUM(r2.Price),0) AS Price
                                              FROM (
	                                            SELECT Number, SUM(OwnPrice) AS Price
	                                            FROM (
		                                            SELECT OrderListID 
		                                            FROM (
			                                            SELECT OrderID
			                                            FROM CustomerOrder
			                                            WHERE CustomerID = '{0}'
			                                            ) r INNER JOIN OrderList o ON o.OrderID = r.OrderID
		                                            ) r1 INNER JOIN OrderListExpand oe ON r1.OrderListID = oe.OrderListID
	                                            WHERE TypeID = {1}
	                                            GROUP BY Number
	                                            ) r2", CustomerID,TypeID.ToString());
            }
            else
            {
                sqlgetPrice = string.Format(@"SELECT ISNULL(SUM(r2.Price),0) AS Price
                                              FROM (
	                                            SELECT Number, SUM(OwnPrice) AS Price
	                                            FROM (
		                                            SELECT OrderListID 
		                                            FROM (
			                                            SELECT OrderID
			                                            FROM CustomerOrder
			                                            WHERE CustomerID = '{0}' AND Page = {1}
			                                            ) r INNER JOIN OrderList o ON o.OrderID = r.OrderID
		                                            ) r1 INNER JOIN OrderListExpand oe ON r1.OrderListID = oe.OrderListID
	                                            WHERE TypeID = {2}
	                                            GROUP BY Number
	                                            ) r2", CustomerID, PageNumber, TypeID.ToString());
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
        private DataTable getNumberXXXFromDB(int TypeID)
        {
            DataTable resultTable = new DataTable();
            resultTable.Columns.Add("เบอร์");
            resultTable.Columns.Add("จำนวนเงิน");

            SqlConnection connection = new SqlConnection(Database.CnnVal("LottoryDB"));
            if(connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            string sqlgetNumberxxxInfo;
            switch (TypeID)
            {
                case BaseTypeID.up3:
                    sqlgetNumberxxxInfo = "SELECT Number, (OwnPrice-OutPrice) AS Price FROM Number_3up WHERE Price > 0 ORDER BY Price DESC";
                    break;
                case BaseTypeID.up2:
                    sqlgetNumberxxxInfo = "SELECT Number, (OwnPrice-OutPrice) AS Price FROM Number_2up WHERE Price > 0 ORDER BY Price DESC";
                    break;
                case BaseTypeID.low2:
                    sqlgetNumberxxxInfo = "SELECT Number, (OwnPrice-OutPrice) AS Price FROM Number_2low WHERE Price > 0 ORDER BY Price DESC";
                    break;
                default:
                    sqlgetNumberxxxInfo = string.Format(@"SELECT Number, SUM(OwnPrice) AS Price
                                                         FROM OrderListExpand
                                                         WHERE TypeID = {0}
                                                         GROUP BY Number
                                                         ORDER BY Price DESC", TypeID.ToString());
                    break;
            }
            
            SqlCommand sqlgetNumberxxxInfoCom = new SqlCommand(sqlgetNumberxxxInfo, connection);
            SqlDataReader NumberListInfo = sqlgetNumberxxxInfoCom.ExecuteReader();
            while(NumberListInfo.Read())
            {
                resultTable.Rows.Add(NumberListInfo["Number"].ToString(), Convert.ToDouble(NumberListInfo["Price"]).ToString("N0"));
            }
            connection.Close();
            return resultTable;
        }
        private DataTable getNumberXXXFromDB(int TypeID,string CustomerID, string PageNumber)
        {
            DataTable resultTable = new DataTable();
            resultTable.Columns.Add("เบอร์");
            resultTable.Columns.Add("จำนวนเงิน");
            SqlConnection connection = new SqlConnection(Database.CnnVal("LottoryDB"));
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            string sqlgetNumberxxxInfo;
            if (string.IsNullOrEmpty(PageNumber))
            {
                sqlgetNumberxxxInfo = string.Format(@"SELECT Number, SUM(Price) AS Price
                                                        FROM (
	                                                    SELECT OrderListID 
	                                                    FROM (
		                                                    SELECT OrderID
		                                                    FROM CustomerOrder
		                                                    WHERE CustomerID = '{0}'
		                                                    ) r INNER JOIN OrderList o ON o.OrderID = r.OrderID
	                                                    ) r1 INNER JOIN OrderListExpand oe ON r1.OrderListID = oe.OrderListID
                                                        WHERE TypeID = {1}
                                                        GROUP BY Number
                                                        ORDER BY Price DESC", CustomerID, TypeID.ToString());
            }
            else
            {
                sqlgetNumberxxxInfo = string.Format(@"SELECT Number, SUM(OwnPrice) AS Price
                                                        FROM (
	                                                    SELECT OrderListID 
	                                                    FROM (
		                                                    SELECT OrderID
		                                                    FROM CustomerOrder
		                                                    WHERE CustomerID = '{0}' AND Page = {1}
		                                                    ) r INNER JOIN OrderList o ON o.OrderID = r.OrderID
	                                                    ) r1 INNER JOIN OrderListExpand oe ON r1.OrderListID = oe.OrderListID
                                                        WHERE TypeID = {2}
                                                        GROUP BY Number
                                                        ORDER BY Price DESC", CustomerID, PageNumber, TypeID.ToString());
            }

            SqlCommand sqlgetNumberxxxInfoCom = new SqlCommand(sqlgetNumberxxxInfo, connection);
            SqlDataReader NumberListInfo = sqlgetNumberxxxInfoCom.ExecuteReader();
            while (NumberListInfo.Read())
            {
                resultTable.Rows.Add(NumberListInfo["Number"].ToString(), Convert.ToDouble(NumberListInfo["Price"]).ToString("N"));
            }
            connection.Close();
            return resultTable;
        }

        private void showAllNumberTable()
        {
            // Update Number 3up
            dgvNumber3up.DataSource = getNumberXXXFromDB(BaseTypeID.up3);
            dgvNumber3up.ClearSelection();

            // Update Number 2up
            dgvNumber2up.DataSource = getNumberXXXFromDB(BaseTypeID.up2);
            dgvNumber2up.ClearSelection();

            // Update Number 2low
            dgvNumber2low.DataSource = getNumberXXXFromDB(BaseTypeID.low2);
            dgvNumber2low.ClearSelection();

            // Update Number 3low
            dgvNumber3low.DataSource = getNumberXXXFromDB(BaseTypeID.low3);
            dgvNumber3low.ClearSelection();

            // udpate Number 1up
            dgvNumber1up.DataSource = getNumberXXXFromDB(BaseTypeID.up1);
            dgvNumber1up.ClearSelection();

            // update Number 1low
            dgvNumber1low.DataSource = getNumberXXXFromDB(BaseTypeID.low1);
            dgvNumber1low.ClearSelection();
        }
        private void showAllBuyingSummary()
        {
            // label for 3up
            lbPrice3up.Text = getNumberXXXPriceFromDB(BaseTypeID.up3).ToString("N0");
            // label for 2up
            lbPrice2up.Text = getNumberXXXPriceFromDB(BaseTypeID.up2).ToString("N0");
            // label for 2low
            lbPrice2low.Text = getNumberXXXPriceFromDB(BaseTypeID.low2).ToString("N0");
            // lable for 3low
            lbPrice3low.Text = getNumberXXXPriceFromDB(BaseTypeID.low3).ToString("N0");
            // lable for 1up
            lbPrice1up.Text = getNumberXXXPriceFromDB(BaseTypeID.up1).ToString("N0");
            // label for 1low
            lbPrice1low.Text = getNumberXXXPriceFromDB(BaseTypeID.low1).ToString("N0");
        }

        private void CloseWindows_Click(object sender, EventArgs e)
        {
            // Close Form
            this.Close();
        }

    }
}
