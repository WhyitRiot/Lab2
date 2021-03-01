using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
// Created by Wyatt T. Putnam, Cole Schweikert, Shaima Sorchi
namespace Lab2
{
    public partial class WebForm8 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] != null)
            {
                lblLoginSuccess.ForeColor = Color.Green;
                lblLoginSuccess.Text = "Login successful. Welcome to the PlaceHolder Moving Co Employee Website";
                lblLoginSuccess.Font.Bold = true;

                if (grdNotifictions.Rows.Count == 0)
                {
                    pnlNotifications.Visible = false;
                }
                else
                {
                    pnlNotifications.Visible = true;
                }

            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }
        }

        protected void btn_Clear(object sender, EventArgs e)
        {
            String sqlQuery = "DELETE FROM Notifications";
            String connectionString = ConfigurationManager.ConnectionStrings["Lab2"].ConnectionString;
            SqlConnection sqlConnect = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnect);

            sqlConnect.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnect.Close();
            Response.Redirect("~/Home.aspx");
        }

        //protected void btnAdd(object sender, EventArgs e)
        //{

        //}
    }
}