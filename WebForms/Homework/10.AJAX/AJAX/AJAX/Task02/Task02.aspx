<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Task02.aspx.cs" Inherits="AJAX.Task02.Task02" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxct" %>

<%@ Import Namespace="AJAX.Data" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <ajaxct:ToolkitScriptManager ID="ToolkitScriptManager" runat="server" />

        <div>
            <asp:UpdatePanel UpdateMode="Conditional" runat="server">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="TimerRefresh" EventName="Tick" />
                </Triggers>
                <ContentTemplate>
                    <asp:Repeater ID="RepeaterMessages" ItemType="Message" runat="server">
                        <ItemTemplate>
                            <asp:Panel runat="server">
                                <asp:Label Text='<%#: "User: " + Item.Username %>' runat="server" />
                                <br />
                                <asp:Label Text='<%#: "Message: " + Item.Text %>' runat="server" />
                            </asp:Panel>
                            <br />
                            <br />
                        </ItemTemplate>
                    </asp:Repeater>
                </ContentTemplate>
            </asp:UpdatePanel>

            <asp:UpdatePanel UpdateMode="Conditional" runat="server">
                <ContentTemplate>
                    <asp:Panel runat="server">
                        <asp:Label Text="Username:" runat="server" />
                        <asp:TextBox ID="TextBoxUsername" runat="server" />
                        <br />
                        <asp:Label Text="Message:" runat="server" />
                        <asp:TextBox ID="TextBoxMessage" runat="server" />
                        <br />
                        <asp:Button ID="ButtonSend" Text="Send" OnClick="ButtonSend_Click" runat="server" />
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>

            <asp:Timer ID="TimerRefresh" Interval="500" OnTick="TimerRefresh_Tick" runat="server" />
        </div>
    </form>
</body>
</html>
