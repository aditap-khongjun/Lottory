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
using Microsoft.VisualBasic;

namespace Lottory
{
    public partial class AddNumberSetting : Form
    {
        private static AddNumberSetting _instance;
        public static AddNumberSetting Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new AddNumberSetting();
                return _instance;
            }

        }
        public static int BuyingLimit1 { get; set; }
        public static int BuyingLimit2 { get; set; }
        public static int BuyingLimit3 { get; set; }
        public static int BuyingLimit4 { get; set; }
        public static int BuyingLimit5 { get; set; }

        public AddNumberSetting()
        {
            InitializeComponent();

        }

        private void AddNumberSetting_FormClosed(object sender, FormClosedEventArgs e)
        {
            _instance = null;
        }

        private void AddNumberSetting_Load(object sender, EventArgs e)
        {
            // Read Money Limit Data from Database
            ReadMoneyLimitFromDB();
            // Read CustomerID from Database
            ReadCusotmerIDFromDB();

        }

        private void editMLim1_Click(object sender, EventArgs e)
        {
            string editMoney = Interaction.InputBox("วงเงินสำหรับ" + lbLimit1.Text, "แก้ไขวงเงิน", MoneyLimit1.Text);

            //change into TextBox
            MoneyLimit1.Text = editMoney;

            //change into MoneyLimit Database
            changeMoneyLimitDB(MoneyLimit1);
        }

        private void editMLim2_Click(object sender, EventArgs e)
        {
            string editMoney = Interaction.InputBox("วงเงินสำหรับ" + lbLimit2.Text, "แก้ไขวงเงิน", MoneyLimit2.Text);

            //change into TextBox
            MoneyLimit2.Text = editMoney;

            //change into MoneyLimit Database
            changeMoneyLimitDB(MoneyLimit2);
        }

        private void editMLim3_Click(object sender, EventArgs e)
        {
            string editMoney = Interaction.InputBox("วงเงินสำหรับ" + lbLimit3.Text, "แก้ไขวงเงิน", MoneyLimit3.Text);

            //change into TextBox
            MoneyLimit3.Text = editMoney;

            //change into MoneyLimit Database
            changeMoneyLimitDB(MoneyLimit3);

        }

        private void editMLim4_Click(object sender, EventArgs e)
        {
            string editMoney = Interaction.InputBox("วงเงินสำหรับ" + lbLimit4.Text, "แก้ไขวงเงิน", MoneyLimit4.Text);

            //change into TextBox
            MoneyLimit4.Text = editMoney;

            //change into MoneyLimit Database
            changeMoneyLimitDB(MoneyLimit4);
        }

        private void editMLim5_Click(object sender, EventArgs e)
        {
            string editMoney = Interaction.InputBox("วงเงินสำหรับ" + lbLimit5.Text, "แก้ไขวงเงิน", MoneyLimit5.Text);

            //change into TextBox
            MoneyLimit5.Text = editMoney;

            //change into MoneyLimit Database
            changeMoneyLimitDB(MoneyLimit5);
        }

        private void changeMoneyLimitDB(TextBox MoneyLimit)
        {
            // Connect Database
            SqlConnection connection = new SqlConnection(Database.CnnVal("LottoryDB"));

            if (connection.State == ConnectionState.Closed)
            {
                connection.Open(); // Open Database
            }

            // get Update Value
            string tbName = MoneyLimit.Name;
            string updateLimit = MoneyLimit.Text;

            string sqlstrcom = "UPDATE MoneyLimit ";
            sqlstrcom = string.Concat(sqlstrcom,"SET LimitMoney = " + "'" + updateLimit + "' " + "WHERE digitID = ");

            switch (tbName)
            {
                case "MoneyLimit1":
                    sqlstrcom = string.Concat(sqlstrcom,"1");
                    BuyingLimit1 = Convert.ToInt32(updateLimit);
                    break;
                case "MoneyLimit2":
                    sqlstrcom = string.Concat(sqlstrcom,"2");
                    BuyingLimit2 = Convert.ToInt32(updateLimit);
                    break;
                case "MoneyLimit3":
                    sqlstrcom = string.Concat(sqlstrcom,"3");
                    BuyingLimit3 = Convert.ToInt32(updateLimit);
                    break;
                case "MoneyLimit4":
                    sqlstrcom = string.Concat(sqlstrcom,"4");
                    BuyingLimit4 = Convert.ToInt32(updateLimit);
                    break;
                case "MoneyLimit5":
                    sqlstrcom = string.Concat(sqlstrcom,"5");
                    BuyingLimit5 = Convert.ToInt32(updateLimit);
                    break;
                default:
                    break;
            }

            // command
            SqlCommand sqlCommand = new SqlCommand(sqlstrcom, connection);
            sqlCommand.ExecuteNonQuery();
            connection.Close();
        }

        private void ReadMoneyLimitFromDB()
        {
            // Read Money Limit Data
            // Connect to Database
            SqlConnection connection = new SqlConnection(Database.CnnVal("LottoryDB"));

            if (connection.State == ConnectionState.Closed)
            {
                connection.Open(); // Open Database
            }

            // get LimitMoney
            string sqlStr = "SELECT digitID, LimitMoney FROM MoneyLimit";
            SqlCommand sqlcom = new SqlCommand(sqlStr, connection);
            SqlDataReader limitMoney = sqlcom.ExecuteReader();
            // take into TextBox
            while (limitMoney.Read())
            {
                int id = (int)limitMoney["digitID"];
                string moneyLimit = limitMoney["LimitMoney"].ToString();
                switch (id)
                {
                    case 1:
                        MoneyLimit1.Text = moneyLimit;
                        BuyingLimit1 = Convert.ToInt32(moneyLimit);
                        break;
                    case 2:
                        MoneyLimit2.Text = moneyLimit;
                        BuyingLimit2 = Convert.ToInt32(moneyLimit);
                        break;
                    case 3:
                        MoneyLimit3.Text = moneyLimit;
                        BuyingLimit3 = Convert.ToInt32(moneyLimit);
                        break;
                    case 4:
                        MoneyLimit4.Text = moneyLimit;
                        BuyingLimit4 = Convert.ToInt32(moneyLimit);
                        break;
                    case 5:
                        MoneyLimit5.Text = moneyLimit;
                        BuyingLimit5 = Convert.ToInt32(moneyLimit);
                        break;
                }
            }
            connection.Close();
        }
        private void ReadCusotmerIDFromDB()
        {
            
            SqlConnection connection = new SqlConnection(Database.CnnVal("LottoryDB"));

            if (connection.State == ConnectionState.Closed)
            {
                connection.Open(); // Open Database
            }

            // get customerID
            string sqlStr = "SELECT CustomerID FROM CustomerInfo";
            SqlCommand sqlcom = new SqlCommand(sqlStr, connection);
            SqlDataReader custIDdata = sqlcom.ExecuteReader();
            while (custIDdata.Read())
            {
                customerID.Items.Add(custIDdata["CustomerID"]);
            }
            connection.Close();
        }

        private void btBackToMain_Click(object sender, EventArgs e)
        {
            //Show MainMenu
            MainLotto mainLotto = (MainLotto)MdiParent;
            mainLotto.ShowForm(MainMenu.Instance);
        }
        private void CreateOrder()
        {
            if (string.IsNullOrEmpty(pageNumber.Text))
            {
                // Create new Order
                SqlConnection connection = new SqlConnection(Database.CnnVal("LottoryDB"));

                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open(); // Open Database
                }
                // get page all page number of customer
                string sqlgetPage = "SELECT Page FROM CustomerOrder WHERE CustomerID = '" + customerID.Text + "'";
                SqlCommand sqlgetPageCom = new SqlCommand(sqlgetPage, connection);
                SqlDataReader pageInfo = sqlgetPageCom.ExecuteReader();
                List<int> pageListInfo = new List<int>();

                while (pageInfo.Read())
                {
                    pageListInfo.Add((int)pageInfo["Page"]);
                }
                connection.Close();

                // find proper page
                int properPage = 0;
                for (int t_page = 1; t_page < 1000; t_page++)
                {
                    bool foundPage = false;
                    foreach (int pageList in pageListInfo)
                    {
                        if (t_page == pageList)
                        {
                            foundPage = true;
                        }
                    }
                    if (!foundPage)
                    {
                        properPage = t_page;
                        break;
                    }

                }
                // get customer name

                // Create new order
                CreateOrder(customerID.Text, Convert.ToString(properPage));
                // get OrderID 
                string orderID = getOrderID(customerID.Text, Convert.ToString(properPage));
                // get Customer name
                string customerName = getCustomerName(customerID.Text);
                // Open AddNumberDetail
                OpenAddNumberDetail(orderID, customerID.Text, Convert.ToString(properPage), customerName);


            }
            else
            {
                // find page in DB
                SqlConnection connection = new SqlConnection(Database.CnnVal("LottoryDB"));

                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open(); // Open Database
                }
                // check order from DB
                //string sqlCustomerOrder = "SELECT OrderID, CustomerID, Page FROM CustomerOrder WHERE (CustomerID = '" + customerID.Text + "') AND (Page = " + pageNumber.Text + ")";
                string sqlCustomerOrder = string.Format(@"SELECT OrderID, CustomerID, Page FROM CustomerOrder
                                                          WHERE CustomerID = '{0}' AND Page = {1}", customerID.Text, pageNumber.Text);
                SqlCommand sqlCustomerOrderCom = new SqlCommand(sqlCustomerOrder, connection);
                SqlDataReader customerOrderInfo = sqlCustomerOrderCom.ExecuteReader();
                if (customerOrderInfo.HasRows)
                {
                    // Found Order
                    // Use that Order
                    // get OrderID
                    string orderID = getOrderID(customerID.Text, pageNumber.Text);
                    // get Customer name
                    string customerName = getCustomerName(customerID.Text);
                    // Open AddNumberDetail
                    OpenAddNumberDetail(orderID, customerID.Text, pageNumber.Text, customerName);
                }
                else
                {
                    // Not found Order
                    // Create new Order
                    CreateOrder(customerID.Text, pageNumber.Text);
                    // get orderID
                    string orderID = getOrderID(customerID.Text, pageNumber.Text);
                    // get Customer name
                    string customerName = getCustomerName(customerID.Text);
                    // Open AddNumberDetail
                    OpenAddNumberDetail(orderID, customerID.Text, pageNumber.Text, customerName);
                    //this.Close();
                }
                connection.Close();
            }
        }
        private void btAddNumber_Click(object sender, EventArgs e)
        {
            if(CheckCorrectOrder())
            {
                // start create order
                CreateOrder();
            }
        }
        private bool CheckCorrectOrder()
        {
            bool correct = false;
            if(string.IsNullOrEmpty(customerID.Text))
            {

                MessageBox.Show("กรุณาใส่รหัสลูกค้า", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (!findCustomerIDinDB(customerID.Text))
            {
                MessageBox.Show("ไม่พบรหัสลูกค้าในฐานข้อมูล", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                correct = true;
            }
            return correct;
        }
        private bool findCustomerIDinDB(string customerid)
        {
            SqlConnection connection = new SqlConnection(Database.CnnVal("LottoryDB"));

            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            string getcustomerid = string.Format("SELECT CustomerID FROM CustomerInfo WHERE CustomerID = '{0}'", customerid);
            SqlCommand getcustomeridCom = new SqlCommand(getcustomerid, connection);
            SqlDataReader customerInfo = getcustomeridCom.ExecuteReader();
            if(customerInfo.HasRows)
            {
                connection.Close();
                return true;
            }
            else
            {
                connection.Close();
                return false;
            }
        }
        private string getCustomerName(string customerID)
        {
            string customerName = null;

            SqlConnection connection = new SqlConnection(Database.CnnVal("LottoryDB"));

            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            //string sqlgetCusName = "SELECT CustomerName FROM CustomerInfo WHERE CustomerID = '" + customerID + "'";
            string sqlgetCusName = string.Format(@"SELECT CustomerName FROM CustomerInfo 
                                                   WHERE CustomerID = '{0}'",customerID);
            SqlCommand sqlgetCusNameCom = new SqlCommand(sqlgetCusName, connection);
            SqlDataReader cusNameInfo = sqlgetCusNameCom.ExecuteReader();
            
            if (cusNameInfo.Read())
            {
                customerName = (string)cusNameInfo["CustomerName"];
            }
            connection.Close();

            return customerName;
        }
        private string getOrderID(string customerID, string pageNumber)
        {
            string orderID = null;
            SqlConnection connection = new SqlConnection(Database.CnnVal("LottoryDB"));

            if (connection.State == ConnectionState.Closed)
            {
                connection.Open(); // Open Database
            }
            //string sqlgetOrderID = "SELECT OrderID FROM CustomerOrder WHERE (CustomerID = '" + customerID + "') AND (Page = " + pageNumber + ")";
            string sqlgetOrderID = string.Format(@"SELECT OrderID FROM CustomerOrder 
                                                   WHERE CustomerID = '{0}' AND Page = {1}",customerID,pageNumber);

            SqlCommand sqlgetOrderIDCom = new SqlCommand(sqlgetOrderID, connection);
            SqlDataReader OrderIDInfo = sqlgetOrderIDCom.ExecuteReader();
            if(OrderIDInfo.Read())
            {
                orderID = Convert.ToString(OrderIDInfo["OrderID"]);
            }
            connection.Close();

            return orderID;
        }

        private void OpenAddNumberDetail(string orderID,string customerID, string pageNumber,string customerName)
        {
            AddNumberDetail addNumDetail = AddNumberDetail.Instance;
            addNumDetail.OrderID = orderID;
            addNumDetail.CustomerID = customerID;
            addNumDetail.Page = pageNumber;
            addNumDetail.lbCustomerID.Text = customerID;
            addNumDetail.lbCustomerName.Text = customerName;
            addNumDetail.lbPage.Text = pageNumber;
            addNumDetail.MdiParent = this.MdiParent;
            addNumDetail.Show();
            addNumDetail.Activate();
        }
        private void CreateOrder(string customerID,string pageNumber)
        {
            SqlConnection connection = new SqlConnection(Database.CnnVal("LottoryDB"));

            if (connection.State == ConnectionState.Closed)
            {
                connection.Open(); // Open Database
            }
            // Insert Order
            // string sqlInsertOrder = "INSERT INTO CustomerOrder(EmployeeID, CustomerID,Page) VALUES('" + Login.EmpolyeeID +"','" + customerID + "'," + pageNumber + ")";
            string sqlInsertOrder = string.Format(@"INSERT INTO CustomerOrder(EmployeeID, CustomerID,Page) 
                                                    VALUES('{0}','{1}',{2})",Login.EmpolyeeID,customerID,pageNumber);

            SqlCommand sqlInsertCom = new SqlCommand(sqlInsertOrder, connection);
            sqlInsertCom.ExecuteNonQuery();

            connection.Close();
        }

        private void customerID_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Enter:
                    pageNumber.Focus();
                    // get PageNumber from DB
                    updatePageNumber();
                    break;
            }
        }
        private void updatePageNumber()
        {
            SqlConnection connection = new SqlConnection(Database.CnnVal("LottoryDB"));

            if (connection.State == ConnectionState.Closed)
            {
                connection.Open(); // Open Database
            }
            // Insert Order
            List<string> pageList = new List<string>();
            string sqlgetAllPageNumber = string.Format("SELECT Page FROM CustomerOrder WHERE CustomerID = '{0}'",customerID.Text);
            SqlCommand sqlgetAllPageNumberCom = new SqlCommand(sqlgetAllPageNumber, connection);
            SqlDataReader PageNumberInfo = sqlgetAllPageNumberCom.ExecuteReader();
            while(PageNumberInfo.Read())
            {
                pageList.Add(PageNumberInfo["Page"].ToString());
            }
            connection.Close();
            pageNumber.DataSource = pageList;
            pageNumber.Text = string.Empty;
        }

        private void pageNumber_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Enter:
                    if (CheckCorrectOrder())
                    {
                        // start create order
                        CreateOrder();
                    }
                    break;
                case Keys.PageUp:
                    customerID.Focus();
                    customerID.SelectAll();
                    break;
            }
        }

        private void customerID_SelectedValueChanged(object sender, EventArgs e)
        {
            // update Page Number
            updatePageNumber();
        }

        private void pageNumber_TextChanged(object sender, EventArgs e)
        {
            int x;
            if(!Int32.TryParse(pageNumber.Text,out x) && !string.IsNullOrEmpty(pageNumber.Text))
            {
                MessageBox.Show("กรุณากำหนดเลขหน้าให้เป็นตัวเลข", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
