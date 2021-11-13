
using ExamAutomation.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ExamAutomation.Infra.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Exams> Exams { get; set; }
        public DbSet<Questions> Questions { get; set; }


   
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Exams>()
                .HasMany(a=>a.Questions)
                .WithOne(x=>x.Exams)
                .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);
        }
    }
}