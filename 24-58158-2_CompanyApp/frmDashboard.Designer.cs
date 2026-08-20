namespace EmployeeDetails
{
    partial class frmDashboard
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblUserId = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.btnManageEmployees = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Label();
            this.accentPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            //
            // lblTitle
            //
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(116, 86, 174);
            this.lblTitle.Location = new System.Drawing.Point(41, 42);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(279, 41);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Company Dashboard";
            //
            // lblWelcome
            //
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Nirmala UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.ForeColor = System.Drawing.Color.FromArgb(65, 65, 75);
            this.lblWelcome.Location = new System.Drawing.Point(44, 119);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(106, 25);
            this.lblWelcome.TabIndex = 1;
            this.lblWelcome.Text = "Welcome";
            //
            // lblUserId
            //
            this.lblUserId.AutoSize = true;
            this.lblUserId.Font = new System.Drawing.Font("Nirmala UI", 9.75F);
            this.lblUserId.ForeColor = System.Drawing.Color.FromArgb(120, 120, 130);
            this.lblUserId.Location = new System.Drawing.Point(45, 156);
            this.lblUserId.Name = "lblUserId";
            this.lblUserId.Size = new System.Drawing.Size(106, 17);
            this.lblUserId.TabIndex = 2;
            this.lblUserId.Text = "Logged-in user ID";
            //
            // lblDescription
            //
            this.lblDescription.Font = new System.Drawing.Font("Nirmala UI", 9.75F);
            this.lblDescription.ForeColor = System.Drawing.Color.FromArgb(120, 120, 130);
            this.lblDescription.Location = new System.Drawing.Point(45, 194);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(395, 47);
            this.lblDescription.TabIndex = 3;
            this.lblDescription.Text = "Manage employee records securely. New records are linked to your account automatically.";
            //
            // btnManageEmployees
            //
            this.btnManageEmployees.BackColor = System.Drawing.Color.FromArgb(117, 86, 174);
            this.btnManageEmployees.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnManageEmployees.FlatAppearance.BorderSize = 0;
            this.btnManageEmployees.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageEmployees.Font = new System.Drawing.Font("Nirmala UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnManageEmployees.ForeColor = System.Drawing.Color.White;
            this.btnManageEmployees.Location = new System.Drawing.Point(48, 258);
            this.btnManageEmployees.Name = "btnManageEmployees";
            this.btnManageEmployees.Size = new System.Drawing.Size(240, 40);
            this.btnManageEmployees.TabIndex = 4;
            this.btnManageEmployees.Text = "MANAGE EMPLOYEES";
            this.btnManageEmployees.UseVisualStyleBackColor = false;
            this.btnManageEmployees.Click += new System.EventHandler(this.btnManageEmployees_Click);
            //
            // btnLogout
            //
            this.btnLogout.BackColor = System.Drawing.Color.White;
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Nirmala UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.FromArgb(117, 86, 174);
            this.btnLogout.Location = new System.Drawing.Point(304, 258);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(130, 40);
            this.btnLogout.TabIndex = 5;
            this.btnLogout.Text = "LOG OUT";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            //
            // btnClose
            //
            this.btnClose.AutoSize = true;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Font = new System.Drawing.Font("Nirmala UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Location = new System.Drawing.Point(471, 8);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(25, 25);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "X";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            //
            // accentPanel
            //
            this.accentPanel.BackColor = System.Drawing.Color.FromArgb(117, 86, 174);
            this.accentPanel.Location = new System.Drawing.Point(0, 0);
            this.accentPanel.Name = "accentPanel";
            this.accentPanel.Size = new System.Drawing.Size(8, 340);
            this.accentPanel.TabIndex = 7;
            //
            // frmDashboard
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(510, 340);
            this.Controls.Add(this.accentPanel);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnManageEmployees);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblUserId);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Company Dashboard";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDashboard_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblUserId;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Button btnManageEmployees;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label btnClose;
        private System.Windows.Forms.Panel accentPanel;
    }
}
