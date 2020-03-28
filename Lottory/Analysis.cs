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
    public partial class Analysis : Form
    {
        private static Analysis _instance;
        public static Analysis Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Analysis();
                return _instance;
            }
        }
        public Analysis()
        {
            InitializeComponent();
            this.ActiveControl = tbMoney;

            dgvResult.CellFormatting += new DataGridViewCellFormattingEventHandler(dgvResult_CellFormatting);
        }

        private void dgvResult_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //DataGridView dgv = (DataGridView)sender;
            //e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            switch(e.ColumnIndex)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                    e.CellStyle.ForeColor = Color.Red;
                    break;
            }
        }

        private void Analysis_FormClosed(object sender, FormClosedEventArgs e)
        {
            _instance = null;
        }

        private void btAnalyze_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Analysis");
            Fcn_Analysis();
        }

        private void Analysis_Load(object sender, EventArgs e)
        {
            tbMoney.Focus();

            //dgvResult.DataSource = findNumber();
        }

        private void tbMoney_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.PageDown:
                    btAnalyze.Focus();
                    break;
                case Keys.Enter:
                    //MessageBox.Show("Analysis");
                    Fcn_Analysis();
                    break;
            }
        }

        private void btAnalyze_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.PageUp:
                    tbMoney.Focus();
                    break;
            }

        }
        private void Fcn_Analysis()
        {
            dgvResult.Rows.Clear();
            dgvResult.Refresh();
            DataTable resultTb = findNumber();
            foreach(DataRow row in resultTb.Rows)
            {
                string number3up = row["Number3up"].ToString();
                string pay3up = Convert.ToDouble(row["Pay3up"]).ToString("N0");
                string number2up = row["Number2up"].ToString();
                string pay2up = Convert.ToDouble(row["Pay2up"]).ToString("N0");
                string number1up = row["Number1up"].ToString();
                string pay1up = Convert.ToDouble(row["Pay1up"]).ToString("N0");
                string inHand = Convert.ToDouble(row["InHand"]).ToString("N0");
                string netPay = Convert.ToDouble(row["Net"]).ToString("N0");
                dgvResult.Rows.Add(number3up, pay3up, number2up, pay2up, number1up, pay1up, inHand, netPay);
            }
            // show first Row
            double lb_pay3up = Convert.ToDouble(resultTb.Rows[0]["Pay3up"]);
            double lb_pay2up = Convert.ToDouble(resultTb.Rows[0]["Pay2up"]);
            lbNumber3up.Text = resultTb.Rows[0]["Number3up"].ToString();
            lbpay3up.Text = lb_pay3up.ToString("N0");
            lbNumber2up.Text = resultTb.Rows[0]["Number2up"].ToString();
            lbpay2up.Text = lb_pay2up.ToString("N0");
            lbNetPay.Text = Convert.ToDouble(resultTb.Rows[0]["Net"]).ToString("N0");

            if(lb_pay3up > lb_pay2up)
            {
                lbpay3up.ForeColor = Color.Red;
            }
            else if(lb_pay2up > lb_pay3up)
            {
                lbpay2up.ForeColor = Color.Red;
            }
            
        }
        private DataTable findNumber()
        {
            DataTable tbOut = new DataTable();
            tbOut.Columns.Add("Number3up");
            tbOut.Columns.Add("Pay3up");
            tbOut.Columns.Add("Number2up");
            tbOut.Columns.Add("Pay2up");
            tbOut.Columns.Add("Number1up");
            tbOut.Columns.Add("Pay1up");
            tbOut.Columns.Add("InHand");
            tbOut.Columns.Add("Net");
            tbOut.Columns["Net"].DataType = typeof(Double);

            // query from DB
            SqlConnection connection = new SqlConnection(Database.CnnVal("LottoryDB"));

            if (connection.State == ConnectionState.Closed)
            {
                connection.Open(); // Open Database
            }
            string getNumber3up = string.Format(@"SELECT DISTINCT Number, SUM(Price) AS Price 
                                                  FROM OrderListExpand
                                                  WHERE TypeID = {0}
                                                  GROUP BY Number",BaseTypeID.up3);
            SqlCommand getNumber3upCom = new SqlCommand(getNumber3up, connection);
            SqlDataReader number3upInfo = getNumber3upCom.ExecuteReader();
            while(number3upInfo.Read())
            {
                string number3up = number3upInfo["Number"].ToString();
                double price3up = Convert.ToDouble(number3upInfo["Price"]);

                // query number 2up
                string number2up = number3up.Substring(1, 2);

                SqlConnection connection2up = new SqlConnection(Database.CnnVal("LottoryDB"));
                if(connection2up.State == ConnectionState.Closed)
                {
                    connection2up.Open();
                }
                string getNumber2up = string.Format(@"SELECT DISTINCT SUM(Price) AS Price
                                                      FROM OrderListExpand
                                                      WHERE TypeID = {0} AND Number = '{1}'
                                                      GROUP BY Number", BaseTypeID.up2, number2up);
                SqlCommand getNumber2upCom = new SqlCommand(getNumber2up, connection2up);
                SqlDataReader number2upInfo = getNumber2upCom.ExecuteReader();
                double price2up = 0;
                while (number2upInfo.Read())
                {
                    price2up = Convert.ToDouble(number2upInfo["Price"]);
                }
                connection2up.Close();

                // query number 1up
                string number1up1 = number3up.Substring(0, 1);
                string number1up2 = number3up.Substring(1, 1);
                string number1up3 = number3up.Substring(2, 1);
                SqlConnection connection1up = new SqlConnection(Database.CnnVal("LottoryDB"));
                if(connection1up.State == ConnectionState.Closed)
                {
                    connection1up.Open();
                }
                string getNumber1up = string.Format(@"SELECT DISTINCT SUM(Price) AS Price
                                                      FROM OrderListExpand
                                                      WHERE TypeID = {0} AND (Number = '{1}' OR Number = '{2}' OR Number = '{3}')
                                                     ", BaseTypeID.up1, number1up1, number1up2, number1up3);
                SqlCommand getNumber1upCom = new SqlCommand(getNumber1up, connection1up);
                SqlDataReader number1upInfo = getNumber1upCom.ExecuteReader();
                double price1up = 0;
                while (number1upInfo.Read())
                {
                    price1up = Convert.ToDouble(number1upInfo["Price"]);
                }
                connection1up.Close();
                double inHandPrice = getMoneyInHand();
                double netPrice = (price3up * 550) + (price2up * 70) + (price1up * 3) - inHandPrice;


                if(netPrice > Convert.ToDouble(tbMoney.Text))
                {
                    // Add to Table
                    tbOut.Rows.Add(number3up, price3up * 550, number2up, price2up * 70, string.Format("{0},{1},{2}", number1up1, number1up2, number1up3), price1up * 3, inHandPrice, netPrice);
                }
            }
            connection.Close();

            tbOut.DefaultView.Sort = "Net DESC";
            tbOut = tbOut.DefaultView.ToTable();

            return tbOut; 
        }

        private double getMoneyInHand()
        {
            // query from DB
            SqlConnection connection = new SqlConnection(Database.CnnVal("LottoryDB"));

            if (connection.State == ConnectionState.Closed)
            {
                connection.Open(); // Open Database
            }
            string getNetInHand = string.Format("SELECT SUM(OwnPrice - DiscPrice) AS Price FROM OrderListExpand");
            SqlCommand getNetInHandCom = new SqlCommand(getNetInHand, connection);
            SqlDataReader netInHandInfo = getNetInHandCom.ExecuteReader();
            double moneyOut = 0;
            while(netInHandInfo.Read())
            {
                moneyOut = Convert.ToDouble(netInHandInfo["Price"]);
            }
            connection.Close();

            return moneyOut;
        }

    }
}
