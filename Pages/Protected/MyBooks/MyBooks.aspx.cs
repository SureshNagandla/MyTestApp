using MyTestApp.DAL;
using System;
using System.Data;
using System.Web.UI;

namespace MyTestApp.Pages.Protected.MyBooks
{
    public partial class MyBooks : Page
    {
        private readonly BorrowRepository borrowRepo = new BorrowRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null) Response.Redirect("~/Pages/Public/Login.aspx");
            if (!IsPostBack) BindMyBooks();
        }

        private void BindMyBooks()
        {
            int userId = Convert.ToInt32(Session["UserId"]);
            var dt = borrowRepo.GetBorrowRecordsForUser(userId);
            gvMyBooks.DataSource = dt;
            gvMyBooks.DataBind();
        }
    }
}
