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
    public partial class ProductListControl : UserControl
    {
        private MainForm mainForm;
        private DataAccess da = new DataAccess();

        public ProductListControl(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        private void ProductListControl_Load(object sender, EventArgs e)
        {
            LoadProductList();
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            mainForm.LoadControl(new ProductCreateControl());
        }

        private void LoadProductList(string searchTerm = "")
        {
            try
            {
                string query = @"
                    SELECT 
                        p.ProductId, 
                        p.Name, 
                        c.Name AS Category, 
                        b.Name AS Brand, 
                        p.UnitPrice, 
                        p.DiscountPercent, 
                        p.QuantityInStock, 
                        p.Description, 
                        CASE WHEN p.IsActive = 1 THEN 'Active' ELSE 'Inactive' END AS Status, 
                        p.CreatedAt
                    FROM Products p
                    LEFT JOIN Categories c ON p.CategoryId = c.CategoryId
                    LEFT JOIN Brands b ON p.BrandId = b.BrandId";

                if (!string.IsNullOrWhiteSpace(searchTerm))
                {
                    query += $" WHERE p.Name LIKE '%{searchTerm}%'";
                }

                DataTable dt = da.ExecuteQueryTable(query);

                dataGridViewProducts.Columns.Clear();
                dataGridViewProducts.DataSource = dt;

                dataGridViewProducts.Columns["ProductId"].HeaderText = "ID";
                dataGridViewProducts.Columns["Name"].HeaderText = "Product Name";
                dataGridViewProducts.Columns["Category"].HeaderText = "Category";
                dataGridViewProducts.Columns["Brand"].HeaderText = "Brand";
                dataGridViewProducts.Columns["UnitPrice"].HeaderText = "Unit Price";
                dataGridViewProducts.Columns["DiscountPercent"].HeaderText = "Discount (%)";
                dataGridViewProducts.Columns["QuantityInStock"].HeaderText = "Stock";
                dataGridViewProducts.Columns["Description"].HeaderText = "Description";
                dataGridViewProducts.Columns["Status"].HeaderText = "Status";
                dataGridViewProducts.Columns["CreatedAt"].HeaderText = "Created At";

                DataGridViewButtonColumn editButton = new DataGridViewButtonColumn();
                editButton.Name = "Edit";
                editButton.HeaderText = "Action";
                editButton.Text = "Edit";
                editButton.UseColumnTextForButtonValue = true;
                editButton.DefaultCellStyle.ForeColor = Color.Blue;
                dataGridViewProducts.Columns.Add(editButton);

                DataGridViewButtonColumn toggleStatusButton = new DataGridViewButtonColumn();
                toggleStatusButton.Name = "ToggleStatus";
                toggleStatusButton.HeaderText = "Status Control";
                toggleStatusButton.Text = "Toggle";
                toggleStatusButton.UseColumnTextForButtonValue = true;
                toggleStatusButton.DefaultCellStyle.ForeColor = Color.DarkGreen;
                dataGridViewProducts.Columns.Add(toggleStatusButton);

                DataGridViewButtonColumn deleteButton = new DataGridViewButtonColumn();
                deleteButton.Name = "Delete";
                deleteButton.HeaderText = "Delete";
                deleteButton.Text = "Delete";
                deleteButton.UseColumnTextForButtonValue = true;
                deleteButton.DefaultCellStyle.ForeColor = Color.Red;
                dataGridViewProducts.Columns.Add(deleteButton);

                dataGridViewProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridViewProducts.ReadOnly = true;
                dataGridViewProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewProducts.MultiSelect = false;
                dataGridViewProducts.AllowUserToAddRows = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading product list: " + ex.Message);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.Trim();
            LoadProductList(searchTerm);
        }
    }
}
