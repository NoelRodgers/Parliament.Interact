namespace Parliament.Interact.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedmigrationforIssueTimeLine : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.IssueTimeLines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Timeline = c.Int(nullable: false),
                        HTMLContent = c.String(),
                        Issue_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Issues", t => t.Issue_Id)
                .Index(t => t.Issue_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IssueTimeLines", "Issue_Id", "dbo.Issues");
            DropIndex("dbo.IssueTimeLines", new[] { "Issue_Id" });
            DropTable("dbo.IssueTimeLines");
        }
    }
}
