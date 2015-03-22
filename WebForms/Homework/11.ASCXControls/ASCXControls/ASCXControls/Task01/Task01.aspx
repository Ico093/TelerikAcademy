<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Task01.aspx.cs" Inherits="ASCXControls.Task01.Task01" %>

<%@ Register Src="~/Controls/Task01/ListOfLinks.ascx" TagPrefix="uc" TagName="ListOfLinks" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc:ListOfLinks runat="server" ID="ListOfLinks" />
    </div>
    </form>
</body>
</html>
