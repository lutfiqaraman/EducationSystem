using EducationSystem.Entities;
using EducationSystem.EntityFramework.EntityConfigurations;
using System.Data.Entity;

namespace EducationSystem.EntityFramework
{
    public class EducationSystemDbContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public EducationSystemDbContext()
            :base("name = DefaultConnection")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CourseConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
