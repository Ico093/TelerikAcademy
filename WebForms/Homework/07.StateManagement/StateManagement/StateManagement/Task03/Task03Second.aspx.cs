using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StateManagement.Task03
{
    public partial class Task03Second : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["username"] == null || Request.Cookies["username"].Value != "pesho" )
            {
                Response.Redirect("~/Task03/Task03First.aspx");
            }
        }
    }
}