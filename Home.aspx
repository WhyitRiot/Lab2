<%@ Page Title="Home" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Lab2.WebForm8" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <%-- Created by Wyatt T. Putnam--%>
    <asp:Label ID="lblLoginSuccess" runat="server" Text=""></asp:Label>
    <br />    <br />    <br />    <br />    <fieldset style=height: "170px" >    <legend>Notification Alert!</legend>    <asp:Panel ID="Panel1" runat="server" BackColor="yellow" Height="100px" Width="100px" >    <asp:Label ID="LabelNotification" runat="server" Text=""></asp:Label>    </asp:Panel>    </fieldset>

</asp:Content>
