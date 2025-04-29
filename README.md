# Overview
This is a Windows Forms application with a target framework of .NET 8.  
The application reads and writes to a MySQL database using Entity Framework Core (EF Core).

## Setting Up
A database connection is needed to save and fetch data. The following steps explain how to set this up.

1. Either create a MySQL database or use an existing one
1. At the project root, create an `appsettings.json` file with the following content:
```
{
  "ConnectionStrings": {
    "MySqlConnection": "(your connection string)"
  }
}
```
3. In Visual Studio, open the **Nuget Package Manager Console**  
(Tools > Nuget Package Manager > Packet Manager Console) and run `update-database` 

For an alternative approach to Step 3, do this:
1. Open a CLI and navigate to the project directory
1. Run `dotnet ef database update`

After completing the steps above, the application will be properly configured for use. 

## Entity Relationships
The entity relationships are as follows:

- ONE `User` has ONE or MANY `Appointments`  
- ONE `Appointment` has ONE `Customer` 
- ONE `Customer` has ONE `Address`  
- ONE `Address` has ONE `City`  
- ONE `City` has ONE `Country`  

## Dependency Injection (DI)
This program leverages DI to manage dependencies efficiently, ensuring modular and testable code.

### Key Points
- Uses `ServiceCollection` to register services and components in a central place  
( `ConfigureServices` ).
- `BuilderServiceProvider()` creates a **service provider**, allowing registered dependencies  
to be resolved when needed. 
- Scope:
	- `AddTransient<>` creates a new instance each time it's requested (e.g., `CustomerService`,  
	`LoginForm`)
	- `AddSingleton<>` Maintains a single instance throughout the application's lifetime  
   (e.g., `Repository`)
- Uses `AddDbContext<>` to configure data base connectivity, binding `Context.Context` to  
MySQL

When the application starts, DI automatically injects dependencies, eliminating manual instantiation  
and promoting maintainability. This ensures clean separation between UI, services, and DB layers.

## Service Architecture 
The generic base service, `EntityBaseService`, provides a reusable and scalable foundation for  
handling database operations across different entity types. By using generics  
(`TEntity` and `TContext`), it abstracts common CRUD operations, allowing multiple entities  
to share the same logic without duplicating code.
- `TEntity` ensures the service can operate on various entity types derived from `EntityBase`
- `TContext` allows integration with different database contexts, making it adaptable across  
applications using `DbContext`  

This approach was implemented to reduce redundancy and maintain efficiency.

## Additional Functionality

### Logging
Each time a user signs into the application, a timestamp with their username is logged to  
`Login_History.txt_` in the `bin` folder. 

### Automatic Timezones
When an entity is created, its timestamp is converted to UTC. During data retrieval,  
timestamps are adjusted  based on the user's system settings, ensuring they are displayed  
in the correct local timezone.

### Validation 
The application handles invalid input by providing clear guidance to the user. It prevents  
inappropriate actions, ensuring the integrity of data during creation and modification.

### Language Translation
The labels on the `Login Form` are displayed in English or Spanish depending on the users  
system language settings.
