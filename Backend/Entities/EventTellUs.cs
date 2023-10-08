namespace Backend.Entities
{
    public class EventTellUs
    {
        public int Id { get; set; }
        public int EventId { get; set; }

        public Event Event { get; set; }

        public int SpeakersId { get; set; }

        public TellUs TellUs { get; set; }
    }
}
