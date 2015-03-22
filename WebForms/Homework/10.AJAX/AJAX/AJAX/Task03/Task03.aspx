<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Task03.aspx.cs" Inherits="AJAX.Task03.Task03" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxct" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="~/Styles/Task03.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <ajaxct:ToolkitScriptManager ID="ToolkitScriptManager" runat="server" />
        <div>
            <asp:UpdatePanel UpdateMode="Conditional" ChildrenAsTriggers="true" runat="server">
                <ContentTemplate>
                    <asp:Panel ID="PanelLarge" runat="server">
                        <asp:Image ID="ImageLarge" AlternateText="Large Image" runat="server" />
                    </asp:Panel>
                    <asp:Panel ID="PanelPictures" runat="server">
                        <asp:Repeater ID="RepeaterPictures" runat="server">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageButtonSmall" ImageUrl="<%# this.GetDataItem() %>" AlternateText="Small Image" OnClick="ImageButtonSmall_Click" runat="server" />
                            </ItemTemplate>
                        </asp:Repeater>
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
