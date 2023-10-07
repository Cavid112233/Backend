namespace Backend.Entities
{
    public class TellUs
    {
        public int Id { get; set; }
        public string SpeakerName { get; set; }

        public string Profession { get; set; }

        public string ImageUrl { get; set; }

        public List<EventTellUs> EventTellUses { get; set; }
    }
}
