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
    public partial class CategoryListControl : UserControl
    {
        private MainForm mainForm;
        private DataAccess da = new DataAccess();
        public CategoryListControl(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        private void CategoryListControl_Load(object sender, EventArgs e)
        {
            LoadCategoryList();
        }

        private void LoadCategoryList(string searchTerm = "")
        {
            try
            {
                string query = @"SELECT CategoryId, Name, Description, 
                    CASE WHEN IsActive = 1 THEN 'Active' ELSE 'Inactive' END AS Status
                    FROM Categories";

                if (!string.IsNullOrWhiteSpace(searchTerm))
                {
                    query += $" WHERE Name LIKE '%{searchTerm}%'";
                }

                DataTable dt = da.ExecuteQueryTable(query);

                dataGridViewCategories.Columns.Clear();
                dataGridViewCategories.DataSource = dt;

                dataGridViewCategories.Columns["CategoryId"].HeaderText = "ID";
                dataGridViewCategories.Columns["Name"].HeaderText = "Category Name";
                dataGridViewCategories.Columns["Description"].HeaderText = "Description";
                dataGridViewCategories.Columns["Status"].HeaderText = "Status";

                DataGridViewButtonColumn editButton = new DataGridViewButtonColumn();
                editButton.Name = "Edit";
                editButton.HeaderText = "Action";
                editButton.Text = "Edit";
                editButton.UseColumnTextForButtonValue = true;
                editButton.DefaultCellStyle.ForeColor = Color.Blue;
                dataGridViewCategories.Columns.Add(editButton);

                DataGridViewButtonColumn toggleStatusButton = new DataGridViewButtonColumn();
                toggleStatusButton.Name = "ToggleStatus";
                toggleStatusButton.HeaderText = "Status Control";
                toggleStatusButton.Text = "Toggle";
                toggleStatusButton.UseColumnTextForButtonValue = true;
                toggleStatusButton.DefaultCellStyle.ForeColor = Color.DarkGreen;
                dataGridViewCategories.Columns.Add(toggleStatusButton);

                DataGridViewButtonColumn deleteButton = new DataGridViewButtonColumn();
                deleteButton.Name = "Delete";
                deleteButton.HeaderText = "Delete";
                deleteButton.Text = "Delete";
                deleteButton.UseColumnTextForButtonValue = true;
                deleteButton.DefaultCellStyle.ForeColor = Color.Red;
                dataGridViewCategories.Columns.Add(deleteButton);

                dataGridViewCategories.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridViewCategories.ReadOnly = true;
                dataGridViewCategories.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewCategories.MultiSelect = false;
                dataGridViewCategories.AllowUserToAddRows = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading category list: " + ex.Message);
            }
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            mainForm.LoadControl(new CategoryCreateControl(mainForm));
        }

        private void dataGridViewCategories_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dataGridViewCategories.Rows.Count)
                return;
            if (e.ColumnIndex < 0 || e.ColumnIndex >= dataGridViewCategories.Columns.Count)
                return;

            int categoryId = Convert.ToInt32(dataGridViewCategories.Rows[e.RowIndex].Cells["CategoryId"].Value);
            if (dataGridViewCategories.Columns[e.ColumnIndex].Name == "ToggleStatus")
            {
                string currentStatus = dataGridViewCategories.Rows[e.RowIndex].Cells["Status"].Value.ToString();
                int newStatus = currentStatus == "Active" ? 0 : 1;

                try
                {
                    string updateQuery = $"UPDATE Categories SET IsActive = {newStatus} WHERE CategoryId = {categoryId}";
                    int result = da.ExecuteDMLQuery(updateQuery);

                    if (result > 0)
                    {
                        string statusText = newStatus == 1 ? "activated" : "deactivated";
                        MessageBox.Show($"Category successfully {statusText}.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadCategoryList();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating status: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (dataGridViewCategories.Columns[e.ColumnIndex].Name == "Edit")
            {
                mainForm.LoadControl(new CategoryCreateControl(mainForm, categoryId));
            }
            else if (dataGridViewCategories.Columns[e.ColumnIndex].Name == "Delete")
            {
                string checkQuery = $"SELECT COUNT(*) FROM Products WHERE CategoryId = {categoryId}";
                DataTable dt = da.ExecuteQueryTable(checkQuery);
                int productCount = Convert.ToInt32(dt.Rows[0][0]);
                if (productCount > 0)
                {
                    MessageBox.Show("Cannot delete this category because it is associated with one or more products.", "Delete Blocked", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var confirm = MessageBox.Show("Are you sure you want to delete this category?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    try
                    {
                        string deleteQuery = $"DELETE FROM Categories WHERE CategoryId = {categoryId}";
                        int result = da.ExecuteDMLQuery(deleteQuery);
                        if (result > 0)
                        {
                            MessageBox.Show("Category deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadCategoryList();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error deleting category: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.Trim();
            LoadCategoryList(searchTerm);
        }
    }
}
