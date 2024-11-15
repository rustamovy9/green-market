# GreenMarket API

GreenMarket API — это бэкенд для торговой платформы, предназначенной для фермеров и бизнесменов. Проект позволяет фермерам добавлять свои продукты для продажи, а бизнесменам просматривать товары, и оформлять заказы.

## Функциональные возможности

- **Пользователи**:
  - Регистрация пользователей (роли: Бизнесмен и Фермер).
  - Управление профилем пользователя.
- **Продукты**:
  - Добавление и редактирование продуктов (только для фермеров).
  - Просмотр списка всех продуктов и фильтрация по категориям.
- **Корзина**:
  - Добавление продуктов в корзину и управление корзиной.
  - Оформление заказа из корзины.
- **Категории товаров**:
  - Просмотр доступных категорий товаров.
- **Отзывы**:
  - Оставление отзыва на продукт (только для бизнесменов).

## Стек технологий

- **Язык программирования**: C#
- **Фреймворк**: ASP.NET Core Web API
- **База данных**: PostgreSQL
- **ORM**: Entity Framework Core
- **Паттерны**: CQRS, Repository<T>, Unit of Work, DTO, SRM,Pagination Filter
- **Документация API**: Swagger


## Установка и запуск
- **dotnet run и dotnet restore**

### Предварительные требования

Для работы вам понадобятся:

- [.NET SDK 7.0](https://dotnet.microsoft.com/download)
- [PostgreSQL](https://www.postgresql.org/download/)

###  Установки

 **Клонируйте репозиторий**:
   ```bash
   git clone https://github.com/rustamovy9/green-market.git

