<%@ Page Title="Search Results for Query" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="LybrarySystem.Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-md-12">
        <h1><%: Page.Title %> “<asp:Literal ID="LiteralQuery" Mode="Encode" runat="server" />”:</h1>

        <asp:Repeater ID="RepeaterResults" ItemType="LybrarySystem.Models.Book" SelectMethod="RepeaterResults_GetData" runat="server">
            <HeaderTemplate>
                <ul>
            </HeaderTemplate>
            <ItemTemplate>
                <li>
                    <a href="<%# "BookDetails.aspx?id=" + Item.Id %>">“<%#: Item.Title %>” <i>by <%#: Item.Author %></i></a>
                    (Category: <%#: Item.Category.Name %>)                 
                </li>
            </ItemTemplate>
            <FooterTemplate>
                </ul>
            </FooterTemplate>
        </asp:Repeater>

        <asp:HyperLink NavigateUrl="~/" Text="Back to books" runat="server" />
    </div>
</asp:Content>
