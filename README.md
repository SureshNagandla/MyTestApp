# 📚 Library Management System

A simple **ASP.NET Web Forms** project with **SQL Server** backend to manage books, users, and borrow/return records.

---

## 🚀 Features
- User authentication (Admin, Librarian, Member roles)
- Add, update, delete books
- Borrow and return books
- Role-based UI (different menus for Admin, Librarian, Member)
- Error handling with NLog
- SQL Server database with stored procedures

---

## 🗂 Project Structure
- **Pages/** → ASPX pages (Login, Register, Books, BorrowRecords, etc.)
- **App_Code/** → Helpers (PasswordHelper, DB logic)
- **Pages/Error/** → Error pages (`GenericError.aspx`)
- **Database/** → SQL scripts (Tables, Stored Procedures, Views)
- **README.md** → Project documentation (this file)

---

## ⚙️ Requirements
- Visual Studio (2019/2022)
- .NET Framework 4.7.2 (or compatible)
- SQL Server 2019 or later

---

## 🔑 Default Users
```sql
INSERT INTO Users (Username, FullName, PasswordHash, Role, CreatedDate)
VALUES 
('admin', 'System Admin', 'jGl25bVBBBW96Qi9Te4V37Fnqchz/Eu4qB9vKrRIqRg=', 'Admin', GETDATE());
