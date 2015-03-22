using AJAX.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AJAX.Task01
{
    public partial class Task01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Page.DataBind();
            }
        }

        protected void GridViewEmployees_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridView gridView = (sender as GridView);

            if (gridView != null)
            {
                System.Threading.Thread.Sleep(3000);

                NORTHWNDEntities context = new NORTHWNDEntities();
                List<Order> orders = context.Orders.Where(x => x.EmployeeID == (int)gridView.SelectedValue).ToList<Order>();

                GridViewOrders.DataSource = orders;
                GridViewOrders.DataBind();
            }
        }
    }
}