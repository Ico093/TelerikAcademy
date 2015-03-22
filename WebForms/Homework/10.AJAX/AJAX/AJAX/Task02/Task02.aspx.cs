using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using AJAX.Data;

namespace AJAX.Task02
{
    public partial class Task02 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ChatEntities context = new ChatEntities();
            List<Message> messages = context.Messages.Take(100).ToList<Message>();

            RepeaterMessages.DataSource = messages;
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Page.DataBind();
            }
        }

        protected void Refresh(object sender, EventArgs e)
        {
            ChatEntities context = new ChatEntities();
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
                    ChatEntities context = new ChatEntities();

                    context.Messages.Add(new Message() { Username = TextBoxUsername.Text, Text = TextBoxMessage.Text });
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
            Refresh(sender,e);
        }
    }
}