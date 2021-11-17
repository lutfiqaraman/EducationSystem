using EducationSystem.Core.Repositories;
using EducationSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationSystem.Core.CourseRepository
{
    public interface ICourseRepository : IRepository<Course>
    {
        IEnumerable<Course> GetTopSellingCourses(int count);
        IEnumerable<Course> GetCourseWithAuthor(int pageIndex, int pageSize);
    }
}
