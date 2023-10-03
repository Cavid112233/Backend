using Backend.DAL;
using Backend.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.ViewComponents
{
    public class FooterViewComponent : ViewComponent
    {
        private readonly AppDbContext _appDbContext;
        public FooterViewComponent(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;

        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            HomeVM vm = new HomeVM()
            {

                Setting = _appDbContext.Setting.ToDictionary(s => s.Key, s => s.Value)

            };
            

            return View(await Task.FromResult(vm));

        }

    }

}