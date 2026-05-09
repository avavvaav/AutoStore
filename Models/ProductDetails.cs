namespace AutoStore.Models;

// Подробные технические характеристики запчасти (связь 1:1 с Product)
public class ProductDetails
{
    public int Id { get; set; }
    public string? Manufacturer { get; set; }
    public string? CountryOfOrigin { get; set; }
    public double? Weight { get; set; }
    public string? Dimensions { get; set; }
    public int WarrantyMonths { get; set; }

    // Внешний ключ и навигация на запчасть
    public int ProductId { get; set; }
    public Product Product { get; set; } = null!;
}
