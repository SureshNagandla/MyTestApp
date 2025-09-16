<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Borrow.aspx.cs" Inherits="MyTestApp.Pages.Protected.Borrow.Borrow" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-4">
        <h3>Borrow Book</h3>
        <asp:Label ID="lblMsg" runat="server" CssClass="text-danger"></asp:Label>
        <asp:DropDownList ID="ddlBooks" runat="server" CssClass="form-control"></asp:DropDownList>
        <asp:Button ID="btnBorrow" runat="server" Text="Borrow" CssClass="btn btn-primary mt-2" OnClick="btnBorrow_Click" />
    </div>
</asp:Content>
