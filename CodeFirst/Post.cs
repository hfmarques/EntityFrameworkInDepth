using System;
using System.Collections.Generic;

namespace CodeFirst
{
    public partial class Post
    {
        public int PostId { get; set; }
        public DateTime DatePublished { get; set; }
        public string Title { get; set; } = null!;
        public string Body { get; set; } = null!;
    }
}
