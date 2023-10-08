using Backend.Entities;
using Backend.ViewModels.PartAdmin;

namespace Backend.ViewModels
{
    public class CourseVM
    {
        public CommentVM Comment { get; set; }
        public List<Course> Courses { get; set; }
    }
}
