using EventManagementSystem.Database.AppDbContextModels;
using EventManagementSystem.Domain.Features;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementSystem.Controllers
{
    public class EventController : Controller
    {
        private readonly EventService _eventService;

        public EventController(EventService eventService)
        {
            _eventService = eventService;
        }

        public IActionResult Index()
        {
            var events = _eventService.GetAllEvents();
            return View(events);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Event newEvent)
        {
            if (ModelState.IsValid)
            {
                _eventService.CreateEvent(newEvent);
                return RedirectToAction("Index");
            }
            return View(newEvent);
        }
    }
}
