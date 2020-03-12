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
    public partial class Setting : Form
    {
        private static Setting _instance;
        public static Setting Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Setting();
                return _instance;
            }
        }

        public Setting()
        {
            InitializeComponent();
        }

        private void btCreateAccount_Click(object sender, EventArgs e)
        {
            //Check correct system
            bool correctFlag = CheckCorrectInfo(out string msgError);
            if(correctFlag)
            {
                //check exist user
                if(existUserInDB(tbUserName.Text))
                {
                    // replace
                    if (correctPassword())
                    {
                        // insert
                        string _admin;
                        if (rbAdmin.Checked)
                        {
                            _admin = 1.ToString();
                        }
                        else
                        {
                            _admin = 0.ToString();
                        }
                        UpdateInfoToDB(tbName.Text, tbUserName.Text, tbPassword.Text, _admin);
                        LoadEmployeeInfoFromDB();
                        clearInfo();
                    }
                    else
                    {
                        MessageBox.Show("รหัสผ่านไม่ตรงกัน");
                    }
                }
                else
                {
                    // check correct password
                    if(correctPassword())
                    {
                        // insert
                        string _admin;
                        if (rbAdmin.Checked)
                        {
                            _admin = 1.ToString();
                        }
                        else
                        {
                            _admin = 0.ToString();
                        }
                        InsertInfoToDB(tbName.Text, tbUserName.Text, tbPassword.Text, _admin);
                        LoadEmployeeInfoFromDB();
                        clearInfo();
                    }
                    else
                    {
                        MessageBox.Show("รหัสผ่านไม่ตรงกัน");
                    }
                }

            }
            else
            {
                MessageBox.Show(msgError);
            }
        }
        private void clearInfo()
        {
            tbName.Clear();
            tbUserName.Clear();
            tbPassword.Clear();
            tbPasswordConfirm.Clear();
            rbAdmin.Checked = true;
        }
        private bool correctPassword()
        {
            if(string.Equals(tbPassword.Text,tbPasswordConfirm.Text))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void UpdateInfoToDB(string name, string username, string password, string admin)
        {
            SqlConnection connection = new SqlConnection(Database.CnnVal("LottoryDB"));

            if (connection.State == ConnectionState.Closed)
            {
                connection.Open(); // Open Database
            }
            Random randomID = new Random();
            string insertInfo = string.Format(@"UPDATE Employee
                                                SET Password = '{1}', EmployeeName = '{2}', Admin = {3}
                                                WHERE BINARY_CHECKSUM(Username) = BINARY_CHECKSUM('{0}')",username, password, name, admin);
            SqlCommand insertInfoCom = new SqlCommand(insertInfo, connection);
            insertInfoCom.ExecuteNonQuery();
            connection.Close();
        }
        private void InsertInfoToDB(string name, string username, string password, string admin)
        {
            SqlConnection connection = new SqlConnection(Database.CnnVal("LottoryDB"));

            if (connection.State == ConnectionState.Closed)
            {
                connection.Open(); // Open Database
            }
            Random randomID = new Random();
            string insertInfo = string.Format(@"INSERT Employee(EmployeeID,Username,Password,EmployeeName,Admin)
                                                       VALUES('{0}','{1}','{2}','{3}',{4})", randomID.Next(0,99999).ToString(), username, password, name, admin);
            SqlCommand insertInfoCom = new SqlCommand(insertInfo, connection);
            insertInfoCom.ExecuteNonQuery();
            connection.Close();
        }
        private bool existUserInDB(string username)
        {
            bool existFlag;
            SqlConnection connection = new SqlConnection(Database.CnnVal("LottoryDB"));

            if (connection.State == ConnectionState.Closed)
            {
                connection.Open(); // Open Database
            }
            string getUserName = string.Format(@"SELECT Username FROM Employee
                                                 WHERE BINARY_CHECKSUM(Username) = BINARY_CHECKSUM('{0}')", username);
            SqlCommand getUserNameCom = new SqlCommand(getUserName, connection);
            SqlDataReader usernameInfo = getUserNameCom.ExecuteReader();
            if(usernameInfo.HasRows)
            {
                existFlag = true;
            }
            else
            {
                existFlag = false;
            }
            connection.Close();
            return existFlag;
        }

        private bool CheckCorrectInfo(out string errOut)
        {
            bool correctOut;
            errOut = string.Empty;

            if (string.IsNullOrEmpty(tbName.Text))
            {
                correctOut = false;
                errOut = "กรุณากรอกชื่อผู้ใช้";
            } 
            else if (string.IsNullOrEmpty(tbUserName.Text))
            {
                correctOut = false;
                errOut = "กรุณากรอกรหัสผู้ใช้";
            } 
            else if (string.IsNullOrEmpty(tbPassword.Text))
            {
                correctOut = false;
                errOut = "กรุณากรอกรหัสผ่าน";
            }
            else
            {
                correctOut = true;
            }
            return correctOut;
        }


        private void Setting_Load(object sender, EventArgs e)
        {
            LoadEmployeeInfoFromDB();
        }

        private void LoadEmployeeInfoFromDB()
        {
            dgvSystemInfo.Rows.Clear();
            SqlConnection connection = new SqlConnection(Database.CnnVal("LottoryDB"));

            if (connection.State == ConnectionState.Closed)
            {
                connection.Open(); // Open Database
            }
            string getEmployeeInfo = "SELECT EmployeeName, Username, Admin FROM Employee";
            SqlCommand getEmployeeInfoCom = new SqlCommand(getEmployeeInfo, connection);
            SqlDataReader employeeInfo = getEmployeeInfoCom.ExecuteReader();
            while(employeeInfo.Read())
            {
                string _Name = employeeInfo["EmployeeName"].ToString();
                string _UserName = employeeInfo["Username"].ToString();
                string _Admin;
                if (Convert.ToInt32(employeeInfo["Admin"]) == 1)
                {
                    _Admin = "ผู้ดูแลระบบ";
                }
                else
                {
                    _Admin = "สมาชิก";
                }

                dgvSystemInfo.Rows.Add(_Name, _UserName, _Admin);
            }
            connection.Close();
        }

        private void Setting_FormClosed(object sender, FormClosedEventArgs e)
        {
            _instance = null;
        }

        private void dgvSystemInfo_KeyDown(object sender, KeyEventArgs e)
        {
            foreach (DataGridViewRow item in this.dgvSystemInfo.SelectedRows)
            {
                deleteUserListItem(item);
            }
        }
        private void deleteUserListItem(DataGridViewRow item)
        {
            // Delete Seleted Rows
            dgvSystemInfo.Rows.Remove(item);

            // Delete Data from DB
            string username = item.Cells[1].Value.ToString();
            DeleteUserListFromDB(username);
        }
        private void DeleteUserListFromDB(string username)
        {
            SqlConnection connection = new SqlConnection(Database.CnnVal("LottoryDB"));

            // get orderlistID
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open(); // Open Database
            }
            string deleteList = string.Format(@"DELETE Employee
                                                WHERE BINARY_CHECKSUM(Username) = BINARY_CHECKSUM('{0}')", username);
            SqlCommand deleteListCom = new SqlCommand(deleteList, connection);
            deleteListCom.ExecuteNonQuery();
            connection.Close();
        }
    }
}
