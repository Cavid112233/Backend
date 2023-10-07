using Backend.Entities;

namespace Backend.ViewModels
{
    public class TeacherPrivateVM
    {
        public string TeacherName { get; set; }

        public string Profession { get; set; }

        public string AboutDesc { get; set; }

        public string ImageUrl { get; set; }

        public string Degree { get; set; }

        public string Experience { get; set; }

        public string Hobbies { get; set; }

        public string Faculty { get; set; }
  

        public ContactVM ContactVM { get; set; }

        public List<Teacher> teachers { get; set; }

        public List<TeacherSkill> skills { get; set; }

        public List<TeacherContact> contacts { get; set; }

    }

    public class ContactVM
    {
        public ContactVM(string eMail, string phoneCall, string skype, string facebook, string pinterest, string vimeo, string twitter)
        {
            EMail = eMail;
            PhoneCall = phoneCall;
            Skype = skype;
            Facebook = facebook;
            Pinterest = pinterest;
            Vimeo = vimeo;
            Twitter = twitter;
        }

        public string EMail { get; set; }
        public string PhoneCall { get; set; }
        public string Skype { get; set; }

        public string Facebook { get; set; }
        public string Pinterest { get; set; }

        public string Vimeo { get; set; }

        public string Twitter { get; set; }
    }

}
