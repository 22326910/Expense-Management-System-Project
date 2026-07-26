using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExpenseManagementSystem.UI;
using ExpenseManagementSystem.DAL;

namespace ExpenseManagmentSystem.UI
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

           

            // Create DB + tables + seed categories
            DatabaseHelper.CreateDatabase();


            Application.Run(new FrmDashboard());
        }
    }
}
