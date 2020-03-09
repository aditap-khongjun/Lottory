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
                    caption = "แก้ไข";
                    message = "แก้ไข้ข้อมูลลูกค้าเรียบร้อยแล้ว";
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
                                                           VALUES('{0}','{1}',{2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17},
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


    }
}
