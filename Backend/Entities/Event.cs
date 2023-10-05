using Backend.Entities;

namespace Backend.Entities
{
    public class Event 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<EventComment> EventComments { get; set; }
    }
}
