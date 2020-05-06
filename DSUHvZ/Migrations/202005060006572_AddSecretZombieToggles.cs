namespace DSUHvZ.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSecretZombieToggles : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "SecretZombiePref", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "IsSecretZombie", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "IsSecretZombie");
            DropColumn("dbo.AspNetUsers", "SecretZombiePref");
        }
    }
}
