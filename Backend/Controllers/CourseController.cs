using Backend.DAL;
using Backend.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    public class CourseController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public IActionResult Index()
        {
            CourseVM courseVM = new CourseVM();
            courseVM.Courses = _appDbContext.Courses.Include(c => c.FuturesCourses).ToList();
            return View(courseVM);
        }
        public IActionResult CourseDetails(int? id)
        {
            var findedcourse = _appDbContext.Courses.Include(c => c.FuturesCourses).FirstOrDefault(c => c.Id == id);
            CoursePrivateVM vm = new CoursePrivateVM();
            vm.Courses = _appDbContext.Courses.ToList();
            vm.ImageUrl = findedcourse.ImageUrl;
            vm.Name = findedcourse.Name;
            vm.CourseCount = findedcourse.CourseCount;
            vm.Description = findedcourse.Description;
            vm.Start = findedcourse.FuturesCourses.Start;
            vm.Duration = findedcourse.FuturesCourses.Duration;
            vm.ClassDuration = findedcourse.FuturesCourses.ClassDuration;
            vm.SkillLevel = findedcourse.FuturesCourses.SkillLevel;
            vm.Languaa = findedcourse.FuturesCourses.Languaa;
            vm.StudentsCount = findedcourse.FuturesCourses.StudentsCount;
            vm.AssestmentsType = findedcourse.FuturesCourses.AssestmentsType;
            vm.CourseFee = findedcourse.FuturesCourses.CourseFee;
            return View();
        }
    }
}
