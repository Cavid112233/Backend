using Backend.Entities;
using Backend.Entities.SliderSection;
using Microsoft.EntityFrameworkCore;

namespace Backend.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<SLider> Sliders { get; set; }
        public DbSet<SliderContent> SliderContents { get; set; }
        public DbSet<Bio> Bios { get; set; }
    }
}
