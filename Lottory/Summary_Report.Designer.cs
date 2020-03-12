namespace Lottory
{
    partial class Summary_Report
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.page_Report = new Lottory.page_Report();
            this.summaryReportTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.page_Report)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.summaryReportTableBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "usersummaryInfo";
            reportDataSource1.Value = this.summaryReportTableBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Lottory.Summary_Report.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(586, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // page_Report
            // 
            this.page_Report.DataSetName = "page_Report";
            this.page_Report.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // summaryReportTableBindingSource
            // 
            this.summaryReportTableBindingSource.DataMember = "summaryReportTable";
            this.summaryReportTableBindingSource.DataSource = this.page_Report;
            // 
            // Summary_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Summary_Report";
            this.Text = "Summary_Report";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Summary_Report_FormClosed);
            this.Load += new System.EventHandler(this.Summary_Report_Load);
            ((System.ComponentModel.ISupportInitialize)(this.page_Report)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.summaryReportTableBindingSource)).EndInit();
            this.ResumeLayout(false);

        }


        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource summaryReportTableBindingSource;
        private page_Report page_Report;
    }
}