namespace CodeFirst.Model
{
#nullable disable
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public IList<Course> Courses { get; set; }
    }
}