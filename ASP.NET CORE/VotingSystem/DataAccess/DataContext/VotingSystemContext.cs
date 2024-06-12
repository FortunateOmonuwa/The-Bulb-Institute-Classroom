using Microsoft.EntityFrameworkCore;
using VotingSystem.Domain.Models;

namespace VotingSystem.DataAccess.DataContext
{
    public class VotingSystemContext : DbContext
    {
        public VotingSystemContext(DbContextOptions options) : base(options) { }


        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Voter> Voters { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Vote> Votes { get; set; }
    }
}
