namespace Parliament.Interact.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mergemigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Issues", "ImageType", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Issues", "ImageType", c => c.String());
        }
    }
}
