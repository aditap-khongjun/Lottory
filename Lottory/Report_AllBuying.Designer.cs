namespace Lottory
{
    partial class Report_AllBuying
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.page_Report = new Lottory.page_Report();
            this.AllBuyingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Search = new System.Windows.Forms.Button();
            this.NumberSearchBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.page_Report)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AllBuyingBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumberSearchBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "CustomerBuyingList";
            reportDataSource1.Value = this.AllBuyingBindingSource;
            reportDataSource2.Name = "NumberInfo";
            reportDataSource2.Value = this.NumberSearchBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Lottory.Report_AllBuying.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(2, 128);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(796, 778);
            this.reportViewer1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Search);
            this.groupBox1.Controls.Add(this.cbType);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbNumber);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 100);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "แสดงยอดซื้อตามเลข";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "เลข";
            // 
            // tbNumber
            // 
            this.tbNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.tbNumber.Location = new System.Drawing.Point(68, 38);
            this.tbNumber.MaxLength = 3;
            this.tbNumber.Name = "tbNumber";
            this.tbNumber.Size = new System.Drawing.Size(100, 31);
            this.tbNumber.TabIndex = 1;
            this.tbNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(208, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "ชนิด";
            // 
            // cbType
            // 
            this.cbType.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cbType.FormattingEnabled = true;
            this.cbType.Items.AddRange(new object[] {
            "บน",
            "ล่าง"});
            this.cbType.Location = new System.Drawing.Point(253, 39);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(121, 32);
            this.cbType.TabIndex = 3;
            // 
            // page_Report
            // 
            this.page_Report.DataSetName = "page_Report";
            this.page_Report.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // AllBuyingBindingSource
            // 
            this.AllBuyingBindingSource.DataMember = "AllBuying";
            this.AllBuyingBindingSource.DataSource = this.page_Report;
            // 
            // Search
            // 
            this.Search.Location = new System.Drawing.Point(420, 38);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(126, 33);
            this.Search.TabIndex = 4;
            this.Search.Text = "แสดง";
            this.Search.UseVisualStyleBackColor = true;
            this.Search.Click += new System.EventHandler(this.Search_Click);
            // 
            // NumberSearchBindingSource
            // 
            this.NumberSearchBindingSource.DataSource = typeof(Lottory.NumberSearch);
            // 
            // Report_AllBuying
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 908);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Report_AllBuying";
            this.Text = "แสดงยอดซื้อตามเลข";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Report_AllBuying_FormClosed);
            this.Load += new System.EventHandler(this.Report_AllBuying_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.page_Report)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AllBuyingBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumberSearchBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource AllBuyingBindingSource;
        private page_Report page_Report;
        private System.Windows.Forms.BindingSource NumberSearchBindingSource;
        private System.Windows.Forms.Button Search;
    }
}