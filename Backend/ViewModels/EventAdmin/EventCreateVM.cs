namespace Backend.ViewModels.EventAdmin
{
    public class EventCreateVM
    {
        public string EventName { get; set; }


        public DateTime DateStart { get; set; }

        public DateTime DateEnd { get; set; }


        public string Venue { get; set; }

        public string ExactDate { get; set; }

        public string Description { get; set; }

        public IFormFile? Photo { get; set; }

        public List<int> SpeakersIds { get; set; }
    }
}
