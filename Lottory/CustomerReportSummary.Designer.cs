namespace Lottory
{
    partial class CustomerReportSummary
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
            this.ReportAll = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ReportCustomerPage = new System.Windows.Forms.Button();
            this.ReportCustomer_pay = new System.Windows.Forms.Button();
            this.ReportCustomer = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.CustomerIDList = new System.Windows.Forms.ComboBox();
            this.PageIDList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ReportAll
            // 
            this.ReportAll.Location = new System.Drawing.Point(28, 41);
            this.ReportAll.Name = "ReportAll";
            this.ReportAll.Size = new System.Drawing.Size(411, 50);
            this.ReportAll.TabIndex = 0;
            this.ReportAll.Text = "รายงานสรุปทั้งหมด";
            this.ReportAll.UseVisualStyleBackColor = true;
            this.ReportAll.Click += new System.EventHandler(this.ReportAll_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ReportCustomer_pay);
            this.groupBox1.Controls.Add(this.ReportCustomer);
            this.groupBox1.Controls.Add(this.ReportAll);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(470, 223);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "รายงานบัญชีลูกค้า";
            // 
            // ReportCustomerPage
            // 
            this.ReportCustomerPage.Location = new System.Drawing.Point(20, 153);
            this.ReportCustomerPage.Name = "ReportCustomerPage";
            this.ReportCustomerPage.Size = new System.Drawing.Size(250, 50);
            this.ReportCustomerPage.TabIndex = 0;
            this.ReportCustomerPage.Text = "รายงานแสดงแต่ละหน้าลูกค้า";
            this.ReportCustomerPage.UseVisualStyleBackColor = true;
            this.ReportCustomerPage.Click += new System.EventHandler(this.ReportCustomerPage_Click);
            // 
            // ReportCustomer_pay
            // 
            this.ReportCustomer_pay.Location = new System.Drawing.Point(28, 153);
            this.ReportCustomer_pay.Name = "ReportCustomer_pay";
            this.ReportCustomer_pay.Size = new System.Drawing.Size(411, 50);
            this.ReportCustomer_pay.TabIndex = 0;
            this.ReportCustomer_pay.Text = "รายงานสรุปรวมลูกค้าแต่ละรายที่ต้องจ่าย";
            this.ReportCustomer_pay.UseVisualStyleBackColor = true;
            this.ReportCustomer_pay.Click += new System.EventHandler(this.ReportCustomer_pay_Click);
            // 
            // ReportCustomer
            // 
            this.ReportCustomer.Location = new System.Drawing.Point(28, 97);
            this.ReportCustomer.Name = "ReportCustomer";
            this.ReportCustomer.Size = new System.Drawing.Size(411, 50);
            this.ReportCustomer.TabIndex = 0;
            this.ReportCustomer.Text = "รายงานสรุปรวมลูกค้าแต่ละราย";
            this.ReportCustomer.UseVisualStyleBackColor = true;
            this.ReportCustomer.Click += new System.EventHandler(this.ReportCustomer_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.button5.Location = new System.Drawing.Point(12, 250);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(211, 50);
            this.button5.TabIndex = 0;
            this.button5.Text = "กลับสู่หน้าหลัก";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.PageIDList);
            this.groupBox2.Controls.Add(this.CustomerIDList);
            this.groupBox2.Controls.Add(this.ReportCustomerPage);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.groupBox2.Location = new System.Drawing.Point(488, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(297, 223);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // CustomerIDList
            // 
            this.CustomerIDList.BackColor = System.Drawing.SystemColors.Window;
            this.CustomerIDList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CustomerIDList.FormattingEnabled = true;
            this.CustomerIDList.Location = new System.Drawing.Point(109, 41);
            this.CustomerIDList.Name = "CustomerIDList";
            this.CustomerIDList.Size = new System.Drawing.Size(161, 32);
            this.CustomerIDList.TabIndex = 1;
            this.CustomerIDList.SelectedIndexChanged += new System.EventHandler(this.CustomerIDList_SelectedIndexChanged);
            this.CustomerIDList.SelectedValueChanged += new System.EventHandler(this.comboBox1_SelectedValueChanged);
            // 
            // PageIDList
            // 
            this.PageIDList.BackColor = System.Drawing.SystemColors.Window;
            this.PageIDList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PageIDList.FormattingEnabled = true;
            this.PageIDList.Location = new System.Drawing.Point(109, 97);
            this.PageIDList.Name = "PageIDList";
            this.PageIDList.Size = new System.Drawing.Size(161, 32);
            this.PageIDList.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "รหัสลูกค้า";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "หน้า";
            // 
            // CustomerReportSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1005, 398);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.groupBox1);
            this.Name = "CustomerReportSummary";
            this.Text = "รายงานบัญชีลูกค้า";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CustomerReportSummary_FormClosed);
            this.Load += new System.EventHandler(this.CustomerReportSummary_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ReportAll;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button ReportCustomerPage;
        private System.Windows.Forms.Button ReportCustomer_pay;
        private System.Windows.Forms.Button ReportCustomer;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox PageIDList;
        private System.Windows.Forms.ComboBox CustomerIDList;
    }
}