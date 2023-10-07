using Backend.Entities;
using Backend.ViewModels.PartAdmin;

namespace Backend.ViewModels
{
    public class BlogPrivateVM
    {
        public string TitleName { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }


        public BlogComment BlogComment { get; set; }
        public List<Course> courses { get; set; }
        public CommentVM CommentVM { get; set; }
    }
}
