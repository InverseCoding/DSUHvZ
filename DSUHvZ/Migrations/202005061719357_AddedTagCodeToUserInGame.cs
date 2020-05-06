namespace DSUHvZ.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTagCodeToUserInGame : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserInGames", "TagCode", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserInGames", "TagCode");
        }
    }
}
