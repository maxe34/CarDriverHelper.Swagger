using System.Linq.Expressions;
using CarDriverHelper.Repositories.Entities;

namespace CarDriverHelper.Repositories;

public interface IRepository<T> : IDisposable where T : BaseEntity
{
    IQueryable<T> GetData();

    T? Get(Guid? id);
    IQueryable<T> GetAll();
    IQueryable<T> Find(Expression<Func<T, bool>> predicate);

    void Add(T entity);
    void AddRange(IQueryable<T> entities);

    void Remove(T entity);
    void RemoveRange(IQueryable<T> entities);

    void SaveChanges();
}