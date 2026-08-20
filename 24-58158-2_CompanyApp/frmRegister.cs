using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeDetails
{
    public partial class frmRegister : Form
    {
        public frmRegister()
        {
            InitializeComponent();
        }

        private readonly User user = new User();

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text.Trim() == "" || txtPassword.Text == "" || txtConPassword.Text == "")
            {
                MessageBox.Show("Username and password fields cannot be empty", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (txtPassword.Text == txtConPassword.Text)
            {
                string username = txtUsername.Text.Trim();

                if (username.Length > 50)
                {
                    MessageBox.Show(
                        "The username cannot contain more than 50 characters.",
                        "Registration Failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    return;
                }

                try
                {
                    if (user.UsernameExists(username))
                    {
                        MessageBox.Show(
                            "That username already exists. Choose a different username.",
                            "Registration Failed",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                        txtUsername.Focus();
                        return;
                    }

                    int userId = user.RegisterUser(username, txtPassword.Text);

                    if (userId > 0)
                    {
                        MessageBox.Show(
                            "Your account has been successfully created.",
                            "Registration Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                        Close();
                    }
                }
                catch (SqlException exception)
                {
                    MessageBox.Show(
                        "Registration could not be completed.\n\n" + exception.Message,
                        "Database Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
            else
            {
                MessageBox.Show("Passwords do not match. Please re-enter them." , "Registration Failed" , MessageBoxButtons.OK , MessageBoxIcon.Error);
                txtPassword.Text = "";
                txtConPassword.Text = "";
                txtPassword.Focus();
            }
        }

        private void checkbxShowPas_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbxShowPas.Checked)
            {
                txtPassword.PasswordChar = '\0';
                txtConPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '•';
                txtConPassword.PasswordChar = '•';
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtConPassword.Text = "";
            txtUsername.Focus();
        }

        private void clickLogin_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Goodbye");
            Application.Exit();
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmRegister_Load(object sender, EventArgs e)
        {

        }
    }
}
