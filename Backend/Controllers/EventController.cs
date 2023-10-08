using Backend.DAL;
using Backend.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    public class EventController : Controller
    {
        private readonly AppDbContext _context;

        public EventController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            EventVM eventVM = new EventVM();
            eventVM.Events = _context.Events.Include(e => e.EventTellUses).ThenInclude(ev => ev.TellUs).ToList();
            return View(eventVM);
        }
        public IActionResult EventDetails(int? id)
        {
            var findedevent = _context.Events.Include(e => e.EventTellUses).ThenInclude(ev => ev.TellUs).FirstOrDefault(t => t.Id == id);
            EventPrivateVM eventIndividualVM = new EventPrivateVM();
            eventIndividualVM.Courses = _context.Courses.ToList();
            eventIndividualVM.ImageUrl = findedevent.ImageUrl;
            eventIndividualVM.Venue = findedevent.Venue;
            eventIndividualVM.DateStart = findedevent.DateStart;
            eventIndividualVM.DateEnd = findedevent.DateEnd;
            eventIndividualVM.ExactDate = findedevent.ExactDate;
            eventIndividualVM.EventName = findedevent.EventName;
            eventIndividualVM.Description = findedevent.Description;
            eventIndividualVM.TellUses = _context.TellUs.Where(s => s.EventTellUses.Any(es => es.EventId == id)).ToList();


            return View(eventIndividualVM);
        }
    }
}
