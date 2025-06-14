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
    public partial class BrandListControl : UserControl
    {
        private MainForm mainForm;
        private DataAccess da = new DataAccess();
        public BrandListControl(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        private void BrandListControl_Load(object sender, EventArgs e)
        {
            LoadBrandList();
        }

        private void LoadBrandList(string searchTerm = "")
        {
            try
            {
                string query = @"SELECT BrandId, Name, Description, 
                    CASE WHEN IsActive = 1 THEN 'Active' ELSE 'Inactive' END AS Status
                    FROM Brands";

                if (!string.IsNullOrWhiteSpace(searchTerm))
                {
                    query += $" WHERE Name LIKE '%{searchTerm}%'";
                }

                DataTable dt = da.ExecuteQueryTable(query);

                dataGridViewBrands.Columns.Clear();
                dataGridViewBrands.DataSource = dt;

                dataGridViewBrands.Columns["BrandId"].HeaderText = "ID";
                dataGridViewBrands.Columns["Name"].HeaderText = "Brand Name";
                dataGridViewBrands.Columns["Description"].HeaderText = "Description";
                dataGridViewBrands.Columns["Status"].HeaderText = "Status";

                DataGridViewButtonColumn editButton = new DataGridViewButtonColumn();
                editButton.Name = "Edit";
                editButton.HeaderText = "Action";
                editButton.Text = "Edit";
                editButton.UseColumnTextForButtonValue = true;
                editButton.DefaultCellStyle.ForeColor = Color.Blue;
                dataGridViewBrands.Columns.Add(editButton);

                DataGridViewButtonColumn toggleStatusButton = new DataGridViewButtonColumn();
                toggleStatusButton.Name = "ToggleStatus";
                toggleStatusButton.HeaderText = "Status Control";
                toggleStatusButton.Text = "Toggle";
                toggleStatusButton.UseColumnTextForButtonValue = true;
                toggleStatusButton.DefaultCellStyle.ForeColor = Color.DarkGreen;
                dataGridViewBrands.Columns.Add(toggleStatusButton);

                DataGridViewButtonColumn deleteButton = new DataGridViewButtonColumn();
                deleteButton.Name = "Delete";
                deleteButton.HeaderText = "Delete";
                deleteButton.Text = "Delete";
                deleteButton.UseColumnTextForButtonValue = true;
                deleteButton.DefaultCellStyle.ForeColor = Color.Red;
                dataGridViewBrands.Columns.Add(deleteButton);

                dataGridViewBrands.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridViewBrands.ReadOnly = true;
                dataGridViewBrands.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewBrands.MultiSelect = false;
                dataGridViewBrands.AllowUserToAddRows = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading brand list: " + ex.Message);
            }
        }

        private void btnAddBrand_Click(object sender, EventArgs e)
        {
            mainForm.LoadControl(new BrandCreateControl(mainForm));
        }

        private void dataGridViewBrands_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dataGridViewBrands.Rows.Count)
                return;
            if (e.ColumnIndex < 0 || e.ColumnIndex >= dataGridViewBrands.Columns.Count)
                return;

            int brandId = Convert.ToInt32(dataGridViewBrands.Rows[e.RowIndex].Cells["BrandId"].Value);
            if (dataGridViewBrands.Columns[e.ColumnIndex].Name == "ToggleStatus")
            {
                string currentStatus = dataGridViewBrands.Rows[e.RowIndex].Cells["Status"].Value.ToString();
                int newStatus = currentStatus == "Active" ? 0 : 1;

                try
                {
                    string updateQuery = $"UPDATE Brands SET IsActive = {newStatus} WHERE BrandId = {brandId}";
                    int result = da.ExecuteDMLQuery(updateQuery);

                    if (result > 0)
                    {
                        string statusText = newStatus == 1 ? "activated" : "deactivated";
                        MessageBox.Show($"Brand successfully {statusText}.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadBrandList();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating status: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (dataGridViewBrands.Columns[e.ColumnIndex].Name == "Edit")
            {
                mainForm.LoadControl(new BrandCreateControl(mainForm, brandId));
            }
            else if (dataGridViewBrands.Columns[e.ColumnIndex].Name == "Delete")
            {
                string checkQuery = $"SELECT COUNT(*) FROM Products WHERE BrandId = {brandId}";
                DataTable dt = da.ExecuteQueryTable(checkQuery);
                int productCount = Convert.ToInt32(dt.Rows[0][0]);
                if (productCount > 0)
                {
                    MessageBox.Show("Cannot delete this brand because it is associated with one or more products.", "Delete Blocked", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var confirm = MessageBox.Show("Are you sure you want to delete this brand?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    try
                    {
                        string deleteQuery = $"DELETE FROM Brands WHERE BrandId = {brandId}";
                        int result = da.ExecuteDMLQuery(deleteQuery);
                        if (result > 0)
                        {
                            MessageBox.Show("Brand deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadBrandList();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error deleting brand: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.Trim();
            LoadBrandList(searchTerm);
        }
    }
}
