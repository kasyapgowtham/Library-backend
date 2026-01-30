using Microsoft.EntityFrameworkCore;
using backend.Models;
namespace backend.data
{
    public class StudentDb : DbContext
    {
        public StudentDb(DbContextOptions<StudentDb> options) : base(options)
        {
        }
        public DbSet<StudentModel> Students { get; set; }

        public DbSet<Payment> Payments { get; set; }

        public DbSet<booking> Bookings { get; set; }

    }
}
