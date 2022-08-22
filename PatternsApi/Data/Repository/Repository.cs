using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace PatternsApi.Data.Repository;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    protected readonly DbContext Context;

    protected Repository(DbContext context)
    {
        Context = context;
    }

    public TEntity? Get(int id)
    {
        return Context.Set<TEntity>().Find(id);
    }

    public IEnumerable<TEntity> GetAll()
    {
        return Context.Set<TEntity>().ToList();
    }

    public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
    {
        return Context.Set<TEntity>().Where(predicate);
    }

    public void Add(TEntity entity)
    {
        Context.Add(entity);
    }

    public void AddRange(IEnumerable<TEntity> entities)
    {
        Context.AddRange(entities);
    }

    public void Remove(TEntity entity)
    {
        Context.Remove(entity);
    }

    public void RemoveRange(IEnumerable<TEntity> entities)
    {
        Context.RemoveRange(entities);
    }
}