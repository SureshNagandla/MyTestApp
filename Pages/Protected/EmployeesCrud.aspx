<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmployeesCrud.aspx.cs" Inherits="MyTestApp.Pages.Protected.Employees" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div class="container">
        <div class="row text-center">
                <h2>Employee Management</h2>
            <div class="col-6 offset-3">
                <div class="card shadow">
                    <!-- Card Header -->
                    <div class="card-header h4">
                        New Employee
                    </div>

                    <!-- Card Body -->
                    <div class="card-body">
                        <!-- Success Message -->
                        <asp:Label ID="lblMessage" runat="server" CssClass="text-success h4" />

                        <!-- Error Message -->
                        <div class="row mb-3">
                            <div class="col-12">
                                <asp:Label ID="Label1" runat="server" ForeColor="Red" CssClass="form-text text-danger" />
                            </div>
                        </div>

                        <!-- Name Field -->
                        <div class="row mb-3">
                            <label for="txtName" class="col-sm-4 col-form-label">Name</label>
                            <div class="col-sm-8">
                                <asp:TextBox ID="txtName" runat="server" CssClass="form-control" />
                            </div>
                        </div>

                        <!-- Email Field -->
                        <div class="row mb-3">
                            <label for="txtEmail" class="col-sm-4 col-form-label">Email</label>
                            <div class="col-sm-8">
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" />
                            </div>
                        </div>

                        <!-- Department Field -->
                        <div class="row mb-3">
                            <label for="txtDepartment" class="col-sm-4 col-form-label">Department</label>
                            <div class="col-sm-8">
                                <asp:TextBox ID="txtDepartment" runat="server" CssClass="form-control" />
                            </div>
                        </div>

                        <!-- Submit Button -->
                        <div class="row">
                            <div class="col-sm-4 offset-sm-4">
                                <asp:Button ID="btnAdd" runat="server" Text="Add Employee" OnClick="btnAdd_Click" CssClass="btn btn-primary" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row mt-3">
            <div class="col">
                <asp:GridView ID="gvEmployees" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
                    CssClass="table table-bordered table-striped table-hover shadow"
                    HeaderStyle-CssClass="table-dark"
                    OnRowEditing="gvEmployees_RowEditing"
                    OnRowUpdating="gvEmployees_RowUpdating"
                    OnRowCancelingEdit="gvEmployees_RowCancelingEdit"
                    OnRowDeleting="gvEmployees_RowDeleting">
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="ID" ReadOnly="True" />
                        <asp:BoundField DataField="Name" HeaderText="Name" />
                        <asp:BoundField DataField="Email" HeaderText="Email" />
                        <asp:BoundField DataField="Department" HeaderText="Department" />
                        <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        </div>
</asp:Content>
