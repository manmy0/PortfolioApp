using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PortfolioApp.Models;

namespace PortfolioApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        private readonly DbContextOptions _options;

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            _options = options;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
        public DbSet<Cdl> Cdl { get; set; } = default!;
        public DbSet<CareerDevelopmentPlan> CareerDevelopmentPlan { get; set; } = default!;
        public DbSet<Competency> Competency { get; set; } = default!;
        public DbSet<CompetencyTracker> CompetencyTracker { get; set; } = default!;
        public DbSet<ContactsOfInterest> ContactsOfInterest { get; set; } = default!;
        public DbSet<Goal> Goal { get; set; } = default!;
        public DbSet<GoalStep> GoalStep { get; set; } = default!;
        public DbSet<IndustryContactInfo> IndustryContactInfo { get; set; } = default!;
        public DbSet<IndustryContactLog> IndustryContactLog { get; set; } = default!;
        public DbSet<NetworkingEvent> NetworkingEvent { get; set; } = default!;
        public DbSet<NetworkingQuestion> NetworkingQuestion { get; set; } = default!;
        public DbSet<UserLink> UserLink { get; set; } = default!;

    }
}
