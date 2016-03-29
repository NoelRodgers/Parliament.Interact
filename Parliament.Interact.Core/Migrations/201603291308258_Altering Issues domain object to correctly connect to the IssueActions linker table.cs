namespace Parliament.Interact.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlteringIssuesdomainobjecttocorrectlyconnecttotheIssueActionslinkertable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ActionItems", "Issue_Id", "dbo.Issues");
            DropIndex("dbo.ActionItems", new[] { "Issue_Id" });
            DropColumn("dbo.ActionItems", "Issue_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ActionItems", "Issue_Id", c => c.Int());
            CreateIndex("dbo.ActionItems", "Issue_Id");
            AddForeignKey("dbo.ActionItems", "Issue_Id", "dbo.Issues", "Id");
        }
    }
}
