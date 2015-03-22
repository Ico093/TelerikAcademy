<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Task01.aspx.cs" Inherits="AJAX.Task01.Task01" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxct" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <ajaxct:ToolkitScriptManager ID="ToolkitScriptManager" runat="server" />
        <div>
            <asp:UpdatePanel ID="UpdatePanelEmployees" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="GridViewEmployees" runat="server" AutoGenerateColumns="False" DataKeyNames="EmployeeID" DataSourceID="EntityDataSourceEmployees" OnSelectedIndexChanged="GridViewEmployees_SelectedIndexChanged">
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" />
                            <asp:BoundField DataField="EmployeeID" HeaderText="EmployeeID" ReadOnly="True" SortExpression="EmployeeID" />
                            <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
                            <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
                            <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                        </Columns>
                    </asp:GridView>
                    <asp:EntityDataSource ID="EntityDataSourceEmployees" runat="server" ConnectionString="name=NORTHWNDEntities"
                        DefaultContainerName="NORTHWNDEntities" EnableFlattening="False" EntitySetName="Employees" />
                </ContentTemplate>
            </asp:UpdatePanel>


            <asp:UpdatePanel ID="UpdatePanelOrders" UpdateMode="Conditional" runat="server">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="GridViewEmployees"/>
                </Triggers>
                <ContentTemplate>
                    <asp:GridView ID="GridViewOrders" runat="server"></asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>

            <asp:UpdateProgress ID="UpdateProgress" runat="server">
                <ProgressTemplate>
                    <asp:Image ImageUrl="~/Images/Task01/loading.gif" runat="server" />
                </ProgressTemplate>
            </asp:UpdateProgress>
        </div>
    </form>
</body>
</html>
