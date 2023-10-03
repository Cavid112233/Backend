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
        public DbSet<ChooseArea> ChooseAreas { get; set; }
        public DbSet<Setting> Setting { get; set; }
    }
}
