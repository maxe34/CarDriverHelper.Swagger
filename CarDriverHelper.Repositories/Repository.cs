using System.Linq.Expressions;
using CarDriverHelper.Repositories.Entities;

namespace CarDriverHelper.Repositories;

public class Repository<T> : IRepository<T> where T : BaseEntity
{
    private readonly AppDbContext _context;

    public Repository(AppDbContext context)
    {
        _context = context;
    }

    public IQueryable<T> GetData()
    {
        return _context.Set<T>().AsQueryable();
    }

    public T? Get(Guid? id)
    {
        return _context.Set<T>().FirstOrDefault(c=>c.Id == id);
    }

    public IQueryable<T> GetAll()
    {
        return _context.Set<T>().AsQueryable();
    }

    public IQueryable<T> Find(Expression<Func<T, bool>> predicate)
    {
        return _context.Set<T>().Where(predicate);
    }

    public void Add(T entity)
    {
        _context.Set<T>().Add(entity);
        SaveChanges();
    }

    public void AddRange(IQueryable<T> entities)
    {
        _context.Set<T>().AddRange(entities);
        SaveChanges();
    }

    public void Remove(T entity)
    {
        _context.Set<T>().Remove(entity);
        SaveChanges();
    }

    public void RemoveRange(IQueryable<T> entities)
    {
        _context.Set<T>().RemoveRange(entities);
        SaveChanges();
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}