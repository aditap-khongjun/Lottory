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
    public partial class CustomerInformation : Form
    {
        private Discount oldDiscount;
        private static CustomerInformation _instance;
        public static CustomerInformation Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new CustomerInformation();
                return _instance;
            }
        }
        private void CustomerInformation_FormClosed(object sender, FormClosedEventArgs e)
        {
            _instance = null;
        }
        public CustomerInformation()
        {
            InitializeComponent();
        }
        private struct Discount
        {
            public int dc_3up;
            public int dc_3low;
            public int dc_3freeup;
            public int dc_2up;
            public int dc_2low;
            public int dc_2freeup;
            public int dc_1freeup;
            public int dc_1front;
            public int dc_1center;
            public int dc_1back;
            public int dc_1freelow;
            public int dc_5free;
        }
        private struct CustomerStruct
        {
            public string customerID;
            public string customerName;
            public string limit_3freeup;
            public string limit_3up;
            public string limit_3low;
            public string limit_2up;
            public string limit_2low;
            public string limit_1freeup;
            public string limit_1freelow;
            public string winRate_3up;
            public string winRate_3low;
            public string winRate_3freeup;
            public string winRate_2up;
            public string winRate_2low;
            public string winRate_2freeup;
            public string winRate_1freeup;
            public string winRate_1front;
            public string winRate_1center;
            public string winRate_1back;
            public string winRate_1freelow;
            public string winRate_5free;
            public string dc_3up;
            public string dc_3low;
            public string dc_3freeup;
            public string dc_2up;
            public string dc_2low;
            public string dc_2freeup;
            public string dc_1freeup;
            public string dc_1front;
            public string dc_1center;
            public string dc_1back;
            public string dc_1freelow;
            public string dc_5free;
        }
        private CustomerStruct readCustomerInfoFromDB(SqlDataReader customerInfo)
        {
            CustomerStruct customerInfoOut = new CustomerStruct();
            // customer Info
            customerInfoOut.customerID = customerInfo["CustomerID"].ToString();
            customerInfoOut.customerName = customerInfo["CustomerName"].ToString();

            // Buying Limit
            customerInfoOut.limit_3freeup = customerInfo["limit_3freeup"].ToString();
            customerInfoOut.limit_3up = customerInfo["limit_3up"].ToString();
            customerInfoOut.limit_3low = customerInfo["limit_3low"].ToString();
            customerInfoOut.limit_2up = customerInfo["limit_2up"].ToString();
            customerInfoOut.limit_2low = customerInfo["limit_2low"].ToString();
            customerInfoOut.limit_1freeup = customerInfo["limit_1freeup"].ToString();
            customerInfoOut.limit_1freelow = customerInfo["limit_1freelow"].ToString();

            // payRate
            customerInfoOut.winRate_3up = customerInfo["winRate_3up"].ToString();
            customerInfoOut.winRate_3low = customerInfo["winRate_3low"].ToString();
            customerInfoOut.winRate_3freeup = customerInfo["winRate_3freeup"].ToString();
            customerInfoOut.winRate_2up = customerInfo["winRate_2up"].ToString();
            customerInfoOut.winRate_2low = customerInfo["winRate_2low"].ToString();
            customerInfoOut.winRate_2freeup = customerInfo["winRate_2freeup"].ToString();
            customerInfoOut.winRate_1freeup = customerInfo["winRate_1freeup"].ToString();
            customerInfoOut.winRate_1front = customerInfo["winRate_1front"].ToString();
            customerInfoOut.winRate_1center = customerInfo["winRate_1center"].ToString();
            customerInfoOut.winRate_1back = customerInfo["winRate_1back"].ToString();
            customerInfoOut.winRate_1freelow = customerInfo["winRate_1freelow"].ToString();
            customerInfoOut.winRate_5free = customerInfo["winRate_5free"].ToString();

            // discount
            customerInfoOut.dc_3up = customerInfo["dc_3up"].ToString();
            customerInfoOut.dc_3low = customerInfo["dc_3low"].ToString();
            customerInfoOut.dc_3freeup = customerInfo["dc_3freeup"].ToString();
            customerInfoOut.dc_2up = customerInfo["dc_2up"].ToString();
            customerInfoOut.dc_2low = customerInfo["dc_2low"].ToString();
            customerInfoOut.dc_2freeup = customerInfo["dc_2freeup"].ToString();
            customerInfoOut.dc_1freeup = customerInfo["dc_1freeup"].ToString();
            customerInfoOut.dc_1front = customerInfo["dc_1front"].ToString();
            customerInfoOut.dc_1center = customerInfo["dc_1center"].ToString();
            customerInfoOut.dc_1back = customerInfo["dc_1back"].ToString();
            customerInfoOut.dc_1freelow = customerInfo["dc_1freelow"].ToString();
            customerInfoOut.dc_5free = customerInfo["dc_5free"].ToString();

            return customerInfoOut;
        }

        private void updateCustomerInfoToForm(CustomerStruct customerInfo,bool ignore)
        {
            // Customer Infomation
            if(!ignore)
            {
                customerID.Text = customerInfo.customerID;
            }
            customerName.Text = customerInfo.customerName;

            // Buying Limit
            limit_3uptod.Text = customerInfo.limit_3freeup;
            limit_3up.Text = customerInfo.limit_3up;
            limit_3low.Text = customerInfo.limit_3low;
            limit_2up.Text = customerInfo.limit_2up;
            limit_2low.Text = customerInfo.limit_2low;
            limit_1up.Text = customerInfo.limit_1freeup;
            limit_1low.Text = customerInfo.limit_1freelow;

            // payRate
            payRate_3up.Text = customerInfo.winRate_3up;
            payRate_3low.Text = customerInfo.winRate_3low;
            payRate_3tod.Text = customerInfo.winRate_3freeup;
            payRate_2up.Text = customerInfo.winRate_2up;
            payRate_2low.Text = customerInfo.winRate_2low;
            payRate_2uptod.Text = customerInfo.winRate_2freeup;
            payRate_1up.Text = customerInfo.winRate_1freeup;
            payRate_1front.Text = customerInfo.winRate_1front;
            payRate_1center.Text = customerInfo.winRate_1center;
            payRate_1back.Text = customerInfo.winRate_1back;
            payRate_1low.Text = customerInfo.winRate_1freelow;
            payRate_5tod.Text = customerInfo.winRate_5free;

            // discount
            discount_3up.Text = customerInfo.dc_3up;
            discount_3low.Text = customerInfo.dc_3low;
            discount_3tod.Text = customerInfo.dc_3freeup;
            discount_2up.Text = customerInfo.dc_2up;
            discount_2low.Text = customerInfo.dc_2low;
            discount_2uptod.Text = customerInfo.dc_2freeup;
            discount_1up.Text = customerInfo.dc_1freeup;
            discount_1front.Text = customerInfo.dc_1front;
            discount_1center.Text = customerInfo.dc_1center;
            discount_1back.Text = customerInfo.dc_1back;
            discount_1low.Text = customerInfo.dc_1freelow;
            discount_5tod.Text = customerInfo.dc_5free;
        }

        private void Change_Click(object sender, EventArgs e)
        {
            Choose_customer_dialog chooseCustomerDialog = new Choose_customer_dialog();
            DialogResult dialogResult = chooseCustomerDialog.ShowDialog();
            if(dialogResult == DialogResult.OK)
            {
                // get customer infomation from DB
                SqlConnection connection = new SqlConnection(Database.CnnVal("LottoryDB"));
                if(connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                string sqlgetCustomerInfo = string.Format("SELECT * FROM CustomerInfo WHERE CustomerID = '{0}'", Choose_customer_dialog.CustomerID);
                SqlCommand sqlgetCustomerInfoCom = new SqlCommand(sqlgetCustomerInfo, connection);
                SqlDataReader customerInfo = sqlgetCustomerInfoCom.ExecuteReader();
                if (customerInfo.Read())
                {
                    // pack cusotmer infomation from DB
                    CustomerStruct customerData = readCustomerInfoFromDB(customerInfo);
                    // update customer information to Form
                    updateCustomerInfoToForm(customerData,false);
                }
                connection.Close();

            }
            else
            {
                // nothing to do
            }
        }

        private void Add_Click(object sender, EventArgs e)
        {
            // find customerID in DB
            SqlConnection connection = new SqlConnection(Database.CnnVal("LottoryDB"));
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            // check customerID to update or insert
            string sqlgetcustomerID = string.Format("SELECT CustomerID FROM CustomerInfo WHERE CustomerID = '{0}'", customerID.Text);
            SqlCommand sqlgetcustomerIDCom = new SqlCommand(sqlgetcustomerID, connection);
            SqlDataReader customerIDinfo = sqlgetcustomerIDCom.ExecuteReader();
            if(customerIDinfo.Read())
            {
                // found
                DialogResult save_result = MessageBox.Show("ต้องการบันทึกการแก้ไขข้อมูลลูกค้าหรือไม่", "Confirmation", MessageBoxButtons.YesNo);
                if(save_result == DialogResult.Yes)
                {
                    // save update
                    connection.Close();
                    // update to DB
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                    string sqlupdateCustomerInfo = string.Format(@"UPDATE CustomerInfo 
                                                               SET CustomerName = '{0}',
                                                                   dc_3up = {1}, dc_3low = {2}, dc_3freeup = {3}, dc_2up = {4}, dc_2low = {5}, dc_2freeup = {6},
                                                                   dc_1freeup = {7}, dc_1front = {8}, dc_1center = {9}, dc_1back = {10}, dc_1freelow = {11}, dc_5free = {12},
                                                                   limit_3freeup = {13}, limit_3up = {14}, limit_3low = {15}, limit_2up = {16}, limit_2low = {17}, limit_1freeup = {18}, limit_1freelow = {19},
                                                                   winRate_3up = {20}, winRate_3low = {21}, winRate_3freeup = {22}, winRate_2up = {23}, winRate_2low = {24}, winRate_2freeup = {25}, winRate_1freeup = {26},
                                                                   winRate_1front = {27}, winRate_1center = {28}, winRate_1back = {29}, winRate_1freelow = {30}, winRate_5free = {31}
                                                                WHERE CustomerID = '{32}'", customerName.Text, discount_3up.Text, discount_3low.Text, discount_3tod.Text, discount_2up.Text,
                                                                    discount_2low.Text, discount_2uptod.Text, discount_1up.Text, discount_1front.Text, discount_1center.Text, discount_1back.Text,
                                                                    discount_1low.Text, discount_5tod.Text, limit_3uptod.Text, limit_3up.Text, limit_3low.Text, limit_2up.Text, limit_2low.Text, limit_1up.Text,
                                                                    limit_1low.Text, payRate_3up.Text, payRate_3low.Text, payRate_3tod.Text, payRate_2up.Text, payRate_2low.Text, payRate_2uptod.Text, payRate_1up.Text,
                                                                    payRate_1front.Text, payRate_1center.Text, payRate_1back.Text, payRate_1low.Text, payRate_5tod.Text, customerID.Text);
                    SqlCommand sqlupdateCustomerInfoCom = new SqlCommand(sqlupdateCustomerInfo, connection);
                    sqlupdateCustomerInfoCom.ExecuteNonQuery();
                    connection.Close();

                    // Show Save status
                    string caption = "แก้ไข";
                    string message = "แก้ไข้ข้อมูลลูกค้าเรียบร้อยแล้ว";
                    MessageBox.Show(message, caption);
                }
                else
                {
                    // nothing to do
                }
            }
            else
            {
                // not found
                DialogResult save_result = MessageBox.Show("ต้องการบันทึกข้อมูลลูกค้าหรือไม่", "Confirmation", MessageBoxButtons.YesNo);
                if(save_result == DialogResult.Yes)
                {
                    // insert to DB
                    connection.Close();
                    //insert
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                    string sqlupdateCustomerInfo = string.Format(@"INSERT INTO CustomerInfo(CustomerID, CustomerName,
                                                           dc_3up, dc_3low, dc_3freeup, dc_2up, dc_2low, dc_2freeup, dc_1freeup, dc_1front, dc_1center, dc_1back, dc_1freelow, dc_5free,
                                                           limit_3freeup, limit_3up, limit_3low, limit_2up, limit_2low, limit_1freeup, limit_1freelow,
                                                           winRate_3up, winRate_3low, winRate_3freeup, winRate_2up, winRate_2low, winRate_2freeup, winRate_1freeup, winRate_1front, winRate_1center, winRate_1back, winRate_1freelow, winRate_5free) 
                                                           VALUES('{0}','{1}',{2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17},
                                                           {18}, {19}, {20}, {21}, {22}, {23}, {24}, {25}, {26}, {27}, {28}, {29}, {30}, {31}, {32})", customerID.Text, customerName.Text,
                                                               discount_3up.Text, discount_3low.Text, discount_3tod.Text, discount_2up.Text, discount_2low.Text, discount_2uptod.Text,
                                                               discount_1up.Text, discount_1front.Text, discount_1center.Text, discount_1back.Text, discount_1low.Text, discount_5tod.Text,
                                                               limit_3uptod.Text, limit_3up.Text, limit_3low.Text, limit_2up.Text, limit_2low.Text, limit_1up.Text, limit_1low.Text,
                                                               payRate_3up.Text, payRate_3low.Text, payRate_3tod.Text, payRate_2up.Text, payRate_2low.Text, payRate_2uptod.Text, payRate_1up.Text,
                                                               payRate_1front.Text, payRate_1center.Text, payRate_1back.Text, payRate_1low.Text, payRate_5tod.Text);
                    SqlCommand sqlupdateCustomerInfoCom = new SqlCommand(sqlupdateCustomerInfo, connection);
                    sqlupdateCustomerInfoCom.ExecuteNonQuery();
                    connection.Close();



                    // Show Save status
                    string caption = "บันทึก";
                    string message = "บันทึกข้อมูลลูกค้าเรียบร้อยแล้ว";
                    MessageBox.Show(message, caption);
                }
                else
                {
                    // nothing to do
                }
            }
            // Add New Customer

            customerID.Text = string.Empty;
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(customerID.Text))
            {
                // Save Customer Info to DB
                SqlConnection connection = new SqlConnection(Database.CnnVal("LottoryDB"));
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                // check customerID to update or insert
                string sqlgetcustomerID = string.Format("SELECT CustomerID FROM CustomerInfo WHERE CustomerID = '{0}'", customerID.Text);
                SqlCommand sqlgetcustomerIDCom = new SqlCommand(sqlgetcustomerID, connection);
                SqlDataReader customerIDinfo = sqlgetcustomerIDCom.ExecuteReader();
                string sqlupdateCustomerInfo;
                string message;
                string caption;
                if (customerIDinfo.Read())
                {
                    connection.Close();
                    //update
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                    sqlupdateCustomerInfo = string.Format(@"UPDATE CustomerInfo 
                                                               SET CustomerName = N'{0}',
                                                                   dc_3up = {1}, dc_3low = {2}, dc_3freeup = {3}, dc_2up = {4}, dc_2low = {5}, dc_2freeup = {6},
                                                                   dc_1freeup = {7}, dc_1front = {8}, dc_1center = {9}, dc_1back = {10}, dc_1freelow = {11}, dc_5free = {12},
                                                                   limit_3freeup = {13}, limit_3up = {14}, limit_3low = {15}, limit_2up = {16}, limit_2low = {17}, limit_1freeup = {18}, limit_1freelow = {19},
                                                                   winRate_3up = {20}, winRate_3low = {21}, winRate_3freeup = {22}, winRate_2up = {23}, winRate_2low = {24}, winRate_2freeup = {25}, winRate_1freeup = {26},
                                                                   winRate_1front = {27}, winRate_1center = {28}, winRate_1back = {29}, winRate_1freelow = {30}, winRate_5free = {31}
                                                                WHERE CustomerID = '{32}'", customerName.Text, discount_3up.Text, discount_3low.Text, discount_3tod.Text, discount_2up.Text,
                                                                    discount_2low.Text, discount_2uptod.Text, discount_1up.Text, discount_1front.Text, discount_1center.Text, discount_1back.Text,
                                                                    discount_1low.Text, discount_5tod.Text, limit_3uptod.Text, limit_3up.Text, limit_3low.Text, limit_2up.Text, limit_2low.Text, limit_1up.Text,
                                                                    limit_1low.Text, payRate_3up.Text, payRate_3low.Text, payRate_3tod.Text, payRate_2up.Text, payRate_2low.Text, payRate_2uptod.Text, payRate_1up.Text,
                                                                    payRate_1front.Text, payRate_1center.Text, payRate_1back.Text, payRate_1low.Text, payRate_5tod.Text, customerID.Text);
                    caption = "แก้ไข";
                    message = "แก้ไข้ข้อมูลลูกค้าเรียบร้อยแล้ว";

                    //update Discount
                    UpdateDiscountFromDB();
                   
                }
                else
                {
                    connection.Close();
                    //insert
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                    sqlupdateCustomerInfo = string.Format(@"INSERT INTO CustomerInfo(CustomerID, CustomerName,
                                                           dc_3up, dc_3low, dc_3freeup, dc_2up, dc_2low, dc_2freeup, dc_1freeup, dc_1front, dc_1center, dc_1back, dc_1freelow, dc_5free,
                                                           limit_3freeup, limit_3up, limit_3low, limit_2up, limit_2low, limit_1freeup, limit_1freelow,
                                                           winRate_3up, winRate_3low, winRate_3freeup, winRate_2up, winRate_2low, winRate_2freeup, winRate_1freeup, winRate_1front, winRate_1center, winRate_1back, winRate_1freelow, winRate_5free) 
                                                           VALUES('{0}',N'{1}',{2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17},
                                                           {18}, {19}, {20}, {21}, {22}, {23}, {24}, {25}, {26}, {27}, {28}, {29}, {30}, {31}, {32})", customerID.Text, customerName.Text,
                                                               discount_3up.Text, discount_3low.Text, discount_3tod.Text, discount_2up.Text, discount_2low.Text, discount_2uptod.Text,
                                                               discount_1up.Text, discount_1front.Text, discount_1center.Text, discount_1back.Text, discount_1low.Text, discount_5tod.Text,
                                                               limit_3uptod.Text, limit_3up.Text, limit_3low.Text, limit_2up.Text, limit_2low.Text, limit_1up.Text, limit_1low.Text,
                                                               payRate_3up.Text, payRate_3low.Text, payRate_3tod.Text, payRate_2up.Text, payRate_2low.Text, payRate_2uptod.Text, payRate_1up.Text,
                                                               payRate_1front.Text, payRate_1center.Text, payRate_1back.Text, payRate_1low.Text, payRate_5tod.Text);

                    caption = "บันทึก";
                    message = "บันทึกข้อมูลลูกค้าเรียบร้อยแล้ว";
                }
                SqlCommand sqlupdateCustomerInfoCom = new SqlCommand(sqlupdateCustomerInfo, connection);
                sqlupdateCustomerInfoCom.ExecuteNonQuery();
                connection.Close();

                // Show Save status
                MessageBox.Show(message, caption);
            }
            else
            {
                MessageBox.Show("กรุณาระบุรหัสลูกค้าที่ต้องการบันทึก", "บันทึกผิดพลาด");
            }

        }
        private void updateDiscount(int typeID)
        {
            SqlConnection connection = new SqlConnection(Database.CnnVal("LottoryDB"));
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            // get orderlist ID
            string getOrderList = string.Format(@"SELECT DISTINCT o.OrderListID,o.TypeID 
                                                  FROM ((CustomerOrder c INNER JOIN OrderList o ON c.OrderID = o.OrderID)
                                                  INNER JOIN OrderListExpand oe ON o.OrderListID = oe.OrderListID)
                                                  WHERE BINARY_CHECKSUM(c.CustomerID) = BINARY_CHECKSUM('{0}') AND o.TypeID = {1}", customerID.Text, typeID.ToString());
            SqlCommand getOrderListCom = new SqlCommand(getOrderList, connection);
            SqlDataReader orderListInfo = getOrderListCom.ExecuteReader();
            while(orderListInfo.Read())
            {
                //update table
                int orderListID = Convert.ToInt32(orderListInfo["OrderListID"]);
                int tID = Convert.ToInt32(orderListInfo["TypeID"]);

                //get Discount
                double discount = getDiscount(tID);
                updateTable(orderListID, (discount / 100));
                
            }
        }
        
        private void updateDiscountOnlyUp(int typeID)
        {
            SqlConnection connection = new SqlConnection(Database.CnnVal("LottoryDB"));
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            // get orderlist ID
            string getOrderList = string.Format(@"SELECT DISTINCT o.OrderListID,o.TypeID,o.Price 
                                                  FROM ((CustomerOrder c INNER JOIN OrderList o ON c.OrderID = o.OrderID)
                                                  INNER JOIN OrderListExpand oe ON o.OrderListID = oe.OrderListID)
                                                  WHERE BINARY_CHECKSUM(c.CustomerID) = BINARY_CHECKSUM('{0}') AND o.TypeID = {1}", customerID.Text, typeID.ToString());
            SqlCommand getOrderListCom = new SqlCommand(getOrderList, connection);
            SqlDataReader orderListInfo = getOrderListCom.ExecuteReader();
            while (orderListInfo.Read())
            {
                double discount = 0;
                switch(typeID)
                {
                    case BaseTypeID.uptod2:
                        //get Discount
                        discount = getDiscount(BaseTypeID.up2);
                        break;
                    case BaseTypeID.uptod3:
                        discount = getDiscount(BaseTypeID.up3);
                        break;
                }
                int Price = Convert.ToInt32(orderListInfo["Price"]);
                int orderListID = Convert.ToInt32(orderListInfo["OrderListID"]);
                updateTableOnlyUp(orderListID, Price * (discount / 100), Price);
            }
        }
        private void updateDiscountOnlyTod(int typeID)
        {
            SqlConnection connection = new SqlConnection(Database.CnnVal("LottoryDB"));
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            // get orderlist ID
            string getOrderList = string.Format(@"SELECT DISTINCT o.OrderListID,o.TypeID,o.Price 
                                                  FROM ((CustomerOrder c INNER JOIN OrderList o ON c.OrderID = o.OrderID)
                                                  INNER JOIN OrderListExpand oe ON o.OrderListID = oe.OrderListID)
                                                  WHERE BINARY_CHECKSUM(c.CustomerID) = BINARY_CHECKSUM('{0}') AND o.TypeID = {1}", customerID.Text, typeID.ToString());
            SqlCommand getOrderListCom = new SqlCommand(getOrderList, connection);
            SqlDataReader orderListInfo = getOrderListCom.ExecuteReader();
            while (orderListInfo.Read())
            {
                double discount = 0;
                switch (typeID)
                {
                    case BaseTypeID.uptod2:
                        discount = getDiscount(BaseTypeID.tod2);
                        break;
                    case BaseTypeID.uptod3:
                        discount = getDiscount(BaseTypeID.tod3);
                        break;
                }
                int Price = Convert.ToInt32(orderListInfo["Price"]);
                int orderListID = Convert.ToInt32(orderListInfo["OrderListID"]);
                updateTableOnlyTod(orderListID, (discount / 100), Price);
            }
        }
        private int getDiscount(int typeID)
        {
            int discount;
            switch (typeID)
            {
                case BaseTypeID.up3:
                case BaseTypeID.group3:
                case BaseTypeID.group4:
                case BaseTypeID.group5:
                case BaseTypeID.door543:
                case BaseTypeID.tgroup3:
                    discount = Convert.ToInt32(discount_3up.Text);
                    break;
                case BaseTypeID.low3:
                case BaseTypeID.lowgroup3:
                    discount = Convert.ToInt32(discount_3low.Text);
                    break;
                case BaseTypeID.tod3:
                    discount = Convert.ToInt32(discount_3tod.Text);
                    break;
                case BaseTypeID.up2:
                case BaseTypeID.ht2:
                case BaseTypeID.hu2:
                case BaseTypeID.door19up2:
                    discount = Convert.ToInt32(discount_2up.Text);
                    break;
                case BaseTypeID.low2:
                case BaseTypeID.door19low2:
                    discount = Convert.ToInt32(discount_2low.Text);
                    break;
                case BaseTypeID.tod2:
                    discount = Convert.ToInt32(discount_2uptod.Text);
                    break;
                case BaseTypeID.up1:
                    discount = Convert.ToInt32(discount_1up.Text);
                    break;
                case BaseTypeID.upfront1:
                    discount = Convert.ToInt32(discount_1front.Text);
                    break;
                case BaseTypeID.upcenter1:
                    discount = Convert.ToInt32(discount_1center.Text);
                    break;
                case BaseTypeID.upback1:
                    discount = Convert.ToInt32(discount_1back.Text);
                    break;
                case BaseTypeID.low1:
                case BaseTypeID.lowfront1:
                case BaseTypeID.lowback1:
                    discount = Convert.ToInt32(discount_1low.Text);
                    break;
                case BaseTypeID.tod5:
                    discount = Convert.ToInt32(discount_5tod.Text);
                    break;
                default:
                    discount = 0;
                    MessageBox.Show(string.Format("get Discount Error from typeID = {0}", typeID.ToString()), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
            return discount;
        }
        private void updateTable(int OrderListID, double discount)
        {
            SqlConnection connection = new SqlConnection(Database.CnnVal("LottoryDB"));
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            // update orderList
            string updateOrderList = string.Format(@"UPDATE OrderListExpand
                                                     SET DiscPrice = OwnPrice*{1}
                                                     WHERE OrderListID = {0}", OrderListID.ToString(), discount.ToString());
            SqlCommand updateOrderListCom = new SqlCommand(updateOrderList, connection);
            updateOrderListCom.ExecuteNonQuery();
            connection.Close();
        }
        private void updateTableOnlyUp(int OrderListID, double discUpdate, int OwnPrice)
        {
            SqlConnection connection = new SqlConnection(Database.CnnVal("LottoryDB"));
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            // update orderList
            string updateOrderList = string.Format(@"UPDATE OrderListExpand
                                                     SET DiscPrice = {1}
                                                     WHERE OrderListID = {0} AND OwnPrice = {2}", OrderListID.ToString(), discUpdate.ToString(),OwnPrice.ToString());
            SqlCommand updateOrderListCom = new SqlCommand(updateOrderList, connection);
            updateOrderListCom.ExecuteNonQuery();
            connection.Close();
        }
        private void updateTableOnlyTod(int OrderListID, double discount, int Price)
        {
            SqlConnection connection = new SqlConnection(Database.CnnVal("LottoryDB"));
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            // update orderList
            string updateOrderList = string.Format(@"UPDATE OrderListExpand
                                                     SET DiscPrice = OwnPrice*{1}
                                                     WHERE OrderListID = {0} AND OwnPrice != {2}", OrderListID.ToString(), discount.ToString(), Price.ToString());
            SqlCommand updateOrderListCom = new SqlCommand(updateOrderList, connection);
            updateOrderListCom.ExecuteNonQuery();
            connection.Close();
        }
        private void UpdateDiscountFromDB()
        {
            // for 1up
            if(oldDiscount.dc_1freeup != Convert.ToInt32(discount_1up.Text))
            {
                updateDiscount(BaseTypeID.up1);
            }
            // for 1front
            if (oldDiscount.dc_1front != Convert.ToInt32(discount_1front.Text))
            {
                updateDiscount(BaseTypeID.upfront1);
            }
            // for 1center
            if (oldDiscount.dc_1center != Convert.ToInt32(discount_1center.Text))
            {
                updateDiscount(BaseTypeID.upcenter1);
            }
            // for 1back
            if (oldDiscount.dc_1back != Convert.ToInt32(discount_1back.Text))
            {
                updateDiscount(BaseTypeID.upback1);
            }
            // for 2up
            if (oldDiscount.dc_2up != Convert.ToInt32(discount_2up.Text))
            {
                updateDiscount(BaseTypeID.up2);
                updateDiscountOnlyUp(BaseTypeID.uptod2); // only 2up
                updateDiscount(BaseTypeID.ht2);
                updateDiscount(BaseTypeID.hu2);
                updateDiscount(BaseTypeID.door62);
                updateDiscount(BaseTypeID.door19up2);
            }
            // for 2low
            if (oldDiscount.dc_2low != Convert.ToInt32(discount_2low.Text))
            {
                updateDiscount(BaseTypeID.low2);
                updateDiscount(BaseTypeID.door19low2);
            }
            // for 2tod
            if (oldDiscount.dc_2freeup != Convert.ToInt32(discount_2uptod.Text))
            {
                updateDiscount(BaseTypeID.tod2);
                updateDiscountOnlyTod(BaseTypeID.uptod2); // only Tod
            }
            // for 3up
            if (oldDiscount.dc_3up != Convert.ToInt32(discount_3up.Text))
            {
                updateDiscount(BaseTypeID.up3);
                updateDiscountOnlyUp(BaseTypeID.uptod3);
                updateDiscount(BaseTypeID.group3);
                updateDiscount(BaseTypeID.door543);
                updateDiscount(BaseTypeID.tgroup3);
                updateDiscount(BaseTypeID.group4);
                updateDiscount(BaseTypeID.group5);
            }
            // for 3low
            if (oldDiscount.dc_3low != Convert.ToInt32(discount_3low.Text))
            {
                updateDiscount(BaseTypeID.low3);
                updateDiscount(BaseTypeID.lowgroup3);
            }
            // for 3tod
            if (oldDiscount.dc_3freeup != Convert.ToInt32(discount_3tod.Text))
            {
                updateDiscount(BaseTypeID.tod3);
                updateDiscountOnlyTod(BaseTypeID.uptod3);
            }
            // for 5tod
            if (oldDiscount.dc_5free != Convert.ToInt32(discount_5tod.Text))
            {
                updateDiscount(BaseTypeID.tod5);
            }
            // for 1low
            if (oldDiscount.dc_1freelow != Convert.ToInt32(discount_1low.Text))
            {
                updateDiscount(BaseTypeID.low1);
                updateDiscount(BaseTypeID.lowfront1);
                updateDiscount(BaseTypeID.lowback1);
            }

            // update old discount
            updateOldDiscount();
        }
        private void correct_checking(object sender, EventArgs e)
        {
            // correct numeric checking when text is always changed
            TextBox tbData = (TextBox)sender;
            if(!string.IsNullOrEmpty(tbData.Text))
            {
                if (!IsValidData(tbData.Text))
                {
                    MessageBox.Show("กรุณากรอกข้อมูลเป็นตัวเลขเท่านั้น");
                    tbData.SelectAll();
                }
            }
        }
        private void select_all_click(object sender, EventArgs e)
        {
            // select all when textbox is always click
            TextBox tbData = (TextBox)sender;
            if(!string.IsNullOrEmpty(tbData.Text))
            {
                tbData.SelectAll();
            }
        }
        private bool IsValidData(string value)
        {
            double x;
            if ((double.TryParse(value, out x)))
            {
                // Yes is Numeric
                return true;
            }
            else
            {
                // No is not Numeric
                return false;
            }
        }

        private void CustomerInformation_Load(object sender, EventArgs e)
        {

        }
        
        private void customerID_Change(object sender, EventArgs e)
        {
            // Enable Delect Button
            //
            // get customerID from DB
            SqlConnection connection = new SqlConnection(Database.CnnVal("LottoryDB"));
            if(connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            string sqlgetcustomerInfo = "SELECT * FROM CustomerInfo";
            SqlCommand sqlgetcustomerInfoCom = new SqlCommand(sqlgetcustomerInfo, connection);
            SqlDataReader customerInfo = sqlgetcustomerInfoCom.ExecuteReader();
            bool foundID = false;
            //string t_customerID = string.Empty;
            CustomerStruct custInfo = new CustomerStruct();
            while(customerInfo.Read())
            {
                // check customerID is in DB or not?
                if (string.Equals(customerInfo["CustomerID"].ToString(),customerID.Text))
                {
                    foundID |= true;
                    
                    // get customer infomation from DB
                    custInfo = readCustomerInfoFromDB(customerInfo);

                    // get Old Discount
                    getOldDiscount(custInfo);
                    
                }
            }
            connection.Close();

            if(foundID)
            {
                // Enable delete button
                Delete.Enabled = true;

                // Auto complete customer infomation
                updateCustomerInfoToForm(custInfo, true);
                
            }
            else
            {
                // Disable delect button
                Delete.Enabled = false;

                // Clear customer information
                clear_CustomerInfo();
            }

        }
        private void getOldDiscount(CustomerStruct custInfo)
        {
            oldDiscount.dc_1freeup = Convert.ToInt32(custInfo.dc_1freeup);
            oldDiscount.dc_1front = Convert.ToInt32(custInfo.dc_1front);
            oldDiscount.dc_1center = Convert.ToInt32(custInfo.dc_1center);
            oldDiscount.dc_1back = Convert.ToInt32(custInfo.dc_1back);
            oldDiscount.dc_2up = Convert.ToInt32(custInfo.dc_2up);
            oldDiscount.dc_2low = Convert.ToInt32(custInfo.dc_2low);
            oldDiscount.dc_2freeup = Convert.ToInt32(custInfo.dc_2freeup);
            oldDiscount.dc_3up = Convert.ToInt32(custInfo.dc_3up);
            oldDiscount.dc_3low = Convert.ToInt32(custInfo.dc_3low);
            oldDiscount.dc_3freeup = Convert.ToInt32(custInfo.dc_3freeup);
            oldDiscount.dc_5free = Convert.ToInt32(custInfo.dc_5free);
            oldDiscount.dc_1freelow = Convert.ToInt32(custInfo.dc_1freelow);

        }
        private void updateOldDiscount()
        {
            oldDiscount.dc_1freeup = Convert.ToInt32(discount_1up.Text);
            oldDiscount.dc_1front = Convert.ToInt32(discount_1front.Text);
            oldDiscount.dc_1center = Convert.ToInt32(discount_1center.Text);
            oldDiscount.dc_1back = Convert.ToInt32(discount_1back.Text);
            oldDiscount.dc_2up = Convert.ToInt32(discount_2up.Text);
            oldDiscount.dc_2low = Convert.ToInt32(discount_2low.Text);
            oldDiscount.dc_2freeup = Convert.ToInt32(discount_2uptod.Text);
            oldDiscount.dc_3up = Convert.ToInt32(discount_3up.Text);
            oldDiscount.dc_3low = Convert.ToInt32(discount_3low.Text);
            oldDiscount.dc_3freeup = Convert.ToInt32(discount_3tod.Text);
            oldDiscount.dc_5free = Convert.ToInt32(discount_5tod.Text);
            oldDiscount.dc_1freelow = Convert.ToInt32(discount_1low.Text);
        }
        private void clear_CustomerInfo()
        {
            // customer Info
            customerName.Text = string.Empty;

            // Buying Limit
            limit_3uptod.Text = Convert.ToString(0);
            limit_3up.Text = Convert.ToString(0);
            limit_3low.Text = Convert.ToString(0);
            limit_2up.Text = Convert.ToString(0);
            limit_2low.Text = Convert.ToString(0);
            limit_1up.Text = Convert.ToString(0);
            limit_1low.Text = Convert.ToString(0);

            // payRate
            payRate_3up.Text = Convert.ToString(0);
            payRate_3low.Text = Convert.ToString(0);
            payRate_3tod.Text = Convert.ToString(0);
            payRate_2up.Text = Convert.ToString(0);
            payRate_2low.Text = Convert.ToString(0);
            payRate_2uptod.Text = Convert.ToString(0);
            payRate_1up.Text = Convert.ToString(0);
            payRate_1front.Text = Convert.ToString(0);
            payRate_1center.Text = Convert.ToString(0);
            payRate_1back.Text = Convert.ToString(0);
            payRate_1low.Text = Convert.ToString(0);
            payRate_5tod.Text = Convert.ToString(0);

            // discount
            discount_3up.Text = Convert.ToString(0);
            discount_3low.Text = Convert.ToString(0);
            discount_3tod.Text = Convert.ToString(0);
            discount_2up.Text = Convert.ToString(0);
            discount_2low.Text = Convert.ToString(0);
            discount_2uptod.Text = Convert.ToString(0);
            discount_1up.Text = Convert.ToString(0);
            discount_1front.Text = Convert.ToString(0);
            discount_1center.Text = Convert.ToString(0);
            discount_1back.Text = Convert.ToString(0);
            discount_1low.Text = Convert.ToString(0);
            discount_5tod.Text = Convert.ToString(0);
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            DialogResult delete_result = MessageBox.Show(string.Format("ต้องการลบข้อมูลลูกค้ารหัส {0} ไช่หรือไม่", customerID.Text), "Confirmation", MessageBoxButtons.YesNo);
            if(delete_result == DialogResult.Yes)
            {
                // Delete Customer infomation from DB
                SqlConnection connection = new SqlConnection(Database.CnnVal("LottoryDB"));
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                string sqldeleteCustomerID = string.Format("DELETE FROM CustomerInfo WHERE CustomerID = '{0}'", customerID.Text);
                SqlCommand sqldeleteCutomerIDCom = new SqlCommand(sqldeleteCustomerID, connection);
                sqldeleteCutomerIDCom.ExecuteNonQuery();
                connection.Close();

                // Show Delete completion
                MessageBox.Show(string.Format("ลบข้อมูลของลูกค้ารหัส {0} เรียบร้อยแล้ว", customerID.Text), "ลบข้อมูล");
            }
            else
            {
                // nothing to do
            }
            
        }

        private void toMain_Click(object sender, EventArgs e)
        {
            //Show MainMenu
            MainLotto mainLotto = (MainLotto)MdiParent;
            mainLotto.ShowForm(MainMenu.Instance);
        }

        private void initial_value_Click(object sender, EventArgs e)
        {
            // initial value for
            //
            // payRate
            payRate_3up.Text = Convert.ToString(550);
            payRate_3low.Text = Convert.ToString(100);
            payRate_3tod.Text = Convert.ToString(100);
            payRate_2up.Text = Convert.ToString(70);
            payRate_2low.Text = Convert.ToString(70);
            payRate_2uptod.Text = Convert.ToString(10);
            payRate_1up.Text = Convert.ToString(3);
            payRate_1front.Text = Convert.ToString(8);
            payRate_1center.Text = Convert.ToString(8);
            payRate_1back.Text = Convert.ToString(8);
            payRate_1low.Text = Convert.ToString(4);
            payRate_5tod.Text = Convert.ToString(10);


        }

        private void textBox_Move(object sender, KeyEventArgs e)
        {
            TextBox tbInfo = (TextBox)sender;
            switch(e.KeyCode)
            {
                case Keys.Enter:
                case Keys.Down:
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    textBoxForword(tbInfo.Name);
                    break;
                case Keys.Up:
                    textBoxBackword(tbInfo.Name);
                    break;
            }
        }

        private void textBoxBackword(string tbName)
        {
            switch (tbName)
            {
                case "customerID":
                    discount_1low.Focus();
                    discount_1low.SelectAll();
                    break;
                case "customerName":
                    customerID.Focus();
                    customerID.SelectAll();
                    break;
                case "limit_3uptod":
                    customerName.Focus();
                    customerName.SelectAll();
                    break;
                case "limit_3up":
                    limit_3uptod.Focus();
                    limit_3uptod.SelectAll();
                    break;
                case "limit_3low":
                    limit_3up.Focus();
                    limit_3up.SelectAll();
                    break;
                case "limit_2up":
                    limit_3low.Focus();
                    limit_3low.SelectAll();
                    break;
                case "limit_2low":
                    limit_2up.Focus();
                    limit_2up.SelectAll();
                    break;
                case "limit_1up":
                    limit_2low.Focus();
                    limit_2low.SelectAll();
                    break;
                case "limit_1low":
                    limit_1up.Focus();
                    limit_1up.SelectAll();
                    break;
                case "payRate_1up":
                    limit_1low.Focus();
                    limit_1low.SelectAll();
                    break;
                case "payRate_1front":
                    payRate_1up.Focus();
                    payRate_1up.SelectAll();
                    break;
                case "payRate_1center":
                    payRate_1front.Focus();
                    payRate_1front.SelectAll();
                    break;
                case "payRate_1back":
                    payRate_1center.Focus();
                    payRate_1center.SelectAll();
                    break;
                case "payRate_2up":
                    payRate_1back.Focus();
                    payRate_1back.SelectAll();
                    break;
                case "payRate_2low":
                    payRate_2up.Focus();
                    payRate_2up.SelectAll();
                    break;
                case "payRate_2uptod":
                    payRate_2low.Focus();
                    payRate_2low.SelectAll();
                    break;
                case "payRate_3up":
                    payRate_2uptod.Focus();
                    payRate_2uptod.SelectAll();
                    break;
                case "payRate_3low":
                    payRate_3up.Focus();
                    payRate_3up.SelectAll();
                    break;
                case "payRate_3tod":
                    payRate_3low.Focus();
                    payRate_3low.SelectAll();
                    break;
                case "payRate_5tod":
                    payRate_3tod.Focus();
                    payRate_3tod.SelectAll();
                    break;
                case "payRate_1low":
                    payRate_5tod.Focus();
                    payRate_5tod.SelectAll();
                    break;
                case "discount_1up":
                    payRate_1low.Focus();
                    payRate_1low.SelectAll();
                    break;
                case "discount_1front":
                    discount_1up.Focus();
                    discount_1up.SelectAll();
                    break;
                case "discount_1center":
                    discount_1front.Focus();
                    discount_1front.SelectAll();
                    break;
                case "discount_1back":
                    discount_1center.Focus();
                    discount_1center.SelectAll();
                    break;
                case "discount_2up":
                    discount_1back.Focus();
                    discount_1back.SelectAll();
                    break;
                case "discount_2low":
                    discount_2up.Focus();
                    discount_2up.SelectAll();
                    break;
                case "discount_2uptod":
                    discount_2low.Focus();
                    discount_2low.SelectAll();
                    break;
                case "discount_3up":
                    discount_2uptod.Focus();
                    discount_2uptod.SelectAll();
                    break;
                case "discount_3low":
                    discount_3up.Focus();
                    discount_3up.SelectAll();
                    break;
                case "discount_3tod":
                    discount_3low.Focus();
                    discount_3low.SelectAll();
                    break;
                case "discount_5tod":
                    discount_3tod.Focus();
                    discount_3tod.SelectAll();
                    break;
                case "discount_1low":
                    discount_5tod.Focus();
                    discount_5tod.SelectAll();
                    break;

            }
        }

        private void textBoxForword(string tbName)
        {
            switch(tbName)
            {
                case "customerID":
                    customerName.Focus();
                    customerName.SelectAll();
                    break;
                case "customerName":
                    limit_3uptod.Focus();
                    limit_3uptod.SelectAll();
                    break;
                case "limit_3uptod":
                    limit_3up.Focus();
                    limit_3up.SelectAll();
                    break;
                case "limit_3up":
                    limit_3low.Focus();
                    limit_3low.SelectAll();
                    break;
                case "limit_3low":
                    limit_2up.Focus();
                    limit_2up.SelectAll();
                    break;
                case "limit_2up":
                    limit_2low.Focus();
                    limit_2low.SelectAll();
                    break;
                case "limit_2low":
                    limit_1up.Focus();
                    limit_1up.SelectAll();
                    break;
                case "limit_1up":
                    limit_1low.Focus();
                    limit_1low.SelectAll();
                    break;
                case "limit_1low":
                    payRate_1up.Focus();
                    payRate_1up.SelectAll();
                    break;
                case "payRate_1up":
                    payRate_1front.Focus();
                    payRate_1front.SelectAll();
                    break;
                case "payRate_1front":
                    payRate_1center.Focus();
                    payRate_1center.SelectAll();
                    break;
                case "payRate_1center":
                    payRate_1back.Focus();
                    payRate_1back.SelectAll();
                    break;
                case "payRate_1back":
                    payRate_2up.Focus();
                    payRate_2up.SelectAll();
                    break;
                case "payRate_2up":
                    payRate_2low.Focus();
                    payRate_2low.SelectAll();
                    break;
                case "payRate_2low":
                    payRate_2uptod.Focus();
                    payRate_2uptod.SelectAll();
                    break;
                case "payRate_2uptod":
                    payRate_3up.Focus();
                    payRate_3up.SelectAll();
                    break;
                case "payRate_3up":
                    payRate_3low.Focus();
                    payRate_3low.SelectAll();
                    break;
                case "payRate_3low":
                    payRate_3tod.Focus();
                    payRate_3tod.SelectAll();
                    break;
                case "payRate_3tod":
                    payRate_5tod.Focus();
                    payRate_5tod.SelectAll();
                    break;
                case "payRate_5tod":
                    payRate_1low.Focus();
                    payRate_1low.SelectAll();
                    break;
                case "payRate_1low":
                    discount_1up.Focus();
                    discount_1up.SelectAll();
                    break;
                case "discount_1up":
                    discount_1front.Focus();
                    discount_1front.SelectAll();
                    break;
                case "discount_1front":
                    discount_1center.Focus();
                    discount_1center.SelectAll();
                    break;
                case "discount_1center":
                    discount_1back.Focus();
                    discount_1back.SelectAll();
                    break;
                case "discount_1back":
                    discount_2up.Focus();
                    discount_2up.SelectAll();
                    break;
                case "discount_2up":
                    discount_2low.Focus();
                    discount_2low.SelectAll();
                    break;
                case "discount_2low":
                    discount_2uptod.Focus();
                    discount_2uptod.SelectAll();
                    break;
                case "discount_2uptod":
                    discount_3up.Focus();
                    discount_3up.SelectAll();
                    break;
                case "discount_3up":
                    discount_3low.Focus();
                    discount_3low.SelectAll();
                    break;
                case "discount_3low":
                    discount_3tod.Focus();
                    discount_3tod.SelectAll();
                    break;
                case "discount_3tod":
                    discount_5tod.Focus();
                    discount_5tod.SelectAll();
                    break;
                case "discount_5tod":
                    discount_1low.Focus();
                    discount_1low.SelectAll();
                    break;
                case "discount_1low":
                    customerID.Focus();
                    customerID.SelectAll();
                    break;
            }
        }
    }
}
