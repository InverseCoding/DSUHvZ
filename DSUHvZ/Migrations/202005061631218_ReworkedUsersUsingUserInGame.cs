namespace DSUHvZ.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReworkedUsersUsingUserInGame : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserInGames",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.String(nullable: false, maxLength: 128),
                        GameID = c.Int(nullable: false),
                        SecretZombiePref = c.Boolean(nullable: false),
                        IsSecretZombie = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            DropColumn("dbo.AspNetUsers", "ActiveGameID");
            DropColumn("dbo.AspNetUsers", "SecretZombiePref");
            DropColumn("dbo.AspNetUsers", "IsSecretZombie");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "IsSecretZombie", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "SecretZombiePref", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "ActiveGameID", c => c.Int(nullable: false));
            DropTable("dbo.UserInGames");
        }
    }
}
