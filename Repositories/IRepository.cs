using System.Linq.Expressions;

namespace Repositories;

public interface IRepository<TEntity> : IDisposable where TEntity : class
{
    IQueryable<TEntity> GetData();

    TEntity Get(int id);
    IQueryable<TEntity> GetAll();
    IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

    void Add(TEntity entity);
    void AddRange(IQueryable<TEntity> entities);

    void Remove(TEntity entity);
    void RemoveRange(IQueryable<TEntity> entities);

    void SaveChanges();
}