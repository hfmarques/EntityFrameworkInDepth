using CodeFirst.Model;
using Microsoft.EntityFrameworkCore;

namespace CodeFirst;

public class PlutoContext : DbContext
{
#nullable disable
    private readonly string connectionString;
    public DbSet<Course> Courses { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Tag> Tags { get; set; }
#nullable enable

    public PlutoContext()
    {
    }

    public PlutoContext(string connectionString)
    {
        this.connectionString = connectionString;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}