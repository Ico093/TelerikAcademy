using Identity.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Identity
{
    public partial class Chat : System.Web.UI.Page
    {
        private ApplicationDbContext context = new ApplicationDbContext();
        private ApplicationUser LoggedUser;

        protected void Page_Load(object sender, EventArgs e)
        {
            List<Message> messages = context.Messages.Take(100).ToList<Message>();

            RepeaterMessages.DataSource = messages;
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)
            {
                UpdatePanelInputMessage.Visible = false;
            }
            else
            {
                UpdatePanelInputMessage.Visible = true;
            }

            if (!IsPostBack)
            {
                Page.DataBind();
            }
        }

        protected void Refresh(object sender, EventArgs e)
        {
            List<Message> messages = context.Messages.Take(100).ToList<Message>();

            RepeaterMessages.DataSource = messages;
            RepeaterMessages.DataBind();
        }

        protected void ButtonSend_Click(object sender, EventArgs e)
        {
            if (TextBoxMessage.Text != "")
            {
                try
                {
                    ApplicationUserManager manager = new ApplicationUserManager(new UserStore<ApplicationUser>(new ApplicationDbContext()));
                    LoggedUser = manager.FindByNameAsync(Context.User.Identity.Name).Result;

                    context.Messages.Add(new Message() { User = LoggedUser.Name, Text = TextBoxMessage.Text });
                    context.SaveChanges();

                    TextBoxMessage.Text = "";
                }
                catch (Exception ex)
                {

                }
            }
        }

        protected void TimerRefresh_Tick(object sender, EventArgs e)
        {
            Refresh(sender, e);
        }

        protected void RepeaterMessages_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Button ButtonEdit = (Button)e.Item.FindControl("ButtonEdit");
            Button ButtonDelete = (Button)e.Item.FindControl("ButtonDelete");

            if (!User.IsInRole("Moderator") && !User.IsInRole("Administrator"))
            {
                ButtonEdit.Visible = false;
            }
            else
            {
                ButtonEdit.Visible = true;
            }

            if (!User.IsInRole("Administrator"))
            {
                ButtonDelete.Visible = false;
            }
            else
            {
                ButtonDelete.Visible = true;
            }
        }

        protected void ButtonEditDelete_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                int Id = int.Parse((string)e.CommandArgument);
                Message msg = context.Messages.FirstOrDefault(x => x.Id == Id);

                if (msg != null)
                {
                    context.Messages.Remove(msg);
                    context.SaveChanges();

                    Refresh(sender,e);
                }
            }

            if (e.CommandName == "Edit")
            {
                //some logic for edit. I'm lazy
            }
        }
    }
}