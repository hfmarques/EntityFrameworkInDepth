namespace Queries.Models
{
    public class Course
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Level { get; set; }

        public float FullPrice { get; set; }
        public int AuthorId { get; set; }

        public virtual Author Author { get; set; }

        public virtual Cover Cover { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
    }
}