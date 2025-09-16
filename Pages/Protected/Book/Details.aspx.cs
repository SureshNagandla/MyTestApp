using System;
using System.Data;
using System.Web.UI;
using System.Data.SqlClient;

namespace MyTestApp.Pages.Protected.Book
{
    public partial class Details : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int bookId = 0;
                if (int.TryParse(Request.QueryString["bookId"], out bookId) && bookId>0)
                {
                    LoadDetails(bookId);
                }
            }
        }

        private void LoadDetails(int bookId)
        {
            using (var conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LibraryDB"].ConnectionString))
            using (var cmd = new SqlCommand(@"SELECT b.Title, a.Name as AuthorName, c.Name as CategoryName, b.ISBN, b.AddedDate
                                             FROM Books b JOIN Authors a ON b.AuthorId=a.AuthorId
                                             JOIN Categories c ON b.CategoryId=c.CategoryId WHERE b.BookId=@BookId", conn))
            {
                cmd.Parameters.AddWithValue("@BookId", bookId);
                conn.Open();
                using (var r = cmd.ExecuteReader())
                {
                    if (r.Read())
                    {
                        lblTitle.Text = r["Title"].ToString();
                        lblAuthor.Text = "Author: " + r["AuthorName"].ToString();
                        lblCategory.Text = "Category: " + r["CategoryName"].ToString();
                        lblISBN.Text = "ISBN: " + r["ISBN"].ToString();
                        lblAdded.Text = "Added: " + Convert.ToDateTime(r["AddedDate"]).ToString("yyyy-MM-dd");
                    }
                }
            }
        }
    }
}
