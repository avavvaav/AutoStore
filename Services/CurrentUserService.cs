using Microsoft.EntityFrameworkCore;
using AutoStore.Data;
using AutoStore.Models;

namespace AutoStore.Services;

// Упрощённый сервис текущего пользователя (без авторизации, для демо)
public interface ICurrentUserService
{
    Task<Customer> GetOrCreateDemoCustomerAsync();
}

public class CurrentUserService : ICurrentUserService
{
    private readonly StoreContext _db;

    // Email гостевого покупателя демо-режима
    private const string GuestUserEmail = "guest@automarket.local";

    public CurrentUserService(StoreContext context) => _db = context;

    // Возвращает существующего гостевого покупателя или создаёт нового
    public async Task<Customer> GetOrCreateDemoCustomerAsync()
    {
        var buyer = await _db.Customers.FirstOrDefaultAsync(c => c.Email == GuestUserEmail);

        if (buyer == null)
        {
            buyer = new Customer
            {
                FullName = "Гость",
                Email = GuestUserEmail,
                RegisteredAt = DateTime.UtcNow
            };
            _db.Customers.Add(buyer);
            await _db.SaveChangesAsync();
        }
        return buyer;
    }
}
