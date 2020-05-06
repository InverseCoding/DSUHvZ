namespace DSUHvZ.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedGamePlayersListInClass : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "Game_ID", "dbo.Games");
            DropIndex("dbo.AspNetUsers", new[] { "Game_ID" });
            DropColumn("dbo.AspNetUsers", "Game_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Game_ID", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "Game_ID");
            AddForeignKey("dbo.AspNetUsers", "Game_ID", "dbo.Games", "ID");
        }
    }
}
