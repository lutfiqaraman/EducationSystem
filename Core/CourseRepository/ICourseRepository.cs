using EducationSystem.Core.Repositories;
using EducationSystem.Entities;
using System.Collections.Generic;

namespace EducationSystem.Core.CourseRepository
{
    public interface ICourseRepository : IRepository<Course>
    {
        IEnumerable<Course> GetTopSellingCourses(int count);
        IEnumerable<Course> GetCourseWithAuthor(int pageIndex, int pageSize);
    }
}
