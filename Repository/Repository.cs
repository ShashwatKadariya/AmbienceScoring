using System.Linq.Expressions;
using AmbienceScoring.Data;
using AmbienceScoring.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace AmbienceScoring.Repository;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly ApplicationDbContext _db;
    internal DbSet<T> dbSet;

    public Repository(ApplicationDbContext db)
    {
        _db = db;
        this.dbSet = _db.Set<T>();
    }
    
    
    public async Task<IEnumerable<T>?> GetAll(string? includeProperties = null)
    {
        IQueryable<T> query = dbSet.AsNoTracking();
        if (!string.IsNullOrEmpty(includeProperties))
        {
            foreach (var includeProperty in includeProperties.Split(',', StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
            
        }
        return await query.ToListAsync();
    }

    public async Task<T?> GetById(Guid id)
    {
        return await dbSet.FindAsync(id);
    }

    public async Task<T?> Get(Expression<Func<T, bool>> predicate, string? includeProperties = null)
    {
        IQueryable<T> query = dbSet;
        query.AsNoTracking();
        query = query.Where(predicate);

        if (!string.IsNullOrEmpty(includeProperties))
        {
            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
        }
        return await query.FirstOrDefaultAsync();
    }

    public async Task Add(T entity)
    {
        await dbSet.AddAsync(entity);
    }

    public void Delete(T entity)
    {
        dbSet.Remove(entity);
    }
}