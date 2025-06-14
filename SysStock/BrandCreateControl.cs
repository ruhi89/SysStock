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
    public partial class BrandCreateControl : UserControl
    {
        private MainForm mainForm;
        private int? editingBrandId;
        private DataAccess da = new DataAccess();

        public BrandCreateControl(MainForm mainForm, int? brandId = null)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.editingBrandId = brandId;

            if (editingBrandId.HasValue)
            {
                lblRegister.Text = "Edit Brand";
                btnRegister.Text = "Save";
                btnClear.Text = "Cancel";
                LoadBrandData(editingBrandId.Value);
            }
        }

        private void LoadBrandData(int brandId)
        {
            string query = $"SELECT * FROM Brands WHERE BrandId = {brandId}";
            DataTable dt = da.ExecuteQueryTable(query);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                txtBrandName.Text = row["Name"].ToString();
                rtbDescription.Text = row["Description"].ToString();
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (editingBrandId.HasValue)
            {
                mainForm.LoadControl(new BrandListControl(mainForm));
            }
            else
            {
                txtBrandName.Clear();
                rtbDescription.Clear();
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string name = txtBrandName.Text.Trim();
            string description = rtbDescription.Text.Trim();

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Please enter a brand name.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string checkNameQuery = $"SELECT COUNT(*) FROM Brands WHERE Name = '{name.Replace("'", "''")}' AND BrandId != {(editingBrandId.HasValue ? editingBrandId.Value : 0)}";
                DataTable dtName = da.ExecuteQueryTable(checkNameQuery);
                int nameCount = Convert.ToInt32(dtName.Rows[0][0]);

                if (nameCount > 0)
                {
                    MessageBox.Show("This brand name already exists.", "Conflict", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string query;
                if (editingBrandId.HasValue)
                {
                    query = $"UPDATE Brands SET Name = '{name}', Description = '{description}' WHERE BrandId = {editingBrandId.Value}";
                }
                else
                {
                    query = $"INSERT INTO Brands (Name, Description, IsActive) VALUES ('{name}', '{description}', 1)";
                }

                int result = da.ExecuteDMLQuery(query);

                if (result == 0)
                {
                    MessageBox.Show(editingBrandId.HasValue ? "Brand update failed." : "Brand creation failed.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(editingBrandId.HasValue ? "Brand updated successfully." : "Brand created successfully.",
                                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    mainForm.LoadControl(new BrandListControl(mainForm));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred. Please try again later.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
