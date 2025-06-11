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
    public partial class ChangePasswordControl: UserControl
    {
        private MainForm mainForm;
        private int userId;

        private DataAccess da = new DataAccess();
        public ChangePasswordControl(MainForm mainForm,int userId)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.userId = userId;
        }

        private void ShowPassCB_CheckedChanged(object sender, EventArgs e)
        {
            if (ShowPassCB.Checked)
            {
                txtOldPassword.PasswordChar = '\0';
                txtNewPassword.PasswordChar = '\0';
            }
            else
            {
                txtOldPassword.PasswordChar = '*';
                txtNewPassword.PasswordChar = '*';
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
         mainForm.LoadControl(new SettingsControl(mainForm, userId));
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string oldPassword = txtOldPassword.Text.Trim();
            string newPassword = txtNewPassword.Text.Trim();

            if (string.IsNullOrEmpty(oldPassword) || string.IsNullOrEmpty(newPassword))
            {
                MessageBox.Show("Please enter both old and new passwords.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {

                string checkQuery = $"SELECT Password FROM Users WHERE UserId = {userId}";
                DataTable dt = da.ExecuteQueryTable(checkQuery);


                string currentPassword = dt.Rows[0]["Password"].ToString();

                if (currentPassword != oldPassword)
                {
                    MessageBox.Show("Old password is incorrect.", "Authentication Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string updateQuery = $"UPDATE Users SET Password = '{newPassword}' WHERE UserId = {userId}";
                int rowsAffected = da.ExecuteDMLQuery(updateQuery);

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Password changed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    mainForm.LoadControl(new SettingsControl(mainForm, userId));
                }
                else
                {
                    MessageBox.Show("Password change failed. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
