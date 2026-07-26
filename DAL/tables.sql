create table Categories (
  CategoryID int primary KEY,
  Type VARCHAR(50)
);
  
CREATE TABLE Expenses(
  ExpenseID int Primary key,
  Amount int,
  PurchaseDate date,
  CategoryID int,
  Descripation text,
  Foreign key (CategoryID) REFERENCES Categories(CategoryID)
);
