using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MyTestApp.DAL
{
    public class BookRepository
    {
        private readonly string _connString;

        public BookRepository()
        {
            _connString = ConfigurationManager.ConnectionStrings["LibraryDB"].ConnectionString;
        }

        public DataTable GetAllBooksWithDetails()
        {
            DataTable dt = new DataTable();
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand("sp_GetAllBooksWithDetails", conn))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                da.Fill(dt);
            }
            return dt;
        }

        public int AddBook(string title, int authorId, int categoryId, string isbn)
        {
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand("sp_AddBook", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Title", title);
                cmd.Parameters.AddWithValue("@AuthorId", authorId);
                cmd.Parameters.AddWithValue("@CategoryId", categoryId);
                cmd.Parameters.AddWithValue("@ISBN", string.IsNullOrEmpty(isbn) ? (object)DBNull.Value : isbn);
                conn.Open();
                var obj = cmd.ExecuteScalar();
                return obj == null ? 0 : Convert.ToInt32(obj);
            }
        }

        public void UpdateBook(int bookId, string title, int authorId, int categoryId, string isbn)
        {
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand("sp_UpdateBook", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BookId", bookId);
                cmd.Parameters.AddWithValue("@Title", title);
                cmd.Parameters.AddWithValue("@AuthorId", authorId);
                cmd.Parameters.AddWithValue("@CategoryId", categoryId);
                cmd.Parameters.AddWithValue("@ISBN", string.IsNullOrEmpty(isbn) ? (object)DBNull.Value : isbn);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteBook(int bookId)
        {
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand("sp_DeleteBook", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BookId", bookId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
