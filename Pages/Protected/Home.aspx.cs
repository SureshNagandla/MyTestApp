using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyTestApp.Pages.Protected
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.Identity.IsAuthenticated)
            {
                lblUsername.Text = User.Identity.Name;
                lblRole.Text = Session["Role"].ToString();
            }
            else
            {
                Response.Redirect("~/Pages/Public/Login.aspx");
            }
        }
    }
}