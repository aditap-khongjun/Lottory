namespace Lottory
{
    partial class Summary_Customer_Page_Report
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource5 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.cusotmerInfo_page_reportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.BuyingTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.page_Report = new Lottory.page_Report();
            this.BuyingSummaryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PayingTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PayingSummaryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.cusotmerInfo_page_reportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BuyingTableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.page_Report)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BuyingSummaryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayingTableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayingSummaryBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // cusotmerInfo_page_reportBindingSource
            // 
            this.cusotmerInfo_page_reportBindingSource.DataSource = typeof(Lottory.cusotmerInfo_page_report);
            // 
            // BuyingTableBindingSource
            // 
            this.BuyingTableBindingSource.DataMember = "BuyingTable";
            this.BuyingTableBindingSource.DataSource = this.page_Report;
            // 
            // page_Report
            // 
            this.page_Report.DataSetName = "page_Report";
            this.page_Report.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // BuyingSummaryBindingSource
            // 
            this.BuyingSummaryBindingSource.DataMember = "BuyingSummary";
            this.BuyingSummaryBindingSource.DataSource = this.page_Report;
            // 
            // PayingTableBindingSource
            // 
            this.PayingTableBindingSource.DataMember = "PayingTable";
            this.PayingTableBindingSource.DataSource = this.page_Report;
            // 
            // PayingSummaryBindingSource
            // 
            this.PayingSummaryBindingSource.DataMember = "PayingSummary";
            this.PayingSummaryBindingSource.DataSource = this.page_Report;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "CustomerInfo";
            reportDataSource1.Value = this.cusotmerInfo_page_reportBindingSource;
            reportDataSource2.Name = "buyinginfo";
            reportDataSource2.Value = this.BuyingTableBindingSource;
            reportDataSource3.Name = "buyingsum";
            reportDataSource3.Value = this.BuyingSummaryBindingSource;
            reportDataSource4.Name = "payinginfo";
            reportDataSource4.Value = this.PayingTableBindingSource;
            reportDataSource5.Name = "payingsum";
            reportDataSource5.Value = this.PayingSummaryBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource4);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource5);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Lottory.report_page_customer.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // Summary_Customer_Page_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Summary_Customer_Page_Report";
            this.Text = "Summary_Customer_Page_Report";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Summary_Customer_Page_Report_FormClosed);
            this.Load += new System.EventHandler(this.Summary_Customer_Page_Report_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cusotmerInfo_page_reportBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BuyingTableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.page_Report)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BuyingSummaryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayingTableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayingSummaryBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource cusotmerInfo_page_reportBindingSource;
        private System.Windows.Forms.BindingSource BuyingTableBindingSource;
        private page_Report page_Report;
        private System.Windows.Forms.BindingSource BuyingSummaryBindingSource;
        private System.Windows.Forms.BindingSource PayingTableBindingSource;
        private System.Windows.Forms.BindingSource PayingSummaryBindingSource;
    }
}