using EducationSystem.Core.UnitOfWork;
using EducationSystem.EntityFramework;
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

            using (var unitOfWork = new UnitOfWork(new EducationSystemDbContext()))
            {
                var course = unitOfWork.Courses.Get(1);

                Console.WriteLine();
                Console.WriteLine("Result of UnitOfWork");
                Console.WriteLine(course.Name);

                unitOfWork.Complete();
            }

            Console.ReadKey();
        }
    }
}
