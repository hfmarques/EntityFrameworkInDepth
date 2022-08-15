using System;
using System.Collections.Generic;

namespace DbFirst
{
    public partial class Author
    {
        public Author()
        {
            Courses = new HashSet<Course>();
        }

        public int AuthorId { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Course> Courses { get; set; }
    }
}
