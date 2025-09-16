using MyTestApp.DAL;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyTestApp.Pages.Protected.Employee
{
    public partial class Employees : System.Web.UI.Page
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private readonly EmployeeRepository repo = new EmployeeRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            logger.Info("Employees page loaded.");
            lblMessage.Visible = !string.IsNullOrWhiteSpace(lblMessage.Text);
            if (!IsPostBack)
                LoadEmployees();
        }

        private void LoadEmployees()
        {
            gvEmployees.DataSource = repo.GetAllEmployees();
            gvEmployees.DataBind();
        }
        protected void gvEmployees_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Find action buttons inside the template
                var btnEdit = (HyperLink)e.Row.FindControl("lnkEdit");
                var btnDelete = (LinkButton)e.Row.FindControl("btnDelete");

                // View is always visible (no need to hide)

                if (User.IsInRole("Viewer"))
                {
                    // Viewer: hide add, edit & delete
                    if (lnkCreate != null) lnkCreate.Visible = false;
                    if (btnEdit != null) btnEdit.Visible = false;
                    if (btnDelete != null) btnDelete.Visible = false;
                }
                else if (User.IsInRole("DataEntry"))
                {
                    // DataEntry: allow edit, hide delete
                    if (btnDelete != null) btnDelete.Visible = false;
                }
                // Admin: full access, nothing hidden
            }
        }


        protected void gvEmployees_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            if (!User.IsInRole("Admin"))
            {
                lblMessage.Text = "You are not Authorized.";
                return;
            }
            int id = Convert.ToInt32(gvEmployees.DataKeys[e.RowIndex].Value);
            repo.DeleteEmployee(id);

            logger.Info($"Employee with ID={id} deleted by {Context.User.Identity.Name}.");
            lblMessage.Text = "Employee deleted successfully.";
            LoadEmployees();
        }
    }
}