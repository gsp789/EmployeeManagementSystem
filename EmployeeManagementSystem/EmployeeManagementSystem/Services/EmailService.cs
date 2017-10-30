using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace EmployeeManagementSystem.Services
{
    public class EmailService: IEmailService
    {
        public void PasswordRecoveryEmail(string to_address, string guid)
        {
            string url = HelperMethods.PasswordRecoveryUrl(guid);
            SendEmail(to_address, "Reset Password", PasswordRecoveryEmailBody(url));

        }

        private static string PasswordRecoveryEmailBody(string url)
        {
            return "<div><span>Dear User,</span><br/><p style='margin-left:20px;'>Please click on the below url to reset your password:</p>" +
                "<br/><p style='margin-left:20px;'><a href='" + url + "'>Click here to reset your password</a></p>" +
                "<br/><p>Thanks,</p><p>Employee Management Syste</div>";
        }
        private static void SendEmail(string to_address, string email_subject, string email_body)
        {
            string from = "ramireddy760@gmail.com";
            string pswd = "srcwfctuwmdvhhuc";
            string[] to = new string[] { to_address };
            string subject = email_subject;
            string body = email_body;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.Credentials = new NetworkCredential(from, pswd);
            MailMessage message = new MailMessage();
            message.Sender = new MailAddress(from, "Employee Management System");
            message.From = new MailAddress(from, "Employee Management System");
            message.Subject = subject;
            message.Body = body;
            message.IsBodyHtml = true;
            foreach (string toMail in to)
            {
                object email = message;
                MailAddress mail = new MailAddress(toMail, "Recipient");
                message.To.Add(mail);
                smtp.SendAsync(message, email);
                message.To.Clear();
            }
        }
    }
}
