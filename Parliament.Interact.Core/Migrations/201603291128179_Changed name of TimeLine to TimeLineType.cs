namespace Parliament.Interact.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangednameofTimeLinetoTimeLineType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.IssueTimeLines", "TimelineType", c => c.Int(nullable: false));
            DropColumn("dbo.IssueTimeLines", "Timeline");
        }
        
        public override void Down()
        {
            AddColumn("dbo.IssueTimeLines", "Timeline", c => c.Int(nullable: false));
            DropColumn("dbo.IssueTimeLines", "TimelineType");
        }
    }
}
