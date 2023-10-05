using Backend.DAL;
using Backend.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    public class TeacherController : Controller
    {
        private readonly AppDbContext _appDbContext;
        public TeacherController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IActionResult Index()
        {
            TeacherVM teacherVM = new();

            teacherVM.Teachers = _appDbContext.Teachers.Include(t => t.Skill).Include(t => t.Contact).ToList();


            return View(teacherVM);
        }
        public IActionResult TeacherDetails(int? id)
        {

            if (id == null) return NotFound();
            var existteacher = _appDbContext.Teachers
                .FirstOrDefault(p => p.Id == id);



            TeacherVM teacherVM = new();

            teacherVM.Teachers = _appDbContext.Teachers.Include(t => t.Skill).Include(t => t.Contact).ToList();
            return View(teacherVM);

        }
    }
}
