using System.Linq.Expressions;

namespace AmbienceScoring.Repository.IRepository;

public interface IRepository<T> where T : class
{
    Task<IEnumerable<T>?> GetAll(string? includeProperties = null);
    Task<T?> GetById(Guid id);
    Task<T?> Get(Expression<Func<T, bool>> predicate, string? includeProperties = null);
    Task Add(T entity);
    void Delete(T entity);
}