<%@ Page Title="Contact Us" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="MyTestApp.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-4 offset-4">
                <div class="card shadow">
                      <div class="card-header">
                        <h2 id="title"><%: Title %></h2>
                      </div>
                    <div class="card-body">
                        <main aria-labelledby="title">
                            <address>
                                National Informatics Centre<br />
                                Training Division, Domlur<br />
                                <abbr title="Phone">P:</abbr>
                                123 456 7890
                            </address>

                            <address>
                                <strong>Support:</strong>   <a href="mailto:Support@example.com">Support@example.com</a><br />
                            </address>
                        </main>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
