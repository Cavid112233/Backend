using Backend.DAL;
using Backend.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            aboutVM.Teachers = _context.Teachers.Include(t => t.Skill).Include(t => t.Contact).ToList();
            aboutVM.Events = _context.Events.ToList();
            return View(aboutVM);
        }
    }
}
