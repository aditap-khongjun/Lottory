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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.Report = new Lottory.Report();
            this.BuyingTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.BuyingSummaryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PayingTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PayingSummaryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.CustomerInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Report)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BuyingTableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BuyingSummaryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayingTableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayingSummaryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerInfoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "BuyingTable";
            reportDataSource1.Value = this.BuyingTableBindingSource;
            reportDataSource2.Name = "BuyingSummary";
            reportDataSource2.Value = this.BuyingSummaryBindingSource;
            reportDataSource3.Name = "PayingTable";
            reportDataSource3.Value = this.PayingTableBindingSource;
            reportDataSource4.Name = "PayingSummary";
            reportDataSource4.Value = this.PayingSummaryBindingSource;
            reportDataSource5.Name = "CustomerInfo";
            reportDataSource5.Value = this.CustomerInfoBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource4);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource5);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Lottory.Summary_Customer_Page_Report.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // Report
            // 
            this.Report.DataSetName = "Report";
            this.Report.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // BuyingTableBindingSource
            // 
            this.BuyingTableBindingSource.DataMember = "BuyingTable";
            this.BuyingTableBindingSource.DataSource = this.Report;
            // 
            // BuyingSummaryBindingSource
            // 
            this.BuyingSummaryBindingSource.DataMember = "BuyingSummary";
            this.BuyingSummaryBindingSource.DataSource = this.Report;
            // 
            // PayingTableBindingSource
            // 
            this.PayingTableBindingSource.DataMember = "PayingTable";
            this.PayingTableBindingSource.DataSource = this.Report;
            // 
            // PayingSummaryBindingSource
            // 
            this.PayingSummaryBindingSource.DataMember = "PayingSummary";
            this.PayingSummaryBindingSource.DataSource = this.Report;
            // 
            // CustomerInfoBindingSource
            // 
            this.CustomerInfoBindingSource.DataMember = "CustomerInfo";
            this.CustomerInfoBindingSource.DataSource = this.Report;
            // 
            // Summary_Customer_Page_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Summary_Customer_Page_Report";
            this.Text = "Summary_Customer_Page_Report";
            this.Load += new System.EventHandler(this.Summary_Customer_Page_Report_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Report)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BuyingTableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BuyingSummaryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayingTableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayingSummaryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerInfoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource BuyingTableBindingSource;
        private Report Report;
        private System.Windows.Forms.BindingSource BuyingSummaryBindingSource;
        private System.Windows.Forms.BindingSource PayingTableBindingSource;
        private System.Windows.Forms.BindingSource PayingSummaryBindingSource;
        private System.Windows.Forms.BindingSource CustomerInfoBindingSource;
    }
}