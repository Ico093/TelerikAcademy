<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Task01.aspx.cs" Inherits="FileUpload.Task01.Task01" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:FileUpload runat="server" ID="FileUploadArchive" />
        <asp:Button runat="server" ID="ButtonSend" Text="Send" OnClick="ButtonSend_Click"/>
        <br />
        <asp:Label runat="server" Text="Status:" />
        <asp:Label runat="server" ID="LabelResult" />
        <br />
        <asp:Label runat="server" ID="LabelContent" />
    </div>
    </form>
</body>
</html>
