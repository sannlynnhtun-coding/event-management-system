# EventManagementSystem

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