using Backend.DAL;
using Backend.Extension;
using Backend.Entities;
using Backend.ViewModels.AdminTeacher;
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
            var existteacher = _appDbContext.Teachers.Include(t => t.Skill).Include(t => t.Contact).ToList();
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
            teacher.ImageUrl = createTeacherVM.Photo.SaveImage("img", _webHostEnvironment);
            TeacherContact contact = new TeacherContact();
            contact.Teacher = teacher;
            contact.Twitter = createTeacherVM.Twitter;
            contact.Vimeo = createTeacherVM.Vimeo;
            contact.Facebook = createTeacherVM.Facebook;
            contact.PhoneCall = createTeacherVM.PhoneCall;
            contact.EMail = createTeacherVM.EMail;
            contact.PhoneCall = createTeacherVM.PhoneCall;
            contact.Skype = createTeacherVM.Skype;
            contact.Pinterest = createTeacherVM.Pinterest;
          
            TeacherSkill skill = new TeacherSkill();
            skill.Teachers = teacher;
            skill.SkillPercantege = createTeacherVM.SkillPercantege;
            skill.SkillName = createTeacherVM.SkillName;
           
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
            var updateteacherVM = new UpdateTeacherVM
            {
                TeacherName = existteacher.TeacherName,

                Profession = existteacher.Profession,
                Degree = existteacher.Degree,
                Hobbies = existteacher.Hobbies,
                Experience = existteacher.Experience,
                Faculty = existteacher.Faculty,
                AboutDesc = existteacher.Profession,

                Twitter = existteacher.Contact.FirstOrDefault().Twitter,
                Vimeo = existteacher.Contact.FirstOrDefault().Vimeo,
                Facebook = existteacher.Contact.FirstOrDefault().Facebook,
                PhoneCall = existteacher.Contact.FirstOrDefault().PhoneCall,
                EMail = existteacher.Contact.FirstOrDefault().EMail,
                Pinterest = existteacher.Contact.FirstOrDefault().Pinterest,
                Skype = existteacher.Contact.FirstOrDefault().Skype,

                TeacherId = existteacher.Contact.FirstOrDefault().TeacherId,

                SkillPercantege = existteacher.Skill.FirstOrDefault().SkillPercantege,
                SkillName = existteacher.Skill.FirstOrDefault().SkillName


            };
            return View(updateteacherVM);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Update(UpdateTeacherVM updateTeacherVM)
        {

            if (!ModelState.IsValid) return View();
            var existteachert = _appDbContext.Teachers.Include(t => t.Skill).Include(t => t.Contact).FirstOrDefault(c => c.Id == updateTeacherVM.Id);


            if (_appDbContext.Teachers.Any(c => c.TeacherName == updateTeacherVM.TeacherName && c.Id != updateTeacherVM.Id))
            {
                ModelState.AddModelError("Name", "Artiq Movcuddur");
                return View();
            }
            Teacher teacher = new();
            teacher.TeacherName = updateTeacherVM.TeacherName;
            teacher.Profession = updateTeacherVM.Profession;
            teacher.Degree = updateTeacherVM.Degree;
            teacher.Hobbies = updateTeacherVM.Hobbies;
            teacher.Experience = updateTeacherVM.Experience;
            teacher.Faculty = updateTeacherVM.Faculty;
            teacher.AboutDesc = updateTeacherVM.AboutDesc;

            TeacherContact contact = new TeacherContact();
            contact.Twitter = updateTeacherVM.Twitter;
            contact.Vimeo = updateTeacherVM.Vimeo;
            contact.Facebook = updateTeacherVM.Facebook;
            contact.PhoneCall = updateTeacherVM.PhoneCall;
            contact.EMail = updateTeacherVM.EMail;
            contact.PhoneCall = updateTeacherVM.PhoneCall;
            contact.Skype = updateTeacherVM.Skype;
            contact.Pinterest = updateTeacherVM.Pinterest;
            contact.Teacher = teacher;
            TeacherSkill skill = new TeacherSkill();
            skill.SkillPercantege = updateTeacherVM.SkillPercantege;
            skill.SkillName = updateTeacherVM.SkillName;
            skill.Teachers = teacher;
            if (!ModelState.IsValid) return NotFound();

            var existsteacher = _appDbContext.Sliders.FirstOrDefault(c => c.Id == updateTeacherVM.Id);

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

            existsteacher.Id = updateTeacherVM.Id;
            existsteacher.ImageUrl = updateTeacherVM.Photo.SaveImage("img", _webHostEnvironment);

            _appDbContext.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}