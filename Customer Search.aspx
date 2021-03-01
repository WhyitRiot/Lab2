<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Customer Search.aspx.cs" Inherits="Lab2.Customer_Search" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Table runat="server">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblCustomerName" runat="server" Text="Search for Customer Below"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblCustomerSearch" runat="server" Text="Enter First or Last Name: "></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtCustomerName" runat="server"></asp:TextBox>
            </asp:TableCell>
            </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
<%--                <asp:Label ID="lblCustomerLastName" runat="server" Text="Enter Last Name: "></asp:Label>--%>
            </asp:TableCell>
            <asp:TableCell>
<%--                <asp:TextBox ID="txtCustomerLastName" runat="server"></asp:TextBox>--%>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:GridView ID="grdServiceTickets" runat="server"></asp:GridView>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>
