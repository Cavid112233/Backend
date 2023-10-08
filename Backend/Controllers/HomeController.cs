using Backend.DAL;
using Backend.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public HomeController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IActionResult Index()
        {
            HomeVM vm = new()
            {
                SliderContents = _appDbContext.SliderContents.ToList(),
                ChooseArea = _appDbContext.ChooseArea.FirstOrDefault(),
                SliderTestimonial = _appDbContext.SliderTestimonial.FirstOrDefault(),
                Events = _appDbContext.Events.ToList(),
                Courses = _appDbContext.Courses.ToList(),
                Blogs = _appDbContext.Blogs.ToList(),
            };

            return View(vm);
        }
    }
}
