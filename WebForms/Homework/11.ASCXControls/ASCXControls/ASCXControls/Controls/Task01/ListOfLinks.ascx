<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListOfLinks.ascx.cs" Inherits="ASCXControls.Controls.Task01.ListOfLinks" %>

<asp:DataList ID="DataListLinks" runat="server">
    <ItemTemplate>
        <asp:HyperLink NavigateUrl='<%# Eval("URL") %>' Text='<%#: Eval("Title") %>' runat="server" />
    </ItemTemplate>
</asp:DataList>