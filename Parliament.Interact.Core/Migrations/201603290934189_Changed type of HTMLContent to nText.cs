namespace Parliament.Interact.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedtypeofHTMLContenttonText : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.IssueTimeLines", "HTMLContent", c => c.String(storeType: "ntext"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.IssueTimeLines", "HTMLContent", c => c.String());
        }
    }
}
