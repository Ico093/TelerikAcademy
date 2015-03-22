using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataBinding.Data;

namespace DataBinding.Task05
{
    public partial class Employees : System.Web.UI.Page
    {
        private List<Employee> employeesList;

        protected void Page_Load(object sender, EventArgs e)
        {
            NORTHWNDEntities context = new NORTHWNDEntities();
            employeesList = context.Employees.OrderBy(x => x.FirstName).ToList<Employee>();
            this.livEmployees.DataSource = employeesList;
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Page.DataBind();
            }
        }

        protected void DataPagerEmployees_PreRender(object sender, EventArgs e)
        {
            this.livEmployees.DataSource = employeesList;
            this.livEmployees.DataBind();
        }
    }
}