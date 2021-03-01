using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab2
{
    public partial class Edit_Work_Flow : System.Web.UI.Page
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
        protected void ddlSelectedIndexChanged(object sender, EventArgs e)
        {
            if (!ddlServiceTickets.SelectedValue.Equals("<--Select-->"))
            {
                lblEmptyTicketError.Text = "";
                grdSelectedServiceTicket.Visible = true;
                grdTicketHistory.Visible = true;

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
            else
            {
                grdSelectedServiceTicket.Visible = false;
                grdTicketHistory.Visible = false;
            }
        }


        protected void btnEditTicket(object sender, EventArgs e)
        {
            if (ddlServiceTickets.SelectedValue.Equals("<--Select-->"))
            {
                lblEmptyTicketError.Text = "Please select a service ticket.";
            }
            else
            {
                lblEmptyTicketError.Text = "";

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
        }

        protected void btnSaveChanges_Click(object sender, EventArgs e)
        {
            if (ddlCustomer.SelectedValue.Equals("<--Select-->") || ddlEmployee.SelectedValue.Equals("<--Select-->"))
            {
                if (ddlCustomer.SelectedValue.Equals("<--Select-->"))
                {
                    lblCustEmptyError.Text = "Please select a customer.";
                }
                if (ddlEmployee.SelectedValue.Equals("<--Select-->"))
                {
                    lblEmpEmptyError.Text = "Please select an employee.";
                }
            }
            else
            {
                lblCustEmptyError.Text = "";
                lblEmpEmptyError.Text = "";
                String newHistory = "INSERT INTO TicketHistory (TicketHistoryID, TicketChangeDate, ServiceTicketID, empID) VALUES (@TicketHistoryID, @TicketChangeDate, @ServiceTicketID, @empID)";

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

                sqlUpdateString = "UPDATE Service_Ticket SET empID = @empID, CustomerID = @CustomerID, TicketStatus = @TicketStatus WHERE ServiceTicketID = @ServiceTicketID";
                sqlAddressUpdateString = "UPDATE \"Move\" SET originAddress = @OriginAddress, destAddress = @DestAddress WHERE ServiceID = @ServiceID";

                //sqlUpdateString = "UPDATE Service_Ticket SET empID = " + employee + ", CustomerID = " + customer + ", TicketStatus = " + "'" + ticketStatus + "'" + " WHERE ServiceTicketID = " + serviceTicketID;
                //sqlAddressUpdateString = "UPDATE \"Move\" SET originAddress = " + "'" + originAddress + "'" + ", destAddress = " + "'" + destAddress + "'" + " WHERE ServiceID = " + serviceID;


                SqlConnection sqlConnect = new SqlConnection(conString);
                sqlConnect.Open();
                SqlCommand sqlCommand = new SqlCommand(sqlUpdateString, sqlConnect);
                sqlCommand.Parameters.AddWithValue("@empID", employee);
                sqlCommand.Parameters.AddWithValue("@CustomerID", customer);
                sqlCommand.Parameters.AddWithValue("@TicketStatus", ticketStatus);
                sqlCommand.Parameters.AddWithValue("@ServiceTicketID", serviceTicketID);

                sqlCommand.ExecuteNonQuery();

                sqlCommand = new SqlCommand(sqlAddressUpdateString, sqlConnect);
                sqlCommand.Parameters.AddWithValue("@OriginAddress", originAddress);
                sqlCommand.Parameters.AddWithValue("@DestAddress", destAddress);
                sqlCommand.Parameters.AddWithValue("@ServiceID", serviceID);

                sqlCommand.ExecuteNonQuery();

                //Get the last service ticket ID and either add one to it or set the new ticket = to 1
                String ticketHistoryQuery = "SELECT MAX(TicketHistoryID) as TicketHistory from TicketHistory";
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
                //newHistory += "(" + ticketHistoryID.ToString() + ", " + "'" + DateTime.Now.ToString() + "'" + ", " + serviceTicketID + ", " + employee + ")";
                //"INSERT INTO TicketHistory (TicketHistoryID, TicketChangeDate, ServiceTicketID, empID) VALUES (@TicketHistoryID, @TicketChangeDate, @ServiceTicketID, @empID)";
                sqlCommand = new SqlCommand(newHistory, sqlConnect);
                sqlCommand.Parameters.AddWithValue("@TicketHistoryID", ticketHistoryID);
                sqlCommand.Parameters.AddWithValue("@TicketChangeDate", DateTime.Now.ToString());
                sqlCommand.Parameters.AddWithValue("@ServiceTicketID", serviceTicketID);
                sqlCommand.Parameters.AddWithValue("@empID", employee);

                int result = sqlCommand.ExecuteNonQuery();

                if (result < 0)
                {
                    Console.WriteLine("Error inserting data into Database!");
                }

                sqlConnect.Close();

            }
        }
        
        protected void btn_Assign(object sender, EventArgs e)
        {
            if (ddlAuction.SelectedValue.Equals("<--Select-->") || ddlTicket.SelectedValue.Equals("<--Select-->"))
            {
                lblStatus.Text = "Please select an AuctionID / Service Ticket";
            }
            else
            {
                lblStatus.Text = "";
                String serviceTicket = ddlTicket.SelectedValue.Substring(0, 0);
                String auctionID = ddlAuction.SelectedValue;

                String sqlQuery = "UPDATE Auction SET ServiceID = @ServiceID WHERE AuctionID = @AuctionID";
                String connectionString = ConfigurationManager.ConnectionStrings["Lab2"].ConnectionString;
                SqlConnection sqlConnect = new SqlConnection(connectionString);
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnect);
                sqlCommand.Parameters.AddWithValue("@ServiceID", serviceTicket);
                sqlCommand.Parameters.AddWithValue("@AuctionID", auctionID);
                sqlConnect.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnect.Close();
            }
        }

        //WIP button cancels edit and hides edit textboxes and buttons
        protected void btnCancelEdit(object sender, EventArgs e)
        {
            lblEmptyTicketError.Text = "";
            lblCustEmptyError.Text = "";
            lblEmpEmptyError.Text = "";
            txtTicketStatus.Text = "";
            txtOrigin.Text = "";
            txtDestination.Text = "";
            ddlCustomer.SelectedIndex = 0;
            ddlEmployee.SelectedIndex = 0;
            Response.Redirect("Edit Work Flow.aspx");
        }
    }
}