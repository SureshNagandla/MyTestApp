<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="MyTestApp.Pages.Protected.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="card shadow text-center">
            <div class="card-body">
                <h2>Welcome, <asp:Label ID="lblUsername" runat="server" /></h2>
                <p>You are successfully logged in.</p>
                <h3>Your role is set as:  <asp:Label ID="lblRole" runat="server" /></h3>
            </div>
        </div>
    </div>
</asp:Content>
