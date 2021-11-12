using EducationSystem.Entities;
using EducationSystem.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public void GetSomeCoursesByLinqExtension()
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
            Console.WriteLine();

            

        }

        public void CourseFilter()
        {
            Console.WriteLine();
            Console.WriteLine("Filter Method");

            IQueryable beginnerCourse = context.Courses
                .Where(c => c.Level == CourseLevel.Beginner)
                .OrderBy(c => c.Name)
                .ThenBy(c => c.Description)
                .Select(c => new { CourseName = c.Name, AuthorName = c.Author.Name });

            foreach (var item in beginnerCourse)
            {
                Console.WriteLine(item);
            }
        }

        public void GetCoursesTags()
        {
            Console.WriteLine();
            Console.WriteLine("Get beginner Courses Tags");

            IQueryable<Tag> tags = context.Courses
                .Where(c => c.Level == CourseLevel.Beginner)
                .OrderBy(c => c.Name)
                .ThenBy(c => c.Description)
                .SelectMany(c => c.Tags)
                .Distinct();

            foreach (var t in tags)
            {
                Console.WriteLine(t.Name);
            }

            Console.WriteLine();
        }

        public void GroupBy()
        {
            Console.WriteLine();
            Console.WriteLine("Group By Level");

            var coursesByGroups = context.Courses.GroupBy(c => c.Level);

            foreach (var group in coursesByGroups)
            {
                switch (group.Key)
                {
                    case CourseLevel.Beginner:
                        Console.WriteLine("Level: Beginner");

                        foreach (var course in group)
                            Console.WriteLine("\t" + course.Name);

                        break;
                    
                    case CourseLevel.Intermediate:
                        Console.WriteLine("Level: Intermediate");

                        foreach (var course in group)
                            Console.WriteLine("\t" + course.Name);

                        break;

                    case CourseLevel.Advanced:
                        Console.WriteLine("Level: Advanced");

                        foreach (var course in group)
                            Console.WriteLine("\t" + course.Name);

                        break;

                    default:
                        break;
                }
            }

            Console.WriteLine();
        }

        public void Join()
        {
            var data = context.Courses
                .Join(context.Authors, c => c.AuthorId, a => a.Id, (course, author) => new { 
                    CourseName = course.Name,
                    AuthorName = author.Name
                })
                .Select(x => new { x.CourseName, x.AuthorName })
                .ToList();

            Console.WriteLine("Join Course with Author");

            foreach (var item in data)
            {
                Console.WriteLine(item.CourseName + " was written by " + item.AuthorName);
            }

            Console.WriteLine();
            Console.WriteLine();
        }

        public void GroupJoin()
        {
            var data = 
                context.Authors.GroupJoin(context.Courses, a => a.Id, c => c.AuthorId, (author, courses) => new
                {
                    Author = author,
                    CoursesCount = courses.Count()
                });

            foreach (var item in data)
            {
                Console.WriteLine(item.Author.Name + " wrote " + item.CoursesCount + " books");
            }

            Console.WriteLine();
            Console.WriteLine();
        }

        public void CrossJoin()
        {
            var data =
                context.Authors.SelectMany(a => context.Courses, (author, course) => new
                {
                    AuthorName = author.Name,
                    CourseName = course.Name
                });

            foreach (var item in data)
            {
                Console.WriteLine(item.AuthorName + " wrote " + item.CourseName);
            }

            Console.WriteLine();
            Console.WriteLine();
        }

        public void LazyLoading()
        {
            var course = context.Courses.Single(c => c.Id == 2);
            string courseName = course.Name;

            Console.WriteLine("Tags of Course " + courseName + " are: ");

            foreach (var tag in course.Tags)
                Console.WriteLine("- " + tag.Name);

            Console.WriteLine();
            Console.WriteLine();
        }

        public void NPlusOne()
        {
            Console.WriteLine("N Plus One Problem");

            List<Course> courses = context.Courses.ToList();

            foreach (var course in courses)
            {
                Console.WriteLine("{0} by {1}", course.Name, course.Author.Name);
            }

            Console.WriteLine();
            Console.WriteLine();
        }

        public void EagerLoading()
        {
            Console.WriteLine("Eager Loading");

            List<Course> courses = context.Courses.Include(c => c.Author).ToList();

            foreach (var course in courses)
                Console.WriteLine("{0} by {1}", course.Name, course.Author.Name);

            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
