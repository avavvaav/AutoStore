using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using AutoStore.Data;

namespace AutoStore.Repositories;

// Базовая реализация универсального репозитория поверх EF Core
public class Repository<T> : IRepository<T> where T : class
{
    protected readonly StoreContext _db;
    protected readonly DbSet<T> _set;

    public Repository(StoreContext context)
    {
        _db = context;
        _set = context.Set<T>();
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync() => await _set.ToListAsync();

    public virtual async Task<T?> GetByIdAsync(int id) => await _set.FindAsync(id);

    // Поиск по произвольному условию
    public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        => await _set.Where(predicate).ToListAsync();

    public async Task AddAsync(T entity) => await _set.AddAsync(entity);
    public void Update(T entity) => _set.Update(entity);
    public void Remove(T entity) => _set.Remove(entity);

    public async Task<int> SaveChangesAsync() => await _db.SaveChangesAsync();
}
