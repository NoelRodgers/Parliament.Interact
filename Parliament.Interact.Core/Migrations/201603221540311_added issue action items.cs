namespace Parliament.Interact.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedissueactionitems : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.IssueActionItems", "ActionItem_Id", "dbo.ActionItems");
            DropForeignKey("dbo.IssueActionItems", "Issue_Id", "dbo.Issues");
            DropIndex("dbo.IssueActionItems", new[] { "ActionItem_Id" });
            DropIndex("dbo.IssueActionItems", new[] { "Issue_Id" });
            DropPrimaryKey("dbo.IssueActionItems");
            AlterColumn("dbo.IssueActionItems", "ActionItem_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.IssueActionItems", "Issue_Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.IssueActionItems", new[] { "Issue_Id", "ActionItem_Id" });
            CreateIndex("dbo.IssueActionItems", "Issue_Id");
            CreateIndex("dbo.IssueActionItems", "ActionItem_Id");
            AddForeignKey("dbo.IssueActionItems", "ActionItem_Id", "dbo.ActionItems", "Id", cascadeDelete: true);
            AddForeignKey("dbo.IssueActionItems", "Issue_Id", "dbo.Issues", "Id", cascadeDelete: true);
            DropColumn("dbo.IssueActionItems", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.IssueActionItems", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.IssueActionItems", "Issue_Id", "dbo.Issues");
            DropForeignKey("dbo.IssueActionItems", "ActionItem_Id", "dbo.ActionItems");
            DropIndex("dbo.IssueActionItems", new[] { "ActionItem_Id" });
            DropIndex("dbo.IssueActionItems", new[] { "Issue_Id" });
            DropPrimaryKey("dbo.IssueActionItems");
            AlterColumn("dbo.IssueActionItems", "Issue_Id", c => c.Int());
            AlterColumn("dbo.IssueActionItems", "ActionItem_Id", c => c.Int());
            AddPrimaryKey("dbo.IssueActionItems", "Id");
            CreateIndex("dbo.IssueActionItems", "Issue_Id");
            CreateIndex("dbo.IssueActionItems", "ActionItem_Id");
            AddForeignKey("dbo.IssueActionItems", "Issue_Id", "dbo.Issues", "Id");
            AddForeignKey("dbo.IssueActionItems", "ActionItem_Id", "dbo.ActionItems", "Id");
        }
    }
}
