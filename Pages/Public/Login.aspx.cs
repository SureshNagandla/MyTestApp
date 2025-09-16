using MyTestApp.DAL;
using MyTestApp.Helpers;
using NLog;
using System;
using System.Web;
using System.Web.Security;

namespace MyTestApp.Pages.Public
{
    public partial class Login : System.Web.UI.Page
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private readonly UserRepository repo = new UserRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            var user = repo.GetUserByUsername(username);
            if (user == null || !PasswordHelper.VerifyPassword(password, user.PasswordHash))
            {
                lblMessage.Text = "Invalid username or password.";
                logger.Info($"Failed login attempt for {username} from {Request.UserHostAddress}");
                return;
            }

            // Create auth ticket
            string userData = user.Role;
            var ticket = new FormsAuthenticationTicket(1, username, DateTime.Now, DateTime.Now.AddMinutes(60), false, userData);
            string encTicket = FormsAuthentication.Encrypt(ticket);
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
            Response.Cookies.Add(cookie);

            Session["Username"] = username;
            Session["FullName"] = user.FullName;
            Session["Role"] = user.Role;
            Session["UserId"] = user.Id;

            logger.Info($"User {username} logged in.");
            Response.Redirect("~/Default.aspx");
        }
    }
}
