namespace Lottory
{
    partial class Summary_Customer_report_pay
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
            this.reportViewCustomerPay = new Microsoft.Reporting.WinForms.ReportViewer();
            this.MyLottoDBDataSet = new Lottory.MyLottoDBDataSet();
            this.BSCustermerPayInfo = new System.Windows.Forms.BindingSource(this.components);
            this.Customer_Report_DatasetTableAdapter = new Lottory.MyLottoDBDataSetTableAdapters.Customer_Report_DatasetTableAdapter();
            this.BSSummary = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.MyLottoDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BSCustermerPayInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BSSummary)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewCustomerPay
            // 
            this.reportViewCustomerPay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewCustomerPay.LocalReport.ReportEmbeddedResource = "Lottory.Summary_Customer_Report.rdlc";
            this.reportViewCustomerPay.Location = new System.Drawing.Point(0, 0);
            this.reportViewCustomerPay.Name = "reportViewCustomerPay";
            this.reportViewCustomerPay.ServerReport.BearerToken = null;
            this.reportViewCustomerPay.Size = new System.Drawing.Size(800, 450);
            this.reportViewCustomerPay.TabIndex = 0;
            // 
            // MyLottoDBDataSet
            // 
            this.MyLottoDBDataSet.DataSetName = "MyLottoDBDataSet";
            this.MyLottoDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // BSCustermerPayInfo
            // 
            this.BSCustermerPayInfo.DataMember = "Customer_Report_Dataset";
            this.BSCustermerPayInfo.DataSource = this.MyLottoDBDataSet;
            // 
            // Customer_Report_DatasetTableAdapter
            // 
            this.Customer_Report_DatasetTableAdapter.ClearBeforeFill = true;
            // 
            // BSSummary
            // 
            this.BSSummary.DataSource = typeof(Lottory.Summary_CustomerInfo);
            // 
            // Summary_Customer_report_pay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewCustomerPay);
            this.Name = "Summary_Customer_report_pay";
            this.Text = "Summary_Customer_report_pay";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Summary_Customer_report_pay_FormClosed);
            this.Load += new System.EventHandler(this.Summary_Customer_report_pay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MyLottoDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BSCustermerPayInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BSSummary)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewCustomerPay;
        private System.Windows.Forms.BindingSource BSSummary;
        private System.Windows.Forms.BindingSource BSCustermerPayInfo;
        private MyLottoDBDataSet MyLottoDBDataSet;
        private MyLottoDBDataSetTableAdapters.Customer_Report_DatasetTableAdapter Customer_Report_DatasetTableAdapter;
    }
}