using System;
using System.Collections.Generic;

namespace EducationSystem.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public CourseLevel Level { get; set; }
        public float FullPrice { get; set; }
        public virtual Author Author { get; set; }
        public int AuthorId { get; set; }
        public virtual IList<Tag> Tags { get; set; }
        public Cover Cover { get; set; }
    }
}
