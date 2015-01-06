using System;
using SendGrid;
using System.Net;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using PancakeProwler.Data.Common.Models;

namespace PancakeProwler.BookCreator
{
    class MailSender : IMailSender
    {

        public void SendCreationEMail(BookCreationRequest request)
        {
            try
            {
                var mailMessage = CreateEMailMessage(request);
                SendMessage(mailMessage);
            }
            catch (Exception ex)
            {
                Trace.WriteLine("Error sending: " + ex.Message, "Error");
            }
            Trace.WriteLine(request.EMail, "Information");
        }
        private SendGridMessage CreateEMailMessage(PancakeProwler.Data.Common.Models.BookCreationRequest decodedMessage)
        {
            var mailMessage = new SendGridMessage();
            mailMessage.AddTo(decodedMessage.EMail);
            mailMessage.From = new System.Net.Mail.MailAddress("cookbook@pancakeprowler.com", "Pancake Prowler");
            mailMessage.Subject = "Cookbook Ready";
            mailMessage.Html = String.Format(@"Hello {0}, Your personalized cook book is available. To download it simply click <a href='{1}'>here</a>",
                                   decodedMessage.Name,
                                   new PdfCreator().GetCookBook(decodedMessage.Name));
            return mailMessage;
        }
        private void SendMessage(SendGridMessage mailMessage)
        {
            var credentials = new NetworkCredential("username", "password");
            var transportREST = new Web(credentials);
            transportREST.Deliver(mailMessage);
        }
    }
}
