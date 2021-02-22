<%@ Page Title="New Customers" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="New Customer.aspx.cs" Inherits="Lab2.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<%--Created by Wyatt T. Putnam--%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--Table to contain and format the text boxes and labels.--%>
     <asp:Table ID="tblCustomer" runat="server">
                <asp:TableRow >
                    <asp:TableCell>
                        <asp:Label ID="lblFirstname" runat="server" Text="First Name: "></asp:Label>
                        <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqFirstName" runat="server" ErrorMessage="Cannot be empty" ControlToValidate="txtFirstName"></asp:RequiredFieldValidator>
                        <asp:Label ID="lblLastname" runat="server" Text="Last Name: "></asp:Label>
                        <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqLastName" runat="server" ErrorMessage="Cannot be empty" ControlToValidate="txtLastName"></asp:RequiredFieldValidator>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="lblPhone" runat="server" Text="Phone Number: "></asp:Label>
                        <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqtxtPhone" runat="server" ErrorMessage="Cannot be empty" ControlToValidate="txtPhone"></asp:RequiredFieldValidator>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="lblAddress" runat="server" Text="Address" Font-style="italic"></asp:Label>
                        <br />
                        <asp:Label ID="lblStreet" runat="server" Text="Street: "></asp:Label>
                        <asp:TextBox ID="txtStreet" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqtxtStreet" runat="server" ErrorMessage="Cannot be empty" ControlToValidate="txtStreet"></asp:RequiredFieldValidator>
                        <asp:Label ID="lblCity" runat="server" Text="City: "></asp:Label>
                        <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqtxtCity" runat="server" ErrorMessage="Cannot be empty" ControlToValidate="txtCity"></asp:RequiredFieldValidator>
                        <asp:Label ID="lblState" runat="server" Text="State: "></asp:Label>
                        <asp:TextBox ID="txtState" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqtxtState" runat="server" ErrorMessage="Cannot be empty" ControlToValidate="txtState"></asp:RequiredFieldValidator>
                        <asp:Label ID="lblZip" runat="server" Text="Zip: "></asp:Label>
                        <asp:TextBox ID="txtZip" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqtxtZip" runat="server" ErrorMessage="Cannot be empty" ControlToValidate="txtZip"></asp:RequiredFieldValidator>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <%--Button to add customer to the database.--%>
                        <asp:Button ID="btnAddCustomer" runat="server" Text="Create Customer" OnClick="CreateCustomer" />
                        <%--Button to clear data from text boxes.--%>
                        <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="ClearTxt" />
                    </asp:TableCell>
                    <asp:TableCell>
                        <%--Button to populate textboxes with test data.--%>
                        <asp:Button ID="btnGenerateData" runat="server" Text="TEST: Populate with data." OnClick="GenerateData" causesvalidation="false" />
                    </asp:TableCell>
                     
                </asp:TableRow>
            </asp:Table>
</asp:Content>
