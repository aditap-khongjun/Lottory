namespace Lottory
{
    partial class Report_PageBuying
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
            this.pageBuying = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.page_Report = new Lottory.page_Report();
            this.PageBuyingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Search = new System.Windows.Forms.Button();
            this.NumberSearchBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pageBuying.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.page_Report)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PageBuyingBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumberSearchBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "SearchInfo";
            reportDataSource1.Value = this.NumberSearchBindingSource;
            reportDataSource2.Name = "DataTable";
            reportDataSource2.Value = this.PageBuyingBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Lottory.Report_pageBuying.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(1, 141);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(798, 871);
            this.reportViewer1.TabIndex = 0;
            // 
            // pageBuying
            // 
            this.pageBuying.Controls.Add(this.Search);
            this.pageBuying.Controls.Add(this.cbType);
            this.pageBuying.Controls.Add(this.label2);
            this.pageBuying.Controls.Add(this.tbNumber);
            this.pageBuying.Controls.Add(this.label1);
            this.pageBuying.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.pageBuying.Location = new System.Drawing.Point(12, 12);
            this.pageBuying.Name = "pageBuying";
            this.pageBuying.Size = new System.Drawing.Size(776, 123);
            this.pageBuying.TabIndex = 1;
            this.pageBuying.TabStop = false;
            this.pageBuying.Text = "แสดงยอดซื้อตามเลข (ตามหน้า)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "เลข : ";
            // 
            // tbNumber
            // 
            this.tbNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.tbNumber.Location = new System.Drawing.Point(78, 49);
            this.tbNumber.MaxLength = 3;
            this.tbNumber.Name = "tbNumber";
            this.tbNumber.Size = new System.Drawing.Size(100, 29);
            this.tbNumber.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(242, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "ชนิด : ";
            // 
            // cbType
            // 
            this.cbType.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cbType.FormattingEnabled = true;
            this.cbType.Items.AddRange(new object[] {
            "บน",
            "ล่าง"});
            this.cbType.Location = new System.Drawing.Point(296, 49);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(121, 32);
            this.cbType.TabIndex = 3;
            // 
            // page_Report
            // 
            this.page_Report.DataSetName = "page_Report";
            this.page_Report.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // PageBuyingBindingSource
            // 
            this.PageBuyingBindingSource.DataMember = "PageBuying";
            this.PageBuyingBindingSource.DataSource = this.page_Report;
            // 
            // Search
            // 
            this.Search.Location = new System.Drawing.Point(468, 49);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(110, 32);
            this.Search.TabIndex = 4;
            this.Search.Text = "แสดง";
            this.Search.UseVisualStyleBackColor = true;
            this.Search.Click += new System.EventHandler(this.Search_Click);
            // 
            // NumberSearchBindingSource
            // 
            this.NumberSearchBindingSource.DataSource = typeof(Lottory.NumberSearch);
            // 
            // Report_PageBuying
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 1024);
            this.Controls.Add(this.pageBuying);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Report_PageBuying";
            this.Text = "Report_PageBuying";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Report_PageBuying_FormClosed);
            this.Load += new System.EventHandler(this.Report_PageBuying_Load);
            this.pageBuying.ResumeLayout(false);
            this.pageBuying.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.page_Report)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PageBuyingBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumberSearchBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.GroupBox pageBuying;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource NumberSearchBindingSource;
        private System.Windows.Forms.BindingSource PageBuyingBindingSource;
        private page_Report page_Report;
        private System.Windows.Forms.Button Search;
    }
}