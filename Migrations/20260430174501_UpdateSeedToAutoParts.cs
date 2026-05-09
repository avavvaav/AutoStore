using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AutoStore.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeedToAutoParts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Детали двигателя, КПП, сцепление", "Двигатель и трансмиссия" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Колодки, диски, суппорты, шланги", "Тормозная система" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Масляные, воздушные, топливные фильтры и масла", "Фильтры и масла" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 4, "Свечи, фары, генераторы, стартеры", "Электрика и освещение" },
                    { 5, "Амортизаторы, рычаги, рулевые тяги, ШРУС", "Подвеска и рулевое" }
                });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Address", "Email", "FullName", "Phone" },
                values: new object[] { "Москва, Автомоторная ул., 12", "alexey@example.com", "Алексей Смирнов", "+7-999-123-45-67" });

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CountryOfOrigin", "Dimensions", "Manufacturer", "WarrantyMonths", "Weight" },
                values: new object[] { "Германия", "Ø76 × 80 мм", "Bosch", 12, 0.17999999999999999 });

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CountryOfOrigin", "Dimensions", "Manufacturer", "WarrantyMonths", "Weight" },
                values: new object[] { "Италия", "155 × 65 × 18 мм", "Brembo", 24, 0.62 });

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CountryOfOrigin", "Dimensions", "Manufacturer", "ProductId", "Weight" },
                values: new object[] { "Нидерланды", "канистра 4 л", "Shell", 3, 3.6000000000000001 });

            migrationBuilder.InsertData(
                table: "ProductDetails",
                columns: new[] { "Id", "CountryOfOrigin", "Dimensions", "Manufacturer", "ProductId", "WarrantyMonths", "Weight" },
                values: new object[,]
                {
                    { 4, "Япония", "M14 × 1.25, L=26.5 мм", "NGK", 4, 18, 0.12 },
                    { 5, "Германия", "L=430 мм, Ø55 мм", "Sachs", 5, 24, 2.3999999999999999 }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name", "Price", "Stock" },
                values: new object[] { 3, "Фильтр масляный для Volkswagen, Audi, Skoda. Надёжная защита двигателя.", "https://placehold.co/300x300/1a1a1a/ffffff?text=Oil+Filter", "Масляный фильтр Bosch 0451103079", 650m, 85 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name", "Price", "Stock" },
                values: new object[] { 2, "Передние тормозные колодки для BMW 3/5 серии. Высокоэффективный состав.", "https://placehold.co/300x300/c62828/ffffff?text=Brake+Pads", "Тормозные колодки Brembo P85020", 3200m, 42 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { 3, "Синтетическое моторное масло для бензиновых и дизельных двигателей.", "https://placehold.co/300x300/ff8f00/ffffff?text=Engine+Oil", "Моторное масло Shell Helix Ultra 5W-40 4л", 4800m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name", "Price", "Stock" },
                values: new object[] { 4, "Иридиевые свечи зажигания. Улучшенный запуск, стабильная работа двигателя.", "https://placehold.co/300x300/212121/ffffff?text=Spark+Plugs", "Свечи зажигания NGK BKR6EK (комплект 4 шт.)", 1890m, 68 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name", "Price", "Stock" },
                values: new object[] { 5, "Газомасляный амортизатор передней подвески для Opel Astra/Zafira.", "https://placehold.co/300x300/424242/ffffff?text=Shock+Absorber", "Амортизатор передний Sachs 312 456", 5600m, 25 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "Description", "ImageUrl", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { 6, 2, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Вентилируемый тормозной диск. Диаметр 300 мм, для Toyota Camry/Lexus ES.", "https://placehold.co/300x300/b71c1c/ffffff?text=Brake+Disc", "Тормозной диск Ferodo DDF1325", 4100m, 33 },
                    { 7, 3, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Фильтр воздушный для Mercedes-Benz C/E-Class. Ресурс 30 000 км.", "https://placehold.co/300x300/333333/ffffff?text=Air+Filter", "Воздушный фильтр Mann C25114", 980m, 55 }
                });

            migrationBuilder.InsertData(
                table: "ProductDetails",
                columns: new[] { "Id", "CountryOfOrigin", "Dimensions", "Manufacturer", "ProductId", "WarrantyMonths", "Weight" },
                values: new object[] { 6, "Великобритания", "Ø300 × 28 мм", "Ferodo", 6, 24, 4.7999999999999998 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "Description", "ImageUrl", "Name", "Price", "Stock" },
                values: new object[] { 8, 5, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Наружный наконечник рулевой тяги для Ford Focus II/III, C-Max.", "https://placehold.co/300x300/555555/ffffff?text=Tie+Rod", "Рулевая тяга Lemförder 25892 01", 1450m, 40 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Смартфоны, ноутбуки и аксессуары", "Электроника" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Мужская и женская одежда", "Одежда" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Художественная и техническая литература", "Книги" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Address", "Email", "FullName", "Phone" },
                values: new object[] { "Москва, ул. Ленина, 1", "ivan@example.com", "Иван Иванов", "+7-999-000-00-01" });

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CountryOfOrigin", "Dimensions", "Manufacturer", "WarrantyMonths", "Weight" },
                values: new object[] { "Южная Корея", "147x70.6x7.6 мм", "Samsung", 24, 0.19600000000000001 });

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CountryOfOrigin", "Dimensions", "Manufacturer", "WarrantyMonths", "Weight" },
                values: new object[] { "Китай", "315x222x14.9 мм", "Lenovo", 36, 1.1200000000000001 });

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CountryOfOrigin", "Dimensions", "Manufacturer", "ProductId", "Weight" },
                values: new object[] { "США", "23x18x3 см", "Manning", 5, 0.80000000000000004 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name", "Price", "Stock" },
                values: new object[] { 1, "Флагманский смартфон Samsung", "https://placehold.co/300x300/0d6efd/ffffff?text=Galaxy+S24", "Смартфон Galaxy S24", 89990m, 15 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name", "Price", "Stock" },
                values: new object[] { 1, "Бизнес-ноутбук Lenovo", "https://placehold.co/300x300/212529/ffffff?text=ThinkPad+X1", "Ноутбук ThinkPad X1", 145000m, 7 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { 2, "100% хлопок", "https://placehold.co/300x300/6c757d/ffffff?text=T-Shirt", "Футболка базовая", 1290m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name", "Price", "Stock" },
                values: new object[] { 2, "Прямой крой, синий цвет", "https://placehold.co/300x300/1e3a8a/ffffff?text=Jeans", "Джинсы классические", 3990m, 45 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name", "Price", "Stock" },
                values: new object[] { 3, "Книга Джона Скита", "https://placehold.co/300x300/198754/ffffff?text=C%23+Book", "C# in Depth", 2490m, 30 });
        }
    }
}
