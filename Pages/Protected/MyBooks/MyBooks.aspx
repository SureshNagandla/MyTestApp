<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyBooks.aspx.cs" Inherits="MyTestApp.Pages.Protected.MyBooks.MyBooks" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-4">
        <h3>My Borrowed Books</h3>
        <asp:GridView ID="gvMyBooks" runat="server" AutoGenerateColumns="false" CssClass="table table-striped">
            <Columns>
                <asp:BoundField DataField="Title" HeaderText="Title" />
                <asp:BoundField DataField="BorrowDate" HeaderText="Borrow Date" DataFormatString="{0:yyyy-MM-dd}" />
                <asp:BoundField DataField="ReturnDate" HeaderText="Return Date" DataFormatString="{0:yyyy-MM-dd}" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
