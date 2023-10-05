using Backend.DAL;
using Backend.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Backend.ViewComponents
{
    public class HeaderViewComponent:ViewComponent
    {
        private readonly AppDbContext _appDbContext;
        public HeaderViewComponent(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
          
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            HomeVM vm = new()
            {

                Setting = _appDbContext.Setting.ToDictionary(s => s.Key, s => s.Value)

            };


            return View(await Task.FromResult(vm));
        }
    }
}
