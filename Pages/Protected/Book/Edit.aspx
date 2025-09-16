<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="MyTestApp.Pages.Protected.Book.Edit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-4">
        <h3>Edit Book</h3>
        <asp:Label ID="lblMsg" runat="server" CssClass="text-danger"></asp:Label>
        <div class="form-group">
            <asp:Label runat="server" Text="Title" />
            <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control" />
            <asp:RequiredFieldValidator ControlToValidate="txtTitle" ErrorMessage="Required" runat="server" CssClass="text-danger" />
        </div>
        <div class="form-row">
            <div class="form-group col-md-4">
                <asp:Label runat="server" Text="Author" />
                <asp:DropDownList ID="ddlAuthor" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>
            <div class="form-group col-md-4">
                <asp:Label runat="server" Text="Category" />
                <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>
            <div class="form-group col-md-4">
                <asp:Label runat="server" Text="ISBN" />
                <asp:TextBox ID="txtISBN" runat="server" CssClass="form-control" />
                <asp:RegularExpressionValidator ControlToValidate="txtISBN" ValidationExpression="^\d{9,13}$" ErrorMessage="ISBN digits only (9-13)" runat="server" CssClass="text-danger" Display="Dynamic"></asp:RegularExpressionValidator>
            </div>
        </div>
        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="btnSave_Click" />
        <a runat="server" href="Books.aspx" class="btn btn-secondary">Back</a>
    </div>
</asp:Content>
