namespace backend.DTOs
{
    public class paymentRequest
    {
        public string Email { get; set; }

        public Decimal Amount { get; set; }

        public int cardnumber { get; set; }

        public string cardholdernname { get; set; }

        public DateTime Expiry { get; set; }

        public int CVV { get; set; }
    }
}
