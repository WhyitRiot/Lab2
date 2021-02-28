﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Customer Portal.aspx.cs" Inherits="Lab2.Customer_Portal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">  
.auto-style1 {  
     width: 100%;  
      }  
.auto-style2 {  
     width: 278px;  
       }  
.auto-style3 {  
      width: 278px;  
      height: 23px;  
        }  
.auto-style4 {  
      height: 23px;  
        }  
</style>  
</head>

<body>
    <form id="form1" runat="server">
        <div>
            <fieldset style="height: 370px">
    <legend>Service Request</legend>
    
            <asp:Panel ID="Panel1" runat="server" BackColor="Blue" Height="35px" Width="1500px" ></asp:Panel>
            <asp:Table CssClass="auto-style1" runat="server">
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="Label1" runat="server" Text="Username">
                        </asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="Username" runat="server" required="true"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="Label6" runat="server" Text="Email ID">
                        </asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="EmailID" runat="server" TextMode="Email"></asp:TextBox>                 
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="Label3" runat="server" Text="Confirm Password"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="TextBox3" runat="server" TextMode="Password"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="Label4" runat="server" Text="Street Address"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="StreetAddress" runat="server"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>

                 <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="Label7" runat="server" Text="City"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="City" runat="server"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>

                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="Label8" runat="server" Text="State"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="State" runat="server"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>


                  <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="Label16" runat="server" Text="Zip Code"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="ZipCode" runat="server"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>

                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="Label5" runat="server" Text="Phone Number"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="PhoneNumber" runat="server" TextMode="Phone"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
             <asp:TableRow>
                 <asp:TableCell>

                 </asp:TableCell>
                 <asp:TableCell>
                     <br />
                     <asp:Button ID="Button1" runat="server" Text="Login" OnClick="Button1_Click"/>
                 </asp:TableCell>
             </asp:TableRow>
            </asp:Table>

            <asp:Label ID="message" runat="server" Font-Size="Medium" ForeColor="Red" ></asp:Label>
        </fieldset>
                </div>
    </form>
    <asp:Table Class="auto-style1" runat="server">
        <asp:TableRow>
            <asp:TableCell CssClass="auto-style2">
                <asp:Label ID="ShowUserNameLabel" runat="server"></asp:Label>               
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="ShowUserName" runat="server"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell CssClass="auto-style2">
                <asp:Label ID="ShowEmailIDLabel" runat="server" ></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="ShowEmail" runat="server" ></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell CssClass="auto-style2">
                <asp:Label ID="ShowStreetAddressLabel" runat="server" ></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="ShowStreetAddress" runat="server" ></asp:Label>
            </asp:TableCell>
        </asp:TableRow>

         <asp:TableRow>
            <asp:TableCell CssClass="auto-style2">
                <asp:Label ID="ShowZipCodelabel" runat="server" ></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="ShowZipCode" runat="server" ></asp:Label>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell CssClass="auto-style2">
                <asp:Label ID="ShowCityLabel" runat="server" ></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="ShowCity" runat="server" ></asp:Label>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell CssClass="auto-style2">
                <asp:Label ID="ShowStateLabel" runat="server" ></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="ShowState" runat="server" ></asp:Label>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell CssClass="auto-style1">
                <asp:Label ID="ShowPhoneLabel" runat="server" ></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="ShowPhone" runat="server" ></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>


    
</body>
</html>
