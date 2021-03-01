using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Security.Cryptography;



//Created by Wyatt T. Putnam, Cole Schweikert, Shaima Sorchi

namespace Lab2
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Get("loggedout") == "true")
            {
                lblStatus.ForeColor = Color.Green;
                lblStatus.Font.Bold = true;
                lblStatus.Text = "User successfully logged out.";
            }
        }
        protected void fnLogin(object sender, EventArgs e)
        {
            SqlConnection dbConnection =
                new SqlConnection(WebConfigurationManager.ConnectionStrings["AUTH"].ConnectionString.ToString());

            SqlCommand LoginCommand = new SqlCommand();
            LoginCommand.Connection = dbConnection;
            LoginCommand.CommandType = System.Data.CommandType.StoredProcedure;
            LoginCommand.CommandText = "JeremyEzellLab3";
            LoginCommand.Parameters.AddWithValue("@Username", txtPassword.ToString());
            LoginCommand.Parameters.AddWithValue("@PasswordHash", txtPassword.ToString());
            dbConnection.Open();
            SqlDataReader loginResults = LoginCommand.ExecuteReader();

            String username = "admin";
            String password = "password";

            if (txtUsername.Text == username && txtPassword.Text == password)
            {
                Session["UserName"] = txtUsername.Text;
                Response.Redirect("~/Home.aspx");
            }
            else
            {
                lblStatus.ForeColor = Color.Red;
                lblStatus.Font.Bold = true;
                lblStatus.Text = "Username/Password incorrect.";
                HttpUtility.HtmlEncode(txtPassword.Text);
                HttpUtility.HtmlEncode(txtUsername.Text);
            }
        }
    }
}