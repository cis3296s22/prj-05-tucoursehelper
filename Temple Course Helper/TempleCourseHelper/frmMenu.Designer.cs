namespace TempleCourseHelper
{
    partial class frmMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenu));
            this.lblCourse1 = new System.Windows.Forms.Label();
            this.Course2 = new System.Windows.Forms.Label();
            this.lblCourse3 = new System.Windows.Forms.Label();
            this.lblCourse4 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblResults = new System.Windows.Forms.Label();
            this.txtBoxCourse1 = new System.Windows.Forms.TextBox();
            this.txtBoxCourse4 = new System.Windows.Forms.TextBox();
            this.txtBoxCourse3 = new System.Windows.Forms.TextBox();
            this.txtBoxCourse2 = new System.Windows.Forms.TextBox();
            this.txtBoxEmail = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.lblEmail = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblCourse1
            // 
            this.lblCourse1.AutoSize = true;
            this.lblCourse1.Location = new System.Drawing.Point(45, 35);
            this.lblCourse1.Name = "lblCourse1";
            this.lblCourse1.Size = new System.Drawing.Size(52, 13);
            this.lblCourse1.TabIndex = 0;
            this.lblCourse1.Text = "Course 1:";
            // 
            // Course2
            // 
            this.Course2.AutoSize = true;
            this.Course2.Location = new System.Drawing.Point(45, 75);
            this.Course2.Name = "Course2";
            this.Course2.Size = new System.Drawing.Size(52, 13);
            this.Course2.TabIndex = 1;
            this.Course2.Text = "Course 2:";
            // 
            // lblCourse3
            // 
            this.lblCourse3.AutoSize = true;
            this.lblCourse3.Location = new System.Drawing.Point(45, 115);
            this.lblCourse3.Name = "lblCourse3";
            this.lblCourse3.Size = new System.Drawing.Size(52, 13);
            this.lblCourse3.TabIndex = 3;
            this.lblCourse3.Text = "Course 3:";
            // 
            // lblCourse4
            // 
            this.lblCourse4.AutoSize = true;
            this.lblCourse4.Location = new System.Drawing.Point(45, 155);
            this.lblCourse4.Name = "lblCourse4";
            this.lblCourse4.Size = new System.Drawing.Size(52, 13);
            this.lblCourse4.TabIndex = 2;
            this.lblCourse4.Text = "Course 4:";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(48, 203);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(164, 23);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblResults
            // 
            this.lblResults.AutoSize = true;
            this.lblResults.Location = new System.Drawing.Point(255, 36);
            this.lblResults.Name = "lblResults";
            this.lblResults.Size = new System.Drawing.Size(45, 13);
            this.lblResults.TabIndex = 5;
            this.lblResults.Text = "Results:";
            this.lblResults.Visible = false;
            // 
            // txtBoxCourse1
            // 
            this.txtBoxCourse1.Location = new System.Drawing.Point(110, 30);
            this.txtBoxCourse1.Name = "txtBoxCourse1";
            this.txtBoxCourse1.Size = new System.Drawing.Size(100, 20);
            this.txtBoxCourse1.TabIndex = 6;
            // 
            // txtBoxCourse4
            // 
            this.txtBoxCourse4.Location = new System.Drawing.Point(110, 150);
            this.txtBoxCourse4.Name = "txtBoxCourse4";
            this.txtBoxCourse4.Size = new System.Drawing.Size(100, 20);
            this.txtBoxCourse4.TabIndex = 7;
            // 
            // txtBoxCourse3
            // 
            this.txtBoxCourse3.Location = new System.Drawing.Point(110, 110);
            this.txtBoxCourse3.Name = "txtBoxCourse3";
            this.txtBoxCourse3.Size = new System.Drawing.Size(100, 20);
            this.txtBoxCourse3.TabIndex = 8;
            // 
            // txtBoxCourse2
            // 
            this.txtBoxCourse2.Location = new System.Drawing.Point(110, 70);
            this.txtBoxCourse2.Name = "txtBoxCourse2";
            this.txtBoxCourse2.Size = new System.Drawing.Size(100, 20);
            this.txtBoxCourse2.TabIndex = 9;
            // 
            // txtBoxEmail
            // 
            this.txtBoxEmail.Location = new System.Drawing.Point(83, 317);
            this.txtBoxEmail.Name = "txtBoxEmail";
            this.txtBoxEmail.Size = new System.Drawing.Size(100, 20);
            this.txtBoxEmail.TabIndex = 12;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(83, 352);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 11;
            this.btnSend.Text = "Send Info";
            this.btnSend.UseVisualStyleBackColor = true;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(42, 320);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(35, 13);
            this.lblEmail.TabIndex = 10;
            this.lblEmail.Text = "Email:";
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtBoxEmail);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtBoxCourse2);
            this.Controls.Add(this.txtBoxCourse3);
            this.Controls.Add(this.txtBoxCourse4);
            this.Controls.Add(this.txtBoxCourse1);
            this.Controls.Add(this.lblResults);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lblCourse3);
            this.Controls.Add(this.lblCourse4);
            this.Controls.Add(this.Course2);
            this.Controls.Add(this.lblCourse1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMenu";
            this.Text = "Temple Course Helper";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCourse1;
        private System.Windows.Forms.Label Course2;
        private System.Windows.Forms.Label lblCourse3;
        private System.Windows.Forms.Label lblCourse4;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblResults;
        private System.Windows.Forms.TextBox txtBoxCourse1;
        private System.Windows.Forms.TextBox txtBoxCourse4;
        private System.Windows.Forms.TextBox txtBoxCourse3;
        private System.Windows.Forms.TextBox txtBoxCourse2;
        private System.Windows.Forms.TextBox txtBoxEmail;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label lblEmail;
    }
}

