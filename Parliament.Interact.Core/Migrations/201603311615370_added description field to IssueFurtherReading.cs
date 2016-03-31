namespace Parliament.Interact.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addeddescriptionfieldtoIssueFurtherReading : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.IssueFurtherReadings", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.IssueFurtherReadings", "Description");
        }
    }
}
