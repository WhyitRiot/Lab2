using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab2
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSaveChanges_Click(object sender, EventArgs e)
        {
            HttpUtility.HtmlEncode(txtCustomer.Text);
            HttpUtility.HtmlEncode(txtEmployee.Text);
            HttpUtility.HtmlEncode(txtCustomer.Text);
            HttpUtility.HtmlEncode(txtService.Text);
            HttpUtility.HtmlEncode(txtServiceTicketID.Text);
            HttpUtility.HtmlEncode(txtTicketStatus.Text);
        }
    }
}