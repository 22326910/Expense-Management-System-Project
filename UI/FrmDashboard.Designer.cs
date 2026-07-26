using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ExpenseManagementSystem.UI
{
   public partial class FrmDashboard : Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private Panel pnlToday;
        private Label lblTodayTitle;
        private Label lblTodayValue;

        private Panel pnlMonth;
        private Label lblMonthTitle;
        private Label lblMonthValue;

        private Panel pnlFiltered;
        private Label lblFilteredTitle;
        private Label lblFilteredValue;

        private Panel pnlLine1;
        private Panel pnlLine2;

        private Label lblFrom;
        private DateTimePicker dtpFrom;

        private Label lblTo;
        private DateTimePicker dtpTo;

        private Label lblCategory;
        private ComboBox cmbCategory;

        private Button btnFilter;
        private Button btnClear;

        private GroupBox grpExpenses;
        private DataGridView dgvExpenses;

        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;

        private Panel pnlChart;
        private TabControl tabCharts;
        private TabPage tabByCategory;
        private TabPage tabByMonth;

        private Chart chartByCategory;
        private Chart chartByMonth;

        private Button btnManageCategories;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.pnlToday = new System.Windows.Forms.Panel();
            this.lblTodayTitle = new System.Windows.Forms.Label();
            this.lblTodayValue = new System.Windows.Forms.Label();
            this.pnlMonth = new System.Windows.Forms.Panel();
            this.lblMonthTitle = new System.Windows.Forms.Label();
            this.lblMonthValue = new System.Windows.Forms.Label();
            this.pnlFiltered = new System.Windows.Forms.Panel();
            this.lblFilteredTitle = new System.Windows.Forms.Label();
            this.lblFilteredValue = new System.Windows.Forms.Label();
            this.pnlLine1 = new System.Windows.Forms.Panel();
            this.pnlLine2 = new System.Windows.Forms.Panel();
            this.lblFrom = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.btnFilter = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.grpExpenses = new System.Windows.Forms.GroupBox();
            this.dgvExpenses = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.pnlChart = new System.Windows.Forms.Panel();
            this.tabCharts = new System.Windows.Forms.TabControl();
            this.tabByCategory = new System.Windows.Forms.TabPage();
            this.chartByCategory = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabByMonth = new System.Windows.Forms.TabPage();
            this.chartByMonth = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnManageCategories = new System.Windows.Forms.Button();
            this.pnlToday.SuspendLayout();
            this.pnlMonth.SuspendLayout();
            this.pnlFiltered.SuspendLayout();
            this.grpExpenses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpenses)).BeginInit();
            this.pnlChart.SuspendLayout();
            this.tabCharts.SuspendLayout();
            this.tabByCategory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartByCategory)).BeginInit();
            this.tabByMonth.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartByMonth)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlToday
            // 
            this.pnlToday.BackColor = System.Drawing.Color.White;
            this.pnlToday.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlToday.Controls.Add(this.lblTodayTitle);
            this.pnlToday.Controls.Add(this.lblTodayValue);
            this.pnlToday.Location = new System.Drawing.Point(10, 10);
            this.pnlToday.Name = "pnlToday";
            this.pnlToday.Size = new System.Drawing.Size(280, 70);
            this.pnlToday.TabIndex = 0;
            // 
            // lblTodayTitle
            // 
            this.lblTodayTitle.ForeColor = System.Drawing.Color.DimGray;
            this.lblTodayTitle.Location = new System.Drawing.Point(0, 8);
            this.lblTodayTitle.Name = "lblTodayTitle";
            this.lblTodayTitle.Size = new System.Drawing.Size(280, 20);
            this.lblTodayTitle.TabIndex = 0;
            this.lblTodayTitle.Text = "Today Total";
            this.lblTodayTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTodayValue
            // 
            this.lblTodayValue.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.lblTodayValue.Location = new System.Drawing.Point(0, 28);
            this.lblTodayValue.Name = "lblTodayValue";
            this.lblTodayValue.Size = new System.Drawing.Size(280, 35);
            this.lblTodayValue.TabIndex = 1;
            this.lblTodayValue.Text = "0.00";
            this.lblTodayValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlMonth
            // 
            this.pnlMonth.BackColor = System.Drawing.Color.White;
            this.pnlMonth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMonth.Controls.Add(this.lblMonthTitle);
            this.pnlMonth.Controls.Add(this.lblMonthValue);
            this.pnlMonth.Location = new System.Drawing.Point(310, 10);
            this.pnlMonth.Name = "pnlMonth";
            this.pnlMonth.Size = new System.Drawing.Size(280, 70);
            this.pnlMonth.TabIndex = 1;
            // 
            // lblMonthTitle
            // 
            this.lblMonthTitle.ForeColor = System.Drawing.Color.DimGray;
            this.lblMonthTitle.Location = new System.Drawing.Point(0, 8);
            this.lblMonthTitle.Name = "lblMonthTitle";
            this.lblMonthTitle.Size = new System.Drawing.Size(280, 20);
            this.lblMonthTitle.TabIndex = 0;
            this.lblMonthTitle.Text = "This Month Total";
            this.lblMonthTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMonthValue
            // 
            this.lblMonthValue.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.lblMonthValue.Location = new System.Drawing.Point(0, 28);
            this.lblMonthValue.Name = "lblMonthValue";
            this.lblMonthValue.Size = new System.Drawing.Size(280, 35);
            this.lblMonthValue.TabIndex = 1;
            this.lblMonthValue.Text = "0.00";
            this.lblMonthValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlFiltered
            // 
            this.pnlFiltered.BackColor = System.Drawing.Color.White;
            this.pnlFiltered.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFiltered.Controls.Add(this.lblFilteredTitle);
            this.pnlFiltered.Controls.Add(this.lblFilteredValue);
            this.pnlFiltered.Location = new System.Drawing.Point(610, 10);
            this.pnlFiltered.Name = "pnlFiltered";
            this.pnlFiltered.Size = new System.Drawing.Size(280, 70);
            this.pnlFiltered.TabIndex = 2;
            // 
            // lblFilteredTitle
            // 
            this.lblFilteredTitle.ForeColor = System.Drawing.Color.DimGray;
            this.lblFilteredTitle.Location = new System.Drawing.Point(0, 8);
            this.lblFilteredTitle.Name = "lblFilteredTitle";
            this.lblFilteredTitle.Size = new System.Drawing.Size(280, 20);
            this.lblFilteredTitle.TabIndex = 0;
            this.lblFilteredTitle.Text = "Filtered Total";
            this.lblFilteredTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFilteredValue
            // 
            this.lblFilteredValue.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.lblFilteredValue.Location = new System.Drawing.Point(0, 28);
            this.lblFilteredValue.Name = "lblFilteredValue";
            this.lblFilteredValue.Size = new System.Drawing.Size(280, 35);
            this.lblFilteredValue.TabIndex = 1;
            this.lblFilteredValue.Text = "0.00";
            this.lblFilteredValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlLine1
            // 
            this.pnlLine1.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlLine1.Location = new System.Drawing.Point(10, 90);
            this.pnlLine1.Name = "pnlLine1";
            this.pnlLine1.Size = new System.Drawing.Size(880, 1);
            this.pnlLine1.TabIndex = 3;
            // 
            // pnlLine2
            // 
            this.pnlLine2.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlLine2.Location = new System.Drawing.Point(10, 180);
            this.pnlLine2.Name = "pnlLine2";
            this.pnlLine2.Size = new System.Drawing.Size(880, 1);
            this.pnlLine2.TabIndex = 12;
            // 
            // lblFrom
            // 
            this.lblFrom.Location = new System.Drawing.Point(20, 110);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(45, 23);
            this.lblFrom.TabIndex = 4;
            this.lblFrom.Text = "From:";
            // 
            // dtpFrom
            // 
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(70, 110);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(120, 31);
            this.dtpFrom.TabIndex = 5;
            // 
            // lblTo
            // 
            this.lblTo.Location = new System.Drawing.Point(210, 110);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(25, 23);
            this.lblTo.TabIndex = 6;
            this.lblTo.Text = "To:";
            // 
            // dtpTo
            // 
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(240, 110);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(120, 31);
            this.dtpTo.TabIndex = 7;
            // 
            // lblCategory
            // 
            this.lblCategory.Location = new System.Drawing.Point(385, 110);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(65, 23);
            this.lblCategory.TabIndex = 8;
            this.lblCategory.Text = "Category:";
            // 
            // cmbCategory
            // 
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.Items.AddRange(new object[] {
            "All",
            "Food",
            "Transport",
            "Shopping",
            "Utilities"});
            this.cmbCategory.Location = new System.Drawing.Point(456, 107);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(150, 33);
            this.cmbCategory.TabIndex = 9;
           
            // 
            // btnFilter
            // 
            this.btnFilter.BackColor = System.Drawing.Color.SteelBlue;
            this.btnFilter.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilter.ForeColor = System.Drawing.Color.White;
            this.btnFilter.Location = new System.Drawing.Point(330, 140);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(90, 28);
            this.btnFilter.TabIndex = 10;
            this.btnFilter.Text = "Filter";
            this.btnFilter.UseVisualStyleBackColor = false;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Gainsboro;
            this.btnClear.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Location = new System.Drawing.Point(430, 140);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(90, 28);
            this.btnClear.TabIndex = 11;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // grpExpenses
            // 
            this.grpExpenses.Controls.Add(this.dgvExpenses);
            this.grpExpenses.Location = new System.Drawing.Point(10, 190);
            this.grpExpenses.Name = "grpExpenses";
            this.grpExpenses.Size = new System.Drawing.Size(560, 230);
            this.grpExpenses.TabIndex = 13;
            this.grpExpenses.TabStop = false;
            this.grpExpenses.Text = "Expenses";
            // 
            // dgvExpenses
            // 
            this.dgvExpenses.AllowUserToAddRows = false;
            this.dgvExpenses.AllowUserToDeleteRows = false;
            this.dgvExpenses.AutoGenerateColumns = false;
            this.dgvExpenses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvExpenses.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvExpenses.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvExpenses.ColumnHeadersHeight = 34;
            this.dgvExpenses.Columns.Clear();
            this.dgvExpenses.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.dgvExpenses.EnableHeadersVisualStyles = false;
            this.dgvExpenses.Location = new System.Drawing.Point(10, 25);
            this.dgvExpenses.MultiSelect = false;
            this.dgvExpenses.Name = "dgvExpenses";
            this.dgvExpenses.ReadOnly = true;
            this.dgvExpenses.RowHeadersVisible = false;
            this.dgvExpenses.RowHeadersWidth = 62;
            this.dgvExpenses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvExpenses.Size = new System.Drawing.Size(540, 195);
            this.dgvExpenses.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Date";
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Date";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn1.Name = "Date";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Category";
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Category";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn2.Name = "Category";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Amount";
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Amount";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn3.Name = "Amount";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Note";
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Note";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn4.Name = "Note";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.SteelBlue;
            this.btnAdd.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Location = new System.Drawing.Point(10, 435);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(90, 30);
            this.btnAdd.TabIndex = 14;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.Gainsboro;
            this.btnEdit.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Location = new System.Drawing.Point(110, 435);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(90, 30);
            this.btnEdit.TabIndex = 15;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.ForeColor = System.Drawing.Color.Black;
            this.btnDelete.Location = new System.Drawing.Point(210, 435);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(90, 30);
            this.btnDelete.TabIndex = 16;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // pnlChart
            // 
            this.pnlChart.BackColor = System.Drawing.Color.White;
            this.pnlChart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlChart.Controls.Add(this.tabCharts);
            this.pnlChart.Location = new System.Drawing.Point(580, 190);
            this.pnlChart.Name = "pnlChart";
            this.pnlChart.Size = new System.Drawing.Size(310, 275);
            this.pnlChart.TabIndex = 18;
            // 
            // tabCharts
            // 
            this.tabCharts.Controls.Add(this.tabByCategory);
            this.tabCharts.Controls.Add(this.tabByMonth);
            this.tabCharts.Location = new System.Drawing.Point(5, 5);
            this.tabCharts.Name = "tabCharts";
            this.tabCharts.SelectedIndex = 0;
            this.tabCharts.Size = new System.Drawing.Size(300, 265);
            this.tabCharts.TabIndex = 0;
            // 
            // tabByCategory
            // 
            this.tabByCategory.Controls.Add(this.chartByCategory);
            this.tabByCategory.Location = new System.Drawing.Point(4, 34);
            this.tabByCategory.Name = "tabByCategory";
            this.tabByCategory.Size = new System.Drawing.Size(292, 227);
            this.tabByCategory.TabIndex = 0;
            this.tabByCategory.Text = "By Category";
            // 
            // chartByCategory
            // 
            chartArea1.Name = "ChartArea1";
            this.chartByCategory.ChartAreas.Add(chartArea1);
            this.chartByCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chartByCategory.Legends.Add(legend1);
            this.chartByCategory.Location = new System.Drawing.Point(0, 0);
            this.chartByCategory.Name = "chartByCategory";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartByCategory.Series.Add(series1);
            this.chartByCategory.Size = new System.Drawing.Size(292, 227);
            this.chartByCategory.TabIndex = 0;
            // 
            // tabByMonth
            // 
            this.tabByMonth.Controls.Add(this.chartByMonth);
            this.tabByMonth.Location = new System.Drawing.Point(4, 34);
            this.tabByMonth.Name = "tabByMonth";
            this.tabByMonth.Size = new System.Drawing.Size(292, 227);
            this.tabByMonth.TabIndex = 1;
            this.tabByMonth.Text = "By Month";
            // 
            // chartByMonth
            // 
            chartArea2.Name = "ChartArea1";
            this.chartByMonth.ChartAreas.Add(chartArea2);
            this.chartByMonth.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.chartByMonth.Legends.Add(legend2);
            this.chartByMonth.Location = new System.Drawing.Point(0, 0);
            this.chartByMonth.Name = "chartByMonth";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartByMonth.Series.Add(series2);
            this.chartByMonth.Size = new System.Drawing.Size(292, 227);
            this.chartByMonth.TabIndex = 0;
            // 
            // btnManageCategories
            // 
            this.btnManageCategories.BackColor = System.Drawing.Color.Gainsboro;
            this.btnManageCategories.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnManageCategories.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageCategories.Location = new System.Drawing.Point(310, 435);
            this.btnManageCategories.Name = "btnManageCategories";
            this.btnManageCategories.Size = new System.Drawing.Size(140, 30);
            this.btnManageCategories.TabIndex = 17;
            this.btnManageCategories.Text = "Manage Categories";
            this.btnManageCategories.UseVisualStyleBackColor = false;
            this.btnManageCategories.Click += new System.EventHandler(this.btnManageCategories_Click);
            // 
            // FrmDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(971, 531);
            this.Controls.Add(this.pnlToday);
            this.Controls.Add(this.pnlMonth);
            this.Controls.Add(this.pnlFiltered);
            this.Controls.Add(this.pnlLine1);
            this.Controls.Add(this.lblFrom);
            this.Controls.Add(this.dtpFrom);
            this.Controls.Add(this.lblTo);
            this.Controls.Add(this.dtpTo);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.pnlLine2);
            this.Controls.Add(this.grpExpenses);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnManageCategories);
            this.Controls.Add(this.pnlChart);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Expense Management System";
            
            this.pnlToday.ResumeLayout(false);
            this.pnlMonth.ResumeLayout(false);
            this.pnlFiltered.ResumeLayout(false);
            this.grpExpenses.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpenses)).EndInit();
            this.pnlChart.ResumeLayout(false);
            this.tabCharts.ResumeLayout(false);
            this.tabByCategory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartByCategory)).EndInit();
            this.tabByMonth.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartByMonth)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
    }
}
