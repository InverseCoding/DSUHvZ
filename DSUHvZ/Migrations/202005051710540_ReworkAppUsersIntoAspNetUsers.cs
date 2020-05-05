namespace DSUHvZ.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReworkAppUsersIntoAspNetUsers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "ActiveGameID", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUsers", "Game_ID", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "Game_ID");
            AddForeignKey("dbo.AspNetUsers", "Game_ID", "dbo.Games", "ID");
            DropTable("dbo.AppUsers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.AppUsers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AccountID = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        ActiveGameID = c.Int(),
                        Email = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.ID);
            
            DropForeignKey("dbo.AspNetUsers", "Game_ID", "dbo.Games");
            DropIndex("dbo.AspNetUsers", new[] { "Game_ID" });
            DropColumn("dbo.AspNetUsers", "Game_ID");
            DropColumn("dbo.AspNetUsers", "ActiveGameID");
        }
    }
}
