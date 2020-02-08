namespace Lottory
{
    partial class Report_OverMoney
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
            this.dgvOver3up = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvOver2up = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvOver2low = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOver3up)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOver2up)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOver2low)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvOver3up
            // 
            this.dgvOver3up.AllowUserToAddRows = false;
            this.dgvOver3up.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOver3up.Location = new System.Drawing.Point(37, 51);
            this.dgvOver3up.Name = "dgvOver3up";
            this.dgvOver3up.RowHeadersVisible = false;
            this.dgvOver3up.Size = new System.Drawing.Size(240, 753);
            this.dgvOver3up.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(127, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "3 บน";
            // 
            // dgvOver2up
            // 
            this.dgvOver2up.AllowUserToAddRows = false;
            this.dgvOver2up.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOver2up.Location = new System.Drawing.Point(333, 51);
            this.dgvOver2up.Name = "dgvOver2up";
            this.dgvOver2up.RowHeadersVisible = false;
            this.dgvOver2up.Size = new System.Drawing.Size(240, 753);
            this.dgvOver2up.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(432, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "2 บน";
            // 
            // dgvOver2low
            // 
            this.dgvOver2low.AllowUserToAddRows = false;
            this.dgvOver2low.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOver2low.Location = new System.Drawing.Point(626, 51);
            this.dgvOver2low.Name = "dgvOver2low";
            this.dgvOver2low.RowHeadersVisible = false;
            this.dgvOver2low.Size = new System.Drawing.Size(240, 753);
            this.dgvOver2low.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(716, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 24);
            this.label3.TabIndex = 5;
            this.label3.Text = "2 ล่าง";
            // 
            // Report_OverMoney
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1467, 831);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvOver2low);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvOver2up);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvOver3up);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "Report_OverMoney";
            this.Text = "รายงานตัวเลขที่ตีออก";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Report_OverMoney_FormClosed);
            this.Load += new System.EventHandler(this.Report_OverMoney_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOver3up)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOver2up)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOver2low)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvOver3up;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvOver2up;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvOver2low;
        private System.Windows.Forms.Label label3;
    }
}