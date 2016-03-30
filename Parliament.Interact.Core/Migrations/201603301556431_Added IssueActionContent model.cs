namespace Parliament.Interact.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedIssueActionContentmodel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.IssueActionContents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(storeType: "ntext"),
                        Key = c.String(),
                        IssueAction_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.IssueActions", t => t.IssueAction_Id)
                .Index(t => t.IssueAction_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IssueActionContents", "IssueAction_Id", "dbo.IssueActions");
            DropIndex("dbo.IssueActionContents", new[] { "IssueAction_Id" });
            DropTable("dbo.IssueActionContents");
        }
    }
}
