using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
