using System;
using System.Data;
using System.Windows.Forms;

namespace SysStock
{
    public partial class CategoryCreateControl : UserControl
    {
        private MainForm mainForm;
        private int? editingCategoryId;
        private DataAccess da = new DataAccess();

        public CategoryCreateControl(MainForm mainForm, int? editingCategoryId = null)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.editingCategoryId = editingCategoryId;

            if (editingCategoryId.HasValue)
            {
                lblAddCategory.Text = "Edit Category";
                btnRegister.Text = "Save";
                btnClear.Text = "Cancel";
                LoadCategoryData(editingCategoryId.Value);
            }
        }

        private void LoadCategoryData(int categoryId)
        {
            string query = $"SELECT * FROM Categories WHERE CategoryId = {categoryId}";
            DataTable dt = da.ExecuteQueryTable(query);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                txtCategoryName.Text = row["Name"].ToString();
                rtbDescription.Text = row["Description"].ToString();
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string name = txtCategoryName.Text.Trim();
            string description = rtbDescription.Text.Trim();

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Please enter a category name.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string checkNameQuery = $"SELECT COUNT(*) FROM Categories WHERE Name = '{name}' AND CategoryId != {(editingCategoryId.HasValue ? editingCategoryId.Value : 0)}";
                DataTable dtName = da.ExecuteQueryTable(checkNameQuery);
                int nameCount = Convert.ToInt32(dtName.Rows[0][0]);

                if (nameCount > 0)
                {
                    MessageBox.Show("This category name already exists.", "Conflict", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string query;
                if (editingCategoryId.HasValue)
                {
                    query = $"UPDATE Categories SET Name = '{name}', Description = '{description}' WHERE CategoryId = {editingCategoryId.Value}";
                }
                else
                {
                    query = $"INSERT INTO Categories (Name, Description, IsActive) VALUES ('{name}', '{description}', 1)";
                }

                int result = da.ExecuteDMLQuery(query);

                if (result == 0)
                {
                    MessageBox.Show(editingCategoryId.HasValue ? "Category update failed." : "Category creation failed.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(editingCategoryId.HasValue ? "Category updated successfully." : "Category created successfully.",
                                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    mainForm.LoadControl(new CategoryListControl(mainForm));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred. Please try again later.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (editingCategoryId.HasValue)
            {
                mainForm.LoadControl(new CategoryListControl(mainForm));
            }
            else
            {
                txtCategoryName.Clear();
                rtbDescription.Clear();
            }
        }

        private void CatagoryCreateControl_Load(object sender, EventArgs e)
        {
            // Optionally set defaults here
        }

    }
}