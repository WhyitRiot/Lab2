using System;
using System.Collections.Generic;
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
                if (!(Session["s1"] == null))
                {
                    LabelNotification.Text = Session["s1"].ToString();
                    LabelNotification.Text = Session["s2"].ToString();
                    LabelNotification.Text = Session["s3"].ToString();
                }


            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }
        }
    }
}