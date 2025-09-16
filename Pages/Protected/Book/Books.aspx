<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Books.aspx.cs" Inherits="MyTestApp.Pages.Protected.Book.Books" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-4">
        <h2>Books</h2>
        <asp:Label ID="lblMessage" runat="server" CssClass="text-success"></asp:Label>
        <asp:Button ID="btnCreate" runat="server" Text="Add New Book" CssClass="btn btn-success mb-2" OnClick="btnCreate_Click" />
        <asp:GridView ID="gvBooks" runat="server" AutoGenerateColumns="false" CssClass="table table-striped" OnRowCommand="gvBooks_RowCommand" DataKeyNames="BookId">
            <Columns>
                <asp:BoundField DataField="BookId" HeaderText="#" />
                <asp:BoundField DataField="Title" HeaderText="Title" />
                <asp:BoundField DataField="AuthorName" HeaderText="Author" />
                <asp:BoundField DataField="CategoryName" HeaderText="Category" />
                <asp:BoundField DataField="ISBN" HeaderText="ISBN" />
                <asp:TemplateField HeaderText="Actions">
                    <ItemTemplate>
                        <asp:Button runat="server" CommandName="Details" CommandArgument='<%# Eval("BookId") %>' Text="Details" CssClass="btn btn-info btn-sm" />
                        <asp:Button runat="server" CommandName="EditBook" CommandArgument='<%# Eval("BookId") %>' Text="Edit" CssClass="btn btn-primary btn-sm" />
                        <asp:Button runat="server" CommandName="DeleteBook" CommandArgument='<%# Eval("BookId") %>' Text="Delete" CssClass="btn btn-danger btn-sm" OnClientClick="return confirm('Delete this book?');" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
