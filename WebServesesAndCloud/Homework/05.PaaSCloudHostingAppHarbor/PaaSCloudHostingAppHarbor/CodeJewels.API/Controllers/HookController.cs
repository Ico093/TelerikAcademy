using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Typesafe.Mailgun;

namespace itGeorgeHook.Controllers
{
    public class HookController : ApiController
    {
        public void Post([FromBody] Dictionary<string, object> content)
        {
            if (ConfigurationManager.AppSettings["disableHook"] == "false")
            {
                var buildReport = JsonConvert.SerializeObject(content);

                var mailgunKeyName = "MAILGUN_API_KEY";

                var mailClient = new MailgunClient("appfb77ce4ac30d479896173fbeb06745d4.mailgun.org", ConfigurationManager.AppSettings[mailgunKeyName]);
                mailClient.SendMail(new System.Net.Mail.MailMessage("ico_di@abv.bg", "hristodimitrov.work@gmail.com")
                {
                    Subject = "Build Report",
                    Body = buildReport
                });
            }
        }
    }
}
