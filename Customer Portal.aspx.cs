using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Lab2
{
    public partial class Customer_Portal : System.Web.UI.Page
    {
        protected System.Web.UI.HtmlControls.HtmlInputFile File1;
        protected System.Web.UI.HtmlControls.HtmlInputFile Submit1;

        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
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





        }



    }
}