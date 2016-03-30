namespace Parliament.Interact.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedActionContentModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ActionContents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(storeType: "ntext"),
                        Key = c.String(),
                        ActionItem_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ActionItems", t => t.ActionItem_Id)
                .Index(t => t.ActionItem_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ActionContents", "ActionItem_Id", "dbo.ActionItems");
            DropIndex("dbo.ActionContents", new[] { "ActionItem_Id" });
            DropTable("dbo.ActionContents");
        }
    }
}
