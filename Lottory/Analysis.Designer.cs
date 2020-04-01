namespace Lottory
{
    partial class Analysis
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btAnalyze = new System.Windows.Forms.Button();
            this.tbMoney = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvResult = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbNumber2up = new System.Windows.Forms.Label();
            this.lbNetPay = new System.Windows.Forms.Label();
            this.lbpay2up = new System.Windows.Forms.Label();
            this.lbpay3up = new System.Windows.Forms.Label();
            this.lbNumber3up = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvNumberDetail = new System.Windows.Forms.DataGridView();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNumberDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // btAnalyze
            // 
            this.btAnalyze.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btAnalyze.Location = new System.Drawing.Point(98, 70);
            this.btAnalyze.Margin = new System.Windows.Forms.Padding(6);
            this.btAnalyze.Name = "btAnalyze";
            this.btAnalyze.Size = new System.Drawing.Size(119, 42);
            this.btAnalyze.TabIndex = 0;
            this.btAnalyze.Text = "วิเคราะห์";
            this.btAnalyze.UseVisualStyleBackColor = true;
            this.btAnalyze.Click += new System.EventHandler(this.btAnalyze_Click);
            this.btAnalyze.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btAnalyze_KeyDown);
            // 
            // tbMoney
            // 
            this.tbMoney.Location = new System.Drawing.Point(98, 33);
            this.tbMoney.Name = "tbMoney";
            this.tbMoney.Size = new System.Drawing.Size(119, 29);
            this.tbMoney.TabIndex = 1;
            this.tbMoney.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbMoney.TextChanged += new System.EventHandler(this.tbMoney_TextChanged);
            this.tbMoney.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbMoney_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "จำนวนเงิน";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(223, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "บาท";
            // 
            // dgvResult
            // 
            this.dgvResult.AllowUserToAddRows = false;
            this.dgvResult.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvResult.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column9,
            this.Column2,
            this.Column3,
            this.Column10,
            this.Column4,
            this.Column8,
            this.Column7});
            this.dgvResult.Location = new System.Drawing.Point(33, 218);
            this.dgvResult.Name = "dgvResult";
            this.dgvResult.RowHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvResult.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvResult.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvResult.RowTemplate.Height = 25;
            this.dgvResult.Size = new System.Drawing.Size(901, 687);
            this.dgvResult.TabIndex = 3;
            this.dgvResult.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvResult_CellMouseClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "3 ตัว";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "ซื้อ";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "จ่าย";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "2 ตัว";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "ซื้อ";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "จ่าย";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "ยอดรับสุทธิ";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 120;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "ขาดทุนสุทธิ";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 120;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 191);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(269, 24);
            this.label3.TabIndex = 4;
            this.label3.Text = "ตารางตัวเลขที่มีความเสียงเกินกำหนด";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lbNumber2up);
            this.groupBox1.Controls.Add(this.lbNetPay);
            this.groupBox1.Controls.Add(this.lbpay2up);
            this.groupBox1.Controls.Add(this.lbpay3up);
            this.groupBox1.Controls.Add(this.lbNumber3up);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(312, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(622, 171);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ชุดตัวเลขเสี่ยงที่สุด";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label6.Location = new System.Drawing.Point(185, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 31);
            this.label6.TabIndex = 1;
            this.label6.Text = "จ่าย";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label5.Location = new System.Drawing.Point(15, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 31);
            this.label5.TabIndex = 0;
            this.label5.Text = "2 ตัว :";
            // 
            // lbNumber2up
            // 
            this.lbNumber2up.AutoSize = true;
            this.lbNumber2up.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbNumber2up.Location = new System.Drawing.Point(100, 111);
            this.lbNumber2up.Name = "lbNumber2up";
            this.lbNumber2up.Size = new System.Drawing.Size(40, 31);
            this.lbNumber2up.TabIndex = 0;
            this.lbNumber2up.Text = "xx";
            // 
            // lbNetPay
            // 
            this.lbNetPay.AutoSize = true;
            this.lbNetPay.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbNetPay.Location = new System.Drawing.Point(373, 70);
            this.lbNetPay.Name = "lbNetPay";
            this.lbNetPay.Size = new System.Drawing.Size(134, 31);
            this.lbNetPay.TabIndex = 0;
            this.lbNetPay.Text = "xx,xxx,xxx";
            // 
            // lbpay2up
            // 
            this.lbpay2up.AutoSize = true;
            this.lbpay2up.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbpay2up.Location = new System.Drawing.Point(185, 111);
            this.lbpay2up.Name = "lbpay2up";
            this.lbpay2up.Size = new System.Drawing.Size(121, 31);
            this.lbpay2up.TabIndex = 0;
            this.lbpay2up.Text = "x,xxx,xxx";
            // 
            // lbpay3up
            // 
            this.lbpay3up.AutoSize = true;
            this.lbpay3up.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbpay3up.Location = new System.Drawing.Point(185, 70);
            this.lbpay3up.Name = "lbpay3up";
            this.lbpay3up.Size = new System.Drawing.Size(121, 31);
            this.lbpay3up.TabIndex = 0;
            this.lbpay3up.Text = "x,xxx,xxx";
            // 
            // lbNumber3up
            // 
            this.lbNumber3up.AutoSize = true;
            this.lbNumber3up.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbNumber3up.Location = new System.Drawing.Point(100, 70);
            this.lbNumber3up.Name = "lbNumber3up";
            this.lbNumber3up.Size = new System.Drawing.Size(53, 31);
            this.lbNumber3up.TabIndex = 0;
            this.lbNumber3up.Text = "xxx";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label8.Location = new System.Drawing.Point(373, 29);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(139, 31);
            this.label8.TabIndex = 0;
            this.label8.Text = "ขาดทุนสุทธิ ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label4.Location = new System.Drawing.Point(15, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 31);
            this.label4.TabIndex = 0;
            this.label4.Text = "3 ตัว :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btAnalyze);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.tbMoney);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(33, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(273, 171);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "กำหนดค่าความเสียง";
            // 
            // dgvNumberDetail
            // 
            this.dgvNumberDetail.AllowUserToAddRows = false;
            this.dgvNumberDetail.AllowUserToDeleteRows = false;
            this.dgvNumberDetail.AllowUserToOrderColumns = true;
            this.dgvNumberDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNumberDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column5,
            this.Column6});
            this.dgvNumberDetail.Location = new System.Drawing.Point(953, 218);
            this.dgvNumberDetail.Name = "dgvNumberDetail";
            this.dgvNumberDetail.RowHeadersVisible = false;
            this.dgvNumberDetail.Size = new System.Drawing.Size(231, 332);
            this.dgvNumberDetail.TabIndex = 7;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "3 ตัว";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "ซื้อ";
            this.Column6.Name = "Column6";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(949, 191);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(201, 24);
            this.label7.TabIndex = 8;
            this.label7.Text = "รายละเอียดตัวเลขชุดที่เหลือ";
            // 
            // Analysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1246, 917);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dgvNumberDetail);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvResult);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Analysis";
            this.Text = "วิเคราะห์ความเสี่ยง";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Analysis_FormClosed);
            this.Load += new System.EventHandler(this.Analysis_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNumberDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tbMoney;
        private System.Windows.Forms.Button btAnalyze;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvResult;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbNumber3up;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lbNumber2up;
        private System.Windows.Forms.Label lbNetPay;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbpay2up;
        private System.Windows.Forms.Label lbpay3up;
        private System.Windows.Forms.DataGridView dgvNumberDetail;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
    }
}