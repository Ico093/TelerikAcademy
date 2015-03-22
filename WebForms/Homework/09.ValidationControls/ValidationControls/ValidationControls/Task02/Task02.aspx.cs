using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ValidationControls.Task02
{
    public partial class Task02 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CheckBoxRequired_ServerValidate(object sender, ServerValidateEventArgs e)
        {
            e.IsValid = CheckBoxAccept.Checked;
        }

        protected void ButtonLoginInfo_Click(object sender, EventArgs e)
        {
            Page.Validate("ValidationGroupLogonInfo");
            ValidationSummary.ValidationGroup = "ValidationGroupLogonInfo";
        }

        protected void ButtonPersonalInfo_Click(object sender, EventArgs e)
        {
            Page.Validate("ValidationGroupPersonalInfo");
            ValidationSummary.ValidationGroup = "ValidationGroupPersonalInfo";
        }

        protected void ButtonAddressInfo_Click(object sender, EventArgs e)
        {
            Page.Validate("ValidationGroupAddressInfo");
            ValidationSummary.ValidationGroup = "ValidationGroupAddressInfo";
        }
    }
}