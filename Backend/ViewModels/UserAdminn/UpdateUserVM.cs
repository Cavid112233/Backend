using System.ComponentModel.DataAnnotations;

namespace Backend.ViewModels.UserAdminn
{
    public class UpdateUserVM
    {
        public string Id { get; set; }

        [StringLength(100)]
        public string FullName { get; set; }
        [StringLength(100)]
        public string UserName { get; set; }
        [EmailAddress, DataType(DataType.EmailAddress)]
        public string Email { get; set; }


    }
}
