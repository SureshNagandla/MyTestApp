<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="MyTestApp.Pages.Protected.Employee.Edit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-4">
        <div class="row">
            <div class="col-6 offset-3">
                <div class="card shadow">
                      <div class="card-header h3">
                        Edit Employee
                      </div>
                    <div class="card-body">
                        <asp:Label ID="lblMessage" runat="server" CssClass="text-success h5"></asp:Label>

                        <!-- Validation Summary -->
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />

                        <!-- Name -->
                        <div class="mb-3">
                            <label>Name</label>
                            <asp:TextBox ID="txtName" runat="server" CssClass="form-control" />
                            <asp:RequiredFieldValidator ID="rfvName" runat="server"
                                ControlToValidate="txtName" ErrorMessage="Name is required"
                                ForeColor="Red" Display="Dynamic" />
                        </div>

                        <!-- Email -->
                        <div class="mb-3">
                            <label>Email</label>
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" />
                            <asp:RequiredFieldValidator ID="rfvEmail" runat="server"
                                ControlToValidate="txtEmail" ErrorMessage="Email is required"
                                ForeColor="Red" Display="Dynamic" />
                            <asp:RegularExpressionValidator ID="revEmail" runat="server"
                                ControlToValidate="txtEmail"
                                ValidationExpression="^[^@\s]+@[^@\s]+\.[^@\s]+$"
                                ErrorMessage="Enter a valid email"
                                ForeColor="Red" Display="Dynamic" />
                        </div>

                        <!-- Department -->
                        <div class="mb-3">
                            <label>Department</label>
                            <asp:TextBox ID="txtDepartment" runat="server" CssClass="form-control" />
                            <asp:RequiredFieldValidator ID="rfvDepartment" runat="server"
                                ControlToValidate="txtDepartment" ErrorMessage="Department is required"
                                ForeColor="Red" Display="Dynamic" />
                        </div>

                        <!-- Update Button -->
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click"
                            CssClass="btn btn-primary" />
                        <a href="Employees.aspx" class="btn btn-secondary">Back</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
