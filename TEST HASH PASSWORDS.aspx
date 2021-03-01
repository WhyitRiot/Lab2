<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TEST HASH PASSWORDS.aspx.cs" Inherits="Lab2.TEST_HASH_PASSWORDS" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
            <asp:Button ID="btnHash" runat="server" Text="Hash that shit" OnClick ="btn_Hash" />

            <asp:Label ID="lblResult" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
