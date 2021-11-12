using EducationSystem.Entities;
using EducationSystem.EntityFramework;
using EducationSystem.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            CourseOperations courses = new CourseOperations();

            courses.GetSomeCoursesByLinqSyntax();
            courses.GetSomeCoursesByLinqExtension();
            courses.CourseFilter();
            courses.GetCoursesTags();
            courses.GroupBy();
            courses.Join();
            courses.GroupJoin();
            courses.CrossJoin();
            courses.LazyLoading();
            courses.NPlusOne();
            courses.EagerLoading();

            Console.ReadKey();
        }
    }
}
