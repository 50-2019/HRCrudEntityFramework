using HrCRUDWebApp.Models;
using Microsoft.EntityFrameworkCore;
namespace HrCRUDWebApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Candidate> Candidates { get; set; }
		public DbSet<Skill> Skills  { get; set; }
       public DbSet<CandidateSkill> CandidatesSkill { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CandidateSkill>().HasKey(cs => new { cs.CandidateId, cs.SkillId });
            modelBuilder.Entity<CandidateSkill>().HasOne(c => c.Candidate).
                WithMany(s => s.CandidateSkill).HasForeignKey(s => s.CandidateId);
			modelBuilder.Entity<CandidateSkill>().HasOne(c => c.Skill).
				WithMany(s => s.CandidateSkill).HasForeignKey(s => s.SkillId);
		}
	}
}

