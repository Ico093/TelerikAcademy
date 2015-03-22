using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StateManagement.Task03
{
    public partial class Task03 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (Request.Cookies["username"] == null || Request.Cookies["username"].Value != "pesho")
            {
                HyperLinkNavigateToSecondPage.Visible = false;
            }
            else
            {
                HyperLinkNavigateToSecondPage.Visible = true;
            }
        }

        protected void ButtonSignIn_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = new HttpCookie("username", "pesho");
            cookie.Expires = DateTime.Now.Add(new TimeSpan(0, 1, 0));

            Response.Cookies.Add(cookie);
        }
    }
}