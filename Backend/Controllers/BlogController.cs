using Backend.DAL;
using Backend.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    public class BlogController : Controller
    {
        private readonly AppDbContext _context;

        public BlogController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            BlogVM blogvm = new BlogVM();
            blogvm.Blogs = _context.Blogs.ToList();

            return View(blogvm);
        }
        public IActionResult BlogDetails(int id)
        {
            var findedBlog = _context.Blogs.FirstOrDefault(c => c.Id == id);
            BlogPrivateVM blogPrivateVM = new();

            blogPrivateVM.courses = _context.Courses.ToList();
            blogPrivateVM.ImageUrl = findedBlog.ImageUrl;
            blogPrivateVM.TitleName = findedBlog.TitleName;
            blogPrivateVM.Description = findedBlog.Description;
            return View(blogPrivateVM);
        }
    }
}
