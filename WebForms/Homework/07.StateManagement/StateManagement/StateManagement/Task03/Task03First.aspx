<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Task03First.aspx.cs" Inherits="StateManagement.Task03.Task03" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="ButtonSignIn" Text="Sign in!" OnClick="ButtonSignIn_Click" runat="server" />
        <asp:HyperLink ID="HyperLinkNavigateToSecondPage" NavigateUrl="~/Task03/Task03Second.aspx" Text="Click me!" runat="server" />
    </div>
    </form>
</body>
</html>
