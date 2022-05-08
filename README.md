# Author
 - Todor Dimitrov
 
# Project description
 - ShopingSystem is example project for ASP.NET Core with Domain Driven Design
 - The solution contains a structure of 5 layers, divided into different projects
	 - Domain
		- This layer contains rich domain models with validation,
		domain events, domain exceptions, factories and domain repositories public interface
		- Bounded contexts - Shoping Request, Published Shoping Request and Execution of the Request
	 - Application
		- This layer contains command and query handlers, validators, models, domain event handlers and query repositories public interface
	 - Infrastructure
		- Database configuration, migrations and repository implementations
	 - Web
		- Controllers and Middlewares 
	 - Startup
		- Web app configurations


# Run the project
	dotnet run

# Resources
- [.NET 5](https://github.com/dotnet)
- [ASP.NET Core](https://github.com/dotnet/aspnetcore)
- [Autofac](https://autofac.readthedocs.io/en/latest/)
- [MediatR](https://github.com/jbogard/MediatR)
- [Automapper](https://github.com/AutoMapper/AutoMapper)
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)
- [Microsoft SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [JWT](https://jwt.io/)
	
# More Info

#### Shoping System - helps other people to get their essentials shoping
&nbsp;
### The project also use implementation of CQRS pattern
- There is separation of the read and write operations
with command and query handlers

### The project also use implementation Repository Pattern
- There are database repositories for every domain model
