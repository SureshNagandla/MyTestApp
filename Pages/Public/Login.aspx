<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MyTestApp.Pages.Public.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-4 offset-4">
                <div class="card shadow">
                      <div class="card-header">
                        Sign-in
                      </div>
                    <div class="card-body">
                    <div class="mb-3">
                          <asp:Label ID="lblMessage" runat="server" CssClass="text-danger"></asp:Label>
                      </div>

                    <asp:ValidationSummary ID="vsSummary" runat="server" CssClass="text-danger" HeaderText="Please fix the following:" />

                    <div class="mb-3">
                        <label for="exampleInputEmail1" class="form-label">Username</label>
                        <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" />
                        <asp:RequiredFieldValidator ID="rfvUsername" runat="server"
                            ControlToValidate="txtUsername"
                            ErrorMessage="Username is required"
                            CssClass="text-danger"
                            Display="Dynamic" />
                    </div>

                    <div class="mb-3">
                        <label for="exampleInputPassword1" class="form-label">Password</label>
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" />
                        <asp:RequiredFieldValidator ID="rfvPassword" runat="server"
                            ControlToValidate="txtPassword"
                            ErrorMessage="Password is required"
                            CssClass="text-danger"
                            Display="Dynamic" />
                    </div>
                      <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click"  CssClass="btn btn-primary" />
                    
                    </div>
                </div>

            </div>
        </div>
    </div>
</asp:Content>
