<%@ Page Title="New Customers" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="New Customer.aspx.cs" Inherits="Lab2.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<%--Created by Wyatt T. Putnam, Cole Schweikert, Shaima Sorchi--%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--Table to contain and format the text boxes and labels.--%>
 
                 <asp:Table runat="server">
                     <asp:TableRow>
                         <asp:TableCell>
                        <asp:Label ID="lblFirstname" runat="server" Text="First Name: "></asp:Label>
                         </asp:TableCell>
                         <asp:TableCell>
                        <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqFirstName" runat="server" ErrorMessage="Cannot be empty" ControlToValidate="txtFirstName"></asp:RequiredFieldValidator>
                         </asp:TableCell>
                     </asp:TableRow>
                     <asp:TableRow>
                         <asp:TableCell>
                         <asp:Label ID="lblLastname" runat="server" Text="Last Name: "></asp:Label>
                         </asp:TableCell>
                         <asp:TableCell>
                          <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="reqLastName" runat="server" ErrorMessage="Cannot be empty" ControlToValidate="txtLastName"></asp:RequiredFieldValidator>
                         </asp:TableCell>
                     </asp:TableRow>
                     <asp:TableRow>
                         <asp:TableCell>
                     <asp:Label ID="lblHowDid" runat="server" Text="How did you contact us: "></asp:Label>
                         </asp:TableCell>
                         <asp:TableCell>
                             <asp:DropDownList ID="HowDidDropDown" runat="server">
                                 <asp:ListItem Text="<-- Select -->"></asp:ListItem>
                                 <asp:ListItem Text="Phone"></asp:ListItem>
                                 <asp:ListItem Text="Email"></asp:ListItem>
                                 <asp:ListItem Text="Text"></asp:ListItem>
                                 <asp:ListItem Text="Other"></asp:ListItem>
                             </asp:DropDownList>
                         </asp:TableCell>
                     </asp:TableRow>
                     <asp:TableRow>
                         <asp:TableCell>
                             <asp:Label ID="lblHear" runat="server" Text="How did you hear about us: "></asp:Label>
                         </asp:TableCell>
                         <asp:TableCell>
                             <asp:TextBox ID="txtHear" runat="server"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="reqtxtHear" runat="server" ErrorMessage="Cannot be empty" ControlToValidate="txtHear"></asp:RequiredFieldValidator>
                         </asp:TableCell>
                     </asp:TableRow>
                     <asp:TableRow>
                         <asp:TableCell>
                             <asp:Label ID="lblChooseService" runat="server" Text="What service are you interested in today?"></asp:Label>
                         </asp:TableCell>
                         <asp:TableCell>
                             <asp:DropDownList ID="ChooseServiceDropDown" runat="server">
                                 <asp:ListItem Text="<-- Select -->"></asp:ListItem>
                                 <asp:ListItem Text="Moving"></asp:ListItem>
                                 <asp:ListItem Text="Auction"></asp:ListItem>
                             </asp:DropDownList>
                         </asp:TableCell>
                     </asp:TableRow>
                     <asp:TableRow>
                         <asp:TableCell>
                        <asp:Label ID="lblPhone" runat="server" Text="Phone Number: "></asp:Label>                        
                         </asp:TableCell>

                         <asp:TableCell>
                             <asp:DropDownList ID="PhoneTypeDropDown" runat="server">
                                 <asp:ListItem Text="<-- Select -->"></asp:ListItem>
                                 <asp:ListItem Text="Home"></asp:ListItem>
                                 <asp:ListItem Text="Cell"></asp:ListItem>
                                 <asp:ListItem Text="Business"></asp:ListItem>
                                 
                             </asp:DropDownList>
                        <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqtxtPhone" runat="server" ErrorMessage="Cannot be empty" ControlToValidate="txtPhone"></asp:RequiredFieldValidator>
                         </asp:TableCell>
                     </asp:TableRow>
                     <asp:TableRow>
                         <asp:TableCell>
                          <asp:Label ID="lblAddress" runat="server" Text="Address: " Font-style="italic"></asp:Label>
                         </asp:TableCell>
                         <asp:TableCell>
                        <asp:Label ID="lblStreet" runat="server" Text="Street: "></asp:Label>
                        <asp:TextBox ID="txtStreet" runat="server"></asp:TextBox>
<%--                        <asp:RequiredFieldValidator ID="reqtxtStreet" runat="server" ErrorMessage="Cannot be empty" ControlToValidate="txtStreet"></asp:RequiredFieldValidator>--%>
                        <asp:Label ID="lblCity" runat="server" Text="City: "></asp:Label>
                        <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
<%--                        <asp:RequiredFieldValidator ID="reqtxtCity" runat="server" ErrorMessage="Cannot be empty" ControlToValidate="txtCity"></asp:RequiredFieldValidator>--%>
                        <asp:Label ID="lblState" runat="server" Text="State: "></asp:Label>
                        <asp:TextBox ID="txtState" runat="server"></asp:TextBox>
<%--                        <asp:RequiredFieldValidator ID="reqtxtState" runat="server" ErrorMessage="Cannot be empty" ControlToValidate="txtState"></asp:RequiredFieldValidator>--%>
                        <asp:Label ID="lblZip" runat="server" Text="Zip: "></asp:Label>
                        <asp:TextBox ID="txtZip" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqtxtZip" runat="server" ErrorMessage="Fillout all address information" ControlToValidate="txtZip"></asp:RequiredFieldValidator>
                         </asp:TableCell>
                     </asp:TableRow>
                     <asp:TableRow>
                         <asp:TableCell>
                             <asp:Label ID="lblEmail" runat="server" Text="Enter Email: "></asp:Label>
                         </asp:TableCell>
                         <asp:TableCell>
                             <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="reqtxtEmail" runat="server" ErrorMessage="Cannot be empty" ControlToValidate="txtEmail"></asp:RequiredFieldValidator>
                         </asp:TableCell>
                     </asp:TableRow>
                     <asp:TableRow>
                         <asp:TableCell>
                             <asp:Label ID="lblMovingCalendar" runat="server" Text="Select Date for Moving: "></asp:Label>
                         </asp:TableCell>
                         <asp:TableCell>
                             <asp:Calendar ID="MovingCalendar" runat="server"></asp:Calendar>
                         </asp:TableCell>
                     </asp:TableRow>
                     <asp:TableRow>
                         <asp:TableCell>
                             <asp:Label ID="lblAuction" runat="server" Text="Select Date for Auction: "></asp:Label>    
                         </asp:TableCell>
                         <asp:TableCell>
                             <asp:Calendar ID="AuctionCalendar" runat="server"></asp:Calendar>
                         </asp:TableCell>
                     </asp:TableRow>
                 </asp:Table>
                  

                  
           

                  

                    
         

                   

                        <%--Button to add customer to the database.--%>
                        <asp:Button ID="btnAddCustomer" runat="server" Text="Create Customer" OnClick="CreateCustomer" />
                        <%--Button to clear data from text boxes.--%>
                        <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="ClearTxt" />
          
                        <%--Button to populate textboxes with test data.--%>
                        <asp:Button ID="btnGenerateData" runat="server" Text="Populate" OnClick="GenerateData" causesvalidation="false" />
      
</asp:Content>
