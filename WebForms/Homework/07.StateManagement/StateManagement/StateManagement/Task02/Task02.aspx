<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Task02.aspx.cs" Inherits="StateManagement.Task02.Task02" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="TextBoxEntry" runat="server" />
        <asp:Button ID="ButtonAppend" Text="Apend" OnClick="ButtonAppend_Click" runat="server" />
        <asp:Label ID="LabelResult" runat="server" />
    </div>
    </form>
</body>
</html>
