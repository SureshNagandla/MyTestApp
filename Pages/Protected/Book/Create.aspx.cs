using MyTestApp.DAL;
using NLog;
using System;
using System.Data;
using System.Web.UI;

namespace MyTestApp.Pages.Protected.Book
{
    public partial class Create : Page
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private readonly BookRepository repo = new BookRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadAuthors();
                LoadCategories();
            }
        }

        private void LoadAuthors()
        {
            var dt = new DataTable();
            using (var conn = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LibraryDB"].ConnectionString))
            using (var cmd = new System.Data.SqlClient.SqlCommand("SELECT AuthorId, Name FROM Authors ORDER BY Name", conn))
            using (var da = new System.Data.SqlClient.SqlDataAdapter(cmd))
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
            using (var conn = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LibraryDB"].ConnectionString))
            using (var cmd = new System.Data.SqlClient.SqlCommand("SELECT CategoryId, Name FROM Categories ORDER BY Name", conn))
            using (var da = new System.Data.SqlClient.SqlDataAdapter(cmd))
            {
                da.Fill(dt);
            }
            ddlCategory.DataSource = dt;
            ddlCategory.DataTextField = "Name";
            ddlCategory.DataValueField = "CategoryId";
            ddlCategory.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text.Trim();
            int authorId = int.Parse(ddlAuthor.SelectedValue);
            int categoryId = int.Parse(ddlCategory.SelectedValue);
            string isbn = txtISBN.Text.Trim();

            int newId = repo.AddBook(title, authorId, categoryId, isbn);

            lblMsg.CssClass = "text-success";
            lblMsg.Text = "Book added successfully.";
            logger.Info($"User {Session["Username"]} added book '{title}' (Id: {newId})");
        }
    }
}
