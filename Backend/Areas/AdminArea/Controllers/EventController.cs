using Backend.DAL;
using Backend.Entities;
using Backend.Extension;
using Backend.ViewModels.EventAdmin;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class EventController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public EventController(AppDbContext appDbContext, IWebHostEnvironment webHostEnvironment)
        {
            _appDbContext = appDbContext;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            return View(_appDbContext.Events.ToList());
        }
        public IActionResult Detail()
        {
            var events = _appDbContext.Events
               .Include(b => b.EventTellUses).
               ThenInclude(bg => bg.TellUs).
               ToList();
            return View(events);
        }
        public IActionResult Create()
        {
            ViewBag.Speakers = _appDbContext.TellUs.ToList();
            return View();
        }


        public IActionResult Delete(int? id)
        {

            if (id == null) return NotFound();
            var deletedevent = _appDbContext.Events.FirstOrDefault(c => c.Id == id);
            if (deletedevent == null) return NotFound();

            _appDbContext.Events.Remove(deletedevent);
            _appDbContext.SaveChanges();
            return RedirectToAction("Index");



        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(EventCreateVM createEventVM)
        {
            ViewBag.TellUs = _appDbContext.TellUs.ToList();
            Event events = new Event();
            events.EventName = createEventVM.EventName;
            events.DateStart = createEventVM.DateStart;
            events.DateEnd = createEventVM.DateEnd;
            events.Venue = createEventVM.Venue;
            events.ExactDate = createEventVM.ExactDate;
            events.Description = createEventVM.Description;



            foreach (var speakerId in createEventVM.SpeakersIds)
            {
                EventTellUs eventSpeaker = new();

                eventSpeaker.Event = events;
                eventSpeaker.SpeakersId = speakerId;
                events.EventTellUses.Add(eventSpeaker);
            }
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Photo", "Bos Qoyma");
                return View();
            }
            if (!createEventVM.Photo.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("Photo", "only image");
                return View();
            }
            if (createEventVM.Photo.Length / 1024 > 1000)
            {
                ModelState.AddModelError("Photo", "Olchu boyukdur");
                return View();
            }
            events.ImageUrl = createEventVM.Photo.SaveImage("img/event", _webHostEnvironment);
            _appDbContext.Events.Add(events);
            _appDbContext.SaveChanges();

            return RedirectToAction("Index");

        }

        public IActionResult Update(int? id)
        {
            if (id == null) return NotFound();
            var existevent = _appDbContext.Events
               .Include(b => b.EventTellUses).
               ThenInclude(bg => bg.TellUs).
               FirstOrDefault(e => e.Id == id);
            if (existevent == null) return NotFound();
            var updateEventVM = new EventUpdateVM
            {
                EventName = existevent.EventName,
                DateStart = existevent.DateStart,
                DateEnd = existevent.DateEnd,
                ExactDate = existevent.ExactDate,
                Description = existevent.Description,
                Venue = existevent.Venue,
                SpeakersIds = existevent.EventTellUses.Select(e => e.Id).ToList(),
                Speakers = _appDbContext.TellUs.ToList()


            };
            return View(updateEventVM);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Update(EventUpdateVM updateEventVM)
        {

            if (!ModelState.IsValid) return View();
            var existEvent = _appDbContext.Events
               .Include(b => b.EventTellUses).
               ThenInclude(bg => bg.TellUs).FirstOrDefault(c => c.Id == updateEventVM.Id);

            if (existEvent == null) return NotFound();

            existEvent.EventName = updateEventVM.EventName;
            existEvent.DateEnd = updateEventVM.DateEnd;
            existEvent.DateStart = updateEventVM.DateStart;
            existEvent.Description = updateEventVM.Description;
            existEvent.Venue = updateEventVM.Venue;
            existEvent.ExactDate = updateEventVM.ExactDate;

            foreach (var speakerId in updateEventVM.SpeakersIds)
            {
                if (!_appDbContext.TellUs.Any(es => es.Id == speakerId))
                {
                    return NotFound();
                }
            }

            UpdateEventSpeaker();

            if (updateEventVM.Photo != null)
            {

                if (!updateEventVM.Photo.ContentType.Contains("image/"))
                {
                    ModelState.AddModelError("Photo", "only image");
                    return View();
                }
                if (updateEventVM.Photo.Length / 1024 > 1000)
                {
                    ModelState.AddModelError("Photo", "Olchu boyukdur");
                    return View();
                }

                existEvent.ImageUrl = updateEventVM.Photo.SaveImage("img/event", _webHostEnvironment);
            }

            void UpdateEventSpeaker()
            {
                //deyiseceyimiz modelin movcud datalari
                var existEventSpeakersIdInDb = existEvent.EventTellUses.Select(es => es.SpeakersId).ToList();

                //deyiseceyimiz modelin update halinda yeni secilenlerden evvelki silinecek olanlarin id si.
                var existEventSpeakersIdsToRemove = existEventSpeakersIdInDb.Except(updateEventVM.SpeakersIds).ToList();


                //deyiseceyimiz modelin icindeki yeni gelen many to many datalarin id si.
                var existEventSpeakerNewIdsToAdd = updateEventVM.SpeakersIds.Except(existEventSpeakersIdInDb).ToList();

                existEvent.EventTellUses.RemoveAll(es => existEventSpeakersIdsToRemove.Contains(es.SpeakersId));

                foreach (var eventSpeakerId in existEventSpeakerNewIdsToAdd)
                {
                    var eventSpeaker = new EventTellUs
                    {
                        EventId = existEvent.Id,
                        SpeakersId = eventSpeakerId,
                    };

                    _appDbContext.EventTellUs.Add(eventSpeaker);

                }

            }
            _appDbContext.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
