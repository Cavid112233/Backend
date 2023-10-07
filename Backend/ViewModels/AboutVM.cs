using Backend.Entities;

namespace Backend.ViewModels
{
    public class AboutVM
    {
        public SliderTestimonial SliderTestimonial { get; set; }

        public AboutVideo AboutVideo { get; set; }
        public AboutBanner AboutBanner { get; set; }
        public List<Teacher> Teachers { get; set; }

        public List<Event> Events { get; set; }
    }
}
