using Backend.Controllers;
using Backend.DAL;
using Backend.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Backend.ViewComponents
{
    public class FooterViewComponent : ViewComponent
    {
        public readonly AppDbContext _context;

        public FooterViewComponent(AppDbContext context)
        {
            _context = context;
        }
    }
}
