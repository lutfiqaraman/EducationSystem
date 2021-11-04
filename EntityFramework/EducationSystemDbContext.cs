using EducationSystem.Entities;
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
            modelBuilder.Entity<Course>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(255);

            modelBuilder.Entity<Course>()
                .Property(c => c.Description)
                .IsRequired()
                .HasMaxLength(2000);

            modelBuilder.Entity<Course>()
                .HasRequired(c => c.Author)
                .WithMany(a => a.Courses)
                .HasForeignKey(c => c.AuthorId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Course>()
                .HasMany(c => c.Tags)
                .WithMany(t => t.Courses)
                .Map(m => {
                    m.ToTable("CourseTags");
                    m.MapLeftKey("CourseId");
                    m.MapRightKey("TagId");
                });

            modelBuilder.Entity<Course>()
                .HasRequired(c => c.Cover)
                .WithRequiredPrincipal(c => c.Course);

            base.OnModelCreating(modelBuilder);
        }
    }
}
