using Backend.Entities;
using Backend.ViewModels.PartAdmin;

namespace Backend.ViewModels
{
    public class BlogVM
    {
        public int Id { get; set; }
        public List<Course> Courses { get; set; }
        public CourseVM CourseVM { get; set; }
        public List<Blog> Blogs { get; set; }
        public CommentVM CommentVM { get; set; }
    }
}
