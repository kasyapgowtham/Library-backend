namespace backend.Models
{
    public class booking
    {
        public int id { get; set; }
        public string? studentId { get; set; }
        public string? Email { get; set; }

        public DateTime booked { get; set; }
    }
}
