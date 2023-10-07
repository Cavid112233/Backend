using Backend.Entities;

namespace Backend.Entities
{
    public class Event 
    {
        public int Id { get; set; }
        public string EventName { get; set; }

        public DateTime DateStart { get; set; }

        public DateTime DateEnd { get; set; }
        public string ImageUrl { get; set; }

        public string Venue {  get; set; }

        public string ExactDate { get; set; }

        public string Description { get; set; }

        public List<EventTellUs> EventTellUses { get; set; }
        public List<EventComment> EventComments { get; set; }
    }
}
