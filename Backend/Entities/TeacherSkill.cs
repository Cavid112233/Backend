using Backend.Entities;

namespace Backend.Entities
{
    public class TeacherSkill
    {
        public int Id { get; set; }
        public string SkillName { get; set; }

        public int SkillPercentage { get; set; }

        public int TeacherId { get; set; }

        public Teacher Teachers { get; set; }
    }
}
