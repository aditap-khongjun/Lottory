namespace Lottory
{
    partial class Setting
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbUser = new System.Windows.Forms.RadioButton();
            this.rbAdmin = new System.Windows.Forms.RadioButton();
            this.btCreateAccount = new System.Windows.Forms.Button();
            this.tbPasswordConfirm = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbUserName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvSystemInfo = new System.Windows.Forms.DataGridView();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSystemInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbUser);
            this.groupBox1.Controls.Add(this.rbAdmin);
            this.groupBox1.Controls.Add(this.btCreateAccount);
            this.groupBox1.Controls.Add(this.tbPasswordConfirm);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tbPassword);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbUserName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(339, 276);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "กำหนดบัญชีผู้ใช้โปรแกรม";
            // 
            // rbUser
            // 
            this.rbUser.AutoSize = true;
            this.rbUser.Location = new System.Drawing.Point(209, 169);
            this.rbUser.Name = "rbUser";
            this.rbUser.Size = new System.Drawing.Size(70, 24);
            this.rbUser.TabIndex = 9;
            this.rbUser.Text = "สมาชิก";
            this.rbUser.UseVisualStyleBackColor = true;
            // 
            // rbAdmin
            // 
            this.rbAdmin.AutoSize = true;
            this.rbAdmin.Checked = true;
            this.rbAdmin.Location = new System.Drawing.Point(108, 169);
            this.rbAdmin.Name = "rbAdmin";
            this.rbAdmin.Size = new System.Drawing.Size(94, 24);
            this.rbAdmin.TabIndex = 9;
            this.rbAdmin.TabStop = true;
            this.rbAdmin.Text = "ผู้ดูแลระบบ";
            this.rbAdmin.UseVisualStyleBackColor = true;
            // 
            // btCreateAccount
            // 
            this.btCreateAccount.Location = new System.Drawing.Point(108, 206);
            this.btCreateAccount.Name = "btCreateAccount";
            this.btCreateAccount.Size = new System.Drawing.Size(171, 49);
            this.btCreateAccount.TabIndex = 8;
            this.btCreateAccount.Text = "สร้างบัญชี";
            this.btCreateAccount.UseVisualStyleBackColor = true;
            this.btCreateAccount.Click += new System.EventHandler(this.btCreateAccount_Click);
            // 
            // tbPasswordConfirm
            // 
            this.tbPasswordConfirm.Location = new System.Drawing.Point(108, 136);
            this.tbPasswordConfirm.Name = "tbPasswordConfirm";
            this.tbPasswordConfirm.PasswordChar = '*';
            this.tbPasswordConfirm.Size = new System.Drawing.Size(171, 26);
            this.tbPasswordConfirm.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "ยืนยันรหัสผ่าน";
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(108, 104);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(171, 26);
            this.tbPassword.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "รหัสผ่าน";
            // 
            // tbUserName
            // 
            this.tbUserName.Location = new System.Drawing.Point(108, 72);
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.Size = new System.Drawing.Size(171, 26);
            this.tbUserName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "รหัสผู้ใช้";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(108, 37);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(171, 26);
            this.tbName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "ชื่อผู้ใช้";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvSystemInfo);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.groupBox2.Location = new System.Drawing.Point(357, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(733, 276);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ข้อมูลบัญชีผู้ใช้";
            // 
            // dgvSystemInfo
            // 
            this.dgvSystemInfo.AllowUserToAddRows = false;
            this.dgvSystemInfo.ColumnHeadersHeight = 40;
            this.dgvSystemInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.UserName,
            this.Status});
            this.dgvSystemInfo.Location = new System.Drawing.Point(12, 28);
            this.dgvSystemInfo.Name = "dgvSystemInfo";
            this.dgvSystemInfo.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgvSystemInfo.RowTemplate.Height = 30;
            this.dgvSystemInfo.Size = new System.Drawing.Size(706, 227);
            this.dgvSystemInfo.TabIndex = 0;
            this.dgvSystemInfo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvSystemInfo_KeyDown);
            // 
            // colName
            // 
            this.colName.HeaderText = "ชื่อผู้ใช้";
            this.colName.Name = "colName";
            this.colName.Width = 150;
            // 
            // UserName
            // 
            this.UserName.HeaderText = "รหัสผู้ใช้";
            this.UserName.Name = "UserName";
            this.UserName.Width = 150;
            // 
            // Status
            // 
            this.Status.HeaderText = "สถานะ";
            this.Status.Name = "Status";
            // 
            // Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1102, 302);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Setting";
            this.Text = "กำหนดค่าต่าง ๆ";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Setting_FormClosed);
            this.Load += new System.EventHandler(this.Setting_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSystemInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btCreateAccount;
        private System.Windows.Forms.TextBox tbPasswordConfirm;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbUserName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvSystemInfo;
        private System.Windows.Forms.RadioButton rbUser;
        private System.Windows.Forms.RadioButton rbAdmin;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
    }
}