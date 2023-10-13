namespace Backend.ViewModels.TellUsAdmin
{
    public class TellUsCreateVm
    {
        public string SpeakerName { get; set; }

        public string Profession { get; set; }

        public IFormFile Photo { get; set; }
    }
}
