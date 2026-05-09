using Microsoft.EntityFrameworkCore;
using AutoStore.Data;
using AutoStore.Models;

namespace AutoStore.Services;

// Бизнес-сервис корзины покупателя
public interface ICartService
{
    Task<IEnumerable<CartItem>> GetCartAsync(int customerId);
    Task AddToCartAsync(int customerId, int productId, int quantity = 1);
    Task UpdateQuantityAsync(int cartItemId, int quantity);
    Task RemoveFromCartAsync(int cartItemId);
    Task ClearCartAsync(int customerId);
    Task<decimal> GetTotalAsync(int customerId);
}

public class CartService : ICartService
{
    private readonly StoreContext _db;

    public CartService(StoreContext context) => _db = context;

    // Содержимое корзины с подгрузкой запчастей
    public async Task<IEnumerable<CartItem>> GetCartAsync(int customerId)
        => await _db.CartItems
            .Include(ci => ci.Product)
            .Where(ci => ci.CustomerId == customerId)
            .ToListAsync();

    // Если запчасть уже в корзине — увеличиваем количество, иначе добавляем
    public async Task AddToCartAsync(int customerId, int productId, int quantity = 1)
    {
        var existing = await _db.CartItems
            .FirstOrDefaultAsync(ci => ci.CustomerId == customerId && ci.ProductId == productId);

        if (existing != null)
        {
            existing.Quantity += quantity;
        }
        else
        {
            await _db.CartItems.AddAsync(new CartItem
            {
                CustomerId = customerId,
                ProductId = productId,
                Quantity = quantity
            });
        }
        await _db.SaveChangesAsync();
    }

    // Количество <= 0 удаляет позицию из корзины
    public async Task UpdateQuantityAsync(int cartItemId, int quantity)
    {
        var item = await _db.CartItems.FindAsync(cartItemId);
        if (item is null) return;

        if (quantity <= 0)
            _db.CartItems.Remove(item);
        else
            item.Quantity = quantity;

        await _db.SaveChangesAsync();
    }

    public async Task RemoveFromCartAsync(int cartItemId)
    {
        var item = await _db.CartItems.FindAsync(cartItemId);
        if (item is null) return;
        _db.CartItems.Remove(item);
        await _db.SaveChangesAsync();
    }

    public async Task ClearCartAsync(int customerId)
    {
        var items = _db.CartItems.Where(ci => ci.CustomerId == customerId);
        _db.CartItems.RemoveRange(items);
        await _db.SaveChangesAsync();
    }

    // Общая стоимость корзины
    public async Task<decimal> GetTotalAsync(int customerId)
        => await _db.CartItems
            .Where(ci => ci.CustomerId == customerId)
            .SumAsync(ci => ci.Quantity * ci.Product.Price);
}
