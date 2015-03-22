<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="DataBinding.Task04.Employees" %>

<%@ Import Namespace="DataBinding.Data" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Repeater runat="server"
                ID="repEmployees"
                ItemType="Employee">
                <ItemTemplate>
                    <div>
                        <%#: Item.FirstName %>
                    </div>
                    <div>
                        <%#: Item.LastName %>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </form>
</body>
</html>
