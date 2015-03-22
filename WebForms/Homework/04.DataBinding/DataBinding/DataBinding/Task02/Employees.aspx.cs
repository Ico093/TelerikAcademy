using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataBinding.Data;

namespace DataBinding.Task02
{
    public partial class Employees : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NORTHWNDEntities context = new NORTHWNDEntities();
            List<Employee> employeesList = context.Employees.OrderBy(x => x.FirstName).ToList<Employee>();
            this.employees.DataSource = employeesList;
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Page.DataBind();
            }
        }
    }
}