using Microsoft.EntityFrameworkCore;
using AutoStore.Data;
using AutoStore.Models;
using AutoStore.Repositories;

namespace AutoStore.Services;

// Бизнес-сервис заказов автозапчастей
public interface IOrderService
{
    Task<IEnumerable<Order>> GetAllAsync();
    Task<Order?> GetByIdAsync(int id);
    Task<IEnumerable<Order>> GetByCustomerAsync(int customerId);
    Task<Order> CreateFromCartAsync(int customerId, string shippingAddress);
    Task UpdateStatusAsync(int orderId, OrderStatus status);
}

public class OrderService : IOrderService
{
    private readonly IOrderRepository _ordersRepo;
    private readonly ICartService _cartService;
    private readonly StoreContext _db;

    public OrderService(IOrderRepository repo, ICartService cart, StoreContext context)
    {
        _ordersRepo = repo;
        _cartService = cart;
        _db = context;
    }

    public Task<IEnumerable<Order>> GetAllAsync() => _ordersRepo.GetAllWithDetailsAsync();
    public Task<Order?> GetByIdAsync(int id) => _ordersRepo.GetByIdWithDetailsAsync(id);
    public Task<IEnumerable<Order>> GetByCustomerAsync(int customerId) => _ordersRepo.GetByCustomerAsync(customerId);

    // Создаёт заказ из корзины: списывает запчасти, считает сумму, очищает корзину
    public async Task<Order> CreateFromCartAsync(int customerId, string shippingAddress)
    {
        var cartItems = (await _cartService.GetCartAsync(customerId)).ToList();
        if (!cartItems.Any())
            throw new InvalidOperationException("Корзина пуста");

        // Цены фиксируем на момент покупки
        var order = new Order
        {
            CustomerId = customerId,
            ShippingAddress = shippingAddress,
            Status = OrderStatus.Pending,
            CreatedAt = DateTime.UtcNow,
            OrderItems = cartItems.Select(ci => new OrderItem
            {
                ProductId = ci.ProductId,
                Quantity = ci.Quantity,
                UnitPrice = ci.Product.Price
            }).ToList()
        };

        order.TotalAmount = order.OrderItems.Sum(oi => oi.Quantity * oi.UnitPrice);

        // Списание со склада с проверкой остатков
        foreach (var ci in cartItems)
        {
            var part = await _db.Products.FindAsync(ci.ProductId);
            if (part != null)
            {
                if (part.Stock < ci.Quantity)
                    throw new InvalidOperationException($"Недостаточно запчасти '{part.Name}' на складе");
                part.Stock -= ci.Quantity;
            }
        }

        await _ordersRepo.AddAsync(order);
        await _ordersRepo.SaveChangesAsync();

        // После успешной покупки очищаем корзину
        await _cartService.ClearCartAsync(customerId);
        return order;
    }

    public async Task UpdateStatusAsync(int orderId, OrderStatus status)
    {
        var order = await _db.Orders.FindAsync(orderId);
        if (order is null) return;
        order.Status = status;
        await _db.SaveChangesAsync();
    }
}
