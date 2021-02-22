<%@ Page Title="Current Customers" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Current Customers.aspx.cs" Inherits="Lab2.WebForm6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
            <asp:Label ID="studentLabel" runat="server" Text="Wyatt T Putnam"></asp:Label>
            <br />

           <%-- Dropdown box to show all current customers.--%>
            <asp:Label ID="lblCurrentCustomers" runat="server" Text="Current Customers"></asp:Label>
        </div>

        <%--Dropdown box with an SQL Source. Displays the last and first name of all customers in the DB.--%>
        <asp:DropDownList ID="ddlCurrentCustomers" runat="server" OnSelectedIndexChanged="ddlCurrentCustomers_SelectedIndexChanged" DataSourceID="datasrcDropDown" DataValueField="CurrentCustomer" AutoPostBack="true">
        </asp:DropDownList>
        <br />

        <%--On click, this button will request the inventory data of all items belonging to the customer selected in the dropdown box.--%>
        <asp:Button ID="btnSelect" runat="server" Text="Show Inventory" OnClick="btnDisplayInventory" />
        <br />
        <asp:Label ID="lblInventory" runat="server" Text="Inventory"></asp:Label>

        <%--Grid view to display inventory data.--%>
        <asp:GridView ID="grdInventory" EmptyDataText="No Customer Selected." runat="server">
        
        </asp:GridView>

        <asp:SqlDataSource
            ID="datasrcDropDown"
            runat="server"
            ConnectionString="<%$ ConnectionStrings:Lab2 %>"
            SelectCommand="Select concat(lastname, ', ', firstname) as CurrentCustomer from Customer;">
        </asp:SqlDataSource>
</asp:Content>
