using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab2
{
    public partial class CustomerPortalHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] != null)
            {

            }
            else
            {
                Response.Redirect("~/Customer Portal Login.aspx");
            }
        }
        protected void btnSubmitRequest_Click(object sender, EventArgs e)
        {
            createNotification(TextBoxService.Text, TextBoxServiceDate.Text, TextBoxDescription.Text);
            lblStatus.Text = "Sent your service request!";
        }

        protected void btn_Logout(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/Customer Portal Login.aspx?loggedout=true");
        }

        protected void createNotification(String service, String date, String description)
        {
            String userName = Session["UserName"].ToString();
            String sqlQuery = "INSERT INTO Notifications (NotificationID, Customer, ServiceNeeded, DateNeeded, NoteDescription) VALUES (@NotificationID, @Customer, @ServiceNeeded, @DateNeeded, @NoteDescription)";
           
            String connectionString = ConfigurationManager.ConnectionStrings["Lab2"].ConnectionString;
            SqlConnection sqlConnect = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnect);
            int noteID = getNoteID();
            sqlCommand.Parameters.AddWithValue("@NotificationID", noteID);
            sqlCommand.Parameters.AddWithValue("@Customer", userName);
            sqlCommand.Parameters.AddWithValue("@ServiceNeeded", service);
            sqlCommand.Parameters.AddWithValue("@DateNeeded", date);
            sqlCommand.Parameters.AddWithValue("@NoteDescription", description);

            sqlConnect.Open();
            sqlCommand.ExecuteNonQuery();

            sqlConnect.Close();
        }

        protected int getNoteID()
        {
            String noteQuery = "SELECT MAX(NotificationID) as NoteID from Notifications";

            String connectionString = ConfigurationManager.ConnectionStrings["Lab2"].ConnectionString;
            SqlConnection sqlConnect = new SqlConnection(connectionString);
            sqlConnect.Open();
            SqlCommand sqlCommand = new SqlCommand(noteQuery, sqlConnect);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            reader.Read();
            int noteID;
            if (reader["NoteID"].ToString() == "" || reader["NoteID"].ToString() == null)
            {
                noteID = 1;
            }
            else
            {
                noteID = (int)reader["TicketHistory"] + 1;
            }
            reader.Close();
            sqlConnect.Close();

            return noteID;
        }
    }
}