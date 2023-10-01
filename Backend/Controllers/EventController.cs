using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    public class EventController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult EventDetails()
        {
            return View();
        }
    }
}
