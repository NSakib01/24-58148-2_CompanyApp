using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace EmployeeDetails
{
    public partial class frmEmployee : Form
    {
        Employee employee = new Employee();
        public frmEmployee()
        {
            InitializeComponent();
            dgvEmployeeDetails.DataSource = employee.GetEmployees();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateEmployeeInputs())
                return;

            employee.EmpId = txtEmpId.Text;
            employee.EmpName = txtEmpName.Text;
            employee.Age = txtAge.Text;
            employee.ContactNo = txtContactNo.Text;
            employee.Gender = cboGender.Text;
            employee.CreatedBy = Session.UserID;

            try
            {
                var success = employee.InsertEmployee(employee);
                dgvEmployeeDetails.DataSource = employee.GetEmployees();
                ClearControls();
                if (success)
                    MessageBox.Show("Employee has been added successfully");
                else
                    MessageBox.Show("Error occurred. Please try again...");
            }
            catch (SqlException exception)
            {
                MessageBox.Show(
                    "The employee could not be added.\n\n" + exception.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!ValidateEmployeeInputs())
                return;

            employee.EmpId = txtEmpId.Text;
            employee.EmpName = txtEmpName.Text;
            employee.Age = txtAge.Text;
            employee.ContactNo = txtContactNo.Text;
            employee.Gender = cboGender.Text;

            try
            {
                var success = employee.UpdateEmployee(employee);
                dgvEmployeeDetails.DataSource = employee.GetEmployees();
                ClearControls();
                if (success)
                    MessageBox.Show("Employee has been updated successfully");
                else
                    MessageBox.Show("Error occurred. Please try again...");
            }
            catch (SqlException exception)
            {
                MessageBox.Show(
                    "The employee could not be updated.\n\n" + exception.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtEmpId.Text.Trim() == "")
            {
                MessageBox.Show("Select an employee before attempting to delete.");
                return;
            }

            DialogResult confirmation = MessageBox.Show(
                "Are you sure you want to delete employee " + txtEmpId.Text + "?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirmation != DialogResult.Yes)
                return;

            employee.EmpId = txtEmpId.Text;

            try
            {
                var success = employee.DeleteEmployee(employee);
                dgvEmployeeDetails.DataSource = employee.GetEmployees();
                ClearControls();
                if (success)
                    MessageBox.Show("Employee has been deleted successfully");
                else
                    MessageBox.Show("Error occurred. Please try again...");
            }
            catch (SqlException exception)
            {
                MessageBox.Show(
                    "The employee could not be deleted.\n\n" + exception.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearControls();
        }

        private void ClearControls()
        {
            txtEmpId.Text = "";
            txtEmpName.Text = "";
            txtAge.Text = "";
            txtContactNo.Text = "";
            cboGender.Text = "";
        }

        private void dgvEmployeeDetails_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow selectedRow = dgvEmployeeDetails.Rows[e.RowIndex];
            txtEmpId.Text = Convert.ToString(selectedRow.Cells["EmpId"].Value);
            txtEmpName.Text = Convert.ToString(selectedRow.Cells["EmpName"].Value);
            txtAge.Text = Convert.ToString(selectedRow.Cells["EmpAge"].Value);
            txtContactNo.Text = Convert.ToString(selectedRow.Cells["EmpContact"].Value);
            cboGender.Text = Convert.ToString(selectedRow.Cells["EmpGender"].Value);
        }

        private void frmEmployee_Load(object sender, EventArgs e)
        {

        }

        private void cboGender_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgvEmployeeDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtEmpId_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string searchTerm = txtSearch.Text.Trim();
                dgvEmployeeDetails.DataSource = searchTerm == ""
                    ? employee.GetEmployees()
                    : employee.SearchEmployees(searchTerm);
            }
            catch (SqlException exception)
            {
                MessageBox.Show(
                    "The employee search could not be completed.\n\n" + exception.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private bool ValidateEmployeeInputs()
        {
            if (Session.UserID <= 0)
            {
                MessageBox.Show("Log in before managing employees.");
                return false;
            }

            if (txtEmpId.Text.Trim() == "" || txtEmpName.Text.Trim() == "")
            {
                MessageBox.Show("Employee ID and employee name are required.");
                return false;
            }

            int age;
            if (!int.TryParse(txtAge.Text, out age) || age <= 0)
            {
                MessageBox.Show("Employee age must be a positive whole number.");
                txtAge.Focus();
                return false;
            }

            if (cboGender.Text.Trim() == "")
            {
                MessageBox.Show("Select the employee's gender.");
                cboGender.Focus();
                return false;
            }

            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
