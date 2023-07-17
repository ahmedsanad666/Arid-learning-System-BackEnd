using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SoloLearning.Models;

namespace SoloLearning.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {
            
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseChapter> CourseChapters { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Slide> Slides { get; set; }
        public DbSet<Question> Question { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);



        }




    }
}
