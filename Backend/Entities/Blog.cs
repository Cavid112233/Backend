using Backend.Entities;

namespace Backend.Entities
{
    public class Blog 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<BlogComment> BlogComments { get; set; }
        
    }
}
