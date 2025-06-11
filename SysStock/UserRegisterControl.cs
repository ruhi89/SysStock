using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SysStock
{
    public partial class UserRegisterControl : UserControl
    {
        public UserRegisterControl()
        {
            InitializeComponent();
        }

        private void UserRegisterControl_Load(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string fullname = txtFullName.Text.Trim();
            string username= txtUsername.Text.Trim();
            string email = txtEmail.Text.Trim();
            string role= rbAdmin.Checked ? "Admin" : "Staff";
            string password = txtPassword.Text.Trim();

            if(fullname==""||username == "" || email == "" || password == ""|| (!rbAdmin.Checked && !rbStaff.Checked))
            {
                MessageBox.Show("Please fill in all fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                DataAccess da = new DataAccess();

                string checkUsernameQuery = $"SELECT COUNT(*) FROM Users WHERE Username = '{username}'";
                DataTable dtUsername = da.ExecuteQueryTable(checkUsernameQuery);
                int usernameCount = Convert.ToInt32(dtUsername.Rows[0][0]);

                if (usernameCount > 0)
                {
                    MessageBox.Show("This username is already taken by another user.", "Conflict", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string checkEmailQuery = $"SELECT COUNT(*) FROM Users WHERE Email = '{email}'";
                DataTable dtEmail = da.ExecuteQueryTable(checkEmailQuery);
                int emailCount = Convert.ToInt32(dtEmail.Rows[0][0]);

                if (emailCount > 0)
                {
                    MessageBox.Show("This email is already in use by another user.", "Conflict", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string query = $"INSERT INTO Users (FullName, Username, Email, Role, Password, IsActive, CreatedAt) " +
                               $"VALUES ('{fullname}', '{username}', '{email}', '{role}', '{password}', 1, GETDATE())";
                int result = da.ExecuteDMLQuery(query);

                if (result == 0)
                {
                    MessageBox.Show("User registration failed. Please try again.", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("User registered successfully.", "Registration Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtFullName.Clear();
                    txtUsername.Clear();
                    txtEmail.Clear();
                    txtPassword.Clear();
                    rbAdmin.Checked = false;
                    rbStaff.Checked = false;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("An error occurred while registering the user. Please try again later.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
