using System.Data;
using System.Data.SQLite;

namespace ExpenseManagementSystem.DAL
{
    public class CategoryDAL
    {
        public DataTable GetAllCategories()
        {
            using (var con = new SQLiteConnection(DatabaseHelper.ConStr))
            {
                con.Open();
                using (var da = new SQLiteDataAdapter("SELECT CategoryId, Name FROM Categories ORDER BY Name;", con))
                {
                    var dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public void AddCategory(string name)
        {
            using (var con = new SQLiteConnection(DatabaseHelper.ConStr))
            {
                con.Open();
                using (var cmd = new SQLiteCommand("INSERT INTO Categories(Name) VALUES(@Name);", con))
                {
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteCategory(int categoryId)
        {
            using (var con = new SQLiteConnection(DatabaseHelper.ConStr))
            {
                con.Open();
                using (var cmd = new SQLiteCommand("DELETE FROM Categories WHERE CategoryId=@Id;", con))
                {
                    cmd.Parameters.AddWithValue("@Id", categoryId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
