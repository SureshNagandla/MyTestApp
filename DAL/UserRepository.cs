using MyTestApp.Models;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MyTestApp.DAL
{
    public class UserRepository
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["LibraryDB"].ConnectionString;

        // Create user: store only hashed password as string
        public int CreateUser(User user, string passwordHash)
        {
            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand("sp_RegisterUser", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Username", user.Username);
                cmd.Parameters.AddWithValue("@FullName", user.FullName);
                cmd.Parameters.AddWithValue("@PasswordHash", passwordHash);
                cmd.Parameters.AddWithValue("@Role", user.Role);
                conn.Open();
                var obj = cmd.ExecuteScalar();
                return obj == null ? 0 : Convert.ToInt32(obj);
            }
        }

        // Get user by username
        public User GetUserByUsername(string username)
        {
            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand("sp_GetUserByUsername", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Username", username);
                using (var da = new SqlDataAdapter(cmd))
                {
                    var dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count == 0) return null;

                    var r = dt.Rows[0];
                    return new User
                    {
                        Id = (int)r["Id"],
                        Username = r["Username"].ToString(),
                        FullName = r["FullName"].ToString(),
                        PasswordHash = r["PasswordHash"].ToString(),
                        Role = r["Role"].ToString()
                    };
                }
            }
        }
    }
}
