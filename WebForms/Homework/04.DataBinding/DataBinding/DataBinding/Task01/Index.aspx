<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="DataBinding.Task01.Index" %>
<%@ Import namespace="DataBinding.Task01.Models" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:DropDownList runat="server"
                ID="producers"
                DataTextField="Name"
                AutoPostBack="True" />

            <asp:DropDownList runat="server"
                ID="models"
                AutoPostBack="True" />

            <asp:Repeater runat="server" ID="extras" ItemType="Extra">
                <ItemTemplate>
                    <label><%#: Item.Name %></label>
                    <input type="checkbox" <%#: Item.IsChecked?"checked":"" %> />
                </ItemTemplate>
            </asp:Repeater>

            <asp:RadioButtonList runat="server" ID="engines" />
        </div>
    </form>
</body>
</html>
