<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Task06.aspx.cs" Inherits="WebAndHTMLControls.Task06" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div>
            <asp:TextBox runat="server" ID="tbxResult"/>
        </div>
        <div>
            <asp:Button runat="server" Text="1" OnCommand="Btn_OnClick" CommandArgument="1"/>
            <asp:Button runat="server" Text="2" OnCommand="Btn_OnClick" CommandArgument="2"/>
            <asp:Button runat="server" Text="3" OnCommand="Btn_OnClick" CommandArgument="3"/>
            <asp:Button runat="server" Text="+" OnCommand="Btn_OnClick" CommandArgument="+"/>
        </div>
        <div>
            <asp:Button runat="server" Text="4" OnCommand="Btn_OnClick" CommandArgument="4"/>
            <asp:Button runat="server" Text="5" OnCommand="Btn_OnClick" CommandArgument="5"/>
            <asp:Button runat="server" Text="6" OnCommand="Btn_OnClick" CommandArgument="6"/>
            <asp:Button runat="server" Text="-" OnCommand="Btn_OnClick" CommandArgument="-"/>
        </div>
        <div>
            <asp:Button runat="server" Text="7" OnCommand="Btn_OnClick" CommandArgument="7"/>
            <asp:Button runat="server" Text="8" OnCommand="Btn_OnClick" CommandArgument="8"/>
            <asp:Button runat="server" Text="9" OnCommand="Btn_OnClick" CommandArgument="9"/>
            <asp:Button runat="server" Text="X" OnCommand="Btn_OnClick" CommandArgument="X"/>
        </div>
        <div>
            <asp:Button runat="server" Text="Clear" OnCommand="Btn_OnClick" CommandArgument="Clear"/>
            <asp:Button runat="server" Text="0" OnCommand="Btn_OnClick" CommandArgument="0"/>
            <asp:Button runat="server" Text="/" OnCommand="Btn_OnClick" CommandArgument="/"/>
            <asp:Button runat="server" Text="√" OnCommand="Btn_OnClick" CommandArgument="√"/>
        </div>
        <div>
            <asp:Button runat="server" Text="=" OnCommand="Btn_OnClick" CommandArgument="="/>
            <asp:HiddenField runat="server" ID="firstNumber"/>
            <asp:HiddenField runat="server" ID="operation"/>
        </div>
    </div>
    </form>
</body>
</html>
