namespace EpiphanyMusic.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addYoutubelink : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.PlayList");
            AddColumn("dbo.PlayList", "PlayListId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.PlayList", "Genre", c => c.String(nullable: false));
            AddColumn("dbo.PlayList", "Youtube", c => c.String());
            AlterColumn("dbo.PlayList", "Artist", c => c.String(nullable: false));
            AddPrimaryKey("dbo.PlayList", "PlayListId");
            DropColumn("dbo.PlayList", "Genere");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PlayList", "Genere", c => c.String(nullable: false));
            DropPrimaryKey("dbo.PlayList");
            AlterColumn("dbo.PlayList", "Artist", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.PlayList", "Youtube");
            DropColumn("dbo.PlayList", "Genre");
            DropColumn("dbo.PlayList", "PlayListId");
            AddPrimaryKey("dbo.PlayList", "Artist");
        }
    }
}
