using EducationSystem.Entities;
using System.Data.Entity.ModelConfiguration;

namespace EducationSystem.EntityFramework.EntityConfigurations
{
    public class CourseConfiguration : EntityTypeConfiguration<Course>
    {
        public CourseConfiguration()
        {

            // Start :: Fields Configuration

            Property(c => c.Description)
                .IsRequired()
                .HasMaxLength(2000);

            Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(255);

            Property(c => c.FullPrice)
                .HasColumnType("float");

            // End :: Fields Configuration
    
            // Start :: Relationship Configuration

            HasRequired(c => c.Author)
                .WithMany(a => a.Courses)
                .HasForeignKey(c => c.AuthorId)
                .WillCascadeOnDelete(false);

            HasRequired(c => c.Cover)
                .WithRequiredPrincipal(c => c.Course);

            HasMany(c => c.Tags)
                .WithMany(t => t.Courses)
                .Map(m => {
                    m.ToTable("CourseTags");
                    m.MapLeftKey("CourseId");
                    m.MapRightKey("TagId");
                });

            // End :: Relationship Configuration
        }
    }
}
