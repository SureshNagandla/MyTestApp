<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="MyTestApp.Pages.Protected.Admin.Users" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-4">
        <h3>Users</h3>
        <asp:GridView ID="gvUsers" runat="server" AutoGenerateColumns="false" CssClass="table table-striped">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="#" />
                <asp:BoundField DataField="Username" HeaderText="Username" />
                <asp:BoundField DataField="FullName" HeaderText="Full Name" />
                <asp:BoundField DataField="Role" HeaderText="Role" />
                <asp:BoundField DataField="CreatedDate" HeaderText="Created" DataFormatString="{0:yyyy-MM-dd}" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
