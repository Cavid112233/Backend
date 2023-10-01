using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    public class TeacherController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult TeacherDetails()
        {
            return View();
        }
    }
}
