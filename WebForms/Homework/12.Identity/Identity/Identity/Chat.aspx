<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Chat.aspx.cs" Inherits="Identity.Chat" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel UpdateMode="Conditional" runat="server">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="TimerRefresh" EventName="Tick" />
                </Triggers>
                <ContentTemplate>
                    <asp:Repeater ID="RepeaterMessages" ItemType="Identity.Models.Message" OnItemDataBound="RepeaterMessages_ItemDataBound" runat="server">
                        <ItemTemplate>
                            <asp:Panel runat="server">
                                <asp:Label Text='<%#: "User: " + Item.User %>' runat="server" />
                                <br />
                                <asp:Label Text='<%#: "Message: " + Item.Text %>' runat="server" />
                                <br />
                                <asp:Button ID="ButtonEdit" Text="Edit" OnCommand="ButtonEditDelete_Command" CommandName="Edit" CommandArgument="<%# Item.Id %>" runat="server" />
                                <asp:Button ID="ButtonDelete" Text="Delete" OnCommand="ButtonEditDelete_Command" CommandName="Delete" CommandArgument="<%# Item.Id %>" runat="server" />
                            </asp:Panel>
                            <br />
                            <br />
                        </ItemTemplate>
                    </asp:Repeater>
                </ContentTemplate>
            </asp:UpdatePanel>

            <asp:UpdatePanel ID="UpdatePanelInputMessage" UpdateMode="Conditional" runat="server">
                <ContentTemplate>
                    <asp:Panel runat="server">
                        <asp:Label Text="Message:" runat="server" />
                        <asp:TextBox ID="TextBoxMessage" runat="server" />
                        <br />
                        <asp:Button ID="ButtonSend" Text="Send" OnClick="ButtonSend_Click" runat="server" />
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>

            <asp:Timer ID="TimerRefresh" Interval="500" OnTick="TimerRefresh_Tick" runat="server" />
</asp:Content>
