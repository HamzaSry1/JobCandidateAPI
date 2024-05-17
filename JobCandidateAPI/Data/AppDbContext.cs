using JobCandidateAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace JobCandidateAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Candidate> Candidates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Candidate>().HasKey(e => e.Email);
        }
    }
}
