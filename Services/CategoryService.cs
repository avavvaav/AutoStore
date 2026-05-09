using AutoStore.Models;
using AutoStore.Repositories;

namespace AutoStore.Services;

// Бизнес-сервис для работы с категориями запчастей
public interface ICategoryService
{
    Task<IEnumerable<Category>> GetAllAsync();
    Task<Category?> GetByIdAsync(int id);
    Task CreateAsync(Category category);
    Task UpdateAsync(Category category);
    Task DeleteAsync(int id);
}

public class CategoryService : ICategoryService
{
    private readonly IRepository<Category> _catalogRepo;

    public CategoryService(IRepository<Category> repo) => _catalogRepo = repo;

    public Task<IEnumerable<Category>> GetAllAsync() => _catalogRepo.GetAllAsync();
    public Task<Category?> GetByIdAsync(int id) => _catalogRepo.GetByIdAsync(id);

    public async Task CreateAsync(Category category)
    {
        await _catalogRepo.AddAsync(category);
        await _catalogRepo.SaveChangesAsync();
    }

    public async Task UpdateAsync(Category category)
    {
        _catalogRepo.Update(category);
        await _catalogRepo.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var category = await _catalogRepo.GetByIdAsync(id);
        if (category is null) return;
        _catalogRepo.Remove(category);
        await _catalogRepo.SaveChangesAsync();
    }
}
