using MyTestApp.DAL;
using MyTestApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyTestApp.Pages.Protected.Employee
{
    public partial class Details : System.Web.UI.Page
    {
        private readonly EmployeeRepository repo = new EmployeeRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                fvEmployee.DataSource = new[] { repo.GetEmployeeById(id) };
                fvEmployee.DataBind();
            }
        }
    }
}