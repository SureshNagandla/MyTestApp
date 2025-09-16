using MyTestApp.DAL;
using MyTestApp.Models;
using MyTestApp.Helpers;
using NLog;
using System;

namespace MyTestApp.Pages.Protected.Admin
{
    public partial class Register : System.Web.UI.Page
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private readonly UserRepository repo = new UserRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Role"] == null || Session["Role"].ToString() != "Admin")
            {
                Response.Redirect("~/Pages/Public/Login.aspx");
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string fullname = txtFullName.Text.Trim();
            string role = ddlRole.SelectedValue;
            string password = txtPassword.Text;

            // Hash password only
            string hash = PasswordHelper.HashPassword(password);

            var user = new User { Username = username, FullName = fullname, Role = role };
            int newId = repo.CreateUser(user, hash);

            lblMsg.CssClass = "text-success";
            lblMsg.Text = "User registered successfully.";

            logger.Info($"Admin {Session["Username"]} created user {username} with role {role}");
        }
    }
}
