namespace DSUHvZ.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedMoreVarsToUserInGame : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserInGames", "Side", c => c.Int(nullable: false));
            AddColumn("dbo.UserInGames", "IsAdmin", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserInGames", "IsAdmin");
            DropColumn("dbo.UserInGames", "Side");
        }
    }
}
