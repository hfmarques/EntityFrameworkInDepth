using PatternsApi.Data.Repository;

namespace PatternsApi.Data;

public interface IUnitOfWork : IDisposable
{
    ICourseRepository Courses { get; }
    IAuthorRepository Authors { get; }

    int SaveChanges();
}