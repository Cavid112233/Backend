using System.ComponentModel.DataAnnotations;

namespace Backend.Entities
{
    public class Subscribe
    {
        public int Id { get; set; }
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
