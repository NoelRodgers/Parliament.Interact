namespace Parliament.Interact.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MovedisPrimarytoIssueActionratherthanActionItem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.IssueActions", "IsPrimary", c => c.Boolean(nullable: false));
            DropColumn("dbo.ActionItems", "IsPrimary");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ActionItems", "IsPrimary", c => c.Boolean(nullable: false));
            DropColumn("dbo.IssueActions", "IsPrimary");
        }
    }
}
