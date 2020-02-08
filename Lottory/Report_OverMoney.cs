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
    public partial class Report_OverMoney : Form
    {
        private static Report_OverMoney _instance;
        public static Report_OverMoney Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Report_OverMoney();
                return _instance;
            }
        }
        public Report_OverMoney()
        {
            InitializeComponent();
        }

        private void Report_OverMoney_Load(object sender, EventArgs e)
        {
            dgvOver3up.DataSource = getOverNumber(BaseTypeID.up3);
            dgvOver3up.ClearSelection();
            dgvOver2up.DataSource = getOverNumber(BaseTypeID.up2);
            dgvOver2low.ClearSelection();
            dgvOver2low.DataSource = getOverNumber(BaseTypeID.low2);
            dgvOver2low.ClearSelection();
        }
        private DataTable getOverNumber(int TypeID)
        {
            DataTable outNumber = new DataTable();
            outNumber.Columns.Add("ตัวเลข");
            outNumber.Columns.Add("จำนวนเงิน");
            //outNumber.Columns["จำนวนเงิน"].DataType = typeof(Double);

            string dbName = string.Empty;
            switch(TypeID)
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
            while(OverNumberInfo.Read())
            {
                outNumber.Rows.Add(OverNumberInfo["Number"].ToString(), Convert.ToDouble(OverNumberInfo["OutPrice"]).ToString("N0"));
            }
            connection.Close();
            return outNumber;
        }

        private void Report_OverMoney_FormClosed(object sender, FormClosedEventArgs e)
        {
            _instance = null;
        }
    }
}
