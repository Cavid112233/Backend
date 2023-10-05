using System.ComponentModel.DataAnnotations;

namespace Backend.ViewModels.PartAdmin
{
    public class CommentVM
    {
        public int ID { get; set; }
        public string Name { get; set; }

        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Subject { get; set; }

        public string Massage { get; set; }
    }
}
