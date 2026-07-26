
# Expense Management System

A desktop expense-tracking application built with **C# Windows Forms** and **SQLite**. The system allows users to record, update, delete, filter, and analyze personal expenses through a simple dashboard.

## Features

- Add new expenses with a date, amount, category, and note
- Edit existing expense records
- Delete expenses with a confirmation message
- Create and delete custom expense categories
- Filter expenses by:
  - Start date
  - End date
  - Category
- Display expense totals for:
  - Today
  - The current month
  - The selected filter
- View expenses in a structured table
- Visualize spending using:
  - A pie chart grouped by category
  - A column chart for the current month
- Automatically create the local SQLite database
- Automatically add default categories on first launch

## Technologies Used

- **C#**
- **.NET Framework 4.7.2**
- **Windows Forms**
- **SQLite**
- **System.Data.SQLite**
- **Windows Forms DataVisualization**
- **Visual Studio**

## Default Categories

When the application is launched for the first time, it creates the following categories:

- Food
- Transport
- Shopping
- Utilities

Users can add or remove categories from the category-management window.

## Project Structure

```text
ExpenseManagmentSystemProject/
├── DAL/
│   ├── CategoryDAL.cs
│   ├── DatabaseHelper.cs
│   ├── ExpensesDAL.cs
│   ├── Inserting.sql
│   └── tables.sql
├── UI/
│   ├── FrmCategories.cs
│   ├── FrmCategories.Designer.cs
│   ├── FrmDashboard.cs
│   ├── FrmDashboard.Designer.cs
│   ├── FrmExpenseAddEdit.cs
│   └── FrmExpenseAddEdit.Designer.cs
├── Properties/
├── App.config
├── ExpenseManagmentSystem.csproj
├── ExpenseManagmentSystem.sln
├── packages.config
└── Program.cs
```

## Application Architecture

The project separates the user interface from database operations.

### User Interface Layer

The `UI` folder contains the Windows Forms used by the application:

- `FrmDashboard` — displays expenses, filters, totals, and charts
- `FrmExpenseAddEdit` — adds or updates an expense
- `FrmCategories` — manages expense categories

### Data Access Layer

The `DAL` folder contains the database logic:

- `DatabaseHelper` — creates the SQLite database, tables, and default categories
- `ExpensesDAL` — handles expense creation, reading, updating, deletion, filtering, and totals
- `CategoryDAL` — handles category creation, retrieval, and deletion

## Database

The application uses a local SQLite database named:

```text
ExpenseDB.db
```

The database is created automatically in the application's executable directory when the program starts.

### Categories Table

| Column | Description |
|---|---|
| `CategoryId` | Unique category identifier |
| `Name` | Unique category name |

### Expenses Table

| Column | Description |
|---|---|
| `ExpenseId` | Unique expense identifier |
| `ExpenseDate` | Date of the expense |
| `Amount` | Expense amount |
| `CategoryId` | Related category identifier |
| `Note` | Optional expense description |

connected to existing expense records may need its related expenses removed or reassigned before deletion.

## Validation

The application includes basic validation:

- Expense amounts must be greater than zero
- A category must be selected
- Duplicate category names are prevented by the database
- Users must select an expense before editing or deleting it
- Delete operations require confirmation

## Possible Future Improvements

- User accounts and authentication
- Monthly budgets and spending limits
- Exporting reports to PDF, Excel, or CSV
- Advanced reports for weekly, monthly, and yearly spending
- Recurring expense support
- Search by expense note
- Additional chart types
- Dark mode
- Cloud database synchronization
- Improved category deletion handling
- Unit and integration testing

## License

This project was created for educational purposes. 
