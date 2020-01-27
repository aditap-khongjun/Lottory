namespace Lottory
{
    partial class Customer_Page_Report
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.Summary_CustomerInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.SummaryInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Summary_CustomerInfoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SummaryInfoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Lottory.Customer_page_report.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(65, 52);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(396, 246);
            this.reportViewer1.TabIndex = 0;
            // 
            // Summary_CustomerInfoBindingSource
            // 
            this.Summary_CustomerInfoBindingSource.DataSource = typeof(Lottory.Summary_CustomerInfo);
            // 
            // SummaryInfoBindingSource
            // 
            this.SummaryInfoBindingSource.DataSource = typeof(Lottory.SummaryInfo);
            // 
            // Customer_Page_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Customer_Page_Report";
            this.Text = "Customer_Page_Report";
            this.Load += new System.EventHandler(this.Customer_Page_Report_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Summary_CustomerInfoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SummaryInfoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource Summary_CustomerInfoBindingSource;
        private System.Windows.Forms.BindingSource SummaryInfoBindingSource;
    }
}