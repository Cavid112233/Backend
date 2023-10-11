namespace Backend.ViewModels.CourseAdmin
{
    public class UpdateCourseVM
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public IFormFile? Photo { get; set; }

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
    }
}
