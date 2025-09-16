-- Tables.sql - LibraryDB
IF EXISTS (SELECT name FROM sys.databases WHERE name = N'LibraryDB')
BEGIN
    PRINT 'Database LibraryDB already exists. Skipping create.'
END
ELSE
BEGIN
    CREATE DATABASE LibraryDB
    ON PRIMARY (
        NAME = LibraryDB_Data,
        FILENAME = 'C:\SQLData\LibraryDB.mdf',
        SIZE = 50MB,
        MAXSIZE = 500MB,
        FILEGROWTH = 10MB
    )
    LOG ON (
        NAME = LibraryDB_Log,
        FILENAME = 'C:\SQLLogs\LibraryDB_log.ldf',
        SIZE = 25MB,
        MAXSIZE = 200MB,
        FILEGROWTH = 10MB
    );
    PRINT 'Database created at C:\SQLData\LibraryDB.mdf'
END
GO

USE LibraryDB;
GO

CREATE TABLE Users (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(100) NOT NULL UNIQUE,
    FullName NVARCHAR(200) NOT NULL,
    PasswordHash VARBINARY(MAX) NOT NULL,
    PasswordSalt VARBINARY(256) NOT NULL,
    Role NVARCHAR(50) NOT NULL,
    CreatedDate DATETIME NOT NULL DEFAULT(GETDATE())
);
GO

CREATE TABLE Authors (
    AuthorId INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(200) NOT NULL,
    CreatedDate DATETIME NOT NULL DEFAULT(GETDATE())
);
GO

CREATE TABLE Categories (
    CategoryId INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(200) NOT NULL,
    CreatedDate DATETIME NOT NULL DEFAULT(GETDATE())
);
GO

CREATE TABLE Books (
    BookId INT IDENTITY(1,1) PRIMARY KEY,
    Title NVARCHAR(500) NOT NULL,
    AuthorId INT NOT NULL,
    CategoryId INT NOT NULL,
    ISBN NVARCHAR(20) NULL,
    AddedDate DATETIME NOT NULL DEFAULT(GETDATE()),
    CONSTRAINT FK_Books_Authors FOREIGN KEY (AuthorId) REFERENCES Authors(AuthorId) ON DELETE CASCADE,
    CONSTRAINT FK_Books_Categories FOREIGN KEY (CategoryId) REFERENCES Categories(CategoryId) ON DELETE CASCADE
);
GO

CREATE TABLE BorrowRecords (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    UserId INT NOT NULL,
    BookId INT NOT NULL,
    BorrowDate DATETIME NOT NULL DEFAULT(GETDATE()),
    ReturnDate DATETIME NULL,
    CONSTRAINT FK_Borrow_User FOREIGN KEY (UserId) REFERENCES Users(Id) ON DELETE CASCADE,
    CONSTRAINT FK_Borrow_Book FOREIGN KEY (BookId) REFERENCES Books(BookId) ON DELETE CASCADE
);
GO

CREATE INDEX IX_Books_Title ON Books(Title);
CREATE INDEX IX_Borrow_UserId ON BorrowRecords(UserId);
CREATE INDEX IX_Books_ISBN ON Books(ISBN);
GO
