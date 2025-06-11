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

namespace SysStock
{
    public partial class LoginForm: Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }



        private void LoginForm_Load(object sender, EventArgs e)
        {
            txtUsername.Focus();
        }
        private void Loginbtn_Click(object sender, EventArgs e)
        {
            string username= txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if(username=="" || password=="")
            {
                MessageBox.Show("Please enter your username and password.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                DataAccess da= new DataAccess();
                string query = $"SELECT * FROM Users WHERE Username = '{username}' AND Password = '{password}' AND IsActive = 1";
                DataTable dt = da.ExecuteQueryTable(query);

                if (dt.Rows.Count == 1)
                {
                    int userId = Convert.ToInt32(dt.Rows[0]["UserId"]);
                    string fullname = dt.Rows[0]["FullName"].ToString();
                    string role = dt.Rows[0]["Role"].ToString();
                    MessageBox.Show($"Welcome {fullname} ({role})", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if(role == "Admin")
                    {
                        MainForm mainForm = new MainForm(userId,fullname);
                        mainForm.Show();
                    }
                    else if (role == "Staff")
                    {
                        StaffForm staffForm = new StaffForm();
                        staffForm.Show();
                    }
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid username or password. Please try again.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsername.Clear();
                    txtPassword.Clear();
                    txtUsername.Focus();
                }
                
            }
            catch(Exception ex)    
            {
                MessageBox.Show("An error occurred while trying to log in. Please try again later.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        

        private void Clearbtn_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtUsername.Focus();
        }

        private void ShowPassCB_CheckedChanged(object sender, EventArgs e)
        {
            if(ShowPassCB.Checked)
            {
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '*';
            }
        }
    }
}
