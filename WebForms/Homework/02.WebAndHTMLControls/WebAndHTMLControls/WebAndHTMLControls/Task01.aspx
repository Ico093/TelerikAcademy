<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Task01.aspx.cs" Inherits="WebAndHTMLControls.Task01" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <input type="text" id="from" runat="server"/>
        <input type="text" id="to" runat="server"/>
        <button type="submit" id="generate" runat="server" OnServerClick="BtnGenerate_Click">Generate</button>
        
        <input type="text" id="result" runat="server"/>
    </div>
    </form>
</body>
</html>
