<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Task03.aspx.cs" Inherits="WebAndHTMLControls.Task03" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="tbxInput" runat="server"/>
        <asp:Button runat="server" Text="Submit" OnClick="BtnSubmit_OnClick"/>

        <asp:TextBox runat="server" ID="tbxResult"/>
        <asp:Label runat="server" ID="lblResult"/>
    </div>
    </form>
</body>
</html>