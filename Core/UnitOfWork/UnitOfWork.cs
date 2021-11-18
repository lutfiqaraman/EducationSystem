using EducationSystem.Core.CourseRepository;
using EducationSystem.EntityFramework;

namespace EducationSystem.Core.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EducationSystemDbContext Context;
        public ICourseRepository Courses { get; private set; }

        public UnitOfWork(EducationSystemDbContext context)
        {
            Context = context;
            Courses = new CourseRepository.CourseRepository(Context);
        }

        public int Complete()
        {
            return Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
