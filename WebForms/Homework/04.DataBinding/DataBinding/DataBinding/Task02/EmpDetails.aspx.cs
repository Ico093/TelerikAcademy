using DataBinding.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DataBinding.Task02
{
    public partial class EmpDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["employee"] == null)
            {
                Response.Redirect("Employees.aspx");
            }

            int employeeNo = int.Parse(Request.Params["employee"]);

            NORTHWNDEntities context = new NORTHWNDEntities();
            List<Employee> employeesList = context.Employees.OrderBy(x=>x.FirstName).ToList<Employee>();
            this.employeeDetailsView.DataSource = new List<Employee>{ employeesList[employeeNo]};

            btnBack.Click += BtnBack_Click;
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            Page.DataBind();
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Employees.aspx");
        }
    }
}