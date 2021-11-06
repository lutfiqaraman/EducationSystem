using EducationSystem.Entities;
using EducationSystem.EntityFramework;
using System;
using System.Linq;

namespace EducationSystem.Operations
{
    public class CourseOperations
    {
        EducationSystemDbContext context = new EducationSystemDbContext();

        public void GetSomeCoursesByLinqSyntax()
        {
            IQueryable<Course> query =
                from c in context.Courses
                where c.Name.Contains("c#")
                orderby c.Name
                select c;

            Console.WriteLine("The courses are using LINQ syntax: ");

            foreach (var course in query)
            {
                Console.WriteLine("- " + course.Name);

            }

            int count =
                (from c in context.Courses
                 where c.Name.Contains("c#")
                 select c.Name
                 ).Count();

            Console.WriteLine();
            Console.WriteLine("You have {0} courses", count);
            Console.WriteLine();
        }

        public void GetSomeCoursesByExtension()
        {
            IQueryable<Course> courses = context.Courses
                .Where(c => c.Name.Contains("c#"))
                .OrderBy(c => c.Name);

            Console.WriteLine("The courses are using Extension methods: ");

            foreach (var item in courses)
            {
                Console.WriteLine("- " + item.Name);
            }

            int count = context.Courses
                .Where(c => c.Name.Contains("c#"))
                .Count();

            Console.WriteLine();
            Console.WriteLine("You have {0} courses", count);
        }
    }
}
