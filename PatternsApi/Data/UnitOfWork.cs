using Microsoft.EntityFrameworkCore;
using PatternsApi.Data.Repository;

namespace PatternsApi.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly DbContext context;

    public UnitOfWork(DbContext context)
    {
        this.context = context;
        Courses = new CourseRepository(context);
        Authors = new AuthorRepository(context);
    }

    public void Dispose()
    {
        context.Dispose();
    }

    public ICourseRepository Courses { get; }
    public IAuthorRepository Authors { get; }

    public int SaveChanges()
    {
        return context.SaveChanges();
    }
}