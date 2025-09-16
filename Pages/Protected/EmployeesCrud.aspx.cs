using MyTestApp.DAL;
using MyTestApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyTestApp.Pages.Protected
{
    public partial class Employees : System.Web.UI.Page
    {
        private readonly EmployeeRepository repo = new EmployeeRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            // Simulate unhandled error
            throw new Exception("Demo exception for GenericError page");
            if (!IsPostBack)
                LoadEmployees();
        }

        private void LoadEmployees()
        {
            gvEmployees.DataSource = repo.GetAllEmployees();
            gvEmployees.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            var emp = new Models.Employee
            {
                Name = txtName.Text,
                Email = txtEmail.Text,
                Department = txtDepartment.Text
            };

            repo.AddEmployee(emp);
            lblMessage.Text = "Employee added successfully.";
            ClearForm();
            LoadEmployees();
        }

        protected void gvEmployees_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvEmployees.EditIndex = e.NewEditIndex;
            LoadEmployees();
        }

        protected void gvEmployees_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvEmployees.EditIndex = -1;
            LoadEmployees();
        }

        protected void gvEmployees_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gvEmployees.Rows[e.RowIndex];
            int id = Convert.ToInt32(gvEmployees.DataKeys[e.RowIndex].Value);
            string name = ((TextBox)row.Cells[1].Controls[0]).Text;
            string email = ((TextBox)row.Cells[2].Controls[0]).Text;
            string dept = ((TextBox)row.Cells[3].Controls[0]).Text;

            var emp = new Models.Employee
            {
                Id = id,
                Name = name,
                Email = email,
                Department = dept
            };

            repo.UpdateEmployee(emp);
            lblMessage.Text = "Employee updated.";
            gvEmployees.EditIndex = -1;
            LoadEmployees();
        }

        protected void gvEmployees_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(gvEmployees.DataKeys[e.RowIndex].Value);
            repo.DeleteEmployee(id);
            lblMessage.Text = "Employee deleted.";
            LoadEmployees();
        }

        private void ClearForm()
        {
            txtName.Text = txtEmail.Text = txtDepartment.Text = "";
        }
    }
}