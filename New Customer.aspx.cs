using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lab1Part3;

//Created by Wyatt T. Putnam, Cole Schweikert, and Shaima Sorchi

namespace Lab2
{
    public partial class WebForm3 : System.Web.UI.Page
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

        //Function to create customer from data in text boxes.
        protected void CreateCustomer(object sender, EventArgs e)
        {
            //CustomerID is recieved from separate function.
            int maxCustID = getCustID();

            String serviceType;

            if (chbxMove.Checked && chbxAuction.Checked)
            {
                serviceType = "Move, Auction";
            }
            else if (chbxMove.Checked)
            {
                serviceType = "Move";
            }
            else
            {
                serviceType = "Auction";
            }

            String address = txtStreet.Text + " " + txtCity.Text + ", " + txtState.Text + " " + txtZip.Text;

            //Adding a customer uses the Customer class
            Customer newCustomer = new Customer(txtFirstName.Text, txtLastName.Text, maxCustID, txtPhone.Text, address);

            String sqlQuery = "INSERT INTO Customer(CustomerID, FirstName, LastName, Phone, \"Address\", Email, ContactMethod, MethodType, ServiceType) VALUES " +
                                                  "(@CustomerID, @FirstName, @LastName, @Phone, @Address, @Email, @ContactMethod, @MethodType, @ServiceType)";


            String conString = ConfigurationManager.ConnectionStrings["Lab2"].ConnectionString;

            SqlConnection sqlConnect = new SqlConnection(conString);
            sqlConnect.Open();

            SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnect);

            sqlCommand.Parameters.AddWithValue("@CustomerID", newCustomer.CustomerID);
            sqlCommand.Parameters.AddWithValue("@FirstName", newCustomer.FirstName);
            sqlCommand.Parameters.AddWithValue("@LastName", newCustomer.LastName);
            sqlCommand.Parameters.AddWithValue("@Phone", newCustomer.Phone);
            sqlCommand.Parameters.AddWithValue("@Address", newCustomer.Address);
            sqlCommand.Parameters.AddWithValue("@Email", txtEmail.Text);
            sqlCommand.Parameters.AddWithValue("@ContactMethod", HowDidDropDown.SelectedValue);
            sqlCommand.Parameters.AddWithValue("@MethodType", txtHear.Text);
            sqlCommand.Parameters.AddWithValue("@ServiceType", serviceType);


            int result = sqlCommand.ExecuteNonQuery();

            if (result < 0)
            {
                Console.WriteLine("Customer added successfully");
            }

            sqlConnect.Close();

        }
        protected void ClearTxt(object sender, EventArgs e)
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtPhone.Text = "";
            txtStreet.Text = "";
            txtCity.Text = "";
            txtState.Text = "";
            txtZip.Text = "";
            HowDidDropDown.ClearSelection();
            PhoneTypeDropDown.ClearSelection();
            txtHear.Text = "";
            txtEmail.Text = "";
            chbxMove.Checked = false;
            chbxAuction.Checked = false;
        }

        protected void GenerateData(object sender, EventArgs e)
        {
            txtFirstName.Text = "Wyatt";
            txtLastName.Text = "Putnam";
            txtPhone.Text = "000-000-0000";
            txtStreet.Text = "123 Street";
            txtCity.Text = "Harrisonburg";
            txtState.Text = "VA";
            txtZip.Text = "22801";
            HowDidDropDown.SelectedIndex = 1;
            txtHear.Text = "Word of mouth.";
            PhoneTypeDropDown.SelectedIndex = 1;
            txtEmail.Text = "test@gmail.com";
            chbxAuction.Checked = true;
            chbxMove.Checked = true;

        }
        
        //Function gets customer ID by retrieving the greatest CustomerID from the DB, and adding one to it.
        //If there are no Customers in the DB, the ID is set to 1.
        protected int getCustID()
        {
            String sqlQuery = "SELECT MAX(CustomerID) as 'CustID' FROM Customer";
            String conString = ConfigurationManager.ConnectionStrings["Lab2"].ConnectionString;
            int maxCustID;

            SqlConnection sqlConnect = new SqlConnection(conString);
            sqlConnect.Open();
            SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnect);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            reader.Read();
            String result = reader["CustID"].ToString();
            if (reader["CustID"] == null || reader["CustID"] == "")
            {
                maxCustID = 1;
            }
            else
            {
                maxCustID = (int)reader["CustID"] + 1;
            }
            reader.Close();
            return maxCustID;
        }
    }
}