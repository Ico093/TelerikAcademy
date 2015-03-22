<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Task01.aspx.cs" Inherits="IntroInWebForms.Task01" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox runat="server" ID="txbName"></asp:TextBox>
        <asp:Button runat="server" ID="btnSend" Text="Send" OnClick="BtnSend_OnClick"/>
        <asp:Label runat="server" ID="lblResult"></asp:Label>
    </div>
    </form>
</body>
</html>
