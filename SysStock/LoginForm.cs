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
    public partial class LoginForm: Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }



        private void LoginForm_Load(object sender, EventArgs e)
        {
            Usernametxt.Focus();
        }
        private void Loginbtn_Click(object sender, EventArgs e)
        {
            string username = Usernametxt.Text.Trim();
            string password = Passtxt.Text;

            // Example: Hardcoded login credentials
            if (username == "admin" && password == "1234")
            {
                MessageBox.Show("Login Successful!", "SysStock", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Open MainForm
                //MainForm mainForm = new MainForm();
                //this.Hide(); // Hide Login Form
                //mainForm.Show();
            }
            else
            {
                MessageBox.Show("Invalid Username or Password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Usernametxt.Clear();
                Passtxt.Clear();
                Usernametxt.Focus();
            }
        }

        private void Clearbtn_Click(object sender, EventArgs e)
        {
            Usernametxt.Clear();
            Passtxt.Clear();
            Usernametxt.Focus();
        }

        private void ShowPassCB_CheckedChanged(object sender, EventArgs e)
        {
            if(ShowPassCB.Checked)
            {
                Passtxt.PasswordChar = '\0';
            }
            else
            {
                Passtxt.PasswordChar = '*';
            }
        }
    }
}
