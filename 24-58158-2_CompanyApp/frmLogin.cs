using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace EmployeeDetails
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            FormClosed += frmLogin_FormClosed;
        }

        private readonly User user = new User();

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();

            if (username == "" || txtPassword.Text == "")
            {
                MessageBox.Show(
                    "Enter both your username and password.",
                    "Login Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                txtUsername.Focus();
                return;
            }

            try
            {
                int userId = user.ValidateLogin(username, txtPassword.Text);

                if (userId > 0)
                {
                    Session.UserID = userId;
                    Session.Username = username;

                    frmDashboard dashboard = new frmDashboard();
                    dashboard.Show();
                    Hide();
                    return;
                }

                MessageBox.Show(
                    "Incorrect username or password. Please try again.",
                    "Login Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                txtPassword.Clear();
                txtUsername.Focus();
            }
            catch (SqlException exception)
            {
                MessageBox.Show(
                    "The application could not reach dbCompanyApp. " +
                    "Run Schema.sql and check App.config.\n\n" + exception.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void checkbxShowPas_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbxShowPas.Checked)
            {
                txtPassword.PasswordChar = '\0';             
            }
            else
            {
                txtPassword.PasswordChar = '•';
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtUsername.Focus();
        }

        private void clickRegister_Click(object sender, EventArgs e)
        {
            Hide();

            using (frmRegister registerForm = new frmRegister())
            {
                registerForm.ShowDialog();
            }

            if (!IsDisposed)
            {
                txtPassword.Clear();
                Show();
                txtUsername.Focus();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Goodbye");
            Application.Exit();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Session.Clear();
            Application.Exit();
        }
    }
}
