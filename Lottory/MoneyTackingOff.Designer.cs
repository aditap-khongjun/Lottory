namespace Lottory
{
    partial class MoneyTackingOff
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
            this.btTakeOff = new System.Windows.Forms.Button();
            this.tbMoneyOfset = new System.Windows.Forms.TextBox();
            this.tbTakeOffMoney = new System.Windows.Forms.TextBox();
            this.cbTypeName = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btShowInHand = new System.Windows.Forms.Button();
            this.btShowTakeOff = new System.Windows.Forms.Button();
            this.btShowAll = new System.Windows.Forms.Button();
            this.btClear = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.dgvNumber3up = new System.Windows.Forms.DataGridView();
            this.dgvNumber2up = new System.Windows.Forms.DataGridView();
            this.dgvNumber2low = new System.Windows.Forms.DataGridView();
            this.dgvNumber3low = new System.Windows.Forms.DataGridView();
            this.dgvNumber1up = new System.Windows.Forms.DataGridView();
            this.dgvNumber1low = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbTakeOut2low = new System.Windows.Forms.Label();
            this.lbTakeOut2up = new System.Windows.Forms.Label();
            this.lbTakeOut3up = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNumber3up)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNumber2up)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNumber2low)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNumber3low)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNumber1up)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNumber1low)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btTakeOff);
            this.groupBox1.Controls.Add(this.tbMoneyOfset);
            this.groupBox1.Controls.Add(this.tbTakeOffMoney);
            this.groupBox1.Controls.Add(this.cbTypeName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(323, 263);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ตีตัวเลขเกินวงเงินอั้น";
            // 
            // btTakeOff
            // 
            this.btTakeOff.Location = new System.Drawing.Point(129, 194);
            this.btTakeOff.Name = "btTakeOff";
            this.btTakeOff.Size = new System.Drawing.Size(133, 44);
            this.btTakeOff.TabIndex = 3;
            this.btTakeOff.Text = "ทำการตีออก";
            this.btTakeOff.UseVisualStyleBackColor = true;
            this.btTakeOff.Click += new System.EventHandler(this.btTakeOff_Click);
            // 
            // tbMoneyOfset
            // 
            this.tbMoneyOfset.Location = new System.Drawing.Point(129, 139);
            this.tbMoneyOfset.Name = "tbMoneyOfset";
            this.tbMoneyOfset.Size = new System.Drawing.Size(133, 26);
            this.tbMoneyOfset.TabIndex = 2;
            this.tbMoneyOfset.Text = "0";
            this.tbMoneyOfset.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbMoneyOfset.TextChanged += new System.EventHandler(this.tbMoneyOfset_TextChanged);
            // 
            // tbTakeOffMoney
            // 
            this.tbTakeOffMoney.Location = new System.Drawing.Point(129, 95);
            this.tbTakeOffMoney.Name = "tbTakeOffMoney";
            this.tbTakeOffMoney.Size = new System.Drawing.Size(133, 26);
            this.tbTakeOffMoney.TabIndex = 2;
            this.tbTakeOffMoney.Text = "0";
            this.tbTakeOffMoney.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbTakeOffMoney.TextChanged += new System.EventHandler(this.tbTakeOffMoney_TextChanged);
            // 
            // cbTypeName
            // 
            this.cbTypeName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cbTypeName.FormattingEnabled = true;
            this.cbTypeName.Items.AddRange(new object[] {
            "3 บน",
            "2 บน",
            "2 ล่าง"});
            this.cbTypeName.Location = new System.Drawing.Point(129, 39);
            this.cbTypeName.Name = "cbTypeName";
            this.cbTypeName.Size = new System.Drawing.Size(133, 28);
            this.cbTypeName.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(21, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 23);
            this.label3.TabIndex = 0;
            this.label3.Text = "ช่วง";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(21, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "วงเงินที่ตีออก";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(21, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "หมวด";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btShowInHand
            // 
            this.btShowInHand.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btShowInHand.Location = new System.Drawing.Point(352, 21);
            this.btShowInHand.Name = "btShowInHand";
            this.btShowInHand.Size = new System.Drawing.Size(184, 46);
            this.btShowInHand.TabIndex = 1;
            this.btShowInHand.Text = "แสดงยอดในมือ";
            this.btShowInHand.UseVisualStyleBackColor = true;
            this.btShowInHand.Click += new System.EventHandler(this.btShowInHand_Click);
            // 
            // btShowTakeOff
            // 
            this.btShowTakeOff.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btShowTakeOff.Location = new System.Drawing.Point(352, 90);
            this.btShowTakeOff.Name = "btShowTakeOff";
            this.btShowTakeOff.Size = new System.Drawing.Size(184, 46);
            this.btShowTakeOff.TabIndex = 2;
            this.btShowTakeOff.Text = "แสดงยอดที่ตีออก";
            this.btShowTakeOff.UseVisualStyleBackColor = true;
            this.btShowTakeOff.Click += new System.EventHandler(this.btShowTakeOff_Click);
            // 
            // btShowAll
            // 
            this.btShowAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btShowAll.Location = new System.Drawing.Point(352, 159);
            this.btShowAll.Name = "btShowAll";
            this.btShowAll.Size = new System.Drawing.Size(184, 46);
            this.btShowAll.TabIndex = 3;
            this.btShowAll.Text = "แสดงยอดทั้งหมด";
            this.btShowAll.UseVisualStyleBackColor = true;
            this.btShowAll.Click += new System.EventHandler(this.btShowAll_Click);
            // 
            // btClear
            // 
            this.btClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btClear.Location = new System.Drawing.Point(352, 228);
            this.btClear.Name = "btClear";
            this.btClear.Size = new System.Drawing.Size(184, 46);
            this.btClear.TabIndex = 4;
            this.btClear.Text = "ยกเลิกการตีออกทั้งหมด";
            this.btClear.UseVisualStyleBackColor = true;
            this.btClear.Click += new System.EventHandler(this.btClear_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.button6.Location = new System.Drawing.Point(12, 293);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(129, 55);
            this.button6.TabIndex = 5;
            this.button6.Text = "กลับสู่เมนูหลัก";
            this.button6.UseVisualStyleBackColor = false;
            // 
            // dgvNumber3up
            // 
            this.dgvNumber3up.AllowUserToAddRows = false;
            this.dgvNumber3up.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNumber3up.Location = new System.Drawing.Point(590, 42);
            this.dgvNumber3up.Name = "dgvNumber3up";
            this.dgvNumber3up.RowHeadersVisible = false;
            this.dgvNumber3up.Size = new System.Drawing.Size(184, 681);
            this.dgvNumber3up.TabIndex = 6;
            // 
            // dgvNumber2up
            // 
            this.dgvNumber2up.AllowUserToAddRows = false;
            this.dgvNumber2up.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNumber2up.Location = new System.Drawing.Point(792, 42);
            this.dgvNumber2up.Name = "dgvNumber2up";
            this.dgvNumber2up.RowHeadersVisible = false;
            this.dgvNumber2up.Size = new System.Drawing.Size(184, 681);
            this.dgvNumber2up.TabIndex = 7;
            // 
            // dgvNumber2low
            // 
            this.dgvNumber2low.AllowUserToAddRows = false;
            this.dgvNumber2low.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNumber2low.Location = new System.Drawing.Point(994, 42);
            this.dgvNumber2low.Name = "dgvNumber2low";
            this.dgvNumber2low.RowHeadersVisible = false;
            this.dgvNumber2low.Size = new System.Drawing.Size(184, 681);
            this.dgvNumber2low.TabIndex = 8;
            // 
            // dgvNumber3low
            // 
            this.dgvNumber3low.AllowUserToAddRows = false;
            this.dgvNumber3low.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNumber3low.Location = new System.Drawing.Point(1196, 42);
            this.dgvNumber3low.Name = "dgvNumber3low";
            this.dgvNumber3low.RowHeadersVisible = false;
            this.dgvNumber3low.Size = new System.Drawing.Size(184, 681);
            this.dgvNumber3low.TabIndex = 9;
            // 
            // dgvNumber1up
            // 
            this.dgvNumber1up.AllowUserToAddRows = false;
            this.dgvNumber1up.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNumber1up.Location = new System.Drawing.Point(1398, 42);
            this.dgvNumber1up.Name = "dgvNumber1up";
            this.dgvNumber1up.RowHeadersVisible = false;
            this.dgvNumber1up.Size = new System.Drawing.Size(184, 681);
            this.dgvNumber1up.TabIndex = 10;
            // 
            // dgvNumber1low
            // 
            this.dgvNumber1low.AllowUserToAddRows = false;
            this.dgvNumber1low.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNumber1low.Location = new System.Drawing.Point(1600, 42);
            this.dgvNumber1low.Name = "dgvNumber1low";
            this.dgvNumber1low.RowHeadersVisible = false;
            this.dgvNumber1low.Size = new System.Drawing.Size(184, 681);
            this.dgvNumber1low.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label4.Location = new System.Drawing.Point(665, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 20);
            this.label4.TabIndex = 12;
            this.label4.Text = "3 บน";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label5.Location = new System.Drawing.Point(866, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "2 บน";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label6.Location = new System.Drawing.Point(1062, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 20);
            this.label6.TabIndex = 12;
            this.label6.Text = "2 ล่าง";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label7.Location = new System.Drawing.Point(1267, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 20);
            this.label7.TabIndex = 12;
            this.label7.Text = "3 ล่าง";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label8.Location = new System.Drawing.Point(1473, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 20);
            this.label8.TabIndex = 12;
            this.label8.Text = "1 บน";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label9.Location = new System.Drawing.Point(1674, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 20);
            this.label9.TabIndex = 12;
            this.label9.Text = "1 ล่าง";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbTakeOut2low);
            this.groupBox2.Controls.Add(this.lbTakeOut2up);
            this.groupBox2.Controls.Add(this.lbTakeOut3up);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.groupBox2.Location = new System.Drawing.Point(352, 293);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(184, 155);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "สรปยอดที่ตีออก";
            // 
            // lbTakeOut2low
            // 
            this.lbTakeOut2low.AutoSize = true;
            this.lbTakeOut2low.Location = new System.Drawing.Point(81, 109);
            this.lbTakeOut2low.Name = "lbTakeOut2low";
            this.lbTakeOut2low.Size = new System.Drawing.Size(65, 24);
            this.lbTakeOut2low.TabIndex = 4;
            this.lbTakeOut2low.Text = "xx,xxx";
            // 
            // lbTakeOut2up
            // 
            this.lbTakeOut2up.AutoSize = true;
            this.lbTakeOut2up.Location = new System.Drawing.Point(81, 70);
            this.lbTakeOut2up.Name = "lbTakeOut2up";
            this.lbTakeOut2up.Size = new System.Drawing.Size(65, 24);
            this.lbTakeOut2up.TabIndex = 5;
            this.lbTakeOut2up.Text = "xx,xxx";
            // 
            // lbTakeOut3up
            // 
            this.lbTakeOut3up.AutoSize = true;
            this.lbTakeOut3up.Location = new System.Drawing.Point(81, 31);
            this.lbTakeOut3up.Name = "lbTakeOut3up";
            this.lbTakeOut3up.Size = new System.Drawing.Size(65, 24);
            this.lbTakeOut3up.TabIndex = 6;
            this.lbTakeOut3up.Text = "xx,xxx";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(16, 109);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 24);
            this.label12.TabIndex = 0;
            this.label12.Text = "2 ล่าง :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(16, 70);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 24);
            this.label11.TabIndex = 0;
            this.label11.Text = "2 บน :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 31);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 24);
            this.label10.TabIndex = 0;
            this.label10.Text = "3 บน :";
            // 
            // MoneyTackingOff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgvNumber1low);
            this.Controls.Add(this.dgvNumber1up);
            this.Controls.Add(this.dgvNumber3low);
            this.Controls.Add(this.dgvNumber2low);
            this.Controls.Add(this.dgvNumber2up);
            this.Controls.Add(this.dgvNumber3up);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.btClear);
            this.Controls.Add(this.btShowAll);
            this.Controls.Add(this.btShowTakeOff);
            this.Controls.Add(this.btShowInHand);
            this.Controls.Add(this.groupBox1);
            this.Name = "MoneyTackingOff";
            this.Text = "ตีตัวเลขเกินวงเงินอั้น";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MoneyTackingOff_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNumber3up)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNumber2up)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNumber2low)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNumber3low)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNumber1up)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNumber1low)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btTakeOff;
        private System.Windows.Forms.TextBox tbMoneyOfset;
        private System.Windows.Forms.TextBox tbTakeOffMoney;
        private System.Windows.Forms.ComboBox cbTypeName;
        private System.Windows.Forms.Button btShowInHand;
        private System.Windows.Forms.Button btShowTakeOff;
        private System.Windows.Forms.Button btShowAll;
        private System.Windows.Forms.Button btClear;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.DataGridView dgvNumber3up;
        private System.Windows.Forms.DataGridView dgvNumber2up;
        private System.Windows.Forms.DataGridView dgvNumber2low;
        private System.Windows.Forms.DataGridView dgvNumber3low;
        private System.Windows.Forms.DataGridView dgvNumber1up;
        private System.Windows.Forms.DataGridView dgvNumber1low;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lbTakeOut2low;
        private System.Windows.Forms.Label lbTakeOut2up;
        private System.Windows.Forms.Label lbTakeOut3up;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
    }
}