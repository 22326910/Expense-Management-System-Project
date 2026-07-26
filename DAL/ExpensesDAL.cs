using System;
using System.Data;
using System.Data.SQLite;

namespace ExpenseManagementSystem.DAL
{
    public class ExpensesDAL
    {
        public DataTable GetExpenses(DateTime from, DateTime to, int categoryIdOrZero)
        {
            using (var con = new SQLiteConnection(DatabaseHelper.ConStr))
            {
                con.Open();

                string sql =
                    @"SELECT e.ExpenseId,
                             e.ExpenseDate AS Date,
                             c.Name AS Category,
                             e.Amount,
                             e.Note,
                             e.CategoryId
                      FROM Expenses e
                      JOIN Categories c ON c.CategoryId = e.CategoryId
                      WHERE date(e.ExpenseDate) >= date(@From)
                        AND date(e.ExpenseDate) <= date(@To)
                        AND (@CatId = 0 OR e.CategoryId=@CatId)
                      ORDER BY date(e.ExpenseDate) DESC;";

                using (var cmd = new SQLiteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@From", from.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@To", to.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@CatId", categoryIdOrZero);

                    using (var da = new SQLiteDataAdapter(cmd))
                    {
                        var dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        public DataRow GetExpenseById(int expenseId)
        {
            using (var con = new SQLiteConnection(DatabaseHelper.ConStr))
            {
                con.Open();
                using (var cmd = new SQLiteCommand(
                    @"SELECT ExpenseId, ExpenseDate, Amount, CategoryId, Note
                      FROM Expenses WHERE ExpenseId=@Id;", con))
                {
                    cmd.Parameters.AddWithValue("@Id", expenseId);
                    using (var da = new SQLiteDataAdapter(cmd))
                    {
                        var dt = new DataTable();
                        da.Fill(dt);
                        return dt.Rows.Count > 0 ? dt.Rows[0] : null;
                    }
                }
            }
        }

        public void AddExpense(DateTime date, decimal amount, int categoryId, string note)
        {
            using (var con = new SQLiteConnection(DatabaseHelper.ConStr))
            {
                con.Open();
                using (var cmd = new SQLiteCommand(
                    @"INSERT INTO Expenses(ExpenseDate, Amount, CategoryId, Note)
                      VALUES(@Date, @Amount, @CatId, @Note);", con))
                {
                    cmd.Parameters.AddWithValue("@Date", date.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@Amount", amount);
                    cmd.Parameters.AddWithValue("@CatId", categoryId);
                    cmd.Parameters.AddWithValue("@Note", note ?? "");
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateExpense(int expenseId, DateTime date, decimal amount, int categoryId, string note)
        {
            using (var con = new SQLiteConnection(DatabaseHelper.ConStr))
            {
                con.Open();
                using (var cmd = new SQLiteCommand(
                    @"UPDATE Expenses
                      SET ExpenseDate=@Date, Amount=@Amount, CategoryId=@CatId, Note=@Note
                      WHERE ExpenseId=@Id;", con))
                {
                    cmd.Parameters.AddWithValue("@Date", date.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@Amount", amount);
                    cmd.Parameters.AddWithValue("@CatId", categoryId);
                    cmd.Parameters.AddWithValue("@Note", note ?? "");
                    cmd.Parameters.AddWithValue("@Id", expenseId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteExpense(int expenseId)
        {
            using (var con = new SQLiteConnection(DatabaseHelper.ConStr))
            {
                con.Open();
                using (var cmd = new SQLiteCommand("DELETE FROM Expenses WHERE ExpenseId=@Id;", con))
                {
                    cmd.Parameters.AddWithValue("@Id", expenseId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public decimal GetTotal(DateTime from, DateTime to, int categoryIdOrZero)
        {
            using (var con = new SQLiteConnection(DatabaseHelper.ConStr))
            {
                con.Open();
                using (var cmd = new SQLiteCommand(
                    @"SELECT IFNULL(SUM(Amount),0)
                      FROM Expenses
                      WHERE date(ExpenseDate) >= date(@From)
                        AND date(ExpenseDate) <= date(@To)
                        AND (@CatId = 0 OR CategoryId=@CatId);", con))
                {
                    cmd.Parameters.AddWithValue("@From", from.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@To", to.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@CatId", categoryIdOrZero);
                    return Convert.ToDecimal(cmd.ExecuteScalar());
                }
            }
        }
    }
}
