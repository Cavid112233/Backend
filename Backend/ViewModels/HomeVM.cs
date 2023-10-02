
using Backend.Entities.Notice;
using Backend.Entities.SliderSection;

namespace Backend.ViewModels
{
    public class HomeVM
    {
        public Dictionary<string, string> Settings { get; set; }
        public List<SliderContent> SliderContents { get; set; }
        public List<Notice> Notices { get; set; }
    }
}
