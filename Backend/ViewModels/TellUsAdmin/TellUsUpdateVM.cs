namespace Backend.ViewModels.TellUsAdmin
{
    public class TellUsUpdateVM
    {
        public int Id { get; set; }

        public string SpeakerName { get; set; }

        public string Profession { get; set; }
        public IFormFile? Photo { get; set; }
    }
}
