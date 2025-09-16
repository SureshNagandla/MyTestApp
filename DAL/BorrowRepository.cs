using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MyTestApp.DAL
{
    public class BorrowRepository
    {
        private readonly string _connString;

        public BorrowRepository()
        {
            _connString = ConfigurationManager.ConnectionStrings["LibraryDB"].ConnectionString;
        }

        public int BorrowBook(int userId, int bookId)
        {
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand("sp_BorrowBook", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.Parameters.AddWithValue("@BookId", bookId);
                conn.Open();
                var obj = cmd.ExecuteScalar();
                return obj == null ? 0 : Convert.ToInt32(obj);
            }
        }

        public void ReturnBook(int borrowId)
        {
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand("sp_ReturnBook", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BorrowId", borrowId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable GetBorrowRecordsForUser(int userId)
        {
            var dt = new DataTable();
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(@"SELECT br.Id, b.Title, br.BorrowDate, br.ReturnDate
                                             FROM BorrowRecords br
                                             JOIN Books b ON br.BookId=b.BookId
                                             WHERE br.UserId=@UserId ORDER BY br.BorrowDate DESC", conn))
            {
                cmd.Parameters.AddWithValue("@UserId", userId);
                using (var da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }
            return dt;
        }
    }
}
