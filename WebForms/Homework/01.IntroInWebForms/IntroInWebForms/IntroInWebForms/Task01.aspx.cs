using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IntroInWebForms
{
    public partial class Task01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void BtnSend_OnClick(object sender, EventArgs e)
        {
            this.lblResult.Text = String.Format("Hello, {0}", this.txbName.Text);
        }
    }
}