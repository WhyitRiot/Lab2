﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerPortalHome.aspx.cs" Inherits="Lab2.CustomerPortalHome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
         <div>    
<fieldset style="height: 170px">
    <legend>Service Request</legend>
        
    <asp:Panel ID="Panel1" runat="server" BackColor="Blue" Height="35px" Width="1500px" ></asp:Panel>
   

    <br />
      <asp:Table ID="Table1" runat="server">
          <asp:TableRow>
              
              <asp:TableCell>
                    <asp:Label ID="lblServiceType" runat="server" Text="Service Type: "></asp:Label> 
                    <asp:TextBox ID="TextBoxService" runat="server"></asp:TextBox> <br />
            </asp:TableCell>
              </asp:TableRow>
          <asp:TableRow>
              <asp:TableCell>
                 <asp:Label ID="lblServiceDate" runat="server" Text="Service Date: "></asp:Label>
        <asp:TextBox ID="TextBoxServiceDate" runat="server"></asp:TextBox> <br />

            </asp:TableCell>
              </asp:TableRow>
          <asp:TableRow>
              <asp:TableCell>
                   <asp:Label ID="lblDescription" runat="server" Text="Description:  "></asp:Label>
        <asp:TextBox ID="TextBoxDescription" runat="server"></asp:TextBox> <br />

            </asp:TableCell>
          </asp:TableRow>

          <asp:TableRow>
              <asp:TableCell>
                  <asp:Button ID="btnSubmitRequest" runat="server" Text="Submit Request" OnClick="btnSubmitRequest_Click" />
              </asp:TableCell>
          </asp:TableRow>
      </asp:Table>

   
   
      

</fieldset>
</div>      
    </form>
</body>
</html>

       