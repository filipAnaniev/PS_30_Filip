using System.Data.Entity;
using UserLogin;

namespace StudentInfoSystem.ViewModels
{
    public class StudentInfoContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<User> Users { get; set; }

        public StudentInfoContext()
            : base(Properties.Settings.Default.DbConnect)
        { }
    }
}
