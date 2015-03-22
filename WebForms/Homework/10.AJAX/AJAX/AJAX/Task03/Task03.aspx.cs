using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AJAX.Task03
{
    public partial class Task03 : System.Web.UI.Page
    {
        private List<string> urls;

        protected void Page_Load(object sender, EventArgs e)
        {
            urls = new List<string>()
            {
                "~/Images/Task03/(444).jpg",
                "~/Images/Task03/(445).jpg",
                "~/Images/Task03/(446).jpg"
            };

            ImageLarge.ImageUrl = urls[0];

            RepeaterPictures.DataSource = urls;
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Page.DataBind();
            }
        }

        protected void ImageButtonSmall_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton imageButton = (sender as ImageButton);

            if(imageButton!=null){
                ImageLarge.ImageUrl = imageButton.ImageUrl;
            }
        }
    }
}