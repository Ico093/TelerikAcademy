<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmpDetails.aspx.cs" Inherits="DataBinding.Task02.EmpDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:DetailsView runat="server"
                ID="employeeDetailsView"
                AutoGenerateRows="true" />
                
            <asp:Button runat="server"
                ID="btnBack" 
                Text="Back"
                OnClick="BtnBack_Click"/>
        </div>
    </form>
</body>
</html>
