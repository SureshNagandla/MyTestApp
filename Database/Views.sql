-- Views.sql
USE LibraryDB;
GO
CREATE VIEW vw_BooksWithAuthorCategory
AS
SELECT b.BookId, b.Title, a.AuthorId, a.Name AS AuthorName, c.CategoryId, c.Name AS CategoryName, b.ISBN, b.AddedDate
FROM Books b
JOIN Authors a ON b.AuthorId = a.AuthorId
JOIN Categories c ON b.CategoryId = c.CategoryId;
GO
