using Microsoft.Extensions.Logging;
using EventManagementSystem.Database.AppDbContextModels;

namespace EventManagementSystem.Domain.Features;

public class EventService
{
    private readonly AppDbContext _dbContext;
    private readonly ILogger<EventService> _logger;

    public EventService(AppDbContext dbContext, ILogger<EventService> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public IEnumerable<Event> GetAllEvents()
    {
        _logger.LogInformation("Retrieving all events");
        return _dbContext.Events.ToList();
    }

    public void CreateEvent(Event newEvent)
    {
        _logger.LogInformation("Creating a new event");
        _dbContext.Events.Add(newEvent);
        _dbContext.SaveChanges();
    }
}
