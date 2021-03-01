using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab2
{
    public partial class TEST_HASH_PASSWORDS : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btn_Hash(object send, EventArgs e)
        {
            lblResult.Text = PasswordHash.HashPassword(txtPassword.Text);
        }
    }
}