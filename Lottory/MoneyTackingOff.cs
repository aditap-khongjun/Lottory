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
    public partial class MoneyTackingOff : Form
    {
        private static MoneyTackingOff _instance;
        public static MoneyTackingOff Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new MoneyTackingOff();
                return _instance;
            }
        }
        private void MoneyTackingOff_FormClosed(object sender, FormClosedEventArgs e)
        {
            _instance = null;
        }
        public MoneyTackingOff()
        {
            InitializeComponent();
        }

        private void btTakeOff_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("คุณแน่ใจที่จะตีออก", "ยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            switch(result)
            {
                case DialogResult.Yes:
                    TakingOffToDB(cbTypeName.Text, tbTakeOffMoney.Text, tbMoneyOfset.Text);

                    MessageBox.Show("ทำการตีออกเรียบร้อบแล้ว", "ตีออก");
                    break;
                case DialogResult.No:
                    // nothing to do
                    break;
            }
        }
        private void TakingOffToDB(string TypeName,string TakeOffMoney, string Offset)
        {
            
            SqlConnection connection = new SqlConnection(Database.CnnVal("LottoryDB"));
            if(connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            string sqlTakeOff = string.Format(@"UPDATE {2}
                                                SET OutPrice = OwnPrice - {0}
                                                WHERE OwnPrice - {0} - OutPrice > {1}", TakeOffMoney, Offset,getNumberXXXDBName(TypeName));
            SqlCommand sqlTakeOffCom = new SqlCommand(sqlTakeOff, connection);
            sqlTakeOffCom.ExecuteNonQuery();
            connection.Close();
        }
        private string getNumberXXXDBName(string TypeName)
        {
            string dbName = string.Empty;
            switch (TypeName)
            {
                case "3 บน":
                    dbName = "Number_3up";
                    break;
                case "2 บน":
                    dbName = "Number_2up";
                    break;
                case "2 ล่าง":
                    dbName = "Number_2low";
                    break;
            }
            return dbName;

        }

        private void tbTakeOffMoney_TextChanged(object sender, EventArgs e)
        {
            int x;
            if(!Int32.TryParse(tbTakeOffMoney.Text,out x) && !string.IsNullOrEmpty(tbTakeOffMoney.Text))
            {
                MessageBox.Show("กรุณาใส่วงเงินที่ตีออกเป็นตัวเลข", "วงเงินไม่ถูกต้อง", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tbMoneyOfset_TextChanged(object sender, EventArgs e)
        {
            int x;
            if(!Int32.TryParse(tbMoneyOfset.Text,out x) && !string.IsNullOrEmpty(tbMoneyOfset.Text))
            {
                MessageBox.Show("กรุณาใส่ช่วงการตีออกเป็นตัวเลข", "ผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btClear_Click(object sender, EventArgs e)
        {
            DialogResult resultClear = MessageBox.Show("แน่ใจที่จะยกเลิกการตีออกทั้งหมดที่ผ่านมา", "ยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            switch(resultClear)
            {
                case DialogResult.Yes:
                    ClearTakingOff();

                    MessageBox.Show("ทำการยกเลิกการตีออกทั้งหมกเรียบร้อยแล้ว", "ยกเลิกตีออก");
                    break;
                case DialogResult.No:
                    // Nothing to do
                    break;
            }
        }
        private void ClearTakingOff()
        {
            //
            clearTakingOffToDB("3 บน");
            clearTakingOffToDB("2 บน");
            clearTakingOffToDB("2 ล่าง");
        }
        private void clearTakingOffToDB(string TypeName)
        {
            SqlConnection connection = new SqlConnection(Database.CnnVal("LottoryDB"));
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            string sqlclearOutPrice = string.Format(@"UPDATE {0}
                                                      SET OutPrice = 0
                                                      WHERE OutPrice > 0", getNumberXXXDBName(TypeName));
            SqlCommand sqlclearOutPriceCom = new SqlCommand(sqlclearOutPrice, connection);
            sqlclearOutPriceCom.ExecuteNonQuery();
            connection.Close();
        }

        private void btShowInHand_Click(object sender, EventArgs e)
        {
            showInHandNumberTable();
        }
        private DataTable getNumberXXXFromDB(int TypeID)
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
            while (NumberListInfo.Read())
            {
                resultTable.Rows.Add(NumberListInfo["Number"].ToString(), Convert.ToDouble(NumberListInfo["Price"]).ToString("N0"));
            }
            connection.Close();
            return resultTable;
        }
        private DataTable getAllNumberXXXFromDB(int TypeID)
        {
            DataTable resultTable = new DataTable();
            resultTable.Columns.Add("เบอร์");
            resultTable.Columns.Add("จำนวนเงิน");

            SqlConnection connection = new SqlConnection(Database.CnnVal("LottoryDB"));
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            string sqlgetNumberxxxInfo = string.Format(@"SELECT Number, SUM(OwnPrice) AS Price
                                                         FROM OrderListExpand
                                                         WHERE TypeID = {0}
                                                         GROUP BY Number
                                                         ORDER BY Price DESC", TypeID.ToString());
            SqlCommand sqlgetNumberxxxInfoCom = new SqlCommand(sqlgetNumberxxxInfo, connection);
            SqlDataReader NumberListInfo = sqlgetNumberxxxInfoCom.ExecuteReader();
            while (NumberListInfo.Read())
            {
                resultTable.Rows.Add(NumberListInfo["Number"].ToString(), Convert.ToDouble(NumberListInfo["Price"]).ToString("N0"));
            }
            connection.Close();
            return resultTable;
        }
        private void showInHandNumberTable()
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
        private void showAllNumberTable()
        {
            // Update Number 3up
            dgvNumber3up.DataSource = getAllNumberXXXFromDB(BaseTypeID.up3);
            dgvNumber3up.ClearSelection();

            // Update Number 2up
            dgvNumber2up.DataSource = getAllNumberXXXFromDB(BaseTypeID.up2);
            dgvNumber2up.ClearSelection();

            // Update Number 2low
            dgvNumber2low.DataSource = getAllNumberXXXFromDB(BaseTypeID.low2);
            dgvNumber2low.ClearSelection();

            // Update Number 3low
            dgvNumber3low.DataSource = getAllNumberXXXFromDB(BaseTypeID.low3);
            dgvNumber3low.ClearSelection();

            // udpate Number 1up
            dgvNumber1up.DataSource = getAllNumberXXXFromDB(BaseTypeID.up1);
            dgvNumber1up.ClearSelection();

            // update Number 1low
            dgvNumber1low.DataSource = getAllNumberXXXFromDB(BaseTypeID.low1);
            dgvNumber1low.ClearSelection();
        }

        private void btShowAll_Click(object sender, EventArgs e)
        {
            showAllNumberTable();
        }

        private void btShowTakeOff_Click(object sender, EventArgs e)
        {
            //
            showTackOffNumber();
        }
        private void showTackOffNumber()
        {
            // Update Number 3up
            dgvNumber3up.DataSource = getTackOffNumberXXXFromDB(BaseTypeID.up3);
            dgvNumber3up.ClearSelection();

            // Update Number 2up
            dgvNumber2up.DataSource = getTackOffNumberXXXFromDB(BaseTypeID.up2);
            dgvNumber2up.ClearSelection();

            // Update Number 2low
            dgvNumber2low.DataSource = getTackOffNumberXXXFromDB(BaseTypeID.low2);
            dgvNumber2low.ClearSelection();

            dgvNumber3low.DataSource = null;

            // udpate Number 1up
            dgvNumber1up.DataSource = null;

            // update Number 1low
            dgvNumber1low.DataSource = null;
        }

        private DataTable getTackOffNumberXXXFromDB(int TypeID)
        {
            DataTable outNumber = new DataTable();
            outNumber.Columns.Add("ตัวเลข");
            outNumber.Columns.Add("จำนวนเงิน");
            //outNumber.Columns["จำนวนเงิน"].DataType = typeof(Double);

            string dbName = string.Empty;
            switch (TypeID)
            {
                case BaseTypeID.up3:
                    dbName = "Number_3up";
                    break;
                case BaseTypeID.up2:
                    dbName = "Number_2up";
                    break;
                case BaseTypeID.low2:
                    dbName = "Number_2low";
                    break;
            }


            SqlConnection connection = new SqlConnection(Database.CnnVal("LottoryDB"));

            // get orderlistID
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open(); // Open Database
            }
            string sqlgetOverNumber = string.Format(@"SELECT Number, OutPrice FROM {0}
                                                      WHERE OutPrice > 0
                                                      ORDER BY OutPrice DESC", dbName);
            SqlCommand sqlgetOverNumberCom = new SqlCommand(sqlgetOverNumber, connection);
            SqlDataReader OverNumberInfo = sqlgetOverNumberCom.ExecuteReader();
            while (OverNumberInfo.Read())
            {
                outNumber.Rows.Add(OverNumberInfo["Number"].ToString(), Convert.ToDouble(OverNumberInfo["OutPrice"]).ToString("N0"));
            }
            connection.Close();
            return outNumber;
        }
    }
}
