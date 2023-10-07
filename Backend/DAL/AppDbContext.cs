using Backend.Entities;
using Backend.Entities.ChooseArea;
using Backend.Entities.SliderSection;
using Microsoft.EntityFrameworkCore;

namespace Backend.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<SliderContent> SliderContents { get; set; }
        public DbSet<ChooseArea> ChooseArea { get; set; }
        public DbSet<Setting> Setting { get; set; }
        public DbSet<SliderTestimonial> SliderTestimonial { get; set; }
        public DbSet<AboutBanner> AboutBanner { get; set; }
        public DbSet<Subscribe> Subscriptions { get; set; }

        public DbSet<AboutVideo> AboutVideo { get; set; }
        public DbSet<Blog> Blogs { get; set; }

        public DbSet<BlogComment> BlogsComment { get; set; }
        public DbSet<Course> Courses { get; set; }

        public DbSet<CourseComment> CourseComments { get; set; }
        public DbSet<Event> Events { get; set; }

        public DbSet<EventComment> EventComments { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<TeacherSkill> TeacherSkill { get; set; }

        public DbSet<TeacherContact> TeacherContact { get; set; }
        public DbSet<FuturesCourse> FuturesCourses { get; set; }
    }
}
