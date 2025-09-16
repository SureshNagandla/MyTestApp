<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="MyTestApp.Pages.Protected.Book.Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-4">
        <h3>Book Details</h3>
        <asp:Label ID="lblTitle" runat="server" CssClass="h4"></asp:Label>
        <div class="mt-2">
            <asp:Label ID="lblAuthor" runat="server"></asp:Label><br />
            <asp:Label ID="lblCategory" runat="server"></asp:Label><br />
            <asp:Label ID="lblISBN" runat="server"></asp:Label><br />
            <asp:Label ID="lblAdded" runat="server"></asp:Label>
        </div>
        <a runat="server" href="Books.aspx" class="btn btn-secondary mt-3">Back</a>
    </div>
</asp:Content>
