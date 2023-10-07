using Backend.Entities;
using Backend.ViewModels.PartAdmin;

namespace Backend.ViewModels
{
    public class CoursePrivateVM
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }

        public int CourseCount { get; set; }

        public string Start { get; set; }
        public string Duration { get; set; }

        public string ClassDuration { get; set; }

        public string SkillLevel { get; set; }

        public string Languaa { get; set; }

        public int StudentsCount { get; set; }

        public string AssestmentsType { get; set; }

        public int CourseFee { get; set; }

        public int CourseId { get; set; }

        public CommentVM CommentVM { get; set; }

        public List<Course> Courses { get; set; }
    }
}
