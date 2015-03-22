<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Task01.aspx.cs" Inherits="DataSourceControls.Task01.Task01" %>

<%@ Import Namespace="DataSourceControls.Task01" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:EntityDataSource ID="EntityDataSourceContinents" runat="server" ConnectionString="name=WorldEntities"
                DefaultContainerName="WorldEntities" EnableFlattening="False" EntitySetName="Continents" EnableDelete="True" EnableInsert="True" EnableUpdate="True">
            </asp:EntityDataSource>

            <asp:EntityDataSource ID="EntityDataSourceCountries" runat="server" ConnectionString="name=WorldEntities"
                DefaultContainerName="WorldEntities" EnableFlattening="False" EntitySetName="Countries" Where="it.Continent=@ContinentID" EnableDelete="True" EnableInsert="True" EnableUpdate="True">
                <WhereParameters>
                    <asp:ControlParameter Name="ContinentID" ControlID="ListBoxContinents" Type="Int32" />
                </WhereParameters>
            </asp:EntityDataSource>

            <asp:EntityDataSource ID="EntityDataSourceTowns" runat="server" ConnectionString="name=WorldEntities"
                DefaultContainerName="WorldEntities" EnableFlattening="False" EntitySetName="Towns" Where="it.Country=@CountryID" EnableDelete="True" EnableInsert="True" EnableUpdate="True">
                <WhereParameters>
                    <asp:ControlParameter Name="CountryID" ControlID="GridViewCountries" Type="Int32" />
                </WhereParameters>
            </asp:EntityDataSource>

            <asp:ListBox runat="server" ID="ListBoxContinents" DataSourceID="EntityDataSourceContinents"
                DataValueField="Id" DataTextField="Name" AutoPostBack="true" />

            <asp:GridView runat="server" ID="GridViewCountries" DataSourceID="EntityDataSourceCountries" AutoGenerateColumns="False" DataKeyNames="Id" AllowPaging="True" AllowSorting="True" AutoPostBack="true">
                <Columns>
                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" />
                    <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id" />
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                    <asp:BoundField DataField="Language" HeaderText="Language" SortExpression="Language" />
                    <asp:BoundField DataField="Population" HeaderText="Population" SortExpression="Population" />
                    <asp:BoundField DataField="Continent" HeaderText="Continent" SortExpression="Continent" />
                </Columns>
            </asp:GridView>

            <asp:ListView ID="ListViewTowns" runat="server" DataSourceID="EntityDataSourceTowns" ItemType="Town" AutoPostBack="true" DataKeyNames="Id" InsertItemPosition="LastItem">
                <LayoutTemplate>
                    <table runat="server">
                        <tr runat="server">
                            <td runat="server">
                                <table id="itemPlaceholderContainer" runat="server" border="0" style="">
                                    <tr runat="server" style="">
                                        <th runat="server"></th>
                                        <th runat="server">Id</th>
                                        <th runat="server">Name</th>
                                        <th runat="server">Population</th>
                                        <th runat="server">Country</th>
                                        <th runat="server">Country1</th>
                                    </tr>
                                    <tr id="itemPlaceholder" runat="server">
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr runat="server">
                            <td runat="server" style="">
                                <asp:DataPager ID="DataPager1" runat="server">
                                    <Fields>
                                        <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowLastPageButton="True" />
                                    </Fields>
                                </asp:DataPager>
                            </td>
                        </tr>
                    </table>
                </LayoutTemplate>

                <AlternatingItemTemplate>
                    <tr style="">
                        <td>
                            <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                            <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                        </td>
                        <td>
                            <asp:Label ID="IdLabel" runat="server" Text='<%# Eval("Id") %>' />
                        </td>
                        <td>
                            <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
                        </td>
                        <td>
                            <asp:Label ID="PopulationLabel" runat="server" Text='<%# Eval("Population") %>' />
                        </td>
                        <td>
                            <asp:Label ID="CountryLabel" runat="server" Text='<%# Eval("Country") %>' />
                        </td>
                        <td>
                            <asp:Label ID="Country1Label" runat="server" Text='<%# Eval("Country1") %>' />
                        </td>
                    </tr>
                </AlternatingItemTemplate>
                <EditItemTemplate>
                    <tr style="">
                        <td>
                            <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
                            <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
                        </td>
                        <td>
                            <asp:Label ID="IdLabel1" runat="server" Text='<%# Eval("Id") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="NameTextBox" runat="server" Text='<%# Bind("Name") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="PopulationTextBox" runat="server" Text='<%# Bind("Population") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="CountryTextBox" runat="server" Text='<%# Bind("Country") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="Country1TextBox" runat="server" Text='<%# Bind("Country1") %>' />
                        </td>
                    </tr>
                </EditItemTemplate>
                <EmptyDataTemplate>
                    <table runat="server" style="">
                        <tr>
                            <td>No data was returned.</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <InsertItemTemplate>
                    <tr style="">
                        <td>
                            <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" />
                            <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Clear" />
                        </td>
                        <td>
                            <asp:TextBox ID="IdTextBox" runat="server" Text='<%# Bind("Id") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="NameTextBox" runat="server" Text='<%# Bind("Name") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="PopulationTextBox" runat="server" Text='<%# Bind("Population") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="CountryTextBox" runat="server" Text='<%# Bind("Country") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="Country1TextBox" runat="server" Text='<%# Bind("Country1") %>' />
                        </td>
                    </tr>
                </InsertItemTemplate>

                <ItemTemplate>
                    <tr style="">
                        <td>
                            <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                            <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                        </td>
                        <td>
                            <asp:Label ID="IdLabel" runat="server" Text='<%# Eval("Id") %>' />
                        </td>
                        <td>
                            <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
                        </td>
                        <td>
                            <asp:Label ID="PopulationLabel" runat="server" Text='<%# Eval("Population") %>' />
                        </td>
                        <td>
                            <asp:Label ID="CountryLabel" runat="server" Text='<%# Eval("Country") %>' />
                        </td>
                        <td>
                            <asp:Label ID="Country1Label" runat="server" Text='<%# Eval("Country1") %>' />
                        </td>
                    </tr>
                </ItemTemplate>
                <SelectedItemTemplate>
                    <tr style="">
                        <td>
                            <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                            <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                        </td>
                        <td>
                            <asp:Label ID="IdLabel" runat="server" Text='<%# Eval("Id") %>' />
                        </td>
                        <td>
                            <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
                        </td>
                        <td>
                            <asp:Label ID="PopulationLabel" runat="server" Text='<%# Eval("Population") %>' />
                        </td>
                        <td>
                            <asp:Label ID="CountryLabel" runat="server" Text='<%# Eval("Country") %>' />
                        </td>
                        <td>
                            <asp:Label ID="Country1Label" runat="server" Text='<%# Eval("Country1") %>' />
                        </td>
                    </tr>
                </SelectedItemTemplate>
            </asp:ListView>
        </div>
    </form>
</body>
</html>
