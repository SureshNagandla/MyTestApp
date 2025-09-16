-- Seed.sql
USE LibraryDB;
GO
INSERT INTO Authors (Name) VALUES ('J. K. Rowling'), ('George Orwell'), ('J. R. R. Tolkien');
GO
INSERT INTO Categories (Name) VALUES ('Fantasy'), ('Science Fiction'), ('Programming'), ('History');
GO
INSERT INTO Books (Title, AuthorId, CategoryId, ISBN)
VALUES 
('Harry Potter and the Sorcerer''s Stone', 1, 1, '9780439708180'),
('1984', 2, 2, '9780451524935'),
('The Hobbit', 3, 1, '9780547928227');
GO
