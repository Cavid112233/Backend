using Backend.Entities;
using Microsoft.AspNetCore.Identity;

namespace Backend.ViewModels.RoleAdminn
{
    public class UpdateRoleVM
    {
        public List<IdentityRole> Roles { get; set; }

        public IList<string> UserRoles { get; set; }

        public AppUser User { get; set; }
    }
}
