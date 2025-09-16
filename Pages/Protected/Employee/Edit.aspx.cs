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
    public partial class Edit : System.Web.UI.Page
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private readonly EmployeeRepository repo = new EmployeeRepository();
        private int EmployeeId => Convert.ToInt32(Request.QueryString["id"]);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var emp = repo.GetEmployeeById(EmployeeId);
                if (emp != null)
                {
                    txtName.Text = emp.Name;
                    txtEmail.Text = emp.Email;
                    txtDepartment.Text = emp.Department;
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!User.IsInRole("Admin") && !User.IsInRole("DataEntry"))
            {
                lblMessage.Text = "You are not Authorized.";
                lblMessage.CssClass = "text-danger h5";
                return;
            }

            // Server-side validation
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtDepartment.Text))
            {
                lblMessage.Text = "All fields are required.";
                lblMessage.CssClass = "text-danger";
                return;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(txtEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                lblMessage.Text = "Invalid email format.";
                lblMessage.CssClass = "text-danger";
                return;
            }

            var emp = new Models.Employee
            {
                Id = EmployeeId,
                Name = txtName.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Department = txtDepartment.Text.Trim()
            };

            repo.UpdateEmployee(emp);

            logger.Info($"Employee with ID={EmployeeId} updated by {Context.User.Identity.Name}.");
            lblMessage.Text = "Employee updated successfully!";
            lblMessage.CssClass = "text-success";
        }
    }
}