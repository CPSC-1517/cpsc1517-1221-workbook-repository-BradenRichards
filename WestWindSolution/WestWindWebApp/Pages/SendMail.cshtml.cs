using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;

namespace WestWindWebApp.Pages
{
    public class SendMailModel : PageModel
    {

        public void OnGet()
        {
            //var gmailUsername = Configuration["GmailCredentials:Username"];
            //var gmailAppPassword = Configuration["GmailCredentials:Password"];
            //FeedbackMessage = $"Gmail Username = {gmailUsername} <br />";
            //FeedbackMessage += $"Gmail App Password = {gmailAppPassword} <br />";
        }

        private readonly IConfiguration Configuration;

        public SendMailModel(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        [BindProperty]
        public string FeedbackMessage { get; set; }

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

        public void OnPostSendMail()
        {
            FeedbackMessage = "<h2>Send Mail button clicked</h2>";

            var sendMailClient = new SmtpClient();
            sendMailClient.Host = "smtp.gmail.com";
            sendMailClient.Port = 587;
            sendMailClient.EnableSsl = true;

            var sendMailCredentials = new NetworkCredential();
            MailUsername = Configuration["GmailCredentials:Username"];
            MailPassword = Configuration["GmailCredentials:Password"];
            sendMailCredentials.UserName = MailUsername;
            sendMailCredentials.Password = MailPassword;

            sendMailClient.Credentials = sendMailCredentials;

            var sendFromAddress = new MailAddress(MailUsername);
            var sendToAddress = new MailAddress(MailToAddress);

            var mailMessage = new MailMessage(sendFromAddress, sendToAddress);
            mailMessage.Subject = MailSubject;
            mailMessage.Body = MailMessage;

            try
            {
                sendMailClient.Send(mailMessage);
                //Clear the form fields associated with the properties below
                MailSubject = "";
                MailMessage = "";
                MailToAddress = "";
                FeedbackMessage = "<div class='alert alert-primary'>Email Sent!</div>";
            }
            catch(Exception)
            {
                FeedbackMessage = "<div class='alert alert-danger'>Error sending email</div>";
            }
            
        }

        public void OnPostClearForm()
        {
            FeedbackMessage = "<h2>Clear Form button clicked</h2>";
        }


    }
}
