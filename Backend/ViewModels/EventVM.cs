using Backend.Entities;

namespace Backend.ViewModels
{
    public class EventVM
    {
        public List<Event> Events { get; set; }

        public List<TellUs> Speakers { get; set; }

        public List<EventTellUs> EventsTellUs { get; set; }

    }
}
