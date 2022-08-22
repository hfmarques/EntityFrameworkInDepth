// See https://aka.ms/new-console-template for more information

using Microsoft.EntityFrameworkCore;
using Queries;

using var context = new PlutoContext();

var query =
    from c in context.Courses
    where c.Name.Contains("c#")
    orderby c.Name
    select c;

foreach (var course in query)
{
    Console.WriteLine(course.Name);
}

Console.WriteLine();

var courses = context.Courses
    .Where(x => x.Name.Contains("c#"))
    .OrderBy(x => x.Name);

foreach (var course in courses)
{
    Console.WriteLine(course.Name);
}

Console.WriteLine();

var query2 =
    from c in context.Courses
    join a in context.Authors on c.AuthorId equals a.Id
    select new {CourseName = c.Name, AuthorName = a.Name};

foreach (var course in query2)
{
    Console.WriteLine($"{course.CourseName} - {course.AuthorName}");
}

Console.WriteLine();

var query3 =
    from a in context.Authors
    from c in context.Courses
    select new {CourseName = c.Name, AuthorName = a.Name};

foreach (var course in query3)
{
    Console.WriteLine($"{course.CourseName} - {course.AuthorName}");
}

Console.WriteLine();

var query4 = 
    context.Courses
    .Join(context.Authors,
        c => c.AuthorId,
        a => a.Id,
        (c, a) => new
        {
            CourseName = c.Name,
            AuthorName = a.Name
        });

foreach (var course in query4)
{
    Console.WriteLine($"{course.CourseName} - {course.AuthorName}");
}

Console.WriteLine();

var query5 = 
    context.Authors
        .SelectMany(x => x.Courses,
            (c, a) => new
            {
                CourseName = c.Name,
                AuthorName = a.Name
            });

foreach (var course in query5)
{
    Console.WriteLine($"{course.CourseName} - {course.AuthorName}");
}

Console.WriteLine();

var query6 = context.Courses.Include(x => x.Author);

foreach (var course in query6)
{
    Console.WriteLine($"{course.Name} - {course.Author.Name}");
}

Console.WriteLine();



Console.ReadLine();