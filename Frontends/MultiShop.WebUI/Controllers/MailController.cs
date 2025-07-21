using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MultiShop.WebUI.Models;

namespace MultiShop.WebUI.Controllers
{
    public class MailController : Controller
    {
        [HttpGet]
        public IActionResult SendMail()
        {
            return View();
        }

        /*[HttpPost]
        public IActionResult SendMail(string recipient, string subject, string message)
        {
            // Here you would typically send the email using an email service.
            // For demonstration purposes, we'll just return a success message.
            if (string.IsNullOrEmpty(recipient) || string.IsNullOrEmpty(subject) || string.IsNullOrEmpty(message))
            {
                return BadRequest("All fields are required.");
            }
            // Simulate sending email
            // EmailService.SendEmail(recipient, subject, message);
            return Ok("Email sent successfully!");
        }*/
        [HttpPost]
        public IActionResult SendMail(MailRequest mailRequest)
        {
            MimeMessage message = new MimeMessage();

            /*MailboxAddress mailboxAddress = new MailboxAddress("MultiShop", mailRequest.ReceiverMail);*/

            MailboxAddress mailboxAddressFrom = new MailboxAddress("MultiShop", "utkaksy01@gmail.com");
            message.From.Add(mailboxAddressFrom);

            MailboxAddress mailboxAddressTo= new MailboxAddress("User", mailRequest.ReceiverMail);
            message.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder
            {
                TextBody = mailRequest.MessageContent
            };
            message.Body=bodyBuilder.ToMessageBody();

            message.Subject = mailRequest.Subject;

            SmtpClient client = new SmtpClient();
            /*client.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);*/

            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("utkaksy01@gmail.com", "gcfueunwfewjhfdx");
            client.Send(message);
            client.Disconnect(true);
            return View();

        }
    }
}
