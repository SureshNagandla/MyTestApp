<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="MyTestApp.Pages.Protected.Employee.Employees" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container my-4">
        <div class="card">
            <div class="card-header h3">Employee List</div>
            <div class="card-body">
                <!-- Success/Error message -->
                <asp:Label ID="lblMessage" runat="server" CssClass="alert alert-info p-1 h5" />

                <div class="my-3">
                    <a id="lnkCreate" runat="server" href="Create.aspx" class="btn btn-primary">Add New Employee</a>
                </div>

                <asp:GridView ID="gvEmployees" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
                    CssClass="table table-bordered table-striped table-hover shadow"
                    HeaderStyle-CssClass="table-dark" OnRowDataBound="gvEmployees_RowDataBound"
                    OnRowDeleting="gvEmployees_RowDeleting">
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="ID" ReadOnly="True" />
                        <asp:BoundField DataField="Name" HeaderText="Name" />
                        <asp:BoundField DataField="Email" HeaderText="Email" />
                        <asp:TemplateField HeaderText="Actions">
                            <ItemTemplate>
                                <!-- View is always available -->
                                <a href='Details.aspx?id=<%# Eval("Id") %>' class="btn btn-info btn-sm">View</a>

                                <!-- Edit button -->
                                <asp:HyperLink ID="lnkEdit" runat="server"
                                    NavigateUrl='<%# "Edit.aspx?id=" + Eval("Id") %>'
                                    CssClass="btn btn-warning btn-sm"
                                    Text="Edit" />

                                <!-- Delete button -->
                                <asp:LinkButton ID="btnDelete" runat="server"
                                    CommandName="Delete"
                                    CommandArgument='<%# Eval("Id") %>'
                                    CssClass="btn btn-danger btn-sm"
                                    CausesValidation="false"
                                    OnClientClick="return confirm('Are you sure you want to delete this employee?');">
                                    Delete
                                </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
