
using Backend.Entities;
using Backend.Entities.ChooseArea;
using Backend.Entities.SliderSection;
using Backend.ViewModels.PartAdmin;

namespace Backend.ViewModels
{
    public class HomeVM
    {
        public List<SliderContent> SliderContents { get; set; }
        public ChooseArea ChooseArea { get; set; }
        public Dictionary<string, string> Setting { get; set; }
        public SliderTestimonial SliderTestimonial { get; internal set; }
        public SubscribeVM? SubscribeVM { get; set; }

        public List<Event> Events { get; set; }

        public List<Blog> Blogs { get; set; }
        public List<Course> Courses { get; set; }
        public CommentVM? CommentVM { get; set; }
    }
}
