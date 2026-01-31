namespace backend.Services
{
    using SendGrid;
    using SendGrid.Helpers.Mail;
    using backend.Services.Interfaces;

    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public async Task SendPaymentSuccessEmail(string toEmail, decimal amount)
        {
            var apiKey = _config["SENDGRID_API_KEY"];
            var client = new SendGridClient(apiKey);

            var from = new EmailAddress(
                _config["SENDGRID_FROM_EMAIL"],
                _config["SENDGRID_FROM_NAME"]
            );

            var to = new EmailAddress(toEmail);

            var subject = "Payment Successful ✅";
            var plainTextContent = $"Your payment of ₹{amount} was successful.";
            var htmlContent = $@"
            <h2>Payment Successful 🎉</h2>
            <p>Your payment of <strong>₹{amount}</strong> has been received.</p>
        ";

            var msg = MailHelper.CreateSingleEmail(
                from, to, subject, plainTextContent, htmlContent
            );

            var response = await client.SendEmailAsync(msg);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("SendGrid email failed");
            }
        }

        //public async Task SendBookingConfirmationEmail(string toEmail, DateTime bookedDate)
        //{
        //    var smtp = new SmtpClient(_config["EmailSettings:SmtpServer"])
        //    {
        //        Port = int.Parse(_config["EmailSettings:Port"]),
        //        Credentials = new NetworkCredential(
        //            _config["EmailSettings:Username"],
        //            _config["EmailSettings:Password"]
        //        ),
        //        EnableSsl = true
        //    };
        //    var mail = new MailMessage
        //    {
        //        From = new MailAddress(
        //            _config["EmailSettings:SenderEmail"],
        //            _config["EmailSettings:SenderName"]
        //        ),
        //        Subject = "Booking Confirmed ✅",
        //        Body = $@" Hello you booked the required book on {bookedDate} was successful.",
        //        IsBodyHtml = false
        //    };
        //    mail.To.Add(toEmail);
        //    await smtp.SendMailAsync(mail);
        //}
    }
}
