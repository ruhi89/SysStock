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
    public partial class SettingsControl: UserControl
    {
        private MainForm mainForm;
        private int userId;

        private DataAccess da = new DataAccess();
        public SettingsControl(MainForm mainForm, int userId)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.userId = userId;
        }

        private void SettingsControl_Load(object sender, EventArgs e)
        {
            GetUserInfo();
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
                    txtRole.Text = row["Role"].ToString();
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

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            mainForm.LoadControl(new ChangePasswordControl(mainForm, userId));

        }

        private void btnEditProfile_Click(object sender, EventArgs e)
        {
            mainForm.LoadControl(new UserEditControl(mainForm, userId));
        }
    }
}
