using System;
using System.Data;
using System.Windows.Forms;
using ExpenseManagementSystem.DAL;

namespace ExpenseManagementSystem.UI
{
    public partial class FrmCategories : Form
    {
        private readonly CategoryDAL _catDal = new CategoryDAL();

        public FrmCategories()
        {
            InitializeComponent();
            this.Load += FrmCategories_Load;
        }

        private void FrmCategories_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void LoadGrid()
        {
            DataTable dt = _catDal.GetAllCategories();
            dgvCategories.DataSource = dt;

           

            if (dgvCategories.Columns.Contains("CategoryId"))
                dgvCategories.Columns["CategoryId"].Visible = false;
           
            dgvCategories.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCategories.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCategories.MultiSelect = false;
        }

        private int? SelectedCategoryId()
        {
            if (dgvCategories.CurrentRow == null) return null;
            return Convert.ToInt32(dgvCategories.CurrentRow.Cells["CategoryId"].Value);
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            try
            {
                _catDal.AddCategory(txtCategoryName.Text.Trim());
                txtCategoryName.Clear();
                LoadGrid();
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            try
            {
                var id = SelectedCategoryId();
                if (!id.HasValue)
                {
                    MessageBox.Show("Select a category first.");
                    return;
                }

                var ok = MessageBox.Show("Delete this category?", "Confirm",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (ok == DialogResult.Yes)
                {
                    _catDal.DeleteCategory(id.Value);
                    LoadGrid();
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FrmCategories_Load_1(object sender, EventArgs e)
        {
           
        }
    }
}
