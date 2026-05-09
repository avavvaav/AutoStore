namespace AutoStore.Models;

// Запчасть в корзине покупателя
public class CartItem
{
    public int Id { get; set; }
    public int Quantity { get; set; }
    public DateTime AddedAt { get; set; } = DateTime.UtcNow;

    // Внешний ключ на покупателя
    public int CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;

    // Внешний ключ на запчасть
    public int ProductId { get; set; }
    public Product Product { get; set; } = null!;
}
