using EducationSystem.Entities;
using EducationSystem.EntityFramework;
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
            EducationSystemDbContext context = new EducationSystemDbContext();

            // START :: LINQ Syntax
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

            // END :: LINQ Syntax

            Console.WriteLine();

            // START :: Extension Method

            var courses = context.Courses
                .Where(c => c.Name.Contains("c#"))
                .OrderBy(c => c.Name);

            Console.WriteLine("The courses are using Extension methods: ");

            foreach (var item in courses)
            {
                Console.WriteLine("- " + item.Name);
            }

            count = context.Courses
                .Where(c => c.Name.Contains("c#"))
                .Count();

            Console.WriteLine();
            Console.WriteLine("You have {0} courses", count);
            // END :: Extension Method

            Console.ReadKey();
        }
    }
}
