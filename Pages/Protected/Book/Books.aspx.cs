using MyTestApp.DAL;
using NLog;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace MyTestApp.Pages.Protected.Book
{
    public partial class Books : System.Web.UI.Page
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private readonly BookRepository repo = new BookRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindBooks();
                if (Session["Role"] != null && (Session["Role"].ToString() == "Member" || Session["Role"].ToString() == "Librarian"))
                {
                    btnCreate.Visible = false;
                }

            }
        }

        private void BindBooks()
        {
            var dt = repo.GetAllBooksWithDetails();
            gvBooks.DataSource = dt;
            gvBooks.DataBind();
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Protected/Book/Create.aspx");
        }

        protected void gvBooks_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int bookId = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Details")
            {
                Response.Redirect($"~/Pages/Protected/Book/Details.aspx?bookId={bookId}");
            }
            else if (e.CommandName == "EditBook")
            {
                Response.Redirect($"~/Pages/Protected/Book/Edit.aspx?bookId={bookId}");
            }
            else if (e.CommandName == "DeleteBook")
            {
                repo.DeleteBook(bookId);
                logger.Info($"User {Session["Username"]} deleted book {bookId}");
                BindBooks();
            }
        }
    }
}
