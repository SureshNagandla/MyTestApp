using MyTestApp.DAL;
using NLog;
using System;
using System.Data;
using System.Web.UI;

namespace MyTestApp.Pages.Protected.Borrow
{
    public partial class Borrow : Page
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private readonly BookRepository bookRepo = new BookRepository();
        private readonly BorrowRepository borrowRepo = new BorrowRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null) Response.Redirect("~/Pages/Public/Login.aspx");
            if (!IsPostBack)
            {
                var dt = bookRepo.GetAllBooksWithDetails();
                ddlBooks.DataSource = dt;
                ddlBooks.DataTextField = "Title";
                ddlBooks.DataValueField = "BookId";
                ddlBooks.DataBind();
            }
        }

        protected void btnBorrow_Click(object sender, EventArgs e)
        {
            int userId = Convert.ToInt32(Session["UserId"]);
            int bookId = Convert.ToInt32(ddlBooks.SelectedValue);
            int borrowId = borrowRepo.BorrowBook(userId, bookId);
            lblMsg.CssClass = "text-success";
            lblMsg.Text = "Book borrowed successfully.";
            logger.Info($"User {Session["Username"]} borrowed bookId {bookId} (BorrowId {borrowId})");
        }
    }
}
