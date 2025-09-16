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
    public partial class Create : System.Web.UI.Page
    {
        private readonly EmployeeRepository repo = new EmployeeRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.IsInRole("Admin") && !User.IsInRole("DataEntry"))
            {
                // Unauthorized users shouldn't access this page
                Response.Redirect("~/Pages/Protected/Employee/Employees.aspx");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            // Server-side validation (extra safety beyond validators)
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
                Name = txtName.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Department = txtDepartment.Text.Trim()
            };

            repo.AddEmployee(emp);
            lblMessage.Text = "Employee added successfully!";
            lblMessage.CssClass = "text-success";

            // Reset form
            txtName.Text = txtEmail.Text = txtDepartment.Text = "";
        }
    }
}