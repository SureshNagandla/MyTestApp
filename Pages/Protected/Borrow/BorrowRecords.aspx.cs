using MyTestApp.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2.Pages.Protected.Borrow
{
    public partial class BorrowRecords : System.Web.UI.Page
    {
        private readonly BorrowRepository borrowRepo = new BorrowRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            // Restrict to librarians
            if (Session["Role"] == null || Session["Role"].ToString() != "Librarian")
            {
                Response.Redirect("~/Pages/Public/Login.aspx");
                return;
            }

            if (!IsPostBack)
                LoadRecords();
        }

        private void LoadRecords()
        {
            gvBorrowRecords.DataSource = borrowRepo.GetAllBorrowRecords();
            gvBorrowRecords.DataBind();
        }

        protected void gvBorrowRecords_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Return")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                int borrowId = Convert.ToInt32(gvBorrowRecords.DataKeys[rowIndex].Value);

                try
                {
                    borrowRepo.MarkAsReturned(borrowId);
                    lblMessage.Text = "Book marked as returned successfully.";
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "Error updating record: " + ex.Message;
                }

                LoadRecords();
            }
        }
    }
}