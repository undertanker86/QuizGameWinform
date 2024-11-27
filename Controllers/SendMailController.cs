using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace QuizGame.Controllers
{
    public class SendMailController
    {
        public void SendMail(string toEmailAddress, string subject, string content)
        {
            var fromEmailAddress = "quizapp@zohomail.com";
            var fromEmailDisplayName = "QUIZAPP";
            var fromEmailPassword = "GBPfvX4yY0Yw";
            var smtpHost = "smtp.zoho.com";
            var smtpPort = 587;

            if (string.IsNullOrEmpty(fromEmailAddress))
                throw new ArgumentNullException(nameof(fromEmailAddress), "From email address cannot be null or empty.");
            if (string.IsNullOrEmpty(toEmailAddress))
                throw new ArgumentNullException(nameof(toEmailAddress), "To email address cannot be null or empty.");

            using (var message = new MailMessage(new MailAddress(fromEmailAddress, fromEmailDisplayName), new MailAddress(toEmailAddress))
            {
                Subject = subject,
                IsBodyHtml = true,
                Body = content
            })
            using (var client = new SmtpClient
            {
                Credentials = new NetworkCredential(fromEmailAddress, fromEmailPassword),
                Host = smtpHost,
                EnableSsl = true,
                Port = smtpPort
            })
            {
                try
                {
                    client.Send(message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error sending email: {ex.Message}");
                }
            }
        }
    }
}
