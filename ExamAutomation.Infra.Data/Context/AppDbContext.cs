
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
        
    }
}