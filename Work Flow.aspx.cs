using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;


//Created by Wyatt T. Putnam

namespace Lab2
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] != null)
            {
                if (grdNotifictions.Rows.Count == 0)
                {
                    pnlNotifications.Visible = false;
                }
                else
                {
                    pnlNotifications.Visible = true;
                }
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }
        }

        //Function to add a Service_Ticket and a Ticket History to the DB
        protected void btnAddWorkFlow(object sender, EventArgs e)
        {
            HttpUtility.HtmlEncode(txtboxDestinationAddress.Text);
            HttpUtility.HtmlEncode(txtboxOriginAddress.Text);
            HttpUtility.HtmlEncode(txtNoteBody.Text);
            HttpUtility.HtmlEncode(txtNoteTitle.Text);



            if (ddlWorkflowCustomer.SelectedValue.Equals("<--Select-->") || ddlWorkflowEmp.SelectedValue.Equals("<--Select-->"))
            {
                if (ddlWorkflowCustomer.SelectedValue.Equals("<--Select-->"))
                {
                    lblEmptyCust.Text = "Please select a customer.";
                }
                if (ddlWorkflowEmp.SelectedValue.Equals("<--Select-->"))
                {
                    lblEmptyEmp.Text = "Please select an employee.";
                }
            }
            else
            {
                HttpUtility.HtmlEncode(txtboxDestinationAddress.Text);
                HttpUtility.HtmlEncode(txtboxOriginAddress.Text);
                HttpUtility.HtmlEncode(txtNoteBody.Text);
                HttpUtility.HtmlEncode(txtNoteTitle.Text);

                lblEmptyEmp.Text = "";
                lblEmptyCust.Text = "";
                String connectionString = ConfigurationManager.ConnectionStrings["Lab2"].ConnectionString;

                //Establish SQL connection and reader object to retrieve information from the DB.
                SqlConnection sqlConnect = new SqlConnection(connectionString);
                sqlConnect.Open();
                SqlDataReader reader;
                
                //Get the CustomerID using the selected Customer
                String sqlQuery = "SELECT CustomerID, concat(lastname, ', ', firstname) as CustomerID from Customer WHERE concat(lastname, ', ', firstname) = " + "'" + ddlWorkflowCustomer.SelectedValue + "'";
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnect);
                reader = sqlCommand.ExecuteReader();
                reader.Read();
                int custID = (int)reader["CustomerID"];
                reader.Close();

                //Create a new inventory entry
                int inventoryID = getInventoryID();
                addNewInventory(inventoryID, custID, DateTime.Now.ToString());
                
                //Create a new Service event
                int serviceID = getServiceID();
                addNewService(custID, serviceID, inventoryID, DateTime.Now.ToString());

                int empID = getEmployeeID();
                //Create a Move event if option is checked
                if (chbxWorkflowMove.Checked)
                {

                    String originAddress = txtboxOriginAddress.Text;
                    String destAddress = txtboxDestinationAddress.Text;
                    addNewMove(serviceID, empID, originAddress, destAddress);   

                }

                //Create an Auction event if option is checked
                if (chbxWorkflowAuction.Checked)
                {
                    addNewAuction(serviceID, empID, DateTime.Now.ToString());
                   
                }

                int ticketID = getServiceTicketID();
                int ticketHistoryID = getTicketHistoryID();
                //Create an Service_ticket entry
                addNewWorkflow(ticketID, "Open", DateTime.Now.ToString(), custID, serviceID, empID);
               

                //Create a tickethistory event
                addNewHistory(ticketHistoryID, DateTime.Now.ToString(), ticketID, empID);
                
                sqlConnect.Close();

                Response.Redirect("Work Flow.aspx");

            }
        }

        //Function when a new service ticket is selected from the dropdownlist
        protected void ddlSelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlServiceTickets.SelectedValue.Equals("<--Select-->"))
            {
                grdSelectedServiceTicket.Visible = false;
                grdTicketHistory.Visible = false;
            }
            else
            {
                grdSelectedServiceTicket.Visible = true;
                grdTicketHistory.Visible = true;
                String currentTicket = ddlServiceTickets.SelectedValue;
                int ticketNumber = getSpecificServiceTicket(ddlServiceTickets.SelectedValue);

                String sqlQuery = "SELECT ServiceTicketID, TicketStatus, TicketOpenDate, concat(Customer.lastname, ', ', Customer.firstname) as Customer, " +
                                  "ServiceID, Service_Ticket.empID, concat(Employee.lastname, ', ', Employee.firstname) as Employee " +
                                  "FROM Service_Ticket FULL OUTER JOIN Customer ON Service_Ticket.CustomerID = Customer.CustomerID " +
                                  "FULL OUTER JOIN Employee ON Service_Ticket.empID = Employee.empID " +
                                  "WHERE concat(TicketOpenDate, ', ', Customer.lastname, ', ', Customer.firstname) = '" + currentTicket + "';";
                SqlConnection sqlConnect = new SqlConnection(ConfigurationManager.ConnectionStrings["Lab2"].ConnectionString);

                SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlQuery, sqlConnect);

                //Display service ticket details
                DataTable dtForGridView = new DataTable();
                sqlAdapter.Fill(dtForGridView);


                String sqlHistoryQuery = "SELECT TicketChangeDate, concat(Employee.lastname, ', ', Employee.firstname) as 'Attending Employee' from TicketHistory " +
                                         "INNER JOIN Employee on TicketHistory.empID = Employee.empID WHERE ServiceTicketID = " + "'" + ticketNumber.ToString() + "'";

                //Display ticket history of selected service ticket
                DataTable dtforTicketHistory = new DataTable();
                sqlAdapter = new SqlDataAdapter(sqlHistoryQuery, sqlConnect);
                sqlAdapter.Fill(dtforTicketHistory);

                grdSelectedServiceTicket.DataSource = dtForGridView;
                grdTicketHistory.DataSource = dtforTicketHistory;
                grdSelectedServiceTicket.DataBind();
                grdTicketHistory.DataBind();
            }
        }
        protected void btn_ClearNotifications(object sender, EventArgs e)
        {
            String sqlQuery = "DELETE FROM Notifications";
            String connectionString = ConfigurationManager.ConnectionStrings["Lab2"].ConnectionString;
            SqlConnection sqlConnect = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnect);

            sqlConnect.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnect.Close();
            Response.Redirect("~/Home.aspx");
        }

        //Function to edit service ticket
        //protected void btnEditTicket(object sender, EventArgs e)
        //{

        //    pnEdit.Visible = true;

        //    String selectedTicket = ddlServiceTickets.SelectedValue.Substring(0, 1);
        //    String serviceTicketID;
        //    String ticketStatus;
        //    String customer;
        //    String service;
        //    String employee;
        //    String destAddress;
        //    String originAddress;

        //    String sqlQuery = "SELECT ServiceTicketID, TicketStatus, TicketOpenDate, Service_Ticket.CustomerID, " +
        //                      "concat(Service_Ticket.CustomerID, ', ', Customer.lastname, ', ', Customer.firstname) as Customer, Service_Ticket.ServiceID, Service_Ticket.empID, " +
        //                      "concat(Service_Ticket.empID, ', ', Employee.lastname, ', ', Employee.firstname) as Employee, " +
        //                      "\"Move\".originAddress, \"Move\".destAddress" +
        //                      " FROM Service_Ticket " +
        //                      "FULL OUTER JOIN Customer on Service_Ticket.CustomerID = Customer.CustomerID " +
        //                      "FULL OUTER JOIN Employee on Service_Ticket.empID = Employee.empID " +
        //                      "FULL OUTER JOIN \"Move\" on Service_Ticket.ServiceID = \"Move\".ServiceID" +
        //                      " WHERE ServiceTicketID = " + selectedTicket.ToString();

        //    String constring = ConfigurationManager.ConnectionStrings["Lab2"].ConnectionString;

        //    SqlConnection sqlConnect = new SqlConnection(constring);
        //    SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnect);
        //    sqlConnect.Open();
        //    SqlDataReader reader = sqlCommand.ExecuteReader();
        //    reader.Read();
        //    String serviceID = reader["ServiceID"].ToString();
        //    serviceTicketID = reader["ServiceTicketID"].ToString();
        //    ticketStatus = reader["TicketStatus"].ToString();
        //    customer = reader["Customer"].ToString();
        //    service = reader["ServiceID"].ToString();
        //    employee = reader["Employee"].ToString();
        //    destAddress = reader["destAddress"].ToString();
        //    originAddress = reader["originAddress"].ToString();
        //    ServiceID.Text = serviceID;
        //    TicketID.Text = serviceTicketID;
        //    reader.Close();

        //    // Sets textboxes to display current data about selected service ticket
        //    txtTicketStatus.Text = ticketStatus;
        //    txtDestination.Text = destAddress;
        //    txtOrigin.Text = originAddress;
        //    ddlCustomer.ClearSelection();

        //    ddlCustomer.Items.FindByValue(customer).Selected = true;

        //    ddlEmployee.ClearSelection();

        //    ddlEmployee.Items.FindByValue(employee).Selected = true;


        //    sqlConnect.Close();
        //}

        //Function to save changes made about selected service ticket
        //protected void btnSaveChanges_Click(object sender, EventArgs e)
        //{
        //    String newHistory = "INSERT INTO TicketHistory (TicketHistoryID, TicketChangeDate, ServiceTicketID, empID) VALUES ";

        //    String serviceTicketID = TicketID.Text;
        //    String ticketStatus = txtTicketStatus.Text;
        //    String customer = ddlCustomer.SelectedValue.Substring(0, 1);
        //    String destAddress = txtDestination.Text;
        //    String originAddress = txtOrigin.Text; ;
        //    String employee = ddlEmployee.SelectedValue.Substring(0, 1);
        //    String sqlUpdateString;
        //    String sqlAddressUpdateString;
        //    String serviceID = ServiceID.Text;

        //    String conString = ConfigurationManager.ConnectionStrings["Lab2"].ConnectionString;

        //    //Sql update strings
        //    sqlUpdateString = "UPDATE Service_Ticket SET empID = " + employee + ", CustomerID = " + customer + ", TicketStatus = " + "'" + ticketStatus + "'" + " WHERE ServiceTicketID = " + serviceTicketID;
        //    sqlAddressUpdateString = "UPDATE \"Move\" SET originAddress = " + "'" + originAddress + "'" + ", destAddress = " + "'" + destAddress + "'" + " WHERE ServiceID = " + serviceID;


        //    SqlConnection sqlConnect = new SqlConnection(conString);
        //    sqlConnect.Open();
        //    SqlCommand sqlCommand = new SqlCommand(sqlUpdateString, sqlConnect);
        //    sqlCommand.ExecuteNonQuery();
        //    sqlCommand = new SqlCommand(sqlAddressUpdateString, sqlConnect);
        //    sqlCommand.ExecuteNonQuery();

        //    //Get the last service ticket ID and either add one to it or set the new ticket = to 1
        //    String ticketHistoryQuery = "SELECT MAX(ServiceTicketID) as TicketHistory from TicketHistory";
        //    sqlCommand = new SqlCommand(ticketHistoryQuery, sqlConnect);
        //    SqlDataReader reader = sqlCommand.ExecuteReader();
        //    reader.Read();
        //    int ticketHistoryID;
        //    if (reader["TicketHistory"].ToString() == "" || reader["TicketHistory"].ToString() == null)
        //    {
        //        ticketHistoryID = 1;
        //    }
        //    else
        //    {
        //        ticketHistoryID = (int)reader["TicketHistory"] + 1;
        //    }
        //    reader.Close();

        //    //Create a new ticket history after service ticket is edited
        //    newHistory += "(" + ticketHistoryID.ToString() + ", " + "'" + DateTime.Now.ToString() + "'" + ", " + serviceTicketID + ", " + employee + ")";
        //    sqlCommand = new SqlCommand(newHistory, sqlConnect);
        //    int result = sqlCommand.ExecuteNonQuery();

        //    if (result < 0)
        //    {
        //        Console.WriteLine("Error inserting data into Database!");
        //    }

        //    sqlConnect.Close();
        //pnEdit.Visible = false;

        //}

        ////WIP button cancels edit and hides edit textboxes and buttons
        //protected void btnCancelEdit(object sender, EventArgs e)
        //{
        //    txtTicketStatus.Text = "";
        //    txtOrigin.Text = "";
        //    txtDestination.Text = "";
        //    ddlCustomer.ClearSelection();
        //    ddlEmployee.ClearSelection();
        //    Response.Redirect("Work Flow.aspx");
        //}

        //String newAuction = "INSERT INTO Auction (ServiceID, empID) VALUES ";
        //String newMove = "INSERT INTO \"Move\" (ServiceID, empID, originAddress, destAddress) VALUES ";
        //String newService = "INSERT INTO \"Service\" (CustomerID, ServiceID, InventoryID, \"Date\") VALUES ";
        //String newWorkFlow = "INSERT INTO Service_Ticket (ServiceTicketID, TicketStatus, TicketOpenDate, CustomerID, ServiceID, empID) VALUES ";
        //String newInventory = "INSERT INTO Inventory (inventoryID, CustomerID, \"date\") VALUES ";
        //String newHistory = "INSERT INTO TicketHistory (TicketHistoryID, TicketChangeDate, ServiceTicketID, empID) VALUES ";
        //String newDetailsNote = "INSERT INTO DetailsNote (DetailsNoteID, ServiceTicketID, NoteTitle, NoteBody) VALUES ";


        protected void addNewAuction(int serviceID, int empID, String date)
        {
            String newAuction = "INSERT INTO Auction (AuctionID, ServiceID, empID, DateOfSale) VALUES (@AuctionID, @ServiceID, @empID, @Date)";

            String connectionString = ConfigurationManager.ConnectionStrings["Lab2"].ConnectionString;

            SqlConnection sqlConnect = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(newAuction, sqlConnect);
            int auctionID = getAuctionID();
            sqlCommand.Parameters.AddWithValue("@AuctionID", auctionID);
            sqlCommand.Parameters.AddWithValue("@ServiceID", serviceID);
            sqlCommand.Parameters.AddWithValue("@empID", empID);
            sqlCommand.Parameters.AddWithValue("@Date", date);
            sqlConnect.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnect.Close();
        }


        protected void addNewMove(int serviceID, int empID, String originAddress, String destAddress)
        {
            String newMove = "INSERT INTO \"Move\" (ServiceID, empID, originAddress, destAddress) VALUES (@ServiceID, @empID, @originAddress, @destAddress)";
            String connectionString = ConfigurationManager.ConnectionStrings["Lab2"].ConnectionString;

            SqlConnection sqlConnect = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(newMove, sqlConnect);

            sqlCommand.Parameters.AddWithValue("@ServiceID", serviceID);
            sqlCommand.Parameters.AddWithValue("@empID", empID);
            sqlCommand.Parameters.AddWithValue("@originAddress", originAddress);
            sqlCommand.Parameters.AddWithValue("@destAddress", destAddress);

            sqlConnect.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnect.Close();
        }
        //String newService = "INSERT INTO \"Service\" (CustomerID, ServiceID, InventoryID, \"Date\") VALUES ";
        protected void addNewService(int customerID, int serviceID, int inventoryID, String date)
        {
            String newService = "INSERT INTO \"Service\" (CustomerID, ServiceID, InventoryID, \"Date\") VALUES (@CustomerID, @ServiceID, @InventoryID, @Date)";
            String connectionString = ConfigurationManager.ConnectionStrings["Lab2"].ConnectionString;

            SqlConnection sqlConnect = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(newService, sqlConnect);

            sqlCommand.Parameters.AddWithValue("@CustomerID", customerID);
            sqlCommand.Parameters.AddWithValue("@ServiceID", serviceID);
            sqlCommand.Parameters.AddWithValue("@InventoryID", inventoryID);
            sqlCommand.Parameters.AddWithValue("@Date", date);

            sqlConnect.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnect.Close();
        }

        //String newWorkFlow = "INSERT INTO Service_Ticket (ServiceTicketID, TicketStatus, TicketOpenDate, CustomerID, ServiceID, empID) VALUES ";
        protected void addNewWorkflow(int serviceTicketID, String ticketStatus, String ticketOpenDate, int customerID, int serviceID, int empID)
        {
            String newWorkFlow = "INSERT INTO Service_Ticket (ServiceTicketID, TicketStatus, TicketOpenDate, CustomerID, ServiceID, empID) VALUES " +
                                 "(@ServiceTicketID, @TicketStatus, @TicketOpenDate, @CustomerID, @ServiceID, @empID)";
            String connectionString = ConfigurationManager.ConnectionStrings["Lab2"].ConnectionString;

            SqlConnection sqlConnect = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(newWorkFlow, sqlConnect);

            sqlCommand.Parameters.AddWithValue("@ServiceTicketID", serviceTicketID);
            sqlCommand.Parameters.AddWithValue("@TicketStatus", ticketStatus);
            sqlCommand.Parameters.AddWithValue("@TicketOpenDate", ticketOpenDate);
            sqlCommand.Parameters.AddWithValue("@CustomerID", customerID);
            sqlCommand.Parameters.AddWithValue("@ServiceID", serviceID);
            sqlCommand.Parameters.AddWithValue("@empID", empID);

            sqlConnect.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnect.Close();
        }


        //String newInventory = "INSERT INTO Inventory (inventoryID, CustomerID, \"date\") VALUES ";
        protected void addNewInventory(int inventoryID, int customerID, String date)
        {
            String newInventory = "INSERT INTO Inventory (inventoryID, CustomerID, \"date\") VALUES (@InventoryID, @CustomerID, @Date)";
            String connectionString = ConfigurationManager.ConnectionStrings["Lab2"].ConnectionString;

            SqlConnection sqlConnect = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(newInventory, sqlConnect);

            sqlCommand.Parameters.AddWithValue("@InventoryID", inventoryID);
            sqlCommand.Parameters.AddWithValue("@CustomerID", customerID);
            sqlCommand.Parameters.AddWithValue("@Date", date);


            sqlConnect.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnect.Close();
        }

        //String newHistory = "INSERT INTO TicketHistory (TicketHistoryID, TicketChangeDate, ServiceTicketID, empID) VALUES ";
        protected void addNewHistory(int ticketHistoryID, String ticketChangeDate, int serviceTicketID, int empID)
        {
            String newHistory = "INSERT INTO TicketHistory (TicketHistoryID, TicketChangeDate, ServiceTicketID, empID) VALUES (@TicketHistoryID, @TicketChangeDate, @ServiceTicketID, @empID)";
            String connectionString = ConfigurationManager.ConnectionStrings["Lab2"].ConnectionString;

            SqlConnection sqlConnect = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(newHistory, sqlConnect);

            sqlCommand.Parameters.AddWithValue("@TicketHistoryID", ticketHistoryID);
            sqlCommand.Parameters.AddWithValue("@TicketChangeDate", ticketChangeDate);
            sqlCommand.Parameters.AddWithValue("@ServiceTicketID", serviceTicketID);
            sqlCommand.Parameters.AddWithValue("@empID", empID);

            sqlConnect.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnect.Close();
        }

        //String newDetailsNote = "INSERT INTO DetailsNote (DetailsNoteID, ServiceTicketID, NoteTitle, NoteBody) VALUES ";
        protected void addNewDetailsNote(int detailsNoteID, int serviceTicketID, String noteTitle, String noteBody)
        {
            String newDetailsNote = "INSERT INTO DetailsNote (DetailsNoteID, ServiceTicketID, NoteTitle, NoteBody) VALUES (@DetailsNoteID, @ServiceTicketID, @NoteTitle, @NoteBody)";
            String connectionString = ConfigurationManager.ConnectionStrings["Lab2"].ConnectionString;

            SqlConnection sqlConnect = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(newDetailsNote, sqlConnect);

            sqlCommand.Parameters.AddWithValue("@DetailsNoteID", detailsNoteID);
            sqlCommand.Parameters.AddWithValue("@ServiceTicketID", serviceTicketID);
            sqlCommand.Parameters.AddWithValue("@NoteTitle", noteTitle);
            sqlCommand.Parameters.AddWithValue("@NoteBody", noteBody);

            sqlConnect.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnect.Close();
        }
        protected int getServiceID()
        {
            String sqlQuery = "SELECT MAX(ServiceID) as ServiceID FROM Service";
            String connectionString = ConfigurationManager.ConnectionStrings["Lab2"].ConnectionString;

            SqlConnection sqlConnect = new SqlConnection(connectionString);
            sqlConnect.Open();
            SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnect);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            reader.Read();
            int serviceID = (int)reader["ServiceID"] + 1;
            reader.Close();
            sqlConnect.Close();

            return serviceID;
        }
        protected int getInventoryID()
        {
            String sqlQuery = "SELECT MAX(inventoryID) as InventoryID FROM Inventory";
            String connectionString = ConfigurationManager.ConnectionStrings["Lab2"].ConnectionString;

            SqlConnection sqlConnect = new SqlConnection(connectionString);
            sqlConnect.Open();
            SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnect);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            reader.Read();
            int inventoryID = (int)reader["InventoryID"] + 1;
            reader.Close();
            sqlConnect.Close();

            return inventoryID;
        }

        protected int getEmployeeID()
        {
            String employee = ddlWorkflowEmp.SelectedValue;

            String sqlQuery = "SELECT empID, concat(lastname, ', ', firstname) as Employee from Employee WHERE concat(lastname, ', ', firstname) = " + "'" + employee + "'";
            String connectionString = ConfigurationManager.ConnectionStrings["Lab2"].ConnectionString;

            SqlConnection sqlConnect = new SqlConnection(connectionString);
            sqlConnect.Open();
            SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnect);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            reader.Read();
            int empID = (int)reader["empID"];
            reader.Close();
            sqlConnect.Close();

            return empID;
        }

        protected int getDetailsNoteID()
        {
            String sqlQuery = "SELECT MAX(DetailsNoteID) as MaxDetailsNote FROM DetailsNote";
            String connectionString = ConfigurationManager.ConnectionStrings["Lab2"].ConnectionString;

            SqlConnection sqlConnect = new SqlConnection(connectionString);
            sqlConnect.Open();
            SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnect);
            SqlDataReader reader = sqlCommand.ExecuteReader();

            int detailsNoteID;
            reader.Read();
            if (reader["MaxDetailsNote"] == null || reader["MaxDetailsNote"].ToString() == "")
            {
                detailsNoteID = 1;
            }
            else
            {
                detailsNoteID = (int)reader["MaxDetailsNote"] + 1;
            }
            reader.Close();
            sqlConnect.Close();

            return detailsNoteID;
        }

        protected int getSpecificServiceTicket(String query)
        {
            String ticketQuery = "SELECT ServiceTicketID from Service_Ticket INNER JOIN Customer ON Customer.CustomerID = Service_Ticket.CustomerID WHERE concat(TicketOpenDate, ', ', Customer.LastName, ', ', Customer.FirstName) = @input";
            String connectionString = ConfigurationManager.ConnectionStrings["Lab2"].ConnectionString;
            SqlConnection sqlConnect = new SqlConnection(connectionString);
            sqlConnect.Open();
            SqlCommand sqlCommand = new SqlCommand(ticketQuery, sqlConnect);
            sqlCommand.Parameters.AddWithValue("@input", query);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            reader.Read();
            int ticketID;
            ticketID = (int)reader["ServiceTicketID"];

            return ticketID;
        }

        protected int getServiceTicketID()
        {
            String ticketQuery = "SELECT MAX(ServiceTicketID) as TicketID from Service_Ticket";
            String connectionString = ConfigurationManager.ConnectionStrings["Lab2"].ConnectionString;
            SqlConnection sqlConnect = new SqlConnection(connectionString);
            sqlConnect.Open();
            SqlCommand sqlCommand = new SqlCommand(ticketQuery, sqlConnect);
            SqlDataReader reader = sqlCommand.ExecuteReader();
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
            sqlConnect.Close();

            return ticketID;
        }
        protected int getTicketHistoryID()
        {
            String ticketHistoryQuery = "SELECT MAX(ServiceTicketID) as TicketHistory from TicketHistory";

            String connectionString = ConfigurationManager.ConnectionStrings["Lab2"].ConnectionString;
            SqlConnection sqlConnect = new SqlConnection(connectionString);
            sqlConnect.Open();
            SqlCommand sqlCommand = new SqlCommand(ticketHistoryQuery, sqlConnect);
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
            sqlConnect.Close();

            return ticketHistoryID;

        }

        protected int getAuctionID()
        {
            String auctionQuery = "SELECT MAX(AuctionID) as AuctionID from Auction";

            String connectionString = ConfigurationManager.ConnectionStrings["Lab2"].ConnectionString;
            SqlConnection sqlConnect = new SqlConnection(connectionString);
            sqlConnect.Open();
            SqlCommand sqlCommand = new SqlCommand(auctionQuery, sqlConnect);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            reader.Read();
            int auctionID;
            if (reader["AuctionID"].ToString() == "" || reader["AuctionID"].ToString() == null)
            {
                auctionID = 1;
            }
            else
            {
                auctionID = (int)reader["AuctionID"] + 1;
            }
            reader.Close();
            sqlConnect.Close();

            return auctionID;
        }

        protected void btn_Populate(object sender, EventArgs e)
        {
            ddlWorkflowCustomer.SelectedIndex = 1;
            ddlWorkflowEmp.SelectedIndex = 1;
            chbxWorkflowAuction.Checked = true;
            chbxWorkflowMove.Checked = true;
            txtboxOriginAddress.Text = "526 Gulburg Ln";
            txtboxDestinationAddress.Text = "527 Sahara Dr";
            txtNoteTitle.Text = "Test";
            txtNoteBody.Text = "Test data";
        }

        protected void btn_Clear(object sender, EventArgs e)
        {
            ddlWorkflowCustomer.ClearSelection();
            ddlWorkflowEmp.ClearSelection();
            chbxWorkflowAuction.Checked = false;
            chbxWorkflowMove.Checked = false;
            txtboxOriginAddress.Text = "";
            txtboxDestinationAddress.Text = "";
            txtNoteTitle.Text = "";
            txtNoteBody.Text = "";
        }
    }
}