using EducationSystem.Core.Repositories;
using EducationSystem.Entities;
using EducationSystem.EntityFramework;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace EducationSystem.Core.CourseRepository
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        public CourseRepository(EducationSystemDbContext context)
            : base(context)
        {

        }

        public IEnumerable<Course> GetCourseWithAuthor(int pageIndex, int pageSize)
        {
            return Context.Courses
                .Include(c => c.Author)
                .OrderBy(c => c.Name)
                .Skip((pageSize - 1) * pageSize)
                .Take(pageSize);
        }

        public IEnumerable<Course> GetTopSellingCourses(int count)
        {
            return Context.Courses.OrderByDescending(c => c.FullPrice).Take(count).ToList();
        }
    }
}
