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
    public partial class NumberLimitSetting : Form
    {
        private static NumberLimitSetting _instance;
        public static NumberLimitSetting Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new NumberLimitSetting();
                return _instance;
            }
        }
        private void NumberLimitSetting_FormClosed(object sender, FormClosedEventArgs e)
        {
            _instance = null;
        }
        public NumberLimitSetting()
        {
            InitializeComponent();
        }

        private void NumberLimitSetting_Load(object sender, EventArgs e)
        {
            // Load Limit Number From DB
            readLimitNumberList();
        }
        private void readLimitNumberList()
        {
            dgvNumberLimit.DataSource = getLimitNumberFromDB();
            dgvNumberLimit.ClearSelection();
        }
        private DataTable getLimitNumberFromDB()
        {
            DataTable NumberLimitTable = new DataTable();
            NumberLimitTable.Columns.Add("เบอร์");
            NumberLimitTable.Columns.Add("ชนิด");
            NumberLimitTable.Columns.Add("จำนวนเงินอั้น");

            SqlConnection connection = new SqlConnection(Database.CnnVal("LottoryDB"));
            if(connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            string sqlgetLimitNumber = @"SELECT lm.Number, t.TypeName, lm.LimitPrice 
                                         FROM LimitNumber lm INNER JOIN TypeNumberInfo t ON lm.TypeID = t.TypeID";
            SqlCommand sqlgetLimitNumberCom = new SqlCommand(sqlgetLimitNumber, connection);
            SqlDataReader LimitNumberInfo = sqlgetLimitNumberCom.ExecuteReader();
            while(LimitNumberInfo.Read())
            {
                string _number = LimitNumberInfo["Number"].ToString();
                string _typename = LimitNumberInfo["TypeName"].ToString();
                string _LimitPrice = Convert.ToInt32(LimitNumberInfo["LimitPrice"]).ToString("N0");
                NumberLimitTable.Rows.Add(_number, _typename, _LimitPrice);
            }
            connection.Close();
            return NumberLimitTable;

        }

        private void tbNumber_TextChanged(object sender, EventArgs e)
        {
            string[] typenameList = null;
            cbTypeName.Items.Clear();
            switch(tbNumber.Text.Length)
            {
                case 2:
                    // update type name list
                    typenameList = new string[] { "บน", "ล่าง" };
                    cbTypeName.Items.AddRange(typenameList);
                    break;
                case 3:
                    // update type name list
                    typenameList = new string[] { "บน", "บน/โต๊ด" };
                    cbTypeName.Items.AddRange(typenameList);
                    break;
            }
            
        }

        private void tbLimitPrice_TextChanged(object sender, EventArgs e)
        {
            int x;
            if(!Int32.TryParse(tbLimitPrice.Text,out x) && !string.IsNullOrEmpty(tbLimitPrice.Text))
            {
                MessageBox.Show("กรุณาใส่วงเงินเป็นตัวเลข");
            }
        }
        private int getTypeID(string typeName, int Numberlen)
        {
            int TypeID = 0;
            // selete typeid
            switch (typeName)
            {
                case "บน":
                    switch(Numberlen)
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
        private void btAdd_Click(object sender, EventArgs e)
        {

            // Add Limit Number to DB
            setLimitNumberToDB(tbNumber.Text, getTypeID(cbTypeName.Text,tbNumber.Text.Length), tbLimitPrice.Text);

            // read Limit Number from DB
            readLimitNumberList();
        }
        private void setLimitNumberToDB(string Number, int TypeID, string LimitPrice)
        {
            SqlConnection connection = new SqlConnection(Database.CnnVal("LottoryDB"));
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            string sqlgetLimitNumber = string.Format(@"SELECT * FROM LimitNumber
                                                       WHERE Number = '{0}' AND TypeID = {1}", Number, TypeID.ToString());
            SqlCommand sqlgetLimitNumbercom = new SqlCommand(sqlgetLimitNumber, connection);
            SqlDataReader LimitNumberInfo = sqlgetLimitNumbercom.ExecuteReader();
            string sqlsetLimitNumber;
            if(LimitNumberInfo.HasRows)
            {
                sqlsetLimitNumber = string.Format(@"UPDATE LimitNumber
                                                           SET LimitPrice = {2}
                                                           WHERE Number = '{0}' AND TypeID = {1}", Number, TypeID.ToString(),LimitPrice);
            }
            else
            {
                sqlsetLimitNumber = string.Format(@"INSERT INTO LimitNumber(Number,TypeID,LimitPrice)
                                                    VALUES ('{0}',{1},{2})",Number, TypeID.ToString(), LimitPrice);
            }
            connection.Close();

            if(connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            SqlCommand sqlgetLimitNumberCom = new SqlCommand(sqlsetLimitNumber, connection);
            sqlgetLimitNumberCom.ExecuteNonQuery();
            connection.Close();
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow SelectedItem in this.dgvNumberLimit.SelectedRows)
            {
                string _number = SelectedItem.Cells[0].Value.ToString();
                int _TypeID = getTypeID(SelectedItem.Cells[1].Value.ToString(),_number.Length);
                deleteNumberListFromDB(_number, _TypeID);
            }

            // read Limit Number from DB
            readLimitNumberList();
        }
        private void deleteNumberListFromDB(string Number, int TypeID)
        {
            SqlConnection connection = new SqlConnection(Database.CnnVal("LottoryDB"));
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            string sqldeleteLimitNumber = string.Format(@"DELETE FROM LimitNumber
                                                          WHERE Number = '{0}' AND TypeID = {1}", Number, TypeID.ToString());
            SqlCommand sqldeleteLimitNumberCom = new SqlCommand(sqldeleteLimitNumber, connection);
            sqldeleteLimitNumberCom.ExecuteNonQuery();
            connection.Close();

        }

 
    }
}
