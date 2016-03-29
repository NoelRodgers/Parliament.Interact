using System.Data.Entity;

namespace Parliament.Interact.Core.Domain.Context
{
    public class InteractDbContext : DbContext
    {
        public DbSet<Issue> Issues { get; set; }
        public DbSet<ActionItem> ActionItems { get; set; } 
        public DbSet<IssueTimeLine> IssueTimeLines { get; set; }
    }
}