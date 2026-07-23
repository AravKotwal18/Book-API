# BookAPI 📚

A RESTful Book Management API built with ASP.NET Core 10 and Entity Framework Core.

## Features
- 📖 **Books** — Full CRUD with author and category linking
- 👤 **Authors** — Manage author profiles
- 🏷️ **Categories** — Organize books by category
- ⭐ **Reviews** — Rate and review books
- 🔗 **Relationships** — One-to-Many and Many-to-Many
- 🗃️ **Repository Pattern** — Clean separation of data access
- 🔄 **DTOs & AutoMapper** — Decoupled data transfer
- 🌐 **Custom HTML Frontend** — BookManager.html dashboard

## Tech Stack
| Layer | Technology |
|-------|------------|
| Framework | ASP.NET Core 10 |
| ORM | Entity Framework Core |
| Database | SQL Server |
| Mapping | AutoMapper |
| Architecture | Repository Pattern |
| Frontend | Custom HTML/CSS/JS |

## Endpoints
### Books
- `GET /api/book` — Get all books
- `GET /api/book/{id}` — Get book by ID
- `POST /api/book` — Add book
- `PUT /api/book/{id}` — Update book
- `DELETE /api/book/{id}` — Delete book

### Authors
- `GET /api/author` — Get all authors
- `GET /api/author/{id}` — Get author by ID
- `POST /api/author` — Add author

### Categories
- `GET /api/category` — Get all categories
- `GET /api/category/{id}` — Get category by ID
- `POST /api/category` — Add category

### Reviews
- `GET /api/review` — Get all reviews
- `GET /api/review/{id}` — Get review by ID
- `POST /api/review` — Add review

## Setup
1. Clone the repo
2. Update connection string in `appsettings.json`
3. Run `dotnet ef database update`
4. Run `dotnet run`
5. Open `BookManager.html` in browser for frontend
