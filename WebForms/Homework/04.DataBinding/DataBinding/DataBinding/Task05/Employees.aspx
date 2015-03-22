<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="DataBinding.Task05.Employees" %>

<%@ Import Namespace="DataBinding.Data" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ListView runat="server"
                ID="livEmployees"
                ItemType="Employee">
                <ItemTemplate>
                    <div>
                        <%#: Item.FirstName %>
                    </div>
                    <div>
                        <%#: Item.LastName %>
                    </div>
                </ItemTemplate>
            </asp:ListView>
            <asp:DataPager runat="server"
                ID="dpEmployees"
                PagedControlID="livEmployees"
                PageSize="3"
                OnPreRender="DataPagerEmployees_PreRender">
                <Fields>
                    <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="true" ShowNextPageButton="false"  />
                    <asp:NumericPagerField  />
                    <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="true" ShowPreviousPageButton="false"/>
                </Fields>
            </asp:DataPager>
        </div>
    </form>
</body>
</html>
