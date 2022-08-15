using System;
using System.Collections.Generic;

namespace CodeFirst
{
    public partial class Tag
    {
        public Tag()
        {
            Courses = new HashSet<Course>();
        }

        public int TagId { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Course> Courses { get; set; }
    }
}
