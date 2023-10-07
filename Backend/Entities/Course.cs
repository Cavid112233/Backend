using Backend.Entities;

namespace Backend.Entities
{
    public class Course 
    {
        public int Id { get; set; }
        public int Name { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }

        public int CourseCount { get; set; }

        public FuturesCourse CourseFeatures { get; set; }
        public List<CourseComment> CourseComments { get; set; }

    }
}
