namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_headingstatusadd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Headings", "HeadingStatus", c => c.Boolean(nullable: false));
            AddColumn("dbo.Contents", "ContentState", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contents", "ContentState");
            DropColumn("dbo.Headings", "HeadingStatus");
        }
    }
}
