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



            var findedteacher = _appDbContext.Teachers.Include(t => t.Skill).Include(t => t.Contact).FirstOrDefault(t => t.Id == id);
            var contact = _appDbContext.TeacherContact.FirstOrDefault(t => t.TeacherId == findedteacher.Id);
            TeacherPrivateVM teacherPrivateVM = new();

            teacherPrivateVM.TeacherName = findedteacher.TeacherName;
            teacherPrivateVM.Hobbies = findedteacher.Hobbies;
            teacherPrivateVM.skills = _appDbContext.TeacherSkill.Where(ts => ts.TeacherId == findedteacher.Id).ToList();

            teacherPrivateVM.Experience = findedteacher.Experience;
            teacherPrivateVM.Profession = findedteacher.Profession;
            teacherPrivateVM.Degree = findedteacher.Degree;
            teacherPrivateVM.AboutDesc = findedteacher.AboutDesc;
            teacherPrivateVM.ImageUrl = findedteacher.ImageUrl;
            teacherPrivateVM.Faculty = findedteacher.Faculty;
            teacherPrivateVM.ContactVM = new ContactVM(contact.Email, contact.Skype, contact.Vimeo, contact.Pinterest, contact.Pinterest, contact.Facebook, contact.PhoneCall);


            return View(teacherPrivateVM);

        }
    }
}
