namespace Parliament.Interact.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedDescriptiontoContentandaddedtypentext : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Issues", "Content", c => c.String(storeType: "ntext"));
            DropColumn("dbo.Issues", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Issues", "Description", c => c.String());
            DropColumn("dbo.Issues", "Content");
        }
    }
}
