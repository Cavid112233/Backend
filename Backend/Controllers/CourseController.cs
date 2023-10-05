using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CourseDetails()
        {
            return View();
        }
    }
}
