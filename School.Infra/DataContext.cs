
using Microsoft.EntityFrameworkCore;
using School.Domain.Aggregates.Student;
using School.Infra.Configuration;

namespace School.Infra
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder model)
        {
            model.ApplyConfiguration(new StudentConfig());
        }
    }
}
