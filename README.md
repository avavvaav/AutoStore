# AutoStore — интернет-магазин автозапчастей

<div align="center">

![.NET Version](https://img.shields.io/badge/.NET-8.0-purple)
![Blazor](https://img.shields.io/badge/Blazor-Server-brightgreen)
![Entity Framework](https://img.shields.io/badge/EF%20Core-8.0-blue)
![PostgreSQL](https://img.shields.io/badge/PostgreSQL-16-blue)
![Docker](https://img.shields.io/badge/Docker-✓-2496ED)
![License](https://img.shields.io/badge/License-MIT-green)

**Курсовой проект по дисциплине «Кроссплатформенная среда исполнения программного обеспечения»**

</div>

---

## О проекте

**AutoStore** — это веб-приложение интернет-магазина автозапчастей, разработанное с использованием современного стека технологий .NET 8, ASP.NET Core, Blazor Server и PostgreSQL. Приложение позволяет пользователям просматривать каталог автозапчастей, управлять корзиной покупок, оформлять заказы с проверкой остатков на складе и отслеживать историю заказов.

Проект демонстрирует навыки работы с кроссплатформенной средой .NET, Entity Framework Core (Code First), Dependency Injection, контейнеризацией Docker, а также построением интерактивных веб-интерфейсов на Blazor Server.

### Основные возможности

- **Просмотр каталога автозапчастей** – список товаров с ценами, изображениями и описанием
- **Фильтрация по категориям** – отображение товаров выбранной категории (Двигатель и трансмиссия, Тормозная система, Фильтры и масла, Электрика и освещение, Подвеска и рулевое)
- **Управление корзиной** – добавление товаров, изменение количества, удаление позиций, расчёт итоговой суммы
- **Оформление заказа** – форма с валидацией данных покупателя, проверка остатков на складе
- **История заказов** – просмотр ранее оформленных заказов с детализацией по позициям
- **Демо-пользователь** – автоматическое создание гостевого аккаунта (alexey@example.com) без необходимости регистрации
- **Технические характеристики** – отображение производителя, веса, размеров, гарантии для каждой запчасти
- **Полная контейнеризация** – запуск приложения и базы данных через Docker Compose

---

## Технологии

| Технология | Назначение |
|------------|------------|
| .NET 8 | Кроссплатформенная среда исполнения |
| ASP.NET Core | Веб-фреймворк |
| Blazor Server | Интерактивный веб-интерфейс на C# |
| Entity Framework Core 8 | ORM, Code First, миграции |
| PostgreSQL 16 | Реляционная база данных |
| FluentValidation | Валидация моделей |
| Docker / Docker Compose | Контейнеризация и оркестрация |
| Git | Система контроля версий |

---

## 📁 Структура проекта
```
AutoStore/
├── AutoStore/ # 📦 Основной веб-проект
│ ├── Components/ # 🧩 Blazor компоненты
│ │ ├── Pages/ # 📄 Страницы приложения
│ │ │ ├── Products.razor # Каталог автозапчастей
│ │ │ ├── ProductDetails.razor # Карточка товара с характеристиками
│ │ │ ├── Cart.razor # Корзина покупок
│ │ │ ├── Checkout.razor # Оформление заказа
│ │ │ ├── Orders.razor # История заказов
│ │ │ └── Home.razor # Главная страница
│ │ └── Layout/ # 🏗️ Макеты и навигация
│ │ ├── MainLayout.razor
│ │ └── NavMenu.razor
│ │
│ ├── Data/ # 🗄️ Доступ к данным
│ │ ├── Configurations/ # ⚙️ Fluent API конфигурации
│ │ │ ├── CategoryConfiguration.cs
│ │ │ ├── ProductConfiguration.cs
│ │ │ ├── CustomerConfiguration.cs
│ │ │ ├── OrderConfiguration.cs
│ │ │ ├── CartItemConfiguration.cs
│ │ │ └── ProductDetailsConfiguration.cs
│ │ ├── DbSeeder.cs # 🌱 Начальные данные (Seed)
│ │ └── StoreContext.cs # 🔗 Контекст БД
│ │
│ ├── Models/ # 📋 Модели сущностей
│ │ ├── Category.cs # 🏷️ Категория автозапчастей
│ │ ├── Product.cs # 🔧 Автозапчасть
│ │ ├── ProductDetails.cs # 📊 Характеристики запчасти (1:1)
│ │ ├── Customer.cs # 👤 Покупатель
│ │ ├── Order.cs # 📦 Заказ
│ │ ├── OrderItem.cs # 📃 Позиция заказа
│ │ └── CartItem.cs # 🛒 Корзина
│ │
│ ├── Repositories/ # 📚 Репозитории
│ │ ├── IRepository.cs # 🔌 Интерфейс универсального репозитория
│ │ ├── Repository.cs # ⚙️ Реализация универсального репозитория
│ │ ├── IProductRepository.cs # 🔌 Интерфейс репозитория товаров
│ │ ├── ProductRepository.cs # 🔧 Репозиторий товаров (+ Include)
│ │ ├── IOrderRepository.cs # 🔌 Интерфейс репозитория заказов
│ │ └── OrderRepository.cs # 📦 Репозиторий заказов (+ Include)
│ │
│ ├── Services/ # ⚙️ Бизнес-логика
│ │ ├── IProductService.cs
│ │ ├── ProductService.cs # CRUD товаров
│ │ ├── ICategoryService.cs
│ │ ├── CategoryService.cs # CRUD категорий
│ │ ├── ICartService.cs
│ │ ├── CartService.cs # Управление корзиной
│ │ ├── IOrderService.cs
│ │ ├── OrderService.cs # Создание заказов, списание товаров
│ │ ├── ICurrentUserService.cs
│ │ └── CurrentUserService.cs # 👤 Демо-пользователь
│ │
│ ├── Validators/ # ✅ FluentValidation валидаторы
│ │ ├── CustomerValidator.cs # Валидация покупателя
│ │ ├── CheckoutValidator.cs # Валидация формы заказа
│ │ └── CheckoutModel.cs # Модель данных формы
│ │
│ ├── wwwroot/ # 🌐 Статические файлы
│ │ ├── css/
│ │ ├── js/
│ │ └── images/
│ │
│ ├── Migrations/ # 📜 EF Core миграции
│ ├── appsettings.json # ⚙️ Конфигурация (строки подключения)
│ ├── appsettings.Development.json # 🛠️ Конфигурация для разработки
│ ├── Program.cs # 🚀 Точка входа, DI, миграции
│ └── Dockerfile # 🐳 Docker-образ приложения
│
├── docker-compose.yml # 🐳 Оркестрация контейнеров
├── README.md # 📖 Документация
└── .gitignore # 🚫 Исключения для Git
```

---

## Модель данных

### Основные сущности и связи

| Сущность | Связь | Описание |
|----------|-------|----------|
| Category | 1 → N | Категория автозапчастей (Двигатель, Тормозная система и т.д.) |
| Product | N → 1 | Принадлежит одной категории |
| Product ↔ ProductDetails | 1 → 1 | Расширенные характеристики товара |
| Customer | 1 → N | Покупатель, может иметь много заказов |
| Order | 1 → N | Заказ, состоит из нескольких позиций |
| OrderItem | N → 1 | Позиция заказа (товар + количество + цена на момент покупки) |
| CartItem | связующая | Корзина покупателя (покупатель ↔ товар с количеством) |

### Начальные данные (Seed)

При первом запуске база данных заполняется тестовыми данными:

- **5 категорий** автозапчастей
- **8 товаров** (масляный фильтр Bosch, тормозные колодки Brembo, моторное масло Shell и др.)
- **6 наборов характеристик** (производитель, страна, вес, размеры, гарантия)
- **1 тестовый покупатель** (Алексей Смирнов)

---

## Быстрый старт

### Предварительные требования

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) (для локальной разработки)
- [Docker Desktop](https://www.docker.com/products/docker-desktop/) (для контейнеризации)
- [PostgreSQL](https://www.postgresql.org/download/) (при локальном запуске без Docker)
- [Git](https://git-scm.com/)

---

## Запуск через Docker (рекомендуемый способ)

Этот способ не требует установки .NET SDK и PostgreSQL на хост-машине — всё работает в изолированных контейнерах.

### Шаг 1: Клонирование репозитория
git clone https://github.com/avavvaav/AutoStore
cd AutoStore
### Шаг 2: Запуск контейнеров
docker-compose up -d
### Шаг 3: Открыть приложение
http://localhost:8024

