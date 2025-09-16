using MyTestApp;
using MyTestApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MyTestApp.DAL
{
    public class EmployeeRepository
    {
        private readonly string _connString;

        public EmployeeRepository()
        {
            _connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public void AddEmployee(Employee emp)
        {
            using (SqlConnection conn = new SqlConnection(_connString))
            {
                string query = "INSERT INTO Employees (Name, Email, Department) VALUES (@Name, @Email, @Department)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", emp.Name);
                cmd.Parameters.AddWithValue("@Email", emp.Email);
                cmd.Parameters.AddWithValue("@Department", emp.Department);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<Employee> GetAllEmployees()
        {
            var employees = new List<Employee>();

            using (SqlConnection conn = new SqlConnection(_connString))
            {
                string query = "SELECT Id, Name, Email, Department FROM Employees";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    employees.Add(new Employee
                    {
                        Id = (int)reader["Id"],
                        Name = reader["Name"].ToString(),
                        Email = reader["Email"].ToString(),
                        Department = reader["Department"].ToString()
                    });
                }
            }

            return employees;
        }

        public Employee GetEmployeeById(int id)
        {
            Employee emp = null;
            using (SqlConnection con = new SqlConnection(_connString))
            {
                string query = "SELECT Id, Name, Email, Department FROM Employees WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", id);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    emp = new Employee
                    {
                        Id = Convert.ToInt32(rdr["Id"]),
                        Name = rdr["Name"].ToString(),
                        Email = rdr["Email"].ToString(),
                        Department = rdr["Department"].ToString()
                    };
                }
            }
            return emp;
        }

        public void UpdateEmployee(Employee emp)
        {
            using (SqlConnection conn = new SqlConnection(_connString))
            {
                string query = "UPDATE Employees SET Name=@Name, Email=@Email, Department=@Department WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", emp.Name);
                cmd.Parameters.AddWithValue("@Email", emp.Email);
                cmd.Parameters.AddWithValue("@Department", emp.Department);
                cmd.Parameters.AddWithValue("@Id", emp.Id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteEmployee(int id)
        {
            using (SqlConnection conn = new SqlConnection(_connString))
            {
                string query = "DELETE FROM Employees WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

    }

}