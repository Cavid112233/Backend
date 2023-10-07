using Backend.Entities;
using Backend.ViewModels.PartAdmin;

namespace Backend.ViewModels
{
    public class EventPrivateVM
    {
        public string EventName { get; set; }

        public string ImageUrl { get; set; }

        public string Venue { get; set; }

        public string ExactDate { get; set; }

        public string Description { get; set; }

        public DateTime DateStart { get; set; }

        public DateTime DateEnd { get; set; }

        public List<TellUs> TellUses { get; set; }

        public List<Course> Courses { get; set; }
        public CommentVM Comment { get; set; }
    }
}
