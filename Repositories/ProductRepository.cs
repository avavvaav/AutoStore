using Microsoft.EntityFrameworkCore;
using AutoStore.Data;
using AutoStore.Models;

namespace AutoStore.Repositories;

// Расширенный репозиторий автозапчастей с подгрузкой связанных данных
public interface IProductRepository : IRepository<Product>
{
    Task<IEnumerable<Product>> GetAllWithCategoryAsync();
    Task<Product?> GetByIdWithDetailsAsync(int id);
    Task<IEnumerable<Product>> GetByCategoryAsync(int categoryId);
}

public class ProductRepository : Repository<Product>, IProductRepository
{
    public ProductRepository(StoreContext context) : base(context) { }

    // Список запчастей с категориями (без отслеживания — read-only сценарий)
    public async Task<IEnumerable<Product>> GetAllWithCategoryAsync()
        => await _db.Products.Include(p => p.Category).AsNoTracking().ToListAsync();

    // Одна запчасть со всеми связанными сущностями
    public async Task<Product?> GetByIdWithDetailsAsync(int id)
        => await _db.Products
            .Include(p => p.Category)
            .Include(p => p.Details)
            .FirstOrDefaultAsync(p => p.Id == id);

    // Фильтрация по категории
    public async Task<IEnumerable<Product>> GetByCategoryAsync(int categoryId)
        => await _db.Products
            .Include(p => p.Category)
            .Where(p => p.CategoryId == categoryId)
            .AsNoTracking()
            .ToListAsync();
}
