using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Lab2
{
    public partial class WebForm6 : System.Web.UI.Page
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
        protected void ddlCurrentCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            //// Create query
            //String sqlQuery = "SELECT CustomerID, FirstName, LastName FROM Customer";

            //// Set up connection to DB
            //SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab1"].ConnectionString);

            //// Sql Object
            //SqlCommand sqlCommand = new SqlCommand();
            //sqlCommand.Connection = sqlConnect;
            //sqlCommand.CommandType = CommandType.Text;
            //sqlCommand.CommandText = sqlQuery;

            //// Open connection
            //sqlConnect.Open();
            //SqlDataReader queryResults = sqlCommand.ExecuteReader();

        }
        protected void btnDisplayInventory(object sender, EventArgs e)
        {
            String currentCustomer = ddlCurrentCustomers.SelectedValue;
            String sqlQuery = "SELECT Item.itemID as \"Item ID\", itemName as \"Name\", itemCost as \"Cost\", " +
                              "concat(Customer.FirstName, ', ', Customer.LastName) as \"Owner\", \"date\" as \"Date\" FROM Item " +
                              "FULL OUTER JOIN Inventory ON Item.itemID = Inventory.itemID " +
                              "FULL OUTER JOIN Customer ON Inventory.customerID = Customer.CustomerID " +
                              "WHERE concat(Customer.LastName, ', ', Customer.FirstName) = '" + currentCustomer + "';";

            SqlConnection sqlConnect = new SqlConnection(ConfigurationManager.ConnectionStrings["Lab2"].ConnectionString);
            SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlQuery, sqlConnect);

            DataTable dtForGridView = new DataTable();
            sqlAdapter.Fill(dtForGridView);

            grdInventory.DataSource = dtForGridView;
            grdInventory.DataBind();
        }

    }
}
