namespace Lottory
{
    partial class CustomerInformation
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
            this.customerName = new System.Windows.Forms.TextBox();
            this.customerID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.limit_1low = new System.Windows.Forms.TextBox();
            this.limit_1up = new System.Windows.Forms.TextBox();
            this.limit_2low = new System.Windows.Forms.TextBox();
            this.limit_2up = new System.Windows.Forms.TextBox();
            this.limit_3low = new System.Windows.Forms.TextBox();
            this.limit_3up = new System.Windows.Forms.TextBox();
            this.limit_3uptod = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.discount_1low = new System.Windows.Forms.TextBox();
            this.discount_5tod = new System.Windows.Forms.TextBox();
            this.discount_3tod = new System.Windows.Forms.TextBox();
            this.discount_3low = new System.Windows.Forms.TextBox();
            this.discount_3up = new System.Windows.Forms.TextBox();
            this.discount_2uptod = new System.Windows.Forms.TextBox();
            this.discount_2low = new System.Windows.Forms.TextBox();
            this.discount_2up = new System.Windows.Forms.TextBox();
            this.discount_1back = new System.Windows.Forms.TextBox();
            this.discount_1center = new System.Windows.Forms.TextBox();
            this.discount_1front = new System.Windows.Forms.TextBox();
            this.discount_1up = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.payRate_1low = new System.Windows.Forms.TextBox();
            this.payRate_5tod = new System.Windows.Forms.TextBox();
            this.payRate_3tod = new System.Windows.Forms.TextBox();
            this.payRate_3low = new System.Windows.Forms.TextBox();
            this.payRate_3up = new System.Windows.Forms.TextBox();
            this.payRate_2uptod = new System.Windows.Forms.TextBox();
            this.payRate_2low = new System.Windows.Forms.TextBox();
            this.payRate_2up = new System.Windows.Forms.TextBox();
            this.payRate_1back = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.payRate_1center = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.payRate_1front = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.payRate_1up = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.Save = new System.Windows.Forms.Button();
            this.Add = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            this.Change = new System.Windows.Forms.Button();
            this.toMain = new System.Windows.Forms.Button();
            this.initial_value = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.customerName);
            this.groupBox1.Controls.Add(this.customerID);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(234, 110);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ข้อมูลลูกค้า";
            // 
            // customerName
            // 
            this.customerName.Location = new System.Drawing.Point(82, 61);
            this.customerName.Name = "customerName";
            this.customerName.Size = new System.Drawing.Size(100, 20);
            this.customerName.TabIndex = 3;
            // 
            // customerID
            // 
            this.customerID.Location = new System.Drawing.Point(82, 32);
            this.customerID.Name = "customerID";
            this.customerID.Size = new System.Drawing.Size(100, 20);
            this.customerID.TabIndex = 2;
            this.customerID.TextChanged += new System.EventHandler(this.customerID_Change);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "ชื่อลูกค้า";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "รหัสลูกค้า";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.limit_1low);
            this.groupBox2.Controls.Add(this.limit_1up);
            this.groupBox2.Controls.Add(this.limit_2low);
            this.groupBox2.Controls.Add(this.limit_2up);
            this.groupBox2.Controls.Add(this.limit_3low);
            this.groupBox2.Controls.Add(this.limit_3up);
            this.groupBox2.Controls.Add(this.limit_3uptod);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(12, 128);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(234, 228);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "จำกัดการเล่น";
            // 
            // limit_1low
            // 
            this.limit_1low.Location = new System.Drawing.Point(82, 188);
            this.limit_1low.Name = "limit_1low";
            this.limit_1low.Size = new System.Drawing.Size(100, 20);
            this.limit_1low.TabIndex = 12;
            this.limit_1low.Text = "0";
            this.limit_1low.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.limit_1low.Click += new System.EventHandler(this.select_all_click);
            this.limit_1low.TextChanged += new System.EventHandler(this.correct_checking);
            // 
            // limit_1up
            // 
            this.limit_1up.Location = new System.Drawing.Point(82, 162);
            this.limit_1up.Name = "limit_1up";
            this.limit_1up.Size = new System.Drawing.Size(100, 20);
            this.limit_1up.TabIndex = 11;
            this.limit_1up.Text = "0";
            this.limit_1up.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.limit_1up.Click += new System.EventHandler(this.select_all_click);
            this.limit_1up.TextChanged += new System.EventHandler(this.correct_checking);
            // 
            // limit_2low
            // 
            this.limit_2low.Location = new System.Drawing.Point(82, 136);
            this.limit_2low.Name = "limit_2low";
            this.limit_2low.Size = new System.Drawing.Size(100, 20);
            this.limit_2low.TabIndex = 10;
            this.limit_2low.Text = "0";
            this.limit_2low.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.limit_2low.Click += new System.EventHandler(this.select_all_click);
            this.limit_2low.TextChanged += new System.EventHandler(this.correct_checking);
            // 
            // limit_2up
            // 
            this.limit_2up.Location = new System.Drawing.Point(82, 110);
            this.limit_2up.Name = "limit_2up";
            this.limit_2up.Size = new System.Drawing.Size(100, 20);
            this.limit_2up.TabIndex = 9;
            this.limit_2up.Text = "0";
            this.limit_2up.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.limit_2up.Click += new System.EventHandler(this.select_all_click);
            this.limit_2up.TextChanged += new System.EventHandler(this.correct_checking);
            // 
            // limit_3low
            // 
            this.limit_3low.Location = new System.Drawing.Point(82, 84);
            this.limit_3low.Name = "limit_3low";
            this.limit_3low.Size = new System.Drawing.Size(100, 20);
            this.limit_3low.TabIndex = 8;
            this.limit_3low.Text = "0";
            this.limit_3low.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.limit_3low.Click += new System.EventHandler(this.select_all_click);
            this.limit_3low.TextChanged += new System.EventHandler(this.correct_checking);
            // 
            // limit_3up
            // 
            this.limit_3up.Location = new System.Drawing.Point(82, 58);
            this.limit_3up.Name = "limit_3up";
            this.limit_3up.Size = new System.Drawing.Size(100, 20);
            this.limit_3up.TabIndex = 7;
            this.limit_3up.Text = "0";
            this.limit_3up.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.limit_3up.Click += new System.EventHandler(this.select_all_click);
            this.limit_3up.TextChanged += new System.EventHandler(this.correct_checking);
            // 
            // limit_3uptod
            // 
            this.limit_3uptod.Location = new System.Drawing.Point(82, 32);
            this.limit_3uptod.Name = "limit_3uptod";
            this.limit_3uptod.Size = new System.Drawing.Size(100, 20);
            this.limit_3uptod.TabIndex = 4;
            this.limit_3uptod.Text = "0";
            this.limit_3uptod.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.limit_3uptod.Click += new System.EventHandler(this.select_all_click);
            this.limit_3uptod.TextChanged += new System.EventHandler(this.correct_checking);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(20, 191);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "1 ล่าง";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 165);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "1 บน";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 139);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "2 ล่าง";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 113);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "2 บน";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "3 ล่าง";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "3 บน";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "3 บน/โต๊ด";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label23);
            this.groupBox3.Controls.Add(this.label22);
            this.groupBox3.Controls.Add(this.discount_1low);
            this.groupBox3.Controls.Add(this.discount_5tod);
            this.groupBox3.Controls.Add(this.discount_3tod);
            this.groupBox3.Controls.Add(this.discount_3low);
            this.groupBox3.Controls.Add(this.discount_3up);
            this.groupBox3.Controls.Add(this.discount_2uptod);
            this.groupBox3.Controls.Add(this.discount_2low);
            this.groupBox3.Controls.Add(this.discount_2up);
            this.groupBox3.Controls.Add(this.discount_1back);
            this.groupBox3.Controls.Add(this.discount_1center);
            this.groupBox3.Controls.Add(this.discount_1front);
            this.groupBox3.Controls.Add(this.discount_1up);
            this.groupBox3.Controls.Add(this.label21);
            this.groupBox3.Controls.Add(this.label20);
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.payRate_1low);
            this.groupBox3.Controls.Add(this.payRate_5tod);
            this.groupBox3.Controls.Add(this.payRate_3tod);
            this.groupBox3.Controls.Add(this.payRate_3low);
            this.groupBox3.Controls.Add(this.payRate_3up);
            this.groupBox3.Controls.Add(this.payRate_2uptod);
            this.groupBox3.Controls.Add(this.payRate_2low);
            this.groupBox3.Controls.Add(this.payRate_2up);
            this.groupBox3.Controls.Add(this.payRate_1back);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.payRate_1center);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.payRate_1front);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.payRate_1up);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Location = new System.Drawing.Point(252, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(271, 380);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "อัตราจ่าย และส่วนลด";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(172, 22);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(57, 13);
            this.label23.TabIndex = 49;
            this.label23.Text = "ส่วนลด (%)";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(127, 22);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(25, 13);
            this.label22.TabIndex = 48;
            this.label22.Text = "จ่าย";
            // 
            // discount_1low
            // 
            this.discount_1low.Location = new System.Drawing.Point(174, 328);
            this.discount_1low.Name = "discount_1low";
            this.discount_1low.Size = new System.Drawing.Size(55, 20);
            this.discount_1low.TabIndex = 47;
            this.discount_1low.Text = "0";
            this.discount_1low.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.discount_1low.Click += new System.EventHandler(this.select_all_click);
            this.discount_1low.TextChanged += new System.EventHandler(this.correct_checking);
            // 
            // discount_5tod
            // 
            this.discount_5tod.Location = new System.Drawing.Point(174, 302);
            this.discount_5tod.Name = "discount_5tod";
            this.discount_5tod.Size = new System.Drawing.Size(55, 20);
            this.discount_5tod.TabIndex = 46;
            this.discount_5tod.Text = "0";
            this.discount_5tod.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.discount_5tod.Click += new System.EventHandler(this.select_all_click);
            this.discount_5tod.TextChanged += new System.EventHandler(this.correct_checking);
            // 
            // discount_3tod
            // 
            this.discount_3tod.Location = new System.Drawing.Point(174, 276);
            this.discount_3tod.Name = "discount_3tod";
            this.discount_3tod.Size = new System.Drawing.Size(55, 20);
            this.discount_3tod.TabIndex = 45;
            this.discount_3tod.Text = "0";
            this.discount_3tod.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.discount_3tod.Click += new System.EventHandler(this.select_all_click);
            this.discount_3tod.TextChanged += new System.EventHandler(this.correct_checking);
            // 
            // discount_3low
            // 
            this.discount_3low.Location = new System.Drawing.Point(174, 251);
            this.discount_3low.Name = "discount_3low";
            this.discount_3low.Size = new System.Drawing.Size(55, 20);
            this.discount_3low.TabIndex = 44;
            this.discount_3low.Text = "0";
            this.discount_3low.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.discount_3low.Click += new System.EventHandler(this.select_all_click);
            this.discount_3low.TextChanged += new System.EventHandler(this.correct_checking);
            // 
            // discount_3up
            // 
            this.discount_3up.Location = new System.Drawing.Point(174, 225);
            this.discount_3up.Name = "discount_3up";
            this.discount_3up.Size = new System.Drawing.Size(55, 20);
            this.discount_3up.TabIndex = 43;
            this.discount_3up.Text = "0";
            this.discount_3up.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.discount_3up.Click += new System.EventHandler(this.select_all_click);
            this.discount_3up.TextChanged += new System.EventHandler(this.correct_checking);
            // 
            // discount_2uptod
            // 
            this.discount_2uptod.Location = new System.Drawing.Point(174, 199);
            this.discount_2uptod.Name = "discount_2uptod";
            this.discount_2uptod.Size = new System.Drawing.Size(55, 20);
            this.discount_2uptod.TabIndex = 42;
            this.discount_2uptod.Text = "0";
            this.discount_2uptod.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.discount_2uptod.Click += new System.EventHandler(this.select_all_click);
            this.discount_2uptod.TextChanged += new System.EventHandler(this.correct_checking);
            // 
            // discount_2low
            // 
            this.discount_2low.Location = new System.Drawing.Point(174, 173);
            this.discount_2low.Name = "discount_2low";
            this.discount_2low.Size = new System.Drawing.Size(55, 20);
            this.discount_2low.TabIndex = 41;
            this.discount_2low.Text = "0";
            this.discount_2low.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.discount_2low.Click += new System.EventHandler(this.select_all_click);
            this.discount_2low.TextChanged += new System.EventHandler(this.correct_checking);
            // 
            // discount_2up
            // 
            this.discount_2up.Location = new System.Drawing.Point(174, 148);
            this.discount_2up.Name = "discount_2up";
            this.discount_2up.Size = new System.Drawing.Size(55, 20);
            this.discount_2up.TabIndex = 40;
            this.discount_2up.Text = "0";
            this.discount_2up.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.discount_2up.Click += new System.EventHandler(this.select_all_click);
            this.discount_2up.TextChanged += new System.EventHandler(this.correct_checking);
            // 
            // discount_1back
            // 
            this.discount_1back.Location = new System.Drawing.Point(174, 122);
            this.discount_1back.Name = "discount_1back";
            this.discount_1back.Size = new System.Drawing.Size(55, 20);
            this.discount_1back.TabIndex = 39;
            this.discount_1back.Text = "0";
            this.discount_1back.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.discount_1back.Click += new System.EventHandler(this.select_all_click);
            this.discount_1back.TextChanged += new System.EventHandler(this.correct_checking);
            // 
            // discount_1center
            // 
            this.discount_1center.Location = new System.Drawing.Point(174, 96);
            this.discount_1center.Name = "discount_1center";
            this.discount_1center.Size = new System.Drawing.Size(55, 20);
            this.discount_1center.TabIndex = 38;
            this.discount_1center.Text = "0";
            this.discount_1center.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.discount_1center.Click += new System.EventHandler(this.select_all_click);
            this.discount_1center.TextChanged += new System.EventHandler(this.correct_checking);
            // 
            // discount_1front
            // 
            this.discount_1front.Location = new System.Drawing.Point(174, 70);
            this.discount_1front.Name = "discount_1front";
            this.discount_1front.Size = new System.Drawing.Size(55, 20);
            this.discount_1front.TabIndex = 37;
            this.discount_1front.Text = "0";
            this.discount_1front.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.discount_1front.Click += new System.EventHandler(this.select_all_click);
            this.discount_1front.TextChanged += new System.EventHandler(this.correct_checking);
            // 
            // discount_1up
            // 
            this.discount_1up.Location = new System.Drawing.Point(174, 45);
            this.discount_1up.Name = "discount_1up";
            this.discount_1up.Size = new System.Drawing.Size(55, 20);
            this.discount_1up.TabIndex = 36;
            this.discount_1up.Text = "0";
            this.discount_1up.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.discount_1up.Click += new System.EventHandler(this.select_all_click);
            this.discount_1up.TextChanged += new System.EventHandler(this.correct_checking);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(39, 331);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(32, 13);
            this.label21.TabIndex = 35;
            this.label21.Text = "1 ล่าง";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(39, 305);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(35, 13);
            this.label20.TabIndex = 34;
            this.label20.Text = "5 โต๊ด";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(39, 279);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(35, 13);
            this.label19.TabIndex = 33;
            this.label19.Text = "3 โต๊ด";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(39, 254);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(32, 13);
            this.label18.TabIndex = 32;
            this.label18.Text = "3 ล่าง";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(39, 228);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(31, 13);
            this.label17.TabIndex = 31;
            this.label17.Text = "3 บน";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(39, 202);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(50, 13);
            this.label16.TabIndex = 30;
            this.label16.Text = "2 โต๊ดบน";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(39, 176);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(32, 13);
            this.label15.TabIndex = 29;
            this.label15.Text = "2 ล่าง";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(39, 151);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(31, 13);
            this.label14.TabIndex = 28;
            this.label14.Text = "2 บน";
            // 
            // payRate_1low
            // 
            this.payRate_1low.Location = new System.Drawing.Point(97, 328);
            this.payRate_1low.Name = "payRate_1low";
            this.payRate_1low.Size = new System.Drawing.Size(55, 20);
            this.payRate_1low.TabIndex = 27;
            this.payRate_1low.Text = "0";
            this.payRate_1low.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.payRate_1low.Click += new System.EventHandler(this.select_all_click);
            this.payRate_1low.TextChanged += new System.EventHandler(this.correct_checking);
            // 
            // payRate_5tod
            // 
            this.payRate_5tod.Location = new System.Drawing.Point(97, 302);
            this.payRate_5tod.Name = "payRate_5tod";
            this.payRate_5tod.Size = new System.Drawing.Size(55, 20);
            this.payRate_5tod.TabIndex = 26;
            this.payRate_5tod.Text = "0";
            this.payRate_5tod.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.payRate_5tod.Click += new System.EventHandler(this.select_all_click);
            this.payRate_5tod.TextChanged += new System.EventHandler(this.correct_checking);
            // 
            // payRate_3tod
            // 
            this.payRate_3tod.Location = new System.Drawing.Point(97, 276);
            this.payRate_3tod.Name = "payRate_3tod";
            this.payRate_3tod.Size = new System.Drawing.Size(55, 20);
            this.payRate_3tod.TabIndex = 25;
            this.payRate_3tod.Text = "0";
            this.payRate_3tod.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.payRate_3tod.Click += new System.EventHandler(this.select_all_click);
            this.payRate_3tod.TextChanged += new System.EventHandler(this.correct_checking);
            // 
            // payRate_3low
            // 
            this.payRate_3low.Location = new System.Drawing.Point(97, 251);
            this.payRate_3low.Name = "payRate_3low";
            this.payRate_3low.Size = new System.Drawing.Size(55, 20);
            this.payRate_3low.TabIndex = 24;
            this.payRate_3low.Text = "0";
            this.payRate_3low.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.payRate_3low.Click += new System.EventHandler(this.select_all_click);
            this.payRate_3low.TextChanged += new System.EventHandler(this.correct_checking);
            // 
            // payRate_3up
            // 
            this.payRate_3up.Location = new System.Drawing.Point(97, 225);
            this.payRate_3up.Name = "payRate_3up";
            this.payRate_3up.Size = new System.Drawing.Size(55, 20);
            this.payRate_3up.TabIndex = 23;
            this.payRate_3up.Text = "0";
            this.payRate_3up.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.payRate_3up.Click += new System.EventHandler(this.select_all_click);
            this.payRate_3up.TextChanged += new System.EventHandler(this.correct_checking);
            // 
            // payRate_2uptod
            // 
            this.payRate_2uptod.Location = new System.Drawing.Point(97, 199);
            this.payRate_2uptod.Name = "payRate_2uptod";
            this.payRate_2uptod.Size = new System.Drawing.Size(55, 20);
            this.payRate_2uptod.TabIndex = 22;
            this.payRate_2uptod.Text = "0";
            this.payRate_2uptod.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.payRate_2uptod.Click += new System.EventHandler(this.select_all_click);
            this.payRate_2uptod.TextChanged += new System.EventHandler(this.correct_checking);
            // 
            // payRate_2low
            // 
            this.payRate_2low.Location = new System.Drawing.Point(97, 173);
            this.payRate_2low.Name = "payRate_2low";
            this.payRate_2low.Size = new System.Drawing.Size(55, 20);
            this.payRate_2low.TabIndex = 21;
            this.payRate_2low.Text = "0";
            this.payRate_2low.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.payRate_2low.Click += new System.EventHandler(this.select_all_click);
            this.payRate_2low.TextChanged += new System.EventHandler(this.correct_checking);
            // 
            // payRate_2up
            // 
            this.payRate_2up.Location = new System.Drawing.Point(97, 148);
            this.payRate_2up.Name = "payRate_2up";
            this.payRate_2up.Size = new System.Drawing.Size(55, 20);
            this.payRate_2up.TabIndex = 20;
            this.payRate_2up.Text = "0";
            this.payRate_2up.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.payRate_2up.Click += new System.EventHandler(this.select_all_click);
            this.payRate_2up.TextChanged += new System.EventHandler(this.correct_checking);
            // 
            // payRate_1back
            // 
            this.payRate_1back.Location = new System.Drawing.Point(97, 122);
            this.payRate_1back.Name = "payRate_1back";
            this.payRate_1back.Size = new System.Drawing.Size(55, 20);
            this.payRate_1back.TabIndex = 18;
            this.payRate_1back.Text = "0";
            this.payRate_1back.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.payRate_1back.Click += new System.EventHandler(this.select_all_click);
            this.payRate_1back.TextChanged += new System.EventHandler(this.correct_checking);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(39, 125);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(34, 13);
            this.label13.TabIndex = 19;
            this.label13.Text = "1 หลัง";
            // 
            // payRate_1center
            // 
            this.payRate_1center.Location = new System.Drawing.Point(97, 96);
            this.payRate_1center.Name = "payRate_1center";
            this.payRate_1center.Size = new System.Drawing.Size(55, 20);
            this.payRate_1center.TabIndex = 16;
            this.payRate_1center.Text = "0";
            this.payRate_1center.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.payRate_1center.Click += new System.EventHandler(this.select_all_click);
            this.payRate_1center.TextChanged += new System.EventHandler(this.correct_checking);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(39, 99);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(39, 13);
            this.label12.TabIndex = 17;
            this.label12.Text = "1 กลาง";
            // 
            // payRate_1front
            // 
            this.payRate_1front.Location = new System.Drawing.Point(97, 70);
            this.payRate_1front.Name = "payRate_1front";
            this.payRate_1front.Size = new System.Drawing.Size(55, 20);
            this.payRate_1front.TabIndex = 14;
            this.payRate_1front.Text = "0";
            this.payRate_1front.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.payRate_1front.Click += new System.EventHandler(this.select_all_click);
            this.payRate_1front.TextChanged += new System.EventHandler(this.correct_checking);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(39, 73);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(36, 13);
            this.label11.TabIndex = 15;
            this.label11.Text = "1 หน้า";
            // 
            // payRate_1up
            // 
            this.payRate_1up.Location = new System.Drawing.Point(97, 45);
            this.payRate_1up.Name = "payRate_1up";
            this.payRate_1up.Size = new System.Drawing.Size(55, 20);
            this.payRate_1up.TabIndex = 4;
            this.payRate_1up.Text = "0";
            this.payRate_1up.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.payRate_1up.Click += new System.EventHandler(this.select_all_click);
            this.payRate_1up.TextChanged += new System.EventHandler(this.correct_checking);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(39, 48);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(31, 13);
            this.label10.TabIndex = 13;
            this.label10.Text = "1 บน";
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(12, 398);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(97, 43);
            this.Save.TabIndex = 3;
            this.Save.Text = "บันทึก";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // Add
            // 
            this.Add.Location = new System.Drawing.Point(115, 398);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(97, 43);
            this.Add.TabIndex = 4;
            this.Add.Text = "เพิ่ม";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // Delete
            // 
            this.Delete.Enabled = false;
            this.Delete.Location = new System.Drawing.Point(220, 398);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(97, 43);
            this.Delete.TabIndex = 5;
            this.Delete.Text = "ลบ";
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // Change
            // 
            this.Change.Location = new System.Drawing.Point(323, 398);
            this.Change.Name = "Change";
            this.Change.Size = new System.Drawing.Size(97, 43);
            this.Change.TabIndex = 6;
            this.Change.Text = "เปลี่ยนลูกค้า";
            this.Change.UseVisualStyleBackColor = true;
            this.Change.Click += new System.EventHandler(this.Change_Click);
            // 
            // toMain
            // 
            this.toMain.Location = new System.Drawing.Point(426, 398);
            this.toMain.Name = "toMain";
            this.toMain.Size = new System.Drawing.Size(97, 43);
            this.toMain.TabIndex = 7;
            this.toMain.Text = "กลับสู่หน้าหลัก";
            this.toMain.UseVisualStyleBackColor = true;
            this.toMain.Click += new System.EventHandler(this.toMain_Click);
            // 
            // initial_value
            // 
            this.initial_value.BackColor = System.Drawing.SystemColors.Control;
            this.initial_value.Location = new System.Drawing.Point(12, 362);
            this.initial_value.Name = "initial_value";
            this.initial_value.Size = new System.Drawing.Size(234, 30);
            this.initial_value.TabIndex = 50;
            this.initial_value.Text = "ค่าเริ่มต้น";
            this.initial_value.UseVisualStyleBackColor = false;
            this.initial_value.Click += new System.EventHandler(this.initial_value_Click);
            // 
            // CustomerInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 465);
            this.Controls.Add(this.initial_value);
            this.Controls.Add(this.toMain);
            this.Controls.Add(this.Change);
            this.Controls.Add(this.Delete);
            this.Controls.Add(this.Add);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "CustomerInformation";
            this.Text = "บัญชีลูกค้า";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CustomerInformation_FormClosed);
            this.Load += new System.EventHandler(this.CustomerInformation_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox customerName;
        private System.Windows.Forms.TextBox customerID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox limit_1low;
        private System.Windows.Forms.TextBox limit_1up;
        private System.Windows.Forms.TextBox limit_2low;
        private System.Windows.Forms.TextBox limit_2up;
        private System.Windows.Forms.TextBox limit_3low;
        private System.Windows.Forms.TextBox limit_3up;
        private System.Windows.Forms.TextBox limit_3uptod;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox discount_1low;
        private System.Windows.Forms.TextBox discount_5tod;
        private System.Windows.Forms.TextBox discount_3tod;
        private System.Windows.Forms.TextBox discount_3low;
        private System.Windows.Forms.TextBox discount_3up;
        private System.Windows.Forms.TextBox discount_2uptod;
        private System.Windows.Forms.TextBox discount_2low;
        private System.Windows.Forms.TextBox discount_2up;
        private System.Windows.Forms.TextBox discount_1back;
        private System.Windows.Forms.TextBox discount_1center;
        private System.Windows.Forms.TextBox discount_1front;
        private System.Windows.Forms.TextBox discount_1up;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox payRate_1low;
        private System.Windows.Forms.TextBox payRate_5tod;
        private System.Windows.Forms.TextBox payRate_3tod;
        private System.Windows.Forms.TextBox payRate_3low;
        private System.Windows.Forms.TextBox payRate_3up;
        private System.Windows.Forms.TextBox payRate_2uptod;
        private System.Windows.Forms.TextBox payRate_2low;
        private System.Windows.Forms.TextBox payRate_2up;
        private System.Windows.Forms.TextBox payRate_1back;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox payRate_1center;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox payRate_1front;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox payRate_1up;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.Button Change;
        private System.Windows.Forms.Button toMain;
        private System.Windows.Forms.Button initial_value;
    }
}