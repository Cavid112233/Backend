using Microsoft.AspNetCore.Identity;

namespace Backend.Entities
{
    public class AppUser:IdentityUser
    {
        public string FullName { get; set; }
    }
}
