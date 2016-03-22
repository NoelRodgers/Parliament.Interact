namespace Parliament.Interact.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedforeignkeyrelationshipbetweenissueandactionItem : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.IssueActionItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ActionItem_Id = c.Int(),
                        Issue_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ActionItems", t => t.ActionItem_Id)
                .ForeignKey("dbo.Issues", t => t.Issue_Id)
                .Index(t => t.ActionItem_Id)
                .Index(t => t.Issue_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IssueActionItems", "Issue_Id", "dbo.Issues");
            DropForeignKey("dbo.IssueActionItems", "ActionItem_Id", "dbo.ActionItems");
            DropIndex("dbo.IssueActionItems", new[] { "Issue_Id" });
            DropIndex("dbo.IssueActionItems", new[] { "ActionItem_Id" });
            DropTable("dbo.IssueActionItems");
        }
    }
}
