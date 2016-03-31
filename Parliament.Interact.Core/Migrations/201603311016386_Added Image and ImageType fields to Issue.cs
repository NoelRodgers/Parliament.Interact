namespace Parliament.Interact.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedImageandImageTypefieldstoIssue : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Issues", "Image", c => c.Binary());
            AddColumn("dbo.Issues", "ImageType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Issues", "ImageType");
            DropColumn("dbo.Issues", "Image");
        }
    }
}
