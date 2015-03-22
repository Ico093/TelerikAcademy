using ASCXControls.Models.Task01;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASCXControls.Controls.Task01
{
    public partial class ListOfLinks : System.Web.UI.UserControl
    {
        public ICollection<LinkModel> Links { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.DataListLinks.DataSource = Links;
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            this.DataBind();
        }
    }
}