using Backend.DAL;
using Backend.Extension;
using Backend.Entities;
using Backend.ViewModels.BlogAdmin;
using Backend.ViewModels.TeacherAdmin;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class BlogController : Controller
    {

        private readonly AppDbContext _appDbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public BlogController(AppDbContext appDbContext, IWebHostEnvironment webHostEnvironment)
        {
            _appDbContext = appDbContext;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            return View(_appDbContext.Blogs.ToList()) ;
        }
        public IActionResult Detail(int?id)
        {
            if (id == null) return NotFound();
            var existBlog = _appDbContext.Blogs.FirstOrDefault(b => b.Id == id);
            if (existBlog == null) return NotFound();
            return View(existBlog);
        }

        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(CreateBlogVM createBlogVM) 
        
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Photo", "Bos Qoyma");
                return View();
            }
            if (!createBlogVM.Photo.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("Photo", "only image");
                return View();
            }
            if (createBlogVM.Photo.Length / 1024 > 1000)
            {
                ModelState.AddModelError("Photo", "Olchu boyukdur");
                return View();
            }
            Blog blog = new();  
            blog.TitleName=createBlogVM.TitleName;
            blog.Description = createBlogVM.Description;
            blog.ImageUrl=createBlogVM.Photo.SaveImage("img/blog", _webHostEnvironment);
            _appDbContext.Blogs.Add(blog);
            _appDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();
            var deletedblog = _appDbContext.Blogs.FirstOrDefault(c => c.Id == id);
            if (deletedblog == null) return NotFound();

            _appDbContext.Blogs.Remove(deletedblog);
            _appDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Update(int?id)
        {
            if (id == null) return NotFound();
            var existblog = _appDbContext.Blogs.FirstOrDefault(c => c.Id == id);
            if (existblog == null) return NotFound();
            var updateblogVM = new UpdateBlogVM
            {
                TitleName = existblog.TitleName,
                Description = existblog.Description,

            };
            return View(updateblogVM);
             
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Update(UpdateBlogVM updateBlogVM)
        {
            if (!ModelState.IsValid) return View();
            var existblog = _appDbContext.Blogs.FirstOrDefault(c => c.Id == updateBlogVM.Id);
            if (updateBlogVM == null) return NotFound();

            existblog.TitleName=updateBlogVM.TitleName;
            existblog.Description=updateBlogVM.Description;

            if (updateBlogVM.Photo != null)
            {

                if (!updateBlogVM.Photo.ContentType.Contains("image/"))
                {
                    ModelState.AddModelError("Photo", "only image");
                    return View();
                }
                if (updateBlogVM.Photo.Length / 1024 > 1000)
                {
                    ModelState.AddModelError("Photo", "Size is High");
                    return View();
                }

                existblog.ImageUrl = updateBlogVM.Photo.SaveImage("img/blog", _webHostEnvironment);
            }

            _appDbContext.SaveChanges();
            return RedirectToAction("Index");

        }
          
           
    }
}
