using System;
using System.Collections.Generic;
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
            Session["s1"] = TextBoxService.Text;
            Session["s2"] = TextBoxDescription.Text;
            Session["s3"] = TextBoxServiceDate.Text;

        }
    }
}