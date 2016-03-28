namespace Parliament.Interact.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlteringTitletouseenum : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ActionItems", "ViewName", c => c.Int(nullable: false));
            DropColumn("dbo.ActionItems", "Title");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ActionItems", "Title", c => c.String());
            DropColumn("dbo.ActionItems", "ViewName");
        }
    }
}
