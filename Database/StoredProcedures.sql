-- StoredProcedures.sql
USE LibraryDB;
GO

CREATE PROCEDURE sp_AddBook
    @Title NVARCHAR(500),
    @AuthorId INT,
    @CategoryId INT,
    @ISBN NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO Books (Title, AuthorId, CategoryId, ISBN) VALUES (@Title, @AuthorId, @CategoryId, @ISBN);
    SELECT SCOPE_IDENTITY() AS NewBookId;
END
GO

CREATE PROCEDURE sp_UpdateBook
    @BookId INT,
    @Title NVARCHAR(500),
    @AuthorId INT,
    @CategoryId INT,
    @ISBN NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE Books
    SET Title=@Title, AuthorId=@AuthorId, CategoryId=@CategoryId, ISBN=@ISBN
    WHERE BookId=@BookId;
END
GO

CREATE PROCEDURE sp_DeleteBook
    @BookId INT
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM Books WHERE BookId=@BookId;
END
GO

CREATE PROCEDURE sp_GetAllBooksWithDetails
AS
BEGIN
    SET NOCOUNT ON;
    SELECT b.BookId, b.Title, a.AuthorId, a.Name AS AuthorName, c.CategoryId, c.Name AS CategoryName, b.ISBN, b.AddedDate
    FROM Books b
    INNER JOIN Authors a ON b.AuthorId=a.AuthorId
    INNER JOIN Categories c ON b.CategoryId=c.CategoryId
    ORDER BY b.Title;
END
GO

CREATE PROCEDURE sp_RegisterUser
    @Username NVARCHAR(100),
    @FullName NVARCHAR(200),
    @PasswordHash VARBINARY(MAX),
    @PasswordSalt VARBINARY(256),
    @Role NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO Users (Username, FullName, PasswordHash, PasswordSalt, Role) VALUES (@Username, @FullName, @PasswordHash, @PasswordSalt, @Role);
    SELECT SCOPE_IDENTITY() AS NewUserId;
END
GO

CREATE PROCEDURE sp_GetUserByUsername
    @Username NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT Id, Username, FullName, PasswordHash, PasswordSalt, Role, CreatedDate FROM Users WHERE Username=@Username;
END
GO

CREATE PROCEDURE sp_BorrowBook
    @UserId INT,
    @BookId INT
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO BorrowRecords (UserId, BookId, BorrowDate) VALUES (@UserId, @BookId);
    SELECT SCOPE_IDENTITY() AS BorrowId;
END
GO

CREATE PROCEDURE sp_ReturnBook
    @BorrowId INT
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE BorrowRecords SET ReturnDate = GETDATE() WHERE Id = @BorrowId;
END
GO
