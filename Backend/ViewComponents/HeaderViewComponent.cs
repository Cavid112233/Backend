using Backend.DAL;
using Backend.Entities;
using Backend.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Backend.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;

        public HeaderViewComponent(AppDbContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }

}


