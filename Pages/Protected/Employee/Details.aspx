<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="MyTestApp.Pages.Protected.Employee.Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-4">
        <div class="row">
            <div class="col-6 offset-3">
                <div class="card shadow">
                      <div class="card-header h3">
                        Employee Details
                      </div>
                    <div class="card-body">
                        <asp:FormView ID="fvEmployee" runat="server" CssClass="table table-bordered table-striped">
                            <ItemTemplate>
                                <p><b>ID:</b> <%# Eval("Id") %></p>
                                <p><b>Name:</b> <%# Eval("Name") %></p>
                                <p><b>Email:</b> <%# Eval("Email") %></p>
                                <p><b>Department:</b> <%# Eval("Department") %></p>
                            </ItemTemplate>
                        </asp:FormView>
                        <a href="Employees.aspx" class="btn btn-secondary">Back</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
