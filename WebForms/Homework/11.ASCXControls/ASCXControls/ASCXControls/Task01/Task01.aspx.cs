using ASCXControls.Models.Task01;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASCXControls.Task01
{
    public partial class Task01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ListOfLinks.Links = new List<LinkModel>()
            {
                new LinkModel(){ Title = "Click me!" , URL = "www.google.bg"},
                new LinkModel(){ Title = "Click me please!" , URL = "www.abv.bg"},
                new LinkModel(){ Title = "Don't Click me!" , URL = "www.facebook.com"},
            };
        }

        protected void Page_PreLoad(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Page.DataBind();
            }
        }
    }
}