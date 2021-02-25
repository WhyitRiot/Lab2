<%@ Page Title="Add New Workflow" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Work Flow.aspx.cs" Inherits="Lab2.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<%--Created by Wyatt T. Putnam, Cole Schweikert, Shaima Sorchi--%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <%--Labels and cooresponding text boxes and dropdownlists to create a Service_Ticket--%>
            <asp:Label ID="lblNewWorkflow" runat="server" Text="Create new workflow."></asp:Label>
            <br />
            <asp:Label ID="lblDescriptionCustomer" runat="server" Text="Select Customer: "></asp:Label>
            <asp:DropDownList ID="ddlWorkflowCustomer" runat="server"
                DataSourceID="dataWKFLCustomer" DataValueField="Customer">
            </asp:DropDownList>
            <br />
            <asp:CheckBox ID="chbxWorkflowMove" runat="server" text="Move"/>
            <br />
            <asp:Label ID="lblOriginAddress" runat="server" Text="Origin Address: "></asp:Label>
            <asp:TextBox ID="txtboxOriginAddress" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="reqOriginAddress" runat="server" ErrorMessage="Cannot be empty" ControlToValidate="txtboxOriginAddress"></asp:RequiredFieldValidator>
            <asp:Label ID="lblDestinationAddress" runat="server" Text="Destination Address: "></asp:Label>
            <asp:TextBox ID="txtboxDestinationAddress" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="reqDestinationAddress" runat="server" ErrorMessage="Cannot be empty" ControlToValidate="txtboxDestinationAddress"></asp:RequiredFieldValidator>
            <br />
            <asp:CheckBox ID="chbxWorkflowAuction" runat="server" text="Auction" />
            
            <br />
            <asp:Label ID="lblDescriptionEmployee" runat="server" Text="Select Attending Employee: "></asp:Label>
            <asp:DropDownList ID="ddlWorkflowEmp" runat="server"
                DataSourceID="dataWKFLEmp" DataValueField="Employee">
            </asp:DropDownList>
            <br />
            <asp:Label ID="lblNotes" runat="server" Text="Note: "></asp:Label>
            <br />
            <asp:Label ID="lblNoteTitle" runat="server" Text="Title: "></asp:Label>
            <asp:TextBox ID="txtNoteTitle" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblNoteBody" runat="server" Text="Notes: "></asp:Label>
            <asp:TextBox ID="txtNoteBody" runat="server" Height="100"></asp:TextBox>
            <br />
        <%--Button takes all values in dropdownlists and text boxes and creates a Service ticket entry--%>
            <asp:Button ID="butnAddWorkFlow" runat="server" Text="Add Workflow" OnClick="btnAddWorkFlow"/>

            <br /> <br />

        <%--Select an existing service ticket and view details--%>
            <asp:Label ID="lblWorkflow" runat="server" Text="Select a Service Ticket from the dropdown menu." CausesValidation="false"></asp:Label>

            <asp:DropDownList ID="ddlServiceTickets" runat="server"
                DataSourceID="dataWKFLServiceTickets"
                DataValueField="Ticket"
                OnSelectedIndexChanged="ddlSelectedIndexChanged"
                AutoPostBack="true">
            </asp:DropDownList>

            <br />

        <%--Gridview to view details of selected ticket--%>
            <asp:GridView ID="grdSelectedServiceTicket" EmptyDataText="No Ticket Selected." runat="server">
        
            </asp:GridView>

            <br /> <br />
            <asp:Label ID="lblTicketHistory" runat="server" Text="Ticket History"></asp:Label>

        <%--Button displays current ticket information into textboxes and dropdownlists--%>
            <asp:Button ID="btnEdit" runat="server" Text="Edit Ticket" OnClick="btnEditTicket" />

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
            <asp:DropDownList ID="ddlCustomer" runat="server" DataSourceID="dataWKFLCustomer" DataValueField="Customer"></asp:DropDownList>
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
            <asp:DropDownList ID="ddlEmployee" runat="server" DataSourceID="dataWKFLEmp" DataValueField="Employee"></asp:DropDownList>
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
