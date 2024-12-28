using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventManagementSystem.Database.AppDbContextModels;

namespace EventManagementSystem.Domain.Features;

public class EventService
{
    private readonly AppDbContext _context;

    public EventService(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Event> GetAllEvents()
    {
        return _context.Events.ToList();
    }

    public void CreateEvent(Event newEvent)
    {
        _context.Events.Add(newEvent);
        _context.SaveChanges();
    }
}
