using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//Created by Wyatt T. Putnam

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
            String username = "testusername";
            String password = "testpassword";

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
            }
        }
    }
}