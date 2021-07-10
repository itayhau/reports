
namespace CORD
{
    partial class ReportStep3
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
            this.reportsGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.reportsGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // reportsGridView
            // 
            this.reportsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.reportsGridView.Location = new System.Drawing.Point(12, 12);
            this.reportsGridView.Name = "reportsGridView";
            this.reportsGridView.RowTemplate.Height = 25;
            this.reportsGridView.Size = new System.Drawing.Size(903, 573);
            this.reportsGridView.TabIndex = 0;
            // 
            // ReportStep3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 608);
            this.Controls.Add(this.reportsGridView);
            this.Name = "ReportStep3";
            this.Text = "Report 3";
            ((System.ComponentModel.ISupportInitialize)(this.reportsGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView reportsGridView;
    }
}