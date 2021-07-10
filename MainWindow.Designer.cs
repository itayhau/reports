
namespace CORD
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.loadJsonLabel = new System.Windows.Forms.Label();
            this.loadJsonButton = new System.Windows.Forms.Button();
            this.report1btn = new System.Windows.Forms.Button();
            this.report2btn = new System.Windows.Forms.Button();
            this.report3btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // loadJSONLabel
            // 
            this.loadJsonLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.loadJsonLabel.Location = new System.Drawing.Point(12, 63);
            this.loadJsonLabel.Name = "loadJSONLabel";
            this.loadJsonLabel.Size = new System.Drawing.Size(511, 49);
            this.loadJsonLabel.TabIndex = 0;
            this.loadJsonLabel.Text = "Please load a JSON file:";
            this.loadJsonLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // loadJSONButton
            // 
            this.loadJsonButton.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.loadJsonButton.Location = new System.Drawing.Point(175, 126);
            this.loadJsonButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.loadJsonButton.Name = "loadJSONButton";
            this.loadJsonButton.Size = new System.Drawing.Size(154, 55);
            this.loadJsonButton.TabIndex = 1;
            this.loadJsonButton.Text = "Open File";
            this.loadJsonButton.UseVisualStyleBackColor = true;
            this.loadJsonButton.Click += new System.EventHandler(this.LoadJsonBtn_Click);
            // 
            // report1Button
            // 
            this.report1btn.Enabled = false;
            this.report1btn.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.report1btn.Location = new System.Drawing.Point(143, 288);
            this.report1btn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.report1btn.Name = "report1Button";
            this.report1btn.Size = new System.Drawing.Size(224, 49);
            this.report1btn.TabIndex = 0;
            this.report1btn.Text = "Report (Step 1)";
            this.report1btn.UseVisualStyleBackColor = true;
            this.report1btn.Click += new System.EventHandler(this.Report1btn_Click);
            // 
            // report2Button
            // 
            this.report2btn.Enabled = false;
            this.report2btn.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.report2btn.Location = new System.Drawing.Point(143, 360);
            this.report2btn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.report2btn.Name = "report2Button";
            this.report2btn.Size = new System.Drawing.Size(224, 49);
            this.report2btn.TabIndex = 2;
            this.report2btn.Text = "Report (Step 2)";
            this.report2btn.UseVisualStyleBackColor = true;
            this.report2btn.Click += new System.EventHandler(this.Report2btn_Click);
            // 
            // report3Button
            // 
            this.report3btn.Enabled = false;
            this.report3btn.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.report3btn.Location = new System.Drawing.Point(143, 438);
            this.report3btn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.report3btn.Name = "report3Button";
            this.report3btn.Size = new System.Drawing.Size(224, 49);
            this.report3btn.TabIndex = 3;
            this.report3btn.Text = "Report (Step 3)";
            this.report3btn.UseVisualStyleBackColor = true;
            this.report3btn.Click += new System.EventHandler(this.Report3btn_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 563);
            this.Controls.Add(this.report3btn);
            this.Controls.Add(this.report2btn);
            this.Controls.Add(this.report1btn);
            this.Controls.Add(this.loadJsonButton);
            this.Controls.Add(this.loadJsonLabel);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainWindow";
            this.Text = "CORD Assignment";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label loadJsonLabel;
        private System.Windows.Forms.Button loadJsonButton;
        private System.Windows.Forms.Button report1btn;
        private System.Windows.Forms.Button report2btn;
        private System.Windows.Forms.Button report3btn;
    }
}

