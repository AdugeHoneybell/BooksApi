# BooksApi

A simple RESTful Web API for managing books, implemented with ASP.NET Core (.NET 10) and C#.

## Tech
- .NET 10
- ASP.NET Core Web API
- C#

## Requirements
- .NET 10 SDK installed: https://dotnet.microsoft.com
- (Optional) Visual Studio 2022/2026 or VS Code

## Getting started
1. Clone the repository:
   git clone https://github.com/AdugeHoneybell/BooksApi.git
2. From the repository root, build and run the API:
   dotnet build
   dotnet run --project BooksApi

Alternatively, open the solution (BooksApi.slnx) in Visual Studio and run the BooksApi project.

## Common commands
- Build: dotnet build
- Run: dotnet run --project BooksApi
- Test: dotnet test

## API (example endpoints)
The API exposes typical CRUD endpoints for books under /api/books. Example routes:
- GET /api/books           — list all books
- GET /api/books/{id}      — get a book by id
- POST /api/books          — create a new book (JSON body)
- PUT /api/books/{id}      — update a book (JSON body)
- DELETE /api/books/{id}   — delete a book

Example request (create):
curl -X POST http://localhost:5000/api/books -H "Content-Type: application/json" -d '{"title":"Example","author":"Author"}'

Adjust host/port based on application launch output or launchSettings.json.

## Configuration
Configuration is handled via appsettings.json and environment variables. Review BooksApi/Properties/launchSettings.json and appsettings.json for ports and environment settings.

## Contributing
Issues and pull requests are welcome. Follow repository conventions and add tests for behavior changes.

## Repository
https://github.com/AdugeHoneybell/BooksApi

## License
No license specified in this repository. Add a LICENSE file if intended for public use.
