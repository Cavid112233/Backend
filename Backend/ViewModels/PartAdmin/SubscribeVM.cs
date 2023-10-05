using System.ComponentModel.DataAnnotations;

namespace Backend.ViewModels.PartAdmin
{
    public class SubscribeVM
    {
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
