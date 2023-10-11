using System.ComponentModel.DataAnnotations;

namespace Backend.ViewModels.TeacherAdmin
{
    public class UpdateTeacherVM
    {
        public int Id { get; set; }
        public string TeacherName { get; set; }
        public string Profession { get; set; }

        public string Degree { get; set; }

        public string Experience { get; set; }

        public string AboutDesc { get; set; }
        public string Hobbies { get; set; }

        public string Faculty { get; set; }
        public string SkillName { get; set; }

        public string SkillPercantege { get; set; }

        public string Email { get; set; }
        public string PhoneCall { get; set; }
        public string Skype { get; set; }

        public string Facebook { get; set; }
        public string Pinterest { get; set; }

        public string Vimeo { get; set; }

        public string Twitter { get; set; }

        public int TeacherId { get; set; }
        public IFormFile? Photo { get; set; }
    }
}
