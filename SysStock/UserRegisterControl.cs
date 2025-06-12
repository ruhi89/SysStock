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
        private MainForm mainForm;
        private int? editingUserId;

        public UserRegisterControl(MainForm mainForm,int? userId = null)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.editingUserId = userId;

            if (editingUserId.HasValue)
            {
                lblRegister.Text = "Edit User Details";
                btnRegister.Text = "Save";
                btnClear.Text = "Cancel";   
                LoadUserData(editingUserId.Value);
            }
        }

        private void LoadUserData(int userId)
        {
            string query = $"SELECT * FROM Users WHERE UserId = {userId}";
            DataTable dt = new DataAccess().ExecuteQueryTable(query);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                txtUsername.Text = row["Username"].ToString();
                txtFullName.Text = row["FullName"].ToString();
                txtEmail.Text = row["Email"].ToString();
                txtPassword.Text = row["Password"].ToString();
                if (row["Role"].ToString() == "Admin")
                {
                    rbAdmin.Checked = true;
                }
                else if (row["Role"].ToString() == "Staff")
                {
                    rbStaff.Checked = true;
                }
            }
        }


        private void UserRegisterControl_Load(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string fullname = txtFullName.Text.Trim();
            string username = txtUsername.Text.Trim();
            string email = txtEmail.Text.Trim();
            string role = rbAdmin.Checked ? "Admin" : "Staff";
            string password = txtPassword.Text.Trim();

            if (fullname == "" || username == "" || email == "" || password == "" || (!rbAdmin.Checked && !rbStaff.Checked))
            {
                MessageBox.Show("Please fill in all fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                DataAccess da = new DataAccess();

                string checkUsernameQuery = $"SELECT COUNT(*) FROM Users WHERE Username = '{username}' AND UserId != {(editingUserId.HasValue ? editingUserId.Value : 0)}";
                DataTable dtUsername = da.ExecuteQueryTable(checkUsernameQuery);
                int usernameCount = Convert.ToInt32(dtUsername.Rows[0][0]);

                if (usernameCount > 0)
                {
                    MessageBox.Show("This username is already taken by another user.", "Conflict", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string checkEmailQuery = $"SELECT COUNT(*) FROM Users WHERE Email = '{email}' AND UserId != {(editingUserId.HasValue ? editingUserId.Value : 0)}";
                DataTable dtEmail = da.ExecuteQueryTable(checkEmailQuery);
                int emailCount = Convert.ToInt32(dtEmail.Rows[0][0]);

                if (emailCount > 0)
                {
                    MessageBox.Show("This email is already in use by another user.", "Conflict", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string query;
                if (editingUserId.HasValue)
                {
                    query = $"UPDATE Users SET FullName = '{fullname}', Username = '{username}', Email = '{email}', Role = '{role}', Password = '{password}' WHERE UserId = {editingUserId.Value}";
                }
                else
                {
                    query = $"INSERT INTO Users (FullName, Username, Email, Role, Password, IsActive, CreatedAt) " +
                            $"VALUES ('{fullname}', '{username}', '{email}', '{role}', '{password}', 1, GETDATE())";
                }

                int result = da.ExecuteDMLQuery(query);

                if (result == 0)
                {
                    MessageBox.Show(editingUserId.HasValue ? "User update failed." : "User registration failed.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(editingUserId.HasValue ? "User updated successfully." : "User registered successfully.",
                                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    mainForm.LoadControl(new UserListControl(mainForm));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred. Please try again later.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (editingUserId.HasValue)
            {
                mainForm.LoadControl(new UserListControl(mainForm));
            }
            else
            {
                txtFullName.Clear();
                txtUsername.Clear();
                txtEmail.Clear();
                txtPassword.Clear();
                rbAdmin.Checked = false;
                rbStaff.Checked = false;
            }
        }
    }
}
