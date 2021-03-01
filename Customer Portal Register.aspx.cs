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
            if (!(txtPassword.Text.Equals(txtConfirmPassword.Text)))
            {
                message.Text = "Passwords do not match!";
            }
            else
            {
                String userAddress = txtStreet.Text + " " + txtCity.Text + " " + txtstate.Text + " " + txtZipCode.Text;
                String userPhone = txtPhone.Text;
                String userName = txtUsername.Text;
                String userEmail = txtEmailID.Text;
                String userFirst = txtFirstname.Text;
                String userLast = txtLastname.Text;
                //String userZipCode = txtZipCode.Text;
                //String userState = txtstate.Text;
                //String userCity= txtCity.Text;

                String userPass = PasswordHash.HashPassword(txtPassword.Text);


                addUser(userFirst, userLast, userAddress, userPhone, userName, userEmail, userPass);


                message.Text = "Hello" + txtUsername.Text + "!";
                message.Text = message.Text + "<br/>  You have successfuly created a profile with the following details.";

                ShowUserName.Text = txtUsername.Text;
                ShowEmail.Text = txtEmailID.Text;

                //ShowAddressLabel.Text = "Address";
                ShowPhoneLabel.Text = "Phone";
                ShowUserNameLabel.Text = "Username";
                ShowEmailIDLabel.Text = "Email ID";
                txtUsername.Text = "";
                txtEmailID.Text = "";

                Response.Redirect("~/Customer Portal Login.aspx");
            }
        }

        protected void addUser(String userFirst, String userLast, String userAddress, String userPhone, String userName, String userEmail, String userPass)
        {
            String sqlQueryPerson = "INSERT INTO Person (FirstName, LastName, Username, UserEmail, UserPhone, UserAddress) VALUES ( @FirstName, @LastName, @Username, @UserEmail, @UserPhone, @UserAddress)";
            String sqlQueryPass = "INSERT INTO Pass (UserID, Username, PasswordHash) VALUES (@UserID, @Username, @PasswordHash)";
            //String sqlQuery = "INSERT INTO Users (UserID, UserAddress, UserPhone, UserName, UserEmail, UserPass) VALUES (@UserID, @UserAddress, @UserPhone, @UserName, @UserEmail, @UserPass)";
            String connectionString = ConfigurationManager.ConnectionStrings["AUTH"].ConnectionString;
            SqlConnection sqlConnect = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(sqlQueryPerson, sqlConnect);

            sqlCommand.Parameters.AddWithValue("@FirstName", userFirst);
            sqlCommand.Parameters.AddWithValue("@LastName", userLast);
            sqlCommand.Parameters.AddWithValue("@UserAddress", userAddress);
            sqlCommand.Parameters.AddWithValue("@UserPhone", userPhone);
            sqlCommand.Parameters.AddWithValue("@UserEmail", userEmail);
            sqlCommand.Parameters.AddWithValue("@Username", userName);
            //sqlCommand.Parameters.AddWithValue("@UserPass", userPass);

            sqlConnect.Open();
            sqlCommand.ExecuteNonQuery();
            sqlCommand = new SqlCommand(sqlQueryPass, sqlConnect);
            int userID = getUserID();
            sqlCommand.Parameters.AddWithValue("@UserID", userID);
            sqlCommand.Parameters.AddWithValue("@Username", userName);
            sqlCommand.Parameters.AddWithValue("@PasswordHash", userPass);
            sqlCommand.ExecuteNonQuery();
            sqlConnect.Close();
        }

        protected int getUserID()
        {
            String sqlQuery = "SELECT MAX(UserID) as MaxUserID FROM Person";
            String connectionString = ConfigurationManager.ConnectionStrings["AUTH"].ConnectionString;
            SqlConnection sqlConnect = new SqlConnection(connectionString);
            sqlConnect.Open();
            SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnect);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            reader.Read();
            int userID;
            userID = (int)reader["MaxUserID"];
            reader.Close();
            sqlConnect.Close();
            return userID;
        }
    }
}