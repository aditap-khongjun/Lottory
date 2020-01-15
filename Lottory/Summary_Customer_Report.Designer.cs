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
            this.Lotto_DBDataSet4 = new Lottory.Lotto_DBDataSet4();
            this.BSCustomerList = new System.Windows.Forms.BindingSource(this.components);
            this.Customer_Report_DatasetTableAdapter = new Lottory.Lotto_DBDataSet4TableAdapters.Customer_Report_DatasetTableAdapter();
            this.BSSummary = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Lotto_DBDataSet4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BSCustomerList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BSSummary)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "CustomerDataset";
            reportDataSource1.Value = this.BSCustomerList;
            reportDataSource2.Name = "SumDataSet";
            reportDataSource2.Value = this.BSSummary;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Lottory.Summary_Customer_Report.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(962, 661);
            this.reportViewer1.TabIndex = 0;
            // 
            // Lotto_DBDataSet4
            // 
            this.Lotto_DBDataSet4.DataSetName = "Lotto_DBDataSet4";
            this.Lotto_DBDataSet4.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // BSCustomerList
            // 
            this.BSCustomerList.DataMember = "Customer_Report_Dataset";
            this.BSCustomerList.DataSource = this.Lotto_DBDataSet4;
            // 
            // Customer_Report_DatasetTableAdapter
            // 
            this.Customer_Report_DatasetTableAdapter.ClearBeforeFill = true;
            // 
            // BSSummary
            // 
            this.BSSummary.DataSource = typeof(Lottory.Summary_CustomerInfo);
            // 
            // Summary_Customer_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 661);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Summary_Customer_Report";
            this.Text = "Summary_Customer_Report";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Summary_Customer_Report_FormClosed);
            this.Load += new System.EventHandler(this.Summary_Customer_Report_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Lotto_DBDataSet4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BSCustomerList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BSSummary)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource BSCustomerList;
        private Lotto_DBDataSet4 Lotto_DBDataSet4;
        private System.Windows.Forms.BindingSource BSSummary;
        private Lotto_DBDataSet4TableAdapters.Customer_Report_DatasetTableAdapter Customer_Report_DatasetTableAdapter;
    }
}