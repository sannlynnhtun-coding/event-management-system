# EventManagementSystem

The **Event Management System** is a .NET-based application designed to manage event-related data efficiently. It provides features to create, retrieve, update, and delete events using Entity Framework Core with a Database First approach. This repository includes a well-structured solution with unit tests to ensure code reliability.

---

## Features

- **Event Management**: Add, view, and manage events.
- **Database First Approach**: Built with EF Core to maintain consistency with the database schema.
- **Logging**: Integrated logging using `ILogger` for better observability.
- **Unit Testing**: Comprehensive test coverage using xUnit and Moq for mocking dependencies.

---

## Technologies Used

- **.NET 8**: Framework for building the application.
- **Entity Framework Core**: Database access using the Database First approach.
- **xUnit**: For writing unit tests.
- **Moq**: For mocking dependencies during tests.
- **In-Memory Database**: Used for testing without affecting the production database.
- **Dependency Injection**: For flexible and testable architecture.

---

## Project Structure

```plaintext
EventManagementSystem/
├── Database/
│   ├── AppDbContextModels/       # EF Core models generated from the database
│   └── AppDbContext.cs           # Database context
├── Domain/
│   ├── Features/                 # Business logic for event management
│   └── DTOs/                     # Data Transfer Objects
├── UnitTests/
│   └── EventServiceTests.cs      # Unit tests for EventService
└── Program.cs                    # Application entry point
```


dotnet ef dbcontext scaffold "Server=.;Database=EventManagementSystem;User ID=sa;Password=sasa@123;Trust Server Certificate=True;" Microsoft.EntityFrameworkCore.SqlServer -o AppDbContextModels -c AppDbContext

```sql
CREATE TABLE Events (
    EventId INT PRIMARY KEY IDENTITY(1,1),
    Title NVARCHAR(100) NOT NULL,
    Description NVARCHAR(MAX),
    Date DATETIME NOT NULL,
    Location NVARCHAR(200)
);

CREATE TABLE Attendees (
    AttendeeId INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100),
    Email NVARCHAR(100)
);

CREATE TABLE Registrations (
    RegistrationId INT PRIMARY KEY IDENTITY(1,1),
    EventId INT,
    AttendeeId INT,
    FOREIGN KEY (EventId) REFERENCES Events(EventId),
    FOREIGN KEY (AttendeeId) REFERENCES Attendees(AttendeeId)
);
```