<%@ Page Title="Books" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LybrarySystem._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row jumbotrone">
        <h1 class="navbar-left"><%: Page.Title %></h1>
        <div class="navbar-form navbar-right" role="search">
            <div class="form-group">
                <asp:TextBox id="TextBoxSearch" class="form-control" Placeholder="Search" runat="server"/>
            </div>
            <asp:Button ID="ButtonSearch" Text="Search" CssClass="btn btn-default" OnClick="ButtonSearch_Click" runat="server"/>
        </div>
    </div>

    <asp:ListView ID="ListViewCategories" SelectMethod="ListViewCategories_GetData" ItemType="LybrarySystem.Models.Category"
        GroupItemCount="3" runat="server">
        <GroupTemplate>
            <div class="row">
                <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
            </div>
        </GroupTemplate>
        <ItemTemplate>
            <div class="col-md-4">
                <h2><%#: Item.Name %></h2>
                <asp:Repeater ID="RepeaterBooks" DataSource="<%# Item.Books %>" ItemType="LybrarySystem.Models.Book" runat="server">
                    <HeaderTemplate>
                        <ul>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <li>
                            <a href='<%# "BookDetails.aspx?id=" + Item.Id %>'>
                                <%#: Item.Title %> by <i><%#: Item.Author %></i>
                            </a>
                        </li>

                    </ItemTemplate>
                    <FooterTemplate>
                        </ul>
                    </FooterTemplate>
                </asp:Repeater>
            </div>

        </ItemTemplate>
    </asp:ListView>
</asp:Content>
