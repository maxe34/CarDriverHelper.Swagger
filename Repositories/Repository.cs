using System.Linq.Expressions;

namespace Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    private readonly AppDbContext _context;

    public Repository(AppDbContext context)
    {
        _context = context;
    }

    public IQueryable<TEntity> GetData()
    {
        return _context.Set<TEntity>().AsQueryable();
    }

    public TEntity Get(int id)
    {
        return _context.Set<TEntity>().Find(id);
    }

    public IQueryable<TEntity> GetAll()
    {
        return _context.Set<TEntity>().AsQueryable();
    }

    public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
    {
        return _context.Set<TEntity>().Where(predicate);
    }

    public void Add(TEntity entity)
    {
        _context.Set<TEntity>().Add(entity);
        SaveChanges();
    }

    public void AddRange(IQueryable<TEntity> entities)
    {
        _context.Set<TEntity>().AddRange(entities);
        SaveChanges();
    }

    public void Remove(TEntity entity)
    {
        _context.Set<TEntity>().Remove(entity);
        SaveChanges();
    }

    public void RemoveRange(IQueryable<TEntity> entities)
    {
        _context.Set<TEntity>().RemoveRange(entities);
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