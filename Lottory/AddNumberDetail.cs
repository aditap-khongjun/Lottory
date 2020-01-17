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
    public partial class AddNumberDetail : Form
    {
        private static AddNumberDetail _instance;
        public static AddNumberDetail Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new AddNumberDetail();
                return _instance;
            }
        }

        public string OrderID { get; set; }
        public string CustomerID { get; set; }
        public string Page { get; set; }

        // Win Rate for each customer
        public int WinRate3up { get; set; }
        public int WinRate3low { get; set; }
        public int WinRate3freeup { get; set; }
        public int WinRate2up { get; set; }
        public int WinRate2low { get; set; }
        public int WinRate2freeup { get; set; }
        public int WinRate1freeup { get; set; }
        public int WinRate1front { get; set; }
        public int WinRate1center { get; set; }
        public int WinRate1back { get; set; }
        public int WinRate1freelow { get; set; }
        public int WinRate5free { get; set; }

        // discount for each customer
        public int dc_3up { get; set; }
        public int dc_3low { get; set; }
        public int dc_3freeup { get; set; }
        public int dc_2up { get; set; }
        public int dc_2low { get; set; }
        public int dc_2freeup { get; set; }
        public int dc_1freeup { get; set; }
        public int dc_1front { get; set; }
        public int dc_1center { get; set; }
        public int dc_1back { get; set; }
        public int dc_1freelow { get; set; }
        public int dc_5free { get; set; }

        // Buying Limit for each customer
        public int limit_3freeup { get; set; }
        public int limit_3up { get; set; }
        public int limit_3low { get; set; }
        public int limit_2up { get; set; }
        public int limit_2low { get; set; }
        public int limit_1freeup { get; set; }
        public int limit_1freelow { get; set; }
        private int PreviousState { get; set; }

        private void checkMoneyTextState()
        {
            if((tbMoney1.Enabled == true) && (tbMoney2.Enabled == false))
            {
                this.PreviousState = 1;
            }
            else if((tbMoney1.Enabled = true) && (tbMoney2.Enabled = true))
            {
                this.PreviousState = 2;
            }
            else if((tbMoney1.Enabled = false) && (tbMoney2.Enabled = true))
            {
                this.PreviousState = 3;
            }
        }
        private void initialCustomerInfo()
        {
            SqlConnection connection = new SqlConnection(Database.CnnVal("LottoryDB"));

            if (connection.State == ConnectionState.Closed)
            {
                connection.Open(); // Open Database
            }
            string sqlgetCustomerInfo = string.Format("SELECT * FROM CustomerInfo WHERE CustomerID = {0}", this.CustomerID);
            SqlCommand sqlgetCustomerInfoCom = new SqlCommand(sqlgetCustomerInfo, connection);
            SqlDataReader CustomerInfo = sqlgetCustomerInfoCom.ExecuteReader();
            while(CustomerInfo.Read())
            {
                // WinRate
                this.WinRate3up = Convert.ToInt32(CustomerInfo["winRate_3up"]);
                this.WinRate3low = Convert.ToInt32(CustomerInfo["winRate_3low"]);
                this.WinRate3freeup = Convert.ToInt32(CustomerInfo["winRate_3freeup"]);
                this.WinRate2up = Convert.ToInt32(CustomerInfo["winRate_2up"]);
                this.WinRate2low = Convert.ToInt32(CustomerInfo["winRate_2low"]);
                this.WinRate2freeup = Convert.ToInt32(CustomerInfo["winRate_2freeup"]);
                this.WinRate1freeup = Convert.ToInt32(CustomerInfo["winRate_1freeup"]);
                this.WinRate1front = Convert.ToInt32(CustomerInfo["winRate_1front"]);
                this.WinRate1center = Convert.ToInt32(CustomerInfo["winRate_1center"]);
                this.WinRate1back = Convert.ToInt32(CustomerInfo["winRate_1back"]);
                this.WinRate1freelow = Convert.ToInt32(CustomerInfo["winRate_1freelow"]);
                this.WinRate5free = Convert.ToInt32(CustomerInfo["winRate_5free"]);

                // Discount
                this.dc_3up = Convert.ToInt32(CustomerInfo["dc_3up"]);
                this.dc_3low = Convert.ToInt32(CustomerInfo["dc_3low"]);
                this.dc_3freeup = Convert.ToInt32(CustomerInfo["dc_3freeup"]);
                this.dc_2up = Convert.ToInt32(CustomerInfo["dc_2up"]);
                this.dc_2low = Convert.ToInt32(CustomerInfo["dc_2low"]);
                this.dc_2freeup = Convert.ToInt32(CustomerInfo["dc_2freeup"]);
                this.dc_1freeup = Convert.ToInt32(CustomerInfo["dc_1freeup"]);
                this.dc_1front = Convert.ToInt32(CustomerInfo["dc_1front"]);
                this.dc_1center = Convert.ToInt32(CustomerInfo["dc_1center"]);
                this.dc_1back = Convert.ToInt32(CustomerInfo["dc_1back"]);
                this.dc_1freelow = Convert.ToInt32(CustomerInfo["dc_1freelow"]);
                this.dc_5free = Convert.ToInt32(CustomerInfo["dc_5free"]);

                // Customer Buying Limit
                // limit_3freeup
                if (Convert.ToInt32(CustomerInfo["limit_3freeup"]) > 0)
                {
                    this.limit_3freeup = Convert.ToInt32(CustomerInfo["limit_3freeup"]);
                }
                else
                {
                    this.limit_3freeup = Int32.MaxValue;
                }
                // limit_3up
                if(Convert.ToInt32(CustomerInfo["limit_3up"]) > 0)
                {
                    this.limit_3up = Convert.ToInt32(CustomerInfo["limit_3up"]);
                }
                else
                {
                    this.limit_3up = Int32.MaxValue;
                }
                // limit_3low
                if(Convert.ToInt32(CustomerInfo["limit_3low"]) > 0)
                {
                    this.limit_3low = Convert.ToInt32(CustomerInfo["limit_3low"]);
                }
                else
                {
                    this.limit_3low = Int32.MaxValue;
                }
                // limit_2up
                if(Convert.ToInt32(CustomerInfo["limit_2up"]) > 0)
                {
                    this.limit_2up = Convert.ToInt32(CustomerInfo["limit_2up"]);
                }
                else
                {
                    this.limit_2up = Int32.MaxValue;
                }
                // limit_2low
                if(Convert.ToInt32(CustomerInfo["limit_2low"]) > 0)
                {
                    this.limit_2low = Convert.ToInt32(CustomerInfo["limit_2low"]);
                }
                else
                {
                    this.limit_2low = Int32.MaxValue;
                }
                // limit_1freeup
                if(Convert.ToInt32(CustomerInfo["limit_1freeup"]) > 0)
                {
                    this.limit_1freeup = Convert.ToInt32(CustomerInfo["limit_1freeup"]);
                }
                else
                {
                    this.limit_1freeup = Int32.MaxValue;
                }
                // limit_1freelow
                if (Convert.ToInt32(CustomerInfo["limit_1freelow"]) > 0)
                {
                    this.limit_1freelow = Convert.ToInt32(CustomerInfo["limit_1freelow"]);
                }
                else
                {
                    this.limit_1freelow = Int32.MaxValue;
                }
            }
            connection.Close();
        }
        public AddNumberDetail()
        {
            InitializeComponent();
            
            timer1.Start();

        }

        private void AddNumberDetail_FormClosed(object sender, FormClosedEventArgs e)
        {
            _instance = null;
            timer1.Stop();
        }

        private void AddNumberDetail_Load(object sender, EventArgs e)
        {
            // initial CustomerInfo
            initialCustomerInfo();

            //show Shortkey label for startup
            // Default 3
            tbNumber.MaxLength = 3;
            showShortKey(tbNumber.MaxLength);

            // check Previous state of Money Text
            checkMoneyTextState();

            // Load buying information from DB
            LoadBuyingOrderToTable();

            //update Number_xxx
            showNumberXXXToForm();

            // update summary table
            showSummaryToForm();
        }
        private void LoadBuyingOrderToTable()
        {
            SqlConnection connection = new SqlConnection(Database.CnnVal("LottoryDB"));

            if (connection.State == ConnectionState.Closed)
            {
                connection.Open(); // Open Database
            }
            // get TypeID
            string sqlgetBuyingInfo = string.Format(@"SELECT TypeNumberInfo.TypeName, OrderList.Number, OrderList.Price, OrderList.GroupPrice
                                                      FROM (CustomerOrder INNER JOIN OrderList ON CustomerOrder.OrderID = OrderList.OrderID)
                                                      INNER JOIN TypeNumberInfo ON OrderList.TypeID = TypeNumberInfo.TypeID
                                                      WHERE (CustomerOrder.CustomerID = '{0}') AND (CustomerOrder.Page = {1})",this.CustomerID,this.Page);
            SqlCommand sqlgetBuyingInfoCom = new SqlCommand(sqlgetBuyingInfo, connection);
            SqlDataReader BuyingInfo = sqlgetBuyingInfoCom.ExecuteReader();
            while(BuyingInfo.Read())
            {
                if(Convert.ToInt32(BuyingInfo["GroupPrice"]) == 0)
                {
                    dgvCusBuyList.Rows.Add(BuyingInfo["Number"].ToString(), BuyingInfo["TypeName"].ToString(), BuyingInfo["Price"].ToString());
                }
                else if(Convert.ToInt32(BuyingInfo["Price"]) == 0)
                {
                    dgvCusBuyList.Rows.Add(BuyingInfo["Number"].ToString(), BuyingInfo["TypeName"].ToString(), string.Empty, BuyingInfo["GroupPrice"].ToString());
                }
                else
                {
                    dgvCusBuyList.Rows.Add(BuyingInfo["Number"].ToString(), BuyingInfo["TypeName"].ToString(), BuyingInfo["Price"].ToString(),BuyingInfo["GroupPrice"].ToString());
                }
                
            }
            connection.Close();
        }


        private void showShortKey(int idx)
        {
            switch(idx)
            {
                case 1:
                    lbTypeShortKey.Text  = "1 ตัว" + Environment.NewLine;
                    lbTypeShortKey.Text += "(-)ล่าง, (+)บน, (1)หน้า, (2)กลาง," + Environment.NewLine;
                    lbTypeShortKey.Text += "(3)หลัง, (4)หน้าล่าง, (5)หลังล่าง, (*)บน/ล่าง";
                    break;
                case 2:
                    lbTypeShortKey.Text  = "2 ตัว" + Environment.NewLine;
                    lbTypeShortKey.Text += "(*)บน/ล่าง, (+)บน, (-)ล่าง, (7)ร้อยสิบ, (8)ร้อยหน่วย," + Environment.NewLine;
                    lbTypeShortKey.Text += "(/)โต๊ด, (6)6 ประตู, (/)19 ประตูบนล่าง, (9)19 ประตูบน," + Environment.NewLine;
                    lbTypeShortKey.Text += "(0)19 ประตูล่าง";
                    break;
                case 3:
                    lbTypeShortKey.Text  = "3 ตัว" + Environment.NewLine;
                    lbTypeShortKey.Text += "(*)บน/โต๊ด, (+)บน, (-)ล่าง, (.)ชุด, (/)โต๊ด," + Environment.NewLine;
                    lbTypeShortKey.Text += "(9)54 ประตู, (5)ตรงชุด, (2)ล่างชุด, (0)บน/โตีด/ล่าง";
                    break;
                case 4:
                    lbTypeShortKey.Text  = "4 ตัว" + Environment.NewLine;
                    lbTypeShortKey.Text += "(.)ชุด";
                    break;
                case 5:
                    lbTypeShortKey.Text  = "5 ตัว" + Environment.NewLine;
                    lbTypeShortKey.Text += "(.)ชุด, (/)โต๊ด";
                    break;
                default:
                    break;

            }
        }
        private void controlTypeList(string strType, int NextState)
        {
            // Test state : OK

            // Add String to Type
            tbType.Text = strType;

            switch (this.PreviousState)
            {
                case 1:
                    switch(NextState)
                    {
                        case 1:
                            // check empty Money1
                            if(!string.IsNullOrEmpty(tbMoney1.Text))
                            {
                                // Money1 not empty
                                
                                tbMoney1.Focus(); // Move to Money1
                                
                                tbMoney1.SelectAll(); // Select All
                            }
                            else
                            {
                                tbMoney1.Focus(); // Move to Money1
                            }
                            break;
                        case 2:
                            // clear Money1
                            tbMoney1.Clear();
                            tbMoney1.Focus();
                            // enable Money2
                            tbMoney2.Enabled = true;

                            // update Previous State
                            this.PreviousState = 2;
                            break;
                        case 3:
                            // Disable Money1
                            tbMoney1.Clear();
                            tbMoney1.Enabled = false;
                            // Move to Money2
                            tbMoney2.Enabled = true;
                            tbMoney2.Focus();

                            // update Previous State
                            this.PreviousState = 3;
                            break;
                        default:
                            // error
                            break;
                    }
                    break;
                case 2:
                    switch(NextState)
                    {
                        case 1:
                            // Move to Money1
                            tbMoney1.Clear();
                            tbMoney1.Focus();
                            // Disable Money2
                            tbMoney2.Clear();
                            tbMoney2.Enabled = false;

                            //update Previous state
                            this.PreviousState = 1;
                            break;
                        case 2:
                            // Move to Money1
                            tbMoney1.Focus();
                            tbMoney1.SelectAll();
                            break;
                        case 3:
                            // Move to Money2
                            tbMoney2.Clear();
                            tbMoney2.Focus();
                            // Disable Money1
                            tbMoney1.Clear();
                            tbMoney1.Enabled = false;

                            // update Previous State
                            this.PreviousState = 3;
                            break;
                        default:
                            // error
                            break;
                    }
                    break;
                case 3:
                    switch(NextState)
                    {
                        case 1:
                            // Enable Money1
                            tbMoney1.Enabled = true;
                            // Move to Money1
                            tbMoney1.Focus();
                            // Disable Money2
                            tbMoney2.Clear();
                            tbMoney2.Enabled = false;

                            // update Previous State
                            this.PreviousState = 1;
                            break;
                        case 2:
                            // Enable Money1
                            tbMoney1.Enabled = true;
                            // Move to Money1
                            tbMoney1.Focus();
                            // Clear Money2
                            tbMoney2.Clear();

                            //update Previous State
                            this.PreviousState = 2;
                            break;
                        case 3:
                            // Move to Money 2
                            tbMoney2.Focus();
                            tbMoney2.SelectAll();
                            break;
                        default:
                            // error
                            break;
                    }
                    break;
                default:
                    // error
                    break;
            }

        }
        private void MoveToMoney1()
        {
            tbMoney1.Focus();
            tbMoney1.SelectAll();
        }
        private void MoveToMoney2()
        {
            tbMoney2.Focus();
            tbMoney2.SelectAll();
        }
        private void AddTypeList(KeyEventArgs e)
        {
            // Test state : OK 

            tbType.SelectAll();
            // Manual Auto complete for Type
            switch (tbNumber.Text.Length)
            {
                case 1:
                    //Check key down
                    switch (e.KeyCode)
                    {
                        case Keys.OemMinus:
                        case Keys.Subtract:
                            //(-) ล่าง
                            tbType.Text = BaseType.low1;
                            // Next state is 1 [Money1 => enable, Group => disable]
                            //controlTypeList(BaseType.low1, 1);
                            enableMoney1Only();
                            MoveToMoney1();
                            break;
                        case Keys.Add:
                            //(+) บน
                            tbType.Text = BaseType.up1;
                            // Next state is 1 [Money1 => enable, Group => disable]
                            //controlTypeList(BaseType.up1, 1);
                            enableMoney1Only();
                            MoveToMoney1();
                            break;
                        case Keys.NumPad1:
                        case Keys.D1:
                            //(1) หน้า
                            tbType.Text = BaseType.upfront1;
                            // Next state is 1 [Money1 => enable, Group => disable]
                            //controlTypeList(BaseType.upfront1, 1);
                            enableMoney1Only();
                            MoveToMoney1();
                            break;
                        case Keys.NumPad2:
                        case Keys.D2:
                            //(2) กลาง
                            tbType.Text = BaseType.upcenter1;
                            // Next state is 1 [Money1 => enable, Group => disable]
                            //controlTypeList(BaseType.upcenter1, 1);
                            enableMoney1Only();
                            MoveToMoney1();
                            break;
                        case Keys.NumPad3:
                        case Keys.D3:
                            //(3) หลัง
                            tbType.Text = BaseType.upback1;
                            // Next state is 1 [Money1 => enable, Group => disable]
                            //controlTypeList(BaseType.upback1, 1);
                            enableMoney1Only();
                            MoveToMoney1();
                            break;
                        case Keys.NumPad4:
                        case Keys.D4:
                            //(4) หน้าล่าง
                            tbType.Text = BaseType.lowfront1;
                            // Next state is 1 [Money1 => enable, Group => disable]
                            //controlTypeList(BaseType.lowfront1, 1);
                            enableMoney1Only();
                            MoveToMoney1();
                            break;
                        case Keys.NumPad5:
                        case Keys.D5:
                            //(5) หลังล่าง
                            tbType.Text = BaseType.lowback1;
                            // Next state is 1 [Money1 => enable, Group => disable]
                            //controlTypeList(BaseType.lowback1, 1);
                            enableMoney1Only();
                            MoveToMoney1();
                            break;
                        case Keys.Multiply:
                        case Keys.D8:
                            //(*) บน/ล่าง
                            tbType.Text = BaseType.uplow1;
                            // Next state is 1 [Money1 => enable, Group => disable]
                            // controlTypeList(BaseType.uplow1, 1);
                            enableMoney1Only();
                            MoveToMoney1();
                            break;

                        // for 2 Number
                        case Keys.Divide:
                        case Keys.OemQuestion:
                            // (/) 19 ประตูบนล่าง
                            tbType.Text = BaseType.door19uplow2;
                            // Next state is 1 [Money1 => enable, Group => disable]
                            //controlTypeList(BaseType.door19uplow2, 1);
                            // remove digit 2
                            //tbNumber.Text = tbNumber.Text.Remove(1, 1);
                            enableMoney1Only();
                            MoveToMoney1();
                            break;
                        case Keys.NumPad9:
                        case Keys.D9:
                            // (9) 19 ประตูบน
                            tbType.Text = BaseType.door19up2;
                            // Next state is 1 [Money1 => enable, Group => disable]
                            //controlTypeList(BaseType.door19up2, 1);
                            // remove digit 2
                            //tbNumber.Text = tbNumber.Text.Remove(1, 1);
                            enableMoney1Only();
                            MoveToMoney1();
                            break;
                        case Keys.NumPad0:
                        case Keys.D0:
                            // (0) 19 ประตูล่าง
                            tbType.Text = BaseType.door19low2;
                            // Next state is 1 [Money1 => enable, Group => disable]
                            //controlTypeList(BaseType.door19low2, 1);
                            // remove digit 2
                            //tbNumber.Text = tbNumber.Text.Remove(1, 1);
                            enableMoney1Only();
                            MoveToMoney1();
                            break;
                        case Keys.Back:
                            // clear text
                            tbType.Clear();
                            break;
                        default:
                            // error
                            MessageBox.Show("กรุณาใส่ชนิดให้ถูกต้อง", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                    }
                    break;
                case 2:
                    // Check key code
                    switch (e.KeyCode)
                    {
                        case Keys.Multiply:
                            //case Keys.D8:
                            // (*) บน/ล่าง
                            tbType.Text = BaseType.uplow2;
                            // Next state is 1 [Money1 => enable, Group => disable]
                            //controlTypeList(BaseType.uplow2, 1);
                            enableMoney1Only();
                            MoveToMoney1();
                            break;
                        case Keys.Add:
                        case Keys.Oemplus:
                            // (+) บน
                            tbType.Text = BaseType.up2;
                            // Next state is 1 [Money1 => enable, Group => disable]
                            //controlTypeList(BaseType.up2, 1);
                            enableMoney1Only();
                            MoveToMoney1();
                            break;
                        case Keys.Subtract:
                        case Keys.OemMinus:
                            // (-) ล่าง
                            tbType.Text = BaseType.low2;
                            // Next state is 1 [Money1 => enable, Group => disable]
                            //controlTypeList(BaseType.low2, 1);
                            enableMoney1Only();
                            MoveToMoney1();
                            break;
                        case Keys.NumPad7:
                        case Keys.D7:
                            // (7) ร้อยสิบ
                            tbType.Text = BaseType.ht2;
                            // Next state is 1 [Money1 => enable, Group => disable]
                            //controlTypeList(BaseType.ht2, 1);
                            enableMoney1Only();
                            MoveToMoney1();
                            break;
                        case Keys.NumPad8:
                            //case Keys.D8:
                            // (8) ร้อยหน่วย
                            tbType.Text = BaseType.hu2;
                            // Next state is 1 [Money1 => enable, Group => disable]
                            //controlTypeList(BaseType.hu2, 1);
                            enableMoney1Only();
                            MoveToMoney1();
                            break;
                        case Keys.Divide:
                        case Keys.OemQuestion:
                            // (/) โต๊ด
                            tbType.Text = BaseType.tod2;
                            // Next state is 1 [Money1 => enable, Group => disable]
                            //controlTypeList(BaseType.tod2, 1);
                            enableMoney1Only();
                            MoveToMoney1();
                            break;
                        case Keys.NumPad6:
                        case Keys.D6:
                            // (6) 6 ประตู
                            tbType.Text = BaseType.door62;
                            // Next state is 1 [Money1 => enable, Group => disable]
                            //controlTypeList(BaseType.door62, 1);
                            enableMoney1Only();
                            MoveToMoney1();
                            break;

                        // for 3 Number
                        case Keys.NumPad9:
                        case Keys.D9:
                            // (9) 54 ประตู
                            tbType.Text = BaseType.door543;
                            // Next state is 1 [Money1 => disable, Group => enable]
                            //controlTypeList(BaseType.door543, 1);
                            // remove digit 3
                            //tbNumber.Text = tbNumber.Text.Remove(2, 1);
                            enableMoney1Only();
                            MoveToMoney1();
                            break;
                        case Keys.Back:
                            // clear Text
                            tbType.Clear();
                            break;
                        default:
                            // error
                            MessageBox.Show("กรุณาใส่ชนิดให้ถูกต้อง", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                    }
                    break;
                case 3:
                    // Check key code
                    switch (e.KeyCode)
                    {
                        case Keys.Subtract:
                        case Keys.OemMinus:
                            // (-) ล่าง
                            tbType.Text = BaseType.low3;
                            // Next state is 1 [Money1 => enable, Group => disable]
                            //controlTypeList(BaseType.low3, 1);
                            enableMoney1Only();
                            MoveToMoney1();
                            break;
                        case Keys.Divide:
                        case Keys.OemQuestion:
                            // (/) โต๊ด
                            tbType.Text = BaseType.tod3;
                            // Next state is 1 [Money1 => disable, Group => enable]
                            //controlTypeList(BaseType.tod3, 1);
                            enableMoney1Only();
                            MoveToMoney1();
                            break;

                        case Keys.Multiply:
                        case Keys.D8:
                            // (*) บนโต๊ด
                            tbType.Text = BaseType.uptod3;
                            // Next state is 1 [Money1 => enable, Group => disable]
                            // controlTypeList(BaseType.uptod3, 1);
                            enableMoney12();
                            MoveToMoney1();
                            break;
                        case Keys.Add:
                        case Keys.Oemplus:
                            // (+) บน
                            tbType.Text = BaseType.up3;
                            // Next state is 1 [Money1 => enable, Group => disable] 
                            //controlTypeList(BaseType.up3, 1);
                            enableMoney12();
                            MoveToMoney1();
                            break;
                        case Keys.NumPad5:
                        case Keys.D5:
                            // (5) ตรงชุด
                            tbType.Text = BaseType.tgroup3;
                            // Next state is 2 [Money1 => enable, Group => enable]
                            //controlTypeList(BaseType.group53, 2);
                            enableMoney12();
                            MoveToMoney1();
                            break;
                        case Keys.NumPad2:
                        case Keys.D2:
                            // (2) ล่างชุด
                            tbType.Text = BaseType.lowgroup3;
                            // Next state is 3 [Money => disable, Group => enable]
                            //controlTypeList(BaseType.lowgroup3, 3);
                            enableMoney2Only();
                            MoveToMoney2();
                            break;
                        case Keys.NumPad0:
                        case Keys.D0:
                            // (0) บน/โต๊ด/ล่าง
                            tbType.Text = BaseType.uplowtod3;
                            // Next state is 1 [Money => enable, Group => disable]
                            //controlTypeList(BaseType.uplowtod3, 1);
                            enableMoney12();
                            MoveToMoney1();
                            break;
                        case Keys.Decimal:
                        case Keys.OemPeriod:
                            // (.) ชุด
                            tbType.Text = BaseType.group3;
                            // Next state is 3 [Money1 => disable, Group => enable]
                            //controlTypeList(BaseType.group3, 3);
                            enableMoney2Only();
                            MoveToMoney2();
                            break;
                        case Keys.Back:
                            // clear text
                            tbType.Clear();
                            break;
                        default:
                            // error
                            MessageBox.Show("กรุณาใส่ชนิดให้ถูกต้อง", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                    }
                    break;
                case 4:
                    // Check key code
                    switch (e.KeyCode)
                    {
                        case Keys.Decimal:
                        case Keys.OemPeriod:
                            //(.) ชุด
                            tbType.Text = BaseType.group4;
                            // Next state is 3 [Money1 => disable, Group => enable]
                            //controlTypeList(BaseType.group4, 3);
                            enableMoney2Only();
                            MoveToMoney2();
                            break;
                        case Keys.Back:
                            // clear text
                            tbType.Clear();
                            break;
                        default:
                            // error
                            MessageBox.Show("กรุณาใส่ชนิดให้ถูกต้อง", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                    }
                    break;
                case 5:
                    // Check key code
                    switch (e.KeyCode)
                    {
                        case Keys.Decimal:
                        case Keys.OemPeriod:
                            //(.) ชุด
                            tbType.Text = BaseType.group5;
                            // Next state is 3 [Money1 => disable, Group => enable]
                            //controlTypeList(BaseType.group5, 3);
                            enableMoney2Only();
                            MoveToMoney2();
                            break;
                        case Keys.Divide:
                        case Keys.OemQuestion:
                            //(/) โต๊ด
                            tbType.Text = BaseType.tod5;
                            // Next state is 1 [Money1 => enable, Group => disable]
                            //controlTypeList(BaseType.tod5, 1);
                            enableMoney1Only();
                            MoveToMoney1();
                            break;
                        case Keys.Back:
                            // clear text
                            tbType.Clear();
                            break;
                        default:
                            // error
                            MessageBox.Show("กรุณาใส่ชนิดให้ถูกต้อง", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                    }
                    break;
                default:
                    break;
            }
        }

        private void tbNumber_KeyDown(object sender, KeyEventArgs e)
        {
            int t_MaxLength;
            switch (e.KeyCode)
            {
                // Arrow up
                case Keys.Up:
                    t_MaxLength = tbNumber.MaxLength;
                    t_MaxLength += 1;
                    if (t_MaxLength > 5)
                    {
                        tbNumber.MaxLength = 1;
                    }
                    else
                    {
                        tbNumber.MaxLength = t_MaxLength;
                    }
                    // Clear Number
                    tbNumber.Clear();
                    break;
                // Arrow Down
                case Keys.Down:
                    t_MaxLength = tbNumber.MaxLength;
                    t_MaxLength -= 1;
                    if (t_MaxLength < 1)
                    {
                        tbNumber.MaxLength = 5;
                    }
                    else
                    {
                        tbNumber.MaxLength = t_MaxLength;
                    }
                    // Clear Number
                    tbNumber.Clear();
                    break;
                case Keys.Enter:
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    // Focus Type
                    tbType.Focus();

                    AutoBuyingCommand();

                    // Select All
                    tbType.SelectAll();
                    break;
                default:
                    break;
            }
            // Show Text in Short Key
            showShortKey(tbNumber.MaxLength);
        }
        private void AutoBuyingCommand()
        {
            // Auto choose proper Type refer Number.
            int row = dgvCusBuyList.Rows.Count;
            if(row > 0)
            {
                bool found = false;
                for (int i = row - 1; i >= 0; i--)
                {
                    int NumLen = dgvCusBuyList.Rows[i].Cells[0].Value.ToString().Length;
                    if (NumLen == tbNumber.Text.Length)
                    {
                        string _type = dgvCusBuyList.Rows[i].Cells[1].Value.ToString();
                        int _numlen = NumLen;
                        tbType.Text = returnType(_type, _numlen);

                        // get Money
                        string _money1 = dgvCusBuyList.Rows[i].Cells[2].Value.ToString();
                        string _money2 = string.Empty;
                        if (dgvCusBuyList.Rows[i].Cells[3].Value != null)
                        {
                            _money2 = dgvCusBuyList.Rows[i].Cells[3].Value.ToString();
                        }

                        // case บน
                        if(string.Equals(_type,"บน") && string.IsNullOrEmpty(_money2))
                        {
                            _money2 = (0).ToString();
                        }

                        // enable Money and fill money
                        setEnableMoney(_type, _numlen, _money1, _money2);
                        found = true;
                        break;
                    }
                }
                if(!found)
                {
                    // not found old item in list
                    string _type = defaultType();
                    int _numlen = tbNumber.Text.Length;
                    tbType.Text = returnType(_type, _numlen);
                    setEnableMoney(_type,_numlen,string.Empty,string.Empty);
                }
            }
            else
            {
                //No item in list
                string _type = defaultType();
                int _numlen = tbNumber.Text.Length;
                tbType.Text = returnType(_type, _numlen);
                setEnableMoney(_type, _numlen, string.Empty, string.Empty);
            } 
        }
        private string defaultType()
        {
            string outTypeDefault = string.Empty;
            switch (tbNumber.Text.Length)
            {
                case 1:
                    outTypeDefault = BaseType.up1;
                    break;
                case 2:
                    outTypeDefault = BaseType.up2;
                    break;
                case 3:
                    outTypeDefault = BaseType.up3;
                    break;
                case 4:
                    outTypeDefault = BaseType.group4;
                    break;
                case 5:
                    outTypeDefault = BaseType.group5;
                    break;
            }
            return outTypeDefault;
        }
        private void setEnableMoney(string typeName, int Numlen, string money1, string money2)
        {
            switch(Numlen)
            {
                case 1:
                    // Enable Money1 Only
                    enableMoney1Only(money1);
                    break;
                case 2:
                    // Enable Money1 Only
                    enableMoney1Only(money1);
                    break;
                case 3:
                    switch(typeName)
                    {
                        case "ล่าง":
                        case "โต๊ด":
                        case "54 ประตู":
                            // Enable Money1 Only
                            enableMoney1Only(money1);
                            break;
                        case "บน/โต๊ด":
                        case "บน":
                        case "ตรงชุด":
                        case "ล่างชุด":
                        case "บน/โต๊ด/ล่าง":
                            // Enable Money 1,2 Only
                            enableMoney12(money1,money2);
                            break;
                        case "ชุด":
                            // Enable Money2 Only
                            enableMoney2Only(money2);
                            break;
                    }
                    break;
                case 4:
                    // Enable Money2 Only
                    enableMoney2Only(money2);
                    break;
                case 5:
                    switch(typeName)
                    {
                        case "โต๊ด":
                            // Enable Money1 Only
                            enableMoney1Only(money1);
                            break;
                        case "ชุด":
                            enableMoney2Only(money2);
                            break;
                    }
                    break;
            }
        }
        private void enableMoney1Only(string money)
        {
            //Money 1 Enable only
            tbMoney1.Enabled = true;
            tbMoney1.Text = money;
            //Money 2 disable
            tbMoney2.Clear();
            tbMoney2.Enabled = false;
        }
        private void enableMoney1Only()
        {
            //Money 1 Enable only
            tbMoney1.Enabled = true;
            //tbMoney1.Text = money;
            //Money 2 disable
            tbMoney2.Clear();
            tbMoney2.Enabled = false;
        }
        private void enableMoney12(string money1, string money2)
        {
            //Enable Money1 
            tbMoney1.Enabled = true;
            tbMoney1.Text = money1;
            //Enable Money2
            tbMoney2.Enabled = true;
            tbMoney2.Text = money2;
        }
        private void enableMoney12()
        {
            //Enable Money1 
            tbMoney1.Enabled = true;
            //tbMoney1.Text = money1;
            //Enable Money2
            tbMoney2.Enabled = true;
            //tbMoney2.Text = money2;
        }
        private void enableMoney2Only(string money)
        {
            // Disable Money1
            tbMoney1.Clear();
            tbMoney1.Enabled = false;
            // Enable Money2
            tbMoney2.Enabled = true;
            tbMoney2.Text = money;
        }
        private void enableMoney2Only()
        {
            // Disable Money1
            tbMoney1.Clear();
            tbMoney1.Enabled = false;
            // Enable Money2
            tbMoney2.Enabled = true;
            //tbMoney2.Text = money;
        }
        private string returnType(string typeName, int NumLen)
        {
            string outType = string.Empty;
            string sign = string.Empty;
            switch(NumLen)
            {
                case 1:
                    switch(typeName)
                    {
                        case "ล่าง":
                            sign = "-";
                            break;
                        case "บน":
                            sign = "+";
                            break;
                        case "หน้า":
                            sign = "1";
                            break;
                        case "กลาง":
                            sign = "2";
                            break;
                        case "หลัง":
                            sign = "3";
                            break;
                        case "หน้าล่าง":
                            sign = "4";
                            break;
                        case "หลังล่าง":
                            sign = "5";
                            break;
                        case "บน/ล่าง":
                            sign = "*";
                            break;
                        case "19 ประตูบนล่าง":
                            sign = "/";
                            break;
                        case "19 ประตูบน":
                            sign = "9";
                            break;
                        case "19 ประตูล่าง":
                            sign = "0";
                            break;
                    }
                    break;
                case 2:
                    switch(typeName)
                    {
                        case "บน/ล่าง":
                            sign = "*";
                            break;
                        case "บน":
                            sign = "+";
                            break;
                        case "ล่าง":
                            sign = "-";
                            break;
                        case "ร้อยสิบ":
                            sign = "7";
                            break;
                        case "ร้อยหน่วย":
                            sign = "8";
                            break;
                        case "โต๊ด":
                            sign = "/";
                            break;
                        case "6 ประตู":
                            sign = "6";
                            break;
                        case "54 ประตู":
                            sign = "9";
                            break;

                    }
                    break;
                case 3:
                    switch(typeName)
                    {
                        case "บน/โต๊ด":
                            sign = "*";
                            break;
                        case "บน":
                            sign = "+";
                            break;
                        case "ล่าง":
                            sign = "-";
                            break;
                        case "ชุด":
                            sign = ".";
                            break;
                        case "โต๊ด":
                            sign = "/";
                            break;
                        case "ตรงชุด":
                            sign = "5";
                            break;
                        case "ล่างชุด":
                            sign = "2";
                            break;
                        case "บน/โต๊ด/ล่าง":
                            sign = "0";
                            break;
                    }
                    break;
                case 4:
                    switch(typeName)
                    {
                        case "ชุด":
                            sign = ".";
                            break;

                    }
                    break;
                case 5:
                    switch(typeName)
                    {
                        case "ชุด":
                            sign = ".";
                            break;
                        case "โต๊ด":
                            sign = "/";
                            break;
                    }
                    break;
            }
            outType = string.Format("{0}{1}", sign, typeName);
            return outType;
        }
        private void tbNumber_TextChanged(object sender, EventArgs e)
        {
            // Auto Focus to Type box
            if(tbNumber.TextLength == tbNumber.MaxLength)
            {
                // Auto Type and Money
                tbType.Focus();

                AutoBuyingCommand();

                // Select All
                tbType.SelectAll();
            }
        }

        private void tbType_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Enter:
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    // Move to Money1 or Money2
                    MovetoMoney();
                    break;
                case Keys.PageDown:
                    // Buy
                    ShortBuying(); 
                    break;
                default:
                    // Add Type List
                    AddTypeList(e);
                    break;
            }

        }
        private void ShortBuying()
        {
            if((tbMoney1.Enabled == true) && (tbMoney2.Enabled == false))
            {
                if(!string.IsNullOrEmpty(tbMoney1.Text))
                {
                    //check buying error and warning
                    if (buyingLimitChecking(Convert.ToInt32(tbMoney1.Text)))
                    {// over buying
                        MessageBox.Show(string.Format("คำสั่งซื้อเกินวงเงินที่กำหนด", "จำกัดวงเงิน"));
                    }
                    else if (NumberLimitChecking(tbNumber.Text, tbType.Text.Substring(1, tbType.Text.Length - 1), tbMoney1.Text))
                    {
                        MessageBox.Show("คำสั่งซื้อตัวเลขนี้เกินวงเงินอั้น", "เกินวงเงินอั้น");
                    }
                    else
                    {// not over buying
                     // Add Buying command to Display Table
                        AddNumberToTable();
                        //Move to Number 
                        tbNumber.SelectAll();
                        tbNumber.Focus();
                    }
                }
                else
                {
                    //error
                    MessageBox.Show("กรุณาใส่จำนวนเงิน", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if((tbMoney1.Enabled == true) && (tbMoney2.Enabled == true))
            {
                if(!string.IsNullOrEmpty(tbMoney1.Text) && !string.IsNullOrEmpty(tbMoney2.Text))
                {
                    if (!string.IsNullOrEmpty(tbMoney1.Text) && !string.IsNullOrEmpty(tbMoney2.Text))
                    {
                        int _money1 = Convert.ToInt32(tbMoney1.Text);
                        int _money2 = Convert.ToInt32(tbMoney2.Text);
                        if (buyingLimitChecking(_money1) || buyingLimitChecking(_money2))
                        {// over buying
                            MessageBox.Show(string.Format("คำสั่งซื้อเกินวงเงินที่กำหนด", "จำกัดวงเงิน"));
                        }
                        else
                        {// not over buying
                         // Add Buying command to Display Table
                            AddNumberToTable();
                            // Move to Number
                            tbNumber.SelectAll();
                            tbNumber.Focus();
                        }
                    }
                }
                else
                {
                    // error
                    MessageBox.Show("กรุณาใส่จำนวนเงิน", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if((tbMoney1.Enabled == false) && (tbMoney2.Enabled == true))
            {
                if(!string.IsNullOrEmpty(tbMoney2.Text))
                {
                    int _money2 = Convert.ToInt32(tbMoney2.Text);
                    if (buyingLimitChecking(_money2))
                    {// over buying
                        MessageBox.Show(string.Format("คำสั่งซื้อเกินวงเงินที่กำหนด", "จำกัดวงเงิน"));
                    }
                    else
                    {// not over buying
                        // Add Buying command to Display Table
                        AddNumberToTable();
                        // Move to Number
                        tbNumber.SelectAll();
                        tbNumber.Focus();
                    }
                }
                else
                {
                    // error
                    MessageBox.Show("กรุณาใส่จำนวนเงิน", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private void MovetoMoney()
        {
            // Check Enable money
            if(tbMoney1.Enabled)
            {
                tbMoney1.Focus();
                tbMoney1.SelectAll();
            }
            else
            {
                if(tbMoney2.Enabled)
                {
                    tbMoney2.Focus();
                    tbMoney2.SelectAll();
                }
            }
        }

        private void tbMoney1_TextChanged(object sender, EventArgs e)
        {
            // Check Money1 is correct or not
            double x;
            if(!double.TryParse(tbMoney1.Text, out x) && !string.IsNullOrEmpty(tbMoney1.Text))
            {
                MessageBox.Show("กรุณาใส่จำนวนเงินเป็นตัวเลขให้ถูกต้อง");
            }
        }

        private void tbMoney2_TextChanged(object sender, EventArgs e)
        {
            // Check Money2 is correct or not?
            double x;
            if (!double.TryParse(tbMoney2.Text, out x) && !string.IsNullOrEmpty(tbMoney2.Text))
            {
                MessageBox.Show("กรุณาใส่จำนวนเงินเป็นตัวเลขให้ถูกต้อง");
            }
        }
        private void AddBuyingListTable(string Money, string Group)
        {
            dgvCusBuyList.Rows.Add(tbNumber.Text, tbType.Text.Substring(1, tbType.Text.Length - 1), Money, Group);
            // auto scolling down
            dgvCusBuyList.FirstDisplayedScrollingRowIndex = dgvCusBuyList.RowCount - 1;
        }
        private void AddNumberToTable()
        {
            // Add Number to Table

            if ((tbMoney2.Enabled == false) && (tbMoney1.Enabled == true))
            {
                // Money State 1 : Money1 => Enable, Money2 => Disable

                // update Buying to List Table Form
                // Add(Number, Type, Money)
                //dgvCusBuyList.Rows.Add(tbNumber.Text, tbType.Text.Substring(1, tbType.Text.Length - 1), tbMoney1.Text,string.Empty);
                // auto scolling down
                //dgvCusBuyList.FirstDisplayedScrollingRowIndex = dgvCusBuyList.RowCount - 1;

                // update OrderList in DB
                updateOrderToDB(tbNumber.Text, tbType.Text.Substring(1, tbType.Text.Length - 1), tbMoney1.Text, string.Empty);

            }
            else if ((tbMoney1.Enabled == true) && (tbMoney2.Enabled == true))
            {
                // Money State 2 : Money1 => Enable, Money2 => Enable
                if (string.IsNullOrEmpty(tbMoney2.Text))
                {

                    // update Buying to List Table Form
                    // Add(Number, Type, Money, Group)
                    //dgvCusBuyList.Rows.Add(tbNumber.Text, tbType.Text.Substring(1, tbType.Text.Length - 1), tbMoney1.Text, tbMoney1.Text);
                    // auto scolling down
                    //dgvCusBuyList.FirstDisplayedScrollingRowIndex = dgvCusBuyList.RowCount - 1;

                    // update OrderList in DB &
                    // update OrderListExpand in DB
                    updateOrderToDB(tbNumber.Text, tbType.Text.Substring(1, tbType.Text.Length - 1), tbMoney1.Text, tbMoney1.Text);
                }
                else
                {
                    // update Buying to List Table Form
                    // Add(Number, Type, Money, Group)
                    //dgvCusBuyList.Rows.Add(tbNumber.Text, tbType.Text.Substring(1, tbType.Text.Length - 1), tbMoney1.Text, tbMoney2.Text);
                    // auto scolling down
                    //dgvCusBuyList.FirstDisplayedScrollingRowIndex = dgvCusBuyList.RowCount - 1;

                    // update OrderList in DB
                    // update OrderListExpand in DB
                    updateOrderToDB(tbNumber.Text, tbType.Text.Substring(1, tbType.Text.Length - 1), tbMoney1.Text, tbMoney2.Text);
                }
            }
            else if((tbMoney1.Enabled == false) && (tbMoney2.Enabled == true))
            {

                // Money State 3 : Money1 => Diable, Money2 => Enable

                // update Buying to List Table Form
                // Add(Number, Type, Group)
                //dgvCusBuyList.Rows.Add(tbNumber.Text, tbType.Text.Substring(1, tbType.Text.Length - 1), string.Empty, tbMoney2.Text);
                // auto scolling down
                //dgvCusBuyList.FirstDisplayedScrollingRowIndex = dgvCusBuyList.RowCount - 1;

                // update OrderList in DB & 
                // update OrderListExpand in DB
                updateOrderToDB(tbNumber.Text, tbType.Text.Substring(1, tbType.Text.Length - 1), string.Empty,tbMoney2.Text);
            }
             
        }
        private void updateCustomerBuyingToForm(List<string> Number,List<int> TypeID)
        {
            DataTable NumberTable = new DataTable();
            NumberTable.Columns.Add("เบอร์");
            NumberTable.Columns.Add("ชนิด");
            NumberTable.Columns.Add("จำนวนเงิน");
            NumberTable.Columns["จำนวนเงิน"].DataType = Type.GetType("System.Int32");

            for(int i = 0 ; i < Number.Count ; i++)
            {   
                SqlConnection connection = new SqlConnection(Database.CnnVal("LottoryDB"));

                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open(); // Open Database
                }
                string sqlgetsumNumber = string.Format(@"SELECT SUM(OwnPrice) AS numPrice
                                                     FROM ((CustomerOrder c INNER JOIN OrderList o ON c.OrderID = o.OrderID)
                                                     INNER JOIN OrderListExpand oe ON o.OrderListID = oe.OrderListID) 
                                                     WHERE (c.CustomerID = {0}) AND (oe.Number = '{1}') AND (oe.TypeID = {2})", this.CustomerID, Number[i], TypeID[i].ToString());
                SqlCommand sqlgetsumNumberCom = new SqlCommand(sqlgetsumNumber, connection);
                SqlDataReader sumNumberInfo = sqlgetsumNumberCom.ExecuteReader();
                while (sumNumberInfo.Read())
                {
                    NumberTable.Rows.Add(Number[i], convertTypeIDToName(TypeID[i]), Convert.ToDouble(sumNumberInfo["numPrice"]));
                }
                connection.Close();
            }
            //NumberTable.DefaultView.Sort = "จำนวนเงิน DESC";
            TbCustomerBuying.DataSource = NumberTable;
            TbCustomerBuying.Sort(TbCustomerBuying.Columns[2], ListSortDirection.Descending);
            TbCustomerBuying.ClearSelection();
        }
        private void updateBuyingToForm(List<string> Number, List<int> TypeID)
        {
            DataTable NumberTable = new DataTable();
            NumberTable.Columns.Add("เบอร์");
            NumberTable.Columns.Add("ชนิด");
            NumberTable.Columns.Add("จำนวนเงิน");
            NumberTable.Columns["จำนวนเงิน"].DataType = Type.GetType("System.Int32");

            for (int i = 0; i < Number.Count; i++)
            {
                SqlConnection connection = new SqlConnection(Database.CnnVal("LottoryDB"));

                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open(); // Open Database
                }
                string sqlgetsumNumber = string.Format(@"SELECT SUM(OwnPrice) AS numPrice
                                                     FROM OrderListExpand oe
                                                     WHERE (oe.Number = '{0}') AND (oe.TypeID = {1})", Number[i], TypeID[i].ToString());
                SqlCommand sqlgetsumNumberCom = new SqlCommand(sqlgetsumNumber, connection);
                SqlDataReader sumNumberInfo = sqlgetsumNumberCom.ExecuteReader();
                while (sumNumberInfo.Read())
                {
                    NumberTable.Rows.Add(Number[i], convertTypeIDToName(TypeID[i]), Convert.ToDouble(sumNumberInfo["numPrice"]));
                }
                connection.Close();
            }
            //NumberTable.DefaultView.Sort = "จำนวนเงิน DESC";
            TbAllBuying.DataSource = NumberTable;
            TbAllBuying.Sort(TbAllBuying.Columns[2], ListSortDirection.Descending);
            TbAllBuying.ClearSelection();
        }

        private string convertTypeIDToName(int TypeID)
        {
            string type = string.Empty;
            switch(TypeID)
            {
                case BaseTypeID.up1:
                    type = BaseType.up1;
                    break;
                case BaseTypeID.low1:
                    type = BaseType.low1;
                    break;
                case BaseTypeID.upfront1:
                    type = BaseType.upfront1;
                    break;
                case BaseTypeID.upcenter1:
                    type = BaseType.upcenter1;
                    break;
                case BaseTypeID.upback1:
                    type = BaseType.upback1;
                    break;
                case BaseTypeID.lowfront1:
                    type = BaseType.lowfront1;
                    break;
                case BaseTypeID.lowback1:
                    type = BaseType.lowback1;
                    break;
                case BaseTypeID.up2:
                    type = BaseType.up2;
                    break;
                case BaseTypeID.low2:
                    type = BaseType.low2;
                    break;
                case BaseTypeID.ht2:
                    type = BaseType.ht2;
                    break;
                case BaseTypeID.hu2:
                    type = BaseType.hu2;
                    break;
                case BaseTypeID.up3:
                    type = BaseType.up3;
                    break;
                case BaseTypeID.low3:
                    type = BaseType.low3;
                    break;
                default:
                    // error
                    break;
            }
            return type;
        }
        private void buyingCustomerChecking(int Money,int TypeID)
        {
            int BuyingLimit = Int32.MaxValue;
            switch(TypeID)
            {
                case BaseTypeID.up1:
                    BuyingLimit = this.limit_1freeup;
                    break;
                case BaseTypeID.low1:
                    BuyingLimit = this.limit_1freelow;
                    break;
                case BaseTypeID.up2:
                    BuyingLimit = this.limit_2up;
                    break;
                case BaseTypeID.low2:
                    BuyingLimit = this.limit_2low;
                    break;
                case BaseTypeID.up3:
                    BuyingLimit = this.limit_3up;
                    break;
                case BaseTypeID.low3:
                    BuyingLimit = this.limit_3low;
                    break;
                case BaseTypeID.uptod3:
                    BuyingLimit = this.limit_3freeup;
                    break;
                default:
                    // error
                    break;
            }
            // check customer buying limit per order
            if (Money > BuyingLimit)
            {
                MessageBox.Show("ลูกค้าซื้อเกินวงเงินที่กำหนด","Warning");
            }
        }
        private void updateOrderListDB(string Number, string Type, string Money, string Group)
        {
            SqlConnection connection = new SqlConnection(Database.CnnVal("LottoryDB"));

            if (connection.State == ConnectionState.Closed)
            {
                connection.Open(); // Open Database
            }
            // get TypeID
            string sqlgetTypeID = string.Format("SELECT TypeID, TypeName FROM TypeNumberInfo WHERE (TypeName = N'{0}') AND (NDigit = {1})", Type, Number.Length.ToString());
            SqlCommand sqlgetTypeIDCom = new SqlCommand(sqlgetTypeID, connection);
            SqlDataReader TypeIDInfo = sqlgetTypeIDCom.ExecuteReader();
            int typeID = 0;
            if (TypeIDInfo.Read())
            {
                typeID = (int)TypeIDInfo["TypeID"];
            }
            connection.Close();

            // update to OrderList in DB
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open(); // Open Database
            }
            string sqlupdateOrderList = null;
            if (!string.IsNullOrEmpty(Money))
            {
                if (string.IsNullOrEmpty(Group))
                {
                    // command For Money state 1

                    // Money1(not empty), Group(empty)
                    sqlupdateOrderList = string.Format("INSERT INTO OrderList(OrderID, TypeID, Number, Price) VALUES({0},{1},'{2}',{3})", this.OrderID, typeID.ToString(), Number, Money);
                }
                else
                {
                    // command For Money state 2

                    // Money1(not empty), Group(not empty)
                    sqlupdateOrderList = string.Format("INSERT INTO OrderList(OrderID, TypeID, Number, Price, GroupPrice) VALUES({0},{1},'{2}',{3},{4})", this.OrderID, typeID.ToString(), Number, Money, Group);
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(Group))
                {
                    // command For Money state 3

                    // Money1(empty), Group(not empty)
                    sqlupdateOrderList = string.Format("INSERT INTO OrderList(OrderID, TypeID, Number, GroupPrice) VALUES({0},{1},'{2}',{3})", this.OrderID, typeID.ToString(), Number, Group);
                }
            }
            SqlCommand sqlupdateOrderListCom = new SqlCommand(sqlupdateOrderList, connection);
            sqlupdateOrderListCom.ExecuteNonQuery();
            connection.Close();
        }
        private void updateOrderToDB(string Number, string Type, string Money, string Group)
        {
            int OrderListID;
            int discount; // customer discount
            List<string> NumberList = new List<string>();
            List<int> TypeIDList = new List<int>();

            // update to OrderListExpand in DB
            switch (Number.Length)
            {
                case 1:
                    switch(Type)
                    {
                       case BaseType.up1:
                            // one-to-one

                            // Add to Buying Table Form
                            AddBuyingListTable(Money, Group);

                            // update OrderList DB
                            updateOrderListDB(Number, Type, Money, Group);

                            // get OrderListID
                            OrderListID = getOrderListIDDB();

                            // get customer discount (%)
                            discount = getCustomerDiscount(BaseTypeID.up1);

                            // update OrderListExpand
                            updateOrderListExpandDB(OrderListID.ToString(), BaseTypeID.up1.ToString(), Number, Money, Money, discount);
                            NumberList.Add(Number);
                            TypeIDList.Add(BaseTypeID.up1);

                            // update Customer Buying Summary
                            updateCustomerBuyingToForm(NumberList, TypeIDList);
                            // update Buying Summary
                            updateBuyingToForm(NumberList, TypeIDList);

                            // update to Number_xxx
                            updateNumberXXXToDB(BaseTypeID.up1, Number, Money, Money);

                            // Customer Buying Check
                            buyingCustomerChecking(Convert.ToInt32(Money), BaseTypeID.up1);
                            break;
                        case BaseType.low1:
                            // one-to-one

                            // Add to Buying Table Form
                            AddBuyingListTable(Money, Group);

                            // update OrderList DB
                            updateOrderListDB(Number, Type, Money, Group);

                            // get OrderListID
                            OrderListID = getOrderListIDDB();

                            // get customer discount (%)
                            discount = getCustomerDiscount(BaseTypeID.low1);

                            // update OrderListExpand
                            updateOrderListExpandDB(OrderListID.ToString(), BaseTypeID.low1.ToString(), Number, Money, Money, discount);
                            NumberList.Add(Number);
                            TypeIDList.Add(BaseTypeID.low1);

                            // update Customer Buying Summary
                            updateCustomerBuyingToForm(NumberList, TypeIDList);
                            // update Buying Summary
                            updateBuyingToForm(NumberList, TypeIDList);

                            // update to Number_xxx
                            updateNumberXXXToDB(BaseTypeID.low1, Number, Money, Money);

                            // Customer Buying Check
                            buyingCustomerChecking(Convert.ToInt32(Money), BaseTypeID.low1);
                            break;
                        case BaseType.upfront1:
                            // one-to-one

                            // Add to Buying Table Form
                            AddBuyingListTable(Money, Group);

                            // update OrderList DB
                            updateOrderListDB(Number, Type, Money, Group);

                            // get OrderListID
                            OrderListID = getOrderListIDDB();

                            // get customer discount (%)
                            discount = getCustomerDiscount(BaseTypeID.upfront1);

                            // update OrderListExpand
                            updateOrderListExpandDB(OrderListID.ToString(), BaseTypeID.upfront1.ToString(), Number, Money, Money, discount);
                            NumberList.Add(Number);
                            TypeIDList.Add(BaseTypeID.upfront1);

                            // update Customer Buying Summary
                            updateCustomerBuyingToForm(NumberList, TypeIDList);
                            // update Buying Summary
                            updateBuyingToForm(NumberList, TypeIDList);

                            // update to Number_xxx
                            updateNumberXXXToDB(BaseTypeID.upfront1, Number, Money, Money);
                            break;
                        case BaseType.upcenter1:
                            // one-to-one

                            // Add to Buying Table Form
                            AddBuyingListTable(Money, Group);

                            // update OrderList DB
                            updateOrderListDB(Number, Type, Money, Group);

                            // get OrderListID
                            OrderListID = getOrderListIDDB();

                            // get customer discount (%)
                            discount = getCustomerDiscount(BaseTypeID.upcenter1);

                            // update OrderListExpand
                            updateOrderListExpandDB(OrderListID.ToString(), BaseTypeID.upcenter1.ToString(), Number, Money, Money, discount);
                            NumberList.Add(Number);
                            TypeIDList.Add(BaseTypeID.upcenter1);

                            // update Customer Buying Summary
                            updateCustomerBuyingToForm(NumberList, TypeIDList);
                            // update Buying Summary
                            updateBuyingToForm(NumberList, TypeIDList);

                            // update to Number_xxx
                            updateNumberXXXToDB(BaseTypeID.upcenter1, Number, Money, Money);
                            break;
                        case BaseType.upback1:
                            // one-to-one

                            // Add to Buying Table Form
                            AddBuyingListTable(Money, Group);

                            // update OrderList DB
                            updateOrderListDB(Number, Type, Money, Group);

                            // get OrderListID
                            OrderListID = getOrderListIDDB();
                            
                            // get customer discount (%)
                            discount = getCustomerDiscount(BaseTypeID.upback1);

                            // update OrderListExpand
                            updateOrderListExpandDB(OrderListID.ToString(), BaseTypeID.upback1.ToString(), Number, Money, Money, discount);
                            NumberList.Add(Number);
                            TypeIDList.Add(BaseTypeID.upback1);

                            // update Customer Buying Summary
                            updateCustomerBuyingToForm(NumberList, TypeIDList);
                            // update Buying Summary
                            updateBuyingToForm(NumberList, TypeIDList);

                            // update to Number_xxx
                            updateNumberXXXToDB(BaseTypeID.upback1, Number, Money, Money);
                            break;
                        case BaseType.lowfront1:
                            // one-to-one

                            // Add to Buying Table Form
                            AddBuyingListTable(Money, Group);

                            // update OrderList DB
                            updateOrderListDB(Number, Type, Money, Group);

                            // get OrderListID
                            OrderListID = getOrderListIDDB();
                            
                            // get customer discount (%)
                            discount = getCustomerDiscount(BaseTypeID.lowfront1);

                            // update OrderListExpand
                            updateOrderListExpandDB(OrderListID.ToString(), BaseTypeID.lowfront1.ToString(), Number, Money, Money, discount);
                            NumberList.Add(Number);
                            TypeIDList.Add(BaseTypeID.lowfront1);

                            // update Customer Buying Summary
                            updateCustomerBuyingToForm(NumberList, TypeIDList);
                            // update Buying Summary
                            updateBuyingToForm(NumberList, TypeIDList);

                            // update to Number_xxx
                            updateNumberXXXToDB(BaseTypeID.lowfront1, Number, Money, Money);
                            break;
                        case BaseType.lowback1:
                            // one-to-one

                            // Add to Buying Table Form
                            AddBuyingListTable(Money, Group);

                            // update OrderList DB
                            updateOrderListDB(Number, Type, Money, Group);

                            // get OrderListID
                            OrderListID = getOrderListIDDB();

                            // get customer discount (%)
                            discount = getCustomerDiscount(BaseTypeID.lowback1);

                            // update OrderListExpand
                            updateOrderListExpandDB(OrderListID.ToString(), BaseTypeID.lowback1.ToString(), Number, Money, Money, discount);
                            NumberList.Add(Number);
                            TypeIDList.Add(BaseTypeID.lowback1);

                            // update Customer Buying Summary
                            updateCustomerBuyingToForm(NumberList, TypeIDList);
                            // update Buying Summary
                            updateBuyingToForm(NumberList, TypeIDList);

                            // update to Number_xxx
                            updateNumberXXXToDB(BaseTypeID.lowback1, Number, Money, Money);
                            break;
                        case BaseType.uplow1:
                            // one-to-many

                            // Add to Buying Table Form
                            AddBuyingListTable(Money, Group);

                            // update OrderList DB
                            updateOrderListDB(Number, Type, Money, Group);

                            // get OrderListID
                            OrderListID = getOrderListIDDB();

                            // for up1
                            // get customer discount (%)
                            discount = getCustomerDiscount(BaseTypeID.up1);
                            // update OrderListExpand
                            updateOrderListExpandDB(OrderListID.ToString(), BaseTypeID.up1.ToString(), Number, Money, Money, discount);
                            NumberList.Add(Number);
                            TypeIDList.Add(BaseTypeID.up1);

                            // update to Number_xxx
                            updateNumberXXXToDB(BaseTypeID.up1, Number, Money, Money);

                            // for low1
                            // get customer discount (%)
                            discount = getCustomerDiscount(BaseTypeID.low1);
                            // update OrderListExpand
                            updateOrderListExpandDB(OrderListID.ToString(), BaseTypeID.low1.ToString(), Number, Money, Money, discount);
                            NumberList.Add(Number);
                            TypeIDList.Add(BaseTypeID.low1);

                            // updat to Number_xxx
                            updateNumberXXXToDB(BaseTypeID.low1, Number, Money, Money);

                            // update Customer Buying Summary
                            updateCustomerBuyingToForm(NumberList, TypeIDList);
                            // update Buying Summary
                            updateBuyingToForm(NumberList, TypeIDList);

                            // Customer Buying Check
                            buyingCustomerChecking(Convert.ToInt32(Money), BaseTypeID.up1);
                            // Customer Buying Check
                            buyingCustomerChecking(Convert.ToInt32(Money), BaseTypeID.low1);
                            break;
                        // Number 2
                        case BaseType.door19up2:
                            // one-to-many

                            // Add to Buying Table Form
                            AddBuyingListTable(Money, Group);

                            // update OrderList DB
                            updateOrderListDB(Number, Type, Money, Group);

                            // get OrderListID
                            OrderListID = getOrderListIDDB();

                            // Expand Number for 19 door up
                            foreach (string itemNumber in ExpandDoor19(Number))
                            {
                                // get customer discount (%)
                                discount = getCustomerDiscount(BaseTypeID.up2);
                                // update OrderListExpand
                                updateOrderListExpandDB(OrderListID.ToString(), BaseTypeID.up2.ToString(), itemNumber, Money, Money, discount);
                                NumberList.Add(itemNumber);
                                TypeIDList.Add(BaseTypeID.up2);

                                // update to Number_xxx
                                updateNumberXXXToDB(BaseTypeID.up2, itemNumber, Money, Money);
                            }
                            // update Customer Buying Summary
                            updateCustomerBuyingToForm(NumberList, TypeIDList);
                            // update Buying Summary
                            updateBuyingToForm(NumberList, TypeIDList);

                            // Customer Buying Check
                            buyingCustomerChecking(Convert.ToInt32(Money), BaseTypeID.up2);
                            break;
                        case BaseType.door19low2:
                            // one-to-many

                            // Add to Buying Table Form
                            AddBuyingListTable(Money, Group);

                            // update OrderList DB
                            updateOrderListDB(Number, Type, Money, Group);

                            // get OrderListID
                            OrderListID = getOrderListIDDB();

                            // Expand Number for 19 door low
                            foreach (string itemNumber in ExpandDoor19(Number))
                            {
                                // get customer discount (%)
                                discount = getCustomerDiscount(BaseTypeID.low2);
                                // update OrderListExpand
                                updateOrderListExpandDB(OrderListID.ToString(), BaseTypeID.low2.ToString(), itemNumber, Money, Money, discount);
                                NumberList.Add(itemNumber);
                                TypeIDList.Add(BaseTypeID.low2);

                                // update to Number_xxx
                                updateNumberXXXToDB(BaseTypeID.low2, itemNumber, Money, Money);
                            }
                            // update Customer Buying Summary
                            updateCustomerBuyingToForm(NumberList, TypeIDList);
                            // update Buying Summary
                            updateBuyingToForm(NumberList, TypeIDList);
                            // Customer Buying Check
                            buyingCustomerChecking(Convert.ToInt32(Money), BaseTypeID.low2);
                            break;
                        case BaseType.door19uplow2:
                            // one-to-many

                            // Add to Buying Table Form
                            AddBuyingListTable(Money, Group);

                            // update OrderList DB
                            updateOrderListDB(Number, Type, Money, Group);

                            // get OrderListID
                            OrderListID = getOrderListIDDB();

                            // for up2
                            // Expand Number for 19 door up
                            foreach (string itemNumber in ExpandDoor19(Number))
                            {
                                // get customer discount (%)
                                discount = getCustomerDiscount(BaseTypeID.up2);
                                // update OrderListExpand
                                updateOrderListExpandDB(OrderListID.ToString(), BaseTypeID.up2.ToString(), itemNumber, Money, Money, discount);
                                NumberList.Add(itemNumber);
                                TypeIDList.Add(BaseTypeID.up2);

                                // update to Number_xxx
                                updateNumberXXXToDB(BaseTypeID.up2, itemNumber, Money, Money);
                            }
                            // Customer Buying Check
                            buyingCustomerChecking(Convert.ToInt32(Money), BaseTypeID.up2);

                            // for low2
                            // Expand Number for 19 door low
                            foreach (string itemNumber in ExpandDoor19(Number))
                            {
                                // get customer discount (%)
                                discount = getCustomerDiscount(BaseTypeID.low2);
                                // update OrderListExpand
                                updateOrderListExpandDB(OrderListID.ToString(), BaseTypeID.low2.ToString(), itemNumber, Money, Money, discount);
                                NumberList.Add(itemNumber);
                                TypeIDList.Add(BaseTypeID.low2);

                                // update to Number_xxx
                                updateNumberXXXToDB(BaseTypeID.low2, itemNumber, Money, Money);
                            }
                            // Customer Buying Check
                            buyingCustomerChecking(Convert.ToInt32(Money), BaseTypeID.low2);
                            // update Customer Buying Summary
                            updateCustomerBuyingToForm(NumberList, TypeIDList);
                            // update Buying Summary
                            updateBuyingToForm(NumberList, TypeIDList);
                            break;
                        default:
                            // error
                            break;
                    }
                    break;
                case 2:
                    switch(Type)
                    {
                        case BaseType.up2:
                            // one-to-one

                            // Add to Buying Table Form
                            AddBuyingListTable(Money, Group);

                            // update OrderList DB
                            updateOrderListDB(Number, Type, Money, Group);

                            // get OrderListID
                            OrderListID = getOrderListIDDB();

                            // get customer discount (%)
                            discount = getCustomerDiscount(BaseTypeID.up2);
                            // update OrderListExpand
                            updateOrderListExpandDB(OrderListID.ToString(), BaseTypeID.up2.ToString(), Number, Money, Money, discount);
                            NumberList.Add(Number);
                            TypeIDList.Add(BaseTypeID.up2);

                            // update Customer Buying Summary
                            updateCustomerBuyingToForm(NumberList, TypeIDList);
                            // update Buying Summary
                            updateBuyingToForm(NumberList, TypeIDList);

                            // update to Number_xxx
                            updateNumberXXXToDB(BaseTypeID.up2, Number, Money, Money);

                            // Customer Buying Check
                            buyingCustomerChecking(Convert.ToInt32(Money), BaseTypeID.up2);
                            break;
                        case BaseType.low2:
                            // one-to-one

                            // Add to Buying Table Form
                            AddBuyingListTable(Money, Group);

                            // update OrderList DB
                            updateOrderListDB(Number, Type, Money, Group);

                            // get OrderListID
                            OrderListID = getOrderListIDDB();

                            // get customer discount (%)
                            discount = getCustomerDiscount(BaseTypeID.low2);
                            // update OrderListExpand
                            updateOrderListExpandDB(OrderListID.ToString(), BaseTypeID.low2.ToString(), Number, Money, Money, discount);
                            NumberList.Add(Number);
                            TypeIDList.Add(BaseTypeID.low2);

                            // update Customer Buying Summary
                            updateCustomerBuyingToForm(NumberList, TypeIDList);
                            // update Buying Summary
                            updateBuyingToForm(NumberList, TypeIDList);

                            // update to Number_xxx
                            updateNumberXXXToDB(BaseTypeID.low2, Number, Money, Money);

                            // Customer Buying Check
                            buyingCustomerChecking(Convert.ToInt32(Money), BaseTypeID.low2);
                            break;
                        case BaseType.tod2:
                            // one-to-many

                            // Add to Buying Table Form
                            AddBuyingListTable(Money, Group);

                            // update OrderList DB
                            updateOrderListDB(Number, Type, Money, Group);

                            // get OrderListID
                            OrderListID = getOrderListIDDB();

                            string todMoney = Convert.ToString(Convert.ToDouble(Money)*rateConvert(this.WinRate2freeup,this.WinRate2up));
                            string OwnPrice = Convert.ToString(Convert.ToDouble(Money) / (ExpandTod2(Number).Count*3));
                            // Exapnd Number for up2
                            foreach(string itemNumber in ExpandTod2(Number))
                            {
                                // get customer discount (%)
                                discount = getCustomerDiscount(BaseTypeID.tod2);
                                // update OrderListExpand
                                updateOrderListExpandDB(OrderListID.ToString(), BaseTypeID.up2.ToString(), itemNumber, todMoney, OwnPrice, discount);
                                NumberList.Add(itemNumber);
                                TypeIDList.Add(BaseTypeID.up2);

                                // update to Number_xxx
                                updateNumberXXXToDB(BaseTypeID.up2, itemNumber, todMoney, OwnPrice);
                            }
                            // Exapnd Numer for HU
                            foreach(string itemNumber in ExpandTod2(Number))
                            {
                                // get customer discount (%)
                                discount = getCustomerDiscount(BaseTypeID.tod2);
                                // update OrderListExpand
                                updateOrderListExpandDB(OrderListID.ToString(), BaseTypeID.hu2.ToString(), itemNumber, todMoney, OwnPrice, discount);
                                NumberList.Add(itemNumber);
                                TypeIDList.Add(BaseTypeID.hu2);

                                // update to Number_xxx
                                updateNumberXXXToDB(BaseTypeID.hu2, itemNumber, todMoney, OwnPrice);
                            }
                            // Expand Number for HT
                            foreach(string itemNumber in ExpandTod2(Number))
                            {
                                // get customer discount (%)
                                discount = getCustomerDiscount(BaseTypeID.tod2);
                                // update OrderListExpand
                                updateOrderListExpandDB(OrderListID.ToString(), BaseTypeID.ht2.ToString(), itemNumber, todMoney, OwnPrice, discount);
                                NumberList.Add(itemNumber);
                                TypeIDList.Add(BaseTypeID.ht2);

                                // update to Number_xxx
                                updateNumberXXXToDB(BaseTypeID.ht2, itemNumber, todMoney, OwnPrice);
                            }
                            // update Customer Buying Summary
                            updateCustomerBuyingToForm(NumberList, TypeIDList);
                            // update Buying Summary
                            updateBuyingToForm(NumberList, TypeIDList);
                            break;
                        case BaseType.uplow2:
                            // one-to-many

                            // Add to Buying Table Form
                            AddBuyingListTable(Money, Group);

                            // update OrderList DB
                            updateOrderListDB(Number, Type, Money, Group);

                            // get OrderListID
                            OrderListID = getOrderListIDDB();

                            // for up2
                            // get customer discount (%)
                            discount = getCustomerDiscount(BaseTypeID.up2);
                            // update OrderListExpand
                            updateOrderListExpandDB(OrderListID.ToString(), BaseTypeID.up2.ToString(), Number, Money, Money, discount);
                            NumberList.Add(Number);
                            TypeIDList.Add(BaseTypeID.up2);

                            // update to Number_xxx
                            updateNumberXXXToDB(BaseTypeID.up2, Number, Money, Money);

                            // Customer Buying Check
                            buyingCustomerChecking(Convert.ToInt32(Money), BaseTypeID.up2);

                            // for low2
                            // get customer discount (%)
                            discount = getCustomerDiscount(BaseTypeID.low2);
                            // update OrderListExpand
                            updateOrderListExpandDB(OrderListID.ToString(), BaseTypeID.low2.ToString(), Number, Money, Money, discount);
                            NumberList.Add(Number);
                            TypeIDList.Add(BaseTypeID.low2);

                            // update to Number_xxx
                            updateNumberXXXToDB(BaseTypeID.low2, Number, Money, Money);

                            // Customer Buying Check
                            buyingCustomerChecking(Convert.ToInt32(Money), BaseTypeID.low2);

                            // update Customer Buyinng Summary
                            updateCustomerBuyingToForm(NumberList, TypeIDList);
                            // update Buying Summary
                            updateBuyingToForm(NumberList, TypeIDList);
                            break;
                        case BaseType.door62:
                            // one-to-many

                            // Add to Buying Table Form
                            AddBuyingListTable(Money, Group);

                            // update OrderList DB
                            updateOrderListDB(Number, Type, Money, Group);

                            // get OrderListID
                            OrderListID = getOrderListIDDB();

                            // Expand for ht2
                            foreach (string itemNumber in ExpandDoor6(Number))
                            {
                                // get customer discount (%)
                                discount = getCustomerDiscount(BaseTypeID.up2);
                                // update OrderlistExpand
                                updateOrderListExpandDB(OrderListID.ToString(), BaseTypeID.ht2.ToString(), itemNumber, Money, Money, discount);
                                NumberList.Add(itemNumber);
                                TypeIDList.Add(BaseTypeID.ht2);

                                // update to Number_xxx
                                updateNumberXXXToDB(BaseTypeID.ht2, itemNumber, Money, Money);
                            }
                            // Expand for hu2
                            foreach(string itemNumber in ExpandDoor6(Number))
                            {
                                // get customer discount (%)
                                discount = getCustomerDiscount(BaseTypeID.up2);
                                // update OrderListExpand
                                updateOrderListExpandDB(OrderListID.ToString(), BaseTypeID.hu2.ToString(), itemNumber, Money, Money, discount);
                                NumberList.Add(itemNumber);
                                TypeIDList.Add(BaseTypeID.hu2);

                                // update to Number_xxx
                                updateNumberXXXToDB(BaseTypeID.hu2, itemNumber, Money, Money);
                            }
                            // Expand for up2
                            foreach(string itemNumber in ExpandDoor6(Number))
                            {
                                // get customer discount (%)
                                discount = getCustomerDiscount(BaseTypeID.up2);
                                // update OrderListExpand
                                updateOrderListExpandDB(OrderListID.ToString(), BaseTypeID.up2.ToString(), itemNumber, Money, Money, discount);
                                NumberList.Add(itemNumber);
                                TypeIDList.Add(BaseTypeID.up2);

                                // update to Number_xxx
                                updateNumberXXXToDB(BaseTypeID.up2, itemNumber, Money, Money);
                            }
                            // update Customer Buying Summary
                            updateCustomerBuyingToForm(NumberList, TypeIDList);
                            // update Buying Summary
                            updateBuyingToForm(NumberList, TypeIDList);
                            break;
                        case BaseType.ht2:
                            // one-to-one

                            // Add to Buying Table Form
                            AddBuyingListTable(Money, Group);

                            // update OrderList DB
                            updateOrderListDB(Number, Type, Money, Group);

                            // get OrderListID
                            OrderListID = getOrderListIDDB();

                            // get customer discount (%)
                            discount = getCustomerDiscount(BaseTypeID.ht2);
                            // update OrderListExpand
                            updateOrderListExpandDB(OrderListID.ToString(), BaseTypeID.ht2.ToString(), Number, Money, Money, discount);
                            NumberList.Add(Number);
                            TypeIDList.Add(BaseTypeID.ht2);

                            // update Customer Buying Summary
                            updateCustomerBuyingToForm(NumberList, TypeIDList);
                            // update Buying Summary
                            updateBuyingToForm(NumberList, TypeIDList);

                            // update to Number_xxx
                            updateNumberXXXToDB(BaseTypeID.ht2, Number, Money, Money);
                            break;
                        case BaseType.hu2:
                            // one-to-one

                            // Add to Buying Table Form
                            AddBuyingListTable(Money, Group);

                            // update OrderList DB
                            updateOrderListDB(Number, Type, Money, Group);

                            // get OrderListID
                            OrderListID = getOrderListIDDB();

                            // get customer discount (%)
                            discount = getCustomerDiscount(BaseTypeID.hu2);
                            // update OrderListExpand
                            updateOrderListExpandDB(OrderListID.ToString(), BaseTypeID.hu2.ToString(), Number, Money, Money, discount);
                            NumberList.Add(Number);
                            TypeIDList.Add(BaseTypeID.hu2);

                            // update Customer Buying Summary
                            updateCustomerBuyingToForm(NumberList, TypeIDList);
                            // update Buying Summary
                            updateBuyingToForm(NumberList, TypeIDList);

                            // update to Number_xxx
                            updateNumberXXXToDB(BaseTypeID.hu2, Number, Money, Money);
                            break;
                        
                        // Number 3
                        case BaseType.door543:
                            // one-to-many

                            // Add to Buying Table Form
                            AddBuyingListTable(Money, Group);

                            // update OrderList DB
                            updateOrderListDB(Number, Type, Money, Group);

                            // get OrderListID
                            OrderListID = getOrderListIDDB();

                            foreach (string itemNumber in ExpandDoor54(Number))
                            {
                                // get customer discount (%)
                                discount = getCustomerDiscount(BaseTypeID.up3);
                                // update OrderListExpand
                                updateOrderListExpandDB(OrderListID.ToString(), BaseTypeID.up3.ToString(), itemNumber, Money, Money, discount);
                                NumberList.Add(itemNumber);
                                TypeIDList.Add(BaseTypeID.up3);

                                // update to Number_xxx
                                updateNumberXXXToDB(BaseTypeID.up3, itemNumber, Money, Money);
                            }
                            // Customer Buying Check
                            buyingCustomerChecking(Convert.ToInt32(Money), BaseTypeID.up3);

                            // update Customer Buying Summary
                            updateCustomerBuyingToForm(NumberList, TypeIDList);
                            // update Buying Summary
                            updateBuyingToForm(NumberList, TypeIDList);
                            break;
                        default:
                            // error
                            break;
                    }
                    break;
                case 3:
                    switch(Type)
                    {
                        case BaseType.up3:
                            // one-to-one
                            
                            // Add to Buying Table Form
                            if(!string.IsNullOrEmpty(Group))
                            {
                                if(Convert.ToInt32(Group) > 0)
                                {
                                    AddBuyingListTable(Money, Group);
                                }
                                else
                                {
                                    AddBuyingListTable(Money, string.Empty);
                                }
                            }
                            
                            // update OrderList DB
                            updateOrderListDB(Number, Type, Money, Group);

                            // get OrderListID
                            OrderListID = getOrderListIDDB();

                            // get customer discount (%)
                            discount = getCustomerDiscount(BaseTypeID.up3);
                            // update OrderListExpand
                            updateOrderListExpandDB(OrderListID.ToString(), BaseTypeID.up3.ToString(), Number, Money, Money, discount);
                            NumberList.Add(Number);
                            TypeIDList.Add(BaseTypeID.up3);

                            // for group
                            if(!string.IsNullOrEmpty(Group))
                            {
                                if(Convert.ToInt32(Group) > 0)
                                {
                                    foreach (string itemNumber in ExpandGroup3(Number))
                                    {
                                        if(!string.Equals(itemNumber,Number))
                                        {
                                            // get customer discount (%)
                                            discount = getCustomerDiscount(BaseTypeID.tod3);
                                            //update OrderListExpand
                                            updateOrderListExpandDB(OrderListID.ToString(), BaseTypeID.up3.ToString(), itemNumber, Group, Group, discount);
                                            NumberList.Add(itemNumber);
                                            TypeIDList.Add(BaseTypeID.up3);

                                            // update to Number_xxx
                                            updateNumberXXXToDB(BaseTypeID.up3, itemNumber, Group, Group);
                                        }

                                    }
                                }

                            }
                            // update Customer Buying Summary
                            updateCustomerBuyingToForm(NumberList, TypeIDList);
                            // update Buying Summary
                            updateBuyingToForm(NumberList, TypeIDList);

                            // update to Number_xxx
                            updateNumberXXXToDB(BaseTypeID.up3, Number, Money, Money);

                            // Customer Buying Check
                            buyingCustomerChecking(Convert.ToInt32(Money), BaseTypeID.up3);
                            break;
                        case BaseType.uptod3:
                            // one-to-many

                            // Add to Buying Table Form
                            AddBuyingListTable(Money, Group);

                            // update OrderList DB
                            updateOrderListDB(Number, Type, Money, Group);

                            // get OrderListID
                            OrderListID = getOrderListIDDB();

                            // for up3
                            // get customer discount (%)
                            discount = getCustomerDiscount(BaseTypeID.up3);
                            // update OrderListExpand
                            updateOrderListExpandDB(OrderListID.ToString(), BaseTypeID.up3.ToString(), Number, Money, Money, discount);

                            // update to Number_xxx
                            updateNumberXXXToDB(BaseTypeID.up3, Number, Money, Money);
                            // for tod3
                            foreach(string itemNumber in ExpandTod3(Number))
                            {
                                string todMoney = Convert.ToString(Convert.ToDouble(Group) *rateConvert(this.WinRate3freeup,this.WinRate3up));
                                string OwnPrice = Convert.ToString(Convert.ToDouble(Group) / ExpandTod3(Number).Count);
                                // get customer discount (%)
                                discount = getCustomerDiscount(BaseTypeID.tod3);
                                //update OrderListExpand
                                updateOrderListExpandDB(OrderListID.ToString(), BaseTypeID.up3.ToString(), itemNumber, todMoney, OwnPrice, discount);
                                NumberList.Add(itemNumber);
                                TypeIDList.Add(BaseTypeID.up3);

                                // update to Number_xxx
                                updateNumberXXXToDB(BaseTypeID.up3, itemNumber, todMoney, OwnPrice);
                            }
                            // Customer Buying Check
                            buyingCustomerChecking(Convert.ToInt32(Money), BaseTypeID.uptod3);

                            // udpate Customer Buying Summary
                            updateCustomerBuyingToForm(NumberList, TypeIDList);
                            // update Buying Summary
                            updateBuyingToForm(NumberList, TypeIDList);
                            break;
                        case BaseType.group3:
                            // one-to-mnay

                            // Add to Buying Table Form
                            AddBuyingListTable(Money, Group);

                            // update OrderList DB
                            updateOrderListDB(Number, Type, Money, Group);

                            // get OrderListID
                            OrderListID = getOrderListIDDB();

                            // Expand for group3
                            foreach (string itemNumber in ExpandGroup3(Number))
                            {
                                // get customer discount (%)
                                discount = getCustomerDiscount(BaseTypeID.up3);
                                // update OrderListExpand
                                updateOrderListExpandDB(OrderListID.ToString(), BaseTypeID.up3.ToString(), itemNumber, Group, Group, discount);
                                NumberList.Add(itemNumber);
                                TypeIDList.Add(BaseTypeID.up3);

                                // update to Number_xxx
                                updateNumberXXXToDB(BaseTypeID.up3, itemNumber, Group, Group);
                            }
                            // Customer Buying Check
                            buyingCustomerChecking(Convert.ToInt32(Group), BaseTypeID.up3);

                            // update Customer Buying Summary
                            updateCustomerBuyingToForm(NumberList, TypeIDList);
                            // update Buying Summary
                            updateBuyingToForm(NumberList, TypeIDList);
                            break;
                        case BaseType.tgroup3:
                            // one-to-many
                            int _money = Convert.ToInt32(Money) + Convert.ToInt32(Group);
                            
                            // Add to Buying Table Form
                            AddBuyingListTable(_money.ToString(), Group);
                            // update OrderList DB
                            updateOrderListDB(Number, Type, _money.ToString(), Group);

                            // get OrderListID
                            OrderListID = getOrderListIDDB();

                            // Expand for up3
                            // get customer discount (%)
                            //discount = getCustomerDiscount(BaseTypeID.up3);
                            // update OrderListExpand
                            //updateOrderListExpandDB(OrderListID.ToString(), BaseTypeID.up3.ToString(), Number, Money, Money, discount);
                            // update to Number_xxx
                           // updateNumberXXXToDB(BaseTypeID.up3, Number, Money, Money);
                            // Customer Buying Check
                            //buyingCustomerChecking(Convert.ToInt32(Money), BaseTypeID.up3);

                            // Expand for group3
                            foreach (string itemNumber in ExpandGroup3(Number))
                            {
                                // get customer discount (%)
                                discount = getCustomerDiscount(BaseTypeID.up3);
                                if(string.Equals(itemNumber,Number))
                                {
                                    // update OrderListExpand
                                    updateOrderListExpandDB(OrderListID.ToString(), BaseTypeID.up3.ToString(), itemNumber, _money.ToString(), _money.ToString(), discount);
                                    // update to Number_xxx
                                    updateNumberXXXToDB(BaseTypeID.up3, itemNumber, _money.ToString(), _money.ToString());
                                }
                                else
                                {
                                    // update OrderListExpand
                                    updateOrderListExpandDB(OrderListID.ToString(), BaseTypeID.up3.ToString(), itemNumber, Group, Group, discount);
                                    // update to Number_xxx
                                    updateNumberXXXToDB(BaseTypeID.up3, itemNumber, Group, Group);
                                }
                                
                                NumberList.Add(itemNumber);
                                TypeIDList.Add(BaseTypeID.up3);
                            }
                            
                            // update Customer Buying Summary
                            updateCustomerBuyingToForm(NumberList, TypeIDList);
                            // update Buying Summary
                            updateBuyingToForm(NumberList, TypeIDList);
                            break;
                        case BaseType.group53:
                            // one-to-many

                            // Add to Buying Table Form
                            AddBuyingListTable(Money, Group);

                            // update OrderList DB
                            updateOrderListDB(Number, Type, Money, Group);

                            // get OrderListID
                            OrderListID = getOrderListIDDB();

                            // Expand for up3
                            // get customer discount (%)
                            discount = getCustomerDiscount(BaseTypeID.up3);
                            // update OrderListExpand
                            updateOrderListExpandDB(OrderListID.ToString(), BaseTypeID.up3.ToString(), Number, Money, Money, discount);
                            NumberList.Add(Number);
                            TypeIDList.Add(BaseTypeID.up3);

                            // update to Number_xxx
                            updateNumberXXXToDB(BaseTypeID.up3, Number, Money, Money);
                            // Customer Buying Check
                            buyingCustomerChecking(Convert.ToInt32(Money), BaseTypeID.up3);

                            // Expand for group5 without orignal number
                            List<string> listNumber = ExpandGroup3(Number);
                            // remove original number
                            int orgNumIdx = listNumber.IndexOf(Number);
                            listNumber.RemoveAt(orgNumIdx);
                            foreach(string itemNumber in listNumber)
                            {
                                // get customer discount (%)
                                discount = getCustomerDiscount(BaseTypeID.up3);
                                // update OrderListExpand
                                updateOrderListExpandDB(OrderListID.ToString(), BaseTypeID.up3.ToString(), itemNumber, Group, Group, discount);
                                NumberList.Add(itemNumber);
                                TypeIDList.Add(BaseTypeID.up3);

                                // update to Number_xxx
                                updateNumberXXXToDB(BaseTypeID.up3, itemNumber, Group, Group);
                            }
                            // update customer Buying Summary
                            updateCustomerBuyingToForm(NumberList, TypeIDList);
                            // update Buying Summary
                            updateBuyingToForm(NumberList, TypeIDList);
                            break;
                        case BaseType.tod3:
                            // one-to-many
                            
                            // Add to Buying Table Form
                            AddBuyingListTable(Money, Group);

                            // update OrderList DB
                            updateOrderListDB(Number, Type, Money, Group);

                            // get OrderListID
                            OrderListID = getOrderListIDDB();

                            // for tod3
                            foreach (string itemNumber in ExpandTod3(Number))
                            {
                                string todMoney = Convert.ToString(Convert.ToDouble(Money)*rateConvert(this.WinRate3freeup,this.WinRate3up));
                                string OwnPrice = Convert.ToString(Convert.ToDouble(Money) / ExpandTod3(Number).Count);
                                // get customer discount (%)
                                discount = getCustomerDiscount(BaseTypeID.tod3);
                                // update OrderListExpand
                                updateOrderListExpandDB(OrderListID.ToString(), BaseTypeID.up3.ToString(), itemNumber, todMoney, OwnPrice, discount);
                                NumberList.Add(itemNumber);
                                TypeIDList.Add(BaseTypeID.up3);

                                // update to Number_xxx
                                updateNumberXXXToDB(BaseTypeID.up3, itemNumber, todMoney, OwnPrice);
                            }

                            // update Customer Buying Summary
                            updateCustomerBuyingToForm(NumberList, TypeIDList);
                            // update Buying Summary
                            updateBuyingToForm(NumberList, TypeIDList);
                            break;
                        case BaseType.low3:
                            // one-to-one

                            // Add to Buying Table Form
                            AddBuyingListTable(Money, Group);

                            // update OrderList DB
                            updateOrderListDB(Number, Type, Money, Group);

                            // get OrderListID
                            OrderListID = getOrderListIDDB();

                            // get customer discount (%)
                            discount = getCustomerDiscount(BaseTypeID.low3);
                            // update OrderListExpand
                            updateOrderListExpandDB(OrderListID.ToString(), BaseTypeID.low3.ToString(), Number, Money, Money, discount);
                            NumberList.Add(Number);
                            TypeIDList.Add(BaseTypeID.low3);

                            // update Customer Buying Summary
                            updateCustomerBuyingToForm(NumberList, TypeIDList);
                            // update Buying Summary
                            updateBuyingToForm(NumberList, TypeIDList);

                            // update to Number_xxx
                            updateNumberXXXToDB(BaseTypeID.low3, Number, Money, Money);

                            // Customer Buying Check
                            buyingCustomerChecking(Convert.ToInt32(Money), BaseTypeID.low3);
                            break;
                        case BaseType.lowgroup3:
                            // one-to-many

                            // Add to Buying Table Form
                            AddBuyingListTable(Money, Group);

                            // update OrderList DB
                            updateOrderListDB(Number, Type, Money, Group);

                            // get OrderListID
                            OrderListID = getOrderListIDDB();

                            foreach (string itemNumber in ExpandGroup3(Number))
                            {
                                // get customer discount (%)
                                discount = getCustomerDiscount(BaseTypeID.low3);
                                // update OrderListExpand
                                updateOrderListExpandDB(OrderListID.ToString(), BaseTypeID.low3.ToString(), itemNumber, Group, Group, discount);
                                NumberList.Add(itemNumber);
                                TypeIDList.Add(BaseTypeID.low3);

                                // update to Number_xxx
                                updateNumberXXXToDB(BaseTypeID.low3, itemNumber, Group, Group);
                            }
                            // Customer Buying Check
                            buyingCustomerChecking(Convert.ToInt32(Group), BaseTypeID.low3);

                            // update Customer Buying Summary
                            updateCustomerBuyingToForm(NumberList, TypeIDList);
                            // update Buying Summary
                            updateBuyingToForm(NumberList, TypeIDList);
                            break;
                        case BaseType.uplowtod3:
                            // one-to-one (up3)

                            // Add to Buying Table Form
                            AddBuyingListTable(Money, Group);
                            
                            // update OrderList DB
                            updateOrderListDB(Number, Type, Money, Group);

                            // get OrderListID
                            OrderListID = getOrderListIDDB();

                            // get customer discount (%)
                            discount = getCustomerDiscount(BaseTypeID.up3);
                            // update OrderListExpand
                            updateOrderListExpandDB(OrderListID.ToString(), BaseTypeID.up3.ToString(), Number, Money, Money, discount);

                            // update to Number_xxx
                            updateNumberXXXToDB(BaseTypeID.up3, Number, Money, Money);

                            // Customer Buying Check
                            buyingCustomerChecking(Convert.ToInt32(Money), BaseTypeID.up3);

                            // one-to-one (low3)
                            // get customer discount (%)
                            discount = getCustomerDiscount(BaseTypeID.low3);
                            // update OrderListExpand
                            updateOrderListExpandDB(OrderListID.ToString(), BaseTypeID.low3.ToString(), Number, Money, Money, discount);
                            NumberList.Add(Number);
                            TypeIDList.Add(BaseTypeID.low3);

                            // update to Number_xxx
                            updateNumberXXXToDB(BaseTypeID.low3, Number, Money, Money);

                            // Customer Buying Check
                            buyingCustomerChecking(Convert.ToInt32(Money), BaseTypeID.low3);

                            // one-to-many (tod3)
                            foreach (string itemNumber in ExpandTod3(Number))
                            {
                                string todMoney = Convert.ToString(Convert.ToDouble(Group) *rateConvert(this.WinRate3freeup,this.WinRate3up));
                                string OwnPrice = Convert.ToString(Convert.ToDouble(Group) / ExpandTod3(Number).Count);
                                // get customer discount (%)
                                discount = getCustomerDiscount(BaseTypeID.tod3);
                                // update OrderListExpand
                                updateOrderListExpandDB(OrderListID.ToString(), BaseTypeID.up3.ToString(), itemNumber, todMoney, OwnPrice, discount);
                                NumberList.Add(itemNumber);
                                TypeIDList.Add(BaseTypeID.up3);

                                // update to Number_xxx
                                updateNumberXXXToDB(BaseTypeID.up3, itemNumber, todMoney, OwnPrice);
                                
                            }
                            // update Customer Buying Summary
                            updateCustomerBuyingToForm(NumberList, TypeIDList);
                            // update Buying Summary
                            updateBuyingToForm(NumberList, TypeIDList);
                            break;
                        default:
                            // error
                            break;
                    }
                    break;
                case 4:
                    switch(Type)
                    {
                        case BaseType.group4:
                            // one-to-many

                            // Add to Buying Table Form
                            AddBuyingListTable(Money, Group);

                            // update OrderList DB
                            updateOrderListDB(Number, Type, Money, Group);

                            // get OrderListID
                            OrderListID = getOrderListIDDB();

                            // Expand for group4
                            foreach (string itemNumber in ExpandGroup4(Number))
                            {
                                // get customer discount (%)
                                discount = getCustomerDiscount(BaseTypeID.up3);
                                // update OrderListExpand in DB
                                updateOrderListExpandDB(OrderListID.ToString(), BaseTypeID.up3.ToString(), itemNumber, Group, Group, discount);
                                NumberList.Add(itemNumber);
                                TypeIDList.Add(BaseTypeID.up3);

                                // update to Number_xxx
                                updateNumberXXXToDB(BaseTypeID.up3, itemNumber, Group, Group);
                            }
                            // Customer Buying Check
                            buyingCustomerChecking(Convert.ToInt32(Group), BaseTypeID.up3);

                            // update Customer Buying Summary
                            updateCustomerBuyingToForm(NumberList, TypeIDList);
                            // update Buying Summary
                            updateBuyingToForm(NumberList, TypeIDList);

                            break;
                        default:
                            // error
                            break;
                    }
                    break;
                case 5:
                    switch(Type)
                    {
                        case BaseType.group5:
                            // one-to-many

                            // Add to Buying Table Form
                            AddBuyingListTable(Money, Group);

                            // update OrderList DB
                            updateOrderListDB(Number, Type, Money, Group);

                            // get OrderListID
                            OrderListID = getOrderListIDDB();

                            // Expand for Group5
                            foreach (string itemNumber in ExpandGroup5(Number))
                            {
                                // get customer discount (%)
                                discount = getCustomerDiscount(BaseTypeID.up3);
                                // update OrderListExpand in DB
                                updateOrderListExpandDB(OrderListID.ToString(), BaseTypeID.up3.ToString(), itemNumber, Group, Group, discount);
                                NumberList.Add(itemNumber);
                                TypeIDList.Add(BaseTypeID.up3);

                                // update to Number_xxx
                                updateNumberXXXToDB(BaseTypeID.up3, itemNumber, Group, Group);
                            }
                            // Customer Buying Check
                            buyingCustomerChecking(Convert.ToInt32(Group), BaseTypeID.up3);

                            // update Customer Buying Summary
                            updateCustomerBuyingToForm(NumberList, TypeIDList);
                            // update Buying Summary
                            updateBuyingToForm(NumberList, TypeIDList);
                            break;
                        case BaseType.tod5:
                            // one-to-many

                            // Add to Buying Table Form
                            AddBuyingListTable(Money, Group);

                            // update OrderList DB
                            updateOrderListDB(Number, Type, Money, Group);

                            // get OrderListID
                            OrderListID = getOrderListIDDB();

                            // Expand for Tod5
                            foreach (string itemNumber in ExpandTod5(Number))
                            {
                                string todMoney = Convert.ToString(Convert.ToDouble(Money) * rateConvert(this.WinRate5free, this.WinRate3up));
                                string OwnPrice = Convert.ToString(Convert.ToDouble(Money) / ExpandTod5(Number).Count);
                                // get customer discount (%)
                                discount = getCustomerDiscount(BaseTypeID.tod5);
                                // update OrderListExpand in DB
                                updateOrderListExpandDB(OrderListID.ToString(), BaseTypeID.up3.ToString(), itemNumber, todMoney, OwnPrice, discount);
                                NumberList.Add(itemNumber);
                                TypeIDList.Add(BaseTypeID.up3);

                                // update to Number_xxx
                                updateNumberXXXToDB(BaseTypeID.up3, itemNumber, todMoney, OwnPrice);
                            }
                            // update customer buying Summary
                            updateCustomerBuyingToForm(NumberList, TypeIDList);
                            // update Buying Summary
                            updateBuyingToForm(NumberList, TypeIDList);
                            break;
                        default:
                            // error
                            break;
                    }
                    break;
                default:
                    // error
                    break;
                    

            }
        }
        private double rateConvert(int winrateFrom, int winrateTo)
        {
            return Convert.ToDouble(winrateFrom) / Convert.ToDouble(winrateTo);
        }
        private List<string> ExpandTod5(string Number)
        {
            return ExpandGroup4(Number);
        }
        private List<string> ExpandGroup5(string Number)
        {
            return ExpandGroup4(Number);
        }
        private List<string> ExpandGroup4(string Number)
        {
            List<string> ExpandNumber = new List<string>();
            for(int i = 0;i < Number.Length;i++)
            {
                for(int j = 0;j < Number.Length;j++)
                {
                    for(int k = 0;k < Number.Length;k++)
                    {
                        if((i != j) && (i != k) && (j != k))
                        {
                            ExpandNumber.Add(string.Format("{0}{1}{2}", Number[i], Number[j], Number[k]));
                        }
                    }
                }
            }
            List<string> uniqNumber = ExpandNumber.Distinct().ToList();
            return uniqNumber;

        }
        private List<string> ExpandGroup3(string Number)
        {
            return ExpandTod3(Number);
        }
        private List<string> ExpandDoor54(string Number)
        {
            List<string> ExpandNumber = new List<string>();
            // for 12*
            for(int num = 0;num < 10;num++)
            {
                ExpandNumber.Add(string.Format("{0}{1}{2}", Number[0], Number[1],num.ToString()));
            }
            for(int num = 0;num < 10;num++)
            {
                ExpandNumber.Add(string.Format("{1}{0}{2}", Number[0], Number[1], num.ToString()));
            }
            // for 1*2
            for(int num = 0;num < 10;num++)
            {
                ExpandNumber.Add(string.Format("{0}{2}{1}", Number[0], Number[1], num.ToString()));
            }
            for(int num = 0;num < 10;num++)
            {
                ExpandNumber.Add(string.Format("{1}{2}{0}", Number[0], Number[1], num.ToString()));
            }
            // for *12
            for(int num = 0;num < 10;num++)
            {
                ExpandNumber.Add(string.Format("{2}{0}{1}", Number[0], Number[1], num.ToString()));
            }
            for(int num = 0;num < 10;num++)
            {
                ExpandNumber.Add(string.Format("{2}{1}{0}", Number[0], Number[1], num.ToString()));
            }
            List<string> uniqueNumber = ExpandNumber.Distinct().ToList();
            return uniqueNumber;
            
        }
        private List<string> ExpandDoor19(string Number)
        {
            List<string> ExpandNumber = new List<string>();
            ExpandNumber.Add(string.Format("{0}{1}", Number, Number));
            for (int num = 0; num < 10; num++)
            {
                if (Convert.ToInt32(Number) != num)
                {
                    ExpandNumber.Add(string.Format("{0}{1}", Number, num.ToString()));
                }
            }
            for (int num = 0; num < 10; num++)
            {
                if (Convert.ToInt32(Number) != num)
                {
                    ExpandNumber.Add(string.Format("{1}{0}", Number, num.ToString()));
                }
            }
            // remove duplicated item
            List<string> uniqueNumber = ExpandNumber.Distinct().ToList();
            return uniqueNumber;
        }
        private List<string> ExpandDoor6(string Number)
        {
            List<string> ExpandNumber = new List<string>();
            //for HT
            ExpandNumber.Add(string.Format("{0}{1}", Number[0], Number[1]));
            ExpandNumber.Add(string.Format("{1}{0}", Number[0], Number[1]));
            // remove duplicated item
            List<string> uniqueNumber = ExpandNumber.Distinct().ToList();
            return uniqueNumber;
        }
        private List<string> ExpandTod2(string Number)
        {
            return ExpandDoor6(Number);
        }
        private List<string> ExpandTod3(string Number)
        {
            List<string> ExpandNumber = new List<string>();
            ExpandNumber.Add(string.Format("{0}{1}{2}", Number[0], Number[1], Number[2]));
            ExpandNumber.Add(string.Format("{2}{1}{0}", Number[0], Number[1], Number[2]));
            ExpandNumber.Add(string.Format("{0}{2}{1}", Number[0], Number[1], Number[2]));
            ExpandNumber.Add(string.Format("{1}{2}{0}", Number[0], Number[1], Number[2]));
            ExpandNumber.Add(string.Format("{1}{0}{2}", Number[0], Number[1], Number[2]));
            ExpandNumber.Add(string.Format("{2}{0}{1}", Number[0], Number[1], Number[2]));

            //remove duplicated item
            List<string> uniqeNumber = ExpandNumber.Distinct().ToList();
            return uniqeNumber;
        }

        private void updateOrderListExpandDB(string orderlistid,string typeid, string number, string money, string OwnPrice, int Pdiscount)
        {
            SqlConnection connection = new SqlConnection(Database.CnnVal("LottoryDB"));

            if (connection.State == ConnectionState.Closed)
            {
                connection.Open(); // Open Database
            }
            string DisPrice = Convert.ToString(Convert.ToDouble(OwnPrice) * Convert.ToDouble(Pdiscount) / 100.0);
            string sqlupdateOrderListExpand = string.Format("INSERT INTO OrderListExpand(OrderListID, TypeID, Number, Price, OwnPrice, DiscPrice) VALUES({0},{1},'{2}',{3},{4},{5})", orderlistid, typeid, number, money, OwnPrice, DisPrice);
            SqlCommand sqlupdateOrderListExpandCom = new SqlCommand(sqlupdateOrderListExpand, connection);
            sqlupdateOrderListExpandCom.ExecuteNonQuery();
            connection.Close();
        }
        private int getCustomerDiscount(int typeID)
        {
            int discount;
            switch(typeID)
            {
                case BaseTypeID.up3:
                    discount = this.dc_3up;
                    break;
                case BaseTypeID.low3:
                    discount = this.dc_3low;
                    break;
                case BaseTypeID.uptod3:
                    discount = this.dc_3freeup;
                    break;
                case BaseTypeID.up2:
                    discount = this.dc_2up;
                    break;
                case BaseTypeID.low2:
                    discount = this.dc_2low;
                    break;
                case BaseTypeID.tod2:
                    discount = this.dc_2freeup;
                    break;
                case BaseTypeID.up1:
                    discount = this.dc_1freeup;
                    break;
                case BaseTypeID.upfront1:
                    discount = this.dc_1front;
                    break;
                case BaseTypeID.upcenter1:
                    discount = this.dc_1center;
                    break;
                case BaseTypeID.upback1:
                    discount = this.dc_1back;
                    break;
                case BaseTypeID.low1:
                    discount = this.dc_1freelow;
                    break;
                case BaseTypeID.tod5:
                    discount = this.dc_5free;
                    break;
                default:
                    discount = 0;
                    break;
            }
            return discount;
        }

        private int getOrderListIDDB()
        {
            SqlConnection connection = new SqlConnection(Database.CnnVal("LottoryDB"));

            // get orderlistID
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open(); // Open Database
            }
            string sqlgetOrderListID = "SELECT MAX(OrderListID) FROM OrderList";
            SqlCommand sqlgetOrderListIDCom = new SqlCommand(sqlgetOrderListID, connection);
            SqlDataReader orderListIDInfo = sqlgetOrderListIDCom.ExecuteReader();
            int OrderListID = 0;
            if (orderListIDInfo.Read())
            {
                OrderListID = Convert.ToInt32(orderListIDInfo[0]);
            }
            connection.Close();

            return OrderListID;
        }

        private void tbMoney1_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Enter:
                    if (tbMoney2.Enabled)
                    {
                        // stop sound when enter
                        e.Handled = true;
                        e.SuppressKeyPress = true;
                        if (!string.IsNullOrEmpty(tbMoney1.Text)) // Check Money1 Empty 
                        {
                            //check buying error and warning
                            if (buyingLimitChecking(Convert.ToInt32(tbMoney1.Text)))
                            {// over buying
                                MessageBox.Show(string.Format("คำสั่งซื้อเกินวงเงินที่กำหนด", "จำกัดวงเงิน"));
                            }
                            else
                            {// not over buying
                             // Move to Money2
                                tbMoney2.SelectAll();
                                tbMoney2.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("กรุณาใส่จำนวนเงิน", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }


                    }
                    else
                    {
                        // stop sound when enter
                        e.Handled = true;
                        e.SuppressKeyPress = true;
                        if (!string.IsNullOrEmpty(tbMoney1.Text))
                        {
                            //check buying error and warning
                            if (buyingLimitChecking(Convert.ToInt32(tbMoney1.Text)))
                            {// over buying
                                MessageBox.Show(string.Format("คำสั่งซื้อเกินวงเงินที่กำหนด", "จำกัดวงเงิน"));
                            }
                            else if (NumberLimitChecking(tbNumber.Text, tbType.Text.Substring(1, tbType.Text.Length - 1), tbMoney1.Text))
                            {
                                MessageBox.Show("คำสั่งซื้อตัวเลขนี้เกินวงเงินอั้น", "เกินวงเงินอั้น");
                            }
                            else
                            {// not over buying
                             // Add Buying command to Display Table
                                AddNumberToTable();
                                //Move to Number 
                                tbNumber.SelectAll();
                                tbNumber.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("กรุณาใส่จำนวนเงิน", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    break;
                case Keys.PageDown:
                    // Buy 
                    ShortBuying();
                    break;
            }

        }
        private bool NumberLimitChecking(string Number, string TypeName, string Price)
        {
            bool overLimit = false;
            SqlConnection connection = new SqlConnection(Database.CnnVal("LottoryDB"));
            if(connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            string sqlgetLimitPrice = string.Format(@"SELECT LimitPrice FROM LimitNumber
                                                      WHERE Number = {0} AND TypeID = {1}", Number, getTypeID(TypeName, Number.Length));
            SqlCommand sqlgetLimitPriceCom = new SqlCommand(sqlgetLimitPrice, connection);
            SqlDataReader LimitPriceInfo = sqlgetLimitPriceCom.ExecuteReader();
            while(LimitPriceInfo.Read())
            {
                int _LimitPrice = Convert.ToInt32(LimitPriceInfo["LimitPrice"]);
                if(Convert.ToInt32(Price) > _LimitPrice)
                {
                    overLimit = true;
                }
            }
            return overLimit;
        }
        private int getTypeID(string typeName, int Numberlen)
        {
            int TypeID = 0;
            // selete typeid
            switch (typeName)
            {
                case "บน":
                    switch (Numberlen)
                    {
                        case 2:
                            TypeID = BaseTypeID.up2;
                            break;
                        case 3:
                            TypeID = BaseTypeID.up3;
                            break;
                    }
                    break;
                case "บน/โต๊ด":
                    TypeID = BaseTypeID.uptod3;
                    break;
                case "ล่าง":
                    TypeID = BaseTypeID.low2;
                    break;
                default:
                    // error
                    break;
            }
            return TypeID;
        }
        private void tbMoney2_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                // stop sound when enter
                e.Handled = true;
                e.SuppressKeyPress = true;
                //check buying error and warning

                if ((tbMoney1.Enabled == true) && (tbMoney2.Enabled == true))
                {
                    if (!string.IsNullOrEmpty(tbMoney2.Text))
                    {
                        int _money1 = Convert.ToInt32(tbMoney1.Text);
                        int _money2 = Convert.ToInt32(tbMoney2.Text);
                        if (buyingLimitChecking(_money1) || buyingLimitChecking(_money2))
                        {// over buying
                            MessageBox.Show(string.Format("คำสั่งซื้อเกินวงเงินที่กำหนด", "จำกัดวงเงิน"));
                        }
                        else
                        {// not over buying
                         // Add Buying command to Display Table
                            AddNumberToTable();
                            // Move to Number
                            tbNumber.SelectAll();
                            tbNumber.Focus();
                        }
                    }
                }
                else if ((tbMoney1.Enabled == false) && (tbMoney2.Enabled == true))
                {
                    if (!string.IsNullOrEmpty(tbMoney2.Text))
                    {
                        int _money2 = Convert.ToInt32(tbMoney2.Text);
                        if (buyingLimitChecking(_money2))
                        {// over buying
                            MessageBox.Show(string.Format("คำสั่งซื้อเกินวงเงินที่กำหนด", "จำกัดวงเงิน"));
                        }
                        else
                        {// not over buying
                         // Add Buying command to Display Table
                            AddNumberToTable();
                            // Move to Number
                            tbNumber.SelectAll();
                            tbNumber.Focus();
                        }
                    }

                }
            }
        }
        private bool buyingLimitChecking(int BuyingPrice)
        {
            bool overBuying = false;
            int buyingLimit = Int32.MaxValue;
            switch(tbNumber.Text.Length)
            {
                case 1:
                    buyingLimit = AddNumberSetting.BuyingLimit1;
                    break;
                case 2:
                    buyingLimit = AddNumberSetting.BuyingLimit2;
                    break;
                case 3:
                    buyingLimit = AddNumberSetting.BuyingLimit3;
                    break;
                case 4:
                    buyingLimit = AddNumberSetting.BuyingLimit4;
                    break;
                case 5:
                    buyingLimit = AddNumberSetting.BuyingLimit5;
                    break;
                default:
                    //error
                    break;
            }
            if(BuyingPrice > buyingLimit)
            {
                overBuying = true;
            }
            else
            {
                overBuying = false;
            }
            return overBuying;
        }
        private void ChangeCustomer_Click(object sender, EventArgs e)
        {
            // Show Number Setting
            AddNumberSetting numbersettingInstance = AddNumberSetting.Instance;
            numbersettingInstance.Show();

            // close Windows
            this.Close();
        }

        private void CloseWindows_Click(object sender, EventArgs e)
        {
            // Close Windows
            this.Close();
        }

        private void Summary_Click(object sender, EventArgs e)
        {

            //Show NumberBuyingList
            MainLotto mainLotto = (MainLotto)MdiParent;
            mainLotto.ShowForm(BuyingSummary.Instance);

        }
        private void deleteBuyingListItem(DataGridViewRow item)
        {
            // Delete Seleted Rows
            dgvCusBuyList.Rows.Remove(item);

            // Delete Data from DB
            string Number = item.Cells[0].Value.ToString();
            string Type = item.Cells[1].Value.ToString();
            //string Price = item.Cells[2].Value;
            //string GroupPrice = item.Cells[3].Value;
            if (Convert.ToString(item.Cells[3].Value) == string.Empty)
            {
                string Price = item.Cells[2].Value.ToString();
                // Delete Buying List From DB
                DeleteBuyingListFromDB(this.OrderID, Number, Type, Price, string.Empty);
            }
            else if (Convert.ToString(item.Cells[2].Value) == string.Empty)
            {
                string GroupPrice = item.Cells[3].Value.ToString();
                // Delete Buying List From DB
                DeleteBuyingListFromDB(this.OrderID, Number, Type, string.Empty, GroupPrice);
            }
            else
            {
                // Delete Buying List From DB
                string Price = item.Cells[2].Value.ToString();
                string GroupPrice = item.Cells[3].Value.ToString();
                DeleteBuyingListFromDB(this.OrderID, Number, Type, Price, GroupPrice);
            }
        }
        private void Delete_specific_Click(object sender, EventArgs e)
        {
            DialogResult deleteRes = MessageBox.Show("ต้องการลบข้อมูลที่เลือกหรือไม่", "ยืนยันการลบข้อมูล", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            switch (deleteRes)
            {
                case DialogResult.Yes:
                    // Delete specific Rows
                    foreach (DataGridViewRow item in this.dgvCusBuyList.Rows)
                    {
                        if (Convert.ToBoolean(item.Cells[4].Value))
                        {
                            deleteBuyingListItem(item);
                        }
                    }
                    break;
                case DialogResult.No:
                    // Do Nothing
                    break;
            }

        }

        private void Delete_all_Click(object sender, EventArgs e)
        {
            DialogResult deleteRes = MessageBox.Show("ต้องการลบข้อมูลทั้งหมดหรือไม่", "ยืนยันการลบข้อมูล", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            switch (deleteRes)
            {
                case DialogResult.Yes:
                // Delete Seleted Rows
                foreach (DataGridViewRow item in this.dgvCusBuyList.Rows)
                {

                    deleteBuyingListItem(item);

                }
                break;
                case DialogResult.No:
                    // Do Nothing
                    break;
            }
        }

        private void dgvCusBuyList_KeyDown(object sender, KeyEventArgs e)
        {
            // Delete Key Down
            if(e.KeyCode == Keys.Delete)
            {
                DialogResult deleteRes = MessageBox.Show("ต้องการลบข้อมูลหรือไม่", "ยืนยันการลบข้อมูล", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                switch(deleteRes)
                {
                    case DialogResult.Yes:
                        // Delete Seleted Rows
                        foreach (DataGridViewRow item in this.dgvCusBuyList.SelectedRows)
                        {
                            deleteBuyingListItem(item);
                        }
                        break;
                    case DialogResult.No:
                        // Do Nothing
                        break;
                }

            }

        }
        private void deletePriceFromNumberXXX(int TypeID,string Number, float Price, float OwnPrice)
        {
            SqlConnection connection = new SqlConnection(Database.CnnVal("LottoryDB"));

            // get orderlistID
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open(); // Open Database
            }
            string sqlreduce;
            string dbTableName = string.Empty;
            switch (TypeID)
            {
                case BaseTypeID.up1:
                case BaseTypeID.upfront1:
                case BaseTypeID.upcenter1:
                case BaseTypeID.upback1:
                    dbTableName = "Number_1up";
                    break;
                case BaseTypeID.low1:
                case BaseTypeID.lowfront1:
                case BaseTypeID.lowback1:
                    dbTableName = "Number_1low";
                    break;
                case BaseTypeID.up2:
                case BaseTypeID.ht2:
                case BaseTypeID.hu2:
                    dbTableName = "Number_2up";
                    break;
                case BaseTypeID.low2:
                    dbTableName = "Number_2low";
                    break;
                case BaseTypeID.up3:
                    dbTableName = "Number_3up";
                    break;
                case BaseTypeID.low3:
                    dbTableName = "Number_3low";
                    break;
                default:
                    // error
                    break;
            }
            sqlreduce = string.Format(@"UPDATE {0}
                                        SET Price = Price - {1}, OwnPrice = OwnPrice - {2}
                                        WHERE Number = '{3}'", dbTableName, Price.ToString(), OwnPrice.ToString(), Number);
            SqlCommand sqlreduceCom = new SqlCommand(sqlreduce, connection);
            sqlreduceCom.ExecuteNonQuery();
            connection.Close();

            // round to zero
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open(); // Open Database
            }
            string sqlroundzero = string.Format(@"UPDATE {0}
                                                  SET Price = 0
                                                  WHERE Price < 0.0001", dbTableName);
            SqlCommand sqlroundzeroCom = new SqlCommand(sqlroundzero, connection);
            sqlroundzeroCom.ExecuteNonQuery();
            sqlroundzeroCom.CommandText = string.Format(@"UPDATE {0}
                                                          SET OwnPrice = 0
                                                          WHERE OwnPrice < 0.0001", dbTableName);
            sqlroundzeroCom.ExecuteNonQuery();
            connection.Close();
            
        }
        private void DeleteBuyingListFromDB(string OrderID, string Number, string Type, string Price, string GroupPrice)
        {
            SqlConnection connection = new SqlConnection(Database.CnnVal("LottoryDB"));

            // get orderlistID
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open(); // Open Database
            }
            string sqlgetOrderListID;
            if(string.IsNullOrEmpty(GroupPrice))
            {
                sqlgetOrderListID = string.Format(@"SELECT o.OrderListID
                                                       FROM (OrderList o INNER JOIN OrderListExpand oe ON o.OrderListID = oe.OrderListID) INNER JOIN TypeNumberInfo t ON o.TypeID = t.TypeID
                                                       WHERE (o.OrderID = {0}) AND (t.TypeName = N'{2}') AND (o.Number = '{1}') AND (o.Price = {3})", OrderID, Number, Type, Price);
            }
            else if(string.IsNullOrEmpty(Price))
            {
                sqlgetOrderListID = string.Format(@"SELECT o.OrderListID
                                                       FROM (OrderList o INNER JOIN OrderListExpand oe ON o.OrderListID = oe.OrderListID) INNER JOIN TypeNumberInfo t ON o.TypeID = t.TypeID
                                                       WHERE (o.OrderID = {0}) AND (t.TypeName = N'{2}') AND (o.Number = '{1}') AND (o.GroupPrice = {3})", OrderID, Number, Type, GroupPrice);
            }
            else
            {
                sqlgetOrderListID = string.Format(@"SELECT o.OrderListID
                                                       FROM (OrderList o INNER JOIN OrderListExpand oe ON o.OrderListID = oe.OrderListID) INNER JOIN TypeNumberInfo t ON o.TypeID = t.TypeID
                                                       WHERE (o.OrderID = {0}) AND (t.TypeName = N'{2}') AND (o.Number = '{1}') AND (o.Price = {3}) AND (o.GroupPrice = {4})", OrderID, Number, Type, Price, GroupPrice);
            }

            SqlCommand sqlgetOrderListIDCom = new SqlCommand(sqlgetOrderListID, connection);
            SqlDataReader OrderListID = sqlgetOrderListIDCom.ExecuteReader();
            if (OrderListID.Read())
            {
                // Reduce Price from Number_xxx
                SqlConnection connection1 = new SqlConnection(Database.CnnVal("LottoryDB"));
                if (connection1.State == ConnectionState.Closed)
                {
                    connection1.Open(); // Open Database
                }
                string sqlgetNumberList = string.Format("SELECT Number, TypeID, Price, OwnPrice FROM OrderListExpand WHERE OrderListID = {0}", OrderListID["OrderListID"].ToString());
                SqlCommand sqlgetNumberListCom = new SqlCommand(sqlgetNumberList, connection1);
                SqlDataReader NumberListInfo = sqlgetNumberListCom.ExecuteReader();
                while (NumberListInfo.Read())
                {
                    // Reduce Price from Number_xxx
                    int _TypeID = Convert.ToInt32(NumberListInfo["TypeID"]);
                    string _Number = NumberListInfo["Number"].ToString();
                    double _Price = Convert.ToDouble(NumberListInfo["Price"]);
                    double _OwnPrice = Convert.ToDouble(NumberListInfo["OwnPrice"]);
                    deletePriceFromNumberXXX(_TypeID, _Number, (float)_Price, (float)_OwnPrice);

                }
                connection1.Close();

                // Delete Buying List via OrderListID
                if (connection1.State == ConnectionState.Closed)
                {
                    connection1.Open(); // Open Database
                }
                string sqldeleteOrderList = string.Format("DELETE FROM OrderList WHERE OrderListID = {0}", OrderListID["OrderListID"].ToString());
                SqlCommand sqldeleteOrderListCom = new SqlCommand(sqldeleteOrderList, connection1);
                sqldeleteOrderListCom.ExecuteNonQuery();
                sqldeleteOrderListCom.CommandText = string.Format("DELETE FROM OrderListExpand WHERE OrderListID = {0}", OrderListID["OrderListID"].ToString());
                sqldeleteOrderListCom.ExecuteNonQuery();
                connection1.Close();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //update Number_xxx
            showNumberXXXToForm();

            //update summary table
            showSummaryToForm();

        }
        private void updateNumberXXXToDB(int TypeID, string Number, string Price, string OwnPrice)
        {
            SqlConnection connection = new SqlConnection(Database.CnnVal("LottoryDB"));

            // get orderlistID
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open(); // Open Database
            }
            string sqlupdate;
            string dbTableName = string.Empty;
            switch (TypeID)
            {
                case BaseTypeID.up1: // set update table to Number_1up
                    dbTableName = "Number_1up";
                    break;
                case BaseTypeID.upfront1: // set update table to Number_1upfront
                    dbTableName = "Number_1upfront";
                    break;
                case BaseTypeID.upcenter1:
                    dbTableName = "Number_1upcenter"; // set update table to Number_1upcenter
                    break;
                case BaseTypeID.upback1:
                    dbTableName = "Number_1upback"; // set update table to Number_1upback
                    break;
                case BaseTypeID.low1: // set update table to Number_1low
                    dbTableName = "Number_1low";
                    break;
                case BaseTypeID.lowfront1:
                    dbTableName = "Number_1lowfront"; // set update table to Number_1lowfront
                    break;
                case BaseTypeID.lowback1:
                    dbTableName = "Number_1lowback"; // set update table to Number_1lowback
                    break;
                case BaseTypeID.up2: // set update table to Number_2up
                    dbTableName = "Number_2up";
                    break;
                case BaseTypeID.ht2:
                    dbTableName = "Number_2ht"; // set update table to Number_2ht
                    break;
                case BaseTypeID.hu2:
                    dbTableName = "Number_2hu"; // set update table to Number_2hu
                    break;
                case BaseTypeID.low2: // set update table to to Number_2low
                    dbTableName = "Number_2low";
                    break;
                case BaseTypeID.up3: // set update table to Number_3up
                    dbTableName = "Number_3up";
                    break;
                case BaseTypeID.low3: // set update table to Number_3low
                    dbTableName = "Number_3low";
                    break;
                default:
                    // error
                    break;
            }
            sqlupdate = string.Format(@"UPDATE {2}
                                                SET Price = Price + {0}, OwnPrice = OwnPrice + {3}
                                                WHERE Number = '{1}'", Price, Number,dbTableName,OwnPrice);
            SqlCommand sqlupdateCom = new SqlCommand(sqlupdate, connection);
            sqlupdateCom.ExecuteNonQuery();
            connection.Close();
        }
        private void showNumberXXXToForm()
        {
            // show for 3up
            DataTable Number3up = getNumberXXXFromDB(BaseTypeID.up3);
            dgvNumber3up.DataSource = Number3up;
            dgvNumber3up.ClearSelection();

            // show for 3low
            DataTable Number3low = getNumberXXXFromDB(BaseTypeID.low3);
            dgvNumber3low.DataSource = Number3low;
            dgvNumber3low.ClearSelection();

            // show for 2up
            DataTable Number2up = getNumberXXXFromDB(BaseTypeID.up2);
            dgvNumber2up.DataSource = Number2up;
            dgvNumber2up.ClearSelection();

            // show for 2low
            DataTable Number2low = getNumberXXXFromDB(BaseTypeID.low2);
            dgvNumber2low.DataSource = Number2low;
            dgvNumber2low.ClearSelection();

            // show for 1up
            DataTable Number1up = getNumberXXXFromDB(BaseTypeID.up1);
            dgvNumber1up.DataSource = Number1up;
            dgvNumber1up.ClearSelection();

            // show for 1low
            DataTable Number1low = getNumberXXXFromDB(BaseTypeID.low1);
            dgvNumber1low.DataSource = Number1low;
            dgvNumber1low.ClearSelection();
        }
        private void showSummaryToForm()
        {
            DataTable summary = getSummaryFromDB();
            TbSummary.DataSource = summary;
            TbSummary.ClearSelection();
        }
        private DataTable getSummaryFromDB()
        {
            DataTable summaryTb = new DataTable();
            // Declear Column Name
            string type = "ชนิด";
            string sumPrice = "ยอดในมือ";
            string discount = "หัก %";
            string net = "สุทธิ";
            // Declear Row Name
            string up3 = "3 บน";
            string up2 = "2 บน";
            string low2 = "2 ล่าง";
            string low3 = "3 ล่าง";
            string up1 = "1 บน";
            string low1 = "1 ล่าง";

            // Create Header Column 
            summaryTb.Columns.Add(type);
            summaryTb.Columns.Add(sumPrice);
            summaryTb.Columns.Add(discount);
            summaryTb.Columns.Add(net);

            // Add Row Data
            summaryTb.Rows.Add(up3, 0, 0, 0);
            summaryTb.Rows.Add(up2, 0, 0, 0);
            summaryTb.Rows.Add(low2, 0, 0, 0);
            summaryTb.Rows.Add(low3, 0, 0, 0);
            summaryTb.Rows.Add(up1, 0, 0, 0);
            summaryTb.Rows.Add(low1, 0, 0, 0);

            // get Sum Price from DB
            summaryTb.Rows[0][sumPrice] = getSumPriceFromDB(BaseTypeID.up3).ToString("N0");
            summaryTb.Rows[1][sumPrice] = getSumPriceFromDB(BaseTypeID.up2).ToString("N0");
            summaryTb.Rows[2][sumPrice] = getSumPriceFromDB(BaseTypeID.low2).ToString("N0");
            summaryTb.Rows[3][sumPrice] = getSumPriceFromDB(BaseTypeID.low3).ToString("N0");
            summaryTb.Rows[4][sumPrice] = getSumPriceFromDB(BaseTypeID.up1).ToString("N0");
            summaryTb.Rows[5][sumPrice] = getSumPriceFromDB(BaseTypeID.low1).ToString("N0");

            // get Discount Price from DB
            summaryTb.Rows[0][discount] = getDiscountPriceFromDB(BaseTypeID.up3).ToString("N0");
            summaryTb.Rows[1][discount] = getDiscountPriceFromDB(BaseTypeID.up2).ToString("N0");
            summaryTb.Rows[2][discount] = getDiscountPriceFromDB(BaseTypeID.low2).ToString("N0");
            summaryTb.Rows[3][discount] = getDiscountPriceFromDB(BaseTypeID.low3).ToString("N0");
            summaryTb.Rows[4][discount] = getDiscountPriceFromDB(BaseTypeID.up1).ToString("N0");
            summaryTb.Rows[5][discount] = getDiscountPriceFromDB(BaseTypeID.low1).ToString("N0");

            // get net price
            summaryTb.Rows[0][net] = Convert.ToDouble(getSumPriceFromDB(BaseTypeID.up3) - getDiscountPriceFromDB(BaseTypeID.up3)).ToString("N0");
            summaryTb.Rows[1][net] = Convert.ToDouble(getSumPriceFromDB(BaseTypeID.up2) - getDiscountPriceFromDB(BaseTypeID.up2)).ToString("N0");
            summaryTb.Rows[2][net] = Convert.ToDouble(getSumPriceFromDB(BaseTypeID.low2) - getDiscountPriceFromDB(BaseTypeID.low2)).ToString("N0");
            summaryTb.Rows[3][net] = Convert.ToDouble(getSumPriceFromDB(BaseTypeID.low3) - getDiscountPriceFromDB(BaseTypeID.low3)).ToString("N0");
            summaryTb.Rows[4][net] = Convert.ToDouble(getSumPriceFromDB(BaseTypeID.up1) - getDiscountPriceFromDB(BaseTypeID.up1)).ToString("N0");
            summaryTb.Rows[5][net] = Convert.ToDouble(getSumPriceFromDB(BaseTypeID.low1) - getDiscountPriceFromDB(BaseTypeID.low1)).ToString("N0");

            return summaryTb;
        }
        private double getSumPriceFromDB(int TypeID)
        {
            double sumPrice = 0.0;
            SqlConnection connection = new SqlConnection(Database.CnnVal("LottoryDB"));

            // get orderlistID
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open(); // Open Database
            }
            string sqlgetSumPrice = string.Empty;
            switch(TypeID)
            {
                case BaseTypeID.up3:
                    sqlgetSumPrice = "SELECT SUM(OwnPrice - OutPrice) AS sumPrice FROM Number_3up";
                    break;
                case BaseTypeID.up2:
                    sqlgetSumPrice = "SELECT SUM(OwnPrice - OutPrice) AS sumPrice FROM Number_2up";
                    break;
                case BaseTypeID.low2:
                    sqlgetSumPrice = "SELECT SUM(OwnPrice - OutPrice) AS sumPrice FROM Number_2low";
                    break;
                case BaseTypeID.low3:
                    sqlgetSumPrice = string.Format(@"SELECT ISNULL(SUM(OwnPrice),0) AS sumPrice 
                                                     FROM OrderListExpand
                                                     WHERE TypeID = {0}", BaseTypeID.low3);
                    break;
                case BaseTypeID.up1:
                    sqlgetSumPrice = string.Format(@"SELECT ISNULL(SUM(OwnPrice),0) AS sumPrice 
                                                     FROM OrderListExpand
                                                     WHERE TypeID = {0}", BaseTypeID.up1);
                    break;
                case BaseTypeID.low1:
                    sqlgetSumPrice = string.Format(@"SELECT ISNULL(SUM(OwnPrice),0) AS sumPrice 
                                                     FROM OrderListExpand
                                                     WHERE TypeID = {0}", BaseTypeID.low1);
                    break;
                default:
                    // error
                    break;
            }
            SqlCommand sqlgetSumPriceCom = new SqlCommand(sqlgetSumPrice, connection);
            SqlDataReader sumPriceInfo = sqlgetSumPriceCom.ExecuteReader();
            if(sumPriceInfo.Read())
            {
                sumPrice = Convert.ToDouble(sumPriceInfo["sumPrice"]);
            }
            connection.Close();
            return sumPrice;
        }
        private double getDiscountPriceFromDB(int TypeID)
        {
            double sumPrice = 0.0;
            SqlConnection connection = new SqlConnection(Database.CnnVal("LottoryDB"));

            // get orderlistID
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open(); // Open Database
            }
            string sqlgetDiscPrice = string.Empty;
            switch (TypeID)
            {
                case BaseTypeID.up3:
                    sqlgetDiscPrice = string.Format(@"SELECT ISNULL(SUM(DiscPrice),0) AS sumPrice 
                                                     FROM OrderListExpand
                                                     WHERE TypeID = {0}", BaseTypeID.up3);
                    break;
                case BaseTypeID.up2:
                    sqlgetDiscPrice = string.Format(@"SELECT ISNULL(SUM(DiscPrice),0) AS sumPrice 
                                                     FROM OrderListExpand
                                                     WHERE TypeID = {0}", BaseTypeID.up2);
                    break;
                case BaseTypeID.low2:
                    sqlgetDiscPrice = string.Format(@"SELECT ISNULL(SUM(DiscPrice),0) AS sumPrice 
                                                     FROM OrderListExpand
                                                     WHERE TypeID = {0}", BaseTypeID.low2);
                    break;
                case BaseTypeID.low3:
                    sqlgetDiscPrice = string.Format(@"SELECT ISNULL(SUM(DiscPrice),0) AS sumPrice 
                                                     FROM OrderListExpand
                                                     WHERE TypeID = {0}", BaseTypeID.low3);
                    break;
                case BaseTypeID.up1:
                    sqlgetDiscPrice = string.Format(@"SELECT ISNULL(SUM(DiscPrice),0) AS sumPrice 
                                                     FROM OrderListExpand
                                                     WHERE TypeID = {0}", BaseTypeID.up1);
                    break;
                case BaseTypeID.low1:
                    sqlgetDiscPrice = string.Format(@"SELECT ISNULL(SUM(DiscPrice),0) AS sumPrice 
                                                     FROM OrderListExpand
                                                     WHERE TypeID = {0}", BaseTypeID.low1);
                    break;
                default:
                    // error
                    break;
            }
            SqlCommand sqlgetDiscPriceCom = new SqlCommand(sqlgetDiscPrice, connection);
            SqlDataReader discPriceInfo = sqlgetDiscPriceCom.ExecuteReader();
            if (discPriceInfo.Read())
            {
                sumPrice = Convert.ToDouble(discPriceInfo["sumPrice"]);
            }
            connection.Close();
            return sumPrice;
        }
        private DataTable getNumberXXXFromDB(int TypeID)
        {
            DataTable resultTable = new DataTable();
            resultTable.Columns.Add("เบอร์");
            resultTable.Columns.Add("จำนวนเงิน");

            SqlConnection connection = new SqlConnection(Database.CnnVal("LottoryDB"));

            // get orderlistID
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open(); // Open Database
            }
            string sqlgetNumberxxxInfo = string.Empty;
            string dbTableName = string.Empty;
            switch (TypeID)
            {
                case BaseTypeID.up3:
                    dbTableName = "Number_3up";
                    sqlgetNumberxxxInfo = string.Format("SELECT TOP(30) Number, (OwnPrice - OutPrice) AS OwnPrice FROM {0} WHERE OwnPrice > 0 ORDER BY OwnPrice DESC", dbTableName);
                    break;
                case BaseTypeID.low3:
                    dbTableName = "Number_3low";
                    sqlgetNumberxxxInfo = string.Format("SELECT TOP(15) Number, OwnPrice FROM {0} WHERE OwnPrice > 0 ORDER BY OwnPrice DESC", dbTableName);
                    break;
                case BaseTypeID.up2:
                    dbTableName = "Number_2up";
                    sqlgetNumberxxxInfo = string.Format("SELECT TOP(30) Number, (OwnPrice-OutPrice) AS OwnPrice FROM {0} WHERE OwnPrice > 0 ORDER BY OwnPrice DESC", dbTableName);
                    break;
                case BaseTypeID.low2:
                    dbTableName = "Number_2low";
                    sqlgetNumberxxxInfo = string.Format("SELECT TOP(30) Number, (OwnPrice-OutPrice) AS OwnPrice FROM {0} WHERE OwnPrice > 0 ORDER BY OwnPrice DESC", dbTableName);
                    break;
                case BaseTypeID.up1:
                    dbTableName = "Number_1up";
                    sqlgetNumberxxxInfo = string.Format("SELECT Number, OwnPrice FROM {0} ORDER BY OwnPrice DESC", dbTableName);
                    break;
                case BaseTypeID.low1:
                    dbTableName = "Number_1low";
                    sqlgetNumberxxxInfo = string.Format("SELECT Number, OwnPrice FROM {0} ORDER BY OwnPrice DESC", dbTableName);
                    break;
                default:
                    // error
                    break;
            }
            SqlCommand sqlgetNumberxxxInfoCom = new SqlCommand(sqlgetNumberxxxInfo, connection);
            SqlDataReader numberxxxInfo = sqlgetNumberxxxInfoCom.ExecuteReader();
            while(numberxxxInfo.Read())
            {
                string Number = numberxxxInfo["Number"].ToString();
                int Price = Convert.ToInt32(numberxxxInfo["OwnPrice"]);
                resultTable.Rows.Add(Number, Price.ToString("N0")); 
            }
            connection.Close();

            return resultTable;
        }

    }
}
