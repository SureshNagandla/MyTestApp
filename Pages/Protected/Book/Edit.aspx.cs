using System;
using System.Data;
using System.Data.SqlClient;
using MyTestApp.DAL;
using NLog;

namespace MyTestApp.Pages.Protected.Book
{
    public partial class Edit : System.Web.UI.Page
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private readonly BookRepository repo = new BookRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadAuthors();
                LoadCategories();

                int bookId;
                if (int.TryParse(Request.QueryString["bookId"], out bookId) && bookId>0)
                {
                    LoadBook(bookId);
                }
            }
        }

        private void LoadAuthors()
        {
            var dt = new DataTable();
            using (var conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LibraryDB"].ConnectionString))
            using (var cmd = new SqlCommand("SELECT AuthorId, Name FROM Authors ORDER BY Name", conn))
            using (var da = new SqlDataAdapter(cmd))
            {
                da.Fill(dt);
            }
            ddlAuthor.DataSource = dt;
            ddlAuthor.DataTextField = "Name";
            ddlAuthor.DataValueField = "AuthorId";
            ddlAuthor.DataBind();
        }

        private void LoadCategories()
        {
            var dt = new DataTable();
            using (var conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LibraryDB"].ConnectionString))
            using (var cmd = new SqlCommand("SELECT CategoryId, Name FROM Categories ORDER BY Name", conn))
            using (var da = new SqlDataAdapter(cmd))
            {
                da.Fill(dt);
            }
            ddlCategory.DataSource = dt;
            ddlCategory.DataTextField = "Name";
            ddlCategory.DataValueField = "CategoryId";
            ddlCategory.DataBind();
        }

        private void LoadBook(int bookId)
        {
            using (var conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LibraryDB"].ConnectionString))
            using (var cmd = new SqlCommand("SELECT BookId, Title, AuthorId, CategoryId, ISBN FROM Books WHERE BookId=@BookId", conn))
            {
                cmd.Parameters.AddWithValue("@BookId", bookId);
                conn.Open();
                using (var r = cmd.ExecuteReader())
                {
                    if (r.Read())
                    {
                        txtTitle.Text = r["Title"].ToString();
                        ddlAuthor.SelectedValue = r["AuthorId"].ToString();
                        ddlCategory.SelectedValue = r["CategoryId"].ToString();
                        txtISBN.Text = r["ISBN"].ToString();
                    }
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int bookId = int.Parse(Request.QueryString["bookId"]);
            string title = txtTitle.Text.Trim();
            int authorId = int.Parse(ddlAuthor.SelectedValue);
            int categoryId = int.Parse(ddlCategory.SelectedValue);
            string isbn = txtISBN.Text.Trim();

            repo.UpdateBook(bookId, title, authorId, categoryId, isbn);
            lblMsg.CssClass = "text-success";
            lblMsg.Text = "Book updated successfully.";
            logger.Info($"User {Session["Username"]} updated book {bookId}");
        }
    }
}
