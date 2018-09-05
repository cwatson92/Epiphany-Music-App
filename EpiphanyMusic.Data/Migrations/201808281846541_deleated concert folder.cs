namespace EpiphanyMusic.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleatedconcertfolder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Concert", "TourName", c => c.String());
            AddColumn("dbo.Concert", "CreatedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Concert", "ModifiedUtc", c => c.DateTimeOffset(precision: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Concert", "ModifiedUtc");
            DropColumn("dbo.Concert", "CreatedUtc");
            DropColumn("dbo.Concert", "TourName");
        }
    }
}
