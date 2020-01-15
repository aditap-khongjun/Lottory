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
    public partial class Choose_customer_dialog : Form
    {
        public static string CustomerID { get; set; }
        public Choose_customer_dialog()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
        }

        private void Choose_customer_dialog_Load(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(Database.CnnVal("LottoryDB"));

            if (connection.State == ConnectionState.Closed)
            {
                connection.Open(); // Open Database
            }

            // get customerID from Database
            string sqlgetcustomerID = "SELECT CustomerID FROM CustomerInfo";
            SqlCommand sqlgetcustomerIDCom = new SqlCommand(sqlgetcustomerID, connection);
            SqlDataReader customerIDInfo = sqlgetcustomerIDCom.ExecuteReader();
            while(customerIDInfo.Read())
            {
                customerIDList.Items.Add(customerIDInfo["CustomerID"].ToString());
            }
            connection.Close();

        }

        private void btOK_Click(object sender, EventArgs e)
        {
            Choose_customer_dialog.CustomerID = this.customerIDList.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
