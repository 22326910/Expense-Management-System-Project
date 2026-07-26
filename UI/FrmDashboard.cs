using ExpenseManagementSystem.DAL;
using ExpenseManagementSystem;
using System;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ExpenseManagementSystem.UI
{
    public partial class FrmDashboard : Form
    {
        private readonly CategoryDAL _catDal = new CategoryDAL();
        private readonly ExpensesDAL _expDal = new ExpensesDAL();

        public FrmDashboard()
        {
            InitializeComponent();
            this.Load += FrmDashboard_Load;
        }

        private void FrmDashboard_Load(object sender, EventArgs e)
        {
            // default dates
            dtpFrom.Value = DateTime.Today.AddDays(-30);
            dtpTo.Value = DateTime.Today;

            LoadCategories();
            LoadExpensesToGrid();
            UpdateTotals();
            UpdatePieChart();
            UpdateMonthChart();
        }

        private void LoadCategories()
        {
           
            cmbCategory.DisplayMember = "Name";
            cmbCategory.ValueMember = "CategoryId";

            // Add "All"
            DataTable dt = _catDal.GetAllCategories();

            DataRow allRow = dt.NewRow();
            allRow["CategoryId"] = 0;
            allRow["Name"] = "All";
            dt.Rows.InsertAt(allRow, 0);

            cmbCategory.DataSource = dt;
            cmbCategory.SelectedValue = 0;
        }

        private int SelectedCategoryId()
        {
            if (cmbCategory.SelectedValue == null) return 0;
            return Convert.ToInt32(cmbCategory.SelectedValue);
        }

        private void LoadExpensesToGrid()
        {
            int catId = SelectedCategoryId();
            DataTable dt = _expDal.GetExpenses(dtpFrom.Value.Date, dtpTo.Value.Date, catId);
            dgvExpenses.Columns.Clear();
            dgvExpenses.AutoGenerateColumns = true;
            dgvExpenses.DataSource = dt;

            // hide ids
            if (dgvExpenses.Columns.Contains("ExpenseId"))
                dgvExpenses.Columns["ExpenseId"].Visible = false;
            
            if (dgvExpenses.Columns.Contains("CategoryId"))
                dgvExpenses.Columns["CategoryId"].Visible = false;

            dgvExpenses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvExpenses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvExpenses.MultiSelect = false;
        }

        private void UpdateTotals()
        {
            // Today
            decimal today = _expDal.GetTotal(DateTime.Today, DateTime.Today, 0);
            lblTodayValue.Text = today.ToString("0.00");

            // This Month
            DateTime first = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            DateTime last = first.AddMonths(1).AddDays(-1);
            decimal month = _expDal.GetTotal(first, last, 0);
            lblMonthValue.Text = month.ToString("0.00");

            
            // Filtered
            int catId = SelectedCategoryId();
            decimal filtered = _expDal.GetTotal(dtpFrom.Value.Date, dtpTo.Value.Date, catId);
            lblFilteredValue.Text = filtered.ToString("0.00");
        }

        private void UpdatePieChart()
        {
            var s = chartByCategory.Series[0];
            s.Points.Clear();
            s.ChartType = SeriesChartType.Pie;

            foreach (DataGridViewRow row in dgvExpenses.Rows)
            {
                if (row.IsNewRow) continue;

                if (row.Cells["Category"].Value == null) continue;
                if (row.Cells["Amount"].Value == null) continue;

                string cat = row.Cells["Category"].Value.ToString();
                decimal amt = Convert.ToDecimal(row.Cells["Amount"].Value);

                // هل الفئة موجودة في الشارت؟
                int index = -1;
                for (int i = 0; i < s.Points.Count; i++)
                {
                    if (s.Points[i].AxisLabel == cat)
                    {
                        index = i;
                        break;
                    }
                }

                if (index == -1)
                {
                    // جديدة
                    var p = s.Points.AddY(amt);
                    s.Points[p].AxisLabel = cat;
                    s.Points[p].LegendText = cat;
                }
                else
                {
                    // موجودة -> زوّد قيمتها
                    s.Points[index].YValues[0] += (double)amt;
                }
            }
        }

        private void UpdateMonthChart()
        {
            // اجمع مصروفات الشهر الحالي فقط (Student easy)
            decimal totalThisMonth = 0;

            foreach (DataGridViewRow row in dgvExpenses.Rows)
            {
                if (row.IsNewRow) continue;

                // لازم أسماء الأعمدة تكون Date و Amount
                if (row.Cells["Date"].Value == null) continue;
                if (row.Cells["Amount"].Value == null) continue;

                DateTime d = Convert.ToDateTime(row.Cells["Date"].Value);
                decimal amt = Convert.ToDecimal(row.Cells["Amount"].Value);

                if (d.Year == DateTime.Today.Year && d.Month == DateTime.Today.Month)
                    totalThisMonth += amt;
            }

            // رسم عمود واحد فقط
            var s = chartByMonth.Series[0];
            s.Points.Clear();
            s.ChartType = SeriesChartType.Column;

            string monthName = DateTime.Today.ToString("MMM yyyy"); // مثال: Dec 2025
            s.Points.AddXY(monthName, totalThisMonth);
        }


        private int? GetSelectedExpenseId()
        {
            if (dgvExpenses.CurrentRow == null) return null;
            if (dgvExpenses.CurrentRow.Cells["ExpenseId"].Value == null) return null;
            return Convert.ToInt32(dgvExpenses.CurrentRow.Cells["ExpenseId"].Value);
        }

        // ===== Buttons =====

        private void btnFilter_Click(object sender, EventArgs e)
        {
            LoadExpensesToGrid();
            UpdateTotals();
            UpdatePieChart();
            UpdateMonthChart();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            dtpFrom.Value = DateTime.Today.AddDays(-30);
            dtpTo.Value = DateTime.Today;
            cmbCategory.SelectedValue = 0;

            LoadExpensesToGrid();
            UpdateTotals();
            UpdatePieChart();
            UpdateMonthChart();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var f = new FrmExpenseAddEdit(null))
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    LoadExpensesToGrid();
                    UpdateTotals();
                    UpdatePieChart();
                    UpdateMonthChart();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var id = GetSelectedExpenseId();
            if (!id.HasValue)
            {
                MessageBox.Show("Select an expense first.");
                return;
            }

            using (var f = new FrmExpenseAddEdit(id.Value))
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    LoadExpensesToGrid();
                    UpdateTotals();
                    UpdatePieChart();
                    UpdateMonthChart();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var id = GetSelectedExpenseId();
            if (!id.HasValue)
            {
                MessageBox.Show("Select an expense first.");
                return;
            }

            var ok = MessageBox.Show("Delete this expense?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (ok == DialogResult.Yes)
            {
                _expDal.DeleteExpense(id.Value);
                LoadExpensesToGrid();
                UpdateTotals();
                UpdatePieChart();
                UpdateMonthChart();
            }
        }

        private void btnManageCategories_Click(object sender, EventArgs e)
        {
            using (var f = new FrmCategories())
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    LoadCategories();
                    LoadExpensesToGrid();
                    UpdateTotals();
                    UpdatePieChart();
                    UpdateMonthChart();
                }
            }
        }
    }
}

