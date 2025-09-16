<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="MyTestApp.Pages.Protected.Admin.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-4">
        <h3>Register New User (Admin only)</h3>
        <asp:Label ID="lblMsg" runat="server" CssClass="text-danger"></asp:Label>
        <div class="form-row">
            <div class="form-group col-md-4">
                <asp:Label runat="server" Text="Username" />
                <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator ControlToValidate="txtUsername" ErrorMessage="Required" runat="server" CssClass="text-danger" />
            </div>
            <div class="form-group col-md-4">
                <asp:Label runat="server" Text="Full Name" />
                <asp:TextBox ID="txtFullName" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator ControlToValidate="txtFullName" ErrorMessage="Required" runat="server" CssClass="text-danger" />
            </div>
            <div class="form-group col-md-4">
                <asp:Label runat="server" Text="Role" />
                <asp:DropDownList ID="ddlRole" runat="server" CssClass="form-control">
                    <asp:ListItem>Admin</asp:ListItem>
                    <asp:ListItem>Librarian</asp:ListItem>
                    <asp:ListItem>Member</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class="form-row">
            <div class="form-group col-md-4">
                <asp:Label runat="server" Text="Password" />
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator ControlToValidate="txtPassword" ErrorMessage="Required" runat="server" CssClass="text-danger" />
            </div>
            <div class="form-group col-md-4">
                <asp:Label runat="server" Text="Confirm Password" />
                <asp:TextBox ID="txtConfirm" runat="server" TextMode="Password" CssClass="form-control" />
                <asp:CompareValidator ControlToCompare="txtPassword" ControlToValidate="txtConfirm" ErrorMessage="Passwords must match" runat="server" CssClass="text-danger" />
            </div>
        </div>
        <asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="btn btn-primary" OnClick="btnRegister_Click" />
    </div>
</asp:Content>
