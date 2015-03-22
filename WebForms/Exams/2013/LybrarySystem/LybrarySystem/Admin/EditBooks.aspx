<%@ Page Title="Edit Books" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditBooks.aspx.cs" Inherits="LybrarySystem.Admin.EditBooks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanelBooks" UpdateMode="Conditional" ChildrenAsTriggers="true" runat="server">
        <Triggers>
            <%--<asp:AsyncPostBackTrigger ControlID="GridViewBooks" EventName="" />--%>
        </Triggers>
        <ContentTemplate>
            <asp:GridView ID="GridViewBooks"
                ItemType="LybrarySystem.Models.Book"
                SelectMethod="GridViewBooks_GetData"
                UpdateMethod="GridViewBooks_UpdateItem"
                DeleteMethod="GridViewBooks_DeleteItem"
                AllowPaging="true" AllowSorting="true"
                DataKeyNames="Id" PageSize="3"
                runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                    <asp:BoundField DataField="Author" HeaderText="Author" SortExpression="Author" />
                    <asp:BoundField DataField="ISBN" HeaderText="ISBN" SortExpression="ISBN" />
                    <asp:BoundField DataField="WebSite" HeaderText="Web Site" SortExpression="WebSite" />
                    <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                    <asp:BoundField DataField="Category.Name" HeaderText="Category" SortExpression="Category.Name" />
                    <asp:CommandField HeaderText="Actions" ShowEditButton="true" ShowDeleteButton="true" />
                </Columns>
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>


    <asp:UpdatePanel ID="UpdatePanelCreate" UpdateMode="Conditional" ChildrenAsTriggers="true" runat="server">
        <ContentTemplate>
            <asp:LinkButton ID="LinkButtonAddNewBook" Text="Add new book" CssClass="btn btn-primary" OnClick="LinkButtonAddNewBook_Click" runat="server" />

            <asp:FormView ID="FormViewCreate" Visible="false" DefaultMode="Insert" ItemType="LybrarySystem.Models.Book" InsertMethod="FormViewCreate_InsertItem" runat="server">
                <InsertItemTemplate>
                    <fieldset>
                        <legend>Add new Book</legend>
                        <div class="form-group">
                            <label for="TextBoxTitle" class="col-lg-2 control-label">Title</label>
                            <div class="col-lg-10">
                                <asp:TextBox ID="TextBoxTitle" Text="<%# BindItem.Title %>" CssClass="form-control" placeholder="Title" runat="server" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="TextBoxAuthor" class="col-lg-2 control-label">Author</label>
                            <div class="col-lg-10">
                                <asp:TextBox ID="TextBoxAuthor" Text="<%# BindItem.Author %>" CssClass="form-control" placeholder="Author" runat="server" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="TextBoxISBN" class="col-lg-2 control-label">ISBN</label>
                            <div class="col-lg-10">
                                <asp:TextBox ID="TextBoxISBN" Text="<%# BindItem.ISBN %>" CssClass="form-control" placeholder="ISBN" runat="server" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="TextBoxWebSite" class="col-lg-2 control-label">Web Site</label>
                            <div class="col-lg-10">
                                <asp:TextBox ID="TextBoxWebSite" Text="<%# BindItem.WebSite %>" CssClass="form-control" placeholder="Web Site" runat="server" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="TextBoxDescription" class="col-lg-2 control-label">Description</label>
                            <div class="col-lg-10">
                                <asp:TextBox ID="TextBoxDescription" Text="<%# BindItem.Description %>" CssClass="form-control" Rows="3" placeholder="Description" TextMode="MultiLine" runat="server" />
                                <span class="help-block">A longer block of help text that breaks onto a new line and may extend beyond one line.</span>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="select" class="col-lg-2 control-label">Categories</label>
                            <div class="col-lg-10">
                                <asp:DropDownList ID="DropDownListCategories" ItemType="LybrarySystem.Models.Category"
                                    SelectMethod="DropDownListCategories_GetData" DataTextField="Name" DataValueField="Id" SelectedValue="<%# BindItem.CategoryId %>" runat="server" />
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-lg-10 col-lg-offset-2">
                                <asp:LinkButton Text="Add" CssClass="btn btn-primary" CommandName="Insert" runat="server" />
                                <asp:LinkButton Text="Cancel" CssClass="btn btn-default" CommandName="Cancel" runat="server" />
                            </div>
                        </div>
                    </fieldset>
                </InsertItemTemplate>
            </asp:FormView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
