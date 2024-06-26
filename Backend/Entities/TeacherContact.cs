﻿using Backend.Entities;

namespace Backend.Entities
{
    public class TeacherContact
    {
        public int Id { get; set; }
        public string Email {  get; set; }
        public string PhoneCall { get; set; }
        public string Skype { get; set; }

        public string Facebook { get; set; }
        public string Pinterest { get; set; }

        public string Vimeo { get; set; }

        public string Twitter { get; set; }

        public int TeacherId { get; set; }

        public Teacher Teacher { get; set; }
    }
}
