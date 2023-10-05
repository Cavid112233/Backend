using Backend.DAL;
using Backend.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    public class AboutController : Controller
    {
        private readonly AppDbContext _context;

        public AboutController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            AboutVM aboutVM = new AboutVM();
            aboutVM.AboutBanner = _context.AboutBanner.FirstOrDefault();
            aboutVM.SliderTestimonial = _context.SliderTestimonial.FirstOrDefault();
            aboutVM.AboutVideo = _context.AboutVideo.FirstOrDefault();
            return View(aboutVM);
        }
    }
}
