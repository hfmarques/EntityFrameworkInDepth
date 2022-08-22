using Microsoft.EntityFrameworkCore;
using PatternsApi.Models;

namespace PatternsApi.Data.Repository;

public class AuthorRepository : Repository<Author>, IAuthorRepository
{
    private PlutoContext PlutoContext => (Context as PlutoContext)!;

    public AuthorRepository(DbContext context) : base(context)
    {
    }
}