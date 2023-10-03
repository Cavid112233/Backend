
using Backend.Entities.ChooseArea;
using Backend.Entities.Notice;
using Backend.Entities.SliderSection;

namespace Backend.ViewModels
{
    public class HomeVM
    {
        public List<SliderContent> SliderContents { get; set; }
        public List<Notice> Notices { get; set; }
        public List<ChooseArea> ChooseAreas { get; set; }
    }
}
