namespace Parliament.Interact.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addingthependingchanges : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.IssueFurtherReadings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LinkName = c.String(),
                        LinkUrl = c.String(),
                        DisplayExternalIcon = c.Boolean(nullable: false),
                        Issue_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Issues", t => t.Issue_Id)
                .Index(t => t.Issue_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IssueFurtherReadings", "Issue_Id", "dbo.Issues");
            DropIndex("dbo.IssueFurtherReadings", new[] { "Issue_Id" });
            DropTable("dbo.IssueFurtherReadings");
        }
    }
}
