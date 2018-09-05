namespace EpiphanyMusic.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adddatabase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Concert", "OwnerId", c => c.Guid(nullable: false));
            AddColumn("dbo.Concert", "City", c => c.String(nullable: false));
            AddColumn("dbo.Concert", "State", c => c.String(nullable: false));
            AlterColumn("dbo.Concert", "Artist", c => c.String(nullable: false));
            DropColumn("dbo.Concert", "Location");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Concert", "Location", c => c.String());
            AlterColumn("dbo.Concert", "Artist", c => c.String());
            DropColumn("dbo.Concert", "State");
            DropColumn("dbo.Concert", "City");
            DropColumn("dbo.Concert", "OwnerId");
        }
    }
}
