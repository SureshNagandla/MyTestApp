using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyTestApp.Pages.Protected
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Sign out the user
            FormsAuthentication.SignOut();

            // Clear session
            Session.Clear();
            Session.Abandon();

            // Optional: clear authentication cookie manually
            HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, "");
            authCookie.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(authCookie);

            // Redirect to login page or public landing page
            Response.Redirect("~/Default.aspx");
        }
    }
}