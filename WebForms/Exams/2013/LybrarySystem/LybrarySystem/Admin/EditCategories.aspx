<%@ Page Title="Edit Categories" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditCategories.aspx.cs" Inherits="LybrarySystem.Admin.EditCategories" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:UpdatePanel ID="UpdatePanelCategories" runat="server">
        <ContentTemplate>
            <asp:ListView ID="ListViewCategories" 
                ItemType="LybrarySystem.Models.Category" 
                SelectMethod="ListViewCategories_GetData"
                UpdateMethod="ListViewCategories_UpdateItem" 
                DeleteMethod="ListViewCategories_DeleteItem" 
                DataKeyNames="Id" runat="server">
                <LayoutTemplate>
                    <table class="gridview" border="1" style="border-collapse: collapse;">
                        <thead>
                            <tr>
                                <th scope="col">
                                    <asp:LinkButton Text="Category Name" CommandName="Sort" CommandArgument="Name" runat="server" />
                                </th>
                                <th scope="col">
                                    <asp:Label Text="Action" runat="server" />
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                            <tr>
                                <td colspan="2">
                                    <asp:DataPager ID="DataPagerCategories" PagedControlID="ListViewCategories" PageSize="3" runat="server">
                                        <Fields>
                                            <asp:NumericPagerField />
                                        </Fields>
                                    </asp:DataPager>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:Label Text="<%#: Item.Name %>" runat="server" />
                        </td>
                        <td>
                            <asp:Button Text="Edit" CommandName="Edit" runat="server" />
                            <asp:Button Text="Delete" CommandName="Delete" runat="server" />
                        </td>
                    </tr>
                </ItemTemplate>
                <EditItemTemplate>
                    <tr>
                        <td>
                            <asp:TextBox ID="TextBoxEditName" Text="<%#: BindItem.Name %>" runat="server" />
                        </td>
                        <td>
                            <asp:Button Text="Save" CommandName="Update" runat="server" />
                            <asp:Button Text="Cancel" CommandName="Cancel" runat="server" />
                        </td>
                    </tr>
                </EditItemTemplate>
            </asp:ListView>
        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:UpdatePanel ID="UpdatePanelCreate" UpdateMode="Conditional" ChildrenAsTriggers="true" runat="server">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="LinkButtonAdd" EventName="Click" />
        </Triggers>
        <ContentTemplate>
            <asp:LinkButton ID="LinkButtonAdd" Text="Add New" CssClass="btn btn-primary" OnClick="LinkButtonAdd_Click" runat="server" />

            <asp:FormView ID="FormViewCreate" ItemType="LybrarySystem.Models.Category" InsertMethod="FormViewCreate_InsertItem" DefaultMode="Insert" Visible="false" runat="server">
                <InsertItemTemplate>
                    <div>
                        <asp:TextBox ID="TextBoxEditName" Text="<%#: BindItem.Name %>" runat="server" />
                        <asp:Button ID="ButtonSave" Text="Save" CommandName="Insert" runat="server" />
                        <asp:Button Text="Cancel" CommandName="Cancel" runat="server" />
                    </div>
                </InsertItemTemplate>
            </asp:FormView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
