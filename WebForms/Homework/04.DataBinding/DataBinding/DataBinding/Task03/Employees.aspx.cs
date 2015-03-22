using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataBinding.Data;

namespace DataBinding.Task03
{
    public partial class Employees : System.Web.UI.Page
    {
        private List<Employee> employeesList;

        protected void Page_Load(object sender, EventArgs e)
        {
            NORTHWNDEntities context = new NORTHWNDEntities();
            employeesList = context.Employees.OrderBy(x => x.FirstName).ToList<Employee>();
            this.employees.DataSource = employeesList;
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Page.DataBind();
            }
        }

        protected void BtnMoreInfo_Command(object sender, CommandEventArgs e)
        {
            this.fmvSelectedEmployee.DataSource = new List<Employee> { employeesList[0] };
            this.fmvSelectedEmployee.DataBind();
        }
    }
}