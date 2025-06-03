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
    public partial class MainForm : Form
    {
        private string currentUser;
        public MainForm(string username)
        {
            InitializeComponent();
            currentUser= username;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            lblHeader.Text = "Welcome, " + currentUser + "!";
        }


        private void lblLogo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void lblFooter_Click(object sender, EventArgs e)
        {

        }

        private void tlpHeader_Paint(object sender, PaintEventArgs e)
        {

        }

        private void llblLogo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void LoadControl(UserControl control)
        {
            panelMain.Controls.Clear();
            control.Dock = DockStyle.Fill;
            panelMain.Controls.Add(control);
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            LoadControl(new UserListControl());
        }
    }
}
