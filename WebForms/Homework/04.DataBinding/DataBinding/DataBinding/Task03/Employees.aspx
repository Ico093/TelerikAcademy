<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="DataBinding.Task03.Employees" %>

<%@ Import Namespace="DataBinding.Data" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView runat="server"
                ID="employees"
                AutoGenerateColumns="false" ItemType="Employee">
                <Columns>
                    <asp:TemplateField HeaderText="Name">
                        <ItemTemplate>
                            <asp:Label ID="lblName" runat="server" Text='<%# Item.FirstName + " " + Item.LastName %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Name">
                        <ItemTemplate>
                            <asp:Button runat="server"
                                ID="btnMoreInfo"
                                Text='See more'
                                OnCommand="BtnMoreInfo_Command"
                                CommandName="Employee"
                                CommandArgument="<%#: Item.EmployeeID %>" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

            <asp:FormView runat="server"
                ID="fmvSelectedEmployee"
                ItemType="Employee">
                <ItemTemplate>
                    <div>
                        <%#: Item.FirstName %>
                    </div>
                    <div>
                        <%#: Item.LastName %>
                    </div>
                </ItemTemplate>
            </asp:FormView>
        </div>
    </form>
</body>
</html>
