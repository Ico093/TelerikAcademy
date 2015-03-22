<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Task02.aspx.cs" Inherits="WebAndHTMLControls.Task02" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="from" runat="server"></asp:TextBox>
        <asp:TextBox ID="to" runat="server"></asp:TextBox>
        <asp:Button runat="server" Text="Generate" OnClick="BtnGenerate_Click"/>

        <asp:TextBox ID="result" runat="server"/>
    </div>
    </form>
</body>
</html>
