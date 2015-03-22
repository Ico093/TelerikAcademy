using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAndHTMLControls
{
    public partial class Task03 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnSubmit_OnClick(object sender, EventArgs e)
        {
            this.tbxResult.Text = this.tbxInput.Text;
            this.lblResult.Text = Server.HtmlEncode(this.tbxInput.Text);
        }
    }
}