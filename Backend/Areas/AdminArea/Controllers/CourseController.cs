using Backend.DAL;
using Backend.Extension;
using Backend.Entities;
using Backend.ViewModels.CourseAdmin;
using Backend.ViewModels.TeacherAdmin;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class CourseController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CourseController(AppDbContext appDbContext, IWebHostEnvironment webHostEnvironment)
        {
            _appDbContext = appDbContext;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            return View(_appDbContext.Courses.ToList());
        }

        public IActionResult Detail(int ?id)
        {
            if (id == null) return NotFound();
            var existcourse = _appDbContext.Courses.Include(t => t.FuturesCourses).FirstOrDefault();
            if (existcourse == null) return NotFound();
            return View(existcourse);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(CreateCourseVM createCourseVM)
        {
            if (_appDbContext.Courses.Any(c => c.Name.ToLower() == createCourseVM.Name.ToLower()))
            {
                ModelState.AddModelError("Name", "Bu Adli Melumat Movcuddur");
                return View();
            }
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Photo", "Bos Qoyma");
                return View();
            }
            if (!createCourseVM.Photo.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("Photo", "only image");
                return View();
            }
            if (createCourseVM.Photo.Length / 1024 > 1000)
            {
                ModelState.AddModelError("Photo", "Olchu boyukdur");
                return View();
            }
            Course course = new Course();
            course.Name = createCourseVM.Name;
            course.Description = createCourseVM.Description;
            course.CourseCount = createCourseVM.CourseCount;
            course.ImageUrl = createCourseVM.Photo.SaveImage("img/course", _webHostEnvironment);
            FuturesCourse features = new FuturesCourse();
            features.Duration = createCourseVM.Duration;
            features.ClassDuration = createCourseVM.ClassDuration;
            features.Languaa = createCourseVM.Languaa;
            features.Start = createCourseVM.Start;
            features.StudentsCount = createCourseVM.StudentsCount;
            features.AssestmentsType = createCourseVM.AssestmentsType;
            features.CourseFee = createCourseVM.CourseFee;
            features.SkillLevel = createCourseVM.SkillLevel;
            features.Course = course;
            _appDbContext.Courses.Add(course);

            _appDbContext.FuturesCourses.Add(features);
            _appDbContext.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();
            var deletedcourse = _appDbContext.Courses.FirstOrDefault(c => c.Id == id);
            if (deletedcourse == null) return NotFound();

            _appDbContext.Courses.Remove(deletedcourse);
            _appDbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int? id)
        {
            if (id == null) return NotFound();
            var existcourse = _appDbContext.Courses.Include(c => c.FuturesCourses).FirstOrDefault(c => c.Id == id);

            if (existcourse == null) return NotFound();

            var courseFeature = _appDbContext.FuturesCourses.FirstOrDefault(tc => tc.CourseId == existcourse.Id);


            var updatecourseVM = new UpdateCourseVM
            {
                Name = existcourse.Name,

                Description = existcourse.Description,
                CourseCount = existcourse.CourseCount,
                Duration = courseFeature.Duration,
                ClassDuration = courseFeature.ClassDuration,
                AssestmentsType = courseFeature.AssestmentsType,
                StudentsCount = courseFeature.StudentsCount,
                Start = courseFeature.Start,
                Languaa = courseFeature.Languaa,
                CourseFee = courseFeature.CourseFee,
                SkillLevel = courseFeature.SkillLevel,
                CourseId = existcourse.Id

            };
            return View(updatecourseVM);
        }


        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Update(UpdateCourseVM updateCourseVM)
        {
            if (!ModelState.IsValid) return View();
            var existcourse = _appDbContext.Courses.Include(c => c.FuturesCourses).FirstOrDefault(c => c.Id == updateCourseVM.Id);

            if (existcourse == null) return NotFound();

            if (_appDbContext.Courses.Any(c => c.Name == updateCourseVM.Name && c.Id != updateCourseVM.Id))
            {
                ModelState.AddModelError("Name", "Artiq Movcuddur");
                return View();
            }
            existcourse.Name = updateCourseVM.Name;
            existcourse.Description = updateCourseVM.Description;
            existcourse.CourseCount = updateCourseVM.CourseCount;

            var existfeature = _appDbContext.FuturesCourses.FirstOrDefault(tc => tc.CourseId == existcourse.Id);
            existfeature.Duration = updateCourseVM.Duration;
            existfeature.ClassDuration = updateCourseVM.ClassDuration;
            existfeature.AssestmentsType = updateCourseVM.AssestmentsType;
            existfeature.SkillLevel = updateCourseVM.SkillLevel;
            existfeature.Start = updateCourseVM.Start;
            existfeature.Languaa = updateCourseVM.Languaa;
            existfeature.CourseFee = updateCourseVM.CourseFee;
            existfeature.StudentsCount = updateCourseVM.StudentsCount;

            if (updateCourseVM.Photo != null)
            {

                if (!updateCourseVM.Photo.ContentType.Contains("image/"))
                {
                    ModelState.AddModelError("Photo", "only image");
                    return View();
                }
                if (updateCourseVM.Photo.Length / 1024 > 1000)
                {
                    ModelState.AddModelError("Photo", "Olchu boyukdur");
                    return View();
                }

                existcourse.ImageUrl = updateCourseVM.Photo.SaveImage("img/course", _webHostEnvironment);


            }
            _appDbContext.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
