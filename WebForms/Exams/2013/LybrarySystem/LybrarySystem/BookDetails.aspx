<%@ Page Title="Book Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BookDetails.aspx.cs" Inherits="LybrarySystem.BookDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h1><%: Page.Title %></h1>

        <asp:FormView ID="FormViewBookDetails" SelectMethod="FormViewBookDetails_GetItem" ItemType="LybrarySystem.Models.Book" runat="server">
            <ItemTemplate>
                <p class="book-title"><%#: Item.Title %></p>
                <p class="book-author"><i>by <%#: Item.Author %></i></p>
                <p class="book-isbn"><i>ISBN <%#: Item.ISBN %></i></p>
                <p class="book-isbn">
                    <i>Web site: 
                    <a href="<%#: Item.WebSite %>"><%#: Item.WebSite %></a></i>
                </p>
                <div class="row-fluid">
                    <div class="span12 book-description">
                        <p><%#: Item.Description %></p>
                    </div>
                </div>
            </ItemTemplate>
        </asp:FormView>

        <asp:HyperLink  NavigateUrl="~/" Text="Back to books" runat="server" />
    </div>
</asp:Content>
