using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace Lottory
{
    public partial class Login : Form
    {
        public static string EmpolyeeID { get; set; }
        public static string EmpolyeeName { get; set; }
        public Login()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
        }

        // Log In
        private void btLogIn_Click(object sender, EventArgs e)
        {
            
            if(Check_Correction())
            {
                // Open Main windows
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                // Nothing to do
            }
        }

        // Method
        private bool Check_Correction()
        {
            bool correctFlag = false;
            if((string.IsNullOrEmpty(tbUserName.Text) || string.IsNullOrWhiteSpace(tbUserName.Text)) && (string.IsNullOrEmpty(tbPassWord.Text) || string.IsNullOrWhiteSpace(tbPassWord.Text)))
            {
                //User Name and Password is Empty
                MessageBox.Show("กรุณาใส่ Username และ Password", "เข้าสู่ระบบผิดพลาด");
            }
            else if (string.IsNullOrEmpty(tbUserName.Text) || string.IsNullOrWhiteSpace(tbUserName.Text))
            {
                //User Name is empty
                MessageBox.Show("กรุณาใส่ Username", "เข้าสู่ระบบผิดพลาด");
            }
            else if(string.IsNullOrEmpty(tbPassWord.Text) || string.IsNullOrWhiteSpace(tbPassWord.Text))
            {
                MessageBox.Show("กรุณาใส่ Password", "เข้าสู่ระบบผิดพลาด");
            }
            else
            {
                //Connect to Database
                string conStr = Database.CnnVal("LottoryDB");

                SqlConnection connection = new SqlConnection(conStr);

                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open(); // Open Database
                }

                // get username, password from database
                string sqlStr = "SELECT EmployeeID, Username, Password FROM Employee";
                SqlCommand sqlcom = new SqlCommand(sqlStr, connection);
                SqlDataReader queryData = sqlcom.ExecuteReader();
                // check correct Login
                string usrLogin = tbUserName.Text;
                string pasLogin = tbPassWord.Text;
                while (queryData.Read())
                {
                    string usrRead = (string)queryData["Username"];
                    string pasRead = (string)queryData["Password"];
                    string idRead = (string)queryData["EmployeeID"];

                    if (string.Equals(usrLogin, usrRead) && (string.Equals(pasLogin, pasRead)))
                    {
                        correctFlag |= true;
                        // update UserName & PassWord
                        Login.EmpolyeeID = idRead;
                        Login.EmpolyeeName = usrRead;
                    }

                }
                if(!correctFlag)
                {
                    MessageBox.Show("Username หรือ Password ไม่ถูกต้อง", "เข้าสู่ระบบผิดพลาด");
                }

                connection.Close();
            }

            return correctFlag;
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
