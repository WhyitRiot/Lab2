<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Edit Work Flow.aspx.cs" Inherits="Lab2.Edit_Work_Flow" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
    <%--Select an existing service ticket and view details--%>
            <asp:Label ID="lblWorkflow" runat="server" Text="Select a Service Ticket from the dropdown menu." CausesValidation="false"></asp:Label>

            <asp:DropDownList ID="ddlServiceTickets" runat="server"
                DataSourceID="dataWKFLServiceTickets"
                DataValueField="Ticket"
                OnSelectedIndexChanged="ddlSelectedIndexChanged"
                AppendDataBoundItems="true"
                AutoPostBack="true">
               <asp:ListItem Text="<--Select-->"></asp:ListItem>
            </asp:DropDownList>
            <asp:Label ID="lblEmptyTicketError" runat="server" Text=""></asp:Label>

            <br />

        <%--Gridview to view details of selected ticket--%>
            <asp:GridView ID="grdSelectedServiceTicket" EmptyDataText="No Ticket Selected." runat="server">
        
            </asp:GridView>

            <br /> <br />
            <asp:Label ID="lblTicketHistory" runat="server" Text="Ticket History"></asp:Label>

        <%--Button displays current ticket information into textboxes and dropdownlists--%>
            <asp:Button ID="btnEdit" runat="server" Text="Edit Ticket" OnClick="btnEditTicket" CausesValidation="false"/>

            <br />

            <asp:GridView ID="grdTicketHistory" runat="server">

            </asp:GridView>
            <br />

       
            <%--Panel w/ textboxes and dropdownlists displaying current ticket information--%>
    <asp:Panel ID="pnEdit" runat="server" Visible="true">
            <asp:Label ID="lblTicketStatus" runat="server" Text="Ticket Status"></asp:Label>
            <br />
            <asp:TextBox ID="txtTicketStatus" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="reqTicketStatus" runat="server" ErrorMessage="Cannot be empty" ControlToValidate="txtTicketStatus"></asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="ServiceID" runat="server" Text="Service ID:" Visible="false"></asp:Label>
            <asp:Label ID="TicketID" runat="server" Text="Ticket ID:" Visible="false"></asp:Label>
            <br />
            <asp:Label ID="lblCustomer" runat="server" Text="Customer"></asp:Label>
            <br />
            <asp:DropDownList ID="ddlCustomer" runat="server" DataSourceID="dataWKFLCustomer" DataValueField="Customer" AppendDataBoundItems="true">
                <asp:ListItem Text ="<--Select-->"></asp:ListItem>
            </asp:DropDownList>
            <asp:Label ID="lblCustEmptyError" runat="server" Text=""></asp:Label>
            <br />

            <asp:Label ID="lblOrigin" runat="server" Text="Origin Address: "></asp:Label>
            <br />
            <asp:TextBox ID="txtOrigin" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="reqOrigin" runat="server" ErrorMessage="Cannot be empty" ControlToValidate="txtOrigin"></asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="lblDestination" runat="server" Text="Destination Address: "></asp:Label>
            <br />
            <asp:TextBox ID="txtDestination" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="reqDestination" runat="server" ErrorMessage="Cannot be empty" ControlToValidate="txtDestination"></asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="lblEmployee" runat="server" Text="Employee"></asp:Label>
            <br />
            <asp:DropDownList ID="ddlEmployee" runat="server" DataSourceID="dataWKFLEmp" DataValueField="Employee" AppendDataBoundItems="true">
                <asp:ListItem Text="<--Select-->"></asp:ListItem>
            </asp:DropDownList>
            <asp:Label ID="lblEmpEmptyError" runat="server" Text=""></asp:Label>
            <br />

        <%--Buttons to save changes, which writes the data in the panel to the DB, and one to cancel which clears all textboxes.--%>
            <asp:Button ID="btnSaveChanges" runat="server" Text="Save Changes" OnClick="btnSaveChanges_Click" />
            <br />
            <asp:Button ID="btnIDCancelEdit" runat="server" Text="Cancel" OnClick ="btnCancelEdit" CausesValidation="false"/>
      </asp:Panel>

            <asp:SqlDataSource ID="dataWKFLCustomer" runat="server"
                 ConnectionString="<%$ ConnectionStrings:Lab2 %>"
                 SelectCommand="Select concat(CustomerID, ', ', lastname, ', ', firstname) as Customer from Customer;">
            </asp:SqlDataSource>

            <asp:SqlDataSource ID="dataWKFLEmp" runat="server"
                 ConnectionString="<%$ ConnectionStrings:Lab2 %>"
                 SelectCommand="Select concat(empID, ', ', lastname, ', ', firstname) as Employee from Employee;">
            </asp:SqlDataSource>

            <asp:SqlDataSource ID="dataWKFLServiceTickets" runat="server"
                 ConnectionString="<%$ ConnectionStrings:Lab2 %>"
                 SelectCommand="Select concat(ServiceTicketID, ', ', Customer.LastName, ', ', Customer.FirstName) as Ticket 
                                from Service_Ticket INNER JOIN Customer ON Customer.CustomerID = Service_Ticket.CustomerID;">
            </asp:SqlDataSource>
<%--            <asp:SqlDataSource ID="dataWKFLTicketHistory" runat="server"
                 ConnectionString="<%$ ConnectionStrings:Lab2 %>"
                 SelectCommand="Select * FROM TicketHistory WHERE ServiceTicketID =">

            </asp:SqlDataSource>--%>
            
        </div>
</asp:Content>
