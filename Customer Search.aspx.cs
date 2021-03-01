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
    public partial class Customer_Search : System.Web.UI.Page
    {
        //SqlConnection connection = new SqlConnection("Data Source = Localhost; Initial Catalog = AUTH; Trusted_Connection=Yes");
        //SqlCommand command;
        //SqlDataReader mdr;
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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
           String search = txtCustomerName.Text;
           


            String sqlQuery = "SELECT ServiceTicketID, TicketStatus, TicketOpenDate, concat(Customer.lastname, ', ', Customer.firstname) as Customer, " +
                              "ServiceID, Service_Ticket.empID, concat(Employee.lastname, ', ', Employee.firstname) as Employee " +
                              "FROM Service_Ticket FULL OUTER JOIN Customer ON Service_Ticket.CustomerID = Customer.CustomerID " +
                              "FULL OUTER JOIN Employee ON Service_Ticket.empID = Employee.empID " +
                              "WHERE concat(Customer.lastname, ', ', Customer.firstname) LIKE '%" + search + "%';";

            SqlConnection sqlConnect = new SqlConnection(ConfigurationManager.ConnectionStrings["Lab2"].ConnectionString);

            SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlQuery, sqlConnect);

            //Display service ticket details
            DataTable dtForGridView = new DataTable();
            sqlAdapter.Fill(dtForGridView);

            ////Display ticket history of selected service ticket
            //DataTable dtforTicketHistory = new DataTable();
            //sqlAdapter = new SqlDataAdapter(sqlHistoryQuery, sqlConnect);
            //sqlAdapter.Fill(dtforTicketHistory);

            grdServiceTickets.DataSource = dtForGridView;
            grdServiceTickets.DataBind();
            //grdSelectedServiceTicket.DataSource = dtForGridView;
            //grdTicketHistory.DataSource = dtforTicketHistory;
            //grdSelectedServiceTicket.DataBind();
            //grdTicketHistory.DataBind();
        }
    }
}