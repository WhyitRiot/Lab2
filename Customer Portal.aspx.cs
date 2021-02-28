using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Configuration;
using System.Data.SqlClient;

namespace Lab2
{
    public partial class Customer_Portal : System.Web.UI.Page
    {
        protected System.Web.UI.HtmlControls.HtmlInputFile File1;
        protected System.Web.UI.HtmlControls.HtmlInputFile Submit1;

        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Create(object sender, EventArgs e)
        {
            message.Text = "Hello" + Username.Text + "!";
            message.Text = message.Text + "<br/>  You have successfuly created a profile with the following details.";

            ShowUserName.Text = Username.Text;
            ShowEmail.Text = Email.Text;

            ShowAddressLabel.Text = "Address";
            ShowPhoneLabel.Text = "Phone";
            ShowUserNameLabel.Text = "Username";
            ShowEmailIDLabel.Text = "Email ID";

            Username.Text = "";
            Email.Text = "";



                addUser(userID, userAddress, userPhone, userName, userEmail, userPass);

            }
        }

        protected void addUser(int userID, String userAddress, String userPhone, String userName, String userEmail, String userPass)
        {
            String sqlQuery = "INSERT INTO Users (UserID, UserAddress, UserPhone, UserName, UserEmail, UserPass) VALUES (@UserID, @UserAddress, @UserPhone, @UserName, @UserEmail, @UserPass)";
            String connectionString = ConfigurationManager.ConnectionStrings["AUTH"].ConnectionString;
            SqlConnection sqlConnect = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnect);
            sqlCommand.Parameters.AddWithValue("@UserID", userID);
            sqlCommand.Parameters.AddWithValue("@UserAddress", userAddress);
            sqlCommand.Parameters.AddWithValue("@UserPhone", userPhone);
            sqlCommand.Parameters.AddWithValue("@UserEmail", userEmail);
            sqlCommand.Parameters.AddWithValue("@UserName", userName);
            sqlCommand.Parameters.AddWithValue("@UserPass", userPass);

            sqlConnect.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnect.Close();
        }

        protected int getUserID()
        {
            String sqlQuery = "SELECT MAX(UserID) as MaxUserID FROM Users";
            String connectionString = ConfigurationManager.ConnectionStrings["AUTH"].ConnectionString;
            SqlConnection sqlConnect = new SqlConnection(connectionString);
            sqlConnect.Open();
            SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnect);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            reader.Read();
            int userID;
            if (reader["MaxUserID"] == null || reader["MaxUserID"] == "")
            {
                userID = 1;
            }
            else
            {
                userID = (int)reader["MaxUserID"] + 1;
            }
            reader.Close();
            sqlConnect.Close();
            return userID;
        }

    }

}