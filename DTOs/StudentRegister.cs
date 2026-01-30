namespace backend.DTOs
{
    public class StudentRegister
    {
        public int StudentId { get; set; }

        public string StudentName { get; set; }

        public string StudentEmail { get; set; }

        public DateTime created {  get; set; }
        public string password { get; set; }
    }
}
