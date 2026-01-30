namespace backend.Models
{
    public class StudentModel
    {
        public int Id { get; set; }

        public int studentId { get; set; }

        public string studentName { get; set; }

        public string Email { get; set; }

        public DateTime Created { get; set; }

        public string password { get; set; }
    }
}
