using Microsoft.EntityFrameworkCore;
using AutoStore.Models;

namespace AutoStore.Data;

// Начальные данные для базы автомагазина (применяются миграцией)
public static class DbSeeder
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        // Категории автозапчастей
        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Двигатель и трансмиссия", Description = "Детали двигателя, КПП, сцепление" },
            new Category { Id = 2, Name = "Тормозная система", Description = "Колодки, диски, суппорты, шланги" },
            new Category { Id = 3, Name = "Фильтры и масла", Description = "Масляные, воздушные, топливные фильтры и масла" },
            new Category { Id = 4, Name = "Электрика и освещение", Description = "Свечи, фары, генераторы, стартеры" },
            new Category { Id = 5, Name = "Подвеска и рулевое", Description = "Амортизаторы, рычаги, рулевые тяги, ШРУС" }
        );

        // Автозапчасти; картинки — заглушки с placehold.co
        modelBuilder.Entity<Product>().HasData(
            new Product { Id = 1, Name = "Масляный фильтр Bosch 0451103079", Description = "Фильтр масляный для Volkswagen, Audi, Skoda. Надёжная защита двигателя.", Price = 650m, Stock = 85, CategoryId = 3, ImageUrl = "https://placehold.co/300x300/1a1a1a/ffffff?text=Oil+Filter", CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
            new Product { Id = 2, Name = "Тормозные колодки Brembo P85020", Description = "Передние тормозные колодки для BMW 3/5 серии. Высокоэффективный состав.", Price = 3200m, Stock = 42, CategoryId = 2, ImageUrl = "https://placehold.co/300x300/c62828/ffffff?text=Brake+Pads", CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
            new Product { Id = 3, Name = "Моторное масло Shell Helix Ultra 5W-40 4л", Description = "Синтетическое моторное масло для бензиновых и дизельных двигателей.", Price = 4800m, Stock = 120, CategoryId = 3, ImageUrl = "https://placehold.co/300x300/ff8f00/ffffff?text=Engine+Oil", CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
            new Product { Id = 4, Name = "Свечи зажигания NGK BKR6EK (комплект 4 шт.)", Description = "Иридиевые свечи зажигания. Улучшенный запуск, стабильная работа двигателя.", Price = 1890m, Stock = 68, CategoryId = 4, ImageUrl = "https://placehold.co/300x300/212121/ffffff?text=Spark+Plugs", CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
            new Product { Id = 5, Name = "Амортизатор передний Sachs 312 456", Description = "Газомасляный амортизатор передней подвески для Opel Astra/Zafira.", Price = 5600m, Stock = 25, CategoryId = 5, ImageUrl = "https://placehold.co/300x300/424242/ffffff?text=Shock+Absorber", CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
            new Product { Id = 6, Name = "Тормозной диск Ferodo DDF1325", Description = "Вентилируемый тормозной диск. Диаметр 300 мм, для Toyota Camry/Lexus ES.", Price = 4100m, Stock = 33, CategoryId = 2, ImageUrl = "https://placehold.co/300x300/b71c1c/ffffff?text=Brake+Disc", CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
            new Product { Id = 7, Name = "Воздушный фильтр Mann C25114", Description = "Фильтр воздушный для Mercedes-Benz C/E-Class. Ресурс 30 000 км.", Price = 980m, Stock = 55, CategoryId = 3, ImageUrl = "https://placehold.co/300x300/333333/ffffff?text=Air+Filter", CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
            new Product { Id = 8, Name = "Рулевая тяга Lemförder 25892 01", Description = "Наружный наконечник рулевой тяги для Ford Focus II/III, C-Max.", Price = 1450m, Stock = 40, CategoryId = 5, ImageUrl = "https://placehold.co/300x300/555555/ffffff?text=Tie+Rod", CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc) }
        );

        // Технические характеристики запчастей
        modelBuilder.Entity<ProductDetails>().HasData(
            new ProductDetails { Id = 1, ProductId = 1, Manufacturer = "Bosch", CountryOfOrigin = "Германия", Weight = 0.18, Dimensions = "Ø76 × 80 мм", WarrantyMonths = 12 },
            new ProductDetails { Id = 2, ProductId = 2, Manufacturer = "Brembo", CountryOfOrigin = "Италия", Weight = 0.62, Dimensions = "155 × 65 × 18 мм", WarrantyMonths = 24 },
            new ProductDetails { Id = 3, ProductId = 3, Manufacturer = "Shell", CountryOfOrigin = "Нидерланды", Weight = 3.6, Dimensions = "канистра 4 л", WarrantyMonths = 0 },
            new ProductDetails { Id = 4, ProductId = 4, Manufacturer = "NGK", CountryOfOrigin = "Япония", Weight = 0.12, Dimensions = "M14 × 1.25, L=26.5 мм", WarrantyMonths = 18 },
            new ProductDetails { Id = 5, ProductId = 5, Manufacturer = "Sachs", CountryOfOrigin = "Германия", Weight = 2.4, Dimensions = "L=430 мм, Ø55 мм", WarrantyMonths = 24 },
            new ProductDetails { Id = 6, ProductId = 6, Manufacturer = "Ferodo", CountryOfOrigin = "Великобритания", Weight = 4.8, Dimensions = "Ø300 × 28 мм", WarrantyMonths = 24 }
        );

        // Тестовый покупатель
        modelBuilder.Entity<Customer>().HasData(
            new Customer { Id = 1, FullName = "Алексей Смирнов", Email = "alexey@example.com", Phone = "+7-999-123-45-67", Address = "Москва, Автомоторная ул., 12", RegisteredAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc) }
        );
    }
}
