using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;
using System.Net.Mail;

namespace WestWindWebApp.Pages
{
    public class SendMailModel : PageModel
    {
        [BindProperty]
        public string MailToAddress { get; set; }
        [BindProperty]
        public string MailSubject { get; set; }
        [BindProperty]
        public string MailUsername { get; set; }
        [BindProperty]
        public string MailPassword { get; set; }
        [BindProperty]
        public string MailMessage { get; set; }

        public void OnGet()
        {
            //MailUsername = "johnnysins@gmail.com";
            //MailPassword = "manOFmanyTalents";
            //MailToAddress = "swu@nait.ca";
            //MailSubject = "CPSC1517 Send Mail demo";
            //MailMessage = "This email was sent from a Razor Page";

            var sendMailClient = new SmtpClient();
            sendMailClient.Host = "localhost";
            sendMailClient.Port = 587;
            sendMailClient.EnableSsl = true;
            var sendMailCredentials = new NetworkCredential();
            sendMailCredentials.UserName = MailUsername;
            sendMailCredentials.Password = MailPassword;
            sendMailClient.Credentials = sendMailCredentials;

            var sendFromAddress = new MailAddress(MailUsername);
            var sendToAddress = new MailAddress(MailToAddress);

            var mailMessage = new MailMessage(sendFromAddress, sendToAddress);
            mailMessage.Subject = MailSubject;
            mailMessage.Body = MailMessage;
            sendMailClient.Send(mailMessage);
        }

    }
}
