using System;
using System.Data;
using System.Windows.Forms;
using ExpenseManagementSystem.DAL;

namespace ExpenseManagementSystem.UI
{
    public partial class FrmExpenseAddEdit : Form
    {
        CategoryDAL catDal = new CategoryDAL();
        ExpensesDAL expDal = new ExpensesDAL();
        int? expenseId;

        public FrmExpenseAddEdit(int? id)
        {
            InitializeComponent();
            expenseId = id;
        }

        private void FrmExpenseAddEdit_Load(object sender, EventArgs e)
        {
            LoadCategories();

            if (expenseId != null)
                LoadExpenseForEdit();
            else
                ClearForm();
        }

        private void LoadCategories()
        {
            DataTable dt = catDal.GetAllCategories();
            cmbCategory.DataSource = dt;
            cmbCategory.DisplayMember = "Name";
            cmbCategory.ValueMember = "CategoryId";
        }

        private void LoadExpenseForEdit()
        {
            DataRow r = expDal.GetExpenseById(expenseId.Value);

            if (r == null)
            {
                MessageBox.Show("Expense not found.");
                return;
            }

            numAmount.Value = Convert.ToDecimal(r["Amount"]);
            dtpDate.Value = Convert.ToDateTime(r["ExpenseDate"]);
            txtNote.Text = r["Note"].ToString();
            cmbCategory.SelectedValue = Convert.ToInt32(r["CategoryId"]);
        }

        private void ClearForm()
        {
            dtpDate.Value = DateTime.Today;
            numAmount.Value = 0;
            txtNote.Text = "";
            if (cmbCategory.Items.Count > 0) cmbCategory.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            decimal amount = numAmount.Value;
            int catId = Convert.ToInt32(cmbCategory.SelectedValue);
            DateTime date = dtpDate.Value.Date;
            string note = txtNote.Text;

            if (amount <= 0)
            {
                MessageBox.Show("Enter amount > 0");
                return;
            }

            try
            {
                if (expenseId == null)
                    expDal.AddExpense(date, amount, catId, note);
                else
                    expDal.UpdateExpense(expenseId.Value, date, amount, catId, note);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
