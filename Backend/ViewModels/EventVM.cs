using Backend.Entities;

namespace Backend.ViewModels
{
    public class EventVM
    {
        public List<Event> Events { get; set; }

        public List<Speakers> Speakers { get; set; }

        public List<EventSpeaker> EventsSpeaker { get; set; }

    }
}
