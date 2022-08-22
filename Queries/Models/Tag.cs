namespace Queries.Models
{
    public class Tag
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual IQueryable<Course> Courses { get; set; }
    }
}