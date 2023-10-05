using Backend.DAL;
using Backend.Entities;
using Backend.ViewModels;
using Backend.ViewModels.PartAdmin;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    public class PartialController : Controller
    {
        private readonly AppDbContext _context;
        public PartialController(AppDbContext context)
        {
            _context = context;
        }


        public IActionResult Comment()
        {

            return View();


        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult BlogComment(CommentVM commentVM)
        {
            if (!ModelState.IsValid)
            {

            }

            if(_context.Blogs.Any(b => b.Id == commentVM.ID))
            {
                return RedirectToAction("Index");
            }

            BlogComment comment = new();
            comment.BlogId = commentVM.ID;
            comment.Name = commentVM.Name;
            comment.Email = commentVM.Email;
            comment.Subject = commentVM.Subject;
            comment.Massage = commentVM.Massage;
           _context.BlogsComment.Add(comment);
            _context.SaveChanges();
            return RedirectToAction("blogdetails","blog");

        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult CourseComment(CommentVM commentVM )
        {

            CourseComment comment = new();
            comment.CourseId = commentVM.ID;
            comment.Name = commentVM.Name;
            comment.Email = commentVM.Email;
            comment.Subject = commentVM.Subject;
            comment.Massage = commentVM.Massage;
            _context.CourseComments.Add(comment);
            _context.SaveChanges();
            return RedirectToAction("blogdetails", "blog");

        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult EventComment(CommentVM commentVM)
        {

            EventComment comment = new();
            comment.EventId = commentVM.ID;
            comment.Name = commentVM.Name;
            comment.Email = commentVM.Email;
            comment.Subject = commentVM.Subject;
            comment.Massage = commentVM.Massage;
            _context.EventComments.Add(comment);
            _context.SaveChanges();
            return RedirectToAction("blogdetails", "blog");

        }


        public IActionResult Subscribe()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Subscribe(SubscribeVM subscribeVM)
        {
            
            Subscribe subscribe = new();
            subscribe.Email = subscribeVM.Email;
            _context.Subscriptions.Add(subscribe);
            _context.SaveChanges();
            return RedirectToAction("blogdetails", "blog");
        }
    }
}
