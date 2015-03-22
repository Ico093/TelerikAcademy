<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Task02.aspx.cs" Inherits="ValidationControls.Task02.Task02" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Panel runat="server">
                <asp:Label Text="Username:" runat="server" />
                <asp:TextBox ID="TextBoxUsername" runat="server" />
                <asp:RequiredFieldValidator ErrorMessage="Fill the username!" Text="*" ControlToValidate="TextBoxUsername" ValidationGroup="ValidationGroupLogonInfo" runat="server" />
            </asp:Panel>
            <asp:Panel runat="server">
                <asp:Label Text="Password:" runat="server" />
                <asp:TextBox ID="TextBoxPassword" TextMode="Password" runat="server" />
                <asp:RequiredFieldValidator ErrorMessage="Fill the password!" Text="*" ControlToValidate="TextBoxPassword" ValidationGroup="ValidationGroupLogonInfo" runat="server" />
            </asp:Panel>
            <asp:Panel runat="server">
                <asp:Label Text="Repeat password:" runat="server" />
                <asp:TextBox ID="TextBoxPasswordRepeat" TextMode="Password" runat="server" />
                <asp:RequiredFieldValidator ErrorMessage="Fill the password repeat!" Text="*" ControlToValidate="TextBoxPasswordRepeat" ValidationGroup="ValidationGroupLogonInfo" runat="server" />
                <asp:CompareValidator ErrorMessage="Passwords don't match!" ControlToValidate="TextBoxPasswordRepeat" ControlToCompare="TextBoxPassword" Type="String" ValidationGroup="ValidationGroupLogonInfo" runat="server" />
            </asp:Panel>
            <asp:Button ID="ButtonLoginInfo" Text="Submit" OnClick="ButtonLoginInfo_Click" runat="server" />

            <asp:Panel runat="server">
                <asp:Label Text="First name:" runat="server" />
                <asp:TextBox ID="TextBoxFirstName" runat="server" />
                <asp:RequiredFieldValidator ErrorMessage="Fill the first name!" Text="*" ControlToValidate="TextBoxFirstName" ValidationGroup="ValidationGroupPersonalInfo" runat="server" />
            </asp:Panel>
            <asp:Panel runat="server">
                <asp:Label Text="Last name:" runat="server" />
                <asp:TextBox ID="TextBoxLastName" runat="server" />
                <asp:RequiredFieldValidator ErrorMessage="Fill the last name!" Text="*" ControlToValidate="TextBoxLastName" ValidationGroup="ValidationGroupPersonalInfo" runat="server" />
            </asp:Panel>
            <asp:Panel runat="server">
                <asp:Label Text="Age:" runat="server" />
                <asp:TextBox ID="TextBoxAge" runat="server" />
                <asp:RequiredFieldValidator ErrorMessage="Fill the age!" Text="*" ControlToValidate="TextBoxAge" ValidationGroup="ValidationGroupPersonalInfo" runat="server" />
                <asp:CompareValidator ErrorMessage="Valid age is between 18 and 81!" ControlToValidate="TextBoxAge" Operator="LessThanEqual" ValueToCompare="81" Type="Integer" ValidationGroup="ValidationGroupPersonalInfo" runat="server" />
                <asp:CompareValidator ErrorMessage="Valid age is between 18 and 81!" ControlToValidate="TextBoxAge" Operator="GreaterThanEqual" ValueToCompare="18" Type="Integer" ValidationGroup="ValidationGroupPersonalInfo" runat="server" />
            </asp:Panel>
            <asp:Panel runat="server">
                <asp:Label Text="Email:" runat="server" />
                <asp:TextBox ID="TextBoxEmail" runat="server" />
                <asp:RequiredFieldValidator ErrorMessage="Fill the email!" Text="*" ControlToValidate="TextBoxEmail" ValidationGroup="ValidationGroupPersonalInfo" runat="server" />
                <asp:RegularExpressionValidator ErrorMessage="Enter valid email!" ControlToValidate="TextBoxEmail" ValidationExpression="\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}\b" ValidationGroup="ValidationGroupPersonalInfo" runat="server" />
            </asp:Panel>
            <asp:Button ID="ButtonPersonalInfo" Text="Submit" OnClick="ButtonPersonalInfo_Click" runat="server" />

            <asp:Panel runat="server">
                <asp:Label Text="Address:" runat="server" />
                <asp:TextBox ID="TextBoxLocalAddress" runat="server" />
                <asp:RequiredFieldValidator ErrorMessage="Fill the local address!" Text="*" ControlToValidate="TextBoxLocalAddress" ValidationGroup="ValidationGroupAddressInfo" runat="server" />
            </asp:Panel>
            <asp:Panel runat="server">
                <asp:Label Text="Phone:" runat="server" />
                <asp:TextBox ID="TextBoxPhone" runat="server" />
                <asp:RequiredFieldValidator ErrorMessage="Fill the phone number!" Text="*" ControlToValidate="TextBoxPhone" ValidationGroup="ValidationGroupAddressInfo" runat="server" />
                <asp:RegularExpressionValidator ErrorMessage="Enter valid phone number!" ControlToValidate="TextBoxPhone" ValidationExpression="^(?:(?:\+?1\s*(?:[.-]\s*)?)?(?:\(\s*([2-9]1[02-9]|[2-9][02-8]1|[2-9][02-8][02-9])\s*\)|([2-9]1[02-9]|[2-9][02-8]1|[2-9][02-8][02-9]))\s*(?:[.-]\s*)?)?([2-9]1[02-9]|[2-9][02-9]1|[2-9][02-9]{2})\s*(?:[.-]\s*)?([0-9]{4})(?:\s*(?:#|x\.?|ext\.?|extension)\s*(\d+))?" ValidationGroup="ValidationGroupAddressInfo" runat="server" />
            </asp:Panel>
            <asp:Panel runat="server">
                <asp:Label Text="Do you accept our terms?" runat="server" />
                <asp:CheckBox ID="CheckBoxAccept" runat="server" />
                <asp:CustomValidator Display="Dynamic" ClientValidationFunction="checkBoxRequiredClientValidate" OnServerValidate="CheckBoxRequired_ServerValidate" ErrorMessage="Please agree with our terms." Text="*" ValidationGroup="ValidationGroupAddressInfo" runat="server" />
            </asp:Panel>
            <asp:Button ID="ButtonAddressInfo" Text="Submit" OnClick="ButtonAddressInfo_Click" runat="server" />
        </div>
        <asp:ValidationSummary ID="ValidationSummary" runat="server" />
    </form>
</body>
</html>
