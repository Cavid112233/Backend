using Backend.DAL;
using Backend.Entities;
using Backend.Extension;
using Backend.ViewModels.TellUsAdmin;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class TellUsController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public TellUsController(AppDbContext appDbContext, IWebHostEnvironment webHostEnvironment)
        {
            _appDbContext = appDbContext;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            return View(_appDbContext.TellUs.ToList());
        }
        public IActionResult Detail(int? id)
        {
            if (id == null) return NotFound();
            var existspeaker = _appDbContext.TellUs.FirstOrDefault(b => b.Id == id);
            if (existspeaker == null) return NotFound();
            return View(existspeaker);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(TellUsCreateVm createSpeakerVM)

        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Photo", "Bos Qoyma");
                return View();
            }
            if (!createSpeakerVM.Photo.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("Photo", "only image");
                return View();
            }
            if (createSpeakerVM.Photo.Length / 1024 > 1000)
            {
                ModelState.AddModelError("Photo", "Olchu boyukdur");
                return View();
            }
            TellUs speakers = new();
            speakers.SpeakerName = createSpeakerVM.SpeakerName;
            speakers.Profession = createSpeakerVM.Profession;
            speakers.ImageUrl = createSpeakerVM.Photo.SaveImage("img/event", _webHostEnvironment);
            _appDbContext.TellUs.Add(speakers);
            _appDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();
            var deletedspeaker = _appDbContext.TellUs.FirstOrDefault(c => c.Id == id);
            if (deletedspeaker == null) return NotFound();

            _appDbContext.TellUs.Remove(deletedspeaker);
            _appDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Update(int? id)
        {
            if (id == null) return NotFound();
            var existspeaker = _appDbContext.TellUs.FirstOrDefault(c => c.Id == id);
            if (existspeaker == null) return NotFound();
            var updateSpeakerVM = new TellUsUpdateVM
            {
                SpeakerName = existspeaker.SpeakerName,
                Profession = existspeaker.Profession,


            };
            return View(updateSpeakerVM);
        }




        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Update(TellUsUpdateVM updateSpeakerVM)
        {
            if (!ModelState.IsValid) return View();
            var existspeaker = _appDbContext.TellUs.FirstOrDefault(c => c.Id == updateSpeakerVM.Id);
            if (updateSpeakerVM == null) return NotFound();

            existspeaker.SpeakerName = updateSpeakerVM.SpeakerName;
            existspeaker.Profession = updateSpeakerVM.Profession;

            if (updateSpeakerVM.Photo != null)
            {

                if (!updateSpeakerVM.Photo.ContentType.Contains("image/"))
                {
                    ModelState.AddModelError("Photo", "only image");
                    return View();
                }
                if (updateSpeakerVM.Photo.Length / 1024 > 1000)
                {
                    ModelState.AddModelError("Photo", "Size is High");
                    return View();
                }

                existspeaker.ImageUrl = updateSpeakerVM.Photo.SaveImage("img/event", _webHostEnvironment);
            }

            _appDbContext.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
