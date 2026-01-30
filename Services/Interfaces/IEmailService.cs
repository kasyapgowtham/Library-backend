namespace backend.Services.Interfaces
{
    public interface IEmailService
    {
        Task SendPaymentSuccessEmail(string toEmail, decimal amount);

        Task SendBookingConfirmationEmail(string toEmail, DateTime bookedDate);
    }
}
