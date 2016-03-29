namespace Parliament.Interact.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedalinkerclassasrequiredbythenewcontentspecificitems : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.IssueActionItems", "Issue_Id", "dbo.Issues");
            DropForeignKey("dbo.IssueActionItems", "ActionItem_Id", "dbo.ActionItems");
            DropIndex("dbo.IssueActionItems", new[] { "Issue_Id" });
            DropIndex("dbo.IssueActionItems", new[] { "ActionItem_Id" });
            CreateTable(
                "dbo.IssueActions",
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
            
            AddColumn("dbo.ActionItems", "Issue_Id", c => c.Int());
            CreateIndex("dbo.ActionItems", "Issue_Id");
            AddForeignKey("dbo.ActionItems", "Issue_Id", "dbo.Issues", "Id");
            DropTable("dbo.IssueActionItems");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.IssueActionItems",
                c => new
                    {
                        Issue_Id = c.Int(nullable: false),
                        ActionItem_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Issue_Id, t.ActionItem_Id });
            
            DropForeignKey("dbo.IssueActions", "Issue_Id", "dbo.Issues");
            DropForeignKey("dbo.ActionItems", "Issue_Id", "dbo.Issues");
            DropForeignKey("dbo.IssueActions", "ActionItem_Id", "dbo.ActionItems");
            DropIndex("dbo.IssueActions", new[] { "Issue_Id" });
            DropIndex("dbo.IssueActions", new[] { "ActionItem_Id" });
            DropIndex("dbo.ActionItems", new[] { "Issue_Id" });
            DropColumn("dbo.ActionItems", "Issue_Id");
            DropTable("dbo.IssueActions");
            CreateIndex("dbo.IssueActionItems", "ActionItem_Id");
            CreateIndex("dbo.IssueActionItems", "Issue_Id");
            AddForeignKey("dbo.IssueActionItems", "ActionItem_Id", "dbo.ActionItems", "Id", cascadeDelete: true);
            AddForeignKey("dbo.IssueActionItems", "Issue_Id", "dbo.Issues", "Id", cascadeDelete: true);
        }
    }
}
