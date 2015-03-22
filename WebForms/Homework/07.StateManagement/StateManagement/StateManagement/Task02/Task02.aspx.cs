using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StateManagement.Task02
{
    public partial class Task02 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (Session["text"] != null)
            {
                LabelResult.Text = string.Join("", (Session["text"] as List<string>).ToArray());
            }
        }

        protected void ButtonAppend_Click(object sender, EventArgs e)
        {
            if (Session["text"] == null)
            {
                List<string> list = new List<string> { TextBoxEntry.Text };
                Session["text"] = list;
            }
            else
            {
                (Session["text"] as List<string>).Add(TextBoxEntry.Text);
            }
        }
    }
}