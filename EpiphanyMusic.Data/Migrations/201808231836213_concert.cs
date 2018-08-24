namespace EpiphanyMusic.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class concert : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Concert",
                c => new
                    {
                        ConcertId = c.Int(nullable: false, identity: true),
                        Artist = c.String(),
                        Location = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ConcertId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Concert");
        }
    }
}
