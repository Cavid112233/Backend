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
            HomeVM vm = new();
            vm.SliderContents = _appDbContext.SliderContents.ToList();
            vm.ChooseArea = _appDbContext.ChooseArea.FirstOrDefault();    

            return View(vm);
        }
    }
}
