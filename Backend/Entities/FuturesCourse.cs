namespace Backend.Entities
{
    public class FuturesCourse
    {
        public int Id { get; set; }
        public string Start { get; set; }
        public string Duration { get; set; }

        public string ClassDuration { get; set; }

        public string SkillLevel { get; set; } 

        public string Languaa { get; set; }

        public int StudentsCount { get; set; }

        public string AssestmentsType { get; set; }

        public int CourseFee { get; set; }

        public int CourseId { get; set; }

        public Course Course { get; set; }
    }
}
