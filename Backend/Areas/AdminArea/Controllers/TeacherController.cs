using Backend.DAL;
using Backend.Extension;
using Backend.Entities;
using Backend.ViewModels.TeacherAdmin;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Backend.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class TeacherController : Controller
    {

        private readonly AppDbContext _appDbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public TeacherController(AppDbContext appDbContext, IWebHostEnvironment webHostEnvironment)
        {
            _appDbContext = appDbContext;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            return View(_appDbContext.Teachers.ToList());
        }
        public IActionResult Detail(int? Id)
        {
            if (Id == null) return NotFound();
            var existteacher = _appDbContext.Teachers.Include(t => t.Skill).Include(t => t.Contact).FirstOrDefault();
            if (existteacher == null) return NotFound();
            return View(existteacher);
        }
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [AutoValidateAntiforgeryToken]

        public IActionResult Create(CreateTeacherVM createTeacherVM)
        {


            if (_appDbContext.Teachers.Any(c => c.TeacherName.ToLower() == createTeacherVM.TeacherName.ToLower()))
            {
                ModelState.AddModelError("Name", "Bu Adli Melumat Movcuddur");
                return View();
            }
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Photo", "Bos Qoyma");
                return View();
            }
            if (!createTeacherVM.Photo.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("Photo", "only image");
                return View();
            }
            if (createTeacherVM.Photo.Length / 1024 > 1000)
            {
                ModelState.AddModelError("Photo", "Olchu boyukdur");
                return View();
            }
            Teacher teacher = new();
            teacher.TeacherName = createTeacherVM.TeacherName;
            teacher.Profession = createTeacherVM.Profession;
            teacher.Degree = createTeacherVM.Degree;
            teacher.Hobbies = createTeacherVM.Hobbies;
            teacher.Experience = createTeacherVM.Experience;
            teacher.Faculty = createTeacherVM.Faculty;
            teacher.AboutDesc = createTeacherVM.AboutDesc;
            teacher.ImageUrl = createTeacherVM.Photo.SaveImage("img/teacher", _webHostEnvironment);
            TeacherContact contact = new TeacherContact();
            contact.Teacher = teacher;
            contact.Twitter = createTeacherVM.Twitter;
            contact.Vimeo = createTeacherVM.Vimeo;
            contact.Facebook = createTeacherVM.Facebook;
            contact.PhoneCall = createTeacherVM.PhoneCall;
            contact.Email = createTeacherVM.Email;
            contact.PhoneCall = createTeacherVM.PhoneCall;
            contact.Skype = createTeacherVM.Skype;
            contact.Pinterest = createTeacherVM.Pinterest;

            TeacherSkill skill = new()
            {
                Teachers = teacher,
                SkillPercentage = createTeacherVM.SkillPercantege,
                SkillName = createTeacherVM.SkillName
            };

            _appDbContext.Teachers.Add(teacher);


            _appDbContext.TeacherSkill.Add(skill);

            _appDbContext.TeacherContact.Add(contact);

            _appDbContext.SaveChanges();


            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();
            var deletedteacher = _appDbContext.Teachers.FirstOrDefault(c => c.Id == id);
            if (deletedteacher == null) return NotFound();

            _appDbContext.Teachers.Remove(deletedteacher);
            _appDbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Update(int? id)
        {
            if (id == null) return NotFound();
            var existteacher = _appDbContext.Teachers.Include(t => t.Skill).Include(t => t.Contact).FirstOrDefault(c => c.Id == id);

            if (existteacher == null) return NotFound();

            var teacherContact = _appDbContext.TeacherContact.FirstOrDefault(tc => tc.TeacherId == existteacher.Id);
            var teacherSkill = _appDbContext.TeacherSkill.FirstOrDefault(tc => tc.TeacherId == existteacher.Id);

            var updateteacherVM = new UpdateTeacherVM
            {
                TeacherName = existteacher.TeacherName,

                Profession = existteacher.Profession,
                Degree = existteacher.Degree,
                Hobbies = existteacher.Hobbies,
                Experience = existteacher.Experience,
                Faculty = existteacher.Faculty,
                AboutDesc = existteacher.Profession,

                Twitter = teacherContact.Twitter,
                Vimeo = teacherContact.Vimeo,
                Facebook = teacherContact.Facebook,
                PhoneCall = teacherContact.PhoneCall,
                Email = teacherContact.Email,
                Pinterest = teacherContact.Pinterest,
                Skype = teacherContact.Skype,

                TeacherId = existteacher.Id,

                SkillPercantege = teacherSkill.SkillPercentage,
                SkillName = teacherSkill.SkillName

            };
            return View(updateteacherVM);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Update(UpdateTeacherVM updateTeacherVM)
        {

            if (!ModelState.IsValid) return View();
            var existTeacher = _appDbContext.Teachers.Include(t => t.Skill).Include(t => t.Contact).FirstOrDefault(c => c.Id == updateTeacherVM.Id);

            if (existTeacher == null) return NotFound();

            if (_appDbContext.Teachers.Any(c => c.TeacherName == updateTeacherVM.TeacherName && c.Id != updateTeacherVM.Id))
            {
                ModelState.AddModelError("Name", "Artiq Movcuddur");
                return View();
            }
            existTeacher.TeacherName = updateTeacherVM.TeacherName;
            existTeacher.Profession = updateTeacherVM.Profession;
            existTeacher.Degree = updateTeacherVM.Degree;
            existTeacher.Hobbies = updateTeacherVM.Hobbies;
            existTeacher.Experience = updateTeacherVM.Experience;
            existTeacher.Faculty = updateTeacherVM.Faculty;
            existTeacher.AboutDesc = updateTeacherVM.AboutDesc;

            var existContact = _appDbContext.TeacherContact.FirstOrDefault(tc => tc.TeacherId == existTeacher.Id);

            existContact.Vimeo = updateTeacherVM.Vimeo;
            existContact.Twitter = updateTeacherVM.Twitter;
            existContact.Email = updateTeacherVM.Email;
            existContact.Skype = updateTeacherVM.Skype;
            existContact.Pinterest = updateTeacherVM.Pinterest;
            existContact.PhoneCall = updateTeacherVM.PhoneCall;
            existContact.Facebook = updateTeacherVM.Facebook;

            var existSkill = _appDbContext.TeacherSkill.FirstOrDefault(tc => tc.TeacherId == existTeacher.Id);

            existSkill.SkillPercentage = updateTeacherVM.SkillPercantege;
            existSkill.SkillName = updateTeacherVM.SkillName;



            if (updateTeacherVM.Photo != null)
            {

                if (!updateTeacherVM.Photo.ContentType.Contains("image/"))
                {
                    ModelState.AddModelError("Photo", "only image");
                    return View();
                }
                if (updateTeacherVM.Photo.Length / 1024 > 1000)
                {
                    ModelState.AddModelError("Photo", "Olchu boyukdur");
                    return View();
                }

                existTeacher.ImageUrl = updateTeacherVM.Photo.SaveImage("img/teacher", _webHostEnvironment);
            }


            _appDbContext.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}