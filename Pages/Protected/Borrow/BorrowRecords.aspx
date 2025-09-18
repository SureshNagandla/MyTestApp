<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BorrowRecords.aspx.cs" Inherits="WebApplication2.Pages.Protected.Borrow.BorrowRecords" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Borrow Records</h2>

    <asp:Label ID="lblMessage" runat="server" CssClass="text-danger"></asp:Label>

    <asp:GridView ID="gvBorrowRecords" runat="server" AutoGenerateColumns="False" 
        CssClass="table table-striped" DataKeyNames="Id" OnRowCommand="gvBorrowRecords_RowCommand">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Borrow ID" />
            <asp:BoundField DataField="Username" HeaderText="Member" />
            <asp:BoundField DataField="Title" HeaderText="Book Title" />
            <asp:BoundField DataField="BorrowDate" HeaderText="Borrowed On" DataFormatString="{0:yyyy-MM-dd}" />
            <asp:BoundField DataField="ReturnDate" HeaderText="Returned On" DataFormatString="{0:yyyy-MM-dd}" />
            <asp:TemplateField HeaderText="Actions">
                <ItemTemplate>
                    <asp:Button ID="btnReturn" runat="server" 
                        Text="Mark Returned" 
                        CommandName="Return" 
                        CommandArgument="<%# Container.DataItemIndex %>" 
                        CssClass="btn btn-sm btn-primary"
                        Visible='<%# string.IsNullOrEmpty(Eval("ReturnDate").ToString()) %>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
