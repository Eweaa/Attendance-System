using Attendance_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Attendance_System.Context
{
    public class ITIContext : DbContext
    {
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Intake> Intakes { get; set; }
        public DbSet<Models.Program> Programs { get; set; }
        public DbSet<User> Users { get; set; }

        public ITIContext(DbContextOptions options) : base(options)
        {
        }
    }
}
