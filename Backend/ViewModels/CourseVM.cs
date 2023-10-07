using Backend.Entities;
using Backend.ViewModels.PartAdmin;

namespace Backend.ViewModels
{
    public class CourseVM
    {
        public int Id { get; set; }
        public CommentVM Comment { get; set; }
        public List<Course> Courses { get; set; }
    }
}
