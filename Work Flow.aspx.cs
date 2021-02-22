using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//Created by Wyatt T. Putnam

namespace Lab2
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] != null)
            {

            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }
        }

        //Function to add a Service_Ticket and a Ticket History to the DB
        protected void btnAddWorkFlow(object sender, EventArgs e)
        {
            //Insert statements declared as String values.
            String newAuction = "INSERT INTO Auction (ServiceID, empID) VALUES ";
            String newMove = "INSERT INTO \"Move\" (ServiceID, empID, originAddress, destAddress) VALUES ";
            String newService = "INSERT INTO \"Service\" (CustomerID, ServiceID, InventoryID, \"Date\") VALUES ";
            String newWorkFlow = "INSERT INTO Service_Ticket (ServiceTicketID, TicketStatus, TicketOpenDate, CustomerID, ServiceID, empID) VALUES ";
            String newInventory = "INSERT INTO Inventory (inventoryID, CustomerID, \"date\") VALUES ";
            String newHistory = "INSERT INTO TicketHistory (TicketHistoryID, TicketChangeDate, ServiceTicketID, empID) VALUES ";
            String ticketQuery = "SELECT MAX(ServiceTicketID) from Service_Ticket";

            String sqlQuery = "SELECT MAX(ServiceID) as ServiceID FROM Service";
            String connectionString = ConfigurationManager.ConnectionStrings["Lab2"].ConnectionString;

            //Establish SQL connection and reader object to retrieve information from the DB.
            SqlConnection sqlConnect = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnect);
            sqlConnect.Open();
            SqlDataReader reader = sqlCommand.ExecuteReader();
            reader.Read();
            int serviceID = (int)reader["ServiceID"] + 1;
            reader.Close();

            //Get the last inventoryID and set the new inventoryID as 1 + the last
            sqlQuery = "SELECT MAX(inventoryID) as InventoryID FROM Inventory";
            sqlCommand = new SqlCommand(sqlQuery, sqlConnect);
            reader = sqlCommand.ExecuteReader();
            reader.Read();
            int inventoryID = (int)reader["InventoryID"] + 1;
            reader.Close();

            //Get the CustomerID using the selected Customer
            sqlQuery = "SELECT CustomerID, concat(lastname, ', ', firstname) as CustomerID from Customer WHERE concat(lastname, ', ', firstname) = " + "'" + ddlWorkflowCustomer.SelectedValue.Substring(3) + "'";
            sqlCommand = new SqlCommand(sqlQuery, sqlConnect);
            reader = sqlCommand.ExecuteReader();
            reader.Read();
            String custID = reader["CustomerID"].ToString();
            reader.Close();

            //Get the employeeID using the selected Employee
            String employee = ddlWorkflowEmp.SelectedValue.Substring(3);
            String empQuery = "SELECT empID, concat(lastname, ', ', firstname) as Employee from Employee WHERE concat(lastname, ', ', firstname) = " + "'" + employee + "'";
            sqlCommand = new SqlCommand(empQuery, sqlConnect);
            reader = sqlCommand.ExecuteReader();
            reader.Read();
            String empID = reader["empID"].ToString();
            reader.Close();

            //Create a new TicketID by adding 1 to the last ticketID
            //If there are no ticketIDs the TicketID = 1
            ticketQuery = "SELECT MAX(ServiceTicketID) as TicketID from Service_Ticket";
            sqlCommand = new SqlCommand(ticketQuery, sqlConnect);
            reader = sqlCommand.ExecuteReader();
            reader.Read();
            int ticketID;
            if (reader["TicketID"].ToString() == "" || reader["TicketID"].ToString() == null)
            {
                ticketID = 1;
            }
            else
            {
                ticketID = (int)reader["TicketID"] + 1;
            }
            reader.Close();

            //Create a tickethistoryID using the same method as TicketID above
            String ticketHistoryQuery = "SELECT MAX(ServiceTicketID) as TicketHistory from TicketHistory";
            sqlCommand = new SqlCommand(ticketHistoryQuery, sqlConnect);
            reader = sqlCommand.ExecuteReader();
            reader.Read();
            int ticketHistoryID;
            if (reader["TicketHistory"].ToString() == "" || reader["TicketHistory"].ToString() == null)
            {
                ticketHistoryID = 1;
            }
            else
            {
                ticketHistoryID = (int)reader["TicketHistory"] + 1;
            }
            reader.Close();

          
            //Create a new inventory entry
            newInventory += "(" + inventoryID.ToString() + ", " + custID.ToString() + ", " + "'" + DateTime.Now.ToString() + "'" + ")";
            sqlCommand = new SqlCommand(newInventory, sqlConnect);


            int result = sqlCommand.ExecuteNonQuery();

            if (result < 0)
            {
                Console.WriteLine("Error inserting data into Database!");
            }
            
            //Create a new Service event
            newService += "(" + custID.ToString() + ", " + serviceID.ToString() + ", " + inventoryID.ToString() + ", " + "'" + DateTime.Now.ToString() + "'" + ")";
            sqlCommand = new SqlCommand(newService, sqlConnect);

            result = sqlCommand.ExecuteNonQuery();

            if (result < 0)
            {
                Console.WriteLine("Error inserting data into Database!");
            }

            //Create a Move event if option is checked
            if (chbxWorkflowMove.Checked)
            {
                
                String originAddress = txtboxOriginAddress.Text;
                String destAddress = txtboxDestinationAddress.Text;

                newMove += "(" + serviceID.ToString() + ", " + empID.ToString() + ", " + "'" + originAddress + "'" + ", " + "'" + destAddress + "'" + ")";

                sqlCommand = new SqlCommand(newMove, sqlConnect);

                result = sqlCommand.ExecuteNonQuery();

                if (result < 0)
                {
                    Console.WriteLine("Error inserting data into Database!");
                }

            }

            //Create an Auction event if option is checked
            if (chbxWorkflowAuction.Checked)
            {

                newAuction += "(" + serviceID.ToString() + ", " + empID.ToString() + ")";

                sqlCommand = new SqlCommand(newAuction, sqlConnect);

                result = sqlCommand.ExecuteNonQuery();

                if (result < 0)
                {
                    Console.WriteLine("Error inserting data into Database!");
                }
            }

            //Create an Service_ticket entry
            newWorkFlow += "(" + ticketID.ToString() + ", " + "'Open'" + ", " + "'" + DateTime.Now.ToString() + "'" + ", " + custID.ToString() + ", " + serviceID.ToString() + ", " + empID.ToString() + ")";
            sqlCommand = new SqlCommand(newWorkFlow, sqlConnect);
            result = sqlCommand.ExecuteNonQuery();

            if (result < 0)
            {
                Console.WriteLine("Error inserting data into Database!");
            }

            //Create a tickethistory event
            newHistory += "(" + ticketHistoryID.ToString() + ", " + "'" + DateTime.Now.ToString() + "'" + ", " + ticketID + ", " + empID + ")";
            sqlCommand = new SqlCommand(newHistory, sqlConnect);
            result = sqlCommand.ExecuteNonQuery();

            if (result < 0)
            {
                Console.WriteLine("Error inserting data into Database!");
            }

            sqlConnect.Close();

            Response.Redirect("Work Flow.aspx");

        }

        //Function when a new service ticket is selected from the dropdownlist
        protected void ddlSelectedIndexChanged(object sender, EventArgs e)
        {
            String currentTicket = ddlServiceTickets.SelectedValue;
            String ticketNumber = currentTicket.Substring(0, 1);

            String sqlQuery = "SELECT ServiceTicketID, TicketStatus, TicketOpenDate, concat(Customer.lastname, ', ', Customer.firstname) as Customer, " +
                              "ServiceID, Service_Ticket.empID, concat(Employee.lastname, ', ', Employee.firstname) as Employee " +
                              "FROM Service_Ticket FULL OUTER JOIN Customer ON Service_Ticket.CustomerID = Customer.CustomerID " +
                              "FULL OUTER JOIN Employee ON Service_Ticket.empID = Employee.empID " +
                              "WHERE concat(ServiceTicketID, ', ', Customer.lastname, ', ', Customer.firstname) = '" + currentTicket + "';";
            SqlConnection sqlConnect = new SqlConnection("Server=Localhost;Database=Lab2;Trusted_Connection=Yes;");

            SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlQuery, sqlConnect);

            //Display service ticket details
            DataTable dtForGridView = new DataTable();
            sqlAdapter.Fill(dtForGridView);

            
            String sqlHistoryQuery = "SELECT TicketChangeDate, concat(Employee.lastname, ', ', Employee.firstname) as 'Attending Employee' from TicketHistory " +
                                     "INNER JOIN Employee on TicketHistory.empID = Employee.empID WHERE ServiceTicketID = " + "'" + ticketNumber + "'";

            //Display ticket history of selected service ticket
            DataTable dtforTicketHistory = new DataTable();
            sqlAdapter = new SqlDataAdapter(sqlHistoryQuery, sqlConnect);
            sqlAdapter.Fill(dtforTicketHistory);

            grdSelectedServiceTicket.DataSource = dtForGridView;
            grdTicketHistory.DataSource = dtforTicketHistory;
            grdSelectedServiceTicket.DataBind();
            grdTicketHistory.DataBind();
        }

        //Function to edit service ticket
        protected void btnEditTicket(object sender, EventArgs e)
        {

            pnEdit.Visible = true;

            String selectedTicket = ddlServiceTickets.SelectedValue.Substring(0, 1);
            String serviceTicketID;
            String ticketStatus;
            String customer;
            String service;
            String employee;
            String destAddress;
            String originAddress;

            String sqlQuery = "SELECT ServiceTicketID, TicketStatus, TicketOpenDate, Service_Ticket.CustomerID, " +
                              "concat(Service_Ticket.CustomerID, ', ', Customer.lastname, ', ', Customer.firstname) as Customer, Service_Ticket.ServiceID, Service_Ticket.empID, " +
                              "concat(Service_Ticket.empID, ', ', Employee.lastname, ', ', Employee.firstname) as Employee, " +
                              "\"Move\".originAddress, \"Move\".destAddress" +
                              " FROM Service_Ticket " +
                              "FULL OUTER JOIN Customer on Service_Ticket.CustomerID = Customer.CustomerID " +
                              "FULL OUTER JOIN Employee on Service_Ticket.empID = Employee.empID " +
                              "FULL OUTER JOIN \"Move\" on Service_Ticket.ServiceID = \"Move\".ServiceID" +
                              " WHERE ServiceTicketID = " + selectedTicket.ToString();

            String constring = ConfigurationManager.ConnectionStrings["Lab2"].ConnectionString;

            SqlConnection sqlConnect = new SqlConnection(constring);
            SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnect);
            sqlConnect.Open();
            SqlDataReader reader = sqlCommand.ExecuteReader();
            reader.Read();
            String serviceID = reader["ServiceID"].ToString();
            serviceTicketID = reader["ServiceTicketID"].ToString();
            ticketStatus = reader["TicketStatus"].ToString();
            customer = reader["Customer"].ToString();
            service = reader["ServiceID"].ToString();
            employee = reader["Employee"].ToString();
            destAddress = reader["destAddress"].ToString();
            originAddress = reader["originAddress"].ToString();
            ServiceID.Text = serviceID;
            TicketID.Text = serviceTicketID;
            reader.Close();

            // Sets textboxes to display current data about selected service ticket
            txtTicketStatus.Text = ticketStatus;
            txtDestination.Text = destAddress;
            txtOrigin.Text = originAddress;
            ddlCustomer.ClearSelection();

            ddlCustomer.Items.FindByValue(customer).Selected = true;

            ddlEmployee.ClearSelection();

            ddlEmployee.Items.FindByValue(employee).Selected = true;


            sqlConnect.Close();
        }

        //Function to save changes made about selected service ticket
        protected void btnSaveChanges_Click(object sender, EventArgs e)
        {
            String newHistory = "INSERT INTO TicketHistory (TicketHistoryID, TicketChangeDate, ServiceTicketID, empID) VALUES ";

            String serviceTicketID = TicketID.Text;
            String ticketStatus = txtTicketStatus.Text;
            String customer = ddlCustomer.SelectedValue.Substring(0, 1);
            String destAddress = txtDestination.Text;
            String originAddress = txtOrigin.Text; ;
            String employee = ddlEmployee.SelectedValue.Substring(0, 1);
            String sqlUpdateString;
            String sqlAddressUpdateString;
            String serviceID = ServiceID.Text;

            String conString = ConfigurationManager.ConnectionStrings["Lab2"].ConnectionString;

            //Sql update strings
            sqlUpdateString = "UPDATE Service_Ticket SET empID = " + employee + ", CustomerID = " + customer + ", TicketStatus = " + "'" + ticketStatus + "'" + " WHERE ServiceTicketID = " + serviceTicketID;
            sqlAddressUpdateString = "UPDATE \"Move\" SET originAddress = " + "'" + originAddress + "'" + ", destAddress = " + "'" + destAddress + "'" + " WHERE ServiceID = " + serviceID;
            

            SqlConnection sqlConnect = new SqlConnection(conString);
            sqlConnect.Open();
            SqlCommand sqlCommand = new SqlCommand(sqlUpdateString, sqlConnect);
            sqlCommand.ExecuteNonQuery();
            sqlCommand = new SqlCommand(sqlAddressUpdateString, sqlConnect);
            sqlCommand.ExecuteNonQuery();

            //Get the last service ticket ID and either add one to it or set the new ticket = to 1
            String ticketHistoryQuery = "SELECT MAX(ServiceTicketID) as TicketHistory from TicketHistory";
            sqlCommand = new SqlCommand(ticketHistoryQuery, sqlConnect);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            reader.Read();
            int ticketHistoryID;
            if (reader["TicketHistory"].ToString() == "" || reader["TicketHistory"].ToString() == null)
            {
                ticketHistoryID = 1;
            }
            else
            {
                ticketHistoryID = (int)reader["TicketHistory"] + 1;
            }
            reader.Close();

            //Create a new ticket history after service ticket is edited
            newHistory += "(" + ticketHistoryID.ToString() + ", " + "'" + DateTime.Now.ToString() + "'" + ", " + serviceTicketID + ", " + employee + ")";
            sqlCommand = new SqlCommand(newHistory, sqlConnect);
            int result = sqlCommand.ExecuteNonQuery();

            if (result < 0)
            {
                Console.WriteLine("Error inserting data into Database!");
            }

            sqlConnect.Close();
            pnEdit.Visible = false;

        }

        //WIP button cancels edit and hides edit textboxes and buttons
        protected void btnCancelEdit(object sender, EventArgs e)
        {
            txtTicketStatus.Text = "";
            txtOrigin.Text = "";
            txtDestination.Text = "";
            ddlCustomer.ClearSelection();
            ddlEmployee.ClearSelection();
            Response.Redirect("Work Flow.aspx");
        }
    }
}