<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GenericError.aspx.cs" Inherits="MyTestApp.Pages.Error.GenericError" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Error - MyTestApp</title>
    <link href="~/Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body class="bg-light">
    <form id="form1" runat="server">
        <div class="container text-center mt-5">
            <h1 class="text-danger">Oops! Something went wrong.</h1>
            <p class="lead">Our team has been notified. Please try again later.</p>
            <a href="~/" runat="server" class="btn btn-primary mt-3">Go Home</a>
        </div>
    </form>
</body>
</html>