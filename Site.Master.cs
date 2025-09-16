using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bool isAuthenticated = Context.User.Identity.IsAuthenticated;

            // Show Register menu only for Admin
            liRegister.Visible = isAuthenticated && Context.User.IsInRole("Admin");
            liBooks.Visible = isAuthenticated & (Context.User.IsInRole("Admin") || Context.User.IsInRole("Librarian"));

            // Toggle login/logout buttons
            btnLogout.Visible = isAuthenticated;
            btnLogin.Visible = !isAuthenticated;

            // Show welcome text
            lblWelcome.Text = isAuthenticated
                ? "Welcome, " + (Session["FullName"] ?? Context.User.Identity.Name)
                : string.Empty;
        }
    }
}