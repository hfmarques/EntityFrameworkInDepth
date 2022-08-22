using Microsoft.EntityFrameworkCore;
using PatternsApi.Data.EntityConfigurations;
using PatternsApi.Models;

namespace PatternsApi.Data
{
    public class PlutoContext : DbContext
    {
        private readonly string connectionString;

        public PlutoContext(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("Pluto");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

#nullable disable
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<Cover> Covers { get; set; }
#nullable enable

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CourseConfiguration());

            var tags = new Dictionary<string, Tag>
            {
                {"c#", new Tag {Id = 1, Name = "c#"}},
                {"angularjs", new Tag {Id = 2, Name = "angularjs"}},
                {"javascript", new Tag {Id = 3, Name = "javascript"}},
                {"nodejs", new Tag {Id = 4, Name = "nodejs"}},
                {"oop", new Tag {Id = 5, Name = "oop"}},
                {"linq", new Tag {Id = 6, Name = "linq"}},
            };

            modelBuilder.Entity<Tag>().HasData(tags.Values);

            var authors = new List<Author>
            {
                new()
                {
                    Id = 1,
                    Name = "Mosh Hamedani"
                },
                new()
                {
                    Id = 2,
                    Name = "Anthony Alicea"
                },
                new()
                {
                    Id = 3,
                    Name = "Eric Wise"
                },
                new()
                {
                    Id = 4,
                    Name = "Tom Owsiak"
                },
                new()
                {
                    Id = 5,
                    Name = "John Smith"
                }
            };

            modelBuilder.Entity<Author>().HasData(authors);

            var courses = new List<Course>
            {
                new()
                {
                    Id = 1,
                    Name = "C# Basics",
                    FullPrice = 49,
                    Description = "Description for C# Basics",
                    Level = 1,
                    AuthorId = 1,
                },
                new()
                {
                    Id = 2,
                    Name = "C# Intermediate",
                    AuthorId = 1,
                    FullPrice = 49,
                    Description = "Description for C# Intermediate",
                    Level = 2,
                },
                new()
                {
                    Id = 3,
                    Name = "C# Advanced",
                    AuthorId = 1,
                    FullPrice = 69,
                    Description = "Description for C# Advanced",
                    Level = 3,
                },
                new()
                {
                    Id = 4,
                    Name = "Javascript: Understanding the Weird Parts",
                    AuthorId = 2,
                    FullPrice = 149,
                    Description = "Description for Javascript",
                    Level = 2,
                },
                new()
                {
                    Id = 5,
                    Name = "Learn and Understand AngularJS",
                    AuthorId = 2,
                    FullPrice = 99,
                    Description = "Description for AngularJS",
                    Level = 2,
                },
                new()
                {
                    Id = 6,
                    Name = "Learn and Understand NodeJS",
                    AuthorId = 2,
                    FullPrice = 149,
                    Description = "Description for NodeJS",
                    Level = 2,
                },
                new()
                {
                    Id = 7,
                    Name = "Programming for Complete Beginners",
                    AuthorId = 3,
                    FullPrice = 45,
                    Description = "Description for Programming for Beginners",
                    Level = 1,
                },
                new()
                {
                    Id = 8,
                    Name = "A 16 Hour C# Course with Visual Studio 2013",
                    AuthorId = 4,
                    FullPrice = 150,
                    Description = "Description 16 Hour Course",
                    Level = 1,
                },
                new()
                {
                    Id = 9,
                    Name = "Learn JavaScript Through Visual Studio 2013",
                    AuthorId = 4,
                    FullPrice = 20,
                    Description = "Description Learn Javascript",
                    Level = 1,
                }
            };

            modelBuilder.Entity<Course>().HasData(courses);

            modelBuilder.Entity("CourseTags").HasData(
                new {CourseId = 1, TagId = 1},
                new {CourseId = 2, TagId = 1},
                new {CourseId = 2, TagId = 5},
                new {CourseId = 3, TagId = 1},
                new {CourseId = 4, TagId = 3},
                new {CourseId = 5, TagId = 2},
                new {CourseId = 6, TagId = 4},
                new {CourseId = 7, TagId = 1},
                new {CourseId = 8, TagId = 1},
                new {CourseId = 9, TagId = 3});

            base.OnModelCreating(modelBuilder);
        }
    }
}