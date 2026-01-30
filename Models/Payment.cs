namespace backend.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public string Email { get; set; }

        public Decimal Amount { get; set; }

        public int cardnumber { get; set; }

        public string cardholdernname { get; set; }

        public DateTime Expiry { get; set; }

        public int CVV { get; set; }
    }
}
