<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Task04.aspx.cs" Inherits="WebAndHTMLControls.Task04" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox runat="server" ID="firstName"/>
        <asp:TextBox runat="server" ID="lastName"/>
        <asp:TextBox runat="server" ID="facultyNumber"/>
        <asp:DropDownList runat="server" ID="univercity">
            <asp:ListItem Text="SU" Value="SU"/>
            <asp:ListItem Text="NBU" Value="NBU"/>
        </asp:DropDownList>
        <asp:ListBox runat="server" ID="courses" SelectionMode="Multiple">
            <asp:ListItem Text="Matmatika" Value="Matmatika"/>
            <asp:ListItem Text="Fitnes" Value="Fitnes"/>
            <asp:ListItem Text="Horeografiq" Value="Horeografiq"/>
        </asp:ListBox>
        
        <asp:Button runat="server" Text="Submit" OnClick="BtnSubmit_OnClick"/>

        <asp:Panel runat="server" ID="resultDiv"/>
    </div>
    </form>
</body>
</html>
