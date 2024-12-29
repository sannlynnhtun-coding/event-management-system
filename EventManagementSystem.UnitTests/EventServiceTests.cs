using EventManagementSystem.Database.AppDbContextModels;
using EventManagementSystem.Domain.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;

namespace EventManagementSystem.UnitTests;

public class EventServiceTests : IDisposable
{
    private readonly EventService _eventService;
    private readonly AppDbContext _dbContext;
    private readonly Mock<ILogger<EventService>> _mockLogger;

    public EventServiceTests()
    {
        // Setting up an in-memory database
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // Use unique database name for each test
            .Options;

        _dbContext = new AppDbContext(options);

        // Seed the database with test data
        SeedDatabase();

        // Mocking the ILogger for EventService
        _mockLogger = new Mock<ILogger<EventService>>();

        // Initialize the EventService with the test DbContext and mocked logger
        _eventService = new EventService(_dbContext, _mockLogger.Object);
    }

    private void SeedDatabase()
    {
        _dbContext.Events.RemoveRange(_dbContext.Events); // Clear existing data
        _dbContext.Events.AddRange(new List<Event>
        {
            new Event { EventId = 1, Title = "Event 1", Location = "Location 1", Date = new DateTime(2024, 1, 1) },
            new Event { EventId = 2, Title = "Event 2", Location = "Location 2", Date = new DateTime(2024, 2, 1) }
        });

        _dbContext.SaveChanges();
    }

    [Fact]
    public void GetAllEvents_ShouldReturnAllEvents()
    {
        // Act
        var events = _eventService.GetAllEvents();

        // Assert
        Assert.NotNull(events);
        Assert.Equal(2, events.Count());

        // Verify logger usage
        _mockLogger.Verify(
            logger => logger.Log(
                LogLevel.Information,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, t) => v.ToString().Contains("Retrieving all events")),
                null,
                It.IsAny<Func<It.IsAnyType, Exception, string>>()),
            Times.Once);
    }

    [Fact]
    public void CreateEvent_ShouldAddNewEvent()
    {
        // Arrange
        var newEvent = new Event
        {
            EventId = 3,
            Title = "Event 3",
            Location = "Location 3",
            Date = new DateTime(2024, 3, 1)
        };

        // Act
        _eventService.CreateEvent(newEvent);

        // Assert
        var events = _dbContext.Events.ToList();
        Assert.Equal(3, events.Count);
        Assert.Contains(events, e => e.Title == "Event 3");

        // Verify logger usage
        _mockLogger.Verify(
            logger => logger.Log(
                LogLevel.Information,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, t) => v.ToString().Contains("Creating a new event")),
                null,
                It.IsAny<Func<It.IsAnyType, Exception, string>>()),
            Times.Once);
    }

    public void Dispose()
    {
        _dbContext.Dispose();
    }
}
