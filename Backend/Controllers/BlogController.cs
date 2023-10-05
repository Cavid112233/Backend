using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult BlogDetails(int id)
        {
            return View();
        }
    }
}
