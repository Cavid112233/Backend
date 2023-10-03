
using Backend.Entities.ChooseArea;
using Backend.Entities.SliderSection;

namespace Backend.ViewModels
{
    public class HomeVM
    {
        public List<SliderContent> SliderContents { get; set; }
        public ChooseArea ChooseArea { get; set; }   
        public Dictionary<string, string> Setting { get; set; }
    }
}
