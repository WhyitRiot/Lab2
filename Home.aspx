<%@ Page Title="Home" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Lab2.WebForm8" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <%-- Created by Wyatt T. Putnam--%>
    <asp:Label ID="lblLoginSuccess" runat="server" Text=""></asp:Label>
    <br />    <br />    <br />    <br />    <fieldset ID="fldNotifications" style=height: "170px" >        <asp:Panel ID="pnlNotifications" runat="server" Height="100px" Width="100px" >     <legend>Notification Alert!</legend>    <asp:GridView ID="grdNotifictions" runat="server" DataSourceID="sqlSourceNotifications"></asp:GridView>    <asp:Button ID="btnClear" runat="server" Text="Clear Notifications" OnClick="btn_Clear" />    </asp:Panel>        </fieldset>
    <asp:SqlDataSource ID="sqlSourceNotifications" runat="server"
       ConnectionString="<%$ ConnectionStrings:Lab2 %>"
       SelectCommand="Select Customer, ServiceNeeded, DateNeeded, NoteDescription from Notifications;">
    </asp:SqlDataSource>
</asp:Content>
