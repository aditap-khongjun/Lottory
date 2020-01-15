namespace Lottory
{
    partial class AddNumberSetting
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
            this.btAddNumber = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.customerID = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pageNumber = new System.Windows.Forms.TextBox();
            this.btBackToMain = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.editMLim5 = new System.Windows.Forms.Button();
            this.MoneyLimit5 = new System.Windows.Forms.TextBox();
            this.lbLimit5 = new System.Windows.Forms.Label();
            this.editMLim4 = new System.Windows.Forms.Button();
            this.MoneyLimit4 = new System.Windows.Forms.TextBox();
            this.lbLimit4 = new System.Windows.Forms.Label();
            this.editMLim3 = new System.Windows.Forms.Button();
            this.MoneyLimit3 = new System.Windows.Forms.TextBox();
            this.lbLimit3 = new System.Windows.Forms.Label();
            this.editMLim2 = new System.Windows.Forms.Button();
            this.MoneyLimit2 = new System.Windows.Forms.TextBox();
            this.lbLimit2 = new System.Windows.Forms.Label();
            this.editMLim1 = new System.Windows.Forms.Button();
            this.MoneyLimit1 = new System.Windows.Forms.TextBox();
            this.lbLimit1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btAddNumber
            // 
            this.btAddNumber.Location = new System.Drawing.Point(16, 99);
            this.btAddNumber.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btAddNumber.Name = "btAddNumber";
            this.btAddNumber.Size = new System.Drawing.Size(135, 27);
            this.btAddNumber.TabIndex = 0;
            this.btAddNumber.Text = "ป้อนตัวเลข";
            this.btAddNumber.UseVisualStyleBackColor = true;
            this.btAddNumber.Click += new System.EventHandler(this.btAddNumber_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "รหัสลูกค้า";
            // 
            // customerID
            // 
            this.customerID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.customerID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.customerID.BackColor = System.Drawing.SystemColors.Window;
            this.customerID.FormattingEnabled = true;
            this.customerID.Location = new System.Drawing.Point(16, 27);
            this.customerID.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.customerID.Name = "customerID";
            this.customerID.Size = new System.Drawing.Size(137, 21);
            this.customerID.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 51);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "หน้า";
            // 
            // pageNumber
            // 
            this.pageNumber.Location = new System.Drawing.Point(16, 66);
            this.pageNumber.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pageNumber.Name = "pageNumber";
            this.pageNumber.Size = new System.Drawing.Size(137, 20);
            this.pageNumber.TabIndex = 4;
            // 
            // btBackToMain
            // 
            this.btBackToMain.Location = new System.Drawing.Point(16, 218);
            this.btBackToMain.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btBackToMain.Name = "btBackToMain";
            this.btBackToMain.Size = new System.Drawing.Size(135, 28);
            this.btBackToMain.TabIndex = 5;
            this.btBackToMain.Text = "กลับสู่หน้าหลัก";
            this.btBackToMain.UseVisualStyleBackColor = true;
            this.btBackToMain.Click += new System.EventHandler(this.btBackToMain_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.editMLim5);
            this.groupBox1.Controls.Add(this.MoneyLimit5);
            this.groupBox1.Controls.Add(this.lbLimit5);
            this.groupBox1.Controls.Add(this.editMLim4);
            this.groupBox1.Controls.Add(this.MoneyLimit4);
            this.groupBox1.Controls.Add(this.lbLimit4);
            this.groupBox1.Controls.Add(this.editMLim3);
            this.groupBox1.Controls.Add(this.MoneyLimit3);
            this.groupBox1.Controls.Add(this.lbLimit3);
            this.groupBox1.Controls.Add(this.editMLim2);
            this.groupBox1.Controls.Add(this.MoneyLimit2);
            this.groupBox1.Controls.Add(this.lbLimit2);
            this.groupBox1.Controls.Add(this.editMLim1);
            this.groupBox1.Controls.Add(this.MoneyLimit1);
            this.groupBox1.Controls.Add(this.lbLimit1);
            this.groupBox1.Location = new System.Drawing.Point(168, 12);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(241, 234);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "วงเงินการเล่น";
            // 
            // editMLim5
            // 
            this.editMLim5.Location = new System.Drawing.Point(185, 200);
            this.editMLim5.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.editMLim5.Name = "editMLim5";
            this.editMLim5.Size = new System.Drawing.Size(44, 20);
            this.editMLim5.TabIndex = 14;
            this.editMLim5.Text = "แก้ไข";
            this.editMLim5.UseVisualStyleBackColor = true;
            this.editMLim5.Click += new System.EventHandler(this.editMLim5_Click);
            // 
            // MoneyLimit5
            // 
            this.MoneyLimit5.Location = new System.Drawing.Point(16, 200);
            this.MoneyLimit5.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MoneyLimit5.Name = "MoneyLimit5";
            this.MoneyLimit5.Size = new System.Drawing.Size(165, 20);
            this.MoneyLimit5.TabIndex = 13;
            this.MoneyLimit5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbLimit5
            // 
            this.lbLimit5.AutoSize = true;
            this.lbLimit5.Location = new System.Drawing.Point(16, 187);
            this.lbLimit5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbLimit5.Name = "lbLimit5";
            this.lbLimit5.Size = new System.Drawing.Size(55, 13);
            this.lbLimit5.TabIndex = 12;
            this.lbLimit5.Text = "5 โต๊ด, ชุด";
            // 
            // editMLim4
            // 
            this.editMLim4.Location = new System.Drawing.Point(185, 163);
            this.editMLim4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.editMLim4.Name = "editMLim4";
            this.editMLim4.Size = new System.Drawing.Size(44, 19);
            this.editMLim4.TabIndex = 11;
            this.editMLim4.Text = "แก้ไข";
            this.editMLim4.UseVisualStyleBackColor = true;
            this.editMLim4.Click += new System.EventHandler(this.editMLim4_Click);
            // 
            // MoneyLimit4
            // 
            this.MoneyLimit4.Location = new System.Drawing.Point(16, 162);
            this.MoneyLimit4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MoneyLimit4.Name = "MoneyLimit4";
            this.MoneyLimit4.Size = new System.Drawing.Size(165, 20);
            this.MoneyLimit4.TabIndex = 10;
            this.MoneyLimit4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbLimit4
            // 
            this.lbLimit4.AutoSize = true;
            this.lbLimit4.Location = new System.Drawing.Point(16, 148);
            this.lbLimit4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbLimit4.Name = "lbLimit4";
            this.lbLimit4.Size = new System.Drawing.Size(30, 13);
            this.lbLimit4.TabIndex = 9;
            this.lbLimit4.Text = "4 ชุด";
            // 
            // editMLim3
            // 
            this.editMLim3.Location = new System.Drawing.Point(185, 124);
            this.editMLim3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.editMLim3.Name = "editMLim3";
            this.editMLim3.Size = new System.Drawing.Size(44, 19);
            this.editMLim3.TabIndex = 8;
            this.editMLim3.Text = "แก้ไข";
            this.editMLim3.UseVisualStyleBackColor = true;
            this.editMLim3.Click += new System.EventHandler(this.editMLim3_Click);
            // 
            // MoneyLimit3
            // 
            this.MoneyLimit3.Location = new System.Drawing.Point(16, 123);
            this.MoneyLimit3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MoneyLimit3.Name = "MoneyLimit3";
            this.MoneyLimit3.Size = new System.Drawing.Size(165, 20);
            this.MoneyLimit3.TabIndex = 7;
            this.MoneyLimit3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbLimit3
            // 
            this.lbLimit3.AutoSize = true;
            this.lbLimit3.Location = new System.Drawing.Point(16, 108);
            this.lbLimit3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbLimit3.Name = "lbLimit3";
            this.lbLimit3.Size = new System.Drawing.Size(122, 13);
            this.lbLimit3.TabIndex = 6;
            this.lbLimit3.Text = "3 บน, ล่าง, โต๊ด(ตรง, ชุด)";
            // 
            // editMLim2
            // 
            this.editMLim2.Location = new System.Drawing.Point(185, 80);
            this.editMLim2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.editMLim2.Name = "editMLim2";
            this.editMLim2.Size = new System.Drawing.Size(44, 19);
            this.editMLim2.TabIndex = 5;
            this.editMLim2.Text = "แก้ไข";
            this.editMLim2.UseVisualStyleBackColor = true;
            this.editMLim2.Click += new System.EventHandler(this.editMLim2_Click);
            // 
            // MoneyLimit2
            // 
            this.MoneyLimit2.Location = new System.Drawing.Point(16, 79);
            this.MoneyLimit2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MoneyLimit2.Name = "MoneyLimit2";
            this.MoneyLimit2.Size = new System.Drawing.Size(165, 20);
            this.MoneyLimit2.TabIndex = 4;
            this.MoneyLimit2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbLimit2
            // 
            this.lbLimit2.AutoSize = true;
            this.lbLimit2.Location = new System.Drawing.Point(16, 64);
            this.lbLimit2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbLimit2.Name = "lbLimit2";
            this.lbLimit2.Size = new System.Drawing.Size(165, 13);
            this.lbLimit2.TabIndex = 3;
            this.lbLimit2.Text = "2 บน, ล่าง, โต๊ด, ถ่าง, ปักหน้า, หลัง";
            // 
            // editMLim1
            // 
            this.editMLim1.Location = new System.Drawing.Point(185, 36);
            this.editMLim1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.editMLim1.Name = "editMLim1";
            this.editMLim1.Size = new System.Drawing.Size(44, 19);
            this.editMLim1.TabIndex = 2;
            this.editMLim1.Text = "แก้ไข";
            this.editMLim1.UseVisualStyleBackColor = true;
            this.editMLim1.Click += new System.EventHandler(this.editMLim1_Click);
            // 
            // MoneyLimit1
            // 
            this.MoneyLimit1.Location = new System.Drawing.Point(16, 35);
            this.MoneyLimit1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MoneyLimit1.Name = "MoneyLimit1";
            this.MoneyLimit1.Size = new System.Drawing.Size(165, 20);
            this.MoneyLimit1.TabIndex = 1;
            this.MoneyLimit1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbLimit1
            // 
            this.lbLimit1.AutoSize = true;
            this.lbLimit1.Location = new System.Drawing.Point(16, 19);
            this.lbLimit1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbLimit1.Name = "lbLimit1";
            this.lbLimit1.Size = new System.Drawing.Size(155, 13);
            this.lbLimit1.TabIndex = 0;
            this.lbLimit1.Text = "1 ลอย, หน้า, กลาง, หลัง, ลอยล่าง";
            // 
            // AddNumberSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 265);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btBackToMain);
            this.Controls.Add(this.pageNumber);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.customerID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btAddNumber);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "AddNumberSetting";
            this.Text = "ตั้งค่าการป้อนตัวเลข";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AddNumberSetting_FormClosed);
            this.Load += new System.EventHandler(this.AddNumberSetting_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btAddNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox customerID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox pageNumber;
        private System.Windows.Forms.Button btBackToMain;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbLimit1;
        private System.Windows.Forms.Button editMLim5;
        private System.Windows.Forms.TextBox MoneyLimit5;
        private System.Windows.Forms.Label lbLimit5;
        private System.Windows.Forms.Button editMLim4;
        private System.Windows.Forms.TextBox MoneyLimit4;
        private System.Windows.Forms.Label lbLimit4;
        private System.Windows.Forms.Button editMLim3;
        private System.Windows.Forms.TextBox MoneyLimit3;
        private System.Windows.Forms.Label lbLimit3;
        private System.Windows.Forms.Button editMLim2;
        private System.Windows.Forms.TextBox MoneyLimit2;
        private System.Windows.Forms.Label lbLimit2;
        private System.Windows.Forms.Button editMLim1;
        private System.Windows.Forms.TextBox MoneyLimit1;
    }
}