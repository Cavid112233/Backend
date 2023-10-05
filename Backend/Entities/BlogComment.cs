using Backend.Entities;
using System.ComponentModel.DataAnnotations;

namespace Backend.Entities
{
    public class BlogComment 
    {
        public int Id { get; set; }
        public string Name {  get; set; }

        [Required,  DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Subject { get; set; }

        public string Massage { get; set; }

        public int BlogId { get; set; }

        public Blog Blog { get; set; }

        

    }
}
