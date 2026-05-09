using AutoStore.Models;
using AutoStore.Repositories;

namespace AutoStore.Services;

// Бизнес-сервис для работы с автозапчастями
public interface IProductService
{
    Task<IEnumerable<Product>> GetAllAsync();
    Task<Product?> GetByIdAsync(int id);
    Task<IEnumerable<Product>> GetByCategoryAsync(int categoryId);
    Task CreateAsync(Product product);
    Task UpdateAsync(Product product);
    Task DeleteAsync(int id);
}

public class ProductService : IProductService
{
    private readonly IProductRepository _partsRepo;

    public ProductService(IProductRepository repo) => _partsRepo = repo;

    public Task<IEnumerable<Product>> GetAllAsync() => _partsRepo.GetAllWithCategoryAsync();
    public Task<Product?> GetByIdAsync(int id) => _partsRepo.GetByIdWithDetailsAsync(id);
    public Task<IEnumerable<Product>> GetByCategoryAsync(int categoryId) => _partsRepo.GetByCategoryAsync(categoryId);

    public async Task CreateAsync(Product product)
    {
        await _partsRepo.AddAsync(product);
        await _partsRepo.SaveChangesAsync();
    }

    public async Task UpdateAsync(Product product)
    {
        _partsRepo.Update(product);
        await _partsRepo.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var part = await _partsRepo.GetByIdAsync(id);
        if (part is null) return;
        _partsRepo.Remove(part);
        await _partsRepo.SaveChangesAsync();
    }
}
