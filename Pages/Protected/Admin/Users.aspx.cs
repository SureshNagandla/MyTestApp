using MyTestApp.DAL;
using System;
using System.Data;
using System.Web.UI;

namespace MyTestApp.Pages.Protected.Admin
{
    public partial class Users : Page
    {
        private readonly UserRepository repo = new UserRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Role"] == null || Session["Role"].ToString() != "Admin")
            {
                Response.Redirect("~/Pages/Public/Login.aspx");
            }
            if (!IsPostBack) LoadUsers();
        }

        private void LoadUsers()
        {
            var dt = new System.Data.DataTable();
            using (var conn = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LibraryDB"].ConnectionString))
            using (var cmd = new System.Data.SqlClient.SqlCommand("SELECT Id, Username, FullName, Role, CreatedDate FROM Users ORDER BY CreatedDate DESC", conn))
            using (var da = new System.Data.SqlClient.SqlDataAdapter(cmd))
            {
                da.Fill(dt);
            }
            gvUsers.DataSource = dt;
            gvUsers.DataBind();
        }
    }
}
