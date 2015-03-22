using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAndHTMLControls
{
    public partial class Task01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnGenerate_Click(object sender, EventArgs e)
        {
            int from = int.Parse(this.from.Value);
            int to = int.Parse(this.to.Value);

            Random rnd = new Random();
            this.result.Value = rnd.Next(from, to).ToString();
        }
    }
}