using System;
using System.Collections.Generic;

namespace DbFirst
{
    public partial class Course
    {
        public Course()
        {
            CourseSections = new HashSet<CourseSection>();
            Tags = new HashSet<Tag>();
        }

        public int CourseId { get; set; }
        public int AuthorId { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public short Price { get; set; }
        public string LevelString { get; set; } = null!;
        public byte Level { get; set; }

        public virtual Author Author { get; set; } = null!;
        public virtual ICollection<CourseSection> CourseSections { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }
    }
}
