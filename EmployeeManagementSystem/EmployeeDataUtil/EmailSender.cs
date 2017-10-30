using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace EmployeeDataUtil
{

    public interface IEmailSender
    {
        void SendEmail(Email email);
    }
    public class EmailSender : IEmailSender
    {
        public EmailSender()
        {

        }
        public void SendEmail(Email email)
        {
            string from = email.fromAddress;
            string pswd = "srcwfctuwmdvhhuc";
            List<string> toAddress = email.toAddress;
            string subject = email.subject;
            string body = email.body;
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
            foreach (string toMail in toAddress)
            {
                object email1 = message;
                MailAddress mail = new MailAddress(toMail, "Recipient");
                message.To.Add(mail);
                try
                {
                    smtp.SendAsync(message, email1);

                }
                catch(Exception e)
                {

                }
                message.To.Clear();
            }
        }
   
    }
}
