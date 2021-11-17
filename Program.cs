using EducationSystem.Operations;
using System;

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
            courses.ExplicitLoading();
            courses.AddCourse();

            Console.ReadKey();
        }
    }
}
