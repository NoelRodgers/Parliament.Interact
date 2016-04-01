namespace Parliament.Interact.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedlogicalorderpropertytoissueAction : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.IssueActions", "LogicalOrder", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.IssueActions", "LogicalOrder");
        }
    }
}
