using Backend.Entities;

namespace Backend.Entities
{
    public class Course 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<CourseComment> CourseComments { get; set;}
       
    }
}
