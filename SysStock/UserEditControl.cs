using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SysStock
{
    public partial class UserEditControl : UserControl
    {
        private MainForm mainForm;
        private int userId;

        private DataAccess da = new DataAccess();
        public UserEditControl(MainForm mainForm, int userId)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.userId = userId;
        }

        private void GetUserInfo()
        {
            try
            {
                string query = $"SELECT Username, FullName, Email, Role, IsActive FROM Users WHERE UserId = {userId}";

                DataTable dt = da.ExecuteQueryTable(query);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];


                    txtUsername.Text = row["Username"].ToString();
                    txtFullName.Text = row["FullName"].ToString();
                    txtEmail.Text = row["Email"].ToString();
                }
                else
                {
                    MessageBox.Show("User not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving user info: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void llblChangePassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            mainForm.LoadControl(new ChangePasswordControl(mainForm, userId));
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            mainForm.LoadControl(new SettingsControl(mainForm, userId));
        }

        private void UserEditControl_Load(object sender, EventArgs e)
        {
            GetUserInfo();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            string fullName = txtFullName.Text.Trim();
            string username = txtUsername.Text.Trim();
            string email = txtEmail.Text.Trim();

            if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {

                string checkUsernameQuery = $"SELECT COUNT(*) FROM Users WHERE Username = '{username}' AND UserId != {userId}";
                DataTable dtUsername = da.ExecuteQueryTable(checkUsernameQuery);
                int usernameCount = Convert.ToInt32(dtUsername.Rows[0][0]);

                if (usernameCount > 0)
                {
                    MessageBox.Show("This username is already taken by another user.", "Conflict", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string checkEmailQuery = $"SELECT COUNT(*) FROM Users WHERE Email = '{email}' AND UserId != {userId}";
                DataTable dtEmail = da.ExecuteQueryTable(checkEmailQuery);
                int emailCount = Convert.ToInt32(dtEmail.Rows[0][0]);

                if (emailCount > 0)
                {
                    MessageBox.Show("This email is already in use by another user.", "Conflict", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string updateQuery = $@"UPDATE Users
                                        SET FullName = '{fullName}', Username = '{username}', Email = '{email}'
                                        WHERE UserId = {userId}";

                int rowsAffected = da.ExecuteDMLQuery(updateQuery);

                if (rowsAffected > 0)
                {
                    MessageBox.Show("User updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    mainForm.LoadControl(new SettingsControl(mainForm, userId));
                }
                else
                {
                    MessageBox.Show("No changes were made.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating user: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
