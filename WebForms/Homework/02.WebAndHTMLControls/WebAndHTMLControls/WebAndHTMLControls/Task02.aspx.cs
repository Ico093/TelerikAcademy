using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAndHTMLControls
{
    public partial class Task02 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnGenerate_Click(object sender, EventArgs e)
        {
            int from = int.Parse(this.from.Text);
            int to = int.Parse(this.to.Text);

            Random rnd = new Random();
            this.result.Text = rnd.Next(from, to).ToString();
        }
    }
}