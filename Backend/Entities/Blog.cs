namespace Backend.Entities
{
    public class Blog
    {
        public int Id { get; set; }
        public string TitleName { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }
        
        public List<Course> courses { get; set; }
        // public List<BlogComment> BlogComments { get; set; }
    }
}
