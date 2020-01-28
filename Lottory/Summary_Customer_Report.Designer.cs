namespace Lottory
{
    partial class Summary_Customer_Report
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
            this.BSSummary = new System.Windows.Forms.BindingSource(this.components);
            this.MyLottoDBDataSet = new Lottory.MyLottoDBDataSet();
            this.BSCustomerBuying = new System.Windows.Forms.BindingSource(this.components);
            this.Customer_Report_DatasetTableAdapter = new Lottory.MyLottoDBDataSetTableAdapters.Customer_Report_DatasetTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.BSSummary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MyLottoDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BSCustomerBuying)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "SumDataSet";
            reportDataSource1.Value = this.BSSummary;
            reportDataSource2.Name = "CustomerTable";
            reportDataSource2.Value = this.BSCustomerBuying;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Lottory.Summary_Customer_Report.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(641, 430);
            this.reportViewer1.TabIndex = 0;
            // 
            // BSSummary
            // 
            this.BSSummary.DataSource = typeof(Lottory.Summary_CustomerInfo);
            // 
            // MyLottoDBDataSet
            // 
            this.MyLottoDBDataSet.DataSetName = "MyLottoDBDataSet";
            this.MyLottoDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // BSCustomerBuying
            // 
            this.BSCustomerBuying.DataMember = "Customer_Report_Dataset";
            this.BSCustomerBuying.DataSource = this.MyLottoDBDataSet;
            // 
            // Customer_Report_DatasetTableAdapter
            // 
            this.Customer_Report_DatasetTableAdapter.ClearBeforeFill = true;
            // 
            // Summary_Customer_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 430);
            this.Controls.Add(this.reportViewer1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Summary_Customer_Report";
            this.Text = "Summary_Customer_Report";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Summary_Customer_Report_FormClosed);
            this.Load += new System.EventHandler(this.Summary_Customer_Report_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BSSummary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MyLottoDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BSCustomerBuying)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource BSSummary;
        private System.Windows.Forms.BindingSource BSCustomerBuying;
        private MyLottoDBDataSet MyLottoDBDataSet;
        private MyLottoDBDataSetTableAdapters.Customer_Report_DatasetTableAdapter Customer_Report_DatasetTableAdapter;
    }
}