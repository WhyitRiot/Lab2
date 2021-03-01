﻿using System;
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
            HttpUtility.HtmlEncode(txtCity.Text);
            HttpUtility.HtmlEncode(txtEmail.Text);
            HttpUtility.HtmlEncode(txtFirstName.Text);
            HttpUtility.HtmlEncode(txtHear.Text);
            HttpUtility.HtmlEncode(txtLastName.Text);
            HttpUtility.HtmlEncode(txtPhone.Text);
            HttpUtility.HtmlEncode(txtState.Text);
            HttpUtility.HtmlEncode(txtStreet.Text);
            HttpUtility.HtmlEncode(txtZip.Text);

            //CustomerID is recieved from separate function.
            int maxCustID = getCustID();

            String address = txtStreet.Text + " " + txtCity.Text + ", " + txtState.Text + " " + txtZip.Text;

            //Adding a customer uses the Customer class
            Customer newCustomer = new Customer(txtFirstName.Text, txtLastName.Text, maxCustID, txtPhone.Text, address);

            String sqlQuery = "INSERT INTO Customer(CustomerID, FirstName, LastName, Phone, \"Address\") VALUES ("
                        + newCustomer.CustomerID + ", '" + newCustomer.FirstName + "', '" + newCustomer.LastName + "', '"
                        + newCustomer.Phone + "', '" + newCustomer.Address + "')";

            String conString = ConfigurationManager.ConnectionStrings["Lab2"].ConnectionString;

            SqlConnection sqlConnect = new SqlConnection(conString);
            sqlConnect.Open();

            SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnect);

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
            HttpUtility.HtmlEncode(txtCity.Text);
            HttpUtility.HtmlEncode(txtEmail.Text);
            HttpUtility.HtmlEncode(txtFirstName.Text);
            HttpUtility.HtmlEncode(txtHear.Text);
            HttpUtility.HtmlEncode(txtLastName.Text);
            HttpUtility.HtmlEncode(txtPhone.Text);
            HttpUtility.HtmlEncode(txtState.Text);
            HttpUtility.HtmlEncode(txtStreet.Text);
            HttpUtility.HtmlEncode(txtZip.Text);
        }

        protected void GenerateData(object sender, EventArgs e)
        {
            txtFirstName.Text = "Wyatt";
            txtLastName.Text = "Putnam";
            txtPhone.Text = "804-267-7840";
            txtStreet.Text = "123 Street";
            txtCity.Text = "Harrisonburg";
            txtState.Text = "VA";
            txtZip.Text = "22801";
            txtHear.Text = "Online";
            HttpUtility.HtmlEncode(txtCity.Text);
            HttpUtility.HtmlEncode(txtEmail.Text);
            HttpUtility.HtmlEncode(txtFirstName.Text);
            HttpUtility.HtmlEncode(txtHear.Text);
            HttpUtility.HtmlEncode(txtLastName.Text);
            HttpUtility.HtmlEncode(txtPhone.Text);
            HttpUtility.HtmlEncode(txtState.Text);
            HttpUtility.HtmlEncode(txtStreet.Text);
            HttpUtility.HtmlEncode(txtZip.Text);

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