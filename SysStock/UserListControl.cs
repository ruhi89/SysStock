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
    public partial class UserListControl : UserControl
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

        private void LoadUserList(string searchTerm = "")
        {
            try
            {
                string query = @"SELECT UserId, Username, FullName, Email, Role, 
                 CASE WHEN IsActive = 1 THEN 'Active' ELSE 'Inactive' END AS Status, 
                 CreatedAt 
                 FROM Users";

                if (!string.IsNullOrWhiteSpace(searchTerm))
                {
                    query += $" WHERE Username LIKE '%{searchTerm}%'";
                }

                DataTable dt = da.ExecuteQueryTable(query);

                dataGridViewUsers.Columns.Clear();
                dataGridViewUsers.DataSource = dt;


                dataGridViewUsers.Columns["UserId"].HeaderText = "ID";
                dataGridViewUsers.Columns["Username"].HeaderText = "Username";
                dataGridViewUsers.Columns["FullName"].HeaderText = "Full Name";
                dataGridViewUsers.Columns["Email"].HeaderText = "Email";
                dataGridViewUsers.Columns["Role"].HeaderText = "User Role";
                dataGridViewUsers.Columns["Status"].HeaderText = "Account Status";
                dataGridViewUsers.Columns["CreatedAt"].HeaderText = "Registration Date";

               
                DataGridViewButtonColumn editButton = new DataGridViewButtonColumn();
                editButton.Name = "Edit";
                editButton.HeaderText = "Action";
                editButton.Text = "Edit";
                editButton.UseColumnTextForButtonValue = true;
                editButton.DefaultCellStyle.ForeColor = Color.Blue;
                dataGridViewUsers.Columns.Add(editButton);

                DataGridViewButtonColumn toggleStatusButton = new DataGridViewButtonColumn();
                toggleStatusButton.Name = "ToggleStatus";
                toggleStatusButton.HeaderText = "Status Control";
                toggleStatusButton.Text = "Toggle";
                toggleStatusButton.UseColumnTextForButtonValue = true;
                toggleStatusButton.DefaultCellStyle.ForeColor = Color.DarkGreen;
                dataGridViewUsers.Columns.Add(toggleStatusButton);


                dataGridViewUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridViewUsers.ReadOnly = true;
                dataGridViewUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewUsers.MultiSelect = false;
                dataGridViewUsers.AllowUserToAddRows = false;
                dataGridViewUsers.AllowUserToDeleteRows = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading user list: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void dataGridViewUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dataGridViewUsers.Rows.Count)
                return;
            if (e.ColumnIndex < 0 || e.ColumnIndex >= dataGridViewUsers.Columns.Count)
                return;

            int userId = Convert.ToInt32(dataGridViewUsers.Rows[e.RowIndex].Cells["UserId"].Value);
            if (dataGridViewUsers.Columns[e.ColumnIndex].Name == "ToggleStatus")
            {


                string currentStatus = dataGridViewUsers.Rows[e.RowIndex].Cells["Status"].Value.ToString();
                int newStatus = currentStatus == "Active" ? 0 : 1;

                try
                {
                    string updateQuery = $"UPDATE Users SET IsActive = {newStatus} WHERE UserId = {userId}";
                    int result = da.ExecuteDMLQuery(updateQuery);

                    if (result > 0)
                    {
                        string statusText = newStatus == 1 ? "activated" : "deactivated";
                        MessageBox.Show($"User successfully {statusText}.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadUserList();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating status: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else if (dataGridViewUsers.Columns[e.ColumnIndex].Name == "Edit")
            {
                mainForm.LoadControl(new UserRegisterControl(mainForm, userId));
            }

        }



        private void btnAddUser_Click(object sender, EventArgs e)
        {
            mainForm.LoadControl(new UserRegisterControl(mainForm));
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.Trim();
            LoadUserList(searchTerm);
        }
    }
}
