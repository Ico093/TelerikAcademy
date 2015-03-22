using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace WebAndHTMLControls
{
    public partial class Task04 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnSubmit_OnClick(object sender, EventArgs e)
        {
            var h1 = new HtmlGenericControl("h1");
            h1.InnerText = this.firstName.Text;
            this.resultDiv.Controls.Add(h1);

            h1 = new HtmlGenericControl("h1");
            h1.InnerText = this.lastName.Text;
            this.resultDiv.Controls.Add(h1);

            h1 = new HtmlGenericControl("h1");
            h1.InnerText = this.facultyNumber.Text;
            this.resultDiv.Controls.Add(h1);

            var p = new HtmlGenericControl("p");
            p.InnerText = this.univercity.SelectedValue;
            this.resultDiv.Controls.Add(p);

            p = new HtmlGenericControl("p");
            foreach (var item in this.courses.Items)
            {
                var listItem = item as ListItem;
                if (listItem != null && listItem.Selected == true)
                {
                    p.InnerText += listItem.Value;
                }
            }
            this.resultDiv.Controls.Add(p);
        }
    }
}