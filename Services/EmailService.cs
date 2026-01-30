namespace backend.Services
{
    using backend.Services.Interfaces;
    using System.Net;
    using System.Net.Mail;

    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public async Task SendPaymentSuccessEmail(string toEmail, decimal amount)
        {
            var smtp = new SmtpClient(_config["EmailSettings:SmtpServer"])
            {
                Port = int.Parse(_config["EmailSettings:Port"]),
                Credentials = new NetworkCredential(
                    _config["EmailSettings:Username"],
                    _config["EmailSettings:Password"]
                ),
                EnableSsl = true
            };

            var mail = new MailMessage
            {
                From = new MailAddress(
                    _config["EmailSettings:SenderEmail"],
                    _config["EmailSettings:SenderName"]
                ),
                Subject = "Payment Successful ✅",
                Body = $@"
Hello,

Your payment of ₹{amount} was successful.

Thank you for purchasing from our Durex.

Have good time with your partner.

Regards,
Durex Team",
                IsBodyHtml = false
            };

            mail.To.Add(toEmail);

            await smtp.SendMailAsync(mail);
        }

        public async Task SendBookingConfirmationEmail(string toEmail, DateTime bookedDate)
        {
            var smtp = new SmtpClient(_config["EmailSettings:SmtpServer"])
            {
                Port = int.Parse(_config["EmailSettings:Port"]),
                Credentials = new NetworkCredential(
                    _config["EmailSettings:Username"],
                    _config["EmailSettings:Password"]
                ),
                EnableSsl = true
            };
            var mail = new MailMessage
            {
                From = new MailAddress(
                    _config["EmailSettings:SenderEmail"],
                    _config["EmailSettings:SenderName"]
                ),
                Subject = "Booking Confirmed ✅",
                Body = $@" Hello you booked the required book on {bookedDate} was successful.",
                IsBodyHtml = false
            };
            mail.To.Add(toEmail);
            await smtp.SendMailAsync(mail);
        }
    }
}
