using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab2
{
    public partial class Customer_Portal_Login : System.Web.UI.Page
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
            LoginCommand.Parameters.AddWithValue("@Username", txtUsername.Text);

            dbConnection.Open();
            SqlDataReader loginResults = LoginCommand.ExecuteReader();
            if (loginResults.HasRows)
            {
                while (loginResults.Read())
                {
                    string storedHash = loginResults["PasswordHash"].ToString();

                    if (PasswordHash.ValidatePassword(txtPassword.Text, storedHash))
                    {
                        Session["UserName"] = txtUsername.Text;
                        Response.Redirect("~/CustomerPortalHome.aspx");
                    }
                }
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