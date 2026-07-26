using System;
using System.IO;
using System.Data.SQLite;

namespace ExpenseManagementSystem.DAL
{
    public static class DatabaseHelper
    {
        public static string DbFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ExpenseDB.db");
        public static string ConStr = "Data Source=" + DbFile + ";Version=3;";

        public static void CreateDatabase()
        {
            // System.Data.SQLite creates the file automatically when you open connection
            using (var con = new SQLiteConnection(ConStr))
            {
                con.Open();

                using (var cmd = new SQLiteCommand(con))
                {
                    cmd.CommandText =
                    @"CREATE TABLE IF NOT EXISTS Categories(
                        CategoryId INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT NOT NULL UNIQUE
                      );

                      CREATE TABLE IF NOT EXISTS Expenses(
                        ExpenseId INTEGER PRIMARY KEY AUTOINCREMENT,
                        ExpenseDate TEXT NOT NULL,
                        Amount REAL NOT NULL,
                        CategoryId INTEGER NOT NULL,
                        Note TEXT,
                        FOREIGN KEY(CategoryId) REFERENCES Categories(CategoryId)
                      );";
                    cmd.ExecuteNonQuery();
                }

                // Seed default categories if empty
                using (var check = new SQLiteCommand("SELECT COUNT(*) FROM Categories;", con))
                {
                    long count = (long)check.ExecuteScalar();
                    if (count == 0)
                    {
                        using (var seed = new SQLiteCommand(
                            @"INSERT INTO Categories(Name) VALUES
                              ('Food'),('Transport'),('Shopping'),('Utilities');", con))
                        {
                            seed.ExecuteNonQuery();
                        }
                    }
                }
            }
        }
    }
}
