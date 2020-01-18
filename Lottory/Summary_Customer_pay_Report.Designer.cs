namespace Lottory
{
    partial class Summary_Customer_pay_Report
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
            this.MyLottoDBDataSet = new Lottory.MyLottoDBDataSet();
            this.BSCustomerTableInfo = new System.Windows.Forms.BindingSource(this.components);
            this.Customer_Report_DatasetTableAdapter = new Lottory.MyLottoDBDataSetTableAdapters.Customer_Report_DatasetTableAdapter();
            this.BSCustomerSummary = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.MyLottoDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BSCustomerTableInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BSCustomerSummary)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "CustomerSummary";
            reportDataSource1.Value = this.BSCustomerSummary;
            reportDataSource2.Name = "CustomerTable";
            reportDataSource2.Value = this.BSCustomerTableInfo;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Lottory.Summary_Customer_pay_Report.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // MyLottoDBDataSet
            // 
            this.MyLottoDBDataSet.DataSetName = "MyLottoDBDataSet";
            this.MyLottoDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // BSCustomerTableInfo
            // 
            this.BSCustomerTableInfo.DataMember = "Customer_Report_Dataset";
            this.BSCustomerTableInfo.DataSource = this.MyLottoDBDataSet;
            // 
            // Customer_Report_DatasetTableAdapter
            // 
            this.Customer_Report_DatasetTableAdapter.ClearBeforeFill = true;
            // 
            // 
            // BSCustomerSummary
            // 
            this.BSCustomerSummary.DataSource = typeof(Lottory.Summary_CustomerInfo);
            // 
            // Summary_Customer_pay_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Summary_Customer_pay_Report";
            this.Text = "Summary_Customer_pay_Report";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Summary_Customer_pay_Report_FormClosed);
            this.Load += new System.EventHandler(this.Summary_Customer_pay_Report_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MyLottoDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BSCustomerTableInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BSCustomerSummary)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource BSCustomerSummary;
        private System.Windows.Forms.BindingSource BSCustomerTableInfo;
        private MyLottoDBDataSet MyLottoDBDataSet;
        private MyLottoDBDataSetTableAdapters.Customer_Report_DatasetTableAdapter Customer_Report_DatasetTableAdapter;
    }
}