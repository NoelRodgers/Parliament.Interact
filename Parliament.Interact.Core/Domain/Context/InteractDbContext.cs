using System.Data.Entity;

namespace Parliament.Interact.Core.Domain.Context
{
    public class InteractDbContext : DbContext
    {
        public DbSet<Issue> Issues { get; set; }
        public DbSet<ActionItem> ActionItems { get; set; } 
        public DbSet<IssueTimeLine> IssueTimeLines { get; set; }
        public DbSet<IssueFurtherReading> FurtherReadings { get; set; }

        public DbSet<IssueAction> IssueActions { get; set; }
        public DbSet<ActionContent> ActionContents { get; set; } 
        public DbSet<IssueActionContent> IssueActionContents { get; set; } 
    }
}