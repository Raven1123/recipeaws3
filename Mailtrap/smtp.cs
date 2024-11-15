using System.Net;
using System.Net.Mail;


namespace Mailtrap

{

    public class smtp
    {
        private readonly SmtpClient _smtpClient;

        public smtp()
        {
            _smtpClient = new SmtpClient("sandbox.smtp.mailtrap.io", 2525)
            {
                Credentials = new NetworkCredential("286ca5f335ebb4", "bbe7541cf04272"),
                EnableSsl = true
            };
        }

        public void SendEmail(string toEmail, string subject, string body)
        {
            var mailMessage = new MailMessage("ravencardeno31@gmail.com", toEmail)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };

            _smtpClient.Send(mailMessage);
            Console.WriteLine("Email sent to: " + toEmail);
        }
    }
}
