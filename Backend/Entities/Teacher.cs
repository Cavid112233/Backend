using Backend.Entities;

namespace Backend.Entities
{
    public class Teacher
    {
        public int Id { get; set; }
        public string TeacherName { get; set; }

        public string Profession { get; set; }

        public string AboutDesc { get; set; }

        public string ImageUrl { get; set; }

        public string Degree { get; set; }

        public string Experience { get; set; }

        public string Hobbies { get; set; }

        public string Faculty { get; set; }
        public List<TeacherSkill> Skill {  get; set; }  

        public List<TeacherContact> Contact { get; set;}



    }
}
