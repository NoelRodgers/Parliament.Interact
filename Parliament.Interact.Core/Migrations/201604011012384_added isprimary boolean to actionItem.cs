namespace Parliament.Interact.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedisprimarybooleantoactionItem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ActionItems", "IsPrimary", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ActionItems", "IsPrimary");
        }
    }
}
