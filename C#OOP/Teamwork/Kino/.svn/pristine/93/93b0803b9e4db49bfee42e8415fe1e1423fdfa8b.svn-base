using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Kino.Classes
{
    class EmailSender:ISender
    {
        public void Send(object content)
        {
            throw new NotImplementedException();
        }

        private static void SendToGroupOfCustomers(List<MailAddress> customersAddresses, string subject, string body)
        {
            var fromAddress = new MailAddress("eilatstonecrew@gmail.com", "EilatStone Team");            
            const string fromPassword = "eilatcrew";
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            //Create Message
            var message = new MailMessage()
            {
                Subject = subject,
                Body = body,
                From=fromAddress,
            };
            //Add Recipients
            for (int i = 0; i < customersAddresses.Count; i++)
            {
                message.To.Add(customersAddresses[i]);
            }            
            //Sending
            using (message)
            {
                try
                {
                    smtp.Send(message);
                }
                catch (SmtpException)
                {
                    MessageBox.Show("Connection Problems. Please try again later!");
                }

            }
        }
        public void SendToAll(object content)
        {
            CustomersStorage.Instance.GetInformation();
            List<MailAddress> addresses = new List<MailAddress>();
            foreach (var customer in CustomersStorage.Customers)
            {
                addresses.Add(new MailAddress(customer.Email,customer.Name));
            }
            if (addresses.Count>0)
            {
                SendToGroupOfCustomers(addresses, "News", content.ToString());
            }
            
        }
    }
}