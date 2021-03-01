<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit Ticket.aspx.cs" Inherits="Lab2.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblServiceTicketID" runat="server" Text="Service Ticket ID"></asp:Label>
            <br />
            <asp:TextBox ID="txtServiceTicketID" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblTicketStatus" runat="server" Text="Ticket Status" Visible="false"></asp:Label>
           
            <asp:TextBox ID="txtTicketStatus" runat="server"></asp:TextBox>
            <br />

            <asp:Label ID="lblCustomer" runat="server" Text="Customer"></asp:Label>
            <br />
            <asp:TextBox ID="txtCustomer" runat="server"></asp:TextBox>
            <br />

            <asp:Label ID="lblService" runat="server" Text="Service"></asp:Label>
            <br />
            <asp:TextBox ID="txtService" runat="server"></asp:TextBox>
            <br />

            <asp:Label ID="lblEmployee" runat="server" Text="Employee"></asp:Label>
            <br />
            <asp:TextBox ID="txtEmployee" runat="server"></asp:TextBox>

            <asp:Button ID="btnSaveChanges" runat="server" Text="Save Changes" OnClick="btnSaveChanges_Click" />

        </div>
    </form>
</body>
</html>
