### MovieShopApp 🎬

MovieShopApp is an ASP.NET Core MVC movie-store application organized into separate application, infrastructure, and web layers. It is designed around movie discovery and movie-related user interactions, with repository and service abstractions for database operations.

Repository: https://github.com/Yashaswini944/MovieShopApp


### Overview

MovieShopApp is a full-stack web application intended to let users browse movies, explore movie details, purchase movies, write reviews, and manage favorites. The application uses ASP.NET Core MVC for its web interface and Entity Framework Core with SQL Server for data access.

The solution separates core contracts and entities from data-access implementations and the web application, making responsibilities easier to understand and maintain.

Tech stack

Area	Technology

Language	C#

Web framework	ASP.NET Core MVC (.NET 10)
Data access	Entity Framework Core 10
Database	Microsoft SQL Server
Architecture	Layered solution with repository and service abstractions
Development	.NET SDK, Visual Studio or VS Code


### Application scope

According to the repository description, the application is intended to support:
- Movie browsing: Explore movies and view detailed information.
- Purchases: Purchase movies through the application.
- Reviews: Add movie reviews.
- Favorites: Save movies to a favorites list.

The source also registers repositories or services associated with movies, genres, cast, users, purchases, reports, accounts, and administration. The presence of these components does not by itself establish that every corresponding workflow is fully implemented or production-ready.

### Solution structure

MovieShopApp/
├── ApplicationCore/         # Core entities and application contracts
├── Infrastructure/          # Data access and service implementations
├── MovieShopAppMVC/         # ASP.NET Core MVC web application
├── MovieShopApp.slnx        # .NET solution
└── README.md

### How the layers fit together
Browser
   |
   v
MovieShopAppMVC
(Controllers + Views)
   |
   v
ApplicationCore
(Entities + Interfaces / Contracts)
   ^
   |
Infrastructure
(Repositories + Services + EF Core DbContext)
   |
   v
SQL Server

The web project registers the EF Core MovieShopDbContext, generic and domain-specific repositories, and application services through ASP.NET Core dependency injection.
Getting started

Prerequisites
- .NET 10 SDK
- SQL Server, SQL Server Express, or SQL Server LocalDB
- Git
- A code editor such as Visual Studio or VS Code

1. Clone the repository
git clone https://github.com/Yashaswini944/MovieShopApp.git
cd MovieShopApp

2. Restore dependencies
dotnet restore MovieShopApp.slnx

3. Configure your SQL Server connection
The application reads its database connection from ConnectionStrings:MovieShopDb. The checked-in configuration references a machine-specific SQL Server instance, so it will typically need to be changed for your computer.

For local development, prefer .NET user secrets rather than committing a real connection string:
cd MovieShopAppMVC
dotnet user-secrets init
dotnet user-secrets set "ConnectionStrings:MovieShopDb" "Server=(localdb)\\MSSQLLocalDB;Database=MovieShopDb;Trusted_Connection=True;TrustServerCertificate=True"
cd ..

The example above uses Windows LocalDB. For another SQL Server installation, substitute a connection string appropriate to your environment. Never commit passwords or production credentials.

4. Prepare the database
If the repository includes EF Core migrations, apply them with:
dotnet tool install --global dotnet-ef
dotnet ef database update --project Infrastructure --startup-project MovieShopAppMVC
If no migrations have been created, the schema must first be established based on the existing EF Core model and project configuration. The database setup has not been verified as a one-command process.

6. Build and run
dotnet build MovieShopApp.slnx
dotnet run --project MovieShopAppMVC
Open the localhost URL shown in the terminal. The development port is determined by your local launch configuration.
Design and implementation notes

- MVC: Controllers and views handle browser-facing requests and presentation.
- Dependency injection: The application registers repository and service contracts with scoped lifetimes.
- EF Core: MovieShopDbContext is configured with the SQL Server provider.
- Repository abstraction: A generic repository and domain-specific repositories separate persistence concerns from higher-level application logic.
- Service abstraction: Domain services provide a place for business logic outside controllers.
These structural decisions are visible in the solution files and application startup configuration; they should not be interpreted as proof of comprehensive automated testing, secure payment integration, or deployment.
Screenshots and demo

### Current limitations and potential improvements
Useful next steps for a more complete engineering portfolio presentation include:
- Verify and document all user-facing workflows and their current completion status.
- Provide reproducible database initialization or migration instructions.
- Add automated unit and integration tests, and show actual results.
- Add CI checks for restoring, building, and testing the solution.
- Document authentication, authorization, and payment handling accurately if implemented.
- Include screenshots, a short demo, and deployment instructions when available.
- Replace any developer-machine-specific configuration with portable local-development guidance.
  
