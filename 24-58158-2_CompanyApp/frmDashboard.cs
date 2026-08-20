using System;
using System.Windows.Forms;

namespace EmployeeDetails
{
    public partial class frmDashboard : Form
    {
        private bool logoutInProgress;

        public frmDashboard()
        {
            InitializeComponent();
            lblWelcome.Text = "Welcome, " + Session.Username;
            lblUserId.Text = "Logged-in user ID: " + Session.UserID;
        }

        private void btnManageEmployees_Click(object sender, EventArgs e)
        {
            if (Session.UserID <= 0)
            {
                MessageBox.Show(
                    "Log in before opening employee management.",
                    "Authentication Required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            using (frmEmployee employeeForm = new frmEmployee())
            {
                employeeForm.ShowDialog();
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (PrepareLogout())
                Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (PrepareLogout())
                Close();
        }

        private void frmDashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (logoutInProgress || e.CloseReason == CloseReason.ApplicationExitCall)
                return;

            if (!PrepareLogout())
                e.Cancel = true;
        }

        private bool PrepareLogout()
        {
            if (logoutInProgress)
                return true;

            DialogResult choice = MessageBox.Show(
                "Are you sure you want to log out?",
                "Confirm Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (choice != DialogResult.Yes)
                return false;

            Session.Clear();
            logoutInProgress = true;

            frmLogin loginForm = new frmLogin();
            loginForm.Show();
            return true;
        }
    }
}
