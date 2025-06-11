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
    public partial class UserListControl: UserControl
    {
        private MainForm mainForm;

        private DataAccess da = new DataAccess();
        public UserListControl(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        private void UserListControl_Load(object sender, EventArgs e)
        {
           LoadUserList();
        }

        private void LoadUserList()
        {
            try
            {
                string query = @"SELECT UserId, Username, FullName, Email, Role, 
                                 CASE WHEN IsActive = 1 THEN 'Active' ELSE 'Inactive' END AS Status, 
                                 CreatedAt 
                                 FROM Users";
                DataTable dt= da.ExecuteQueryTable(query);

                dataGridViewUsers.DataSource = dt;

                DataGridViewButtonColumn deleteButton = new DataGridViewButtonColumn();
                deleteButton.Name = "Delete";
                deleteButton.HeaderText = "Action";
                deleteButton.Text = "Delete";
                deleteButton.UseColumnTextForButtonValue = true;
                deleteButton.DefaultCellStyle.ForeColor = Color.Red;

                dataGridViewUsers.Columns.Add(deleteButton);

                dataGridViewUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridViewUsers.ReadOnly = true;
                dataGridViewUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewUsers.MultiSelect = false;
                dataGridViewUsers.AllowUserToAddRows = false;
                dataGridViewUsers.AllowUserToDeleteRows = false;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error loading user list: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void dataGridViewUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridViewUsers.Columns[e.ColumnIndex].Name == "Delete")
            {
                int userId = Convert.ToInt32(dataGridViewUsers.Rows[e.RowIndex].Cells["UserId"].Value);

                DialogResult result = MessageBox.Show("Are you sure you want to delete this user?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        string query = $"DELETE FROM Users WHERE UserId = {userId}";
                        int rowsAffected = da.ExecuteDMLQuery(query);

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("User deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadUserList();
                        }
                        else
                        {
                            MessageBox.Show("No user deleted. Check if the user exists.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error deleting user: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        private void btnAddUser_Click(object sender, EventArgs e)
        {
            mainForm.LoadControl(new UserRegisterControl());
        }
    }
}
